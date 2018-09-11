Public Class FormMenteTechnicLevelMaster
    '技術レベルマスタテーブル操作用
    Private CtrlDbNaviMaster As ControlDbMaster

    'DataGridView操作用
    Private CtrlDgv As ControlDataGridView = New ControlDataGridView

    'ＤＢ定義
    'Private DefMasterDb As DefineMasterDb = New DefineMasterDb
    Public Sub New(ByVal mstControlDb As ControlDbMaster)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        CtrlDbNaviMaster = mstControlDb.Clone

    End Sub
    ''' <summary>
    ''' フォーム読み込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormMenteTechnicLevelMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingDgvMain()
    End Sub

    ''' <summary>
    ''' 技術レベルマスタメンテナンス用DataGridViewの初期設定を行う処理メイン
    ''' </summary>
    ''' <remarks></remarks>
    Sub SettingDgvMain()
        'DataGridViewのデータ列設定
        SetDgvColumDataMain()
        RefreshDgv()

        DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
        '並べ替えを無効にする
        For Each c As DataGridViewColumn In DataGridView.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
    End Sub
    ''' <summary>
    ''' 技術レベルマスタメンテナンス用DataGridViewの列設定メイン処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDgvColumDataMain()
        '列が自動的に作成されないようにする
        DataGridView.AutoGenerateColumns = False
        CtrlDgv.AddTextboxColumn(DataGridView, "ID", "ID", "ID", True)

        '技術レベル階級列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "技術レベル階級", "技術レベル階級", "技術レベル階級", True)

        '技術レベル列追加
        CtrlDgv.AddTextboxColumn(DataGridView, "技術レベル名", "技術レベル名", "技術レベル名", False)

        '登録者情報列追加
        CtrlDgv.AddRegisterInfoTextboxColoumn(DataGridView)
    End Sub
    ''' <summary>
    ''' 技術レベルマスタメンテナンス用DataGridViewの表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDgv()

        'DataGridView.DataSource = ""
        '接続文字列作成
        Dim connect_txt As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.Append("SELECT ")
        sbSql.Append("a.ID as ID")
        sbSql.Append(",a.技術レベル階級 as 技術レベル階級")
        sbSql.Append(",a.技術レベル名 as 技術レベル名")
        sbSql.Append(",a.登録日 as 登録日")
        sbSql.Append(",b.氏名 as 登録者")
        sbSql.Append(",a.更新日 as 更新日")
        sbSql.Append(",c.氏名 as 更新者")
        sbSql.Append(",a.登録者マンナンバー as 登録者マンナンバー")
        sbSql.Append(",a.更新者マンナンバー as 更新者マンナンバー")

        sbSql.Append(" FROM ")

        '更新者結合-----------------------------------------
        sbSql.Append("(")
        '登録者結合-----------------------------------------
        sbSql.Append("(")
        sbSql.Append(dbnameA & ".[" & CtrlDbNaviMaster.DefMstDb.TableTechnicLevelMaster & "] as a")
        sbSql.Append(" left join ")
        sbSql.Append(dbnameA & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as b")
        sbSql.Append(" ON (a.登録者マンナンバー=b.マンナンバー)")
        sbSql.Append(")")
        '登録者結合--------------------------------------END
        sbSql.Append(" left join ")
        sbSql.Append(dbnameA & ".[" & CtrlDbNaviMaster.DefMstDb.TableUser & "] as c")
        sbSql.Append(" ON (a.更新者マンナンバー=c.マンナンバー)")
        sbSql.Append(")")
        '更新者結合--------------------------------------END

        sbSql.Append(" order by a.技術レベル階級")

        Dim tb As DataTable = CtrlDbNaviMaster.GetTableData(sbSql.ToString, connect_txt)
        If tb IsNot Nothing Then
            CtrlDgv.BindTableToDgv(DataGridView, tb)
        End If
    End Sub
    ''' <summary>
    ''' 更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If IsExistModifiedData() = False Then
            MessageBox.Show("更新データはありません。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If UpDateTechnicTable(CtrlDbNaviMaster.DefMstDb.EnableConnectPassword) = True Then
            RefreshDgv()
            MessageBox.Show("データを更新しました。", "データ更新", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ''' <summary>
    ''' 技術レベルマスタテーブル更新処理メイン
    ''' </summary>
    ''' <param name="isUseConnectPass"></param>
    ''' データベースにパスワードを使用して接続するフラグ
    ''' True(EnableConnectPassword):パスワードを使用して接続
    ''' False(DisableConnectPassword):パスワードを使用せず接続
    ''' <returns>
    ''' True:更新成功　False:更新失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function UpDateTechnicTable(ByVal isUseConnectPass As Boolean) As Boolean
        Dim isCompleteUpdate As Boolean = False

        Dim bs As BindingSource = DirectCast(DataGridView.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)

        Dim connect_txt As String = CtrlDbNaviMaster.GetMasterDbConnectString()

        Dim Cn As New System.Data.OleDb.OleDbConnection(connect_txt)
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
                    Case DataRowState.Modified
                        SQL = GetModifiedSqlString(Row)
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
    ''' <summary>
    ''' 技術レベルマスタテーブル更新SQL文を取得する
    ''' </summary>
    ''' <param name="row">
    ''' 更新する行データ(DataRow)
    ''' </param>
    ''' <returns>
    ''' 取得したSQL文字列
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetModifiedSqlString(ByRef row As DataRow) As String
        Dim sbSqlString As New System.Text.StringBuilder

        Dim dt As DateTime = DateTime.Now
        sbSqlString.Append("UPDATE " & CtrlDbNaviMaster.DefMstDb.TableTechnicLevelMaster)
        sbSqlString.Append(" SET 技術レベル名='" & row("技術レベル名") & "'")
        sbSqlString.Append(",")
        If row("登録者マンナンバー") Is DBNull.Value Then
            sbSqlString.Append(" 登録者マンナンバー='" & SysLoginUserInfo.ManNumber & "'")
            sbSqlString.Append(",")
            sbSqlString.Append(" 登録日='" & dt & "'")
        Else
            sbSqlString.Append(" 更新者マンナンバー='" & SysLoginUserInfo.ManNumber & "'")
            sbSqlString.Append(",")
            sbSqlString.Append(" 更新日='" & dt & "'")
        End If
        sbSqlString.Append(" WHERE ID=" & row("ID", DataRowVersion.Original))

        Return sbSqlString.ToString
    End Function
    ''' <summary>
    ''' 技術レベルマスタの更新データ有無を取得する
    ''' </summary>
    ''' <returns>
    ''' True:更新データ有　False：更新データなし
    ''' </returns>
    ''' <remarks></remarks>
    Public Function IsExistModifiedData() As Boolean
        Dim isExist As Boolean = False

        Dim bs As BindingSource = DirectCast(DataGridView.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)

        For Each Row As DataRow In table.Rows
            Dim SQL As String = ""
            '●SQL文の生成
            Select Case Row.RowState
                Case DataRowState.Modified
                    isExist = True
                    Exit For
                Case Else
                    Continue For
            End Select
        Next

        Return isExist
    End Function


End Class