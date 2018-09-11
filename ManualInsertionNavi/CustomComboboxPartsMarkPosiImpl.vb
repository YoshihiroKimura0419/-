Public Class CustomComboboxPartsMarkPosiImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox

    Public Sub New(ByRef markCombo As ComboBox)
        MyCombobox = markCombo
        MaxItemNum = AlignTextItemNum
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub
    Public Overrides Sub SetComboboxDataSource()
        Dim tb As New DataTable
        tb.Columns.Add("Value", GetType(Integer))
        tb.Columns.Add("Diaplay", GetType(String))
        For i As Integer = 0 To AlignTextItemNum - 1
            tb.Rows.Add(i, AlignText(i))
        Next
        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = "Diaplay"
        MyCombobox.ValueMember = "Value"
    End Sub
End Class
