''' <summary>
''' 手挿入ナビで使用する共通列挙体定義モジュール
''' </summary>
Public Module ModuleDefineCommnEnum
    ''' <summary>
    ''' 諸元表のファイル形式識別用
    ''' 
    ''' </summary>
    Public Enum ShogenhyoFileType
        '力電用？
        Type1
        '長電用？(NAPSから出力されるデータはこの形式みたい)
        Type2
        '不明
        Unknown = -1
    End Enum
    ''' <summary>
    ''' 諸元表のデータ行の列数識別用
    ''' </summary>
    Public Enum ShogenhyoDataColumnNum
        '力電用？
        Type1 = 11
        '長電用？(NAPSから出力されるデータはこの形式みたい)
        Type2 = 26
        '不明
        Unknown = -1

    End Enum
    ''' <summary>
    ''' 図面情報編集モード識別用
    ''' </summary>
    Public Enum DrawingInfoEditMode
        '新規作成
        CreateNewData
        '内容編集(図面副番変更を除く)
        ContentsEdit
        '図面副番変更
        DrawingRevisionUpdate
        '図面閲覧
        Browsing
    End Enum
    ''' <summary>
    ''' 図形配置定義
    ''' </summary>
    Public Enum Align As Integer
        TopLeft = 0
        TopCenter = 1
        TopRight = 2
        MiddleLeft = 3
        MiddleCenter = 4
        MiddleRight = 5
        BottomLeft = 6
        BottomCenter = 7
        BottomRight = 8
    End Enum
    '形状列挙
    Enum Shape As Integer
        Retacgle = 0
        Circle = 1
    End Enum
    '描画する部材形状の状況
    Public Enum DrawParsStatus
        '選択されている部材(モニタ表示用)
        MonitorSelectedParts = 0
        '選択されている部材と同一のパーツコード部材(モニタ表示用)
        MonitorSamePartsCode = 1
        '選択されている部材(プロジェクタ表示用)
        ProjectorSelectedParts = 2
        '選択されている部材と同一のパーツコード部材(プロジェクタ表示用)
        ProjectorSamePartsCode = 3
    End Enum
    ''' <summary>
    ''' なびフォームオープン時のモード管理用列挙体
    ''' </summary>
    Public Enum FormNaviMode
        '不定
        Unknown = -1
        'なびデータ編集モード
        Edit
        'なびモード
        Navi
    End Enum
    ''' <summary>
    ''' 図面マスタメンテナンス画面オープンモード管理用
    ''' </summary>
    Public Enum FormMenteDrawingMasterOpenMode
        Edit
        DataSelect
    End Enum
    ''' <summary>
    ''' 図面マスタメンテナンス画面オープンモード管理用
    ''' </summary>
    Public Enum FormMentePartsMasterOpenMode
        Edit
        DataSelect
    End Enum
End Module
