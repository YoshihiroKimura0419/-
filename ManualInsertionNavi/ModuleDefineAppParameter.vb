''' <summary>
''' 手挿入なびのアプリケーション共通変数定義モジュール
''' 
''' </summary>
Public Module ModuleDefineAppParameter

    'システム設定データ（固定値）
    ''設定ファイル名
    Public Const NaviToolSettingCsvFileName As String = "Setting.csv"
    '設定ファイル認識用ヘッダー文字列
    Public Const NaviToolSettingCsvHeader As String = "基板手挿入なび設定ファイル"

    '菱テクカレンダー格納テーブル
    Public CalanderTable As New DataTable
    Public PartsInsertNaviAppConfigData As ApplicationConfigData = New ApplicationConfigData(NaviToolSettingCsvFileName, NaviToolSettingCsvHeader)

    'ログインユーザー情報構造体定義
    Public SysLoginUserInfo As LoginUserInfo = New LoginUserInfo

    'ＤＢ定義
    Public DefMasterDb As DefineMasterDb = New DefineMasterDb
    Public DefPartsMasterDb As DefinePartsMasterDb = New DefinePartsMasterDb
    Public DefDrawingMasterDb As New DefineDrawingMasterDb
    Public DefOrderDb As DefineOrderDb = New DefineOrderDb

    'DBコントロールクラス定義
    Public ControlMasterDb As ControlDbMaster = New ControlDbMaster(DefMasterDb)
    Public ControlPartsMasterDb As ControlDbPartsMaster = New ControlDbPartsMaster(DefPartsMasterDb)
    Public ControlDrawingMasterDb As ControlDbDrawingMaster = New ControlDbDrawingMaster(DefDrawingMasterDb)
    Public ControlOrderDb As ControlDbOrder = New ControlDbOrder(DefOrderDb)

End Module
