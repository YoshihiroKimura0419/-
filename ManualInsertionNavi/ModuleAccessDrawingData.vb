Public Module ModuleAccessDrawingData
    'サムネイル情報ファイル名(エクスプローラーが自動的に作成するファイル)
    Public Const ThumbsFileName As String = "Thumbs.db"

    ''' <summary>
    ''' 図面に添付されたファイルの名称を取得する。
    ''' ※指定フォルダ以下には、１つしかファイルが存在しないものとする。
    ''' </summary>
    ''' <param name="systemDataPathDrawing">
    ''' システムの図面フォルダパス
    ''' </param>
    ''' <param name="drawingNumber">
    ''' ファイル名を取得したい図面番号
    ''' </param>
    ''' <param name="drawingRevision">
    ''' ファイル名を取得したい図面の副番
    ''' </param>
    ''' <param name="subfolderIndex">
    ''' ファイル名を取得したいサブフォルダのインデクス番号
    ''' DrawingSubFolder列挙体で指定
    ''' </param>
    ''' <returns>
    ''' 取得したファイル名。ファイルが無い場合は、Nothingを返す。
    ''' </returns>
    Public Function GetDrawingAttachedFileName(ByVal systemDataPathDrawing As String, ByVal drawingNumber As String, ByVal drawingRevision As String, ByVal subfolderIndex As Integer) As String
        Dim filename As String = Nothing
        Dim subFolderName As String = Nothing
        Dim result As Boolean = True
        Dim fileExtention As String = "*"
        Dim searchPath As String = Nothing

        Select Case subfolderIndex
            Case DrawingSubFolder.DrawingImage, DrawingSubFolder.BoardImage, DrawingSubFolder.Shogenhyou, DrawingSubFolder.NetList, DrawingSubFolder.NaviData
                subFolderName = DrawingSubFolderName(subfolderIndex)
            Case Else
                Return ""
        End Select
        searchPath = String.Format("{0}\{1}\{2}\{3}", systemDataPathDrawing, drawingNumber, drawingRevision, subFolderName)

        filename = GetOnlyOneFileName(searchPath, fileExtention)

        Return filename
    End Function
    ''' <summary>
    ''' 図面に添付されたファイルのフルパスを取得する。
    ''' ※指定フォルダ以下には、１つしかファイルが存在しないものとする。
    ''' </summary>
    ''' <param name="systemDataPathDrawing">
    ''' システムの図面フォルダパス
    ''' </param>
    ''' <param name="drawingNumber">
    ''' ファイル名を取得したい図面番号
    ''' </param>
    ''' <param name="drawingRevision">
    ''' ファイル名を取得したい図面の副番
    ''' </param>
    ''' <param name="subfolderIndex">
    ''' ファイル名を取得したいサブフォルダのインデクス番号
    ''' DrawingSubFolder列挙体で指定
    ''' </param>
    ''' <returns>
    ''' 取得したファイル名。ファイルが無い場合は、Nothingを返す。
    ''' </returns>
    Public Function GetDrawingAttachedFileFullPath(ByVal systemDataPathDrawing As String, ByVal drawingNumber As String, ByVal drawingRevision As String, ByVal subfolderIndex As Integer) As String
        Dim filename As String = Nothing
        Dim searchPath As String = Nothing

        searchPath = String.Format("{0}\{1}\{2}\{3}", systemDataPathDrawing, drawingNumber, drawingRevision, DrawingSubFolderName(subfolderIndex))

        filename = GetDrawingAttachedFileName(systemDataPathDrawing, drawingNumber, drawingRevision, subfolderIndex)
        If filename <> "" Then
            filename = searchPath & "\" & filename
        End If

        Return filename
    End Function

End Module
