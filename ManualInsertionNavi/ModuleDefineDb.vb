''' <summary>
''' 手挿入ナビで使用するDB関連列挙体及び列名称定義モジュール
''' </summary>
Public Module ModuleDefineDb
    Public Enum ElementType
        '列名
        ColumnName = 0
        'データ型
        DataType = 1
    End Enum
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 部材マスタテーブル列識別番号定義
    ''' PMT=PartsMasterTableの略
    ''' </summary>
    Public Enum PMTColumn
        'ID
        ID
        '部材コード
        PartsCode
        'データ有効
        DataEnable
        '品名
        PartsName
        '型名
        ModelName
        '部品形状ID
        PartsShapeId
        '部材画像
        IsRegistedPartsImage
        'カンコツファイル
        IsRegistedKankotsu
        '備考
        Note
        '変更履歴
        ChangeHistory
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' 部材マスタテーブルの列名文字配列定義
    ''' </summary>
    Public PMTColumnName As String() = {
        "ID",
        "部材コード",
        "データ有効",
        "品名",
        "型名",
        "部品形状ID",
        "部材画像",
        "カンコツファイル",
        "備考",
        "変更履歴",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }


    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' アクセス権管理テーブル列識別番号定義
    ''' ART=AccessRightTableの略
    ''' </summary>
    Public Enum ARTColumn
        'マンナンバー
        ManNumber
        'なび画面
        WindowNavi
        'マスタメンテナンス
        WindowMasterMente
        'システム設定
        WindowSystemSetting
        'オーダー管理
        WindowOrderMente
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' アクセス権管理テーブルの列名文字配列定義
    ''' </summary>
    Public ARTColumnName As String() = {
        "マンナンバー",
        "なび画面",
        "マスタメンテナンス",
        "システム設定",
        "オーダー管理",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }

    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' ユーザー管理レベルテーブル列識別番号定義
    ''' UDT=UserDataTableの略
    ''' </summary>
    Public Enum UDTColumn
        'マンナンバー
        ManNumber
        'データ有効
        DataEnable
        '氏名
        UserName
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' ユーザー管理テーブルの列名文字配列定義
    ''' </summary>
    Public UDTColumnName As String() = {
        "マンナンバー",
        "データ有効",
        "氏名",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }

    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' ユーザー技術管理レベルテーブル列識別番号定義
    ''' UTLT=UserTechnicLevelTableの略
    ''' </summary>
    Public Enum UTLTColumn
        'マンナンバー
        ManNumber
        '技術レベルマスタID
        TechnicLevelId
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' ユーザー技術レベルテーブルの列名文字配列定義
    ''' </summary>
    Public UTLTColumnName As String() = {
        "マンナンバー",
        "技術レベルマスタID",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 技術レベルマスタテーブル列識別番号定義
    ''' TLT=TechnicLevelTableの略
    ''' </summary>
    Public Enum TLTColumn
        'ID
        ID
        '技術レベル名
        TechnicLevelName
        '技術レベル階級
        TechnicLevel
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' 技術レベルマステーブルの列名文字配列定義
    ''' </summary>
    Public TLTColumnName As String() = {
        "ID",
        "技術レベル名",
        "技術レベル階級",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }

    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 部品形状管理テーブル列識別番号定義
    ''' PST=PartShapeTableの略
    ''' </summary>
    Public Enum PSTColumn
        'ID
        ID
        'データ有効
        DataEnable
        '部品形状名
        PartsShapeName
        '部品形状分類ID
        PartsShapeTypeId
        '縦サイズ
        PartsHeight
        '横サイズ
        PartsWidth
        '部品形状No
        PartsShapeId
        '識別符号有無
        UseMarker
        '識別符号位置
        MarkerPosi
        '原点位置
        OriginPosi
        '変更履歴
        ChangeHistory
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
        'データ整備完了
        DataCommit
    End Enum
    ''' <summary>
    ''' 部品形状管理テーブルの列名文字配列定義
    ''' </summary>
    Public PSTColumnName As String() = {
        "ID",
        "データ有効",
        "部品形状名",
        "部品形状分類ID",
        "縦サイズ",
        "横サイズ",
        "部品形状No",
        "識別符号有無",
        "識別符号位置",
        "原点位置",
        "変更履歴",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー",
        "データ整備"
    }

    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 部品形状分類テーブル列識別番号定義
    ''' PSCT=PartShapeCategoryTableの略
    ''' </summary>
    Public Enum PSCTColumn
        'ID
        ID
        'データ有効
        DataEnable
        '部品形状分類名称
        PartsShapeCategoryName
        '備考
        Note
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
    End Enum
    ''' <summary>
    ''' 部品形状分類テーブルの列名文字配列定義
    ''' </summary>
    Public PSCTColumnName As String() = {
        "ID",
        "データ有効",
        "部品形状分類名称",
        "備考",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
    }
    '----------------------------------------------------------------------------------
    '図面情報テーブル（DrawingInfoTable=DIT）
    ''' <summary>
    ''' 図面情報テーブルの列インデックス定義
    ''' DIT=DrawingInfoTableの略
    ''' </summary>
    Public Enum DITColmun As Integer
        'ID
        Id
        'データ有効
        DataEnable
        '図面番号
        DrawingNumber
        '図面副番
        DrawingRevision
        '基板名称
        BoardName
        '基板横サイズ
        BoardWidth
        '基板縦サイズ
        BoardHeight
        '図面画像登録
        RegistImageDrawing
        '基板画像登録
        RegistImageBoard
        '諸元表登録
        RegistShogenhyo
        'NETリスト登録
        RegistNetlist
        '備考
        Note
        '変更履歴
        ChangeHistory
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber
        '最大同時制作数
        MaxLot
    End Enum

    ''' <summary>
    ''' 図面情報テーブルの列名文字配列定義
    ''' </summary>
    Public DITColumnName As String() = {
        "ID",
        "データ有効",
        "図面番号",
        "副番",
        "基板名称",
        "基板横サイズ",
        "基板縦サイズ",
        "図面画像登録",
        "基板画像登録",
        "諸元表登録",
        "NETリスト登録",
        "備考",
        "変更履歴",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー",
        "最大同時制作数"
        }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' NETリストテーブルの列インデックス定義
    ''' NLT=NetListTableの略
    ''' </summary>
    Public Enum NLTColmun
        '諸元
        Shogen
        '予備1
        Spare1
        '部品形状名
        ShapeName
        '予備2
        Spare2
        'X座標
        X
        'Y座標
        Y
        '回転角度
        Rotate
    End Enum
    ''' <summary>
    ''' NETリストテーブルの列名文字列定義
    ''' </summary>
    Public NLTColumnName As String() = {
        "諸元",
        "予備1",
        "部品形状名",
        "予備2",
        "X座標",
        "Y座標",
        "回転角度"
        }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 諸元表データテーブル列識別番号定義
    ''' SDT=ShogenhyouDataTableの略
    ''' </summary>
    Public Enum SDTColumn
        '行番号
        RowNumber
        '部品名称
        PartsName
        '部品型式
        PartsModelName
        '部材コード
        PartsCode
        '諸元
        Shogen
        '使用数量
        UseCount
    End Enum

    Public SDTColumnName As String() = {
        "行番号",
        "部品名称",
        "部品型名",
        "部材コード",
        "諸元",
        "使用数量"
    }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' ナビゲーションデータテーブルの列インデックス定義
    ''' NVDT=NaVigationDataTableの略
    ''' </summary>
    Public Enum NVDTColumn
        'ID
        Id
        'データ有効
        DataEnable
        'ナビ不要
        NoNavi
        'ナビデータ副番
        DataRev
        'ステップ
        NaviStep
        '部材コード
        PartsCode
        '諸元
        Shogen
        '使用数量
        UseCount
        'X座標
        X
        'Y座標
        Y
        '回転角度
        Rotate
        '必要技術レベル
        RequestTechnicLevel
        'キッティング要
        NeedKitting
        '備考
        Note
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber

    End Enum
    Public NVDTColumnInfo As String(,) = {
        {"ID", "System.Int32"},
        {"データ有効", "System.Boolean"},
        {"ナビ不要", "System.Boolean"},
        {"ナビデータ副番", "System.String"},
        {"ステップ", "System.Int32"},
        {"部材コード", "System.String"},
        {"諸元", "System.String"},
        {"使用数量", "System.Int32"},
        {"X座標", "System.Double"},
        {"Y座標", "System.Double"},
        {"回転角度", "System.Double"},
        {"必要技術レベル", "System.Int32"},
        {"キッティング要", "System.Boolean"},
        {"備考", "System.String"},
        {"登録日", "System.DateTime"},
        {"登録者マンナンバー", "System.String"},
        {"更新日", "System.DateTime"},
        {"更新者マンナンバー", "System.String"}
     }

    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 部材コードから抽出した描画用部品形状関連データテーブル列識別番号定義
    ''' DPSDT=DrawPartShapeDataTableの略
    ''' </summary>
    Public Enum DPSDTColumn
        '部材コード
        PartsCode
        'データ有効
        DataEnable
        '部品形状名
        PartsShapeName
        '縦サイズ
        PartsHeight
        '横サイズ
        PartsWidth
        '部品形状No
        PartsShapeId
        '識別符号有無
        UseMarker
        '識別符号位置
        MarkerPosi
        '原点位置
        OriginPosi
    End Enum
    ''' <summary>
    ''' 部材コードから抽出した部品形状関連テーブルの列名文字配列定義
    ''' </summary>
    Public DPSDTColumnName As String() = {
        "部材コード",
        "データ有効",
        "部品形状名",
        "縦サイズ",
        "横サイズ",
        "部品形状No",
        "識別符号有無",
        "識別符号位置",
        "原点位置"
    }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' 生産計画実績テーブル列識別番号定義
    ''' PPAT=ProductionPlanActualTableの略
    ''' </summary>
    Public Enum PPATColumn
        'ID
        ID
        'オーダー
        Order
        '基板名称
        BoardName
        '図面ID
        DrawingId
        '製作日
        ProductDate
        '製作計画数
        ProductionPlan
        '製作実績数
        ProductionActural
        '作業者マンナンバー
        WorkerManNumber
        'BU管理ID
        BuId
    End Enum
    ''' <summary>
    ''' 生産計画実績テーブルの列名文字配列定義
    ''' </summary>
    Public PPATColumnName As String() = {
        "ID",
        "オーダー",
        "基板名称",
        "図面ID",
        "生産日",
        "生産計画数",
        "生産実績数",
        "作業者マンナンバー",
        "BU管理ID"
    }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' オーダー管理テーブル列識別番号定義
    ''' OMT=OrderManegementTableの略
    ''' </summary>
    Public Enum OMTColumn
        'オーダー
        Order
        'データ有効
        DataEnable
        '基板名称
        BoardName
        'BU管理ID
        BuId
        '生産枚数
        ProductionCount
        '変更履歴
        ChangeHistory
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber

    End Enum
    ''' <summary>
    ''' オーダー管理テーブルの列名文字配列定義
    ''' </summary>
    Public OMTColumnName As String() = {
        "オーダー",
        "データ有効",
        "基板名称",
        "BU管理ID",
        "生産枚数",
        "変更履歴",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
        }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' BU管理テーブル列識別番号定義
    ''' BUMT=BUManegementTableの略
    ''' </summary>
    Public Enum BUMTColumn
        'ID
        ID
        'データ有効
        DataEnable
        'BU名
        BuName
        '変更履歴
        ChangeHistory
        '登録日
        RegistDate
        '登録者マンナンバー
        RegistManNumber
        '更新日
        UpdateDate
        '更新者マンナンバー
        UpdateManNumber

    End Enum
    ''' <summary>
    ''' BU管理テーブルの列名文字配列定義
    ''' </summary>
    Public BUMTColumnName As String() = {
        "ID",
        "データ有効",
        "BU名",
        "変更履歴",
        "登録日",
        "登録者マンナンバー",
        "更新日",
        "更新者マンナンバー"
        }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' シリアル管理テーブル列識別番号定義
    ''' SNMT=SerialNumberManegementTableの略
    ''' </summary>
    Public Enum SNMTColumn
        'オーダー
        Order
        '最終シリアルNo
        LastSerialNo

    End Enum
    ''' <summary>
    ''' シリアル管理テーブルの列名文字配列定義
    ''' </summary>
    Public SNMTColumnName As String() = {
        "オーダー",
        "最終シリアルNo"
        }
    '----------------------------------------------------------------------------------
    ''' <summary>
    ''' オーダー管理テーブル列識別番号定義
    ''' WLT=WorkLogTableの略
    ''' </summary>
    Public Enum WLTColumn
        'ID
        Id
        '生産計画実績ID
        ProductionAcutualId
        'オーダー
        Order
        '基板名称
        BoardName
        '図面ID
        DrawingId
        'シリアルNo
        SerialNo
        '加工開始日時
        StartDate
        '加工終了日時
        EndDate
        '製作ロット
        ProductionLot
        'ロット番号
        LotNumber
        'ナビID
        NaviId
        '部材コード
        PartsCode
        '諸元
        Shogen
        '作業者マンナンバー
        WorkerManNumber
        '作業時間
        WorkTime

    End Enum
    ''' <summary>
    ''' 作業ログテーブルの列名文字配列定義
    ''' </summary>
    Public WLTColumnName As String() = {
        "ID",
        "生産計画実績ID",
        "オーダー",
        "基板名称",
        "図面ID",
        "シリアルNo",
        "加工開始日時",
        "加工終了日時",
        "製作ロット",
        "ロット番号",
        "ナビID",
        "部材コード",
        "諸元",
        "作業者マンナンバー",
        "作業時間"
        }

End Module
