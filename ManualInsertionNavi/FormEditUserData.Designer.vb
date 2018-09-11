<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditUserData
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
        Me.TextBoxManNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.TextBoxUserName = New System.Windows.Forms.TextBox()
        Me.CheckBoxFormNavi = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxSystemSetting = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMasterMente = New System.Windows.Forms.CheckBox()
        Me.LabelTechnicLevel = New System.Windows.Forms.Label()
        Me.ComboBoxTechnicLevel = New System.Windows.Forms.ComboBox()
        Me.LabelDataEnable = New System.Windows.Forms.Label()
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxTechnicLevelName = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxOrderMente = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(233, 366)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 45
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(76, 366)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 44
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(220, 330)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "更新者"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(220, 299)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "更新日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 330)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "登録者"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 299)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "登録日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUpdateUser
        '
        Me.TextBoxUpdateUser.Enabled = False
        Me.TextBoxUpdateUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateUser.Location = New System.Drawing.Point(269, 327)
        Me.TextBoxUpdateUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateUser.Name = "TextBoxUpdateUser"
        Me.TextBoxUpdateUser.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateUser.TabIndex = 40
        '
        'TextBoxUpdateDate
        '
        Me.TextBoxUpdateDate.Enabled = False
        Me.TextBoxUpdateDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateDate.Location = New System.Drawing.Point(269, 296)
        Me.TextBoxUpdateDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateDate.Name = "TextBoxUpdateDate"
        Me.TextBoxUpdateDate.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateDate.TabIndex = 41
        Me.TextBoxUpdateDate.Text = "2017/07/07 10:10:10"
        '
        'TextBoxRegistrationUser
        '
        Me.TextBoxRegistrationUser.Enabled = False
        Me.TextBoxRegistrationUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationUser.Location = New System.Drawing.Point(71, 327)
        Me.TextBoxRegistrationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationUser.Name = "TextBoxRegistrationUser"
        Me.TextBoxRegistrationUser.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationUser.TabIndex = 42
        '
        'TextBoxRegistrationDate
        '
        Me.TextBoxRegistrationDate.Enabled = False
        Me.TextBoxRegistrationDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationDate.Location = New System.Drawing.Point(71, 296)
        Me.TextBoxRegistrationDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationDate.Name = "TextBoxRegistrationDate"
        Me.TextBoxRegistrationDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationDate.TabIndex = 43
        '
        'TextBoxManNumber
        '
        Me.TextBoxManNumber.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxManNumber.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBoxManNumber.Location = New System.Drawing.Point(106, 47)
        Me.TextBoxManNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxManNumber.Name = "TextBoxManNumber"
        Me.TextBoxManNumber.Size = New System.Drawing.Size(96, 19)
        Me.TextBoxManNumber.TabIndex = 48
        Me.TextBoxManNumber.Text = "9500569"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gold
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 19)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "マンナンバー"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelUserName
        '
        Me.LabelUserName.BackColor = System.Drawing.Color.Gold
        Me.LabelUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUserName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelUserName.Location = New System.Drawing.Point(11, 84)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(89, 19)
        Me.LabelUserName.TabIndex = 47
        Me.LabelUserName.Text = "ユーザー名"
        Me.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUserName.Location = New System.Drawing.Point(106, 83)
        Me.TextBoxUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(137, 19)
        Me.TextBoxUserName.TabIndex = 48
        Me.TextBoxUserName.Text = "菱テク　太郎"
        '
        'CheckBoxFormNavi
        '
        Me.CheckBoxFormNavi.AutoSize = True
        Me.CheckBoxFormNavi.Location = New System.Drawing.Point(23, 27)
        Me.CheckBoxFormNavi.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxFormNavi.Name = "CheckBoxFormNavi"
        Me.CheckBoxFormNavi.Size = New System.Drawing.Size(68, 16)
        Me.CheckBoxFormNavi.TabIndex = 50
        Me.CheckBoxFormNavi.Text = "なび画面"
        Me.CheckBoxFormNavi.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SkyBlue
        Me.GroupBox1.Controls.Add(Me.CheckBoxOrderMente)
        Me.GroupBox1.Controls.Add(Me.CheckBoxSystemSetting)
        Me.GroupBox1.Controls.Add(Me.CheckBoxMasterMente)
        Me.GroupBox1.Controls.Add(Me.CheckBoxFormNavi)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 149)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(434, 129)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "アクセス権"
        '
        'CheckBoxSystemSetting
        '
        Me.CheckBoxSystemSetting.AutoSize = True
        Me.CheckBoxSystemSetting.Location = New System.Drawing.Point(23, 83)
        Me.CheckBoxSystemSetting.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxSystemSetting.Name = "CheckBoxSystemSetting"
        Me.CheckBoxSystemSetting.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxSystemSetting.TabIndex = 50
        Me.CheckBoxSystemSetting.Text = "システム設定"
        Me.CheckBoxSystemSetting.UseVisualStyleBackColor = True
        '
        'CheckBoxMasterMente
        '
        Me.CheckBoxMasterMente.AutoSize = True
        Me.CheckBoxMasterMente.Location = New System.Drawing.Point(23, 55)
        Me.CheckBoxMasterMente.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxMasterMente.Name = "CheckBoxMasterMente"
        Me.CheckBoxMasterMente.Size = New System.Drawing.Size(114, 16)
        Me.CheckBoxMasterMente.TabIndex = 50
        Me.CheckBoxMasterMente.Text = "マスターメンテナンス"
        Me.CheckBoxMasterMente.UseVisualStyleBackColor = True
        '
        'LabelTechnicLevel
        '
        Me.LabelTechnicLevel.BackColor = System.Drawing.Color.Gold
        Me.LabelTechnicLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTechnicLevel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelTechnicLevel.Location = New System.Drawing.Point(11, 120)
        Me.LabelTechnicLevel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTechnicLevel.Name = "LabelTechnicLevel"
        Me.LabelTechnicLevel.Size = New System.Drawing.Size(89, 19)
        Me.LabelTechnicLevel.TabIndex = 47
        Me.LabelTechnicLevel.Text = "技術レベル"
        Me.LabelTechnicLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxTechnicLevel
        '
        Me.ComboBoxTechnicLevel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxTechnicLevel.FormattingEnabled = True
        Me.ComboBoxTechnicLevel.Location = New System.Drawing.Point(106, 119)
        Me.ComboBoxTechnicLevel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxTechnicLevel.Name = "ComboBoxTechnicLevel"
        Me.ComboBoxTechnicLevel.Size = New System.Drawing.Size(65, 20)
        Me.ComboBoxTechnicLevel.TabIndex = 52
        '
        'LabelDataEnable
        '
        Me.LabelDataEnable.BackColor = System.Drawing.Color.Gold
        Me.LabelDataEnable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelDataEnable.Location = New System.Drawing.Point(11, 13)
        Me.LabelDataEnable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataEnable.Name = "LabelDataEnable"
        Me.LabelDataEnable.Size = New System.Drawing.Size(89, 19)
        Me.LabelDataEnable.TabIndex = 47
        Me.LabelDataEnable.Text = "データ状態"
        Me.LabelDataEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(106, 11)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 119)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 19)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "技術レベル名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxTechnicLevelName
        '
        Me.TextBoxTechnicLevelName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxTechnicLevelName.Location = New System.Drawing.Point(285, 119)
        Me.TextBoxTechnicLevelName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxTechnicLevelName.Name = "TextBoxTechnicLevelName"
        Me.TextBoxTechnicLevelName.Size = New System.Drawing.Size(160, 19)
        Me.TextBoxTechnicLevelName.TabIndex = 48
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(391, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "社外秘"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBoxOrderMente
        '
        Me.CheckBoxOrderMente.AutoSize = True
        Me.CheckBoxOrderMente.Location = New System.Drawing.Point(183, 27)
        Me.CheckBoxOrderMente.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxOrderMente.Name = "CheckBoxOrderMente"
        Me.CheckBoxOrderMente.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxOrderMente.TabIndex = 50
        Me.CheckBoxOrderMente.Text = "オーダー管理"
        Me.CheckBoxOrderMente.UseVisualStyleBackColor = True
        '
        'FormEditUserData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 420)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxDataEnable)
        Me.Controls.Add(Me.ComboBoxTechnicLevel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBoxTechnicLevelName)
        Me.Controls.Add(Me.TextBoxUserName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelTechnicLevel)
        Me.Controls.Add(Me.LabelUserName)
        Me.Controls.Add(Me.LabelDataEnable)
        Me.Controls.Add(Me.TextBoxManNumber)
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
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEditUserData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ユーザー情報編集"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
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
    Protected WithEvents TextBoxManNumber As System.Windows.Forms.TextBox
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents LabelUserName As System.Windows.Forms.Label
    Protected WithEvents TextBoxUserName As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxFormNavi As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxSystemSetting As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxMasterMente As System.Windows.Forms.CheckBox
    Protected WithEvents LabelTechnicLevel As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTechnicLevel As System.Windows.Forms.ComboBox
    Protected WithEvents LabelDataEnable As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDataEnable As System.Windows.Forms.ComboBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TextBoxTechnicLevelName As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxOrderMente As CheckBox
End Class
