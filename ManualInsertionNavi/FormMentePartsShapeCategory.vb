Public Class FormMentePartsShapeCategory
    'マスターデータ操作用
    Private CtrlDbNaviMaster As ControlDbMaster

    'DataGridView操作用
    Private CtrlDgv As ControlDataGridView = New ControlDataGridView

    Public Sub New(ByVal mstContDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        CtrlDbNaviMaster = mstContDb.Clone
    End Sub

    ''' <summary>
    ''' フォーム読み込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormMenteUserMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingDgvMain()
    End Sub
    ''' <summary>
    ''' 更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonEditData_Click(sender As Object, e As EventArgs) Handles ButtonEditData.Click
        EditData()
    End Sub
    ''' <summary>
    ''' 行追加ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonAddNewData_Click(sender As Object, e As EventArgs) Handles ButtonAddNewData.Click
        OpenEditDataForm(True, Nothing)

    End Sub
    ''' <summary>
    ''' データ抽出ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonExtractData_Click(sender As Object, e As EventArgs) Handles ButtonExtractData.Click
        RefreshDgv()
    End Sub
    ''' <summary>
    ''' DataGridViewのセルをダブルクリックした際の処理。
    ''' データ編集画面を表示する。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        EditData()
    End Sub
    ''' <summary>
    ''' 行削除押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

        Dim dataId As Integer = DirectCast(DataGridView("ID", indexRow).Value, Integer)

        If DeletePartsCategoryDataFromDB(dataId) = True Then
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
    ''' マスタメンテナンス用DataGridViewの初期設定を行う処理メイン
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
        'ID列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "ID", "ID", "ID", True)
        'データ有効列列追加
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbNaviMaster.GetEnableTable("利用中", "利用停止")
        CtrlDgv.AddComboboxColumn(DataGridView, dataEnableTable,
                              "データ有効", "データ有効", "データ状態",
                                "Value", "Display", True)
        '部品形状分類名称列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "部品形状分類名称", "部品形状分類名称", "部品形状分類名称", True)
        '部品形状分類名称列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "備考", "備考", "備考", True)
        '登録者情報列追加
        CtrlDgv.AddRegisterInfoTextboxColoumn(DataGridView)
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
        Dim NowRowsCount As Integer = Nothing
        Try
            indexRow = DataGridView.CurrentCell.RowIndex
            indexCol = DataGridView.CurrentCell.ColumnIndex
            previousRowsCount = DataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show("データ更新する行が選択されていないか、データがありません。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        Dim partsCategoryId As Integer = DirectCast(DataGridView("ID", indexRow).Value, Integer)
        OpenEditDataForm(False, partsCategoryId)
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
    ''' DataGridViewの表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDgv()

        'DataGridView.DataSource = ""
        '接続文字列作成
        Dim connectString As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNameString As String = CtrlDbNaviMaster.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.Append("SELECT ")
        sbSql.Append("a.ID as ID")
        sbSql.Append(",a.データ有効 as データ有効")
        sbSql.Append(",a.部品形状分類名称 as 部品形状分類名称")
        sbSql.Append(",a.備考 as 備考")
        sbSql.Append(",a.登録日 as 登録日")
        sbSql.Append(",b.氏名 as 登録者")
        sbSql.Append(",a.更新日 as 更新日")
        sbSql.Append(",c.氏名 as 更新者")

        sbSql.Append(" FROM ")

        '更新者結合-----------------------------------------
        sbSql.Append("(")
        '登録者結合-----------------------------------------
        sbSql.Append("(")
        sbSql.Append(dbNameString & ".[" & CtrlDbNaviMaster.DefMstDb.TablePartsShapeCategory & "] as a")
        sbSql.Append(" left join ")
        sbSql.Append(dbNameString & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as b")
        sbSql.Append(" ON (a.登録者マンナンバー=b.マンナンバー)")
        sbSql.Append(")")
        '登録者結合--------------------------------------END
        sbSql.Append(" left join ")
        sbSql.Append(dbNameString & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as c")
        sbSql.Append(" ON (a.更新者マンナンバー=c.マンナンバー)")
        sbSql.Append(")")
        '更新者結合--------------------------------------END

        Dim isWhereAdd As Boolean = False
        If CheckBoxIncludeDisableData.Checked = False Then
            sbSql.Append(" where a.データ有効=True")
            isWhereAdd = True
        End If
        If TextBoxExtractCategory.Text <> "" Then
            If isWhereAdd = False Then
                sbSql.Append(" where ")
            Else
                sbSql.Append(" and ")
            End If
            sbSql.Append(" a.部品形状分類名称 like '%" & TextBoxExtractCategory.Text & "%'")
        End If

        sbSql.Append(" order by a.部品形状分類名称")
        Dim tb As DataTable = CtrlDbNaviMaster.GetTableData(sbSql.ToString, connectString)
        If tb IsNot Nothing Then
            CtrlDgv.BindTableToDgv(DataGridView, tb)
        End If
    End Sub
    ''' <summary>
    ''' データ編集用フォームを開く
    ''' </summary>
    ''' <param name="isNewdata">
    ''' 編集フォームを開くモードを選択
    ''' True:新規ユーザーデータ登録モード
    ''' False:既存ユーザーデータ更新モード
    ''' </param>
    ''' <param name="partsCategoryId">
    ''' 更新したいデータ（新規の場合はNothingを指定）
    ''' </param>
    ''' <remarks></remarks>
    Private Sub OpenEditDataForm(ByVal isNewdata As Boolean, ByVal partsCategoryId As Integer)
        Dim fm As FormEditPartsCategory = New FormEditPartsCategory(isNewdata, partsCategoryId, CtrlDbNaviMaster)
        Dim dresult As DialogResult
        dresult = fm.ShowDialog(Me)

        If fm IsNot Nothing Then
            fm.Dispose()
        End If
        If dresult = Windows.Forms.DialogResult.OK Then
            If isNewdata = True Then
                MessageBox.Show("新規を登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("データを更新しました。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            RefreshDgv()
        End If

    End Sub

    ''' <summary>
    ''' partsCategoryNameで指定したデータをテーブルから削除する
    ''' </summary>
    ''' <param name="partsCategoryId">
    ''' データベースから削除する部品形状分類のID
    ''' </param>
    ''' <returns>
    ''' True:挿入成功
    ''' False:挿入失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function DeletePartsCategoryDataFromDB(ByVal partsCategoryId As String) As Boolean
        Dim isCompleteUpdate As Boolean = False

        '接続文字列作成
        Dim connect_txt As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        'DBパス取得
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
            sqlUserTableString = GetDeleteSqlPartsCategoryFromTable(partsCategoryId)
            sqlCmd.CommandText = sqlUserTableString
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
    ''' <param name="partsCategoryId">
    ''' 削除する部品形状分類名称文字列
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetDeleteSqlPartsCategoryFromTable(ByVal partsCategoryId As Integer) As String
        Dim sbSql As New System.Text.StringBuilder()

        sbSql.Append("DELETE FROM " & CtrlDbNaviMaster.DefMstDb.TablePartsShapeCategory & " WHERE ")
        sbSql.Append("ID=" & partsCategoryId.ToString)

        Return sbSql.ToString

    End Function

    ''' <summary>
    ''' DataGridViewセル書式設定処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        Dim val As Integer
        Try
            val = Boolean.Parse(DataGridView("データ有効", e.RowIndex).Value)
        Catch ex As Exception
            val = False
        End Try
        'セルの値により、背景色を変更する
        Select Case val
            Case True
                DataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            Case False
                DataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End Select

    End Sub

    Private Function IsExistUserDataInUserTbRegisterOrUpdater(ByVal partsCategoryId As Integer) As Boolean
        Return True
    End Function

End Class