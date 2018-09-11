Imports System
''' <summary>
''' 描画倍率管理
''' </summary>
''' <remarks></remarks>
Public Class ControlDrawRatio
    Implements ICloneable
    'X側倍率
    Public Property X As Double
    'Y側倍率
    Public Property Y As Double

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>
    ''' X,Yの描画倍率を１．０としてインスタンスを作成
    ''' </remarks>
    Public Sub New()
        X = 1.0
        Y = 1.0
    End Sub
    ''' <summary>
    ''' 描画倍率を変更する。
    ''' </summary>
    ''' <param name="xRatio">
    ''' X方向の描画倍率
    ''' </param>
    ''' <param name="yRatio">
    ''' Y方向の描画倍率
    ''' </param>
    ''' <remarks></remarks>
    Public Sub ChangeRatio(ByVal xRatio As Double, ByVal yRatio As Double)
        X = xRatio
        Y = yRatio
    End Sub
    ''' <summary>
    ''' クラスコピー
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function
End Class
