Imports ManualInsertionNavi
Module DefineAnalysisCommn
    ''' <summary>
    ''' 分析ツール用設定ファイル名
    ''' </summary>
    Public Const AnalysisSettingFileCsv As String = "AnalisysSetting.Csv"

    ''' <summary>
    ''' 分析ツール用設定ファイル認識文字列
    ''' </summary>
    Public Const AnalysisSettingCsvHeader As String = "ナビ分析ツール設定ファイル"

    ''' <summary>
    ''' ナビ分析ツール起動フォルダ格納変数
    ''' </summary>
    Public AnalysisSystemPath As String = Nothing

    ''' <summary>
    ''' システムデータフォルダ格納
    ''' 本変数にナビシステムの各フォルダが格納される。
    ''' 本データ使用前に必ずSetSystemDataPath(ByVal systemRootPath As String)で設定すること。
    ''' </summary>
    Public SystemDataPath As ManualInsertionNavi.SystemDataPath


    Public DefDbMaster As New ManualInsertionNavi.DefineMasterDb
    Public DefDbOrder As New ManualInsertionNavi.DefineOrderDb
    Public DefDbPpa As New ManualInsertionNavi.DefineProductionPlanActualDb
    Public DefDbWlog As New ManualInsertionNavi.DefineWorkLogDb

    Public CtrlDbMaster As New ManualInsertionNavi.ControlDbMaster(DefDbMaster)
    Public CtrlDbOrder As New ManualInsertionNavi.ControlDbOrder(DefDbOrder)
    Public CtrlDbPpa As New ManualInsertionNavi.ControlDbProductionPlanActual(DefDbPpa)
    Public CtrlDbWlog As New ManualInsertionNavi.ControlDbWorkLog(DefDbWlog)

    Public TbTimesCalender As New DataTable
    Public CtrlTimesCalender As New ControlRtcCalendar
    Public EnableTimesCalender As Boolean = False

End Module
