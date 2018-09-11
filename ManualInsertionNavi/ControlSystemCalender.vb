Public Class ControlSystemCalender
    Inherits ControlRtcCalendar

    Public MstCtrlDb As ControlDbMaster

    Public Sub New(ByVal ctrlDb As ControlDbMaster)
        MstCtrlDb = ctrlDb.Clone
    End Sub
    ''' <summary>
    ''' システムカレンダーDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得した接続文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetSystemCalenderDbConnectString() As String
        '接続文字列作成
        Dim connectString As String = Nothing

        If MstCtrlDb.DefMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合--------------------------------END--
            connectString = "Provider=" & MstCtrlDb.DefMstDb.Provider & ";Data Source=" & MstCtrlDb.DefMstDb.DbPath & "\" & MstCtrlDb.DefMstDb.DbCalenderName & MstCtrlDb.DefMstDb.DbExtention & MstCtrlDb.DefMstDb.ConnectPassword
        Else
            'パスワードなしで接続する場合-------------------------------------
            connectString = "Provider=" & MstCtrlDb.DefMstDb.Provider & ";Data Source=" & MstCtrlDb.DefMstDb.DbPath & "\" & MstCtrlDb.DefMstDb.DbCalenderName & MstCtrlDb.DefMstDb.DbExtention
        End If
        Return connectString
    End Function
    ''' <summary>
    ''' システムカレンダーDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得したマスターDBのパス
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetSystemCalenderDbPathString() As String
        Dim dbNameString As String = Nothing

        If MstCtrlDb.DefMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合--------------------------------END--
            dbNameString = "[" & MstCtrlDb.DefMstDb.DbPath & "\" & MstCtrlDb.DefMstDb.DbCalenderName & MstCtrlDb.DefMstDb.DbExtention & MstCtrlDb.DefMstDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合-------------------------------------
            dbNameString = "[" & MstCtrlDb.DefMstDb.DbPath & "\" & MstCtrlDb.DefMstDb.DbCalenderName & MstCtrlDb.DefMstDb.DbExtention & "]"
        End If
        Return dbNameString
    End Function

    ''' <summary>
    ''' システムカレンダーテーブルの内容を取得する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSystemCalenderDB() As DataTable
        Dim retResult As Boolean = False
        Dim connectString As String = GetSystemCalenderDbConnectString()
        Dim dbNameString As String = GetSystemCalenderDbPathString()

        'SQL文作成
        Dim sbSqlString As New System.Text.StringBuilder
        sbSqlString.Append("SELECT * FROM ")
        sbSqlString.Append(dbNameString & ".[" & MstCtrlDb.DefMstDb.DbCalenderName & "]")
        sbSqlString.Append(" ORDER BY 年,月")

        Return MstCtrlDb.GetTableData(sbSqlString.ToString, connectString)
    End Function

    Public Function UpDateSystemCalenderDB(ByVal table As DataTable) As Boolean
        Dim retResult As Boolean = False
        Dim connectString As String = GetSystemCalenderDbConnectString()

        Dim dbNameString As String = GetSystemCalenderDbPathString()

        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand
        Dim Trz As System.Data.OleDb.OleDbTransaction

        Cn.Open()
        Trz = Cn.BeginTransaction
        retResult = False
        '●更新実行
        Try
            SQLCm.Transaction = Trz
            For i As Integer = 0 To table.Rows.Count - 1
                SQLCm.CommandText = fucnMakeInsertCalenderSql(table, i)
                SQLCm.ExecuteNonQuery() '実行
            Next

            retResult = True
            Trz.Commit() 'コミット（確定）
        Catch ex As Exception
            MessageBox.Show(SQLCm.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trz.Rollback() 'ロールバック
            retResult = False
        Finally
            Cn.Close() 'DB切断
        End Try

        SQLCm.Dispose()
        Cn.Dispose()
        Return retResult
    End Function
    Public Function fucnMakeInsertCalenderSql(ByVal table As DataTable, ByVal index As Integer) As String
        Dim dtNow As DateTime = DateTime.Now
        Dim sbSql As New System.Text.StringBuilder
        sbSql.Append("INSERT INTO " & MstCtrlDb.DefMstDb.DbCalenderName)
        sbSql.Append(" (")
        sbSql.Append("年,月,")
        For i As Integer = DbCalenderHeaderCount To DbDaysColumnCount + 1
            sbSql.Append(table.Columns(i).Caption)
            If i < DbDaysColumnCount + 1 Then
                sbSql.Append(",")
            End If
        Next
        sbSql.Append(")")

        sbSql.Append(" VALUES (")
        sbSql.Append("'" & table.Rows(index)(0) & "',")
        sbSql.Append("'" & table.Rows(index)(1) & "',")
        For j As Integer = DbCalenderHeaderCount To DbDaysColumnCount + 1
            sbSql.Append(table.Rows(index)(j))
            If j < DbDaysColumnCount + 1 Then
                sbSql.Append(",")
            End If
        Next

        sbSql.Append(")")

        Return sbSql.ToString
    End Function
End Class
