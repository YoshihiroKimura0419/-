Public Module ModuleImageControl
    ''' <summary>
    ''' filePathの画像をpicboxに表示する。
    ''' ※本メソッドは、Image.FromFileを使用した場合ファイルがロックされる不具合を解消したもの
    ''' </summary>
    ''' <param name="picbox">
    ''' 画像を表示するPicturBox
    ''' </param>
    ''' <param name="filePath">
    ''' 表示したい画像ファイルのパス
    ''' </param>
    Public Sub SetImageToPictureBox(ByRef picbox As PictureBox, ByVal filePath As String)
        If filePath = "" Then
            Exit Sub
        End If

        If IO.File.Exists(filePath) = True Then

            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)
            '画像を表示する
            picbox.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()

        Else
            picbox.Image = Nothing
        End If

    End Sub
    Public Sub SetImageToPictureBoxBottmLeft(ByRef picbox As PictureBox, ByVal filePath As String, ByVal drawRatio As Double)
        If filePath = "" Then
            Exit Sub
        End If

        If IO.File.Exists(filePath) = True Then
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim img As Image = System.Drawing.Image.FromStream(fs)
            Dim canvas As New Bitmap(picbox.Width, picbox.Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.ScaleTransform(drawRatio, drawRatio, MatrixOrder.Append)
            Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
            g.MultiplyTransform(myMatrix)

            g.TranslateTransform(0, picbox.Height - 1, MatrixOrder.Append)
            '画像が反転してしまうので、位置及び高さの調整
            g.DrawImage(img, New Rectangle(0, img.Height, img.Width, -img.Height))

            img.Dispose()
            g.Dispose()
            picbox.Image = canvas
            fs.Close()

        Else
            picbox.Image = Nothing
        End If

    End Sub
    ''' <summary>
    ''' filePathの画像のサイズを取得する。
    ''' ※本メソッドは、Image.FromFileを使用した場合ファイルがロックされる不具合を解消したもの
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Function GetImageSize(ByVal filePath As String) As Size
        Dim imageSize As New Size
        Dim fs As System.IO.FileStream
        '有効なファイルパスを指定すること
        fs = New System.IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)
        imageSize.Width = System.Drawing.Image.FromStream(fs).Width
        imageSize.Height = System.Drawing.Image.FromStream(fs).Height
        fs.Close()
        Return imageSize
    End Function
    ''' <summary>
    ''' filePathで指定した画像をPictureBoxに表示した場合の表示倍率を取得する
    ''' 表示倍率取得の際、縦基準か横基準かをwidthBaseDrawに設定する。
    ''' </summary>
    ''' <param name="filePath">
    ''' 表示画像のファイルパス
    ''' </param>
    ''' <param name="pictureBoxSize">
    ''' 画像を表示するPictureBoxコントロール
    ''' </param>
    ''' <param name="widthBaseDraw">
    ''' 表示倍率計算時の基準設定
    ''' True:横基準　False:縦基準
    ''' </param>
    ''' <returns>
    ''' 表示倍率
    ''' </returns>
    Public Function GetPictureboxDispRatio(ByVal filePath As String, ByVal pictureBoxSize As Size, ByRef widthBaseDraw As Boolean) As Double
        If System.IO.File.Exists(filePath) = False Then
            Return 0
        End If
        Dim dispRatio As Double

        Dim imageSize As New Size
        Dim imageXYRatio As Double
        Dim pictboxXYRatio As Double

        imageSize = GetImageSize(filePath)
        imageXYRatio = imageSize.Width / imageSize.Height
        pictboxXYRatio = pictureBoxSize.Width / pictureBoxSize.Height
        Dim cnvImgsize As Double
        If 1 < imageXYRatio Then
            '横長画像
            widthBaseDraw = True
            dispRatio = pictureBoxSize.Width / imageSize.Width
            cnvImgsize = imageSize.Height * dispRatio
            If pictureBoxSize.Height < cnvImgsize Then
                dispRatio *= (pictureBoxSize.Height / cnvImgsize)
                widthBaseDraw = False
            End If
        Else
            '縦長画像
            dispRatio = pictureBoxSize.Height / imageSize.Height
            widthBaseDraw = False
            cnvImgsize = imageSize.Width * dispRatio
            If pictureBoxSize.Width < cnvImgsize Then
                dispRatio *= (pictureBoxSize.Width / cnvImgsize)
                widthBaseDraw = True
            End If
        End If

        Return dispRatio
    End Function
    Public Function GetPictureboxDispRatio(ByVal imageSize As Size, ByVal pictureBoxSize As Size, ByRef widthBaseDraw As Boolean) As Double
        Dim dispratio As Double

        Dim imagexyratio As Double
        Dim pictboxxyratio As Double

        imagexyratio = imageSize.Width / imageSize.Height
        pictboxxyratio = pictureBoxSize.Width / pictureBoxSize.Height
        If pictboxxyratio <= imagexyratio Then
            '画像がピクチャーボックスより横長の場合
            dispratio = pictureBoxSize.Width / imageSize.Width
            widthBaseDraw = True
        Else
            '画像がピクチャーボックスより縦の場合
            dispratio = pictureBoxSize.Height / imageSize.Height
            widthBaseDraw = False
        End If

        Return dispratio
    End Function
    ''' <summary>
    ''' picboxに表示している画像のサイズと基板のサイズから表示倍率を取得する。
    ''' </summary>
    ''' <param name="picbox">
    ''' 基板画像を表示しているPictureBox
    ''' </param>
    ''' <param name="boardWidth">
    ''' 基板の幅
    ''' </param>
    ''' <param name="boardHeight">
    ''' 基板の縦
    ''' </param>
    ''' <param name="widthBaseDraw">
    ''' picboxに表示している画像が横基準で表示されているかどうかを表す
    ''' True:横基準　False:縦基準
    ''' </param>
    ''' <returns></returns>
    Public Function GetDrawRatio(ByVal picbox As PictureBox, ByVal boardWidth As Double, ByVal boardHeight As Double, ByVal widthBaseDraw As Boolean) As Double
        Dim dispRatio As Double

        Dim canvasMillimeterWidth As Double
        Dim canvasMillimeterHeight As Double
        Dim canvas As New Bitmap(picbox.Width, picbox.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)

        canvasMillimeterWidth = canvas.Width / g.DpiX * ConvetInchiToMillimeter
        canvasMillimeterHeight = canvas.Height / g.DpiY * ConvetInchiToMillimeter

        If widthBaseDraw = True Then
            dispRatio = canvasMillimeterWidth / boardWidth
        Else
            dispRatio = canvasMillimeterHeight / boardHeight

        End If

        Return dispRatio
    End Function

End Module
