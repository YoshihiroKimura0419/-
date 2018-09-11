Public Class FormMenteDrawingMaster
    'マスターデータ操作用
    Private CtrlDbMaster As ControlDbMaster

    '図面マスターデータ操作用
    Private CtrlDbDrawingMaster As ControlDbDrawingMaster

    Private CtrlDgv As ControlDataGridView = New ControlDataGridView

    Private FormOpenMode As Integer = FormMenteDrawingMasterOpenMode.Edit

    '選択基板名称
    Public SelectedBoardName As String = Nothing

    Public Sub New(ByVal mstContDb As ControlDbMaster, ByVal mode As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Dim defDrawingMasterDb As New DefineDrawingMasterDb
        CtrlDbDrawingMaster = New ControlDbDrawingMaster(defDrawingMasterDb)
        CtrlDbDrawingMaster.DefMstDb.DbPath = mstContDb.DefMstDb.DbPath
        CtrlDbMaster = mstContDb
        FormOpenMode = mode
    End Sub

    Private Sub FormMenteDrawingMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeCheckedListBoxChecked()
        InitializeComboBoxAndOr()
        SettingDgvMain()
        SetControlVisible(FormOpenMode)
    End Sub
    Private Sub SetControlVisible(ByVal mode As Integer)
        Select Case mode
            Case FormMenteDrawingMasterOpenMode.Edit
                ButtonEditData.Visible = True
                ButtonAddNewData.Visible = True
                ButtonDeleteData.Visible = True
                ButtonOpenNavidataEdit.Visible = True
                ButtonSelectModeOK.Visible = False
                ButtonSelectModeCancel.Visible = False
            Case FormMenteDrawingMasterOpenMode.DataSelect
                ButtonEditData.Visible = False
                ButtonAddNewData.Visible = False
                ButtonDeleteData.Visible = False
                ButtonOpenNavidataEdit.Visible = False
                ButtonSelectModeOK.Visible = True
                ButtonSelectModeCancel.Visible = True
        End Select
    End Sub
    Private Sub InitializeComboBoxAndOr()
        ComboBoxAndOr1.SelectedIndex = 0
        ComboBoxAndOr2.SelectedIndex = 0
        ComboBoxAndOr3.SelectedIndex = 0
    End Sub

    Private Sub InitializeCheckedListBoxChecked()
        CheckedListBoxDataEnable.SetItemChecked(0, True)
        CheckedListBoxDataEnable.SetItemChecked(1, True)

        CheckedListBoxDrawingImageRegisted.SetItemChecked(0, True)
        CheckedListBoxDrawingImageRegisted.SetItemChecked(1, True)

        CheckedListBoxBoardImageRegisted.SetItemChecked(0, True)
        CheckedListBoxBoardImageRegisted.SetItemChecked(1, True)

        CheckedListBoxShogenhyoRegisted.SetItemChecked(0, True)
        CheckedListBoxShogenhyoRegisted.SetItemChecked(1, True)

        CheckedListBoxNetlistRegisted.SetItemChecked(0, True)
        CheckedListBoxNetlistRegisted.SetItemChecked(1, True)

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
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.Id),
                                 DITColumnName(DITColmun.Id),
                                 DITColumnName(DITColmun.Id),
                                 True)
        'データ有効列列追加
        Dim dataEnableTable As New DataTable()
        dataEnableTable = CtrlDbMaster.GetEnableTable("利用中", "利用停止")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  dataEnableTable,
                                  DITColumnName(DITColmun.DataEnable),
                                  DITColumnName(DITColmun.DataEnable),
                                  DITColumnName(DITColmun.DataEnable),
                                  "Value", "Display", True)
        '部品名
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.DrawingNumber),
                                 DITColumnName(DITColmun.DrawingNumber),
                                 DITColumnName(DITColmun.DrawingNumber),
                                 True)
        '部品型名
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.DrawingRevision),
                                 DITColumnName(DITColmun.DrawingRevision),
                                 DITColumnName(DITColmun.DrawingRevision),
                                 True)

        '基板名称
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.BoardName),
                                 DITColumnName(DITColmun.BoardName),
                                 DITColumnName(DITColmun.BoardName),
                                 True)

        '基板横サイズ
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.BoardWidth),
                                 DITColumnName(DITColmun.BoardWidth),
                                 DITColumnName(DITColmun.BoardWidth),
                                 True)
        '基板縦サイズ
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.BoardHeight),
                                 DITColumnName(DITColmun.BoardHeight),
                                 DITColumnName(DITColmun.BoardHeight),
                                 True)

        '最大同時制作数
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.MaxLot),
                                 DITColumnName(DITColmun.MaxLot),
                                 DITColumnName(DITColmun.MaxLot),
                                 True)

        '図面画像登録
        Dim boardImageRegistTable As New DataTable()
        boardImageRegistTable = CtrlDbMaster.GetEnableTable("登録済", "登録未")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  boardImageRegistTable,
                                  DITColumnName(DITColmun.RegistImageDrawing),
                                  DITColumnName(DITColmun.RegistImageDrawing),
                                  DITColumnName(DITColmun.RegistImageDrawing),
                                  "Value", "Display", True)

        '基板画像登録
        Dim boardImageExistTable As New DataTable()
        boardImageExistTable = CtrlDbMaster.GetEnableTable("登録済", "登録未")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  boardImageExistTable,
                                  DITColumnName(DITColmun.RegistImageBoard),
                                  DITColumnName(DITColmun.RegistImageBoard),
                                  DITColumnName(DITColmun.RegistImageBoard),
                                  "Value", "Display", True)

        '諸元表登録
        Dim shogenhyouRegistTable As New DataTable()
        shogenhyouRegistTable = CtrlDbMaster.GetEnableTable("登録済", "登録未")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  shogenhyouRegistTable,
                                  DITColumnName(DITColmun.RegistShogenhyo),
                                  DITColumnName(DITColmun.RegistShogenhyo),
                                  DITColumnName(DITColmun.RegistShogenhyo),
                                  "Value", "Display", True)

        'NETリスト表登録
        Dim netlistRegistTable As New DataTable()
        netlistRegistTable = CtrlDbMaster.GetEnableTable("登録済", "登録未")
        CtrlDgv.AddComboboxColumn(DataGridView,
                                  netlistRegistTable,
                                  DITColumnName(DITColmun.RegistNetlist),
                                  DITColumnName(DITColmun.RegistNetlist),
                                  DITColumnName(DITColmun.RegistNetlist),
                                  "Value", "Display", True)

        '備考
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.Note),
                                 DITColumnName(DITColmun.Note),
                                 DITColumnName(DITColmun.Note),
                                 True)
        '変更履歴
        CtrlDgv.AddTextboxColumn(DataGridView,
                                 DITColumnName(DITColmun.ChangeHistory),
                                 DITColumnName(DITColmun.ChangeHistory),
                                 DITColumnName(DITColmun.ChangeHistory),
                                 True)


        '登録者情報列追加
        CtrlDgv.AddRegisterInfoTextboxColoumn(DataGridView)
    End Sub
    ''' <summary>
    ''' DataGridViewの表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDgv()
        Dim whereOrAdd As String = Nothing

        'DataGridView.DataSource = ""
        '接続文字列作成
        Dim connectString As String = CtrlDbDrawingMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNameDrawing As String = CtrlDbDrawingMaster.GetMasterDbPathString()
        Dim dbNameMaster As String = CtrlDbMaster.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(GetSqlSelectItem(DITColumnName(DITColmun.Id)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.DataEnable)))

        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.DrawingNumber)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.DrawingRevision)))

        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.BoardName)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.BoardWidth)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.BoardHeight)))

        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.RegistImageDrawing)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.RegistImageBoard)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.RegistShogenhyo)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.RegistNetlist)))

        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.Note)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.ChangeHistory)))
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.MaxLot)))

        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.RegistDate)))

        sbSql.AppendLine(",b." & UDTColumnName(UDTColumn.UserName) & " as 登録者")
        sbSql.AppendLine("," & GetSqlSelectItem(DITColumnName(DITColmun.UpdateDate)))
        sbSql.AppendLine(",c." & UDTColumnName(UDTColumn.UserName) & " as 更新者")

        sbSql.AppendLine(" FROM ")

        '更新者結合-----------------------------------------
        sbSql.AppendLine("(")
        '登録者結合-----------------------------------------
        sbSql.AppendLine("(")
        sbSql.AppendLine(dbNameDrawing & ".[" & CtrlDbDrawingMaster.DefMstDb.TabaleDrawingInfo & "] as a")
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameMaster & ".[" & CtrlDbMaster.DefMstDb.TableUser & "] as b")
        sbSql.AppendLine(" ON (a." & DITColumnName(DITColmun.RegistManNumber) & "=b." & UDTColumnName(UDTColumn.ManNumber) & ")")
        sbSql.AppendLine(")")
        '登録者結合--------------------------------------END
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameMaster & ".[" & CtrlDbMaster.DefMstDb.TableUser & "] as c")
        sbSql.AppendLine(" ON (a." & DITColumnName(DITColmun.UpdateManNumber) & "=c." & UDTColumnName(UDTColumn.ManNumber) & ")")
        sbSql.AppendLine(")")
        '更新者結合--------------------------------------END

        Dim isWhereAdd As Boolean = False

        '図面番号指定
        sbSql.AppendLine(GetSqlTextBox(TextBoxDrawingNo, DITColumnName(DITColmun.DrawingNumber), isWhereAdd))

        '副番
        sbSql.AppendLine(GetSqlTextBox(TextBoxRevision, DITColumnName(DITColmun.DrawingRevision), isWhereAdd))

        '基板名称
        sbSql.AppendLine(GetSqlTextBox(TextBoxBoardName, DITColumnName(DITColmun.BoardName), isWhereAdd))


        'データ有効状態
        If isWhereAdd = True Then
            whereOrAdd = " and "
        Else
            whereOrAdd = "  WHERE ( "
        End If
        If CheckedListBoxDataEnable.GetItemChecked(0) = True Then
            sbSql.AppendLine(whereOrAdd)
            sbSql.AppendLine(" (a." & DITColumnName(DITColmun.DataEnable) & "=TRUE")
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.AppendLine(" or a." & DITColumnName(DITColmun.DataEnable) & " =FALSE")
            End If
            sbSql.AppendLine(")")
            isWhereAdd = True
        Else
            If CheckedListBoxDataEnable.GetItemChecked(1) = True Then
                sbSql.AppendLine(whereOrAdd)
                sbSql.AppendLine(" (a." & DITColumnName(DITColmun.DataEnable) & "=FALSE)")
                isWhereAdd = True
            End If
        End If


        '本項目以降は、or条件で連結
        '図面画像登録
        sbSql.AppendLine(GetSqlCheckedListbox(CheckedListBoxDrawingImageRegisted, DITColumnName(DITColmun.RegistImageDrawing), Nothing, whereOrAdd, isWhereAdd))
        sbSql.AppendLine(GetSqlCheckedListbox(CheckedListBoxBoardImageRegisted, DITColumnName(DITColmun.RegistImageBoard), ComboBoxAndOr1, whereOrAdd, isWhereAdd))
        sbSql.AppendLine(GetSqlCheckedListbox(CheckedListBoxShogenhyoRegisted, DITColumnName(DITColmun.RegistShogenhyo), ComboBoxAndOr2, whereOrAdd, isWhereAdd))
        sbSql.AppendLine(GetSqlCheckedListbox(CheckedListBoxNetlistRegisted, DITColumnName(DITColmun.RegistNetlist), ComboBoxAndOr3, whereOrAdd, isWhereAdd))

        If isWhereAdd = True Then
            sbSql.AppendLine(")")
        End If

        sbSql.AppendLine(" order by a." & DITColumnName(DITColmun.DrawingNumber) & ",a." & DITColumnName(DITColmun.DrawingRevision))
        Dim tb As DataTable = CtrlDbDrawingMaster.GetTableData(sbSql.ToString, connectString)
        If tb IsNot Nothing Then
            CtrlDgv.BindTableToDgv(DataGridView, tb)
        End If
    End Sub
    Private Function GetSqlSelectItem(ByVal colmunName As String) As String
        Return "a." & colmunName & " as " & colmunName
    End Function
    Private Function GetSqlTextBox(ByRef tbox As TextBox, ByVal colmunName As String, ByRef isWhereAdd As Boolean) As String
        Dim sbSql As New Text.StringBuilder

        '図面番号指定
        If tbox.Text <> "" Then
            If isWhereAdd = False Then
                sbSql.AppendLine(" where (")
                isWhereAdd = True
            Else
                sbSql.AppendLine(" and ")
            End If
            sbSql.AppendLine(" (a." & colmunName & " like '%" & tbox.Text & "%')")
        End If
        Return sbSql.ToString
    End Function
    Private Function GetSqlCheckedListbox(ByRef clb As CheckedListBox, ByVal colmunName As String, ByRef cb As ComboBox,
                                          ByRef whereOrAdd As String, ByRef isWhereAdd As Boolean) As String
        Dim sbSql As New Text.StringBuilder


        If isWhereAdd = True Then
            If cb IsNot Nothing Then
                Select Case cb.SelectedIndex
                    Case 0
                        whereOrAdd = " and "
                    Case 1
                        whereOrAdd = " or "
                End Select
            Else
                whereOrAdd = " and "
            End If
        Else
            whereOrAdd = "  WHERE ( "
        End If

        If clb.GetItemChecked(0) = True Then
            sbSql.AppendLine(whereOrAdd)
            sbSql.AppendLine(" (a." & colmunName & "=TRUE")
            If clb.GetItemChecked(1) = True Then
                sbSql.AppendLine(" or a." & colmunName & " =FALSE")
            End If
            sbSql.AppendLine(")")
            isWhereAdd = True
        Else
            If clb.GetItemChecked(1) = True Then
                sbSql.AppendLine(whereOrAdd)
                sbSql.AppendLine(" ( a." & colmunName & " =FALSE)")
                isWhereAdd = True
            End If
        End If
        Return sbSql.ToString

    End Function

    ''' <summary>
    ''' データ編集用フォームを開く
    ''' </summary>
    ''' <param name="mode">
    ''' 編集フォームを開くモードを選択
    ''' True:新規ユーザーデータ登録モード
    ''' False:既存ユーザーデータ更新モード
    ''' </param>
    ''' <param name="id">
    ''' 更新したいデータ（新規の場合はNothingを指定）
    ''' </param>
    ''' <param name="rev">
    ''' 図面副番を変更する場合に指定する副番（図面副番を変更しない場合はNothingを指定）
    ''' </param>
    ''' <remarks></remarks>
    Private Sub OpenEditDataForm(ByVal mode As Integer, ByVal id As Integer, ByVal rev As String)
        Dim dresult As DialogResult
        Try
            Using fm As FormEditDrawingData = New FormEditDrawingData(mode, id, rev, CtrlDbMaster, CtrlDbDrawingMaster)
                dresult = fm.ShowDialog(Me)

                If fm IsNot Nothing Then
                    fm.Dispose()
                End If
                If dresult = Windows.Forms.DialogResult.OK Then
                    RefreshDgv()
                    Select Case mode
                        Case DrawingInfoEditMode.CreateNewData
                            MessageBox.Show("新規を登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case DrawingInfoEditMode.ContentsEdit
                            MessageBox.Show("データを更新しました。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case DrawingInfoEditMode.DrawingRevisionUpdate
                            MessageBox.Show("図面副番を変更しデータを登録しました。", "データ登録（副番変更）", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case DrawingInfoEditMode.Browsing
                            MessageBox.Show("図面情報閲覧画面を閉じました。", "図面データ閲覧", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MessageBox.Show("新規作成／編集処理を中断しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


    ''' <summary>
    ''' idで指定した図面マスターデータをテーブルから削除する
    ''' </summary>
    ''' <param name="id">
    ''' データベースから削除する図面番号
    ''' </param>
    ''' <returns>
    ''' True:削除成功
    ''' False:削除失敗
    ''' </returns>
    ''' <remarks></remarks>
    Private Function DeleteDrawingDataFromDB(ByVal id As Integer) As Boolean
        Dim isCompleteUpdate As Boolean = False

        '接続文字列作成
        Dim connect_txt As String = CtrlDbDrawingMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDbDrawingMaster.GetMasterDbPathString()

        Dim oleCon As New System.Data.OleDb.OleDbConnection(connect_txt)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            'ユーザー管理テーブル
            sqlCmd.CommandText = GetDeleteSqlDrawingMasterFromTable(id)
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
    ''' idで指定した図面マスタデータをテーブルから削除するSQL文を取得する
    ''' </summary>
    ''' <param name="id">
    ''' 削除する図面ＩＤ
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetDeleteSqlDrawingMasterFromTable(ByVal id As Integer) As String
        Dim sbSql As New System.Text.StringBuilder()

        sbSql.AppendLine("DELETE FROM " & CtrlDbDrawingMaster.DefMstDb.TabaleDrawingInfo & " WHERE ")
        sbSql.AppendLine("ID=" & id.ToString)

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

    Private Sub ButtonExtractData_Click(sender As Object, e As EventArgs) Handles ButtonExtractData.Click
        RefreshDgv()
    End Sub

    Private Sub ButtonEditData_Click(sender As Object, e As EventArgs) Handles ButtonEditData.Click
        OpenDrawingDataEditFormMain()
    End Sub
    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        Dim dResult As DialogResult
        Dim mess As New System.Text.StringBuilder
        Select Case FormOpenMode
            Case FormMenteDrawingMasterOpenMode.Edit
                mess.AppendLine("　　項目を選択して下さい。")
                mess.AppendLine("－－－－－－－－－－－－－－")
                mess.AppendLine("　はい　　　：図面情報編集")
                mess.AppendLine("　いいえ　　：なびデータ編集")
                mess.AppendLine("　キャンセル：中止")
                dResult = MessageBox.Show(mess.ToString, "選択", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                Select Case dResult
                    Case DialogResult.Yes
                        OpenDrawingDataEditFormMain()
                    Case DialogResult.No
                        OpenNavidataEditFormMain()
                    Case DialogResult.Cancel
                End Select
            Case FormMenteDrawingMasterOpenMode.DataSelect
                mess.AppendLine("　　項目を選択して下さい。")
                mess.AppendLine("－－－－－－－－－－－－－－")
                mess.AppendLine("　はい　　　：データ選択")
                mess.AppendLine("　いいえ　　：図面データ閲覧")
                mess.AppendLine("　キャンセル：中止")
                dResult = MessageBox.Show(mess.ToString, "選択", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                Select Case dResult
                    Case DialogResult.Yes
                        SelectedBoardName = GetSelectBoardName()
                        If SelectedBoardName IsNot Nothing Then
                            Me.DialogResult = DialogResult.OK
                        End If
                    Case DialogResult.No
                        OpenDrawingDataEditFormMain()
                    Case DialogResult.Cancel
                End Select
        End Select
    End Sub
    Private Function GetSelectBoardName() As String
        Dim mess As New System.Text.StringBuilder
        Dim boardName As String = Nothing

        If DataGridView(DITColumnName(DITColmun.BoardName), DataGridView.CurrentCell.RowIndex).Value IsNot DBNull.Value Then
            boardName = DataGridView(DITColumnName(DITColmun.BoardName), DataGridView.CurrentCell.RowIndex).Value
        Else
            mess.Clear()
            mess.AppendLine("選択データは、基板名が登録されていません。")
            mess.AppendLine("マスタメンテナンス画面で、データを編集してください。")
            MessageBox.Show(mess.ToString, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return boardName
    End Function
    Private Sub OpenNavidataEditFormMain()
        Dim indexRow As Integer = Nothing
        Dim indexCol As Integer = Nothing
        Dim id As Integer = Nothing

        Try
            indexRow = DataGridView.CurrentCell.RowIndex
            indexCol = DataGridView.CurrentCell.ColumnIndex
        Catch ex As Exception
            MessageBox.Show("データ更新する行が選択されていないか、データがありません。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        If indexRow = -1 Then Exit Sub
        Dim prdInfo As New ProductionInfomation
        prdInfo.Initialize()

        prdInfo.DrawingId = DataGridView(DITColumnName(DITColmun.Id), indexRow).Value
        Dim fm As FormEditNavidata = New FormEditNavidata(CtrlDbMaster, CtrlDbDrawingMaster, prdInfo, FormNaviMode.Edit)
        fm.ShowDialog()
        If fm IsNot Nothing Then
            fm.Dispose()
        End If

    End Sub
    ''' <summary>
    ''' 図面情報編集処理画面を開く処理メイン
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenDrawingDataEditFormMain()
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
        If indexRow = -1 Then Exit Sub

        Dim beforeRev As String = Nothing
        Dim id As Integer = Nothing

        id = DirectCast(DataGridView(DITColumnName(DITColmun.Id), indexRow).Value, Integer)
        If DataGridView(DITColumnName(DITColmun.DrawingRevision), indexRow).Value IsNot DBNull.Value Then
            beforeRev = DirectCast(DataGridView(DITColumnName(DITColmun.DrawingRevision), indexRow).Value, String)
        Else
            beforeRev = NoRevisionFolderName
        End If
        Dim dResult As DialogResult
        Dim inputRev As String = Nothing
        Select Case FormOpenMode
            Case FormMenteDrawingMasterOpenMode.DataSelect
                OpenEditDataForm(DrawingInfoEditMode.Browsing, id, Nothing)
            Case FormMenteDrawingMasterOpenMode.Edit
                dResult = MessageBox.Show("図面副番を変更しますか？", "変更確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

                If dResult = DialogResult.Yes Then
                    inputRev = InputBox("変更する図面の副番を入力してください。（現在副番：" & beforeRev & "）", "副番入力")
                    If inputRev = Nothing Then
                        MessageBox.Show("副番入力がありませんでしたので、処理を中断します。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    OpenEditDataForm(DrawingInfoEditMode.DrawingRevisionUpdate, id, inputRev)
                Else
                    OpenEditDataForm(DrawingInfoEditMode.ContentsEdit, id, Nothing)
                    nowRowsCount = DataGridView.Rows.Count
                    If 0 < nowRowsCount Then
                        If nowRowsCount <> previousRowsCount Then
                            If (nowRowsCount - 1) < indexRow Then
                                indexRow = nowRowsCount - 1
                            End If
                        End If
                        DataGridView.CurrentCell = DataGridView(indexCol, indexRow)
                    End If
                End If
        End Select
    End Sub

    Private Sub ButtonAddNewData_Click(sender As Object, e As EventArgs) Handles ButtonAddNewData.Click
        OpenEditDataForm(DrawingInfoEditMode.CreateNewData, -1, Nothing)
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

        '他で使われていないか確認が必要
        MessageBox.Show("他で使われていないか確認して下さい。")

        Dim id As Integer = DirectCast(DataGridView(DITColumnName(DITColmun.Id), indexRow).Value, Integer)
        Dim drawingNumber As String = DirectCast(DataGridView(DITColumnName(DITColmun.DrawingNumber), indexRow).Value, String)
        Dim rev As String = Nothing
        If DataGridView(DITColumnName(DITColmun.DrawingRevision), indexRow).Value IsNot DBNull.Value Then
            rev = DirectCast(DataGridView(DITColumnName(DITColmun.DrawingRevision), indexRow).Value, String)
        Else
            rev = NoRevisionFolderName
        End If
        If DeleteDrawingDataFromDB(id) = True Then
            '部材コードフォルダ削除
            Dim delFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\" & drawingNumber & "\" & rev
            Dim errMess As String = Nothing
            Do While True
                If DeleteFile(delFolder, errMess) <> 0 Then
                    Dim errMessDelete As New Text.StringBuilder
                    errMessDelete.AppendLine("図面データフォルダの削除が出来ませんでした。")
                    errMessDelete.AppendLine("詳細は、下記を参照して下さい。")
                    errMessDelete.AppendLine("リトライしますか？")
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

    Private Sub ButtonOpenNavidataEdit_Click(sender As Object, e As EventArgs) Handles ButtonOpenNavidataEdit.Click
        OpenNavidataEditFormMain()
    End Sub
End Class