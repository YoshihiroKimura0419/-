Public Class FormDispProjector
    Public PictBoxList As New List(Of List(Of PictureBox))

    Public PrjSetting As ProjectorSetting
    Public PicBoxSize As Size
    Public TickPictboxIndex As Integer
    Private NaviBoardCount As Integer = 0
    Public Sub New(ByVal pjSetting As ProjectorSetting)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        PrjSetting = pjSetting
        NaviBoardCount = PrjSetting.MaxBoroadNum
    End Sub
    Private Sub FormDispProjector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = PrjSetting.FormSize
        Me.Top = PrjSetting.Posi.Y
        Me.Left = PrjSetting.Posi.X

        CreateNaviPictureBox(PrjSetting)
        TickPictboxIndex = -1
        TimerTick.Enabled = False
    End Sub
    Private Sub CreateNaviPictureBox(ByVal pjSetting As ProjectorSetting)
        Dim picSize As Size = GetPicBoxSize(pjSetting)
        Dim picLeft As Integer = 0
        Dim itemNum As Integer = System.Enum.GetNames(GetType(PictboxItem)).Length
        Dim pitch As Integer = CInt(pjSetting.FormSize.Width / pjSetting.MaxBoroadNum)

        For i As Integer = 0 To pjSetting.MaxBoroadNum - 1
            Dim partsPictBoxs As New List(Of PictureBox)
            For item As Integer = 0 To itemNum - 1
                Dim pictbox As New PictureBox
                pictbox.Size = picSize
                partsPictBoxs.Add(pictbox)
            Next
            SetPictureBoxParent(partsPictBoxs(PictboxItem.AllParts), partsPictBoxs(PictboxItem.SelParts))
            PictBoxList.Add(partsPictBoxs)
            PictBoxList(i)(PictboxItem.AllParts).Left = picLeft

            picLeft += pitch
        Next
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pjSetting"></param>
    ''' <returns></returns>
    Private Function GetPicBoxSize(ByVal pjSetting As ProjectorSetting) As Size
        Dim picSize As New Size


        Dim monitorDotPerMilliW As Double = pjSetting.FormSize.Width / pjSetting.ProjectionWidth
        Dim monitorDotPerMilliH As Double = pjSetting.FormSize.Height / pjSetting.ProjectionHeight
        picSize.Width = CInt(pjSetting.BoardWidth * monitorDotPerMilliW)
        picSize.Height = CInt(pjSetting.BoardHeight * monitorDotPerMilliH)

        Return picSize

    End Function
    Public Function GetNowDispRatio() As Double

        Dim dispRatio As Double

        Dim canvasMillimeterWidth As Double
        Dim canvasMillimeterHeight As Double
        Dim canvas As New Bitmap(PictBoxList(0)(PictboxItem.AllParts).Width, PictBoxList(0)(PictboxItem.AllParts).Height)
        Dim g As Graphics = Graphics.FromImage(canvas)

        canvasMillimeterWidth = canvas.Width / g.DpiX * ConvetInchiToMillimeter
        canvasMillimeterHeight = canvas.Height / g.DpiY * ConvetInchiToMillimeter

        dispRatio = canvasMillimeterWidth / PrjSetting.BoardWidth

        Return dispRatio

    End Function
    ''' <summary>
    ''' 部品表示用ピクチャーボックスのペアレント設定
    ''' </summary>
    ''' <param name="allPartsPicbox">
    ''' 全部品表示表ピクチャーボックス
    ''' </param>
    ''' <param name="selectePartsPicbox">
    ''' 選択部品用ピクチャーボックス
    ''' </param>
    Private Sub SetPictureBoxParent(ByRef allPartsPicbox As PictureBox, ByRef selectePartsPicbox As PictureBox)
        With allPartsPicbox
            .Parent = Me
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Normal
            .Top = CInt((Me.Height - .Height) / 2)
            .Left = 0
            Me.Controls.Add(allPartsPicbox)
        End With
        With selectePartsPicbox
            .Parent = allPartsPicbox
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Normal
            .Top = 0
            .Left = 0
            allPartsPicbox.Controls.Add(selectePartsPicbox)
        End With

    End Sub
    Public Sub ChangeTick(ByVal isTickStart As Boolean)
        TimerTick.Enabled = isTickStart
    End Sub
    Public Sub ChangeNaviBoard(ByVal boardIndex As Integer)
        'If PictBoxList.Count < boardIndex Then
        '    MessageBox.Show("インデックスが範囲外です。", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If NaviBoardCount - 1 < boardIndex Then
            MessageBox.Show("インデックスが範囲外です。", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        TickPictboxIndex = boardIndex
    End Sub
    Private Sub TimerTick_Tick(sender As Object, e As EventArgs) Handles TimerTick.Tick
        For i As Integer = 0 To PrjSetting.MaxBoroadNum - 1
            If i < NaviBoardCount Then
                If i = TickPictboxIndex Then
                    PictBoxList(i)(PictboxItem.SelParts).Visible = Not PictBoxList(i)(PictboxItem.SelParts).Visible
                Else
                    PictBoxList(i)(PictboxItem.SelParts).Visible = True
                End If
            Else
                PictBoxList(i)(PictboxItem.SelParts).Visible = False
                PictBoxList(i)(PictboxItem.AllParts).Visible = False
            End If
        Next
    End Sub
    Public Function SetNaviBoardCount(ByVal naviCount As Integer) As Boolean
        If naviCount < 1 Then
            Return False
        End If
        If PrjSetting.MaxBoroadNum < naviCount Then
            Return False
        End If
        NaviBoardCount = naviCount
        Return True
    End Function
End Class