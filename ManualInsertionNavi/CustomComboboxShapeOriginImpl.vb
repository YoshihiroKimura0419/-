Public Class CustomComboboxShapeOriginImpl
    Inherits AbstractCustomCombobox
    Implements ICustomCombobox
    '最大アイテム数
    Public ItemNum As Integer = 5
    'カスタムアライン定義
    'Private CustomAlign As New CustomAlign
    Public Sub New(ByRef markCombo As ComboBox)
        MyCombobox = markCombo
        MaxItemNum = ItemNum
        MyCombobox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Overrides Sub SetComboboxDataSource()
        Dim tb As New DataTable
        tb.Columns.Add("Value", GetType(Integer))
        tb.Columns.Add("Diaplay", GetType(String))
        tb.Rows.Add(Align.BottomLeft, AlignText(Align.BottomLeft))
        tb.Rows.Add(Align.BottomRight, AlignText(Align.BottomRight))
        tb.Rows.Add(Align.MiddleCenter, AlignText(Align.MiddleCenter))
        tb.Rows.Add(Align.TopLeft, AlignText(Align.TopLeft))
        tb.Rows.Add(Align.TopRight, AlignText(Align.TopRight))

        'tb.Rows.Add(Align.BottomLeft, CustomAlign.GetAlignText(Align.BottomLeft))
        'tb.Rows.Add(Align.BottomRight, CustomAlign.GetAlignText(Align.BottomRight))
        'tb.Rows.Add(Align.MiddleCenter, CustomAlign.GetAlignText(Align.MiddleCenter))
        'tb.Rows.Add(Align.TopLeft, CustomAlign.GetAlignText(Align.TopLeft))
        'tb.Rows.Add(Align.TopRight, CustomAlign.GetAlignText(Align.TopRight))

        MyCombobox.DataSource = tb
        MyCombobox.DisplayMember = "Diaplay"
        MyCombobox.ValueMember = "Value"
    End Sub

End Class
