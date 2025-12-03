<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class successDiag
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
        Dim Panel6 As System.Windows.Forms.Panel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(successDiag))
        Dim pnlHeaderPanel As System.Windows.Forms.Panel
        Me.ToolStripcontainer = New System.Windows.Forms.ToolStripContainer()
        Me.lblVerifyResultHeader = New System.Windows.Forms.Label()
        Me.HelpToolStrip = New System.Windows.Forms.ToolStrip()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkEmail = New System.Windows.Forms.Label()
        Me.lnkSaveFile = New System.Windows.Forms.Label()
        Me.lnkSignaturesStatus = New System.Windows.Forms.Label()
        Me.lnkOpenDirectory = New System.Windows.Forms.Label()
        Me.pnlFileSave = New System.Windows.Forms.Panel()
        Me.lblFilePathName = New System.Windows.Forms.Label()
        Me.btnPicture = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSignStatus = New System.Windows.Forms.Label()
        Me.layoutOriginal = New System.Windows.Forms.FlowLayoutPanel()
        Me.pbPdf = New System.Windows.Forms.PictureBox()
        Me.lblOriginalFilePath = New System.Windows.Forms.Label()
        Me.lblOriginalFileHeader = New System.Windows.Forms.Label()
        Me.lblFileLocation = New System.Windows.Forms.Label()
        Me.pnlDottedLineMid = New System.Windows.Forms.Panel()
        Me.lblWhat = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlLowerPanel = New System.Windows.Forms.Panel()
        Me.btnOpenOriginalFile = New SignVerify.GUI.RoundedButton()
        Me.pnlLowDottedLine = New System.Windows.Forms.Panel()
        Me.OK_Button = New SignVerify.GUI.RoundedButton()
        Me.SaveOrigianlFile = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Panel6 = New System.Windows.Forms.Panel()
        pnlHeaderPanel = New System.Windows.Forms.Panel()
        Panel6.SuspendLayout()
        Me.ToolStripcontainer.ContentPanel.SuspendLayout()
        Me.ToolStripcontainer.SuspendLayout()
        Me.HelpToolStrip.SuspendLayout()
        pnlHeaderPanel.SuspendLayout()
        Me.pnlFileSave.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.layoutOriginal.SuspendLayout()
        CType(Me.pbPdf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlLowerPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Panel6.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Panel6.Controls.Add(Me.ToolStripcontainer)
        Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Panel6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Panel6.Location = New System.Drawing.Point(0, 0)
        Panel6.Margin = New System.Windows.Forms.Padding(0)
        Panel6.Name = "Panel6"
        Panel6.Size = New System.Drawing.Size(499, 34)
        Panel6.TabIndex = 6
        '
        'ToolStripcontainer
        '
        Me.ToolStripcontainer.BottomToolStripPanelVisible = False
        '
        'ToolStripcontainer.ContentPanel
        '
        Me.ToolStripcontainer.ContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ToolStripcontainer.ContentPanel.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.ToolStripcontainer.ContentPanel.Controls.Add(Me.lblVerifyResultHeader)
        Me.ToolStripcontainer.ContentPanel.Controls.Add(Me.HelpToolStrip)
        Me.ToolStripcontainer.ContentPanel.Size = New System.Drawing.Size(499, 35)
        Me.ToolStripcontainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripcontainer.LeftToolStripPanelVisible = False
        Me.ToolStripcontainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripcontainer.Name = "ToolStripcontainer"
        Me.ToolStripcontainer.RightToolStripPanelVisible = False
        Me.ToolStripcontainer.Size = New System.Drawing.Size(499, 35)
        Me.ToolStripcontainer.TabIndex = 0
        Me.ToolStripcontainer.Text = "ToolStripContainer1"
        '
        'ToolStripcontainer.TopToolStripPanel
        '
        Me.ToolStripcontainer.TopToolStripPanel.Padding = New System.Windows.Forms.Padding(0, 0, 25, 25)
        Me.ToolStripcontainer.TopToolStripPanelVisible = False
        '
        'lblVerifyResultHeader
        '
        Me.lblVerifyResultHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.lblVerifyResultHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblVerifyResultHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblVerifyResultHeader.ForeColor = System.Drawing.Color.White
        Me.lblVerifyResultHeader.Location = New System.Drawing.Point(355, 0)
        Me.lblVerifyResultHeader.Name = "lblVerifyResultHeader"
        Me.lblVerifyResultHeader.Size = New System.Drawing.Size(144, 35)
        Me.lblVerifyResultHeader.TabIndex = 1
        Me.lblVerifyResultHeader.Text = "úåöàåú áãé÷ú àéîåú"
        Me.lblVerifyResultHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.HelpToolStrip.Size = New System.Drawing.Size(499, 35)
        Me.HelpToolStrip.TabIndex = 2
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.HelpToolStripButton.Enabled = False
        Me.HelpToolStripButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HelpToolStripButton.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.Margin = New System.Windows.Forms.Padding(0)
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.HelpToolStripButton.Size = New System.Drawing.Size(55, 35)
        Me.HelpToolStripButton.Text = "עזרה"
        Me.HelpToolStripButton.Visible = False
        '
        'pnlHeaderPanel
        '
        pnlHeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        pnlHeaderPanel.Controls.Add(Me.Label3)
        pnlHeaderPanel.Controls.Add(Me.Label2)
        pnlHeaderPanel.Controls.Add(Me.Label1)
        pnlHeaderPanel.Controls.Add(Me.lnkEmail)
        pnlHeaderPanel.Controls.Add(Me.lnkSaveFile)
        pnlHeaderPanel.Controls.Add(Me.lnkSignaturesStatus)
        pnlHeaderPanel.Controls.Add(Me.lnkOpenDirectory)
        pnlHeaderPanel.Controls.Add(Me.pnlFileSave)
        pnlHeaderPanel.Controls.Add(Me.pnlDottedLineMid)
        pnlHeaderPanel.Controls.Add(Me.lblWhat)
        pnlHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        pnlHeaderPanel.Location = New System.Drawing.Point(0, 34)
        pnlHeaderPanel.Margin = New System.Windows.Forms.Padding(0)
        pnlHeaderPanel.Name = "pnlHeaderPanel"
        pnlHeaderPanel.Size = New System.Drawing.Size(499, 242)
        pnlHeaderPanel.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(214, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(9, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "|"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(316, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(9, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "|"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(415, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(9, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "|"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkEmail
        '
        Me.lnkEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkEmail.AutoSize = True
        Me.lnkEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lnkEmail.Location = New System.Drawing.Point(86, 213)
        Me.lnkEmail.Name = "lnkEmail"
        Me.lnkEmail.Size = New System.Drawing.Size(125, 16)
        Me.lnkEmail.TabIndex = 33
        Me.lnkEmail.Text = "ùìç ÷åáõ çúåí áãåà""ì"
        Me.ToolTip1.SetToolTip(Me.lnkEmail, "ùìç ÷åáõ çúåí áãåà""ì")
        '
        'lnkSaveFile
        '
        Me.lnkSaveFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSaveFile.AutoSize = True
        Me.lnkSaveFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lnkSaveFile.Location = New System.Drawing.Point(224, 213)
        Me.lnkSaveFile.Name = "lnkSaveFile"
        Me.lnkSaveFile.Size = New System.Drawing.Size(94, 16)
        Me.lnkSaveFile.TabIndex = 32
        Me.lnkSaveFile.Text = "שמור קובץ מקורי"
        Me.ToolTip1.SetToolTip(Me.lnkSaveFile, "שמור את הקובץ המקורי")
        '
        'lnkSignaturesStatus
        '
        Me.lnkSignaturesStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSignaturesStatus.AutoSize = True
        Me.lnkSignaturesStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lnkSignaturesStatus.Location = New System.Drawing.Point(328, 213)
        Me.lnkSignaturesStatus.Name = "lnkSignaturesStatus"
        Me.lnkSignaturesStatus.Size = New System.Drawing.Size(85, 16)
        Me.lnkSignaturesStatus.TabIndex = 31
        Me.lnkSignaturesStatus.Text = "ñèèåñ çúéîåú" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.lnkSignaturesStatus, "ôúç ñèèåñ çúéîåú")
        '
        'lnkOpenDirectory
        '
        Me.lnkOpenDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkOpenDirectory.AutoSize = True
        Me.lnkOpenDirectory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lnkOpenDirectory.Location = New System.Drawing.Point(425, 213)
        Me.lnkOpenDirectory.Name = "lnkOpenDirectory"
        Me.lnkOpenDirectory.Size = New System.Drawing.Size(75, 16)
        Me.lnkOpenDirectory.TabIndex = 30
        Me.lnkOpenDirectory.Text = "ôúç úé÷ééä"
        Me.ToolTip1.SetToolTip(Me.lnkOpenDirectory, "ôúç àú úé÷ééú ä÷åáõ äçúåí")
        '
        'pnlFileSave
        '
        Me.pnlFileSave.Controls.Add(Me.lblFilePathName)
        Me.pnlFileSave.Controls.Add(Me.btnPicture)
        Me.pnlFileSave.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlFileSave.Controls.Add(Me.layoutOriginal)
        Me.pnlFileSave.Controls.Add(Me.lblOriginalFileHeader)
        Me.pnlFileSave.Controls.Add(Me.lblFileLocation)
        Me.pnlFileSave.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFileSave.Location = New System.Drawing.Point(0, 0)
        Me.pnlFileSave.Name = "pnlFileSave"
        Me.pnlFileSave.Size = New System.Drawing.Size(499, 175)
        Me.pnlFileSave.TabIndex = 11
        '
        'lblFilePathName
        '
        Me.lblFilePathName.AutoEllipsis = True
        Me.lblFilePathName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblFilePathName.Location = New System.Drawing.Point(9, 134)
        Me.lblFilePathName.Name = "lblFilePathName"
        Me.lblFilePathName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFilePathName.Size = New System.Drawing.Size(475, 33)
        Me.lblFilePathName.TabIndex = 1
        Me.lblFilePathName.Text = "Label2"
        '
        'btnPicture
        '
        Me.btnPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPicture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPicture.Image = Global.SignVerify.GUI.My.Resources.Resources.SignGreen
        Me.btnPicture.Location = New System.Drawing.Point(451, 9)
        Me.btnPicture.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPicture.Name = "btnPicture"
        Me.btnPicture.Size = New System.Drawing.Size(33, 41)
        Me.btnPicture.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnPicture, "ôúç ñèèåñ çúéîåú")
        Me.btnPicture.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.lblSignStatus)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(425, 35)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'lblSignStatus
        '
        Me.lblSignStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSignStatus.AutoSize = True
        Me.lblSignStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSignStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSignStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSignStatus.ForeColor = System.Drawing.Color.Black
        Me.lblSignStatus.Location = New System.Drawing.Point(283, 0)
        Me.lblSignStatus.Name = "lblSignStatus"
        Me.lblSignStatus.Size = New System.Drawing.Size(139, 16)
        Me.lblSignStatus.TabIndex = 1
        Me.lblSignStatus.Text = "úåöàåú áãé÷ú àéîåú"
        '
        'layoutOriginal
        '
        Me.layoutOriginal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.layoutOriginal.AutoScroll = True
        Me.layoutOriginal.AutoSize = True
        Me.layoutOriginal.Controls.Add(Me.pbPdf)
        Me.layoutOriginal.Controls.Add(Me.lblOriginalFilePath)
        Me.layoutOriginal.Location = New System.Drawing.Point(12, 72)
        Me.layoutOriginal.Name = "layoutOriginal"
        Me.layoutOriginal.Size = New System.Drawing.Size(475, 36)
        Me.layoutOriginal.TabIndex = 4
        '
        'pbPdf
        '
        Me.pbPdf.Image = Global.SignVerify.GUI.My.Resources.Resources.pdfExtrasmall
        Me.pbPdf.Location = New System.Drawing.Point(447, 0)
        Me.pbPdf.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pbPdf.Name = "pbPdf"
        Me.pbPdf.Size = New System.Drawing.Size(25, 25)
        Me.pbPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPdf.TabIndex = 5
        Me.pbPdf.TabStop = False
        Me.pbPdf.Visible = False
        '
        'lblOriginalFilePath
        '
        Me.lblOriginalFilePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOriginalFilePath.AutoEllipsis = True
        Me.lblOriginalFilePath.AutoSize = True
        Me.lblOriginalFilePath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOriginalFilePath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblOriginalFilePath.Location = New System.Drawing.Point(395, 0)
        Me.lblOriginalFilePath.Name = "lblOriginalFilePath"
        Me.lblOriginalFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOriginalFilePath.Size = New System.Drawing.Size(46, 16)
        Me.lblOriginalFilePath.TabIndex = 3
        Me.lblOriginalFilePath.Text = "Label2"
        Me.lblOriginalFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOriginalFileHeader
        '
        Me.lblOriginalFileHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOriginalFileHeader.AutoSize = True
        Me.lblOriginalFileHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOriginalFileHeader.Location = New System.Drawing.Point(375, 50)
        Me.lblOriginalFileHeader.Name = "lblOriginalFileHeader"
        Me.lblOriginalFileHeader.Size = New System.Drawing.Size(114, 16)
        Me.lblOriginalFileHeader.TabIndex = 2
        Me.lblOriginalFileHeader.Text = "ùí ä÷åáõ äî÷åøé:"
        '
        'lblFileLocation
        '
        Me.lblFileLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileLocation.AutoSize = True
        Me.lblFileLocation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblFileLocation.Location = New System.Drawing.Point(361, 111)
        Me.lblFileLocation.Name = "lblFileLocation"
        Me.lblFileLocation.Size = New System.Drawing.Size(129, 16)
        Me.lblFileLocation.TabIndex = 0
        Me.lblFileLocation.Text = "îé÷åí  ä÷åáõ äçúåí:"
        '
        'pnlDottedLineMid
        '
        Me.pnlDottedLineMid.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.pnlDottedLineMid.Location = New System.Drawing.Point(9, 181)
        Me.pnlDottedLineMid.Name = "pnlDottedLineMid"
        Me.pnlDottedLineMid.Size = New System.Drawing.Size(475, 2)
        Me.pnlDottedLineMid.TabIndex = 28
        '
        'lblWhat
        '
        Me.lblWhat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWhat.AutoSize = True
        Me.lblWhat.Location = New System.Drawing.Point(358, 193)
        Me.lblWhat.Name = "lblWhat"
        Me.lblWhat.Size = New System.Drawing.Size(131, 16)
        Me.lblWhat.TabIndex = 20
        Me.lblWhat.Text = "îä áøöåðê ìòùåú ëòú?"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel2.Controls.Add(pnlHeaderPanel, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pnlLowerPanel, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Panel6, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(499, 311)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'pnlLowerPanel
        '
        Me.pnlLowerPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.pnlLowerPanel.Controls.Add(Me.btnOpenOriginalFile)
        Me.pnlLowerPanel.Controls.Add(Me.pnlLowDottedLine)
        Me.pnlLowerPanel.Controls.Add(Me.OK_Button)
        Me.pnlLowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLowerPanel.Location = New System.Drawing.Point(0, 276)
        Me.pnlLowerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLowerPanel.Name = "pnlLowerPanel"
        Me.pnlLowerPanel.Size = New System.Drawing.Size(499, 35)
        Me.pnlLowerPanel.TabIndex = 3
        '
        'btnOpenOriginalFile
        '
        Me.btnOpenOriginalFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenOriginalFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnOpenOriginalFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnOpenOriginalFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnOpenOriginalFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnOpenOriginalFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenOriginalFile.ForeColor = System.Drawing.SystemColors.Window
        Me.btnOpenOriginalFile.Location = New System.Drawing.Point(390, 6)
        Me.btnOpenOriginalFile.Name = "btnOpenOriginalFile"
        Me.btnOpenOriginalFile.Size = New System.Drawing.Size(103, 26)
        Me.btnOpenOriginalFile.TabIndex = 30
        Me.btnOpenOriginalFile.Text = "ôúç ÷åáõ î÷åøé"
        Me.ToolTip1.SetToolTip(Me.btnOpenOriginalFile, "ôúç ÷åáõ î÷åøé")
        Me.btnOpenOriginalFile.UseVisualStyleBackColor = False
        '
        'pnlLowDottedLine
        '
        Me.pnlLowDottedLine.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.pnlLowDottedLine.Location = New System.Drawing.Point(9, 0)
        Me.pnlLowDottedLine.Name = "pnlLowDottedLine"
        Me.pnlLowDottedLine.Size = New System.Drawing.Size(475, 2)
        Me.pnlLowDottedLine.TabIndex = 29
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.OK_Button.Location = New System.Drawing.Point(9, 6)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(55, 26)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "ñâåø"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "ñâåø àú äîñê")
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'successDiag
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.BoderBack
        Me.ClientSize = New System.Drawing.Size(499, 311)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "successDiag"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "àéùåø"
        Me.ToolTip1.SetToolTip(Me, "úåöàåú çúéîä")
        Panel6.ResumeLayout(False)
        Me.ToolStripcontainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripcontainer.ContentPanel.PerformLayout()
        Me.ToolStripcontainer.ResumeLayout(False)
        Me.ToolStripcontainer.PerformLayout()
        Me.HelpToolStrip.ResumeLayout(False)
        Me.HelpToolStrip.PerformLayout()
        pnlHeaderPanel.ResumeLayout(False)
        pnlHeaderPanel.PerformLayout()
        Me.pnlFileSave.ResumeLayout(False)
        Me.pnlFileSave.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.layoutOriginal.ResumeLayout(False)
        Me.layoutOriginal.PerformLayout()
        CType(Me.pbPdf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnlLowerPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SaveOrigianlFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlDottedLineMid As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWhat As System.Windows.Forms.Label
    Friend WithEvents pnlFileSave As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblSignStatus As System.Windows.Forms.Label
    Friend WithEvents lblFilePathName As System.Windows.Forms.Label
    Friend WithEvents layoutOriginal As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblOriginalFilePath As System.Windows.Forms.Label
    Friend WithEvents lblOriginalFileHeader As System.Windows.Forms.Label
    Friend WithEvents lblFileLocation As System.Windows.Forms.Label
    Friend WithEvents pnlLowerPanel As System.Windows.Forms.Panel
    Friend WithEvents pnlLowDottedLine As System.Windows.Forms.Panel
    Friend WithEvents OK_Button As RoundedButton
    Friend WithEvents ToolStripcontainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lblVerifyResultHeader As System.Windows.Forms.Label
    Friend WithEvents HelpToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPicture As System.Windows.Forms.Button
    Friend WithEvents btnOpenOriginalFile As RoundedButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lnkOpenDirectory As System.Windows.Forms.Label
    Friend WithEvents lnkSignaturesStatus As System.Windows.Forms.Label
    Friend WithEvents lnkSaveFile As System.Windows.Forms.Label
    Friend WithEvents lnkEmail As System.Windows.Forms.Label
    Friend WithEvents pbPdf As System.Windows.Forms.PictureBox

End Class
