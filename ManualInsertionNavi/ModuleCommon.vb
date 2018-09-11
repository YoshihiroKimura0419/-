Public Module ModuleCommon
    '**********************************************************************************************************
    '以下は、ソリューションで使用する基本的な定数等を定義している。
    '**********************************************************************************************************
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    'オーダーテキスト長定義
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    'オーダーテキスト最大長
    Public Const MaxOrderTextLength As Integer = 20
    'オーダーテキスト最小長
    Public Const MinOrderTextLength As Integer = 14


    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    '製作数量関連定義
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' 製作数量管理アイテム数定義
    ''' </summary>
    Public Const QuantityItemNum As Integer = 6
    ''' <summary>
    ''' 製作数量管理アイテムインデクス定義
    ''' </summary>
    Public Enum QuantityItem
        '日産計画（個人）
        DailyPlan
        '日産実績（個人）
        DailyActual
        '総製作（オーダー）
        OrderTotalPlan
        '総実績（オーダー）
        OrderTotalActual
    End Enum
    ''' <summary>
    ''' PictureBox識別用列挙体
    ''' </summary>
    Public Enum PictboxItem
        '全部品
        AllParts
        '選択部品
        SelParts
    End Enum

    '**********************************************************************************************************
    '以下はソリューションで使用する共通関数群を定義している
    '**********************************************************************************************************

    ''' <summary>
    ''' 部材コードフォルダの直下にあるKankotsu.csvファイルを読み取り、読み取ったファイル名をリストボックスに設定する。
    ''' </summary>
    ''' <param name="partsCode">
    ''' 部材コード
    ''' </param>
    ''' <param name="kankotsuListbox">
    ''' ファイル名を設定するリストボックス
    ''' </param>
    Public Sub SetKankotsuFileListBox(ByVal partsCode As String, ByRef kankotsuListbox As ListBox)
        Dim partsCodeFolder As String = Nothing
        Dim ctrlKankotsuFile As New ControlKankotsuCsv
        Dim errMess As String = Nothing
        Dim kankotsuFile As New List(Of String)
        kankotsuListbox.Items.Clear()

        If partsCode <> Nothing Then
            partsCodeFolder = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode
            kankotsuFile = ctrlKankotsuFile.ReadFile(partsCodeFolder, errMess)
            If kankotsuFile Is Nothing Then
                Exit Sub
            End If
            If kankotsuFile IsNot Nothing Then
                For Each file As String In kankotsuFile
                    kankotsuListbox.Items.Add(file)
                Next
            End If
        Else
            kankotsuListbox.Items.Clear()
        End If
    End Sub
    ''' <summary>
    ''' 部材画像リストボックスのインデックスが変更になった時に、変更されたインデックスの画像ファイルをPictureBoxに設定する。
    ''' </summary>
    ''' <param name="partsListBox">
    ''' 部材画像リストボックス
    ''' </param>
    ''' <param name="pictureBoxParts">
    ''' 部材画像表示用PictureBox
    ''' </param>
    ''' <param name="regPCode">
    ''' 編集が確定した部材コード。部材データ編集中の場合は、Nothingを設定。
    ''' </param>
    ''' <param name="tempPCode">
    ''' 編集中の部材コード。部材データ編集中の場合のみ使用。
    ''' </param>
    Public Sub ListBoxPartsImageSelectedIndexChange(ByRef partsListBox As ListBox, ByRef pictureBoxParts As PictureBox, ByVal regPCode As String, ByVal tempPCode As String)
        Dim fileName As String = Nothing
        Dim fullPath As New System.Text.StringBuilder

        If partsListBox.SelectedIndex = -1 Then
            Exit Sub
        End If
        fullPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\")
        If regPCode <> Nothing Then
            fullPath.Append(regPCode & "\")
        Else
            fullPath.Append(tempPCode & "\")
        End If
        fullPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName & "\")
        fileName = partsListBox.Text
        fullPath.Append(fileName)
        SetImageToPictureBox(pictureBoxParts, fullPath.ToString)

    End Sub
    ''' <summary>
    ''' sorceStrの文字列を半角・大文字に変換した文字列を取得する
    ''' </summary>
    ''' <param name="sorceStr">
    ''' 変換前の文字列
    ''' </param>
    ''' <returns>
    ''' 変換後の文字列
    ''' </returns>
    Public Function ConvetStrUpperNarrow(ByVal sorceStr As String) As String
        Dim convertStr As String
        If sorceStr.Length = 0 Then
            Return Nothing
        End If
        '半角変換
        convertStr = StrConv(sorceStr, Microsoft.VisualBasic.VbStrConv.Narrow)
        '大文字変換
        convertStr = StrConv(convertStr, Microsoft.VisualBasic.VbStrConv.Uppercase)
        Return convertStr
    End Function

    ''' <summary>
    ''' 指定文字列が半角英数のみで
    ''' </summary>
    ''' <param name="checkString"></param>
    ''' <returns></returns>
    Public Function IsNumAlpha(ByVal checkString As String) As Boolean
        '正規表現パターンを指定(英字a - z, A - Z, 数値0 - 9)
        Dim regx As New System.Text.RegularExpressions.Regex(“^[a-zA-Z0-9]+$”)
        Dim result As Boolean
        '半角英数字に一致しているかチェック
        If regx.IsMatch(checkString) = False Then
            '半角英数字以外の文字が含まれている
            result = False
        Else
            result = True
        End If
        Return result
    End Function
    ''' <summary>
    ''' 指定文字列がオーダー文字列か判別する
    ''' </summary>
    ''' <param name="checkString"></param>
    ''' <returns></returns>
    Public Function IsOrderString(ByVal checkString As String) As Boolean
        If checkString Is Nothing Then
            Return False
        End If
        Dim len As Integer = checkString.Length
        If (len < MinOrderTextLength) OrElse (MaxOrderTextLength < len) Then
            Return False
        End If

        '正規表現パターンを指定(英字a - z, A - Z, 数値0 - 9)
        Dim regx As New System.Text.RegularExpressions.Regex(“^[a-zA-Z0-9-]+$”)
        Dim result As Boolean
        '半角英数字に一致しているかチェック
        If regx.IsMatch(checkString) = False Then
            'オーダー以外の文字が含まれている
            result = False
        Else
            result = True
        End If
        Return result
    End Function
    ''' <summary>
    ''' workDateで指定した日の作業日文字列を取得する。１日の就業時間は、8：30-翌日8：30とする。
    ''' </summary>
    ''' <param name="workDate">
    ''' 作業日文字列を取得したい日のDateTimeオブジェクト
    ''' </param>
    ''' <returns></returns>
    Public Function GetWorkDateString(ByVal workDate As DateTime) As String
        Dim sdt As DateTime = CType(String.Format("{0} 08:30:00", workDate.ToLongDateString), DateTime)
        Dim workDateStr As String = Nothing
        If workDate < sdt Then
            workDate = workDate.AddDays(-1)
            workDateStr = workDate.ToString("yyyy/MM/dd")
        Else
            workDateStr = workDate.ToString("yyyy/MM/dd")
        End If
        Return workDateStr
    End Function

End Module
