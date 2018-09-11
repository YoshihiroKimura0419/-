Public Class FormEditOrder
    '新規データ作成フラグ
    Private IsNewData As Boolean

    '追加/更新する部品形状分類のID
    Private EdittingOrder As String
    'オーダー管理テーブル
    Private TableOrder As New DataTable

    'Buデータテーブル（コンボボックス用）
    Private TableBu As New DataTable

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    'データ管理テーブル操作用
    Private CtrlDbOrder As ControlDbOrder
    'マスタデータ管理テーブル操作用
    Private CtrlDbMaster As ControlDbMaster

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="isNew">
    ''' 新規作成フラグ
    ''' </param>
    ''' <param name="order">
    ''' オーダー名。新規作成時は、Nothingを指定。
    ''' </param>
    ''' <param name="ctrlDb">
    ''' オーダーDB操作用オブジェクト
    ''' </param>
    ''' <param name="ctrlDbmst">
    ''' マスターDB操作用オブジェクト
    ''' </param>
    Public Sub New(ByVal isNew As Boolean, ByVal order As String, ByVal ctrlDb As ControlDbOrder, ByVal ctrlDbmst As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        IsNewData = isNew
        EdittingOrder = order
        If IsNewData = False Then
            ButtonRegistData.Text = "更新"
        Else
            ButtonRegistData.Text = "登録"
        End If
        CtrlDbOrder = ctrlDb.Clone
        CtrlDbMaster = ctrlDbmst.Clone
    End Sub

    Private Sub FormEditOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        '各種テーブルデータの取得
        TableOrder = CtrlDbOrder.GetOrderOneDataFromTable(EdittingOrder)

        'コントロール読取専用設定
        TextBoxBoardName.ReadOnly = True
        TextBoxRegistrationDate.ReadOnly = True
        TextBoxRegistrationUser.ReadOnly = True

        TextBoxUpdateDate.ReadOnly = True
        TextBoxUpdateUser.ReadOnly = True

        If IsNewData = True Then
            TextBoxOrder.ReadOnly = False
            TextBoxOrder.Text = ""
            SetNewOrderDataToTable(SysLoginUserInfo.ManNumber)
        Else
            TextBoxOrder.ReadOnly = True
            TableOrder.Rows(0)(OMTColumnName(OMTColumn.UpdateManNumber)) = SysLoginUserInfo.ManNumber
            TextBoxOrder.Text = CtrlDbOrder.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.Order))
        End If

        'ComboBoxDataEnableのDataSource設定
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbOrder.GetEnableTable("利用中", "利用停止")
        ComboBoxDataEnable.DataSource = dataEnableTable
        ComboBoxDataEnable.DisplayMember = "Display"
        ComboBoxDataEnable.ValueMember = "Value"
        ComboBoxDataEnable.SelectedValue = TableOrder.Rows(0)(OMTColumnName(OMTColumn.DataEnable))

        TextBoxBoardName.Text = CtrlDbMaster.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.BoardName))
        TextBoxProductionCount.Text = CtrlDbMaster.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.ProductionCount))

        TextBoxChangeHistory.Text = CtrlDbOrder.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.ChangeHistory))

        TextBoxRegistrationDate.Text = CtrlDbOrder.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.RegistDate))
        TextBoxUpdateDate.Text = CtrlDbOrder.GetRowColmunContentString(TableOrder.Rows(0), OMTColumnName(OMTColumn.UpdateDate))

        TextBoxRegistrationUser.Text = CtrlDbMaster.GetRegisterName(TableOrder.Rows(0), OMTColumnName(OMTColumn.RegistManNumber))
        TextBoxUpdateUser.Text = CtrlDbMaster.GetRegisterName(TableOrder.Rows(0), OMTColumnName(OMTColumn.UpdateManNumber))

        'BUコンボボックスデータソース設定
        TableBu = CtrlDbOrder.GetBuDataTable(True)
        Dim insertRow As DataRow = TableBu.NewRow
        TableBu.Rows.InsertAt(insertRow, 0)
        ComboBoxBu.DataSource = TableBu
        ComboBoxBu.DisplayMember = BUMTColumnName(BUMTColumn.BuName)
        ComboBoxBu.ValueMember = BUMTColumnName(BUMTColumn.ID)
        ComboBoxBu.SelectedValue = TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId))

        TableOrder.AcceptChanges()

        NowInitializing = False

    End Sub
    ''' <summary>
    ''' 新規オーダー登録時の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewOrderDataToTable(ByVal registerManNumber As String)

        'ユーザー管理設定
        TableOrder.Rows.Add()
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.Order)) = Nothing
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.DataEnable)) = True
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.BoardName)) = Nothing
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId)) = DBNull.Value
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.ProductionCount)) = 0
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.ChangeHistory)) = Nothing
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.RegistDate)) = DBNull.Value
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.RegistManNumber)) = registerManNumber
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.UpdateDate)) = DBNull.Value
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.UpdateManNumber)) = Nothing
        TableOrder.AcceptChanges()

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
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.DataEnable)) = ComboBoxDataEnable.SelectedValue
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 登録/更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim connectString As String = CtrlDbOrder.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbOrder.GetMasterDbPathString()
        Dim sqlString As String = Nothing
        Dim sqlStringSerial As String = Nothing

        If IsNewData = True Then
            If IsStartEdit = False Then
                MessageBox.Show("登録するデータが入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TableOrder.Rows(0)(OMTColumnName(OMTColumn.RegistDate)) = dt

            'DBへオーダーデータ挿入
            sqlString = CtrlDbOrder.GetInsertSqlString(CtrlDbOrder.DefOrdDb.TableOrder, TableOrder.Rows(0), Nothing)
            sqlStringSerial = CtrlDbOrder.GetSqlInsertSerial(TableOrder.Rows(0)(OMTColumnName(OMTColumn.Order)))

            Dim insertResult As Boolean
            'insertResult = CtrlDbOrder.UpdateTableWithSQL(connectString, dbnameA, sqlString)
            insertResult = RagistOrderSerial(connectString, dbnameA, sqlString, sqlStringSerial)
            If insertResult = True Then
                TableOrder.AcceptChanges()

                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            If IsStartEdit = False Then
                MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            TableOrder.Rows(0)(OMTColumnName(OMTColumn.UpdateDate)) = dt

            'DBのデータ更新
            sqlString = CtrlDbOrder.GetModifiedSqlString(CtrlDbOrder.DefOrdDb.TableOrder,
                                                         TableOrder.Rows(0),
                                                         OMTColumnName(OMTColumn.Order)
                                                         )

            Dim insertResult As Boolean
            insertResult = CtrlDbOrder.UpdateTableWithSQL(connectString, dbnameA, sqlString)
            If insertResult = True Then
                TableOrder.AcceptChanges()
                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    ''' <summary>
    ''' キャンセルボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        If IsStartEdit = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                TableOrder.AcceptChanges()
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
        'If IsExistModifiedData() = true Then
        If IsStartEdit = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub


    Private Sub TextBoxOrder_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxOrder.KeyUp
        If e.KeyCode = Keys.Enter Then
            If IsOkOrder() = True Then

            End If
        End If
    End Sub
    Private Function IsOkOrder() As Boolean
        Dim isOk As Boolean = True
        Dim order As String = ConvetStrUpperNarrow(TextBoxOrder.Text)
        If IsOrderString(order) = False Then
            ErrorProviderInput.SetError(TextBoxOrder, order & "未入力又は、使用禁止文字が含まれてるか、桁数(14-20)が間違っています。")
            TextBoxOrder.BackColor = Color.Yellow
            isOk = False
        End If
        If isOk = True Then
            Dim isExist As Boolean = CtrlDbOrder.IsExistOrder(order)
            If isExist = True Then
                ErrorProviderInput.SetError(TextBoxOrder, "入力したオーダーは、登録済みです。")
                TextBoxOrder.BackColor = Color.Yellow
                isOk = False
            Else
                TextBoxOrder.Text = order
                TableOrder.Rows(0)(OMTColumnName(OMTColumn.Order)) = order
                isOk = True
            End If
        End If
        Return isOk

    End Function


    Private Sub TextBoxOrder_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxOrder.Validating
        If IsNewData = True Then
            If (IsOkOrder() = False) AndAlso (ActiveControl IsNot TextBoxOrder) Then
                e.Cancel = True
            End If

        End If

    End Sub
    Private Sub TextBoxOrder_Validated(sender As Object, e As EventArgs) Handles TextBoxOrder.Validated
        ErrorProviderInput.SetError(TextBoxOrder, "")
        TextBoxOrder.BackColor = SystemColors.Window
    End Sub


    Private Sub TextBoxProductionCount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxProductionCount.Validating
        Dim count As Integer
        If (Integer.TryParse(TextBoxProductionCount.Text, count) = True) AndAlso (ActiveControl IsNot TextBoxProductionCount) Then
            If TextBoxProductionCount.Modified = True Then
                TableOrder.Rows(0)(OMTColumnName(OMTColumn.ProductionCount)) = count
                TextBoxProductionCount.Text = count.ToString
            End If
        Else
            ErrorProviderInput.SetError(TextBoxProductionCount, "整数を入力してください。")
            TextBoxProductionCount.BackColor = Color.Yellow
            e.Cancel = True
        End If

    End Sub

    Private Sub TextBoxProductionCount_Validated(sender As Object, e As EventArgs) Handles TextBoxProductionCount.Validated
        ErrorProviderInput.SetError(TextBoxProductionCount, "")
        TextBoxProductionCount.BackColor = SystemColors.Window
    End Sub
    Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles TextBoxOrder.Enter, TextBoxProductionCount.Enter,
        TextBoxBoardName.Enter, TextBoxChangeHistory.Enter
        Dim cs As Control() = Me.Controls.Find(sender.name, True)
        If 0 < cs.Length Then
            CType(cs(0), TextBox).BackColor = Color.LightBlue
        End If

    End Sub

    Private Sub ComboBoxBu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBoxBu.Validating
        If ComboBoxBu.SelectedValue Is DBNull.Value Then
            ErrorProviderInput.SetError(ComboBoxBu, "BU名を選択してください。")
            ComboBoxBu.BackColor = Color.Yellow
            e.Cancel = True
        Else
            If TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId)) IsNot DBNull.Value Then
                If TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId)) = ComboBoxBu.SelectedValue Then
                    Exit Sub
                End If
            End If
            TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId)) = ComboBoxBu.SelectedValue
        End If
    End Sub

    Private Sub ComboBoxBu_Validated(sender As Object, e As EventArgs) Handles ComboBoxBu.Validated
        ErrorProviderInput.SetError(ComboBoxBu, "")
        ComboBoxBu.BackColor = SystemColors.Window
    End Sub

    Private Sub TextBoxBoardName_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxBoardName.DoubleClick
        Dim selectedBoardName As String = Nothing
        Using fm As New FormMenteDrawingMaster(CtrlDbMaster, FormMenteDrawingMasterOpenMode.DataSelect)
            Dim dResult As DialogResult
            dResult = fm.ShowDialog()
            If dResult = DialogResult.OK Then
                selectedBoardName = fm.SelectedBoardName
                TableOrder.Rows(0)(OMTColumnName(OMTColumn.BoardName)) = selectedBoardName
                TextBoxBoardName.Text = selectedBoardName
            End If
        End Using

    End Sub


    Private Sub TextBoxBoardName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxBoardName.Validating
        If (TextBoxBoardName.Text <> "") AndAlso (ActiveControl IsNot TextBoxBoardName) Then
            If TextBoxBoardName.Modified = True Then
                TableOrder.Rows(0)(OMTColumnName(OMTColumn.BoardName)) = TextBoxBoardName.Text
            End If
        Else
            ErrorProviderInput.SetError(TextBoxProductionCount, "基板名をダブルクリックして選択してください。")
            TextBoxProductionCount.BackColor = Color.Yellow
            e.Cancel = True
        End If

    End Sub
    Private Sub TextBoxBoardName_Validated(sender As Object, e As EventArgs) Handles TextBoxBoardName.Validated
        ErrorProviderInput.SetError(TextBoxBoardName, "")
        TextBoxBoardName.BackColor = SystemColors.Window
    End Sub

    Private Sub TextBoxChangeHistory_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxChangeHistory.Validating
        If TextBoxChangeHistory.Modified = False Then
            Exit Sub
        End If
        TableOrder.Rows(0)(OMTColumnName(OMTColumn.ChangeHistory)) = TextBoxChangeHistory.Text
        IsStartEdit = True

    End Sub

    Private Sub TextBoxChangeHistory_Validated(sender As Object, e As EventArgs) Handles TextBoxChangeHistory.Validated
        TextBoxChangeHistory.BackColor = SystemColors.Window
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBoxOrder.TextChanged,
                                                                              TextBoxBoardName.TextChanged,
                                                                              TextBoxProductionCount.TextChanged,
                                                                              TextBoxChangeHistory.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If

        IsStartEdit = True
    End Sub

    Private Sub ComboBoxBu_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxBu.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If

        IsStartEdit = True
    End Sub

    Private Function RagistOrderSerial(ByVal connectString As String, ByVal dbnameA As String, ByVal sqlString As String, ByVal sqlStringSerial As String) As Boolean
        Dim isCompleteUpdate As Boolean = False
        Dim oleCon As New System.Data.OleDb.OleDbConnection(connectString)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            sqlCmd.CommandText = sqlString
            sqlCmd.ExecuteNonQuery() '実行

            sqlCmd.CommandText = sqlStringSerial
            sqlCmd.ExecuteNonQuery() '実行

            isCompleteUpdate = True
            trz.Commit() 'コミット（確定）
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