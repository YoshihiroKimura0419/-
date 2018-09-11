Public Class FormLogin
    'ユーザー情報構造体定義
    Public LoginUser As LoginUserInfo

    'マスターデータ操作用
    Private CtrlDbMaster As ControlDbMaster
    'ＤＢ定義
    Private DefMasterDb As DefineMasterDb

    Public Sub New(ByVal logUserInfo As LoginUserInfo, ByVal mstCtrlDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        LoginUser = logUserInfo
        CtrlDbMaster = mstCtrlDb.Clone
        DefMasterDb = mstCtrlDb.DefMstDb.Clone
    End Sub

    ''' <summary>
    ''' TextBox1キー押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxLoginId.KeyDown
        Dim check_result As Boolean
        If (e.KeyCode = Keys.Enter) Then

            Dim mess As String = ""
            check_result = LoginSystemUser(TextBoxLoginId.Text, mess)
            'ユーザー情報取得
            If check_result = True Then

                If GetUserInfo(LoginUser, mess, DefMasterDb.EnableConnectPassword) = True Then
                    mess = ""
                Else

                End If
            Else

            End If

            TextBoxLoginId.Text = ""
            LabelMessage.Text = mess
            If check_result = True Then Me.Close()
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LabelMessage.Text = ""
    End Sub

    Private Sub FormLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    ''' -----------------------------------------------------------------------------------
    ''' <summary>
    ''' ユーザーログインチェック。ログインOK時は、UserInfo構造体(Public変数)にManNumber、UserNameを設定する。
    ''' </summary>
    ''' <param name="manNumber">
    ''' ログインしようとしているユーザーのID
    ''' </param>
    ''' <param name="messString">
    ''' ログイン時のエラーメッセージ格納用文字列
    ''' </param>
    ''' <returns>
    ''' True:ログインOK,False:ログインNG
    ''' </returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------------
    Public Function LoginSystemUser(ByVal manNumber As String, ByRef messString As String) As Boolean

        Dim connect_txt As String = CtrlDbMaster.GetMasterDbConnectString

        Dim canLogin As Boolean = False

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(CtrlDbMaster.DefMstDb.TableUser)
        sbSql.AppendLine(" where")
        sbSql.AppendLine(String.Format("{0}='{1}'", UDTColumnName(UDTColumn.ManNumber), manNumber))

        'データの読み込み
        Dim tb As New DataTable()
        tb = CtrlDbMaster.GetTableData(sbSql.ToString, connect_txt)

        If tb.Rows.Count = 1 Then
            LoginUser.ManNumber = tb.Rows(0)(UDTColumnName(UDTColumn.ManNumber))
            LoginUser.UserName = tb.Rows(0)(UDTColumnName(UDTColumn.UserName))
            messString = ""
            canLogin = True
        Else
            messString = "入力されたマンナンバーは登録されていません。"
            canLogin = False
        End If

        '後処理
        tb.Dispose()
        Return canLogin
    End Function
    ''' <summary>
    ''' uInfoの構造体に格納されたメンバManNumberの技術レベル・アクセス権を取得する処理メイン
    ''' </summary>
    ''' <param name="uinfo">
    ''' UserInfo構造体
    ''' </param>
    ''' <param name="messString">
    ''' メッセージ格納文字列
    ''' </param>
    ''' <param name="isUseConnectPass">
    ''' DB接続パスワードフラグ
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetUserInfo(ByRef uinfo As LoginUserInfo, ByRef messString As String,
                                       ByVal isUseConnectPass As Boolean) As Boolean
        Dim hasGotUserInfo As Boolean = False

        'ユーザー技術レベル取得
        If GetUserTechnicLevel(uinfo, messString, DefMasterDb.EnableConnectPassword) = True Then
            messString = ""
        Else

        End If

        'ユーザーアクセス権取得
        If GetUserAccessRight(uinfo, messString) = True Then
        Else

        End If
        If messString <> "" Then
            messString &= vbCrLf & "システム管理者に設定を依頼してください。" & vbCrLf
            MessageBox.Show(messString, "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        messString = ""
        hasGotUserInfo = True

        Return hasGotUserInfo
    End Function
    ''' <summary>
    ''' uInfoの構造体に格納されたメンバManNumberの技術レベルを取得する。
    ''' </summary>
    ''' <param name="uInfo">
    ''' UserInfo構造体
    ''' </param>
    ''' <param name="messString">
    ''' メッセージ格納文字列
    ''' </param>
    ''' <param name="isUseConnectPass">
    ''' DB接続パスワードフラグ
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetUserTechnicLevel(ByRef uInfo As LoginUserInfo, ByRef messString As String,
                                       ByVal isUseConnectPass As Boolean) As Boolean
        Dim hasGotUserLevel As Boolean = False
        Dim connect_txt As String
        Dim dbnameA As String

        If messString <> "" Then
            messString &= vbCrLf
        End If

        dbnameA = CtrlDbMaster.GetMasterDbPathString
        connect_txt = CtrlDbMaster.GetMasterDbConnectString

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("a.マンナンバー as マンナンバー")
        sbSql.AppendLine(",b.技術レベル名 as 技術レベル名")
        sbSql.AppendLine(",b.技術レベル階級 as 技術レベル階級")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine("(")
        sbSql.AppendLine(dbnameA & ".[" & DefMasterDb.TableUserTechnicLevel & "] as a")
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbnameA & ".[" & DefMasterDb.TableTechnicLevelMaster & "] as b")
        sbSql.AppendLine(" ON (a.技術レベルマスタID=b.ID)")
        sbSql.AppendLine(")")

        sbSql.AppendLine(" where a.マンナンバー='" & uInfo.ManNumber & "'")


        'データアダプターを生成
        Dim oleAdapter As New System.Data.OleDb.OleDbDataAdapter(sbSql.ToString, connect_txt)

        'データの読み込み
        Dim tb As New DataTable()
        Try
            oleAdapter.Fill(tb)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim dataCount As Integer

        dataCount = tb.Rows.Count
        If dataCount = 1 Then

            '以下別途取得の必要有
            uInfo.TechnicLevelName = tb.Rows(0)("技術レベル名")
            uInfo.TechnicLevel = tb.Rows(0)("技術レベル階級")
            hasGotUserLevel = True
        Else
            uInfo.TechnicLevelName = Nothing
            uInfo.TechnicLevel = 0
            messString &= "入力されたマンナンバーの技術レベルは登録されていません。"
            hasGotUserLevel = False
        End If
        '後処理
        tb.Dispose()
        oleAdapter.Dispose()
        Return hasGotUserLevel
    End Function
    ''' <summary>
    ''' uInfoの構造体に格納されたメンバManNumberのアクセス権を取得する。
    ''' </summary>
    ''' <param name="uInfo">
    ''' UserInfo構造体
    ''' </param>
    ''' <param name="messString">
    ''' メッセージ格納文字列
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetUserAccessRight(ByRef uInfo As LoginUserInfo, ByRef messString As String) As Boolean
        Dim hasGotAccessRight As Boolean = False

        If messString <> "" Then
            messString &= vbCrLf
        End If

        '接続文字列作成
        Dim connect_txt As String = CtrlDbMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDbMaster.GetMasterDbPathString()


        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(dbnameA & ".[" & DefMasterDb.TableUserAccessRight & "]")
        sbSql.AppendLine(" where")
        sbSql.AppendLine(String.Format("{0}='{1}'", ARTColumnName(ARTColumn.ManNumber), uInfo.ManNumber))


        'データアダプターを生成
        Dim oleAdapter As New System.Data.OleDb.OleDbDataAdapter(sbSql.ToString, connect_txt)

        'データの読み込み
        Dim tb As New DataTable()
        Try
            oleAdapter.Fill(tb)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim dataCount As Integer

        dataCount = tb.Rows.Count
        If dataCount = 1 Then
            uInfo.EnableAccessForm.EnableFormNavi = tb.Rows(0)(ARTColumnName(ARTColumn.WindowNavi))
            uInfo.EnableAccessForm.EnableFormMentenanceMenu = tb.Rows(0)(ARTColumnName(ARTColumn.WindowMasterMente))
            uInfo.EnableAccessForm.EnableFormSystemSetting = tb.Rows(0)(ARTColumnName(ARTColumn.WindowSystemSetting))
            uInfo.EnableAccessForm.EnableFormOrderMente = tb.Rows(0)(ARTColumnName(ARTColumn.WindowOrderMente))
            hasGotAccessRight = True
        Else
            uInfo.EnableAccessForm.EnableFormNavi = True
            uInfo.EnableAccessForm.EnableFormMentenanceMenu = False
            uInfo.EnableAccessForm.EnableFormSystemSetting = False
            uInfo.EnableAccessForm.EnableFormOrderMente = False
            messString &= "入力されたマンナンバーのアクセス権は登録されていません。"
            hasGotAccessRight = False
        End If

        '後処理
        tb.Dispose()
        oleAdapter.Dispose()
        Return hasGotAccessRight
    End Function

End Class