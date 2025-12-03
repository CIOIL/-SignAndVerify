<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class testDisplaySignatures
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(testDisplaySignatures))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.SignaturesTreeGrid1 = New SignVerify.GUI.SignaturesTreeGrid
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(396, 431)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'SignaturesTreeGrid1
        '
        Me.SignaturesTreeGrid1.CollapsedImage = CType(resources.GetObject("SignaturesTreeGrid1.CollapsedImage"), System.Drawing.Image)
        Me.SignaturesTreeGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SignaturesTreeGrid1.ExpandedImage = CType(resources.GetObject("SignaturesTreeGrid1.ExpandedImage"), System.Drawing.Image)
        Me.SignaturesTreeGrid1.ExpandedRowHeight = 131
        Me.SignaturesTreeGrid1.HeaderHeight = 20
        Me.SignaturesTreeGrid1.InitialState = SignVerify.GUI.PanelStateType.Collapsed
        Me.SignaturesTreeGrid1.Location = New System.Drawing.Point(0, 0)
        Me.SignaturesTreeGrid1.Name = "SignaturesTreeGrid1"
        Me.SignaturesTreeGrid1.Size = New System.Drawing.Size(475, 454)
        Me.SignaturesTreeGrid1.TabIndex = 1
        '
        'testDisplaySignatures
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 454)
        Me.Controls.Add(Me.SignaturesTreeGrid1)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "testDisplaySignatures"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "          "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents SignaturesTreeGrid1 As SignVerify.GUI.SignaturesTreeGrid

End Class
