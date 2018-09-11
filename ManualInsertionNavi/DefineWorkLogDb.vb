''' <summary>
''' 作業中および作業ログデータベースにアクセスするためのDB初期設定クラス
''' 
''' </summary>
Public Class DefineWorkLogDb
    Inherits DefineDbSetting
    Implements ICloneable

    ''' <summary>
    ''' 作業データ保存フォルダ名
    ''' 本フォルダは、systemDataフォルダの直下に配置されているものとする。
    ''' </summary>
    Public ReadOnly Property WorkLogFolderName As String = "WorkLog"

    ''' <summary>
    ''' 作業ログひな形ファイル名
    ''' </summary>
    Public ReadOnly Property DbTemplateName As String = "WorkLog_yyyyMM" & DbExtention
    ''' <summary>
    ''' 作業中（仕掛データ）管理DBファイル名
    ''' </summary>
    Public ReadOnly Property DbWorkingDbName As String = "WorkingData" & DbExtention

    ''' <summary>
    ''' 作業ログファイルヘッダー文字列。この後にyyyyMM(年月)を付与したファイルを該当月のログファイルとする。
    ''' </summary>
    Public ReadOnly Property DbWorkLogFilenameHeader As String = "WorkLog_"

    ''' <summary>
    ''' 作業ログテーブル名
    ''' </summary>
    Public ReadOnly Property TableWorkLog As String = "作業ログ"

    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function


End Class
