Imports System.IO
Public Class FormEditPartsData
    '新規データ作成フラグ
    Private IsNewData As Boolean

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    'マスタDBのテーブル操作用
    Private CtrlDbNaviMaster As ControlDbMaster

    'マスタDBのテーブル操作用
    Private CtrlDbPartsMaster As ControlDbPartsMaster

    '部材コード名最大長定義
    Private Const MaxModelNameTextLength As Integer = 15

    '新規作成時の部品情報フォルダ名のヘッダ
    Private Const PartsDataFolderNameHeader As String = "PartsData"

    '部品形状名コンボボックスコントロール
    Private CstmShapeNameCombobox As CustomComboboxShapeNameImpl

    '形状分類コンボボックスコントロール
    Private CstmShapeCategoryCombobox As CustomComboboxShapeCategoryImpl

    'データ状態コンボボックスコントロール
    Private CstmEnableCombobox As CustomComboboxEnableImpl

    '部材情報データテーブル
    Private DtPartsData As New DataTable

    '部材画像表示用Imageオブジェクト
    Private PictureboxImage As System.Drawing.Image = Nothing

    '編集開始前のImageフォルダ内のファイルリスト
    Private OriginalPartsImageFileList As New List(Of String)

    '編集開始前のKankotsuファイルリスト
    Private OriginalKankotsuFileList As New List(Of String)

    Private TempPartsCode As String = Nothing

    Public RegistedPartsCode As String = Nothing


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="isNew">
    ''' 新規作成フラグ
    ''' </param>
    ''' <param name="partsCode">
    ''' 形状データID
    ''' </param>
    ''' <param name="mstContDb">
    ''' ControlDbMasterオブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal isNew As Boolean, ByVal partsCode As String, ByVal mstContDb As ControlDbMaster, ByVal mstPartsContDb As ControlDbPartsMaster)
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Dim dt As DateTime = DateTime.Now

        IsNewData = isNew
        If IsNewData = False Then
            ButtonRegistData.Text = "更新"
            LabelEditMode.Text = "データ編集"
            LabelEditMode.BackColor = Color.Orange
        Else
            ButtonRegistData.Text = "登録"
            LabelEditMode.Text = "新規作成"
            LabelEditMode.BackColor = Color.Yellow
        End If
        CtrlDbNaviMaster = mstContDb.Clone
        CtrlDbPartsMaster = mstPartsContDb.Clone

        If partsCode = Nothing Then
            RegistedPartsCode = Nothing
            '新規データ作成の場合の仮フォルダ作成
            TempPartsCode = GetTempFolderName(PartsDataFolderNameHeader)
            If CreatePartsDataFolder(TempPartsCode) = False Then
                MessageBox.Show(TempPartsCode & "のフォルダ作成ができませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            '新規データ作成の場合のカンコツCsvファイルの作成

        Else
            RegistedPartsCode = partsCode
            TempPartsCode = Nothing
            If CreatePartsDataFolder(RegistedPartsCode) = False Then
                MessageBox.Show(TempPartsCode & "のフォルダ作成ができませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        '各種テーブルデータの取得
        DtPartsData = CtrlDbPartsMaster.GetPartsOneDataFromTable(partsCode)
    End Sub

    Private Sub FormEditPartsData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        'コントロールのセッティング
        SetFormControlSetting()

        'コントロールへの値設定
        SetFormControlValue()

        '部材マスタテーブル確定処理
        DtPartsData.AcceptChanges()

        SetPartsImageFileListBox(RegistedPartsCode)

        SetKankotsuFileListBox(RegistedPartsCode, ListBoxKankotsuFile)
        NowInitializing = False

    End Sub
    Private Sub SetFormControlSetting()
        'カスタムコンボボックスの設定
        'データ状態コンボボックス
        CstmEnableCombobox = New CustomComboboxEnableImpl(ComboBoxDataEnable, "利用中", "利用停止", "Display", "Value")
        CstmEnableCombobox.SetComboboxDataSource()

        '部品形状名コンボボックス
        CstmShapeNameCombobox = New CustomComboboxShapeNameImpl(ComboBoxShapeName, CtrlDbNaviMaster)
        CstmShapeNameCombobox.SetComboboxDataSource()

        '形状分類コンボボックス
        CstmShapeCategoryCombobox = New CustomComboboxShapeCategoryImpl(ComboBoxShapeCategory, CtrlDbNaviMaster)
        CstmShapeCategoryCombobox.SetComboboxDataSource()

        'コントロール読取専用設定
        TextBoxRegistrationDate.ReadOnly = True
        TextBoxRegistrationUser.ReadOnly = True

        TextBoxUpdateDate.ReadOnly = True
        TextBoxUpdateUser.ReadOnly = True

    End Sub
    Private Sub SetFormControlValue()

        If IsNewData = True Then
            TextBoxPartsCode.ReadOnly = False
            SetNewPartsShapeDataToTable(SysLoginUserInfo.ManNumber)
        Else
            TextBoxPartsCode.ReadOnly = True
            DtPartsData.Rows(0)(PMTColumn.UpdateManNumber) = SysLoginUserInfo.ManNumber
        End If

        If DtPartsData.Rows(0)(PMTColumn.PartsCode) Is DBNull.Value Then
            TextBoxPartsCode.Text = Nothing
        Else
            TextBoxPartsCode.Text = CtrlDbPartsMaster.GetRowColmunContentString(DtPartsData.Rows(0), PMTColumnName(PMTColumn.PartsCode))
        End If

        '各種コントロールの値設定
        CstmEnableCombobox.SetSelectedValueInt(DtPartsData.Rows(0)(PMTColumn.DataEnable))

        TextBoxPartsName.Text = CtrlDbPartsMaster.GetRowColmunContentString(DtPartsData.Rows(0), PMTColumnName(PMTColumn.PartsName))
        TextBoxPartsModelName.Text = CtrlDbPartsMaster.GetRowColmunContentString(DtPartsData.Rows(0), PMTColumnName(PMTColumn.ModelName))

        If DtPartsData.Rows(0)(PMTColumn.PartsShapeId) IsNot DBNull.Value Then
            CstmShapeNameCombobox.SetSelectedValueInt(DtPartsData.Rows(0)(PMTColumn.PartsShapeId))
            DrawPartsShape(PictureBoxPartsShape, DtPartsData.Rows(0)(PMTColumn.PartsShapeId))
        Else
            CstmShapeNameCombobox.SetSelectedValueDbNull()
        End If

        Dim tb As New DataTable
        tb = DirectCast(CstmShapeNameCombobox.MyCombobox.DataSource, DataTable).Copy

        If CstmShapeNameCombobox.GetSelectedValueInt <> -1 Then
            '形状IDに対応した分類を表示
            CstmShapeCategoryCombobox.SetSelectedValueInt(tb.Rows(CstmShapeNameCombobox.MyCombobox.SelectedIndex)(PSTColumn.PartsShapeTypeId))
        Else
            CstmShapeCategoryCombobox.SetSelectedValueDbNull()

        End If
        tb.Dispose()
        If DtPartsData.Rows(0)(PMTColumn.Note) IsNot DBNull.Value Then
            TextBoxNote.Text = DtPartsData.Rows(0)(PMTColumn.Note)
        Else
            TextBoxNote.Text = Nothing
        End If

        If DtPartsData.Rows(0)(PMTColumn.ChangeHistory) IsNot DBNull.Value Then
            TextBoxUpdateHistory.Text = DtPartsData.Rows(0)(PMTColumn.ChangeHistory)
        Else
            TextBoxUpdateHistory.Text = Nothing
        End If

        TextBoxRegistrationDate.Text = CtrlDbPartsMaster.GetRowColmunContentString(DtPartsData.Rows(0), PMTColumnName(PMTColumn.RegistDate))
        TextBoxUpdateDate.Text = CtrlDbPartsMaster.GetRowColmunContentString(DtPartsData.Rows(0), PMTColumnName(PMTColumn.UpdateDate))

        TextBoxRegistrationUser.Text = CtrlDbNaviMaster.GetRegisterName(DtPartsData.Rows(0), PMTColumnName(PMTColumn.RegistManNumber))
        TextBoxUpdateUser.Text = CtrlDbNaviMaster.GetRegisterName(DtPartsData.Rows(0), PMTColumnName(PMTColumn.UpdateManNumber))



    End Sub
    Private Sub SetPartsImageFileListBox(ByVal partsCode As String)
        Dim partsImageFolder As String = Nothing

        If partsCode <> Nothing Then
            partsImageFolder = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
            OriginalPartsImageFileList = GetAllFileList(partsImageFolder)
            ListBoxPartsImage.Items.Clear()

            For Each file As String In OriginalPartsImageFileList
                ListBoxPartsImage.Items.Add(file)
            Next
        Else
            ListBoxPartsImage.Items.Clear()
        End If
    End Sub


    ''' <summary>
    ''' 部品形状管理の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewPartsShapeDataToTable(ByVal registerManNumber As String)

        '部材データ設定
        DtPartsData.Rows.Add()
        DtPartsData.Rows(0)(PMTColumn.PartsCode) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.DataEnable) = True
        DtPartsData.Rows(0)(PMTColumn.PartsName) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.ModelName) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.PartsShapeId) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.IsRegistedPartsImage) = False
        DtPartsData.Rows(0)(PMTColumn.IsRegistedKankotsu) = False
        DtPartsData.Rows(0)(PMTColumn.Note) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.ChangeHistory) = Nothing

        DtPartsData.Rows(0)(PMTColumn.RegistDate) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.RegistManNumber) = registerManNumber
        DtPartsData.Rows(0)(PMTColumn.UpdateDate) = DBNull.Value
        DtPartsData.Rows(0)(PMTColumn.UpdateManNumber) = Nothing

        DtPartsData.AcceptChanges()
    End Sub
    ''' <summary>
    ''' 部品描画処理メイン
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawPartsShape(ByVal picbox As PictureBox, ByVal partsShapeId As Integer)
        '描画図形情報リスト（本クラスでは、１個しか使わない）
        Dim drawShapeListA As New List(Of DrawShapeInfo)

        '部品形状管理テーブル
        Dim tbPartsShape As New DataTable

        '描画キャンバスサイズ
        Dim cSize As New DoubleSize
        '描画キャンバスの原点位置指定
        Dim cOriginAlign As Integer = Align.MiddleCenter
        '描画位置構造体
        Dim drawPosi As New DrawPosition
        '描画図形データ
        Dim pShapeData As New PartsShapeData

        cSize.Width = CType(picbox.Width, Double)
        cSize.Height = CType(picbox.Height, Double)

        drawPosi.X = 0
        drawPosi.Y = 0


        '各種テーブルデータの取得
        tbPartsShape = CtrlDbNaviMaster.GetPartsShapeOneDataFromTable(partsShapeId)
        '部品形状データ作成
        pShapeData.SetShapeData(tbPartsShape.Rows(0))


        drawShapeListA.Add(New DrawShapeInfo(cSize, cOriginAlign, drawPosi, 0.0F, pShapeData))
        drawShapeListA(0).PartsShape.SetShapeData(tbPartsShape.Rows(0))

        Dim drawPartsShape As New DrawPartsShape(DrawParsStatus.MonitorSelectedParts)
        drawPartsShape.SetDrawRatio(1D, 1D)
        drawPartsShape.DrawOneParts(PictureBoxPartsShape, drawShapeListA(0))
    End Sub
    Private Sub ComboBoxShapeName_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxShapeName.SelectedValueChanged

        If NowInitializing = True Then
            Exit Sub
        End If

        If (CstmShapeNameCombobox.MyCombobox.SelectedIndex = -1) OrElse (CstmShapeNameCombobox.MyCombobox.SelectedIndex = 0) Then
            DtPartsData.Rows(0)(PMTColumn.PartsShapeId) = DBNull.Value
        Else
            DtPartsData.Rows(0)(PMTColumn.PartsShapeId) = CstmShapeNameCombobox.GetSelectedValueInt
        End If


        If DtPartsData.Rows(0)(PMTColumn.PartsShapeId) IsNot DBNull.Value Then
            CstmShapeNameCombobox.SetSelectedValueInt(DtPartsData.Rows(0)(PMTColumn.PartsShapeId))
        Else
            CstmShapeNameCombobox.SetSelectedValueDbNull()
        End If

        Dim tb As New DataTable
        tb = DirectCast(CstmShapeNameCombobox.MyCombobox.DataSource, DataTable).Copy

        If (CstmShapeNameCombobox.MyCombobox.SelectedIndex = -1) OrElse (CstmShapeNameCombobox.MyCombobox.SelectedIndex = 0) Then
            '先頭の空欄を表示
            CstmShapeCategoryCombobox.SetSelectedValueDbNull()
        Else
            '形状IDに対応した分類を表示
            CstmShapeCategoryCombobox.SetSelectedValueInt(tb.Rows(CstmShapeNameCombobox.MyCombobox.SelectedIndex)(PSTColumn.PartsShapeTypeId))

        End If
        tb.Dispose()

        IsStartEdit = True


    End Sub

    Private Sub TextBoxPartsCode_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsCode.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.PartsCode) = TextBoxPartsCode.Text
        IsStartEdit = True

    End Sub

    Private Sub ComboBoxDataEnable_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDataEnable.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.DataEnable) = CstmEnableCombobox.GetSelectedValueInt
        IsStartEdit = True

    End Sub

    Private Sub TextBoxPartsName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsName.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.PartsName) = TextBoxPartsName.Text
        IsStartEdit = True

    End Sub

    Private Sub TextBoxPartsModelName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsModelName.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.ModelName) = TextBoxPartsModelName.Text
        IsStartEdit = True

    End Sub

    Private Sub TextBoxNote_Leave(sender As Object, e As EventArgs) Handles TextBoxNote.Leave
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.Note) = TextBoxNote.Text
        IsStartEdit = True
    End Sub

    Private Sub TextBoxUpdateHistory_Leave(sender As Object, e As EventArgs) Handles TextBoxUpdateHistory.Leave
        If NowInitializing = True Then
            Exit Sub
        End If
        DtPartsData.Rows(0)(PMTColumn.ChangeHistory) = TextBoxUpdateHistory.Text
        IsStartEdit = True
    End Sub

    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim connectString As String = CtrlDbPartsMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbPartsMaster.GetMasterDbPathString()
        Dim SqlPartsCodeData As String = Nothing
        Dim deleteFile As New List(Of String)
        Dim errMess As String = ""
        If IsNewData = True Then
            '新規データ登録
            If IsExistModifiedData() = False Then
                MessageBox.Show("登録するデータが入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If (TextBoxPartsCode.Text IsNot Nothing) AndAlso (TextBoxPartsCode.Text <> "") Then
                If MaxModelNameTextLength <= TextBoxPartsCode.Text.Length Then
                    MessageBox.Show("部材コードは、半角" & MaxModelNameTextLength.ToString & "文字内で入力して下さい。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CtrlDbPartsMaster.IsExistPartsCode(TextBoxPartsCode.Text) = True Then
                    MessageBox.Show("部材コードは既に登録されています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                MessageBox.Show("部材コードが入力されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            DtPartsData.Rows(0)(PMTColumn.RegistDate) = dt

            'DBのデータ登録SQL作成
            SqlPartsCodeData = CtrlDbPartsMaster.GetInsertSqlString(CtrlDbPartsMaster.DefPtMstDb.TablePartsMaster, DtPartsData.Rows(0), "ID")

            Dim insertResult As Boolean
            insertResult = CtrlDbPartsMaster.UpdateTableWithSQL(connectString, dbnameA, SqlPartsCodeData)
            If insertResult = True Then
                DtPartsData.AcceptChanges()
                RegistedPartsCode = TextBoxPartsCode.Text
                Dim pf As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root

                Dim dResult As DialogResult
                Do While True
                    '登録前の仮フォルダ名を登録後の部材コード名に変更
                    If RenameFileFolder(pf & "\" & TempPartsCode, pf & "\" & RegistedPartsCode) <> 0 Then
                        Dim mess As New System.Text.StringBuilder
                        mess.Append("フォルダ名の変更ができませんでした。" & vbCrLf)
                        mess.Append("変更前：" & pf & "\" & TempPartsCode & vbCrLf)
                        mess.Append("変更後：" & pf & "\" & RegistedPartsCode & vbCrLf)
                        mess.Append(vbCrLf)
                        mess.Append("リトライしますか？")

                        dResult = MessageBox.Show(mess.ToString, "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                        If dResult = DialogResult.No Then
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop

                '不要ファイルの削除
                DeleteNoUseImageFiles(RegistedPartsCode)

                'カンコツファイルCSV書出し
                WriteKankotsuCsvFile(RegistedPartsCode)


                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Else
            '既存データ更新
            If IsExistModifiedData() = False Then
                MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim dt As DateTime = DateTime.Now
            DtPartsData.Rows(0)(PMTColumn.UpdateDate) = dt

            'DBのデータ更新SQL作成
            SqlPartsCodeData = CtrlDbPartsMaster.GetModifiedSqlString(CtrlDbPartsMaster.DefPtMstDb.TablePartsMaster, DtPartsData.Rows(0), PMTColumnName(PMTColumn.ID))

            Dim insertResult As Boolean
            insertResult = CtrlDbPartsMaster.UpdateTableWithSQL(connectString, dbnameA, SqlPartsCodeData)
            If insertResult = True Then
                DtPartsData.AcceptChanges()
                '不要ファイルの削除
                DeleteNoUseImageFiles(RegistedPartsCode)
                'カンコツファイルCSV書出し
                WriteKankotsuCsvFile(RegistedPartsCode)

                IsStartEdit = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub
    Private Function WriteKankotsuCsvFile(ByVal partsCode As String) As Boolean
        'カンコツファイルCSV書出し
        Dim CtrlKankotsu As New ControlKankotsuCsv
        Dim kankotsuFolder As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode
        Dim kankotsuList As New List(Of String)
        Dim errDetailsKankotsu As String = Nothing
        Dim dResult As DialogResult
        Dim sts As Boolean = False

        kankotsuList.Clear()
        For i As Integer = 0 To ListBoxKankotsuFile.Items.Count - 1
            kankotsuList.Add(ListBoxKankotsuFile.Items(i))
        Next

        Do While True
            If CtrlKankotsu.WriteFile(kankotsuFolder, kankotsuList, errDetailsKankotsu) = False Then
                Dim errMessKankotsu As New System.Text.StringBuilder
                errMessKankotsu.Append("カンコツファイルCSVが作成できませんでした。" & vbCrLf)
                errMessKankotsu.Append(vbCrLf)
                errMessKankotsu.Append("リトライしますか？")
                Using errMessDialog As New FormMessageDetailsDialog(errMessKankotsu.ToString, "ファイル削除エラー", errDetailsKankotsu, MessageBoxButtons.YesNo)
                    dResult = errMessDialog.ShowDialog()
                    If dResult = DialogResult.No Then
                        Exit Do
                    End If
                End Using
            Else
                sts = True
                Exit Do
            End If
        Loop
        Return sts
    End Function
    Private Function DeleteNoUseImageFiles(ByVal partsCode As String) As Boolean
        Dim deleteFile As New List(Of String)
        Dim errMess As String = ""
        Dim dResult As DialogResult
        Dim sts As Boolean = False

        deleteFile = GetDeleteImageFileList(partsCode)
        Do While True
            If DeleteAllPartsImageFile(partsCode, deleteFile, errMess) = False Then
                sts = False
                Dim errMessDelete As New Text.StringBuilder
                errMessDelete.Append("データ登録時に不要ファイルの削除が出来ませんでした。" & vbCrLf)
                errMessDelete.Append("ファイルの詳細は、下記を参照して下さい。" & vbCrLf)
                errMessDelete.Append("リトライしますか？" & vbCrLf)
                errMessDelete.Append(vbCrLf)

                Using errMessDialog As New FormMessageDetailsDialog(errMessDelete.ToString, "ファイル削除エラー", errMess, MessageBoxButtons.YesNo)
                    dResult = errMessDialog.ShowDialog()
                    If dResult = DialogResult.No Then
                        Exit Do
                    End If

                End Using
            Else
                sts = True
                Exit Do
            End If
        Loop

        Return sts
    End Function
    ''' <summary>
    ''' partsCodeで指定された部材コードのImageフォルダから削除するファイルのリスト配列を取得する
    ''' Imageフォルダ内に存在するファイルとListBoxPartsImageに設定されたファイルの差分
    ''' </summary>
    ''' <param name="partsCode">
    ''' 部材コード文字列
    ''' </param>
    ''' <returns>
    ''' 取得した削除するファイル名のリスト配列
    ''' </returns>
    Private Function GetDeleteImageFileList(ByVal partsCode As String) As List(Of String)
        Dim partsImageFolder As String = Nothing
        Dim existFile As New List(Of String)
        Dim delFile As New List(Of String)
        Dim find As Boolean = False

        If partsCode <> Nothing Then
            partsImageFolder = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
            existFile = GetAllFileList(partsImageFolder)
            For Each f As String In existFile
                find = False
                For i As Integer = 0 To ListBoxPartsImage.Items.Count - 1
                    If f = ListBoxPartsImage.Items(i).ToString Then
                        find = True
                        Exit For
                    End If
                Next
                If find = False Then
                    delFile.Add(f)
                End If
            Next

        Else

        End If

        Return delFile
    End Function
    Private Function DeleteAllPartsImageFile(ByVal partsCode As String, ByVal delFile As List(Of String), ByRef errMessage As String) As Boolean
        Dim hasMessAdded As Boolean = False
        Dim result As Boolean = True
        Dim errMess As New Text.StringBuilder
        Dim mess As String = ""

        Dim delFileDir As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode & "\" & PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName
        Dim delFilePath As String = Nothing

        For Each f As String In delFile
            delFilePath = delFileDir & "\" & f
            If DeleteFile(delFilePath, mess) <> 0 Then
                If hasMessAdded = False Then
                    errMess.Append("以下の画像ファイルの削除が出来ませんでした。" & vbCrLf)
                    errMess.Append(vbCrLf)
                    hasMessAdded = True
                End If
                errMess.Append(mess & vbCrLf)
                errMess.Append(vbCrLf)
                result = False
            End If
        Next

        errMessage = errMess.ToString
        Return result
    End Function

    ''' <summary>
    ''' 部品形状分類の更新有無情報を取得する。
    ''' </summary>
    ''' <returns>
    ''' True:更新有　False:更新なし
    ''' </returns>
    ''' <remarks></remarks>
    Private Function IsExistModifiedData() As Boolean
        If IsStartEdit = True Then
            Return True
        End If
        For Each row As DataRow In DtPartsData.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next
        Return False
    End Function


    Private Sub FormEditPartsData_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If PictureboxImage IsNot Nothing Then
            PictureboxImage.Dispose()
        End If

    End Sub


    Private Sub ListBoxPartsImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPartsImage.SelectedIndexChanged
        If NowInitializing = True Then
            Exit Sub
        End If

        ListBoxPartsImageSelectedIndexChange(ListBoxPartsImage, PictureBoxPartsImage, RegistedPartsCode, TempPartsCode)

    End Sub
    Private Sub ButtonAddImageFile_Click(sender As Object, e As EventArgs) Handles ButtonAddImageFile.Click
        Dim selImageFile As String = SelectImageFileByDialog("")
        If selImageFile = Nothing Then
            Exit Sub
        End If

        Dim fileName As String = Nothing
        Dim destPath As New System.Text.StringBuilder

        destPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\")
        If RegistedPartsCode <> Nothing Then
            destPath.Append(RegistedPartsCode & "\")
        Else
            destPath.Append(TempPartsCode & "\")
        End If
        Dim selFileName As String = System.IO.Path.GetFileName(selImageFile)
        destPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName & "\")

        destPath.Append(selFileName)
        If System.IO.File.Exists(destPath.ToString) = True Then
            MessageBox.Show("同一ファイル名が既にあります。", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CopyFileAsNewName(selImageFile, destPath.ToString) <> 0 Then
            MessageBox.Show("ファイルコピーができませんでした。", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        ListBoxPartsImage.Items.Add(selFileName)
        ListBoxPartsImage.SelectedIndex = ListBoxPartsImage.Items.Count - 1

        If DtPartsData.Rows(0)(PMTColumn.IsRegistedPartsImage) = False Then
            DtPartsData.Rows(0)(PMTColumn.IsRegistedPartsImage) = True
        End If

        IsStartEdit = True

    End Sub
    Private Sub ButtonDeleteImageFile_Click(sender As Object, e As EventArgs) Handles ButtonDeleteImageFile.Click
        Dim selIndex As Integer = ListBoxPartsImage.SelectedIndex
        If selIndex <> -1 Then
            ListBoxPartsImage.Items.RemoveAt(selIndex)
            selIndex -= 1
            ListBoxPartsImage.SelectedIndex = selIndex

            If ListBoxPartsImage.Items.Count = 0 Then
                If DtPartsData.Rows(0)(PMTColumn.IsRegistedPartsImage) = True Then
                    DtPartsData.Rows(0)(PMTColumn.IsRegistedPartsImage) = False
                End If
            End If

            IsStartEdit = True
        Else
            MessageBox.Show("削除するファイルが選択されていません", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub ComboBoxShapeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxShapeName.SelectedIndexChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        If DtPartsData.Rows(0)(PMTColumn.PartsShapeId) IsNot DBNull.Value Then
            DrawPartsShape(PictureBoxPartsShape, DtPartsData.Rows(0)(PMTColumn.PartsShapeId))
        Else
            PictureBoxPartsShape.Image = Nothing
        End If
        IsStartEdit = True

    End Sub

    Private Sub ButtonAddKankotsuFile_Click(sender As Object, e As EventArgs) Handles ButtonAddKankotsuFile.Click

        Dim selectFile As String = SelectFileByDialog(PartsInsertNaviAppConfigData.SystemDataPath.Kankotsu)

        If selectFile = "" Then
            Exit Sub
        End If

        Dim replacePath As String = Nothing

        If selectFile.IndexOf(PartsInsertNaviAppConfigData.SystemDataPath.Kankotsu & "\") >= 0 Then
            replacePath = selectFile.Replace(PartsInsertNaviAppConfigData.SystemDataPath.Kankotsu & "\", "")
        Else
            MessageBox.Show("ファイルは、" & PartsInsertNaviAppConfigData.SystemDataPath.Kankotsu & "内から選択してください。", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim find As Boolean = False
        For i As Integer = 0 To ListBoxKankotsuFile.Items.Count - 1
            If ListBoxKankotsuFile.Items(i) = replacePath Then
                find = True
                Exit For
            End If
        Next
        If find = True Then
            MessageBox.Show("同一ファイル名が既にあります。", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            ListBoxKankotsuFile.Items.Add(replacePath)
            If DtPartsData.Rows(0)(PMTColumn.IsRegistedKankotsu) = False Then
                DtPartsData.Rows(0)(PMTColumn.IsRegistedKankotsu) = True
            End If
        End If
        IsStartEdit = True

    End Sub

    Private Sub ButtonDeleteKankotsuFile_Click(sender As Object, e As EventArgs) Handles ButtonDeleteKankotsuFile.Click
        Dim selIndex As Integer = ListBoxKankotsuFile.SelectedIndex
        If selIndex <> -1 Then
            ListBoxKankotsuFile.Items.RemoveAt(selIndex)
            selIndex -= 1
            ListBoxKankotsuFile.SelectedIndex = selIndex
            IsStartEdit = True
            If ListBoxPartsImage.Items.Count = 0 Then
                If DtPartsData.Rows(0)(PMTColumn.IsRegistedKankotsu) = True Then
                    DtPartsData.Rows(0)(PMTColumn.IsRegistedKankotsu) = False
                End If
            End If

        Else
            MessageBox.Show("削除するファイルが選択されていません", "ファイル確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub ButtonOpenKankotsuFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenKankotsuFile.Click
        OpenKankotsuFileSelectByListBox(ListBoxKankotsuFile)
    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
    Private Sub FormEditPartsData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim isClose As Boolean = False
        isClose = ConfirmFormClosing()
        If isClose = False Then
            e.Cancel = True
        End If
    End Sub
    Private Function ConfirmFormClosing() As Boolean
        Dim isClose As Boolean = False

        Dim delPath As New Text.StringBuilder
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                DtPartsData.AcceptChanges()

                '不要データ削除
                If IsNewData = True Then
                    '新規データの場合は、仮データフォルダ以下全て削除
                    delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\")
                    delPath.Append(TempPartsCode & "\")
                    DeleteFile(delPath.ToString)
                Else
                    '既存データの場合は、OriginalPartsImageFileList以外のファイルを削除
                    delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\")
                    delPath.Append(RegistedPartsCode & "\")
                    delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.ImageFolderName)
                    Dim existFile As New List(Of String)
                    existFile = GetAllFileList(delPath.ToString)
                    delPath.Append("\")
                    Dim delFile As String = Nothing
                    Dim find As Boolean = False
                    For Each f As String In existFile
                        find = False
                        For Each d As String In OriginalPartsImageFileList
                            If f = d Then
                                find = True
                                Exit For
                            End If
                        Next
                        If find = False Then
                            delFile = delPath.ToString & f
                            DeleteFile(delFile)
                        End If
                    Next
                End If
                isClose = True
            End If
        Else
            If IsNewData = True Then
                '新規データの場合は、仮データフォルダ以下全て削除
                delPath.Append(PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\")
                delPath.Append(TempPartsCode)
                DeleteFile(delPath.ToString)
            End If
            isClose = True
        End If
        Return isClose
    End Function

End Class

