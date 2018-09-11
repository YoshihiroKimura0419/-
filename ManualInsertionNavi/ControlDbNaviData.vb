''' <summary>
''' ControlDbを継承して作成した、なびデータ操作用クラス
''' </summary>
''' <remarks></remarks>
Public Class ControlDbNaviData
    Inherits ControlDb
    Implements ICloneable

    'データベース設定オブジェクト定義
    Public DefNaviDb As DefineNaviDB

    Private DrawingNumber As String = Nothing

    Private DrawingRevision As String = Nothing

    ''' <summary>
    ''' コンストラクタ。
    ''' </summary>
    ''' <param name="defDb">
    ''' データベース設定オブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal defDb As DefineNaviDB)
        DefNaviDb = defDb.Clone
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
    ''' ナビDB保存フォルダを設定する。
    ''' </summary>
    ''' <param name="sysDataPath">
    ''' 本システムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetDbPath(ByRef sysDataPath As String)
        DefNaviDb.DbPath = sysDataPath & "\DB"
    End Sub
    ''' <summary>
    ''' ナビDB保存フォルダを取得する。
    ''' </summary>
    Public Function GetDbPath() As String
        Return DefNaviDb.DbPath
    End Function

    ''' <summary>
    ''' ナビデータDB接続用文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得した接続文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetMasterDbConnectString() As String
        '接続文字列作成
        Dim connectString As String = Nothing

        '接続
        If DefNaviDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            connectString = "Provider=" & DefNaviDb.Provider & ";Data Source=" & DefNaviDb.DbPath & "\" & DefNaviDb.DbName & DefNaviDb.ConnectPassword
        Else
            'パスワードなしで接続する場合
            connectString = "Provider=" & DefNaviDb.Provider & ";Data Source=" & DefNaviDb.DbPath & "\" & DefNaviDb.DbName
        End If
        Return connectString
    End Function
    ''' <summary>
    ''' ナビデータDBのパスを取得する。
    ''' </summary>
    ''' <returns>
    ''' 取得したDBのパス
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetNaviDbPathString() As String
        Dim dbNameString As String = Nothing
        '接続
        If DefNaviDb.EnableConnectPassword = True Then
            'パスワードありで接続する場合
            dbNameString = "[" & DefNaviDb.DbPath & "\" & DefNaviDb.DbName & DefNaviDb.SqlPassword & "]"
        Else
            'パスワードなしで接続する場合
            dbNameString = "[" & DefNaviDb.DbPath & "\" & DefNaviDb.DbName & "]"
        End If

        Return dbNameString
    End Function
    ''' <summary>
    ''' ナビ用DBのパスを設定する。
    ''' </summary>
    ''' <param name="systemDataDrawingPath">
    ''' 図面データフォルダパス
    ''' </param>
    ''' <param name="dNumber">
    ''' 図面番号
    ''' </param>
    ''' <param name="dRevision">
    ''' 図面副番
    ''' </param>
    Public Sub SetDbPath(ByVal systemDataDrawingPath As String, ByVal dNumber As String, ByVal dRevision As String)
        DefNaviDb.DbPath = String.Format("{0}\{1}\{2}\{3}", systemDataDrawingPath, dNumber, dRevision, DrawingSubFolderName(DrawingSubFolder.NaviData))
        DrawingNumber = dNumber
        DrawingRevision = dRevision
    End Sub

    Public Function CreateNaviDataMain() As Boolean
        Dim shogenhyouFilePath As String = Nothing
        shogenhyouFilePath = GetDrawingAttachedFileFullPath(PartsInsertNaviAppConfigData.SystemDataPath.Drawing, DrawingNumber, DrawingRevision, DrawingSubFolder.Shogenhyou)
        Dim rds As New ReadShogenhyo

        If shogenhyouFilePath = Nothing Then
            MessageBox.Show("諸元表ファイル設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If rds.ReadFile(shogenhyouFilePath) <> 0 Then
            MessageBox.Show("諸元表ファイルが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim dtShogen As DataTable = rds.DtShogenhyouData.Copy

        Dim netListFilePath As String = Nothing
        Dim ctrlNLT As ControlNetListTable = Nothing
        Dim dtNetList As DataTable = Nothing
        Dim dvNetList As DataView = Nothing
        Dim dvShogen As DataView = dtShogen.DefaultView

        netListFilePath = GetDrawingAttachedFileFullPath(PartsInsertNaviAppConfigData.SystemDataPath.Drawing, DrawingNumber, DrawingRevision, DrawingSubFolder.NetList)

        If netListFilePath = Nothing Then
            MessageBox.Show("Netリストファイルが設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ctrlNLT = New ControlNetListTable(netListFilePath)
        dtNetList = ctrlNLT.GetTable
        dvNetList = dtNetList.DefaultView

        Dim defNavi As New DefineNaviDB

        Dim tempDt As DataTable = CreateNaviData(dtShogen, dtNetList)
        Dim updateSts As Boolean = False
        updateSts = UpDateTable(tempDt,
                                    Me.DefNaviDb.TableNaviData,
                                    NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                    Me.GetMasterDbConnectString()
                                    )
        Return updateSts
    End Function

    Public Function CopyNaviMasterDb(ByVal sourceFolder As String) As Boolean

        If DrawingRevision = Nothing Then
            DrawingRevision = NoRevisionFolderName
        End If

        Dim destFolder As String = Me.DefNaviDb.DbPath

        Dim destPath As String = destFolder & "\" & Me.DefNaviDb.DbName
        Dim sourcePath As String = sourceFolder & "\" & Me.DefNaviDb.DbName

        Dim sts As Integer = 0

        If System.IO.File.Exists(destPath.ToString) = False Then
            sts = CopyFileAsNewName(sourcePath, destPath)
        End If

        If sts = 0 Then
            Me.DefNaviDb.DbPath = destFolder
            Return True
        Else
            Me.DefNaviDb.DbPath = Nothing
            Return False
        End If
    End Function

    Public Function CreateNaviData(ByVal dtShogen As DataTable, ByVal dtNet As DataTable) As DataTable

        Dim dtNabiData As DataTable = CreateNabiDatatable()
        Dim previousPartsCode As String = Nothing
        Dim nowPartsCode As String = Nothing
        Dim naviStep As Integer = 1
        Dim dvNet As DataView = dtNet.DefaultView
        Dim useCount As Integer = 0
        Dim samePartsCodeCount As Integer = 0
        Dim registDate As DateTime = DateTime.Now

        'ナビ不要データ（諸元表の諸元/備考欄に()で記載されている諸元を格納する）テーブル
        Dim dtNoNaviShogen As New DataTable
        Dim noNaviShogenStr As String = Nothing
        'テーブルに諸元列を追加
        dtNoNaviShogen.Columns.Add(SDTColumnName(SDTColumn.Shogen))
        Dim dvNoNaviShogen As New DataView(dtNoNaviShogen)

        'キッティングのみの部材フラグ
        Dim isOnlyKitting As Boolean = False

        For rowIndex As Integer = 0 To dtShogen.Rows.Count - 1
            Dim strRowShogen As String = dtShogen.Rows(rowIndex)(SDTColumnName(SDTColumn.Shogen))
            Dim shogenArray As String() = Split(strRowShogen, ",", -1, CompareMethod.Text)
            Dim strShogen As String = Nothing
            nowPartsCode = dtShogen.Rows(rowIndex)(SDTColumnName(SDTColumn.PartsCode))
            If (rowIndex = 0) OrElse (previousPartsCode <> nowPartsCode) Then
                useCount = dtShogen.Rows(rowIndex)(SDTColumnName(SDTColumn.UseCount))
                samePartsCodeCount = 0
            End If
            For arraycount As Integer = 0 To UBound(shogenArray)
                samePartsCodeCount += 1
                '諸元にかっこ"("が含まれている場合は、その前までを諸元として取得
                Dim leftParenthesisPosi As Integer = shogenArray(arraycount).IndexOf("(")
                If leftParenthesisPosi < 0 Then
                    '"("が無い場合
                    strShogen = shogenArray(arraycount)

                    Dim dashIndex As Integer = strShogen.IndexOf("-")
                    If dashIndex < 0 Then
                        'ハイフン無しの場合
                        'ナビが必要な諸元
                        isOnlyKitting = False
                    Else
                        'ハイフンありの場合
                        'ナビ不要だが、キッティング指示が必要な諸元
                        isOnlyKitting = True
                    End If

                Else
                    '"("の前までを諸元として取得
                    strShogen = shogenArray(arraycount).Substring(0, leftParenthesisPosi)
                    isOnlyKitting = False

                    '"()"ないの諸元を取得（ナビ不要データ）
                    Dim rightParentesisPosi As Integer = shogenArray(arraycount).IndexOf(")")
                    noNaviShogenStr = shogenArray(arraycount).Substring(leftParenthesisPosi + 1,
                                                                     rightParentesisPosi - leftParenthesisPosi - 1)
                    dvNoNaviShogen.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & noNaviShogenStr & "'"

                    If dvNoNaviShogen.Count = 0 Then
                        'ナビ不要データとして追加
                        Dim r As DataRow = dtNoNaviShogen.NewRow
                        r(SDTColumnName(SDTColumn.Shogen)) = noNaviShogenStr
                        dtNoNaviShogen.Rows.Add(r)
                    End If
                End If
                Dim drow As DataRow = dtNabiData.NewRow
                drow(NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName)) = DBNull.Value
                drow(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName)) = True
                drow(NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName)) = Nothing
                drow(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)) = naviStep
                drow(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)) = nowPartsCode

                If samePartsCodeCount <= useCount Then
                    drow(NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName)) = 1
                Else
                    drow(NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName)) = 0
                End If


                drow(NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName)) = strShogen

                dvNet.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & strShogen & "'"
                Dim dtFilterdNetList As DataTable = dvNet.ToTable
                If dtFilterdNetList.Rows.Count = 1 Then
                    drow(NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName)) = dtFilterdNetList.Rows(0)(NLTColmun.X)
                    drow(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName)) = dtFilterdNetList.Rows(0)(NLTColmun.Y)
                    drow(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)) = dtFilterdNetList.Rows(0)(NLTColmun.Rotate)
                Else
                    drow(NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName)) = 0
                    drow(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName)) = 0
                    drow(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)) = 0
                End If

                If isOnlyKitting = True Then
                    drow(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)) = True
                    drow(NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName)) = True
                Else
                    drow(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)) = False
                    drow(NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName)) = True
                End If

                'drow(NVDTColumnInfo(NVDTColumn.RequestTechnicLevel, ElementType.ColumnName)) = 1
                drow(NVDTColumnInfo(NVDTColumn.RegistDate, ElementType.ColumnName)) = registDate
                drow(NVDTColumnInfo(NVDTColumn.RegistManNumber, ElementType.ColumnName)) = SysLoginUserInfo.ManNumber
                drow(NVDTColumnInfo(NVDTColumn.UpdateDate, ElementType.ColumnName)) = DBNull.Value
                drow(NVDTColumnInfo(NVDTColumn.UpdateManNumber, ElementType.ColumnName)) = Nothing
                dtNabiData.Rows.Add(drow)
                naviStep += 1
                previousPartsCode = nowPartsCode
            Next
        Next

        'ナビ不要データの設定
        For Each row As DataRow In dtNabiData.Rows
            dvNoNaviShogen.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & row(SDTColumnName(SDTColumn.Shogen)) & "'"
            If 0 < dvNoNaviShogen.Count Then
                'ナビ不要データ
                row(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)) = True
                row(NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName)) = False
            End If
        Next

        Return dtNabiData
    End Function
    Public Function CreateNabiDatatable() As DataTable
        Dim dt As New DataTable
        Dim count As Integer = UBound(NVDTColumnInfo, 1)

        For col As Integer = 0 To count
            dt.Columns.Add(NVDTColumnInfo(col, ElementType.ColumnName), Type.GetType(NVDTColumnInfo(col, ElementType.DataType)))

        Next
        Return dt
    End Function
End Class
