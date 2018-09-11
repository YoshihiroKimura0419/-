<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenuMasterMente
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
        Me.Btn_MenteUserMaster = New System.Windows.Forms.Button()
        Me.ButtonMentePartsShapeCategory = New System.Windows.Forms.Button()
        Me.ButtonMenteUserTechnicMaster = New System.Windows.Forms.Button()
        Me.ButtonMentePartsShapeMaster = New System.Windows.Forms.Button()
        Me.ButtonMentePartsMaster = New System.Windows.Forms.Button()
        Me.ButtonMenteDrawingMaster = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_MenteUserMaster
        '
        Me.Btn_MenteUserMaster.Location = New System.Drawing.Point(30, 21)
        Me.Btn_MenteUserMaster.Name = "Btn_MenteUserMaster"
        Me.Btn_MenteUserMaster.Size = New System.Drawing.Size(169, 46)
        Me.Btn_MenteUserMaster.TabIndex = 0
        Me.Btn_MenteUserMaster.Text = "ユーザーマスタ"
        Me.Btn_MenteUserMaster.UseVisualStyleBackColor = True
        '
        'ButtonMentePartsShapeCategory
        '
        Me.ButtonMentePartsShapeCategory.Location = New System.Drawing.Point(30, 125)
        Me.ButtonMentePartsShapeCategory.Name = "ButtonMentePartsShapeCategory"
        Me.ButtonMentePartsShapeCategory.Size = New System.Drawing.Size(169, 46)
        Me.ButtonMentePartsShapeCategory.TabIndex = 0
        Me.ButtonMentePartsShapeCategory.Text = "部品形状分類マスタ"
        Me.ButtonMentePartsShapeCategory.UseVisualStyleBackColor = True
        '
        'ButtonMenteUserTechnicMaster
        '
        Me.ButtonMenteUserTechnicMaster.Location = New System.Drawing.Point(30, 73)
        Me.ButtonMenteUserTechnicMaster.Name = "ButtonMenteUserTechnicMaster"
        Me.ButtonMenteUserTechnicMaster.Size = New System.Drawing.Size(169, 46)
        Me.ButtonMenteUserTechnicMaster.TabIndex = 0
        Me.ButtonMenteUserTechnicMaster.Text = "ユーザー技術レベル管理マスタ"
        Me.ButtonMenteUserTechnicMaster.UseVisualStyleBackColor = True
        '
        'ButtonMentePartsShapeMaster
        '
        Me.ButtonMentePartsShapeMaster.Location = New System.Drawing.Point(30, 197)
        Me.ButtonMentePartsShapeMaster.Name = "ButtonMentePartsShapeMaster"
        Me.ButtonMentePartsShapeMaster.Size = New System.Drawing.Size(169, 46)
        Me.ButtonMentePartsShapeMaster.TabIndex = 0
        Me.ButtonMentePartsShapeMaster.Text = "部品形状マスタ"
        Me.ButtonMentePartsShapeMaster.UseVisualStyleBackColor = True
        '
        'ButtonMentePartsMaster
        '
        Me.ButtonMentePartsMaster.Location = New System.Drawing.Point(30, 260)
        Me.ButtonMentePartsMaster.Name = "ButtonMentePartsMaster"
        Me.ButtonMentePartsMaster.Size = New System.Drawing.Size(169, 46)
        Me.ButtonMentePartsMaster.TabIndex = 0
        Me.ButtonMentePartsMaster.Text = "部材マスタ"
        Me.ButtonMentePartsMaster.UseVisualStyleBackColor = True
        '
        'ButtonMenteDrawingMaster
        '
        Me.ButtonMenteDrawingMaster.Location = New System.Drawing.Point(265, 21)
        Me.ButtonMenteDrawingMaster.Name = "ButtonMenteDrawingMaster"
        Me.ButtonMenteDrawingMaster.Size = New System.Drawing.Size(169, 46)
        Me.ButtonMenteDrawingMaster.TabIndex = 0
        Me.ButtonMenteDrawingMaster.Text = "図面情報マスタ"
        Me.ButtonMenteDrawingMaster.UseVisualStyleBackColor = True
        '
        'FormMenuMasterMente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 353)
        Me.Controls.Add(Me.ButtonMenteUserTechnicMaster)
        Me.Controls.Add(Me.Btn_MenteUserMaster)
        Me.Controls.Add(Me.ButtonMenteDrawingMaster)
        Me.Controls.Add(Me.ButtonMentePartsMaster)
        Me.Controls.Add(Me.ButtonMentePartsShapeMaster)
        Me.Controls.Add(Me.ButtonMentePartsShapeCategory)
        Me.Name = "FormMenuMasterMente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "マスターメンテナンス"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_MenteUserMaster As System.Windows.Forms.Button
    Friend WithEvents ButtonMentePartsShapeCategory As System.Windows.Forms.Button
    Friend WithEvents ButtonMenteUserTechnicMaster As System.Windows.Forms.Button
    Friend WithEvents ButtonMentePartsShapeMaster As System.Windows.Forms.Button
    Friend WithEvents ButtonMentePartsMaster As System.Windows.Forms.Button
    Friend WithEvents ButtonMenteDrawingMaster As Button
End Class
