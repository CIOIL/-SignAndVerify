<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignVerfiyCL
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignVerfiyCL))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.imgFooter = New System.Windows.Forms.PictureBox()
        Me.pnlSelectFile = New System.Windows.Forms.Panel()
        Me.btnCancel = New SignVerify.GUI.Controls.GlassButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.plFiles = New System.Windows.Forms.Panel()
        Me.lblExplanation = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.About = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDiag = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BgWorker = New System.ComponentModel.BackgroundWorker()
        Me.SaveFolderDiag = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gvFiles = New SignVerify.GUI.FileList()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.imgFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectFile.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.plFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.BackMidMain
        Me.TableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.imgFooter, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlSelectFile, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(432, 287)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'imgFooter
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.imgFooter, 2)
        Me.imgFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.imgFooter.Image = Global.SignVerify.GUI.My.Resources.Resources.ButtomMain
        Me.imgFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.imgFooter.Location = New System.Drawing.Point(0, 262)
        Me.imgFooter.Margin = New System.Windows.Forms.Padding(0)
        Me.imgFooter.Name = "imgFooter"
        Me.imgFooter.Size = New System.Drawing.Size(432, 25)
        Me.imgFooter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgFooter.TabIndex = 9
        Me.imgFooter.TabStop = False
        '
        'pnlSelectFile
        '
        Me.pnlSelectFile.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.pnlSelectFile, 2)
        Me.pnlSelectFile.Controls.Add(Me.btnCancel)
        Me.pnlSelectFile.Controls.Add(Me.ProgressBar1)
        Me.pnlSelectFile.Controls.Add(Me.Panel1)
        Me.pnlSelectFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSelectFile.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSelectFile.Name = "pnlSelectFile"
        Me.pnlSelectFile.Size = New System.Drawing.Size(432, 262)
        Me.pnlSelectFile.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.DisabledGlowColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.GlowColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(332, 221)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.ShineColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "בטל"
        Me.btnCancel.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 221)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(300, 20)
        Me.ProgressBar1.TabIndex = 27
        Me.ProgressBar1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.plFiles)
        Me.Panel1.Controls.Add(Me.lblExplanation)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(9, 9)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(410, 207)
        Me.Panel1.TabIndex = 25
        '
        'plFiles
        '
        Me.plFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plFiles.AutoScroll = True
        Me.plFiles.BackColor = System.Drawing.Color.White
        Me.plFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plFiles.Controls.Add(Me.gvFiles)
        Me.plFiles.Location = New System.Drawing.Point(12, 61)
        Me.plFiles.Name = "plFiles"
        Me.plFiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.plFiles.Size = New System.Drawing.Size(386, 133)
        Me.plFiles.TabIndex = 24
        '
        'lblExplanation
        '
        Me.lblExplanation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExplanation.AutoSize = True
        Me.lblExplanation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblExplanation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExplanation.Location = New System.Drawing.Point(191, 4)
        Me.lblExplanation.Name = "lblExplanation"
        Me.lblExplanation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblExplanation.Size = New System.Drawing.Size(210, 32)
        Me.lblExplanation.TabIndex = 22
        Me.lblExplanation.Text = "לתחילת תהליך של חתימה או אימות, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "לחץ על עיון לבחירת הקבצים."
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(284, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "קבצים לחתימה/אימות"
        '
        'Help
        '
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(105, 22)
        Me.Help.Text = "עזרה"
        '
        'About
        '
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(105, 22)
        Me.About.Text = "אודות"
        '
        'itemHelp
        '
        Me.itemHelp.Name = "itemHelp"
        Me.itemHelp.Size = New System.Drawing.Size(105, 22)
        Me.itemHelp.Text = "עזרה"
        '
        'itemAbout
        '
        Me.itemAbout.Name = "itemAbout"
        Me.itemAbout.Size = New System.Drawing.Size(105, 22)
        Me.itemAbout.Text = "אודות"
        '
        'SaveFileDiag
        '
        Me.SaveFileDiag.RestoreDirectory = True
        Me.SaveFileDiag.SupportMultiDottedExtensions = True
        '
        'BgWorker
        '
        Me.BgWorker.WorkerReportsProgress = True
        Me.BgWorker.WorkerSupportsCancellation = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "All files|*.*|Signed files|*.signed"
        Me.OpenFileDialog1.Multiselect = True
        '
        'gvFiles
        '
        Me.gvFiles.AutoSize = True
        Me.gvFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gvFiles.BackColor = System.Drawing.Color.Transparent
        Me.gvFiles.ColumnCount = 1
        Me.gvFiles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.gvFiles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.gvFiles.Location = New System.Drawing.Point(3, 3)
        Me.gvFiles.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.gvFiles.Name = "gvFiles"
        Me.gvFiles.Size = New System.Drawing.Size(0, 0)
        Me.gvFiles.TabIndex = 21
        '
        'SignVerfiyCL
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.ClientSize = New System.Drawing.Size(432, 287)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SignVerfiyCL"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "אמת וחתום 2.0"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.imgFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectFile.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.plFiles.ResumeLayout(False)
        Me.plFiles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imgFooter As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSelectFile As System.Windows.Forms.Panel

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDiag As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gvFiles As SignVerify.GUI.FileList
    Friend WithEvents plFiles As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblExplanation As System.Windows.Forms.Label
    Friend WithEvents BgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFolderDiag As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCancel As SignVerify.GUI.Controls.GlassButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
