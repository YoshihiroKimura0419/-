''' <summary>
''' CustomComboboxのインターフェースクラス定義
''' </summary>
Public Interface ICustomCombobox
    '形状最大数
    Property MaxItemNum As Integer

    Sub SetComboboxDataSource()
    Sub SetSelectedValueInt(ByVal selValue As Integer)
    Function GetSelectedValueInt() As Integer

    Sub SetSelectedValueStr(ByVal selValue As String)
    Function GetSelectedValueStr() As String

    Function GetInputText() As String

    Sub SetSelectedValueDbNull()

End Interface

