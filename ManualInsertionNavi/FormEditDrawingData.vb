Imports System.IO

Public Class FormEditDrawingData
    '基板IDなし識別コード
    Private Const NoId As Integer = -1

    'データ作成モード
    Private EditMode As Integer

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    'マスタDBのテーブル操作用
    Private CtrlDbMaster As ControlDbMaster

    '図面マスターデータ操作用
    Private CtrlDbDrawingMaster As ControlDbDrawingMaster

    '部材マスターデータ操作用
    Private CtrlDbPartsMaster As ControlDbPartsMaster

    'データ状態コンボボックスコントロール
    Private CstmEnableCombobox As CustomComboboxEnableImpl

    '図面情報データテーブル
    Private DtDrawingInfoData As New DataTable

    '仮図面番号フォルダ名
    Private TempDrawingFolder As String = Nothing

    '仮副番フォルダ名
    Private Const TempDrawingRevFolder As String = "TempRevision"

    '同名添付ファイル時のフォルダ名
    Private Const TempAttachedFileHeader As String = "TempAttached_"


    '新規作成時の図面情報フォルダ名のヘッダ
    Private Const DrawingDataFolderNameHeader As String = "DrawingData"

    '添付ファイル（画像ファイル、諸元表、Netリスト）のオリジナルファイル名保存用
    Private OrigialFile As AttachedFile

    '添付ファイル（画像ファイル、諸元表、Netリスト）の変更されたファイル名保存用
    Private ChangeFile As AttachedFile

    '添付ファイル（画像ファイル、諸元表、Netリスト）の変更時に同じファイル名が選択された場合に、仮に付けるファイル名保存用
    Private TempSameNameFile As AttachedFile

    'NETリスト読込コントロール
    Private NetlistReader As New NetListReaderImpl

    '図面副番変更前の副番
    Private BeforeDrawingRev As String

    '登録or更新処理実施フラグ
    Private IsRegistedData As Boolean = False

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="mode">
    ''' 新規作成フラグ
    ''' </param>
    ''' <param name="id">
    ''' 形状データID
    ''' </param>
    ''' <param name="rev">
    ''' 図面副番を変更する場合に指定する図面副番。(図面副番を変更しない場合は、Nothingを指定)
    ''' </param>
    ''' <param name="mstContDb">
    ''' ControlDbMasterオブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mode As Integer, ByVal id As Integer, ByVal rev As String, ByVal mstContDb As ControlDbMaster, ByVal drawingMstCtrlDb As ControlDbDrawingMaster)
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        CtrlDbMaster = mstContDb.Clone
        CtrlDbDrawingMaster = drawingMstCtrlDb.Clone

        Dim defPartsMasterDb As New DefinePartsMasterDb
        CtrlDbPartsMaster = New ControlDbPartsMaster(defPartsMasterDb)
        CtrlDbPartsMaster.DefPtMstDb.DbPath = CtrlDbMaster.DefMstDb.DbPath
        EditMode = mode
        InitializeParam(id, rev)
    End Sub

    ''' <summary>
    ''' フォーム読込処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormEditDrawingData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        'コントロールのセッティング
        SetFormControlSetting()

        'コントロールへの値設定
        SetFormControlValue()

        '図面マスタテーブル確定処理
        DtDrawingInfoData.AcceptChanges()

        SetAttachedFileNameToTextbox(OrigialFile)

        Dim imagePath As String = Nothing

        imagePath = GetTargetFilePath(DrawingSubFolder.DrawingImage, OrigialFile.DrawingImage)
        SetImageToPictureBox(PictureBoxDrawingImage, imagePath)

        imagePath = GetTargetFilePath(DrawingSubFolder.BoardImage, OrigialFile.BoardImage)
        SetImageToPictureBox(PictureBoxBoardImage, imagePath)

        If EditMode = DrawingInfoEditMode.Browsing Then
            SetControlBrowsingMode()
        End If

        NowInitializing = False

    End Sub

    ''' <summary>
    ''' 各種初期化処理
    ''' </summary>
    ''' <param name="id">
    ''' 図面情報テーブルID。新規作成の場合はNothing
    ''' </param>
    ''' <param name="rev">
    ''' 図面副番を変更する場合の副番。（図面副番を変更しない場合はNothingを指定）
    ''' </param>
    Private Sub InitializeParam(ByVal id As Integer, ByVal rev As String)
        Dim dt As DateTime = DateTime.Now
        Dim mess As New Text.StringBuilder
        Dim dResult As DialogResult = Nothing
        Dim errMess As String = Nothing

        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                ButtonRegistData.Text = "登録"
                LabelEditMode.Text = "新規作成"
                LabelEditMode.BackColor = Color.Yellow
            Case DrawingInfoEditMode.ContentsEdit
                ButtonRegistData.Text = "更新"
                LabelEditMode.Text = "データ編集"
                LabelEditMode.BackColor = Color.Orange
            Case DrawingInfoEditMode.DrawingRevisionUpdate
                ButtonRegistData.Text = "登録(図面副番更新)"
                LabelEditMode.Text = "新規作成"
                LabelEditMode.BackColor = Color.Cyan
            Case DrawingInfoEditMode.Browsing
                ButtonRegistData.Visible = False
                LabelEditMode.Text = "閲覧"
                LabelEditMode.BackColor = Color.White
                ButtonCancel.Text = "閉じる"
        End Select


        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                '新規データ作成の場合の仮フォルダ作成
                TempDrawingFolder = GetTempFolderName(DrawingDataFolderNameHeader)
                Do While True
                    If CreateTempDrawingDataFolder(TempDrawingFolder) = False Then
                        mess.Append("このまま続行すると正常にデータ作成ができません" & vbCrLf)
                        mess.Append("処理を続行しますか？")
                        dResult = MessageBox.Show(mess.ToString, "フォルダ作成エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                        If dResult = DialogResult.Cancel Then
                            Me.Close()
                            Exit Sub
                        Else
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If

                Loop
            Case DrawingInfoEditMode.ContentsEdit, DrawingInfoEditMode.DrawingRevisionUpdate, DrawingInfoEditMode.Browsing
                TempDrawingFolder = Nothing
        End Select

        'テーブルデータの取得
        DtDrawingInfoData = CtrlDbDrawingMaster.GetDrawingOneDataFromTable(id)

        If EditMode = DrawingInfoEditMode.DrawingRevisionUpdate Then
            '副番変更前のデータをフォルダごとコピー
            DtDrawingInfoData.Rows(0)(DITColmun.Id) = DBNull.Value
            If DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) IsNot DBNull.Value Then
                BeforeDrawingRev = DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision)
            Else
                BeforeDrawingRev = NoRevisionFolderName
            End If
            DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) = rev
            DtDrawingInfoData.AcceptChanges()
            CopyRevisionFolder()
        End If


        InitializeAttachedFileStructure(ChangeFile)
        InitializeAttachedFileStructure(TempSameNameFile)

        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                InitializeAttachedFileStructure(OrigialFile)
            Case DrawingInfoEditMode.ContentsEdit, DrawingInfoEditMode.DrawingRevisionUpdate, DrawingInfoEditMode.Browsing
                If GetAttachedFiles(OrigialFile, errMess) = False Then
                    mess.Clear()
                    mess.AppendLine("図面情報関連ファイルの取得に失敗しました。")
                    mess.AppendLine("詳細を確認して下さい。")
                    Using fm As FormMessageDetailsDialog = New FormMessageDetailsDialog("", "ファイル取得エラー", errMess.ToLower, MessageBoxButtons.OK)
                        fm.ShowDialog()
                    End Using
                End If
        End Select

    End Sub
    Private Sub SetControlBrowsingMode()
        TextBoxId.ReadOnly = True
        ComboBoxDataEnable.Enabled = False
        TextBoxDrawingNo.ReadOnly = True
        TextBoxMaxLot.ReadOnly = True
        TextBoxBoardName.ReadOnly = True
        TextBoxBoardWidth.ReadOnly = True
        TextBoxBoardHeight.ReadOnly = True
        TextBoxMaxLot.ReadOnly = True
        TextBoxUpdateHistory.ReadOnly = True
        ButtonSelectDrawingImageFile.Visible = False
        ButtonSelectBoardImageFile.Visible = False
        ButtonSelectShogenhyoFile.Visible = False
        ButtonSelectNetlistFile.Visible = False
        ButtonRegistPartsData.Visible = False
        TextBoxNote.ReadOnly = True
    End Sub
    ''' <summary>
    ''' 変更前副番のフォルダを変更後副番のフォルダにコピーする
    ''' </summary>
    ''' <returns></returns>
    Private Function CopyRevisionFolder() As Boolean
        Dim dNumber As String = DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber)
        Dim changeRev As String = Nothing

        changeRev = DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision)

        Dim destFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\" & dNumber & "\" & changeRev
        Dim sourceFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\" & dNumber & "\" & BeforeDrawingRev

        '変更前副番のフォルダを変更後副番のフォルダにコピーする
        Try
            My.Computer.FileSystem.CopyDirectory(sourceFolder, destFolder, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ファイルコピーエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True

    End Function
    ''' <summary>
    ''' 添付ファイル構造体の初期化
    ''' </summary>
    ''' <param name="afs">
    ''' 初期化する添付ファイル構造体
    ''' </param>
    Private Sub InitializeAttachedFileStructure(ByRef afs As AttachedFile)
        afs.BoardImage = Nothing
        afs.DrawingImage = Nothing
        afs.Netlist = Nothing
        afs.Shogenhyou = Nothing
    End Sub
    ''' <summary>
    ''' 図面情報として登録された添付ファイルの名称を取得する。
    ''' </summary>
    ''' <param name="af">
    ''' 取得したファイル名称を格納するAttachedFile構造体
    ''' </param>
    ''' <param name="errMess">
    ''' エラーメッセージを格納する
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    Private Function GetAttachedFiles(ByRef af As AttachedFile, ByRef errMess As String) As Boolean
        Dim dNumber As String = DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber)
        Dim rev As String = Nothing

        If (DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) IsNot DBNull.Value) Then
            rev = DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision)
        Else
            rev = NoRevisionFolderName
        End If


        Dim drawingFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing
        Dim result As Boolean = True
        Dim errMesssage As New Text.StringBuilder


        '図面画像登録ファイル名取得
        af.DrawingImage = GetDrawingAttachedFileName(drawingFolder, dNumber, rev, DrawingSubFolder.DrawingImage)
        If af.DrawingImage = "" Then
            If DtDrawingInfoData.Rows(0)(DITColmun.RegistImageDrawing) = True Then
                errMesssage.AppendLine("登録された" & DrawingSubFolderNameJapanese(DrawingSubFolder.DrawingImage) & "がありません。")
                errMesssage.AppendLine("再登録して下さい。")
                errMesssage.Append(vbCrLf)
                DtDrawingInfoData.Rows(0)(DITColmun.RegistImageDrawing) = False
                result = False
            End If
        End If


        '基板画像登録ファイル名取得
        af.BoardImage = GetDrawingAttachedFileName(drawingFolder, dNumber, rev, DrawingSubFolder.BoardImage)
        If af.BoardImage = "" Then
            If DtDrawingInfoData.Rows(0)(DITColmun.RegistImageBoard) = True Then
                errMesssage.AppendLine("登録された" & DrawingSubFolderNameJapanese(DrawingSubFolder.BoardImage) & "がありません。")
                errMesssage.AppendLine("再登録して下さい。")
                errMesssage.Append(vbCrLf)
                DtDrawingInfoData.Rows(0)(DITColmun.RegistImageBoard) = False
                result = False
            End If

        End If


        '諸元表ファイル名取得
        af.Shogenhyou = GetDrawingAttachedFileName(drawingFolder, dNumber, rev, DrawingSubFolder.Shogenhyou)
        If af.Shogenhyou = "" Then
            If DtDrawingInfoData.Rows(0)(DITColmun.RegistShogenhyo) = True Then
                errMesssage.AppendLine("登録された" & DrawingSubFolderNameJapanese(DrawingSubFolder.Shogenhyou) & "がありません。")
                errMesssage.AppendLine("再登録して下さい。")
                errMesssage.Append(vbCrLf)
                DtDrawingInfoData.Rows(0)(DITColmun.RegistShogenhyo) = False
                result = False
            End If
        End If


        'NETリストファイル名取得
        af.Netlist = GetDrawingAttachedFileName(drawingFolder, dNumber, rev, DrawingSubFolder.NetList)
        If af.Netlist = "" Then
            If DtDrawingInfoData.Rows(0)(DITColmun.RegistNetlist) = True Then
                errMesssage.AppendLine("登録された" & DrawingSubFolderNameJapanese(DrawingSubFolder.NetList) & "がありません。")
                errMesssage.AppendLine("再登録して下さい。")
                errMesssage.Append(vbCrLf)
                DtDrawingInfoData.Rows(0)(DITColmun.RegistNetlist) = False
                result = False
            End If
        End If

        Return result
    End Function
    ''' <summary>
    ''' 添付ファイル名を各テキストボックスに設定する
    ''' </summary>
    ''' <param name="af">
    ''' 設定したい添付ファイル名を格納したAttachiedFile構造体
    ''' </param>
    Private Sub SetAttachedFileNameToTextbox(ByVal af As AttachedFile)
        TextBoxBoardImageFilename.Text = af.BoardImage
        TextBoxDrawingImageFilename.Text = af.DrawingImage
        TextBoxNetlistFilename.Text = af.Netlist
        TextBoxShogenhyoFilename.Text = af.Shogenhyou
    End Sub

    ''' <summary>
    ''' フォーム内のコントロールに初期値を設定する処理
    ''' </summary>
    Private Sub SetFormControlValue()
        TextBoxId.ReadOnly = True

        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                TextBoxId.Text = "新規"
                SetNewDrawingInfoDataToTable(SysLoginUserInfo.ManNumber)
            Case DrawingInfoEditMode.ContentsEdit
                DtDrawingInfoData.Rows(0)(DITColmun.UpdateManNumber) = SysLoginUserInfo.ManNumber
                TextBoxId.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.Id))
            Case DrawingInfoEditMode.DrawingRevisionUpdate
                DtDrawingInfoData.Rows(0)(DITColmun.RegistDate) = DBNull.Value
                DtDrawingInfoData.Rows(0)(DITColmun.RegistManNumber) = SysLoginUserInfo.ManNumber
                DtDrawingInfoData.Rows(0)(DITColmun.UpdateDate) = DBNull.Value
                DtDrawingInfoData.Rows(0)(DITColmun.UpdateManNumber) = DBNull.Value
                TextBoxId.Text = "図面副番更新"
            Case DrawingInfoEditMode.Browsing
                TextBoxId.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.Id))
        End Select



        '各種コントロールの値設定
        CstmEnableCombobox.SetSelectedValueInt(DtDrawingInfoData.Rows(0)(DITColmun.DataEnable))

        '図面番号
        TextBoxDrawingNo.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.DrawingNumber))
        '副番
        TextBoxRevision.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.DrawingRevision))
        '基板名称
        TextBoxBoardName.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.BoardName))
        '基板横サイズ
        TextBoxBoardWidth.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.BoardWidth))
        '基板縦サイズ
        TextBoxBoardHeight.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.BoardHeight))

        '備考
        TextBoxNote.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.Note))

        '更新履歴
        TextBoxUpdateHistory.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.ChangeHistory))

        SetRegistStatusLabel(DITColumnName(DITColmun.RegistImageDrawing), LabelDrawingImageRegistStatus)
        SetRegistStatusLabel(DITColumnName(DITColmun.RegistImageBoard), LabelBoardImageRagistStatus)
        SetRegistStatusLabel(DITColumnName(DITColmun.RegistShogenhyo), LabelShogenhyoResistStatus)
        SetRegistStatusLabel(DITColumnName(DITColmun.RegistNetlist), LabelNetlistResistStatus)

        TextBoxRegistrationDate.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.RegistDate))
        TextBoxUpdateDate.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.UpdateDate))

        TextBoxRegistrationUser.Text = CtrlDbMaster.GetRegisterName(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.RegistManNumber))
        TextBoxUpdateUser.Text = CtrlDbMaster.GetRegisterName(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.UpdateManNumber))

        '最大制作ロット数
        TextBoxMaxLot.Text = CtrlDbDrawingMaster.GetRowColmunContentString(DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.MaxLot))
    End Sub
    ''' <summary>
    ''' 各種データの登録状況ラベルを設定する
    ''' 対象のラベルコントロール：BoardImageRagistStatus、LabelShogenhyoResistStatus、LabelNetlistResistStatus
    ''' DtDrawingInfoData.Rows(0)の列名colNameの値によって
    ''' </summary>
    ''' <param name="colName">
    ''' 登録状況ラベルを設定するDtDrawingInfoDataの列名
    ''' </param>
    ''' <param name="label">
    ''' 登録状況ラベルコントロール
    ''' </param>
    Private Sub SetRegistStatusLabel(ByVal colName As String, ByRef label As Label)
        If DtDrawingInfoData.Rows(0)(colName) IsNot DBNull.Value Then
            If DtDrawingInfoData.Rows(0)(colName) = True Then
                label.Text = "登録済"
                label.BackColor = Color.Lime
            Else
                label.Text = "登録未"
                label.BackColor = Color.Orange
            End If
        Else
            label.Text = "登録未"
            label.BackColor = Color.Orange
        End If
    End Sub

    ''' <summary>
    ''' 図面情報の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewDrawingInfoDataToTable(ByVal registerManNumber As String)

        '部材データ設定
        DtDrawingInfoData.Rows.Add()
        DtDrawingInfoData.Rows(0)(DITColmun.Id) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.DataEnable) = True
        DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.BoardName) = DBNull.Value

        DtDrawingInfoData.Rows(0)(DITColmun.BoardWidth) = 10
        DtDrawingInfoData.Rows(0)(DITColmun.BoardHeight) = 10
        DtDrawingInfoData.Rows(0)(DITColmun.RegistImageDrawing) = False

        DtDrawingInfoData.Rows(0)(DITColmun.RegistImageBoard) = False
        DtDrawingInfoData.Rows(0)(DITColmun.RegistShogenhyo) = False
        DtDrawingInfoData.Rows(0)(DITColmun.RegistNetlist) = False
        DtDrawingInfoData.Rows(0)(DITColmun.Note) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.ChangeHistory) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.RegistDate) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.RegistManNumber) = registerManNumber
        DtDrawingInfoData.Rows(0)(DITColmun.UpdateDate) = DBNull.Value
        DtDrawingInfoData.Rows(0)(DITColmun.UpdateManNumber) = Nothing
        DtDrawingInfoData.Rows(0)(DITColmun.MaxLot) = 1
        DtDrawingInfoData.AcceptChanges()

    End Sub
    ''' <summary>
    ''' フォーム内のコントロール初期設定処理
    ''' </summary>
    Private Sub SetFormControlSetting()
        'カスタムコンボボックスの設定
        'データ状態コンボボックス
        CstmEnableCombobox = New CustomComboboxEnableImpl(ComboBoxDataEnable, "利用中", "利用停止", "Display", "Value")
        CstmEnableCombobox.SetComboboxDataSource()

        '編集モードによる読取専用設定
        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                TextBoxRevision.ReadOnly = False
                TextBoxDrawingNo.ReadOnly = False
            Case DrawingInfoEditMode.ContentsEdit, DrawingInfoEditMode.DrawingRevisionUpdate
                TextBoxRevision.ReadOnly = True
                TextBoxDrawingNo.ReadOnly = True
                TextBoxBoardName.ReadOnly = True
        End Select

        'コントロール読取専用設定
        TextBoxRegistrationDate.ReadOnly = True
        TextBoxRegistrationUser.ReadOnly = True


        TextBoxUpdateDate.ReadOnly = True
        TextBoxUpdateUser.ReadOnly = True

        TextBoxDrawingImageFilename.ReadOnly = True
        TextBoxBoardImageFilename.ReadOnly = True

        TextBoxShogenhyoFilename.ReadOnly = True
        TextBoxNetlistFilename.ReadOnly = True

    End Sub

    ''' <summary>
    ''' 図面情報フォルダをサブフォルダを含め作成する。
    ''' </summary>
    ''' <param name="drawingFolderName">
    ''' 作成する仮図面フォルダ名
    ''' </param>
    ''' <returns></returns>
    Private Function CreateTempDrawingDataFolder(ByVal drawingFolderName As String) As Boolean
        Dim drawingFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\" & drawingFolderName
        Dim result As Boolean = False
        Dim errMess As String = ""
        Dim resultMess As New Text.StringBuilder
        Dim dResult As DialogResult = Nothing

        Dim subFolder As String = Nothing

        '図面番号フォルダの作成（仮フォルダも含む）
        If Directory.Exists(drawingFolder) = False Then
            If MakeFolder(drawingFolder, errMess) = True Then
                result = True
            Else
                result = False
                resultMess.Append(errMess & vbCrLf)
                resultMess.Append(vbCrLf)
            End If
        Else
            result = True
        End If

        If result = True Then
            '図面フォルダが作成できた場合のみサブフォルダの作成を行う
            For Each folder As String In DrawingSubFolderName
                subFolder = drawingFolder & "\" & TempDrawingRevFolder & "\" & folder
                If Directory.Exists(subFolder) = False Then
                    If MakeFolder(subFolder, errMess) = False Then
                        resultMess.Append(errMess)
                        resultMess.Append(vbCrLf)
                        result = False
                    End If
                End If
            Next
        End If

        If result = False Then
            Using fm As FormMessageDetailsDialog = New FormMessageDetailsDialog("図面フォルダの作成が出来ませんでした", "図面フォルダ作成エラー", resultMess.ToString, MessageBoxButtons.OK)
                fm.ShowDialog()
            End Using
        End If
        Return result
    End Function
    ''' <summary>
    ''' 図面情報の更新有無情報を取得する。
    ''' </summary>
    ''' <returns>
    ''' True:更新有　False:更新なし
    ''' </returns>
    ''' <remarks></remarks>
    Private Function IsExistModifiedData() As Boolean
        If IsStartEdit = True Then
            Return True
        End If
        For Each row As DataRow In DtDrawingInfoData.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next
        Return False
    End Function
    ''' <summary>
    ''' フォームのクロージング処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormEditDrawingData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim isClose As Boolean = False
        isClose = DoCancelFormCloseProcess()
        If isClose = False Then
            e.Cancel = True
        End If

    End Sub
    ''' <summary>
    ''' キャンセルボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 更新処理をせずフォームを閉じる際の処理。（キャンセルボタンまたは×ボタンでフォームを閉じる）
    ''' </summary>
    ''' <returns>
    ''' True:更新せずフォームを閉じる処理完了　False:更新せずフォームを閉じる処理を中止
    ''' </returns>
    Private Function DoCancelFormCloseProcess() As Boolean
        Dim isClose As Boolean = False

        Dim delPath As New Text.StringBuilder
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                DtDrawingInfoData.AcceptChanges()

                '不要データ削除
                Select Case EditMode
                    Case DrawingInfoEditMode.CreateNewData
                        '新規データの場合は、仮データフォルダ以下全て削除
                        delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\")
                        delPath.Append(TempDrawingFolder & "\")
                        DeleteFile(delPath.ToString)
                    Case DrawingInfoEditMode.ContentsEdit
                        '既存データの場合は、TempSameNameFileかChangeFileのファイルを削除
                        'DrawingImageファイル削除
                        If DeleteChangedAttachFile(DrawingSubFolder.DrawingImage) = False Then

                        End If
                        'BoardImageファイル削除
                        If DeleteChangedAttachFile(DrawingSubFolder.BoardImage) = False Then

                        End If

                        '諸元表ファイル削除
                        If DeleteChangedAttachFile(DrawingSubFolder.Shogenhyou) = False Then

                        End If

                        'Netリストファイル削除
                        If DeleteChangedAttachFile(DrawingSubFolder.NetList) = False Then

                        End If
                    Case DrawingInfoEditMode.DrawingRevisionUpdate
                        '副番更新データの場合は、データフォルダ以下全て削除
                        delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\")
                        delPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber) & "\")
                        delPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) & "\")
                        DeleteFile(delPath.ToString)
                End Select
                isClose = True
            End If
        Else
            If IsRegistedData = False Then
                Select Case EditMode
                    Case DrawingInfoEditMode.CreateNewData
                        '新規データの場合は、仮データフォルダ以下全て削除
                        delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\")
                        delPath.Append(TempDrawingFolder & "\")
                        DeleteFile(delPath.ToString)
                    Case DrawingInfoEditMode.ContentsEdit
                    '編集データが無いので何もしない
                    Case DrawingInfoEditMode.DrawingRevisionUpdate
                        '副番更新データの場合は、データフォルダ以下全て削除
                        delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\")
                        delPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber) & "\")
                        delPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) & "\")
                        DeleteFile(delPath.ToString)
                End Select
            End If
            isClose = True
        End If
        Return isClose
    End Function

    Private Sub ComboBoxDataEnable_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDataEnable.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        DtDrawingInfoData.Rows(0)(DITColmun.DataEnable) = CstmEnableCombobox.GetSelectedValueInt
        IsStartEdit = True

    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles TextBoxDrawingNo.Leave, TextBoxRevision.Leave,
        TextBoxUpdateHistory.Leave, TextBoxNote.Leave, TextBoxBoardName.Leave

        '子コントロールも検索する。
        Dim cs As Control() = Me.Controls.Find(sender.name, True)
        '見つかった場合
        If cs.Length > 0 Then
            TextBoxLeave(CType(cs(0), TextBox))
        End If

    End Sub
    Private Sub TextBoxLeave(ByRef tBox As TextBox)
        If NowInitializing = True Then
            Exit Sub
        End If
        If tBox.Modified = False Then
            Exit Sub
        End If
        Dim colNmae As String = Nothing
        Select Case tBox.Name
            Case "TextBoxDrawingNo"
                colNmae = DITColumnName(DITColmun.DrawingNumber)
                tBox.Text = ((tBox.Text).Replace(" ", "")).ToUpper
            Case "TextBoxRevision"
                colNmae = DITColumnName(DITColmun.DrawingRevision)
                tBox.Text = ((tBox.Text).Replace(" ", "")).ToUpper
            Case "TextBoxUpdateHistory"
                colNmae = DITColumnName(DITColmun.ChangeHistory)
            Case "TextBoxNote"
                colNmae = DITColumnName(DITColmun.Note)
            Case "TextBoxBoardName"
                colNmae = DITColumnName(DITColmun.BoardName)
        End Select

        DtDrawingInfoData.Rows(0)(colNmae) = tBox.Text
        IsStartEdit = True
    End Sub


    Private Sub ButtonSelectBoardImageFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectBoardImageFile.Click
        SeletAttachedFile(DrawingSubFolder.BoardImage, DITColmun.RegistImageBoard, TextBoxBoardImageFilename, PictureBoxBoardImage)
    End Sub
    Private Sub ButtonSelectDrawingImageFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectDrawingImageFile.Click
        SeletAttachedFile(DrawingSubFolder.DrawingImage, DITColmun.RegistImageDrawing, TextBoxDrawingImageFilename, PictureBoxDrawingImage)
    End Sub
    ''' <summary>
    ''' 編集中の副番フォルダのパスを取得する。
    ''' 副番なしのフォルダ名は、NoRevisionFolderNameとする。
    ''' 新規作成の場合の副番フォルダ名は、TempDrawingFolderとする。
    ''' </summary>
    ''' <returns></returns>
    Private Function GetDestinationRevisionFolderPath() As String
        Dim destPath As New System.Text.StringBuilder

        destPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Drawing & "\")
        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                destPath.Append(TempDrawingFolder & "\")
                destPath.Append(TempDrawingRevFolder & "\")
            Case DrawingInfoEditMode.ContentsEdit, DrawingInfoEditMode.DrawingRevisionUpdate, DrawingInfoEditMode.Browsing
                destPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingNumber) & "\")
                If (DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) IsNot DBNull.Value) Then
                    destPath.Append(DtDrawingInfoData.Rows(0)(DITColmun.DrawingRevision) & "\")
                Else
                    destPath.Append(NoRevisionFolderName & "\")
                End If
        End Select
        Return destPath.ToString
    End Function
    ''' <summary>
    ''' subFolderIndexで指定されたサブフォルダ内のfileNameのフルパスを取得する。
    ''' </summary>
    ''' <param name="subFolderIndex"></param>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Private Function GetTargetFilePath(ByVal subFolderIndex As Integer, ByVal fileName As String) As String
        Dim destPath As New System.Text.StringBuilder
        destPath.Append(GetDestinationRevisionFolderPath())
        destPath.Append(DrawingSubFolderName(subFolderIndex) & "\")
        destPath.Append(fileName)
        Return destPath.ToString
    End Function

    ''' <summary>
    ''' 登録・更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim connectString As String = CtrlDbDrawingMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbDrawingMaster.GetMasterDbPathString()
        Dim SqlDrawingInfoData As String = Nothing
        Dim deleteFile As New List(Of String)
        Dim errMess As String = ""
        Dim mess As New Text.StringBuilder
        Dim insertResult As Boolean
        Dim drawingNumber As String = Nothing
        Dim drawingRevi As String = Nothing


        Select Case EditMode
            Case DrawingInfoEditMode.CreateNewData
                '新規データ登録
                If CanRegistNewData() = False Then
                    Exit Sub
                End If
                insertResult = RegistNewDrawingInfoData()
                If insertResult = True Then
                    DtDrawingInfoData.AcceptChanges()
                    RenameTempFolder()
                    IsRegistedData = True
                    IsStartEdit = False
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If

            Case DrawingInfoEditMode.ContentsEdit
                '既存データ更新
                If IsExistModifiedData() = False Then
                    MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                insertResult = UpdateDrawingInfoData()

                If insertResult = True Then
                    DtDrawingInfoData.AcceptChanges()
                    '添付ファイルの更新
                    If UpdateAttachedFile() = False Then
                        MessageBox.Show("添付ファイルの更新が出来ませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    IsRegistedData = True
                    IsStartEdit = False
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Case DrawingInfoEditMode.DrawingRevisionUpdate
                '新規データ登録
                If CanRegistNewData() = False Then
                    Exit Sub
                End If

                insertResult = RegistNewDrawingInfoData()
                If insertResult = True Then
                    DtDrawingInfoData.AcceptChanges()
                    '添付ファイルの更新
                    If UpdateAttachedFile() = False Then
                        MessageBox.Show("添付ファイルの更新が出来ませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    IsRegistedData = True
                    IsStartEdit = False
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
        End Select
    End Sub
    ''' <summary>
    ''' 登録しようとしている図面情報データが登録できるかを返す。
    ''' </summary>
    ''' <returns>
    ''' True:登録可能　False:登録不可
    ''' </returns>
    Private Function CanRegistNewData() As Boolean
        Dim mess As New Text.StringBuilder
        '新規データ登録
        If IsExistModifiedData() = False Then
            mess.Clear()
            mess.Append("登録するデータが入力されていません。")
            MessageBox.Show(mess.ToString, "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If (TextBoxDrawingNo.Text IsNot Nothing) AndAlso (TextBoxDrawingNo.Text <> "") Then
            If CtrlDbDrawingMaster.IsExistDrawingNumber(TextBoxDrawingNo.Text, TextBoxRevision.Text) = True Then
                mess.Clear()
                mess.AppendLine("図面番号：" & TextBoxDrawingNo.Text)
                mess.AppendLine(" 副番：" & TextBoxRevision.Text)
                mess.AppendLine("図面は既に登録されています。")
                MessageBox.Show(mess.ToString, "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            mess.Clear()
            mess.Append("図面番号が入力されていません。")
            MessageBox.Show(mess.ToString, "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' 図面情報の新規作成時に仮フォルダとして作成したフォルダを正式フォルダ名に変更する処理
    ''' </summary>
    Private Sub RenameTempFolder()
        Dim drawingNo As String = TextBoxDrawingNo.Text
        Dim df As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing
        Dim revision As String = TextBoxRevision.Text
        If revision = "" Then
            revision = NoRevisionFolderName
        End If
        '図面番号フォルダ名変更
        RenameFolderName(df & "\" & TempDrawingFolder, df & "\" & drawingNo)
        '副番フォルダ名変更
        RenameFolderName(df & "\" & drawingNo & "\" & TempDrawingRevFolder, df & "\" & drawingNo & "\" & revision)

    End Sub
    ''' <summary>
    ''' 図面情報テーブル更新処理。
    ''' ※本処理はテーブルのみ更新のため、別途添付ファイル更新処理も行う必要あり。
    ''' </summary>
    ''' <returns>
    ''' True:更新成功　False:更新失敗
    ''' </returns>
    Private Function UpdateDrawingInfoData() As Boolean
        Dim connectString As String = CtrlDbDrawingMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbDrawingMaster.GetMasterDbPathString()
        Dim dt As DateTime = DateTime.Now
        Dim SqlDrawingInfoData As String = Nothing
        Dim updateResult As Boolean
        DtDrawingInfoData.Rows(0)(DITColmun.UpdateDate) = dt

        'DBのデータ更新SQL作成
        SqlDrawingInfoData = CtrlDbDrawingMaster.GetModifiedSqlString(CtrlDbDrawingMaster.DefMstDb.TabaleDrawingInfo, DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.Id))

        updateResult = CtrlDbDrawingMaster.UpdateTableWithSQL(connectString, dbnameA, SqlDrawingInfoData)
        Return updateResult
    End Function
    ''' <summary>
    ''' 図面情報テーブル新規登録処理
    ''' </summary>
    ''' <returns>
    ''' True:登録成功　False:登録失敗
    ''' </returns>
    Private Function RegistNewDrawingInfoData() As Boolean
        Dim connectString As String = CtrlDbDrawingMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbDrawingMaster.GetMasterDbPathString()
        Dim dt As DateTime = DateTime.Now
        Dim SqlDrawingInfoData As String = Nothing
        Dim insertResult As Boolean

        DtDrawingInfoData.Rows(0)(DITColmun.RegistDate) = dt

        'DBのデータ登録SQL作成
        SqlDrawingInfoData = CtrlDbDrawingMaster.GetInsertSqlString(CtrlDbDrawingMaster.DefMstDb.TabaleDrawingInfo, DtDrawingInfoData.Rows(0), DITColumnName(DITColmun.Id))

        insertResult = CtrlDbDrawingMaster.UpdateTableWithSQL(connectString, dbnameA, SqlDrawingInfoData)
        Return insertResult

    End Function
    ''' <summary>
    ''' フォルダ名を変更する
    ''' </summary>
    ''' <param name="sourcePath">
    ''' 変更前のフォルダパス
    ''' </param>
    ''' <param name="destinationPath">
    ''' 変更後のフォルダパス
    ''' </param>
    ''' <returns>
    ''' True:成功　False:失敗
    ''' </returns>
    Private Function RenameFolderName(ByVal sourcePath As String, ByVal destinationPath As String) As Boolean
        Dim dResult As DialogResult
        Dim mess As New Text.StringBuilder
        Dim result As Boolean = False
        Do While True
            '登録前の仮図副番フォルダ名を登録後の図面番号名に変更
            If RenameFileFolder(sourcePath, destinationPath) <> 0 Then
                mess.Clear()
                mess.Append("フォルダ名の変更ができませんでした。" & vbCrLf)
                mess.Append("変更前：" & sourcePath & vbCrLf)
                mess.Append("変更後：" & destinationPath & vbCrLf)
                mess.Append(vbCrLf)
                mess.Append("リトライしますか？")

                dResult = MessageBox.Show(mess.ToString, "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                If dResult = DialogResult.No Then
                    result = False
                    Exit Do
                End If
            Else
                result = True
                Exit Do
            End If
        Loop
        Return result
    End Function
    ''' <summary>
    ''' 諸元表選択ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonSelectShogenhyoFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectShogenhyoFile.Click
        SeletAttachedFile(DrawingSubFolder.Shogenhyou, DITColmun.RegistShogenhyo, TextBoxShogenhyoFilename, Nothing)

    End Sub
    ''' <summary>
    ''' NETリスト選択ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonSelectNetlistFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectNetlistFile.Click
        SeletAttachedFile(DrawingSubFolder.NetList, DITColmun.RegistNetlist, TextBoxNetlistFilename, Nothing)
    End Sub
    ''' <summary>
    ''' 添付ファイル選択処理
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 添付ファイルを選択するフォルダのインデックス番号
    ''' </param>
    ''' <param name="registDataColumnIndex">
    ''' DtDrawingInfoData内の選択するファイルの登録情報列番号
    ''' </param>
    ''' <param name="textboxFileName">
    ''' 選択したファイル名を設定するテキストボックス
    ''' </param>
    ''' <param name="picbox">
    ''' 選択したファイルが画像の場合に表示するPictureBox。画像以外のときはNothingを指定
    ''' </param>
    Private Sub SeletAttachedFile(ByVal subFolderIndex As Integer, ByVal registDataColumnIndex As Integer, ByRef textboxFileName As TextBox, ByRef picbox As PictureBox)
        Dim selFilePath As String = Nothing
        Select Case subFolderIndex
            Case DrawingSubFolder.NetList
                selFilePath = SelectNetlistFileByDialog("")
            Case DrawingSubFolder.Shogenhyou
                selFilePath = SelectCsvFileByDialog("")
            Case DrawingSubFolder.DrawingImage, DrawingSubFolder.BoardImage
                selFilePath = SelectImageFileByDialog("")
        End Select
        If selFilePath = Nothing Then
            Exit Sub
        End If
        Dim selFileName As String = System.IO.Path.GetFileName(selFilePath)
        Dim tempFileName As String = Nothing
        Dim destFilePath As String = Nothing

        Dim mess As New Text.StringBuilder
        Dim dResult As DialogResult = Nothing
        Dim isExistSameNameFile As Boolean = False

        '登録編集中添付ファイル削除
        If DeleteChangedAttachFile(subFolderIndex) = False Then

        End If

        destFilePath = GetTargetFilePath(subFolderIndex, selFileName)
        If System.IO.File.Exists(destFilePath.ToString) = True Then
            mess.AppendLine("同一ファイル名が既にあります。")
            mess.AppendLine("ファイルを置き換えますか？")
            dResult = MessageBox.Show(mess.ToString, "ファイル処理確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            If dResult = DialogResult.Cancel Then
                Exit Sub
            End If
            isExistSameNameFile = True
            tempFileName = TempAttachedFileHeader & selFileName
            destFilePath = GetTargetFilePath(subFolderIndex, tempFileName)
        Else
            isExistSameNameFile = False
            tempFileName = Nothing
        End If

        If CopyFileAsNewName(selFilePath, destFilePath) <> 0 Then
            MessageBox.Show("ファイルコピーができませんでした。", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        SetAttachedFileName(subFolderIndex, selFileName, tempFileName)

        textboxFileName.Text = selFileName
        If DtDrawingInfoData.Rows(0)(registDataColumnIndex) = False Then
            DtDrawingInfoData.Rows(0)(registDataColumnIndex) = True
        End If

        Select Case subFolderIndex
            Case DrawingSubFolder.BoardImage, DrawingSubFolder.DrawingImage
                SetImageToPictureBox(picbox, destFilePath)
            Case DrawingSubFolder.NetList
            Case DrawingSubFolder.Shogenhyou
            Case Else
        End Select

        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 現在編集中の添付ファイル名を取得する。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 取得したいフォルダのインデックス番号
    ''' </param>
    ''' <returns>
    ''' 取得したファイル名。無い場合はNothing。
    ''' </returns>
    Private Function GetNowEdittingAttachedFileName(ByVal subFolderIndex As Integer) As String

        Dim tempAttachF As String = Nothing
        Dim changeF As String = Nothing
        Dim edittingAttachedFileName As String = Nothing

        Select Case subFolderIndex
            Case DrawingSubFolder.DrawingImage
                tempAttachF = TempSameNameFile.DrawingImage
                changeF = ChangeFile.DrawingImage
            Case DrawingSubFolder.BoardImage
                tempAttachF = TempSameNameFile.BoardImage
                changeF = ChangeFile.BoardImage
            Case DrawingSubFolder.NetList
                tempAttachF = TempSameNameFile.Netlist
                changeF = ChangeFile.Netlist
            Case DrawingSubFolder.Shogenhyou
                tempAttachF = TempSameNameFile.Shogenhyou
                changeF = ChangeFile.Shogenhyou
        End Select

        If tempAttachF <> Nothing Then
            edittingAttachedFileName = tempAttachF
        ElseIf changeF <> Nothing Then
            edittingAttachedFileName = changeF

        End If
        Return edittingAttachedFileName
    End Function
    ''' <summary>
    ''' データ登録・更新時に添付ファイルを更新する処理
    ''' </summary>
    ''' <returns>
    ''' True:更新成功　False:更新失敗
    ''' </returns>
    Private Function UpdateAttachedFile() As Boolean
        Dim orgDelStatus As Boolean = False

        '図面画像更新
        If ChangeFile.DrawingImage <> Nothing Then
            orgDelStatus = DeleteOriginalAttachFile(DrawingSubFolder.DrawingImage)
            If orgDelStatus = False Then
                Return False
            End If
        End If
        RenameNameAttachedFileName(DrawingSubFolder.DrawingImage)

        '基板画像更新
        If ChangeFile.BoardImage <> Nothing Then
            orgDelStatus = DeleteOriginalAttachFile(DrawingSubFolder.BoardImage)
            If orgDelStatus = False Then
                Return False
            End If
        End If
        RenameNameAttachedFileName(DrawingSubFolder.BoardImage)

        '諸元表ファイル更新
        If ChangeFile.Shogenhyou <> Nothing Then
            orgDelStatus = DeleteOriginalAttachFile(DrawingSubFolder.Shogenhyou)
            If orgDelStatus = False Then
                Return False
            End If
        End If
        RenameNameAttachedFileName(DrawingSubFolder.Shogenhyou)

        'NETリストファイル更新
        If ChangeFile.Netlist <> Nothing Then
            orgDelStatus = DeleteOriginalAttachFile(DrawingSubFolder.NetList)
            If orgDelStatus = False Then
                Return False
            End If
        End If
        RenameNameAttachedFileName(DrawingSubFolder.NetList)

        Return True
    End Function
    ''' <summary>
    ''' 登録済み添付ファイル名称を取得する。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 取得したいフォルダのインデックス番号
    ''' </param>
    ''' <returns>
    ''' 取得したファイル名称。無い場合はNothing。
    ''' </returns>
    Private Function GetOriginalAttachedFileName(ByVal subFolderIndex As Integer) As String

        Dim fileName As String = Nothing

        Select Case subFolderIndex
            Case DrawingSubFolder.DrawingImage
                fileName = OrigialFile.DrawingImage
            Case DrawingSubFolder.BoardImage
                fileName = OrigialFile.BoardImage
            Case DrawingSubFolder.NetList
                fileName = OrigialFile.Netlist
            Case DrawingSubFolder.Shogenhyou
                fileName = OrigialFile.Shogenhyou
        End Select
        Return fileName
    End Function
    ''' <summary>
    ''' 添付ファイル名を変更する。
    ''' 編集中同名ファイルが添付ファイルとして指定された場合にTempAttachedFileHeader+ファイル名としていたものを本来のファイル名に
    ''' 変更する処理。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' ファイル名を変更したいフォルダ名インデックス番号
    ''' </param>
    Private Sub RenameNameAttachedFileName(ByVal subFolderIndex As Integer)
        Dim drawingNo As String = TextBoxDrawingNo.Text
        Dim df As String = PartsInsertNaviAppConfigData.SystemDataPath.Drawing
        Dim revision As String = TextBoxRevision.Text
        If revision = "" Then
            revision = NoRevisionFolderName
        End If

        Dim destPath As New System.Text.StringBuilder
        Dim sorceFileName As String = Nothing
        Dim destFileName As String = Nothing

        Select Case subFolderIndex
            Case DrawingSubFolder.BoardImage
                sorceFileName = TempSameNameFile.BoardImage
                destFileName = ChangeFile.BoardImage
            Case DrawingSubFolder.DrawingImage
                sorceFileName = TempSameNameFile.DrawingImage
                destFileName = ChangeFile.DrawingImage
            Case DrawingSubFolder.NetList
                sorceFileName = TempSameNameFile.Netlist
                destFileName = ChangeFile.Netlist
            Case DrawingSubFolder.Shogenhyou
                sorceFileName = TempSameNameFile.Shogenhyou
                destFileName = ChangeFile.Shogenhyou
            Case Else
        End Select

        If (sorceFileName <> Nothing) AndAlso (destFileName <> Nothing) Then
            destPath.Append(GetDestinationRevisionFolderPath())
            destPath.Append(DrawingSubFolderName(subFolderIndex) & "\")
            RenameFileFolder(destPath.ToString & sorceFileName, destPath.ToString & destFileName)
        End If

    End Sub
    ''' <summary>
    ''' 編集前に登録されていた（添付されていた）ファイルを削除する。
    ''' </summary>
    ''' <param name="subFolderIndex"></param>
    ''' <returns></returns>
    Public Function DeleteOriginalAttachFile(ByVal subFolderIndex As Integer) As Boolean
        Dim deletePath As String = Nothing
        Dim deleteFileName As String = Nothing

        deleteFileName = GetOriginalAttachedFileName(subFolderIndex)
        If deleteFileName <> Nothing Then
            deletePath = GetTargetFilePath(subFolderIndex, deleteFileName)
            If DeleteFile(deletePath) <> 0 Then
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' 変更された添付ファイルを削除する。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 削除するファイルのフォルダインデックス番号
    ''' </param>
    ''' <returns>
    ''' True:削除成功　False:削除失敗
    ''' </returns>
    Public Function DeleteChangedAttachFile(ByVal subFolderIndex As Integer) As Boolean
        Dim deletePath As String = Nothing
        Dim deleteFileName As String = Nothing

        deleteFileName = GetNowEdittingAttachedFileName(subFolderIndex)
        If deleteFileName <> Nothing Then
            deletePath = GetTargetFilePath(subFolderIndex, deleteFileName)
            If DeleteFile(deletePath) <> 0 Then
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' 添付ファイル名を構造体に設定する。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 設定する添付フォルダのインデックス番号
    ''' </param>
    ''' <param name="changeFileName">
    ''' 変更された添付ファイル名
    ''' </param>
    ''' <param name="sameTempFileName">
    ''' 登録済み添付ファイルと同名のファイルが選択された場合に仮命名したファイル名称
    ''' </param>
    Private Sub SetAttachedFileName(ByVal subFolderIndex As Integer, ByVal changeFileName As String, ByVal sameTempFileName As String)
        Select Case subFolderIndex
            '基板名称
            Case DrawingSubFolder.BoardImage
                ChangeFile.BoardImage = changeFileName
                TempSameNameFile.BoardImage = sameTempFileName
            '図面画像
            Case DrawingSubFolder.DrawingImage
                ChangeFile.DrawingImage = changeFileName
                TempSameNameFile.DrawingImage = sameTempFileName
            'NETリスト
            Case DrawingSubFolder.NetList
                ChangeFile.Netlist = changeFileName
                TempSameNameFile.Netlist = sameTempFileName
            '諸元表
            Case DrawingSubFolder.Shogenhyou
                ChangeFile.Shogenhyou = changeFileName
                TempSameNameFile.Shogenhyou = sameTempFileName
        End Select

    End Sub

    Private Sub ButtonOpenShogenhyoFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenShogenhyoFile.Click
        OpenAttachedFile(DrawingSubFolder.Shogenhyou)

    End Sub

    Private Sub ButtonOpenNetlistFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenNetlistFile.Click
        OpenAttachedFile(DrawingSubFolder.NetList)
    End Sub
    ''' <summary>
    ''' 現在有効な添付ファイルを開く
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 開きたい添付ファイルのフォルダインデックス番号
    ''' </param>
    Private Sub OpenAttachedFile(ByVal subFolderIndex As Integer)
        Dim enableFilePath As String = Nothing
        enableFilePath = GetEnableAttachedFileName(subFolderIndex)
        If enableFilePath <> Nothing Then
            ExecuteFile(enableFilePath)
        End If
    End Sub
    ''' <summary>
    ''' 現在有効な添付ファイルのフルパスを取得する。
    ''' </summary>
    ''' <param name="subFolderIndex">
    ''' 取得したい添付ファイルフォルダインデックス番号
    ''' </param>
    ''' <returns>
    ''' 取得したファイルのフルパス。有効なファイルが無い場合はNothingを返す。
    ''' </returns>
    Private Function GetEnableAttachedFileName(ByVal subFolderIndex As Integer) As String
        Dim edittingFileName As String = Nothing
        Dim enableFilePath As String = Nothing
        Dim originalFileName As String = Nothing

        edittingFileName = GetNowEdittingAttachedFileName(subFolderIndex)
        If edittingFileName <> Nothing Then
            enableFilePath = GetTargetFilePath(subFolderIndex, edittingFileName)
        Else
            originalFileName = GetOriginalAttachedFileName(subFolderIndex)
            If originalFileName <> Nothing Then
                enableFilePath = GetTargetFilePath(subFolderIndex, originalFileName)
            End If
        End If
        Return enableFilePath

    End Function


    Private Sub ButtonRegistPartsData_Click(sender As Object, e As EventArgs) Handles ButtonRegistPartsData.Click
        '諸元表の読込
        Dim shogenhyouFilePath As String = Nothing
        shogenhyouFilePath = GetEnableAttachedFileName(DrawingSubFolder.Shogenhyou)
        Dim rds As New ReadShogenhyo

        If shogenhyouFilePath = Nothing Then
            Exit Sub
        End If

        If rds.ReadFile(shogenhyouFilePath) <> 0 Then
            MessageBox.Show("指定した諸元表のファイルが見つかりません。")
            Exit Sub
        End If

        '部品コード一覧取得(重複削除済み)
        Dim dtPartsCode As DataTable = rds.GetPartsCodeList

        Dim dtShogen As DataTable = rds.DtShogenhyouData.Copy

        ''各種データ登録用テーブル作成
        Dim dtRegistData As DataTable = Nothing

        Select Case rds.ShogenFileType
            Case ShogenhyoFileType.Type1
                dtRegistData = GetRegistTableType1(rds.DtShogenhyouData, dtPartsCode)
            Case ShogenhyoFileType.Type2
                dtRegistData = GetRegistTableType2(rds.DtShogenhyouData, dtPartsCode)
            Case ShogenhyoFileType.Unknown

        End Select
        '-------------部品形状分類未登録データを登録する必要があるか要検討
        '部材形状分類未登録データ登録
        'RegistShapeCategory(dtRegistData)
        '-------------部品形状分類未登録データを登録する必要があるか要検討ｰｰｰEND

        '部材形状未登録データ登録
        RegistShapeName(dtRegistData)

        '部材データ登録
        RegistPartsCode(dtRegistData)
    End Sub
    ''' <summary>
    ''' 諸元表とNETリストの連結結果データから部材コード未登録データを調べ、DBに登録する。
    ''' </summary>
    ''' <param name="dtCombinedData">
    ''' 諸元表とNETリストの連結結果データ（部材コード列重複削除済み）
    ''' </param>
    ''' <returns></returns>
    Private Function RegistPartsCode(ByVal dtCombinedData As DataTable) As Boolean
        Dim canRegisted As Boolean = True

        'NETリストテーブルから形状データを検索用SQL文格納
        Dim sbSql As New Text.StringBuilder

        '登録済み部材コードテーブル
        Dim dtRegistedPartsCode As DataTable

        '既に登録済みの部材データ名を重複分を削除した状態で取得するSQL文作成。
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("DISTINCT")
        sbSql.AppendLine(PMTColumnName(PMTColumn.PartsCode))
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbPartsMaster.DefPtMstDb.TablePartsMaster)
        sbSql.AppendLine("ORDER BY")
        sbSql.AppendLine(PMTColumnName(PMTColumn.PartsCode))
        '作成したSQL分で部材コードデータ名を取得
        dtRegistedPartsCode = CtrlDbPartsMaster.GetTableData(sbSql.ToString, CtrlDbPartsMaster.GetMasterDbConnectString)
        Dim dvRegistedPartsCode As New DataView(dtRegistedPartsCode)

        Dim dtFilterData As New DataTable

        '未登録部材形状名テーブル
        Dim dtNoRegistPartsData = CtrlDbPartsMaster.GetPartsOneDataFromTable(Nothing)

        '未登録部材形状名の抽出
        For Each row As DataRow In dtCombinedData.Rows
            '登録済みか確認
            dvRegistedPartsCode.RowFilter = PMTColumnName(PMTColumn.PartsCode) & "='" & row(PMTColumnName(PMTColumn.PartsCode)) & "'"
            dtFilterData = dvRegistedPartsCode.ToTable
            If row(0) Is DBNull.Value Then
                Continue For
            End If

            If 0 < dtFilterData.Rows.Count Then
                '登録済みデータ有
                Continue For
            End If
            Dim dr As DataRow = dtNoRegistPartsData.NewRow

            '部材形状名に一致する部材形状IDを取得する。
            If row(PSTColumnName(PSTColumn.PartsShapeName)) IsNot DBNull.Value Then
                Dim PartsShapeId As Integer = GetPartsShapeId(row(PSTColumnName(PSTColumn.PartsShapeName)))
                If 0 < PartsShapeId Then
                    dr(PMTColumnName(PMTColumn.PartsShapeId)) = PartsShapeId
                End If
            End If
            dr(PMTColumnName(PMTColumn.PartsCode)) = row(PMTColumnName(PMTColumn.PartsCode))
            dr(PMTColumnName(PMTColumn.DataEnable)) = True
            'dr(PMTColumnName(PMTColumn.PartsName)) = row("部品名称")
            'dr(PMTColumnName(PMTColumn.ModelName)) = row("部品型名")
            dr(PMTColumnName(PMTColumn.PartsName)) = row(SDTColumnName(SDTColumn.PartsName))
            dr(PMTColumnName(PMTColumn.ModelName)) = row(SDTColumnName(SDTColumn.PartsModelName))
            dr(PMTColumnName(PMTColumn.RegistDate)) = DateTime.Now
            dr(PMTColumnName(PMTColumn.RegistManNumber)) = SysLoginUserInfo.ManNumber
            dtNoRegistPartsData.Rows.Add(dr)
            'MessageBox.Show(row(0) & "は、未登録です。")
        Next
        Dim sbMess As New Text.StringBuilder
        If 0 < dtNoRegistPartsData.Rows.Count Then
            For Each row As DataRow In dtNoRegistPartsData.Rows
                CreatePartsDataFolder(PMTColumnName(PMTColumn.PartsCode))
            Next
            canRegisted = CtrlDbPartsMaster.RegistPartsData(dtNoRegistPartsData)
            If canRegisted = True Then
                sbMess.AppendLine(dtNoRegistPartsData.Rows.Count.ToString & "件の部材データを登録しました。")
                sbMess.AppendLine("別途部材データの整備を行ってください。")
                sbMess.AppendLine("登録した部材データのを表示します。")
                MessageBox.Show(sbMess.ToString, "部材データ登録確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Using fm As New FormDispDataTable(dtNoRegistPartsData, "登録部材データ一覧")
                    fm.ShowDialog()
                End Using
            End If
        Else
            sbMess.AppendLine("新規登録する部材データは、ありませんでした。")
            MessageBox.Show(sbMess.ToString, "部材データ登録確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return canRegisted
    End Function
    Private Function GetPartsShapeId(ByVal partsShapeName As String) As Integer
        Dim sbSql As New Text.StringBuilder
        Dim tb As DataTable
        Dim id As Integer = -1
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbMaster.DefMstDb.TablePartsShapeMaster)
        sbSql.AppendLine("WHERE")
        sbSql.AppendLine(PSTColumnName(PSTColumn.PartsShapeName) & "='" & partsShapeName & "'")
        '作成したSQL分で部材コードデータ名を取得
        tb = CtrlDbPartsMaster.GetTableData(sbSql.ToString, CtrlDbMaster.GetMasterDbConnectString)
        If 1 = tb.Rows.Count Then
            id = tb.Rows(0)(PSTColumnName(PSTColumn.ID))
        End If
        tb.Dispose()
        Return id
    End Function


    ''' <summary>
    ''' 諸元表とNETリストの連結結果データから未登録部材形状名を調べ、DBに登録する。
    ''' </summary>
    ''' <param name="dtCombinedData">
    ''' 諸元表とNETリストの連結結果データ（部材コード列重複削除済み）
    ''' </param>
    ''' <returns></returns>
    Private Function RegistShapeName(ByVal dtCombinedData As DataTable) As Boolean
        Dim canRegisted As Boolean = True

        Dim dvCombinedData As New DataView(dtCombinedData)
        'NETリストテーブルから形状データを検索用SQL文格納
        Dim sbSql As New Text.StringBuilder

        '登録済み部材形状名テーブル
        Dim dtRegistedShapeName As DataTable

        '既に登録済みの形状データ名を重複分を削除した状態で取得するSQL文作成。
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("DISTINCT")
        sbSql.AppendLine(PSTColumnName(PSTColumn.PartsShapeName))
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbMaster.DefMstDb.TablePartsShapeMaster)
        sbSql.AppendLine("ORDER BY")
        sbSql.AppendLine(PSTColumnName(PSTColumn.PartsShapeName))
        '作成したSQL分で形状データ名を取得
        dtRegistedShapeName = CtrlDbMaster.GetTableData(sbSql.ToString, CtrlDbMaster.GetMasterDbConnectString)

        'dvRegistDataから部材形状名の重複削除テーブルを取得
        Dim dvRegistedShapeName As New DataView(dtRegistedShapeName)
        Dim dtShapeNameList As DataTable = dvCombinedData.ToTable(True, PSTColumnName(PSTColumn.PartsShapeName))

        Dim dtFilterData As New DataTable

        '未登録部材形状名テーブル
        Dim dtNoRegistShapeName As New DataTable
        dtNoRegistShapeName = dtShapeNameList.Clone

        '未登録部材形状名の抽出
        For Each row As DataRow In dtShapeNameList.Rows
            '登録済みか確認
            dvRegistedShapeName.RowFilter = PSTColumnName(PSTColumn.PartsShapeName) & "='" & row(PSTColumnName(PSTColumn.PartsShapeName)) & "'"
            dtFilterData = dvRegistedShapeName.ToTable
            If row(0) Is DBNull.Value Then
                Continue For
            End If

            If 0 < dtFilterData.Rows.Count Then
                '登録済みデータ有
                Continue For
            End If
            Dim dr As DataRow = dtNoRegistShapeName.NewRow
            dr(PSTColumnName(PSTColumn.PartsShapeName)) = row(0)
            dtNoRegistShapeName.Rows.Add(dr)
            'MessageBox.Show(row(0) & "は、未登録です。")
        Next
        Dim sbMess As New Text.StringBuilder
        If 0 < dtNoRegistShapeName.Rows.Count Then
            '登録データがある場合
            canRegisted = CtrlDbMaster.RegistPartsShapeName(dtNoRegistShapeName)
            If canRegisted = True Then
                sbMess.AppendLine(dtNoRegistShapeName.Rows.Count.ToString & "件の部材形状データを登録しました。")
                sbMess.AppendLine("別途部材形状データの整備を行ってください。")
                sbMess.AppendLine("登録した部材形状データのを表示します。")
                MessageBox.Show(sbMess.ToString, "部材形状データ登録確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Using fm As New FormDispDataTable(dtNoRegistShapeName, "登録部材形状データ一覧")
                    fm.ShowDialog()
                End Using
            End If
        Else
            '登録データがない場合
            sbMess.AppendLine("新規登録する部材形状データは、ありませんでした。")
            MessageBox.Show(sbMess.ToString, "部材形状データ登録確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            canRegisted = True
        End If
        Return canRegisted
    End Function
    ''' <summary>
    ''' 諸元表とNETリストの連結結果データから未登録部材形状分類を調べ、DBに登録する。
    ''' </summary>
    ''' <param name="dtCombinedData">
    ''' 諸元表とNETリストの連結結果データ（部材コード列重複削除済み）
    ''' </param>
    ''' <returns></returns>
    Private Function RegistShapeCategory(ByVal dtCombinedData As DataTable) As Boolean
        Dim canRegisted As Boolean = True
        Dim dvCombinedData As New DataView(dtCombinedData)
        'NETリストテーブルから形状データを検索
        Dim sbSql As New Text.StringBuilder
        Dim ctrlDbPm As New ControlDbPartsMaster(DefPartsMasterDb)

        '既に登録済みの形状データ名を重複分を削除した状態で取得するSQL文作成。
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("DISTINCT")
        sbSql.AppendLine(PSCTColumnName(PSCTColumn.PartsShapeCategoryName))
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbMaster.DefMstDb.TablePartsShapeCategory)
        sbSql.AppendLine("ORDER BY")
        sbSql.AppendLine(PSCTColumnName(PSCTColumn.PartsShapeCategoryName))

        '登録済み部材形状名テーブル
        Dim dtRegistedShapeCategory As DataTable
        '作成したSQL分で形状分類データ名を取得
        dtRegistedShapeCategory = CtrlDbMaster.GetTableData(sbSql.ToString, CtrlDbMaster.GetMasterDbConnectString)
        Dim dvRegistedShapeCategory As New DataView(dtRegistedShapeCategory)
        Dim dtShapeCategoryList As DataTable = dvCombinedData.ToTable(True, SDTColumnName(SDTColumn.PartsName))

        Dim dtFilterData As New DataTable

        '未登録部材形状名テーブル
        Dim dtNoRegistedPartsCategoryData = CtrlDbMaster.GetPartsCategoryOneDataFromTable(Nothing)

        '未登録部材形状名の抽出
        For Each row As DataRow In dtShapeCategoryList.Rows
            '登録済みか確認
            dvRegistedShapeCategory.RowFilter = PSCTColumnName(PSCTColumn.PartsShapeCategoryName) & "='" & row(0) & "'"
            dtFilterData = dvRegistedShapeCategory.ToTable
            If row(0) Is DBNull.Value Then
                Continue For
            End If

            If 0 < dtFilterData.Rows.Count Then
                '登録済みデータ有
                Continue For
            End If
            Dim dr As DataRow = dtNoRegistedPartsCategoryData.NewRow
            dr(PSCTColumnName(PSCTColumn.PartsShapeCategoryName)) = row(0)
            dr(PSCTColumnName(PSCTColumn.DataEnable)) = True
            dr(PSCTColumnName(PSCTColumn.RegistDate)) = DateTime.Now
            dr(PSCTColumnName(PSCTColumn.RegistManNumber)) = SysLoginUserInfo.ManNumber
            dtNoRegistedPartsCategoryData.Rows.Add(dr)
            'MessageBox.Show(row(0) & "は、未登録です。")
        Next
        If 0 < dtNoRegistedPartsCategoryData.Rows.Count Then
            canRegisted = CtrlDbMaster.RegistPartsCategory(dtNoRegistedPartsCategoryData)
            If canRegisted = True Then
                Dim sbMess As New Text.StringBuilder
                sbMess.AppendLine(dtNoRegistedPartsCategoryData.Rows.Count.ToString & "件の部材データを登録しました。")
                sbMess.AppendLine("別途部材データの整備を行ってください。")
                sbMess.AppendLine("登録した部材データのを表示します。")
                MessageBox.Show(sbMess.ToString, "部材データ登録確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Using fm As New FormDispDataTable(dtNoRegistedPartsCategoryData, "登録部材データ一覧")
                    fm.ShowDialog()
                End Using
            End If
        End If
        Return canRegisted

    End Function
    ''' <summary>
    ''' dtPartsCodeに該当するデータを諸元表データdtShogenから検索し、登録データテーブルを作成する。
    ''' 対応諸元表フォーマット：Type1
    ''' </summary>
    ''' <param name="dtShogen">
    ''' 諸元表データテーブル
    ''' </param>
    ''' <param name="dtPartsCode">
    ''' 部材コードデータテーブル（諸元表から重複データを削除したもの）
    ''' </param>
    ''' <returns>
    ''' 諸元表とNETリストを連結した登録用データテーブル
    ''' </returns>
    Private Function GetRegistTableType1(ByVal dtShogen As DataTable, ByVal dtPartsCode As DataTable) As DataTable
        'NETリスト読込
        Dim enableNetListFilePath As String = Nothing
        Dim ctrlNLT As ControlNetListTable = Nothing
        Dim dtNetList As DataTable = Nothing
        Dim dvNetList As DataView = Nothing
        Dim dvShogen As DataView = dtShogen.DefaultView
        '各種データ登録用テーブル作成
        Dim dtRegistData As DataTable = dtShogen.Clone
        dtRegistData.Columns.Add(NLTColumnName(NLTColmun.ShapeName))

        enableNetListFilePath = GetEnableAttachedFileName(DrawingSubFolder.NetList)

        If enableNetListFilePath = Nothing Then
            Return Nothing
        End If

        ctrlNLT = New ControlNetListTable(enableNetListFilePath)
        dtNetList = ctrlNLT.GetTable
        dvNetList = dtNetList.DefaultView

        For Each row As DataRow In dtPartsCode.Rows
            '諸元表テーブルから部材コードに該当するテーブルデータを取得
            dvShogen.RowFilter = SDTColumnName(SDTColumn.PartsCode) & "='" & row(0) & "'"
            Dim dtExtractShogen As DataTable = dvShogen.ToTable()

            Dim drowRegistData As DataRow = dtRegistData.NewRow
            '抽出した諸元の項目の内容をDtRegistDataに追加反映
            For i As Integer = 0 To dtExtractShogen.Rows.Item(0).ItemArray.Count - 1
                If i = SDTColumn.Shogen Then
                    '項目が諸元列の場合
                    Try
                        Dim str As String() = Split(dtExtractShogen.Rows(0)(i), ",")
                        drowRegistData(i) = str(0)

                        'NETリストテーブルから形状データを検索
                        dvNetList.RowFilter = NLTColumnName(NLTColmun.Shogen) & "='" & drowRegistData(i) & "'"
                        Dim dtFilterdNetList As DataTable = dvNetList.ToTable
                        If dtFilterdNetList.Rows.Count = 1 Then
                            drowRegistData(NLTColumnName(NLTColmun.ShapeName)) = dtFilterdNetList.Rows(0)(NLTColmun.ShapeName)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    '項目が諸元列以外の場合
                    If dtExtractShogen.Rows(0)(i) IsNot DBNull.Value Then
                        drowRegistData(i) = dtExtractShogen.Rows(0)(i)
                    End If
                End If
            Next
            dtRegistData.Rows.Add(drowRegistData)

        Next
        Return dtRegistData
    End Function
    ''' <summary>
    ''' dtPartsCodeに該当するデータを諸元表データdtShogenから検索し、登録データテーブルを作成する。
    ''' 対応諸元表フォーマット：Type2
    ''' </summary>
    ''' <param name="dtShogen">
    ''' 諸元表データテーブル
    ''' </param>
    ''' <param name="dtPartsCode">
    ''' 部材コードデータテーブル（諸元表から重複データを削除したもの）
    ''' </param>
    ''' <returns>
    ''' 諸元表とNETリストを連結した登録用データテーブル
    ''' </returns>
    Private Function GetRegistTableType2(ByVal dtShogen As DataTable, ByVal dtPartsCode As DataTable)
        'NETリスト読込
        Dim enableNetListFilePath As String = Nothing
        Dim ctrlNLT As ControlNetListTable = Nothing
        Dim dtNetList As DataTable = Nothing
        Dim dvNetList As DataView = Nothing
        Dim dvShogen As DataView = dtShogen.DefaultView

        enableNetListFilePath = GetEnableAttachedFileName(DrawingSubFolder.NetList)

        If enableNetListFilePath = Nothing Then
            Return Nothing
        End If

        ctrlNLT = New ControlNetListTable(enableNetListFilePath)
        dtNetList = ctrlNLT.GetTable
        dvNetList = dtNetList.DefaultView


        '各種データ登録用テーブル作成
        Dim dtRegistData As DataTable = dtShogen.Clone
        dtRegistData.Columns.Add(NLTColumnName(NLTColmun.ShapeName))

        '形状データ登録を除外するデータ（諸元表の諸元/備考欄に()で記載されている諸元を格納する）テーブル
        Dim dtRejectShogen As New DataTable
        Dim rejectShogen As String = Nothing

        'テーブルに諸元列を追加
        dtRejectShogen.Columns.Add(SDTColumnName(SDTColumn.Shogen))
        Dim dvReject As New DataView(dtRejectShogen)

        For Each row As DataRow In dtPartsCode.Rows
            '諸元表テーブルから部材コードに該当するテーブルデータを取得
            dvShogen.RowFilter = SDTColumnName(SDTColumn.PartsCode) & "='" & row(0) & "'"
            Dim dtExtractShogen As DataTable = dvShogen.ToTable()

            Dim drowRegistData As DataRow = dtRegistData.NewRow
            For i As Integer = 0 To dtExtractShogen.Rows.Item(0).ItemArray.Count - 1
                Dim colname = dtExtractShogen.Columns(i).ColumnName
                If colname = SDTColumnName(SDTColumn.Shogen) Then
                    '項目が諸元列の場合
                    Try

                        Dim str As String() = Split(dtExtractShogen.Rows(0)(colname), ",")
                        'Str(0)の文字列の中に()があるか確認する。
                        Dim startIndex As Integer = str(0).IndexOf("(")
                        If startIndex < 0 Then
                            '(が見つからない場合（除外項目が無い）
                            '-(ハイフン)が入っていないか確認
                            Dim dashIndex As Integer = str(0).IndexOf("-")
                            If dashIndex < 0 Then
                                'ハイフン無しの場合
                                '除外テーブルに諸元が無いか検索
                                dvReject.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & str(0) & "'"
                                If dvReject.Count = 0 Then
                                    drowRegistData(colname) = str(0)
                                End If
                            Else
                                'ハイフンありの場合
                                '除外テーブルに諸元が無いか検索し、無ければ追加
                                dvReject.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & str(0) & "'"
                                If dvReject.Count = 0 Then
                                    Dim r As DataRow = dtRejectShogen.NewRow
                                    r(SDTColumnName(SDTColumn.Shogen)) = str(0)
                                    dtRejectShogen.Rows.Add(r)
                                End If
                            End If
                        Else
                            '(が見つかった場合（除外項目がある）
                            Dim endIndex As Integer = str(0).IndexOf(")")
                            drowRegistData(colname) = str(0).Substring(0, startIndex)
                            rejectShogen = str(0).Substring(startIndex + 1, endIndex - startIndex - 1)

                            '除外テーブルに諸元が無いか検索し、無ければ追加
                            dvReject.RowFilter = SDTColumnName(SDTColumn.Shogen) & "='" & rejectShogen & "'"
                            If dvReject.Count = 0 Then
                                Dim r As DataRow = dtRejectShogen.NewRow
                                r(SDTColumnName(SDTColumn.Shogen)) = rejectShogen
                                dtRejectShogen.Rows.Add(r)
                            End If
                        End If

                        'NETリストテーブルから形状データを検索し、見つかればデータを設定
                        dvNetList.RowFilter = NLTColumnName(NLTColmun.Shogen) & "='" & drowRegistData(i) & "'"
                        Dim dtFilterdNetList As DataTable = dvNetList.ToTable
                        If dtFilterdNetList.Rows.Count = 1 Then
                            drowRegistData(NLTColumnName(NLTColmun.ShapeName)) = dtFilterdNetList.Rows(0)(NLTColmun.ShapeName)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    '項目が諸元列以外の場合、登録データにそのまま設定
                    If dtExtractShogen.Rows(0)(colname) IsNot DBNull.Value Then
                        drowRegistData(colname) = dtExtractShogen.Rows(0)(colname)
                    End If

                End If
            Next
            dtRegistData.Rows.Add(drowRegistData)

        Next
        Dim dvRegistData As New DataView(dtRegistData)
        dvRegistData.RowFilter = SDTColumnName(SDTColumn.Shogen) & " IS NOT NULL"
        Return dvRegistData.ToTable

    End Function



    Private Sub TextBoxMaxLot_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxMaxLot.Validating

        Dim inputLot As Integer
        If ActiveControl IsNot TextBoxMaxLot Then
            If (Integer.TryParse(TextBoxMaxLot.Text, inputLot) = True) Then
                Dim boardWidth As Double = DtDrawingInfoData.Rows(0)(DITColumnName(DITColmun.BoardWidth))
                Dim settableLot As Integer = CInt(PartsInsertNaviAppConfigData.ProjectorWidth \ boardWidth)
                If settableLot < inputLot Then
                    ErrorProviderInput.SetError(TextBoxMaxLot, "この基板は、" & settableLot.ToString & "以下に設定してください。")
                    e.Cancel = True
                End If
            Else
                ErrorProviderInput.SetError(TextBoxMaxLot, "整数を入力してください。")
                e.Cancel = True
            End If

        End If
        If e.Cancel = True Then
            TextBoxMaxLot.BackColor = Color.Yellow
            If TextBoxMaxLot.CanUndo Then
                'アンドゥする
                TextBoxMaxLot.Undo()
                'アンドゥバッファを削除する
                TextBoxMaxLot.ClearUndo()
                TextBoxMaxLot.Modified = False
            End If

        Else
            If TextBoxMaxLot.Modified = True Then
                DtDrawingInfoData.Rows(0)(DITColumnName(DITColmun.MaxLot)) = inputLot
                IsStartEdit = True
            End If
        End If
    End Sub

    Private Sub TextBoxInput_Validated(sender As Object, e As EventArgs) Handles TextBoxMaxLot.Validated, TextBoxBoardHeight.Validated, TextBoxBoardWidth.Validated
        '子コントロールも含め探す場合
        Dim cs As Control() = Me.Controls.Find(sender.name, True)
        If 0 < cs.Length Then
            ErrorProviderInput.SetError(CType(cs(0), TextBox), "")
            CType(cs(0), TextBox).BackColor = SystemColors.Window
        End If

    End Sub

    Private Sub TextBoxBoardHeight_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxBoardHeight.Validating
        Dim inputValue As Double
        If ActiveControl IsNot TextBoxBoardHeight Then
            If Double.TryParse(TextBoxBoardHeight.Text, inputValue) = True Then
                Dim settableHeight As Double = PartsInsertNaviAppConfigData.ProjectorHeight
                If settableHeight < inputValue Then
                    ErrorProviderInput.SetError(TextBoxBoardHeight, "この基板の縦サイズは、" & settableHeight.ToString(0.0) & "以下に設定してください。")
                    e.Cancel = True
                End If
            Else
                ErrorProviderInput.SetError(TextBoxBoardHeight, "整数を入力してください。")
                e.Cancel = True
            End If
        End If

        If e.Cancel = True Then
            TextBoxBoardHeight.BackColor = Color.Yellow
            If TextBoxBoardHeight.CanUndo Then
                'アンドゥする
                TextBoxBoardHeight.Undo()
                'アンドゥバッファを削除する
                TextBoxBoardHeight.ClearUndo()
                TextBoxBoardHeight.Modified = False
            End If

        Else
            If TextBoxBoardHeight.Modified = True Then
                DtDrawingInfoData.Rows(0)(DITColumnName(DITColmun.BoardHeight)) = inputValue
                IsStartEdit = True
            End If
        End If

    End Sub

    Private Sub TextBoxBoardWidth_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxBoardWidth.Validating
        Dim inputValue As Double
        If ActiveControl IsNot TextBoxBoardWidth Then

            If Double.TryParse(TextBoxBoardWidth.Text, inputValue) = True Then
                Dim settableWidth As Double = PartsInsertNaviAppConfigData.ProjectorWidth
                If settableWidth < inputValue Then
                    ErrorProviderInput.SetError(TextBoxBoardWidth, "プロジェクタ表示サイズ(" & settableWidth & ")以下に設定してください。")
                    e.Cancel = True
                End If
            Else
                ErrorProviderInput.SetError(TextBoxBoardWidth, "数値を入力してください。")
                e.Cancel = True
            End If
            If e.Cancel = True Then
                TextBoxBoardWidth.BackColor = Color.Yellow
                If TextBoxBoardWidth.CanUndo Then
                    'アンドゥする
                    TextBoxBoardWidth.Undo()
                    'アンドゥバッファを削除する
                    TextBoxBoardWidth.ClearUndo()
                    TextBoxBoardWidth.Modified = False
                End If
            Else
                If TextBoxBoardWidth.Modified = True Then
                    DtDrawingInfoData.Rows(0)(DITColumnName(DITColmun.BoardWidth)) = inputValue
                    IsStartEdit = True
                End If

            End If
        End If


    End Sub
End Class