Imports System

Public Class DrawShapeInfo
    Implements ICloneable

    '描画位置定義
    Public Posi As New DrawPosition

    '原点座標構造体定義
    Public Origin As New DrawOrigin

    '原点位置
    Public Property OriginAlign As Integer

    '描画図形データ
    Public PartsShape As PartsShapeData

    '描画回転角度
    Public Property Rotation As Single

    ''' <summary>
    ''' 各図形の描画情報管理クラスコンストラクタ
    ''' </summary>
    ''' <param name="cvsSize">
    ''' 描画キャンバスサイズ構造体
    ''' </param>
    ''' <param name="canvasOriginAlign">
    ''' 描画キャンバスの原点位置(Align.***で指定)
    ''' </param>
    ''' <param name="rot">
    ''' 描画回転角度（0～360：左回り）
    ''' </param>
    ''' <param name="drawPosi">
    ''' 描画位置構造体
    ''' </param>
    ''' <param name="shapeData"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal cvsSize As DoubleSize, ByVal canvasOriginAlign As Integer, ByVal drawPosi As DrawPosition, ByVal rot As Single, ByVal shapeData As PartsShapeData)
        PartsShape = shapeData.Clone
        OriginAlign = canvasOriginAlign
        ChangeOrigin(cvsSize, OriginAlign)
        SetDrawPosi(drawPosi, OriginAlign)
        Rotation = rot
    End Sub

    ''' <summary>
    ''' drawPosiで指定された描画位置（X,Y座標）をorgnAlign(Align.***で指定)にあわせ座標変換する。
    ''' </summary>
    ''' <param name="drawPosi">
    ''' 図形描画位置DrawPositionオブジェクト
    ''' </param>
    ''' <param name="orgnAlign">
    ''' 描画キャンバスの原点位置(Align.***で指定)
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetDrawPosi(ByVal drawPosi As DrawPosition, ByVal orgnAlign As Integer)
        Posi.X = drawPosi.X
        Posi.Y = drawPosi.Y

    End Sub
    ''' <summary>
    ''' cvsSizeのデータからorgnAlign(Align.***で指定)にあわせ原点位置を変更する。
    ''' </summary>
    ''' <param name="cvsSize">
    ''' 描画キャンバス情報CanvasSize構造体
    ''' </param>
    ''' <param name="orgnAlign">
    ''' 描画キャンバスの原点位置(Align.***で指定)
    ''' </param>
    ''' <remarks></remarks>
    Private Sub ChangeOrigin(ByVal cvsSize As DoubleSize, ByVal orgnAlign As Integer)
        Select Case orgnAlign
            Case Align.BottomLeft
                Origin.X = CType(0, Double)
                Origin.Y = CType(cvsSize.Height, Double)
            Case Align.BottomCenter
                Origin.X = CType(cvsSize.Width / 2, Double)
                Origin.Y = CType(cvsSize.Height, Double)
            Case Align.BottomRight
                Origin.X = CType(cvsSize.Width, Double)
                Origin.Y = CType(cvsSize.Height, Double)
            Case Align.MiddleLeft
                Origin.X = CType(0, Double)
                Origin.Y = CType(cvsSize.Height / 2, Double)
            Case Align.MiddleCenter
                Origin.X = CType(cvsSize.Width / 2, Double)
                Origin.Y = CType(cvsSize.Height / 2, Double)
            Case Align.MiddleRight
                Origin.X = CType(cvsSize.Width, Double)
                Origin.Y = CType(cvsSize.Height / 2, Double)
            Case Align.TopLeft
                Origin.X = CType(0, Double)
                Origin.Y = CType(0, Double)
            Case Align.TopCenter
                Origin.X = CType(cvsSize.Width / 2, Double)
                Origin.Y = CType(0, Double)
            Case Align.TopRight
                Origin.X = CType(cvsSize.Width, Double)
                Origin.Y = CType(0, Double)
        End Select

    End Sub
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function
End Class
