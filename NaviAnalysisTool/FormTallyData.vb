Imports System.Windows.Forms.DataVisualization.Charting

Imports ManualInsertionNavi
Public Class FormTallyData
    Private DtUserComboboxDataSouce As DataTable
    Private DtBuComboboxDataSouce As DataTable

    Private OrderSource As New AutoCompleteStringCollection
    Private BoardNameSource As New AutoCompleteStringCollection
    Private HasFormLoaded As Boolean = False

    Private DtTallyData As DataTable

    Private CtrlDgv As New ControlDataGridView

    Private FormMode As Integer = TallyDataFomMode.PlanActual

    Private SumColName As String() = {"生産数(累積)", "計画数(累積)", "休日"}

    Private WorkTimeColName As String() = {
                                            "日付",
                                            "平均",
                                            "最大",
                                            "最小",
                                            "休日"
                                            }

    Private Enum SumCol
        Actual = 0
        Plan = 1
        Holiday = 2
    End Enum
    Private Enum WorkTimeCol
        WorkDate
        AveTime
        MinTime
        MaxTime
        Holiday
    End Enum

    Private Sub FromWorkTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HasFormLoaded = False
        SetDvgColum(FormMode)
        SetBuComboboxDataSouce()
        SetDateTimePicker()
        SetWokerNameComboboxDataSouce()
        SetGraph("未設定")
        HasFormLoaded = True
    End Sub
    Private Sub SetDvgColum(ByVal mode As Integer)
        Select Case mode
            Case TallyDataFomMode.PlanActual
                SetPlanActualDgvColumn()
            Case TallyDataFomMode.WorkTime
                SetWorkTimeDgvColumn()
        End Select
    End Sub
    Private Sub SetPlanActualDgvColumn()
        DataGridViewTalliyData.Columns.Clear()
        With CtrlDgv

            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 PPATColumnName(PPATColumn.ProductDate),
                                 PPATColumnName(PPATColumn.ProductDate),
                                 PPATColumnName(PPATColumn.ProductDate),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 PPATColumnName(PPATColumn.ProductionActural),
                                 PPATColumnName(PPATColumn.ProductionActural),
                                 PPATColumnName(PPATColumn.ProductionActural),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 PPATColumnName(PPATColumn.ProductionPlan),
                                 PPATColumnName(PPATColumn.ProductionPlan),
                                 PPATColumnName(PPATColumn.ProductionPlan),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 SumColName(SumCol.Actual),
                                 SumColName(SumCol.Actual),
                                 SumColName(SumCol.Actual),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 SumColName(SumCol.Plan),
                                 SumColName(SumCol.Plan),
                                 SumColName(SumCol.Plan),
                                 True
                                 )
        End With
        SetPlanActualDgvColumnFormat()
    End Sub
    Private Sub SetPlanActualDgvColumnFormat()
        For i As Integer = 0 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        DataGridViewTalliyData.Columns(PPATColumnName(PPATColumn.ProductionActural)).DefaultCellStyle.Format = "#,0"
        DataGridViewTalliyData.Columns(PPATColumnName(PPATColumn.ProductionPlan)).DefaultCellStyle.Format = "#,0"
        DataGridViewTalliyData.Columns(SumColName(SumCol.Actual)).DefaultCellStyle.Format = "#,0"
        DataGridViewTalliyData.Columns(SumColName(SumCol.Plan)).DefaultCellStyle.Format = "#,0"

        For i As Integer = 0 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Next

        DataGridViewTalliyData.Columns(0).Width = 70
        For i As Integer = 1 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.Columns(i).Width = 100
        Next

    End Sub
    Private Sub SetWorkTimeDgvColumn()
        DataGridViewTalliyData.Columns.Clear()
        With CtrlDgv
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 WorkTimeColName(WorkTimeCol.WorkDate),
                                 WorkTimeColName(WorkTimeCol.WorkDate),
                                 WorkTimeColName(WorkTimeCol.WorkDate),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 WorkTimeColName(WorkTimeCol.AveTime),
                                 WorkTimeColName(WorkTimeCol.AveTime),
                                 WorkTimeColName(WorkTimeCol.AveTime),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 WorkTimeColName(WorkTimeCol.MinTime),
                                 WorkTimeColName(WorkTimeCol.MinTime),
                                 WorkTimeColName(WorkTimeCol.MinTime),
                                 True
                                 )
            CtrlDgv.AddTextboxColumn(DataGridViewTalliyData,
                                 WorkTimeColName(WorkTimeCol.MaxTime),
                                 WorkTimeColName(WorkTimeCol.MaxTime),
                                 WorkTimeColName(WorkTimeCol.MaxTime),
                                 True
                                 )
        End With
        SetWorkTimeDgvColumnFormat()
    End Sub
    Private Sub SetWorkTimeDgvColumnFormat()
        For i As Integer = 0 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        DataGridViewTalliyData.Columns(WorkTimeColName(WorkTimeCol.AveTime)).DefaultCellStyle.Format = "0.0"
        DataGridViewTalliyData.Columns(WorkTimeColName(WorkTimeCol.MinTime)).DefaultCellStyle.Format = "0.0"
        DataGridViewTalliyData.Columns(WorkTimeColName(WorkTimeCol.MaxTime)).DefaultCellStyle.Format = "0.0"

        For i As Integer = 0 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Next

        DataGridViewTalliyData.Columns(0).Width = 70
        For i As Integer = 1 To DataGridViewTalliyData.ColumnCount - 1
            DataGridViewTalliyData.Columns(i).Width = 100
        Next

    End Sub

    Private Sub SetDateTimePicker()
        DateTimePickerStart.Value = Date.Today.AddMonths(-1)
        DateTimePickerEnd.Value = Date.Today
    End Sub
    Private Sub SetBuComboboxDataSouce()
        DtBuComboboxDataSouce = CtrlDbOrder.GetBuDataTable(False)
        Dim drow As DataRow = DtBuComboboxDataSouce.NewRow
        drow(BUMTColumnName(BUMTColumn.ID)) = -1
        drow(BUMTColumnName(BUMTColumn.BuName)) = DBNull.Value
        DtBuComboboxDataSouce.Rows.InsertAt(drow, 0)

        ComboBoxBuSelect.DataSource = DtBuComboboxDataSouce
        ComboBoxBuSelect.ValueMember = BUMTColumnName(BUMTColumn.ID)
        ComboBoxBuSelect.DisplayMember = BUMTColumnName(BUMTColumn.BuName)

    End Sub
    Private Sub SetWokerNameComboboxDataSouce()
        DtUserComboboxDataSouce = CtrlDbMaster.GetUserIdAndNameTable(False)
        Dim drow As DataRow = DtUserComboboxDataSouce.NewRow
        drow(UDTColumnName(UDTColumn.ManNumber)) = ""
        drow(UDTColumnName(UDTColumn.UserName)) = DBNull.Value
        DtUserComboboxDataSouce.Rows.InsertAt(drow, 0)

        ComboBoxWokerName.DataSource = DtUserComboboxDataSouce
        ComboBoxWokerName.ValueMember = UDTColumnName(UDTColumn.ManNumber)
        ComboBoxWokerName.DisplayMember = UDTColumnName(UDTColumn.UserName)
    End Sub

    Private Sub ComboBoxBuSelect_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxBuSelect.SelectedValueChanged
        SetTextBoxAutoComplete()
    End Sub
    Private Sub SetTextBoxAutoComplete()
        If HasFormLoaded = False Then
            Exit Sub
        End If
        SetTextBoxOrderAutoComplete(CDate(DateTimePickerStart.Value), CDate(DateTimePickerEnd.Value), ComboBoxBuSelect.SelectedValue)
        SetTextBoxBoardNameAutoComplete(CDate(DateTimePickerStart.Value), CDate(DateTimePickerEnd.Value), ComboBoxBuSelect.SelectedValue)
    End Sub
    Private Sub SetTextBoxOrderAutoComplete(ByVal startDate As Date, ByVal endDate As Date, ByVal buId As Integer)
        Dim orderList As New List(Of String)
        'Dim getStatus As Boolean = CtrlDbOrder.GetOrderList(buId, orderList)

        Dim getStatus As Boolean = GetOrderList(startDate, endDate, buId, orderList)

        If getStatus = False Then
            Me.Close()
        End If
        With TextBoxOrder
            .AutoCompleteCustomSource.Clear()
        End With

        OrderSource.Clear()
        For Each str As String In orderList
            OrderSource.Add(str)
        Next
        With TextBoxOrder
            .AutoCompleteCustomSource = OrderSource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With
    End Sub

    Private Function GetOrderList(ByVal startDate As Date, ByVal endDate As Date, ByVal buId As Integer, ByRef orderList As List(Of String)) As Boolean
        '接続文字列取得
        Dim connect_txt As String = CtrlDbPpa.GetMasterDbConnectString()
        Dim dbNamePpa As String = CtrlDbPpa.GetMasterDbPathString
        Dim dbNameOrder As String = CtrlDbOrder.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("distinct")
        sbSql.AppendLine(String.Format("a.{0} as {1},", PPATColumnName(PPATColumn.Order), PPATColumnName(PPATColumn.Order)))
        sbSql.AppendLine(String.Format("b.{0} as {1}", BUMTColumnName(BUMTColumn.BuName), BUMTColumnName(BUMTColumn.BuName)))

        sbSql.AppendLine("FROM")
        sbSql.AppendLine(String.Format(" {0}.[{1}] as a", dbNamePpa, CtrlDbPpa.DefPpaDb.TablePlanActual))
        sbSql.AppendLine("left join ")
        sbSql.AppendLine(String.Format(" {0}.[{1}] as b", dbNameOrder, CtrlDbOrder.DefOrdDb.TableBu))
        sbSql.AppendLine("on ")
        sbSql.AppendLine(String.Format(" a.{0}=b.{1}", PPATColumnName(PPATColumn.BuId), BUMTColumnName(BUMTColumn.ID)))
        sbSql.AppendLine("where ")
        sbSql.AppendLine(String.Format(" a.{0}={1}", PPATColumnName(PPATColumn.BuId), buId))
        sbSql.AppendLine("and")
        sbSql.AppendLine("(")
        sbSql.AppendLine(String.Format(" a.{0}>=#{1}#", PPATColumnName(PPATColumn.ProductDate), startDate.ToShortDateString))
        sbSql.AppendLine(" and")
        sbSql.AppendLine(String.Format(" a.{0}<=#{1}#", PPATColumnName(PPATColumn.ProductDate), endDate.ToShortDateString))
        sbSql.AppendLine(")")

        sbSql.AppendLine("order by")
        sbSql.AppendLine(String.Format(" a.{0}", PPATColumnName(PPATColumn.Order)))

        Dim dt As DataTable = CtrlDbPpa.GetTableData(sbSql.ToString, connect_txt)
        If dt.Columns.Count < 1 Then
            Return False
        End If
        For Each row As DataRow In dt.Rows
            If row(OMTColumnName(OMTColumn.Order)) IsNot DBNull.Value Then
                orderList.Add(row(OMTColumnName(OMTColumn.Order)))
            End If
        Next
        Return True
    End Function

    Private Sub DateTimePicker_Validated(sender As Object, e As EventArgs) Handles DateTimePickerStart.Validated, DateTimePickerEnd.Validated
        SetTextBoxAutoComplete()
    End Sub

    Private Sub DateTimePicker_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerStart.Validating, DateTimePickerEnd.Validating
        If HasFormLoaded = False Then
            Exit Sub
        End If
        If DateTimePickerStart.Value > DateTimePickerEnd.Value Then
            MessageBox.Show("開始日<=終了日となるようにしてください。", "日付設定確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub
    Private Sub SetTextBoxBoardNameAutoComplete(ByVal startDate As Date, ByVal endDate As Date, ByVal buId As Integer)
        Dim boardList As New List(Of String)
        'Dim getStatus As Boolean = CtrlDbOrder.GetOrderList(buId, orderList)

        Dim getStatus As Boolean = GetBoardNameList(startDate, endDate, buId, boardList)

        If getStatus = False Then
            Me.Close()
        End If
        With TextBoxBoardName
            .AutoCompleteCustomSource.Clear()
        End With

        BoardNameSource.Clear()
        For Each str As String In boardList
            BoardNameSource.Add(str)
        Next
        With TextBoxBoardName
            .AutoCompleteCustomSource = BoardNameSource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With
    End Sub

    Private Function GetBoardNameList(ByVal startDate As Date, ByVal endDate As Date, ByVal buId As Integer, ByRef orderList As List(Of String)) As Boolean
        '接続文字列取得
        Dim connect_txt As String = CtrlDbPpa.GetMasterDbConnectString()
        Dim dbNamePpa As String = CtrlDbPpa.GetMasterDbPathString

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("distinct")
        sbSql.AppendLine(String.Format("a.{0} as {1}", PPATColumnName(PPATColumn.BoardName), PPATColumnName(PPATColumn.BoardName)))

        sbSql.AppendLine("FROM")
        sbSql.AppendLine(String.Format(" {0}.[{1}] as a", dbNamePpa, CtrlDbPpa.DefPpaDb.TablePlanActual))

        sbSql.AppendLine("where ")
        sbSql.AppendLine(String.Format(" a.{0}={1}", PPATColumnName(PPATColumn.BuId), buId))
        sbSql.AppendLine("and")
        sbSql.AppendLine("(")
        sbSql.AppendLine(String.Format(" a.{0}>=#{1}#", PPATColumnName(PPATColumn.ProductDate), startDate.ToShortDateString))
        sbSql.AppendLine(" and")
        sbSql.AppendLine(String.Format(" a.{0}<=#{1}#", PPATColumnName(PPATColumn.ProductDate), endDate.ToShortDateString))
        sbSql.AppendLine(")")

        sbSql.AppendLine("order by")
        sbSql.AppendLine(String.Format(" a.{0}", PPATColumnName(PPATColumn.BoardName)))

        Dim dt As DataTable = CtrlDbPpa.GetTableData(sbSql.ToString, connect_txt)
        If dt.Columns.Count < 1 Then
            Return False
        End If
        For Each row As DataRow In dt.Rows
            If row(PPATColumnName(PPATColumn.BoardName)) IsNot DBNull.Value Then
                orderList.Add(row(PPATColumnName(PPATColumn.BoardName)))
            End If
        Next
        Return True
    End Function

    Private Sub ButtonTallyData_Click(sender As Object, e As EventArgs) Handles ButtonTallyData.Click, ButtonOutputExcel.Click
        '条件あったデータを生産計画DBから抽出する。
        Select Case FormMode
            Case TallyDataFomMode.PlanActual

                DtTallyData = GetPlanAcutualTalliedData(
                                                        CDate(DateTimePickerStart.Value),
                                                        CDate(DateTimePickerEnd.Value),
                                                        ComboBoxBuSelect.SelectedValue,
                                                        TextBoxOrder.Text,
                                                        ComboBoxWokerName.SelectedValue
                                                        )
            Case TallyDataFomMode.WorkTime
                DtTallyData = GetWorkTimeTalliedData(
                                                     CDate(DateTimePickerStart.Value),
                                                     CDate(DateTimePickerEnd.Value),
                                                     TextBoxBoardName.Text,
                                                     TextBoxOrder.Text,
                                                     ComboBoxWokerName.SelectedValue
                                                     )
        End Select

        If DtTallyData Is Nothing Then
            Exit Sub
        End If
        CtrlDgv.BindTableToDgv(DataGridViewTalliyData, DtTallyData)


        Select Case FormMode
            Case TallyDataFomMode.PlanActual
                SetPlanAcutualChartSeries(DtTallyData)
            Case TallyDataFomMode.WorkTime
                SetWorkTimeChartSeries(DtTallyData)
        End Select



    End Sub
    ''' <summary>
    ''' 生産計画・実績トレンドデータを集計する。
    ''' </summary>
    ''' <param name="startDate">
    ''' 集計開始日
    ''' </param>
    ''' <param name="endDate">
    ''' 集計終了日
    ''' </param>
    ''' <param name="buId">
    ''' 集計BUのID
    ''' </param>
    ''' <param name="order">
    ''' 集計オーダー
    ''' </param>
    ''' <param name="workerManNumber">
    ''' 集計条件の作業者マンナンバー
    ''' </param>
    ''' <returns>
    ''' 集計したDataTable
    ''' 集計に失敗した場合は、Nothing
    ''' </returns>
    Private Function GetPlanAcutualTalliedData(ByVal startDate As Date, ByVal endDate As Date, ByVal buId As Integer, ByVal order As String, ByVal workerManNumber As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = CtrlDbPpa.GetMasterDbConnectString()
        Dim dbNamePpa As String = CtrlDbPpa.GetMasterDbPathString
        Dim whereAdd As Boolean = False
        Dim whereOrAndStr As String = "where"

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(String.Format("format(a.{0},'yyyy/MM/dd') as {1},", PPATColumnName(PPATColumn.ProductDate), PPATColumnName(PPATColumn.ProductDate)))
        sbSql.AppendLine(String.Format("sum(a.{0}) as {1},", PPATColumnName(PPATColumn.ProductionPlan), PPATColumnName(PPATColumn.ProductionPlan)))
        sbSql.AppendLine(String.Format("sum(a.{0}) as {1}", PPATColumnName(PPATColumn.ProductionActural), PPATColumnName(PPATColumn.ProductionActural)))

        sbSql.AppendLine("FROM")
        sbSql.AppendLine(String.Format(" {0}.[{1}] as a", dbNamePpa, CtrlDbPpa.DefPpaDb.TablePlanActual))

        If buId <> -1 Then
            sbSql.AppendLine(whereOrAndStr)
            sbSql.AppendLine(String.Format(" a.{0}={1}", PPATColumnName(PPATColumn.BuId), buId))
            whereAdd = True
            whereOrAndStr = "and"
        End If

        sbSql.AppendLine(whereOrAndStr)
        sbSql.AppendLine("(")
        sbSql.AppendLine(String.Format(" a.{0}>=#{1}#", PPATColumnName(PPATColumn.ProductDate), startDate.ToShortDateString))
        sbSql.AppendLine(" and")
        sbSql.AppendLine(String.Format(" a.{0}<=#{1}#", PPATColumnName(PPATColumn.ProductDate), endDate.ToShortDateString))
        sbSql.AppendLine(")")

        If order <> "" Then
            sbSql.AppendLine(whereOrAndStr)
            sbSql.AppendLine(String.Format(" a.{0} like '%{1}%'", PPATColumnName(PPATColumn.Order), order))
        End If

        If workerManNumber <> "" Then
            sbSql.AppendLine(whereOrAndStr)
            sbSql.AppendLine(String.Format(" a.{0}='{1}'", PPATColumnName(PPATColumn.WorkerManNumber), workerManNumber))
        End If
        sbSql.AppendLine("group by")
        sbSql.AppendLine(String.Format(" a.{0}", PPATColumnName(PPATColumn.ProductDate)))

        sbSql.AppendLine("order by")
        sbSql.AppendLine(String.Format(" a.{0}", PPATColumnName(PPATColumn.ProductDate)))

        Dim dt As DataTable = CtrlDbPpa.GetTableData(sbSql.ToString, connect_txt)
        If dt.Columns.Count < 1 Then
            Return Nothing
        End If
        '抽出データは日付が非連続なので、連続日付データに変換する。
        ConvertPlanAcutualConsecutiveDateTalliedData(dt, startDate, endDate)

        Return dt
    End Function
    Private Function GetWorkTimeTalliedData(ByVal startDate As Date, ByVal endDate As Date, ByVal boardName As String, ByVal order As String, ByVal workerManNumber As String) As DataTable
        Dim dt As New DataTable
        '接続文字列取得
        Dim connect_txt As String
        Dim dbNameWlog As String
        Dim whereAdd As Boolean = False
        Dim whereOrAndStr As String
        Dim checkDate As Date = startDate
        Dim sbSql As New System.Text.StringBuilder
        Dim dbpath As String

        Do While checkDate <= endDate
            whereOrAndStr = "Where"
            connect_txt = CtrlDbWlog.GetWorkLogDbConnectString(checkDate.ToString("yyyyMM"))
            dbNameWlog = CtrlDbWlog.GetSqlWorkLogDbPathString(checkDate.ToString("yyyyMM"))
            dbpath = CtrlDbWlog.GetWorkLogDbPathString(checkDate.ToString("yyyyMM"))
            If System.IO.File.Exists(dbpath) = True Then
                sbSql.Clear()
                sbSql.AppendLine("SELECT ")
                sbSql.AppendLine(String.Format("format({0},'yyyy/mm/dd') as {1},", "MAX加工終了日時", WorkTimeColName(WorkTimeCol.WorkDate)))
                sbSql.AppendLine(String.Format("avg({0}) as {1},", "合計時間", WorkTimeColName(WorkTimeCol.AveTime)))
                sbSql.AppendLine(String.Format("min({0}) as {1},", "合計時間", WorkTimeColName(WorkTimeCol.MinTime)))
                sbSql.AppendLine(String.Format("max({0}) as {1}", "合計時間", WorkTimeColName(WorkTimeCol.MaxTime)))

                sbSql.AppendLine("FROM")
                sbSql.AppendLine(" (")
                sbSql.AppendLine("  SELECT ")
                sbSql.AppendLine(String.Format("   sum(a.{0}) as {1},", WLTColumnName(WLTColumn.WorkTime), "合計時間"))
                sbSql.AppendLine(String.Format("   max(a.{0}) as {1}", WLTColumnName(WLTColumn.EndDate), "MAX加工終了日時"))
                sbSql.AppendLine("  FROM")

                sbSql.AppendLine(String.Format(" {0}.[{1}] as a", dbNameWlog, CtrlDbWlog.DefWlogDb.TableWorkLog))

                If boardName <> "" Then
                    sbSql.AppendLine(whereOrAndStr)
                    sbSql.AppendLine(String.Format(" a.{0}='{1}'", WLTColumnName(WLTColumn.BoardName), boardName))
                    whereAdd = True
                    whereOrAndStr = "and"
                End If

                sbSql.AppendLine(whereOrAndStr)
                sbSql.AppendLine("(")
                sbSql.AppendLine(String.Format(" a.{0}>=#{1}#", WLTColumnName(WLTColumn.EndDate), startDate.ToShortDateString))
                sbSql.AppendLine(" and")
                sbSql.AppendLine(String.Format(" a.{0}<=#{1}#", WLTColumnName(WLTColumn.EndDate), endDate.ToShortDateString))
                sbSql.AppendLine(")")
                whereAdd = True
                whereOrAndStr = "and"

                If order <> "" Then
                    sbSql.AppendLine(whereOrAndStr)
                    sbSql.AppendLine(String.Format(" a.{0} like '%{1}%'", WLTColumnName(WLTColumn.Order), order))
                End If

                If workerManNumber <> "" Then
                    sbSql.AppendLine(whereOrAndStr)
                    sbSql.AppendLine(String.Format(" a.{0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), workerManNumber))
                End If
                sbSql.AppendLine(" group by")
                sbSql.AppendLine(String.Format("  a.{0}", WLTColumnName(WLTColumn.SerialNo)))
                sbSql.AppendLine(" )")

                sbSql.AppendLine("group by")
                sbSql.AppendLine(String.Format("format({0},'yyyy/mm/dd')", "MAX加工終了日時"))
                sbSql.AppendLine("order by")
                sbSql.AppendLine(String.Format("format({0},'yyyy/mm/dd')", "MAX加工終了日時"))
                'データアダプターを生成
                Dim oleAdapter As New System.Data.OleDb.OleDbDataAdapter(sbSql.ToString, connect_txt)
                Try
                    oleAdapter.Fill(dt)
                Catch ex As Exception
                    Dim mess As String = ex.Message & vbCrLf & vbCrLf & "SQL" & vbCrLf & sbSql.ToString
                    MessageBox.Show(mess, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                oleAdapter.Dispose()

            End If
            checkDate = checkDate.AddMonths(1)
        Loop

        If dt.Columns.Count < 1 Then
            Return Nothing
        End If

        '抽出データは日付が非連続なので、連続日付データに変換する。
        ConvertWorkTimeConsecutiveDateTalliedData(dt, startDate, endDate)

        Return dt
    End Function


    ''' <summary>
    ''' dtのデータを連続した日付のデータに変換する。
    ''' </summary>
    ''' <param name="dt">
    ''' GetTalliedDataで取得したデータテーブル
    ''' </param>
    ''' <param name="startDate">
    ''' 集計開始日
    ''' </param>
    ''' <param name="endDate">
    ''' 集計終了日
    ''' </param>
    Private Sub ConvertPlanAcutualConsecutiveDateTalliedData(ByRef dt As DataTable, ByVal startDate As Date, ByVal endDate As Date)
        Dim rowIdx As Integer = 0
        Dim checkDate As Date = startDate
        Dim needAddRow As Boolean = False
        Dim sumAcutual As Integer = 0
        Dim sumPlan As Integer = 0

        dt.Columns.Add(SumColName(SumCol.Actual), Type.GetType("System.Int32"))
        dt.Columns.Add(SumColName(SumCol.Plan), Type.GetType("System.Int32"))
        dt.Columns.Add(SumColName(SumCol.Holiday), Type.GetType("System.Boolean"))

        Do While checkDate <= endDate
            If (rowIdx = dt.Rows.Count) Then
                needAddRow = True
            Else
                If checkDate.ToShortDateString <> dt.Rows(rowIdx)(PPATColumnName(PPATColumn.ProductDate)) Then
                    needAddRow = True
                Else
                    sumAcutual += dt.Rows(rowIdx)(PPATColumnName(PPATColumn.ProductionActural))
                    sumPlan += dt.Rows(rowIdx)(PPATColumnName(PPATColumn.ProductionPlan))
                    dt.Rows(rowIdx)(SumColName(SumCol.Actual)) = sumAcutual
                    dt.Rows(rowIdx)(SumColName(SumCol.Plan)) = sumPlan
                    needAddRow = False
                End If
            End If
            If needAddRow = True Then
                Dim r As DataRow = dt.NewRow
                r(PPATColumnName(PPATColumn.ProductDate)) = checkDate.ToShortDateString
                r(PPATColumnName(PPATColumn.ProductionPlan)) = 0
                r(PPATColumnName(PPATColumn.ProductionActural)) = 0
                r(SumColName(SumCol.Actual)) = sumAcutual
                r(SumColName(SumCol.Plan)) = sumPlan
                dt.Rows.InsertAt(r, rowIdx)
            End If
            dt.Rows(rowIdx)(SumColName(SumCol.Holiday)) = CtrlTimesCalender.IsHoriday(TbTimesCalender, checkDate)
            rowIdx += 1
            checkDate = checkDate.AddDays(1)
        Loop
    End Sub
    ''' <summary>
    ''' dtのデータを連続した日付のデータに変換する。
    ''' </summary>
    ''' <param name="dt">
    ''' GetTalliedDataで取得したデータテーブル
    ''' </param>
    ''' <param name="startDate">
    ''' 集計開始日
    ''' </param>
    ''' <param name="endDate">
    ''' 集計終了日
    ''' </param>
    Private Sub ConvertWorkTimeConsecutiveDateTalliedData(ByRef dt As DataTable, ByVal startDate As Date, ByVal endDate As Date)
        Dim rowIdx As Integer = 0
        Dim checkDate As Date = startDate
        Dim needAddRow As Boolean = False
        dt.Columns.Add(WorkTimeColName(WorkTimeCol.Holiday), Type.GetType("System.Boolean"))

        Do While checkDate <= endDate
            If (rowIdx = dt.Rows.Count) Then
                needAddRow = True
            Else
                If checkDate.ToShortDateString <> dt.Rows(rowIdx)(WorkTimeColName(WorkTimeCol.WorkDate)) Then
                    needAddRow = True
                Else
                    needAddRow = False
                End If
            End If
            If needAddRow = True Then
                Dim r As DataRow = dt.NewRow
                r(WorkTimeColName(WorkTimeCol.WorkDate)) = checkDate.ToShortDateString
                r(WorkTimeColName(WorkTimeCol.AveTime)) = DBNull.Value
                r(WorkTimeColName(WorkTimeCol.MinTime)) = DBNull.Value
                r(WorkTimeColName(WorkTimeCol.MaxTime)) = DBNull.Value
                dt.Rows.InsertAt(r, rowIdx)
            End If
            dt.Rows(rowIdx)(WorkTimeColName(WorkTimeCol.Holiday)) = CtrlTimesCalender.IsHoriday(TbTimesCalender, checkDate)
            rowIdx += 1
            checkDate = checkDate.AddDays(1)
        Loop
    End Sub

    Private Sub SetGraph(ByVal strTitle As String)
        With Chart1
            .Titles.Clear()
            .Titles.Add("")  'Title オブジェクトを追加

            With .Titles.Item(0)
                .Alignment = Drawing.ContentAlignment.TopCenter  '上部中央に表示
                .ForeColor = Color.Black
                .Font = New Font("ＭＳ Ｐゴシック", 12, FontStyle.Bold Or FontStyle.Underline)
                .Text = strTitle

            End With
            '凡例の垂直方向の表示位置の設定(Near=上端　Center=中央　Far=下端)
            .Legends(0).Alignment = StringAlignment.Center
            '凡例のドッキング先を設定(Top・Right・Bottom・Left があり既定値は、 Right)
            .Legends(0).Docking = Docking.Top
            '凡例のテキストの表示スタイルを設定(Column・Table=複数行で表示　Row=1行で表示　既定値は、Table)
            '但し、Docking プロパティが Top のような場合は、Table=1行で表示されます。
            .Legends(0).LegendStyle = LegendStyle.Table

            .BorderSkin.SkinStyle = BorderSkinStyle.Emboss
            .BorderSkin.BackColor = Color.Aqua
            .BorderSkin.PageColor = Color.Transparent

        End With
        'SetChartSeries()



    End Sub
    Private Sub SetPlanAcutualChartSeries(ByVal tb As DataTable)
        With Chart1
            .DataSource = Nothing
            .ChartAreas.Clear()
            .Series.Clear()

            .ChartAreas.Add("main")
            .ChartAreas("main").AxisY.Title = "数量(枚)"
            .ChartAreas("main").AxisX.Title = "日付"

            .BorderSkin.SkinStyle = BorderSkinStyle.Emboss 'グラフエリアの外観の設定

            '■------------------- チャートエリアの境界線を描画 -----------------Start--■
            .BorderColor = Color.Black
            .BorderDashStyle = ChartDashStyle.Solid
            .BorderWidth = 1
            '■------------------------------------------------------------------End----■

            '■------------------- 背景をグラデーションで描画 ----------------Start--■
            '背景のグラデーションの向きを上から下へ設定
            .BackGradientStyle = GradientStyle.TopBottom
            .BackColor = Color.White    '背景の最初の色を設定
            .BackSecondaryColor = Color.LightBlue  '背景の2番目の色を設定

            'プロットエリアの背景のグラデーションの向きを上から下へ設定
            .ChartAreas("main").BackGradientStyle = GradientStyle.TopBottom
            .ChartAreas("main").BackColor = Color.White       '背景の最初の色を設定
            .ChartAreas("main").BackSecondaryColor = Color.LightGreen '背景の2番目の色を設定
            '■---------------------------------------------------------------End----■

            '■------プロットエリアの境界線を描画(青色表示の枠の部分)---------Start--■
            .ChartAreas("main").BorderDashStyle = ChartDashStyle.Solid
            .ChartAreas("main").BorderWidth = 1
            .ChartAreas("main").BorderColor = Color.Blue
            .ChartAreas("main").ShadowOffset = 3
            '■---------------------------------------------------------------End----■
            .ChartAreas("main").AxisX.IsStartedFromZero = False

            .ChartAreas("main").AxisX.MajorGrid.Enabled = False
            .ChartAreas("main").AxisX.MajorGrid.Interval = 0
            .ChartAreas("main").AxisX.MajorGrid.LineWidth = 1
            .ChartAreas("main").AxisX.MajorGrid.LineColor = Color.Black

            .ChartAreas("main").AxisX.MinorGrid.Enabled = False
            .ChartAreas("main").AxisX.MinorGrid.Interval = 1
            .ChartAreas("main").AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash
            .ChartAreas("main").AxisX.MinorGrid.LineColor = Color.Black

            .ChartAreas("main").AxisX.LabelStyle.Interval = 1

            Dim flag As Boolean = False

            '系列追加.
            For i = 1 To tb.Columns.Count - 1

                Dim columnName As String = tb.Columns(i).ColumnName

                '.Series.Add(columnName)
                Select Case columnName
                    Case SumColName(SumCol.Actual), SumColName(SumCol.Plan)

                        .Series.Add(columnName)
                        .Series(columnName).ChartType = DataVisualization.Charting.SeriesChartType.Line
                        .Series(columnName).YAxisType = AxisType.Primary
                        .Series(columnName).MarkerBorderColor = Color.Black
                        .Series(columnName).MarkerBorderWidth = 1
                        .Series(columnName).BorderWidth = 3
                        '値のラベル表示
                        .Series(columnName).IsValueShownAsLabel = False
                    Case Else
                        Continue For
                End Select
                Select Case columnName
                    Case SumColName(SumCol.Actual)
                        .Series(columnName).MarkerStyle = MarkerStyle.Diamond
                        .Series(columnName).Color = Color.Orange
                        .Series(columnName).BorderDashStyle = ChartDashStyle.Solid
                    Case SumColName(SumCol.Plan)
                        .Series(columnName).MarkerStyle = MarkerStyle.Circle
                        .Series(columnName).Color = Color.Red
                        .Series(columnName).BorderDashStyle = ChartDashStyle.Solid

                End Select
                .Series(columnName).ChartArea = "main"

                'X軸
                .Series(columnName).XValueType = ChartValueType.String
                .Series(columnName).XValueMember = tb.Columns(0).ColumnName
                'Y軸
                .Series(columnName).YValueMembers = columnName

            Next

            .DataSource = tb

        End With
    End Sub
    Private Sub SetWorkTimeChartSeries(ByVal tb As DataTable)
        With Chart1
            .DataSource = Nothing
            .ChartAreas.Clear()
            .Series.Clear()

            .ChartAreas.Add("main")
            .ChartAreas("main").AxisY.Title = "秒"
            .ChartAreas("main").AxisX.Title = "日付"

            .BorderSkin.SkinStyle = BorderSkinStyle.Emboss 'グラフエリアの外観の設定

            '■------------------- チャートエリアの境界線を描画 -----------------Start--■
            .BorderColor = Color.Black
            .BorderDashStyle = ChartDashStyle.Solid
            .BorderWidth = 1
            '■------------------------------------------------------------------End----■

            '■------------------- 背景をグラデーションで描画 ----------------Start--■
            '背景のグラデーションの向きを上から下へ設定
            .BackGradientStyle = GradientStyle.TopBottom
            .BackColor = Color.White    '背景の最初の色を設定
            .BackSecondaryColor = Color.LightBlue  '背景の2番目の色を設定

            'プロットエリアの背景のグラデーションの向きを上から下へ設定
            .ChartAreas("main").BackGradientStyle = GradientStyle.TopBottom
            .ChartAreas("main").BackColor = Color.White       '背景の最初の色を設定
            .ChartAreas("main").BackSecondaryColor = Color.LightGreen '背景の2番目の色を設定
            '■---------------------------------------------------------------End----■

            '■------プロットエリアの境界線を描画(青色表示の枠の部分)---------Start--■
            .ChartAreas("main").BorderDashStyle = ChartDashStyle.Solid
            .ChartAreas("main").BorderWidth = 1
            .ChartAreas("main").BorderColor = Color.Blue
            .ChartAreas("main").ShadowOffset = 3
            '■---------------------------------------------------------------End----■
            .ChartAreas("main").AxisX.IsStartedFromZero = False

            .ChartAreas("main").AxisX.MajorGrid.Enabled = False
            .ChartAreas("main").AxisX.MajorGrid.Interval = 0
            .ChartAreas("main").AxisX.MajorGrid.LineWidth = 1
            .ChartAreas("main").AxisX.MajorGrid.LineColor = Color.Black

            .ChartAreas("main").AxisX.MinorGrid.Enabled = False
            .ChartAreas("main").AxisX.MinorGrid.Interval = 1
            .ChartAreas("main").AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash
            .ChartAreas("main").AxisX.MinorGrid.LineColor = Color.Black

            .ChartAreas("main").AxisX.LabelStyle.Interval = 1

            Dim flag As Boolean = False

            '系列追加.
            For i = 1 To tb.Columns.Count - 1

                Dim columnName As String = tb.Columns(i).ColumnName

                '.Series.Add(columnName)
                Select Case columnName
                    Case WorkTimeColName(WorkTimeCol.AveTime), WorkTimeColName(WorkTimeCol.MinTime), WorkTimeColName(WorkTimeCol.MaxTime)

                        .Series.Add(columnName)
                        .Series(columnName).ChartType = DataVisualization.Charting.SeriesChartType.Line
                        .Series(columnName).YAxisType = AxisType.Primary
                        .Series(columnName).MarkerBorderColor = Color.Black
                        .Series(columnName).MarkerBorderWidth = 1
                        .Series(columnName).BorderWidth = 3
                        '値のラベル表示
                        .Series(columnName).IsValueShownAsLabel = False
                    Case Else
                        Continue For
                End Select
                Select Case columnName
                    Case WorkTimeColName(WorkTimeCol.AveTime)
                        .Series(columnName).MarkerStyle = MarkerStyle.Diamond
                        .Series(columnName).Color = Color.Green
                        .Series(columnName).BorderDashStyle = ChartDashStyle.Solid
                    Case WorkTimeColName(WorkTimeCol.MinTime)
                        .Series(columnName).MarkerStyle = MarkerStyle.Circle
                        .Series(columnName).Color = Color.Red
                        .Series(columnName).BorderDashStyle = ChartDashStyle.Solid
                    Case WorkTimeColName(WorkTimeCol.MaxTime)
                        .Series(columnName).MarkerStyle = MarkerStyle.Circle
                        .Series(columnName).Color = Color.Red
                        .Series(columnName).BorderDashStyle = ChartDashStyle.Solid

                End Select
                .Series(columnName).ChartArea = "main"

                'X軸
                .Series(columnName).XValueType = ChartValueType.String
                .Series(columnName).XValueMember = tb.Columns(0).ColumnName
                'Y軸
                .Series(columnName).YValueMembers = columnName

            Next

            .DataSource = tb

        End With
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPlanAcutual.CheckedChanged, RadioButtonWorkTime.CheckedChanged
        If HasFormLoaded = False Then
            Exit Sub
        End If
        If RadioButtonPlanAcutual.Checked = True Then
            FormMode = TallyDataFomMode.PlanActual
            SetGraph("生産　計画・実績グラフ")
            If DtTallyData IsNot Nothing Then
                DtTallyData.Clear()
                SetPlanAcutualChartSeries(DtTallyData)
            End If
            SetPlanActualDgvColumn()
        Else
            FormMode = TallyDataFomMode.WorkTime
            SetGraph("作業時間グラフ")
            If DtTallyData IsNot Nothing Then
                DtTallyData.Clear()
                SetWorkTimeChartSeries(DtTallyData)
            End If
            SetWorkTimeDgvColumn()
        End If
    End Sub

    Private Sub DataGridViewTalliyData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewTalliyData.CellFormatting
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If DtTallyData.Rows.Count <= 0 Then
            Exit Sub
        End If

        Select Case FormMode
            Case TallyDataFomMode.PlanActual
                If DtTallyData.Rows(e.RowIndex)(SumColName(SumCol.Holiday)) = True Then
                    DataGridViewTalliyData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                Else
                    DataGridViewTalliyData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
            Case TallyDataFomMode.WorkTime
                If DtTallyData.Rows(e.RowIndex)(WorkTimeColName(WorkTimeCol.Holiday)) = True Then
                    DataGridViewTalliyData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                Else
                    DataGridViewTalliyData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
        End Select
    End Sub
End Class