Public Class FormTestDraw
    Dim DrawRatio As Double = 1.0
    '部品原点位置コンボボックスコントロール
    Private CtrlOriginAlignCombobox As CustomComboboxShapeOriginImpl

    Private Sub DrawAxis(ByRef allGraphics As Graphics, ByRef canvas As Bitmap, ByVal originAlign As Integer)
        '原点位置は、移動するが座標系は、数学と同じものを用いる
        Dim XstartPosi As New DrawPosition
        Dim XendPosi As New DrawPosition
        Dim YstartPosi As New DrawPosition
        Dim YendPosi As New DrawPosition
        allGraphics.PageUnit = GraphicsUnit.Millimeter
        allGraphics.ScaleTransform(0.5, 0.5, MatrixOrder.Append)
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        allGraphics.MultiplyTransform(myMatrix)

        ' Set world transform of graphics object to rotate.
        allGraphics.RotateTransform(30.0F, MatrixOrder.Append)
        Dim testBlkPen As New Pen(Color.DarkGreen, 0.5F)
        Dim testRPen As New Pen(Color.DarkOrange, 0.5F)
        allGraphics.DrawLine(testBlkPen, -1000, 0, 1000, 0)
        allGraphics.DrawLine(testRPen, 0, -1000, 0, 1000)
        'allGraphics.DrawLine(testRPen, 10, -1000, 10, 1000)
        testRPen.Dispose()
        testBlkPen.Dispose()

        ' Then to translate, appending to world transform.
        allGraphics.TranslateTransform(40.0F, 30.0F, MatrixOrder.Append)
        allGraphics.DrawRectangle(New Pen(Color.Blue, 3), 0, 0, 20, 30)

        Dim testPen As New Pen(Color.Black, 0.5F)
        Dim testRedPen As New Pen(Color.Red, 0.5F)
        allGraphics.DrawLine(testPen, -1000, 0, 1000, 0)
        allGraphics.DrawLine(testRedPen, 0, -1000, 0, 1000)
        testRedPen.Dispose()
        testPen.Dispose()


        allGraphics.RotateTransform(30.0F, MatrixOrder.Append)
        Dim cyanPen As New Pen(Color.DarkCyan, 0.5F)
        allGraphics.DrawRectangle(cyanPen, -5, -5, 10, 10)
        cyanPen.Dispose()

        allGraphics.TranslateTransform(10.0F, 20.0F, MatrixOrder.Append)

        Dim orangePen As New Pen(Color.Orange, 0.5F)
        Dim pinkPen As New Pen(Color.Pink, 0.5F)
        allGraphics.DrawLine(orangePen, -1000, 0, 1000, 0)
        allGraphics.DrawLine(pinkPen, 0, -1000, 0, 1000)
        allGraphics.DrawRectangle(orangePen, -5, -5, 10, 10)
        pinkPen.Dispose()
        orangePen.Dispose()


        ' Draw rotated, translated ellipse to screen.
        allGraphics.DrawRectangle(New Pen(Color.Blue, 3), 0, 0, 20, 30)



        'allGraphics.PageUnit = GraphicsUnit.Millimeter
        'allGraphics.ScaleTransform(CType(DrawRatio, Single), CType(DrawRatio, Single), MatrixOrder.Append)

        'Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        'allGraphics.MultiplyTransform(myMatrix)

        'Dim canvasMillimeterWidth As Double = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter / DrawRatio
        'Dim canvasMillimeterHeight As Double = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter / DrawRatio
        'allGraphics.TranslateTransform(canvasMillimeterWidth / 2, -canvasMillimeterHeight / 2, MatrixOrder.Append)

        'Dim testPen As New Pen(Color.Black, 0.5F)
        'Dim testRedPen As New Pen(Color.Red, 0.5F)
        'allGraphics.DrawLine(testPen, -1000, 0, 1000, 0)
        'allGraphics.DrawLine(testRedPen, 0, -1000, 0, 1000)

        'allGraphics.DrawRectangle(testPen, -10, -15, 20, 30)


        'allGraphics.TranslateTransform(20, 20)
        'allGraphics.RotateTransform(45, MatrixOrder.Append)
        'allGraphics.DrawLine(testPen, -1000, 0, 1000, 0)
        'allGraphics.DrawLine(testRedPen, 0, -1000, 0, 1000)

        'testRedPen.Dispose()
        'testPen.Dispose()

        'TrasrateOrigin(allGraphics, canvasMillimeterWidth, canvasMillimeterHeight, originAlign)
        ''X軸の描画座標計算
        'Select Case originAlign
        '    Case Align.BottomCenter
        '        XstartPosi.X = -(canvasMillimeterWidth / 2) / DrawRatio
        '        XstartPosi.Y = 0
        '        XendPosi.X = canvasMillimeterWidth / 2 / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.BottomLeft
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.BottomRight
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = -canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.MiddleCenter
        '        XstartPosi.X = canvasMillimeterWidth / 2 / DrawRatio
        '        XstartPosi.Y = 0
        '        XendPosi.X = -(canvasMillimeterWidth / 2) / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.MiddleLeft
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.MiddleRight
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = -canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.TopCenter
        '        XstartPosi.X = canvasMillimeterWidth / DrawRatio
        '        XstartPosi.Y = 0
        '        XendPosi.X = -canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.TopLeft
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        '    Case Align.TopRight
        '        XstartPosi.X = 0
        '        XstartPosi.Y = 0
        '        XendPosi.X = -canvasMillimeterWidth / DrawRatio
        '        XendPosi.Y = 0
        'End Select

        ''X軸の描画座標計算
        'Select Case originAlign
        '    Case Align.BottomCenter, Align.BottomLeft, Align.BottomRight
        '        YstartPosi.X = 0
        '        YstartPosi.Y = 0
        '        YendPosi.X = 0
        '        YendPosi.Y = canvas.Height / DrawRatio
        '    Case Align.MiddleCenter, Align.MiddleLeft, Align.MiddleRight
        '        YstartPosi.X = 0
        '        YstartPosi.Y = -canvasMillimeterHeight / 2 / DrawRatio
        '        YendPosi.X = 0
        '        YendPosi.Y = canvasMillimeterHeight / 2 / DrawRatio
        '    Case Align.TopCenter, Align.TopLeft, Align.TopRight
        '        YstartPosi.X = 0
        '        YstartPosi.Y = 0
        '        YendPosi.X = 0
        '        YendPosi.Y = -(canvasMillimeterHeight / 2) / DrawRatio
        'End Select

        ''Penを用意する
        'Dim redPen As New Pen(Color.Red, 0.5F)
        ''Penを用意する
        'Dim blackPen As New Pen(Color.Black, 0.5F)

        ''X軸描画
        'allGraphics.DrawLine(blackPen, CType((XstartPosi.X), Single), CType(XstartPosi.Y, Single), CType(XendPosi.X, Single), CType(XendPosi.Y, Single))
        ''Y軸描画
        'allGraphics.DrawLine(blackPen, CType((YstartPosi.X), Single), CType(YstartPosi.Y, Single), CType(YendPosi.X, Single), CType(YendPosi.Y, Single))

        'allGraphics.DrawRectangle(blackPen, 10.0F, 10.0F, 20, 30)
        'allGraphics.DrawRectangle(redPen, -20.0F, -10.0F, 40, 30)

        'allGraphics.TranslateTransform(10, 5)
        'allGraphics.RotateTransform(30)

        'Dim bluePen As New Pen(Color.Blue, 0.5F)
        'allGraphics.DrawRectangle(bluePen, 0, 0, 20, 30)
        'bluePen.Dispose()


    End Sub
    Private Sub TrasrateOrigin(ByRef allGraphics As Graphics, ByVal canvasMillimeterWidth As Double, ByVal canvasMillimeterHeight As Double, ByVal originAlign As Integer)
        '座標系をWindows系から数学で扱う座標系に変換
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        allGraphics.MultiplyTransform(myMatrix)

        Select Case originAlign
            Case Align.BottomCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2, canvasMillimeterHeight, MatrixOrder.Append)
            Case Align.BottomLeft
                allGraphics.TranslateTransform(0, canvasMillimeterHeight, MatrixOrder.Append)
            Case Align.BottomRight
                allGraphics.TranslateTransform(canvasMillimeterWidth, canvasMillimeterHeight, MatrixOrder.Append)
            Case Align.MiddleCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2, canvasMillimeterHeight / 2, MatrixOrder.Append)
            Case Align.MiddleLeft
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2, 0, MatrixOrder.Append)
            Case Align.MiddleRight
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2, canvasMillimeterHeight, MatrixOrder.Append)
            Case Align.TopCenter
                allGraphics.TranslateTransform(canvasMillimeterWidth / 2, 0, MatrixOrder.Append)
            Case Align.TopLeft
                allGraphics.TranslateTransform(0, 0, MatrixOrder.Append)
            Case Align.TopRight
                allGraphics.TranslateTransform(canvasMillimeterWidth, 0, MatrixOrder.Append)
        End Select
        '座標軸描画
        'Matrixクラスついては右記URL参照　https://msdn.microsoft.com/ja-jp/library/system.drawing.drawing2d.matrix(v=vs.110).aspx
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBoxDispRatio.Text <> Nothing Then
            DrawRatio = CType(TextBoxDispRatio.Text, Double)
        Else
            DrawRatio = 1.0
        End If
        Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim allGraphics As Graphics = Graphics.FromImage(canvas)

        DrawAxis(allGraphics, canvas, CtrlOriginAlignCombobox.GetSelectedValueInt)

        allGraphics.Dispose()

        PictureBox1.Image = canvas

    End Sub

    Private Sub FormTestDraw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '部品原点位置コンボボックス
        CtrlOriginAlignCombobox = New CustomComboboxShapeOriginImpl(ComboBoxOriginAlign)
        CtrlOriginAlignCombobox.SetComboboxDataSource()

    End Sub
End Class