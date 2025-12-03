<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignaturesHistory
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignaturesHistory))
        Me.OK_Button = New SignVerify.GUI.RoundedButton()
        Me.pnlHistory = New System.Windows.Forms.Panel()
        Me.SignaturesTreeGrid1 = New SignVerify.GUI.SignaturesTreeGrid()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.pnlLowDottedLine = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.HelpToolStrip = New System.Windows.Forms.ToolStrip()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lnkExpandAll = New System.Windows.Forms.Label()
        Me.lnkCollopseAll = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHistory.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.HelpToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OK_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.Window
        Me.OK_Button.Location = New System.Drawing.Point(13, 185)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(55, 24)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "סגור"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "סגור מסך")
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'pnlHistory
        '
        Me.pnlHistory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHistory.AutoScroll = True
        Me.pnlHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHistory.Controls.Add(Me.SignaturesTreeGrid1)
        Me.pnlHistory.Location = New System.Drawing.Point(14, 62)
        Me.pnlHistory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHistory.Name = "pnlHistory"
        Me.pnlHistory.Size = New System.Drawing.Size(503, 345)
        Me.pnlHistory.TabIndex = 2
        '
        'SignaturesTreeGrid1
        '
        Me.SignaturesTreeGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SignaturesTreeGrid1.BackColor = System.Drawing.Color.Transparent
        Me.SignaturesTreeGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SignaturesTreeGrid1.CollapsedImage = Global.SignVerify.GUI.My.Resources.Resources.Plus1
        Me.SignaturesTreeGrid1.ExpandedImage = Global.SignVerify.GUI.My.Resources.Resources.Minus1
        Me.SignaturesTreeGrid1.ExpandedRowHeight = 200
        Me.SignaturesTreeGrid1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SignaturesTreeGrid1.HeaderHeight = 24
        Me.SignaturesTreeGrid1.InitialState = SignVerify.GUI.PanelStateType.Collapsed
        Me.SignaturesTreeGrid1.Location = New System.Drawing.Point(0, 0)
        Me.SignaturesTreeGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SignaturesTreeGrid1.Name = "SignaturesTreeGrid1"
        Me.SignaturesTreeGrid1.PanelBackGroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.SignaturesTreeGrid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SignaturesTreeGrid1.Size = New System.Drawing.Size(500, 0)
        Me.SignaturesTreeGrid1.TabIndex = 2
        '
        'pnlBack
        '
        Me.pnlBack.Controls.Add(Me.OK_Button)
        Me.pnlBack.Controls.Add(Me.pnlLowDottedLine)
        Me.pnlBack.Controls.Add(Me.Panel2)
        Me.pnlBack.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBack.Location = New System.Drawing.Point(0, 264)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(531, 215)
        Me.pnlBack.TabIndex = 3
        '
        'pnlLowDottedLine
        '
        Me.pnlLowDottedLine.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.pnlLowDottedLine.Location = New System.Drawing.Point(12, 179)
        Me.pnlLowDottedLine.Name = "pnlLowDottedLine"
        Me.pnlLowDottedLine.Size = New System.Drawing.Size(507, 2)
        Me.pnlLowDottedLine.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Location = New System.Drawing.Point(12, 363)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(506, 3)
        Me.Panel2.TabIndex = 0
        '
        'lblSep
        '
        Me.lblSep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSep.AutoSize = True
        Me.lblSep.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSep.Location = New System.Drawing.Point(449, 42)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(9, 13)
        Me.lblSep.TabIndex = 36
        Me.lblSep.Text = "|"
        Me.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.HelpToolStrip)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(531, 36)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(531, 36)
        Me.ToolStripContainer1.TabIndex = 41
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'HelpToolStrip
        '
        Me.HelpToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.HelpToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HelpToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HelpToolStrip.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStrip.GripMargin = New System.Windows.Forms.Padding(0)
        Me.HelpToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.HelpToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripButton})
        Me.HelpToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.HelpToolStrip.Name = "HelpToolStrip"
        Me.HelpToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpToolStrip.ShowItemToolTips = False
        Me.HelpToolStrip.Size = New System.Drawing.Size(531, 36)
        Me.HelpToolStrip.TabIndex = 0
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.BackColor = System.Drawing.Color.Transparent
        Me.HelpToolStripButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HelpToolStripButton.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.HelpToolStripButton.Margin = New System.Windows.Forms.Padding(0)
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.HelpToolStripButton.Size = New System.Drawing.Size(55, 36)
        Me.HelpToolStripButton.Text = "עזרה"
        Me.HelpToolStripButton.Visible = False
        '
        'lnkExpandAll
        '
        Me.lnkExpandAll.AutoSize = True
        Me.lnkExpandAll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkExpandAll.Location = New System.Drawing.Point(393, 39)
        Me.lnkExpandAll.Name = "lnkExpandAll"
        Me.lnkExpandAll.Size = New System.Drawing.Size(55, 16)
        Me.lnkExpandAll.TabIndex = 42
        Me.lnkExpandAll.Text = "פתח הכל"
        Me.ToolTip1.SetToolTip(Me.lnkExpandAll, "פתח את סטטוס החתימות")
        '
        'lnkCollopseAll
        '
        Me.lnkCollopseAll.AutoSize = True
        Me.lnkCollopseAll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkCollopseAll.Location = New System.Drawing.Point(458, 39)
        Me.lnkCollopseAll.Name = "lnkCollopseAll"
        Me.lnkCollopseAll.Size = New System.Drawing.Size(60, 16)
        Me.lnkCollopseAll.TabIndex = 43
        Me.lnkCollopseAll.Text = "צמצם הכל"
        Me.ToolTip1.SetToolTip(Me.lnkCollopseAll, "סגור את סטטוס החתימות")
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'SignaturesHistory
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(531, 479)
        Me.Controls.Add(Me.lnkCollopseAll)
        Me.Controls.Add(Me.lnkExpandAll)
        Me.Controls.Add(Me.lblSep)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.pnlHistory)
        Me.Controls.Add(Me.pnlBack)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SignaturesHistory"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "סטטוס חתימות מפורט"
        Me.pnlHistory.ResumeLayout(False)
        Me.pnlBack.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.HelpToolStrip.ResumeLayout(False)
        Me.HelpToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As RoundedButton
    Friend WithEvents pnlHistory As System.Windows.Forms.Panel
    Friend WithEvents SignaturesTreeGrid1 As SignVerify.GUI.SignaturesTreeGrid
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblSep As System.Windows.Forms.Label
    Friend WithEvents pnlLowDottedLine As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents HelpToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lnkExpandAll As System.Windows.Forms.Label
    Friend WithEvents lnkCollopseAll As System.Windows.Forms.Label

End Class
