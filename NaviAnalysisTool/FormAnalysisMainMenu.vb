Imports ManualInsertionNavi
Public Class FormAnalysisMainMenu
    Private Sub FormAnalysisMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim status As Integer
        Dim sbErrMess As New System.Text.StringBuilder

        status = GetAnalysisSettingCsvData(sbErrMess)
        Select Case status
            Case AnalisysStatus.ErrReadSettingCsv
                DispSystemError(sbErrMess.ToString, AnalysisSettingFileCsv & "読込エラー")
            Case AnalisysStatus.ErrInvalidSettinCsvFile
                DispSystemError(sbErrMess.ToString, AnalysisSettingFileCsv & "内容エラー")
            Case AnalisysStatus.ErrNoExistNaviSytemDataPath
                DispSystemError(sbErrMess.ToString, "手挿入ナビシステムデータフォルダ指定エラー")
        End Select

        If status = AnalisysStatus.Ok Then
            CtrlDbMaster.SetDbPath(SystemDataPath.Root)
            CtrlDbOrder.SetDbPath(SystemDataPath.Root)
            CtrlDbPpa.SetDbPath(SystemDataPath.Root)
            CtrlDbWlog.SetWorkingDataAndLogDbPath(SystemDataPath.Root)
        Else
            Me.Close()
            Exit Sub
        End If
        If CtrlTimesCalender.GetTimesServerRtcCalenderTable(TbTimesCalender) = True Then
            EnableTimesCalender = True
        Else
            EnableTimesCalender = False
            sbErrMess.Clear()
            sbErrMess.AppendLine("Timesカレンダーが取得取得できませんでした。")
            sbErrMess.AppendLine("休日判定を無効にします。")
            DispSystemError(sbErrMess.ToString, "Timesカレンダー取得エラー")

        End If
    End Sub
    Private Function GetAnalysisSettingCsvData(ByRef sbErrMess As System.Text.StringBuilder) As Integer
        AnalysisSystemPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        Dim settingCsvPath As String = String.Format("{0}\{1}", AnalysisSystemPath, AnalysisSettingFileCsv)

        Dim csvRead As ManualInsertionNavi.ReadCsv = New ManualInsertionNavi.ReadCsv
        Dim csvRecords As System.Collections.ArrayList
        Try
            csvRecords = csvRead.GetCsvFileCollection(settingCsvPath)
        Catch ex As Exception
            sbErrMess.AppendLine(ex.Message)
            sbErrMess.AppendLine("")
            sbErrMess.AppendLine("システム終了します。")
            Return AnalisysStatus.ErrReadSettingCsv
        End Try

        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To csvRecords.Count - 1
            Dim str() As String = csvRecords(i)
            Dim strItem As String = str(0)

            'ファイルヘッダー確認
            If i = 0 And strItem <> AnalysisSettingCsvHeader Then
                sbErrMess.AppendLine("このファイルは、" & AnalysisSettingCsvHeader & "ではありません")
                sbErrMess.AppendLine("")
                sbErrMess.AppendLine("システム終了します。")
                Return AnalisysStatus.ErrInvalidSettinCsvFile
            End If

            '設定値読み込み
            Select Case strItem
                Case "ヘッダー"
                    Continue For
                Case "設定値"
                    Select Case str(1)
                        Case "SystemDataPath"
                            SetSystemDataPath(str(2))
                    End Select
                Case Else
                    Continue For
            End Select
        Next
        If System.IO.Directory.Exists(SystemDataPath.Root) = False Then
            sbErrMess.AppendLine("指定のフォルダが存在しません。")
            sbErrMess.AppendLine("SystemDataPath:" & SystemDataPath.Root)
            sbErrMess.AppendLine(AnalysisSettingFileCsv & "を確認してください。")
            sbErrMess.AppendLine("")
            sbErrMess.AppendLine("システム終了します。")
            Return AnalisysStatus.ErrNoExistNaviSytemDataPath
        End If
        Return AnalisysStatus.Ok
    End Function

    Private Function DispSystemError(ByVal mess As String, ByVal title As String) As DialogResult
        Dim fm As New ManualInsertionNavi.FormMessageDialog
        Dim dResult As DialogResult
        fm.SetButtonsType(MessageBoxButtons.OK)
        fm.SetTitleAndMessage(title, mess, Color.Red)
        dResult = fm.ShowDialog()
        If fm IsNot Nothing Then
            fm.Dispose()
        End If
        Return dResult
    End Function

    Private Sub ButtonTrendPlanAcutual_Click(sender As Object, e As EventArgs) Handles ButtonTrendPlanAcutual.Click
        Dim fm As FormTallyData = New FormTallyData
        fm.ShowDialog()
        If fm IsNot Nothing Then
            fm.Dispose()
        End If

    End Sub


End Class
