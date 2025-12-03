<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class testGlobalization
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(testGlobalization))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblCurrentCulture = New System.Windows.Forms.Label
        Me.lblCulture = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = Nothing
        Me.Button1.AccessibleName = Nothing
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackgroundImage = Nothing
        Me.Button1.Font = Nothing
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AccessibleDescription = Nothing
        Me.Button2.AccessibleName = Nothing
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.BackgroundImage = Nothing
        Me.Button2.Font = Nothing
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblCurrentCulture
        '
        Me.lblCurrentCulture.AccessibleDescription = Nothing
        Me.lblCurrentCulture.AccessibleName = Nothing
        resources.ApplyResources(Me.lblCurrentCulture, "lblCurrentCulture")
        Me.lblCurrentCulture.Font = Nothing
        Me.lblCurrentCulture.Name = "lblCurrentCulture"
        '
        'lblCulture
        '
        Me.lblCulture.AccessibleDescription = Nothing
        Me.lblCulture.AccessibleName = Nothing
        resources.ApplyResources(Me.lblCulture, "lblCulture")
        Me.lblCulture.Font = Nothing
        Me.lblCulture.ForeColor = System.Drawing.Color.Red
        Me.lblCulture.Name = "lblCulture"
        '
        'testGlobalization
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.lblCulture)
        Me.Controls.Add(Me.lblCurrentCulture)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "testGlobalization"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblCurrentCulture As System.Windows.Forms.Label
    Friend WithEvents lblCulture As System.Windows.Forms.Label
End Class
