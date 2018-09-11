Public Class FormMenuMain
    Private VersionUpFlag As Boolean = False

    Private Sub FormMenuMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PartsInsertNaviAppConfigData.ApplicationExcecutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        Dim controlSetting As CotrolSettingCsv = New CotrolSettingCsv
        'Setting.csvファイル読み込み
        If controlSetting.ReadFile(PartsInsertNaviAppConfigData, ControlMasterDb.DefMstDb) <> 0 Then

        End If
        'アプリケーション設定データのコピー
        PartsInsertNaviAppConfigData = controlSetting.AppConfigData.Clone
        ControlMasterDb.DefMstDb = controlSetting.DefMasterDb.Clone
        ControlPartsMasterDb.DefPtMstDb.DbPath = ControlMasterDb.DefMstDb.DbPath
        ControlDrawingMasterDb.DefMstDb.DbPath = ControlMasterDb.DefMstDb.DbPath
        'ControlOrderDb.DefOrdDb.DbPath = ControlMasterDb.DefMstDb.DbPath
        ControlOrderDb.SetDbPath(PartsInsertNaviAppConfigData.SystemDataPath.Root)

        LoginSystem()
        '自分自身のAssemblyを取得
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        'バージョンの取得
        Dim ver As System.Version = asm.GetName().Version

        ToolStripStatusLabel1.Text = "Name:" & SysLoginUserInfo.UserName & "  /  TechnicLevel:" & SysLoginUserInfo.TechnicLevel &
                                    "    System Version:" & ver.ToString


    End Sub
    Private Sub ButtonMasterMenteMasterMente_Click(sender As Object, e As EventArgs) Handles ButtonMasterMente.Click
        Me.Hide()

        Using fm As New FormMenuMasterMente
            fm.ShowDialog()
        End Using

        Me.Show()
    End Sub

    Private Sub ButtonSettingSystem_Click(sender As Object, e As EventArgs) Handles ButtonSettingSystem.Click

        Using fm As New FormSettingSystem(PartsInsertNaviAppConfigData, ControlMasterDb)
            Dim dResult As DialogResult = fm.ShowDialog()
            If dResult = Windows.Forms.DialogResult.OK Then
                PartsInsertNaviAppConfigData = fm.AppConfigData.Clone
                ControlMasterDb.DefMstDb = fm.CtrlDb.DefMstDb.Clone
            End If
        End Using

    End Sub

    Private Sub LoginSystem()

        Dim dresult As DialogResult = Nothing

        Using fm As New FormLogin(SysLoginUserInfo, ControlMasterDb)
            dresult = fm.ShowDialog()
            SysLoginUserInfo = fm.LoginUser
        End Using


        '自分自身のAssemblyを取得
        Dim asm As System.Reflection.Assembly = _
            System.Reflection.Assembly.GetExecutingAssembly()
        'バージョンの取得
        Dim ver As System.Version = asm.GetName().Version
        ToolStripStatusLabel1.Text = "LoginUser：" & SysLoginUserInfo.UserName & "  / " & "TechnicLevel：" & SysLoginUserInfo.TechnicLevel & _
                                     "    System Version:" & ver.ToString
        SetControlLevel(SysLoginUserInfo.EnableAccessForm)

        If dresult = Windows.Forms.DialogResult.OK Then
        End If

    End Sub
    Public Function funcCopyFile(ByVal sourcePath As String, ByVal targetPath As String) As Integer

        Try
            My.Computer.FileSystem.CopyFile(sourcePath, targetPath)
        Catch ex As System.IO.IOException
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' ログインユーザーのAccessForm構造体情報に合わせて各ボタンのEnableを設定する
    ''' </summary>
    ''' <param name="enableAccessForm"></param>
    ''' <remarks></remarks>
    Private Sub SetControlLevel(ByVal enableAccessForm As AccessForm)
        ButtonInsertNavi.Enabled = enableAccessForm.EnableFormNavi
        ButtonMasterMente.Enabled = enableAccessForm.EnableFormMentenanceMenu
        ButtonSettingSystem.Enabled = enableAccessForm.EnableFormSystemSetting
        ButtonOpenOrderMente.Enabled = enableAccessForm.EnableFormOrderMente
    End Sub

    Private Sub ButtonInsertNavi_Click(sender As Object, e As EventArgs) Handles ButtonInsertNavi.Click
        Me.Hide()
        Dim productInfo As New ProductionInfomation
        productInfo.Initialize()
        Dim dresult As DialogResult
        Using fl As New FormInputProductInfo(ControlMasterDb.DefMstDb.DbPath)
            dresult = fl.ShowDialog()
            If dresult = DialogResult.OK Then
                productInfo = fl.ProductInfo
                Using fen As New FormEditNavidata(ControlMasterDb, ControlDrawingMasterDb, productInfo, FormNaviMode.Navi)
                    fen.ShowDialog()
                End Using
            Else

            End If
        End Using

        Me.Show()
    End Sub


    Private Sub FormMenuMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If VersionUpFlag = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

        Using fl As New FormTestDraw
            fl.ShowDialog()
        End Using

        Me.Show()

    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        LoginSystem()
    End Sub

    Private Sub ButtonOpenOrderMente_Click(sender As Object, e As EventArgs) Handles ButtonOpenOrderMente.Click
        Me.Hide()

        Using fm As New FormMenteOrder(ControlMasterDb, ControlOrderDb)
            Dim dResult As DialogResult
            dResult = fm.ShowDialog()
        End Using

        Me.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fm As New FormBoardSerialInput(4)
        fm.ShowDialog()
        If fm IsNot Nothing Then
            fm.Dispose()
        End If
    End Sub

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    MyBase.OnPaint(e)

    '    'Penを用意する
    '    Dim redPen As New Pen(Color.Red, 5.0F)

    '    'インチ単位にする
    '    e.Graphics.PageUnit = GraphicsUnit.Millimeter
    '    e.Graphics.ScaleTransform(0.5F, 0.5F, MatrixOrder.Append)
    '    '太さ0.1インチで4X2インチの長方形を描画
    '    e.Graphics.DrawRectangle(redPen, 150.0F, 150.0F, 40, 30)

    '    'Penを破棄
    '    redPen.Dispose()
    'End Sub

End Class
