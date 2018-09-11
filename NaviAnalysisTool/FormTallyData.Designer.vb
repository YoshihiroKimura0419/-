<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTallyData
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DataGridViewTalliyData = New System.Windows.Forms.DataGridView()
        Me.ButtonTallyData = New System.Windows.Forms.Button()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxOrder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxWokerName = New System.Windows.Forms.ComboBox()
        Me.DateTimePickerStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxBuSelect = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonWorkTime = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPlanAcutual = New System.Windows.Forms.RadioButton()
        Me.DateTimePickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonOutputExcel = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridViewTalliyData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(747, 551)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DataGridViewTalliyData)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ButtonOutputExcel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Chart1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1264, 557)
        Me.SplitContainer2.SplitterDistance = 507
        Me.SplitContainer2.TabIndex = 0
        '
        'DataGridViewTalliyData
        '
        Me.DataGridViewTalliyData.AllowUserToAddRows = False
        Me.DataGridViewTalliyData.AllowUserToDeleteRows = False
        Me.DataGridViewTalliyData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridViewTalliyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTalliyData.Location = New System.Drawing.Point(0, 32)
        Me.DataGridViewTalliyData.Name = "DataGridViewTalliyData"
        Me.DataGridViewTalliyData.ReadOnly = True
        Me.DataGridViewTalliyData.RowHeadersVisible = False
        Me.DataGridViewTalliyData.RowTemplate.Height = 21
        Me.DataGridViewTalliyData.Size = New System.Drawing.Size(507, 525)
        Me.DataGridViewTalliyData.TabIndex = 0
        '
        'ButtonTallyData
        '
        Me.ButtonTallyData.Location = New System.Drawing.Point(822, 18)
        Me.ButtonTallyData.Name = "ButtonTallyData"
        Me.ButtonTallyData.Size = New System.Drawing.Size(138, 42)
        Me.ButtonTallyData.TabIndex = 3
        Me.ButtonTallyData.Text = "データ集計"
        Me.ButtonTallyData.UseVisualStyleBackColor = True
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(510, 29)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.Size = New System.Drawing.Size(169, 19)
        Me.TextBoxBoardName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(451, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "作業者名"
        '
        'TextBoxOrder
        '
        Me.TextBoxOrder.Location = New System.Drawing.Point(246, 52)
        Me.TextBoxOrder.Name = "TextBoxOrder"
        Me.TextBoxOrder.Size = New System.Drawing.Size(169, 19)
        Me.TextBoxOrder.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(463, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "基板名"
        '
        'ComboBoxWokerName
        '
        Me.ComboBoxWokerName.FormattingEnabled = True
        Me.ComboBoxWokerName.Location = New System.Drawing.Point(510, 51)
        Me.ComboBoxWokerName.Name = "ComboBoxWokerName"
        Me.ComboBoxWokerName.Size = New System.Drawing.Size(169, 20)
        Me.ComboBoxWokerName.TabIndex = 1
        '
        'DateTimePickerStart
        '
        Me.DateTimePickerStart.Location = New System.Drawing.Point(47, 9)
        Me.DateTimePickerStart.Name = "DateTimePickerStart"
        Me.DateTimePickerStart.Size = New System.Drawing.Size(109, 19)
        Me.DateTimePickerStart.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(161, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "～"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "期間"
        '
        'ComboBoxBuSelect
        '
        Me.ComboBoxBuSelect.FormattingEnabled = True
        Me.ComboBoxBuSelect.Location = New System.Drawing.Point(246, 29)
        Me.ComboBoxBuSelect.Name = "ComboBoxBuSelect"
        Me.ComboBoxBuSelect.Size = New System.Drawing.Size(169, 20)
        Me.ComboBoxBuSelect.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(197, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "オーダー"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "BU"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkOrange
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.ButtonTallyData)
        Me.GroupBox1.Controls.Add(Me.TextBoxBoardName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBoxOrder)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBoxWokerName)
        Me.GroupBox1.Controls.Add(Me.ComboBoxBuSelect)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1250, 83)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "条件設定"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButtonWorkTime)
        Me.GroupBox2.Controls.Add(Me.RadioButtonPlanAcutual)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 59)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "集計内容"
        '
        'RadioButtonWorkTime
        '
        Me.RadioButtonWorkTime.AutoSize = True
        Me.RadioButtonWorkTime.Location = New System.Drawing.Point(26, 37)
        Me.RadioButtonWorkTime.Name = "RadioButtonWorkTime"
        Me.RadioButtonWorkTime.Size = New System.Drawing.Size(71, 16)
        Me.RadioButtonWorkTime.TabIndex = 5
        Me.RadioButtonWorkTime.Text = "作業時間"
        Me.RadioButtonWorkTime.UseVisualStyleBackColor = True
        '
        'RadioButtonPlanAcutual
        '
        Me.RadioButtonPlanAcutual.AutoSize = True
        Me.RadioButtonPlanAcutual.Checked = True
        Me.RadioButtonPlanAcutual.Location = New System.Drawing.Point(26, 18)
        Me.RadioButtonPlanAcutual.Name = "RadioButtonPlanAcutual"
        Me.RadioButtonPlanAcutual.Size = New System.Drawing.Size(77, 16)
        Me.RadioButtonPlanAcutual.TabIndex = 5
        Me.RadioButtonPlanAcutual.TabStop = True
        Me.RadioButtonPlanAcutual.Text = "計画・実績"
        Me.RadioButtonPlanAcutual.UseVisualStyleBackColor = True
        '
        'DateTimePickerEnd
        '
        Me.DateTimePickerEnd.Location = New System.Drawing.Point(184, 9)
        Me.DateTimePickerEnd.Name = "DateTimePickerEnd"
        Me.DateTimePickerEnd.Size = New System.Drawing.Size(109, 19)
        Me.DateTimePickerEnd.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Gray
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Khaki
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePickerEnd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePickerStart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 681)
        Me.SplitContainer1.SplitterDistance = 120
        Me.SplitContainer1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gold
        Me.Label7.Location = New System.Drawing.Point(1, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 26)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "集計データ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonOutputExcel
        '
        Me.ButtonOutputExcel.Location = New System.Drawing.Point(413, 5)
        Me.ButtonOutputExcel.Name = "ButtonOutputExcel"
        Me.ButtonOutputExcel.Size = New System.Drawing.Size(91, 26)
        Me.ButtonOutputExcel.TabIndex = 3
        Me.ButtonOutputExcel.Text = "Excel出力"
        Me.ButtonOutputExcel.UseVisualStyleBackColor = True
        '
        'FormTallyData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormTallyData"
        Me.Text = "FromWorkTime"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridViewTalliyData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DataGridViewTalliyData As DataGridView
    Friend WithEvents ButtonTallyData As Button
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxOrder As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxWokerName As ComboBox
    Friend WithEvents DateTimePickerStart As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxBuSelect As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTimePickerEnd As DateTimePicker
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButtonWorkTime As RadioButton
    Friend WithEvents RadioButtonPlanAcutual As RadioButton
    Friend WithEvents ButtonOutputExcel As Button
    Friend WithEvents Label7 As Label
End Class
