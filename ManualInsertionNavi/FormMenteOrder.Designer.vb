<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenteOrder
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
        Me.ButtonEditData = New System.Windows.Forms.Button()
        Me.ButtonDeleteData = New System.Windows.Forms.Button()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxDataEnable = New System.Windows.Forms.CheckedListBox()
        Me.ButtonAddNewData = New System.Windows.Forms.Button()
        Me.ComboBoxBu = New System.Windows.Forms.ComboBox()
        Me.ButtonExtractData = New System.Windows.Forms.Button()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.TextBoxOrder = New System.Windows.Forms.TextBox()
        Me.LabelBoardName = New System.Windows.Forms.Label()
        Me.LabelBu = New System.Windows.Forms.Label()
        Me.LabelOrder = New System.Windows.Forms.Label()
        Me.GroupBoxExtractionConditions = New System.Windows.Forms.GroupBox()
        Me.ErrorProviderInput = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBoxExtractionConditions.SuspendLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonEditData
        '
        Me.ButtonEditData.Location = New System.Drawing.Point(13, 13)
        Me.ButtonEditData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditData.Name = "ButtonEditData"
        Me.ButtonEditData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonEditData.TabIndex = 33
        Me.ButtonEditData.Text = "データ編集"
        Me.ButtonEditData.UseVisualStyleBackColor = True
        '
        'ButtonDeleteData
        '
        Me.ButtonDeleteData.Location = New System.Drawing.Point(252, 13)
        Me.ButtonDeleteData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteData.Name = "ButtonDeleteData"
        Me.ButtonDeleteData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonDeleteData.TabIndex = 35
        Me.ButtonDeleteData.Text = "完全削除"
        Me.ButtonDeleteData.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(13, 119)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 21
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1025, 338)
        Me.DataGridView.TabIndex = 36
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckedListBoxDataEnable)
        Me.GroupBox3.Location = New System.Drawing.Point(331, 14)
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
        'ButtonAddNewData
        '
        Me.ButtonAddNewData.Location = New System.Drawing.Point(142, 13)
        Me.ButtonAddNewData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddNewData.Name = "ButtonAddNewData"
        Me.ButtonAddNewData.Size = New System.Drawing.Size(100, 61)
        Me.ButtonAddNewData.TabIndex = 34
        Me.ButtonAddNewData.Text = "新規追加"
        Me.ButtonAddNewData.UseVisualStyleBackColor = True
        '
        'ComboBoxBu
        '
        Me.ComboBoxBu.FormattingEnabled = True
        Me.ComboBoxBu.Location = New System.Drawing.Point(100, 70)
        Me.ComboBoxBu.Name = "ComboBoxBu"
        Me.ComboBoxBu.Size = New System.Drawing.Size(209, 20)
        Me.ComboBoxBu.TabIndex = 19
        '
        'ButtonExtractData
        '
        Me.ButtonExtractData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonExtractData.Location = New System.Drawing.Point(537, 17)
        Me.ButtonExtractData.Name = "ButtonExtractData"
        Me.ButtonExtractData.Size = New System.Drawing.Size(123, 73)
        Me.ButtonExtractData.TabIndex = 18
        Me.ButtonExtractData.Text = "データ抽出"
        Me.ButtonExtractData.UseVisualStyleBackColor = False
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(100, 42)
        Me.TextBoxBoardName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.Size = New System.Drawing.Size(209, 19)
        Me.TextBoxBoardName.TabIndex = 15
        '
        'TextBoxOrder
        '
        Me.TextBoxOrder.Location = New System.Drawing.Point(100, 14)
        Me.TextBoxOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxOrder.Name = "TextBoxOrder"
        Me.TextBoxOrder.Size = New System.Drawing.Size(144, 19)
        Me.TextBoxOrder.TabIndex = 15
        '
        'LabelBoardName
        '
        Me.LabelBoardName.AutoSize = True
        Me.LabelBoardName.Location = New System.Drawing.Point(51, 45)
        Me.LabelBoardName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelBoardName.Name = "LabelBoardName"
        Me.LabelBoardName.Size = New System.Drawing.Size(41, 12)
        Me.LabelBoardName.TabIndex = 16
        Me.LabelBoardName.Text = "基板名"
        '
        'LabelBu
        '
        Me.LabelBu.AutoSize = True
        Me.LabelBu.Location = New System.Drawing.Point(71, 73)
        Me.LabelBu.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelBu.Name = "LabelBu"
        Me.LabelBu.Size = New System.Drawing.Size(21, 12)
        Me.LabelBu.TabIndex = 16
        Me.LabelBu.Text = "BU"
        '
        'LabelOrder
        '
        Me.LabelOrder.AutoSize = True
        Me.LabelOrder.Location = New System.Drawing.Point(49, 17)
        Me.LabelOrder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelOrder.Name = "LabelOrder"
        Me.LabelOrder.Size = New System.Drawing.Size(43, 12)
        Me.LabelOrder.TabIndex = 16
        Me.LabelOrder.Text = "オーダー"
        '
        'GroupBoxExtractionConditions
        '
        Me.GroupBoxExtractionConditions.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox3)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ComboBoxBu)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ButtonExtractData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxBoardName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxOrder)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelBoardName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelBu)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelOrder)
        Me.GroupBoxExtractionConditions.Location = New System.Drawing.Point(372, 13)
        Me.GroupBoxExtractionConditions.Name = "GroupBoxExtractionConditions"
        Me.GroupBoxExtractionConditions.Size = New System.Drawing.Size(666, 99)
        Me.GroupBoxExtractionConditions.TabIndex = 37
        Me.GroupBoxExtractionConditions.TabStop = False
        Me.GroupBoxExtractionConditions.Text = "抽出条件"
        '
        'ErrorProviderInput
        '
        Me.ErrorProviderInput.ContainerControl = Me
        '
        'FormMenteOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 470)
        Me.Controls.Add(Me.ButtonEditData)
        Me.Controls.Add(Me.ButtonDeleteData)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ButtonAddNewData)
        Me.Controls.Add(Me.GroupBoxExtractionConditions)
        Me.Name = "FormMenteOrder"
        Me.Text = "オーダー管理"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.PerformLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonEditData As Button
    Friend WithEvents ButtonDeleteData As Button
    Friend WithEvents DataGridView As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckedListBoxDataEnable As CheckedListBox
    Friend WithEvents ButtonAddNewData As Button
    Friend WithEvents ComboBoxBu As ComboBox
    Friend WithEvents ButtonExtractData As Button
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents TextBoxOrder As TextBox
    Friend WithEvents LabelBoardName As Label
    Friend WithEvents LabelBu As Label
    Friend WithEvents LabelOrder As Label
    Friend WithEvents GroupBoxExtractionConditions As GroupBox
    Friend WithEvents ErrorProviderInput As ErrorProvider
End Class
