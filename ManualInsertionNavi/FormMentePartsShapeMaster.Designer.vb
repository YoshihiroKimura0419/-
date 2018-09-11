<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMentePartsShapeMaster
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
        Me.ComboBoxShapeCategory = New System.Windows.Forms.ComboBox()
        Me.ButtonExtractData = New System.Windows.Forms.Button()
        Me.CheckBoxIncludeDisableData = New System.Windows.Forms.CheckBox()
        Me.TextBoxPartsShapeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ButtonDeleteData = New System.Windows.Forms.Button()
        Me.ButtonAddNewData = New System.Windows.Forms.Button()
        Me.ButtonEditData = New System.Windows.Forms.Button()
        Me.CheckBoxNoCommitData = New System.Windows.Forms.CheckBox()
        Me.GroupBoxExtractionConditions.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxExtractionConditions
        '
        Me.GroupBoxExtractionConditions.BackColor = System.Drawing.Color.LightGreen
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ComboBoxShapeCategory)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ButtonExtractData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.CheckBoxNoCommitData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.CheckBoxIncludeDisableData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxPartsShapeName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.Label1)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelUserName)
        Me.GroupBoxExtractionConditions.Location = New System.Drawing.Point(395, 13)
        Me.GroupBoxExtractionConditions.Name = "GroupBoxExtractionConditions"
        Me.GroupBoxExtractionConditions.Size = New System.Drawing.Size(644, 61)
        Me.GroupBoxExtractionConditions.TabIndex = 27
        Me.GroupBoxExtractionConditions.TabStop = False
        Me.GroupBoxExtractionConditions.Text = "抽出条件"
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
        Me.ButtonExtractData.Location = New System.Drawing.Point(500, 14)
        Me.ButtonExtractData.Name = "ButtonExtractData"
        Me.ButtonExtractData.Size = New System.Drawing.Size(123, 41)
        Me.ButtonExtractData.TabIndex = 18
        Me.ButtonExtractData.Text = "データ抽出"
        Me.ButtonExtractData.UseVisualStyleBackColor = False
        '
        'CheckBoxIncludeDisableData
        '
        Me.CheckBoxIncludeDisableData.AutoSize = True
        Me.CheckBoxIncludeDisableData.Location = New System.Drawing.Point(352, 18)
        Me.CheckBoxIncludeDisableData.Name = "CheckBoxIncludeDisableData"
        Me.CheckBoxIncludeDisableData.Size = New System.Drawing.Size(115, 16)
        Me.CheckBoxIncludeDisableData.TabIndex = 17
        Me.CheckBoxIncludeDisableData.Text = "利用停止中も含む"
        Me.CheckBoxIncludeDisableData.UseVisualStyleBackColor = True
        '
        'TextBoxPartsShapeName
        '
        Me.TextBoxPartsShapeName.Location = New System.Drawing.Point(100, 14)
        Me.TextBoxPartsShapeName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPartsShapeName.Name = "TextBoxPartsShapeName"
        Me.TextBoxPartsShapeName.Size = New System.Drawing.Size(209, 19)
        Me.TextBoxPartsShapeName.TabIndex = 15
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
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.Location = New System.Drawing.Point(15, 17)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(77, 12)
        Me.LabelUserName.TabIndex = 16
        Me.LabelUserName.Text = "部品形状名称"
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(11, 81)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 21
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1025, 376)
        Me.DataGridView.TabIndex = 26
        '
        'ButtonDeleteData
        '
        Me.ButtonDeleteData.Location = New System.Drawing.Point(250, 13)
        Me.ButtonDeleteData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteData.Name = "ButtonDeleteData"
        Me.ButtonDeleteData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonDeleteData.TabIndex = 25
        Me.ButtonDeleteData.Text = "完全削除"
        Me.ButtonDeleteData.UseVisualStyleBackColor = True
        '
        'ButtonAddNewData
        '
        Me.ButtonAddNewData.Location = New System.Drawing.Point(140, 13)
        Me.ButtonAddNewData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddNewData.Name = "ButtonAddNewData"
        Me.ButtonAddNewData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonAddNewData.TabIndex = 24
        Me.ButtonAddNewData.Text = "新規項目追加"
        Me.ButtonAddNewData.UseVisualStyleBackColor = True
        '
        'ButtonEditData
        '
        Me.ButtonEditData.Location = New System.Drawing.Point(11, 13)
        Me.ButtonEditData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditData.Name = "ButtonEditData"
        Me.ButtonEditData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonEditData.TabIndex = 23
        Me.ButtonEditData.Text = "データ編集"
        Me.ButtonEditData.UseVisualStyleBackColor = True
        '
        'CheckBoxNoCommitData
        '
        Me.CheckBoxNoCommitData.AutoSize = True
        Me.CheckBoxNoCommitData.Location = New System.Drawing.Point(352, 38)
        Me.CheckBoxNoCommitData.Name = "CheckBoxNoCommitData"
        Me.CheckBoxNoCommitData.Size = New System.Drawing.Size(121, 16)
        Me.CheckBoxNoCommitData.TabIndex = 17
        Me.CheckBoxNoCommitData.Text = "データ整備未完のみ"
        Me.CheckBoxNoCommitData.UseVisualStyleBackColor = True
        '
        'FormMentePartsShapeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 470)
        Me.Controls.Add(Me.GroupBoxExtractionConditions)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ButtonDeleteData)
        Me.Controls.Add(Me.ButtonAddNewData)
        Me.Controls.Add(Me.ButtonEditData)
        Me.Name = "FormMentePartsShapeMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品形状マスタメンテナンス"
        Me.GroupBoxExtractionConditions.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxExtractionConditions As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonExtractData As System.Windows.Forms.Button
    Friend WithEvents CheckBoxIncludeDisableData As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxPartsShapeName As System.Windows.Forms.TextBox
    Friend WithEvents LabelUserName As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonDeleteData As System.Windows.Forms.Button
    Friend WithEvents ButtonAddNewData As System.Windows.Forms.Button
    Friend WithEvents ButtonEditData As System.Windows.Forms.Button
    Friend WithEvents ComboBoxShapeCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxNoCommitData As CheckBox
End Class
