Public Class ControlDbOrder
    Inherits ControlDb
    Implements ICloneable

    'データベース設定オブジェクト定義
    Public DefOrdDb As DefineOrderDb


    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefineOrderDb)
        DefOrdDb = defDb.Clone
    End Sub
    ''' <summary>
    ''' ICloneable.Cloneの実装
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

    ''' <summary>
    ''' オーダー管理DB保存フォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' 本システムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetDbPath(ByRef sysDataPath As String)
        DefOrdDb.DbPath = sysDataPath & "\DB"
    End Sub
    ''' <summary>
    ''' オーダー管理DB保存フォルダを取得する。
    ''' </summary>
    Public Function GetDbPath() As String
        Return DefOrdDb.DbPath
    End Function

    ''' <summary>
    ''' マスターDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得した接続文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetMasterDbConnectString() As String
        '接続文字列作成
        Dim connectString As String = Nothing

        '接続
        If DefOrdDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = "Provider=" & DefOrdDb.Provider & ";Data Source=" & DefOrdDb.DbPath & "\" & DefOrdDb.DbName & DefOrdDb.ConnectPassword
        Else
            'パスワードなしで接続する場合
            connectString = "Provider=" & DefOrdDb.Provider & ";Data Source=" & DefOrdDb.DbPath & "\" & DefOrdDb.DbName
        End If
        Return connectString
    End Function
    ''' <summary>
    ''' マスターDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得したマスターDBのパス
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetMasterDbPathString() As String
        Dim dbNameString As String = Nothing
        '接続
        If DefOrdDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = "[" & DefOrdDb.DbPath & "\" & DefOrdDb.DbName & DefOrdDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合
            dbNameString = "[" & DefOrdDb.DbPath & "\" & DefOrdDb.DbName & "]"
        End If

        Return dbNameString
    End Function
    Public Function GetOrderOneDataFromTable(ByVal order As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefOrdDb.TableOrder)
        If order = Nothing Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(OMTColumnName(OMTColumn.Order) & "='Nothing'")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(OMTColumnName(OMTColumn.Order) & "='" & order & "'")
        End If
        'データの読み込み
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    Public Function GetOrderList(ByVal buId As Integer, ByRef list As List(Of String)) As Boolean
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()
        Dim dbNameOrder As String = GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("distinct")
        sbSql.AppendLine(String.Format("a.{0} as {1},", OMTColumnName(OMTColumn.Order), OMTColumnName(OMTColumn.Order)))
        sbSql.AppendLine(String.Format("b.{0} as {1}", BUMTColumnName(BUMTColumn.BuName), BUMTColumnName(BUMTColumn.BuName)))

        sbSql.AppendLine("FROM")
        sbSql.AppendLine(String.Format("{0}.[{1}] as a", dbNameOrder, DefOrdDb.TableOrder))
        sbSql.AppendLine("left join ")
        sbSql.AppendLine(String.Format("{0}.[{1}] as b", dbNameOrder, DefOrdDb.TableBu))
        sbSql.AppendLine("on ")
        sbSql.AppendLine(String.Format("a.{0}=b.{1}", OMTColumnName(OMTColumn.BuId), BUMTColumnName(BUMTColumn.ID)))
        sbSql.AppendLine("where ")
        sbSql.AppendLine(String.Format("a.{0}={1}", OMTColumnName(OMTColumn.BuId), buId))
        sbSql.AppendLine("order by")
        sbSql.AppendLine(String.Format("a.{0}", OMTColumnName(OMTColumn.Order)))

        Dim dt As DataTable = GetTableData(sbSql.ToString, connect_txt)
        If dt.Columns.Count < 1 Then
            Return False
        End If
        For Each row As DataRow In dt.Rows
            If row(OMTColumnName(OMTColumn.Order)) IsNot DBNull.Value Then
                list.Add(row(OMTColumnName(OMTColumn.Order)))
            End If
        Next
        Return True
    End Function

    Public Function IsExistOrder(ByVal order As String) As Boolean
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefOrdDb.TableOrder)
        If order IsNot Nothing Then
            sbSql.AppendLine(" where")
            sbSql.AppendLine(OMTColumnName(OMTColumn.Order) & "=" & "'" & order & "'")
        Else
            sbSql.AppendLine(" where")
            sbSql.AppendLine(OMTColumnName(OMTColumn.Order) & "='Nothing'")
        End If
        'データの読み込み
        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)
        If 0 < tb.Rows.Count Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function GetBuDataTable(ByVal includeDisableData As Boolean) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefOrdDb.TableBu)
        If includeDisableData = False Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(BUMTColumnName(BUMTColumn.DataEnable) & "=True")
        End If
        sbSql.AppendLine("order by")
        sbSql.AppendLine(BUMTColumnName(BUMTColumn.BuName))

        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    Public Function GetSqlInsertSerial(ByVal order As String) As String
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("insert into")
        sbSql.AppendLine(DefOrdDb.TableSerial)
        sbSql.AppendLine("(")
        sbSql.AppendLine(SNMTColumnName(SNMTColumn.Order))
        sbSql.AppendLine(",")
        sbSql.AppendLine(SNMTColumnName(SNMTColumn.LastSerialNo))
        sbSql.AppendLine(")")
        sbSql.AppendLine("values (")
        sbSql.AppendLine(String.Format("'{0}'", order))
        sbSql.AppendLine(",")
        sbSql.AppendLine("0")
        sbSql.AppendLine(")")
        Return sbSql.ToString
    End Function
End Class
