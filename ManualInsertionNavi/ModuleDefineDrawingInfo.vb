''' <summary>
''' 手挿入なびで使用する図面関連の定義モジュール
''' </summary>
Public Module ModuleDefineDrawingInfo
    'インチをミリに変換する際の係数
    Public Const ConvetInchiToMillimeter As Double = 25.4

    Public AlignTextItemNum As Integer = 9
    '配置テキスト定義（データの並びは、Enum Alignに合わせる事）
    Public AlignText() As String = {"上-左", "上-中", "上-右", "中-左", "中-中", "中-右", "下-左", "下-中", "下-右"}

    ''' <summary>
    ''' 図面フォルダ以下のサブフォルダ名文字配列識別用列挙
    ''' </summary>
    Public Enum DrawingSubFolder As Integer
        BoardImage = 0
        Shogenhyou = 1
        NetList = 2
        NaviData = 3
        DrawingImage = 4
    End Enum
    ''' <summary>
    ''' 図面フォルダのサブフォルダ名文字配列
    ''' Enum DrawingSubFolderを使ってサブフォルダの名称を取得する。
    ''' </summary>
    Public DrawingSubFolderName As String() = {"BoardImage", "Shogenhyou", "NetList", "NaviData", "DrawingImage"}
    Public DrawingSubFolderNameJapanese As String() = {"図面画像", "諸元表", "NETリスト", "なびデータ", "図面画像"}
    ''' <summary>
    ''' 副番無し時につけるフォルダ名
    ''' </summary>
    Public Const NoRevisionFolderName As String = "-"

End Module
