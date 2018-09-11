Public Class FormBoardSerialInput
    Public SerialList As New List(Of String)
    Private Const ErrorExistSerialMessage As String = "のシリアルNoは、登録済みです。"
    Private Const ErrorSerialMessage As String = "は、シリアルNoではありません。"
    Private Const StartWorkMessage As String = "OKまたはEnterキーを押してください。"
    Private Const ErrorSerialCount As String = "シリアルNoの数量が不足しています。"

    Private LotCount As Integer


    Public Sub New(ByVal lot As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        LotCount = lot

    End Sub
    Private Sub FormBoardSerialInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBoxSerial.Items.Clear()
        LabelMessage.Text = ""
    End Sub

    Private Sub FormBoardSerialInput_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        ActiveControl = TextBoxInputSerial

    End Sub

    Private Function IsOkSerialNumber(ByRef serial As String) As Boolean

        serial = ConvetStrUpperNarrow(serial)
        'とりあえずシリアルNoの書式がわかるまで５文字以下を除外する。
        '書式が判明した時点で、判別ロジックを追加の事！！
        If serial.Length < 5 Then
            Return False
        End If
        Return True
    End Function

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If ListBoxSerial.Items.Count <> LotCount Then
            LabelMessage.Text = ErrorSerialCount
            ActiveControl = TextBoxInputSerial
            Exit Sub
        End If
        For Each str As String In ListBoxSerial.Items
            SerialList.Add(str)
        Next
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBoxInputSerial_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxInputSerial.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBoxInputSerial.Text.Length = 0 Then
                LabelMessage.Text = "シリアルNoが入力されていません。"
                ActiveControl = TextBoxInputSerial
                Exit Sub
            End If
            Dim serial As String = TextBoxInputSerial.Text
            If IsOkSerialNumber(serial) = True Then
                Dim index As Integer
                index = ListBoxSerial.FindStringExact(serial)
                If index < 0 Then
                    ListBoxSerial.Items.Add(serial)
                    TextBoxInputSerial.Text = ""
                    LabelMessage.Text = ""
                    If ListBoxSerial.Items.Count = LotCount Then
                        LabelMessage.Text = StartWorkMessage
                        ActiveControl = ButtonOK
                    End If
                Else
                    LabelMessage.Text = serial & ErrorExistSerialMessage
                    ActiveControl = TextBoxInputSerial
                End If
            Else
                LabelMessage.Text = serial & ErrorSerialMessage
                ActiveControl = TextBoxInputSerial
            End If
        End If
    End Sub
End Class