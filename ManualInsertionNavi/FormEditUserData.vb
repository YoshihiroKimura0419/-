Public Class FormEditUserData
    '新規ユーザーデータ作成フラグ
    Private IsNewData As Boolean

    '追加/更新するユーザーのマンナンバー
    Private EditUserManNumber As String
    'ユーザー管理テーブル
    Private TableUser As New DataTable
    'ユーザーアクセス権管理テーブル
    Private TableAccess As New DataTable
    '技術レベル管理テーブル
    Private TableTechnic As New DataTable
    '技術レベルマスタ管理テーブル
    Private TabaleTechincMaster As New DataTable

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    'ユーザーデータ管理テーブル操作用
    Private CtrlDbNaviMaster As ControlDbMaster
    'ＤＢ定義
    Private DefMasterDb As DefineMasterDb = New DefineMasterDb

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="userManNumber"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal isNew As Boolean, ByVal userManNumber As String, ByVal ctrlDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        IsNewData = isNew
        EditUserManNumber = userManNumber
        If IsNewData = False Then
            ButtonRegistData.Text = "更新"
        Else
            ButtonRegistData.Text = "登録"
        End If
        CtrlDbNaviMaster = ctrlDb.Clone
        DefMasterDb = ctrlDb.DefMstDb.Clone
    End Sub
    ''' <summary>
    ''' フォーム読み込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormEditUserData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        '各種テーブルデータの取得
        TabaleTechincMaster = CtrlDbNaviMaster.GetTechnicTableMaster()
        TableUser = CtrlDbNaviMaster.GetUserTable(EditUserManNumber)
        TableTechnic = CtrlDbNaviMaster.GetTechnicTable(EditUserManNumber)
        TableAccess = CtrlDbNaviMaster.GetAccessRightTable(EditUserManNumber)

        'ComboBoxDataEnableのDataSource設定
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbNaviMaster.GetEnableTable("利用中", "利用停止")
        ComboBoxDataEnable.DataSource = dataEnableTable
        ComboBoxDataEnable.DisplayMember = "Display"
        ComboBoxDataEnable.ValueMember = "Value"

        'ComboBoxTechnicLevelのDataSource設定
        ComboBoxTechnicLevel.DataSource = TabaleTechincMaster
        ComboBoxTechnicLevel.DisplayMember = TLTColumnName(TLTColumn.TechnicLevelName)
        ComboBoxTechnicLevel.ValueMember = TLTColumnName(TLTColumn.ID)


        If IsNewData = True Then
            SetNewUserData2Table(SysLoginUserInfo.ManNumber)
            TextBoxManNumber.ReadOnly = False
        Else
            TableUser.Rows(0)(UDTColumnName(UDTColumn.UpdateManNumber)) = SysLoginUserInfo.ManNumber
            TableAccess.Rows(0)(ARTColumnName(ARTColumn.UpdateManNumber)) = SysLoginUserInfo.ManNumber
            TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.UpdateManNumber)) = SysLoginUserInfo.ManNumber
            TextBoxManNumber.ReadOnly = True
        End If

        TextBoxRegistrationDate.ReadOnly = False
        TextBoxRegistrationUser.ReadOnly = False

        TextBoxUpdateDate.ReadOnly = False
        TextBoxUpdateUser.ReadOnly = False
        TextBoxTechnicLevelName.ReadOnly = True

        TextBoxManNumber.Text = CtrlDbNaviMaster.GetRowColmunContentString(TableUser.Rows(0), UDTColumnName(UDTColumn.ManNumber))
        TextBoxUserName.Text = CtrlDbNaviMaster.GetRowColmunContentString(TableUser.Rows(0), UDTColumnName(UDTColumn.UserName))
        TextBoxRegistrationDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TableUser.Rows(0), UDTColumnName(UDTColumn.RegistDate))
        TextBoxUpdateDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TableUser.Rows(0), UDTColumnName(UDTColumn.UpdateDate))

        TextBoxRegistrationUser.Text = CtrlDbNaviMaster.GetRegisterName(TableUser.Rows(0), UDTColumnName(UDTColumn.RegistManNumber))
        TextBoxUpdateUser.Text = CtrlDbNaviMaster.GetRegisterName(TableUser.Rows(0), UDTColumnName(UDTColumn.UpdateManNumber))

        'アクセスレベルチェックボックス設定
        CheckBoxFormNavi.Checked = TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowNavi))
        CheckBoxMasterMente.Checked = TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowMasterMente))
        CheckBoxSystemSetting.Checked = TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowSystemSetting))
        CheckBoxOrderMente.Checked = TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowOrderMente))
        ComboBoxDataEnable.SelectedValue = TableUser.Rows(0)(UDTColumnName(UDTColumn.DataEnable))
        ComboBoxTechnicLevel.SelectedValue = TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.TechnicLevelId))


        Dim id As Integer = ComboBoxTechnicLevel.SelectedValue
        SetTechnicLevelName(id)

        TableUser.AcceptChanges()
        TableAccess.AcceptChanges()
        TableTechnic.AcceptChanges()

        NowInitializing = False

    End Sub
    ''' <summary>
    ''' 技術レベル名テキストボックス設定処理
    ''' </summary>
    ''' <param name="id">
    ''' 技術レベル階級コンボボックスの選択ID
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetTechnicLevelName(ByVal id As Integer)
        Dim dv As New DataView(TabaleTechincMaster)
        dv.RowFilter = "ID=" & id
        Dim tb As New DataTable
        tb = dv.ToTable
        If tb.Rows.Count = 1 Then
            TextBoxTechnicLevelName.Text = tb.Rows(0)(TLTColumnName(TLTColumn.TechnicLevelName))
            TextBoxTechnicLevelName.BackColor = Color.White
        Else
            TextBoxTechnicLevelName.Text = "技術レベル名がありません"
            TextBoxTechnicLevelName.BackColor = Color.Red
        End If
    End Sub

    ''' <summary>
    ''' 新規ユーザー登録時の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewUserData2Table(ByVal registerManNumber As String)

        'ユーザー管理設定
        TableUser.Rows.Add()
        TableUser.Rows(0)(UDTColumnName(UDTColumn.ManNumber)) = Nothing
        TableUser.Rows(0)(UDTColumnName(UDTColumn.DataEnable)) = True
        TableUser.Rows(0)(UDTColumnName(UDTColumn.UserName)) = ""
        TableUser.Rows(0)(UDTColumnName(UDTColumn.RegistDate)) = DBNull.Value
        TableUser.Rows(0)(UDTColumnName(UDTColumn.RegistManNumber)) = registerManNumber
        TableUser.Rows(0)(UDTColumnName(UDTColumn.UpdateDate)) = DBNull.Value
        TableUser.Rows(0)(UDTColumnName(UDTColumn.UpdateManNumber)) = Nothing
        TableUser.AcceptChanges()

        'アクセス権管理設定
        TableAccess.Rows.Add()
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.ManNumber)) = ""
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowNavi)) = True
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowMasterMente)) = False
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowSystemSetting)) = False
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowOrderMente)) = False
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.RegistDate)) = DBNull.Value
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.RegistManNumber)) = registerManNumber
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.UpdateDate)) = DBNull.Value
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.UpdateManNumber)) = Nothing
        TableAccess.AcceptChanges()

        'ユーザー技術レベル管理設定
        TableTechnic.Rows.Add()
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.ManNumber)) = Nothing
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.TechnicLevelId)) = TabaleTechincMaster.Rows(0)(TLTColumnName(TLTColumn.ID))
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.RegistDate)) = DBNull.Value
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.RegistManNumber)) = registerManNumber
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.UpdateDate)) = DBNull.Value
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.UpdateManNumber)) = Nothing
        TableTechnic.AcceptChanges()


    End Sub

    ''' <summary>
    ''' データ有効コンボボックスSelectedValueChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxDataEnable_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDataEnable.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableUser.Rows(0)(UDTColumnName(UDTColumn.DataEnable)) = ComboBoxDataEnable.SelectedValue
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 技術レベルコンボボックスSelectedValueChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxTechnicLevel_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTechnicLevel.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.TechnicLevelId)) = ComboBoxTechnicLevel.SelectedValue
        SetTechnicLevelName(ComboBoxTechnicLevel.SelectedValue)
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' なび画面チェックボックスCheckedChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBoxFormNavi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFormNavi.CheckedChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowNavi)) = CheckBoxFormNavi.Checked
        IsStartEdit = True
    End Sub
    ''' <summary>
    ''' マスターメンテナンスチェックボックスCheckedChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBoxMasterMente_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMasterMente.CheckedChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowMasterMente)) = CheckBoxMasterMente.Checked
        IsStartEdit = True

    End Sub

    ''' <summary>
    ''' システム設定チェックボックスCheckedChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBoxSystemSetting_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSystemSetting.CheckedChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowSystemSetting)) = CheckBoxSystemSetting.Checked
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' オーダー管理チェックボックスCheckedChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CheckBoxOrderMente_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOrderMente.CheckedChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TableAccess.Rows(0)(ARTColumnName(ARTColumn.WindowOrderMente)) = CheckBoxOrderMente.Checked
        IsStartEdit = True
    End Sub

    ''' <summary>
    ''' 登録/更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        If IsNewData = True Then
            If IsExistModifedUserData() = False Then
                MessageBox.Show("登録するデータ入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If (TextBoxManNumber.Text IsNot Nothing) AndAlso (TextBoxManNumber.Text <> "") Then
                If TextBoxManNumber.Text.Length < 7 Then
                    MessageBox.Show("マンナンバーは英数字7～10文字内で入力して下さい。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim existUserName As String = Nothing
                If CtrlDbNaviMaster.IsExistInputManNumber(TextBoxManNumber.Text, existUserName) = True Then
                    MessageBox.Show("入力されたマンナンバーは" & existUserName & "さんが既に使用しています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                MessageBox.Show("マンナンバーが入力されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If TextBoxUserName.Text = "" Then
                MessageBox.Show("氏名が入力されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TableUser.Rows(0)(UDTColumnName(UDTColumn.RegistDate)) = dt
            TableAccess.Rows(0)(ARTColumnName(ARTColumn.RegistDate)) = dt
            TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.RegistDate)) = dt

            'DBへユーザーデータ挿入
            If InsertUserData2DB() = True Then
                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            If IsExistModifedUserData() = False Then
                MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TableUser.Rows(0)(UDTColumnName(UDTColumn.UpdateDate)) = dt
            TableAccess.Rows(0)(ARTColumnName(ARTColumn.UpdateDate)) = dt
            TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.UpdateDate)) = dt
            'DBへユーザーデータ更新
            If UpdateUserData2DB() = True Then
                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    ''' <summary>
    ''' マンナンバーテキストボックスLeave処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxManNumber_Leave(sender As Object, e As EventArgs) Handles TextBoxManNumber.Leave
        If NowInitializing = True Then
            Exit Sub
        End If
        If IsNewData = False Then
            Exit Sub
        End If

        Dim r As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$")

        If r.IsMatch(TextBoxManNumber.Text) = False Then
            MessageBox.Show("マンナンバーは、半角英数字のみで入力して下さい", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim txtLen As Integer = TextBoxManNumber.Text.Length
        If (txtLen < 7) Or (10 < txtLen) Then
            MessageBox.Show("マンナンバーは英数字7～10文字内で入力して下さい。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ActiveControl = TextBoxManNumber
        Else
            TextBoxManNumber.Text = TextBoxManNumber.Text.ToUpper

            'ユーザー管理設定
            TableUser.Rows(0)(UDTColumnName(UDTColumn.ManNumber)) = TextBoxManNumber.Text
            'アクセス権管理設定
            TableAccess.Rows(0)(ARTColumnName(ARTColumn.ManNumber)) = TextBoxManNumber.Text
            'ユーザー技術レベル管理設定
            TableTechnic.Rows(0)(UTLTColumnName(UTLTColumn.ManNumber)) = TextBoxManNumber.Text

        End If

    End Sub
    ''' <summary>
    ''' ユーザー名テキストボックスLeave処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxUserName_Leave(sender As Object, e As EventArgs) Handles TextBoxUserName.Leave
        If NowInitializing = True Then
            Exit Sub
        End If
        TableUser.Rows(0)(UDTColumnName(UDTColumn.UserName)) = TextBoxUserName.Text
    End Sub
    ''' <summary>
    ''' ユーザーデータ更新有無情報を取得する。
    ''' </summary>
    ''' <returns>
    ''' True:更新有　False:更新なし
    ''' </returns>
    ''' <remarks></remarks>
    Private Function IsExistModifedUserData() As Boolean
        If IsStartEdit = True Then
            Return True
        End If
        For Each row As DataRow In TableUser.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next

        For Each row As DataRow In TableAccess.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next

        For Each row As DataRow In TableTechnic.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next

        Return False
    End Function
    ''' <summary>
    ''' FormClosing処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormEditUserData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsExistModifedUserData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' マンナンバーテキストボックス変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxManNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxManNumber.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If

        IsStartEdit = True
    End Sub
    ''' <summary>
    ''' ユーザー名テキストボックス変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxUserName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUserName.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If

        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' キャンセルボタン押下処理。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' キャンセルボタン押下時、編集データがある場合は、キャンセルするか確認のダイアログを表示する。
    ''' ここで、「はい」を押した場合に、再度確認のダイアログが表示されない様にするため、
    ''' 各テーブルの内容を確定(AcceptChanges)し、IsStartEditフラグをFalseにしている
    ''' </remarks>
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        If IsExistModifedUserData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                TableUser.AcceptChanges()
                TableTechnic.AcceptChanges()
                TableAccess.AcceptChanges()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    ''' <summary>
    ''' ユーザーデータをユーザー管理テーブルに挿入する
    ''' </summary>
    ''' <returns>
    ''' True:挿入成功
    ''' False:挿入失敗
    ''' </returns>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Private Function InsertUserData2DB() As Boolean
        Dim isCompleteUpdate As Boolean = False
        '接続文字列取得
        Dim connect_txt As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        'マスターDBパス取得
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()

        Dim oleCon As New System.Data.OleDb.OleDbConnection(connect_txt)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction
        Dim sqlUserTableString As String = ""
        Dim sqlTechnicTableString As String = ""
        Dim sqlAccessTableString As String = ""

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            'ユーザー管理テーブル
            sqlUserTableString = CtrlDbNaviMaster.GetInsertSqlString(DefMasterDb.TableUser, TableUser.Rows(0), Nothing)
            sqlCmd.CommandText = sqlUserTableString
            sqlCmd.ExecuteNonQuery() '実行

            'ユーザー技術レベル管理テーブル
            sqlTechnicTableString = CtrlDbNaviMaster.GetInsertSqlString(DefMasterDb.TableUserTechnicLevel, TableTechnic.Rows(0), Nothing)
            sqlCmd.CommandText = sqlTechnicTableString
            sqlCmd.ExecuteNonQuery() '実行
            'アクセス権管理テーブル
            sqlAccessTableString = CtrlDbNaviMaster.GetInsertSqlString(DefMasterDb.TableUserAccessRight, TableAccess.Rows(0), Nothing)
            sqlCmd.CommandText = sqlAccessTableString
            sqlCmd.ExecuteNonQuery() '実行

            isCompleteUpdate = True
            trz.Commit() 'コミット（確定）
            TableUser.AcceptChanges()
            TableTechnic.AcceptChanges()
            TableAccess.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(sqlCmd.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            trz.Rollback() 'ロールバック
            isCompleteUpdate = False
        Finally
            oleCon.Close() 'DB切断
        End Try

        sqlCmd.Dispose()
        oleCon.Dispose()
        Return isCompleteUpdate
    End Function
    ''' <summary>
    ''' ユーザーデータをユーザー管理テーブルに挿入する
    ''' </summary>
    ''' <returns>
    ''' True:挿入成功
    ''' False:挿入失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function UpdateUserData2DB() As Boolean
        Dim isCompleteUpdate As Boolean = False
        '接続文字列取得
        Dim connect_txt As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        'マスターDBパス取得
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()

        Dim oleCon As New System.Data.OleDb.OleDbConnection(connect_txt)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction
        Dim sqlUserTableString As String = ""
        Dim sqlTechnicTableString As String = ""
        Dim sqlAccessTableString As String = ""

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            'ユーザー管理テーブル
            sqlUserTableString = CtrlDbNaviMaster.GetModifiedSqlString(DefMasterDb.TableUser, TableUser.Rows(0), "マンナンバー")
            sqlCmd.CommandText = sqlUserTableString
            sqlCmd.ExecuteNonQuery() '実行

            'ユーザー技術レベル管理テーブル
            sqlTechnicTableString = CtrlDbNaviMaster.GetModifiedSqlString(DefMasterDb.TableUserTechnicLevel, TableTechnic.Rows(0), "マンナンバー")
            sqlCmd.CommandText = sqlTechnicTableString
            sqlCmd.ExecuteNonQuery() '実行
            'アクセス権管理テーブル
            sqlAccessTableString = CtrlDbNaviMaster.GetModifiedSqlString(DefMasterDb.TableUserAccessRight, TableAccess.Rows(0), "マンナンバー")
            sqlCmd.CommandText = sqlAccessTableString
            sqlCmd.ExecuteNonQuery() '実行

            isCompleteUpdate = True
            trz.Commit() 'コミット（確定）
            TableUser.AcceptChanges()
            TableTechnic.AcceptChanges()
            TableAccess.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(sqlCmd.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            trz.Rollback() 'ロールバック
            isCompleteUpdate = False
        Finally
            oleCon.Close() 'DB切断
        End Try

        sqlCmd.Dispose()
        oleCon.Dispose()
        Return isCompleteUpdate
    End Function

End Class