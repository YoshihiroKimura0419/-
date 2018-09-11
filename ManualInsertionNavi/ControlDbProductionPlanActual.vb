Public Class ControlDbProductionPlanActual
    Inherits ControlDb
    Implements ICloneable

    'データベース設定オブジェクト定義
    Public DefPpaDb As DefineProductionPlanActualDb


    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefineProductionPlanActualDb)
        DefPpaDb = defDb.Clone
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
    ''' 生産計画実績管理DB保存フォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' 本システムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetDbPath(ByRef sysDataPath As String)
        DefPpaDb.DbPath = sysDataPath & "\DB"
    End Sub
    ''' <summary>
    ''' 生産計画実績管理DB保存フォルダを取得する。
    ''' </summary>
    Public Function GetDbPath() As String
        Return DefPpaDb.DbPath
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
        If DefPpaDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = "Provider=" & DefPpaDb.Provider & ";Data Source=" & DefPpaDb.DbPath & "\" & DefPpaDb.DbName & DefPpaDb.ConnectPassword
        Else
            'パスワードなしで接続する場合
            connectString = "Provider=" & DefPpaDb.Provider & ";Data Source=" & DefPpaDb.DbPath & "\" & DefPpaDb.DbName
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
        If DefPpaDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = "[" & DefPpaDb.DbPath & "\" & DefPpaDb.DbName & DefPpaDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合
            dbNameString = "[" & DefPpaDb.DbPath & "\" & DefPpaDb.DbName & "]"
        End If

        Return dbNameString
    End Function
    ''' <summary>
    ''' 生産計画情報を取得する。
    ''' </summary>
    ''' <param name="pInfo">
    ''' 製作情報構造体
    ''' </param>
    ''' <returns>
    ''' 取得テーブル
    ''' </returns>
    Public Function GetProductionPlanActual(ByVal pInfo As ProductionInfomation) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()
        Dim isOk As Boolean = False
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefPpaDb.TablePlanActual)

        sbSql.AppendLine("where")
        sbSql.AppendLine(PPATColumnName(PPATColumn.Order) & "='" & pInfo.Order & "'")
        sbSql.AppendLine("and")
        'sbSql.AppendLine(PPATColumnName(PPATColumn.ProductDate) & "='" & pInfo.ProductionDate & "'")
        sbSql.AppendLine(PPATColumnName(PPATColumn.ProductDate) & "=#" & pInfo.ProductionDate.ToShortDateString & "#")
        sbSql.AppendLine("and")
        sbSql.AppendLine(PPATColumnName(PPATColumn.WorkerManNumber) & "='" & pInfo.WorkerManNumber & "'")
        sbSql.AppendLine("and")
        sbSql.AppendLine(PPATColumnName(PPATColumn.DrawingId) & "=" & pInfo.DrawingId)

        'データの読み込み
        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)
        Return tb
    End Function
    ''' <summary>
    ''' オーダーの実績値取得。
    ''' </summary>
    ''' <param name="order">
    ''' 取得したいオーダー
    ''' </param>
    ''' <returns></returns>
    Public Function GetTotalOrderActual(ByVal order As String) As Integer
        Dim connect_txt As String = GetMasterDbConnectString()
        Dim isOk As Boolean = False
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(String.Format("sum({0})", PPATColumnName(PPATColumn.ProductionActural)))
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefPpaDb.TablePlanActual)

        sbSql.AppendLine("where")
        sbSql.AppendLine(PPATColumnName(PPATColumn.Order) & "='" & order & "'")

        'データの読み込み
        Dim tb As New DataTable()
        tb = GetTableData(sbSql.ToString, connect_txt)
        If tb.Rows.Count = 1 AndAlso (tb(0)(0) IsNot DBNull.Value) Then
            Return tb(0)(0)
        End If
        Return 0

    End Function

    ''' <summary>
    ''' ppaDataRowの内容を基にProductionPlanActualの生産計画実績テーブルに行を追加する
    ''' </summary>
    ''' <param name="ppaDataRow">
    ''' 生産計画情報テーブルの行データ
    ''' ※あらかじめデータを設定しておくこと。
    ''' 
    ''' </param>
    ''' <returns></returns>
    Public Function InsertProductionPlanActualDataAndReturnId(ByRef ppaDataRow As DataRow) As Integer
        Dim registStatus As Integer = -1
        Dim connectString As String = GetMasterDbConnectString()
        Dim oleCon As New System.Data.OleDb.OleDbConnection(connectString)
        Dim sqlCmd As System.Data.OleDb.OleDbCommand = oleCon.CreateCommand
        Dim trz As System.Data.OleDb.OleDbTransaction
        Dim insertId As Integer = -1
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("INSERT INTO " & DefPpaDb.TablePlanActual)
        sbSql.AppendLine("(")
        sbSql.AppendLine(PPATColumnName(PPATColumn.Order))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.BoardName))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.DrawingId))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.ProductDate))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.ProductionPlan))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.ProductionActural))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.WorkerManNumber))
        sbSql.AppendLine(",")
        sbSql.AppendLine(PPATColumnName(PPATColumn.BuId))
        sbSql.AppendLine(")")

        sbSql.AppendLine(" VALUES (")
        sbSql.AppendLine("'" & ppaDataRow(PPATColumnName(PPATColumn.Order)) & "'")
        sbSql.AppendLine(",")
        sbSql.AppendLine("'" & ppaDataRow(PPATColumnName(PPATColumn.BoardName)) & "'")
        sbSql.AppendLine(",")
        sbSql.AppendLine(ppaDataRow(PPATColumnName(PPATColumn.DrawingId)))
        sbSql.AppendLine(",")
        sbSql.AppendLine("'" & ppaDataRow(PPATColumnName(PPATColumn.ProductDate)) & "'")
        sbSql.AppendLine(",")
        sbSql.AppendLine(ppaDataRow(PPATColumnName(PPATColumn.ProductionPlan)))
        sbSql.AppendLine(",")
        sbSql.AppendLine("0")
        sbSql.AppendLine(",")
        sbSql.AppendLine(ppaDataRow(PPATColumnName(PPATColumn.WorkerManNumber)))
        sbSql.AppendLine(",")
        sbSql.AppendLine(ppaDataRow(PPATColumnName(PPATColumn.BuId)))
        sbSql.AppendLine(")")

        oleCon.Open()
        trz = oleCon.BeginTransaction
        '●更新実行
        Try
            sqlCmd.Transaction = trz
            sqlCmd.CommandText = sbSql.ToString
            sqlCmd.ExecuteNonQuery() '実行

            sqlCmd.CommandText = "Select @@IDENTITY"
            Dim obj As Object = sqlCmd.ExecuteScalar() '実行
            If obj IsNot Nothing AndAlso obj.GetType IsNot GetType(DBNull) Then
                insertId = CInt(obj)
            Else
                '基本的に本行は実行されない
                insertId = 0
            End If

            trz.Commit() 'コミット（確定）
        Catch ex As Exception
            MessageBox.Show(sqlCmd.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            trz.Rollback() 'ロールバック
            insertId = -1
        Finally
            oleCon.Close() 'DB切断
        End Try

        sqlCmd.Dispose()
        oleCon.Dispose()
        Return insertId
    End Function

End Class
