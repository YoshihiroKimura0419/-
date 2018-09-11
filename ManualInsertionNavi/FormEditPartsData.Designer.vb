<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditPartsData
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBoxPartsCode = New System.Windows.Forms.TextBox()
        Me.TextBoxPartsName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.ComboBoxShapeCategory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBoxPartsImage = New System.Windows.Forms.PictureBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateHistory = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateUser = New System.Windows.Forms.TextBox()
        Me.TextBoxUpdateDate = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationUser = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationDate = New System.Windows.Forms.TextBox()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LabelEditMode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListBoxPartsImage = New System.Windows.Forms.ListBox()
        Me.ButtonDeleteImageFile = New System.Windows.Forms.Button()
        Me.ButtonAddImageFile = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBoxPartsShape = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListBoxKankotsuFile = New System.Windows.Forms.ListBox()
        Me.ButtonRegistKankotsuFile = New System.Windows.Forms.Button()
        Me.ButtonOpenKankotsuFile = New System.Windows.Forms.Button()
        Me.ButtonDeleteKankotsuFile = New System.Windows.Forms.Button()
        Me.ButtonAddKankotsuFile = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.ComboBoxShapeName = New System.Windows.Forms.ComboBox()
        Me.TextBoxPartsModelName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxPartsImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBoxPartsShape, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxPartsCode
        '
        Me.TextBoxPartsCode.Location = New System.Drawing.Point(94, 47)
        Me.TextBoxPartsCode.Name = "TextBoxPartsCode"
        Me.TextBoxPartsCode.Size = New System.Drawing.Size(171, 19)
        Me.TextBoxPartsCode.TabIndex = 0
        '
        'TextBoxPartsName
        '
        Me.TextBoxPartsName.Location = New System.Drawing.Point(95, 98)
        Me.TextBoxPartsName.Name = "TextBoxPartsName"
        Me.TextBoxPartsName.Size = New System.Drawing.Size(258, 19)
        Me.TextBoxPartsName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "部材コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "分類"
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(94, 72)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 1
        '
        'ComboBoxShapeCategory
        '
        Me.ComboBoxShapeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxShapeCategory.Enabled = False
        Me.ComboBoxShapeCategory.FormattingEnabled = True
        Me.ComboBoxShapeCategory.Location = New System.Drawing.Point(95, 174)
        Me.ComboBoxShapeCategory.Name = "ComboBoxShapeCategory"
        Me.ComboBoxShapeCategory.Size = New System.Drawing.Size(181, 20)
        Me.ComboBoxShapeCategory.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "データ状態"
        '
        'PictureBoxPartsImage
        '
        Me.PictureBoxPartsImage.BackColor = System.Drawing.Color.White
        Me.PictureBoxPartsImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxPartsImage.Location = New System.Drawing.Point(6, 7)
        Me.PictureBoxPartsImage.Name = "PictureBoxPartsImage"
        Me.PictureBoxPartsImage.Size = New System.Drawing.Size(407, 248)
        Me.PictureBoxPartsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPartsImage.TabIndex = 71
        Me.PictureBoxPartsImage.TabStop = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(403, 433)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "品名"
        '
        'TextBoxUpdateHistory
        '
        Me.TextBoxUpdateHistory.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateHistory.Location = New System.Drawing.Point(13, 19)
        Me.TextBoxUpdateHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateHistory.Multiline = True
        Me.TextBoxUpdateHistory.Name = "TextBoxUpdateHistory"
        Me.TextBoxUpdateHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxUpdateHistory.Size = New System.Drawing.Size(340, 73)
        Me.TextBoxUpdateHistory.TabIndex = 0
        Me.TextBoxUpdateHistory.Text = "菱テク　太郎"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(198, 130)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "更新者"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 130)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "更新日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(198, 103)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "登録者"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 103)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "登録日"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUpdateUser
        '
        Me.TextBoxUpdateUser.Enabled = False
        Me.TextBoxUpdateUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateUser.Location = New System.Drawing.Point(247, 127)
        Me.TextBoxUpdateUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateUser.Name = "TextBoxUpdateUser"
        Me.TextBoxUpdateUser.Size = New System.Drawing.Size(107, 19)
        Me.TextBoxUpdateUser.TabIndex = 84
        Me.TextBoxUpdateUser.TabStop = False
        '
        'TextBoxUpdateDate
        '
        Me.TextBoxUpdateDate.Enabled = False
        Me.TextBoxUpdateDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateDate.Location = New System.Drawing.Point(63, 127)
        Me.TextBoxUpdateDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateDate.Name = "TextBoxUpdateDate"
        Me.TextBoxUpdateDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxUpdateDate.TabIndex = 85
        Me.TextBoxUpdateDate.TabStop = False
        Me.TextBoxUpdateDate.Text = "2017/07/07 10:10:10"
        '
        'TextBoxRegistrationUser
        '
        Me.TextBoxRegistrationUser.Enabled = False
        Me.TextBoxRegistrationUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationUser.Location = New System.Drawing.Point(247, 100)
        Me.TextBoxRegistrationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationUser.Name = "TextBoxRegistrationUser"
        Me.TextBoxRegistrationUser.Size = New System.Drawing.Size(106, 19)
        Me.TextBoxRegistrationUser.TabIndex = 86
        Me.TextBoxRegistrationUser.TabStop = False
        '
        'TextBoxRegistrationDate
        '
        Me.TextBoxRegistrationDate.Enabled = False
        Me.TextBoxRegistrationDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationDate.Location = New System.Drawing.Point(63, 100)
        Me.TextBoxRegistrationDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationDate.Name = "TextBoxRegistrationDate"
        Me.TextBoxRegistrationDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationDate.TabIndex = 87
        Me.TextBoxRegistrationDate.TabStop = False
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(256, 433)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 1
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LabelEditMode)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.TabControl1)
        Me.GroupBox4.Controls.Add(Me.ComboBoxDataEnable)
        Me.GroupBox4.Controls.Add(Me.ComboBoxShapeName)
        Me.GroupBox4.Controls.Add(Me.ComboBoxShapeCategory)
        Me.GroupBox4.Controls.Add(Me.TextBoxPartsCode)
        Me.GroupBox4.Controls.Add(Me.TextBoxPartsModelName)
        Me.GroupBox4.Controls.Add(Me.TextBoxPartsName)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(815, 414)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "基本情報"
        '
        'LabelEditMode
        '
        Me.LabelEditMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelEditMode.Location = New System.Drawing.Point(10, 15)
        Me.LabelEditMode.Name = "LabelEditMode"
        Me.LabelEditMode.Size = New System.Drawing.Size(173, 23)
        Me.LabelEditMode.TabIndex = 90
        Me.LabelEditMode.Text = "編集モード"
        Me.LabelEditMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.DarkKhaki
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateDate)
        Me.GroupBox2.Controls.Add(Me.TextBoxRegistrationDate)
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateHistory)
        Me.GroupBox2.Controls.Add(Me.TextBoxRegistrationUser)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateUser)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 248)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 156)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "更新情報"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(376, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(433, 390)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Orange
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ListBoxPartsImage)
        Me.TabPage1.Controls.Add(Me.ButtonDeleteImageFile)
        Me.TabPage1.Controls.Add(Me.ButtonAddImageFile)
        Me.TabPage1.Controls.Add(Me.PictureBoxPartsImage)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(425, 364)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "部材画像"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 12)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "画像ファイルリスト"
        '
        'ListBoxPartsImage
        '
        Me.ListBoxPartsImage.FormattingEnabled = True
        Me.ListBoxPartsImage.ItemHeight = 12
        Me.ListBoxPartsImage.Location = New System.Drawing.Point(6, 278)
        Me.ListBoxPartsImage.Name = "ListBoxPartsImage"
        Me.ListBoxPartsImage.Size = New System.Drawing.Size(315, 76)
        Me.ListBoxPartsImage.TabIndex = 0
        '
        'ButtonDeleteImageFile
        '
        Me.ButtonDeleteImageFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDeleteImageFile.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonDeleteImageFile.Location = New System.Drawing.Point(333, 326)
        Me.ButtonDeleteImageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteImageFile.Name = "ButtonDeleteImageFile"
        Me.ButtonDeleteImageFile.Size = New System.Drawing.Size(85, 24)
        Me.ButtonDeleteImageFile.TabIndex = 2
        Me.ButtonDeleteImageFile.Text = "画像削除"
        Me.ButtonDeleteImageFile.UseVisualStyleBackColor = False
        '
        'ButtonAddImageFile
        '
        Me.ButtonAddImageFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAddImageFile.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonAddImageFile.Location = New System.Drawing.Point(333, 294)
        Me.ButtonAddImageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddImageFile.Name = "ButtonAddImageFile"
        Me.ButtonAddImageFile.Size = New System.Drawing.Size(85, 24)
        Me.ButtonAddImageFile.TabIndex = 1
        Me.ButtonAddImageFile.Text = "画像追加"
        Me.ButtonAddImageFile.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Goldenrod
        Me.TabPage2.Controls.Add(Me.PictureBoxPartsShape)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(425, 364)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "部品形状"
        '
        'PictureBoxPartsShape
        '
        Me.PictureBoxPartsShape.BackColor = System.Drawing.Color.White
        Me.PictureBoxPartsShape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxPartsShape.Location = New System.Drawing.Point(6, 6)
        Me.PictureBoxPartsShape.Name = "PictureBoxPartsShape"
        Me.PictureBoxPartsShape.Size = New System.Drawing.Size(413, 352)
        Me.PictureBoxPartsShape.TabIndex = 72
        Me.PictureBoxPartsShape.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Peru
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.ListBoxKankotsuFile)
        Me.TabPage3.Controls.Add(Me.ButtonRegistKankotsuFile)
        Me.TabPage3.Controls.Add(Me.ButtonOpenKankotsuFile)
        Me.TabPage3.Controls.Add(Me.ButtonDeleteKankotsuFile)
        Me.TabPage3.Controls.Add(Me.ButtonAddKankotsuFile)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(425, 364)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "カンコツ"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 12)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "カンコツファイルリスト"
        '
        'ListBoxKankotsuFile
        '
        Me.ListBoxKankotsuFile.FormattingEnabled = True
        Me.ListBoxKankotsuFile.ItemHeight = 12
        Me.ListBoxKankotsuFile.Location = New System.Drawing.Point(9, 69)
        Me.ListBoxKankotsuFile.Name = "ListBoxKankotsuFile"
        Me.ListBoxKankotsuFile.Size = New System.Drawing.Size(410, 280)
        Me.ListBoxKankotsuFile.TabIndex = 4
        '
        'ButtonRegistKankotsuFile
        '
        Me.ButtonRegistKankotsuFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistKankotsuFile.Location = New System.Drawing.Point(344, 7)
        Me.ButtonRegistKankotsuFile.Name = "ButtonRegistKankotsuFile"
        Me.ButtonRegistKankotsuFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRegistKankotsuFile.TabIndex = 3
        Me.ButtonRegistKankotsuFile.Text = "ファイル登録"
        Me.ButtonRegistKankotsuFile.UseVisualStyleBackColor = False
        '
        'ButtonOpenKankotsuFile
        '
        Me.ButtonOpenKankotsuFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenKankotsuFile.Location = New System.Drawing.Point(170, 7)
        Me.ButtonOpenKankotsuFile.Name = "ButtonOpenKankotsuFile"
        Me.ButtonOpenKankotsuFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpenKankotsuFile.TabIndex = 2
        Me.ButtonOpenKankotsuFile.Text = "ファイルを開く"
        Me.ButtonOpenKankotsuFile.UseVisualStyleBackColor = False
        '
        'ButtonDeleteKankotsuFile
        '
        Me.ButtonDeleteKankotsuFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDeleteKankotsuFile.Location = New System.Drawing.Point(89, 7)
        Me.ButtonDeleteKankotsuFile.Name = "ButtonDeleteKankotsuFile"
        Me.ButtonDeleteKankotsuFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDeleteKankotsuFile.TabIndex = 1
        Me.ButtonDeleteKankotsuFile.Text = "削除"
        Me.ButtonDeleteKankotsuFile.UseVisualStyleBackColor = False
        '
        'ButtonAddKankotsuFile
        '
        Me.ButtonAddKankotsuFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAddKankotsuFile.Location = New System.Drawing.Point(8, 7)
        Me.ButtonAddKankotsuFile.Name = "ButtonAddKankotsuFile"
        Me.ButtonAddKankotsuFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAddKankotsuFile.TabIndex = 0
        Me.ButtonAddKankotsuFile.Text = "追加"
        Me.ButtonAddKankotsuFile.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Chocolate
        Me.TabPage4.Controls.Add(Me.TextBoxNote)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(425, 364)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "備考"
        '
        'TextBoxNote
        '
        Me.TextBoxNote.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxNote.Location = New System.Drawing.Point(11, 7)
        Me.TextBoxNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNote.Multiline = True
        Me.TextBoxNote.Name = "TextBoxNote"
        Me.TextBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxNote.Size = New System.Drawing.Size(407, 343)
        Me.TextBoxNote.TabIndex = 0
        Me.TextBoxNote.Text = "菱テク　太郎"
        '
        'ComboBoxShapeName
        '
        Me.ComboBoxShapeName.FormattingEnabled = True
        Me.ComboBoxShapeName.Location = New System.Drawing.Point(95, 148)
        Me.ComboBoxShapeName.Name = "ComboBoxShapeName"
        Me.ComboBoxShapeName.Size = New System.Drawing.Size(259, 20)
        Me.ComboBoxShapeName.TabIndex = 4
        '
        'TextBoxPartsModelName
        '
        Me.TextBoxPartsModelName.Location = New System.Drawing.Point(95, 123)
        Me.TextBoxPartsModelName.Name = "TextBoxPartsModelName"
        Me.TextBoxPartsModelName.Size = New System.Drawing.Size(258, 19)
        Me.TextBoxPartsModelName.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "部品形状名"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "型名"
        '
        'FormEditPartsData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(832, 482)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRegistData)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FormEditPartsData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部材マスタ編集"
        CType(Me.PictureBoxPartsImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBoxPartsShape, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxPartsCode As TextBox
    Friend WithEvents TextBoxPartsName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxDataEnable As ComboBox
    Friend WithEvents ComboBoxShapeCategory As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents PictureBoxPartsImage As PictureBox
    Protected WithEvents ButtonCancel As Button
    Friend WithEvents Label2 As Label
    Protected WithEvents TextBoxUpdateHistory As TextBox
    Protected WithEvents Label12 As Label
    Protected WithEvents Label11 As Label
    Protected WithEvents Label4 As Label
    Protected WithEvents Label7 As Label
    Protected WithEvents TextBoxUpdateUser As TextBox
    Protected WithEvents TextBoxUpdateDate As TextBox
    Protected WithEvents TextBoxRegistrationUser As TextBox
    Protected WithEvents TextBoxRegistrationDate As TextBox
    Protected WithEvents ButtonRegistData As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextBoxPartsModelName As TextBox
    Friend WithEvents Label6 As Label
    Protected WithEvents TextBoxNote As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBoxShapeName As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents PictureBoxPartsShape As PictureBox
    Protected WithEvents ButtonDeleteImageFile As Button
    Protected WithEvents ButtonAddImageFile As Button
    Friend WithEvents ButtonRegistKankotsuFile As Button
    Friend WithEvents ButtonOpenKankotsuFile As Button
    Friend WithEvents ButtonDeleteKankotsuFile As Button
    Friend WithEvents ButtonAddKankotsuFile As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ListBoxPartsImage As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ListBoxKankotsuFile As ListBox
    Friend WithEvents LabelEditMode As Label
End Class
