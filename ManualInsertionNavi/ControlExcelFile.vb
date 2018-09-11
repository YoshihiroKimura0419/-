Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

''' <summary>
''' エクセルファイルコントロールクラス
''' 本クラス使用の注意事項----------------------------------------
''' ModuleDefineStructureExcel.vbを同一プロジェクトに組み込む事。
''' （エクセル関連の構造体を定義）
''' --------------------------------------------------------------
''' </summary>

Public Class ControlExcelFile
    ''' <summary>
    ''' 指定したエクセルファイル名の指定シートの指定セル位置にxlsInsertImageStatusで指定した画像を挿入して保存する。
    ''' </summary>
    ''' <param name="excelFileName">
    ''' エクセルファイル名
    ''' </param>
    ''' <param name="sheetName">
    ''' エクセルシート名
    ''' </param>
    ''' <param name="rowNumber">
    ''' セルの行番号
    ''' </param>
    ''' <param name="colmunNumber">
    ''' セルの列番号
    ''' </param>
    ''' <param name="xlsInsertImageStatus">
    ''' 貼り付ける画像情報構造体
    ''' </param>
    ''' <remarks></remarks>
    Public Sub InsertImage2ExcellFilename(ByVal excelFileName As String, ByVal sheetName As String,
                                          ByVal rowNumber As Integer, ByVal colmunNumber As Integer, _
                                          ByVal xlsInsertImageStatus As ExcelInsertImageStatus)
        Dim xlApp As New Excel.Application()
        If xlApp IsNot Nothing Then
            xlApp.Visible = True
            Dim wb As Excel.Workbook = xlApp.Workbooks.Open(excelFileName)

            InsertImage2ExcellWorkbook(wb, sheetName, rowNumber, colmunNumber, xlsInsertImageStatus)

            xlApp.ActiveWorkbook.Close(True)
            xlApp.Quit()
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(xlApp)
        End If
    End Sub

    ''' <summary>
    ''' エクセルワークブックの指定したシート名のセルに画像を貼り付ける（オフセット有）
    ''' </summary>
    ''' <param name="workBook">
    ''' エクセルワークブック
    ''' </param>
    ''' <param name="sheetName">
    ''' エクセルシート名
    ''' </param>
    ''' <param name="rowNumber">
    ''' セルの行番号
    ''' </param>
    ''' <param name="colmunNumber">
    ''' セルの列番号
    ''' </param>
    ''' <param name="xlsInsertImageStatus">
    ''' 貼り付ける画像情報構造体
    ''' </param>
    ''' <remarks></remarks>
    Public Sub InsertImage2ExcellWorkbook(ByRef workBook As Excel.Workbook, ByVal sheetName As String, _
                                          ByVal rowNumber As Integer, ByVal colmunNumber As Integer, _
                                          ByVal xlsInsertImageStatus As ExcelInsertImageStatus)
        Dim xlCells As Excel.Range
        Dim xlSheets As Excel.Sheets = workBook.Sheets
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(sheetName), Excel.Worksheet)
        Dim colmunStringTypeA1 As String
        colmunStringTypeA1 = GetColumNameAlpha(colmunNumber)

        ''書式含めた行のコピー
        'If rowNumber > 6 Then
        '    Dim strcpyrow As String = rowNumber.ToString & ":" & rowNumber.ToString
        '    xlSheet.Range("6:6").Copy(Destination:=xlSheet.Range(strcpyrow))
        'End If

        xlCells = xlSheet.Range(colmunStringTypeA1 & rowNumber)
        If xlCells IsNot Nothing Then
            Dim shapes As Excel.Shapes = xlSheet.Shapes
            Dim fx As Double = Double.Parse(xlCells.Left.ToString()) + xlsInsertImageStatus.OffsetX
            Dim fy As Double = Double.Parse(xlCells.Top.ToString()) + xlsInsertImageStatus.OffsetY
            shapes.AddPicture(xlsInsertImageStatus.ImageFileName, _
                              Microsoft.Office.Core.MsoTriState.msoFalse, _
                              Microsoft.Office.Core.MsoTriState.msoTrue, _
                              fx, fy, xlsInsertImageStatus.ImageWidth, xlsInsertImageStatus.ImageWidth)
            Marshal.ReleaseComObject(shapes)
        End If

        Marshal.ReleaseComObject(xlCells)
        Marshal.ReleaseComObject(xlSheet)
        Marshal.ReleaseComObject(xlSheets)
    End Sub


    ''' <summary>
    ''' 指定のワークブックのセルに値を設定する.セルの色も設定する
    ''' </summary>
    ''' <param name="workBook">
    ''' エクセルワークブック</param>
    ''' <param name="sheetName">
    ''' エクセルシート名</param>
    ''' <param name="setValue">
    ''' 設定する値</param>
    ''' <param name="rowNumber">
    ''' 値を設定するセルの行番号</param>
    ''' <param name="colmunNumber">
    ''' 値を設定するセルの列番号</param>
    ''' <param name="useLine">
    ''' セルの周りに罫線を引く　True:罫線を引く False:罫線を引かない</param>
    ''' <remarks></remarks>
    Public Sub SetCellValueColorWorkbook(ByRef workBook As Excel.Workbook, ByVal sheetName As String, ByVal setValue As String, _
                                         ByVal rowNumber As Integer, ByVal colmunNumber As Integer, _
                                         ByVal useLine As Boolean, ByVal setBackColor As System.Drawing.Color)
        Dim xlCells As Excel.Range
        Dim xlBorders As Excel.Borders

        Dim xlSheets As Excel.Sheets = workBook.Sheets
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(sheetName), Excel.Worksheet)

        Dim colmunStringTypeA1 As String
        colmunStringTypeA1 = GetColumNameAlpha(colmunNumber)

        xlCells = xlSheet.Range(colmunStringTypeA1 & rowNumber)
        Dim xlInterior = xlCells.Interior
        xlInterior.Color = System.Drawing.ColorTranslator.ToOle(setBackColor)

        If useLine = True Then
            xlBorders = xlCells.Borders
            xlBorders.LineStyle = Excel.XlLineStyle.xlContinuous
            Marshal.ReleaseComObject(xlBorders)
        End If
        xlCells.Value2 = setValue
        Marshal.ReleaseComObject(xlInterior)
        Marshal.ReleaseComObject(xlCells)
        Marshal.ReleaseComObject(xlSheet)
        Marshal.ReleaseComObject(xlSheets)

    End Sub

    ''' <summary>
    ''' 指定のワークブックの指定セルに値を設定する
    ''' </summary>
    ''' <param name="workBook">
    ''' エクセルワークブック</param>
    ''' <param name="sheetName">
    ''' エクセルシート名
    ''' </param>
    ''' <param name="setValue">
    ''' 設定する値
    ''' </param>
    ''' <param name="rowNumber">
    ''' 値を設定するセルの行番号
    ''' </param>
    ''' <param name="colmunNumber">
    ''' 値を設定するセルの列番号
    ''' </param>
    ''' <param name="useLine">
    ''' セルの周りに罫線を引く　True:罫線を引く False:罫線を引かない
    ''' </param>
    ''' <remarks></remarks>
    Public Sub SetCellValueWorkbook(ByRef workBook As Excel.Workbook, ByVal sheetName As String, ByVal setValue As String, _
                                    ByVal rowNumber As Integer, ByVal colmunNumber As Integer, ByVal useLine As Boolean)
        Dim xlCells As Excel.Range
        Dim xlBorders As Excel.Borders

        Dim xlSheets As Excel.Sheets = workBook.Sheets
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(sheetName), Excel.Worksheet)

        Dim colmunStringTypeA1 As String
        colmunStringTypeA1 = GetColumNameAlpha(colmunNumber)

        xlCells = xlSheet.Range(colmunStringTypeA1 & rowNumber)

        If useLine = True Then
            xlBorders = xlCells.Borders
            xlBorders.LineStyle = Excel.XlLineStyle.xlContinuous
            Marshal.ReleaseComObject(xlBorders)
        End If
        xlCells.Value2 = setValue
        Marshal.ReleaseComObject(xlCells)
        Marshal.ReleaseComObject(xlSheet)
        Marshal.ReleaseComObject(xlSheets)

    End Sub


    ''' <summary>
    ''' エクセルワークブックの指定シートの指定セルのデータを取得する
    ''' </summary>
    ''' <param name="workBook">
    ''' ワークブックオブジェクト
    ''' </param>
    ''' <param name="sheetName">
    ''' セルのデータを取得するシート名
    ''' </param>
    ''' <param name="rowNumber">
    ''' セルの行位置
    ''' </param>
    ''' <param name="colmunNumber">
    ''' セルの列位置
    ''' </param>
    ''' <returns>
    ''' 取得したセルの文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetCellValueWorkbook(ByRef workBook As Excel.Workbook, ByVal sheetName As String, _
                                         ByVal rowNumber As Integer, ByVal colmunNumber As Integer) As String
        Dim str As String
        Dim xlCells As Excel.Range

        Dim xlSheets As Excel.Sheets = workBook.Sheets
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(sheetName), Excel.Worksheet)

        Dim colmunStringTypeA1 As String
        colmunStringTypeA1 = GetColumNameAlpha(colmunNumber)

        xlCells = xlSheet.Range(colmunStringTypeA1 & rowNumber)

        str = xlCells.Value2
        Marshal.ReleaseComObject(xlCells)
        Marshal.ReleaseComObject(xlSheet)
        Marshal.ReleaseComObject(xlSheets)
        Return str
    End Function

    ''' <summary>
    ''' SaveDialogを開き、DataGridViewの内容をエクセルに保存するメイン処理
    ''' </summary>
    ''' <param name="dgv">
    ''' DataGridViewオブジェクト
    ''' </param>
    ''' <param name="useOverWritePrompt">
    ''' SaveDialogで上書き確認を行うかどうか　True:確認する False:確認しない
    ''' </param>
    ''' <param name="initialDirectry">
    ''' SaveDialogで表示する初期フォルダパス
    ''' </param>
    ''' <returns>
    ''' 保存したファイル名。保存しなかった場合：””
    ''' </returns>
    ''' <remarks></remarks>
    Function SaveDgvDataToExcel(ByRef dgv As DataGridView, ByVal useOverWritePrompt As Boolean, ByVal initialDirectry As String) As String
        Dim sd As SaveFileDialog = New SaveFileDialog
        Dim isCancelSave As Boolean = False

        'SaveDialog処理
        Dim dresult As DialogResult
        If initialDirectry IsNot Nothing Then
            If System.IO.Directory.Exists(initialDirectry) = True Then
                sd.InitialDirectory = initialDirectry
            Else
                sd.InitialDirectory = "c:\"
            End If
        Else
            sd.InitialDirectory = "c:\"
        End If
        sd.Title = "Excelファイルへ出力"
        sd.DefaultExt = "xlsx"
        sd.Filter = "Excelファイル |*.xlsx*"
        sd.OverwritePrompt = useOverWritePrompt
        dresult = sd.ShowDialog()
        If dresult = Windows.Forms.DialogResult.Cancel Then
            Return ""
        End If

        Dim fileName As String = ""
        fileName = sd.FileName

        '指定ファイルの既存確認
        Dim isExistSaveFile As Boolean = False
        If System.IO.File.Exists(fileName) = True Then
            isExistSaveFile = True
        End If

        'Excelシートのインスタンスを作る
        Dim ExcelApp As New Excel.Application()
        Dim wbs As Excel.Workbooks = Nothing
        Dim wb As Excel.Workbook = Nothing
        Dim shs As Excel.Sheets = Nothing
        Dim ws As Excel.Worksheet = Nothing

        'シート追加情報構造体作成＆初期化
        Dim xlsAddSheetStatus As New ExcelAddSheetStatus
        xlsAddSheetStatus.InitializeParam()

        Try
            If isExistSaveFile = False Then
                '新規作成
                wbs = ExcelApp.Workbooks
                wb = wbs.Add()
                shs = wb.Sheets
                ws = shs(1)
                ws.Select(Type.Missing)
                Dim temname As String = ""
                Do While temname = ""
                    temname = InputBox("作成するシート名を入力してください。", "シート名入力", "sheet1")
                Loop
                xlsAddSheetStatus.SheetName = temname
                xlsAddSheetStatus.IsSelect = True
            Else
                '上書き保存
                wbs = ExcelApp.Workbooks
                wb = wbs.Open(fileName)

                'エクセルシート追加情報構造体取得
                xlsAddSheetStatus = GetExcelSheetNameBySeletComboboxForm(wb, True)
                If xlsAddSheetStatus.IsSelect Then
                    'シート選択が行われた
                    shs = wb.Sheets
                    If xlsAddSheetStatus.IsAddSheet = True Then
                        ws = shs.Add()
                        ws.Name = xlsAddSheetStatus.SheetName
                    Else
                        ws = DirectCast(shs(xlsAddSheetStatus.SheetName), Excel.Worksheet)
                    End If
                    'シート内データ削除処理
                    Dim strclsrow As String = "1:" & ws.Rows.Count
                    ws.Range(strclsrow).Delete()
                Else
                    'シート選択がキャンセルされた
                    MessageBox.Show("保存処理を取り消しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            If xlsAddSheetStatus.IsSelect = True Then
                '指定シートへデータを出力
                ExcelApp.Visible = False
                OutputDgvData2ExcelSheet(dgv, wb, xlsAddSheetStatus.SheetName)
                Try
                    wb.SaveAs(fileName)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    isCancelSave = True
                End Try
            Else
                isCancelSave = True
            End If

            wb.Close(False)
            ExcelApp.Quit()
        Finally
            'Excelのオブジェクトを開放し忘れているとプロセスが落ちないため注意
            Marshal.ReleaseComObject(ws)
            Marshal.ReleaseComObject(shs)
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(wbs)
            Marshal.ReleaseComObject(ExcelApp)
            ws = Nothing
            shs = Nothing
            wb = Nothing
            wbs = Nothing
            ExcelApp = Nothing

            GC.Collect()

        End Try

        If isCancelSave = True Then
            Return ""
        End If
        Return fileName

    End Function

    ''' <summary>
    ''' DataGridViewの内容を指定したファイル名の指定したシートに書き出しエクセルファイルとして保存する。
    ''' </summary>
    ''' <param name="dgv">
    ''' DataGridViewオブジェクト
    ''' </param>
    ''' <param name="fileName">
    ''' 保存ファイルのフルパス
    ''' </param>
    ''' <param name="sheetName">
    ''' 保存シート名
    ''' </param>
    ''' <returns>
    ''' 保存したファイル名。保存しなかった場合：""
    ''' </returns>
    ''' <remarks></remarks>
    Function SaveDgvData2ExcelSheetName(ByRef dgv As DataGridView, ByVal fileName As String, ByVal sheetName As String) As String
        Dim save_cancel As Boolean = False

        'MessageBox.Show("filename:" & file_name)

        'Excelシートのインスタンスを作る
        Dim ExcelApp As New Excel.Application()
        Dim wbs As Excel.Workbooks = Nothing
        Dim wb As Excel.Workbook = Nothing
        Dim shs As Excel.Sheets = Nothing
        Dim ws As Excel.Worksheet = Nothing

        Try
            wbs = ExcelApp.Workbooks
            wb = wbs.Open(fileName)

            shs = wb.Sheets
            ws = DirectCast(shs(sheetName), Excel.Worksheet)
            'ws.Select(Type.Missing)
            ExcelApp.Visible = False

            OutputDgvData2ExcelSheet(dgv, wb, sheetName)
            Try
                wb.SaveAs(fileName)
            Catch ex As Exception
                MessageBox.Show("保存処理を取り消します。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                save_cancel = True
            End Try
            wb.Close(False)
            ExcelApp.Quit()
        Finally
            'Excelのオブジェクトを開放し忘れているとプロセスが落ちないため注意
            Marshal.ReleaseComObject(ws)
            Marshal.ReleaseComObject(shs)
            Marshal.ReleaseComObject(wb)
            Marshal.ReleaseComObject(wbs)
            Marshal.ReleaseComObject(ExcelApp)
            ws = Nothing
            shs = Nothing
            wb = Nothing
            wbs = Nothing
            ExcelApp = Nothing

            GC.Collect()

        End Try

        If save_cancel = True Then
            Return ""
        End If
        Return fileName
    End Function
    '''<summary>
    ''' dgvのデータをエクセルワークブック(workBook)のシート(sheetName)に書き出す。書き出しは１行目から実施。
    ''' 
    '''</summary>
    '''<param name="dgv">
    ''' データ元のDataGridViewオブジェクト
    '''</param>
    '''<param name="workBook">
    ''' データを書き出すエクセルワークブック
    '''</param>
    '''<param name="sheetName">
    ''' データを書き出すエクセルのシート名
    '''</param>
    '''<remarks></remarks>
    Sub OutputDgvData2ExcelSheet(ByRef dgv As DataGridView, ByRef workBook As Excel.Workbook, ByVal sheetName As String)
        Dim fpo As New FormMessage
        fpo.Title = "エクセル出力"        'ダイアログのタイトルを設定
        fpo.Message = ""
        fpo.Minimum = 0                     'プログレスバーの最小値を設定
        fpo.Maximum = dgv.Rows.Count - 1 'プログレスバーの最大値を設定
        fpo.Value = 0                       'プログレスバーの初期値を設定
        fpo.Show()                        '進行状況ダイアログを表示する


        Dim headerRowCount As Integer = 1

        For i As Integer = 0 To dgv.ColumnCount - 1
            SetCellValueWorkbook(workBook, sheetName, dgv.Columns(i).HeaderText, headerRowCount, i + 1, True)
        Next

        Dim str As String = ""
        For row = 0 To dgv.Rows.Count - 1
            fpo.Message = "データ出力中・・・(" & row & "/" & dgv.Rows.Count & ")"
            fpo.Value = row                    'プログレスバーの初期値を設定
            For i As Integer = 0 To dgv.ColumnCount - 1
                'Dim back_col As System.Drawing.Color
                If dgv.Rows(row).Cells(i).Value IsNot DBNull.Value Then
                    'back_col = dgv.Rows(row).Cells(i).Style.BackColor
                    str = CType(dgv.Rows(row).Cells(i).Value, String)
                Else
                    str = ""
                End If
                SetCellValueWorkbook(workBook, sheetName, str, row + headerRowCount + 1, i + 1, True)
                'subExcellSetValueColorWb(wb, sheet_name, str, row + count, i + 1, True, back_col)
            Next
        Next
        fpo.Value = fpo.Maximum
        'ダイアログを閉じる
        fpo.CloseWindow()

    End Sub
    ''' <summary>
    ''' dgvのデータをエクセルワークブック(workBook)のシート(sheetName)に書き出す。書き出しはstartRowから実施。
    ''' </summary>
    ''' <param name="dgv">
    ''' データ元のDataGridViewオブジェクト
    ''' </param>
    ''' <param name="workBook">
    ''' データを書き出すエクセルワークブック
    ''' </param>
    ''' <param name="sheetName">
    ''' データを書き出すエクセルのシート名
    ''' </param>
    ''' <param name="startRow">
    ''' データを書き出す開始行
    ''' </param>
    ''' <remarks></remarks>
    Sub OutputDgvData2ExcelSheet(ByRef dgv As DataGridView, ByRef workBook As Excel.Workbook, ByVal sheetName As String, ByVal startRow As Integer)
        Dim fpo As New FormMessage
        fpo.Title = "エクセル出力"        'ダイアログのタイトルを設定
        fpo.Message = ""
        fpo.Minimum = 0                     'プログレスバーの最小値を設定
        fpo.Maximum = dgv.Rows.Count - 1 'プログレスバーの最大値を設定
        fpo.Value = 0                       'プログレスバーの初期値を設定
        fpo.Show()                        '進行状況ダイアログを表示する

        Dim headerRowCount As Integer = 1

        For i As Integer = 0 To dgv.ColumnCount - 1
            SetCellValueWorkbook(workBook, sheetName, dgv.Columns(i).HeaderText, headerRowCount, i + 1, True)
        Next

        Dim cellSetString As String = ""
        For rowNumber = 0 To dgv.Rows.Count - 1
            fpo.Message = "データ出力中・・・(" & rowNumber & "/" & dgv.Rows.Count & ")"
            fpo.Value = rowNumber                    'プログレスバーの初期値を設定
            For i As Integer = 0 To dgv.ColumnCount - 1
                'Dim back_col As System.Drawing.Color
                If dgv.Rows(rowNumber).Cells(i).Value IsNot DBNull.Value Then
                    'back_col = dgv.Rows(row).Cells(i).Style.BackColor
                    cellSetString = CType(dgv.Rows(rowNumber).Cells(i).Value, String)
                Else
                    cellSetString = ""
                End If
                SetCellValueWorkbook(workBook, sheetName, cellSetString, rowNumber + headerRowCount + 1, i + 1, True)
                'subExcellSetValueColorWb(wb, sheet_name, str, row + count, i + 1, True, back_col)
            Next
        Next
        fpo.Value = fpo.Maximum
        'ダイアログを閉じる
        fpo.CloseWindow()

    End Sub
    ''' <summary>
    ''' エクセルの列番号をアルファベット表記に変換する
    ''' </summary>
    ''' <param name="rowNumber">
    ''' エクセルの列番号
    ''' </param>
    ''' <returns>
    ''' 変換後のA1形式のA部分のアルファベット文字列
    ''' </returns>
    ''' <remarks></remarks>
    Function GetColumNameAlpha(ByVal rowNumber As Integer) As String
        Dim base As Integer = 26
        Dim num() As Integer
        ReDim num(0)
        rowNumber -= 1
        Dim sho As Integer
        Dim i As Integer = 0
        sho = rowNumber \ base
        num(0) = rowNumber Mod base

        Do While sho > 0
            i += 1
            ReDim Preserve num(i)
            num(i) = (sho Mod base) - 1
            sho = sho \ base
        Loop

        Dim str1, str2 As String
        str1 = ""
        i = UBound(num)
        Do
            Dim code As Integer = Asc("A")
            code += num(i)
            str2 = Chr(code)
            str1 += str2
            i -= 1
        Loop While i >= 0

        Return str1
    End Function

    ''' <summary>
    ''' シート名選択ダイアログを表示し、選択したシート名を取得する。
    ''' </summary>
    ''' <param name="workBook">
    ''' シートを選択するエクセルワークブックオブジェクト
    ''' </param>
    ''' <param name="isVisibleAddSheetCheckbox">
    ''' 新規シート追加チェックボックスを表示するか
    ''' True:表示　False:非表示
    ''' </param>
    ''' <returns>
    ''' True:シート名選択ダイアログでOKボタンが押された
    ''' False:シート名選択ダイアログでキャンセルボタンが押された
    ''' </returns>
    ''' <remarks>
    ''' 2017/07/13　追加　木村（欣）
    ''' </remarks>
    Public Function GetExcelSheetNameBySeletComboboxForm(ByRef workBook As Excel.Workbook, ByVal isVisibleAddSheetCheckbox As Boolean) As ExcelAddSheetStatus
        'シート追加情報宣言
        Dim xlsAddSheetStatus As New ExcelAddSheetStatus
        'シート追加パラメータ初期化
        xlsAddSheetStatus.InitializeParam()

        'エクセルファイルのシート選択----------------------------------------------------
        Dim sheetnameList As New List(Of String)
        Dim xlSheets As Excel.Sheets = Nothing
        xlSheets = workBook.Worksheets
        For i As Integer = 1 To xlSheets.Count
            Dim xlSheet As Excel.Worksheet = Nothing
            xlSheet = DirectCast(xlSheets(i), Excel.Worksheet)
            sheetnameList.Add(xlSheet.Name)
            Marshal.ReleaseComObject(xlSheet)
        Next
        Marshal.ReleaseComObject(xlSheets)

        'シート選択ダイアログの表示
        Dim fm As FormComboboxSelect = New FormComboboxSelect("シート選択", sheetnameList, isVisibleAddSheetCheckbox)
        Dim dresult As DialogResult = fm.ShowDialog()

        If dresult = Windows.Forms.DialogResult.OK Then
            'シート名が選択された場合
            xlsAddSheetStatus.IsAddSheet = fm.AddNewSheet
            xlsAddSheetStatus.SheetName = fm.SelectedSheetName
            xlsAddSheetStatus.IsSelect = True
        Else
            'シート名選択がキャンセルされた場合
            xlsAddSheetStatus.IsAddSheet = False
            xlsAddSheetStatus.SheetName = Nothing
            xlsAddSheetStatus.IsSelect = False
        End If

        If fm IsNot Nothing Then
            fm.Dispose()
        End If

        Return xlsAddSheetStatus
    End Function

End Class

