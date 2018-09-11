Imports System.Configuration

Public Class FormSettingSystem

    Private CalenderTB As New DataTable

    Private SettingFilePath As String = Nothing

    'アプリケーション設定情報管理オブジェクト定義
    Public AppConfigData As ApplicationConfigData

    'DB操作オブジェクト定義
    Public CtrlDb As ControlDbMaster

    Public Sub New(ByVal appConfig As ApplicationConfigData, ByVal mstCtrlDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        AppConfigData = appConfig.Clone
        CtrlDb = mstCtrlDb.Clone
    End Sub
    Private Sub ButtonBrowsFolder_Click(sender As Object, e As EventArgs) Handles ButtonBrowsFolder.Click
        Dim selpath As String = ""
        Dim dresult As DialogResult

        Using fbd As New FolderBrowserDialog
            fbd.SelectedPath = AppConfigData.SystemDataPath.Root

            dresult = fbd.ShowDialog()
            selpath = fbd.SelectedPath

        End Using


        If dresult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        TextBoxSystemFolder.Text = selpath

    End Sub

    Private Sub ButtonUpdateSetting_Click(sender As Object, e As EventArgs) Handles ButtonUpdateSetting.Click
        Dim backupSystemRoot As String = AppConfigData.SystemDataPath.Root
        Dim backupMasterDbPath As String = AppConfigData.SystemDataPath.Db
        Dim backupIstestModeOn As Boolean = AppConfigData.IsTestModeOn
        Dim backupIsUseTimesCalender As Boolean = AppConfigData.IsUseTimesCalender
        Dim backupProjectorWidth As Boolean = AppConfigData.ProjectorWidth
        Dim backupProjectorHeight As Boolean = AppConfigData.ProjectorHeight

        AppConfigData.SystemDataPath.Root = TextBoxSystemFolder.Text
        'CtrlDb.DefMstDb.SetMasterDbPath(AppConfigData.SystemDataPath.Root)
        CtrlDb.SetDbPath(AppConfigData.SystemDataPath.Root)
        AppConfigData.IsTestModeOn = CheckBoxDemoFlag.Checked
        AppConfigData.IsUseTimesCalender = RadioButtonTimesCalender.Checked

        AppConfigData.ProjectorWidth = CDbl(TextBoxProjectorWidth.Text)
        AppConfigData.ProjectorHeight = CDbl(TextBoxProjectorHeight.Text)

        Dim controlSetting As CotrolSettingCsv = New CotrolSettingCsv

        Dim dResult As DialogResult = Nothing
        Dim mess As New System.Text.StringBuilder

        Dim updateResult As Boolean = False
        Do While True
            If controlSetting.WriteFile(AppConfigData) = False Then
                mess.Clear()
                mess.Append("設定ファイルの書込みに失敗しました。" & vbCrLf)
                mess.Append(AppConfigData.ApplicationExcecutePath & "\" & AppConfigData.SettingCsvFileName & vbCrLf)
                mess.Append(vbCrLf)
                mess.Append("リトライしますか？" & vbCrLf)
                mess.Append("　はい　　：リトライする" & vbCrLf)
                mess.Append("　いいえ　：メモリ内部のみ更新し、設定ファイルは更新しない" & vbCrLf)
                mess.Append("キャンセル：更新処理を中断" & vbCrLf)

                dResult = MessageBox.Show(mess.ToString, "設定ファイル書込みエラー", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)

                Select Case dResult
                    Case DialogResult.Yes
                        updateResult = False
                    Case DialogResult.No
                        updateResult = False
                        Exit Do
                    Case DialogResult.Cancel
                        AppConfigData.SystemDataPath.Root = backupSystemRoot
                        'CtrlDb.DefMstDb.SetMasterDbPath(backupMasterDbPath)
                        CtrlDb.SetDbPath(backupMasterDbPath)
                        AppConfigData.IsTestModeOn = backupIstestModeOn
                        AppConfigData.IsUseTimesCalender = backupIsUseTimesCalender
                        AppConfigData.ProjectorWidth = backupProjectorWidth
                        AppConfigData.ProjectorHeight = backupProjectorHeight
                        updateResult = False
                        Exit Sub
                End Select
            Else
                updateResult = True
                Exit Do
            End If
        Loop
        If updateResult = True Then
            Dim errResultMessage As String = ""
            If AppConfigData.IsExistSystemDataPath(errResultMessage) = False Then
                mess.Clear()
                mess.Append("システムに必要なフォルダがありません。" & vbCrLf)
                mess.Append("フォルダを作成しますか？" & vbCrLf)
                mess.Append("作成フォルダは、詳細を確認して下さい。" & vbCrLf)
                Using errDialog As New FormMessageDetailsDialog(mess.ToString, "システムフォルダ作成確認", errResultMessage, MessageBoxButtons.YesNo)
                    dResult = errDialog.ShowDialog
                End Using
                If dResult = DialogResult.Yes Then
                    errResultMessage = ""
                    If AppConfigData.MakeSystemDataFolder(errResultMessage) = False Then
                        mess.Clear()
                        mess.Append("システムフォルダが作成できませんでした。" & vbCrLf)
                        mess.Append("詳細を確認し、システム管理者に連絡してください。")
                        Using errDialog As New FormMessageDetailsDialog(mess.ToString, "システムフォルダ作成エラー", errResultMessage, MessageBoxButtons.OK)
                            dResult = errDialog.ShowDialog
                        End Using
                    End If
                End If
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancelSetting_Click(sender As Object, e As EventArgs) Handles ButtonCancelSetting.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormSettingSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxSystemFolder.Text = AppConfigData.SystemDataPath.Root

        'アプリケーションパスの表示
        TextBoxAppExecutePath.Text = AppConfigData.ApplicationExcecutePath

        TextBoxProjectorHeight.Text = AppConfigData.ProjectorHeight.ToString(0.0)
        TextBoxProjectorWidth.Text = AppConfigData.ProjectorWidth.ToString(0.0)

        CheckBoxDemoFlag.Checked = AppConfigData.IsTestModeOn
        RadioButtonSystemDBCalender.Checked = Not AppConfigData.IsUseTimesCalender
        RadioButtonTimesCalender.Checked = AppConfigData.IsUseTimesCalender
        ButtonUpDateSystemDBCalender.Enabled = False

    End Sub

    Private Sub RadioButtonTimesCalender_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTimesCalender.CheckedChanged
        AppConfigData.IsUseTimesCalender = RadioButtonTimesCalender.Checked
    End Sub

    Private Sub ButtonGetTimesCalender_Click(sender As Object, e As EventArgs) Handles ButtonGetTimesCalender.Click
        Dim controlRtcCal As ControlRtcCalendar = New ControlRtcCalendar

        If controlRtcCal.GetTimesServerRtcCalenderTable(CalenderTB) = True Then
            Dim fm As FormDispDataTable = New FormDispDataTable(CalenderTB, "菱テクTimesカレンダー")
            fm.ShowDialog()
            If fm IsNot Nothing Then
                fm.Dispose()
            End If
            Dim workdayCount As Integer = 0

            Dim dateToday As Date = Date.Today
            '取得月の稼動日合計を確認。合計が０の場合データ取得異常
            Dim thisYear As String = dateToday.Year
            Dim thisMonth As String = String.Format("{0:D2}", dateToday.Month)
            For rowCount As Integer = 0 To CalenderTB.Rows.Count - 1
                If (CalenderTB.Rows(rowCount)("YEAR") = thisYear) AndAlso (CalenderTB.Rows(rowCount)("MONTH") = thisMonth) Then
                    '今月の稼働日情報が設定されているか確認
                    For colmunCount As Integer = 2 To controlRtcCal.DbDaysColumnCount + 1
                        If CalenderTB.Rows(rowCount)(colmunCount) = 1 Then
                            workdayCount += 1
                        End If
                    Next
                    Exit For
                End If
            Next
            If workdayCount > 0 Then
                ButtonUpDateSystemDBCalender.Enabled = True
            Else
                MessageBox.Show("菱テクTimesカレンダーが正常に取得できませんでした。", _
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ButtonUpDateSystemDBCalender.Enabled = False
            End If
        Else
            MessageBox.Show("菱テクTimesカレンダーの取得に失敗しました。", _
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ButtonUpDateSystemDBCalender.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub ButtonUpDateSystemDBCalender_Click(sender As Object, e As EventArgs) Handles ButtonUpDateSystemDBCalender.Click
        Dim timesCalender As New DataTable
        Dim sysCalender As DataTable = Nothing

        Dim updatetable As New DataTable

        updatetable = CalenderTB.Copy

        Dim ctrlSysCal As ControlSystemCalender = New ControlSystemCalender(CtrlDb)

        'Timesカレンダー取得
        If ctrlSysCal.GetTimesServerRtcCalenderTable(timesCalender) = False Then
            MessageBox.Show("Timesのカレンダー取得に失敗しました。", _
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Systemカレンダー取得
        sysCalender = ctrlSysCal.GetSystemCalenderDB()
        If sysCalender Is Nothing Then
            MessageBox.Show("Timesのカレンダー取得に失敗しました。", _
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For Each drow As DataRow In timesCalender.Rows
            For Each sdrow As DataRow In sysCalender.Rows
                If (drow("YEAR") = sdrow("年")) AndAlso (drow("MONTH").ToString = sdrow("月").ToString) Then
                    drow.Delete()
                    Exit For
                End If
            Next
        Next

        timesCalender.AcceptChanges()

        If timesCalender.Rows.Count > 0 Then
            If ctrlSysCal.UpDateSystemCalenderDB(timesCalender) = False Then
                MessageBox.Show("システムの菱テクカレンダー更新に失敗しました。", _
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("システムの菱テクカレンダーを更新しました。", _
                                "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("更新データはありませんでした。", _
                            "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBoxProjectorHeight_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxProjectorHeight.Validating
        Dim value As Double
        If (Double.TryParse(TextBoxProjectorHeight.Text, value) = False) AndAlso (ActiveControl IsNot TextBoxProjectorHeight) Then
            ErrorProviderInput.SetError(TextBoxProjectorHeight, "数値を入力してください。")
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxProjectorHeight_Validated(sender As Object, e As EventArgs) Handles TextBoxProjectorHeight.Validated
        ErrorProviderInput.SetError(TextBoxProjectorHeight, "")
    End Sub

    Private Sub TextBoxProjectorWidth_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxProjectorWidth.Validating
        Dim value As Double
        If (Double.TryParse(TextBoxProjectorWidth.Text, value) = False) AndAlso (ActiveControl IsNot TextBoxProjectorWidth) Then
            ErrorProviderInput.SetError(TextBoxProjectorWidth, "数値を入力してください。")
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxProjectorWidth_Validated(sender As Object, e As EventArgs) Handles TextBoxProjectorWidth.Validated
        ErrorProviderInput.SetError(TextBoxProjectorWidth, "")
    End Sub
End Class