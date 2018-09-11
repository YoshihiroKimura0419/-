Imports System
''' <summary>
''' ControlDbを継承して作成した、部材マスタデータ操作用クラス
''' </summary>
''' <remarks></remarks>
Public Class ControlDbPartsMaster
    Inherits ControlDb
    Implements ICloneable

    'データベース設定オブジェクト定義
    Public DefPtMstDb As DefinePartsMasterDb


    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' 部材マスタデータベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefinePartsMasterDb)
        DefPtMstDb = defDb.Clone
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
    ''' 部材マスタDB保存フォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' 本システムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetDbPath(ByRef sysDataPath As String)
        DefPtMstDb.DbPath = sysDataPath & "\DB"
    End Sub
    ''' <summary>
    ''' 部材マスタDB保存フォルダを取得する。
    ''' </summary>
    Public Function GetDbPath() As String
        Return DefPtMstDb.DbPath
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
        If DefPtMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = "Provider=" & DefPtMstDb.Provider & ";Data Source=" & DefPtMstDb.DbPath & "\" & DefPtMstDb.DbName & DefPtMstDb.ConnectPassword
        Else
            'パスワードなしで接続する場合
            connectString = "Provider=" & DefPtMstDb.Provider & ";Data Source=" & DefPtMstDb.DbPath & "\" & DefPtMstDb.DbName
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
        If DefPtMstDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = "[" & DefPtMstDb.DbPath & "\" & DefPtMstDb.DbName & DefPtMstDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合
            dbNameString = "[" & DefPtMstDb.DbPath & "\" & DefPtMstDb.DbName & "]"
        End If

        Return dbNameString
    End Function
    ''' <summary>
    ''' partsCodeで指定した部材データをテーブルから取得する。
    ''' 取得データは、基本的に１件のみ
    ''' </summary>
    ''' <param name="partsCode">
    ''' データを取得したい部品の部材コード文字列
    ''' </param>
    ''' <returns>
    ''' 取得した部品形状管理テーブル（１件分）
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetPartsOneDataFromTable(ByVal partsCode As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefPtMstDb.TablePartsMaster)

        If (partsCode = Nothing) OrElse (partsCode = "") Then
            sbSql.AppendLine(" where " & PMTColumnName(PMTColumn.PartsCode) & "='Nothing'")
        Else
            sbSql.AppendLine(" where " & PMTColumnName(PMTColumn.PartsCode) & "='" & partsCode.ToString & "'")
        End If

        'データの読み込み
        Dim tb As New DataTable()

        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    ''' <summary>
    ''' partsCodeで指定データが既に部材管理テーブル存在するか確認
    ''' </summary>
    ''' <param name="partsCode">
    ''' 部材コード文字列
    ''' </param>
    ''' <returns>
    ''' True:partsCodeで指定した部材コードが存在する
    ''' False:partsCodeで指定した部材コードが存在しない
    ''' </returns>
    ''' <remarks></remarks>
    Public Function IsExistPartsCode(ByVal partsCode As String) As Boolean
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefPtMstDb.TablePartsMaster)

        If partsCode IsNot Nothing Then
            sbSql.AppendLine(" where " & PMTColumnName(PMTColumn.PartsCode) & "='" & partsCode.ToString & "'")
        Else
            sbSql.AppendLine(" where " & PMTColumnName(PMTColumn.PartsCode) & "='Nothing'")
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

    Public Function RegistPartsData(ByVal dtPartsData As DataTable) As Boolean
        Return MyBase.UpDateTable(dtPartsData, DefPtMstDb.TablePartsMaster, "ID", GetMasterDbConnectString)

    End Function

End Class
