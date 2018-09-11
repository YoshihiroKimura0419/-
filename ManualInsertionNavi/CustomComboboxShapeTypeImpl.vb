Public Class CustomComboboxShapeTypeImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox
    Private ItemNum As Integer = 2

    Private ShapeNameText() As String = {"四角", "丸"}

    Public Sub New(ByRef markCombo As ComboBox)
        MyCombobox = markCombo
        MaxItemNum = ItemNum
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Overrides Sub SetComboboxDataSource()
        Dim tb As New DataTable
        tb.Columns.Add("Value", GetType(Integer))
        tb.Columns.Add("Diaplay", GetType(String))
        For i As Integer = 0 To ItemNum - 1
            tb.Rows.Add(i, ShapeNameText(i))
        Next
        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = "Diaplay"
        MyCombobox.ValueMember = "Value"
    End Sub

End Class
