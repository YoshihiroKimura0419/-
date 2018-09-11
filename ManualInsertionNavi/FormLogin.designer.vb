<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxLoginId = New System.Windows.Forms.TextBox()
        Me.LabelLoginMess = New System.Windows.Forms.Label()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxLoginId
        '
        Me.TextBoxLoginId.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxLoginId.Location = New System.Drawing.Point(130, 43)
        Me.TextBoxLoginId.Name = "TextBoxLoginId"
        Me.TextBoxLoginId.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TextBoxLoginId.Size = New System.Drawing.Size(188, 23)
        Me.TextBoxLoginId.TabIndex = 0
        Me.TextBoxLoginId.Text = "9500569"
        '
        'LabelLoginMess
        '
        Me.LabelLoginMess.AutoSize = True
        Me.LabelLoginMess.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelLoginMess.Location = New System.Drawing.Point(81, 9)
        Me.LabelLoginMess.Name = "LabelLoginMess"
        Me.LabelLoginMess.Size = New System.Drawing.Size(209, 16)
        Me.LabelLoginMess.TabIndex = 1
        Me.LabelLoginMess.Text = "マンナンバーを入力してください。"
        '
        'LabelMessage
        '
        Me.LabelMessage.AutoSize = True
        Me.LabelMessage.BackColor = System.Drawing.SystemColors.Control
        Me.LabelMessage.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelMessage.ForeColor = System.Drawing.Color.Red
        Me.LabelMessage.Location = New System.Drawing.Point(51, 78)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(101, 16)
        Me.LabelMessage.TabIndex = 2
        Me.LabelMessage.Text = "LabelMessage"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 112)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.LabelLoginMess)
        Me.Controls.Add(Me.TextBoxLoginId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "基板手挿入なびログイン"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxLoginId As System.Windows.Forms.TextBox
    Friend WithEvents LabelLoginMess As System.Windows.Forms.Label
    Friend WithEvents LabelMessage As System.Windows.Forms.Label
End Class
