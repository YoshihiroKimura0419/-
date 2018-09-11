Public Class ControlKankotsuCsv
    Inherits ReadCsv
    Private Const CsvName As String = "Kankotsu.csv"
    Private Const CsvHeader As String = "カンコツファイルリスト"
    Private ContentsString As String() = {"項目ヘッダー", "設定値"}
    Private CsvHeaderString As String() = {"設定項目名", "値"}
    Private SettingItemNameString As String() = {"ファイル名"}
    Private Enum Contents As Integer
        ItemHeader = 0
        Value = 1
    End Enum
    Private Enum SettingItem As Integer
        FileName = 0
    End Enum

    ''' <summary>
    ''' カンンコツファイルリストを読込む
    ''' </summary>
    ''' <param name="path">
    ''' カンコツファイルリストを読込む部材コードディレクトリパス文字列
    ''' </param>
    ''' <returns>
    ''' 読込みファイルリスト配列。読込み文字列はSystemDataPath\Kankotsu以下の文字列
    ''' 読込みに失敗した場合は、Nothingを返す
    ''' </returns>
    ''' <remarks></remarks>
    Public Function ReadFile(ByVal path As String, ByRef errMess As String) As List(Of String)
        errMess = Nothing
        Dim kankotsuFile As New List(Of String)

        Dim filepath As String = path & "\" & CsvName
        If System.IO.File.Exists(filepath) = False Then
            errMess = "カンコツファイルリストがありません。" & vbCrLf
            errMess &= filepath
            Return Nothing
        End If
        'Dim csvRead As ReadCsv = New ReadCsv
        'Dim csvRecords As System.Collections.ArrayList = csvRead.GetCsvFileCollection(filepath)
        Dim csvRecords As System.Collections.ArrayList = GetCsvFileCollection(filepath)

        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To count - 1
            Dim str() As String = csvRecords(i)
            Dim strItem As String = str(0)

            'ファイルヘッダー確認
            If (i = 0) AndAlso (str(0) <> CsvHeader) Then
                errMess = "このファイルは、" & CsvHeader & "ではありません" & vbCrLf
                errMess &= filepath
                Return Nothing
            End If

            '設定値読み込み
            Select Case strItem
                Case ContentsString(Contents.ItemHeader)
                    Continue For
                Case ContentsString(Contents.Value)
                    Select Case str(1)
                        Case SettingItemNameString(SettingItem.FileName)
                            kankotsuFile.Add(str(2))
                    End Select
                Case Else
                    Continue For
            End Select
        Next
        Return kankotsuFile
    End Function

    Public Function WriteFile(ByVal path As String, ByVal kankotuList As List(Of String), ByRef errMess As String) As Boolean
        errMess = Nothing
        Dim filepath As String = path & "\" & CsvName

        Try
            'CSVファイルに書き込むときに使うEncoding
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

            '書き込むファイルを開く
            'Dim sr As New System.IO.StreamWriter(path, True, enc)
            Using sr As New System.IO.StreamWriter(filepath, False, enc)
                Dim sbFieldString As New System.Text.StringBuilder
                'セッティングファイル認識ヘッダ---------------------------------------------
                sbFieldString.Append(CsvHeader & vbCrLf)
                sr.Write(sbFieldString.ToString)

                '項目ヘッダー---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append(ContentsString(Contents.ItemHeader) & ",")

                For i As Integer = 0 To UBound(CsvHeaderString)
                    sbFieldString.Append(CsvHeaderString(i))
                    If i < UBound(CsvHeaderString) Then
                        sbFieldString.Append(",")
                    End If
                Next
                sbFieldString.Append(vbCrLf)
                sr.Write(sbFieldString.ToString)
                '---------------------------------------------------------------------------
                'ファイルリスト出力---------------------------------------------------------
                sbFieldString.Clear()
                For i As Integer = 0 To kankotuList.Count - 1
                    sbFieldString.Append(ContentsString(Contents.Value))
                    sbFieldString.Append(",")
                    sbFieldString.Append(SettingItemNameString(SettingItem.FileName))
                    sbFieldString.Append(",")
                    sbFieldString.Append(kankotuList(i))
                    sbFieldString.Append(vbCrLf)
                Next
                sr.Write(sbFieldString.ToString)
                '---------------------------------------------------------------------------
            End Using
        Catch ex As Exception
            errMess = ex.Message
            Return False
        End Try
        Return True
    End Function

End Class
