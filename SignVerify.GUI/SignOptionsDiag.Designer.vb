<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignOptionsDiag
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignOptionsDiag))
        Me.RadioSame = New System.Windows.Forms.RadioButton()
        Me.btnBrowseDestinationFile = New System.Windows.Forms.Button()
        Me.RadioDifferent = New System.Windows.Forms.RadioButton()
        Me.tbDestinationFolder = New System.Windows.Forms.RichTextBox()
        Me.plCertificateName = New System.Windows.Forms.Panel()
        Me.picboxCertificateIcon = New System.Windows.Forms.PictureBox()
        Me.flowlayCertificateName = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCertificateName = New System.Windows.Forms.Label()
        Me.btnOpenCertDiag = New System.Windows.Forms.Button()
        Me.lblManyCertificates = New System.Windows.Forms.Label()
        Me.lblNoCertificate = New System.Windows.Forms.Label()
        Me.FolderBrowserSaveSigned = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlSelectFile = New System.Windows.Forms.Panel()
        Me.lblSavingType = New System.Windows.Forms.Label()
        Me.ddlSavingType = New System.Windows.Forms.ComboBox()
        Me.pnlSaveFile = New System.Windows.Forms.Panel()
        Me.picboxSaveFile = New System.Windows.Forms.PictureBox()
        Me.lblChooseHeader = New System.Windows.Forms.Label()
        Me.pnlSelectCert = New System.Windows.Forms.Panel()
        Me.pnlErrorMessage = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlCertificate = New System.Windows.Forms.Panel()
        Me.picBoxCertificate = New System.Windows.Forms.PictureBox()
        Me.lblChooseCert = New System.Windows.Forms.Label()
        Me.tipQuestionMark = New System.Windows.Forms.ToolTip(Me.components)
        Me.picBoxCosign = New System.Windows.Forms.PictureBox()
        Me.picBoxProfile = New System.Windows.Forms.PictureBox()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.layoutShowSignOption = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbShowSignOptions = New System.Windows.Forms.CheckBox()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.radioParallel = New System.Windows.Forms.RadioButton()
        Me.radioSerial = New System.Windows.Forms.RadioButton()
        Me.pnlCosignHeader = New System.Windows.Forms.Panel()
        Me.lblChooseCosign = New System.Windows.Forms.Label()
        Me.pnlCosignOptions = New System.Windows.Forms.Panel()
        Me.lnklblHistory = New System.Windows.Forms.Label()
        Me.lnkOpenOriginalFile = New System.Windows.Forms.Label()
        Me.flowlaySerial = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.flowLayParallel = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblParallel = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.pnlProfileHeader = New System.Windows.Forms.Panel()
        Me.lblSelectProfile = New System.Windows.Forms.Label()
        Me.ddlProfils = New System.Windows.Forms.ComboBox()
        Me.pnlProfile = New System.Windows.Forms.Panel()
        Me.lnklblProfile = New System.Windows.Forms.Label()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.HelpToolStrip = New System.Windows.Forms.ToolStrip()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAdvancedSettings = New System.Windows.Forms.Button()
        Me.plCertificateName.SuspendLayout()
        CType(Me.picboxCertificateIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flowlayCertificateName.SuspendLayout()
        Me.pnlSelectFile.SuspendLayout()
        Me.pnlSaveFile.SuspendLayout()
        CType(Me.picboxSaveFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectCert.SuspendLayout()
        Me.pnlErrorMessage.SuspendLayout()
        Me.pnlCertificate.SuspendLayout()
        CType(Me.picBoxCertificate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxCosign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.layoutShowSignOption.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCosignHeader.SuspendLayout()
        Me.pnlCosignOptions.SuspendLayout()
        Me.flowlaySerial.SuspendLayout()
        Me.flowLayParallel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProfileHeader.SuspendLayout()
        Me.pnlProfile.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.HelpToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioSame
        '
        Me.RadioSame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioSame.AutoSize = True
        Me.RadioSame.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.RadioSame.Location = New System.Drawing.Point(402, 45)
        Me.RadioSame.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioSame.Name = "RadioSame"
        Me.RadioSame.Size = New System.Drawing.Size(160, 19)
        Me.RadioSame.TabIndex = 26
        Me.RadioSame.TabStop = True
        Me.RadioSame.Text = "שמור בתיקיית הקובץ המקורי"
        Me.RadioSame.UseVisualStyleBackColor = True
        '
        'btnBrowseDestinationFile
        '
        Me.btnBrowseDestinationFile.Location = New System.Drawing.Point(25, 73)
        Me.btnBrowseDestinationFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseDestinationFile.Name = "btnBrowseDestinationFile"
        Me.btnBrowseDestinationFile.Size = New System.Drawing.Size(53, 24)
        Me.btnBrowseDestinationFile.TabIndex = 11
        Me.btnBrowseDestinationFile.Text = "עיון"
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, "חפש את הקובץ לחתימה \ אימות")
        Me.btnBrowseDestinationFile.UseVisualStyleBackColor = True
        '
        'RadioDifferent
        '
        Me.RadioDifferent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioDifferent.AutoSize = True
        Me.RadioDifferent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioDifferent.Location = New System.Drawing.Point(440, 76)
        Me.RadioDifferent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioDifferent.Name = "RadioDifferent"
        Me.RadioDifferent.Size = New System.Drawing.Size(121, 19)
        Me.RadioDifferent.TabIndex = 25
        Me.RadioDifferent.TabStop = True
        Me.RadioDifferent.Text = "שמור בתיקייה אחרת"
        Me.RadioDifferent.UseVisualStyleBackColor = True
        '
        'tbDestinationFolder
        '
        Me.tbDestinationFolder.BackColor = System.Drawing.SystemColors.Control
        Me.tbDestinationFolder.Location = New System.Drawing.Point(84, 72)
        Me.tbDestinationFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbDestinationFolder.Multiline = False
        Me.tbDestinationFolder.Name = "tbDestinationFolder"
        Me.tbDestinationFolder.ReadOnly = True
        Me.tbDestinationFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbDestinationFolder.Size = New System.Drawing.Size(329, 26)
        Me.tbDestinationFolder.TabIndex = 10
        Me.tbDestinationFolder.Text = "הקובץ כווץ לZIP שנחתם "
        '
        'plCertificateName
        '
        Me.plCertificateName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plCertificateName.BackColor = System.Drawing.Color.Transparent
        Me.plCertificateName.Controls.Add(Me.picboxCertificateIcon)
        Me.plCertificateName.Controls.Add(Me.flowlayCertificateName)
        Me.plCertificateName.Location = New System.Drawing.Point(137, 69)
        Me.plCertificateName.Margin = New System.Windows.Forms.Padding(0)
        Me.plCertificateName.Name = "plCertificateName"
        Me.plCertificateName.Padding = New System.Windows.Forms.Padding(1)
        Me.plCertificateName.Size = New System.Drawing.Size(432, 28)
        Me.plCertificateName.TabIndex = 5
        '
        'picboxCertificateIcon
        '
        Me.picboxCertificateIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.picboxCertificateIcon.Dock = System.Windows.Forms.DockStyle.Right
        Me.picboxCertificateIcon.Image = Global.SignVerify.GUI.My.Resources.Resources.certificate
        Me.picboxCertificateIcon.Location = New System.Drawing.Point(397, 1)
        Me.picboxCertificateIcon.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picboxCertificateIcon.Name = "picboxCertificateIcon"
        Me.picboxCertificateIcon.Size = New System.Drawing.Size(34, 26)
        Me.picboxCertificateIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxCertificateIcon.TabIndex = 5
        Me.picboxCertificateIcon.TabStop = False
        '
        'flowlayCertificateName
        '
        Me.flowlayCertificateName.Controls.Add(Me.lblCertificateName)
        Me.flowlayCertificateName.Location = New System.Drawing.Point(4, 6)
        Me.flowlayCertificateName.Name = "flowlayCertificateName"
        Me.flowlayCertificateName.Size = New System.Drawing.Size(384, 21)
        Me.flowlayCertificateName.TabIndex = 6
        '
        'lblCertificateName
        '
        Me.lblCertificateName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCertificateName.AutoSize = True
        Me.lblCertificateName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCertificateName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblCertificateName.Location = New System.Drawing.Point(336, 0)
        Me.lblCertificateName.Name = "lblCertificateName"
        Me.lblCertificateName.Size = New System.Drawing.Size(45, 13)
        Me.lblCertificateName.TabIndex = 4
        Me.lblCertificateName.Text = "Label3"
        Me.lblCertificateName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblCertificateName, "הצג פרטי תעודה")
        '
        'btnOpenCertDiag
        '
        Me.btnOpenCertDiag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnOpenCertDiag.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOpenCertDiag.Location = New System.Drawing.Point(25, 57)
        Me.btnOpenCertDiag.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOpenCertDiag.Name = "btnOpenCertDiag"
        Me.btnOpenCertDiag.Size = New System.Drawing.Size(85, 24)
        Me.btnOpenCertDiag.TabIndex = 2
        Me.btnOpenCertDiag.Text = "בחר תעודה"
        Me.ToolTip1.SetToolTip(Me.btnOpenCertDiag, "בחר תעודה לצורך החתימה")
        Me.btnOpenCertDiag.UseVisualStyleBackColor = True
        '
        'lblManyCertificates
        '
        Me.lblManyCertificates.AutoSize = True
        Me.lblManyCertificates.Location = New System.Drawing.Point(85, 0)
        Me.lblManyCertificates.Name = "lblManyCertificates"
        Me.lblManyCertificates.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblManyCertificates.Size = New System.Drawing.Size(339, 16)
        Me.lblManyCertificates.TabIndex = 0
        Me.lblManyCertificates.Text = "נמצאו מספר תעודות מתאימות לחתימה. אנא בחר תעודה לחתימה"
        Me.lblManyCertificates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNoCertificate
        '
        Me.lblNoCertificate.AutoSize = True
        Me.lblNoCertificate.ForeColor = System.Drawing.Color.Red
        Me.lblNoCertificate.Location = New System.Drawing.Point(120, 16)
        Me.lblNoCertificate.Name = "lblNoCertificate"
        Me.lblNoCertificate.Size = New System.Drawing.Size(304, 16)
        Me.lblNoCertificate.TabIndex = 5
        Me.lblNoCertificate.Text = " לא נמצאו תעודות לחתימה, בבקשה הוסף תעודה לחתימה."
        Me.lblNoCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.AutoSize = True
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblHeader.Location = New System.Drawing.Point(340, 10)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(228, 19)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "בחר כיצד ברצונך לחתום על הקובץ"
        '
        'pnlSelectFile
        '
        Me.pnlSelectFile.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectFile.Controls.Add(Me.lblSavingType)
        Me.pnlSelectFile.Controls.Add(Me.ddlSavingType)
        Me.pnlSelectFile.Controls.Add(Me.btnBrowseDestinationFile)
        Me.pnlSelectFile.Controls.Add(Me.RadioSame)
        Me.pnlSelectFile.Controls.Add(Me.tbDestinationFolder)
        Me.pnlSelectFile.Controls.Add(Me.RadioDifferent)
        Me.pnlSelectFile.Controls.Add(Me.pnlSaveFile)
        Me.pnlSelectFile.Location = New System.Drawing.Point(0, 39)
        Me.pnlSelectFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlSelectFile.Name = "pnlSelectFile"
        Me.pnlSelectFile.Size = New System.Drawing.Size(576, 148)
        Me.pnlSelectFile.TabIndex = 21
        '
        'lblSavingType
        '
        Me.lblSavingType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSavingType.AutoSize = True
        Me.lblSavingType.Location = New System.Drawing.Point(450, 116)
        Me.lblSavingType.Name = "lblSavingType"
        Me.lblSavingType.Size = New System.Drawing.Size(98, 16)
        Me.lblSavingType.TabIndex = 30
        Me.lblSavingType.Text = "אופן הכנת קבצים:"
        '
        'ddlSavingType
        '
        Me.ddlSavingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSavingType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ddlSavingType.FormattingEnabled = True
        Me.ddlSavingType.Items.AddRange(New Object() {"חתימת כל קובץ בנפרד", "כווץ הקבצים (ZIP) וחתימת הקובץ המכווץ ", "חתימת כל קובץ בנפרד וכווץ הקבצים החתומים לקובץ ZIP"})
        Me.ddlSavingType.Location = New System.Drawing.Point(84, 113)
        Me.ddlSavingType.Name = "ddlSavingType"
        Me.ddlSavingType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ddlSavingType.Size = New System.Drawing.Size(329, 24)
        Me.ddlSavingType.TabIndex = 29
        '
        'pnlSaveFile
        '
        Me.pnlSaveFile.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlSaveFile.Controls.Add(Me.picboxSaveFile)
        Me.pnlSaveFile.Controls.Add(Me.lblChooseHeader)
        Me.pnlSaveFile.Location = New System.Drawing.Point(6, 15)
        Me.pnlSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSaveFile.Name = "pnlSaveFile"
        Me.pnlSaveFile.Size = New System.Drawing.Size(563, 24)
        Me.pnlSaveFile.TabIndex = 2
        '
        'picboxSaveFile
        '
        Me.picboxSaveFile.BackColor = System.Drawing.Color.Transparent
        Me.picboxSaveFile.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picboxSaveFile.Location = New System.Drawing.Point(4, 2)
        Me.picboxSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxSaveFile.Name = "picboxSaveFile"
        Me.picboxSaveFile.Size = New System.Drawing.Size(20, 20)
        Me.picboxSaveFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxSaveFile.TabIndex = 0
        Me.picboxSaveFile.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picboxSaveFile, "בחר את המיקום בו אתה רוצה לשמור את הקובץ")
        '
        'lblChooseHeader
        '
        Me.lblChooseHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChooseHeader.AutoSize = True
        Me.lblChooseHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblChooseHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblChooseHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblChooseHeader.Location = New System.Drawing.Point(385, 5)
        Me.lblChooseHeader.Name = "lblChooseHeader"
        Me.lblChooseHeader.Size = New System.Drawing.Size(172, 15)
        Me.lblChooseHeader.TabIndex = 1
        Me.lblChooseHeader.Text = "הגדרת תיקייה לשמירת קובץ חתום"
        '
        'pnlSelectCert
        '
        Me.pnlSelectCert.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectCert.Controls.Add(Me.pnlErrorMessage)
        Me.pnlSelectCert.Controls.Add(Me.plCertificateName)
        Me.pnlSelectCert.Controls.Add(Me.btnOpenCertDiag)
        Me.pnlSelectCert.Controls.Add(Me.pnlCertificate)
        Me.pnlSelectCert.Location = New System.Drawing.Point(0, 183)
        Me.pnlSelectCert.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlSelectCert.Name = "pnlSelectCert"
        Me.pnlSelectCert.Size = New System.Drawing.Size(576, 97)
        Me.pnlSelectCert.TabIndex = 22
        '
        'pnlErrorMessage
        '
        Me.pnlErrorMessage.Controls.Add(Me.lblManyCertificates)
        Me.pnlErrorMessage.Controls.Add(Me.lblNoCertificate)
        Me.pnlErrorMessage.Location = New System.Drawing.Point(137, 37)
        Me.pnlErrorMessage.Name = "pnlErrorMessage"
        Me.pnlErrorMessage.Size = New System.Drawing.Size(427, 26)
        Me.pnlErrorMessage.TabIndex = 6
        '
        'pnlCertificate
        '
        Me.pnlCertificate.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlCertificate.Controls.Add(Me.picBoxCertificate)
        Me.pnlCertificate.Controls.Add(Me.lblChooseCert)
        Me.pnlCertificate.Location = New System.Drawing.Point(6, 10)
        Me.pnlCertificate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCertificate.Name = "pnlCertificate"
        Me.pnlCertificate.Size = New System.Drawing.Size(563, 24)
        Me.pnlCertificate.TabIndex = 2
        '
        'picBoxCertificate
        '
        Me.picBoxCertificate.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picBoxCertificate.Location = New System.Drawing.Point(4, 2)
        Me.picBoxCertificate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picBoxCertificate.Name = "picBoxCertificate"
        Me.picBoxCertificate.Size = New System.Drawing.Size(20, 20)
        Me.picBoxCertificate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoxCertificate.TabIndex = 2
        Me.picBoxCertificate.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picBoxCertificate, "בחר את התעודה איתה ברצונך לבצע את החתימה")
        '
        'lblChooseCert
        '
        Me.lblChooseCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChooseCert.AutoSize = True
        Me.lblChooseCert.BackColor = System.Drawing.Color.Transparent
        Me.lblChooseCert.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblChooseCert.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblChooseCert.Location = New System.Drawing.Point(414, 5)
        Me.lblChooseCert.Name = "lblChooseCert"
        Me.lblChooseCert.Size = New System.Drawing.Size(143, 15)
        Me.lblChooseCert.TabIndex = 1
        Me.lblChooseCert.Text = "בחר תעודה לביצוע החתימה:"
        '
        'tipQuestionMark
        '
        Me.tipQuestionMark.AutoPopDelay = 5000
        Me.tipQuestionMark.InitialDelay = 500
        Me.tipQuestionMark.IsBalloon = True
        Me.tipQuestionMark.ReshowDelay = 100
        Me.tipQuestionMark.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tipQuestionMark.ToolTipTitle = "עזרה"
        '
        'picBoxCosign
        '
        Me.picBoxCosign.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picBoxCosign.Location = New System.Drawing.Point(4, 2)
        Me.picBoxCosign.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picBoxCosign.Name = "picBoxCosign"
        Me.picBoxCosign.Size = New System.Drawing.Size(20, 20)
        Me.picBoxCosign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoxCosign.TabIndex = 2
        Me.picBoxCosign.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picBoxCosign, "בחר האם אתה רוצה לחתום את הקובץ החתום במקביל או באופן טורי")
        '
        'picBoxProfile
        '
        Me.picBoxProfile.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picBoxProfile.Location = New System.Drawing.Point(4, 2)
        Me.picBoxProfile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picBoxProfile.Name = "picBoxProfile"
        Me.picBoxProfile.Size = New System.Drawing.Size(20, 20)
        Me.picBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoxProfile.TabIndex = 2
        Me.picBoxProfile.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picBoxProfile, "בחר את הפרופיל בו אתה רוצה להשתמש לביצוע החתימה")
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.Transparent
        Me.pnlButton.Controls.Add(Me.layoutShowSignOption)
        Me.pnlButton.Controls.Add(Me.OK_Button)
        Me.pnlButton.Controls.Add(Me.Panel1)
        Me.pnlButton.Controls.Add(Me.Cancel_Button)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 539)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(576, 34)
        Me.pnlButton.TabIndex = 27
        '
        'layoutShowSignOption
        '
        Me.layoutShowSignOption.Controls.Add(Me.cbShowSignOptions)
        Me.layoutShowSignOption.Location = New System.Drawing.Point(402, 4)
        Me.layoutShowSignOption.Name = "layoutShowSignOption"
        Me.layoutShowSignOption.Size = New System.Drawing.Size(166, 26)
        Me.layoutShowSignOption.TabIndex = 28
        '
        'cbShowSignOptions
        '
        Me.cbShowSignOptions.AutoSize = True
        Me.cbShowSignOptions.Location = New System.Drawing.Point(29, 3)
        Me.cbShowSignOptions.Name = "cbShowSignOptions"
        Me.cbShowSignOptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbShowSignOptions.Size = New System.Drawing.Size(134, 20)
        Me.cbShowSignOptions.TabIndex = 23
        Me.cbShowSignOptions.Text = "אל תציג מסך זה יותר" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cbShowSignOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbShowSignOptions.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(9, 6)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(59, 24)
        Me.OK_Button.TabIndex = 26
        Me.OK_Button.Text = "חתום"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "חתום על הקובץ שנבחר")
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(13, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 2)
        Me.Panel1.TabIndex = 18
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel2.Location = New System.Drawing.Point(0, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 2)
        Me.Panel2.TabIndex = 19
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(74, 6)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(56, 24)
        Me.Cancel_Button.TabIndex = 25
        Me.Cancel_Button.Text = "בטל"
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, "בטל את פעולת החתימה")
        '
        'radioParallel
        '
        Me.radioParallel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radioParallel.AutoSize = True
        Me.radioParallel.Checked = True
        Me.radioParallel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.radioParallel.Location = New System.Drawing.Point(423, 51)
        Me.radioParallel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radioParallel.Name = "radioParallel"
        Me.radioParallel.Size = New System.Drawing.Size(138, 19)
        Me.radioParallel.TabIndex = 0
        Me.radioParallel.TabStop = True
        Me.radioParallel.Text = "חתימה במקביל לחתימה"
        Me.radioParallel.UseVisualStyleBackColor = True
        '
        'radioSerial
        '
        Me.radioSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radioSerial.AutoSize = True
        Me.radioSerial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.radioSerial.Location = New System.Drawing.Point(436, 105)
        Me.radioSerial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radioSerial.Name = "radioSerial"
        Me.radioSerial.Size = New System.Drawing.Size(123, 19)
        Me.radioSerial.TabIndex = 1
        Me.radioSerial.Text = "חתימה מעל לחתימה "
        Me.radioSerial.UseVisualStyleBackColor = True
        '
        'pnlCosignHeader
        '
        Me.pnlCosignHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlCosignHeader.Controls.Add(Me.picBoxCosign)
        Me.pnlCosignHeader.Controls.Add(Me.lblChooseCosign)
        Me.pnlCosignHeader.Location = New System.Drawing.Point(6, 10)
        Me.pnlCosignHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCosignHeader.Name = "pnlCosignHeader"
        Me.pnlCosignHeader.Size = New System.Drawing.Size(563, 24)
        Me.pnlCosignHeader.TabIndex = 2
        '
        'lblChooseCosign
        '
        Me.lblChooseCosign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChooseCosign.AutoSize = True
        Me.lblChooseCosign.BackColor = System.Drawing.Color.Transparent
        Me.lblChooseCosign.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblChooseCosign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblChooseCosign.Location = New System.Drawing.Point(412, 5)
        Me.lblChooseCosign.Name = "lblChooseCosign"
        Me.lblChooseCosign.Size = New System.Drawing.Size(145, 15)
        Me.lblChooseCosign.TabIndex = 1
        Me.lblChooseCosign.Text = "בחר הגדרות לחתימה נוספת:"
        '
        'pnlCosignOptions
        '
        Me.pnlCosignOptions.BackColor = System.Drawing.Color.Transparent
        Me.pnlCosignOptions.Controls.Add(Me.lnklblHistory)
        Me.pnlCosignOptions.Controls.Add(Me.lnkOpenOriginalFile)
        Me.pnlCosignOptions.Controls.Add(Me.flowlaySerial)
        Me.pnlCosignOptions.Controls.Add(Me.flowLayParallel)
        Me.pnlCosignOptions.Controls.Add(Me.Panel4)
        Me.pnlCosignOptions.Controls.Add(Me.Panel3)
        Me.pnlCosignOptions.Controls.Add(Me.PictureBox2)
        Me.pnlCosignOptions.Controls.Add(Me.PictureBox1)
        Me.pnlCosignOptions.Controls.Add(Me.lblSep)
        Me.pnlCosignOptions.Controls.Add(Me.pnlCosignHeader)
        Me.pnlCosignOptions.Controls.Add(Me.radioSerial)
        Me.pnlCosignOptions.Controls.Add(Me.radioParallel)
        Me.pnlCosignOptions.Location = New System.Drawing.Point(0, 378)
        Me.pnlCosignOptions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlCosignOptions.Name = "pnlCosignOptions"
        Me.pnlCosignOptions.Size = New System.Drawing.Size(576, 163)
        Me.pnlCosignOptions.TabIndex = 24
        '
        'lnklblHistory
        '
        Me.lnklblHistory.AutoSize = True
        Me.lnklblHistory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnklblHistory.Location = New System.Drawing.Point(379, 168)
        Me.lnklblHistory.Name = "lnklblHistory"
        Me.lnklblHistory.Size = New System.Drawing.Size(83, 16)
        Me.lnklblHistory.TabIndex = 24
        Me.lnklblHistory.Text = "סטטוס חתימות"
        Me.ToolTip1.SetToolTip(Me.lnklblHistory, "הצג את סטטוס חתימות עבור הקובץ שנבחר")
        '
        'lnkOpenOriginalFile
        '
        Me.lnkOpenOriginalFile.AutoSize = True
        Me.lnkOpenOriginalFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkOpenOriginalFile.Location = New System.Drawing.Point(472, 168)
        Me.lnkOpenOriginalFile.Name = "lnkOpenOriginalFile"
        Me.lnkOpenOriginalFile.Size = New System.Drawing.Size(90, 16)
        Me.lnkOpenOriginalFile.TabIndex = 23
        Me.lnkOpenOriginalFile.Text = "פתח קובץ מקורי"
        Me.ToolTip1.SetToolTip(Me.lnkOpenOriginalFile, "פתח את הקובץ המקורי")
        '
        'flowlaySerial
        '
        Me.flowlaySerial.Controls.Add(Me.lblSerial)
        Me.flowlaySerial.Location = New System.Drawing.Point(13, 133)
        Me.flowlaySerial.Name = "flowlaySerial"
        Me.flowlaySerial.Size = New System.Drawing.Size(493, 21)
        Me.flowlaySerial.TabIndex = 22
        '
        'lblSerial
        '
        Me.lblSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSerial.AutoSize = True
        Me.lblSerial.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSerial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSerial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSerial.Location = New System.Drawing.Point(214, 0)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(276, 16)
        Me.lblSerial.TabIndex = 15
        Me.lblSerial.Text = "חתימה מעל לחתימה היא חתימה נוספת ברמה נוספת"
        Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flowLayParallel
        '
        Me.flowLayParallel.Controls.Add(Me.lblParallel)
        Me.flowLayParallel.Location = New System.Drawing.Point(13, 75)
        Me.flowLayParallel.Name = "flowLayParallel"
        Me.flowLayParallel.Size = New System.Drawing.Size(490, 21)
        Me.flowLayParallel.TabIndex = 21
        '
        'lblParallel
        '
        Me.lblParallel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblParallel.AutoSize = True
        Me.lblParallel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblParallel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblParallel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblParallel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblParallel.Location = New System.Drawing.Point(198, 0)
        Me.lblParallel.Name = "lblParallel"
        Me.lblParallel.Size = New System.Drawing.Size(289, 16)
        Me.lblParallel.TabIndex = 13
        Me.lblParallel.Text = "חתימה במקביל לחתימה היא חתימה נוספת באותה רמה"
        Me.lblParallel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel4.Location = New System.Drawing.Point(13, 196)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(550, 2)
        Me.Panel4.TabIndex = 20
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel3.Location = New System.Drawing.Point(13, 163)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(550, 2)
        Me.Panel3.TabIndex = 19
        Me.Panel3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SignVerify.GUI.My.Resources.Resources.SignSerial
        Me.PictureBox2.Location = New System.Drawing.Point(512, 129)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 27)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SignVerify.GUI.My.Resources.Resources.SignParallel
        Me.PictureBox1.Location = New System.Drawing.Point(511, 76)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 20)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'lblSep
        '
        Me.lblSep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSep.AutoSize = True
        Me.lblSep.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSep.Location = New System.Drawing.Point(462, 170)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(9, 13)
        Me.lblSep.TabIndex = 12
        Me.lblSep.Text = "|"
        Me.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlProfileHeader
        '
        Me.pnlProfileHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlProfileHeader.Controls.Add(Me.picBoxProfile)
        Me.pnlProfileHeader.Controls.Add(Me.lblSelectProfile)
        Me.pnlProfileHeader.Location = New System.Drawing.Point(6, 10)
        Me.pnlProfileHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlProfileHeader.Name = "pnlProfileHeader"
        Me.pnlProfileHeader.Size = New System.Drawing.Size(563, 24)
        Me.pnlProfileHeader.TabIndex = 2
        '
        'lblSelectProfile
        '
        Me.lblSelectProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSelectProfile.AutoSize = True
        Me.lblSelectProfile.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectProfile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSelectProfile.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblSelectProfile.Location = New System.Drawing.Point(407, 5)
        Me.lblSelectProfile.Name = "lblSelectProfile"
        Me.lblSelectProfile.Size = New System.Drawing.Size(150, 15)
        Me.lblSelectProfile.TabIndex = 1
        Me.lblSelectProfile.Text = "בחר פרופיל הגדרות לחתימה: "
        '
        'ddlProfils
        '
        Me.ddlProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlProfils.FormattingEnabled = True
        Me.ddlProfils.Location = New System.Drawing.Point(184, 59)
        Me.ddlProfils.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddlProfils.Name = "ddlProfils"
        Me.ddlProfils.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ddlProfils.Size = New System.Drawing.Size(279, 24)
        Me.ddlProfils.TabIndex = 1
        '
        'pnlProfile
        '
        Me.pnlProfile.BackColor = System.Drawing.Color.Transparent
        Me.pnlProfile.Controls.Add(Me.btnAdvancedSettings)
        Me.pnlProfile.Controls.Add(Me.lnklblProfile)
        Me.pnlProfile.Controls.Add(Me.ddlProfils)
        Me.pnlProfile.Controls.Add(Me.pnlProfileHeader)
        Me.pnlProfile.Location = New System.Drawing.Point(0, 280)
        Me.pnlProfile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlProfile.Name = "pnlProfile"
        Me.pnlProfile.Size = New System.Drawing.Size(576, 98)
        Me.pnlProfile.TabIndex = 23
        '
        'lnklblProfile
        '
        Me.lnklblProfile.AutoSize = True
        Me.lnklblProfile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnklblProfile.Location = New System.Drawing.Point(516, 60)
        Me.lnklblProfile.Name = "lnklblProfile"
        Me.lnklblProfile.Size = New System.Drawing.Size(45, 16)
        Me.lnklblProfile.TabIndex = 20
        Me.lnklblProfile.Text = "פרופיל:"
        Me.ToolTip1.SetToolTip(Me.lnklblProfile, "הצג את פרטי הפרופיל שנבחר לחתימה")
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.Size = New System.Drawing.Size(576, 51)
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.ToolStripContainer1.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lblHeader)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.HelpToolStrip)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(576, 39)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(576, 39)
        Me.ToolStripContainer1.TabIndex = 28
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'HelpToolStrip
        '
        Me.HelpToolStrip.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.HelpToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HelpToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HelpToolStrip.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStrip.GripMargin = New System.Windows.Forms.Padding(0)
        Me.HelpToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.HelpToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.HelpToolStrip.Name = "HelpToolStrip"
        Me.HelpToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpToolStrip.ShowItemToolTips = False
        Me.HelpToolStrip.Size = New System.Drawing.Size(576, 39)
        Me.HelpToolStrip.TabIndex = 1
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.BackColor = System.Drawing.Color.Transparent
        Me.HelpToolStripButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HelpToolStripButton.ForeColor = System.Drawing.Color.DimGray
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.HelpToolStripButton.Margin = New System.Windows.Forms.Padding(0)
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.HelpToolStripButton.Size = New System.Drawing.Size(55, 39)
        Me.HelpToolStripButton.Text = "עזרה"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnAdvancedSettings
        '
        Me.btnAdvancedSettings.Location = New System.Drawing.Point(39, 60)
        Me.btnAdvancedSettings.Name = "btnAdvancedSettings"
        Me.btnAdvancedSettings.Size = New System.Drawing.Size(71, 24)
        Me.btnAdvancedSettings.TabIndex = 21
        Me.btnAdvancedSettings.Text = "הגדרות"
        Me.btnAdvancedSettings.UseVisualStyleBackColor = True
        Me.btnAdvancedSettings.Visible = False
        '
        'SignOptionsDiag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(576, 573)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.pnlSelectFile)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.pnlSelectCert)
        Me.Controls.Add(Me.pnlCosignOptions)
        Me.Controls.Add(Me.pnlProfile)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SignOptionsDiag"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "אפשרויות חתימה"
        Me.plCertificateName.ResumeLayout(False)
        CType(Me.picboxCertificateIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flowlayCertificateName.ResumeLayout(False)
        Me.flowlayCertificateName.PerformLayout()
        Me.pnlSelectFile.ResumeLayout(False)
        Me.pnlSelectFile.PerformLayout()
        Me.pnlSaveFile.ResumeLayout(False)
        Me.pnlSaveFile.PerformLayout()
        CType(Me.picboxSaveFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectCert.ResumeLayout(False)
        Me.pnlErrorMessage.ResumeLayout(False)
        Me.pnlErrorMessage.PerformLayout()
        Me.pnlCertificate.ResumeLayout(False)
        Me.pnlCertificate.PerformLayout()
        CType(Me.picBoxCertificate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxCosign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.layoutShowSignOption.ResumeLayout(False)
        Me.layoutShowSignOption.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlCosignHeader.ResumeLayout(False)
        Me.pnlCosignHeader.PerformLayout()
        Me.pnlCosignOptions.ResumeLayout(False)
        Me.pnlCosignOptions.PerformLayout()
        Me.flowlaySerial.ResumeLayout(False)
        Me.flowlaySerial.PerformLayout()
        Me.flowLayParallel.ResumeLayout(False)
        Me.flowLayParallel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProfileHeader.ResumeLayout(False)
        Me.pnlProfileHeader.PerformLayout()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.HelpToolStrip.ResumeLayout(False)
        Me.HelpToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBrowseDestinationFile As System.Windows.Forms.Button
    Friend WithEvents tbDestinationFolder As System.Windows.Forms.RichTextBox
    Friend WithEvents RadioSame As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDifferent As System.Windows.Forms.RadioButton
    Friend WithEvents lblManyCertificates As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserSaveSigned As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblCertificateName As System.Windows.Forms.Label
    Friend WithEvents btnOpenCertDiag As System.Windows.Forms.Button
    Friend WithEvents lblNoCertificate As System.Windows.Forms.Label
    Friend WithEvents plCertificateName As System.Windows.Forms.Panel
    Friend WithEvents picboxCertificateIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents pnlSelectFile As System.Windows.Forms.Panel
    Friend WithEvents pnlSaveFile As System.Windows.Forms.Panel
    Friend WithEvents lblChooseHeader As System.Windows.Forms.Label
    Friend WithEvents picboxSaveFile As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSelectCert As System.Windows.Forms.Panel
    Friend WithEvents pnlCertificate As System.Windows.Forms.Panel
    Friend WithEvents lblChooseCert As System.Windows.Forms.Label
    Friend WithEvents picBoxCertificate As System.Windows.Forms.PictureBox
    Friend WithEvents tipQuestionMark As System.Windows.Forms.ToolTip
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents radioParallel As System.Windows.Forms.RadioButton
    Friend WithEvents radioSerial As System.Windows.Forms.RadioButton
    Friend WithEvents pnlCosignHeader As System.Windows.Forms.Panel
    Friend WithEvents picBoxCosign As System.Windows.Forms.PictureBox
    Friend WithEvents lblChooseCosign As System.Windows.Forms.Label
    Friend WithEvents pnlCosignOptions As System.Windows.Forms.Panel
    Friend WithEvents pnlProfileHeader As System.Windows.Forms.Panel
    Friend WithEvents picBoxProfile As System.Windows.Forms.PictureBox
    Friend WithEvents lblSelectProfile As System.Windows.Forms.Label
    Friend WithEvents ddlProfils As System.Windows.Forms.ComboBox
    Friend WithEvents pnlProfile As System.Windows.Forms.Panel
    Friend WithEvents lblParallel As System.Windows.Forms.Label
    Friend WithEvents lblSep As System.Windows.Forms.Label
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents HelpToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents flowlayCertificateName As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlErrorMessage As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flowLayParallel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flowlaySerial As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lnklblProfile As System.Windows.Forms.Label
    Friend WithEvents lnkOpenOriginalFile As System.Windows.Forms.Label
    Friend WithEvents lnklblHistory As System.Windows.Forms.Label
    Friend WithEvents layoutShowSignOption As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbShowSignOptions As System.Windows.Forms.CheckBox
    Friend WithEvents lblSavingType As System.Windows.Forms.Label
    Friend WithEvents ddlSavingType As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdvancedSettings As System.Windows.Forms.Button

End Class
