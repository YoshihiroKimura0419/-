Public Class ControlDbWorkLog
    Inherits ControlDb
    Implements ICloneable
    'データベース設定オブジェクト定義
    Public DefWlogDb As DefineWorkLogDb
    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    Public Sub New(ByVal defDb As DefineWorkLogDb)
        DefWlogDb = defDb.Clone
    End Sub
    ''' <summary>
    ''' ICloneable.Cloneの実装
    ''' </summary>
    ''' <returns></returns>
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

    ''' <summary>
    ''' 作業中およびログデータを保存するフォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' システムデータフォルダ文字列
    ''' </param>
    Public Sub SetWorkingDataAndLogDbPath(ByRef sysDataPath As String)
        DefWlogDb.DbPath = String.Format("{0}\{1}", sysDataPath, DefWlogDb.WorkLogFolderName)
    End Sub
    ''' <summary>
    ''' 作業中データDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得した接続文字列
    ''' </returns>
    Public Function GetWorkingDataDbConnectString() As String
        '接続文字列作成
        Dim connectString As String = Nothing

        '接続
        If DefWlogDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = String.Format("Provider={0};Data Source={1}\{2}{3}", DefWlogDb.Provider, DefWlogDb.DbPath, DefWlogDb.DbWorkingDbName, DefWlogDb.ConnectPassword)
        Else
            'パスワードなしで接続する場合
            connectString = String.Format("Provider={0};Data Source={1}\{2}", DefWlogDb.Provider, DefWlogDb.DbPath, DefWlogDb.DbWorkingDbName)
        End If
        Return connectString
    End Function
    ''' <summary>
    ''' 作業ログデータDB接続用文字列を取得する。
    ''' </summary>
    ''' <param name="yyyyMMString">
    ''' 取得したい作業ログデータの年月文字列
    ''' 文字列はyyyy:西暦　MM:月(01～12)
    ''' </param>
    ''' <returns></returns>
    Public Function GetWorkLogDbConnectString(ByVal yyyyMMString As String) As String

        '接続文字列作成
        Dim connectString As String = Nothing
        Dim dbFileName As String = String.Format("{0}{1}{2}", DefWlogDb.DbWorkLogFilenameHeader, yyyyMMString, DefWlogDb.DbExtention)
        '接続
        If DefWlogDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = String.Format("Provider={0};Data Source={1}\{2}{3}", DefWlogDb.Provider, DefWlogDb.DbPath, dbFileName, DefWlogDb.ConnectPassword)
        Else
            'パスワードなしで接続する場合
            connectString = String.Format("Provider={0};Data Source={1}\{2}", DefWlogDb.Provider, DefWlogDb.DbPath, dbFileName)
        End If
        Return connectString
    End Function
    ''' <summary>
    ''' SQL文内で指定する作業中データDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得したSQL文用の作業中データDBパス文字列
    ''' </returns>
    Public Function GetSqlWorkingDataDbPathString() As String
        Dim dbNameString As String = Nothing
        '接続
        If DefWlogDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = String.Format("[{0}\{1}{2}]", DefWlogDb.DbPath, DefWlogDb.DbWorkingDbName, DefWlogDb.SqlPassword)
        Else
            'パスワードなしで接続する場合
            dbNameString = String.Format("[{0}\{1}]", DefWlogDb.DbPath, DefWlogDb.DbWorkingDbName)
        End If

        Return dbNameString
    End Function
    ''' <summary>
    ''' SQL文内で指定する作業ログデータDB接続用文字列を取得する。
    ''' </summary>
    ''' <param name="yyyyMMString">
    ''' 取得したい作業ログデータの年月文字列
    ''' 文字列はyyyy:西暦　MM:月(01～12)
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文用の作業ログDBパス文字列
    ''' </returns>
    Public Function GetSqlWorkLogDbPathString(ByVal yyyyMMString As String) As String
        Dim dbFileName As String = String.Format("{0}{1}{2}", DefWlogDb.DbWorkLogFilenameHeader, yyyyMMString, DefWlogDb.DbExtention)
        Dim dbNameString As String = Nothing
        '接続
        If DefWlogDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = String.Format("[{0}\{1}{2}]", DefWlogDb.DbPath, dbFileName, DefWlogDb.SqlPassword)
        Else
            'パスワードなしで接続する場合
            dbNameString = String.Format("[{0}\{1}]", DefWlogDb.DbPath, dbFileName)
        End If

        Return dbNameString
    End Function

    ''' <summary>
    ''' 作業中ファイルパスを取得する
    ''' </summary>
    ''' <returns>
    ''' 作業中ファイルのフルパス文字列
    ''' </returns>
    Public Function GetWorkingDataDbPathString() As String
        Dim dbNameString As String = Nothing
        dbNameString = String.Format("{0}\{1}", DefWlogDb.DbPath, DefWlogDb.DbWorkingDbName)
        Return dbNameString
    End Function
    ''' <summary>
    ''' 作業ログファイルの雛形ファイルのパスを取得する
    ''' </summary>
    ''' <returns></returns>
    Public Function GetWorLogTemplateDbPathString() As String
        Dim dbNameString As String = Nothing
        dbNameString = String.Format("{0}\{1}", DefWlogDb.DbPath, DefWlogDb.DbTemplateName)
        Return dbNameString
    End Function
    ''' <summary>
    ''' 作業ログDBのファイルパスを取得する
    ''' </summary>
    ''' <param name="yyyyMMString">
    ''' 取得したい作業ログデータの年月文字列
    ''' 文字列はyyyy:西暦　MM:月(01～12)
    ''' </param>
    ''' <returns>
    ''' 作業ログファイルのフルパス文字列
    ''' </returns>
    Public Function GetWorkLogDbPathString(ByVal yyyyMMString As String) As String
        Dim dbFileName As String = String.Format("{0}{1}{2}", DefWlogDb.DbWorkLogFilenameHeader, yyyyMMString, DefWlogDb.DbExtention)
        Dim dbNameString As String = Nothing
        dbNameString = String.Format("{0}\{1}", DefWlogDb.DbPath, dbFileName)
        Return dbNameString
    End Function
    Public Function GetWorkingCount(ByVal order As String, ByVal workerManNumber As String) As Integer
        '接続文字列取得
        Dim connect_txt As String = GetWorkingDataDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        'accdbでは、SELECT COUNT(DISTINCT 属性2) From テーブル1のような記述ができない

        sbSql.AppendLine("Select")
        sbSql.AppendLine(String.Format("Count({0})", WLTColumnName(WLTColumn.SerialNo)))
        sbSql.AppendLine("from")
        sbSql.AppendLine("(")
        sbSql.AppendLine("Select")
        sbSql.AppendLine(String.Format("Distinct {0}", WLTColumnName(WLTColumn.SerialNo)))
        sbSql.AppendLine("from")
        sbSql.AppendLine(DefWlogDb.TableWorkLog)
        sbSql.AppendLine("Where")

        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.Order), order))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), workerManNumber))
        sbSql.AppendLine(")")

        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)

        If 0 <= tb.Rows.Count Then
            Return tb.Rows(0)(0)
        Else
            Return -1
        End If
    End Function
    Public Function GetWorkingSerialList(ByVal order As String, ByVal workerManNumber As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetWorkingDataDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("Select")
        sbSql.AppendLine(WLTColumnName(WLTColumn.SerialNo) & ",")
        sbSql.AppendLine(String.Format("MIN({0})", WLTColumnName(WLTColumn.Id)))
        sbSql.AppendLine("from")
        sbSql.AppendLine(DefWlogDb.TableWorkLog)
        sbSql.AppendLine("Where")

        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.Order), order))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), workerManNumber))

        sbSql.AppendLine("group by")
        sbSql.AppendLine(WLTColumnName(WLTColumn.SerialNo))
        sbSql.AppendLine("order by")
        sbSql.AppendLine(String.Format("MIN({0})", WLTColumnName(WLTColumn.Id)))

        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)

        Return tb
    End Function
    Public Function GetWrokingDataWorkEndRowCount(ByVal order As String, ByVal workerManNumber As String, ByVal serialNo As String) As Integer
        '接続文字列取得
        Dim connect_txt As String = GetWorkingDataDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("Select")
        sbSql.AppendLine("count(*)")
        sbSql.AppendLine("from")
        sbSql.AppendLine(DefWlogDb.TableWorkLog)
        sbSql.AppendLine("Where")

        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.Order), order))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), workerManNumber))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.SerialNo), serialNo))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0} is not Null", WLTColumnName(WLTColumn.EndDate)))

        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)

        If (tb.Columns.Count <> 0) Then
            Return tb.Rows(0)(0)
        Else
            Return -1
        End If

    End Function
    Public Function GetWorkingData(ByVal order As String, ByVal workerManNumber As String, ByVal serialNo As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetWorkingDataDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("Select")
        sbSql.AppendLine("*")
        sbSql.AppendLine("from")
        sbSql.AppendLine(DefWlogDb.TableWorkLog)
        sbSql.AppendLine("Where")

        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.Order), order))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), workerManNumber))
        sbSql.AppendLine("and")
        sbSql.AppendLine(String.Format("{0}='{1}'", WLTColumnName(WLTColumn.SerialNo), serialNo))

        sbSql.AppendLine("order by")
        sbSql.AppendLine(WLTColumnName(WLTColumn.Id))

        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)

        Return tb
    End Function

    Public Function GetWorkingDataTemplate() As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetWorkingDataDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("Select")
        sbSql.AppendLine("*")
        sbSql.AppendLine("from")
        sbSql.AppendLine(DefWlogDb.TableWorkLog)
        sbSql.AppendLine("Where")

        sbSql.AppendLine(String.Format("{0}={1}", WLTColumnName(WLTColumn.Id), -1))

        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)

        Return tb

    End Function


End Class
