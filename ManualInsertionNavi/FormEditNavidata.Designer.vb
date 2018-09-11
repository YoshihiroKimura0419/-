<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditNavidata
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxDrawingNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxNetlistFilename = New System.Windows.Forms.TextBox()
        Me.TextBoxShogenhyoFilename = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TextBoxBoardHeight = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxBoardWidth = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBoxMaxLot = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabelDrawingID = New System.Windows.Forms.Label()
        Me.TextBoxRevision = New System.Windows.Forms.TextBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.GroupBoxNaviBoardNo = New System.Windows.Forms.GroupBox()
        Me.LabelProductionLot = New System.Windows.Forms.Label()
        Me.GroupBoxOperationControl = New System.Windows.Forms.GroupBox()
        Me.Label1WorkTime = New System.Windows.Forms.Label()
        Me.ButtonStartProduction = New System.Windows.Forms.Button()
        Me.ButtonIncrimentNaviStepBoard = New System.Windows.Forms.Button()
        Me.ButtonDecrimentNaviStepBoard = New System.Windows.Forms.Button()
        Me.ButtonPauseProduction = New System.Windows.Forms.Button()
        Me.ButtonTerminateProdution = New System.Windows.Forms.Button()
        Me.GroupBoxOrderInfo = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBoxProductionDailyPlan = New System.Windows.Forms.TextBox()
        Me.TextBoxProductionDailyActual = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxProductionTotalPlan = New System.Windows.Forms.TextBox()
        Me.TextBoxProductionTotalActual = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxOrder = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBoxPresentParts = New System.Windows.Forms.PictureBox()
        Me.PictureBoxAllParts = New System.Windows.Forms.PictureBox()
        Me.PictureBoxBoard = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ButtonOpenPartsImageFile = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListBoxPartsImage = New System.Windows.Forms.ListBox()
        Me.PictureBoxPartsImage = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ListBoxKankotsuFile = New System.Windows.Forms.ListBox()
        Me.ButtonOpenKankotsuFile = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.TextBoxTotalUseCount = New System.Windows.Forms.TextBox()
        Me.TextBoxModelName = New System.Windows.Forms.TextBox()
        Me.TextBoxPartsName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxPartsCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewSamePartsCode = New System.Windows.Forms.DataGridView()
        Me.CheckBoxEditStep = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.DataGridViewNavidata = New System.Windows.Forms.DataGridView()
        Me.ButtonDownStep = New System.Windows.Forms.Button()
        Me.ButtonUpStep = New System.Windows.Forms.Button()
        Me.ButtonOpenEditPartsMaster = New System.Windows.Forms.Button()
        Me.ButtonEditPartsShape = New System.Windows.Forms.Button()
        Me.ButtonAddNaviData = New System.Windows.Forms.Button()
        Me.TimerFlicker = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDispWorkTime = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGetOrderActual = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.GroupBoxNaviBoardNo.SuspendLayout()
        Me.GroupBoxOperationControl.SuspendLayout()
        Me.GroupBoxOrderInfo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBoxPresentParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAllParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBoxPartsImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridViewSamePartsCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewNavidata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBoxEditStep)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonRegistData)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewNavidata)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonDownStep)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonUpStep)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonOpenEditPartsMaster)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonEditPartsShape)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonAddNaviData)
        Me.SplitContainer1.Size = New System.Drawing.Size(1776, 1015)
        Me.SplitContainer1.SplitterDistance = 815
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.DarkGreen
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1776, 815)
        Me.SplitContainer2.SplitterDistance = 158
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxDrawingNo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.TextBoxId)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.LabelDrawingID)
        Me.GroupBox2.Controls.Add(Me.TextBoxRevision)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1421, 151)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'TextBoxDrawingNo
        '
        Me.TextBoxDrawingNo.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxDrawingNo.Location = New System.Drawing.Point(108, 71)
        Me.TextBoxDrawingNo.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDrawingNo.Name = "TextBoxDrawingNo"
        Me.TextBoxDrawingNo.ReadOnly = True
        Me.TextBoxDrawingNo.Size = New System.Drawing.Size(200, 28)
        Me.TextBoxDrawingNo.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 21)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "図面番号"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxNetlistFilename)
        Me.GroupBox1.Controls.Add(Me.TextBoxShogenhyoFilename)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(893, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(521, 127)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "諸元表/Netリスト　ファイル"
        '
        'TextBoxNetlistFilename
        '
        Me.TextBoxNetlistFilename.Location = New System.Drawing.Point(118, 61)
        Me.TextBoxNetlistFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNetlistFilename.Name = "TextBoxNetlistFilename"
        Me.TextBoxNetlistFilename.ReadOnly = True
        Me.TextBoxNetlistFilename.Size = New System.Drawing.Size(395, 28)
        Me.TextBoxNetlistFilename.TabIndex = 88
        '
        'TextBoxShogenhyoFilename
        '
        Me.TextBoxShogenhyoFilename.Location = New System.Drawing.Point(118, 24)
        Me.TextBoxShogenhyoFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxShogenhyoFilename.Name = "TextBoxShogenhyoFilename"
        Me.TextBoxShogenhyoFilename.ReadOnly = True
        Me.TextBoxShogenhyoFilename.Size = New System.Drawing.Size(395, 28)
        Me.TextBoxShogenhyoFilename.TabIndex = 87
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 21)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Netリスト"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 31)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 21)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "諸元表"
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(108, 35)
        Me.TextBoxId.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.ReadOnly = True
        Me.TextBoxId.Size = New System.Drawing.Size(124, 28)
        Me.TextBoxId.TabIndex = 92
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardHeight)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardWidth)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.TextBoxMaxLot)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.TextBoxBoardName)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(331, 17)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(554, 127)
        Me.GroupBox5.TabIndex = 98
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "基板情報"
        '
        'TextBoxBoardHeight
        '
        Me.TextBoxBoardHeight.Location = New System.Drawing.Point(119, 93)
        Me.TextBoxBoardHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardHeight.Name = "TextBoxBoardHeight"
        Me.TextBoxBoardHeight.ReadOnly = True
        Me.TextBoxBoardHeight.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxBoardHeight.TabIndex = 2
        Me.TextBoxBoardHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(232, 97)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 21)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "mm"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(31, 96)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 21)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "縦サイズ"
        '
        'TextBoxBoardWidth
        '
        Me.TextBoxBoardWidth.Location = New System.Drawing.Point(119, 57)
        Me.TextBoxBoardWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardWidth.Name = "TextBoxBoardWidth"
        Me.TextBoxBoardWidth.ReadOnly = True
        Me.TextBoxBoardWidth.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxBoardWidth.TabIndex = 2
        Me.TextBoxBoardWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(234, 61)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 21)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "mm"
        '
        'TextBoxMaxLot
        '
        Me.TextBoxMaxLot.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxMaxLot.Location = New System.Drawing.Point(449, 61)
        Me.TextBoxMaxLot.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxMaxLot.Name = "TextBoxMaxLot"
        Me.TextBoxMaxLot.ReadOnly = True
        Me.TextBoxMaxLot.Size = New System.Drawing.Size(73, 28)
        Me.TextBoxMaxLot.TabIndex = 97
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(31, 60)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 21)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "横サイズ"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(284, 64)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(157, 21)
        Me.Label22.TabIndex = 95
        Me.Label22.Text = "最大同時制作数"
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(119, 24)
        Me.TextBoxBoardName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.ReadOnly = True
        Me.TextBoxBoardName.Size = New System.Drawing.Size(403, 28)
        Me.TextBoxBoardName.TabIndex = 2
        Me.TextBoxBoardName.Text = "012345678901234567890123456789"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(59, 27)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 21)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "名称"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 110)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 21)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "副番"
        '
        'LabelDrawingID
        '
        Me.LabelDrawingID.AutoSize = True
        Me.LabelDrawingID.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelDrawingID.Location = New System.Drawing.Point(32, 38)
        Me.LabelDrawingID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDrawingID.Name = "LabelDrawingID"
        Me.LabelDrawingID.Size = New System.Drawing.Size(71, 21)
        Me.LabelDrawingID.TabIndex = 94
        Me.LabelDrawingID.Text = "図面ID"
        '
        'TextBoxRevision
        '
        Me.TextBoxRevision.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRevision.Location = New System.Drawing.Point(108, 106)
        Me.TextBoxRevision.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRevision.Name = "TextBoxRevision"
        Me.TextBoxRevision.ReadOnly = True
        Me.TextBoxRevision.Size = New System.Drawing.Size(73, 28)
        Me.TextBoxRevision.TabIndex = 97
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.ForestGreen
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.YellowGreen
        Me.SplitContainer3.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer3.Panel2.Controls.Add(Me.TextBoxTotalUseCount)
        Me.SplitContainer3.Panel2.Controls.Add(Me.TextBoxModelName)
        Me.SplitContainer3.Panel2.Controls.Add(Me.TextBoxPartsName)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer3.Panel2.Controls.Add(Me.TextBoxPartsCode)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridViewSamePartsCode)
        Me.SplitContainer3.Size = New System.Drawing.Size(1776, 652)
        Me.SplitContainer3.SplitterDistance = 1434
        Me.SplitContainer3.SplitterWidth = 6
        Me.SplitContainer3.TabIndex = 4
        '
        'SplitContainer4
        '
        Me.SplitContainer4.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.AutoScroll = True
        Me.SplitContainer4.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer4.Panel1.Controls.Add(Me.GroupBoxNaviBoardNo)
        Me.SplitContainer4.Panel1.Controls.Add(Me.GroupBoxOperationControl)
        Me.SplitContainer4.Panel1.Controls.Add(Me.GroupBoxOrderInfo)
        Me.SplitContainer4.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Button7)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Button2)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.PictureBoxPresentParts)
        Me.SplitContainer4.Panel2.Controls.Add(Me.PictureBoxAllParts)
        Me.SplitContainer4.Panel2.Controls.Add(Me.PictureBoxBoard)
        Me.SplitContainer4.Size = New System.Drawing.Size(1434, 652)
        Me.SplitContainer4.SplitterDistance = 323
        Me.SplitContainer4.TabIndex = 0
        '
        'GroupBoxNaviBoardNo
        '
        Me.GroupBoxNaviBoardNo.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.GroupBoxNaviBoardNo.Controls.Add(Me.LabelProductionLot)
        Me.GroupBoxNaviBoardNo.Location = New System.Drawing.Point(3, 193)
        Me.GroupBoxNaviBoardNo.Name = "GroupBoxNaviBoardNo"
        Me.GroupBoxNaviBoardNo.Size = New System.Drawing.Size(306, 90)
        Me.GroupBoxNaviBoardNo.TabIndex = 98
        Me.GroupBoxNaviBoardNo.TabStop = False
        Me.GroupBoxNaviBoardNo.Text = "ロットNo／生産ロット"
        '
        'LabelProductionLot
        '
        Me.LabelProductionLot.BackColor = System.Drawing.Color.White
        Me.LabelProductionLot.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelProductionLot.Location = New System.Drawing.Point(29, 19)
        Me.LabelProductionLot.Name = "LabelProductionLot"
        Me.LabelProductionLot.Size = New System.Drawing.Size(254, 58)
        Me.LabelProductionLot.TabIndex = 97
        Me.LabelProductionLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBoxOperationControl
        '
        Me.GroupBoxOperationControl.BackColor = System.Drawing.Color.DarkCyan
        Me.GroupBoxOperationControl.Controls.Add(Me.Label1WorkTime)
        Me.GroupBoxOperationControl.Controls.Add(Me.ButtonStartProduction)
        Me.GroupBoxOperationControl.Controls.Add(Me.ButtonIncrimentNaviStepBoard)
        Me.GroupBoxOperationControl.Controls.Add(Me.ButtonDecrimentNaviStepBoard)
        Me.GroupBoxOperationControl.Controls.Add(Me.ButtonPauseProduction)
        Me.GroupBoxOperationControl.Controls.Add(Me.ButtonTerminateProdution)
        Me.GroupBoxOperationControl.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBoxOperationControl.Location = New System.Drawing.Point(4, 289)
        Me.GroupBoxOperationControl.Name = "GroupBoxOperationControl"
        Me.GroupBoxOperationControl.Size = New System.Drawing.Size(308, 249)
        Me.GroupBoxOperationControl.TabIndex = 96
        Me.GroupBoxOperationControl.TabStop = False
        Me.GroupBoxOperationControl.Text = "操作選択"
        '
        'Label1WorkTime
        '
        Me.Label1WorkTime.BackColor = System.Drawing.Color.White
        Me.Label1WorkTime.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1WorkTime.ForeColor = System.Drawing.Color.Black
        Me.Label1WorkTime.Location = New System.Drawing.Point(9, 187)
        Me.Label1WorkTime.Name = "Label1WorkTime"
        Me.Label1WorkTime.Size = New System.Drawing.Size(290, 52)
        Me.Label1WorkTime.TabIndex = 3
        Me.Label1WorkTime.Text = "00:00:00"
        Me.Label1WorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonStartProduction
        '
        Me.ButtonStartProduction.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonStartProduction.Font = New System.Drawing.Font("MS UI Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonStartProduction.ForeColor = System.Drawing.Color.Black
        Me.ButtonStartProduction.Location = New System.Drawing.Point(7, 23)
        Me.ButtonStartProduction.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonStartProduction.Name = "ButtonStartProduction"
        Me.ButtonStartProduction.Size = New System.Drawing.Size(294, 51)
        Me.ButtonStartProduction.TabIndex = 2
        Me.ButtonStartProduction.Text = "作業開始"
        Me.ButtonStartProduction.UseVisualStyleBackColor = False
        '
        'ButtonIncrimentNaviStepBoard
        '
        Me.ButtonIncrimentNaviStepBoard.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonIncrimentNaviStepBoard.ForeColor = System.Drawing.Color.Black
        Me.ButtonIncrimentNaviStepBoard.Location = New System.Drawing.Point(7, 100)
        Me.ButtonIncrimentNaviStepBoard.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonIncrimentNaviStepBoard.Name = "ButtonIncrimentNaviStepBoard"
        Me.ButtonIncrimentNaviStepBoard.Size = New System.Drawing.Size(134, 35)
        Me.ButtonIncrimentNaviStepBoard.TabIndex = 2
        Me.ButtonIncrimentNaviStepBoard.Text = "次に進む"
        Me.ButtonIncrimentNaviStepBoard.UseVisualStyleBackColor = False
        '
        'ButtonDecrimentNaviStepBoard
        '
        Me.ButtonDecrimentNaviStepBoard.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDecrimentNaviStepBoard.ForeColor = System.Drawing.Color.Black
        Me.ButtonDecrimentNaviStepBoard.Location = New System.Drawing.Point(167, 100)
        Me.ButtonDecrimentNaviStepBoard.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDecrimentNaviStepBoard.Name = "ButtonDecrimentNaviStepBoard"
        Me.ButtonDecrimentNaviStepBoard.Size = New System.Drawing.Size(134, 35)
        Me.ButtonDecrimentNaviStepBoard.TabIndex = 2
        Me.ButtonDecrimentNaviStepBoard.Text = "前に戻る"
        Me.ButtonDecrimentNaviStepBoard.UseVisualStyleBackColor = False
        '
        'ButtonPauseProduction
        '
        Me.ButtonPauseProduction.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonPauseProduction.ForeColor = System.Drawing.Color.Black
        Me.ButtonPauseProduction.Location = New System.Drawing.Point(7, 143)
        Me.ButtonPauseProduction.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonPauseProduction.Name = "ButtonPauseProduction"
        Me.ButtonPauseProduction.Size = New System.Drawing.Size(134, 35)
        Me.ButtonPauseProduction.TabIndex = 2
        Me.ButtonPauseProduction.Text = "一時中断"
        Me.ButtonPauseProduction.UseVisualStyleBackColor = False
        '
        'ButtonTerminateProdution
        '
        Me.ButtonTerminateProdution.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonTerminateProdution.ForeColor = System.Drawing.Color.Black
        Me.ButtonTerminateProdution.Location = New System.Drawing.Point(167, 143)
        Me.ButtonTerminateProdution.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonTerminateProdution.Name = "ButtonTerminateProdution"
        Me.ButtonTerminateProdution.Size = New System.Drawing.Size(134, 35)
        Me.ButtonTerminateProdution.TabIndex = 2
        Me.ButtonTerminateProdution.Text = "作業終了"
        Me.ButtonTerminateProdution.UseVisualStyleBackColor = False
        '
        'GroupBoxOrderInfo
        '
        Me.GroupBoxOrderInfo.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBoxOrderInfo.Controls.Add(Me.GroupBox4)
        Me.GroupBoxOrderInfo.Controls.Add(Me.GroupBox3)
        Me.GroupBoxOrderInfo.Controls.Add(Me.TextBoxOrder)
        Me.GroupBoxOrderInfo.Controls.Add(Me.Label11)
        Me.GroupBoxOrderInfo.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBoxOrderInfo.Location = New System.Drawing.Point(4, 3)
        Me.GroupBoxOrderInfo.Name = "GroupBoxOrderInfo"
        Me.GroupBoxOrderInfo.Size = New System.Drawing.Size(308, 184)
        Me.GroupBoxOrderInfo.TabIndex = 95
        Me.GroupBoxOrderInfo.TabStop = False
        Me.GroupBoxOrderInfo.Text = "オーダー情報"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBoxProductionDailyPlan)
        Me.GroupBox4.Controls.Add(Me.TextBoxProductionDailyActual)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox4.Location = New System.Drawing.Point(17, 116)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(282, 55)
        Me.GroupBox4.TabIndex = 95
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "日産(実績/計画)"
        '
        'TextBoxProductionDailyPlan
        '
        Me.TextBoxProductionDailyPlan.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxProductionDailyPlan.Location = New System.Drawing.Point(170, 20)
        Me.TextBoxProductionDailyPlan.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProductionDailyPlan.Name = "TextBoxProductionDailyPlan"
        Me.TextBoxProductionDailyPlan.ReadOnly = True
        Me.TextBoxProductionDailyPlan.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxProductionDailyPlan.TabIndex = 92
        Me.TextBoxProductionDailyPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxProductionDailyActual
        '
        Me.TextBoxProductionDailyActual.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxProductionDailyActual.Location = New System.Drawing.Point(34, 20)
        Me.TextBoxProductionDailyActual.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProductionDailyActual.Name = "TextBoxProductionDailyActual"
        Me.TextBoxProductionDailyActual.ReadOnly = True
        Me.TextBoxProductionDailyActual.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxProductionDailyActual.TabIndex = 92
        Me.TextBoxProductionDailyActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(146, 23)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 21)
        Me.Label15.TabIndex = 94
        Me.Label15.Text = "/"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxProductionTotalPlan)
        Me.GroupBox3.Controls.Add(Me.TextBoxProductionTotalActual)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox3.Location = New System.Drawing.Point(18, 55)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(282, 55)
        Me.GroupBox3.TabIndex = 95
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "総生産（実績/計画）"
        '
        'TextBoxProductionTotalPlan
        '
        Me.TextBoxProductionTotalPlan.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxProductionTotalPlan.Location = New System.Drawing.Point(172, 20)
        Me.TextBoxProductionTotalPlan.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProductionTotalPlan.Name = "TextBoxProductionTotalPlan"
        Me.TextBoxProductionTotalPlan.ReadOnly = True
        Me.TextBoxProductionTotalPlan.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxProductionTotalPlan.TabIndex = 92
        Me.TextBoxProductionTotalPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxProductionTotalActual
        '
        Me.TextBoxProductionTotalActual.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxProductionTotalActual.Location = New System.Drawing.Point(33, 20)
        Me.TextBoxProductionTotalActual.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProductionTotalActual.Name = "TextBoxProductionTotalActual"
        Me.TextBoxProductionTotalActual.ReadOnly = True
        Me.TextBoxProductionTotalActual.Size = New System.Drawing.Size(100, 28)
        Me.TextBoxProductionTotalActual.TabIndex = 92
        Me.TextBoxProductionTotalActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(143, 23)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 21)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "/"
        '
        'TextBoxOrder
        '
        Me.TextBoxOrder.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxOrder.Location = New System.Drawing.Point(76, 18)
        Me.TextBoxOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxOrder.Name = "TextBoxOrder"
        Me.TextBoxOrder.ReadOnly = True
        Me.TextBoxOrder.Size = New System.Drawing.Size(227, 28)
        Me.TextBoxOrder.TabIndex = 92
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 21)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 21)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "オーダー"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 545)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(296, 57)
        Me.TextBox1.TabIndex = 1
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(191, 610)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(116, 25)
        Me.Button7.TabIndex = 2
        Me.Button7.Text = "Button2"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(9, 610)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(174, 25)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBoxPresentParts
        '
        Me.PictureBoxPresentParts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxPresentParts.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxPresentParts.Margin = New System.Windows.Forms.Padding(9, 5, 9, 5)
        Me.PictureBoxPresentParts.Name = "PictureBoxPresentParts"
        Me.PictureBoxPresentParts.Size = New System.Drawing.Size(1103, 648)
        Me.PictureBoxPresentParts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPresentParts.TabIndex = 1
        Me.PictureBoxPresentParts.TabStop = False
        '
        'PictureBoxAllParts
        '
        Me.PictureBoxAllParts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxAllParts.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxAllParts.Margin = New System.Windows.Forms.Padding(9, 5, 9, 5)
        Me.PictureBoxAllParts.Name = "PictureBoxAllParts"
        Me.PictureBoxAllParts.Size = New System.Drawing.Size(1103, 648)
        Me.PictureBoxAllParts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxAllParts.TabIndex = 2
        Me.PictureBoxAllParts.TabStop = False
        '
        'PictureBoxBoard
        '
        Me.PictureBoxBoard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxBoard.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxBoard.Margin = New System.Windows.Forms.Padding(9, 5, 9, 5)
        Me.PictureBoxBoard.Name = "PictureBoxBoard"
        Me.PictureBoxBoard.Size = New System.Drawing.Size(1103, 648)
        Me.PictureBoxBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxBoard.TabIndex = 3
        Me.PictureBoxBoard.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(10, 360)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(300, 281)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Orange
        Me.TabPage1.Controls.Add(Me.ButtonOpenPartsImageFile)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.ListBoxPartsImage)
        Me.TabPage1.Controls.Add(Me.PictureBoxPartsImage)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(292, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "部材画像"
        '
        'ButtonOpenPartsImageFile
        '
        Me.ButtonOpenPartsImageFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenPartsImageFile.Location = New System.Drawing.Point(162, 165)
        Me.ButtonOpenPartsImageFile.Name = "ButtonOpenPartsImageFile"
        Me.ButtonOpenPartsImageFile.Size = New System.Drawing.Size(107, 26)
        Me.ButtonOpenPartsImageFile.TabIndex = 82
        Me.ButtonOpenPartsImageFile.Text = "ファイルを開く"
        Me.ButtonOpenPartsImageFile.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "画像リスト"
        '
        'ListBoxPartsImage
        '
        Me.ListBoxPartsImage.FormattingEnabled = True
        Me.ListBoxPartsImage.ItemHeight = 16
        Me.ListBoxPartsImage.Location = New System.Drawing.Point(16, 194)
        Me.ListBoxPartsImage.Name = "ListBoxPartsImage"
        Me.ListBoxPartsImage.Size = New System.Drawing.Size(258, 52)
        Me.ListBoxPartsImage.TabIndex = 0
        '
        'PictureBoxPartsImage
        '
        Me.PictureBoxPartsImage.BackColor = System.Drawing.Color.White
        Me.PictureBoxPartsImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxPartsImage.Location = New System.Drawing.Point(16, 6)
        Me.PictureBoxPartsImage.Name = "PictureBoxPartsImage"
        Me.PictureBoxPartsImage.Size = New System.Drawing.Size(258, 150)
        Me.PictureBoxPartsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPartsImage.TabIndex = 71
        Me.PictureBoxPartsImage.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Peru
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.ListBoxKankotsuFile)
        Me.TabPage3.Controls.Add(Me.ButtonOpenKankotsuFile)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(292, 255)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "カンコツ"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 16)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "カンコツファイルリスト"
        '
        'ListBoxKankotsuFile
        '
        Me.ListBoxKankotsuFile.FormattingEnabled = True
        Me.ListBoxKankotsuFile.ItemHeight = 16
        Me.ListBoxKankotsuFile.Location = New System.Drawing.Point(12, 54)
        Me.ListBoxKankotsuFile.Name = "ListBoxKankotsuFile"
        Me.ListBoxKankotsuFile.Size = New System.Drawing.Size(274, 164)
        Me.ListBoxKankotsuFile.TabIndex = 4
        '
        'ButtonOpenKankotsuFile
        '
        Me.ButtonOpenKankotsuFile.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenKankotsuFile.Location = New System.Drawing.Point(12, 6)
        Me.ButtonOpenKankotsuFile.Name = "ButtonOpenKankotsuFile"
        Me.ButtonOpenKankotsuFile.Size = New System.Drawing.Size(107, 26)
        Me.ButtonOpenKankotsuFile.TabIndex = 2
        Me.ButtonOpenKankotsuFile.Text = "ファイルを開く"
        Me.ButtonOpenKankotsuFile.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Chocolate
        Me.TabPage4.Controls.Add(Me.TextBoxNote)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(292, 255)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "備考"
        '
        'TextBoxNote
        '
        Me.TextBoxNote.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.TextBoxNote.Location = New System.Drawing.Point(4, 7)
        Me.TextBoxNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNote.Multiline = True
        Me.TextBoxNote.Name = "TextBoxNote"
        Me.TextBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxNote.Size = New System.Drawing.Size(281, 248)
        Me.TextBoxNote.TabIndex = 0
        Me.TextBoxNote.Text = "菱テク　太郎"
        '
        'TextBoxTotalUseCount
        '
        Me.TextBoxTotalUseCount.Location = New System.Drawing.Point(91, 113)
        Me.TextBoxTotalUseCount.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxTotalUseCount.Name = "TextBoxTotalUseCount"
        Me.TextBoxTotalUseCount.ReadOnly = True
        Me.TextBoxTotalUseCount.Size = New System.Drawing.Size(106, 23)
        Me.TextBoxTotalUseCount.TabIndex = 103
        '
        'TextBoxModelName
        '
        Me.TextBoxModelName.Location = New System.Drawing.Point(91, 79)
        Me.TextBoxModelName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxModelName.Name = "TextBoxModelName"
        Me.TextBoxModelName.ReadOnly = True
        Me.TextBoxModelName.Size = New System.Drawing.Size(230, 23)
        Me.TextBoxModelName.TabIndex = 103
        '
        'TextBoxPartsName
        '
        Me.TextBoxPartsName.Location = New System.Drawing.Point(91, 48)
        Me.TextBoxPartsName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsName.Name = "TextBoxPartsName"
        Me.TextBoxPartsName.ReadOnly = True
        Me.TextBoxPartsName.Size = New System.Drawing.Size(230, 23)
        Me.TextBoxPartsName.TabIndex = 103
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 82)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "型名"
        '
        'TextBoxPartsCode
        '
        Me.TextBoxPartsCode.Location = New System.Drawing.Point(91, 17)
        Me.TextBoxPartsCode.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsCode.Name = "TextBoxPartsCode"
        Me.TextBoxPartsCode.ReadOnly = True
        Me.TextBoxPartsCode.Size = New System.Drawing.Size(164, 23)
        Me.TextBoxPartsCode.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "品名"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 116)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "総数"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "部材コード"
        '
        'DataGridViewSamePartsCode
        '
        Me.DataGridViewSamePartsCode.AllowUserToAddRows = False
        Me.DataGridViewSamePartsCode.AllowUserToDeleteRows = False
        Me.DataGridViewSamePartsCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSamePartsCode.Location = New System.Drawing.Point(10, 144)
        Me.DataGridViewSamePartsCode.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewSamePartsCode.Name = "DataGridViewSamePartsCode"
        Me.DataGridViewSamePartsCode.ReadOnly = True
        Me.DataGridViewSamePartsCode.RowHeadersVisible = False
        Me.DataGridViewSamePartsCode.RowTemplate.Height = 21
        Me.DataGridViewSamePartsCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewSamePartsCode.Size = New System.Drawing.Size(300, 201)
        Me.DataGridViewSamePartsCode.TabIndex = 0
        '
        'CheckBoxEditStep
        '
        Me.CheckBoxEditStep.AutoSize = True
        Me.CheckBoxEditStep.Location = New System.Drawing.Point(536, 14)
        Me.CheckBoxEditStep.Name = "CheckBoxEditStep"
        Me.CheckBoxEditStep.Size = New System.Drawing.Size(104, 20)
        Me.CheckBoxEditStep.TabIndex = 3
        Me.CheckBoxEditStep.Text = "ステップ変更"
        Me.CheckBoxEditStep.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(4, 17)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "なびデータ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(175, 5)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(106, 34)
        Me.ButtonRegistData.TabIndex = 99
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = False
        '
        'DataGridViewNavidata
        '
        Me.DataGridViewNavidata.AllowUserToAddRows = False
        Me.DataGridViewNavidata.AllowUserToDeleteRows = False
        Me.DataGridViewNavidata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewNavidata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewNavidata.Location = New System.Drawing.Point(4, 47)
        Me.DataGridViewNavidata.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewNavidata.Name = "DataGridViewNavidata"
        Me.DataGridViewNavidata.RowTemplate.Height = 21
        Me.DataGridViewNavidata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridViewNavidata.Size = New System.Drawing.Size(1767, 141)
        Me.DataGridViewNavidata.TabIndex = 0
        '
        'ButtonDownStep
        '
        Me.ButtonDownStep.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDownStep.Location = New System.Drawing.Point(698, 6)
        Me.ButtonDownStep.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDownStep.Name = "ButtonDownStep"
        Me.ButtonDownStep.Size = New System.Drawing.Size(43, 34)
        Me.ButtonDownStep.TabIndex = 2
        Me.ButtonDownStep.Text = "▼"
        Me.ButtonDownStep.UseVisualStyleBackColor = False
        '
        'ButtonUpStep
        '
        Me.ButtonUpStep.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonUpStep.Location = New System.Drawing.Point(647, 6)
        Me.ButtonUpStep.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonUpStep.Name = "ButtonUpStep"
        Me.ButtonUpStep.Size = New System.Drawing.Size(43, 34)
        Me.ButtonUpStep.TabIndex = 2
        Me.ButtonUpStep.Text = "▲"
        Me.ButtonUpStep.UseVisualStyleBackColor = False
        '
        'ButtonOpenEditPartsMaster
        '
        Me.ButtonOpenEditPartsMaster.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOpenEditPartsMaster.Location = New System.Drawing.Point(797, 5)
        Me.ButtonOpenEditPartsMaster.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonOpenEditPartsMaster.Name = "ButtonOpenEditPartsMaster"
        Me.ButtonOpenEditPartsMaster.Size = New System.Drawing.Size(124, 34)
        Me.ButtonOpenEditPartsMaster.TabIndex = 2
        Me.ButtonOpenEditPartsMaster.Text = "部材マスタ編集"
        Me.ButtonOpenEditPartsMaster.UseVisualStyleBackColor = False
        '
        'ButtonEditPartsShape
        '
        Me.ButtonEditPartsShape.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonEditPartsShape.Location = New System.Drawing.Point(929, 5)
        Me.ButtonEditPartsShape.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditPartsShape.Name = "ButtonEditPartsShape"
        Me.ButtonEditPartsShape.Size = New System.Drawing.Size(124, 34)
        Me.ButtonEditPartsShape.TabIndex = 2
        Me.ButtonEditPartsShape.Text = "部材形状編集"
        Me.ButtonEditPartsShape.UseVisualStyleBackColor = False
        '
        'ButtonAddNaviData
        '
        Me.ButtonAddNaviData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAddNaviData.Location = New System.Drawing.Point(312, 5)
        Me.ButtonAddNaviData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddNaviData.Name = "ButtonAddNaviData"
        Me.ButtonAddNaviData.Size = New System.Drawing.Size(94, 34)
        Me.ButtonAddNaviData.TabIndex = 2
        Me.ButtonAddNaviData.Text = "行追加"
        Me.ButtonAddNaviData.UseVisualStyleBackColor = False
        '
        'TimerFlicker
        '
        Me.TimerFlicker.Interval = 500
        '
        'TimerDispWorkTime
        '
        Me.TimerDispWorkTime.Interval = 1000
        '
        'TimerGetOrderActual
        '
        Me.TimerGetOrderActual.Interval = 60000
        '
        'FormEditNavidata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1776, 1015)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEditNavidata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "なびデータ編集画面"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.GroupBoxNaviBoardNo.ResumeLayout(False)
        Me.GroupBoxOperationControl.ResumeLayout(False)
        Me.GroupBoxOrderInfo.ResumeLayout(False)
        Me.GroupBoxOrderInfo.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBoxPresentParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAllParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBoxPartsImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DataGridViewSamePartsCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewNavidata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextBoxBoardHeight As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBoxBoardWidth As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxId As TextBox
    Friend WithEvents TextBoxRevision As TextBox
    Friend WithEvents TextBoxDrawingNo As TextBox
    Friend WithEvents LabelDrawingID As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxShogenhyoFilename As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxNetlistFilename As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridViewNavidata As DataGridView
    Protected WithEvents ButtonRegistData As Button
    Friend WithEvents PictureBoxPresentParts As PictureBox
    Friend WithEvents PictureBoxAllParts As PictureBox
    Friend WithEvents PictureBoxBoard As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents DataGridViewSamePartsCode As DataGridView
    Friend WithEvents TimerFlicker As Timer
    Friend WithEvents TextBoxTotalUseCount As TextBox
    Friend WithEvents TextBoxPartsCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents ListBoxPartsImage As ListBox
    Friend WithEvents PictureBoxPartsImage As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label10 As Label
    Friend WithEvents ListBoxKankotsuFile As ListBox
    Friend WithEvents ButtonOpenKankotsuFile As Button
    Friend WithEvents TabPage4 As TabPage
    Protected WithEvents TextBoxNote As TextBox
    Friend WithEvents GroupBoxOrderInfo As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBoxProductionTotalActual As TextBox
    Friend WithEvents ButtonIncrimentNaviStepBoard As Button
    Friend WithEvents ButtonDecrimentNaviStepBoard As Button
    Friend WithEvents ButtonTerminateProdution As Button
    Friend WithEvents ButtonPauseProduction As Button
    Friend WithEvents TextBoxOrder As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents ButtonOpenPartsImageFile As Button
    Friend WithEvents CheckBoxEditStep As CheckBox
    Friend WithEvents ButtonDownStep As Button
    Friend WithEvents ButtonUpStep As Button
    Friend WithEvents ButtonAddNaviData As Button
    Friend WithEvents TextBoxMaxLot As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextBoxProductionDailyPlan As TextBox
    Friend WithEvents TextBoxProductionDailyActual As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBoxProductionTotalPlan As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBoxOperationControl As GroupBox
    Friend WithEvents GroupBoxNaviBoardNo As GroupBox
    Friend WithEvents LabelProductionLot As Label
    Friend WithEvents ButtonStartProduction As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxModelName As TextBox
    Friend WithEvents TextBoxPartsName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonEditPartsShape As Button
    Friend WithEvents ButtonOpenEditPartsMaster As Button
    Friend WithEvents Label1WorkTime As Label
    Friend WithEvents TimerDispWorkTime As Timer
    Friend WithEvents TimerGetOrderActual As Timer
End Class
