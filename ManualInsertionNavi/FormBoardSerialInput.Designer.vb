<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBoardSerialInput
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TextBoxInputSerial = New System.Windows.Forms.TextBox()
        Me.ListBoxSerial = New System.Windows.Forms.ListBox()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 58)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "基板のシリアル番号のバーコードを読み込んでください。"
        '
        'ButtonOK
        '
        Me.ButtonOK.BackColor = System.Drawing.Color.Silver
        Me.ButtonOK.Location = New System.Drawing.Point(37, 404)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(173, 41)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.Silver
        Me.ButtonCancel.Location = New System.Drawing.Point(275, 404)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(173, 41)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'TextBoxInputSerial
        '
        Me.TextBoxInputSerial.Location = New System.Drawing.Point(6, 69)
        Me.TextBoxInputSerial.Name = "TextBoxInputSerial"
        Me.TextBoxInputSerial.Size = New System.Drawing.Size(481, 34)
        Me.TextBoxInputSerial.TabIndex = 3
        '
        'ListBoxSerial
        '
        Me.ListBoxSerial.FormattingEnabled = True
        Me.ListBoxSerial.ItemHeight = 27
        Me.ListBoxSerial.Location = New System.Drawing.Point(6, 107)
        Me.ListBoxSerial.Name = "ListBoxSerial"
        Me.ListBoxSerial.Size = New System.Drawing.Size(481, 220)
        Me.ListBoxSerial.TabIndex = 4
        '
        'LabelMessage
        '
        Me.LabelMessage.BackColor = System.Drawing.Color.Transparent
        Me.LabelMessage.ForeColor = System.Drawing.Color.Red
        Me.LabelMessage.Location = New System.Drawing.Point(7, 330)
        Me.LabelMessage.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(480, 58)
        Me.LabelMessage.TabIndex = 0
        Me.LabelMessage.Text = "メッセージ"
        '
        'FormBoardSerialInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(496, 455)
        Me.Controls.Add(Me.ListBoxSerial)
        Me.Controls.Add(Me.TextBoxInputSerial)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(7)
        Me.Name = "FormBoardSerialInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBoardSerialInput"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents TextBoxInputSerial As TextBox
    Friend WithEvents ListBoxSerial As ListBox
    Friend WithEvents LabelMessage As Label
End Class
