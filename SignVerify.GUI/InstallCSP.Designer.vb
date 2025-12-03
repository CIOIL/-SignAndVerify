<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallCSP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCSP = New System.Windows.Forms.Label
        Me.layoutCSP = New System.Windows.Forms.FlowLayoutPanel
        Me.lnkCSP = New System.Windows.Forms.LinkLabel
        Me.lblSupport = New System.Windows.Forms.Label
        Me.layoutCSP.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCSP
        '
        Me.lblCSP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCSP.AutoSize = True
        Me.lblCSP.BackColor = System.Drawing.Color.Transparent
        Me.lblCSP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblCSP.Location = New System.Drawing.Point(138, 0)
        Me.lblCSP.Name = "lblCSP"
        Me.lblCSP.Size = New System.Drawing.Size(416, 44)
        Me.lblCSP.TabIndex = 0
        Me.lblCSP.Text = "לצורך חתימה, נדרש עדכון תוכנה לשימוש בכרטיס חכם . " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "אנא התקן את הגרסה חדשה מהקישו" & _
            "ר הבא:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'layoutCSP
        '
        Me.layoutCSP.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.layoutCSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.layoutCSP.Controls.Add(Me.lblCSP)
        Me.layoutCSP.Controls.Add(Me.lnkCSP)
        Me.layoutCSP.Controls.Add(Me.lblSupport)
        Me.layoutCSP.Cursor = System.Windows.Forms.Cursors.Default
        Me.layoutCSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutCSP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.layoutCSP.Location = New System.Drawing.Point(0, 0)
        Me.layoutCSP.Name = "layoutCSP"
        Me.layoutCSP.Size = New System.Drawing.Size(557, 126)
        Me.layoutCSP.TabIndex = 1
        '
        'lnkCSP
        '
        Me.lnkCSP.AutoSize = True
        Me.lnkCSP.BackColor = System.Drawing.Color.Transparent
        Me.lnkCSP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkCSP.Location = New System.Drawing.Point(75, 44)
        Me.lnkCSP.Name = "lnkCSP"
        Me.lnkCSP.Size = New System.Drawing.Size(479, 16)
        Me.lnkCSP.TabIndex = 1
        Me.lnkCSP.TabStop = True
        Me.lnkCSP.Text = "" & _
            "m"
        '
        'lblSupport
        '
        Me.lblSupport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSupport.AutoSize = True
        Me.lblSupport.BackColor = System.Drawing.Color.Transparent
        Me.lblSupport.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSupport.Location = New System.Drawing.Point(246, 60)
        Me.lblSupport.Name = "lblSupport"
        Me.lblSupport.Size = New System.Drawing.Size(308, 22)
        Me.lblSupport.TabIndex = 2
        Me.lblSupport.Text = "לתמיכה אנא התקשר ל-1800-200-560."
        '
        'InstallCSP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(557, 126)
        Me.Controls.Add(Me.layoutCSP)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InstallCSP"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "גרסת CSP לא מעודכנת"
        Me.layoutCSP.ResumeLayout(False)
        Me.layoutCSP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCSP As System.Windows.Forms.Label
    Friend WithEvents layoutCSP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lnkCSP As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSupport As System.Windows.Forms.Label
End Class
