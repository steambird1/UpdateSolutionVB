Public Class MainExecuter
    Private Sub MainExecuter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s As IO.BinaryWriter = New IO.BinaryWriter(IO.File.Open("D:\example.txt", IO.FileMode.Create))
        s.Write(My.Resources.FileResource.TestExtract)
        s.Close()
        End
    End Sub
End Class
