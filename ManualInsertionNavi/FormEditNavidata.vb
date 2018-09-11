Imports System.ComponentModel
Imports Microsoft.Office.Interop.Access.Dao
#Const NO_PROJECTOR = True
Public Class FormEditNavidata
    'マスターデータ操作用
    Private CtrlDbMaster As ControlDbMaster

    '図面マスターデータ操作用
    Private CtrlDbDrawingMaster As ControlDbDrawingMaster

    '部材コードマスタDB定義
    Private DefPartsMst As New DefinePartsMasterDb
    '部材コードマスタデータ操作用
    Private CtrlDbPartsMaster As New ControlDbPartsMaster(DefPartsMst)

    'ナビデータ操作用
    Private defNavidata As New DefineNaviDB

    Private CtrlDbNaviData As New ControlDbNaviData(defNavidata)

    Private CtrlDgv As ControlDataGridView = New ControlDataGridView

    '作業ログDB操作用
    Private DefWorkLog As New DefineWorkLogDb
    Private CtrlWorkLog As New ControlDbWorkLog(DefWorkLog)

    Private DefPrdAct As New DefineProductionPlanActualDb
    Private CtrlPrdAct As New ControlDbProductionPlanActual(DefPrdAct)

    ''' <summary>
    ''' 図面IDから抽出した図面情報格納データテーブル
    ''' </summary>
    Private TbDrawing As DataTable

    ''' <summary>
    ''' 図面番号格納変数
    ''' </summary>
    Private DrawingNumber As String = Nothing

    ''' <summary>
    ''' 図面副番格納変数
    ''' 副番なし時は、"-"を格納
    ''' </summary>
    Private DrawingRevision As String = Nothing

    Private DtSelectedPartsCodeData As New DataTable

    'PictureboxBoardへの基板画像表示倍率
    Private PictureboxDispRatio As Double = 1.0
    Private DrawRatio As Double = 1.0
    Private BoardSize As DoubleSize
    Private BoardImageSize As Size
    Private TbNaviData As DataTable

    Private TbPartsShapeData As DataTable

    Private TbSelectedNaviData As DataTable

    '同じ部材コードのナビデータだけに絞ったテーブル
    Private TbSamePartsCodeNaviData As DataTable

    '添付ファイル（画像ファイル、諸元表、Netリスト）のファイル名保存用
    Private AttachedFile As AttachedFile

    Private IsFormInitializing As Boolean = True
    Private IsFormShown As Boolean = False

    '幅基準での図面描画(True:幅基準　False:縦基準)
    Private IsWidthBaseDraw As Boolean = True

    '編集開始前のImageフォルダ内のファイルリスト
    Private PartsImageFileList As New List(Of String)

    Private SelectedPartsCode As String = Nothing
    Private PreviousPartsCode As String = Nothing

    Private SelectedRowIndex As Integer = -999
    Private SelectedNaviStep As Integer = 0

    ''' <summary>
    ''' 本フォームオープン時のモード格納変数
    ''' FormNaviMode列挙体(Unknown,Edit,Navi)で指定
    ''' </summary>
    Private OpenFormMode As Integer = FormNaviMode.Unknown

    Private DebugMessage As New System.Text.StringBuilder
    Private DebugStopWatch As New System.Diagnostics.Stopwatch()

    ''' <summary>
    ''' 生産情報格納構造体変数定義
    ''' </summary>
    Private ProductInfo As New ProductionInfomation

    ''' <summary>
    ''' プロジェクター表示フォーム定義
    ''' </summary>
    Private FormProjecter As FormDispProjector

    ''' <summary>
    ''' プロジェクタ情報構造体
    ''' </summary>
    Private ProjectorSettingData As ProjectorSetting

    'ナビ情報
    Private NaviRowIndex As Integer = -1
    Private NaviBoradIndex As Integer = -1
    Private IsStartProduction As Boolean = False

    ''' <summary>
    ''' 同時生産枚数。
    ''' </summary>
    Private ProductionLot As Integer = 0

    ''' <summary>
    ''' 基板画像を表示しているピクチャーボックスに対するナビメッセージを表示するテキストの
    ''' 高さの割合(PictureBox.Hight:Text.Height=1：Text.Height*NaviMessageTextHeightRatio)
    ''' </summary>
    Private Const NaviMessageTextHeightRatio As Double = 0.2
    ''' <summary>
    ''' ナビメッセージを表示するテキスト表示位置オフセット量Y
    ''' </summary>
    Private Const NaviMessageTextOffsetY As Integer = 10

    Private NaviDgvEdittingColmunIndex As Integer = -1
    Private NaviDgvEdittingRowIndex As Integer = -1

    ''' <summary>
    ''' なびモード時のメッセージ表示用フォーム定義
    ''' </summary>
    Private FMessageDialog As FormMessageDialog = New FormMessageDialog

    ''' <summary>
    ''' 作業ログ格納リスト(生産ロット数分要素を確保)
    ''' </summary>
    Private WorkLogList As New List(Of DataTable)

    ''' <summary>
    ''' 読み込んだ基板のシリアル番号格納リスト
    ''' </summary>
    Private BoardSerialList As New List(Of String)

    ''' <summary>
    ''' 作業の開始日時
    ''' 各ステップのナビ基板が切り替わる毎に設定する。
    ''' この日時を作業データの開始日時に記録する。
    ''' </summary>
    Private WorkStartDate As DateTime = Nothing
    ''' <summary>
    ''' 作業の終了日時
    ''' 各ステップのナビ基板が切り替わる毎に設定する。
    ''' この日時を作業データの終了日時に記録する。
    ''' </summary>
    Private WorkEndDate As DateTime = Nothing

    ''' <summary>
    ''' 仕掛データや作業中断までの作業合計時間(中断した場合にこの変数にDateTime.Now-LotWorkStartDateの差分を加算)
    ''' </summary>
    Private SumPreviousWorktime As Double = 0

    ''' <summary>
    ''' 生産ロットの作業開始日時(作業開始および中断から再開した際にその日時を格納)
    ''' </summary>
    Private LotWorkStartDate As DateTime = Nothing

    Private Const TempWorkLogFileName As String = "Temp_WorkingLog.accdb"
    Private Const TempWorkLogFileNameBackup As String = "Temp_WorkingLogBackUp.accdb"
    Private Const TempWorkLogFileCsvHeader As String = "作業ファイル最適化状況ファイル"
    Private Const CompactWorkLogDbStatusCsvFileName As String = "Compact.csv"

    ''' <summary>
    ''' DataGridViewマルチセル選択ステータス列挙体定義
    ''' </summary>
    Private Enum DgvCellSelectStatus
        'データ選択正常
        Ok
        'データ未選択
        NoSelect
        '非連続データ選択
        NoConsecutive
    End Enum
    ''' <summary>
    ''' なび中の状態定義列挙体
    ''' </summary>
    Private Enum NaviStatus
        ''' <summary>
        ''' OK
        ''' </summary>
        OK = 0

        ''' <summary>
        ''' 仕掛データなし
        ''' </summary>
        NoExistWorkingData = 100
        ''' <summary>
        ''' 仕掛データあり
        ''' </summary>
        ExistWorkingData = 101



        ''' <summary>
        ''' 仕掛データ取得エラー
        ''' </summary>
        ErrGetWorkingData = 1000

        ''' <summary>
        ''' 生産計画実績ID更新エラー
        ''' </summary>
        ErrUpdateProductionActualId = 1001

        '作業データファイル最適化処理時のエラー---------------
        ''' <summary>
        ''' 仮の作業データ(TempWorkLogFileName)ファイル削除エラー
        ''' </summary>
        ErrDeleteTempWorkingData = 1100

        ''' <summary>
        ''' 作業データ最適化状況ファイル名指定エラー
        ''' </summary>
        ErrInvalidCompactStatusFilename = 1101
        ''' <summary>
        ''' 作業データ最適化状況ファイル読込エラー
        ''' </summary>
        ErrReadCompactStatusFile = 1102


        ''' <summary>
        ''' 作業データ最適化状況ファイル書込エラー
        ''' </summary>
        ErrWriteCompactStatusFile = 1110

        ''' <summary>
        ''' 作業データ最適化状況ファイル書込エラー
        ''' </summary>
        ErrCompactFileRenameBackup = 1120


        ''' <summary>
        ''' 作業データ最適化エラー
        ''' </summary>
        ErrWorkingDbCompact = 1150
        ''' <summary>
        ''' 作業データ最適化エラー
        ''' </summary>
        ErrRecoverWorkingDbCompactFile = 1151

        '作業データファイル最適化状況---------------
        ''' <summary>
        ''' 作業データ最適化済み
        ''' </summary>
        WorkingDbCompacted = 1200
        ''' <summary>
        ''' 作業データの最適化必要
        ''' </summary>
        WorkingDbNeedCompact = 1201
        ''' <summary>
        ''' 作業データ最適化中
        ''' </summary>
        WorkingDbNowCompacting = 1202
        ''' <summary>
        ''' 作業データ最適化ファイルリネーム完了
        ''' </summary>
        WorkingDbCompactRenameBackUpComplete = 1203
        ''' <summary>
        ''' 作業データ最適化完了
        ''' </summary>
        WorkingDbCompactComplete = 1210

    End Enum
    ''' <summary>
    ''' DB最適化状況格納構造体定義
    ''' </summary>
    Private Structure DbCompact
        Public ComputerName As String
        Public LastDate As Date
        Public Status As String
    End Structure


    ''' <summary>
    ''' 作業データ最適化情報格納変数
    ''' </summary>
    Private DbCompactStatus As DbCompact

    ''' <summary>
    ''' コンストラクター
    ''' </summary>
    ''' <param name="mstContDb">
    ''' マスターDBコントロールクラス
    ''' </param>
    ''' <param name="mstCtrlDrawingMaster">
    ''' 図面マスタDBコントロールクラス
    ''' </param>
    ''' <param name="prdInfo">
    ''' 製作情報構造体
    ''' </param>
    Public Sub New(ByVal mstContDb As ControlDbMaster, ByVal mstCtrlDrawingMaster As ControlDbDrawingMaster, ByVal prdInfo As ProductionInfomation, ByVal mode As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        OpenFormMode = mode
        ProductInfo = prdInfo
        If (OpenFormMode <> FormNaviMode.Navi) AndAlso (OpenFormMode <> FormNaviMode.Edit) Then
            MessageBox.Show("Unkown FormNaviMode:" & OpenFormMode, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        SetNaviDgvColumn(OpenFormMode)
        CtrlDbMaster = mstContDb.Clone
        CtrlDbDrawingMaster = mstCtrlDrawingMaster.Clone
        CtrlDbPartsMaster.DefPtMstDb.DbPath = CtrlDbMaster.DefMstDb.DbPath
        CtrlPrdAct.DefPpaDb.DbPath = CtrlDbMaster.DefMstDb.DbPath
        TbDrawing = CtrlDbDrawingMaster.GetDrawingOneDataFromTable(ProductInfo.DrawingId)
        DrawingNumber = TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingNumber))
        If TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingRevision)) IsNot DBNull.Value Then
            DrawingRevision = TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingRevision))
        Else
            DrawingRevision = NoRevisionFolderName
        End If
        CtrlDbNaviData.SetDbPath(PartsInsertNaviAppConfigData.SystemDataPath.Drawing, DrawingNumber, DrawingRevision)
        AttachedFile.BoardImage = GetDrawingAttachedFileFullPath(PartsInsertNaviAppConfigData.SystemDataPath.Drawing, DrawingNumber, DrawingRevision, DrawingSubFolder.BoardImage)
        SetPictureBoxPropaty(PictureBoxBoard, PictureBoxAllParts, PictureBoxPresentParts)

    End Sub
    Private Sub FormEditNavidata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sbStr As New System.Text.StringBuilder
        Dim sts As Boolean
        sts = CtrlDbNaviData.CopyNaviMasterDb(PartsInsertNaviAppConfigData.SystemDataPath.Db)
        If sts = False Then
            Me.Close()
        End If
        InitializeNaviParameter()

        Select Case OpenFormMode
            Case FormNaviMode.Edit
                EnableStepEditButton(CheckBoxEditStep.Checked)
                '編集用なびデータ取得
                TbNaviData = GetEditNaviDataTable()
                If TbNaviData.Rows.Count = 0 Then
                    MessageBox.Show("なびデータが無いので諸元表とNetリストから雛形を作成します。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim createResult As Boolean = CtrlDbNaviData.CreateNaviDataMain()
                    If createResult = False Then
                        MessageBox.Show("なびデータ(雛形)の作成ができませんでした。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    TbNaviData = GetEditNaviDataTable()
                End If
            Case FormNaviMode.Navi
                'なび用データ取得
                TbNaviData = GetNaviDataTable()
                If TbNaviData.Rows.Count = 0 Then
                    DispNoNaviData()
                    Me.Close()
                    Exit Sub
                End If
                '作業ログフォルダの設定
                CtrlWorkLog.SetWorkingDataAndLogDbPath(PartsInsertNaviAppConfigData.SystemDataPath.Root)
        End Select

        'なびデータのバインド
        DataGridViewNavidata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewNavidata.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        CtrlDgv.BindTableToDgv(DataGridViewNavidata, TbNaviData)
        DataGridViewNavidata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        SetDrawingInfoToTextBox()
        SetSamePartsDgvColum()
        ChangeContrlMode(OpenFormMode)

        If OpenFormMode = FormNaviMode.Navi Then
            If NaviModeFormLoard() = False Then
                Me.Close()
                Exit Sub
            End If
        End If
        IsFormInitializing = False
        TimerFlicker.Enabled = True

    End Sub


    ''' <summary>
    ''' なびモード時のフォームロード処理
    ''' </summary>
    ''' <returns>
    ''' True:フォームロード成功　
    ''' False:フォームロード失敗（プロジェクタ電源ON確認異常、仕掛データ読込異常）
    ''' </returns>
    Private Function NaviModeFormLoard() As Boolean
        SetOrderInfoText()
        If ConfirmTurnOnProjector() = False Then
            Return False
        End If
        If SetProjectorSettingData() = False Then
#If NO_PROJECTOR Then
            '本処理は、モニタ１台でのデバッグ地位LabelProductionLot
            DebugProjecterSetting()
#Else
            Return False
