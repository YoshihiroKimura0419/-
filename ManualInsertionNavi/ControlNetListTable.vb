Public Class ControlNetListTable
    Private Enum NLRColumn
        '諸元
        Shogen
        '予備1
        Spare1
        '部品形状名
        ShapeName
        '予備2
        Spare2
        'X座標
        X
        'Y座標
        Y
        '回転角度
        Rotate

    End Enum

    Private FilePath As String = Nothing

    Private Table As New DataTable

    Private NetListReader As New NetListReaderImpl

    'NETリストの項目数=NLRColumnの要素数
    Private Const NetListItemNum As Integer = 7

    Public Sub New(ByVal netListfilePath As String)
        FilePath = netListfilePath
        CreateTable()
        SetTable()
    End Sub

    Private Sub ClearTable()
        Table.Clear()
    End Sub
    Private Sub CreateTable()
        Table.Reset()

        Table.Columns.Add(NLTColumnName(NLTColmun.Shogen), GetType(String))
        Table.Columns.Add(NLTColumnName(NLTColmun.Spare1), GetType(String))
        Table.Columns.Add(NLTColumnName(NLTColmun.ShapeName), GetType(String))
        Table.Columns.Add(NLTColumnName(NLTColmun.Spare2), GetType(String))
        Table.Columns.Add(NLTColumnName(NLTColmun.X), GetType(Double))
        Table.Columns.Add(NLTColumnName(NLTColmun.Y), GetType(Double))
        Table.Columns.Add(NLTColumnName(NLTColmun.Rotate), GetType(Double))

    End Sub
    Public Sub ChangeFilePath(ByVal path As String)
        FilePath = path
        CreateTable()
        SetTable()
    End Sub
    Private Sub SetTable()
        Dim readNetStringBuf() As String = NetListReader.GetText(FilePath)
        Dim delimiter As String = ","
        For Each line As String In readNetStringBuf
            Dim str As String() = Split(line, delimiter, -1, CompareMethod.Text)
            If UBound(str) <> UBound(NLTColumnName) Then
                MessageBox.Show("NETリストの項目数が既定(" & (UBound(NLTColumnName) + 1) & "項目)と異なります。", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim dr As DataRow = Table.NewRow
            For i As Integer = 0 To UBound(NLTColumnName)
                dr(i) = str(i)
            Next
            Table.Rows.Add(dr)
        Next
    End Sub
    Public Function GetTable() As DataTable
        Return Table
    End Function
End Class
