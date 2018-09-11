Public Class CustomComboboxShapeNameImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox

    'マスターデータ操作用
    Private CtrlDNM As ControlDbMaster

    Public Sub New(ByRef markCombo As ComboBox, ByVal mstContDb As ControlDbMaster)
        MyCombobox = markCombo
        CtrlDNM = mstContDb.Clone
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Overrides Sub SetComboboxDataSource()
        '接続文字列作成
        Dim connect_txt As String = CtrlDNM.GetMasterDbConnectString()
        'DBパス取得
        Dim dbnameA As String = CtrlDNM.GetMasterDbPathString()

        'SQL文
        Dim sbSql As New System.Text.StringBuilder

        sbSql.Append("SELECT ")
        sbSql.Append(" a." & PSTColumnName(PSTColumn.ID) & " as " & PSTColumnName(PSTColumn.ID))
        sbSql.Append(",a." & PSTColumnName(PSTColumn.DataEnable) & " as " & PSTColumnName(PSTColumn.DataEnable))
        sbSql.Append(",a." & PSTColumnName(PSTColumn.PartsShapeName) & " as " & PSTColumnName(PSTColumn.PartsShapeName))
        sbSql.Append(",a." & PSTColumnName(PSTColumn.PartsShapeTypeId) & " as " & PSTColumnName(PSTColumn.PartsShapeTypeId))
        sbSql.Append(" FROM ")
        sbSql.Append(dbnameA & ".[" & CtrlDNM.DefMstDb.TablePartsShapeMaster & "] as a")
        sbSql.Append(" where a." & PSTColumnName(PSTColumn.DataEnable) & "=True")
        sbSql.Append(" order by a." & PSTColumnName(PSTColumn.PartsShapeName))
        Dim tb As DataTable = CtrlDNM.GetTableData(sbSql.ToString, connect_txt)
        Dim InsertRow As DataRow = tb.NewRow
        tb.Rows.InsertAt(InsertRow, 0)
        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = PSTColumnName(PSTColumn.PartsShapeName)
        MyCombobox.ValueMember = PSTColumnName(PSTColumn.ID)
    End Sub

End Class
