Public Class FormComboboxSelect
    Private ComboList As List(Of String)
    Public SelectedSheetName As String = ""
    Public AddNewSheet As Boolean = False
    ''' <summary>
    ''' コンボボックス選択フォームのコンストラクタ
    ''' </summary>
    ''' <param name="title">
    ''' フォームに表示するタイトル文字列
    ''' </param>
    ''' <param name="strList">
    ''' コンボボックスに設定する文字列リスト
    ''' </param>
    ''' <param name="isVisibleAddNewSheetCheckbox">
    ''' </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal title As String, ByVal strList As List(Of String), ByVal isVisibleAddNewSheetCheckbox As Boolean)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        ComboList = strList
        Me.Text = title
        CheckBoxAddNewSheet.Visible = isVisibleAddNewSheetCheckbox

    End Sub

    Private Sub FormComboboxSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To ComboList.Count - 1
            ComboBox1.Items.Add(ComboList(i))
        Next
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        '2016/12/01 modified --------------------------------------------------
        SelectedSheetName = ComboList(ComboBox1.SelectedIndex)
        If CheckBoxAddNewSheet.Checked = True Then
            Dim temname As String = ""
            Do While temname = ""
                temname = InputBox("新規作成するシート名を入力してください。", "シート名入力")
            Loop
            SelectedSheetName = temname
            AddNewSheet = True
        Else
            SelectedSheetName = ComboList(ComboBox1.SelectedIndex)
            AddNewSheet = False
        End If
        '2016/12/01 modified --------------------------------------------END---
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class