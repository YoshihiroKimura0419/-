Public Class ReadShogenhyo
    Inherits ReadCsv
    '----------------------------------------------------------------------
    ''' <summary>
    ''' フォーマットType1の諸元表CSVファイルのヘッダー列識別番号
    ''' </summary>
    Public Enum CsvHeaderColumnType1
        '出力日時
        OutputDate
        '標摘番号
        HyotekiNumber
        '標摘副番
        HyotekiRevision
        '実装形式（機器名称？）
        Type
        '基板型名
        ModelName
        '予備1
        Spare1
        '予備2
        Spare2
    End Enum
    ''' <summary>
    ''' フォーマットType1の諸元表CSVファイルのデータ列識別番号
    ''' </summary>
    Public Enum CsvDataColumnType1
        '予備1
        Spare1
        '予備2
        Spare2
        '行番号
        RowNumber
        '部品名称
        PartsName
        '部品型式
        PartsModelName
        '部品型式
        PartsCode
        '予備3
        Spare3
        '予備4
        Spare4
        '予備5
        Spare5
        '諸元
        Shogen
        '使用数量
        UseCount
    End Enum
    '----------------------------------------------------------------------
    ''' <summary>
    ''' フォーマットType2のヘッダー列識別番号
    ''' フォーマットType1とフォーマットType2との違いは、定格、手配アイテムのみ？
    ''' </summary>
    Public Enum CsvHeader1ColumnType2
        '出力日時
        OutputDate
        '標摘番号
        HyotekiNumber
        '標摘副番
        HyotekiRevision
        '実装形式（機器名称？）
        Type
        '基板型名
        ModelName
        '定格
        Rating
        '手配アイテム
        OrderItem
    End Enum
    ''' <summary>
    ''' フォーマットType2の諸元表CSVファイルのデータ列識別番号
    ''' </summary>
    Public Enum CsvDataColumnType2
        '変更副番（行の副番？）
        RowRevision
        '品番
        Number
        '部品名称
        PartsName
        '部品型式
        PartsModelName
        '補足仕様
        SupplementarySpecification
        '部材コード（品目コード）
        PartsCode
        '副番（本ソフトでは使用しないのでSpare1とする）
        Spare1
        '寸法（本ソフトでは使用しないのでSpare2とする）
        Spare2
        '単位（本ソフトでは使用しないのでSpare3とする）
        Spare3
        '諸元（諸元記号/備考）
        Shogen
        'MRPﾌﾟﾛﾌｧｲﾙ（本ソフトでは使用しないのでSpare4とする）
        Spare4
        '基準区分（本ソフトでは使用しないのでSpare4とする）
        Spare5
        'RoHS対応状況（本ソフトでは使用しないのでSpare4とする）
        Spare6
        'RoHS切替状況（本ソフトでは使用しないのでSpare4とする）
        Spare7
        'Pb（本ソフトでは使用しないのでSpare4とする）
        Spare8
        'Cd（本ソフトでは使用しないのでSpare4とする）
        Spare9
        'Hg（本ソフトでは使用しないのでSpare4とする）
        Spare10
        'CrVI（本ソフトでは使用しないのでSpare4とする）
        Spare11
        'PBB（本ソフトでは使用しないのでSpare4とする）
        Spare12
        'PBDE（本ソフトでは使用しないのでSpare4とする）
        Spare13
        '単価（本ソフトでは使用しないのでSpare4とする）
        Spare14
        '単価区分（本ソフトでは使用しないのでSpare4とする）
        Spare15
        '最小ﾛｯﾄ（本ソフトでは使用しないのでSpare4とする）
        Spare16
        '丸め数量（本ソフトでは使用しないのでSpare4とする）
        Spare17
        '取引先名（本ソフトでは使用しないのでSpare4とする）
        Spare18
        'N01（使用数量）
        UseCount
    End Enum
    ''' <summary>
    ''' フォーマットType2の諸元表CSVファイルの行識別番号
    ''' </summary>
    Private Enum Type2Row
        ShogenhyoInfoHeader = 0
        ShogenhyoInfoData = 1
        DataHeader = 2
        Data = 3
    End Enum
    '----------------------------------------------------------------------


    '諸元表情報構造体定義
    Public ShogenhyoInfo As ShogenhyoInfomation

    'フォーマットType1のヘッダー列名配列
    Public Type1Header As String() = {"出力日時", "標摘番号", "副番", "ﾊﾟｰﾂﾘｽﾄ ﾃｿｳ", "型名", "予備1", "予備2"}

    'フォーマットType1のヘッダー列名配列
    Public Type2Header As String() = {"出力日時", "標摘番号", "副番", "機器名称", "型名", "定格", "手配ｱｲﾃﾑ"}

    'ヘッダー列数定義
    Private Const HeaderColumnCount As Integer = 7

    '諸元表ファイル形式
    Public ShogenFileType As Integer = ShogenhyoFileType.Type1

    '諸元表データ格納データテーブル
    Public DtShogenhyouData As New DataTable

    ''' <summary>
    ''' filepathで指定された諸元表のファイル内容を読込みDtShogenhyouDataに格納する。
    ''' </summary>
    ''' <param name="filepath">
    ''' 諸元表のファイルパス
    ''' </param>
    ''' <returns></returns>
    Public Function ReadFile(ByVal filepath As String) As Integer
        Dim type As Integer = ShogenhyoFileType.Unknown
        If System.IO.File.Exists(filepath) = False Then
            Return 1
        End If

        Dim csvRecords As System.Collections.ArrayList = GetCsvFileCollection(filepath)

        ShogenFileType = GetFileType(csvRecords(0))

        CreateTable()
        Dim readResult As Boolean = False
        Select Case ShogenFileType
            Case ShogenhyoFileType.Type1
                readResult = GetType1FileData(csvRecords)
            Case ShogenhyoFileType.Type2
                readResult = GetType2FileData(csvRecords)
            Case ShogenhyoFileType.Unknown
                readResult = GetTypeUnknownFileData(csvRecords)
        End Select
        If readResult = False Then
            Return 2
        End If
        Return 0
    End Function
    ''' <summary>
    ''' 諸元表データテーブル作成
    ''' </summary>
    Private Sub CreateTable()
        DtShogenhyouData.Reset()
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.RowNumber), GetType(Integer))
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.PartsName), GetType(String))
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.PartsModelName), GetType(String))
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.PartsCode), GetType(String))
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.Shogen), GetType(String))
        DtShogenhyouData.Columns.Add(SDTColumnName(SDTColumn.UseCount), GetType(Integer))
    End Sub
    ''' <summary>
    ''' 諸元表フォーマットのFileType.Normalのデータを取得し、ShogenhyouInfo及びDtShogenhyouDataに格納する。
    ''' </summary>
    ''' <param name="csvRecords">
    ''' 諸元表ファイルのCSV読込データ
    ''' </param>
    ''' <returns></returns>
    Private Function GetType1FileData(ByVal csvRecords As System.Collections.ArrayList) As Boolean
        Dim result As Boolean = True

        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To count - 1
            Dim str() As String = csvRecords(i)

            'ヘッダー行から諸元表情報を取得
            If i = 0 Then
                ShogenhyoInfo.Model = str(CsvHeaderColumnType1.ModelName)
                ShogenhyoInfo.HyotekiNumber = str(CsvHeaderColumnType1.HyotekiNumber)
                ShogenhyoInfo.HyotekiRevision = str(CsvHeaderColumnType1.HyotekiRevision)
                ShogenhyoInfo.OutputDate = str(CsvHeaderColumnType1.OutputDate)
            End If

            'データ行処理
            If 0 < i Then
                'データ項目数が異なる
                If UBound(str) <> (ShogenhyoDataColumnNum.Type1 - 1) Then
                    'データ行終了
                    Exit For
                End If
                'データ行終了判断1(データ列に何か入っているか)
                If str(CsvDataColumnType1.RowNumber) <> Nothing Then
                    If str(CsvDataColumnType1.PartsName) = Nothing Then
                        Continue For
                    End If
                    Dim rowNumber As Integer = -1
                    Try
                        'データ行終了判断2(Integerに変換できるか)
                        rowNumber = Integer.Parse(str(CsvDataColumnType1.RowNumber))
                    Catch ex As Exception
                        'データ行終了
                        Exit For
                    End Try

                    Try
                        Dim dr As DataRow = DtShogenhyouData.NewRow()
                        dr(SDTColumn.RowNumber) = rowNumber
                        dr(SDTColumn.PartsName) = str(CsvDataColumnType1.PartsName)
                        dr(SDTColumn.PartsModelName) = str(CsvDataColumnType1.PartsModelName)
                        dr(SDTColumn.PartsCode) = str(CsvDataColumnType1.PartsCode)
                        dr(SDTColumn.Shogen) = str(CsvDataColumnType1.Shogen)
                        dr(SDTColumn.UseCount) = str(CsvDataColumnType1.UseCount)
                        DtShogenhyouData.Rows.Add(dr)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message & vbCrLf & "諸元表の読込を中断します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = False
                        Exit For
                    End Try
                Else
                    'データ行終了
                    Exit For
                End If
                If result = True Then
                    If DtShogenhyouData.Rows.Count = 0 Then
                        MessageBox.Show("諸元表の有効データがありませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = False
                    End If
                End If
            End If

        Next
        Return result
    End Function

    ''' <summary>
    ''' 諸元表フォーマットのFileType.Type2のデータを取得し、ShogenhyouInfo及びDtShogenhyouDataに格納する。
    ''' </summary>
    ''' <param name="csvRecords">
    ''' 諸元表ファイルのCSV読込データ
    ''' </param>
    ''' <returns></returns>
    Private Function GetType2FileData(ByVal csvRecords As System.Collections.ArrayList) As Boolean
        Dim result As Boolean = True

        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To count - 1
            Dim str() As String = csvRecords(i)
            If (i = Type2Row.ShogenhyoInfoHeader) OrElse (i = Type2Row.DataHeader) Then
                'ヘッダー行のため処理無し
                '１行目は標摘情報のヘッダー
                '３行目はデータ行のヘッダー
                Continue For
            End If

            '2行目のデータから諸元表情報を取得
            If i = Type2Row.ShogenhyoInfoData Then
                ShogenhyoInfo.Model = str(CsvHeader1ColumnType2.ModelName)
                ShogenhyoInfo.HyotekiNumber = str(CsvHeader1ColumnType2.HyotekiNumber)
                ShogenhyoInfo.HyotekiRevision = str(CsvHeader1ColumnType2.HyotekiRevision)
                ShogenhyoInfo.OutputDate = str(CsvHeader1ColumnType2.OutputDate)
            End If

            '4行目以降はデータ行処理
            If Type2Row.Data <= i Then
                'データ項目数が異なる
                If UBound(str) <> (ShogenhyoDataColumnNum.Type2 - 1) Then
                    'データ行終了
                    Exit For
                End If

                'データ行終了判断1(データ列に何か入っているか)
                If str(CsvDataColumnType2.Number) <> Nothing Then

                    Dim rowNumber As Integer = -1
                    Try
                        'データ行終了判断2(Integerに変換できるか)
                        rowNumber = Integer.Parse(str(CsvDataColumnType2.Number))
                        If str(CsvDataColumnType1.PartsName) = Nothing Then
                            Continue For
                        End If
                    Catch ex As Exception
                        'データ行終了
                        Exit For
                    End Try

                    Try
                        Dim dr As DataRow = DtShogenhyouData.NewRow()
                        dr(SDTColumn.RowNumber) = rowNumber
                        dr(SDTColumn.PartsName) = str(CsvDataColumnType2.PartsName)
                        dr(SDTColumn.PartsModelName) = str(CsvDataColumnType2.PartsModelName)
                        dr(SDTColumn.PartsCode) = str(CsvDataColumnType2.PartsCode)
                        dr(SDTColumn.Shogen) = str(CsvDataColumnType2.Shogen)
                        dr(SDTColumn.UseCount) = str(CsvDataColumnType2.UseCount)
                        DtShogenhyouData.Rows.Add(dr)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message & vbCrLf & "諸元表の読込を中断します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = False
                        Exit For
                    End Try
                Else
                    'データ行終了
                    Exit For
                End If
            End If

        Next
        If result = True Then
            If DtShogenhyouData.Rows.Count = 0 Then
                MessageBox.Show("諸元表の有効データがありませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                result = False
            End If
        End If

        Return result
    End Function
    ''' <summary>
    ''' 諸元表フォーマットのFileType.Unknownのデータを取得し、ShogenhyouInfo及びDtShogenhyouDataに格納する。
    ''' </summary>
    ''' <param name="csvRecords">
    ''' 諸元表ファイルのCSV読込データ
    ''' </param>
    ''' <returns></returns>
    Private Function GetTypeUnknownFileData(ByVal csvRecords As System.Collections.ArrayList) As Boolean
        Dim result As Boolean = True

        MessageBox.Show("諸元表ファイル形式が不明のため、読み込みできません。", "諸元表読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        result = False

        Return result
    End Function

    ''' <summary>
    ''' 諸元表のファイル形式をファイルの１行目の内容から判断し取得する。
    ''' </summary>
    ''' <param name="str">
    ''' 諸元表CSVファイルの１行目文字配列
    ''' </param>
    ''' <returns>
    ''' FileTypeを返す。（Enum FileType参照）
    ''' </returns>
    Private Function GetFileType(ByVal str As String()) As Integer

        Dim count As Integer = UBound(str) + 1
        Dim type As Integer = ShogenhyoFileType.Unknown

        Select Case count
            Case HeaderColumnCount
                'Normalの場合は、NomalTypeHeader(NormalColumn.Type)部分の一致でしか判別できない
                If str(3) = Type1Header(CsvHeaderColumnType1.Type) Then
                    type = ShogenhyoFileType.Type1
                Else
                    'FileType.ExtendType1かの判断
                    Dim match As Boolean = False
                    For i As Integer = 0 To UBound(Type2Header)
                        If str(i) <> Type2Header(i) Then
                            match = False
                            Exit For
                        Else
                            match = True
                        End If
                    Next
                    If match = True Then
                        type = ShogenhyoFileType.Type2
                    Else
                        type = ShogenhyoFileType.Unknown
                    End If
                End If

            Case Else
                type = ShogenhyoFileType.Unknown
        End Select

        Return type
    End Function
    ''' <summary>
    ''' DtShogenhyouDataデータテーブルから重複データ削除済みの部材コード列データのみを取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得した部材コードデータテーブル
    ''' </returns>
    Public Function GetPartsCodeList() As DataTable
        Dim dv As DataView = DtShogenhyouData.DefaultView
        Dim dt As DataTable = dv.ToTable(True, SDTColumnName(SDTColumn.PartsCode))
        Return dt
    End Function
End Class
