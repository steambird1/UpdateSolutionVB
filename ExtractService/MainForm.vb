Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Resources

''' <summary>
''' Warning:
''' Before generating application, please write ExtractData.zip
''' and ExtractList.txt in your own!
''' </summary>

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' test!
        'MsgBox(Environ("temp"))
        'End
        ExtractWorker.RunWorkerAsync()
    End Sub


    ' Will create all inside directories.
    Private Sub SmartCreateDirectory(dir As String)
        Shell("cmd /c mkdir " & dir, AppWinStyle.Hide, True)
    End Sub

    Dim seeder As Random = New Random()

    Private Function FindFreeFile(prefix As String, appendix As String) As String
        Dim fn As String = ""
        Do Until fn.Length > 0 AndAlso (Not My.Computer.FileSystem.FileExists(fn))
            fn = prefix & seeder.Next() & appendix
        Loop
        Return fn
    End Function

    Private Sub ExtractWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExtractWorker.DoWork
        ExtractWorker.ReportProgress(0)
        Dim listdata As String = My.Resources.ExtractInfo.ExtractList
        ExtractWorker.ReportProgress(10)
        Dim spl As String() = Split(listdata, vbCrLf)
        Dim current As Integer = 0
        ExtractWorker.ReportProgress(20)
        ' Extract ZIP File (Using DEFLATE)
        Dim etarget As String = FindFreeFile(Environ("temp") & "\", ".zip")
        Dim estream As BinaryWriter = New BinaryWriter(File.Open(etarget, FileMode.Create))
        estream.Write(My.Resources.ExtractInfo.ExtractData)
        estream.Close()
        Dim arc As ZipArchive = New ZipArchive(File.Open(etarget, FileMode.Open), ZipArchiveMode.Read)
        ExtractWorker.ReportProgress(100)
        For Each i In spl
            ExtractWorker.ReportProgress((current * 100) / spl.Count())
            If i.Length <= 0 OrElse i(0) = "#"c Then
                Continue For
            End If
            Dim mspl As String() = Split(i, ">")
            Dim source_path As String = Trim(mspl(0))
            Dim target_path As String = My.Resources.ExtractInfo.ExtractTarget & Trim(mspl(1))
            Dim target_file_path As String = target_path & source_path
            SmartCreateDirectory(target_path)
            Dim ae As ZipArchiveEntry = arc.GetEntry(source_path)
            Dim source_stream As BinaryReader = New BinaryReader(ae.Open())
            Dim target_stream As BinaryWriter = New BinaryWriter(File.Open(target_file_path, FileMode.Create))
            target_stream.Write(source_stream.ReadBytes(ae.Length)) '...
            target_stream.Close()
            source_stream.Close()
            current += 1
        Next
        ExtractWorker.ReportProgress(100)
        End
    End Sub

    Private Sub ExtractWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ExtractWorker.ProgressChanged
        ExtractStatus.Value = e.ProgressPercentage
    End Sub
End Class
