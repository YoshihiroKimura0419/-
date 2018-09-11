Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBoxDispData.Text = ""
        'Netlistインスタンス作成
        Dim NetListReader As New NetListReaderImpl
        'ネットリストファイル名取得
        Dim fileName As String = NetListReader.GetFilePath(My.Application.Info.DirectoryPath)

        'ネットリストファイル内容取得
        Dim readNetStringBuf() As String = NetListReader.GetText(fileName)

        'テキストボックス表示用文字列作成
        Dim readNetString As New System.Text.StringBuilder
        If readNetStringBuf IsNot Nothing Then
            For Each line As String In readNetStringBuf
                readNetString.Append(line)
                readNetString.Append(vbCrLf)
            Next
        Else
            MessageBox.Show(fileName & "は、ネットリストではありません。", "ファイルエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'テキストボックス表示
        TextBoxDispData.AppendText(readNetString.ToString)

    End Sub


End Class
