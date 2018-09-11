Module AnalysisCommon
    ''' <summary>
    ''' 分析ツールで参照するナビシステム各フォルダを設定する。
    ''' </summary>
    ''' <param name="systemRootPath">
    ''' ナビシステムのSystemDataトップフォルダ
    ''' </param>
    Public Sub SetSystemDataPath(ByVal systemRootPath As String)
        SystemDataPath.Root = systemRootPath
        SystemDataPath.Db = SystemDataPath.Root & "\Db"
        SystemDataPath.Drawing = SystemDataPath.Root & "\Drawing"
        SystemDataPath.Kankotsu = SystemDataPath.Root & "\Kankotsu"
        SystemDataPath.WorkLog = SystemDataPath.Root & "\WorkLog"
        SystemDataPath.Parts.Root = SystemDataPath.Root & "\Parts"
        SystemDataPath.Parts.ImageFolderName = "Image"
    End Sub

End Module
