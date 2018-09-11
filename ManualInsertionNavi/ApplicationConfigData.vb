Imports System
Imports System.IO
''' <summary>
''' 本クラスは、アプリケーションの設定データを管理・制御するクラス
''' </summary>

Public Class ApplicationConfigData
    Implements ICloneable

    'アプリケーション実行パス
    Public Property ApplicationExcecutePath As String
    'セッティングファイル名
    Public Property SettingCsvFileName As String

    'SystemDataPath構造体定義
    Public SystemDataPath As SystemDataPath

    '設定ファイル認識ヘッダー文字列（）
    Public Property SettingCsvHeader As String

    'Timesカレンダーの利用フラグ
    Public Property IsUseTimesCalender As Boolean

    'テストモードで動作させるフラグ
    Public Property IsTestModeOn As Boolean

    'プロジェクタ表示幅(mm)
    Public Property ProjectorWidth As Double
    'プロジェクタ表示縦(mm)
    Public Property ProjectorHeight As Double

    ''' <summary>
    ''' コンストラクタ
    ''' 各パラメータ初期化実施
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ApplicationExcecutePath = Nothing
        SettingCsvFileName = Nothing
        SettingCsvHeader = Nothing
        SystemDataPath = Nothing
        IsUseTimesCalender = False
        IsTestModeOn = False
        ProjectorWidth = 0
        ProjectorHeight = 0
    End Sub
    ''' <summary>
    ''' コンストラクタ
    ''' 設定ファイル名と設定ファイルヘッダー情報を使用し、各プロパティの初期化を実施。
    ''' </summary>
    ''' <param name="settingFilename">
    ''' 設定ファイル名
    ''' </param>
    ''' <param name="settingHeader">
    ''' 設定ファイルヘッダー情報文字列
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal settingFilename As String, ByVal settingHeader As String)
        ApplicationExcecutePath = Nothing
        SettingCsvFileName = settingFilename
        SettingCsvHeader = settingHeader
        SystemDataPath = Nothing
        IsUseTimesCalender = False
        IsTestModeOn = False
    End Sub
    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function
    ''' <summary>
    ''' SystemDataPathの各フォルダを設定する。
    ''' </summary>
    ''' <param name="systemRootPath">
    ''' SystemDataのルートパス
    ''' </param>
    Public Sub SetSystemDataPath(ByVal systemRootPath As String)
        SystemDataPath.Root = systemRootPath
        SystemDataPath.Db = SystemDataPath.Root & "\Db"
        SystemDataPath.Drawing = SystemDataPath.Root & "\Drawing"
        SystemDataPath.Kankotsu = SystemDataPath.Root & "\Kankotsu"
        SystemDataPath.WorkLog = SystemDataPath.Root & "\WorkLog"
        SystemDataPath.Parts.Root = SystemDataPath.Root & "\Parts"
        SystemDataPath.Parts.ImageFolderName = "Image"

    End Sub
    ''' <summary>
    ''' システム用データフォルダの存在確認
    ''' </summary>
    ''' <returns>
    ''' True:データフォルダが全て存在する　False:データフォルダの一部か全部が存在しない
    ''' </returns>
    Public Function IsExistSystemDataPath(ByRef errMessage As String) As Boolean
        Dim isExist As Boolean = True
        Dim isAddedMess As Boolean = False
        Dim errMess As New Text.StringBuilder

        errMessage = ""

        'SystemDataPath.Rootの存在確認
        If Directory.Exists(SystemDataPath.Root) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【SystemData】：システムフォルダ")
            errMess.AppendLine(SystemDataPath.Root)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If

        'SystemDataPath.Dbの存在確認
        If Directory.Exists(SystemDataPath.Db) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【DB】：データベースフォルダ")
            errMess.AppendLine(SystemDataPath.Db)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If

        'SystemDataPath.Drawingの存在確認
        If Directory.Exists(SystemDataPath.Drawing) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【Drawing】：図面情報フォルダ")
            errMess.AppendLine(SystemDataPath.Drawing)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If

        'SystemDataPath.Kankotsuの存在確認
        If Directory.Exists(SystemDataPath.Kankotsu) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【Kankotsu】：カンコツ情報フォルダ")
            errMess.AppendLine(SystemDataPath.Kankotsu)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If

        'SystemDataPath.WorkLogの存在確認
        If Directory.Exists(SystemDataPath.WorkLog) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【WorkLog】：作業ログフォルダ")
            errMess.AppendLine(SystemDataPath.WorkLog)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If

        'SystemDataPath.Parts.Rootの存在確認
        If Directory.Exists(SystemDataPath.Parts.Root) = False Then
            If isAddedMess = False Then
                errMess.Append(GetNoSystemFolderMessage())
                isAddedMess = True
            End If
            errMess.AppendLine("【Parts】：部品情報フォルダ")
            errMess.AppendLine(SystemDataPath.Parts.Root)
            errMess.AppendLine(vbCrLf)
            isExist = False
        End If
        If isExist = False Then
            errMessage = errMess.ToString
        End If
        Return isExist
    End Function

    ''' <summary>
    ''' システムフォルダが存在しないメッセージのヘッダー部分の文字列を取得する
    ''' </summary>
    ''' <returns>
    ''' ヘッダー部分の文字列
    ''' </returns>
    Private Function GetNoSystemFolderMessage() As String
        Dim errMess As New Text.StringBuilder
        errMess.AppendLine("以下のシステムフォルダが存在しません。")
        Return errMess.ToString
    End Function
    ''' <summary>
    ''' SystemDataPathにDataFolderを作成する。
    ''' </summary>
    ''' <param name="errMessage">
    ''' DataFolder作成時に発生したエラーメッセージ格納文字列
    ''' </param>
    ''' <returns>
    ''' True:DataFolder作成成功　False：True:DataFolder作成失敗
    ''' </returns>
    Public Function MakeSystemDataFolder(ByRef errMessage As String) As Boolean

        Dim hasMadeRoot As Boolean = False
        Dim isAddedMess As Boolean = False
        Dim errMess As String = ""
        Dim sbAllErrMess As New Text.StringBuilder

        If MakeFolder(SystemDataPath.Root, errMess) = False Then
            sbAllErrMess.AppendLine(errMess)
            hasMadeRoot = False
            isAddedMess = True
        Else
            hasMadeRoot = True
        End If

        If hasMadeRoot = True Then
            errMess = ""
            If MakeFolder(SystemDataPath.Db, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

            errMess = ""
            If MakeFolder(SystemDataPath.Db, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

            errMess = ""
            If MakeFolder(SystemDataPath.Drawing, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

            errMess = ""
            If MakeFolder(SystemDataPath.Kankotsu, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

            errMess = ""
            If MakeFolder(SystemDataPath.WorkLog, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

            errMess = ""
            If MakeFolder(SystemDataPath.Parts.Root, errMess) = False Then
                sbAllErrMess.AppendLine(errMess)
                isAddedMess = True
            End If

        End If
        If isAddedMess = False Then
            errMessage = errMess.ToString
        End If

        Return True
    End Function
End Class

