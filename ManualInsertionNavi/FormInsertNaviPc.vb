Public Class FormInsertNaviPc

    Private Sub FormInsertNaviPc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBoxBoard.Dock = DockStyle.Fill
        'PictureBox透過テスト
        With PictureBoxPresentParts
            .Parent = PictureBoxAllParts
            .Top = 0
            .Left = 0
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Transparent
            PictureBoxAllParts.Controls.Add(PictureBoxPresentParts)
            .Dock = DockStyle.Fill
        End With

        'PictureBox透過テスト
        With PictureBoxAllParts
            .Parent = PictureBoxBoard
            .Top = 0
            .Left = 0
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Transparent
            PictureBoxBoard.Controls.Add(PictureBoxAllParts)
            .Dock = DockStyle.Fill
        End With

    End Sub
End Class