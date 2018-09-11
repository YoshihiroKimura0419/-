<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenteUserMaster
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
        Me.ButtonDeleteData = New System.Windows.Forms.Button()
        Me.ButtonAddNewData = New System.Windows.Forms.Button()
        Me.ButtonEditData = New System.Windows.Forms.Button()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TextBoxExtractUserName = New System.Windows.Forms.TextBox()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.GroupBoxExtractionConditions = New System.Windows.Forms.GroupBox()
        Me.ButtonExtractUserData = New System.Windows.Forms.Button()
        Me.CheckBoxIncludeDisableData = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxExtractionConditions.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonDeleteData
        '
        Me.ButtonDeleteData.Location = New System.Drawing.Point(255, 15)
        Me.ButtonDeleteData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteData.Name = "ButtonDeleteData"
        Me.ButtonDeleteData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonDeleteData.TabIndex = 13
        Me.ButtonDeleteData.Text = "完全削除"
        Me.ButtonDeleteData.UseVisualStyleBackColor = True
        '
        'ButtonAddNewData
        '
        Me.ButtonAddNewData.Location = New System.Drawing.Point(145, 15)
        Me.ButtonAddNewData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddNewData.Name = "ButtonAddNewData"
        Me.ButtonAddNewData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonAddNewData.TabIndex = 12
        Me.ButtonAddNewData.Text = "ユーザー追加"
        Me.ButtonAddNewData.UseVisualStyleBackColor = True
        '
        'ButtonEditData
        '
        Me.ButtonEditData.Location = New System.Drawing.Point(16, 15)
        Me.ButtonEditData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditData.Name = "ButtonEditData"
        Me.ButtonEditData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonEditData.TabIndex = 11
        Me.ButtonEditData.Text = "データ編集"
        Me.ButtonEditData.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(16, 83)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 21
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1112, 461)
        Me.DataGridView.TabIndex = 14
        '
        'TextBoxExtractUserName
        '
        Me.TextBoxExtractUserName.Location = New System.Drawing.Point(83, 22)
        Me.TextBoxExtractUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxExtractUserName.Name = "TextBoxExtractUserName"
        Me.TextBoxExtractUserName.Size = New System.Drawing.Size(209, 22)
        Me.TextBoxExtractUserName.TabIndex = 15
        '
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.Location = New System.Drawing.Point(15, 25)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(37, 15)
        Me.LabelUserName.TabIndex = 16
        Me.LabelUserName.Text = "氏名"
        '
        'GroupBoxExtractionConditions
        '
        Me.GroupBoxExtractionConditions.BackColor = System.Drawing.Color.PaleTurquoise
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ButtonExtractUserData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.CheckBoxIncludeDisableData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxExtractUserName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelUserName)
        Me.GroupBoxExtractionConditions.Location = New System.Drawing.Point(400, 15)
        Me.GroupBoxExtractionConditions.Name = "GroupBoxExtractionConditions"
        Me.GroupBoxExtractionConditions.Size = New System.Drawing.Size(644, 61)
        Me.GroupBoxExtractionConditions.TabIndex = 17
        Me.GroupBoxExtractionConditions.TabStop = False
        Me.GroupBoxExtractionConditions.Text = "抽出条件"
        '
        'ButtonExtractUserData
        '
        Me.ButtonExtractUserData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonExtractUserData.Location = New System.Drawing.Point(500, 14)
        Me.ButtonExtractUserData.Name = "ButtonExtractUserData"
        Me.ButtonExtractUserData.Size = New System.Drawing.Size(123, 41)
        Me.ButtonExtractUserData.TabIndex = 18
        Me.ButtonExtractUserData.Text = "データ抽出"
        Me.ButtonExtractUserData.UseVisualStyleBackColor = False
        '
        'CheckBoxIncludeDisableData
        '
        Me.CheckBoxIncludeDisableData.AutoSize = True
        Me.CheckBoxIncludeDisableData.Location = New System.Drawing.Point(329, 25)
        Me.CheckBoxIncludeDisableData.Name = "CheckBoxIncludeDisableData"
        Me.CheckBoxIncludeDisableData.Size = New System.Drawing.Size(139, 19)
        Me.CheckBoxIncludeDisableData.TabIndex = 17
        Me.CheckBoxIncludeDisableData.Text = "利用停止中も含む"
        Me.CheckBoxIncludeDisableData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(1074, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "社外秘"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormMenteUserMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 557)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBoxExtractionConditions)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ButtonDeleteData)
        Me.Controls.Add(Me.ButtonAddNewData)
        Me.Controls.Add(Me.ButtonEditData)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMenteUserMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ユーザーマスタメンテナンス"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxExtractionConditions.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonDeleteData As System.Windows.Forms.Button
    Friend WithEvents ButtonAddNewData As System.Windows.Forms.Button
    Friend WithEvents ButtonEditData As System.Windows.Forms.Button
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TextBoxExtractUserName As System.Windows.Forms.TextBox
    Friend WithEvents LabelUserName As System.Windows.Forms.Label
    Friend WithEvents GroupBoxExtractionConditions As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxIncludeDisableData As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonExtractUserData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
