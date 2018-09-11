Public Class FormDispDataTable

    Private dtDispTable As New DataTable

    Public Sub New(ByVal disptable As DataTable, ByVal strTitle As String)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        dtDispTable = disptable.Copy
        DataGridView1.DataSource = dtDispTable
        Me.Text = strTitle
    End Sub

    Private Sub ButtonCloseWindow_Click(sender As Object, e As EventArgs) Handles ButtonCloseWindow.Click
        Me.Close()
    End Sub

    Private Sub ButtonSaveExcel_Click(sender As Object, e As EventArgs) Handles ButtonSaveExcel.Click
        Dim file_name As String
        Dim controlXls As ControlExcelFile = New ControlExcelFile
        file_name = controlXls.SaveDgvDataToExcel(DataGridView1, False, "c:\")
        If file_name <> "" Then
            ExecuteFile(file_name)
        End If
    End Sub

End Class