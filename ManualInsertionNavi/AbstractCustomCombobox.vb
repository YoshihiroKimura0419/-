Public Class AbstractCustomCombobox
    Implements ICustomCombobox
    Public MyCombobox As ComboBox

    Public Property MaxItemNum As Integer Implements ICustomCombobox.MaxItemNum

    Public Overridable Sub SetComboboxDataSource() Implements ICustomCombobox.SetComboboxDataSource

    End Sub

    Public Sub SetSelectedValueInt(selValue As Integer) Implements ICustomCombobox.SetSelectedValueInt
        MyCombobox.SelectedValue = selValue
    End Sub

    Public Function GetSelectedValueInt() As Integer Implements ICustomCombobox.GetSelectedValueInt
        If MyCombobox.SelectedValue Is DBNull.Value Then
            Return -1
        Else
            Return MyCombobox.SelectedValue
        End If
    End Function

    Public Sub SetSelectedValueStr(selValue As String) Implements ICustomCombobox.SetSelectedValueStr
        MyCombobox.SelectedValue = selValue
    End Sub

    Public Function GetSelectedValueStr() As String Implements ICustomCombobox.GetSelectedValueStr
        If MyCombobox.SelectedValue Is DBNull.Value Then
            Return Nothing
        Else
            Return MyCombobox.SelectedValue
        End If
    End Function
    Public Function GetInputText() As String Implements ICustomCombobox.GetInputText
        Return MyCombobox.Text
    End Function
    Public Sub SetSelectedValueDbNull() Implements ICustomCombobox.SetSelectedValueDbNull
        MyCombobox.SelectedValue = DBNull.Value
    End Sub

End Class
