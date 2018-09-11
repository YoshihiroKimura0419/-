Public Class FormMenuMasterMente


    Private Sub Btn_MenteUserMaster_Click(sender As Object, e As EventArgs) Handles Btn_MenteUserMaster.Click
        Me.Hide()

        Using fm As New FormMenteUserMaster(ControlMasterDb)
            fm.ShowDialog()
        End Using

        Me.Show()
    End Sub

    Private Sub ButtonMentePartsShapeCategory_Click(sender As Object, e As EventArgs) Handles ButtonMentePartsShapeCategory.Click
        Me.Hide()

        Using fm As New FormMentePartsShapeCategory(ControlMasterDb)
            fm.ShowDialog()
        End Using

        Me.Show()

    End Sub

    Private Sub ButtonMenteUserTechnicMaster_Click(sender As Object, e As EventArgs) Handles ButtonMenteUserTechnicMaster.Click
        Me.Hide()

        Using fm As New FormMenteTechnicLevelMaster(ControlMasterDb)
            fm.ShowDialog()
        End Using


        Me.Show()

    End Sub


    Private Sub ButtonMentePartsShapeMaster_Click(sender As Object, e As EventArgs) Handles ButtonMentePartsShapeMaster.Click
        Me.Hide()

        Using fm As New FormMentePartsShapeMaster(ControlMasterDb)
            fm.ShowDialog()
        End Using


        Me.Show()

    End Sub

    Private Sub ButtonMentePartsMaster_Click(sender As Object, e As EventArgs) Handles ButtonMentePartsMaster.Click
        Me.Hide()

        Using fm As New FormMentePartsMaster(ControlMasterDb, ControlPartsMasterDb, FormMentePartsMasterOpenMode.Edit)
            fm.ShowDialog()
        End Using


        Me.Show()
    End Sub

    Private Sub ButtonMenteDrawingMaster_Click(sender As Object, e As EventArgs) Handles ButtonMenteDrawingMaster.Click
        Me.Hide()

        Using fm As New FormMenteDrawingMaster(ControlMasterDb, FormMenteDrawingMasterOpenMode.Edit)
            fm.ShowDialog()
        End Using


        Me.Show()

    End Sub
End Class