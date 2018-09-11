<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettingSystem
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonUpDateSystemDBCalender = New System.Windows.Forms.Button()
        Me.ButtonGetTimesCalender = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButtonSystemDBCalender = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTimesCalender = New System.Windows.Forms.RadioButton()
        Me.TextDbFolder = New System.Windows.Forms.Label()
        Me.TextBoxSystemFolder = New System.Windows.Forms.TextBox()
        Me.ButtonBrowsFolder = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxAppExecutePath = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CheckBoxDemoFlag = New System.Windows.Forms.CheckBox()
        Me.ButtonCancelSetting = New System.Windows.Forms.Button()
        Me.ButtonUpdateSetting = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxProjectorHeight = New System.Windows.Forms.TextBox()
        Me.TextBoxProjectorWidth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ErrorProviderInput = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 280)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.TextDbFolder)
        Me.TabPage1.Controls.Add(Me.TextBoxSystemFolder)
        Me.TabPage1.Controls.Add(Me.ButtonBrowsFolder)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(649, 254)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "設定"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonUpDateSystemDBCalender)
        Me.GroupBox1.Controls.Add(Me.ButtonGetTimesCalender)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RadioButtonSystemDBCalender)
        Me.GroupBox1.Controls.Add(Me.RadioButtonTimesCalender)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 108)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "菱テクカレンダー"
        '
        'ButtonUpDateSystemDBCalender
        '
        Me.ButtonUpDateSystemDBCalender.Location = New System.Drawing.Point(152, 51)
        Me.ButtonUpDateSystemDBCalender.Name = "ButtonUpDateSystemDBCalender"
        Me.ButtonUpDateSystemDBCalender.Size = New System.Drawing.Size(207, 32)
        Me.ButtonUpDateSystemDBCalender.TabIndex = 3
        Me.ButtonUpDateSystemDBCalender.Text = "Times最新情報にシステムDBを更新"
        Me.ButtonUpDateSystemDBCalender.UseVisualStyleBackColor = True
        '
        'ButtonGetTimesCalender
        '
        Me.ButtonGetTimesCalender.Location = New System.Drawing.Point(25, 51)
        Me.ButtonGetTimesCalender.Name = "ButtonGetTimesCalender"
        Me.ButtonGetTimesCalender.Size = New System.Drawing.Size(121, 32)
        Me.ButtonGetTimesCalender.TabIndex = 3
        Me.ButtonGetTimesCalender.Text = "Times情報取得"
        Me.ButtonGetTimesCalender.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "取得方法"
        '
        'RadioButtonSystemDBCalender
        '
        Me.RadioButtonSystemDBCalender.AutoSize = True
        Me.RadioButtonSystemDBCalender.Location = New System.Drawing.Point(213, 29)
        Me.RadioButtonSystemDBCalender.Name = "RadioButtonSystemDBCalender"
        Me.RadioButtonSystemDBCalender.Size = New System.Drawing.Size(119, 16)
        Me.RadioButtonSystemDBCalender.TabIndex = 0
        Me.RadioButtonSystemDBCalender.TabStop = True
        Me.RadioButtonSystemDBCalender.Text = "システムDBから取得"
        Me.RadioButtonSystemDBCalender.UseVisualStyleBackColor = True
        '
        'RadioButtonTimesCalender
        '
        Me.RadioButtonTimesCalender.AutoSize = True
        Me.RadioButtonTimesCalender.Location = New System.Drawing.Point(103, 29)
        Me.RadioButtonTimesCalender.Name = "RadioButtonTimesCalender"
        Me.RadioButtonTimesCalender.Size = New System.Drawing.Size(96, 16)
        Me.RadioButtonTimesCalender.TabIndex = 0
        Me.RadioButtonTimesCalender.TabStop = True
        Me.RadioButtonTimesCalender.Text = "Timesから取得"
        Me.RadioButtonTimesCalender.UseVisualStyleBackColor = True
        '
        'TextDbFolder
        '
        Me.TextDbFolder.AutoSize = True
        Me.TextDbFolder.Location = New System.Drawing.Point(13, 30)
        Me.TextDbFolder.Name = "TextDbFolder"
        Me.TextDbFolder.Size = New System.Drawing.Size(78, 12)
        Me.TextDbFolder.TabIndex = 3
        Me.TextDbFolder.Text = "システムフォルダ"
        '
        'TextBoxSystemFolder
        '
        Me.TextBoxSystemFolder.Location = New System.Drawing.Point(97, 27)
        Me.TextBoxSystemFolder.Name = "TextBoxSystemFolder"
        Me.TextBoxSystemFolder.Size = New System.Drawing.Size(435, 19)
        Me.TextBoxSystemFolder.TabIndex = 4
        '
        'ButtonBrowsFolder
        '
        Me.ButtonBrowsFolder.Location = New System.Drawing.Point(557, 25)
        Me.ButtonBrowsFolder.Name = "ButtonBrowsFolder"
        Me.ButtonBrowsFolder.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBrowsFolder.TabIndex = 5
        Me.ButtonBrowsFolder.Text = "参照"
        Me.ButtonBrowsFolder.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.TextBoxAppExecutePath)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(649, 254)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "システム情報"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "実行フォルダ"
        '
        'TextBoxAppExecutePath
        '
        Me.TextBoxAppExecutePath.Location = New System.Drawing.Point(127, 24)
        Me.TextBoxAppExecutePath.Name = "TextBoxAppExecutePath"
        Me.TextBoxAppExecutePath.Size = New System.Drawing.Size(516, 19)
        Me.TextBoxAppExecutePath.TabIndex = 8
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CheckBoxDemoFlag)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(649, 254)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Debug"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CheckBoxDemoFlag
        '
        Me.CheckBoxDemoFlag.AutoSize = True
        Me.CheckBoxDemoFlag.Location = New System.Drawing.Point(26, 29)
        Me.CheckBoxDemoFlag.Name = "CheckBoxDemoFlag"
        Me.CheckBoxDemoFlag.Size = New System.Drawing.Size(88, 16)
        Me.CheckBoxDemoFlag.TabIndex = 9
        Me.CheckBoxDemoFlag.Text = "デバッグモード"
        Me.CheckBoxDemoFlag.UseVisualStyleBackColor = True
        '
        'ButtonCancelSetting
        '
        Me.ButtonCancelSetting.Location = New System.Drawing.Point(357, 298)
        Me.ButtonCancelSetting.Name = "ButtonCancelSetting"
        Me.ButtonCancelSetting.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancelSetting.TabIndex = 3
        Me.ButtonCancelSetting.Text = "キャンセル"
        Me.ButtonCancelSetting.UseVisualStyleBackColor = True
        '
        'ButtonUpdateSetting
        '
        Me.ButtonUpdateSetting.Location = New System.Drawing.Point(244, 298)
        Me.ButtonUpdateSetting.Name = "ButtonUpdateSetting"
        Me.ButtonUpdateSetting.Size = New System.Drawing.Size(75, 23)
        Me.ButtonUpdateSetting.TabIndex = 4
        Me.ButtonUpdateSetting.Text = "設定更新"
        Me.ButtonUpdateSetting.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextBoxProjectorWidth)
        Me.GroupBox2.Controls.Add(Me.TextBoxProjectorHeight)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 108)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "プロジェクタ表示サイズ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "縦"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "横"
        '
        'TextBoxProjectorHeight
        '
        Me.TextBoxProjectorHeight.Location = New System.Drawing.Point(51, 29)
        Me.TextBoxProjectorHeight.Name = "TextBoxProjectorHeight"
        Me.TextBoxProjectorHeight.Size = New System.Drawing.Size(104, 19)
        Me.TextBoxProjectorHeight.TabIndex = 4
        '
        'TextBoxProjectorWidth
        '
        Me.TextBoxProjectorWidth.Location = New System.Drawing.Point(51, 58)
        Me.TextBoxProjectorWidth.Name = "TextBoxProjectorWidth"
        Me.TextBoxProjectorWidth.Size = New System.Drawing.Size(104, 19)
        Me.TextBoxProjectorWidth.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "mm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "mm"
        '
        'ErrorProviderInput
        '
        Me.ErrorProviderInput.ContainerControl = Me
        '
        'FormSettingSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 333)
        Me.Controls.Add(Me.ButtonCancelSetting)
        Me.Controls.Add(Me.ButtonUpdateSetting)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormSettingSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "システム設定"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TextDbFolder As System.Windows.Forms.Label
    Friend WithEvents TextBoxSystemFolder As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBrowsFolder As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAppExecutePath As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxDemoFlag As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCancelSetting As System.Windows.Forms.Button
    Friend WithEvents ButtonUpdateSetting As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonUpDateSystemDBCalender As System.Windows.Forms.Button
    Friend WithEvents ButtonGetTimesCalender As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonSystemDBCalender As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTimesCalender As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxProjectorWidth As TextBox
    Friend WithEvents TextBoxProjectorHeight As TextBox
    Friend WithEvents ErrorProviderInput As ErrorProvider
End Class
