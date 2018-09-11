<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditOrder
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
        Me.ComboBoxDataEnable = New System.Windows.Forms.ComboBox()
        Me.TextBoxChangeHistory = New System.Windows.Forms.TextBox()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.LabelDataEnable = New System.Windows.Forms.Label()
        Me.TextBoxBoardName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonRegistData = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxUpdateUser = New System.Windows.Forms.TextBox()
        Me.TextBoxUpdateDate = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationUser = New System.Windows.Forms.TextBox()
        Me.TextBoxRegistrationDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxBu = New System.Windows.Forms.ComboBox()
        Me.TextBoxOrder = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrorProviderInput = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxProductionCount = New System.Windows.Forms.TextBox()
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxDataEnable
        '
        Me.ComboBoxDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxDataEnable.FormattingEnabled = True
        Me.ComboBoxDataEnable.Location = New System.Drawing.Point(147, 41)
        Me.ComboBoxDataEnable.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboBoxDataEnable.Name = "ComboBoxDataEnable"
        Me.ComboBoxDataEnable.Size = New System.Drawing.Size(96, 20)
        Me.ComboBoxDataEnable.TabIndex = 2
        '
        'TextBoxChangeHistory
        '
        Me.TextBoxChangeHistory.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxChangeHistory.Location = New System.Drawing.Point(12, 200)
        Me.TextBoxChangeHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxChangeHistory.Multiline = True
        Me.TextBoxChangeHistory.Name = "TextBoxChangeHistory"
        Me.TextBoxChangeHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxChangeHistory.Size = New System.Drawing.Size(435, 104)
        Me.TextBoxChangeHistory.TabIndex = 6
        Me.TextBoxChangeHistory.Text = "菱テク　太郎"
        '
        'LabelUserName
        '
        Me.LabelUserName.BackColor = System.Drawing.Color.Gold
        Me.LabelUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUserName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelUserName.Location = New System.Drawing.Point(12, 181)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(126, 19)
        Me.LabelUserName.TabIndex = 87
        Me.LabelUserName.Text = "変更履歴"
        Me.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelDataEnable
        '
        Me.LabelDataEnable.BackColor = System.Drawing.Color.Gold
        Me.LabelDataEnable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelDataEnable.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelDataEnable.Location = New System.Drawing.Point(13, 42)
        Me.LabelDataEnable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataEnable.Name = "LabelDataEnable"
        Me.LabelDataEnable.Size = New System.Drawing.Size(126, 19)
        Me.LabelDataEnable.TabIndex = 84
        Me.LabelDataEnable.Text = "データ状態"
        Me.LabelDataEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxBoardName
        '
        Me.TextBoxBoardName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxBoardName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBoxBoardName.Location = New System.Drawing.Point(146, 72)
        Me.TextBoxBoardName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxBoardName.Name = "TextBoxBoardName"
        Me.TextBoxBoardName.Size = New System.Drawing.Size(301, 19)
        Me.TextBoxBoardName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gold
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 19)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "基板名称"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonCancel
        '
        Me.ButtonCancel.CausesValidation = False
        Me.ButtonCancel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(258, 387)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(130, 41)
        Me.ButtonCancel.TabIndex = 8
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonRegistData
        '
        Me.ButtonRegistData.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRegistData.Location = New System.Drawing.Point(101, 387)
        Me.ButtonRegistData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonRegistData.Name = "ButtonRegistData"
        Me.ButtonRegistData.Size = New System.Drawing.Size(130, 41)
        Me.ButtonRegistData.TabIndex = 7
        Me.ButtonRegistData.Text = "登録/更新"
        Me.ButtonRegistData.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(209, 346)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "更新者"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(209, 315)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "更新日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 346)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "登録者"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 315)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "登録日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUpdateUser
        '
        Me.TextBoxUpdateUser.Enabled = False
        Me.TextBoxUpdateUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateUser.Location = New System.Drawing.Point(258, 343)
        Me.TextBoxUpdateUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateUser.Name = "TextBoxUpdateUser"
        Me.TextBoxUpdateUser.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateUser.TabIndex = 78
        Me.TextBoxUpdateUser.TabStop = False
        '
        'TextBoxUpdateDate
        '
        Me.TextBoxUpdateDate.Enabled = False
        Me.TextBoxUpdateDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxUpdateDate.Location = New System.Drawing.Point(258, 312)
        Me.TextBoxUpdateDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUpdateDate.Name = "TextBoxUpdateDate"
        Me.TextBoxUpdateDate.Size = New System.Drawing.Size(120, 19)
        Me.TextBoxUpdateDate.TabIndex = 79
        Me.TextBoxUpdateDate.TabStop = False
        '
        'TextBoxRegistrationUser
        '
        Me.TextBoxRegistrationUser.Enabled = False
        Me.TextBoxRegistrationUser.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationUser.Location = New System.Drawing.Point(60, 343)
        Me.TextBoxRegistrationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationUser.Name = "TextBoxRegistrationUser"
        Me.TextBoxRegistrationUser.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationUser.TabIndex = 80
        Me.TextBoxRegistrationUser.TabStop = False
        '
        'TextBoxRegistrationDate
        '
        Me.TextBoxRegistrationDate.Enabled = False
        Me.TextBoxRegistrationDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRegistrationDate.Location = New System.Drawing.Point(60, 312)
        Me.TextBoxRegistrationDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxRegistrationDate.Name = "TextBoxRegistrationDate"
        Me.TextBoxRegistrationDate.Size = New System.Drawing.Size(123, 19)
        Me.TextBoxRegistrationDate.TabIndex = 81
        Me.TextBoxRegistrationDate.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gold
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 105)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 19)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "BU"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxBu
        '
        Me.ComboBoxBu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBu.FormattingEnabled = True
        Me.ComboBoxBu.Location = New System.Drawing.Point(145, 105)
        Me.ComboBoxBu.Name = "ComboBoxBu"
        Me.ComboBoxBu.Size = New System.Drawing.Size(209, 20)
        Me.ComboBoxBu.TabIndex = 4
        '
        'TextBoxOrder
        '
        Me.TextBoxOrder.Location = New System.Drawing.Point(146, 13)
        Me.TextBoxOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxOrder.Name = "TextBoxOrder"
        Me.TextBoxOrder.Size = New System.Drawing.Size(144, 19)
        Me.TextBoxOrder.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gold
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 19)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "オーダー"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProviderInput
        '
        Me.ErrorProviderInput.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 138)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "製作枚数"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxProductionCount
        '
        Me.TextBoxProductionCount.Location = New System.Drawing.Point(145, 138)
        Me.TextBoxProductionCount.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProductionCount.Name = "TextBoxProductionCount"
        Me.TextBoxProductionCount.Size = New System.Drawing.Size(144, 19)
        Me.TextBoxProductionCount.TabIndex = 5
        '
        'FormEditOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 439)
        Me.Controls.Add(Me.TextBoxProductionCount)
        Me.Controls.Add(Me.TextBoxOrder)
        Me.Controls.Add(Me.ComboBoxBu)
        Me.Controls.Add(Me.ComboBoxDataEnable)
        Me.Controls.Add(Me.TextBoxChangeHistory)
        Me.Controls.Add(Me.LabelUserName)
        Me.Controls.Add(Me.LabelDataEnable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxBoardName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonRegistData)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxUpdateUser)
        Me.Controls.Add(Me.TextBoxUpdateDate)
        Me.Controls.Add(Me.TextBoxRegistrationUser)
        Me.Controls.Add(Me.TextBoxRegistrationDate)
        Me.Name = "FormEditOrder"
        Me.Text = "オーダー登録・編集画面"
        CType(Me.ErrorProviderInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxDataEnable As ComboBox
    Protected WithEvents TextBoxChangeHistory As TextBox
    Protected WithEvents LabelUserName As Label
    Protected WithEvents LabelDataEnable As Label
    Protected WithEvents TextBoxBoardName As TextBox
    Protected WithEvents Label2 As Label
    Protected WithEvents ButtonCancel As Button
    Protected WithEvents ButtonRegistData As Button
    Protected WithEvents Label12 As Label
    Protected WithEvents Label11 As Label
    Protected WithEvents Label10 As Label
    Protected WithEvents Label9 As Label
    Protected WithEvents TextBoxUpdateUser As TextBox
    Protected WithEvents TextBoxUpdateDate As TextBox
    Protected WithEvents TextBoxRegistrationUser As TextBox
    Protected WithEvents TextBoxRegistrationDate As TextBox
    Protected WithEvents Label3 As Label
    Friend WithEvents ComboBoxBu As ComboBox
    Friend WithEvents TextBoxOrder As TextBox
    Protected WithEvents Label4 As Label
    Friend WithEvents ErrorProviderInput As ErrorProvider
    Friend WithEvents TextBoxProductionCount As TextBox
    Protected WithEvents Label1 As Label
End Class
