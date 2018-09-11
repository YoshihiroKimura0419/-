Imports System.Windows.Forms
Public Class FormMessageDetailsDialog
    Private DispButtonType As Integer = MessageBoxButtons.YesNoCancel
    Private ErrMessage As String = Nothing
    Private FormTitle As String = Nothing
    Private ErrDetails As String = Nothing

    Public Sub New(ByVal errMess As String, ByVal title As String, ByVal details As String, ByVal buttonType As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        DispButtonType = buttonType
        ErrMessage = errMess
        FormTitle = title
        ErrDetails = details

    End Sub

    Private Sub FormErrDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetButtons(DispButtonType)
        SetMessages()
        ActiveControl = Button1
    End Sub
    Private Sub SetButtons(ByVal buttonType As Integer)
        Select Case buttonType
            Case MessageBoxButtons.YesNoCancel
                Button1.Text = "はい"
                Button2.Text = "いいえ"
                Button3.Text = "キャンセル"
                Button1.Visible = True
                Button2.Visible = True
                Button3.Visible = True
            Case MessageBoxButtons.YesNo
                Button1.Text = "はい"
                Button2.Text = ""
                Button3.Text = "いいえ"
                Button1.Visible = True
                Button2.Visible = False
                Button3.Visible = True
            Case MessageBoxButtons.OKCancel
                Button1.Text = "ＯＫ"
                Button2.Text = ""
                Button3.Text = "キャンセル"
                Button1.Visible = True
                Button2.Visible = False
                Button3.Visible = True
            Case MessageBoxButtons.RetryCancel
                Button1.Text = "リトライ"
                Button2.Text = ""
                Button3.Text = "キャンセル"
                Button1.Visible = True
                Button2.Visible = False
                Button3.Visible = True
            Case MessageBoxButtons.OK
                Button1.Text = ""
                Button2.Text = "ＯＫ"
                Button3.Text = ""
                Button1.Visible = False
                Button2.Visible = True
                Button3.Visible = False
        End Select
    End Sub
    Private Sub SetMessages()
        LabelErrMessage.Text = ErrMessage
        TextBoxDetalis.Text = ErrDetails
        Me.Text = FormTitle
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case DispButtonType
            Case MessageBoxButtons.YesNoCancel, MessageBoxButtons.YesNo
                Me.DialogResult = DialogResult.Yes
            Case MessageBoxButtons.OKCancel
                Me.DialogResult = DialogResult.OK
            Case MessageBoxButtons.RetryCancel
                Me.DialogResult = DialogResult.Retry
        End Select
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case DispButtonType
            Case MessageBoxButtons.YesNoCancel
                Me.DialogResult = DialogResult.No
                Me.Close()
            Case MessageBoxButtons.YesNo
            Case MessageBoxButtons.OKCancel
            Case MessageBoxButtons.RetryCancel
            Case MessageBoxButtons.OK
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Select Case DispButtonType
            Case MessageBoxButtons.YesNoCancel, MessageBoxButtons.OKCancel, MessageBoxButtons.RetryCancel
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            Case MessageBoxButtons.YesNo
                Me.DialogResult = DialogResult.No
                Me.Close()
        End Select

    End Sub
End Class