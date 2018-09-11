Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class FormEditPartsShape
    Private Enum DbUpdateMode
        Insert
        Modify
    End Enum
    '新規データ作成フラグ
    Private IsNewData As Boolean

    '追加/更新する部品形状のデータID
    Private EdittingPartsShapeId As Integer
    '部品形状管理テーブル
    Private TablePartsShape As New DataTable

    '初期化処理中
    Private NowInitializing As Boolean = True

    'データ編集開始フラグ
    Private IsStartEdit As Boolean = False

    '部品形状管理テーブル操作用
    Private CtrlDbNaviMaster As ControlDbMaster

    '部品形状名最大長定義
    Private Const MaxShapeNameTextLength As Integer = 20

    '部品識別符号位置コンボボックスコントロール
    Private CtrlPartsMarkPosiCombobox As CustomComboboxPartsMarkPosiImpl
    '形状分類コンボボックスコントロール
    Private CtrlShapeCategoryCombobox As CustomComboboxShapeCategoryImpl
    'データ状態コンボボックスコントロール
    Private CtrlEnableCombobox As CustomComboboxEnableImpl
    '部品形状コンボボックスコントロール
    Private CtrlShapeTypeCombobox As CustomComboboxShapeTypeImpl
    '部品原点位置コンボボックスコントロール
    Private CtrlOriginAlignCombobox As CustomComboboxShapeOriginImpl

    'データ整備コンボボックスコントロール
    Private CtrlDataCommitCombobox As CustomComboboxEnableImpl

    '描画図形情報リスト（本クラスでは、１個しか使わない）
    Private DrawShapeList As New List(Of DrawShapeInfo)

    '描画図形データ
    Private PartsShapeData As New PartsShapeData

    '描画率構造体
    Private CtrlDrawRatio As New ControlDrawRatio

    '描画位置構造体
    Private drawPosi As New DrawPosition

    '描画キャンバス構造体
    Private CnvsSize As New DoubleSize

    '描画キャンバスの原点位置指定
    Private CnvsOriginAlign As Integer = Align.MiddleCenter
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="isNew">
    ''' 新規作成フラグ
    ''' </param>
    ''' <param name="shapeId">
    ''' 形状データID
    ''' </param>
    ''' <param name="ctrlDb">
    ''' ControlDbMasterオブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal isNew As Boolean, ByVal shapeId As String, ByVal ctrlDb As ControlDbMaster)
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        IsNewData = isNew
        EdittingPartsShapeId = shapeId
        If IsNewData = False Then
            ButtonRegistData.Text = "更新"
        Else
            ButtonRegistData.Text = "登録"
        End If
        CtrlDbNaviMaster = ctrlDb.Clone
    End Sub


    ''' <summary>
    ''' フォーム読み込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' フォーム読み込み処理時は、NowInitializingをTrueにし、プロパティ変更等によるイベント発生を抑制している。
    ''' </remarks>
    Private Sub FormEditPartsShape_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NowInitializing = True

        'カスタムコンボボックスの設定
        '部品形状コンボボックス
        CtrlShapeTypeCombobox = New CustomComboboxShapeTypeImpl(ComboBoxShapeType)
        CtrlShapeTypeCombobox.SetComboboxDataSource()

        '識別符号位置コンボボックス
        CtrlPartsMarkPosiCombobox = New CustomComboboxPartsMarkPosiImpl(ComboBoxMarkPosi)
        CtrlPartsMarkPosiCombobox.SetComboboxDataSource()

        '形状分類コンボボックス
        CtrlShapeCategoryCombobox = New CustomComboboxShapeCategoryImpl(ComboBoxShapeCategory, CtrlDbNaviMaster)
        CtrlShapeCategoryCombobox.SetComboboxDataSource()

        'データ状態コンボボックス
        CtrlEnableCombobox = New CustomComboboxEnableImpl(ComboBoxDataEnable, "利用中", "利用停止", "Display", "Value")
        CtrlEnableCombobox.SetComboboxDataSource()

        '部品原点位置コンボボックス
        CtrlOriginAlignCombobox = New CustomComboboxShapeOriginImpl(ComboBoxOriginAlign)
        CtrlOriginAlignCombobox.SetComboboxDataSource()

        'データ整備コンボボックス
        CtrlDataCommitCombobox = New CustomComboboxEnableImpl(ComboBoxDataCommit, "完了", "未完了", "Display", "Value")
        CtrlDataCommitCombobox.SetComboboxDataSource()

        '各種テーブルデータの取得
        TablePartsShape = CtrlDbNaviMaster.GetPartsShapeOneDataFromTable(EdittingPartsShapeId)

        'コントロール読取専用設定
        TextBoxId.ReadOnly = True
        TextBoxRegistrationDate.ReadOnly = True
        TextBoxRegistrationUser.ReadOnly = True

        TextBoxUpdateDate.ReadOnly = True
        TextBoxUpdateUser.ReadOnly = True

        If IsNewData = True Then
            SetNewPartsShapeDataToTable(SysLoginUserInfo.ManNumber)
        Else
            TablePartsShape.Rows(0)(PSTColumn.UpdateManNumber) = SysLoginUserInfo.ManNumber
        End If

        If EdittingPartsShapeId = Nothing Then
            TextBoxId.Text = "新規"
        Else
            TextBoxId.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.ID))
        End If

        '各種コントロールの値設定
        CtrlEnableCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.DataEnable))
        TextBoxPartsShapeName.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.PartsShapeName))
        CtrlShapeCategoryCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.PartsShapeTypeId))
        CtrlDataCommitCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.DataCommit))

        TextBoxPartHeight.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.PartsHeight))
        TextBoxPartsWidth.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.PartsWidth))

        CtrlShapeTypeCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.PartsShapeId))

        CheckBoxUseMark.Checked = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.UseMarker))

        CtrlPartsMarkPosiCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.MarkerPosi))
        CtrlOriginAlignCombobox.SetSelectedValueInt(TablePartsShape.Rows(0)(PSTColumn.OriginPosi))
        TextBoxNote.Text = TablePartsShape.Rows(0)(PSTColumn.ChangeHistory)

        TextBoxRegistrationDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.RegistDate))
        TextBoxUpdateDate.Text = CtrlDbNaviMaster.GetRowColmunContentString(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.UpdateDate))

        TextBoxRegistrationUser.Text = CtrlDbNaviMaster.GetRegisterName(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.RegistManNumber))
        TextBoxUpdateUser.Text = CtrlDbNaviMaster.GetRegisterName(TablePartsShape.Rows(0), PSTColumnName(PSTColumn.UpdateManNumber))

        '部品形状テーブル確定処理
        TablePartsShape.AcceptChanges()

        '部品形状データ作成
        PartsShapeData.SetShapeData(TablePartsShape.Rows(0))

        '部品形状情報データをリスト登録
        drawPosi.X = 0
        drawPosi.Y = 0
        CnvsSize.Width = CType(PictureBox1.Width, Double)
        CnvsSize.Height = CType(PictureBox1.Height, Double)
        DrawShapeList.Add(New DrawShapeInfo(CnvsSize, CnvsOriginAlign, drawPosi, 0.0F, PartsShapeData))
        DrawPartsShape()

        NowInitializing = False

    End Sub
    ''' <summary>
    ''' 部品描画処理メイン
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawPartsShape()
        Dim drawPartsShape As New DrawPartsShape(DrawParsStatus.MonitorSelectedParts)
        drawPartsShape.SetDrawRatio(1, 1)
        drawPartsShape.DrawOneParts(PictureBox1, DrawShapeList(0))

    End Sub

    ''' <summary>
    ''' 部品形状管理の初期テーブルデータを設定する。
    ''' </summary>
    ''' <param name="registerManNumber">
    ''' 登録者のマンナンバー
    ''' </param>
    ''' <remarks></remarks>
    Private Sub SetNewPartsShapeDataToTable(ByVal registerManNumber As String)

        '部品形状管理データ設定
        'TablePartsShape.Rows.Add()
        'TablePartsShape.Rows(0)(PSTColumn.ID) = DBNull.Value
        'TablePartsShape.Rows(0)(PSTColumn.DataEnable) = True
        'TablePartsShape.Rows(0)(PSTColumn.PartsShapeName) = DBNull.Value
        'TablePartsShape.Rows(0)(PSTColumn.PartsShapeTypeId) = 0
        'TablePartsShape.Rows(0)(PSTColumn.PartsHeight) = 10
        'TablePartsShape.Rows(0)(PSTColumn.PartsWidth) = 10
        'TablePartsShape.Rows(0)(PSTColumn.PartsShapeId) = Shape.Retacgle
        'TablePartsShape.Rows(0)(PSTColumn.UseMarker) = True
        'TablePartsShape.Rows(0)(PSTColumn.MarkerPosi) = Align.BottomLeft
        'TablePartsShape.Rows(0)(PSTColumn.ChangeHistory) = ""
        'TablePartsShape.Rows(0)(PSTColumn.OriginPosi) = Align.BottomLeft

        'TablePartsShape.Rows(0)(PSTColumn.RegistDate) = DBNull.Value
        'TablePartsShape.Rows(0)(PSTColumn.RegistManNumber) = registerManNumber
        'TablePartsShape.Rows(0)(PSTColumn.UpdateDate) = DBNull.Value
        'TablePartsShape.Rows(0)(PSTColumn.UpdateManNumber) = Nothing

        TablePartsShape.Clear()
        TablePartsShape.Rows.Add(CtrlDbNaviMaster.GetNewPartsShapeNameDataRow(TablePartsShape))
        TablePartsShape.Rows(0)(PSTColumn.RegistManNumber) = registerManNumber
        TablePartsShape.AcceptChanges()

    End Sub
    ''' <summary>
    ''' データ有効コンボボックスSelectedValueChanged処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxDataEnable_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDataEnable.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.DataEnable) = CtrlEnableCombobox.GetSelectedValueInt
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 部品形状名テキスト変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxPartsShapeName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsShapeName.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.PartsShapeName) = TextBoxPartsShapeName.Text
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()
        IsStartEdit = True
    End Sub
    ''' <summary>
    ''' 形状分類コンボボックス変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxShapeCategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxShapeCategory.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.PartsShapeTypeId) = CtrlShapeCategoryCombobox.GetSelectedValueInt
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 部品高さテキスト変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxPartHeight_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartHeight.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        Try
            TablePartsShape.Rows(0)(PSTColumn.PartsHeight) = CType(TextBoxPartHeight.Text, Double)
            DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
            DrawPartsShape()
        Catch ex As Exception

        End Try
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 部品幅テキスト変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxPartsWidth_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPartsWidth.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        Try
            TablePartsShape.Rows(0)(PSTColumn.PartsWidth) = CType(TextBoxPartsWidth.Text, Double)
            DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
            DrawPartsShape()
        Catch ex As Exception

        End Try
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 識別符号有無チェックボックス変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBoxUseMark_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUseMark.CheckedChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        IsStartEdit = True
        TablePartsShape.Rows(0)(PSTColumn.UseMarker) = CheckBoxUseMark.Checked
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))

        DrawPartsShape()
        If CheckBoxUseMark.Checked = True Then
            CtrlPartsMarkPosiCombobox.MyCombobox.Visible = True
        Else
            CtrlPartsMarkPosiCombobox.MyCombobox.Visible = False
        End If

    End Sub
    ''' <summary>
    ''' 識別符号位置コンボボックス変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxMarkPosi_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMarkPosi.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.MarkerPosi) = CtrlPartsMarkPosiCombobox.GetSelectedValueInt
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()

        IsStartEdit = True


    End Sub
    ''' <summary>
    ''' 原点配置コンボボックス変更処理(ComboBoxOriginAlign)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxOriginAlign_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxOriginAlign.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.OriginPosi) = CtrlOriginAlignCombobox.GetSelectedValueInt
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()

        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 備考欄テキスト変更処理(TextBoxNote)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxNote_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNote.TextChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.ChangeHistory) = TextBoxNote.Text
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()
        IsStartEdit = True

    End Sub
    ''' <summary>
    ''' 形状コンボボックス変更処理(ComboBoxShapeNo)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxShapeNo_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxShapeType.SelectedValueChanged
        If NowInitializing = True Then
            Exit Sub
        End If
        TablePartsShape.Rows(0)(PSTColumn.PartsShapeId) = CtrlShapeTypeCombobox.GetSelectedValueInt
        DrawShapeList(0).PartsShape.SetShapeData(TablePartsShape.Rows(0))
        DrawPartsShape()
        IsStartEdit = True
    End Sub


    ''' <summary>
    ''' 登録/更新ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonRegistData_Click(sender As Object, e As EventArgs) Handles ButtonRegistData.Click
        Dim connectString As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()
        Dim updateResult As Boolean = False

        If IsNewData = True Then
            If IsExistModifiedData() = False Then
                MessageBox.Show("登録するデータが入力されていません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If (TextBoxPartsShapeName.Text IsNot Nothing) AndAlso (TextBoxPartsShapeName.Text <> "") Then
                If MaxShapeNameTextLength <= TextBoxPartsShapeName.Text.Length Then
                    MessageBox.Show("部品形状分類名称は、半角30文字(全角15文字)内で入力して下さい。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CtrlDbNaviMaster.IsExistPartsShapeName(TextBoxPartsShapeName.Text) = True Then
                    MessageBox.Show("部品形状分類名称は既に登録されています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                MessageBox.Show("部品形状分類名称が入力されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            updateResult = InsertOrModifyPartsShapeData(DbUpdateMode.Insert)

        Else
            If IsExistModifiedData() = False Then
                MessageBox.Show("データが変更されていないので、更新する必要がありません", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            updateResult = InsertOrModifyPartsShapeData(DbUpdateMode.Modify)

        End If
    End Sub
    Private Function InsertOrModifyPartsShapeData(ByVal mode As Integer) As Boolean
        Dim connectString As String = CtrlDbNaviMaster.GetMasterDbConnectString()
        Dim dbnameA As String = CtrlDbNaviMaster.GetMasterDbPathString()

        Dim dt As DateTime = DateTime.Now
        Dim SqlPartsShape As String = Nothing

        Select Case mode
            Case DbUpdateMode.Insert
                TablePartsShape.Rows(0)(PSTColumn.RegistDate) = dt
                TablePartsShape.Rows(0)(PSTColumn.RegistManNumber) = SysLoginUserInfo.ManNumber
                SqlPartsShape = CtrlDbNaviMaster.GetInsertSqlString(CtrlDbNaviMaster.DefMstDb.TablePartsShapeMaster, TablePartsShape.Rows(0), "ID")
            Case DbUpdateMode.Modify
                TablePartsShape.Rows(0)(PSTColumn.UpdateDate) = dt
                TablePartsShape.Rows(0)(PSTColumn.UpdateManNumber) = SysLoginUserInfo.ManNumber
                SqlPartsShape = CtrlDbNaviMaster.GetModifiedSqlString(CtrlDbNaviMaster.DefMstDb.TablePartsShapeMaster, TablePartsShape.Rows(0), "ID")
        End Select

        Dim updateResult As Boolean
        updateResult = CtrlDbNaviMaster.UpdateTableWithSQL(connectString, dbnameA, SqlPartsShape)
        If updateResult = True Then
            TablePartsShape.AcceptChanges()
            IsStartEdit = False
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        Return updateResult

    End Function
    Private Function CreatePartsDataFolder(ByVal partsCode As String) As Boolean
        Dim partsDataPath As String = PartsInsertNaviAppConfigData.SystemDataPath.Parts.Root & "\" & partsCode


        If Directory.Exists(partsDataPath) = True Then

        End If
        Return True
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
        For Each row As DataRow In TablePartsShape.Rows
            Select Case row.RowState
                Case DataRowState.Modified
                    Return True
            End Select
        Next
        Return False
    End Function

    ''' <summary>
    ''' キャンセルボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 変更データがある場合は、登録または、更新せず終了するか確認メッセージを表示。
    ''' 登録せずに終了を選択された場合は、IsStartEditをFalse、TablePartsShapeデータを確定し
    ''' FormEditPartsShape_FormClosing処理の動作を抑制している。
    ''' </remarks>
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.Yes Then
                IsStartEdit = False
                TablePartsShape.AcceptChanges()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub
    ''' <summary>
    ''' フォーム終了前処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' フォームを閉じる前に編集データが無いか確認する。変更データがある場合は、更新せず終了するか確認メッセージを表示。
    ''' Windows.Forms.DialogResult.Noが選択された場合は、終了処理をキャンセルする。
    ''' </remarks>
    Private Sub FormEditPartsShape_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsExistModifiedData() = True Then
            Dim dResult As DialogResult
            dResult = MessageBox.Show("登録または、更新せずに終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dResult = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

End Class