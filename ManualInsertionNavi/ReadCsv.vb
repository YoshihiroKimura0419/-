''' <summary>
''' CSVファイル読み込み用クラス
''' </summary>
Public Class ReadCsv
    ''' <summary>
    ''' csvFileNameで指定されたCSVファイルを読込みCollections配列に格納する
    ''' </summary>
    ''' <param name="csvFileName">
    ''' 読込むCSVファイルのフルパス
    ''' </param>
    ''' <returns>
    ''' 読込んだCollections配列
    ''' </returns>
    ''' <remarks></remarks>
    ''' 
    Public Function GetCsvFileCollection(ByVal csvFileName As String) As System.Collections.ArrayList
        Dim csvRecords As New System.Collections.ArrayList()


        'Shift JISで読み込む
        Using tfp As New FileIO.TextFieldParser(csvFileName, System.Text.Encoding.GetEncoding(932))
            'フィールドが文字で区切られているとする
            'デフォルトでDelimitedなので、必要なし
            tfp.TextFieldType = FileIO.FieldType.Delimited
            '区切り文字を,とする
            tfp.Delimiters = New String() {","}
            'フィールドを"で囲み、改行文字、区切り文字を含めることができるか
            'デフォルトでtrueなので、必要なし
            tfp.HasFieldsEnclosedInQuotes = True
            'フィールドの前後からスペースを削除する
            'デフォルトでtrueなので、必要なし
            tfp.TrimWhiteSpace = True

            While Not tfp.EndOfData
                'フィールドを読み込む
                Dim fields As String() = tfp.ReadFields()
                '保存
                csvRecords.Add(fields)
            End While
        End Using


        Return csvRecords
    End Function

End Class

