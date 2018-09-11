
''' <summary>
''' MessageBoxでは文字が小さいので、文字サイズを大きくした独自のメッセージ表示ダイアログクラス
''' SetButtonsTypeでボタンの形式を設定
''' 設定可能な形式：MessageBoxButtons.OK,MessageBoxButtons.OKCancel,MessageBoxButtons.YesNo,MessageBoxButtons.YesNoCancel
''' Form作成後以下の手順で呼び出し
''' SetButtonsType→SetTitleAndMessage→ShowDialog
''' </summary>
Public Class FormMessageDialog
    Private ButtonType As System.Windows.Forms.MessageBoxButtons
    Public Sub SetTitleAndMessage(ByVal title As String, ByVal message As String, ByVal col As System.Drawing.Color)
        LabelTitle.Text = title
        TextBoxMainMessage.Text = message
        'TextBoxMainMessage.BackColor = col
        LabelTitle.BackColor = col
    End Sub
    Public Sub SetButtonsType(ByVal button As System.Windows.Forms.MessageBoxButtons)
        ButtonType = button
        Select Case ButtonType
            Case MessageBoxButtons.OK
                Button1.Text = ""
                Button1.Visible = False

                Button2.Text = "OK"
                Button2.Visible = True

                Button3.Text = ""
                Button3.Visible = False
                Me.ActiveControl = Me.Button2
            Case MessageBoxButtons.OKCancel
                Button1.Text = "OK"
                Button1.Visible = True

                Button2.Text = ""
                Button2.Visible = False

                Button3.Text = "キャンセル"
                Button3.Visible = True
                Me.ActiveControl = Me.Button1

            Case MessageBoxButtons.YesNo
                Button1.Text = "はい"
                Button1.Visible = True

                Button2.Text = ""
                Button2.Visible = False

                Button3.Text = "いいえ"
                Button3.Visible = True
                Me.ActiveControl = Me.Button1

            Case MessageBoxButtons.YesNoCancel
                Button1.Text = "はい"
                Button1.Visible = True

                Button2.Text = "いいえ"
                Button2.Visible = True

                Button3.Text = "キャンセル"
                Button3.Visible = True
                Me.ActiveControl = Me.Button1

        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case ButtonType
            Case MessageBoxButtons.OK
                Exit Sub
            Case MessageBoxButtons.OKCancel
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Case MessageBoxButtons.YesNo
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            Case MessageBoxButtons.YesNoCancel
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case ButtonType
            Case MessageBoxButtons.OK
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Case MessageBoxButtons.OKCancel
                Exit Sub
            Case MessageBoxButtons.YesNo
                Exit Sub
            Case MessageBoxButtons.YesNoCancel
                Me.DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
        End Select

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Select Case ButtonType
            Case MessageBoxButtons.OK
                Exit Sub
            Case MessageBoxButtons.OKCancel
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Case MessageBoxButtons.YesNo
                Me.DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
            Case MessageBoxButtons.YesNoCancel
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
        End Select

    End Sub

    Private Sub Button1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button1.PreviewKeyDown, Button2.PreviewKeyDown, Button3.PreviewKeyDown
        subForcusChange(e)
    End Sub

    Private Sub subForcusChange(ByVal e As PreviewKeyDownEventArgs)
        Select Case e.KeyCode
            '矢印キーが押されたことを表示する
            Case Keys.Up, Keys.Down
                e.IsInputKey = True
            Case Keys.Left
                e.IsInputKey = True
                Select Case ButtonType
                    Case MessageBoxButtons.OK
                        e.IsInputKey = True
                    Case MessageBoxButtons.OKCancel, MessageBoxButtons.YesNo
                        If Button1.Focused = True Then
                            Me.ActiveControl = Me.Button3
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button3.Focused = True Then
                            Me.ActiveControl = Me.Button1
                            GoTo L_FOCUS_CHANGE
                        End If
                    Case MessageBoxButtons.YesNoCancel
                        If Button1.Focused = True Then
                            Me.ActiveControl = Me.Button3
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button2.Focused = True Then
                            Me.ActiveControl = Me.Button1
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button3.Focused = True Then
                            Me.ActiveControl = Me.Button2
                            GoTo L_FOCUS_CHANGE
                        End If
                End Select
            Case Keys.Right
                e.IsInputKey = True
                Select Case ButtonType
                    Case MessageBoxButtons.OK
                        e.IsInputKey = True
                    Case MessageBoxButtons.OKCancel, MessageBoxButtons.YesNo
                        If Button1.Focused = True Then
                            Me.ActiveControl = Me.Button3
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button3.Focused = True Then
                            Me.ActiveControl = Me.Button1
                            GoTo L_FOCUS_CHANGE
                        End If
                    Case MessageBoxButtons.YesNoCancel
                        If Button1.Focused = True Then
                            Me.ActiveControl = Me.Button2
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button2.Focused = True Then
                            Me.ActiveControl = Me.Button3
                            GoTo L_FOCUS_CHANGE
                        End If
                        If Button3.Focused = True Then
                            Me.ActiveControl = Me.Button1
                            GoTo L_FOCUS_CHANGE
                        End If
                End Select

            Case Keys.Tab
                e.IsInputKey = True
        End Select
L_FOCUS_CHANGE:
        SetButtonTextBoldOrRegular()
    End Sub
    Private Sub SetButtonTextBoldOrRegular()
        If Button1.Focused = True Then
            Button1.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Bold, GraphicsUnit.Point, 128)
            Button2.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)
            Button3.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)

        End If
        If Button2.Focused = True Then
            Button1.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)
            Button2.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Bold, GraphicsUnit.Point, 128)
            Button3.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)
        End If
        If Button3.Focused = True Then
            Button1.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)
            Button2.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Regular, GraphicsUnit.Point, 128)
            Button3.Font = New System.Drawing.Font("MS UI Gothic", 12, FontStyle.Bold, GraphicsUnit.Point, 128)
        End If
    End Sub

    Private Sub FormMessageDialog_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SetButtonTextBoldOrRegular()
        Me.Activate()

    End Sub
End Class