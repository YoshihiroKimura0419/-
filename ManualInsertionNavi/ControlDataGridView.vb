Public Class ControlDataGridView

    'DataGridView選択行リスト配列
    Public SelectedRowList As New List(Of Integer)
    ''' <summary>
    ''' DataGridViewの選択行番号列を取得する
    ''' </summary>
    ''' <param name="dgv">
    ''' コピーを行うDataGridViewオブジェクト
    ''' </param>
    ''' <param name="rowList">
    ''' 選択行リスト格納配列
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    ''' <remarks></remarks>
    Function GetSelectedRowIndexes(ByVal dgv As DataGridView, ByRef rowList As List(Of Integer)) As Boolean
        Dim flag As Boolean = False
        rowList.Clear()
        For Each r As DataGridViewRow In dgv.SelectedRows
            flag = True
            rowList.Add(r.Index)
        Next r
        Return flag
    End Function
    ''' <summary>
    ''' DataGridViewの行コピー行う。本コピーは選択行リストを取得するのみ。
    ''' </summary>
    ''' <param name="dgv">
    ''' コピーを行うDataGridViewオブジェクト</param>
    ''' <returns>
    ''' True:コピーOK　False:コピー失敗</returns>
    ''' <remarks></remarks>
    Function GetCopyRowList(ByRef dgv As DataGridView, ByRef rowList As List(Of Integer)) As Boolean
        If GetSelectedRowIndexes(dgv, rowList) = True Then
            MessageBox.Show("選択行をコピーしました")
            Return True
        Else
            MessageBox.Show("コピーする行を選択して下さい")
            Return False
        End If
    End Function
    ''' <summary>
    ''' DataGridViewの行貼り付けを行う。貼り付け前にfuncGetDgvCopyRowListで行コピーを実施しておく。
    ''' </summary>
    ''' <param name="dgv">
    ''' 貼り付けを行うDataGridViewオブジェクト
    ''' </param>
    ''' <param name="rowNumber">
    ''' 貼り付け先の先頭行番号
    ''' </param>
    ''' <param name="rowList">
    ''' 貼り付け元の行リスト配列
    ''' </param>
    ''' <returns>
    ''' True:貼り付け成功 False:貼り付け失敗
    ''' </returns>
    ''' <remarks></remarks>
    Function PasteRowListData(ByRef dgv As DataGridView, ByVal rowNumber As Integer, ByVal rowList As List(Of Integer)) As Boolean
        Dim result As DialogResult

        result = MessageBox.Show("行貼付けを行いますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
        If result = Windows.Forms.DialogResult.Cancel Then Return False

        Dim bs As BindingSource = DirectCast(dgv.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)

        Dim isIncrementData As Boolean
        Dim pasteCount As Integer = 0

        If rowList(0) > rowList(rowList.Count - 1) Then
            isIncrementData = False
        Else
            isIncrementData = True
        End If
        Dim i As Integer
        Dim srcRowNumber, desRowNumber As DataRow
        For i = 1 To rowList.Count
            If isIncrementData = True Then
                srcRowNumber = table.Rows(rowList(i - 1))
            Else
                srcRowNumber = table.Rows(rowList(rowList.Count - i))
            End If
            If rowNumber > table.Rows.Count - 1 Then
                bs.AddNew()
                bs.EndEdit()
            End If
            desRowNumber = table.Rows(rowNumber)
            For n As Integer = 1 To srcRowNumber.ItemArray.Length - 1
                Dim colname As String = table.Columns(n).ColumnName
                Select Case colname
                    'Case "登録者ID", "登録日", "更新者ID", "更新日"
                    Case "RegistrationDate", "RegistrationUserId", "UpdateDate", "UpdateUserId"
                    Case Else
                        desRowNumber(n) = srcRowNumber(n)
                End Select

            Next
            rowNumber += 1
            pasteCount += 1
        Next
        If pasteCount = 0 Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' DataGridViewにテキスト列を追加する
    ''' </summary>
    ''' <param name="dgv">
    ''' テキスト列列を追加するDataGridViewオブジェクト
    ''' </param>
    ''' <param name="dataPropertyName">
    ''' テキスト列のDataPropertyName設定文字列
    ''' </param>
    ''' <param name="name">
    ''' テキスト列のName設定文字列
    ''' </param>
    ''' <param name="headerText">
    ''' テキスト列のHeaderText設定文字列
    ''' </param>
    ''' <param name="isReadOnly">
    ''' テキスト列の読取専用フラグ
    ''' </param>
    ''' <remarks></remarks>
    Public Sub AddTextboxColumn(ByRef dgv As DataGridView, ByVal dataPropertyName As String, ByVal name As String,
                                    ByVal headerText As String, ByVal isReadOnly As Boolean)
        Dim textColumn As New DataGridViewTextBoxColumn()

        textColumn.DataPropertyName = dataPropertyName
        textColumn.Name = name
        textColumn.HeaderText = headerText
        textColumn.ReadOnly = isReadOnly
        dgv.Columns.Add(textColumn)

    End Sub
    ''' <summary>
    ''' DataGridViewにコンボボックス列を追加する
    ''' </summary>
    ''' <param name="dgv">
    ''' コンボボックス列を追加するDataGridViewオブジェクト</param>
    ''' <param name="tb">
    ''' コンボボックス列に設定するDataTableオブジェクト(データ設定済)</param>
    ''' <param name="dataPropertyName">
    ''' コンボボックス列のDataPropertyName設定文字列</param>
    ''' <param name="name">
    ''' コンボボックス列のName設定文字列</param>
    ''' <param name="headerText">
    ''' コンボボックス列のHeaderText設定文字列</param>
    ''' <param name="valueMember">
    ''' コンボボックス設定されているデータテーブル(tb)の列名</param>
    ''' <param name="displayMember">
    ''' コンボボックスに表示するデータテーブル(tb)の列名</param>
    ''' <param name="isReadOnly">
    ''' コンボボックス読み取り専用フラグ</param>
    ''' <remarks></remarks>
    Public Sub AddComboboxColumn(ByRef dgv As DataGridView, ByRef tb As DataTable,
                                       ByVal dataPropertyName As String, ByVal name As String, ByVal headerText As String,
                                       ByVal valueMember As String, ByVal displayMember As String, ByVal isReadOnly As Boolean)

        Dim comboColumn As New DataGridViewComboBoxColumn()

        comboColumn.DataPropertyName = dataPropertyName
        comboColumn.Name = name
        comboColumn.HeaderText = headerText
        If isReadOnly = True Then
            comboColumn.ReadOnly = True
            comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        End If

        'DataGridViewComboBoxColumnのDataSourceを設定
        comboColumn.DataSource = tb

        '実際の値が"Value"列、表示するテキストが"Display"列とする
        comboColumn.ValueMember = valueMember
        comboColumn.DisplayMember = displayMember
        'DataGridViewに追加する
        dgv.Columns.Add(comboColumn)

    End Sub
    ''' <summary>
    ''' データグリッドビューにボタン列を追加する
    ''' </summary>
    ''' <param name="dgv">
    ''' ボタン列を追加するDataGridViewオブジェクト</param>
    ''' <param name="dataPropertyName">
    ''' ボタン列のDataPropertyName設定文字列</param>
    ''' <param name="name">
    ''' ボタン列のName設定文字列</param>
    ''' <param name="headerText">
    ''' ボタン列のHeaderText設定文字列</param>
    ''' <param name="buttonText">
    ''' ボタン列のText設定文字列（この文字列がボタンに表示される）</param>
    ''' <remarks></remarks>
    Public Sub AddButtonColumn(ByRef dgv As DataGridView, ByVal dataPropertyName As String, ByVal name As String, ByVal headerText As String, ByVal buttonText As String)
        Dim buttonColumn As DataGridViewButtonColumn = New DataGridViewButtonColumn
        buttonColumn.DataPropertyName = dataPropertyName
        buttonColumn.Name = name
        buttonColumn.HeaderText = headerText
        buttonColumn.Text = buttonText
        buttonColumn.UseColumnTextForButtonValue = True
        dgv.Columns.Add(buttonColumn)

    End Sub
    ''' <summary>
    ''' DataGridViewにチェックボックス列を追加する。
    ''' </summary>
    ''' <param name="dgv">
    ''' チェックボックス列を追加するDataGridViewオブジェクト
    ''' </param>
    ''' <param name="dataPropertyName">
    ''' データプロパティ名
    ''' </param>
    ''' <param name="name">
    ''' データ名
    ''' </param>
    ''' <param name="headerText">
    ''' 列ヘッダーテキスト名
    ''' </param>
    ''' <remarks></remarks>
    Public Sub AddCheckBoxColumn(ByRef dgv As DataGridView, ByVal dataPropertyName As String, ByVal name As String, ByVal headerText As String)

        Dim checkboxColumn As New DataGridViewCheckBoxColumn()
        checkboxColumn.DataPropertyName = dataPropertyName
        checkboxColumn.Name = name
        checkboxColumn.HeaderText = headerText
        checkboxColumn.ReadOnly = False
        dgv.Columns.Add(checkboxColumn)

    End Sub
    ''' <summary>
    ''' DataGridViewに登録者関連情報列をまとめて追加する
    ''' </summary>
    ''' <param name="dgv">
    ''' 登録者関連情報列を追加したいDataGridViewオブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub AddRegisterInfoTextboxColoumn(ByRef dgv As DataGridView)
        AddTextboxColumn(dgv, "登録日", "登録日", "登録日", True)
        AddTextboxColumn(dgv, "登録者", "登録者", "登録者", True)
        AddTextboxColumn(dgv, "更新日", "更新日", "更新日", True)
        AddTextboxColumn(dgv, "更新者", "更新者", "更新者", True)

    End Sub

    ''' <summary>
    ''' 登録・更新情報データを該当行に設定する
    ''' </summary>
    ''' <param name="dgv">
    ''' 登録・更新情報を設定するDataGridViewオブジェクト
    ''' </param>
    ''' <remarks></remarks>
    Public Sub SetResisterInfoDataToTable(ByRef dgv As DataGridView, ByVal regManNumber As String)

        Dim bs As BindingSource = DirectCast(dgv.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)
        Dim dtNow As DateTime = DateTime.Now

        For Each Row As DataRow In table.Rows
            Select Case Row.RowState
                Case DataRowState.Added        '▼新規追加されたレコードの場合
                    '追加処理
                    Row("登録日") = dtNow
                    Row("登録者マンナンバー") = regManNumber
                Case DataRowState.Modified     '▼修正されたレコードの場合
                    Row("更新日") = dtNow
                    Row("更新者マンナンバー") = regManNumber
                Case Else
                    Continue For
            End Select
        Next
        table.Dispose()
    End Sub
    ''' <summary>
    ''' DataGridViewの登録日、更新日のセルフォーマットを"yyyy/MM/dd HH:mm:ss"形式に設定する。
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Public Sub SetCellstyleDate(ByRef dgv As DataGridView)
        dgv.Columns("RegistrationDate").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
        dgv.Columns("UpdateDate").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
    End Sub
    ''' <summary>
    ''' DataGridViewのRowIndexからDataTableのDataRowを取得する
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="RowIdx"></param>
    ''' <returns></returns>
    ''' <remarks>ソート時など、DataGridViewのRowIndexが必ずしもDataTableのRowIndexとマッチしないため
    ''' </remarks>
    Public Function GetDataRowByRowIndex(ByVal dgv As DataGridView, ByVal rowIdx As Integer) As DataRow
        Try
            If dgv.Rows(rowIdx).DataBoundItem Is Nothing Then
                Return Nothing
            End If
        Catch ex As IndexOutOfRangeException
            Return Nothing
        End Try

        Dim dr As DataRow
        Dim drv As DataRowView = CType(dgv.Rows(rowIdx).DataBoundItem, System.Data.DataRowView)
        dr = CType(drv.Row, System.Data.DataRow)

        Return dr
    End Function
    ''' -----------------------------------------------------------------------------------
    ''' <summary>
    ''' データグリッドにバインドされたテーブルデータの更新有無を調べる
    ''' </summary>
    ''' <param name="dgv">
    ''' 調べたいDataGridViewオブジェクト
    ''' </param>
    ''' <returns>
    ''' True:更新あり、False:更新なし
    ''' </returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------------
    Public Function IsExistUpdateDataDgvTable(ByRef dgv As DataGridView) As Boolean
        Dim bs As BindingSource = DirectCast(dgv.DataSource, BindingSource)
        Dim table As DataTable = DirectCast(bs.DataSource, DataTable)
        Dim isNeed As Boolean = False

        For Each Row As DataRow In table.Rows
            Select Case Row.RowState
                Case DataRowState.Added        '▼新規追加されたレコードの場合
                    isNeed = True
                    Exit For
                Case DataRowState.Deleted      '▼削除されたレコードの場合
                    isNeed = True
                    Exit For
                Case DataRowState.Modified     '▼修正されたレコードの場合
                    isNeed = True
                    Exit For
                Case Else
                    Continue For
            End Select
        Next
        table.Dispose()
        Return isNeed
    End Function
    Public Sub BindTableToDgv(ByRef dgv As DataGridView, ByRef table As DataTable)

        'データの読み込み
        Try
            'データソースを設定してDataGridViewにデータを表示
            dgv.AutoGenerateColumns = False
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

            Dim BindingSource As New BindingSource
            BindingSource.DataSource = table
            dgv.DataSource = BindingSource

            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class


