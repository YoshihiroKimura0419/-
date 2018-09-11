Imports System

Public Class DefineMasterDb
    Inherits DefineDbSetting
    Implements ICloneable

    'データベース名定義
    '使用するデータベース名をここで定義する
    'マスター管理DBファイル名定義
    Public Property DbName As String = "PartsInsertNaviMaster" & DbExtention

    'テーブル名定義
    'データベース内にあるテーブル名の定義
    Public Property TableUser As String = "ユーザー管理"
    Public Property TableUserAccessRight As String = "アクセス権管理"
    Public Property TableUserTechnicLevel As String = "ユーザー技術レベル管理"
    Public Property TableTechnicLevelMaster As String = "技術レベルマスタ"
    Public Property TablePartsShapeCategory As String = "部品形状分類マスタ"
    Public Property TablePartsShapeMaster As String = "部品形状管理"

    'カレンダーDB名定義
    Public Property DbCalenderName As String = "RtcCalendar"
    'カレンダーテーブル名定義
    Public Property TableCalenderName As String = "RtcCalendar"

    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

    '''' <summary>
    '''' マスターデータベースのパスを設定する。
    '''' </summary>
    '''' <remarks></remarks>
    'Public Sub SetMasterDbPath(ByRef sysDataPath As String)
    '    DbPath = sysDataPath & "\DB"
    'End Sub


End Class
