Public Class FormEditPartsCategory
    '新規データ作成フラグ
    Private IsNewData As Boolean

    '追加/更新する部品形状分類のID
    Private EdittingPartsCategoryId As String
    '部品形状分類マスタテーブル
    Private TablePartsCategory As New DataTable

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    'データ管理テーブル操作用
    Private CtrlDbNaviMaster As ControlDbMaster

    Private Const MaxCategoryTextLength As Integer = 30
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal isNew As Boolean, ByVal id As Integer, ByVal ctrlDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        IsNewData = isNew
        EdittingPartsCategoryId = id
        If IsNewData = False Then
            ButtonRegistData.Text = "更新"
        Else
            ButtonRegistData.Text = "登録"
        End If
        CtrlDbNaviMaster = ctrlDb.Clone
    End Sub
    ''' <summary>
    ''' FormEditPartsCategory読み込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' フォーム読み込み処理時は、NowInitializingをTrueにし、プロパティ変更等によるイベント発生を抑制する。
    ''' </remarks>
    Private Sub FormEditPartsCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        '各種テーブルデータの取得
        TablePartsCategory = CtrlDbNaviMaster.GetPartsCategoryOneDataFromTable(EdittingPartsCategoryId)

        'コントロール読取専用設定
        TextBoxId.ReadOnly = True
        TextBoxRegistrationDate.ReadOnly = True
        TextBoxRegistrationUser.ReadOnly = True

        TextBoxUpdateDate.ReadOnly = True
        TextBoxUpdateUser.ReadOnly = True

        If IsNewData = True Then
            SetNewPartsCategoryDataToTable(SysLoginUserInfo.ManNumber)
        Else
            TablePartsCategory.Rows(0)("更新者マンナンバー") = SysLoginUserInfo.ManNumber
        End If

        If EdittingPartsCategoryId = Nothing Then
            TextBoxId.Text = "新規"
        Else
            TextBoxId.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsCategory.Rows(0), "ID")
        End If

        'ComboBoxDataEnableのDataSource設定
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbNaviMaster.GetEnableTable("利用中", "利用停止")
        ComboBoxDataEnable.DataSource = dataEnableTable
        ComboBoxDataEnable.DisplayMember = "Display"
        ComboBoxDataEnable.ValueMember = "Value"
        ComboBoxDataEnable.SelectedValue = TablePartsCategory.Rows(0)("データ有効")
        TextBoxPartsCategoryName.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsCategory.Rows(0), "部品形状分類名称")
        TextBoxNote.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsCategory.Rows(0), "備考")

        TextBoxRegistrationDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsCategory.Rows(0), "登録日")
        TextBoxUpdateDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsCategory.Rows(0), "更新日")

        TextBoxRegistrationUser.Text = CtrlDbNaviMaster.GetRegisterName(TablePartsCategory.Rows(0), "登録者マンナンバー")
        TextBoxUpdateUser.Text = CtrlDbNaviMaster.GetRegisterName(TablePartsCategory.Rows(0), "更新者マンナンバー")



        TablePartsCategory.AcceptChanges()

        NowInitializing = False

    End Sub
    ''' <summary>
    ''' 新規ユーザー登録時の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewPartsCategoryDataToTable(ByVal registerManNumber As String)

        'ユーザー管理設定
        TablePartsCategory.Rows.Add()
        TablePartsCategory.Rows(0)("ID") = DBNull.Value
        TablePartsCategory.Rows(0)("データ有効") = True
        TablePartsCategory.Rows(0)("部品形状分類名称") = ""
        TablePartsCategory.Rows(0)("備考") = ""
        TablePartsCategory.Rows(0)("登録日") = DBNull.Value
        TablePartsCategory.Rows(0)("登録者マンナンバー") = registerManNumber
        TablePartsCategory.Rows(0)("更新日") = DBNull.Value
        TablePartsCategory.Rows(0)("更新者マンナンバー") = Nothing
        TablePartsCategory.AcceptChanges()

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
        TablePartsCategory.Rows(0)("データ有効") = ComboBoxDataEnable.SelectedValue
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 登録/更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim connectString As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()
        If IsNewData = True Then
            If IsExistModifiedData() = False Then
                MessageBox.Show("登録するデータが入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If (TextBoxPartsCategoryName.Text IsNot Nothing) AndAlso (TextBoxPartsCategoryName.Text <> "") Then
                If MaxCategoryTextLength <= TextBoxPartsCategoryName.Text.Length Then
                    MessageBox.Show("部品形状分類名称は、半角30文字(全角15文字)内で入力して下さい。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CtrlDbNaviMaster.IsExistPartsCategoryName(TextBoxPartsCategoryName.Text) = True Then
                    MessageBox.Show("部品形状分類名称は既に登録されています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                MessageBox.Show("部品形状分類名称が入力されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TablePartsCategory.Rows(0)("登録日") = dt

            'DBへユーザーデータ挿入

            Dim sqlUserTableString As String = Nothing
            sqlUserTableString = CtrlDbNaviMaster.GetInsertSqlString(CtrlDbNaviMaster.DefMstDb.TablePartsShapeCategory, TablePartsCategory.Rows(0), "ID")

            Dim insertResult As Boolean
            insertResult = CtrlDbNaviMaster.UpdateTableWithSQL(connectString, dbnameA, sqlUserTableString)
            If insertResult = True Then
                TablePartsCategory.AcceptChanges()
                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            If IsExistModifiedData() = False Then
                MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TablePartsCategory.Rows(0)("更新日") = dt

            'DBのデータ更新
            Dim sqlUserTableString As String = Nothing
            sqlUserTableString = CtrlDbNaviMaster.GetModifiedSqlString(CtrlDbNaviMaster.DefMstDb.TablePartsShapeCategory, TablePartsCategory.Rows(0), "ID")

            Dim insertResult As Boolean
            insertResult = CtrlDbNaviMaster.UpdateTableWithSQL(connectString, dbnameA, sqlUserTableString)
            If insertResult = True Then
                TablePartsCategory.AcceptChanges()
                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 部品形状分類の更新有無情報を取得する。
    ''' </summary>
    ''' <returns>
    ''' True:更新有　False:更新なし
    ''' </returns>
    ''' <remarks></remarks>
    Private Function IsExistModifiedData() As Boolean
        If IsStartEdit = True Then
            Return True
        End If
        For Each row As DataRow In TablePartsCategory.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next
        Return False
    End Function
    ''' <summary>
    ''' TextBoxNoteのText変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxNote_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNote.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsCategory.Rows(0)("備考") = TextBoxNote.Text
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' TextBoxPartsCategoryNameのText変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxPartsCategoryName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsCategoryName.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsCategory.Rows(0)("部品形状分類名称") = TextBoxPartsCategoryName.Text
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' キャンセルボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                TablePartsCategory.AcceptChanges()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub
    ''' <summary>
    ''' FormClosing処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' IsExistModifiedDataにより変更有無を確認し、変更がある場合は、データ更新せずに終了するか確認を行う。
    ''' 
    ''' </remarks>
    Private Sub FormEditPartsCategory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub
End Class