Public Class DefineOrderDb
    Inherits DefineDbSetting
    Implements ICloneable

    'データベース名定義
    '使用するデータベース名をここで定義する
    'オーダー管理DBファイル名定義
    Public Property DbName As String = "Order" & DbExtention

    'テーブル名定義
    'データベース内にあるテーブル名の定義
    Public Property TableOrder As String = "オーダー管理"
    Public Property TableBu As String = "BU管理"
    Public Property TableSerial As String = "シリアル管理"
    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function
    '''' <summary>
    '''' マスターDBのパスを設定する。
    '''' </summary>
    '''' <param name="sysDataPath">
    '''' 本システムのSystemDataトップフォルダ
    '''' </param>
    'Public Sub SetDbPath(ByRef sysDataPath As String)
    '    DbPath = sysDataPath & "\DB"
    'End Sub
    'Public Function GetDbPath() As String
    '    Return DbPath
    'End Function


End Class
