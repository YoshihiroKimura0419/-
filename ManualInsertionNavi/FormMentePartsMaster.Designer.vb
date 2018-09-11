<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMentePartsMaster
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
        Me.GroupBoxExtractionConditions = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxKankotsu = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxShapeName = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxDataEnable = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxPartsImage = New System.Windows.Forms.CheckedListBox()
        Me.ComboBoxShapeCategory = New System.Windows.Forms.ComboBox()
        Me.ButtonExtractData = New System.Windows.Forms.Button()
        Me.TextBoxPartsName = New System.Windows.Forms.TextBox()
        Me.TextBoxPartsCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelPartsCode = New System.Windows.Forms.Label()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ButtonDeleteData = New System.Windows.Forms.Button()
        Me.ButtonAddNewData = New System.Windows.Forms.Button()
        Me.ButtonEditOrSelectData = New System.Windows.Forms.Button()
        Me.GroupBoxExtractionConditions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxExtractionConditions
        '
        Me.GroupBoxExtractionConditions.BackColor = System.Drawing.Color.Khaki
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox2)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox4)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox3)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox1)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ComboBoxShapeCategory)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ButtonExtractData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxPartsName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxPartsCode)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.Label2)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.Label1)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelPartsCode)
        Me.GroupBoxExtractionConditions.Location = New System.Drawing.Point(370, 13)
        Me.GroupBoxExtractionConditions.Name = "GroupBoxExtractionConditions"
        Me.GroupBoxExtractionConditions.Size = New System.Drawing.Size(666, 123)
        Me.GroupBoxExtractionConditions.TabIndex = 32
        Me.GroupBoxExtractionConditions.TabStop = False
        Me.GroupBoxExtractionConditions.Text = "抽出条件"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckedListBoxKankotsu)
        Me.GroupBox2.Location = New System.Drawing.Point(362, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(90, 55)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "カンコツファイル"
        '
        'CheckedListBoxKankotsu
        '
        Me.CheckedListBoxKankotsu.FormattingEnabled = True
        Me.CheckedListBoxKankotsu.Items.AddRange(New Object() {"有", "無"})
        Me.CheckedListBoxKankotsu.Location = New System.Drawing.Point(21, 17)
        Me.CheckedListBoxKankotsu.Name = "CheckedListBoxKankotsu"
        Me.CheckedListBoxKankotsu.Size = New System.Drawing.Size(63, 32)
        Me.CheckedListBoxKankotsu.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckedListBoxShapeName)
        Me.GroupBox4.Location = New System.Drawing.Point(145, 62)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(115, 55)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "部品形状名"
        '
        'CheckedListBoxShapeName
        '
        Me.CheckedListBoxShapeName.FormattingEnabled = True
        Me.CheckedListBoxShapeName.Items.AddRange(New Object() {"設定済", "設定未"})
        Me.CheckedListBoxShapeName.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxShapeName.Name = "CheckedListBoxShapeName"
        Me.CheckedListBoxShapeName.Size = New System.Drawing.Size(91, 32)
        Me.CheckedListBoxShapeName.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckedListBoxDataEnable)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(128, 55)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "データ状態"
        '
        'CheckedListBoxDataEnable
        '
        Me.CheckedListBoxDataEnable.FormattingEnabled = True
        Me.CheckedListBoxDataEnable.Items.AddRange(New Object() {"利用中", "利用停止中"})
        Me.CheckedListBoxDataEnable.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxDataEnable.Name = "CheckedListBoxDataEnable"
        Me.CheckedListBoxDataEnable.Size = New System.Drawing.Size(100, 32)
        Me.CheckedListBoxDataEnable.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckedListBoxPartsImage)
        Me.GroupBox1.Location = New System.Drawing.Point(266, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(90, 55)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "部品画像"
        '
        'CheckedListBoxPartsImage
        '
        Me.CheckedListBoxPartsImage.FormattingEnabled = True
        Me.CheckedListBoxPartsImage.Items.AddRange(New Object() {"有", "無"})
        Me.CheckedListBoxPartsImage.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxPartsImage.Name = "CheckedListBoxPartsImage"
        Me.CheckedListBoxPartsImage.Size = New System.Drawing.Size(63, 32)
        Me.CheckedListBoxPartsImage.TabIndex = 0
        '
        'ComboBoxShapeCategory
        '
        Me.ComboBoxShapeCategory.FormattingEnabled = True
        Me.ComboBoxShapeCategory.Location = New System.Drawing.Point(100, 36)
        Me.ComboBoxShapeCategory.Name = "ComboBoxShapeCategory"
        Me.ComboBoxShapeCategory.Size = New System.Drawing.Size(209, 20)
        Me.ComboBoxShapeCategory.TabIndex = 19
        '
        'ButtonExtractData
        '
        Me.ButtonExtractData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonExtractData.Location = New System.Drawing.Point(537, 76)
        Me.ButtonExtractData.Name = "ButtonExtractData"
        Me.ButtonExtractData.Size = New System.Drawing.Size(123, 41)
        Me.ButtonExtractData.TabIndex = 18
        Me.ButtonExtractData.Text = "データ抽出"
        Me.ButtonExtractData.UseVisualStyleBackColor = False
        '
        'TextBoxPartsName
        '
        Me.TextBoxPartsName.Location = New System.Drawing.Point(370, 14)
        Me.TextBoxPartsName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsName.Name = "TextBoxPartsName"
        Me.TextBoxPartsName.Size = New System.Drawing.Size(209, 19)
        Me.TextBoxPartsName.TabIndex = 15
        '
        'TextBoxPartsCode
        '
        Me.TextBoxPartsCode.Location = New System.Drawing.Point(100, 14)
        Me.TextBoxPartsCode.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsCode.Name = "TextBoxPartsCode"
        Me.TextBoxPartsCode.Size = New System.Drawing.Size(209, 19)
        Me.TextBoxPartsCode.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "品名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "部品形状分類"
        '
        'LabelPartsCode
        '
        Me.LabelPartsCode.AutoSize = True
        Me.LabelPartsCode.Location = New System.Drawing.Point(36, 17)
        Me.LabelPartsCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPartsCode.Name = "LabelPartsCode"
        Me.LabelPartsCode.Size = New System.Drawing.Size(56, 12)
        Me.LabelPartsCode.TabIndex = 16
        Me.LabelPartsCode.Text = "部材コード"
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(11, 143)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 21
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1025, 314)
        Me.DataGridView.TabIndex = 31
        '
        'ButtonDeleteData
        '
        Me.ButtonDeleteData.Location = New System.Drawing.Point(250, 13)
        Me.ButtonDeleteData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteData.Name = "ButtonDeleteData"
        Me.ButtonDeleteData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonDeleteData.TabIndex = 30
        Me.ButtonDeleteData.Text = "完全削除"
        Me.ButtonDeleteData.UseVisualStyleBackColor = True
        '
        'ButtonAddNewData
        '
        Me.ButtonAddNewData.Location = New System.Drawing.Point(140, 13)
        Me.ButtonAddNewData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddNewData.Name = "ButtonAddNewData"
        Me.ButtonAddNewData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonAddNewData.TabIndex = 29
        Me.ButtonAddNewData.Text = "新規部材追加"
        Me.ButtonAddNewData.UseVisualStyleBackColor = True
        '
        'ButtonEditOrSelectData
        '
        Me.ButtonEditOrSelectData.Location = New System.Drawing.Point(11, 13)
        Me.ButtonEditOrSelectData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditOrSelectData.Name = "ButtonEditOrSelectData"
        Me.ButtonEditOrSelectData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonEditOrSelectData.TabIndex = 28
        Me.ButtonEditOrSelectData.Text = "データ編集"
        Me.ButtonEditOrSelectData.UseVisualStyleBackColor = True
        '
        'FormMentePartsMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 470)
        Me.Controls.Add(Me.GroupBoxExtractionConditions)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ButtonDeleteData)
        Me.Controls.Add(Me.ButtonAddNewData)
        Me.Controls.Add(Me.ButtonEditOrSelectData)
        Me.Name = "FormMentePartsMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部材マスタメンテナンス"
        Me.GroupBoxExtractionConditions.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxExtractionConditions As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxShapeCategory As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonExtractData As System.Windows.Forms.Button
    Friend WithEvents TextBoxPartsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelPartsCode As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonDeleteData As System.Windows.Forms.Button
    Friend WithEvents ButtonAddNewData As System.Windows.Forms.Button
    Friend WithEvents ButtonEditOrSelectData As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckedListBoxKankotsu As CheckedListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckedListBoxDataEnable As CheckedListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckedListBoxPartsImage As CheckedListBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CheckedListBoxShapeName As CheckedListBox
    Friend WithEvents TextBoxPartsName As TextBox
    Friend WithEvents Label2 As Label
End Class
