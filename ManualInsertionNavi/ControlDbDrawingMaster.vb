Public Class ControlDbDrawingMaster
    Inherits ControlDb
    Implements ICloneable
    'データベース設定オブジェクト定義
    Public DefMstDb As DefineDrawingMasterDb
    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefineDrawingMasterDb)
        DefMstDb = defDb.Clone
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
        If DefMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = "Provider=" & DefMstDb.Provider & ";Data Source=" & DefMstDb.DbPath & "\" & DefMstDb.DbName & DefMstDb.ConnectPassword
        Else
            'パスワードなしで接続する場合
            connectString = "Provider=" & DefMstDb.Provider & ";Data Source=" & DefMstDb.DbPath & "\" & DefMstDb.DbName
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
        If DefMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = "[" & DefMstDb.DbPath & "\" & DefMstDb.DbName & DefMstDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合
            dbNameString = "[" & DefMstDb.DbPath & "\" & DefMstDb.DbName & "]"
        End If

        Return dbNameString
    End Function
    ''' <summary>
    ''' drawingNumberで指定した図面の情報を図面管理テーブルから取得する。
    ''' </summary>
    ''' <param name="drawingNumber">
    ''' データを取得したい図面番号文字列
    ''' </param>
    ''' <param name="revision">
    ''' データを取得したい図面の副番文字列
    ''' </param>
    ''' <returns>
    ''' 取得した図面情報テーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetDrawingTable(ByVal drawingNumber As String, ByVal revision As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefMstDb.TabaleDrawingInfo)

        If drawingNumber <> "" Then
            sbSql.AppendLine(" where " & DITColumnName(DITColmun.DrawingNumber) & "='" & drawingNumber & "'")
            If revision <> "" Then
                sbSql.AppendLine(" and " & DITColumnName(DITColmun.DrawingRevision) & " ='" & revision & "'")
            Else
                sbSql.AppendLine(" and " & DITColumnName(DITColmun.DrawingRevision) & " IS NULL")
            End If
        Else
            sbSql.AppendLine(" where " & DITColumnName(DITColmun.DrawingNumber) & "='NoDrawingNumber'")
            sbSql.AppendLine(" and " & DITColumnName(DITColmun.DrawingRevision) & " ='" & revision & "'")
        End If


        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    ''' <summary>
    ''' idで指定した図面データをテーブルから取得する。
    ''' 取得データは、基本的に１件のみ
    ''' </summary>
    ''' <param name="id">
    ''' データを取得したい図面マスタID文字列
    ''' </param>
    ''' <returns>
    ''' 取得した図面マスタテーブル（１件分）
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetDrawingOneDataFromTable(ByVal id As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefMstDb.TabaleDrawingInfo)
        sbSql.AppendLine(" where " & DITColumnName(DITColmun.Id) & "=" & id.ToString)

        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function

    ''' <summary>
    ''' drawingNumberで指定した図面番号＋副番の図面管理テーブル存在有無を取得
    ''' </summary>
    ''' <param name="drawingNumber">
    ''' 存在有無を取得したい図面番号文字列
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExistDrawingNumber(ByVal drawingNumber As String, ByVal revision As String) As Boolean

        'データの読み込み
        Dim tb As New DataTable()
        tb = GetDrawingTable(drawingNumber, revision)

        If 0 < tb.Rows.Count Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function IsExistBoardName(ByVal boardName As String) As Boolean
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefMstDb.TabaleDrawingInfo)
        sbSql.AppendLine(" where " & DITColumnName(DITColmun.BoardName) & "='" & boardName & "'")
        sbSql.AppendLine(" and " & DITColumnName(DITColmun.DataEnable) & "=True")

        'データの読み込み
        Dim tb As DataTable = GetTableData(sbSql.ToString, connect_txt)

        If 0 < tb.Rows.Count Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' boardNameに該当する基板名称の図面情報データを取得する（複数データの場合あり）
    ''' </summary>
    ''' <param name="boardName"></param>
    ''' <returns></returns>
    Public Function GetDrawingDatasByBoardName(ByVal boardName As String, ByVal includeDisableData As Boolean) As DataTable
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefMstDb.TabaleDrawingInfo)
        sbSql.AppendLine(" where " & DITColumnName(DITColmun.BoardName) & "='" & boardName & "'")
        If includeDisableData = False Then
            sbSql.AppendLine(" and " & DITColumnName(DITColmun.DataEnable) & "=True")
        End If

        'データの読み込み
        Dim tb As DataTable = GetTableData(sbSql.ToString, connect_txt)

        Return tb

    End Function


End Class
