Public Class FormMentePartsMaster
    'マスターデータ操作用
    Private CtrlDbNaviMaster As ControlDbMaster
    '部材マスタデータ操作用
    Private CtrlDbPartsMaster As ControlDbPartsMaster

    'DataGridView操作用
    Private CtrlShapeCategoryCombobox As CustomComboboxShapeCategoryImpl

    Private CtrlDgv As ControlDataGridView = New ControlDataGridView
    Private FormOpenMode As Integer = FormMentePartsMasterOpenMode.Edit

    '選択した部材コードのデータ格納テーブル
    Public TbSelectedPartsCodeData As New DataTable

    Public Sub New(ByVal mstContDb As ControlDbMaster, ByVal mstPartsContDb As ControlDbPartsMaster, ByVal openMode As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        CtrlDbNaviMaster = mstContDb.Clone
        CtrlDbPartsMaster = mstPartsContDb.Clone
        FormOpenMode = openMode
    End Sub

    Private Sub FormMentePartsMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case FormOpenMode
            Case FormMentePartsMasterOpenMode.Edit
                ButtonEditOrSelectData.Text = "データ編集"
            Case FormMentePartsMasterOpenMode.DataSelect
                ButtonEditOrSelectData.Text = "決定"
                ButtonAddNewData.Visible = False
                ButtonDeleteData.Visible = False
        End Select


        CtrlShapeCategoryCombobox = New CustomComboboxShapeCategoryImpl(ComboBoxShapeCategory, CtrlDbNaviMaster)
        CtrlShapeCategoryCombobox.SetComboboxDataSource()

        CheckedListBoxDataEnable.SetItemChecked(0, True)
        CheckedListBoxDataEnable.SetItemChecked(1, True)

        CheckedListBoxShapeName.SetItemChecked(0, True)
        CheckedListBoxShapeName.SetItemChecked(1, True)

        CheckedListBoxPartsImage.SetItemChecked(0, True)
        CheckedListBoxPartsImage.SetItemChecked(1, True)

        CheckedListBoxKankotsu.SetItemChecked(0, True)
        CheckedListBoxKankotsu.SetItemChecked(1, True)


        SettingDgvMain()
    End Sub
    Private Sub ButtonEditOrSelectData_Click(sender As Object, e As EventArgs) Handles ButtonEditOrSelectData.Click
        Dim indexRow As Integer = Nothing
        Dim indexCol As Integer = Nothing
        Try
            indexRow = DataGridView.CurrentCell.RowIndex
            indexCol = DataGridView.CurrentCell.ColumnIndex
        Catch ex As Exception
            MessageBox.Show("データが選択されていないか、データがありません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try


        Select Case FormOpenMode
            Case FormMentePartsMasterOpenMode.Edit
                EditData(indexRow, indexCol)
            Case FormMentePartsMasterOpenMode.DataSelect
                Dim partsCode As String = DataGridView(PMTColumnName(PMTColumn.PartsCode), indexRow).Value()

                TbSelectedPartsCodeData = CtrlDbPartsMaster.GetPartsOneDataFromTable(partsCode)

                Me.DialogResult = DialogResult.OK

        End Select
    End Sub

    Private Sub ButtonAddNewData_Click(sender As Object, e As EventArgs) Handles ButtonAddNewData.Click
        OpenEditDataForm(True, Nothing)

    End Sub
    ''' <summary>
    ''' DataGridViewのセルをダブルクリックした際の処理。
    ''' データ編集画面を表示する。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        If (e.RowIndex < 0) OrElse (e.ColumnIndex < 0) Then
            Exit Sub
        End If
        Select Case FormOpenMode
            Case FormMentePartsMasterOpenMode.Edit
                EditData(e.RowIndex, e.ColumnIndex)
            Case FormMentePartsMasterOpenMode.DataSelect
                Dim partsCode As String = DataGridView(PMTColumnName(PMTColumn.PartsCode), e.RowIndex).Value()
                TbSelectedPartsCodeData = CtrlDbPartsMaster.GetPartsOneDataFromTable(partsCode)
                Me.DialogResult = DialogResult.OK
        End Select

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

        '他で使われていないか確認が必要
        MessageBox.Show("他で使われていないのでデータを完全に削除します")

        Dim partsCode As String = DirectCast(DataGridView("部材コード", indexRow).Value, String)
        If DeletePartsShapeDataFromDB(partsCode) = True Then
            '部材コードフォルダ削除
            Dim delFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode
            Dim errMess As String = Nothing
            Do While True
                If DeleteFile(delFolder, errMess) <> 0 Then
                    Dim errMessDelete As New Text.StringBuilder
                    errMessDelete.Append("部材データフォルダの削除が出来ませんでした。" & vbCrLf)
                    errMessDelete.Append("詳細は、下記を参照して下さい。" & vbCrLf)
                    errMessDelete.Append("リトライしますか？" & vbCrLf)
                    errMessDelete.Append(vbCrLf)

                    Using errMessDialog As New FormMessageDetailsDialog(errMessDelete.ToString, "ファイル削除エラー", errMess, MessageBoxButtons.YesNo)
                        dResult = errMessDialog.ShowDialog()
                        If dResult = DialogResult.No Then
                            Exit Do
                        End If
                    End Using
                Else
                    Exit Do
                End If
            Loop

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

        'DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
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
        '部材コード列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "部材コード", "部材コード", "部材コード", True)
        'データ有効列列追加
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbNaviMaster.GetEnableTable("利用中", "利用停止")
        CtrlDgv.AddComboboxColumn(DataGridView, dataEnableTable,
                              "データ有効", "データ有効", "データ状態",
                                "Value", "Display", True)
        '部品名
        CtrlDgv.AddTextboxColumn(DataGridView, "品名", "品名", "品名", True)
        '部品型名
        CtrlDgv.AddTextboxColumn(DataGridView, "型名", "型名", "型名", True)

        '部品形状名
        CtrlDgv.AddTextboxColumn(DataGridView, "部品形状名", "部品形状名", "部品形状名", True)

        '形状分類
        CtrlDgv.AddTextboxColumn(DataGridView, "形状分類", "形状分類", "形状分類", True)

        ''部材画像名
        'ControlDgv.AddTextboxColumn(DataGridView, "部材画像名", "部材画像名", "部材画像名", True)

        '部材画像有
        Dim imageExistTable As New DataTable()
        imageExistTable = CtrlDbNaviMaster.GetEnableTable("有", "無")
        CtrlDgv.AddComboboxColumn(DataGridView, imageExistTable,
                              "部材画像", "部材画像", "部材画像",
                                "Value", "Display", True)

        '部材画像有
        Dim kankotsuExistTable As New DataTable()
        kankotsuExistTable = CtrlDbNaviMaster.GetEnableTable("有", "無")
        CtrlDgv.AddComboboxColumn(DataGridView, kankotsuExistTable,
                              "カンコツファイル", "カンコツファイル", "カンコツファイル",
                                "Value", "Display", True)


        '備考
        CtrlDgv.AddTextboxColumn(DataGridView, "備考", "備考", "備考", True)
        '変更履歴
        CtrlDgv.AddTextboxColumn(DataGridView, "変更履歴", "変更履歴", "変更履歴", True)

        '登録者情報列追加
        CtrlDgv.AddRegisterInfoTextboxColoumn(DataGridView)
    End Sub
    ''' <summary>
    ''' 編集処理メイン
    ''' 編集には、****を使用する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditData(ByVal indexRow As Integer, ByVal indexCol As Integer)
        Dim previousRowsCount As Integer = Nothing
        Dim nowRowsCount As Integer = Nothing
        'Try
        '    indexRow = DataGridView.CurrentCell.RowIndex
        '    indexCol = DataGridView.CurrentCell.ColumnIndex
        '    previousRowsCount = DataGridView.Rows.Count
        'Catch ex As Exception
        '    MessageBox.Show("データ更新する行が選択されていないか、データがありません。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End Try
        Dim partsCode As String = DirectCast(DataGridView("部材コード", indexRow).Value, String)
        OpenEditDataForm(False, partsCode)
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
    ''' DataGridViewの表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDgv()
        Dim whereOrAdd As String = Nothing

        'DataGridView.DataSource = ""
        '接続文字列作成
        Dim connectString As String = CtrlDbPartsMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNameString As String = CtrlDbPartsMaster.GetMasterDbPathString()
        Dim dbNameStringMaster As String = CtrlDbNaviMaster.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.Append("SELECT ")
        sbSql.Append("a.部材コード as 部材コード")
        sbSql.Append(",a.データ有効 as データ有効")
        sbSql.Append(",a.品名 as 品名")
        sbSql.Append(",a.型名 as 型名")
        sbSql.Append(",b.部品形状名 as 部品形状名")
        sbSql.Append(",e.部品形状分類名称 as 形状分類")

        sbSql.Append(",a.部材画像 as 部材画像")
        sbSql.Append(",a.カンコツファイル as カンコツファイル")
        sbSql.Append(",a.備考 as 備考")
        sbSql.Append(",a.変更履歴 as 変更履歴")

        sbSql.Append(",a.登録日 as 登録日")
        sbSql.Append(",c.氏名 as 登録者")
        sbSql.Append(",a.更新日 as 更新日")
        sbSql.Append(",d.氏名 as 更新者")
        sbSql.Append(",a.部品形状ID as 部品形状ID")
        sbSql.Append(",b.部品形状分類ID as 部品形状分類ID")

        sbSql.Append(" FROM ")

        '部品形状管理結合-----------------------------------
        sbSql.Append("(")
        '更新者結合-----------------------------------------
        sbSql.Append("(")
        '登録者結合-----------------------------------------
        sbSql.Append("(")
        '部品形状ID結合-------------------------------------
        sbSql.Append("(")
        sbSql.Append(dbNameString & ".[" & CtrlDbPartsMaster.DefPtMstDb.TablePartsMaster & "] as a")
        sbSql.Append(" left join ")
        sbSql.Append(dbNameStringMaster & ".[" & CtrlDbNaviMaster.DefMstDb.TablePartsShapeMaster & "] as b")
        sbSql.Append(" ON (a.部品形状ID=b.ID)")
        sbSql.Append(")")
        '部品形状ID結合----------------------------------END
        sbSql.Append(" left join ")
        sbSql.Append(dbNameStringMaster & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as c")
        sbSql.Append(" ON (a.登録者マンナンバー=c.マンナンバー)")
        sbSql.Append(")")
        '登録者結合--------------------------------------END
        sbSql.Append(" left join ")
        sbSql.Append(dbNameStringMaster & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as d")
        sbSql.Append(" ON (a.更新者マンナンバー=d.マンナンバー)")
        sbSql.Append(")")
        '更新者結合--------------------------------------END
        sbSql.Append(" left join ")
        sbSql.Append(dbNameStringMaster & ".[" & CtrlDbNaviMaster.DefMstDb.TablePartsShapeCategory & "] as e")
        sbSql.Append(" ON (b.部品形状分類ID=e.ID)")
        sbSql.Append(")")
        '部品形状管理結合--------------------------------END

        Dim isWhereAdd As Boolean = False

        '部材コード指定
        If TextBoxPartsCode.Text <> "" Then
            If isWhereAdd = False Then
                sbSql.Append(" where (")
            Else
                sbSql.Append(" and ")
            End If
            sbSql.Append(" (a.部材コード like '%" & TextBoxPartsCode.Text & "%')")
            isWhereAdd = True
        End If

        'データ有効状態
        If isWhereAdd = True Then
            whereOrAdd = " and "
        Else
            whereOrAdd = "  WHERE ( "
        End If
        If CheckedListBoxDataEnable.GetItemChecked(0) = True Then
            sbSql.Append(whereOrAdd)
            sbSql.Append(" (a.データ有効 =True")
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.Append(" or a.データ有効 =False")
            End If
            sbSql.Append(")")
            isWhereAdd = True
        Else
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.Append(whereOrAdd)
                sbSql.Append(" (a.データ有効 =False)")
                isWhereAdd = True
            End If
        End If


        '部品形状名
        If isWhereAdd = True Then
            whereOrAdd = " and "
        Else
            whereOrAdd = "  WHERE ( "
        End If
        If CheckedListBoxShapeName.GetItemChecked(0) = True Then
            sbSql.Append(whereOrAdd)
            sbSql.Append(" (a.部品形状ID IS NOT NULL")
            If CheckedListBoxShapeName.GetItemChecked(1) = True Then
                sbSql.Append(" or a.部品形状ID IS NULL")
            End If
            sbSql.Append(")")
            isWhereAdd = True
        Else
            If CheckedListBoxShapeName.GetItemChecked(1) = True Then
                sbSql.Append(whereOrAdd)
                sbSql.Append(" (a.部品形状ID IS NULL)")
                isWhereAdd = True
            End If
        End If

        '部品画像
        If isWhereAdd = True Then
            whereOrAdd = " and "
        Else
            whereOrAdd = "  WHERE ( "
        End If
        If CheckedListBoxPartsImage.GetItemChecked(0) = True Then
            sbSql.Append(whereOrAdd)
            sbSql.Append(" (a.部材画像 =TRUE")
            If CheckedListBoxPartsImage.GetItemChecked(1) = True Then
                sbSql.Append(" or a.部材画像 =FALSE")
            End If
            sbSql.Append(")")
            isWhereAdd = True
        Else
            If CheckedListBoxPartsImage.GetItemChecked(1) = True Then
                sbSql.Append(whereOrAdd)
                sbSql.Append(" ( a.部材画像 =FALSE)")
                isWhereAdd = True
            End If
        End If


        'カンコツファイル
        If isWhereAdd = True Then
            whereOrAdd = " and "
        Else
            whereOrAdd = "  WHERE ( "
        End If
        If CheckedListBoxKankotsu.GetItemChecked(0) = True Then
            sbSql.Append(whereOrAdd)
            sbSql.Append(" (a.カンコツファイル =TRUE")
            If CheckedListBoxKankotsu.GetItemChecked(1) = True Then
                sbSql.Append(" or a.カンコツファイル =FALSE")
            End If
            sbSql.Append(")")
            isWhereAdd = True
        Else
            If CheckedListBoxKankotsu.GetItemChecked(1) = True Then
                sbSql.Append(whereOrAdd)
                sbSql.Append(" ( a.カンコツファイル =FALSE)")
                isWhereAdd = True
            End If
        End If

        '分類
        If CtrlShapeCategoryCombobox.MyCombobox.Text <> "" Then
            If isWhereAdd = False Then
                sbSql.Append(" where ")
            Else
                sbSql.Append(" and ")
            End If
            sbSql.Append(" e.部品形状分類名称='" & CtrlShapeCategoryCombobox.MyCombobox.Text & "'")
        End If

        '品名
        If TextBoxPartsName.Text <> "" Then
            If isWhereAdd = False Then
                sbSql.Append(" where ")
            Else
                sbSql.Append(" and ")
            End If
            sbSql.Append(" (a.品名 like '%" & TextBoxPartsName.Text & "%')")
        End If


        If isWhereAdd = True Then
            sbSql.Append(")")
        End If

        sbSql.Append(" order by a.部材コード")
        Dim tb As DataTable = CtrlDbPartsMaster.GetTableData(sbSql.ToString, connectString)
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
    ''' <param name="partsCode">
    ''' 更新したいデータ（新規の場合はNothingを指定）
    ''' </param>
    ''' <remarks></remarks>
    Private Sub OpenEditDataForm(ByVal isNewdata As Boolean, ByVal partsCode As String)
        Dim fm As FormEditPartsData = New FormEditPartsData(isNewdata, partsCode, CtrlDbNaviMaster, CtrlDbPartsMaster)
        Dim dresult As DialogResult
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

    ''' <summary>
    ''' partsCodeで指定した部材データをテーブルから削除する
    ''' </summary>
    ''' <param name="partsCode">
    ''' データベースから削除する部材コード
    ''' </param>
    ''' <returns>
    ''' True:挿入成功
    ''' False:挿入失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function DeletePartsShapeDataFromDB(ByVal partsCode As String) As Boolean
        Dim isCompleteUpdate As Boolean = False

        '接続文字列作成
        Dim connect_txt As String = CtrlDbPartsMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDbPartsMaster.GetMasterDbPathString()

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
            sqlUserTableString = GetDeleteSqlPartsMasterFromTable(partsCode)
            sqlCmd.CommandText = sqlUserTableString
            sqlCmd.ExecuteNonQuery() '実行

            '他のテーブルで使用されていないか確認が必要
            MessageBox.Show("他のテーブルで使用されていないか確認が必要です！")

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
    ''' partsCodeで指定した部材マスタデータをテーブルから削除するSQL文を取得する
    ''' </summary>
    ''' <param name="partsCode">
    ''' 削除する部材コード文字列
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetDeleteSqlPartsMasterFromTable(ByVal partsCode As String) As String
        Dim sbSql As New System.Text.StringBuilder()

        sbSql.Append("DELETE FROM " & CtrlDbPartsMaster.DefPtMstDb.TablePartsMaster & " WHERE ")
        sbSql.Append("部材コード='" & partsCode.ToString & "'")

        Return sbSql.ToString

    End Function

    ''' <summary>
    ''' DataGridViewセル書式設定処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting

        Dim dataEnableColValue As Boolean
        Dim boardImageRegistColValue As Boolean
        Dim kankotsuFileRegistColValue As Boolean
        Dim partsShapeNameColValue As String = Nothing
        Try
            dataEnableColValue = DataGridView("データ有効", e.RowIndex).Value
            boardImageRegistColValue = DataGridView("部材画像", e.RowIndex).Value
            kankotsuFileRegistColValue = DataGridView("カンコツファイル", e.RowIndex).Value
        Catch ex As Exception
            dataEnableColValue = False
            boardImageRegistColValue = False
            partsShapeNameColValue = False
        End Try
        If DataGridView("部品形状名", e.RowIndex).Value IsNot DBNull.Value Then
            partsShapeNameColValue = DataGridView("部品形状名", e.RowIndex).Value
        End If
        Dim headercellname As String = Nothing
        headercellname = DataGridView.Columns(e.ColumnIndex).HeaderCell.Value

        'セルの値により、背景色を変更する
        If dataEnableColValue = True Then
            DataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            Select Case headercellname
                Case "部品形状名"
                    If partsShapeNameColValue = Nothing Then
                        DataGridView(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Orange
                    End If
                Case "部材画像"
                    If boardImageRegistColValue = False Then
                        DataGridView(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Orange
                    End If
                Case "カンコツファイル"
                    If kankotsuFileRegistColValue = False Then
                        DataGridView(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Orange
                    End If
            End Select

        Else
            DataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        End If


    End Sub

    Private Sub ButtonExtractData_Click(sender As Object, e As EventArgs) Handles ButtonExtractData.Click
        RefreshDgv()
    End Sub

End Class