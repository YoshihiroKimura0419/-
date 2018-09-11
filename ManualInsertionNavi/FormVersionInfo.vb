Public Class FormVersionInfo

    Private Sub FormVersionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '自分自身のAssemblyを取得
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        'バージョンの取得
        Dim ver As System.Version = asm.GetName().Version
        LabelVersion.Text = ver.ToString
    End Sub
End Class