<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenteDrawingMaster
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
        Me.ButtonEditData = New System.Windows.Forms.Button()
        Me.ButtonDeleteData = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxBoardImageRegisted = New System.Windows.Forms.CheckedListBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxDataEnable = New System.Windows.Forms.CheckedListBox()
        Me.ButtonAddNewData = New System.Windows.Forms.Button()
        Me.ButtonExtractData = New System.Windows.Forms.Button()
        Me.TextBoxRevision = New System.Windows.Forms.TextBox()
        Me.TextBoxDrawingNo = New System.Windows.Forms.TextBox()
        Me.LabelRevision = New System.Windows.Forms.Label()
        Me.LabelDrawingNo = New System.Windows.Forms.Label()
        Me.GroupBoxExtractionConditions = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxAndOr3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxAndOr2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxAndOr1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxDrawingImageRegisted = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxNetlistRegisted = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxShogenhyoRegisted = New System.Windows.Forms.CheckedListBox()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonOpenNavidataEdit = New System.Windows.Forms.Button()
        Me.ButtonSelectModeOK = New System.Windows.Forms.Button()
        Me.ButtonSelectModeCancel = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxExtractionConditions.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonEditData
        '
        Me.ButtonEditData.Location = New System.Drawing.Point(13, 13)
        Me.ButtonEditData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEditData.Name = "ButtonEditData"
        Me.ButtonEditData.Size = New System.Drawing.Size(100, 34)
        Me.ButtonEditData.TabIndex = 33
        Me.ButtonEditData.Text = "データ編集"
        Me.ButtonEditData.UseVisualStyleBackColor = True
        '
        'ButtonDeleteData
        '
        Me.ButtonDeleteData.Location = New System.Drawing.Point(252, 13)
        Me.ButtonDeleteData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDeleteData.Name = "ButtonDeleteData"
        Me.ButtonDeleteData.Size = New System.Drawing.Size(100, 34)
        Me.ButtonDeleteData.TabIndex = 35
        Me.ButtonDeleteData.Text = "完全削除"
        Me.ButtonDeleteData.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckedListBoxBoardImageRegisted)
        Me.GroupBox2.Location = New System.Drawing.Point(196, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(115, 55)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "基板画像登録"
        '
        'CheckedListBoxBoardImageRegisted
        '
        Me.CheckedListBoxBoardImageRegisted.FormattingEnabled = True
        Me.CheckedListBoxBoardImageRegisted.Items.AddRange(New Object() {"登録済", "登録未"})
        Me.CheckedListBoxBoardImageRegisted.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxBoardImageRegisted.Name = "CheckedListBoxBoardImageRegisted"
        Me.CheckedListBoxBoardImageRegisted.Size = New System.Drawing.Size(91, 32)
        Me.CheckedListBoxBoardImageRegisted.TabIndex = 0
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(13, 195)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowTemplate.Height = 21
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1056, 262)
        Me.DataGridView.TabIndex = 36
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckedListBoxDataEnable)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 55)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ状態"
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
        Me.ButtonAddNewData.Size = New System.Drawing.Size(100, 34)
        Me.ButtonAddNewData.TabIndex = 34
        Me.ButtonAddNewData.Text = "新規図面登録"
        Me.ButtonAddNewData.UseVisualStyleBackColor = True
        '
        'ButtonExtractData
        '
        Me.ButtonExtractData.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonExtractData.Location = New System.Drawing.Point(928, 22)
        Me.ButtonExtractData.Name = "ButtonExtractData"
        Me.ButtonExtractData.Size = New System.Drawing.Size(123, 101)
        Me.ButtonExtractData.TabIndex = 18
        Me.ButtonExtractData.Text = "データ抽出"
        Me.ButtonExtractData.UseVisualStyleBackColor = False
        '
        'TextBoxRevision
        '
        Me.TextBoxRevision.Location = New System.Drawing.Point(238, 19)
        Me.TextBoxRevision.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRevision.Name = "TextBoxRevision"
        Me.TextBoxRevision.Size = New System.Drawing.Size(60, 19)
        Me.TextBoxRevision.TabIndex = 15
        '
        'TextBoxDrawingNo
        '
        Me.TextBoxDrawingNo.Location = New System.Drawing.Point(77, 19)
        Me.TextBoxDrawingNo.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDrawingNo.Name = "TextBoxDrawingNo"
        Me.TextBoxDrawingNo.Size = New System.Drawing.Size(117, 19)
        Me.TextBoxDrawingNo.TabIndex = 15
        '
        'LabelRevision
        '
        Me.LabelRevision.AutoSize = True
        Me.LabelRevision.Location = New System.Drawing.Point(201, 22)
        Me.LabelRevision.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRevision.Name = "LabelRevision"
        Me.LabelRevision.Size = New System.Drawing.Size(29, 12)
        Me.LabelRevision.TabIndex = 16
        Me.LabelRevision.Text = "副番"
        '
        'LabelDrawingNo
        '
        Me.LabelDrawingNo.AutoSize = True
        Me.LabelDrawingNo.Location = New System.Drawing.Point(13, 22)
        Me.LabelDrawingNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDrawingNo.Name = "LabelDrawingNo"
        Me.LabelDrawingNo.Size = New System.Drawing.Size(53, 12)
        Me.LabelDrawingNo.TabIndex = 16
        Me.LabelDrawingNo.Text = "図面番号"
        '
        'GroupBoxExtractionConditions
        '
        Me.GroupBoxExtractionConditions.BackColor = System.Drawing.Color.DarkKhaki
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox6)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.GroupBox1)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.ButtonExtractData)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxRevision)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxBoardName)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.TextBoxDrawingNo)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.Label1)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelRevision)
        Me.GroupBoxExtractionConditions.Controls.Add(Me.LabelDrawingNo)
        Me.GroupBoxExtractionConditions.Location = New System.Drawing.Point(12, 54)
        Me.GroupBoxExtractionConditions.Name = "GroupBoxExtractionConditions"
        Me.GroupBoxExtractionConditions.Size = New System.Drawing.Size(1057, 134)
        Me.GroupBoxExtractionConditions.TabIndex = 37
        Me.GroupBoxExtractionConditions.TabStop = False
        Me.GroupBoxExtractionConditions.Text = "抽出条件"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboBoxAndOr3)
        Me.GroupBox6.Controls.Add(Me.ComboBoxAndOr2)
        Me.GroupBox6.Controls.Add(Me.ComboBoxAndOr1)
        Me.GroupBox6.Controls.Add(Me.GroupBox5)
        Me.GroupBox6.Controls.Add(Me.GroupBox4)
        Me.GroupBox6.Controls.Add(Me.GroupBox2)
        Me.GroupBox6.Controls.Add(Me.GroupBox3)
        Me.GroupBox6.Location = New System.Drawing.Point(140, 45)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(700, 78)
        Me.GroupBox6.TabIndex = 21
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ファイル登録状態"
        '
        'ComboBoxAndOr3
        '
        Me.ComboBoxAndOr3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAndOr3.FormattingEnabled = True
        Me.ComboBoxAndOr3.Items.AddRange(New Object() {"AND", "OR"})
        Me.ComboBoxAndOr3.Location = New System.Drawing.Point(507, 36)
        Me.ComboBoxAndOr3.Name = "ComboBoxAndOr3"
        Me.ComboBoxAndOr3.Size = New System.Drawing.Size(63, 20)
        Me.ComboBoxAndOr3.TabIndex = 21
        '
        'ComboBoxAndOr2
        '
        Me.ComboBoxAndOr2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAndOr2.FormattingEnabled = True
        Me.ComboBoxAndOr2.Items.AddRange(New Object() {"AND", "OR"})
        Me.ComboBoxAndOr2.Location = New System.Drawing.Point(317, 36)
        Me.ComboBoxAndOr2.Name = "ComboBoxAndOr2"
        Me.ComboBoxAndOr2.Size = New System.Drawing.Size(63, 20)
        Me.ComboBoxAndOr2.TabIndex = 21
        '
        'ComboBoxAndOr1
        '
        Me.ComboBoxAndOr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAndOr1.FormattingEnabled = True
        Me.ComboBoxAndOr1.Items.AddRange(New Object() {"AND", "OR"})
        Me.ComboBoxAndOr1.Location = New System.Drawing.Point(127, 36)
        Me.ComboBoxAndOr1.Name = "ComboBoxAndOr1"
        Me.ComboBoxAndOr1.Size = New System.Drawing.Size(63, 20)
        Me.ComboBoxAndOr1.TabIndex = 21
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CheckedListBoxDrawingImageRegisted)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(115, 55)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "図面画像登録"
        '
        'CheckedListBoxDrawingImageRegisted
        '
        Me.CheckedListBoxDrawingImageRegisted.FormattingEnabled = True
        Me.CheckedListBoxDrawingImageRegisted.Items.AddRange(New Object() {"登録済", "登録未"})
        Me.CheckedListBoxDrawingImageRegisted.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxDrawingImageRegisted.Name = "CheckedListBoxDrawingImageRegisted"
        Me.CheckedListBoxDrawingImageRegisted.Size = New System.Drawing.Size(91, 32)
        Me.CheckedListBoxDrawingImageRegisted.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckedListBoxNetlistRegisted)
        Me.GroupBox4.Location = New System.Drawing.Point(576, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(115, 55)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Netリスト登録"
        '
        'CheckedListBoxNetlistRegisted
        '
        Me.CheckedListBoxNetlistRegisted.FormattingEnabled = True
        Me.CheckedListBoxNetlistRegisted.Items.AddRange(New Object() {"登録済", "登録未"})
        Me.CheckedListBoxNetlistRegisted.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxNetlistRegisted.Name = "CheckedListBoxNetlistRegisted"
        Me.CheckedListBoxNetlistRegisted.Size = New System.Drawing.Size(91, 32)
        Me.CheckedListBoxNetlistRegisted.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckedListBoxShogenhyoRegisted)
        Me.GroupBox3.Location = New System.Drawing.Point(386, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(115, 55)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "諸元表登録"
        '
        'CheckedListBoxShogenhyoRegisted
        '
        Me.CheckedListBoxShogenhyoRegisted.FormattingEnabled = True
        Me.CheckedListBoxShogenhyoRegisted.Items.AddRange(New Object() {"登録済", "登録未"})
        Me.CheckedListBoxShogenhyoRegisted.Location = New System.Drawing.Point(18, 18)
        Me.CheckedListBoxShogenhyoRegisted.Name = "CheckedListBoxShogenhyoRegisted"
        Me.CheckedListBoxShogenhyoRegisted.Size = New System.Drawing.Size(91, 32)
        Me.CheckedListBoxShogenhyoRegisted.TabIndex = 0
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(395, 19)
        Me.TextBoxBoardName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.Size = New System.Drawing.Size(206, 19)
        Me.TextBoxBoardName.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(331, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "基板名称"
        '
        'ButtonOpenNavidataEdit
        '
        Me.ButtonOpenNavidataEdit.Location = New System.Drawing.Point(392, 13)
        Me.ButtonOpenNavidataEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonOpenNavidataEdit.Name = "ButtonOpenNavidataEdit"
        Me.ButtonOpenNavidataEdit.Size = New System.Drawing.Size(117, 34)
        Me.ButtonOpenNavidataEdit.TabIndex = 34
        Me.ButtonOpenNavidataEdit.Text = "なびデータ作成/編集"
        Me.ButtonOpenNavidataEdit.UseVisualStyleBackColor = True
        '
        'ButtonSelectModeOK
        '
        Me.ButtonSelectModeOK.Location = New System.Drawing.Point(589, 13)
        Me.ButtonSelectModeOK.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSelectModeOK.Name = "ButtonSelectModeOK"
        Me.ButtonSelectModeOK.Size = New System.Drawing.Size(117, 34)
        Me.ButtonSelectModeOK.TabIndex = 34
        Me.ButtonSelectModeOK.Text = "決定"
        Me.ButtonSelectModeOK.UseVisualStyleBackColor = True
        '
        'ButtonSelectModeCancel
        '
        Me.ButtonSelectModeCancel.Location = New System.Drawing.Point(726, 13)
        Me.ButtonSelectModeCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSelectModeCancel.Name = "ButtonSelectModeCancel"
        Me.ButtonSelectModeCancel.Size = New System.Drawing.Size(117, 34)
        Me.ButtonSelectModeCancel.TabIndex = 34
        Me.ButtonSelectModeCancel.Text = "キャンセル"
        Me.ButtonSelectModeCancel.UseVisualStyleBackColor = True
        '
        'FormMenteDrawingMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 472)
        Me.Controls.Add(Me.ButtonEditData)
        Me.Controls.Add(Me.ButtonDeleteData)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ButtonSelectModeCancel)
        Me.Controls.Add(Me.ButtonSelectModeOK)
        Me.Controls.Add(Me.ButtonOpenNavidataEdit)
        Me.Controls.Add(Me.ButtonAddNewData)
        Me.Controls.Add(Me.GroupBoxExtractionConditions)
        Me.Name = "FormMenteDrawingMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "図面マスタメンテナンス"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.ResumeLayout(False)
        Me.GroupBoxExtractionConditions.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonEditData As Button
    Friend WithEvents ButtonDeleteData As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckedListBoxBoardImageRegisted As CheckedListBox
    Friend WithEvents DataGridView As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckedListBoxDataEnable As CheckedListBox
    Friend WithEvents ButtonAddNewData As Button
    Friend WithEvents ButtonExtractData As Button
    Friend WithEvents TextBoxRevision As TextBox
    Friend WithEvents TextBoxDrawingNo As TextBox
    Friend WithEvents LabelRevision As Label
    Friend WithEvents LabelDrawingNo As Label
    Friend WithEvents GroupBoxExtractionConditions As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CheckedListBoxNetlistRegisted As CheckedListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckedListBoxShogenhyoRegisted As CheckedListBox
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CheckedListBoxDrawingImageRegisted As CheckedListBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ComboBoxAndOr3 As ComboBox
    Friend WithEvents ComboBoxAndOr2 As ComboBox
    Friend WithEvents ComboBoxAndOr1 As ComboBox
    Friend WithEvents ButtonOpenNavidataEdit As Button
    Friend WithEvents ButtonSelectModeOK As Button
    Friend WithEvents ButtonSelectModeCancel As Button
End Class
