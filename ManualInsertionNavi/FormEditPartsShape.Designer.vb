<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditPartsShape
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
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxPartsShapeName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxPartHeight = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxPartsWidth = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxMarkPosi = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CheckBoxUseMark = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxShapeType = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.ComboBoxShapeCategory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateUser = New System.Windows.Forms.TextBox()
        Me.TextBoxUpdateDate = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationUser = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationDate = New System.Windows.Forms.TextBox()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxOriginAlign = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboBoxDataCommit = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxId
        '
        Me.TextBoxId.Location = New System.Drawing.Point(70, 20)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(97, 19)
        Me.TextBoxId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "形状ID"
        '
        'TextBoxPartsShapeName
        '
        Me.TextBoxPartsShapeName.Location = New System.Drawing.Point(71, 71)
        Me.TextBoxPartsShapeName.Name = "TextBoxPartsShapeName"
        Me.TextBoxPartsShapeName.Size = New System.Drawing.Size(258, 19)
        Me.TextBoxPartsShapeName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "形状名称"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "形状分類"
        '
        'TextBoxPartHeight
        '
        Me.TextBoxPartHeight.Location = New System.Drawing.Point(44, 18)
        Me.TextBoxPartHeight.Name = "TextBoxPartHeight"
        Me.TextBoxPartHeight.Size = New System.Drawing.Size(85, 19)
        Me.TextBoxPartHeight.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "縦"
        '
        'TextBoxPartsWidth
        '
        Me.TextBoxPartsWidth.Location = New System.Drawing.Point(44, 43)
        Me.TextBoxPartsWidth.Name = "TextBoxPartsWidth"
        Me.TextBoxPartsWidth.Size = New System.Drawing.Size(85, 19)
        Me.TextBoxPartsWidth.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "横"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBoxMarkPosi)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.CheckBoxUseMark)
        Me.GroupBox1.Location = New System.Drawing.Point(570, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(205, 67)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "識別符号有無"
        '
        'ComboBoxMarkPosi
        '
        Me.ComboBoxMarkPosi.FormattingEnabled = True
        Me.ComboBoxMarkPosi.Location = New System.Drawing.Point(108, 34)
        Me.ComboBoxMarkPosi.Name = "ComboBoxMarkPosi"
        Me.ComboBoxMarkPosi.Size = New System.Drawing.Size(87, 20)
        Me.ComboBoxMarkPosi.TabIndex = 63
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(48, 37)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "符号位置"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxUseMark
        '
        Me.CheckBoxUseMark.AutoSize = True
        Me.CheckBoxUseMark.Location = New System.Drawing.Point(23, 18)
        Me.CheckBoxUseMark.Name = "CheckBoxUseMark"
        Me.CheckBoxUseMark.Size = New System.Drawing.Size(107, 16)
        Me.CheckBoxUseMark.TabIndex = 3
        Me.CheckBoxUseMark.Text = "識別記号をつかう"
        Me.CheckBoxUseMark.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(134, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "mm"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(134, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "mm"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxPartHeight)
        Me.GroupBox2.Controls.Add(Me.TextBoxPartsWidth)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(431, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 79)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "部品サイズ"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.MediumBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(12, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 20)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "部品形状"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBoxShapeType)
        Me.GroupBox3.Location = New System.Drawing.Point(644, 167)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(131, 76)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "部品形状"
        '
        'ComboBoxShapeType
        '
        Me.ComboBoxShapeType.FormattingEnabled = True
        Me.ComboBoxShapeType.Location = New System.Drawing.Point(24, 35)
        Me.ComboBoxShapeType.Name = "ComboBoxShapeType"
        Me.ComboBoxShapeType.Size = New System.Drawing.Size(92, 20)
        Me.ComboBoxShapeType.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboBoxDataCommit)
        Me.GroupBox4.Controls.Add(Me.ComboBoxDataEnable)
        Me.GroupBox4.Controls.Add(Me.ComboBoxShapeCategory)
        Me.GroupBox4.Controls.Add(Me.TextBoxId)
        Me.GroupBox4.Controls.Add(Me.TextBoxPartsShapeName)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(431, 28)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(344, 130)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "基本情報"
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(70, 45)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 75
        '
        'ComboBoxShapeCategory
        '
        Me.ComboBoxShapeCategory.FormattingEnabled = True
        Me.ComboBoxShapeCategory.Location = New System.Drawing.Point(71, 96)
        Me.ComboBoxShapeCategory.Name = "ComboBoxShapeCategory"
        Me.ComboBoxShapeCategory.Size = New System.Drawing.Size(181, 20)
        Me.ComboBoxShapeCategory.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "データ状態"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(12, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 400)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(190, 499)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 47
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(52, 499)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 46
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(596, 520)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "更新者"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(596, 489)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "更新日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(416, 520)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "登録者"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(416, 489)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "登録日"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUpdateUser
        '
        Me.TextBoxUpdateUser.Enabled = False
        Me.TextBoxUpdateUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateUser.Location = New System.Drawing.Point(645, 517)
        Me.TextBoxUpdateUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateUser.Name = "TextBoxUpdateUser"
        Me.TextBoxUpdateUser.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateUser.TabIndex = 65
        '
        'TextBoxUpdateDate
        '
        Me.TextBoxUpdateDate.Enabled = False
        Me.TextBoxUpdateDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateDate.Location = New System.Drawing.Point(645, 486)
        Me.TextBoxUpdateDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateDate.Name = "TextBoxUpdateDate"
        Me.TextBoxUpdateDate.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateDate.TabIndex = 66
        Me.TextBoxUpdateDate.Text = "2017/07/07 10:10:10"
        '
        'TextBoxRegistrationUser
        '
        Me.TextBoxRegistrationUser.Enabled = False
        Me.TextBoxRegistrationUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationUser.Location = New System.Drawing.Point(465, 517)
        Me.TextBoxRegistrationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationUser.Name = "TextBoxRegistrationUser"
        Me.TextBoxRegistrationUser.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationUser.TabIndex = 67
        '
        'TextBoxRegistrationDate
        '
        Me.TextBoxRegistrationDate.Enabled = False
        Me.TextBoxRegistrationDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationDate.Location = New System.Drawing.Point(465, 486)
        Me.TextBoxRegistrationDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationDate.Name = "TextBoxRegistrationDate"
        Me.TextBoxRegistrationDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationDate.TabIndex = 68
        '
        'TextBoxNote
        '
        Me.TextBoxNote.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxNote.Location = New System.Drawing.Point(431, 335)
        Me.TextBoxNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNote.Multiline = True
        Me.TextBoxNote.Name = "TextBoxNote"
        Me.TextBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxNote.Size = New System.Drawing.Size(344, 104)
        Me.TextBoxNote.TabIndex = 69
        Me.TextBoxNote.Text = "菱テク　太郎"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(432, 319)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "更新履歴"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ComboBoxOriginAlign)
        Me.GroupBox5.Location = New System.Drawing.Point(431, 251)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(129, 65)
        Me.GroupBox5.TabIndex = 70
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "部品原点位置"
        '
        'ComboBoxOriginAlign
        '
        Me.ComboBoxOriginAlign.FormattingEnabled = True
        Me.ComboBoxOriginAlign.Location = New System.Drawing.Point(18, 27)
        Me.ComboBoxOriginAlign.Name = "ComboBoxOriginAlign"
        Me.ComboBoxOriginAlign.Size = New System.Drawing.Size(87, 20)
        Me.ComboBoxOriginAlign.TabIndex = 63
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(195, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 12)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "データ整備"
        '
        'ComboBoxDataCommit
        '
        Me.ComboBoxDataCommit.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataCommit.FormattingEnabled = True
        Me.ComboBoxDataCommit.Location = New System.Drawing.Point(257, 18)
        Me.ComboBoxDataCommit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataCommit.Name = "ComboBoxDataCommit"
        Me.ComboBoxDataCommit.Size = New System.Drawing.Size(72, 20)
        Me.ComboBoxDataCommit.TabIndex = 76
        '
        'FormEditPartsShape
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(802, 550)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.TextBoxNote)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxUpdateUser)
        Me.Controls.Add(Me.TextBoxUpdateDate)
        Me.Controls.Add(Me.TextBoxRegistrationUser)
        Me.Controls.Add(Me.TextBoxRegistrationDate)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRegistData)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Name = "FormEditPartsShape"
        Me.Text = "部品形状編集"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPartsShapeName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPartHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPartsWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxShapeCategory As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxUseMark As System.Windows.Forms.CheckBox
    Protected WithEvents ButtonCancel As System.Windows.Forms.Button
    Protected WithEvents ButtonRegistData As System.Windows.Forms.Button
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TextBoxUpdateUser As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxUpdateDate As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxRegistrationUser As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxRegistrationDate As System.Windows.Forms.TextBox
    Protected WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Protected WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMarkPosi As System.Windows.Forms.ComboBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDataEnable As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxShapeType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxOriginAlign As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboBoxDataCommit As ComboBox
End Class
