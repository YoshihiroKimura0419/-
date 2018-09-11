''' <summary>
''' 手挿入なびで使用する構造体定義モジュール
''' </summary>
Public Module ModuleDefineStructure
    ''' <summary>
    ''' ログインユーザー情報
    ''' </summary>
    Public Structure LoginUserInfo
        'マンナンバー
        Public ManNumber As String
        'ユーザー名
        Public UserName As String
        '技術レベル
        Public TechnicLevel As Integer
        '技術レベル名称
        Public TechnicLevelName As String
        'フォームアクセス管理構造体定義
        Public EnableAccessForm As AccessForm
    End Structure
    ''' <summary>
    ''' フォームへのアクセス権
    ''' </summary>
    Public Structure AccessForm
        Public EnableFormNavi As Boolean
        Public EnableFormMentenanceMenu As Boolean
        Public EnableFormSystemSetting As Boolean
        Public EnableFormOrderMente As Boolean
    End Structure

    ''' <summary>
    ''' 描画原点位置管理構造体
    ''' </summary>
    ''' <remarks></remarks>
    Structure DrawOrigin
        '描画原点位置X
        Public X As Double
        '描画原点位置Y
        Public Y As Double
    End Structure
    ''' <summary>
    ''' 描画位置
    ''' </summary>
    Structure DrawPosition
        '原点からの描画位置X座標
        Public X As Double
        '原点からの描画位置Y座標
        Public Y As Double
    End Structure
    ''' <summary>
    ''' Dboule型のサイズ
    ''' </summary>
    Structure DoubleSize
        '描画キャンバスの幅
        Public Width As Double
        '描画キャンバスの高さ
        Public Height As Double
    End Structure
    ''' <summary>
    ''' 図面情報添付ファイル名格納
    ''' </summary>
    Structure AttachedFile
        Public BoardImage As String
        Public Shogenhyou As String
        Public Netlist As String
        Public DrawingImage As String
    End Structure

    ''' <summary>
    ''' 諸元表情報格納
    ''' </summary>
    Public Structure ShogenhyoInfomation
        '基板型名
        Public Model As String
        '標摘番号
        Public HyotekiNumber As String
        '標摘副番
        Public HyotekiRevision As String
        '標摘データ出力日
        Public OutputDate As DateTime

    End Structure
    ''' <summary>
    ''' システムデータフォルダ情報格納用
    ''' </summary>
    Public Structure SystemDataPath
        'SystemDataPath(ルート)
        Public Root As String
        'DbPath
        Public Db As String
        '図面データ
        Public Drawing As String

        'PartsDataPath構造体定義
        Public Parts As PartsDataPath

        'カンコツファイル
        Public Kankotsu As String

        '作業ログ
        Public WorkLog As String
    End Structure
    ''' <summary>
    ''' 部材データフォルダ情報格納用
    ''' </summary>
    Public Structure PartsDataPath
        'PartsDataPath(ルート)
        Public Root As String
        'Imageデータ
        Public ImageFolderName As String
    End Structure

    ''' <summary>
    ''' 製作情報構造体
    ''' </summary>
    Public Structure ProductionInfomation
        '製作オーダー
        Public Order As String
        '製作基板名称
        Public BoardName As String
        '図面ID
        Public DrawingId As Integer
        '数量リスト配列（要素数は、QuantityItemNumで定義）
        Public Quantity As List(Of Integer)
        ''製作日(yyyy/MM/ddの文字列型)
        'Public ProductionDate As String
        '製作日(yyyy/MM/dd)
        Public ProductionDate As Date

        '生産計画実績ID
        Public ProductionPlanActualId As Integer
        '作業者マンナンバー
        Public WorkerManNumber As String
        Public BuId As Integer
        Public Sub Initialize()
            Order = Nothing
            BoardName = Nothing
            DrawingId = -1

            If Quantity Is Nothing Then
                Quantity = New List(Of Integer)
            Else
                Quantity.Clear()
            End If
            For i As Integer = 0 To ([Enum].GetValues(GetType(QuantityItem))).Length - 1
                Quantity.Add(0)
            Next

            ProductionDate = Now.Date
            ProductionPlanActualId = -1
            WorkerManNumber = Nothing
            BuId = -1
        End Sub
    End Structure
    ''' <summary>
    ''' ナビデータ表示用プロジェクタの設定構造体
    ''' </summary>
    Public Structure ProjectorSetting
        'プロジェクター表示位置
        ''' <summary>
        ''' PCスクリーンでのプロジェクター表示位置
        ''' </summary>
        Public Posi As Point
        '
        ''' <summary>
        ''' PCスクリーンでのフォームサイズ（２画面分）
        ''' </summary>
        Public FormSize As Size
        ''' <summary>
        ''' 表示倍率
        ''' </summary>
        Public DispRatio As Double
        ''' <summary>
        ''' 最大ナビ枚数
        ''' </summary>
        Public MaxBoroadNum As Integer
        ''' <summary>
        ''' 基板横サイズ(mmm)
        ''' </summary>
        Public BoardWidth As Double
        ''' <summary>
        ''' 基板縦サイズ(mm)
        ''' </summary>
        Public BoardHeight As Double
        ''' <summary>
        ''' プロジェクター投影画像サイズ横(mm)
        ''' </summary>
        Public ProjectionWidth As Double
        ''' <summary>
        ''' プロジェクター投影画像サイズ縦(mm)
        ''' </summary>
        Public ProjectionHeight As Double

    End Structure
    ''' <summary>
    ''' セルのインデックス構造体
    ''' </summary>
    Public Structure CellIndex
        Dim row As Integer
        Dim col As Integer
    End Structure
End Module
