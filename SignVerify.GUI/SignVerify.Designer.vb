<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignVerfiy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignVerfiy))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.plMenu = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.govilLbl = New System.Windows.Forms.ToolStripLabel()
        Me.btnShowCardDetails = New System.Windows.Forms.ToolStripButton()
        Me.SepCard = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSystemSettings = New System.Windows.Forms.ToolStripButton()
        Me.btnHelp = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnChangeLanguage = New System.Windows.Forms.ToolStripButton()
        Me.pnlSelectFile = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.plFiles = New System.Windows.Forms.Panel()
        Me.gvFiles = New SignVerify.GUI.FileList()
        Me.pnlVerify = New SignVerify.GUI.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlSign = New SignVerify.GUI.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSign = New SignVerify.GUI.Controls.GlassButton()
        Me.GlassButton2 = New SignVerify.GUI.Controls.GlassButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFiles = New SignVerify.GUI.RoundedButton()
        Me.btnCancel = New SignVerify.GUI.Controls.GlassButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnVerify = New SignVerify.GUI.Controls.GlassButton()
        Me.Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.About = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDiag = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BgWorker = New System.ComponentModel.BackgroundWorker()
        Me.SaveFolderDiag = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.plMenu.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.ToolStripButtons.SuspendLayout()
        Me.pnlSelectFile.SuspendLayout()
        Me.plFiles.SuspendLayout()
        Me.pnlVerify.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSign.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Controls.Add(Me.plMenu, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlSelectFile, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(660, 509)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'plMenu
        '
        Me.plMenu.BackgroundImage = CType(resources.GetObject("plMenu.BackgroundImage"), System.Drawing.Image)
        Me.TableLayoutPanel1.SetColumnSpan(Me.plMenu, 2)
        Me.plMenu.Controls.Add(Me.pnlHeader)
        Me.plMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plMenu.Location = New System.Drawing.Point(0, 0)
        Me.plMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.plMenu.Name = "plMenu"
        Me.plMenu.Size = New System.Drawing.Size(660, 46)
        Me.plMenu.TabIndex = 7
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.ToolStripButtons)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlHeader.Location = New System.Drawing.Point(0, 5)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(660, 41)
        Me.pnlHeader.TabIndex = 1
        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ToolStripButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripButtons.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.govilLbl, Me.btnShowCardDetails, Me.SepCard, Me.btnSystemSettings, Me.btnHelp, Me.btnChangeLanguage})
        Me.ToolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripButtons.Size = New System.Drawing.Size(660, 41)
        Me.ToolStripButtons.TabIndex = 0
        '
        'govilLbl
        '
        Me.govilLbl.AutoSize = False
        Me.govilLbl.BackgroundImage = CType(resources.GetObject("govilLbl.BackgroundImage"), System.Drawing.Image)
        Me.govilLbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.govilLbl.Margin = New System.Windows.Forms.Padding(10, 1, 5, 2)
        Me.govilLbl.Name = "govilLbl"
        Me.govilLbl.Size = New System.Drawing.Size(100, 38)
        '
        'btnShowCardDetails
        '
        Me.btnShowCardDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnShowCardDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowCardDetails.ForeColor = System.Drawing.Color.White
        Me.btnShowCardDetails.Image = CType(resources.GetObject("btnShowCardDetails.Image"), System.Drawing.Image)
        Me.btnShowCardDetails.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowCardDetails.Name = "btnShowCardDetails"
        Me.btnShowCardDetails.Size = New System.Drawing.Size(106, 38)
        Me.btnShowCardDetails.Text = "הצג פרטי משתמש"
        '
        'SepCard
        '
        Me.SepCard.Name = "SepCard"
        Me.SepCard.Size = New System.Drawing.Size(6, 41)
        '
        'btnSystemSettings
        '
        Me.btnSystemSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSystemSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemSettings.ForeColor = System.Drawing.Color.White
        Me.btnSystemSettings.Image = CType(resources.GetObject("btnSystemSettings.Image"), System.Drawing.Image)
        Me.btnSystemSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSystemSettings.Name = "btnSystemSettings"
        Me.btnSystemSettings.Size = New System.Drawing.Size(96, 38)
        Me.btnSystemSettings.Text = "הגדרות משתמש"
        '
        'btnHelp
        '
        Me.btnHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolItemHelp, Me.ToolItemAbout})
        Me.btnHelp.Enabled = False
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnHelp.ForeColor = System.Drawing.Color.White
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(67, 38)
        Me.btnHelp.Text = "עזרה"
        Me.btnHelp.Visible = False
        '
        'ToolItemHelp
        '
        Me.ToolItemHelp.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolItemHelp.Name = "ToolItemHelp"
        Me.ToolItemHelp.Size = New System.Drawing.Size(106, 22)
        Me.ToolItemHelp.Text = "עזרה"
        Me.ToolItemHelp.ToolTipText = "עזרה"
        '
        'ToolItemAbout
        '
        Me.ToolItemAbout.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolItemAbout.Name = "ToolItemAbout"
        Me.ToolItemAbout.Size = New System.Drawing.Size(106, 22)
        Me.ToolItemAbout.Text = "אודות"
        Me.ToolItemAbout.ToolTipText = "אודות"
        '
        'btnChangeLanguage
        '
        Me.btnChangeLanguage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnChangeLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnChangeLanguage.Enabled = False
        Me.btnChangeLanguage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnChangeLanguage.ForeColor = System.Drawing.Color.Black
        Me.btnChangeLanguage.Image = CType(resources.GetObject("btnChangeLanguage.Image"), System.Drawing.Image)
        Me.btnChangeLanguage.ImageTransparentColor = System.Drawing.Color.MediumAquamarine
        Me.btnChangeLanguage.Name = "btnChangeLanguage"
        Me.btnChangeLanguage.Size = New System.Drawing.Size(58, 38)
        Me.btnChangeLanguage.Text = "English"
        Me.btnChangeLanguage.Visible = False
        '
        'pnlSelectFile
        '
        Me.pnlSelectFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.pnlSelectFile, 2)
        Me.pnlSelectFile.Controls.Add(Me.Label2)
        Me.pnlSelectFile.Controls.Add(Me.plFiles)
        Me.pnlSelectFile.Controls.Add(Me.pnlVerify)
        Me.pnlSelectFile.Controls.Add(Me.pnlSign)
        Me.pnlSelectFile.Controls.Add(Me.btnSign)
        Me.pnlSelectFile.Controls.Add(Me.GlassButton2)
        Me.pnlSelectFile.Controls.Add(Me.Label3)
        Me.pnlSelectFile.Controls.Add(Me.btnFiles)
        Me.pnlSelectFile.Controls.Add(Me.btnCancel)
        Me.pnlSelectFile.Controls.Add(Me.ProgressBar1)
        Me.pnlSelectFile.Controls.Add(Me.btnVerify)
        Me.pnlSelectFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSelectFile.Location = New System.Drawing.Point(0, 46)
        Me.pnlSelectFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSelectFile.Name = "pnlSelectFile"
        Me.pnlSelectFile.Size = New System.Drawing.Size(660, 463)
        Me.pnlSelectFile.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gabriola", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(359, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 59)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "כלי חתימה ואימות"
        '
        'plFiles
        '
        Me.plFiles.AutoScroll = True
        Me.plFiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.plFiles.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.letter
        Me.plFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plFiles.Controls.Add(Me.gvFiles)
        Me.plFiles.Location = New System.Drawing.Point(9, 93)
        Me.plFiles.Name = "plFiles"
        Me.plFiles.Size = New System.Drawing.Size(636, 228)
        Me.plFiles.TabIndex = 24
        '
        'gvFiles
        '
        Me.gvFiles.AutoSize = True
        Me.gvFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gvFiles.BackColor = System.Drawing.Color.Transparent
        Me.gvFiles.ColumnCount = 1
        Me.gvFiles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.gvFiles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.gvFiles.DisplayTS = False
        Me.gvFiles.Location = New System.Drawing.Point(3, 3)
        Me.gvFiles.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.gvFiles.Name = "gvFiles"
        Me.gvFiles.Size = New System.Drawing.Size(0, 0)
        Me.gvFiles.TabIndex = 21
        '
        'pnlVerify
        '
        Me.pnlVerify.BackColor = System.Drawing.Color.White
        Me.pnlVerify.BorderColor = System.Drawing.Color.LightGray
        Me.pnlVerify.Controls.Add(Me.Label5)
        Me.pnlVerify.Controls.Add(Me.Label6)
        Me.pnlVerify.Controls.Add(Me.PictureBox2)
        Me.pnlVerify.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnlVerify.Edge = 20
        Me.pnlVerify.Location = New System.Drawing.Point(12, 341)
        Me.pnlVerify.Name = "pnlVerify"
        Me.pnlVerify.Size = New System.Drawing.Size(299, 57)
        Me.pnlVerify.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(126, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "אימות של קבצים"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "בדיקת החתימה על הקבצים הנבחרים"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(244, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'pnlSign
        '
        Me.pnlSign.BackColor = System.Drawing.Color.White
        Me.pnlSign.BorderColor = System.Drawing.Color.LightGray
        Me.pnlSign.Controls.Add(Me.Label1)
        Me.pnlSign.Controls.Add(Me.Label4)
        Me.pnlSign.Controls.Add(Me.PictureBox1)
        Me.pnlSign.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnlSign.Edge = 20
        Me.pnlSign.Location = New System.Drawing.Point(348, 341)
        Me.pnlSign.Name = "pnlSign"
        Me.pnlSign.Size = New System.Drawing.Size(299, 57)
        Me.pnlSign.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(126, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "חתימה על קבצים"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "הוספת חתימה על הקבצים הנבחרים"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(241, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnSign
        '
        Me.btnSign.BackColor = System.Drawing.Color.White
        Me.btnSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSign.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnSign.DisabledGlowColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnSign.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnSign.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnSign.GlowColor = System.Drawing.Color.White
        Me.btnSign.Image = CType(resources.GetObject("btnSign.Image"), System.Drawing.Image)
        Me.btnSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSign.Location = New System.Drawing.Point(113, 398)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.ShineColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSign.Size = New System.Drawing.Size(48, 36)
        Me.btnSign.TabIndex = 0
        Me.btnSign.Text = "חתימה על קבצים"
        Me.ToolTip1.SetToolTip(Me.btnSign, "חתום על הקובץ")
        Me.btnSign.Visible = False
        '
        'GlassButton2
        '
        Me.GlassButton2.BackColor = System.Drawing.SystemColors.ControlText
        Me.GlassButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GlassButton2.DisabledGlowColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GlassButton2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GlassButton2.ForeColor = System.Drawing.Color.White
        Me.GlassButton2.GlowColor = System.Drawing.Color.White
        Me.GlassButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GlassButton2.Location = New System.Drawing.Point(12, 405)
        Me.GlassButton2.Name = "GlassButton2"
        Me.GlassButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GlassButton2.ShineColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.GlassButton2.Size = New System.Drawing.Size(74, 29)
        Me.GlassButton2.TabIndex = 27
        Me.GlassButton2.Text = "נקה"
        Me.ToolTip1.SetToolTip(Me.GlassButton2, "בחר קובץ")
        Me.GlassButton2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.Location = New System.Drawing.Point(275, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(373, 17)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "לביצוע חתימה/אימות העלו את הקבצים הרלוונטים מהמחשב לכאן"
        '
        'btnFiles
        '
        Me.btnFiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnFiles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiles.ForeColor = System.Drawing.Color.White
        Me.btnFiles.Location = New System.Drawing.Point(12, 38)
        Me.btnFiles.Name = "btnFiles"
        Me.btnFiles.Size = New System.Drawing.Size(162, 40)
        Me.btnFiles.TabIndex = 29
        Me.btnFiles.Text = "העלאת קבצים"
        Me.btnFiles.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.DisabledGlowColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.GlowColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(563, 414)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.ShineColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "בטל"
        Me.btnCancel.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(252, 414)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(300, 20)
        Me.ProgressBar1.TabIndex = 27
        Me.ProgressBar1.Visible = False
        '
        'btnVerify
        '
        Me.btnVerify.BackColor = System.Drawing.SystemColors.ControlText
        Me.btnVerify.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnVerify.DisabledGlowColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnVerify.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnVerify.ForeColor = System.Drawing.Color.White
        Me.btnVerify.GlowColor = System.Drawing.Color.White
        Me.btnVerify.Image = Global.SignVerify.GUI.My.Resources.Resources.verifyBtn
        Me.btnVerify.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerify.Location = New System.Drawing.Point(191, 393)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.ShineColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnVerify.Size = New System.Drawing.Size(37, 41)
        Me.btnVerify.TabIndex = 1
        Me.btnVerify.Text = "אמת"
        Me.btnVerify.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnVerify, "אמת את הקובץ")
        Me.btnVerify.Visible = False
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
        'SignVerfiy
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.ClientSize = New System.Drawing.Size(660, 509)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SignVerfiy"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "אמת וחתום 2.0"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.plMenu.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ToolStripButtons.ResumeLayout(False)
        Me.ToolStripButtons.PerformLayout()
        Me.pnlSelectFile.ResumeLayout(False)
        Me.pnlSelectFile.PerformLayout()
        Me.plFiles.ResumeLayout(False)
        Me.plFiles.PerformLayout()
        Me.pnlVerify.ResumeLayout(False)
        Me.pnlVerify.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSign.ResumeLayout(False)
        Me.pnlSign.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSign As SignVerify.GUI.Controls.GlassButton
    Friend WithEvents btnVerify As SignVerify.GUI.Controls.GlassButton
    Friend WithEvents pnlSelectFile As System.Windows.Forms.Panel

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDiag As System.Windows.Forms.SaveFileDialog
    Friend WithEvents plMenu As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents btnShowCardDetails As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSystemSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolItemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolItemAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnChangeLanguage As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents SepCard As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gvFiles As SignVerify.GUI.FileList
    Friend WithEvents plFiles As System.Windows.Forms.Panel
    Friend WithEvents BgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFolderDiag As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCancel As SignVerify.GUI.Controls.GlassButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GlassButton2 As SignVerify.GUI.Controls.GlassButton
    Friend WithEvents govilLbl As ToolStripLabel
    Friend WithEvents btnFiles As RoundedButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlSign As RoundedPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlVerify As RoundedPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
