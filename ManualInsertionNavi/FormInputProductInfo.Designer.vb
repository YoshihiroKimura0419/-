<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputProductInfo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxOrder = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxQuantityPlanDaily = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ErrorProviderInput = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CheckBoxUseDisableData = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxQuantityPlanTotal = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBoxQuantityActualTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelPrivateActual = New System.Windows.Forms.Label()
        Me.LabelPrivateActualUnit = New System.Windows.Forms.Label()
        Me.TextBoxQuantityActualDaily = New System.Windows.Forms.TextBox()
        Me.LabelInputMessege = New System.Windows.Forms.Label()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(657, 43)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "生産情報を入力してください。"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "基板名称"
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Location = New System.Drawing.Point(145, 92)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.ReadOnly = True
        Me.TextBoxBoardName.Size = New System.Drawing.Size(314, 28)
        Me.TextBoxBoardName.TabIndex = 2
        Me.TextBoxBoardName.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "オーダー"
        '
        'TextBoxOrder
        '
        Me.TextBoxOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBoxOrder.Location = New System.Drawing.Point(145, 43)
        Me.TextBoxOrder.Name = "TextBoxOrder"
        Me.TextBoxOrder.Size = New System.Drawing.Size(314, 28)
        Me.TextBoxOrder.TabIndex = 1
        Me.TextBoxOrder.Text = "ab1234567890-1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "生産枚数"
        '
        'TextBoxQuantityPlanDaily
        '
        Me.TextBoxQuantityPlanDaily.Location = New System.Drawing.Point(145, 40)
        Me.TextBoxQuantityPlanDaily.Name = "TextBoxQuantityPlanDaily"
        Me.TextBoxQuantityPlanDaily.Size = New System.Drawing.Size(117, 28)
        Me.TextBoxQuantityPlanDaily.TabIndex = 2
        Me.TextBoxQuantityPlanDaily.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "枚"
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(137, 384)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(133, 37)
        Me.ButtonOK.TabIndex = 3
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.CausesValidation = False
        Me.ButtonCancel.Location = New System.Drawing.Point(354, 384)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(133, 37)
        Me.ButtonCancel.TabIndex = 4
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ErrorProviderInput
        '
        Me.ErrorProviderInput.ContainerControl = Me
        '
        'CheckBoxUseDisableData
        '
        Me.CheckBoxUseDisableData.AutoSize = True
        Me.CheckBoxUseDisableData.Location = New System.Drawing.Point(465, 95)
        Me.CheckBoxUseDisableData.Name = "CheckBoxUseDisableData"
        Me.CheckBoxUseDisableData.Size = New System.Drawing.Size(141, 25)
        Me.CheckBoxUseDisableData.TabIndex = 6
        Me.CheckBoxUseDisableData.TabStop = False
        Me.CheckBoxUseDisableData.Text = "旧データ使用"
        Me.CheckBoxUseDisableData.UseVisualStyleBackColor = True
        Me.CheckBoxUseDisableData.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 21)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "生産枚数"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 21)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "枚"
        '
        'TextBoxQuantityPlanTotal
        '
        Me.TextBoxQuantityPlanTotal.Location = New System.Drawing.Point(145, 139)
        Me.TextBoxQuantityPlanTotal.Name = "TextBoxQuantityPlanTotal"
        Me.TextBoxQuantityPlanTotal.ReadOnly = True
        Me.TextBoxQuantityPlanTotal.Size = New System.Drawing.Size(117, 28)
        Me.TextBoxQuantityPlanTotal.TabIndex = 3
        Me.TextBoxQuantityPlanTotal.TabStop = False
        Me.TextBoxQuantityPlanTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.CheckBoxUseDisableData)
        Me.Panel1.Controls.Add(Me.TextBoxQuantityActualTotal)
        Me.Panel1.Controls.Add(Me.TextBoxQuantityPlanTotal)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextBoxOrder)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxBoardName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(628, 182)
        Me.Panel1.TabIndex = 7
        '
        'TextBoxQuantityActualTotal
        '
        Me.TextBoxQuantityActualTotal.Location = New System.Drawing.Point(407, 139)
        Me.TextBoxQuantityActualTotal.Name = "TextBoxQuantityActualTotal"
        Me.TextBoxQuantityActualTotal.ReadOnly = True
        Me.TextBoxQuantityActualTotal.Size = New System.Drawing.Size(117, 28)
        Me.TextBoxQuantityActualTotal.TabIndex = 3
        Me.TextBoxQuantityActualTotal.TabStop = False
        Me.TextBoxQuantityActualTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(526, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 21)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "枚"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(328, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 21)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "実績数"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 21)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "オーダー情報"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Khaki
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.LabelPrivateActual)
        Me.Panel2.Controls.Add(Me.LabelPrivateActualUnit)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TextBoxQuantityActualDaily)
        Me.Panel2.Controls.Add(Me.TextBoxQuantityPlanDaily)
        Me.Panel2.Location = New System.Drawing.Point(12, 249)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(628, 79)
        Me.Panel2.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 21)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "本日の生産予定"
        '
        'LabelPrivateActual
        '
        Me.LabelPrivateActual.AutoSize = True
        Me.LabelPrivateActual.Location = New System.Drawing.Point(328, 43)
        Me.LabelPrivateActual.Name = "LabelPrivateActual"
        Me.LabelPrivateActual.Size = New System.Drawing.Size(73, 21)
        Me.LabelPrivateActual.TabIndex = 1
        Me.LabelPrivateActual.Text = "実績数"
        '
        'LabelPrivateActualUnit
        '
        Me.LabelPrivateActualUnit.AutoSize = True
        Me.LabelPrivateActualUnit.Location = New System.Drawing.Point(530, 43)
        Me.LabelPrivateActualUnit.Name = "LabelPrivateActualUnit"
        Me.LabelPrivateActualUnit.Size = New System.Drawing.Size(31, 21)
        Me.LabelPrivateActualUnit.TabIndex = 1
        Me.LabelPrivateActualUnit.Text = "枚"
        '
        'TextBoxQuantityActualDaily
        '
        Me.TextBoxQuantityActualDaily.Location = New System.Drawing.Point(407, 40)
        Me.TextBoxQuantityActualDaily.Name = "TextBoxQuantityActualDaily"
        Me.TextBoxQuantityActualDaily.ReadOnly = True
        Me.TextBoxQuantityActualDaily.Size = New System.Drawing.Size(117, 28)
        Me.TextBoxQuantityActualDaily.TabIndex = 3
        Me.TextBoxQuantityActualDaily.TabStop = False
        Me.TextBoxQuantityActualDaily.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelInputMessege
        '
        Me.LabelInputMessege.AutoSize = True
        Me.LabelInputMessege.ForeColor = System.Drawing.Color.Red
        Me.LabelInputMessege.Location = New System.Drawing.Point(18, 342)
        Me.LabelInputMessege.Name = "LabelInputMessege"
        Me.LabelInputMessege.Size = New System.Drawing.Size(151, 21)
        Me.LabelInputMessege.TabIndex = 1
        Me.LabelInputMessege.Text = "入力メッセージ欄"
        '
        'FormInputProductInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 435)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelInputMessege)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "FormInputProductInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "制作情報入力画面"
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxBoardName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxOrder As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxQuantityPlanDaily As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ErrorProviderInput As ErrorProvider
    Friend WithEvents CheckBoxUseDisableData As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxQuantityPlanTotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents LabelPrivateActual As Label
    Friend WithEvents LabelPrivateActualUnit As Label
    Friend WithEvents TextBoxQuantityActualDaily As TextBox
    Friend WithEvents TextBoxQuantityActualTotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LabelInputMessege As Label
End Class
