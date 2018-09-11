<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditPartsCategory
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
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.LabelDataEnable = New System.Windows.Forms.Label()
        Me.TextBoxPartsCategoryName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateUser = New System.Windows.Forms.TextBox()
        Me.TextBoxUpdateDate = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationUser = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(147, 45)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 73
        '
        'TextBoxNote
        '
        Me.TextBoxNote.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxNote.Location = New System.Drawing.Point(13, 137)
        Me.TextBoxNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNote.Multiline = True
        Me.TextBoxNote.Name = "TextBoxNote"
        Me.TextBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxNote.Size = New System.Drawing.Size(435, 138)
        Me.TextBoxNote.TabIndex = 68
        Me.TextBoxNote.Text = "菱テク　太郎"
        '
        'LabelUserName
        '
        Me.LabelUserName.BackColor = System.Drawing.Color.Gold
        Me.LabelUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUserName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelUserName.Location = New System.Drawing.Point(13, 112)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(126, 19)
        Me.LabelUserName.TabIndex = 67
        Me.LabelUserName.Text = "備考"
        Me.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelDataEnable
        '
        Me.LabelDataEnable.BackColor = System.Drawing.Color.Gold
        Me.LabelDataEnable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelDataEnable.Location = New System.Drawing.Point(13, 46)
        Me.LabelDataEnable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataEnable.Name = "LabelDataEnable"
        Me.LabelDataEnable.Size = New System.Drawing.Size(126, 19)
        Me.LabelDataEnable.TabIndex = 63
        Me.LabelDataEnable.Text = "データ状態"
        Me.LabelDataEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxPartsCategoryName
        '
        Me.TextBoxPartsCategoryName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxPartsCategoryName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBoxPartsCategoryName.Location = New System.Drawing.Point(147, 79)
        Me.TextBoxPartsCategoryName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsCategoryName.Name = "TextBoxPartsCategoryName"
        Me.TextBoxPartsCategoryName.Size = New System.Drawing.Size(301, 19)
        Me.TextBoxPartsCategoryName.TabIndex = 70
        Me.TextBoxPartsCategoryName.Text = "部品形状分類名称"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gold
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 79)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 19)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "部品形状分類名称"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(235, 367)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 62
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(78, 367)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 61
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(222, 331)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "更新者"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(222, 300)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "更新日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 331)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "登録者"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 300)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "登録日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUpdateUser
        '
        Me.TextBoxUpdateUser.Enabled = False
        Me.TextBoxUpdateUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateUser.Location = New System.Drawing.Point(271, 328)
        Me.TextBoxUpdateUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateUser.Name = "TextBoxUpdateUser"
        Me.TextBoxUpdateUser.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateUser.TabIndex = 57
        '
        'TextBoxUpdateDate
        '
        Me.TextBoxUpdateDate.Enabled = False
        Me.TextBoxUpdateDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateDate.Location = New System.Drawing.Point(271, 297)
        Me.TextBoxUpdateDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateDate.Name = "TextBoxUpdateDate"
        Me.TextBoxUpdateDate.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateDate.TabIndex = 58
        Me.TextBoxUpdateDate.Text = "2017/07/07 10:10:10"
        '
        'TextBoxRegistrationUser
        '
        Me.TextBoxRegistrationUser.Enabled = False
        Me.TextBoxRegistrationUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationUser.Location = New System.Drawing.Point(73, 328)
        Me.TextBoxRegistrationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationUser.Name = "TextBoxRegistrationUser"
        Me.TextBoxRegistrationUser.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationUser.TabIndex = 59
        '
        'TextBoxRegistrationDate
        '
        Me.TextBoxRegistrationDate.Enabled = False
        Me.TextBoxRegistrationDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationDate.Location = New System.Drawing.Point(73, 297)
        Me.TextBoxRegistrationDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationDate.Name = "TextBoxRegistrationDate"
        Me.TextBoxRegistrationDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationDate.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxId.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBoxId.Location = New System.Drawing.Point(147, 13)
        Me.TextBoxId.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(116, 19)
        Me.TextBoxId.TabIndex = 70
        Me.TextBoxId.Text = "ID"
        '
        'FormEditPartsCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 420)
        Me.Controls.Add(Me.ComboBoxDataEnable)
        Me.Controls.Add(Me.TextBoxNote)
        Me.Controls.Add(Me.LabelUserName)
        Me.Controls.Add(Me.LabelDataEnable)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxPartsCategoryName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRegistData)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxUpdateUser)
        Me.Controls.Add(Me.TextBoxUpdateDate)
        Me.Controls.Add(Me.TextBoxRegistrationUser)
        Me.Controls.Add(Me.TextBoxRegistrationDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormEditPartsCategory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品形状分類マスタメンテナンス"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ComboBoxDataEnable As System.Windows.Forms.ComboBox
    Protected WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Protected WithEvents LabelUserName As System.Windows.Forms.Label
    Protected WithEvents LabelDataEnable As System.Windows.Forms.Label
    Protected WithEvents TextBoxPartsCategoryName As System.Windows.Forms.TextBox
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents ButtonCancel As System.Windows.Forms.Button
    Protected WithEvents ButtonRegistData As System.Windows.Forms.Button
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TextBoxUpdateUser As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxUpdateDate As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxRegistrationUser As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxRegistrationDate As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxId As System.Windows.Forms.TextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
End Class
