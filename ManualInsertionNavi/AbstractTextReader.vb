''' <summary>
''' インターフェースITextReaderからテキストファイル読み込みの抽象クラス定義
''' </summary>
''' <remarks></remarks>
Public Class AbstractTextReader
    Implements ITextReader

    '読み込みテキスト格納配列
    Public ReadString() As String

    ''' <summary>
    ''' pathで指定したファイルのテキスト取得する。
    ''' </summary>
    ''' <param name="path">
    ''' テキストファイルのパス
    ''' </param>
    ''' <returns>
    ''' テキストの行毎の配列
    ''' </returns>
    ''' <remarks></remarks>
    Public Overridable Function GetText(ByVal path As String) As String() Implements ITextReader.GetText
        '処理は派生クラスで実装
        Return ReadString
    End Function
    ''' <summary>
    ''' pathで指定したファイルの取得したテキスト配列の指定行番号の文字列を返す
    ''' </summary>
    ''' <param name="path">
    ''' テキストファイルのパス
    ''' </param>
    ''' <param name="lineNo">
    ''' 取得したい行番号
    ''' </param>
    ''' <returns>
    ''' 指定行の文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Overridable Function GetTextOneLine(ByVal path As String, ByVal lineNo As Integer) As String Implements ITextReader.GetTextOneLine
        Return ReadString(lineNo)

    End Function
    ''' <summary>
    ''' ファイル指定ダイアログボックスを開き、読み込むファイル名を取得する。
    ''' </summary>
    ''' <param name="initialPath">
    ''' 表示ダイアログの初期フォルダ
    ''' </param>
    ''' <returns>
    ''' 指定ファイル名
    ''' </returns>
    ''' <remarks></remarks>
    Public Overridable Function GetFilePath(ByVal initialPath As String) As String Implements ITextReader.GetFilePath
        Dim path As String = ""
        Return path
    End Function

End Class
