Public Class CustomComboboxEnableImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox
    '最大アイテム数
    Private ItemNum As Integer = 2

    Private DispTrueStr As String
    Private DispFalseStr As String
    Private DispMemberStr As String
    Private ValueMemberStr As String

    Public Sub New(ByRef Combo As ComboBox, ByVal dispTrueString As String, ByVal dispFalseString As String,
                   ByVal dispMemberString As String, ByVal valueMemberString As String)
        MyCombobox = Combo
        MaxItemNum = ItemNum
        DispTrueStr = dispTrueString
        DispFalseStr = dispFalseString
        DispMemberStr = dispMemberString
        ValueMemberStr = valueMemberString
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Overrides Sub SetComboboxDataSource()
        Dim tb As New DataTable()
        tb.Columns.Add("Display", GetType(String))
        tb.Columns.Add("Value", GetType(Boolean))
        tb.Rows.Add(DispTrueStr, True)
        tb.Rows.Add(DispFalseStr, False)
        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = DispMemberStr
        MyCombobox.ValueMember = ValueMemberStr
    End Sub
End Class