#End If
        End If
        If WorkingDbCompactMain() = False Then
            Return False
        End If
        Dim fpo As New FormMessage
        fpo.Title = "初期データ設定"        'ダイアログのタイトルを設定
        fpo.Minimum = 0                     'プログレスバーの最小値を設定
        fpo.Maximum = ProjectorSettingData.MaxBoroadNum - 1                     'プログレスバーの最大値を設定
        fpo.Value = 0                       'プログレスバーの初期値を設定
        fpo.Show(Me)                        '進行状況ダイアログを表示する
        fpo.Value = 0                       'プログレスバーの値を変更する
        Me.Enabled = False

        For i As Integer = 0 To ProjectorSettingData.MaxBoroadNum - 1
            fpo.Message = String.Format("作業データ雛形を作成しています・・・({0}/{1})", i + 1, ProjectorSettingData.MaxBoroadNum)
            fpo.Value = i
            Dim dt As DataTable = CtrlWorkLog.GetWorkingDataTemplate()
            WorkLogList.Add(dt)
        Next
        'ダイアログを閉じる
        fpo.CloseWindow()
        If fpo IsNot Nothing Then
            fpo.Dispose()
        End If
        Me.Enabled = True
        Return True
    End Function
    Private Function IsExistWorkingData() As Integer
        Dim sts As Integer = NaviStatus.OK

        Dim tbWorkingSerial As DataTable = CtrlWorkLog.GetWorkingSerialList(ProductInfo.Order, SysLoginUserInfo.ManNumber)
        If 0 < tbWorkingSerial.Rows.Count Then
            '仕掛データあり
            ProductionLot = tbWorkingSerial.Rows.Count
            '仕掛データをWorkLogListに設定
            For Each row As DataRow In tbWorkingSerial.Rows
                BoardSerialList.Add(row(WLTColumnName(WLTColumn.SerialNo)))
            Next
            For j As Integer = 0 To ProductionLot - 1
                WorkLogList(j) = CtrlWorkLog.GetWorkingData(ProductInfo.Order, SysLoginUserInfo.ManNumber, BoardSerialList(j))
                If (WorkLogList(j).Rows.Count = 0) OrElse (WorkLogList(j).Columns.Count = 0) Then
                    '仕掛データ取得失敗
                    DispErrorGetWorkingData()
                    sts = NaviStatus.ErrGetWorkingData
                    Return sts
                End If
                If WorkLogList(j).Rows(0)(WLTColumnName(WLTColumn.ProductionAcutualId)) <> ProductInfo.ProductionPlanActualId Then
                    '生産計画実績IDの更新
                    SetNewProducionAuctualId(j)
                    If RegistWorkingDataToDb(j) = False Then
                        DispErrorUpdateProductionActualId(j)
                        sts = NaviStatus.ErrUpdateProductionActualId
                        Return sts
                    End If
                End If
            Next
            If sts = NaviStatus.OK Then
                DispExistWorkingData()
                sts = NaviStatus.ExistWorkingData
            End If
        ElseIf (0 = tbWorkingSerial.Rows.Count) AndAlso (tbWorkingSerial.Columns.Count = 0) Then
            '仕掛データ取得失敗
            DispErrorGetWorkingData()
            sts = NaviStatus.ErrGetWorkingData
        Else
            '仕掛データなし
            sts = NaviStatus.NoExistWorkingData
        End If
        tbWorkingSerial.Dispose()
        Return sts
    End Function

    Private Sub SetNewProducionAuctualId(ByVal boardIdx As Integer)

        For Each row As DataRow In WorkLogList(boardIdx).Rows
            row(WLTColumnName(WLTColumn.ProductionAcutualId)) = ProductInfo.ProductionPlanActualId
        Next

    End Sub

    ''' <summary>
    ''' FormLordではできない初期化処理を行う。
    ''' DataGridViewのフォーカス変更処理は、FormLoad時には実行されないため、本処理で行う。
    ''' 表示倍率も表示後に取得としている。
    ''' ※Shownイベントは、初回表示時のみしか実行されない。
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormEditNavidata_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        IsFormShown = False
        BoardImageSize = GetImageSize(AttachedFile.BoardImage)

        PictureboxDispRatio = GetPictureboxDispRatio(BoardImageSize, PictureBoxBoard.Size, IsWidthBaseDraw)

        SetImageToPictureBoxBottmLeft(PictureBoxBoard, AttachedFile.BoardImage, PictureboxDispRatio)

        DrawRatio = GetDrawRatio(PictureBoxBoard, BoardSize.Width, BoardSize.Height, IsWidthBaseDraw)

        DataGridViewNavidata.CurrentCell = Nothing
        If OpenFormMode = FormNaviMode.Navi Then
            If FormProjecter Is Nothing Then
                FormProjecter = New FormDispProjector(ProjectorSettingData)
                FormProjecter.Show()
                ProjectorSettingData.DispRatio = FormProjecter.GetNowDispRatio
            End If
            TimerGetOrderActual.Enabled = True
        End If
        Me.Activate()
        ActiveControl = ButtonStartProduction
        IsFormShown = True

    End Sub
    ''' <summary>
    ''' デバッグ時にプロジェクタを接続していない場合、ダミーのプロジェクタフォームを表示するための設定
    ''' </summary>
    Private Sub DebugProjecterSetting()
        ProjectorSettingData.Posi.Y = 0
        ProjectorSettingData.Posi.X = 1100
        ProjectorSettingData.FormSize.Width = 640
        ProjectorSettingData.FormSize.Height = 360
    End Sub
    ''' <summary>
    ''' ナビゲーション用PictureBoxのプロパティ設定
    ''' </summary>
    ''' <param name="boradPicbox">
    ''' 基板画像表示用PictureBox
    ''' </param>
    ''' <param name="allPartsPicbox">
    ''' 同一部品表示用PictureBox
    ''' </param>
    ''' <param name="selectePartsPicbox">
    ''' 選択部品表示用PictureBox
    ''' </param>
    Private Sub SetPictureBoxPropaty(ByRef boradPicbox As PictureBox, ByRef allPartsPicbox As PictureBox, ByRef selectePartsPicbox As PictureBox)
        With allPartsPicbox
            .Parent = boradPicbox
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Normal
            boradPicbox.Controls.Add(allPartsPicbox)
        End With
        With selectePartsPicbox
            .Parent = allPartsPicbox
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.Normal
            allPartsPicbox.Controls.Add(selectePartsPicbox)
        End With

    End Sub
    ''' <summary>
    ''' オーダー情報テキストボックス内容の設定
    ''' </summary>
    Private Sub SetOrderInfoText()
        TextBoxOrder.Text = ProductInfo.Order
        TextBoxProductionTotalActual.Text = ProductInfo.Quantity(QuantityItem.OrderTotalActual).ToString("#,0")
        TextBoxProductionTotalPlan.Text = ProductInfo.Quantity(QuantityItem.OrderTotalPlan).ToString("#,0")
        TextBoxProductionDailyActual.Text = ProductInfo.Quantity(QuantityItem.DailyActual).ToString("#,0")
        TextBoxProductionDailyPlan.Text = ProductInfo.Quantity(QuantityItem.DailyPlan).ToString("#,0")
    End Sub
    ''' <summary>
    ''' 生産ロットラベルの内容設定
    ''' </summary>
    Private Sub SetProductionLotLabel()
        If IsStartProduction = True Then
            LabelProductionLot.Text = String.Format("{0}/{1}枚", NaviBoradIndex + 1, ProductionLot)
        Else
            If 0 < ProductionLot Then
                LabelProductionLot.Text = String.Format("-/{0}枚", ProductionLot)
            Else
                LabelProductionLot.Text = "-/-枚"
            End If
        End If
    End Sub
    ''' <summary>
    ''' 基板シリアルナンバー読込キャンセル時のメッセージ表示
    ''' </summary>
    Private Sub DispSerialCancelMessage()
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("基板シリアルNoのバーコード読み込みがキャンセルされました。")
        sbStr.AppendLine("作業を取り消します。")
        sbStr.AppendLine("作業を開始するには「作業開始」ボタンまたはEnterキーを押してください。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("シリアルNoバーコード読み込みキャンセル", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' 仕掛データの生産計画実績ID更新処理エラーメッセージ表示
    ''' </summary>
    ''' <param name="naviBoardIdx">
    ''' 更新しようとした基板インデックス番号(0-)
    ''' </param>
    Private Sub DispErrorUpdateProductionActualId(ByVal naviBoardIdx As Integer)
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("本日以前の仕掛データがあり、生産計画実績IDを更新しようとしましたが処理ができませんでした。")
        sbStr.AppendLine(String.Format("オーダー：{0}", ProductInfo.Order))
        sbStr.AppendLine(String.Format("生産計画ID：{0}", ProductInfo.ProductionPlanActualId))
        sbStr.AppendLine(String.Format("ロットNo:{0}", naviBoardIdx + 1))
        sbStr.AppendLine("メニューに戻ります。")
        sbStr.AppendLine("")
        sbStr.AppendLine("数度行っても状況が改善しない場合は、管理者に問い合わせてください。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("仕掛データ生産計画実績ID更新処理異常", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' 作業データ登録異常メッセージ表示
    ''' </summary>
    ''' <param name="naviBoardIdx">
    ''' 登録しようとした基板インデックス番号(0-)
    ''' </param>
    Private Sub DispErrorRegistWorkingData(ByVal naviBoardIdx As Integer)
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("作業データの登録に失敗しました。")
        sbStr.AppendLine(String.Format("NaviBoradIndex={0}", naviBoardIdx))
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("作業データ登録異常", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' 作業中の作業終了確認。
    ''' </summary>
    ''' <returns>
    ''' DialogResult.Yes / DialogResult.No
    ''' </returns>
    Private Function ConfirmTerminateWork() As DialogResult
        Dim sbStr As New System.Text.StringBuilder
        Dim dResult As DialogResult
        sbStr.AppendLine("作業途中ですが、作業を終了しますか？")
        sbStr.AppendLine("「はい」　：作業を終了し、メニューに戻ります。")
        sbStr.AppendLine("「いいえ」：作業に戻ります。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.YesNo)
        FMessageDialog.SetTitleAndMessage("作業途中での終了確認", sbStr.ToString, Color.Yellow)
        dResult = FMessageDialog.ShowDialog()
        Return dResult
    End Function
    ''' <summary>
    ''' 仕掛作業データがありのメッセージ表示
    ''' </summary>
    Private Sub DispExistWorkingData()
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("仕掛作業データがあります。")
        sbStr.AppendLine("指定箇所から作業を再開してください。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("仕掛作業を完了させてください。", sbStr.ToString, Color.Yellow)
        FMessageDialog.ShowDialog()
    End Sub

    ''' <summary>
    ''' プロジェクター電源ＯＦＦの確認メッセージ表示
    ''' </summary>
    Private Sub DispTurnOffProjector()
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("プロジェクタの電源ボタンを押して電源をＯＦＦして下さい。")
        sbStr.AppendLine("　（プロジェクタは、２台あります）")
        sbStr.AppendLine("")
        sbStr.AppendLine("電源ボタンを押すと電源ランプが点滅します。")
        sbStr.AppendLine("しばらくすると電源ランプが点灯に変わります。")
        sbStr.AppendLine("")
        sbStr.AppendLine("プロジェクタの表示が消えたらＯＫボタンを押してください。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("なび画面終了（プロジェクタ電源ＯＦＦ）", sbStr.ToString, Color.Yellow)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' なびモード時にナビデータがない場合のメッセージ表示
    ''' </summary>
    Private Sub DispNoNaviData()
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("なびデータ作成されていません。")
        sbStr.AppendLine("なびデータを作成してください。")
        sbStr.AppendLine("メニューに戻ります。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("なびデータ未作成", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' 仕掛データ数取得失敗時のエラーメッセージ表示
    ''' </summary>
    Private Sub DispErrorGetWorkingData()
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("仕掛データの取得に失敗しました。")
        sbStr.AppendLine("メニューに戻ります。")
        sbStr.AppendLine("")
        sbStr.AppendLine("しばらく時間をおいて再度実行してください。")
        sbStr.AppendLine("状態が改善しない場合は、管理者に問い合わせてください。")
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage("仕掛データ取得異常", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()

    End Sub
    ''' <summary>
    ''' プロジェクター電源ON確認メッセージ表示
    ''' </summary>
    ''' <returns>
    ''' True:Yesボタンが押された(プロジェクターが表示された)　False:Noボタンが押された(プロジェクターが表示されない)
    ''' </returns>
    Private Function ConfirmTurnOnProjector() As Boolean
        Dim dResult As DialogResult
        Dim sbStr As New System.Text.StringBuilder
        sbStr.AppendLine("プロジェクタの電源ボタンを押して下さい。")
        sbStr.AppendLine("　（プロジェクタは、２台あります）")
        sbStr.AppendLine("電源ボタンを押すと電源ランプが点滅します。")
        sbStr.AppendLine("しばらくすると電源ランプが点灯に変わります。")
        sbStr.AppendLine("Windowsの画面が正常に表示されましたか？")
        FMessageDialog.SetButtonsType(MessageBoxButtons.YesNo)
        FMessageDialog.SetTitleAndMessage("プロジェクタ準備", sbStr.ToString, Color.Yellow)
        dResult = FMessageDialog.ShowDialog
        If dResult = DialogResult.No Then
            FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
            sbStr.Clear()
            sbStr.AppendLine("「いいえ」が押されたのでメニューに戻ります。")
            FMessageDialog.SetTitleAndMessage("プロジェクタ表示不良", sbStr.ToString, Color.Yellow)
            FMessageDialog.ShowDialog()
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' システム関連のエラー表示
    ''' </summary>
    ''' <param name="mess">
    ''' エラーメッセージ
    ''' </param>
    ''' <param name="title">
    ''' エラータイトル
    ''' </param>
    Private Sub DispSystemError(ByVal mess As String, ByVal title As String)
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        FMessageDialog.SetTitleAndMessage(title, mess, Color.Red)
        FMessageDialog.ShowDialog()
    End Sub

    ''' <summary>
    ''' 生産ロット数分の作業が完了した場合のメッセージ表示
    ''' </summary>
    Private Sub DispCompleteWorkLot()
        Dim sbStr As New System.Text.StringBuilder
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        sbStr.Clear()
        sbStr.AppendLine(String.Format("{0}枚の生産が完了しました。", ProductionLot))
        sbStr.AppendLine("ナビを終了します。")
        sbStr.AppendLine("「ＯＫ」ボタンを押してください")
        sbStr.AppendLine("")
        sbStr.AppendLine("次のロットを生産するには、「作業開始」ボタンを押して下さい。")
        FMessageDialog.SetTitleAndMessage("作業完了", sbStr.ToString, Color.LimeGreen)
        FMessageDialog.ShowDialog()
    End Sub

    ''' <summary>
    ''' 生産計画数分の作業が完了した場合のメッセージ表示
    ''' </summary>
    Private Sub DispCompleteDailyPlan()
        Dim sbStr As New System.Text.StringBuilder
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        sbStr.Clear()
        sbStr.AppendLine(String.Format("計画枚数の生産が完了しました。", ProductionLot))
        sbStr.AppendLine("ナビを終了します。")
        sbStr.AppendLine("「ＯＫ」ボタンを押してください")
        sbStr.AppendLine("")
        sbStr.AppendLine("メニューに戻ります。")
        FMessageDialog.SetTitleAndMessage("生産計画数の生産が完了しました。", sbStr.ToString, Color.LimeGreen)
        FMessageDialog.ShowDialog()
    End Sub
    Private Sub DispPauseWork()
        Dim sbStr As New System.Text.StringBuilder
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        sbStr.Clear()
        sbStr.AppendLine("作業を中断しています。")
        sbStr.AppendLine("ナビを終了します。")
        sbStr.AppendLine("作業を再開するには「ＯＫ」ボタンを押してください")
        FMessageDialog.SetTitleAndMessage("作業中断中！！", sbStr.ToString, Color.LimeGreen)
        FMessageDialog.ShowDialog()
    End Sub

    ''' <summary>
    ''' プロジェクタの台数が合わない場合のメッセージ表示
    ''' </summary>
    ''' <param name="count">
    ''' 検出したプロジェクタの数量
    ''' </param>
    Private Sub DispInvalidProjectorCount(ByVal count As Integer)
        Dim sbStr As New System.Text.StringBuilder
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        sbStr.Clear()
        sbStr.AppendLine("プロジェクタが接続されているか確認して下さい。")
        sbStr.AppendLine("プロジェクタは、２台使用します。")
        sbStr.AppendLine(String.Format("プロジェクタ検出台数：{0}", count))
        sbStr.AppendLine("")
        sbStr.AppendLine("メニューに戻ります。")
        FMessageDialog.SetTitleAndMessage("プロジェクタ検出異常", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()
    End Sub
    ''' <summary>
    ''' プロジェクタの解像度が異なる場合のメッセージ表示
    ''' </summary>
    Private Sub DispDifferentResolution()
        Dim sbStr As New System.Text.StringBuilder
        FMessageDialog.SetButtonsType(MessageBoxButtons.OK)
        sbStr.AppendLine("プロジェクターの解像度が異なります。")
        sbStr.AppendLine("２台の解像度を同じに設定してください。")
        sbStr.AppendLine("メニューに戻ります。")
        FMessageDialog.SetTitleAndMessage("プロジェクタ解像度設定異常", sbStr.ToString, Color.Red)
        FMessageDialog.ShowDialog()
    End Sub
    ''' <summary>
    ''' ProjectorSettingDataを設定する。
    ''' 接続されているプロジェクタの情報を基にProjectorSettingData.FormSizeおよびProjectorSettingData.Posiを設定する。
    ''' </summary>
    ''' <returns>
    ''' True:データ設定OK　False:データ設定異常（プロジェクタの解像度が異なる。プロジェクタの数が異なる）
    ''' </returns>
    Private Function SetProjectorSettingData() As Boolean
        ProjectorSettingData.BoardHeight = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardHeight))
        ProjectorSettingData.BoardWidth = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardWidth))
        ProjectorSettingData.MaxBoroadNum = TbDrawing.Rows(0)(DITColumnName(DITColmun.MaxLot))
        ProjectorSettingData.ProjectionWidth = PartsInsertNaviAppConfigData.ProjectorWidth
        ProjectorSettingData.ProjectionHeight = PartsInsertNaviAppConfigData.ProjectorHeight

        Dim s As System.Windows.Forms.Screen
        'X座標の初期値は、わざと３画面分より大きな値を設定
        ProjectorSettingData.Posi.Y = 0
        ProjectorSettingData.Posi.X = 6000
        ProjectorSettingData.FormSize.Width = 0
        ProjectorSettingData.FormSize.Height = 0
        Dim projecterCount As Integer = 0
        '接続されているモニタ全ての情報からプロジェクターのサイズ・位置を算出する。
        'PCのモニタはプライマリスクリーンとし、一番左側に配置する。
        'PC：プロジェクタ１：プロジェクタ２の順とする。
        Dim pd As String = System.Windows.Forms.Screen.PrimaryScreen.DeviceName

        For Each s In System.Windows.Forms.Screen.AllScreens
            If s.DeviceName <> pd Then
                projecterCount += 1
                'プライマリ以外のスクリーン
                If s.Bounds.X < ProjectorSettingData.Posi.X Then
                    ProjectorSettingData.Posi.X = s.Bounds.X
                End If
                ProjectorSettingData.FormSize.Width += s.Bounds.Width
                If (ProjectorSettingData.FormSize.Height <> 0) AndAlso (ProjectorSettingData.FormSize.Height <> s.Bounds.Height) Then
                    DispDifferentResolution()
                    Return False
                End If
                ProjectorSettingData.FormSize.Height = s.Bounds.Height
            End If
        Next

        If projecterCount = 2 Then
            Return True
        Else
            DispInvalidProjectorCount(projecterCount)
            Return False
        End If
    End Function
    ''' <summary>
    ''' フォーム上のコントロールの状態をmodeに合わせ変更する。
    ''' </summary>
    ''' <param name="mode">
    ''' フォームのモード(FormNaviMode列挙体で指定)
    ''' </param>
    Private Sub ChangeContrlMode(ByVal mode As Integer)
        Select Case OpenFormMode
            Case FormNaviMode.Edit
                SetNavidataEditControlVisible(True)
                SetOrderInfoControlEnable(False)
            Case FormNaviMode.Navi
                SetNavidataEditControlVisible(False)
                SetOrderInfoControlEnable(True)
        End Select
    End Sub
    Private Sub EnableStepEditButton(ByVal isEnable As Boolean)
        ButtonUpStep.Enabled = isEnable
        ButtonDownStep.Enabled = isEnable
    End Sub
    ''' <summary>
    ''' なびデータ編集用コントロールの表示/非表示を切り替える
    ''' </summary>
    ''' <param name="visibleStatus">
    ''' True:コントロールを表示　False:コントロールを非表示
    ''' </param>
    Private Sub SetNavidataEditControlVisible(ByVal visibleStatus As Boolean)
        ButtonRegistData.Visible = visibleStatus
        CheckBoxEditStep.Visible = visibleStatus
        ButtonUpStep.Visible = visibleStatus
        ButtonDownStep.Visible = visibleStatus
        ButtonAddNaviData.Visible = visibleStatus
        ButtonEditPartsShape.Visible = visibleStatus
        ButtonOpenEditPartsMaster.Visible = visibleStatus
        ButtonEditPartsShape.Visible = visibleStatus
    End Sub
    Private Sub SetOrderInfoControlEnable(ByVal isEnable As Boolean)
        GroupBoxOrderInfo.Enabled = isEnable
        GroupBoxOperationControl.Enabled = isEnable
        GroupBoxNaviBoardNo.Enabled = isEnable
    End Sub

    ''' <summary>
    ''' CtrlDbNaviDataに設定されたナビDB情報を基に、ナビデータを全て取得する。
    ''' CtrlDbNaviDataにアクセスするDBの情報を事前に設定する必要あり。
    ''' </summary>
    ''' <returns></returns>
    Private Function GetNaviDataTable() As DataTable

        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbNaviData.DefNaviDb.TableNaviData)
        sbSql.AppendLine("WHERE")
        sbSql.AppendLine(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName) & "=TRUE")
        sbSql.AppendLine("AND")
        sbSql.AppendLine(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName) & "=FALSE")

        sbSql.AppendLine("ORDER BY")
        sbSql.AppendLine(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName))
        Dim connectString As String = CtrlDbNaviData.GetMasterDbConnectString
        Return CtrlDbNaviData.GetTableData(sbSql.ToString, connectString)

    End Function
    ''' <summary>
    ''' CtrlDbNaviDataに設定されたナビDB情報を基に、編集用ナビデータを全て取得する。
    ''' CtrlDbNaviDataにアクセスするDBの情報を事前に設定する必要あり。
    ''' </summary>
    ''' <returns></returns>
    Private Function GetEditNaviDataTable() As DataTable

        Dim sbSql As New System.Text.StringBuilder
        sbSql.AppendLine("SELECT")
        sbSql.AppendLine("*")
        sbSql.AppendLine("FROM")
        sbSql.AppendLine(CtrlDbNaviData.DefNaviDb.TableNaviData)
        'sbSql.AppendLine("WHERE")
        'sbSql.AppendLine(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName) & "=TRUE")

        sbSql.AppendLine("ORDER BY")
        sbSql.AppendLine(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName))
        Dim connectString As String = CtrlDbNaviData.GetMasterDbConnectString
        Return CtrlDbNaviData.GetTableData(sbSql.ToString, connectString)

    End Function

    ''' <summary>
    ''' 基板図面情報をテキストボックスに設定する。
    ''' </summary>
    Private Sub SetDrawingInfoToTextBox()
        TextBoxId.Text = TbDrawing.Rows(0)(DITColumnName(DITColmun.Id))
        TextBoxDrawingNo.Text = TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingNumber))

        If TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingRevision)) IsNot DBNull.Value Then
            TextBoxRevision.Text = TbDrawing.Rows(0)(DITColumnName(DITColmun.DrawingRevision))
        End If
        If TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardName)) IsNot DBNull.Value Then
            TextBoxBoardName.Text = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardName))
        End If

        If TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardWidth)) IsNot DBNull.Value Then
            BoardSize.Width = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardWidth))
            TextBoxBoardWidth.Text = BoardSize.Width.ToString
        End If
        If TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardHeight)) IsNot DBNull.Value Then
            BoardSize.Height = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardHeight))
            TextBoxBoardHeight.Text = BoardSize.Height.ToString
        End If
        If TbDrawing.Rows(0)(DITColumnName(DITColmun.MaxLot)) IsNot DBNull.Value Then
            TextBoxMaxLot.Text = TbDrawing.Rows(0)(DITColumnName(DITColmun.MaxLot))
            BoardSize.Height = TbDrawing.Rows(0)(DITColumnName(DITColmun.BoardHeight))
        End If

        TextBoxShogenhyoFilename.Text = GetDrawingAttachedFileName(PartsInsertNaviAppConfigData.SystemDataPath.Drawing,
                                                                   DrawingNumber,
                                                                   DrawingRevision,
                                                                   DrawingSubFolder.Shogenhyou
                                                                   )
        TextBoxNetlistFilename.Text = GetDrawingAttachedFileName(PartsInsertNaviAppConfigData.SystemDataPath.Drawing,
                                                                 DrawingNumber,
                                                                 DrawingRevision,
                                                                 DrawingSubFolder.NetList
                                                                 )

    End Sub
    ''' <summary>
    ''' なび用データグリッドビュー（DataGridViewNavidata）の列をmodeに合わせて設定する。
    ''' </summary>
    ''' <param name="mode">
    ''' フォームのモード(FormNaviMode列挙体で指定)
    ''' </param>
    Private Sub SetNaviDgvColumn(ByVal mode As Integer)
        DataGridViewNavidata.AutoGenerateColumns = False
        Select Case mode
            Case FormNaviMode.Edit
                SetEditModeDgvColumn()
            Case FormNaviMode.Navi
                SetNaviModeDgvColumn()
                SetNaviModeDgvColumnWidth()
        End Select

    End Sub
    ''' <summary>
    ''' なびデータ編集モード用DataGridView列設定
    ''' </summary>
    Private Sub SetEditModeDgvColumn()

        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 True)
        CtrlDgv.AddCheckBoxColumn(DataGridViewNavidata,
                                  NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName)
                                  )
        CtrlDgv.AddCheckBoxColumn(DataGridViewNavidata,
                                  NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)
                                  )
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
                                 True)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName),
                                 True)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName),
                                 True)

        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 False)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 False)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName),
                                 False)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName),
                                 False)
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName),
                                 False)


        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 False)

        CtrlDgv.AddCheckBoxColumn(DataGridViewNavidata,
                                  NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName),
                                  NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName)
                                  )

        For i As Integer = NVDTColumn.RegistDate To NVDTColumn.UpdateManNumber
            CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 True)

        Next

    End Sub
    ''' <summary>
    ''' なびモード用DataGridView列設定
    ''' </summary>
    Private Sub SetNaviModeDgvColumn()
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                 True)
        'CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
        '                         NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
        '                         NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
        '                         NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName),
        '                         True)
        For i As Integer = NVDTColumn.NaviStep To NVDTColumn.Rotate
            CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 NVDTColumnInfo(i, ElementType.ColumnName),
                                 True)

        Next
        CtrlDgv.AddTextboxColumn(DataGridViewNavidata,
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName),
                                 True)


    End Sub
    Private Sub SetNaviModeDgvColumnWidth()
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)).Width = 100
        DataGridViewNavidata.Columns(NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName)).Width = 1000

    End Sub
    ''' <summary>
    ''' 同一部材コードの諸元表示用DataGridView列設定
    ''' </summary>
    Private Sub SetSamePartsDgvColum()
        '列が自動的に作成されないようにする
        DataGridViewSamePartsCode.AutoGenerateColumns = False
        CtrlDgv.AddTextboxColumn(DataGridViewSamePartsCode,
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName),
                                 True)
        CtrlDgv.AddTextboxColumn(DataGridViewSamePartsCode,
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName),
                                 True)
    End Sub

    ''' <summary>
    ''' 同一部材コードのなびデータテーブルを取得する。
    ''' </summary>
    ''' <param name="dtNavidata">
    ''' なびデータテーブル
    ''' </param>
    ''' <param name="partsCode">
    ''' 部材コード
    ''' </param>
    ''' <returns>
    ''' なびデータテーブルに部材コードでフィルタをかけた結果のデータテーブル
    ''' </returns>
    Private Function GetSamePatsCodeData(ByVal dtNavidata As DataTable, ByVal partsCode As String) As DataTable
        Dim dtCopy As DataTable = dtNavidata.Copy
        Dim dvNavidata As DataView = dtCopy.DefaultView
        dvNavidata.RowFilter = NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName) & "='" & partsCode & "'"
        Dim dtSamaPatsCode As DataTable = dvNavidata.ToTable
        Return dtSamaPatsCode
    End Function

    ''' <summary>
    ''' 選択ステップのナビデータ取得
    ''' </summary>
    ''' <param name="dtNavidata">
    ''' なびデータテーブル
    ''' </param>
    ''' <param name="selectedStep">
    ''' 選択ステップ
    ''' </param>
    ''' <returns></returns>
    Private Function GetNaviData(ByVal dtNavidata As DataTable, ByVal selectedStep As Integer) As DataTable
        Dim dtCopy As DataTable = dtNavidata.Copy
        Dim dvNavidata As DataView = dtCopy.DefaultView
        dvNavidata.RowFilter = NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName) & "='" & selectedStep & "'"
        Dim dtSamePatsCode As DataTable = dvNavidata.ToTable
        Return dtSamePatsCode

    End Function
    ''' <summary>
    ''' なびパーツ形状の描画処理
    ''' </summary>
    ''' <param name="samePartsCodePicbox">
    ''' 同一部材コードの形状描画用PictureBox
    ''' </param>
    ''' <param name="selectedPartsPicbox">
    ''' 選択部材コードの形状描画用PictureBox
    ''' </param>
    ''' <param name="partShapeDatarow">
    ''' 部材形状データ
    ''' </param>
    ''' <param name="tbSamePartsCode">
    ''' 同一部材コードのみのなびデータテーブル
    ''' </param>
    ''' <param name="selectedStep">
    ''' 選択ステップ
    ''' </param>
    Private Sub DrawNaviPartsShapes(ByRef samePartsCodePicbox As PictureBox, ByRef selectedPartsPicbox As PictureBox, ByVal partShapeDatarow As DataRow, ByVal tbSamePartsCode As DataTable, ByVal selectedStep As Integer)
        '描画図形情報リスト
        Dim SamePartsCodeDrawShapeList As New List(Of DrawShapeInfo)
        Dim SelectedDrawShapeList As New List(Of DrawShapeInfo)

        '描画キャンバスサイズ
        Dim cSamePartsCodePicboxSize As New DoubleSize
        Dim cSelectedPartsPicboxSize As New DoubleSize

        '描画キャンバスの原点位置指定
        Dim cSameParsCodeOriginAlign As Integer = Align.BottomLeft
        Dim cSelectedParsOriginAlign As Integer = Align.BottomLeft

        cSamePartsCodePicboxSize.Width = CType(samePartsCodePicbox.Width, Double)
        cSamePartsCodePicboxSize.Height = CType(samePartsCodePicbox.Height, Double)

        cSelectedPartsPicboxSize.Width = CType(selectedPartsPicbox.Width, Double)
        cSelectedPartsPicboxSize.Height = CType(selectedPartsPicbox.Height, Double)

        For Each row As DataRow In tbSamePartsCode.Rows
            '描画位置構造体
            Dim drawPosi As New DrawPosition
            '描画図形データ
            Dim pShapeData As New PartsShapeData

            drawPosi.X = row(NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName))
            drawPosi.Y = row(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName))

            pShapeData.SetShapeData(partShapeDatarow)
            Dim navilStep As Integer = row(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName))
            '部品形状データ作成
            If navilStep = selectedStep Then
                SelectedDrawShapeList.Add(New DrawShapeInfo(cSelectedPartsPicboxSize, cSelectedParsOriginAlign, drawPosi, row(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)), pShapeData))
            Else
                SamePartsCodeDrawShapeList.Add(New DrawShapeInfo(cSamePartsCodePicboxSize, cSameParsCodeOriginAlign, drawPosi, row(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)), pShapeData))
            End If

        Next

        Dim drawSelectedPartsShape As New DrawPartsShape(DrawParsStatus.MonitorSelectedParts)
        Dim drawSamePartsCodeShape As New DrawPartsShape(DrawParsStatus.MonitorSamePartsCode)
        drawSamePartsCodeShape.SetDrawRatio(DrawRatio, DrawRatio)
        drawSamePartsCodeShape.Draw(samePartsCodePicbox, SamePartsCodeDrawShapeList, True, cSameParsCodeOriginAlign, False)

        drawSelectedPartsShape.SetDrawRatio(DrawRatio, DrawRatio)
        drawSelectedPartsShape.Draw(selectedPartsPicbox, SelectedDrawShapeList, True, cSelectedParsOriginAlign, False)

        If OpenFormMode = FormNaviMode.Navi Then
            drawSamePartsCodeShape.SetDrawingColor(DrawParsStatus.ProjectorSamePartsCode)
            drawSelectedPartsShape.SetDrawingColor(DrawParsStatus.ProjectorSelectedParts)
            drawSamePartsCodeShape.SetMarkColor(DrawParsStatus.ProjectorSamePartsCode)
            drawSelectedPartsShape.SetMarkColor(DrawParsStatus.ProjectorSelectedParts)

            drawSamePartsCodeShape.SetDrawRatio(ProjectorSettingData.DispRatio, ProjectorSettingData.DispRatio)
            drawSelectedPartsShape.SetDrawRatio(ProjectorSettingData.DispRatio, ProjectorSettingData.DispRatio)
            For i As Integer = 0 To FormProjecter.PictBoxList.Count - 1
                drawSamePartsCodeShape.Draw(FormProjecter.PictBoxList(i)(PictboxItem.AllParts), SamePartsCodeDrawShapeList, True, cSameParsCodeOriginAlign, True)
                drawSelectedPartsShape.Draw(FormProjecter.PictBoxList(i)(PictboxItem.SelParts), SelectedDrawShapeList, True, cSelectedParsOriginAlign, False)
            Next
        End If

    End Sub
    Private Sub DrawBoardSettingPosition(ByVal boardCount As Integer)
        Dim drawSelectedPartsShape As New DrawPartsShape(DrawParsStatus.ProjectorSelectedParts)
        Dim drawSamePartsCodeShape As New DrawPartsShape(DrawParsStatus.ProjectorSamePartsCode)
        Dim SamePartsCodeDrawShapeList As New List(Of DrawShapeInfo)
        Dim SelectedDrawShapeList As New List(Of DrawShapeInfo)

        drawSamePartsCodeShape.SetDrawingColor(DrawParsStatus.ProjectorSamePartsCode)
        drawSelectedPartsShape.SetDrawingColor(DrawParsStatus.ProjectorSelectedParts)
        drawSamePartsCodeShape.SetMarkColor(DrawParsStatus.ProjectorSamePartsCode)
        drawSelectedPartsShape.SetMarkColor(DrawParsStatus.ProjectorSelectedParts)

        drawSamePartsCodeShape.SetDrawRatio(ProjectorSettingData.DispRatio, ProjectorSettingData.DispRatio)
        drawSelectedPartsShape.SetDrawRatio(ProjectorSettingData.DispRatio, ProjectorSettingData.DispRatio)

        For i As Integer = 0 To boardCount - 1
            drawSamePartsCodeShape.Draw(FormProjecter.PictBoxList(i)(PictboxItem.AllParts), SamePartsCodeDrawShapeList, True, Align.BottomLeft, True)
            drawSelectedPartsShape.Draw(FormProjecter.PictBoxList(i)(PictboxItem.SelParts), SelectedDrawShapeList, True, Align.BottomLeft, False)
        Next

        DrawNoteStringToAllPartsPictrueBox("基板をセットしてください。", True)

    End Sub
    Private Sub ClearAllPartsPictureBox()
        Dim canvas As Bitmap = New Bitmap(PictureBoxAllParts.Width, PictureBoxAllParts.Height)

        PictureBoxAllParts.Image = canvas

    End Sub
    Private Sub ClearSelectedPartsPictureBox()
        Dim canvas As Bitmap = New Bitmap(PictureBoxPresentParts.Width, PictureBoxPresentParts.Height)

        PictureBoxPresentParts.Image = canvas

    End Sub

    ''' <summary>
    ''' PictureBoxAllPartsのイメージを取得し、messStrの文字列を表示する。
    ''' 表示位置は、isMessPosiBottomで指定
    ''' </summary>
    ''' <param name="messStr">
    ''' 表示したい文字列
    ''' </param>
    ''' <param name="isMessPosiBottom">
    ''' True:下段表示　False:上段表示
    ''' </param>
    Private Sub DrawNoteStringToAllPartsPictrueBox(ByVal messStr As String, ByVal isMessPosiBottom As Boolean)
        Dim canvas As Bitmap
        If PictureBoxAllParts.Image IsNot Nothing Then
            canvas = PictureBoxAllParts.Image
        Else
            canvas = New Bitmap(PictureBoxAllParts.Width, PictureBoxAllParts.Height)
        End If
        Dim g As Graphics = Graphics.FromImage(canvas)

        'フォントオブジェクトの作成
        Dim fontSize As Single = CSng(30 * DrawRatio)
        Dim fnt As New Font("MS UI Gothic", fontSize)
        Dim drawPoint As New Point

        If isMessPosiBottom = True Then
            drawPoint.X = 0
            drawPoint.Y = PictureBoxAllParts.Height - CInt(PictureBoxAllParts.Height * NaviMessageTextHeightRatio)
        Else
            drawPoint.X = 0
            drawPoint.Y = CInt(10 * DrawRatio)
        End If
        Dim w As Integer = PictureBoxAllParts.Width - NaviMessageTextOffsetY
        Dim h As Integer = CInt(PictureBoxAllParts.Height * NaviMessageTextHeightRatio)

        Dim rect As New RectangleF(drawPoint.X, drawPoint.Y, w, h)
        Using messBackcolorBrush As SolidBrush = New SolidBrush(Color.FromArgb(100, Color.White))
            g.FillRectangle(messBackcolorBrush, rect)
        End Using
        g.DrawString(messStr, fnt, Brushes.Red, rect)

        fnt.Dispose()
        g.Dispose()

        PictureBoxAllParts.Image = canvas
    End Sub
    Private Sub FormEditNavidata_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        RedrawNaviPartsShapes()
    End Sub
    Private Sub FormEditNavidata_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        RedrawNaviPartsShapes()
    End Sub
    ''' <summary>
    ''' なび図形再描画処理
    ''' </summary>
    Private Sub RedrawNaviPartsShapes()
        If IsFormInitializing = True Then
            Exit Sub
        End If

        PictureboxDispRatio = GetPictureboxDispRatio(BoardImageSize, PictureBoxBoard.Size, IsWidthBaseDraw)
        SetImageToPictureBoxBottmLeft(PictureBoxBoard, AttachedFile.BoardImage, PictureboxDispRatio)
        DrawRatio = GetDrawRatio(PictureBoxBoard, BoardSize.Width, BoardSize.Height, IsWidthBaseDraw)
        If 0 < DataGridViewNavidata.SelectedRows.Count Then
            If DrawNaviData(SelectedPartsCode, SelectedNaviStep) = True Then
                SetNaviMessage()
            End If
        End If

    End Sub
    Private Sub DataGridViewNavidata_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewNavidata.RowEnter
        If IsFormInitializing = True Then
            Exit Sub
        End If

        If e.RowIndex < 0 Then Exit Sub

        SelectedRowIndex = e.RowIndex

        Select Case OpenFormMode
            Case FormNaviMode.Edit
                If CheckBoxEditStep.Checked = False Then
                    DispNaviDataMain(SelectedRowIndex)
                Else
                    PictureBoxAllParts.Image = Nothing
                    PictureBoxPresentParts.Image = Nothing
                End If
            Case FormNaviMode.Navi
                DispNaviDataMain(SelectedRowIndex)
        End Select
    End Sub
    ''' <summary>
    ''' ナビデータ表示メイン処理
    ''' </summary>
    ''' <param name="rowIndex">
    ''' DataGridViewNavidataの選択行インデックス
    ''' </param>
    Private Sub DispNaviDataMain(ByVal rowIndex As Integer)
        If IsFormInitializing = True Then
            Exit Sub
        End If
        If rowIndex < 0 Then
            Exit Sub
        End If
        Dim isNoNaviData As Boolean = True
        If IsFormShown = True Then
            If DataGridViewNavidata(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName), rowIndex).Value IsNot DBNull.Value Then
                PreviousPartsCode = SelectedPartsCode
                isNoNaviData = False
            Else
                '部材コード設定画面を表示する？
                isNoNaviData = True
            End If
        End If
        If isNoNaviData = True Then
            MessageBox.Show("ナビデータを設定してください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        SelectedPartsCode = DataGridViewNavidata(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName), rowIndex).Value

        SelectedNaviStep = DataGridViewNavidata(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName), rowIndex).Value
        SetPartsTabInfomation()
        SetSamePartsCodeDgv(SelectedPartsCode, SelectedNaviStep)
        If DrawNaviData(SelectedPartsCode, SelectedNaviStep) = True Then
            SetNaviMessage()
        End If

    End Sub

    ''' <summary>
    ''' 部材データタブのデータ設定処理
    ''' </summary>
    Private Sub SetPartsTabInfomation()
        If PreviousPartsCode <> SelectedPartsCode Then
            DtSelectedPartsCodeData = CtrlDbPartsMaster.GetPartsOneDataFromTable(SelectedPartsCode)

            If 0 < DtSelectedPartsCodeData.Rows.Count Then
                PictureBoxPartsImage.Image = Nothing
                SetKankotsuFileListBox(SelectedPartsCode, ListBoxKankotsuFile)
                SetPartsImageFileListBox(SelectedPartsCode)

                If DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.Note)) IsNot DBNull.Value Then
                    TextBoxNote.Text = DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.Note))
                Else
                    TextBoxNote.Text = Nothing
                End If
                If DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.PartsName)) IsNot DBNull.Value Then
                    TextBoxPartsName.Text = DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.PartsName))
                Else
                    TextBoxPartsName.Text = Nothing
                End If

                If DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.ModelName)) IsNot DBNull.Value Then
                    TextBoxModelName.Text = DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.ModelName))
                Else
                    TextBoxModelName.Text = Nothing
                End If
            Else
                ClearPartsTabInfomation()
            End If
        End If
    End Sub
    Private Sub ClearPartsTabInfomation()
        PictureBoxPartsImage.Image = Nothing
        ListBoxKankotsuFile.Items.Clear()
        ListBoxPartsImage.Items.Clear()
        TextBoxNote.Text = Nothing
        TextBoxPartsName.Text = Nothing
        TextBoxModelName.Text = Nothing
    End Sub


    ''' <summary>
    ''' 選択しているステップの部品及びその部品と同一部材コードの図形を描画する。
    ''' </summary>
    ''' <param name="partsCode">
    ''' 選択しているステップの部材コード
    ''' </param>
    ''' <param name="selStep">
    ''' 選択ステップ番号
    ''' </param>
    Private Function DrawNaviData(ByVal partsCode As String, ByVal selStep As Integer) As Boolean
        Dim sbMessage As New System.Text.StringBuilder
        Dim dResult As DialogResult

        TextBoxPartsCode.Text = partsCode
        Dim isExistPartsCodeData As Boolean = CtrlDbPartsMaster.IsExistPartsCode(partsCode)

        If isExistPartsCodeData = False Then
            sbMessage.Clear()
            sbMessage.AppendLine("部材コード：" & partsCode & "が部材マスタに登録されていません。")
            sbMessage.AppendLine("部材マスタ編集画面でデータを登録してください。")
            sbMessage.AppendLine("")
            sbMessage.AppendLine("<<<なび不要の場合、登録の必要はありません>>>")
            sbMessage.AppendLine("")
            MessageBox.Show(sbMessage.ToString, "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        TbPartsShapeData = CtrlDbMaster.GetShapeDataByPartsCode(partsCode)
        Dim regResult As DialogResult

        If TbPartsShapeData.Rows.Count = 0 Then
            sbMessage.Clear()
            sbMessage.AppendLine("部材コード：" & partsCode & "に部品形状データが設定されていません。")
            sbMessage.AppendLine("部材マスタ画面でデータを登録してください。")
            sbMessage.AppendLine("部材マスタ編集画面を表示しますか？")
            dResult = MessageBox.Show(sbMessage.ToString, "メッセージ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = DialogResult.Yes Then
                Dim fm As FormEditPartsData = New FormEditPartsData(False, partsCode, CtrlDbMaster, CtrlDbPartsMaster)
                regResult = fm.ShowDialog()
                If fm IsNot Nothing Then
                    fm.Dispose()
                End If
                If regResult <> DialogResult.OK Then Return False
                TbPartsShapeData = CtrlDbMaster.GetShapeDataByPartsCode(partsCode)
            Else
                Return False
            End If
        End If
        DrawNaviPartsShapes(PictureBoxAllParts, PictureBoxPresentParts, TbPartsShapeData.Rows(0), TbSamePartsCodeNaviData, selStep)
        Return True
    End Function
    ''' <summary>
    ''' 同一部材コードの情報をDataGridViewSamePartsCodeに設定する。
    ''' </summary>
    ''' <param name="partsCode">
    ''' DataGridViewSamePartsCodeに設定した部材コード
    ''' </param>
    ''' <param name="selStep">
    ''' 現在選択しているナビステップ番号
    ''' </param>
    Private Sub SetSamePartsCodeDgv(ByVal partsCode As String, ByVal selStep As Integer)
        TbSamePartsCodeNaviData = GetSamePatsCodeData(TbNaviData, partsCode)
        TbSelectedNaviData = GetNaviData(TbNaviData, selStep)

        DataGridViewSamePartsCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewSamePartsCode.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridViewSamePartsCode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        CtrlDgv.BindTableToDgv(DataGridViewSamePartsCode, TbSamePartsCodeNaviData)

        DataGridViewSamePartsCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewSamePartsCode.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridViewSamePartsCode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize


    End Sub

    ''' <summary>
    ''' 部材備考・ナビ備考をPictureBoxPresentPartsに描画する。
    ''' </summary>
    Private Sub SetNaviMessage()
        Dim sumColName As String = NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName)
        TextBoxTotalUseCount.Text = TbSamePartsCodeNaviData.Compute("SUM(" & sumColName & ")", Nothing).ToString

        Dim maxPosiY As Double = 0
        Dim minPosiY As Double = 1000

        For Each row As DataRow In TbSamePartsCodeNaviData.Rows
            Dim posiY As Double = row(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName))
            If posiY < minPosiY Then
                minPosiY = posiY
            End If
            If maxPosiY < posiY Then
                maxPosiY = posiY
            End If
        Next
        Dim difTopFromMaxY As Double = BoardSize.Height - maxPosiY
        Dim difBotttomFromMinY As Double = minPosiY
        Dim isMessPosiBottom As Boolean = False

        If difTopFromMaxY < difBotttomFromMinY Then
            isMessPosiBottom = True
        Else
            isMessPosiBottom = False
        End If

        Dim naviMessage As String = Nothing
        If DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.Note)) IsNot DBNull.Value AndAlso
           DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.Note)) <> "" Then
            naviMessage = "部材備考：" & DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.Note))
        Else
            naviMessage = Nothing
        End If
        If TbSelectedNaviData.Rows(0)(NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName)) IsNot DBNull.Value AndAlso
           TbSelectedNaviData.Rows(0)(NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName)) <> "" Then
            If naviMessage <> "" Then
                naviMessage &= vbCrLf
            End If
            naviMessage &= "挿入備考：" & TbSelectedNaviData.Rows(0)(NVDTColumnInfo(NVDTColumn.Note, ElementType.ColumnName))
        End If
        If naviMessage <> "" Then
            DrawNoteStringToAllPartsPictrueBox(naviMessage, isMessPosiBottom)
        End If


    End Sub


    ''' <summary>
    ''' デバッグ用
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sbMess As New System.Text.StringBuilder
        Dim canvas As New Bitmap(PictureBoxBoard.Width, PictureBoxBoard.Height)
        Dim allGraphics As Graphics = Graphics.FromImage(canvas)

        Dim canvasMillimeterWidth As Double = canvas.Width / allGraphics.DpiX * ConvetInchiToMillimeter
        Dim canvasMillimeterHeight As Double = canvas.Height / allGraphics.DpiY * ConvetInchiToMillimeter

        sbMess.AppendLine("canvasMillimeterWidth:" & canvasMillimeterWidth.ToString("0.00"))
        sbMess.AppendLine("canvasMillimeterHeight:" & canvasMillimeterHeight.ToString("0.00"))

        sbMess.AppendLine("PictureboxDispRatio:" & PictureboxDispRatio.ToString("0.00"))
        sbMess.AppendLine("DrawRatio:" & DrawRatio.ToString("0.00"))
        If FormProjecter IsNot Nothing Then
            sbMess.AppendLine("DispProjector")
            For i As Integer = 0 To FormProjecter.PictBoxList.Count - 1
                For j = 0 To 1
                    sbMess.AppendLine(String.Format("({0},{1}):TOP={2}/Left={3})", i, j, FormProjecter.PictBoxList(i)(j).Top, FormProjecter.PictBoxList(i)(j).Left))
                Next
            Next
            sbMess.AppendLine("")
            For i As Integer = 0 To FormProjecter.PictBoxList.Count - 1
                For j = 0 To 1
                    sbMess.AppendLine(String.Format("({0},{1}):Width={2}/Height={3})", i, j, FormProjecter.PictBoxList(i)(j).Width, FormProjecter.PictBoxList(i)(j).Height))
                Next
            Next

        End If


        TextBox1.Text = sbMess.ToString
        allGraphics.Dispose()
        canvas.Dispose()

    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        DebugMessage.Clear()
    End Sub

    Private Sub TimerFlicker_Tick(sender As Object, e As EventArgs) Handles TimerFlicker.Tick
        If IsFormInitializing = True Then
            Exit Sub
        End If
        PictureBoxPresentParts.Visible = Not PictureBoxPresentParts.Visible
    End Sub
    ''' <summary>
    ''' partsCodeで指定された部材のImageデータに添付されたファイル名をリストボックスに設定する。
    ''' ファイルが１つ以上ある場合は、Index=0の画像をListBoxPartsImageに表示する。
    ''' </summary>
    ''' <param name="partsCode"></param>
    Private Sub SetPartsImageFileListBox(ByVal partsCode As String)
        Dim partsImageFolder As String = Nothing

        If partsCode <> Nothing Then
            partsImageFolder = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
            If System.IO.Directory.Exists(partsImageFolder) = True Then
                PartsImageFileList = GetAllFileList(partsImageFolder)
                ListBoxPartsImage.Items.Clear()

                For Each file As String In PartsImageFileList
                    ListBoxPartsImage.Items.Add(file)
                Next
                If 0 < ListBoxPartsImage.Items.Count Then
                    ListBoxPartsImage.SelectedIndex = 0
                End If
            Else
                ListBoxPartsImage.Items.Clear()
            End If
        Else
            ListBoxPartsImage.Items.Clear()
        End If
    End Sub

    Private Sub ListBoxPartsImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPartsImage.SelectedIndexChanged
        If IsFormInitializing = True Then
            Exit Sub
        End If

        ListBoxPartsImageSelectedIndexChange(ListBoxPartsImage, PictureBoxPartsImage, SelectedPartsCode, Nothing)

    End Sub

    Private Sub ButtonOpenKankotsuFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenKankotsuFile.Click
        OpenKankotsuFileSelectByListBox(ListBoxKankotsuFile)
        ActiveControl = ButtonStartProduction

    End Sub


    Private Sub ButtonOpenPartsImageFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenPartsImageFile.Click
        If SelectedPartsCode <> Nothing Then
            OpenPartsImageFileSelectByListBox(ListBoxPartsImage, SelectedPartsCode)
        End If
        ActiveControl = ButtonStartProduction
    End Sub

    Private Sub ButtonAddNaviData_Click(sender As Object, e As EventArgs) Handles ButtonAddNaviData.Click
        Dim drow As DataRow = TbNaviData.NewRow
        Dim insertRowStep As Integer = TbNaviData.Rows(SelectedRowIndex)(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName))

        drow(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)) = insertRowStep
        drow(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName)) = True
        TbNaviData.Rows.InsertAt(drow, SelectedRowIndex)
        insertRowStep += 1
        For i As Integer = SelectedRowIndex To TbNaviData.Rows.Count - 1
            TbNaviData.Rows(i)(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)) = insertRowStep
            insertRowStep += 1
        Next
    End Sub

    Private Sub CheckBoxEditStep_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEditStep.CheckedChanged
        EnableStepEditButton(CheckBoxEditStep.Checked)
        If OpenFormMode <> FormNaviMode.Edit Then
            Exit Sub
        End If
        If CheckBoxEditStep.Checked = True Then
            TimerFlicker.Enabled = False
        Else
            TimerFlicker.Enabled = True
        End If
    End Sub

    Private Sub FormEditNavidata_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If FormProjecter IsNot Nothing Then
            FormProjecter.Dispose()
        End If
    End Sub


    Private Sub ButtonStartProduction_Click(sender As Object, e As EventArgs) Handles ButtonStartProduction.Click
        Dim sts As Integer = NaviStatus.OK
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        If IsStartProduction = True Then
            Exit Sub
        End If

        BoardSerialList.Clear()
        sts = IsExistWorkingData()
        If (sts <> NaviStatus.ExistWorkingData) AndAlso (sts <> NaviStatus.NoExistWorkingData) Then
            Me.Close()
            Exit Sub
        End If
        TimerDispWorkTime.Enabled = True
        LotWorkStartDate = DateTime.Now

        If sts = NaviStatus.ExistWorkingData Then
            '仕掛あり
            SumPreviousWorktime = GetSumWorkTimeWorkingData()
            IsStartProduction = True
            '仕掛作業再開行の特定
            SetNaviPosition()
            SetProductionLotLabel()
            DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, NaviRowIndex)
            WorkStartDate = DateTime.Now
            SetWorkStartDateToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
            If RegistWorkingDataToDb(NaviBoradIndex) = False Then
                DispErrorRegistWorkingData(NaviBoradIndex)
            End If
            If FormProjecter IsNot Nothing Then
                FormProjecter.ChangeTick(True)
                FormProjecter.ChangeNaviBoard(NaviBoradIndex)
            End If

        Else
            '仕掛なし
            If IsStartProduction = False Then
                '仕掛データなし
                Dim diff As Integer = ProductInfo.Quantity(QuantityItem.DailyPlan) - ProductInfo.Quantity(QuantityItem.DailyActual)
                If diff < ProjectorSettingData.MaxBoroadNum Then
                    ProductionLot = diff
                Else
                    ProductionLot = ProjectorSettingData.MaxBoroadNum
                End If
                WorkStartDate = DateTime.Now
                '基板セット位置表示
                FormProjecter.SetNaviBoardCount(ProductionLot)
                DrawBoardSettingPosition(ProductionLot)
                SetProductionLotLabel()

                '基板のシリアルNoバーコード読み込み処理
                Dim fm As New FormBoardSerialInput(ProductionLot)
                Dim dResult As DialogResult
                dResult = fm.ShowDialog()
                If dResult <> DialogResult.OK Then
                    '製作中断メッセージ
                    DispSerialCancelMessage()
                Else
                    For Each str As String In fm.SerialList
                        BoardSerialList.Add(str)
                    Next
                End If
                If fm IsNot Nothing Then
                    fm.Dispose()
                End If
                If dResult <> DialogResult.OK Then
                    '製作中断
                    InitializeNaviParameter()
                    Exit Sub
                End If

                '作業ログテーブル作成
                SetWorkLogListTable(ProductionLot)
                WorkEndDate = DateTime.Now
                For listNo As Integer = 0 To ProductionLot - 1
                    SetWorkStartDateToWorkLogListTable(NaviRowIndex, listNo)
                    SetWorkEndDataToWorkLogListTable(NaviRowIndex, listNo)
                    '基板毎の作業ログテーブルをDBに登録
                    If RegistWorkingDataToDb(listNo) = False Then
                        DispErrorRegistWorkingData(listNo)
                    End If
                Next
                IsStartProduction = True
                SetFirstNaviboardIndex()
            End If
        End If
        ActiveControl = ButtonStartProduction

    End Sub
    Private Sub ButtonTerminateProdution_Click(sender As Object, e As EventArgs) Handles ButtonTerminateProdution.Click
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If

        If IsStartProduction = True Then
            If ConfirmTerminateWork() <> DialogResult.Yes Then
                ActiveControl = ButtonStartProduction
                Exit Sub
            End If
            WorkEndDate = DateTime.Now
            If NaviBoradIndex = -1 Then
                For listCount As Integer = 0 To ProductionLot - 1
                    SetWorkEndDataToWorkLogListTable(NaviRowIndex, listCount)
                    If RegistWorkingDataToDb(listCount) = False Then
                        DispErrorRegistWorkingData(listCount)
                    End If
                Next
            Else
                SetWorkEndDataToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
                If RegistWorkingDataToDb(NaviBoradIndex) = False Then
                    DispErrorRegistWorkingData(NaviBoradIndex)
                End If
            End If
            InitializeNaviParameter()
            Me.Close()
        End If
        ActiveControl = ButtonStartProduction

    End Sub
    ''' <summary>
    ''' フォームでのキー入力を取得する。
    ''' ボタンがフォームに配置されている場合、PrevieKeyイベントがうまく発生しないため
    ''' 常にButtonStartProductにフォーカスをあて、このボタンでキー入力イベントを処理している。
    ''' ※他のボタンがマウスでクリックされた場合、処理後に[ActiveControl=ButtonStartProduct]処理を
    ''' 　行うこと。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonStartProduction_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ButtonStartProduction.PreviewKeyDown
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        If IsStartProduction = False Then
            Select Case e.KeyCode
                Case Keys.Right, Keys.Left, Keys.Up, Keys.Down
                    e.IsInputKey = True
            End Select

            Exit Sub
        End If

        Select Case e.KeyCode
            Case Keys.Right
                IncrimentNaviBoardIndex()
                e.IsInputKey = True
            Case Keys.Left
                DecrimentNaviBoardIndex()
                e.IsInputKey = True
            Case Keys.Up
            Case Keys.Down
        End Select

    End Sub
    Private Sub InitializeNaviParameter()
        IsStartProduction = False
        WorkStartDate = Nothing
        WorkEndDate = Nothing
        NaviRowIndex = -1
        NaviBoradIndex = -1
        SelectedRowIndex = -1
        ProductionLot = 0
        TextBoxPartsCode.Text = Nothing
        PreviousPartsCode = Nothing
        SelectedPartsCode = Nothing
        TimerDispWorkTime.Enabled = False
        ClearPartsTabInfomation()
        ClearAllPartsPictureBox()
        ClearSelectedPartsPictureBox()
        DataGridViewNavidata.ClearSelection()
        DataGridViewNavidata.CurrentCell = Nothing
        SetProductionLotLabel()
        SetOrderInfoText()
        If TbSamePartsCodeNaviData IsNot Nothing Then
            TbSamePartsCodeNaviData.Clear()
        End If
        BoardSerialList.Clear()
        LotWorkStartDate = Nothing
        SumPreviousWorktime = 0
        ActiveControl = ButtonStartProduction
    End Sub
    Private Sub SetFirstNaviboardIndex()
        WorkEndDate = DateTime.Now
        NaviRowIndex = 0
        NaviBoradIndex = 0
        SetProductionLotLabel()
        WorkStartDate = DateTime.Now
        WorkEndDate = Nothing
        DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, NaviRowIndex)
        SetWorkStartDateToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
        If RegistWorkingDataToDb(NaviBoradIndex) = False Then
            DispErrorRegistWorkingData(NaviBoradIndex)
        End If
        If FormProjecter IsNot Nothing Then
            FormProjecter.ChangeTick(True)
            FormProjecter.ChangeNaviBoard(NaviBoradIndex)
        End If
    End Sub
    ''' <summary>
    ''' なびモード時のなび基板インデックスを加算する。
    ''' 加算した結果が製作ロット以上の場合は、インデックスを0にし、次の行へ移行する。
    ''' </summary>
    Public Sub IncrimentNaviBoardIndex()
        WorkEndDate = DateTime.Now
        SetWorkEndDataToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
        If RegistWorkingDataToDb(NaviBoradIndex) = False Then
            DispErrorRegistWorkingData(NaviBoradIndex)
        End If
        NaviBoradIndex += 1
        If (ProductionLot - 1) < NaviBoradIndex Then
            NaviBoradIndex = 0
            NaviRowIndex += 1
            If TbNaviData.Rows.Count - 1 < NaviRowIndex Then
                'なび終了
                TimerDispWorkTime.Enabled = False
                DispCompleteWorkLot()
                If MoveWorkingDataToLogDb() = False Then
                    Me.Close()
                    Exit Sub
                End If
                ProductInfo.Quantity(QuantityItem.DailyActual) += ProductionLot
                ProductInfo.Quantity(QuantityItem.OrderTotalActual) += ProductionLot
                If ProductInfo.Quantity(QuantityItem.DailyPlan) <= ProductInfo.Quantity(QuantityItem.DailyActual) Then
                    DispCompleteDailyPlan()
                    Me.Close()
                End If
                InitializeNaviParameter()
                Exit Sub
            Else
                '次の行へなび移行
                DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, NaviRowIndex)
                SetWorkStartDateToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
                If RegistWorkingDataToDb(NaviBoradIndex) = False Then
                    DispErrorRegistWorkingData(NaviBoradIndex)
                End If
            End If
        Else
            WorkStartDate = DateTime.Now
            WorkEndDate = Nothing
            'なび基板切替
            SetWorkStartDateToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
            If RegistWorkingDataToDb(NaviBoradIndex) = False Then
                DispErrorRegistWorkingData(NaviBoradIndex)
            End If
        End If
        FormProjecter.ChangeNaviBoard(NaviBoradIndex)
        SetProductionLotLabel()

    End Sub
    ''' <summary>
    ''' なびモード時のなび基板インデックスを減算する。
    ''' 減算した結果が0以下の場合は、インデックスを製作ロット数-1し、前の行へ移行する。
    ''' ただし、NaviRowIndex=0かつNaviBoradIndex=0の時はなにもしない
    ''' </summary>
    Public Sub DecrimentNaviBoardIndex()

        If Not ((0 = NaviRowIndex) AndAlso (0 = NaviBoradIndex)) Then
            WorkEndDate = DateTime.Now
            SetWorkEndDataToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
            If RegistWorkingDataToDb(NaviBoradIndex) = False Then
                DispErrorRegistWorkingData(NaviBoradIndex)
            End If
            WorkStartDate = DateTime.Now
            WorkEndDate = Nothing

            NaviBoradIndex -= 1
            If NaviBoradIndex < 0 Then
                NaviBoradIndex = ProductionLot - 1
                If 0 < NaviRowIndex Then
                    NaviRowIndex -= 1
                    DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, NaviRowIndex)
                ElseIf NaviRowIndex < 0 Then
                    NaviRowIndex = 0
                End If
            End If
            FormProjecter.ChangeNaviBoard(NaviBoradIndex)
            SetProductionLotLabel()

        End If
    End Sub

    Private Sub ButtonIncrimentNaviStepBoard_Click(sender As Object, e As EventArgs) Handles ButtonIncrimentNaviStepBoard.Click
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        If IsStartProduction = True Then
            IncrimentNaviBoardIndex()
        End If
        ActiveControl = ButtonStartProduction
    End Sub

    Private Sub ButtonDecrimentNaviStepBoard_Click(sender As Object, e As EventArgs) Handles ButtonDecrimentNaviStepBoard.Click
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        If IsStartProduction = True Then
            DecrimentNaviBoardIndex()
        End If
        ActiveControl = ButtonStartProduction
    End Sub

    Private Sub ButtonPauseProduction_Click(sender As Object, e As EventArgs) Handles ButtonPauseProduction.Click
        If IsStartProduction = True Then
            WorkEndDate = DateTime.Now
            SetWorkEndDataToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
            SumPreviousWorktime = GetLotWorkTime()
            LotWorkStartDate = Nothing
            TimerDispWorkTime.Enabled = False
            DispPauseWork()

            LotWorkStartDate = DateTime.Now
            TimerDispWorkTime.Enabled = True
            WorkStartDate = DateTime.Now
            WorkEndDate = Nothing
            SetWorkStartDateToWorkLogListTable(NaviRowIndex, NaviBoradIndex)
        End If
        ActiveControl = ButtonStartProduction
    End Sub

    Private Sub DataGridViewNavidata_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewNavidata.CellFormatting
        Select Case OpenFormMode
            Case FormNaviMode.Edit
                EditModeCellFormatting(sender, e)
            Case FormNaviMode.Navi
                NaviModeCellFormatting(sender, e)
        End Select
    End Sub
    ''' <summary>
    ''' 編集モード時のDataGridViewNavidataのセルフォーマット処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub EditModeCellFormatting(ByRef sender As Object, ByRef e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        Dim rowColor As System.Drawing.Color = Color.White

        If SelectedRowIndex = e.RowIndex Then
            '選択行
            rowColor = Color.LightBlue
        Else
            If TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName)) = True Then
                If TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)) IsNot DBNull.Value Then
                    'データ有効行
                    If TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)) = True Then
                        'ナビ不要行
                        rowColor = Color.Orange
                    Else
                        rowColor = Color.White
                    End If
                Else
                    rowColor = Color.White
                End If
            Else
                'データ無効行
                rowColor = Color.DarkGray
            End If
        End If
        DirectCast(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = rowColor

    End Sub
    ''' <summary>
    ''' なびモード時のDataGridViewNavidataのセルフォーマット処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NaviModeCellFormatting(ByRef sender As Object, ByRef e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        Dim rowColor As System.Drawing.Color = Color.White

        If SelectedRowIndex = e.RowIndex Then
            '選択行
            rowColor = Color.LightBlue
        Else
            If IsWorkEndedRow(e.RowIndex) = True Then
                rowColor = Color.Gray
            Else
                rowColor = Color.White
            End If
        End If

        DirectCast(sender, DataGridView).Rows(e.RowIndex).DefaultCellStyle.BackColor = rowColor

    End Sub

    Private Sub DataGridViewNavidata_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewNavidata.CellMouseDoubleClick
        If (e.RowIndex < 0) OrElse (e.ColumnIndex < 0) Then Exit Sub

        Dim cName As String = DataGridViewNavidata.Columns(e.ColumnIndex).DataPropertyName
        If OpenFormMode <> FormNaviMode.Edit Then
            Exit Sub
        End If
        Select Case cName
            Case NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)
                Dim isNewData As Boolean = False
                If TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)) IsNot DBNull.Value Then
                    isNewData = False
                Else
                    isNewData = True
                End If
                Using fm As New FormMentePartsMaster(ControlMasterDb, ControlPartsMasterDb, FormMentePartsMasterOpenMode.DataSelect)
                    Dim dResult As DialogResult = fm.ShowDialog()
                    If dResult <> DialogResult.OK Then
                        Exit Sub
                    End If
                    DtSelectedPartsCodeData = fm.TbSelectedPartsCodeData.Copy
                    TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)) = DtSelectedPartsCodeData(0)(PMTColumnName(PMTColumn.PartsCode))
                    If isNewData = True Then
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.DataEnable, ElementType.ColumnName)) = True
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.NoNavi, ElementType.ColumnName)) = False
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.DataRev, ElementType.ColumnName)) = Nothing
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName)) = "新規"
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.UseCount, ElementType.ColumnName)) = 1
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.X, ElementType.ColumnName)) = 0
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.Y, ElementType.ColumnName)) = 0
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.Rotate, ElementType.ColumnName)) = 0
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.NeedKitting, ElementType.ColumnName)) = True
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.RegistDate, ElementType.ColumnName)) = DateTime.Now
                        TbNaviData.Rows(e.RowIndex)(NVDTColumnInfo(NVDTColumn.RegistManNumber, ElementType.ColumnName)) = SysLoginUserInfo.ManNumber
                    End If
                    DispNaviDataMain(e.RowIndex)
                End Using
        End Select


    End Sub
    ''' <summary>
    ''' DataGridViewNavidataでセルの編集が終了した時に発生するイベント
    ''' 編集が行われた場合、Enterキーでセルが移動するが、DataGridViewNavidata_SelectionChangedをハンドルして
    ''' セル移動キャンセルしている
    ''' マウスの左クリックが押された場合は、何もせず、クリックされたセルへ移動する。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridViewNavidata_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewNavidata.CellEndEdit
        If OpenFormMode <> FormNaviMode.Edit Then
            Exit Sub
        End If
        If Control.MouseButtons = MouseButtons.Left Then
            Exit Sub
        End If
        NaviDgvEdittingColmunIndex = e.ColumnIndex
        NaviDgvEdittingRowIndex = e.RowIndex
        AddHandler DataGridViewNavidata.SelectionChanged, AddressOf DataGridViewNavidata_SelectionChanged
    End Sub
    ''' <summary>
    ''' DataGridViewNavidataでセルが編集後Enterが押された場合、行が移動する処理を無効化する。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridViewNavidata_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RemoveHandler DataGridViewNavidata.SelectionChanged, AddressOf DataGridViewNavidata_SelectionChanged
        DataGridViewNavidata.CurrentCell = DataGridViewNavidata(NaviDgvEdittingColmunIndex, NaviDgvEdittingRowIndex)
    End Sub


    Public Function IsExistModifiedData(ByRef dgv As DataGridView) As Boolean
        Dim isExist As Boolean = False

        Dim bs As BindingSource = DirectCast(dgv.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)

        For Each Row As DataRow In table.Rows
            Select Case Row.RowState
                Case DataRowState.Modified
                    isExist = True
                    Exit For
                Case Else
                    Continue For
            End Select
        Next

        Return isExist
    End Function

    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim dResult As DialogResult
        If IsExistModifiedData(DataGridViewNavidata) = True Then
            dResult = MessageBox.Show("データを登録/更新しますか？", "データ登録・更新確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If dResult = DialogResult.No Then
                Exit Sub
            End If
        End If
        Dim noDate As DateTime = DateTime.Now
        For Each Row As DataRow In TbNaviData.Rows
            Select Case Row.RowState
                Case DataRowState.Modified     '▼修正されたレコードの場合
                    Row(NVDTColumnInfo(NVDTColumn.UpdateManNumber, ElementType.ColumnName)) = SysLoginUserInfo.ManNumber
                    Row(NVDTColumnInfo(NVDTColumn.UpdateDate, ElementType.ColumnName)) = noDate
                Case Else
                    Continue For
            End Select
        Next

        Dim targetDbPath As String = CtrlDbNaviData.GetNaviDbPathString
        Dim tableName As String = CtrlDbNaviData.DefNaviDb.TableNaviData
        Dim connectString As String = CtrlDbNaviData.GetMasterDbConnectString

        Dim registStatus As Boolean = CtrlDbNaviData.UpDateTable(TbNaviData,
                                                                 tableName,
                                                                 NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName),
                                                                 connectString
                                                                 )

        If registStatus = True Then
            MessageBox.Show("データを登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TbNaviData = GetEditNaviDataTable()
            CtrlDgv.BindTableToDgv(DataGridViewNavidata, TbNaviData)
        Else
            MessageBox.Show("データ登録ができませんでした。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim sbString As New System.Text.StringBuilder

        For Each Row As DataRow In TbNaviData.Rows
            Select Case Row.RowState
                Case DataRowState.Modified
                    sbString.AppendLine(Row(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)))
                Case Else
                    Continue For
            End Select
        Next
        TextBox1.Text = sbString.ToString

    End Sub

    Private Sub ButtonUpStep_Click(sender As Object, e As EventArgs) Handles ButtonUpStep.Click

        Dim selectedCells As New List(Of CellIndex)
        Dim distinctRowIndexes As New List(Of Integer)

        Dim selStatus As Integer = GetDgvSelectedRowIndexes(DataGridViewNavidata, selectedCells, distinctRowIndexes)

        If selStatus <> DgvCellSelectStatus.Ok Then
            Exit Sub
        End If

        Dim dgvcolumnwidth As New List(Of Integer)
        For i As Integer = 0 To DataGridViewNavidata.Columns.Count - 1
            dgvcolumnwidth.Add(DataGridViewNavidata.Columns(i).Width)
        Next


        Dim stepColName As String = NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)
        Dim nowStep As Integer = TbNaviData.Rows(distinctRowIndexes(0))(stepColName)

        For count As Integer = 0 To distinctRowIndexes.Count - 1
            TbNaviData.Rows(distinctRowIndexes(count))(stepColName) = (nowStep - 1) + count
        Next

        TbNaviData.Rows(distinctRowIndexes(0) - 1)(stepColName) = (nowStep - 1) + distinctRowIndexes.Count

        '新No列でデータをソート
        Dim rows As DataRow() = TbNaviData.Select(Nothing, stepColName).Clone()

        'ソートデータ格納テーブル
        Dim dtblSrt As New DataTable()
        'ソート前テーブルの情報をクローン作成
        dtblSrt = TbNaviData.Clone()

        'ソートされてる DataRow 配列をソート後の DataTable に追加
        For Each row As DataRow In rows
            dtblSrt.ImportRow(row)
        Next

        TbNaviData.Clear()
        TbNaviData = dtblSrt.Copy
        CtrlDgv.BindTableToDgv(DataGridViewNavidata, TbNaviData)
        Try
            DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, distinctRowIndexes(0) - 1)
        Catch ex As Exception

        End Try
        For i As Integer = 0 To DataGridViewNavidata.Columns.Count - 1
            DataGridViewNavidata.Columns(i).Width = dgvcolumnwidth(i)
        Next
        DataGridViewNavidata.ClearSelection()

        For Each cell As CellIndex In selectedCells
            Dim c As Integer = cell.col
            Dim r As Integer = cell.row
            DataGridViewNavidata(c, r - 1).Selected = True
        Next


    End Sub
    Private Sub ButtonDownStep_Click(sender As Object, e As EventArgs) Handles ButtonDownStep.Click

        Dim selectedCells As New List(Of CellIndex)

        Dim distinctRowIndexes As New List(Of Integer)
        Dim selStatus As Integer = GetDgvSelectedRowIndexes(DataGridViewNavidata, selectedCells, distinctRowIndexes)

        If selStatus <> DgvCellSelectStatus.Ok Then
            Exit Sub
        End If


        Dim dgvcolumnwidth As New List(Of Integer)
        For i As Integer = 0 To DataGridViewNavidata.Columns.Count - 1
            dgvcolumnwidth.Add(DataGridViewNavidata.Columns(i).Width)
        Next
        Dim stepColName As String = NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName)
        Dim nowStep As Integer = TbNaviData.Rows(distinctRowIndexes(distinctRowIndexes.Count - 1))(stepColName)

        For count As Integer = (distinctRowIndexes.Count - 1) To 0 Step -1
            TbNaviData.Rows(distinctRowIndexes(count))(stepColName) = (nowStep + 1) - (distinctRowIndexes.Count - 1 - count)
        Next

        TbNaviData.Rows(distinctRowIndexes(distinctRowIndexes.Count - 1) + 1)(stepColName) = (nowStep + 1) - distinctRowIndexes.Count

        '新No列でデータをソート
        Dim rows As DataRow() = TbNaviData.Select(Nothing, stepColName).Clone()

        'ソートデータ格納テーブル
        Dim dtblSrt As New DataTable()
        'ソート前テーブルの情報をクローン
        dtblSrt = TbNaviData.Clone()

        'ソートされてる DataRow 配列をソート後の DataTable に追加
        For Each row As DataRow In rows
            dtblSrt.ImportRow(row)
        Next

        TbNaviData.Clear()
        TbNaviData = dtblSrt.Copy
        CtrlDgv.BindTableToDgv(DataGridViewNavidata, TbNaviData)
        Try
            DataGridViewNavidata.CurrentCell = DataGridViewNavidata(0, distinctRowIndexes(0) - 1)
        Catch ex As Exception

        End Try
        For i As Integer = 0 To DataGridViewNavidata.Columns.Count - 1
            DataGridViewNavidata.Columns(i).Width = dgvcolumnwidth(i)
        Next
        DataGridViewNavidata.ClearSelection()

        For Each cell As CellIndex In selectedCells
            Dim c As Integer = cell.col
            Dim r As Integer = cell.row
            DataGridViewNavidata(c, r + 1).Selected = True
        Next

    End Sub
    ''' <summary>
    ''' DataGridViewで選択しているセルのインデックス一覧及び重複削除した選択行インデックス一覧を取得する。
    ''' </summary>
    ''' <param name="dgv">
    ''' DataGridViewインスタンス
    ''' </param>
    ''' <param name="selectedCells">
    ''' 選択セルリスト
    ''' </param>
    ''' <param name="distinctRowIndexes">
    ''' 選択行リスト
    ''' </param>
    ''' <returns></returns>
    Private Function GetDgvSelectedRowIndexes(ByRef dgv As DataGridView, ByRef selectedCells As List(Of CellIndex), ByRef distinctRowIndexes As List(Of Integer)) As Integer
        Dim selCellsCount As Integer = dgv.GetCellCount(DataGridViewElementStates.Selected)

        If selCellsCount < 1 Then
            MessageBox.Show("データが選択されていません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return DgvCellSelectStatus.NoSelect
        End If
        'Dim selectedCells As New List(Of CellIndex)
        Dim rowIndexs As New List(Of Integer)
        For Each c As DataGridViewCell In dgv.SelectedCells
            rowIndexs.Add(c.RowIndex)
            Dim ci As CellIndex
            ci.col = c.ColumnIndex
            ci.row = c.RowIndex
            selectedCells.Add(ci)
        Next c
        'Dim distinctRowIndexes As List(Of Integer)
        distinctRowIndexes = rowIndexs.Distinct.ToList

        If 1 < distinctRowIndexes.Count Then
            '昇順に並び替えて
            distinctRowIndexes.Sort()

            Dim previousIndex As Integer = -1
            Dim isConsecutiveSelect As Boolean = True

            '連続した行選択か確認
            For i As Integer = 0 To distinctRowIndexes.Count - 1
                If i = 0 Then
                    previousIndex = distinctRowIndexes(i)
                    Continue For
                End If
                If (distinctRowIndexes(i) - previousIndex) <> 1 Then
                    '非連続
                    isConsecutiveSelect = False
                End If
                previousIndex = distinctRowIndexes(i)
            Next
            If isConsecutiveSelect = False Then
                MessageBox.Show("連続したデータを選択してください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return DgvCellSelectStatus.NoConsecutive

            End If
        End If
        Return DgvCellSelectStatus.Ok

    End Function

    Private Sub ButtonEditPartsShape_Click(sender As Object, e As EventArgs) Handles ButtonEditPartsShape.Click
        OpenEditPartsShapeForm()
    End Sub
    ''' <summary>
    ''' なびデータ編集モード時にDataGridViewNavidataで選択した行の部材形状を変更フォームを表示する。
    ''' </summary>
    Private Sub OpenEditPartsShapeForm()
        If DataGridViewNavidata.CurrentCell Is Nothing Then
            MessageBox.Show("部材形状を変更する行を選択してください。", "行未選択", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim regResult As DialogResult

        If DtSelectedPartsCodeData.Rows.Count = 0 Then
            MessageBox.Show("部材コードが設定されていません。", "部材コード未設定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim shapeId As Integer = DtSelectedPartsCodeData.Rows(0)(PMTColumnName(PMTColumn.PartsShapeId))

        Dim fm As FormEditPartsShape = New FormEditPartsShape(False, shapeId, CtrlDbMaster)

        regResult = fm.ShowDialog()
        If fm IsNot Nothing Then
            fm.Dispose()
        End If
        If regResult = DialogResult.No Then Exit Sub
        DispNaviDataMain(DataGridViewNavidata.CurrentRow.Index)

    End Sub

    Private Sub ButtonOpenEditPartsMaster_Click(sender As Object, e As EventArgs) Handles ButtonOpenEditPartsMaster.Click
        If DataGridViewNavidata.CurrentCell Is Nothing Then
            MessageBox.Show("部材マスタを変更する行を選択してください。", "行未選択", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim regResult As DialogResult

        If DtSelectedPartsCodeData.Rows.Count = 0 Then
            MessageBox.Show("部材コードが設定されていません。", "部材コード未設定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim fm As FormEditPartsData = New FormEditPartsData(False, SelectedPartsCode, CtrlDbMaster, CtrlDbPartsMaster)
        regResult = fm.ShowDialog()
        Dim partsCode As String = fm.RegistedPartsCode
        If fm IsNot Nothing Then
            fm.Dispose()
        End If
        If regResult <> DialogResult.OK Then Exit Sub
        PreviousPartsCode = Nothing
        SelectedPartsCode = DataGridViewNavidata(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName), DataGridViewNavidata.CurrentRow.Index).Value

        SelectedNaviStep = DataGridViewNavidata(NVDTColumnInfo(NVDTColumn.NaviStep, ElementType.ColumnName), DataGridViewNavidata.CurrentRow.Index).Value
        SetPartsTabInfomation()
        SetSamePartsCodeDgv(SelectedPartsCode, SelectedNaviStep)
        If DrawNaviData(SelectedPartsCode, SelectedNaviStep) = True Then
            SetNaviMessage()
        End If


    End Sub

    Private Sub FormEditNavidata_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        Dim hasTurnedOff As Boolean = HasTurnedOffProjecter()
        If hasTurnedOff = True Then
            Exit Sub
        End If

        'プロジェクターの電源OFF確認
        DispTurnOffProjector()

    End Sub
    ''' <summary>
    ''' プロジェクタの電源が切られているか取得する。
    ''' 確認は、プライマリスクリーン以外が存在するかどうかで行っている。
    ''' </summary>
    ''' <returns>
    ''' True:全てのプロジェクタの電源が切られている　False:１つ以上のプロジェクタの電源が入っている。
    ''' </returns>
    Private Function HasTurnedOffProjecter() As Boolean
        Dim pd As String = System.Windows.Forms.Screen.PrimaryScreen.DeviceName
        Dim projecterCount As Integer = 0

        For Each s In System.Windows.Forms.Screen.AllScreens
            If s.DeviceName <> pd Then
                'プライマリ以外のスクリーン
                projecterCount += 1
            End If
        Next
        If projecterCount = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' WorkLogListにprdCountで指定した数分の作業データを設定する。
    ''' 設定する際、各WorkLogListの先頭行は、準備作業データとし、ナビID＝-1を設定する。
    ''' </summary>
    ''' <param name="prdCount"></param>
    Private Sub SetWorkLogListTable(ByVal prdCount As Integer)
        For i As Integer = 0 To ProjectorSettingData.MaxBoroadNum - 1
            WorkLogList(i).Clear()
        Next

        '基板セッティング準備作業行の追加
        For j As Integer = 0 To prdCount - 1
            AddRowWorkLogListTable(j, BoardSerialList(j), j + 1, Nothing)
        Next

        'ナビデータに対応した作業データの追加
        For Each row As DataRow In TbNaviData.Rows
            For j As Integer = 0 To prdCount - 1
                AddRowWorkLogListTable(j, BoardSerialList(j), j + 1, row)
            Next
        Next
    End Sub
    ''' <summary>
    ''' 作業データ(WorkLogList)のlistNoで指定したテーブルに新規行を追加する。
    ''' </summary>
    ''' <param name="listNo">
    ''' 新規行を追加したいWorkLogListのインデックス番号
    ''' </param>
    ''' <param name="serialNo">
    ''' 新規追加する基板のシリアル番号
    ''' </param>
    ''' <param name="lotNo">
    ''' 新規追加する基板のロットNo
    ''' </param>
    ''' <param name="naviRowData">
    ''' 新規追加する際に参照するナビデータ(TbNaviData)の該当行DataRow
    ''' </param>
    Private Sub AddRowWorkLogListTable(ByVal listNo As Integer, ByVal serialNo As String, ByVal lotNo As Integer, ByVal naviRowData As DataRow)
        Dim drow As DataRow = WorkLogList(listNo).NewRow
        drow(WLTColumnName(WLTColumn.Id)) = DBNull.Value
        drow(WLTColumnName(WLTColumn.ProductionAcutualId)) = ProductInfo.ProductionPlanActualId
        drow(WLTColumnName(WLTColumn.Order)) = ProductInfo.Order
        drow(WLTColumnName(WLTColumn.BoardName)) = ProductInfo.BoardName
        drow(WLTColumnName(WLTColumn.DrawingId)) = ProductInfo.DrawingId
        drow(WLTColumnName(WLTColumn.SerialNo)) = serialNo
        drow(WLTColumnName(WLTColumn.StartDate)) = DBNull.Value
        drow(WLTColumnName(WLTColumn.EndDate)) = DBNull.Value
        drow(WLTColumnName(WLTColumn.ProductionLot)) = ProductionLot
        drow(WLTColumnName(WLTColumn.LotNumber)) = lotNo
        If naviRowData IsNot Nothing Then
            drow(WLTColumnName(WLTColumn.NaviId)) = CInt(naviRowData(NVDTColumnInfo(NVDTColumn.Id, ElementType.ColumnName)))
            drow(WLTColumnName(WLTColumn.PartsCode)) = CStr(naviRowData(NVDTColumnInfo(NVDTColumn.PartsCode, ElementType.ColumnName)))
            drow(WLTColumnName(WLTColumn.Shogen)) = CStr(naviRowData(NVDTColumnInfo(NVDTColumn.Shogen, ElementType.ColumnName)))
        Else
            drow(WLTColumnName(WLTColumn.NaviId)) = -1
            drow(WLTColumnName(WLTColumn.PartsCode)) = DBNull.Value
            drow(WLTColumnName(WLTColumn.Shogen)) = DBNull.Value
        End If
        drow(WLTColumnName(WLTColumn.WorkerManNumber)) = SysLoginUserInfo.ManNumber
        drow(WLTColumnName(WLTColumn.WorkTime)) = 0

        WorkLogList(listNo).Rows.Add(drow)
    End Sub
    ''' <summary>
    ''' 作業データ(WorkLogList)の該当データに開始時間を設定する。
    ''' </summary>
    ''' <param name="naviRowIndex">
    ''' 開始時間を設定する作業データ(WorkLogList)の行番号
    ''' </param>
    ''' <param name="listNo">
    ''' 開始時間を設定する作業データ(WorkLogList)のインデックス番号
    ''' </param>
    Private Sub SetWorkStartDateToWorkLogListTable(ByVal naviRowIndex As Integer, ByVal listNo As Integer)
        If WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.StartDate)) Is DBNull.Value Then
            WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.StartDate)) = WorkStartDate

        End If
    End Sub
    ''' <summary>
    ''' 作業データ(WorkLogList)の該当データに終了時間を設定する。
    ''' </summary>
    ''' <param name="naviRowIndex">
    ''' 終了時間を設定する作業データ(WorkLogList)の行番号
    ''' </param>
    ''' <param name="listNo">
    ''' 終了時間を設定する作業データ(WorkLogList)のインデックス番号
    ''' </param>
    Private Sub SetWorkEndDataToWorkLogListTable(ByVal naviRowIndex As Integer, ByVal listNo As Integer)
        WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.EndDate)) = WorkEndDate
        Dim workTimeSum As Double = 0
        If WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.WorkTime)) IsNot DBNull.Value Then
            workTimeSum = WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.WorkTime))
        End If
        Dim diffTime As Double = (((WorkEndDate - WorkStartDate).Ticks) / TimeSpan.TicksPerMillisecond) / 1000
        If naviRowIndex < 0 Then
            workTimeSum += diffTime / ProductionLot
        Else
            workTimeSum += diffTime
        End If
        WorkLogList(listNo).Rows(naviRowIndex + 1)(WLTColumnName(WLTColumn.WorkTime)) = workTimeSum

    End Sub
    ''' <summary>
    ''' DateTimeの２値間の秒数を求める
    ''' </summary>
    ''' <param name="dateFrom">
    ''' 秒数を求める終わりのDateTime
    ''' </param>
    ''' <param name="dateTo">
    ''' 秒数を求める初めのDateTime
    ''' </param>
    ''' <returns>
    ''' dateTo - dateFromで求めた秒数
    ''' </returns>
    Private Function CalcDatePeriodPerSecond(ByVal dateFrom As DateTime, ByVal dateTo As DateTime) As Double
        Dim diffTime As Double = (((dateTo - dateFrom).Ticks) / TimeSpan.TicksPerMillisecond) / 1000
        Return diffTime
    End Function

    ''' <summary>
    ''' 作業データテーブルをDBに登録・更新する。
    ''' </summary>
    ''' <param name="naviBoardIdx">
    ''' 登録・更新したいWorkLogListのインデックス番号
    ''' </param>
    ''' <returns></returns>
    Private Function RegistWorkingDataToDb(ByVal naviBoardIdx As Integer) As Boolean
        Dim connectString As String = CtrlWorkLog.GetWorkingDataDbConnectString
        Dim updateStatus As Boolean
        updateStatus = UpDateWorlLogTableAndGetId(WorkLogList(naviBoardIdx), CtrlWorkLog.DefWlogDb.TableWorkLog, connectString)
        Return updateStatus
    End Function

    ''' <summary>
    ''' 仕掛データのなび開始位置を設定する。
    ''' </summary>
    Private Sub SetNaviPosition()
        Dim idList As New List(Of Integer)

        For i As Integer = 0 To ProductionLot - 1
            Dim count As Integer
            count = CtrlWorkLog.GetWrokingDataWorkEndRowCount(ProductInfo.Order, SysLoginUserInfo.ManNumber, BoardSerialList(i))
            idList.Add(count)
        Next
        Dim rowIndex As Integer = -1
        Dim previousRowIndex As Integer = -1
        Dim bIndex As Integer = 0
        For j As Integer = 0 To (idList.Count - 1)
            If idList(j) <> 0 Then
                rowIndex = idList(j)
                If rowIndex < previousRowIndex Then
                    bIndex = j
                    Exit For
                End If
                previousRowIndex = rowIndex
            End If
        Next
        NaviBoradIndex = bIndex
        NaviRowIndex = rowIndex - 1
    End Sub
    ''' -----------------------------------------------------------------------------------
    ''' <summary>
    ''' データテーブルの内容を基にデータベースのテーブルを更新する。
    ''' 更新した際、追加行に対して追加したときのIDを設定する。
    ''' </summary>
    ''' <param name="table">
    ''' 更新するテーブルデータ
    ''' </param>
    ''' <param name="tableName">
    ''' 更新するテーブル名
    ''' </param>
    ''' <param name="connectString">
    ''' 更新するDBの接続文字列
    ''' </param>
    ''' <returns>
    ''' Ture:更新成功　False:更新失敗
    ''' </returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------------
    Public Function UpDateWorlLogTableAndGetId(ByRef table As DataTable, ByVal tableName As String, ByVal connectString As String) As Boolean
        Dim isCompleteUpdate As Boolean = False

        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand
        Dim Trz As System.Data.OleDb.OleDbTransaction

        Cn.Open()
        Trz = Cn.BeginTransaction
        isCompleteUpdate = False
        '●更新実行
        Try
            SQLCm.Transaction = Trz
            For Each Row As DataRow In table.Rows
                Dim isAdded As Boolean = False
                Dim SQL As String = ""
                '●SQL文の生成
                Select Case Row.RowState
                    Case DataRowState.Added        '▼新規追加されたレコードの場合
                        SQL = CtrlWorkLog.GetInsertSqlString(tableName, Row, WLTColumnName(WLTColumn.Id))
                        isAdded = True
                    Case DataRowState.Deleted      '▼削除されたレコードの場合
                        SQL = CtrlWorkLog.GetDeleteSqlString(tableName, Row, WLTColumnName(WLTColumn.Id))
                    Case DataRowState.Modified     '▼修正されたレコードの場合
                        SQL = CtrlWorkLog.GetModifiedSqlString(tableName, Row, WLTColumnName(WLTColumn.Id))
                    Case Else
                        Continue For
                End Select

                SQLCm.CommandText = SQL
                SQLCm.ExecuteNonQuery() '実行
                If isAdded = True Then
                    SQLCm.CommandText = "Select @@IDENTITY"
                    Dim obj As Object = SQLCm.ExecuteScalar() '実行
                    If obj IsNot Nothing AndAlso obj.GetType IsNot GetType(DBNull) Then
                        Row(WLTColumnName(WLTColumn.Id)) = CInt(obj)
                    Else
                        '基本的に本行は実行されない
                        Row(WLTColumnName(WLTColumn.Id)) = 0
                    End If
                End If
            Next
            isCompleteUpdate = True
            Trz.Commit() 'コミット（確定）
            table.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show(SQLCm.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trz.Rollback() 'ロールバック
            isCompleteUpdate = False
        Finally
            Cn.Close() 'DB切断
        End Try

        SQLCm.Dispose()
        Cn.Dispose()
        Return isCompleteUpdate
    End Function

    Public Function MoveWorkingDataToLogDb() As Boolean
        Dim isCompleteUpdate As Boolean = False
        Dim connectString As String = CtrlWorkLog.GetWorkingDataDbConnectString

        Dim yyyymmString As String = DateTime.Now.ToString("yyyyMM")
        Dim connectStringLog As String = CtrlWorkLog.GetWorkLogDbConnectString(yyyymmString)
        Dim logDbFilename As String = CtrlWorkLog.GetWorkLogDbPathString(yyyymmString)

        Dim connectStringPpa As String = CtrlPrdAct.GetMasterDbConnectString

        If System.IO.File.Exists(logDbFilename) = False Then
            Dim sourcePath As String = CtrlWorkLog.GetWorLogTemplateDbPathString
            Try
                System.IO.File.Copy(sourcePath, logDbFilename)
            Catch ex As Exception
                DispSystemError(ex.Message, "ログファイルをコピー出来ませんでした。")
                Return False
            End Try
        End If


        '作業データ用
        Dim Cn As New System.Data.OleDb.OleDbConnection(connectString)
        Dim SQLCm As System.Data.OleDb.OleDbCommand = Cn.CreateCommand
        Dim Trz As System.Data.OleDb.OleDbTransaction

        '作業ログ用
        Dim CnLog As New System.Data.OleDb.OleDbConnection(connectStringLog)
        Dim SQLCmLog As System.Data.OleDb.OleDbCommand = CnLog.CreateCommand
        Dim TrzLog As System.Data.OleDb.OleDbTransaction

        '生産計画実績用
        Dim CnPpa As New System.Data.OleDb.OleDbConnection(connectStringPpa)
        Dim SQLCmPpa As System.Data.OleDb.OleDbCommand = CnPpa.CreateCommand
        Dim TrzPpa As System.Data.OleDb.OleDbTransaction


        Cn.Open()
        CnLog.Open()
        CnPpa.Open()
        Trz = Cn.BeginTransaction
        TrzLog = CnLog.BeginTransaction
        TrzPpa = CnPpa.BeginTransaction
        isCompleteUpdate = False

        SQLCm.Transaction = Trz
        SQLCmLog.Transaction = TrzLog
        SQLCmPpa.Transaction = TrzPpa
        Try
            For list As Integer = 0 To ProductionLot - 1
                '作業ログへの登録
                For Each Row As DataRow In WorkLogList(list).Rows
                    Dim SqlLog As String = ""
                    SqlLog = CtrlWorkLog.GetInsertSqlString(CtrlWorkLog.DefWlogDb.TableWorkLog, Row, WLTColumnName(WLTColumn.Id))
                    SQLCmLog.CommandText = SqlLog
                    SQLCmLog.ExecuteNonQuery() '実行
                Next
                '作業データの削除
                SQLCm.CommandText = GetDeleteWrokingDataSql(list)
                SQLCm.ExecuteNonQuery()
            Next
            '生産計画実績DBの実績数加算
            SQLCmPpa.CommandText = GetCountUpActualSql(ProductionLot)
            SQLCmPpa.ExecuteNonQuery()

            isCompleteUpdate = True
            'コミット（確定）
            Trz.Commit()
            TrzLog.Commit()
            TrzPpa.Commit()
        Catch ex As Exception
            MessageBox.Show(SQLCm.CommandText) 'SQL表示（デバッグ用）
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ロールバック
            Trz.Rollback()
            TrzLog.Rollback()
            TrzPpa.Rollback()
            isCompleteUpdate = False
        Finally
            'DB切断
            Cn.Close()
            CnLog.Close()
            CnPpa.Close()
        End Try

        SQLCm.Dispose()
        SQLCmLog.Dispose()
        SQLCmPpa.Dispose()
        Cn.Dispose()
        CnLog.Dispose()
        CnPpa.Dispose()

        Return isCompleteUpdate
    End Function
    Private Function GetDeleteWrokingDataSql(ByVal boardIdx As Integer) As String
        Dim delSql As New System.Text.StringBuilder
        delSql.AppendLine("delete ")
        delSql.AppendLine("from")
        delSql.AppendLine(CtrlWorkLog.DefWlogDb.TableWorkLog)
        delSql.AppendLine("where")
        delSql.AppendLine(String.Format(" {0}={1}", WLTColumnName(WLTColumn.ProductionAcutualId), ProductInfo.ProductionPlanActualId))
        delSql.AppendLine("and")
        delSql.AppendLine(String.Format(" {0}='{1}'", WLTColumnName(WLTColumn.Order), ProductInfo.Order))
        delSql.AppendLine("and")
        delSql.AppendLine(String.Format(" {0}='{1}'", WLTColumnName(WLTColumn.WorkerManNumber), ProductInfo.WorkerManNumber))
        delSql.AppendLine("and")
        delSql.AppendLine(String.Format(" {0}='{1}'", WLTColumnName(WLTColumn.SerialNo), BoardSerialList(boardIdx)))
        Return delSql.ToString
    End Function
    Private Function GetCountUpActualSql(ByVal actualCount As Integer) As String
        Dim delSql As New System.Text.StringBuilder
        delSql.AppendLine("update ")
        delSql.AppendLine(CtrlPrdAct.DefPpaDb.TablePlanActual)
        delSql.AppendLine("set")
        delSql.AppendLine(String.Format(" {0}={1}+{2}",
                                        PPATColumnName(PPATColumn.ProductionActural),
                                        PPATColumnName(PPATColumn.ProductionActural),
                                        actualCount))
        delSql.AppendLine("where")
        delSql.AppendLine(String.Format(" {0}={1}", PPATColumnName(PPATColumn.ID), ProductInfo.ProductionPlanActualId))
        delSql.AppendLine("and")
        delSql.AppendLine(String.Format(" {0}='{1}'", PPATColumnName(PPATColumn.Order), ProductInfo.Order))
        delSql.AppendLine("and")
        delSql.AppendLine(String.Format(" {0}='{1}'", PPATColumnName(PPATColumn.WorkerManNumber), ProductInfo.WorkerManNumber))
        Return delSql.ToString
    End Function
    Private Function IsWorkEndedRow(ByVal rowIdx As Integer) As Boolean
        If ProductionLot <= 0 Then
            Return False
        End If
        For i As Integer = 0 To ProductionLot - 1
            If 0 < WorkLogList(i).Rows.Count Then
                If WorkLogList(i).Rows(rowIdx + 1)(WLTColumnName(WLTColumn.EndDate)) Is DBNull.Value Then
                    Return False
                End If
            Else
                Return False
            End If
        Next
        Return True
    End Function


    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged,
                                                                                           ListBoxPartsImage.SelectedIndexChanged,
                                                                                           ListBoxKankotsuFile.SelectedIndexChanged
        If IsFormShown = False Then Exit Sub
        If OpenFormMode = FormNaviMode.Navi Then
            ActiveControl = ButtonStartProduction
        End If
    End Sub

    ''' <summary>
    ''' 仕掛データの総作業時間を求める
    ''' </summary>
    ''' <returns></returns>
    Private Function GetSumWorkTimeWorkingData() As Double
        Dim sumWorktime As Double = 0
        For i As Integer = 0 To ProductionLot - 1
            Dim objSum As Object = WorkLogList(i).Compute("SUM(" & WLTColumnName(WLTColumn.WorkTime) & ")", Nothing)
            If objSum IsNot Nothing Then
                sumWorktime += DirectCast(objSum, Double)
            End If
        Next
        Return sumWorktime
    End Function

    Private Function GetLotWorkTime() As Double
        Dim sumWorktime As Double = 0
        Dim diffTime As Double = 0
        If (Not (LotWorkStartDate <> Nothing)) = True Then
            diffTime = 0
        Else
            diffTime = (((DateTime.Now - LotWorkStartDate).Ticks) / TimeSpan.TicksPerMillisecond) / 1000
        End If

        sumWorktime = SumPreviousWorktime + diffTime
        Return sumWorktime
    End Function
    Private Sub DispWorkTime(ByVal workTime As Double)
        Dim ts As TimeSpan = New TimeSpan(0, 0, CInt(workTime))
        Label1WorkTime.Text = ts.ToString
    End Sub

    Private Sub TimerDispWorkTime_Tick(sender As Object, e As EventArgs) Handles TimerDispWorkTime.Tick
        If IsFormInitializing = True Then
            Exit Sub
        End If

        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        DispWorkTime(GetLotWorkTime())
    End Sub

    Private Sub TimerGetOrderActual_Tick(sender As Object, e As EventArgs) Handles TimerGetOrderActual.Tick
        If OpenFormMode <> FormNaviMode.Navi Then
            Exit Sub
        End If
        Dim sum As Integer
        sum = CtrlPrdAct.GetTotalOrderActual(ProductInfo.Order)
        ProductInfo.Quantity(QuantityItem.OrderTotalActual) = sum
        TextBoxProductionTotalActual.Text = ProductInfo.Quantity(QuantityItem.OrderTotalActual).ToString("#,0")

    End Sub
    Private Function WorkingDbCompactMain() As Boolean
        Dim isCloseForm As Boolean = False
        Dim sbErrMess As New System.Text.StringBuilder
        Dim cmpStatus As Integer
        Dim fpo As New FormMessage
        fpo.Title = "作業ファイルの最適化確認中・・・"        'ダイアログのタイトルを設定
        fpo.Minimum = 0                     'プログレスバーの最小値を設定
        fpo.Maximum = 1                     'プログレスバーの最大値を設定
        fpo.Value = 0                       'プログレスバーの初期値を設定
        fpo.Show(Me)                        '進行状況ダイアログを表示する
        fpo.Value = 0                       'プログレスバーの値を変更する
        Me.Enabled = False
        Do While True
            sbErrMess.Clear()
            Dim mess As String = Nothing
            fpo.Message = "作業ファイルの最適化確認中・・・"

            cmpStatus = CompactWorkingLogDb(sbErrMess)
            Select Case cmpStatus
                Case NaviStatus.OK
                    fpo.Value = 1
                    fpo.Message = "作業ファイルの最適化が完了しました。"
                    Exit Do
                Case NaviStatus.ErrReadCompactStatusFile,
                     NaviStatus.ErrWriteCompactStatusFile,
                     NaviStatus.ErrInvalidCompactStatusFilename,
                     NaviStatus.ErrWorkingDbCompact
                    sbErrMess.AppendLine("")
                    sbErrMess.AppendLine("フォームを閉じます。")
                    sbErrMess.AppendLine("しばらく待ってからやり直してください。")
                    DispSystemError(sbErrMess.ToString, "作業データ最適化処理ができませんでした。")
                    isCloseForm = True
                    Exit Do
                Case NaviStatus.WorkingDbNowCompacting
                    fpo.Message = DbCompactStatus.ComputerName & "が作業ファイルを最適化するのを待っています・・・"
                    System.Threading.Thread.Sleep(1000)
                    If fpo.Canceled = True Then
                        Exit Do
                    End If
                Case NaviStatus.WorkingDbCompacted
                    fpo.Value = 1
                    fpo.Message = "作業ファイル最適化済みです。"
                    Exit Do
            End Select
        Loop
        'ダイアログを閉じる
        fpo.CloseWindow()
        If fpo IsNot Nothing Then
            fpo.Dispose()
        End If
        Me.Enabled = True
        If isCloseForm = True Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sbErrMess"></param>
    ''' <returns>
    ''' NaviStatus.OK
    ''' NaviStatus.ErrReadCompactStatusFile
    ''' NaviStatus.ErrInvalidCompactStatusFilename
    ''' NaviStatus.ErrWriteCompactStatusFile
    ''' NaviStatus.ErrWorkingDbCompact
    ''' NaviStatus.WorkingDbCompacted
    ''' NaviStatus.WorkingDbNowCompacting
    ''' 
    ''' </returns>
    Private Function CompactWorkingLogDb(ByRef sbErrMess As System.Text.StringBuilder) As Integer
        Dim cmpSts As Integer = GetWorkLogCompactStatus(sbErrMess)

        If cmpSts <> NaviStatus.WorkingDbNeedCompact Then
            Return cmpSts
        End If
        Dim backupDbCompactStatus As DbCompact
        backupDbCompactStatus = DbCompactStatus

        DbCompactStatus.ComputerName = Environment.MachineName
        DbCompactStatus.Status = "最適化中"
        DbCompactStatus.LastDate = Date.Today

        cmpSts = WriteWorkLogCompactStatus(sbErrMess)
        If cmpSts = NaviStatus.ErrWriteCompactStatusFile Then
            Return cmpSts
        End If

        Dim tempWorkLogPath As String = String.Format("{0}\{1}", CtrlWorkLog.DefWlogDb.DbPath, TempWorkLogFileName)
        Dim tempWorkLogBackUpPath As String = String.Format("{0}\{1}", CtrlWorkLog.DefWlogDb.DbPath, TempWorkLogFileNameBackup)
        Dim targetPath As String = CtrlWorkLog.GetWorkingDataDbPathString

        cmpSts = NaviStatus.OK
        If System.IO.File.Exists(targetPath) = True Then
            'エラーで出来たファイルの削除
            If System.IO.File.Exists(tempWorkLogPath) = True Then
                Try
                    System.IO.File.Delete(tempWorkLogPath)
                Catch ex As Exception
                    If sbErrMess.Length <> 0 Then
                        sbErrMess.AppendLine(vbCrLf)
                    End If
                    sbErrMess.AppendLine("仮の作業データファイル削除ができませんでした。")
                    sbErrMess.AppendLine(ex.Message)
                    DbCompactStatus = backupDbCompactStatus
                    cmpSts = NaviStatus.ErrDeleteTempWorkingData
                    GoTo LB_CompactErrorExit
                End Try
            End If
            If System.IO.File.Exists(tempWorkLogBackUpPath) = True Then
                Try
                    System.IO.File.Delete(tempWorkLogBackUpPath)
                Catch ex As Exception
                    If sbErrMess.Length <> 0 Then
                        sbErrMess.AppendLine(vbCrLf)
                    End If
                    sbErrMess.AppendLine("仮の作業データファイル削除ができませんでした。")
                    sbErrMess.AppendLine(ex.Message)
                    DbCompactStatus = backupDbCompactStatus
                    cmpSts = NaviStatus.ErrRecoverWorkingDbCompactFile
                    GoTo LB_CompactErrorExit
                End Try
            End If
        Else
            'エラーでリネームできなかったファイルの修復（リネーム）
            If System.IO.File.Exists(tempWorkLogBackUpPath) = True Then
                Try
                    System.IO.File.Move(tempWorkLogBackUpPath, targetPath)
                Catch ex As Exception
                    If sbErrMess.Length <> 0 Then
                        sbErrMess.AppendLine(vbCrLf)
                    End If
                    sbErrMess.AppendLine("作業データファイルの修復にができませんでした。")
                    sbErrMess.AppendLine(ex.Message)
                    DbCompactStatus = backupDbCompactStatus
                    cmpSts = NaviStatus.ErrRecoverWorkingDbCompactFile
                    GoTo LB_CompactErrorExit
                End Try
            End If
            'エラーで出来たファイルの削除
            If System.IO.File.Exists(tempWorkLogPath) = True Then
                Try
                    System.IO.File.Delete(tempWorkLogPath)
                Catch ex As Exception
                    If sbErrMess.Length <> 0 Then
                        sbErrMess.AppendLine(vbCrLf)
                    End If
                    sbErrMess.AppendLine("仮の作業データファイル削除ができませんでした。")
                    sbErrMess.AppendLine(ex.Message)
                    DbCompactStatus = backupDbCompactStatus
                    cmpSts = NaviStatus.ErrDeleteTempWorkingData
                    GoTo LB_CompactErrorExit
                End Try
            End If
        End If



        '作業ファイルの最適化
        'If cmpSts <> NaviStatus.ErrDeleteTempWorkingData Then
        'End If
        Dim dbe As DBEngine = New DBEngineClass()
        Try
            dbe.CompactDatabase(targetPath, tempWorkLogPath, Nothing, Nothing, CtrlWorkLog.DefWlogDb.SqlPassword)
            cmpSts = NaviStatus.WorkingDbCompactComplete
        Catch ex As Exception
            DbCompactStatus = backupDbCompactStatus
            If sbErrMess.Length <> 0 Then
                sbErrMess.AppendLine(vbCrLf)
            End If
            sbErrMess.AppendLine("作業データファイルの最適化ができませんでした。")
            sbErrMess.AppendLine(ex.Message)
            cmpSts = NaviStatus.ErrWorkingDbCompact
            GoTo LB_CompactErrorExit
        End Try


        '旧作業ファイルを一時退避のため、リネーム
        'If (cmpSts <> NaviStatus.ErrWorkingDbCompact) AndAlso
        '   (cmpSts <> NaviStatus.ErrDeleteTempWorkingData) Then
        'End If
        Try
            System.IO.File.Move(targetPath, tempWorkLogBackUpPath)
            cmpSts = NaviStatus.WorkingDbCompactRenameBackUpComplete
        Catch ex As Exception
            DbCompactStatus = backupDbCompactStatus
            If sbErrMess.Length <> 0 Then
                sbErrMess.AppendLine(vbCrLf)
            End If
            sbErrMess.AppendLine("作業データファイル最適化後にファイル名が変換ができませんでした。")
            sbErrMess.AppendLine(ex.Message)
            cmpSts = NaviStatus.ErrCompactFileRenameBackup
            GoTo LB_CompactErrorExit
        End Try


        '最適化ファイルを作業ファイルにリネーム
        'If (cmpSts <> NaviStatus.ErrWorkingDbCompact) AndAlso
        '   (cmpSts <> NaviStatus.ErrDeleteTempWorkingData) AndAlso
        '   (cmpSts <> NaviStatus.ErrCompactFileRenameBackup) Then
        'End If
        Try
            System.IO.File.Move(tempWorkLogPath, targetPath)
            DbCompactStatus.Status = "完了"
            DbCompactStatus.LastDate = Date.Today
            cmpSts = NaviStatus.WorkingDbCompactComplete
        Catch ex As Exception
            DbCompactStatus = backupDbCompactStatus
            If sbErrMess.Length <> 0 Then
                sbErrMess.AppendLine(vbCrLf)
            End If
            sbErrMess.AppendLine("作業データファイル最適化後にファイル名の変更ができませんでした。")
            sbErrMess.AppendLine("システム管理者に確認してください。")
            sbErrMess.AppendLine(vbCrLf)
            sbErrMess.AppendLine(ex.Message)
            cmpSts = NaviStatus.ErrWorkingDbCompact
            GoTo LB_CompactErrorExit
        End Try


        '旧作業ファイルの削除
        'If (cmpSts <> NaviStatus.ErrWorkingDbCompact) AndAlso
        '   (cmpSts <> NaviStatus.ErrDeleteTempWorkingData) AndAlso
        '   (cmpSts <> NaviStatus.ErrCompactFileRenameBackup) Then
        'End If
        Try
            System.IO.File.Delete(tempWorkLogBackUpPath)
            cmpSts = NaviStatus.WorkingDbCompactComplete
        Catch ex As Exception
            DbCompactStatus = backupDbCompactStatus
            If sbErrMess.Length <> 0 Then
                sbErrMess.AppendLine(vbCrLf)
            End If
            sbErrMess.AppendLine("作業データファイル最適化後に仮ファイルが削除できませんでした。")
            sbErrMess.AppendLine(ex.Message)
            cmpSts = NaviStatus.ErrWorkingDbCompact
            GoTo LB_CompactErrorExit
        End Try



LB_CompactErrorExit:
        cmpSts = WriteWorkLogCompactStatus(sbErrMess)
        If sbErrMess.Length <> 0 Then
            cmpSts = NaviStatus.ErrWorkingDbCompact
        Else
            cmpSts = NaviStatus.OK
        End If

        Return cmpSts

    End Function

    Private Function GetWorkLogCompactStatus(ByRef sbErrMess As System.Text.StringBuilder) As Integer
        Dim filepath As String = String.Format("{0}\{1}", CtrlWorkLog.DefWlogDb.DbPath, CompactWorkLogDbStatusCsvFileName)
        Dim sts As Integer = NaviStatus.OK

        Dim csvRead As ReadCsv = New ReadCsv
        Dim csvRecords As System.Collections.ArrayList
        Try
            csvRecords = csvRead.GetCsvFileCollection(filepath)
        Catch ex As Exception
            sbErrMess.AppendLine(ex.Message)
            Return NaviStatus.ErrReadCompactStatusFile
        End Try
        Dim count As Integer = csvRecords.Count

        For i As Integer = 0 To csvRecords.Count - 1
            Dim str() As String = csvRecords(i)
            Dim strItem As String = str(0)

            'ファイルヘッダー確認
            If i = 0 And strItem <> TempWorkLogFileCsvHeader Then
                sbErrMess.AppendLine("このファイルは、" & TempWorkLogFileCsvHeader & "ではありません")
                Return NaviStatus.ErrInvalidCompactStatusFilename
            End If

            '設定値読み込み
            Select Case strItem
                Case "ヘッダー"
                    Continue For
                Case "設定値"
                    Select Case str(1)
                        Case "コンピュータ名"
                            DbCompactStatus.ComputerName = str(2)
                        Case "最適化日"
                            If str(2) = "未設定" Then
                                DbCompactStatus.LastDate = Nothing
                            Else
                                DbCompactStatus.LastDate = CDate(str(2))
                            End If
                        Case "状況"
                            DbCompactStatus.Status = str(2)
                    End Select
                Case Else
                    Continue For
            End Select
        Next
        If ((Not (DbCompactStatus.LastDate <> Nothing)) = True) OrElse
            (DbCompactStatus.LastDate <> Date.Today) Then

            sts = NaviStatus.WorkingDbNeedCompact
        Else
            Select Case DbCompactStatus.Status
                Case "完了"
                    sts = NaviStatus.WorkingDbCompacted
                Case "最適化中"
                    sts = NaviStatus.WorkingDbNowCompacting
                Case "未完了"
                    sts = NaviStatus.WorkingDbNeedCompact
            End Select
        End If
        Return sts
    End Function
    Public Function WriteWorkLogCompactStatus(ByRef sbErrMess As System.Text.StringBuilder) As Integer
        Dim filepath As String = String.Format("{0}\{1}", CtrlWorkLog.DefWlogDb.DbPath, CompactWorkLogDbStatusCsvFileName)
        Dim sts As Integer = NaviStatus.OK
        Try
            'CSVファイルに書き込むときに使うEncoding
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

            '書き込むファイルを開く(上書き)
            Using sr As New System.IO.StreamWriter(filepath, False, enc)
                Dim sbFieldString As New System.Text.StringBuilder
                'セッティングファイル認識ヘッダ---------------------------------------------
                sbFieldString.AppendLine(TempWorkLogFileCsvHeader)
                sr.Write(sbFieldString.ToString)

                '項目ヘッダー---------------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.AppendLine("ヘッダー,項目名,値")
                sr.Write(sbFieldString.ToString)
                '---------------------------------------------------------------------------
                'ファイルリスト出力---------------------------------------------------------
                sbFieldString.Clear()
                sbFieldString.AppendLine(String.Format("設定値,コンピュータ名,{0}", DbCompactStatus.ComputerName))
                sbFieldString.AppendLine(String.Format("設定値,最適化日,{0}", DbCompactStatus.LastDate.ToShortDateString))
                sbFieldString.AppendLine(String.Format("設定値,状況,{0}", DbCompactStatus.Status))
                sr.Write(sbFieldString.ToString)
                '---------------------------------------------------------------------------
            End Using
            sts = NaviStatus.OK
        Catch ex As Exception
            If sbErrMess.Length <> 0 Then
                sbErrMess.AppendLine(vbCrLf)
            End If
            sbErrMess.AppendLine(ex.Message)
            sts = NaviStatus.ErrWriteCompactStatusFile
        End Try
        Return sts
    End Function

End Class

