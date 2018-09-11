Public Class CotrolSettingCsv
    Inherits ReadCsv
    Public AppConfigData As ApplicationConfigData = New ApplicationConfigData
    'ＤＢ定義
    Public DefMasterDb As DefineMasterDb = New DefineMasterDb


    ''' <summary>
    ''' 設定ファイルを読込む
    ''' </summary>
    ''' <param name="appConfig">
    ''' アプリケーションセッティングオブジェクト
    ''' </param>
    ''' <returns>
    ''' 0:正常終了　-1:設定ファイルではない
    ''' </returns>
    ''' <remarks></remarks>
    Public Function ReadFile(ByVal appConfig As ApplicationConfigData, ByVal defMstDb As DefineMasterDb) As Integer
        AppConfigData = appConfig.Clone
        DefMasterDb = defMstDb.Clone
        Dim filepath As String = AppConfigData.ApplicationExcecutePath & "\" & AppConfigData.SettingCsvFileName
        If System.IO.File.Exists(filepath) = False Then
            Return 1
        End If

        Dim csvRecords As System.Collections.ArrayList = GetCsvFileCollection(filepath)

        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To count - 1
            Dim str() As String = csvRecords(i)
            Dim strItem As String = str(0)

            'ファイルヘッダー確認
            If i = 0 And strItem <> AppConfigData.SettingCsvHeader Then
                MessageBox.Show("このファイルは、" & AppConfigData.SettingCsvHeader & "ではありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return -1
            End If

            '設定値読み込み
            Select Case strItem
                Case "ヘッダー"
                    Continue For
                Case "設定値"
                    Select Case str(1)
                        Case "SystemDataPath"
                            AppConfigData.SetSystemDataPath(str(2))
                            DefMasterDb.DbPath = AppConfigData.SystemDataPath.Db
                        Case "UseTimesCalender"
                            AppConfigData.IsUseTimesCalender = CType(str(2), Boolean)
                        Case "ProjectorWidth"
                            AppConfigData.ProjectorWidth = CType(str(2), Double)
                        Case "ProjectorHeight"
                            AppConfigData.ProjectorHeight = CType(str(2), Double)
                    End Select
                Case Else
                    Continue For
            End Select
        Next
        Return 0
    End Function
    ''' <summary>
    ''' 設定値をCSVファイルに書き込む
    ''' </summary>
    ''' <param name="appConfig">
    ''' アプリケーションセッティングオブジェクト
    ''' </param>
    ''' <returns>
    ''' True:書込み成功　False:書込み失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function WriteFile(ByVal appConfig As ApplicationConfigData) As Boolean
        Dim filepath As String = appConfig.ApplicationExcecutePath & "\" & appConfig.SettingCsvFileName

        Try

            'CSVファイルに書き込むときに使うEncoding
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

            '書き込むファイルを開く
            'Dim sr As New System.IO.StreamWriter(path, True, enc)
            Using sr As New System.IO.StreamWriter(filepath, False, enc)
                Dim sbFieldString As New System.Text.StringBuilder
                'セッティングファイル認識ヘッダ---------------------------------------------
                sbFieldString.Append(appConfig.SettingCsvHeader)
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)

                '項目ヘッダー---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append("ヘッダー,項目,値")
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)
                '---------------------------------------------------------------------------

                'SystemFolderPath---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append("設定値,")
                sbFieldString.Append("SystemDataPath,")
                sbFieldString.Append(appConfig.SystemDataPath.Root)
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)
                '---------------------------------------------------------------------------

                'UseTimesCalender---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append("設定値,")
                sbFieldString.Append("UseTimesCalender,")
                sbFieldString.Append(appConfig.IsUseTimesCalender.ToString)
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)
                '---------------------------------------------------------------------------
                'UseTimesCalender---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append("設定値,")
                sbFieldString.Append("ProjectorWidth,")
                sbFieldString.Append(appConfig.ProjectorWidth.ToString)
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)
                '---------------------------------------------------------------------------
                'UseTimesCalender---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.Append("設定値,")
                sbFieldString.Append("ProjectorHeight,")
                sbFieldString.Append(appConfig.ProjectorHeight.ToString)
                sr.Write(sbFieldString.ToString)
                sr.Write(vbCrLf)
                '---------------------------------------------------------------------------

                ''閉じる
                'sr.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function


End Class


