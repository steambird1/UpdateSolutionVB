Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.IO

Public Class MainForm

    Private Startup As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
    Private FlagTarget As String = Environ("temp") & "\flag.bin"
    Private ApplicationTarget As String = Environ("temp") & "\update" & My.Resources.Settings.TargetFileKind

    Private Sub NetWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles NetWorker.DoWork
        Try
            If My.Computer.FileSystem.FileExists(FlagTarget) Then
                My.Computer.FileSystem.DeleteFile(FlagTarget)
            End If
            If My.Computer.FileSystem.FileExists(ApplicationTarget) Then
                My.Computer.FileSystem.DeleteFile(ApplicationTarget)
            End If
            My.Computer.Network.DownloadFile(My.Resources.Settings.VerifierPath, FlagTarget)
            Dim sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(FlagTarget)
            Dim cur As String = sr.ReadLine()   ' Only first one is valid.
            sr.Close()
            ' Verifier must be text.
            Dim reg As RegistryKey = Application.UserAppDataRegistry
            Dim LastNamePosition As String = "LastName" & My.Resources.Settings.ApplicationName
            Dim reges As Object = reg.GetValue(LastNamePosition)
            If IsNothing(reges) OrElse (New String(reges) <> cur) Then
                ' Download latest update, and execute it
                reg.SetValue(LastNamePosition, cur)
                NetWorker.ReportProgress(50)
                My.Computer.Network.DownloadFile(My.Resources.Settings.DownloadPath, ApplicationTarget)
                If My.Resources.Settings.ExecuteAfterDownload = "True" Then
                    Shell(ApplicationTarget, Val(My.Resources.Settings.ExecutionDisplay), True)
                End If
                End
            Else
                NetWorker.ReportProgress(90)
            End If
        Catch ex As Exception
            MsgBox(My.Resources.Languages.FailPrompt & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical, My.Resources.Languages.FailTitle)
            End
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup.SetValue("AppUpdater" & My.Resources.Settings.ApplicationName, Application.ExecutablePath)
        Me.Text = My.Resources.Languages.UpdateTitle
        UpdateTitle.Text = My.Resources.Languages.UpdateTitle
        UpdatePrompt.Text = My.Resources.Languages.CheckPrompt
        NetWorker.RunWorkerAsync()
    End Sub

    Private Sub NetWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles NetWorker.ProgressChanged
        If e.ProgressPercentage >= 90 Then
            UpdatePrompt.Text = My.Resources.Languages.UpToDatePrompt
            DelayQuit.Enabled = True
        ElseIf e.ProgressPercentage >= 50 Then
            UpdatePrompt.Text = My.Resources.Languages.UpdatePrompt
        End If
    End Sub

    Private Sub DelayQuit_Tick(sender As Object, e As EventArgs) Handles DelayQuit.Tick
        End
    End Sub
End Class
