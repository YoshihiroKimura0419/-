Imports System

''' <summary>
''' 各種ファイルコントロール用モジュール
''' </summary>
Public Module ModuleControlFile

    ''' <summary>
    ''' execPathのファイルを別プロセスで開く
    ''' </summary>
    ''' <param name="execPath">
    ''' 開くファイルのフルパス</param>
    ''' <remarks></remarks>
    Public Sub ExecuteFile(ByVal execPath As String)
        Dim executeFileProc As New Process

        With executeFileProc
            .StartInfo.FileName = execPath
            .Start()
        End With

    End Sub
    ''' <summary>
    ''' 画像ファイル選択ダイアログを開き、選択した画像ファイルのフルパスを取得する
    ''' 対応画像ファイル：*.gif;*.jpg;*.jpeg;*.png
    ''' </summary>
    ''' <param name="initialFolder">
    ''' ダイアログを開く初期フォルダ名</param>
    ''' <returns>
    ''' 選択したファイルのフルパス。キャンセルした場合は、""。</returns>
    ''' <remarks></remarks>
    Public Function SelectImageFileByDialog(ByVal initialFolder As String) As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()
        Dim selFileString As String = Nothing

        '表示フォルダ設定
        If System.IO.Directory.Exists(initialFolder) = True Then
            ofd.InitialDirectory = initialFolder
        End If

        '表示ファイルフィルタ設定
        ofd.Filter = "画像ファイル(*.gif;*.jpg;*.jpeg;*.png)|*.gif;*.jpg;*.jpeg;*.png"

        'タイトルを設定する
        ofd.Title = "画像ファイルを選択してください"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            selFileString = ofd.FileName
        Else
            selFileString = ""
        End If
        If ofd IsNot Nothing Then
            ofd.Dispose()
        End If
        Return selFileString
    End Function
    ''' <summary>
    ''' CSVファイル選択ダイアログを開き、選択したCSVファイルのフルパスを取得する
    ''' 対象ファイル拡張子：CSVファイル(*.CSV)
    ''' </summary>
    ''' <param name="initialFolder"></param>
    ''' <returns></returns>
    Public Function SelectCsvFileByDialog(ByVal initialFolder As String) As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()
        Dim selFileString As String = Nothing

        '表示フォルダ設定
        If System.IO.Directory.Exists(initialFolder) = True Then
            ofd.InitialDirectory = initialFolder
        End If

        '表示ファイルフィルタ設定
        ofd.Filter = "CSVファイル(*.CSV)|*.CSV"

        'タイトルを設定する
        ofd.Title = "ファイルを選択してください"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            selFileString = ofd.FileName
        Else
            selFileString = ""
        End If
        If ofd IsNot Nothing Then
            ofd.Dispose()
        End If
        Return selFileString
    End Function

    ''' <summary>
    ''' NETリストファイル選択ダイアログを開き、選択したNetリストファイルのフルパスを取得する
    ''' 対象ファイル拡張子：NETリストファイル(*.net;*.txt)
    ''' </summary>
    ''' <param name="initialFolder"></param>
    ''' <returns></returns>
    Public Function SelectNetlistFileByDialog(ByVal initialFolder As String) As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()
        Dim selFileString As String = Nothing

        '表示フォルダ設定
        If System.IO.Directory.Exists(initialFolder) = True Then
            ofd.InitialDirectory = initialFolder
        End If

        '表示ファイルフィルタ設定
        ofd.Filter = "NETリストファイル(*.net;*.txt)|*.net;*.txt"

        'タイトルを設定する
        ofd.Title = "Netリストのファイルを選択してください"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            selFileString = ofd.FileName
        Else
            selFileString = ""
        End If
        If ofd IsNot Nothing Then
            ofd.Dispose()
        End If
        Return selFileString
    End Function
    ''' <summary>
    ''' ファイル選択ダイアログを開き、選択したNetリストファイルのフルパスを取得する
    ''' 対象ファイル拡張子：全て
    ''' </summary>
    ''' <param name="initialFolder"></param>
    ''' <returns></returns>
    Public Function SelectFileByDialog(ByVal initialFolder As String) As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()
        Dim selFileString As String = Nothing

        '表示フォルダ設定
        If System.IO.Directory.Exists(initialFolder) = True Then
            ofd.InitialDirectory = initialFolder
        End If

        '表示ファイルフィルタ設定
        ofd.Filter = "全てのファイル(*.*)|*.*"

        'タイトルを設定する
        ofd.Title = "ファイルを選択してください"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            selFileString = ofd.FileName
        Else
            selFileString = ""
        End If
        If ofd IsNot Nothing Then
            ofd.Dispose()
        End If
        Return selFileString
    End Function

    ''' <summary>
    ''' filePathで指定したファイルのフォルダとfolderが同一か確認する。
    ''' </summary>
    ''' <param name="filePath">
    ''' 確認したいファイルのフルパス</param>
    ''' <param name="folder">
    ''' 同日フォルダか確認したいフォルダのパス</param>
    ''' <returns>
    ''' True:同一フォルダ。　False:同名ではないフォルダ</returns>
    ''' <remarks></remarks>
    Public Function IsSameFileFolder(ByVal filePath As String, ByVal folder As String) As Boolean
        Dim fileFolderString As String
        fileFolderString = System.IO.Path.GetDirectoryName(filePath)
        If fileFolderString = folder Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' src_pathのファイルのコピーをdes_pathで指定した名前で保存する。
    ''' </summary>
    ''' <param name="src_path">
    ''' コピーするファイルのフルパス</param>
    ''' <param name="des_path">
    ''' コピー先のファイル名を含むフルパス</param>
    ''' <returns>
    ''' 0:コピー成功　-1:コピー失敗　1:コピー失敗</returns>
    ''' <remarks></remarks>
    Public Function CopyFileAsNewName(ByVal src_path As String, ByVal des_path As String) As Integer

        Try
            My.Computer.FileSystem.CopyFile(src_path, des_path)
        Catch ex As System.IO.IOException
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' pathでしたフォルダを作成する。既存の場合は、何もしない。
    ''' </summary>
    ''' <param name="path">
    ''' 作成するフォルダのフルパス
    ''' </param>
    ''' <returns>
    ''' True:作成成功
    ''' False:作成失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function MakeFolder(ByVal path As String, ByRef errMess As String) As Boolean
        Dim isExist As Boolean
        isExist = System.IO.Directory.Exists(path)
        If isExist = False Then
            Try
                My.Computer.FileSystem.CreateDirectory(path)
            Catch ex As System.Exception
                errMess = ex.Message
                'MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Else
            Return True
        End If
        Return True
    End Function
    ''' <summary>
    ''' deleteFilePathのファイルを削除する。
    ''' </summary>
    ''' <param name="deleteFilePath">
    ''' 削除したいファイルのフルパス
    ''' </param>
    ''' <returns>
    ''' 0：削除成功　1：ファイルI/O関連エラー　-1：その他例外
    ''' </returns>
    ''' <remarks></remarks>
    Public Function DeleteFile(ByVal deleteFilePath As String) As Integer

        Try
            If System.IO.File.Exists(deleteFilePath) = True Then
                My.Computer.FileSystem.DeleteFile(deleteFilePath)
            ElseIf System.IO.Directory.Exists(deleteFilePath) = True Then
                My.Computer.FileSystem.DeleteDirectory(deleteFilePath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Catch ex As System.IO.IOException
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' deleteFilePathのファイルを削除する。
    ''' </summary>
    ''' <param name="deleteFilePath">
    ''' 削除したいファイルのフルパス
    ''' </param>
    ''' <param name="errMessage">
    ''' エラー発生時のメッセージ格納文字列
    ''' </param>
    ''' <returns>
    ''' 0：削除成功　1：ファイルI/O関連エラー　-1：その他例外
    ''' </returns>
    Public Function DeleteFile(ByVal deleteFilePath As String, ByRef errMessage As String) As Integer

        Try
            If System.IO.File.Exists(deleteFilePath) = True Then
                My.Computer.FileSystem.DeleteFile(deleteFilePath)
            ElseIf System.IO.Directory.Exists(deleteFilePath) = True Then
                My.Computer.FileSystem.DeleteDirectory(deleteFilePath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Catch ex As System.IO.IOException
            errMessage &= ex.Message
            Return 1
        Catch ex As System.Exception
            errMessage &= ex.Message
            Return -1
        End Try
        Return 0
    End Function

    ''' <summary>
    ''' searchDir内のファイル名リストを取得する
    ''' </summary>
    ''' <param name="searchDir">
    ''' ファイル名リストを取得するディレクトリ
    ''' </param>
    ''' <returns>
    ''' 取得したファイル名の文字列Listオブジェクト
    ''' </returns>
    Public Function GetAllFileList(ByVal searchDir As String) As List(Of String)
        Dim fileList As New List(Of String)

        'searchDir以下のファイルをすべて取得する
        Dim di As New System.IO.DirectoryInfo(searchDir)
        Dim files As System.IO.FileInfo() = di.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        'ListBox1に結果を表示する
        For Each f As System.IO.FileInfo In files
            If f.Name = "Thumbs.db" Then Continue For
            fileList.Add(f.Name)
        Next
        Return fileList
    End Function
    ''' <summary>
    ''' ファイル／フォルダの移動（名前変更）を行う。
    ''' 移動先に同一名称がある場合は、上書きをする。
    ''' </summary>
    ''' <param name="source">
    ''' 移動（名前変更）元のファイル／ディレクトリ名
    ''' </param>
    ''' <param name="dest">
    ''' 移動（名前変更）先のファイル／ディレクトリ名
    ''' </param>
    ''' <returns></returns>
    Public Function RenameFileFolder(ByVal source As String, ByVal dest As String) As Integer
        Try
            If System.IO.File.GetAttributes(source) = IO.FileAttributes.Directory Then
                My.Computer.FileSystem.MoveDirectory(source, dest, True)
            Else
                My.Computer.FileSystem.RenameFile(source, System.IO.Path.GetFileName(dest))
            End If
        Catch ex As System.IO.IOException
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return 0

    End Function
    Public Function GetTempFolderName(ByVal tempFolderNameHeader As String) As String
        Dim dt As DateTime = DateTime.Now
        Return tempFolderNameHeader & "_" & SysLoginUserInfo.ManNumber & "_" & dt.ToString("yyyyMMddHHmmss")
    End Function
    ''' <summary>
    ''' searchDirフォルダ内のextentionで指定した拡張子ファイルの一番最初に見つかったファイル名を取得する。
    ''' 本メソッド使用時の注意事項
    ''' searchDir以下にThumbsFileName以外１つのファイルしか存在しない事を前提としている。
    ''' </summary>
    ''' <param name="searchDir"></param>
    ''' <param name="extention"></param>
    ''' <returns></returns>
    Public Function GetOnlyOneFileName(ByVal searchDir As String, ByVal extention As String) As String
        Dim fileName As String = Nothing

        'searchDir以下のファイルをすべて取得する
        Dim di As New System.IO.DirectoryInfo(searchDir)
        Dim files As System.IO.FileInfo() = di.GetFiles("*." & extention, System.IO.SearchOption.AllDirectories)

        For Each f As System.IO.FileInfo In files
            If f.Name = ThumbsFileName Then Continue For
            fileName = f.Name
            Exit For
        Next
        Return fileName
    End Function

    Public Function CreatePartsDataFolder(ByVal partsCode As String) As Boolean
        Dim partsFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode
        Dim imageFolder As String = partsFolder & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
        Dim result As Boolean = False
        Dim errMess As String = ""

        If System.IO.Directory.Exists(partsFolder) = False Then
            If MakeFolder(partsFolder, errMess) = True Then
                If MakeFolder(imageFolder, errMess) = True Then
                    result = True
                Else
                    result = False
                End If

            Else
                result = False
            End If
        Else
            result = True
        End If
        If result = False Then
            MessageBox.Show(errMess, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return result
    End Function
    Public Sub OpenKankotsuFileSelectByListBox(ByVal kListBox As ListBox)
        Dim selIndex As Integer = kListBox.SelectedIndex
        Dim kankotsuFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Kankotsu & "\"
        Dim selFileName As String = Nothing

        If selIndex <> -1 Then
            selFileName = kankotsuFolder & kListBox.Items(selIndex)
        Else
            MessageBox.Show("ファイルが選択されていません", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ExecuteFile(selFileName)
    End Sub

    Public Sub OpenPartsImageFileSelectByListBox(ByVal piListBox As ListBox, ByVal partsCode As String)
        Dim selIndex As Integer = piListBox.SelectedIndex
        Dim partsImageFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root
        partsImageFolder &= "\" & partsCode & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
        Dim selFileName As String = Nothing

        If selIndex <> -1 Then
            selFileName = partsImageFolder & "\" & piListBox.Items(selIndex)
        Else
            MessageBox.Show("ファイルが選択されていません", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ExecuteFile(selFileName)
    End Sub

End Module

