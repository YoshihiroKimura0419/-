
Imports System
''' <summary>
''' ControlDbを継承して作成した、手挿入なびマスタデータ操作用クラス
''' </summary>
''' <remarks></remarks>
Public Class ControlDbMaster
    Inherits ControlDb
    Implements ICloneable

    'データベース設定オブジェクト定義
    Public DefMstDb As DefineMasterDb


    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefineMasterDb)
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
    ''' マスターデータ管理DB保存フォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' 本システムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetDbPath(ByRef sysDataPath As String)
        DefMstDb.DbPath = sysDataPath & "\DB"
    End Sub
    ''' <summary>
    ''' マスターデータ管理DB保存フォルダを取得する。
    ''' </summary>
    Public Function GetDbPath() As String
        Return DefMstDb.DbPath
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
    ''' manNumberで指定したユーザーのデータをユーザー管理テーブルから取得する。
    ''' </summary>
    ''' <param name="manNumber">
    ''' データを取得したいユーザーのマンナンバー
    ''' </param>
    ''' <returns>
    ''' 取得したユーザー情報テーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetUserTable(ByVal manNumber As String) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TableUser)
        If manNumber <> "" Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(UDTColumnName(UDTColumn.ManNumber) & "='" & manNumber & "'")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(UDTColumnName(UDTColumn.ManNumber) & "='NoUser'")
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    ''' <summary>
    ''' ユーザー管理テーブルからユーザーIDと氏名の一覧を取得する。
    ''' </summary>
    ''' <param name="isIncludeDisableData">
    ''' 無効データを含めるか指定
    ''' True:無効データを含める　False:無効データを含めない
    ''' </param>
    ''' <returns>
    ''' 取得したテーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetUserIdAndNameTable(ByVal isIncludeDisableData As Boolean) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(UDTColumnName(UDTColumn.ManNumber) & ",")
        sbSql.AppendLine(UDTColumnName(UDTColumn.UserName))
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TableUser)
        If isIncludeDisableData = False Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(String.Format("{0}=True", UDTColumnName(UDTColumn.DataEnable)))
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function


    ''' <summary>
    ''' manNumberで指定したユーザーのアクセス権データをアクセス権管理テーブルから取得する。
    ''' </summary>
    ''' <param name="manNumber">
    ''' データを取得したいユーザーのマンナンバー
    ''' </param>
    ''' <returns>
    ''' 取得したアクセス権管理テーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetAccessRightTable(ByVal manNumber As String) As DataTable
        '接続文字列取得
        Dim connectString As String = GetMasterDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TableUserAccessRight)
        If manNumber IsNot Nothing Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(ARTColumnName(ARTColumn.ManNumber) & "='" & manNumber & "'")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(ARTColumnName(ARTColumn.ManNumber) & "='NoUser'")
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connectString)

    End Function
    ''' <summary>
    ''' manNumberで指定したユーザーの技術レベルデータをユーザー技術レベル管理テーブルから取得する。
    ''' </summary>
    ''' <param name="manNumber">
    ''' データを取得したいユーザーのマンナンバー
    ''' </param>
    ''' <returns>
    ''' 取得したユーザー技術レベル管理テーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetTechnicTable(ByVal manNumber As String) As DataTable
        '接続文字列取得
        Dim connectString As String = GetMasterDbConnectString()
        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine(" * ")
        sbSql.AppendLine(" FROM ")
        sbSql.AppendLine(DefMstDb.TableUserTechnicLevel)
        If manNumber IsNot Nothing Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(UTLTColumnName(UTLTColumn.ManNumber) & "='" & manNumber & "'")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(UTLTColumnName(UTLTColumn.ManNumber) & "='NoUser'")
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connectString)

    End Function
    ''' <summary>
    ''' partsCategoryIdで指定した部品形状分類マスタのデータをテーブルから取得する。
    ''' 取得データは、基本的に１件のみ
    ''' </summary>
    ''' <param name="partsCategoryId">
    ''' データを取得したい部品形状分類マスタのID
    ''' </param>
    ''' <returns>
    ''' 取得した部品形状分類マスタテーブル（１件分）
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetPartsCategoryOneDataFromTable(ByVal partsCategoryId As Integer) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TablePartsShapeCategory)
        If (partsCategoryId = Nothing) OrElse (partsCategoryId = 0) Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSCTColumnName(PSCTColumn.ID) & "=-1")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSCTColumnName(PSCTColumn.ID) & "=" & partsCategoryId.ToString)
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function
    ''' <summary>
    ''' partsShapeIdで指定した部品形状管理データをテーブルから取得する。
    ''' 取得データは、基本的に１件のみ
    ''' </summary>
    ''' <param name="partsShapeId">
    ''' データを取得したい部品形状管理のID
    ''' </param>
    ''' <returns>
    ''' 取得した部品形状管理テーブル（１件分）
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetPartsShapeOneDataFromTable(ByVal partsShapeId As Integer) As DataTable
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TablePartsShapeMaster)
        If (partsShapeId = Nothing) OrElse (partsShapeId = 0) Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSTColumnName(PSTColumn.ID) & "=-1")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSTColumnName(PSTColumn.ID) & "=" & partsShapeId.ToString)
        End If
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connect_txt)

    End Function

    ''' <summary>
    ''' manNumberで指定したユーザーの氏名をユーザー管理テーブルから取得する。
    ''' </summary>
    ''' <param name="manNumber">
    ''' 氏名を取得したいユーザーのマンナンバー文字列
    ''' </param>
    ''' <returns>
    ''' 取得したユーザーの氏名文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetUserName(ByVal manNumber As String) As String
        Dim connect_txt As String = GetMasterDbConnectString()

        Dim sbSqlString As New System.Text.StringBuilder
        sbSqlString.AppendLine("SELECT")
        sbSqlString.AppendLine(UDTColumnName(UDTColumn.UserName))
        sbSqlString.AppendLine("FROM")
        sbSqlString.AppendLine(DefMstDb.TableUser)
        sbSqlString.AppendLine("WHERE")
        sbSqlString.AppendLine(UDTColumnName(UDTColumn.ManNumber) & "='" & manNumber & "'")
        Dim table As New DataTable
        table = GetTableData(sbSqlString.ToString, connect_txt)

        If table.Rows.Count > 0 Then
            Return table.Rows(0)(UDTColumnName(UDTColumn.UserName))
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' 技術レベルマスタテーブル情報を技術レベル列順に並び替えて全て取得する
    ''' </summary>
    ''' <returns>
    ''' 取得した技術レベルマスタテーブル
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetTechnicTableMaster() As DataTable
        Dim connectString As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TableTechnicLevelMaster)
        sbSql.AppendLine("order by")
        sbSql.AppendLine(TLTColumnName(TLTColumn.TechnicLevel))
        'データの読み込み
        Dim tb As New DataTable()
        Return GetTableData(sbSql.ToString, connectString)

    End Function
    ''' <summary>
    ''' manNumberで指定したユーザーが既にユーザー管理テーブル存在有無取得
    ''' </summary>
    ''' <param name="manNumber">
    ''' 存在有無を取得したユーザーのマンナンバー文字列
    ''' </param>
    ''' <param name="existUserName">
    ''' テーブルに存在する場合、そのユーザー名
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExistInputManNumber(ByVal manNumber As String, ByRef existUserName As String) As Boolean
        existUserName = GetUserName(manNumber)
        If existUserName Is Nothing Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' manNumberで指定したユーザーが既にユーザー管理テーブル存在有無取得
    ''' </summary>
    ''' <param name="partCategory">
    ''' 存在有無を取得したユーザーのマンナンバー文字列
    ''' </param>
    ''' <returns>
    ''' True:partCategoryで指定した部品形状分類名称が存在する
    ''' False:partCategoryで指定した部品形状分類名称が存在しない
    ''' </returns>
    ''' <remarks></remarks>
    Public Function IsExistPartsCategoryName(ByVal partCategory As String) As Boolean
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TablePartsShapeCategory)
        If partCategory IsNot Nothing Then
            sbSql.AppendLine(" where")
            sbSql.AppendLine(PSCTColumnName(PSCTColumn.PartsShapeCategoryName) & "=" & "'" & partCategory & "'")
        Else
            sbSql.AppendLine(" where")
            sbSql.AppendLine(PSCTColumnName(PSCTColumn.PartsShapeCategoryName) & "='Nothing'")
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
    ''' <summary>
    ''' partsShapeNameで指定した部品形状データの部品形状管理テーブル存在有無取得
    ''' </summary>
    ''' <param name="partsShapeName">
    ''' 存在有無を取得したい部品形状名文字列
    ''' </param>
    ''' <returns>
    ''' True:partsShapeNameで指定した部品形状名が存在する
    ''' False:partsShapeNameで指定した部品形状名が存在しない
    ''' </returns>
    ''' <remarks></remarks>
    Public Function IsExistPartsShapeName(ByVal partsShapeName As String) As Boolean
        '接続文字列取得
        Dim connect_txt As String = GetMasterDbConnectString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT ")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(DefMstDb.TablePartsShapeMaster)
        If partsShapeName IsNot Nothing Then
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSTColumnName(PSTColumn.PartsShapeName) & "='" & partsShapeName & "'")
        Else
            sbSql.AppendLine("where")
            sbSql.AppendLine(PSTColumnName(PSTColumn.PartsShapeName) & "='Nothing'")
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

    ''' <summary>
    ''' rowDataのregColmunNameのデータを元に登録者/更新者の氏名を取得する。
    ''' 
    ''' </summary>
    ''' <param name="rowData">
    ''' regColmunName列データを検索するDataRowオブジェクト。ユーザー管理テーブルのDataRow
    ''' </param>
    ''' <param name="regColmunName">
    ''' データを取得する列名称
    ''' </param>
    ''' <returns>
    ''' 取得したデータ列値
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetRegisterName(ByVal rowData As DataRow, ByVal regColmunName As String) As String
        Dim isSetComplete As Boolean = False
        Dim retString As String = Nothing
        If rowData(regColmunName) IsNot DBNull.Value Then
            Dim ut As New DataTable
            ut = GetUserTable(rowData(regColmunName))
            If ut.Rows.Count = 1 Then
                isSetComplete = True
                retString = ut.Rows(0)(UDTColumnName(UDTColumn.UserName).ToString)
            Else

                MessageBox.Show("登録者/更新者情報取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                isSetComplete = False
                retString = Nothing
            End If
        Else
            isSetComplete = True
            retString = Nothing
        End If
        Return retString
    End Function
    ''' <summary>
    ''' 部材形状名テーブルに新規挿入する行のデータを取得する。
    ''' 挿入データには、初期値を設定
    ''' </summary>
    ''' <param name="dtPartsShapeName">
    ''' 新規挿入行を崇徳したい部材形状名データテーブル
    ''' </param>
    ''' <returns>
    ''' 新規作成したDataRow
    ''' </returns>
    Public Function GetNewPartsShapeNameDataRow(ByVal dtPartsShapeName As DataTable) As DataRow
        Dim dr As DataRow = dtPartsShapeName.NewRow

        dr(PSTColumn.ID) = DBNull.Value
        dr(PSTColumn.DataEnable) = True
        dr(PSTColumn.PartsShapeName) = DBNull.Value
        dr(PSTColumn.PartsShapeTypeId) = 0
        dr(PSTColumn.PartsHeight) = 10
        dr(PSTColumn.PartsWidth) = 10
        dr(PSTColumn.PartsShapeId) = Shape.Retacgle
        dr(PSTColumn.UseMarker) = True
        dr(PSTColumn.MarkerPosi) = Align.BottomLeft
        dr(PSTColumn.ChangeHistory) = ""
        dr(PSTColumn.OriginPosi) = Align.BottomLeft

        dr(PSTColumn.RegistDate) = DBNull.Value
        dr(PSTColumn.RegistManNumber) = DBNull.Value
        dr(PSTColumn.UpdateDate) = DBNull.Value
        dr(PSTColumn.UpdateManNumber) = Nothing
        dr(PSTColumn.DataCommit) = False

        Return dr
    End Function
    ''' <summary>
    ''' 部材形状名を登録する。
    ''' </summary>
    ''' <param name="dtPartsShapeName">
    ''' 部材形状名テーブル
    ''' </param>
    ''' <returns>
    ''' True:成功　False:失敗
    ''' </returns>
    Public Function RegistPartsShapeName(ByVal dtPartsShapeName As DataTable) As Boolean
        Dim sbSql As New Text.StringBuilder

        '部品形状テーブルの構造取得
        Dim dt As DataTable = GetPartsShapeOneDataFromTable(Nothing)
        For Each row As DataRow In dtPartsShapeName.Rows
            Dim dr As DataRow = GetNewPartsShapeNameDataRow(dt)
            dr(PSTColumn.PartsShapeName) = row(PSTColumnName(PSTColumn.PartsShapeName))
            dr(PSTColumn.RegistDate) = DateTime.Now
            dr(PSTColumn.RegistManNumber) = SysLoginUserInfo.ManNumber
            dt.Rows.Add(dr)
        Next
        Return MyBase.UpDateTable(dt, DefMstDb.TablePartsShapeMaster, "ID", GetMasterDbConnectString)

    End Function
    ''' <summary>
    ''' 部材形状分類データを登録する。
    ''' </summary>
    ''' <param name="dtPartsCategory">
    ''' 部材形状分類データテーブル
    ''' </param>
    ''' <returns>
    ''' True:更新成功　False:更新失敗
    ''' </returns>
    Public Function RegistPartsCategory(ByVal dtPartsCategory As DataTable) As Boolean
        Return MyBase.UpDateTable(dtPartsCategory, DefMstDb.TablePartsShapeCategory, "ID", GetMasterDbConnectString)
    End Function
    ''' <summary>
    ''' 部材コードから部品形状データを取得する
    ''' </summary>
    ''' <returns>
    ''' 取得した部品形状データ
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetShapeDataByPartsCode(ByVal partsCode As String) As DataTable
        Dim defPstMst As New DefinePartsMasterDb
        defPstMst.DbPath = Me.DefMstDb.DbPath
        Dim ctrlDbPartsMaster As New ControlDbPartsMaster(defPstMst)
        '接続文字列作成
        Dim connectString As String = Me.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNamePartsMaster As String = ctrlDbPartsMaster.GetMasterDbPathString()
        Dim dbNameMaster As String = Me.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.AppendLine("SELECT ")
        For i As Integer = 0 To UBound(DPSDTColumnName)
            If i = 0 Then
                sbSql.AppendLine("a." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i) & ",")
            Else
                If i < UBound(DPSDTColumnName) Then
                    sbSql.AppendLine("b." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i) & ",")
                Else
                    sbSql.AppendLine("b." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i))
                End If
            End If
        Next

        sbSql.AppendLine(" FROM ")

        sbSql.AppendLine("(")
        sbSql.AppendLine(dbNamePartsMaster & ".[" & ctrlDbPartsMaster.DefPtMstDb.TablePartsMaster & "] as a")
        sbSql.AppendLine(" left join ")
        sbSql.AppendLine(dbNameMaster & ".[" & Me.DefMstDb.TablePartsShapeMaster & "] as b")
        sbSql.AppendLine(" ON (a." & PMTColumnName(PMTColumn.PartsShapeId) & "=b." & PSTColumnName(PSTColumn.ID) & ")")
        sbSql.AppendLine(")")

        '部材コード指定
        sbSql.AppendLine("WHERE")
        sbSql.AppendLine("a." & PMTColumnName(PMTColumn.PartsCode) & "='" & partsCode & "'")
        sbSql.AppendLine("AND")
        sbSql.AppendLine("b." & DPSDTColumnName(DPSDTColumn.DataEnable) & "=TRUE")

        Dim tb As DataTable = ctrlDbPartsMaster.GetTableData(sbSql.ToString, connectString)
        Return tb
    End Function

    Public Function GetShapeDatasByPartsCodes(ByVal partsCodes As List(Of String)) As DataTable
        Dim defPstMst As New DefinePartsMasterDb
        defPstMst.DbPath = Me.DefMstDb.DbPath
        Dim ctrlDbPartsMaster As New ControlDbPartsMaster(defPstMst)
        '接続文字列作成
        Dim connectString As String = Me.GetMasterDbConnectString()
        'DBパス取得
        Dim dbNamePartsMaster As String = ctrlDbPartsMaster.GetMasterDbPathString()
        Dim dbNameMaster As String = Me.GetMasterDbPathString()
        Dim tb As New DataTable
        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand

        Cn.Open()

        ''SQL文
        Dim sbSql As New System.Text.StringBuilder
        Try
            For Each code As String In partsCodes
                sbSql.Clear()
                sbSql.AppendLine("SELECT ")
                For i As Integer = 0 To UBound(DPSDTColumnName)
                    If i = 0 Then
                        sbSql.AppendLine("a." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i) & ",")
                    Else
                        If i < UBound(DPSDTColumnName) Then
                            sbSql.AppendLine("b." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i) & ",")
                        Else
                            sbSql.AppendLine("b." & DPSDTColumnName(i) & " as " & DPSDTColumnName(i))
                        End If
                    End If
                Next

                sbSql.AppendLine(" FROM ")

                sbSql.AppendLine("(")
                sbSql.AppendLine(dbNamePartsMaster & ".[" & ctrlDbPartsMaster.DefPtMstDb.TablePartsMaster & "] as a")
                sbSql.AppendLine(" left join ")
                sbSql.AppendLine(dbNameMaster & ".[" & Me.DefMstDb.TablePartsShapeMaster & "] as b")
                sbSql.AppendLine(" ON (a." & PMTColumnName(PMTColumn.PartsShapeId) & "=b." & PSTColumnName(PSTColumn.ID) & ")")
                sbSql.AppendLine(")")

                '部材コード指定
                sbSql.AppendLine("WHERE")
                sbSql.AppendLine("a." & PMTColumnName(PMTColumn.PartsCode) & "='" & code & "'")
                sbSql.AppendLine("AND")
                sbSql.AppendLine("b." & DPSDTColumnName(DPSDTColumn.DataEnable) & "=TRUE")
                SQLCm.CommandText = sbSql.ToString
                Dim reader As IDataReader = SQLCm.ExecuteReader()
                tb.Load(reader)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー")
        Finally
            Cn.Close() 'DB切断
            SQLCm.Dispose()
            Cn.Dispose()
        End Try

        Return tb
    End Function

End Class

