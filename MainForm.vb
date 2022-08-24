Imports Microsoft.Win32
Imports System.IO

Public Class MainForm

    Private Startup As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
    Private FlagTarget As String = Environ("temp") & "\flag.bin"
    Private ApplicationTarget As String = Environ("temp") & "\update" & My.Resources.Settings.TargetFileKind

    Private Sub NetWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles NetWorker.DoWork
        Try
            My.Computer.Network.DownloadFile(My.Resources.Settings.VerifierPath, FlagTarget)
            Dim sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(FlagTarget)
            Dim cur As String = sr.ReadToEnd()
            sr.Close()
            ' Verifier must be text.
            Dim reg As RegistryKey = Application.CommonAppDataRegistry
            Dim reges As Object = reg.GetValue("LastName")
            If IsNothing(reges) OrElse (New String(reges) <> cur) Then
                ' Download latest update, and execute it
                My.Computer.Network.DownloadFile(My.Resources.Settings.DownloadPath, ApplicationTarget)
                If My.Resources.Settings.ExecuteAfterDownload = "True" Then
                    Shell(ApplicationTarget, Val(My.Resources.Settings.ExecutionDisplay), True)
                End If
            End If
        Catch ex As Exception
            MsgBox(My.Resources.Languages.FailPrompt & vbCrLf & ex.Message, MsgBoxStyle.Critical, My.Resources.Languages.FailTitle)
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup.SetValue("AppUpdater" & My.Resources.Settings.ApplicationName, Application.ExecutablePath)
        Me.Text = My.Resources.Languages.UpdateTitle
        UpdateTitle.Text = My.Resources.Languages.UpdateTitle
        UpdatePrompt.Text = My.Resources.Languages.CheckPrompt
        NetWorker.RunWorkerAsync()
    End Sub
End Class
