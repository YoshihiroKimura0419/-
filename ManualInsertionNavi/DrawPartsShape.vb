Public Class DrawPartsShape
    '**********************************************************************************************************
    '部品描画クラス
    '本クラスを使用する上での注意事項
    'TranslateTransform使用時
    'TranslateTransformは軸に沿っての移動ではなく、単純にWindows座標系で原点(左上)空のの並行移動となるので注意！！
    '　左上：原点　X軸：右側に＋方向　Y軸：下側に＋方向
    'さらにScaleTransformで設定した倍率は適用されないので、独自で計算しなければならない。
    'Matrixクラスついては右記URL参照　https://msdn.microsoft.com/ja-jp/library/system.drawing.drawing2d.matrix(v=vs.110).aspx
    '**********************************************************************************************************

    '塗りつぶし色のアルファ値設定(0：完全透明～255：完全不透明)
    Private Const ColorAlpha As Integer = 200
    '図形枠の幅(mm)
    Private Const PenWidth As Single = 0.5
    '図形枠の幅(mm)
    Private Const OutlinePenWidth As Single = 1

    '部品塗りつぶし色(Enum　DrawParsStatusで指定)
    Private DrawShapeColor As Color() = {
        Color.FromArgb(ColorAlpha, Color.Red), Color.FromArgb(ColorAlpha, Color.Orange),
        Color.FromArgb(255, Color.White), Color.FromArgb(255, Color.Yellow)
    }

    '識別符号色(Enum　DrawParsStatusで指定)
    Private DrawMarkColor As Color() = {
        Color.FromArgb(ColorAlpha, Color.Yellow), Color.FromArgb(ColorAlpha, Color.Red),
        Color.FromArgb(255, Color.Red), Color.FromArgb(255, Color.Blue)
    }
    '図形を描画する色指定
    Private Property DrawingColor As Color = DrawShapeColor(DrawParsStatus.MonitorSelectedParts)

    '図形を描画する色指定
    Private Property MarkColor As Color = DrawMarkColor(DrawParsStatus.MonitorSelectedParts)

    '図形原点位置を表す（Aling.***で指定）
    Public Property ShapeOriginAlign As Integer

    '座標軸の原点からの長さ(mm)
    Private Const AxsisLength As Single = 5000

    '識別符号の大きさ(mm)
    Private MarkWidth As Double = 4
    Private MarkHeight As Double = 4

    Private DrawRatio As New ControlDrawRatio
    Private CanvasMillimeterWidth As Double
    Private CanvasMillimeterHeight As Double

    Public Sub New(ByVal partsStatus As Integer)
        SetDrawingColor(partsStatus)
        SetMarkColor(partsStatus)
        ShapeOriginAlign = Align.BottomLeft
        DrawRatio.X = 1.0
        DrawRatio.Y = 1.0

    End Sub
    Public Sub SetDrawingColor(ByVal partsStatus As Integer)
        DrawingColor = DrawShapeColor(partsStatus)
    End Sub
    Public Sub SetMarkColor(ByVal partsStatus As Integer)
        MarkColor = DrawMarkColor(partsStatus)
    End Sub
    Public Function GetDrawingColor() As Color
        Return DrawingColor
    End Function
    Public Function GetMarkColor() As Color
        Return MarkColor
    End Function

    Public Sub SetDrawRatio(ByVal scaleX As Double, ByVal scaleY As Double)
        DrawRatio.X = scaleX
        DrawRatio.Y = scaleY
    End Sub
    Private Function GetPosiX(ByVal dShapeInfo As DrawShapeInfo) As Double
        Dim posiX As Double = 0

        Select Case dShapeInfo.PartsShape.OriginAlign
            Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                posiX = 0

            Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                posiX = -(dShapeInfo.PartsShape.Width / 2)

            Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                posiX = -dShapeInfo.PartsShape.Width
        End Select

        Return posiX
    End Function
    Private Function GetPosiY(ByVal dShapeInfo As DrawShapeInfo) As Double
        Dim posiY As Double = 0

        Select Case dShapeInfo.PartsShape.OriginAlign
            Case Align.BottomLeft, Align.BottomCenter, Align.BottomRight
                posiY = 0

            Case Align.MiddleLeft, Align.MiddleCenter, Align.MiddleRight
                posiY = -(dShapeInfo.PartsShape.Height / 2)

            Case Align.TopLeft, Align.TopCenter, Align.TopRight
                posiY = -dShapeInfo.PartsShape.Height
        End Select

        Return posiY
    End Function

    Public Sub DrawOneParts(ByRef pictBox As PictureBox, ByVal drawShapeInfo As DrawShapeInfo)

        Dim canvas As New Bitmap(pictBox.Width, pictBox.Height)
        Dim allGraphics As Graphics = Graphics.FromImage(canvas)
        Dim partsPosiX As Double
        Dim partsPosiY As Double

        CanvasMillimeterWidth = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter / DrawRatio.X
        CanvasMillimeterHeight = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter / DrawRatio.Y
        '座標軸描画
        DrawAxis(allGraphics, canvas, Align.MiddleCenter)

        allGraphics.PageUnit = GraphicsUnit.Millimeter
        allGraphics.ScaleTransform(CType(DrawRatio.X, Single), CType(DrawRatio.Y, Single), MatrixOrder.Append)
        '座標系をWindows系から数学で扱う座標系に変換
        'Matrixクラスついては右記URL参照　https://msdn.microsoft.com/ja-jp/library/system.drawing.drawing2d.matrix(v=vs.110).aspx
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        allGraphics.MultiplyTransform(myMatrix)

        MoveOrigin(allGraphics, CanvasMillimeterWidth, CanvasMillimeterHeight, Align.MiddleCenter)

        partsPosiX = 0
        partsPosiY = 0

        Dim realDrawPosi As New DrawPosition
        realDrawPosi.X = GetPosiX(drawShapeInfo)
        realDrawPosi.Y = GetPosiY(drawShapeInfo)

        Using partsBrush As SolidBrush = New SolidBrush(GetDrawingColor)
            Using blkPen As New Pen(Color.Black, PenWidth)
                Dim pwidth As Single = CSng(drawShapeInfo.PartsShape.Width)
                Dim pheight As Single = CSng(drawShapeInfo.PartsShape.Height)
                Select Case drawShapeInfo.PartsShape.ShapeType
                    Case Shape.Circle
                        allGraphics.FillEllipse(partsBrush, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                        allGraphics.DrawEllipse(blkPen, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                    Case Shape.Retacgle
                        allGraphics.FillRectangle(partsBrush, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                        allGraphics.DrawRectangle(blkPen, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                End Select

            End Using

        End Using

        '符号描画
        If drawShapeInfo.PartsShape.IsUseMark = True Then
            DrawMark(allGraphics, drawShapeInfo)
        End If

        ''ワールド座標リセット
        allGraphics.ResetTransform()

        ''オブジェクトのリソースを解放する
        allGraphics.Dispose()
        'pictBoxに表示する
        pictBox.Image = canvas

    End Sub

    Public Sub Draw(ByRef pictBox As PictureBox, ByVal drawShapeList As List(Of DrawShapeInfo), ByVal isDrawAxis As Boolean, ByVal originAlign As Integer, ByVal isDrawOutline As Boolean)

        Dim canvas As New Bitmap(pictBox.Width, pictBox.Height)
        Dim allGraphics As Graphics = Graphics.FromImage(canvas)
        Dim partsPosiX As Double
        Dim partsPosiY As Double
        DrawAxis(allGraphics, canvas, originAlign)

        CanvasMillimeterWidth = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter
        CanvasMillimeterHeight = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter
        allGraphics.PageUnit = GraphicsUnit.Millimeter
        Using outLineRedPen As New Pen(Color.Red, OutlinePenWidth)
            If isDrawOutline = True Then
                allGraphics.DrawRectangle(outLineRedPen,
                                        CSng(OutlinePenWidth / 2),
                                        CSng(OutlinePenWidth / 2),
                                        CSng(CanvasMillimeterWidth - OutlinePenWidth),
                                        CSng(CanvasMillimeterHeight - OutlinePenWidth)
                                        )
            End If
        End Using

        For i As Integer = 0 To drawShapeList.Count - 1
            allGraphics.PageUnit = GraphicsUnit.Millimeter

            '本設定でスケールを変更してもTranslateTransformでの原点移動には、スケールが反映されない。
            allGraphics.ScaleTransform(CType(DrawRatio.X, Single), CType(DrawRatio.Y, Single), MatrixOrder.Append)

            '座標系をWindows系から数学で扱う座標系に変換
            'Matrixクラスついては右記URL参照　https://msdn.microsoft.com/ja-jp/library/system.drawing.drawing2d.matrix(v=vs.110).aspx
            Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
            allGraphics.MultiplyTransform(myMatrix)

            '回転角度設定
            allGraphics.RotateTransform(drawShapeList(i).Rotation, MatrixOrder.Append)

            '原点移動
            '部品の原点位置とサイズから算出
            'TranslateTransformは軸に沿っての移動ではなく、単純にWindows座標系での並行移動となるので注意！！
            '左上：原点　X軸：右側に＋方向　Y軸：下側に＋方向
            'さらにScaleTransformで設定した倍率は適用されないので、独自で計算しなければならない。
            partsPosiX = drawShapeList(i).Posi.X * DrawRatio.X
            partsPosiY = CanvasMillimeterHeight - (drawShapeList(i).Posi.Y * DrawRatio.Y)

            '原点移動後の原点からの描画位置
            Dim realDrawPosi As New DrawPosition
            realDrawPosi.X = GetPosiX(drawShapeList(i))
            realDrawPosi.Y = GetPosiY(drawShapeList(i))

            allGraphics.TranslateTransform(partsPosiX, partsPosiY, MatrixOrder.Append)

            Using blkPen As New Pen(Color.Black, PenWidth)
                Using partsBrush As SolidBrush = New SolidBrush(GetDrawingColor)
                    Dim pwidth As Single = CSng(drawShapeList(i).PartsShape.Width)
                    Dim pheight As Single = CSng(drawShapeList(i).PartsShape.Height)
                    Select Case drawShapeList(i).PartsShape.ShapeType
                        Case Shape.Circle
                            allGraphics.FillEllipse(partsBrush, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                            allGraphics.DrawEllipse(blkPen, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                        Case Shape.Retacgle
                            allGraphics.FillRectangle(partsBrush, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                            allGraphics.DrawRectangle(blkPen, CSng(realDrawPosi.X), CSng(realDrawPosi.Y), pwidth, pheight)
                    End Select
                End Using
            End Using


            '符号描画
            If drawShapeList(i).PartsShape.IsUseMark = True Then
                DrawMark(allGraphics, drawShapeList(i))
            End If

            ''ワールド座標リセット
            allGraphics.ResetTransform()

        Next
        ''オブジェクトのリソースを解放する
        allGraphics.Dispose()
        'pictBoxに表示する
        pictBox.Image = canvas

    End Sub
    Private Sub DrawMark(ByRef allGraphics As Graphics, ByVal shapeInfo As DrawShapeInfo)
        Dim pWidth As Double = shapeInfo.PartsShape.Width
        Dim pHeight As Double = shapeInfo.PartsShape.Height
        Dim pAlign As Integer = shapeInfo.PartsShape.OriginAlign
        Dim mAlign As Integer = shapeInfo.PartsShape.MarkAlign
        Dim mPosiX As Double
        Dim mPosiY As Double
        Select Case pAlign
            Case Align.BottomCenter
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = 0
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = (pHeight - MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth / 2
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -MarkWidth / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth / 2 - MarkWidth
                End Select
            Case Align.BottomLeft
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = 0
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = (pHeight - MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = 0
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = (pWidth - MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth - MarkWidth
                End Select
            Case Align.BottomRight
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = 0
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = (pHeight - MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -(pWidth + MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = -MarkWidth
                End Select

            Case Align.MiddleCenter
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight / 2
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -MarkHeight / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight / 2 - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth / 2
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -MarkWidth / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth / 2 - MarkWidth
                End Select
            Case Align.MiddleLeft
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight / 2
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -MarkHeight / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight / 2 - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = 0
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = (pWidth - MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth - MarkWidth
                End Select
            Case Align.MiddleRight
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight / 2
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -MarkHeight / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = pHeight / 2 - MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -(pWidth + MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = -MarkWidth
                End Select

            Case Align.TopCenter
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -(pHeight + MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = -MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth / 2
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -MarkWidth / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth / 2 - MarkWidth
                End Select
            Case Align.TopLeft
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -(pHeight + MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = -MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = 0
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = (pWidth - MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = pWidth - MarkWidth
                End Select
            Case Align.TopRight
                '符号Y座標計算
                Select Case mAlign
                    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
                        mPosiY = -pHeight
                    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
                        mPosiY = -(pHeight + MarkHeight) / 2
                    Case Align.TopCenter, Align.TopLeft, Align.TopRight
                        mPosiY = -MarkHeight
                End Select
                '符号X座標計算
                Select Case mAlign
                    Case Align.BottomLeft, Align.MiddleLeft, Align.TopLeft
                        mPosiX = -pWidth
                    Case Align.BottomCenter, Align.MiddleCenter, Align.TopCenter
                        mPosiX = -(pWidth + MarkWidth) / 2
                    Case Align.BottomRight, Align.MiddleRight, Align.TopRight
                        mPosiX = -MarkWidth
                End Select
        End Select
        Dim markBrush As SolidBrush = New SolidBrush(GetMarkColor)
        allGraphics.FillEllipse(markBrush, CSng(mPosiX), CSng(mPosiY), CSng(MarkWidth), CSng(MarkHeight))
        markBrush.Dispose()
    End Sub

    Private Sub DrawAxis(ByRef allGraphics As Graphics, ByRef canvas As Bitmap, ByVal originAlign As Integer)
        '原点位置は、移動するが座標系は、数学と同じものを用いる
        Dim XstartPosi As New DrawPosition
        Dim XendPosi As New DrawPosition
        Dim YstartPosi As New DrawPosition
        Dim YendPosi As New DrawPosition

        allGraphics.PageUnit = GraphicsUnit.Millimeter
        allGraphics.ScaleTransform(CType(DrawRatio.X, Single), CType(DrawRatio.Y, Single), MatrixOrder.Append)
        '座標系をWindows系から数学で扱う座標系に変換
        'Matrixクラスついては右記URL参照　https://msdn.microsoft.com/ja-jp/library/system.drawing.drawing2d.matrix(v=vs.110).aspx
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        allGraphics.MultiplyTransform(myMatrix)

        CanvasMillimeterWidth = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter / DrawRatio.X
        CanvasMillimeterHeight = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter / DrawRatio.Y

        MoveOrigin(allGraphics, CanvasMillimeterWidth, CanvasMillimeterHeight, originAlign)

        'X軸の描画座標計算
        XstartPosi.X = -AxsisLength
        XstartPosi.Y = 0
        XendPosi.X = AxsisLength
        XendPosi.Y = 0

        'X軸の描画座標計算
        YstartPosi.X = 0
        YstartPosi.Y = -AxsisLength
        YendPosi.X = 0
        YendPosi.Y = AxsisLength

        'Penを用意する
        Dim blackPen As New Pen(Color.Black, 0.5F)
        'X軸描画
        allGraphics.DrawLine(blackPen, -AxsisLength, 0, AxsisLength, 0)
        'Y軸描画
        allGraphics.DrawLine(blackPen, 0, -AxsisLength, 0, AxsisLength)

        blackPen.Dispose()
        allGraphics.ResetTransform()
    End Sub
    Public Sub DrawOutLine(ByRef pictBox As PictureBox)

        Dim canvas As New Bitmap(pictBox.Width, pictBox.Height)
        Dim allGraphics As Graphics = Graphics.FromImage(canvas)

        CanvasMillimeterWidth = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter
        CanvasMillimeterHeight = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter
        allGraphics.PageUnit = GraphicsUnit.Millimeter
        Using outLineRedPen As New Pen(Color.Red, OutlinePenWidth)
            allGraphics.DrawRectangle(outLineRedPen,
                                        CSng(OutlinePenWidth / 2),
                                        CSng(OutlinePenWidth / 2),
                                        CSng(CanvasMillimeterWidth - OutlinePenWidth),
                                        CSng(CanvasMillimeterHeight - OutlinePenWidth)
                                        )
        End Using

        ''オブジェクトのリソースを解放する
        allGraphics.Dispose()
        'pictBoxに表示する
        pictBox.Image = canvas

    End Sub

    Private Sub MoveOrigin(ByRef allGraphics As Graphics, ByVal canvasMillimeterWidth As Double, ByVal canvasMillimeterHeight As Double, ByVal originAlign As Integer)
        'TranslateTransformは、
        Select Case originAlign
            Case Align.BottomCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2 * DrawRatio.X, canvasMillimeterHeight * DrawRatio.Y, MatrixOrder.Append)
            Case Align.BottomLeft
                allGraphics.TranslateTransform(0, canvasMillimeterHeight * DrawRatio.Y, MatrixOrder.Append)
            Case Align.BottomRight
                allGraphics.TranslateTransform(canvasMillimeterWidth * DrawRatio.X, canvasMillimeterHeight * DrawRatio.Y, MatrixOrder.Append)
            Case Align.MiddleCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2 * DrawRatio.X, canvasMillimeterHeight / 2 * DrawRatio.Y, MatrixOrder.Append)
            Case Align.MiddleLeft
                allGraphics.TranslateTransform(0, canvasMillimeterHeight / 2 * DrawRatio.X * DrawRatio.Y, MatrixOrder.Append)
            Case Align.MiddleRight
                allGraphics.TranslateTransform(canvasMillimeterWidth * DrawRatio.X, canvasMillimeterHeight / 2 * DrawRatio.Y, MatrixOrder.Append)
            Case Align.TopCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2 * DrawRatio.X, 0, MatrixOrder.Append)
            Case Align.TopLeft
                allGraphics.TranslateTransform(0, 0, MatrixOrder.Append)
            Case Align.TopRight
                allGraphics.TranslateTransform(canvasMillimeterWidth * DrawRatio.X, 0, MatrixOrder.Append)
        End Select

    End Sub



End Class
