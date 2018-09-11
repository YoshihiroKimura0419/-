''' <summary>
''' テキスト読み込み用インターフェース
''' </summary>
''' <remarks></remarks>
Public Interface ITextReader
    Function GetText(ByVal path As String) As String()
    Function GetTextOneLine(ByVal path As String, ByVal lineNo As Integer) As String
    Function GetFilePath(ByVal initialPath As String) As String
End Interface
