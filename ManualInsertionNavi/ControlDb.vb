Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Public Class ControlDb

    ''' <summary>
    ''' DBに接続し、sql_txtで指定した内容をテーブルに読込、そのテーブルを返す
    ''' </summary>
    ''' <param name="sqlString">
    ''' SQL文字列
    ''' </param>
    ''' <param name="connectString">
    ''' 接続文字列
    ''' </param>
    ''' <returns>
    ''' テーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetTableData(ByVal sqlString As String, ByVal connectString As String) As DataTable

        'データアダプターを生成
        Dim oleAdapter As New System.Data.OleDb.OleDbDataAdapter(sqlString, connectString)

        'データの読み込み
        Dim dt As New DataTable

        Try
            oleAdapter.Fill(dt)
        Catch ex As Exception
            Dim mess As String = ex.Message & vbCrLf & vbCrLf & "SQL" & vbCrLf & sqlString
            MessageBox.Show(mess, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function
    ''' <summary>
    ''' 行挿入SQL作成
    ''' </summary>
    ''' <param name="tableName">
    ''' 行挿入するテーブル名
    ''' </param>
    ''' <param name="row">
    ''' 行挿入するDataRowオブジェクト
    ''' </param>
    ''' <param name="keyColmunName">
    ''' AUTONUMBER列が行挿入キーとなる場合の列名称。AUTONUMBER列以外は、Nothingを指定
    ''' </param>
    ''' <returns>
    ''' 作成した行削除SQL文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetInsertSqlString(ByVal tableName As String, ByRef row As DataRow, ByVal keyColmunName As String) As String

        'SQL文作成用
        Dim sbSql As New System.Text.StringBuilder()

        '▼挿入文作成
        sbSql.AppendLine("INSERT INTO " & tableName)
        sbSql.AppendLine(" (")
        For i As Integer = 0 To row.ItemArray.Count - 1
            If (keyColmunName <> Nothing) AndAlso (keyColmunName = row.Table.Columns(i).ColumnName) Then Continue For
            sbSql.Append(row.Table.Columns(i).ColumnName)
            If i < row.ItemArray.Count - 1 Then
                sbSql.AppendLine(",")
            End If

        Next

        sbSql.AppendLine(" )")
        sbSql.AppendLine(" VALUES (")

        For j As Integer = 0 To row.ItemArray.Count - 1
            If (keyColmunName <> "") And (keyColmunName = row.Table.Columns(j).ColumnName) Then Continue For

            Dim dtype As Type = row.Table.Columns(j).DataType
            Select Case dtype
                Case GetType(Integer), GetType(Double)
                    If row(j) IsNot DBNull.Value Then
                        sbSql.Append(row(j))
                    Else
                        sbSql.Append("NULL")
                    End If
                Case GetType(String)
                    If row(j) IsNot DBNull.Value Then
                        sbSql.Append("'" & row(j) & "'")
                    Else
                        sbSql.Append("NULL")
                    End If
                Case GetType(DateTime)
                    If row(j) IsNot DBNull.Value Then
                        sbSql.Append("'" & row(j) & "'")
                    Else
                        sbSql.Append("NULL")
                    End If
                Case GetType(Boolean)
                    If row(j) IsNot DBNull.Value Then
                        sbSql.Append(row(j))
                    Else
                        sbSql.Append("False")
                    End If
            End Select
            If j < row.ItemArray.Count - 1 Then
                sbSql.AppendLine(",")
            End If
        Next
        sbSql.AppendLine(")")

        Return sbSql.ToString
    End Function

    ''' <summary>
    ''' 行削除SQL作成
    ''' </summary>
    ''' <param name="tableName">
    ''' 行削除するテーブル名
    ''' </param>
    ''' <param name="row">
    ''' テーブル内の行削除するDataRowオブジェクト
    ''' </param>
    ''' <param name="keyColmunName">
    ''' 削除キーとなる列名称
    ''' </param>
    ''' <returns>
    ''' 作成した行削除SQL文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetDeleteSqlString(ByVal tableName As String, ByRef row As DataRow, ByVal keyColmunName As String) As String
        Dim sbSql As New System.Text.StringBuilder()

        Dim keyColDateType As Type = row.Table.Columns(keyColmunName).DataType

        sbSql.AppendLine("DELETE FROM " & tableName & " WHERE ")

        Select Case keyColDateType
            Case GetType(Integer), GetType(Double), GetType(Boolean)
                sbSql.AppendLine(keyColmunName & "=" & row(keyColmunName, DataRowVersion.Original))
            Case GetType(String)
                sbSql.AppendLine(keyColmunName & "='" & row(keyColmunName, DataRowVersion.Original) & "'")
            Case GetType(DateTime)
                sbSql.AppendLine(keyColmunName & "=#" & row(keyColmunName, DataRowVersion.Original) & "#")
        End Select

        Return sbSql.ToString

    End Function
    ''' <summary>
    ''' 行更新SQL作成
    ''' </summary>
    ''' <param name="tableName">
    ''' 行更新するテーブル名
    ''' </param>
    ''' <param name="row">
    ''' テーブル内の行更新するDataRowオブジェクト
    ''' </param>
    ''' <param name="keyColmunName">
    ''' テーブル内更新キーとなる列名称。必ず指定する事
    ''' </param>
    ''' <returns>
    ''' 作成した行更新SQL文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetModifiedSqlString(ByVal tableName As String, ByRef row As DataRow, ByVal keyColmunName As String) As String
        Dim dtNow As DateTime = DateTime.Now

        Dim sbSql As New System.Text.StringBuilder()
        Dim keyColDateType As Type = Nothing


        sbSql.AppendLine("UPDATE " & tableName & " SET ")

        For i As Integer = 0 To row.ItemArray.Count - 1
            If (keyColmunName <> "") AndAlso (keyColmunName = row.Table.Columns(i).ColumnName) Then
                keyColDateType = row.Table.Columns(i).DataType
                Continue For
            End If
            Dim dtype As Type = row.Table.Columns(i).DataType
            sbSql.Append(row.Table.Columns(i).ColumnName)
            Select Case dtype
                Case GetType(Integer), GetType(Double)
                    If row(i) IsNot DBNull.Value Then
                        sbSql.Append("=" & row(i))
                    Else
                        sbSql.Append("= NULL")
                    End If
                Case GetType(String)
                    If row(i) IsNot DBNull.Value Then
                        sbSql.Append("='" & row(i) & "'")
                    Else
                        sbSql.Append("= NULL")
                    End If
                Case GetType(DateTime)
                    If row(i) IsNot DBNull.Value Then
                        sbSql.Append("='" & row(i) & "'")
                    Else
                        sbSql.Append(" = NULL")
                    End If
                Case GetType(Boolean)
                    If row(i) IsNot DBNull.Value Then
                        sbSql.Append("=" & row(i))
                    Else
                        sbSql.Append("False")
                    End If
            End Select
            If i < row.ItemArray.Count - 1 Then
                sbSql.AppendLine(",")
            End If
        Next
        sbSql.AppendLine(" WHERE ")
        Select Case keyColDateType
            Case GetType(Integer), GetType(Double), GetType(Boolean)
                sbSql.AppendLine(keyColmunName & "=" & row(keyColmunName, DataRowVersion.Original))
            Case GetType(String)
                sbSql.AppendLine(keyColmunName & "='" & row(keyColmunName, DataRowVersion.Original) & "'")
            Case GetType(DateTime)
                sbSql.AppendLine(keyColmunName & "=#" & row(keyColmunName, DataRowVersion.Original) & "#")
        End Select

        Return sbSql.ToString

    End Function
    ''' <summary>
    ''' True/Falseに対応した表示文字列DataTableを取得する
    ''' </summary>
    ''' <param name="dispTrueString">
    ''' Trueに対応した表示文字列
    ''' </param>
    ''' <param name="dispFalseString">
    ''' Falseに対応した表示文字列
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEnableTable(ByVal dispTrueString As String, ByVal dispFalseString As String) As DataTable
        Dim dataEnableTable As New DataTable()
        dataEnableTable.Columns.Add("Display", GetType(String))
        dataEnableTable.Columns.Add("Value", GetType(Boolean))
        dataEnableTable.Rows.Add(dispTrueString, True)
        dataEnableTable.Rows.Add(dispFalseString, False)
        Return dataEnableTable
    End Function
    ''' <summary>
    ''' Sql文を元にマスターDBの該当テーブルで挿入・更新・削除のいづれかを実施する。
    ''' </summary>
    ''' <param name="connectString">
    ''' DB接続文字列
    ''' </param>
    ''' <param name="dbnameA">
    ''' 接続DBパス
    ''' </param>
    ''' <param name="sqlString">
    ''' SQL文
    ''' </param>
    ''' <returns>
    ''' True:成功
    ''' False：失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function UpdateTableWithSQL(ByVal connectString As String, ByVal dbnameA As String, ByVal sqlString As String) As Boolean
        Dim isCompleteUpdate As Boolean = False
        Dim oleCon As New System.Data.OleDb.OleDbConnection(connectString)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction

        oleCon.Open()
        trz = oleCon.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            sqlCmd.Transaction = trz

            sqlCmd.CommandText = sqlString
            sqlCmd.ExecuteNonQuery() '実行

            isCompleteUpdate = True
            trz.Commit() 'コミット（確定）
        Catch ex As Exception
            MessageBox.Show(sqlCmd.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            trz.Rollback() 'ロールバック
            isCompleteUpdate = False
        Finally
            oleCon.Close() 'DB切断
        End Try

        sqlCmd.Dispose()
        oleCon.Dispose()
        Return isCompleteUpdate
    End Function
    ''' -----------------------------------------------------------------------------------
    ''' <summary>
    ''' データテーブルの内容を基にデータベースのテーブルを更新する。
    ''' </summary>
    ''' <param name="table">
    ''' 更新するテーブルデータ
    ''' </param>
    ''' <param name="tableName">
    ''' 更新するテーブル名
    ''' </param>
    ''' <param name="keyColmunName">
    ''' 更新するテーブルのオートナンバー列名。無い場合は、""を指定
    ''' </param>
    ''' <param name="connectString">
    ''' 更新するDBの接続文字列
    ''' </param>
    ''' <returns>
    ''' Ture:更新成功　False:更新失敗
    ''' </returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------------
    Public Function UpDateTable(ByVal table As DataTable, ByVal tableName As String,
                                ByVal keyColmunName As String, ByVal connectString As String) As Boolean
        Dim isCompleteUpdate As Boolean = False

        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand
        Dim Trz As System.Data.OleDb.OleDbTransaction

        Cn.Open()
        Trz = Cn.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            SQLCm.Transaction = Trz
            For Each Row As DataRow In table.Rows
                Dim SQL As String = ""
                '●SQL文の生成
                Select Case Row.RowState
                    Case DataRowState.Added        '▼新規追加されたレコードの場合
                        SQL = GetInsertSqlString(tableName, Row, keyColmunName)
                    Case DataRowState.Deleted      '▼削除されたレコードの場合
                        SQL = GetDeleteSqlString(tableName, Row, keyColmunName)
                    Case DataRowState.Modified     '▼修正されたレコードの場合
                        SQL = GetModifiedSqlString(tableName, Row, keyColmunName)
                    Case Else
                        Continue For
                End Select

                SQLCm.CommandText = SQL
                SQLCm.ExecuteNonQuery() '実行
            Next
            isCompleteUpdate = True
            Trz.Commit() 'コミット（確定）
            table.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(SQLCm.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trz.Rollback() 'ロールバック
            isCompleteUpdate = False
        Finally
            Cn.Close() 'DB切断
        End Try

        table.Dispose()
        SQLCm.Dispose()
        Cn.Dispose()
        Return isCompleteUpdate
    End Function
    ''' -----------------------------------------------------------------------------------
    ''' <summary>
    ''' DataGridView内の情報をデータベーステーブルに反映させる
    ''' </summary>
    ''' <param name="targetDbPath">
    ''' 更新するデータベースのフルパス</param>
    ''' <param name="tableName">
    ''' 更新するテーブル名</param>
    ''' <param name="dgview">
    ''' データが表示されているDataGridViewオブジェクト</param>
    ''' <param name="keyColmunName">
    ''' 更新するテーブルのオートナンバー列名。無い場合は、""を指定</param>
    ''' <param name="connectString">
    ''' 更新するDBの接続文字列</param>
    ''' <returns>
    ''' Ture:更新成功　False:更新失敗</returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------------
    Public Function UpDateDgvTable2Db(ByVal targetDbPath As String, ByVal tableName As String, ByVal dgview As DataGridView,
                               ByVal keyColmunName As String, ByVal connectString As String) As Boolean
        Dim sts As Boolean = False

        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand
        Dim bs As BindingSource = DirectCast(dgview.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)
        Dim Trz As System.Data.OleDb.OleDbTransaction

        Cn.Open()
        Trz = Cn.BeginTransaction
        sts = False
        '●更新実行
        Try
            SQLCm.Transaction = Trz
            For Each Row As DataRow In table.Rows
                Dim SQL As String = ""
                '●SQL文の生成
                Select Case Row.RowState
                    Case DataRowState.Added        '▼新規追加されたレコードの場合
                        SQL = GetInsertSqlString(tableName, Row, keyColmunName)
                    Case DataRowState.Deleted      '▼削除されたレコードの場合
                        SQL = GetDeleteSqlString(tableName, Row, keyColmunName)
                    Case DataRowState.Modified     '▼修正されたレコードの場合
                        SQL = GetModifiedSqlString(tableName, Row, keyColmunName)
                    Case Else
                        Continue For
                End Select

                SQLCm.CommandText = SQL
                SQLCm.ExecuteNonQuery() '実行
            Next
            sts = True
            Trz.Commit() 'コミット（確定）
            table.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(SQLCm.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trz.Rollback() 'ロールバック
            sts = False
        Finally
            Cn.Close() 'DB切断
            table.Dispose()
            SQLCm.Dispose()
            Cn.Dispose()
        End Try

        Return sts
    End Function
    ''' <summary>
    ''' rowDataのregColmunName列のデータ文字列を取得する
    ''' </summary>
    ''' <param name="rowData">
    ''' データを取得したいDataRowオブジェクト
    ''' </param>
    ''' <param name="regColmunName">
    ''' データを取得したいDataRowオブジェクトの列名
    ''' </param>
    ''' <returns>
    ''' 取得した列のデータ文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetRowColmunContentString(ByVal rowData As DataRow, ByVal regColmunName As String) As String
        If rowData(regColmunName) IsNot DBNull.Value Then
            Return rowData(regColmunName).ToString
        Else
            Return Nothing
        End If

    End Function

End Class
