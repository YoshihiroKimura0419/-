
''' <summary>
''' 抽象クラスClassSuperTextReaderからNetlistを扱うためのクラスをオーバーライド
''' </summary>
''' <remarks></remarks>
Public Class NetListReaderImpl
    Inherits AbstractTextReader
    Implements ITextReader
    Private Const DataLineMarker As String = "};"
    Private FileType(,) As String = {
                                {"ネットリストファイル", "*.net"},
                                {"テキストファイル", "*.txt"}
                            }
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
    Public Overrides Function GetText(path As String) As String()
        If path <> "" Then
            If System.IO.File.Exists(path) = False Then
                Return Nothing
            End If
        End If
        '文字コード(ここでは、Shift JIS)
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")
        ''テキストファイルの中身をすべて読み込む
        'Dim str As String = System.IO.File.ReadAllText(path, enc)
        '行ごとの配列として、テキストファイルの中身をすべて読み込む
        MyBase.ReadString = GetDataCsvFormat(System.IO.File.ReadAllLines(path, enc))
        Return MyBase.ReadString
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
    Public Overrides Function GetTextOneLine(path As String, lineNo As Integer) As String
        Dim sts As Boolean = False
        If path <> "" Then
            If System.IO.File.Exists(path) = False Then
                sts = ""
                Return Nothing
            End If
        End If
        '文字コード(ここでは、Shift JIS)
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")
        ''テキストファイルの中身をすべて読み込む
        'Dim str As String = System.IO.File.ReadAllText(path, enc)
        '行ごとの配列として、テキストファイルの中身をすべて読み込む
        ReadString = System.IO.File.ReadAllLines(path, enc)
        Return MyBase.ReadString(lineNo)
    End Function
    ''' <summary>
    ''' ファイル指定ダイアログボックスを開き、読み込むファイル名を取得する。
    ''' 指定可能ファイルは、GetFileFilterStrでフィルター指定したファイルのみ
    ''' </summary>
    ''' <param name="initialPath">
    ''' 表示ダイアログの初期フォルダ
    ''' </param>
    ''' <returns>
    ''' 指定ファイル名
    ''' </returns>
    ''' <remarks></remarks>
    Public Overrides Function GetFilePath(ByVal initialPath As String) As String
        Dim filePath As String = ""
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        ofd.InitialDirectory = initialPath

        '表示ファイルフィルタ設定
        ofd.Filter = GetFileFilterStr()

        'タイトルを設定する
        ofd.Title = "ネットリストファイル選択"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            filePath = ofd.FileName
        Else
            filePath = ""
        End If
        If ofd IsNot Nothing Then
            ofd.Dispose()
        End If

        Return filePath
    End Function


    ''' <summary>
    ''' readString文字配列を''' Tabや};、]={などの無駄な文字列を削除しデータ行のみにしたCSVフォーマットデータを取得する
    ''' </summary>
    ''' <param name="readString">
    ''' GetTextメソッドで取得した文字配列
    ''' </param>
    ''' <returns>
    ''' CSV形式に変換したデータ行のみの文字配列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetDataCsvFormat(ByVal readString() As String) As String()
        Dim CNetlistReader As New AbstractTextReader
        Dim dataString As New System.Text.StringBuilder

        If readString(1).IndexOf("<< CADVANCE NET LIST >>") = -1 Then
            Return Nothing
        End If
        '挿入位置データ行のみ抜き出す
        For i As Integer = 0 To UBound(readString)
            If readString(i).IndexOf(DataLineMarker) = -1 Then
                Continue For
            End If
            dataString.Append(readString(i))
            '次の行がデータ行なら改行コードを付加
            If i < UBound(readString) - 1 Then
                If 0 <= readString(i + 1).IndexOf(DataLineMarker) Then
                    dataString.Append(vbCrLf)
                End If
            End If

        Next
        '不要文字の削除
        dataString.Replace(vbTab, "")
        dataString.Replace(" ", "")
        dataString.Replace(DataLineMarker, "")
        dataString.Replace("""", "")
        dataString.Replace("]={", ",")
        dataString.Replace("[", ",")

        Dim convertCsvString() As String = Split(dataString.ToString, vbCrLf)
        Return convertCsvString
    End Function
    ''' <summary>
    ''' Netリストファイルを選択する際にFileOpenDialogのフィルターに設定する文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' フィルーター設定文字列
    ''' </returns>
    Private Function GetFileFilterStr() As String
        Dim filter As String = ""
        For i As Integer = 0 To UBound(FileType, 1)
            filter &= FileType(i, 0) & "(" & FileType(i, 1) & ")"
            filter &= "|" & FileType(i, 1)
            If i < UBound(FileType, 1) Then
                filter &= "|"
            End If
        Next
        Return filter
    End Function

End Class
