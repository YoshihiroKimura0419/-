Public Class FormMenteOrder

    'Buコンボボックス用テーブル
    Private TableBu As New DataTable

    Private CtrlDgv As ControlDataGridView = New ControlDataGridView

    'データ管理テーブル操作用
    Private CtrlDbOrder As ControlDbOrder
    'マスタデータ管理テーブル操作用
    Private CtrlDbMaster As ControlDbMaster

    Public Sub New(ByVal ctrlDbMst As ControlDbMaster, ByVal ctrlDbOrd As ControlDbOrder)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        CtrlDbMaster = ctrlDbMst.Clone
        CtrlDbOrder = ctrlDbOrd.Clone

    End Sub

    Private Sub FormMenteOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedListBoxDataEnable.SetItemChecked(0, True)
        CheckedListBoxDataEnable.SetItemChecked(1, True)

        'BUコンボボックスデータソース設定
        TableBu = CtrlDbOrder.GetBuDataTable(True)
        Dim insertRow As DataRow = TableBu.NewRow
        TableBu.Rows.InsertAt(insertRow, 0)
        ComboBoxBu.DataSource = TableBu
        ComboBoxBu.DisplayMember = BUMTColumnName(BUMTColumn.BuName)
        ComboBoxBu.ValueMember = BUMTColumnName(BUMTColumn.ID)
        ComboBoxBu.SelectedValue = DBNull.Value

        SettingDgvMain()

    End Sub
    ''' <summary>
    ''' オーダー管理用DataGridViewの初期設定を行う処理メイン
    ''' </summary>
    ''' <remarks></remarks>
    Sub SettingDgvMain()
        'DataGridViewのデータ列設定
        SetDgvColumDataMain()
        RefreshDgv()

        DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
        '並べ替えを無効にする
        For Each c As DataGridViewColumn In DataGridView.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

    End Sub
    ''' <summary>
    ''' マスタメンテナンス用DataGridViewの列設定メイン処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDgvColumDataMain()
        '列が自動的に作成されないようにする
        DataGridView.AutoGenerateColumns = False

        'オーダー列追加
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 OMTColumnName(OMTColumn.Order),
                                 OMTColumnName(OMTColumn.Order),
                                 OMTColumnName(OMTColumn.Order),
                                 True)
        'データ有効列列追加
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbMaster.GetEnableTable("利用中", "利用停止")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  dataEnableTable,
                                  OMTColumnName(OMTColumn.DataEnable),
                                  OMTColumnName(OMTColumn.DataEnable),
                                  OMTColumnName(OMTColumn.DataEnable),
                                  "Value", "Display", True)

        '基板名称
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 OMTColumnName(OMTColumn.BoardName),
                                 OMTColumnName(OMTColumn.BoardName),
                                 OMTColumnName(OMTColumn.BoardName),
                                 True)

        'Bu名
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 BUMTColumnName(BUMTColumn.BuName),
                                 BUMTColumnName(BUMTColumn.BuName),
                                 BUMTColumnName(BUMTColumn.BuName),
                                 True)

        '製作枚数
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 OMTColumnName(OMTColumn.ProductionCount),
                                 OMTColumnName(OMTColumn.ProductionCount),
                                 OMTColumnName(OMTColumn.ProductionCount),
                                 True)
        '変更履歴
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 OMTColumnName(OMTColumn.ChangeHistory),
                                 OMTColumnName(OMTColumn.ChangeHistory),
                                 OMTColumnName(OMTColumn.ChangeHistory),
                                 True)

        '登録者情報列追加
        CtrlDgv.AddRegisterInfoTextboxColoumn(DataGridView)
    End Sub
    ''' <summary>
    ''' DataGridViewの表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDgv()

        'DataGridView.DataSource = ""
        '接続文字列作成
        Dim connectString As String = CtrlDbOrder.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNameString As String = CtrlDbOrder.GetMasterDbPathString()
        Dim dbNameStringB As String = CtrlDbMaster.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.Order), OMTColumnName(OMTColumn.Order)))
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.DataEnable), OMTColumnName(OMTColumn.DataEnable)))
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.BoardName), OMTColumnName(OMTColumn.BoardName)))
        sbSql.AppendLine(String.Format("d.{0} as {1},", BUMTColumnName(BUMTColumn.BuName), BUMTColumnName(BUMTColumn.BuName)))
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.ProductionCount), OMTColumnName(OMTColumn.ProductionCount)))
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.ChangeHistory), OMTColumnName(OMTColumn.ChangeHistory)))

        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.RegistDate), OMTColumnName(OMTColumn.RegistDate)))
        sbSql.AppendLine(String.Format("b.{0} as {1},", UDTColumnName(UDTColumn.UserName), "登録者"))

        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.UpdateDate), OMTColumnName(OMTColumn.UpdateDate)))
        sbSql.AppendLine(String.Format("c.{0} as {1}", UDTColumnName(UDTColumn.UserName), "更新者"))

        sbSql.AppendLine(" FROM ")

        '部品形状管理結合-----------------------------------------
        sbSql.AppendLine("(")
        '更新者結合-----------------------------------------
        sbSql.AppendLine("(")
        '登録者結合-----------------------------------------
        sbSql.AppendLine("(")
        sbSql.AppendLine(dbNameString & ".[" & CtrlDbOrder.DefOrdDb.TableOrder & "] as a")
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameStringB & ".[" & CtrlDbMaster.DefMstDb.TableUser & "] as b")
        sbSql.AppendLine(" ON (a.登録者マンナンバー=b.マンナンバー)")
        sbSql.AppendLine(")")
        '登録者結合--------------------------------------END
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameStringB & ".[" & CtrlDbMaster.DefMstDb.TableUser & "] as c")
        sbSql.AppendLine(" ON (a.更新者マンナンバー=c.マンナンバー)")
        sbSql.AppendLine(")")
        '更新者結合--------------------------------------END
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameString & ".[" & CtrlDbOrder.DefOrdDb.TableBu & "] as d")
        sbSql.AppendLine(String.Format("ON (a.{0}=d.{1})", OMTColumnName(OMTColumn.BuId), BUMTColumnName(BUMTColumn.ID)))
        sbSql.AppendLine(")")
        '部品形状管理結合--------------------------------------END

        Dim isWhereAdd As Boolean = False
        Dim whereOrAdd As String = Nothing

        'オーダー指定
        If TextBoxOrder.Text <> "" Then

            'If isWhereAdd = False Then
            '    sbSql.AppendLine(" where (")
            'Else
            '    sbSql.AppendLine(" and ")
            'End If

            whereOrAdd = GetWhereOrAddString(isWhereAdd)
            sbSql.AppendLine(whereOrAdd)

            sbSql.AppendLine(String.Format("a.{0} like '%{1}%'", OMTColumnName(OMTColumn.Order), TextBoxOrder.Text))
            isWhereAdd = True
        End If

        'データ有効状態
        'If isWhereAdd = True Then
        '    whereOrAdd = " and "
        'Else
        '    whereOrAdd = "  WHERE ( "
        'End If
        whereOrAdd = GetWhereOrAddString(isWhereAdd)
        If CheckedListBoxDataEnable.GetItemChecked(0) = True Then
            sbSql.AppendLine(whereOrAdd)
            sbSql.AppendLine(String.Format("(a.{0}=TRUE", OMTColumnName(OMTColumn.DataEnable)))
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.AppendLine(String.Format("or a.{0}=False", OMTColumnName(OMTColumn.DataEnable)))
            End If
            sbSql.AppendLine(")")
            isWhereAdd = True
        Else
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.AppendLine(whereOrAdd)
                sbSql.AppendLine(String.Format("(a.{0}=False)", OMTColumnName(OMTColumn.DataEnable)))
                isWhereAdd = True
            End If
        End If

        '基板名指定
        'If isWhereAdd = True Then
        '    whereOrAdd = " and "
        'Else
        '    whereOrAdd = "  WHERE ( "
        'End If
        whereOrAdd = GetWhereOrAddString(isWhereAdd)
        If TextBoxBoardName.Text <> "" Then
            'If isWhereAdd = False Then
            '    sbSql.AppendLine(" where (")
            'Else
            '    sbSql.AppendLine(" and ")
            'End If
            whereOrAdd = GetWhereOrAddString(isWhereAdd)
            sbSql.AppendLine(whereOrAdd)


            sbSql.AppendLine(String.Format("a.{0} like '%{1}%'", OMTColumnName(OMTColumn.BoardName), TextBoxBoardName.Text))
            isWhereAdd = True
        End If

        '基板名指定
        'If isWhereAdd = True Then
        '    whereOrAdd = " and "
        'Else
        '    whereOrAdd = "  WHERE ( "
        'End If
        If ComboBoxBu.SelectedValue IsNot DBNull.Value Then
            'If isWhereAdd = False Then
            '    sbSql.AppendLine(" where (")
            'Else
            '    sbSql.AppendLine(" and ")
            'End If
            whereOrAdd = GetWhereOrAddString(isWhereAdd)
            sbSql.AppendLine(whereOrAdd)

            sbSql.AppendLine(String.Format("a.{0}={1}", OMTColumnName(OMTColumn.BuId), ComboBoxBu.SelectedValue))
            isWhereAdd = True
        End If

        If isWhereAdd = True Then
            sbSql.AppendLine(")")
        End If

        sbSql.AppendLine(String.Format("order by a.{0}", OMTColumnName(OMTColumn.Order)))

        Dim tb As DataTable = CtrlDbOrder.GetTableData(sbSql.ToString, connectString)
        If tb IsNot Nothing Then
            CtrlDgv.BindTableToDgv(DataGridView, tb)
        End If
    End Sub
    Private Function GetWhereOrAddString(ByVal isAddedWhere As Boolean) As String

        If isAddedWhere = True Then
            Return " and "
        Else
            Return "  WHERE ( "
        End If

    End Function
    Private Sub ButtonEditData_Click(sender As Object, e As EventArgs) Handles ButtonEditData.Click
        EditData()
    End Sub

    Private Sub ButtonAddNewData_Click(sender As Object, e As EventArgs) Handles ButtonAddNewData.Click

        OpenEditDataForm(True, Nothing)

    End Sub

    Private Sub ButtonDeleteData_Click(sender As Object, e As EventArgs) Handles ButtonDeleteData.Click
        Dim indexRow As Integer = -1
        Dim indexCol As Integer = Nothing
        Dim previousRowsCount As Integer = Nothing
        Dim NowRowsCount As Integer = Nothing

        Dim dResult As DialogResult
        dResult = MessageBox.Show("削除するとデータを元に戻せません。" & vbCrLf & "完全に削除しますか？",
                                  "完全データ削除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dResult = Windows.Forms.DialogResult.No Then
            MessageBox.Show("完全削除をキャンセルしました", "完全データ削除", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            indexRow = DataGridView.CurrentCell.RowIndex
            indexCol = DataGridView.CurrentCell.ColumnIndex
            previousRowsCount = DataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show("完全削除する行が選択されていないか、データがありません。", "完全データ削除", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Dim order As String = DirectCast(DataGridView(OMTColumnName(OMTColumn.Order), indexRow).Value, String)

        If DeleteOrderDataFromDB(order) = True Then
            RefreshDgv()
            MessageBox.Show("データを完全に削除しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

        End If
        NowRowsCount = DataGridView.Rows.Count
        If 0 < NowRowsCount Then
            If NowRowsCount <> previousRowsCount Then
                If (NowRowsCount - 1) < indexRow Then
                    indexRow = NowRowsCount - 1
                End If
            End If
            DataGridView.CurrentCell = DataGridView(indexCol, indexRow)
        End If

    End Sub
    ''' <summary>
    ''' 編集処理メイン
    ''' 編集には、****を使用する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditData()
        Dim isnewData As Boolean = True
        Dim indexRow As Integer = Nothing
        Dim indexCol As Integer = Nothing
        Dim previousRowsCount As Integer = Nothing
        Dim nowRowsCount As Integer = Nothing
        Try
            indexRow = DataGridView.CurrentCell.RowIndex
            indexCol = DataGridView.CurrentCell.ColumnIndex
            previousRowsCount = DataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show("データ更新する行が選択されていないか、データがありません。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        Dim order As String = DirectCast(DataGridView(OMTColumnName(OMTColumn.Order), indexRow).Value, String)
        OpenEditDataForm(False, order)
        nowRowsCount = DataGridView.Rows.Count
        If 0 < nowRowsCount Then
            If nowRowsCount <> previousRowsCount Then
                If (nowRowsCount - 1) < indexRow Then
                    indexRow = nowRowsCount - 1
                End If
            End If
            DataGridView.CurrentCell = DataGridView(indexCol, indexRow)
        End If
    End Sub
    ''' <summary>
    ''' データ編集用フォームを開く
    ''' </summary>
    ''' <param name="isNewdata">
    ''' 編集フォームを開くモードを選択
    ''' True:新規オーダー登録モード
    ''' False:既存オーダー更新モード
    ''' </param>
    ''' <param name="order">
    ''' 更新したいオーダー（新規の場合はNothingを指定）
    ''' </param>
    ''' <remarks></remarks>
    Private Sub OpenEditDataForm(ByVal isNewdata As Boolean, ByVal order As String)
        Dim dresult As DialogResult
        Dim fm As New FormEditOrder(isNewdata, order, ControlOrderDb, ControlMasterDb)
        dresult = fm.ShowDialog(Me)
        If fm IsNot Nothing Then
            fm.Dispose()
        End If
        If dresult = Windows.Forms.DialogResult.OK Then
            RefreshDgv()
            If isNewdata = True Then
                MessageBox.Show("新規を登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("データを更新しました。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        EditData()
    End Sub

    ''' <summary>
    ''' orderで指定したデータをテーブルから削除する
    ''' </summary>
    ''' <param name="order">
    ''' データベースから削除するオーダー文字列
    ''' </param>
    ''' <returns>
    ''' True:成功
    ''' False:失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function DeleteOrderDataFromDB(ByVal order As String) As Boolean
        Dim isCompleteUpdate As Boolean = False

        '接続文字列作成
        Dim connect_txt As String = CtrlDbOrder.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDbOrder.GetMasterDbPathString()

        Dim oleCon As New System.Data.OleDb.OleDbConnection(connect_txt)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction
        Dim sqlString As String = ""

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            'ユーザー管理テーブル
            sqlString = GetDeleteSqlOrderFromTable(order)
            sqlCmd.CommandText = sqlString
            sqlCmd.ExecuteNonQuery() '実行

            '他のテーブルで使用されていないか確認が必要

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
    ''' <summary>
    ''' partsCategoryNameで指定したデータを部品形状分類マスタテーブルから削除するSQL文を取得する
    ''' </summary>
    ''' <param name="order">
    ''' 削除する部品形状分類名称文字列
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetDeleteSqlOrderFromTable(ByVal order As String) As String
        Dim sbSql As New System.Text.StringBuilder()

        sbSql.AppendLine("DELETE")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbOrder.DefOrdDb.TableOrder)
        sbSql.AppendLine("WHERE ")
        sbSql.AppendLine(String.Format("{0}='{1}'", OMTColumnName(OMTColumn.Order), order))

        Return sbSql.ToString

    End Function

    Private Sub ButtonExtractData_Click(sender As Object, e As EventArgs) Handles ButtonExtractData.Click
        RefreshDgv()
    End Sub

    Private Sub CheckedListBoxDataEnable_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CheckedListBoxDataEnable.Validating
        For i As Integer = 0 To CheckedListBoxDataEnable.Items.Count - 1
            If CheckedListBoxDataEnable.GetItemChecked(i) = True Then
                Exit Sub
            End If
        Next
        e.Cancel = True
        ErrorProviderInput.SetError(CheckedListBoxDataEnable, "一つは必ずチェックをしてください。")
        CheckedListBoxDataEnable.BackColor = Color.Yellow
    End Sub

    Private Sub CheckedListBoxDataEnable_Validated(sender As Object, e As EventArgs) Handles CheckedListBoxDataEnable.Validated
        ErrorProviderInput.SetError(CheckedListBoxDataEnable, "")
        CheckedListBoxDataEnable.BackColor = SystemColors.Window
    End Sub
End Class