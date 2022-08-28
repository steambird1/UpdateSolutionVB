<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UpdateTitle = New System.Windows.Forms.Label()
        Me.UpdatePrompt = New System.Windows.Forms.Label()
        Me.UpdateProgress = New System.Windows.Forms.ProgressBar()
        Me.NetWorker = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'UpdateTitle
        '
        Me.UpdateTitle.AutoSize = True
        Me.UpdateTitle.Location = New System.Drawing.Point(12, 24)
        Me.UpdateTitle.Name = "UpdateTitle"
        Me.UpdateTitle.Size = New System.Drawing.Size(111, 15)
        Me.UpdateTitle.TabIndex = 0
        Me.UpdateTitle.Text = "[UpdateTitle]"
        '
        'UpdatePrompt
        '
        Me.UpdatePrompt.AutoSize = True
        Me.UpdatePrompt.Location = New System.Drawing.Point(12, 54)
        Me.UpdatePrompt.Name = "UpdatePrompt"
        Me.UpdatePrompt.Size = New System.Drawing.Size(119, 15)
        Me.UpdatePrompt.TabIndex = 1
        Me.UpdatePrompt.Text = "[UpdatePrompt]"
        '
        'UpdateProgress
        '
        Me.UpdateProgress.Location = New System.Drawing.Point(13, 89)
        Me.UpdateProgress.Name = "UpdateProgress"
        Me.UpdateProgress.Size = New System.Drawing.Size(616, 23)
        Me.UpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.UpdateProgress.TabIndex = 2
        '
        'NetWorker
        '
        Me.NetWorker.WorkerReportsProgress = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 138)
        Me.Controls.Add(Me.UpdateProgress)
        Me.Controls.Add(Me.UpdatePrompt)
        Me.Controls.Add(Me.UpdateTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Updater"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UpdateTitle As Label
    Friend WithEvents UpdatePrompt As Label
    Friend WithEvents UpdateProgress As ProgressBar
    Friend WithEvents NetWorker As System.ComponentModel.BackgroundWorker
End Class
