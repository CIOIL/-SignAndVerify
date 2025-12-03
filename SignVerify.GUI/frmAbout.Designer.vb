<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblRights = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.pnlUpper = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.pnlUpper.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblRights)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 42)
        Me.Panel1.TabIndex = 0
        '
        'lblRights
        '
        Me.lblRights.AutoSize = True
        Me.lblRights.BackColor = System.Drawing.Color.Transparent
        Me.lblRights.ForeColor = System.Drawing.Color.White
        Me.lblRights.Image = Global.SignVerify.GUI.My.Resources.Resources.IconRights
        Me.lblRights.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRights.Location = New System.Drawing.Point(63, 17)
        Me.lblRights.Name = "lblRights"
        Me.lblRights.Size = New System.Drawing.Size(195, 16)
        Me.lblRights.TabIndex = 3
        Me.lblRights.Text = "    כל הזכויות שמורות למדינת ישראל"
        Me.lblRights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.White
        Me.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersion.Location = New System.Drawing.Point(66, 19)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Padding = New System.Windows.Forms.Padding(5)
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(189, 28)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Sign and Verify Version 2.1.6"
        '
        'pnlUpper
        '
        Me.pnlUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlUpper.Controls.Add(Me.lblVersion)
        Me.pnlUpper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUpper.Location = New System.Drawing.Point(0, 0)
        Me.pnlUpper.Name = "pnlUpper"
        Me.pnlUpper.Size = New System.Drawing.Size(327, 61)
        Me.pnlUpper.TabIndex = 3
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.ClientSize = New System.Drawing.Size(327, 103)
        Me.Controls.Add(Me.pnlUpper)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "אודות"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlUpper.ResumeLayout(False)
        Me.pnlUpper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents pnlUpper As System.Windows.Forms.Panel
    Friend WithEvents lblRights As System.Windows.Forms.Label
End Class
