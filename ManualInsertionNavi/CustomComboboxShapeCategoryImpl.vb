Public Class CustomComboboxShapeCategoryImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox

    'マスターデータ操作用
    Private MasterControlDb As ControlDbMaster

    Public Sub New(ByRef markCombo As ComboBox, ByVal mstContDb As ControlDbMaster)
        MyCombobox = markCombo
        MasterControlDb = mstContDb.Clone
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Overrides Sub SetComboboxDataSource()
        '接続文字列作成
        Dim connect_txt As String = MasterControlDb.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = MasterControlDb.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.Append("SELECT ")
        sbSql.Append(PSCTColumnName(PSCTColumn.ID))
        sbSql.Append("," & PSCTColumnName(PSCTColumn.DataEnable))
        sbSql.Append("," & PSCTColumnName(PSCTColumn.PartsShapeCategoryName))
        sbSql.Append(" FROM ")
        sbSql.Append(dbnameA & ".[" & MasterControlDb.DefMstDb.TablePartsShapeCategory & "] as a")
        sbSql.Append(" where a." & PSCTColumnName(PSCTColumn.DataEnable) & "=True")
        sbSql.Append(" order by a." & PSCTColumnName(PSCTColumn.PartsShapeCategoryName))
        Dim tb As DataTable = MasterControlDb.GetTableData(sbSql.ToString, connect_txt)
        Dim InsertRow As DataRow = tb.NewRow
        tb.Rows.InsertAt(InsertRow, 0)
        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = PSCTColumnName(PSCTColumn.PartsShapeCategoryName)
        MyCombobox.ValueMember = PSCTColumnName(PSCTColumn.ID)

    End Sub

End Class
