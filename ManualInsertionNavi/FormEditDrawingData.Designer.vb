<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditDrawingData
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
        Me.components = New System.ComponentModel.Container()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TextBoxMaxLot = New System.Windows.Forms.TextBox()
        Me.TextBoxBoardHeight = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxBoardWidth = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LabelEditMode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxUpdateDate = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationDate = New System.Windows.Forms.TextBox()
        Me.TextBoxUpdateHistory = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationUser = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateUser = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LabelDrawingImageRegistStatus = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonSelectDrawingImageFile = New System.Windows.Forms.Button()
        Me.PictureBoxDrawingImage = New System.Windows.Forms.PictureBox()
        Me.TextBoxDrawingImageFilename = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelBoardImageRagistStatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonSelectBoardImageFile = New System.Windows.Forms.Button()
        Me.PictureBoxBoardImage = New System.Windows.Forms.PictureBox()
        Me.TextBoxBoardImageFilename = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxNetlistFilename = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelNetlistResistStatus = New System.Windows.Forms.Label()
        Me.ButtonOpenNetlistFile = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonSelectNetlistFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxShogenhyoFilename = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelShogenhyoResistStatus = New System.Windows.Forms.Label()
        Me.ButtonOpenShogenhyoFile = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonSelectShogenhyoFile = New System.Windows.Forms.Button()
        Me.ButtonRegistPartsData = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxRevision = New System.Windows.Forms.TextBox()
        Me.TextBoxDrawingNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErrorProviderInput = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBoxDrawingImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBoxBoardImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(403, 507)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 5
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(253, 507)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 4
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.PaleGreen
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.LabelEditMode)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.TabControl1)
        Me.GroupBox4.Controls.Add(Me.ComboBoxDataEnable)
        Me.GroupBox4.Controls.Add(Me.TextBoxId)
        Me.GroupBox4.Controls.Add(Me.TextBoxRevision)
        Me.GroupBox4.Controls.Add(Me.TextBoxDrawingNo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(815, 488)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "基本情報"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.GroupBox5.Controls.Add(Me.TextBoxMaxLot)
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardHeight)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardWidth)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardName)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 151)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(364, 161)
        Me.GroupBox5.TabIndex = 91
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "基板情報"
        '
        'TextBoxMaxLot
        '
        Me.TextBoxMaxLot.Location = New System.Drawing.Point(85, 125)
        Me.TextBoxMaxLot.Name = "TextBoxMaxLot"
        Me.TextBoxMaxLot.Size = New System.Drawing.Size(112, 19)
        Me.TextBoxMaxLot.TabIndex = 2
        Me.TextBoxMaxLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxBoardHeight
        '
        Me.TextBoxBoardHeight.Location = New System.Drawing.Point(85, 76)
        Me.TextBoxBoardHeight.Name = "TextBoxBoardHeight"
        Me.TextBoxBoardHeight.Size = New System.Drawing.Size(112, 19)
        Me.TextBoxBoardHeight.TabIndex = 2
        Me.TextBoxBoardHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(203, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(17, 12)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "枚"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 12)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "最大制作ロット"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(203, 79)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 12)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "mm"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(27, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 12)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "縦サイズ"
        '
        'TextBoxBoardWidth
        '
        Me.TextBoxBoardWidth.Location = New System.Drawing.Point(85, 51)
        Me.TextBoxBoardWidth.Name = "TextBoxBoardWidth"
        Me.TextBoxBoardWidth.Size = New System.Drawing.Size(112, 19)
        Me.TextBoxBoardWidth.TabIndex = 2
        Me.TextBoxBoardWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(203, 54)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 12)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "mm"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 12)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "横サイズ"
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(85, 26)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.Size = New System.Drawing.Size(245, 19)
        Me.TextBoxBoardName.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(44, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 12)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "名称"
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
        Me.GroupBox2.BackColor = System.Drawing.Color.ForestGreen
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateDate)
        Me.GroupBox2.Controls.Add(Me.TextBoxRegistrationDate)
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateHistory)
        Me.GroupBox2.Controls.Add(Me.TextBoxRegistrationUser)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBoxUpdateUser)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 326)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 156)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "更新情報"
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(376, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(433, 464)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.GreenYellow
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.LabelDrawingImageRegistStatus)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.ButtonSelectDrawingImageFile)
        Me.TabPage2.Controls.Add(Me.PictureBoxDrawingImage)
        Me.TabPage2.Controls.Add(Me.TextBoxDrawingImageFilename)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(425, 438)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "図面画像"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "登録状況"
        '
        'LabelDrawingImageRegistStatus
        '
        Me.LabelDrawingImageRegistStatus.BackColor = System.Drawing.Color.Lime
        Me.LabelDrawingImageRegistStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelDrawingImageRegistStatus.Location = New System.Drawing.Point(82, 9)
        Me.LabelDrawingImageRegistStatus.Name = "LabelDrawingImageRegistStatus"
        Me.LabelDrawingImageRegistStatus.Size = New System.Drawing.Size(60, 20)
        Me.LabelDrawingImageRegistStatus.TabIndex = 92
        Me.LabelDrawingImageRegistStatus.Text = "登録済"
        Me.LabelDrawingImageRegistStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 290)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 12)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "画像ファイル名"
        '
        'ButtonSelectDrawingImageFile
        '
        Me.ButtonSelectDrawingImageFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSelectDrawingImageFile.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSelectDrawingImageFile.Location = New System.Drawing.Point(336, 304)
        Me.ButtonSelectDrawingImageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSelectDrawingImageFile.Name = "ButtonSelectDrawingImageFile"
        Me.ButtonSelectDrawingImageFile.Size = New System.Drawing.Size(85, 24)
        Me.ButtonSelectDrawingImageFile.TabIndex = 87
        Me.ButtonSelectDrawingImageFile.Text = "ファイル選択"
        Me.ButtonSelectDrawingImageFile.UseVisualStyleBackColor = False
        '
        'PictureBoxDrawingImage
        '
        Me.PictureBoxDrawingImage.BackColor = System.Drawing.Color.White
        Me.PictureBoxDrawingImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxDrawingImage.Location = New System.Drawing.Point(11, 29)
        Me.PictureBoxDrawingImage.Name = "PictureBoxDrawingImage"
        Me.PictureBoxDrawingImage.Size = New System.Drawing.Size(407, 248)
        Me.PictureBoxDrawingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxDrawingImage.TabIndex = 89
        Me.PictureBoxDrawingImage.TabStop = False
        '
        'TextBoxDrawingImageFilename
        '
        Me.TextBoxDrawingImageFilename.Location = New System.Drawing.Point(11, 304)
        Me.TextBoxDrawingImageFilename.Name = "TextBoxDrawingImageFilename"
        Me.TextBoxDrawingImageFilename.Size = New System.Drawing.Size(318, 19)
        Me.TextBoxDrawingImageFilename.TabIndex = 88
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.YellowGreen
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.LabelBoardImageRagistStatus)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ButtonSelectBoardImageFile)
        Me.TabPage1.Controls.Add(Me.PictureBoxBoardImage)
        Me.TabPage1.Controls.Add(Me.TextBoxBoardImageFilename)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(425, 438)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "基板画像"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "登録状況"
        '
        'LabelBoardImageRagistStatus
        '
        Me.LabelBoardImageRagistStatus.BackColor = System.Drawing.Color.Lime
        Me.LabelBoardImageRagistStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelBoardImageRagistStatus.Location = New System.Drawing.Point(82, 9)
        Me.LabelBoardImageRagistStatus.Name = "LabelBoardImageRagistStatus"
        Me.LabelBoardImageRagistStatus.Size = New System.Drawing.Size(60, 20)
        Me.LabelBoardImageRagistStatus.TabIndex = 86
        Me.LabelBoardImageRagistStatus.Text = "登録済"
        Me.LabelBoardImageRagistStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 12)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "画像ファイル名"
        '
        'ButtonSelectBoardImageFile
        '
        Me.ButtonSelectBoardImageFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSelectBoardImageFile.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSelectBoardImageFile.Location = New System.Drawing.Point(336, 304)
        Me.ButtonSelectBoardImageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSelectBoardImageFile.Name = "ButtonSelectBoardImageFile"
        Me.ButtonSelectBoardImageFile.Size = New System.Drawing.Size(85, 24)
        Me.ButtonSelectBoardImageFile.TabIndex = 1
        Me.ButtonSelectBoardImageFile.Text = "ファイル選択"
        Me.ButtonSelectBoardImageFile.UseVisualStyleBackColor = False
        '
        'PictureBoxBoardImage
        '
        Me.PictureBoxBoardImage.BackColor = System.Drawing.Color.White
        Me.PictureBoxBoardImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxBoardImage.Location = New System.Drawing.Point(11, 29)
        Me.PictureBoxBoardImage.Name = "PictureBoxBoardImage"
        Me.PictureBoxBoardImage.Size = New System.Drawing.Size(407, 248)
        Me.PictureBoxBoardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxBoardImage.TabIndex = 71
        Me.PictureBoxBoardImage.TabStop = False
        '
        'TextBoxBoardImageFilename
        '
        Me.TextBoxBoardImageFilename.Location = New System.Drawing.Point(11, 304)
        Me.TextBoxBoardImageFilename.Name = "TextBoxBoardImageFilename"
        Me.TextBoxBoardImageFilename.Size = New System.Drawing.Size(318, 19)
        Me.TextBoxBoardImageFilename.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.OliveDrab
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.ButtonRegistPartsData)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(425, 438)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "諸元表／NETリスト"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxNetlistFilename)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.LabelNetlistResistStatus)
        Me.GroupBox3.Controls.Add(Me.ButtonOpenNetlistFile)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.ButtonSelectNetlistFile)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 159)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(408, 130)
        Me.GroupBox3.TabIndex = 84
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NETリスト"
        '
        'TextBoxNetlistFilename
        '
        Me.TextBoxNetlistFilename.Location = New System.Drawing.Point(21, 98)
        Me.TextBoxNetlistFilename.Name = "TextBoxNetlistFilename"
        Me.TextBoxNetlistFilename.Size = New System.Drawing.Size(318, 19)
        Me.TextBoxNetlistFilename.TabIndex = 85
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "登録状況"
        '
        'LabelNetlistResistStatus
        '
        Me.LabelNetlistResistStatus.BackColor = System.Drawing.Color.Lime
        Me.LabelNetlistResistStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelNetlistResistStatus.Location = New System.Drawing.Point(92, 20)
        Me.LabelNetlistResistStatus.Name = "LabelNetlistResistStatus"
        Me.LabelNetlistResistStatus.Size = New System.Drawing.Size(60, 20)
        Me.LabelNetlistResistStatus.TabIndex = 84
        Me.LabelNetlistResistStatus.Text = "登録済"
        Me.LabelNetlistResistStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonOpenNetlistFile
        '
        Me.ButtonOpenNetlistFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenNetlistFile.Location = New System.Drawing.Point(172, 54)
        Me.ButtonOpenNetlistFile.Name = "ButtonOpenNetlistFile"
        Me.ButtonOpenNetlistFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpenNetlistFile.TabIndex = 2
        Me.ButtonOpenNetlistFile.Text = "ファイルを開く"
        Me.ButtonOpenNetlistFile.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 12)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "ファイル名"
        '
        'ButtonSelectNetlistFile
        '
        Me.ButtonSelectNetlistFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSelectNetlistFile.Location = New System.Drawing.Point(21, 54)
        Me.ButtonSelectNetlistFile.Name = "ButtonSelectNetlistFile"
        Me.ButtonSelectNetlistFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSelectNetlistFile.TabIndex = 0
        Me.ButtonSelectNetlistFile.Text = "登録/変更"
        Me.ButtonSelectNetlistFile.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxShogenhyoFilename)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LabelShogenhyoResistStatus)
        Me.GroupBox1.Controls.Add(Me.ButtonOpenShogenhyoFile)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ButtonSelectShogenhyoFile)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 146)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "諸元表"
        '
        'TextBoxShogenhyoFilename
        '
        Me.TextBoxShogenhyoFilename.Location = New System.Drawing.Point(21, 104)
        Me.TextBoxShogenhyoFilename.Name = "TextBoxShogenhyoFilename"
        Me.TextBoxShogenhyoFilename.Size = New System.Drawing.Size(318, 19)
        Me.TextBoxShogenhyoFilename.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "登録状況"
        '
        'LabelShogenhyoResistStatus
        '
        Me.LabelShogenhyoResistStatus.BackColor = System.Drawing.Color.Lime
        Me.LabelShogenhyoResistStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelShogenhyoResistStatus.Location = New System.Drawing.Point(92, 20)
        Me.LabelShogenhyoResistStatus.Name = "LabelShogenhyoResistStatus"
        Me.LabelShogenhyoResistStatus.Size = New System.Drawing.Size(60, 20)
        Me.LabelShogenhyoResistStatus.TabIndex = 84
        Me.LabelShogenhyoResistStatus.Text = "登録済"
        Me.LabelShogenhyoResistStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonOpenShogenhyoFile
        '
        Me.ButtonOpenShogenhyoFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenShogenhyoFile.Location = New System.Drawing.Point(172, 54)
        Me.ButtonOpenShogenhyoFile.Name = "ButtonOpenShogenhyoFile"
        Me.ButtonOpenShogenhyoFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpenShogenhyoFile.TabIndex = 2
        Me.ButtonOpenShogenhyoFile.Text = "ファイルを開く"
        Me.ButtonOpenShogenhyoFile.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 12)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "ファイル名"
        '
        'ButtonSelectShogenhyoFile
        '
        Me.ButtonSelectShogenhyoFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSelectShogenhyoFile.Location = New System.Drawing.Point(21, 54)
        Me.ButtonSelectShogenhyoFile.Name = "ButtonSelectShogenhyoFile"
        Me.ButtonSelectShogenhyoFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSelectShogenhyoFile.TabIndex = 0
        Me.ButtonSelectShogenhyoFile.Text = "登録/変更"
        Me.ButtonSelectShogenhyoFile.UseVisualStyleBackColor = False
        '
        'ButtonRegistPartsData
        '
        Me.ButtonRegistPartsData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistPartsData.Location = New System.Drawing.Point(11, 311)
        Me.ButtonRegistPartsData.Name = "ButtonRegistPartsData"
        Me.ButtonRegistPartsData.Size = New System.Drawing.Size(152, 39)
        Me.ButtonRegistPartsData.TabIndex = 2
        Me.ButtonRegistPartsData.Text = "部品データ登録"
        Me.ButtonRegistPartsData.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.DarkGreen
        Me.TabPage4.Controls.Add(Me.TextBoxNote)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(425, 438)
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
        Me.TextBoxNote.Size = New System.Drawing.Size(407, 421)
        Me.TextBoxNote.TabIndex = 0
        Me.TextBoxNote.Text = "菱テク　太郎"
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(94, 80)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 1
        '
        'TextBoxId
        '
        Me.TextBoxId.Location = New System.Drawing.Point(94, 55)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(171, 19)
        Me.TextBoxId.TabIndex = 0
        '
        'TextBoxRevision
        '
        Me.TextBoxRevision.Location = New System.Drawing.Point(275, 106)
        Me.TextBoxRevision.Name = "TextBoxRevision"
        Me.TextBoxRevision.Size = New System.Drawing.Size(50, 19)
        Me.TextBoxRevision.TabIndex = 3
        '
        'TextBoxDrawingNo
        '
        Me.TextBoxDrawingNo.Location = New System.Drawing.Point(95, 106)
        Me.TextBoxDrawingNo.Name = "TextBoxDrawingNo"
        Me.TextBoxDrawingNo.Size = New System.Drawing.Size(135, 19)
        Me.TextBoxDrawingNo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(240, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "副番"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "データ状態"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "図面番号"
        '
        'ErrorProviderInput
        '
        Me.ErrorProviderInput.ContainerControl = Me
        '
        'FormEditDrawingData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(836, 561)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRegistData)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormEditDrawingData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "図面情報編集画面"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBoxDrawingImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBoxBoardImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents ButtonCancel As Button
    Protected WithEvents ButtonRegistData As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents LabelEditMode As Label
    Friend WithEvents GroupBox2 As GroupBox
    Protected WithEvents TextBoxUpdateDate As TextBox
    Protected WithEvents TextBoxRegistrationDate As TextBox
    Protected WithEvents TextBoxUpdateHistory As TextBox
    Protected WithEvents TextBoxRegistrationUser As TextBox
    Protected WithEvents Label12 As Label
    Protected WithEvents TextBoxUpdateUser As TextBox
    Protected WithEvents Label11 As Label
    Protected WithEvents Label7 As Label
    Protected WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label5 As Label
    Protected WithEvents ButtonSelectBoardImageFile As Button
    Friend WithEvents PictureBoxBoardImage As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ButtonOpenShogenhyoFile As Button
    Friend WithEvents TabPage4 As TabPage
    Protected WithEvents TextBoxNote As TextBox
    Friend WithEvents ComboBoxDataEnable As ComboBox
    Friend WithEvents TextBoxId As TextBox
    Friend WithEvents TextBoxRevision As TextBox
    Friend WithEvents TextBoxDrawingNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ButtonSelectShogenhyoFile As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelShogenhyoResistStatus As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelBoardImageRagistStatus As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LabelNetlistResistStatus As Label
    Friend WithEvents ButtonOpenNetlistFile As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents ButtonSelectNetlistFile As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents TextBoxBoardImageFilename As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label13 As Label
    Friend WithEvents LabelDrawingImageRegistStatus As Label
    Friend WithEvents Label18 As Label
    Protected WithEvents ButtonSelectDrawingImageFile As Button
    Friend WithEvents PictureBoxDrawingImage As PictureBox
    Friend WithEvents TextBoxDrawingImageFilename As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextBoxBoardHeight As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBoxBoardWidth As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBoxNetlistFilename As TextBox
    Friend WithEvents TextBoxShogenhyoFilename As TextBox
    Friend WithEvents ButtonRegistPartsData As Button
    Friend WithEvents TextBoxMaxLot As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents ErrorProviderInput As ErrorProvider
End Class
