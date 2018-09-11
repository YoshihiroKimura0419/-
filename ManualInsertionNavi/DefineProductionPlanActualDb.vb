Public Class DefineProductionPlanActualDb
    Inherits DefineDbSetting
    Implements ICloneable

    'データベース名定義
    '使用するデータベース名をここで定義する
    'マスター管理DBファイル名定義
    Public Property DbName As String = "ProductionPlanActual" & DbExtention

    'テーブル名定義
    'データベース内にあるテーブル名の定義
    Public Property TablePlanActual As String = "生産計画実績"

    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function


End Class
