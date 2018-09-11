Imports System
''' <summary>
''' 部品形状管理クラス
''' </summary>
Public Class PartsShapeData
    Implements ICloneable
    '部品形状ID
    Public Property ShapeID As Integer
    '部品形状名称
    Public Property ShapeName As String
    '部品サイズ（幅）
    Public Property Width As Double
    '部品サイズ（高さ）
    Public Property Height As Double
    '識別符号使用有無
    Public Property IsUseMark As Boolean
    '形状番号
    Public Property ShapeType As Integer
    '識別符号表示位置
    Public Property MarkAlign As Integer
    '図形原点位置(Align.***で指定)
    Public Property OriginAlign As Integer
    '部品分類番号
    Public Property ShapeCategory As Integer

    Public Sub New()
        ShapeID = -1
        ShapeName = Nothing
        Width = 0
        Height = 0
        IsUseMark = False
        MarkAlign = Align.BottomLeft
        ShapeType = Shape.Retacgle
        ShapeCategory = 0
        OriginAlign = Align.BottomLeft
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="shapeTableRow">
    ''' 部品形状テーブルデータ
    ''' </param>
    Public Sub SetShapeData(ByVal shapeTableRow As DataRow)
        'If shapeTableRow(PSTColumnName(PSTColumn.ID)) IsNot DBNull.Value Then
        '    ShapeID = shapeTableRow(PSTColumn.ID)
        'Else
        '    ShapeID = -1
        'End If
        If shapeTableRow(PSTColumnName(PSTColumn.PartsShapeName)) IsNot DBNull.Value Then
            ShapeName = shapeTableRow(PSTColumnName(PSTColumn.PartsShapeName))
        Else
            ShapeName = Nothing
        End If
        Height = shapeTableRow(PSTColumnName(PSTColumn.PartsHeight))
        Width = shapeTableRow(PSTColumnName(PSTColumn.PartsWidth))
        IsUseMark = shapeTableRow(PSTColumnName(PSTColumn.UseMarker))
        MarkAlign = shapeTableRow(PSTColumnName(PSTColumn.MarkerPosi))
        ShapeType = shapeTableRow(PSTColumnName(PSTColumn.PartsShapeId))
        'ShapeCategory = shapeTableRow(PSTColumnName(PSTColumn.PartsShapeTypeId))
        OriginAlign = shapeTableRow(PSTColumnName(PSTColumn.OriginPosi))
    End Sub
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

End Class
