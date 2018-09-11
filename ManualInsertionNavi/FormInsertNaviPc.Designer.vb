<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInsertNaviPc
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.PictureBoxBoard = New System.Windows.Forms.PictureBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.PictureBoxAllParts = New System.Windows.Forms.PictureBox()
        Me.PictureBoxPresentParts = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PictureBoxBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.PictureBoxAllParts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPresentParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1175, 513)
        Me.SplitContainer1.SplitterDistance = 828
        Me.SplitContainer1.SplitterWidth = 7
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.RoyalBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBoxPresentParts)
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBoxAllParts)
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBoxBoard)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Size = New System.Drawing.Size(828, 513)
        Me.SplitContainer2.SplitterDistance = 422
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'PictureBoxBoard
        '
        Me.PictureBoxBoard.Location = New System.Drawing.Point(25, 40)
        Me.PictureBoxBoard.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.PictureBoxBoard.Name = "PictureBoxBoard"
        Me.PictureBoxBoard.Size = New System.Drawing.Size(249, 260)
        Me.PictureBoxBoard.TabIndex = 0
        Me.PictureBoxBoard.TabStop = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.DarkGreen
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.PaleGreen
        Me.SplitContainer3.Size = New System.Drawing.Size(340, 513)
        Me.SplitContainer3.SplitterDistance = 374
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.GreenYellow
        Me.Label1.Location = New System.Drawing.Point(-2, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "なび情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer.Size = New System.Drawing.Size(1175, 605)
        Me.SplitContainer.SplitterDistance = 88
        Me.SplitContainer.TabIndex = 1
        '
        'PictureBoxAllParts
        '
        Me.PictureBoxAllParts.Location = New System.Drawing.Point(286, 40)
        Me.PictureBoxAllParts.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.PictureBoxAllParts.Name = "PictureBoxAllParts"
        Me.PictureBoxAllParts.Size = New System.Drawing.Size(249, 260)
        Me.PictureBoxAllParts.TabIndex = 0
        Me.PictureBoxAllParts.TabStop = False
        '
        'PictureBoxPresentParts
        '
        Me.PictureBoxPresentParts.Location = New System.Drawing.Point(547, 40)
        Me.PictureBoxPresentParts.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.PictureBoxPresentParts.Name = "PictureBoxPresentParts"
        Me.PictureBoxPresentParts.Size = New System.Drawing.Size(249, 260)
        Me.PictureBoxPresentParts.TabIndex = 0
        Me.PictureBoxPresentParts.TabStop = False
        '
        'FormInsertNaviPc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 605)
        Me.Controls.Add(Me.SplitContainer)
        Me.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Name = "FormInsertNaviPc"
        Me.Text = "FormInsertNaviPc"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PictureBoxBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.PictureBoxAllParts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPresentParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxBoard As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents PictureBoxPresentParts As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxAllParts As System.Windows.Forms.PictureBox
End Class
