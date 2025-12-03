
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDiag
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDiag))
        Me.FolderBrowserSaveSigned = New System.Windows.Forms.FolderBrowserDialog()
        Me.tipQuestionMark = New System.Windows.Forms.ToolTip(Me.components)
        Me.picboxSaveFile = New System.Windows.Forms.PictureBox()
        Me.picBoxProfile = New System.Windows.Forms.PictureBox()
        Me.picboxAdvanceSettingSign = New System.Windows.Forms.PictureBox()
        Me.picboxAdvanceSettingsVerify = New System.Windows.Forms.PictureBox()
        Me.pnlSelectFile = New System.Windows.Forms.Panel()
        Me.lblSavingType = New System.Windows.Forms.Label()
        Me.ddlSavingType = New System.Windows.Forms.ComboBox()
        Me.btnBrowseDestinationFile = New SignVerify.GUI.RoundedButton()
        Me.RadioSame = New System.Windows.Forms.RadioButton()
        Me.tbDestinationFolder = New System.Windows.Forms.RichTextBox()
        Me.RadioDifferent = New System.Windows.Forms.RadioButton()
        Me.pnlSaveFile = New System.Windows.Forms.Panel()
        Me.lblChooseHeader = New System.Windows.Forms.Label()
        Me.pnlProfile = New System.Windows.Forms.Panel()
        Me.btnAdvancedSettings = New SignVerify.GUI.RoundedButton()
        Me.lblProfile = New System.Windows.Forms.Label()
        Me.ddlProfils = New System.Windows.Forms.ComboBox()
        Me.pnlProfileHeader = New System.Windows.Forms.Panel()
        Me.lblSelectProfile = New System.Windows.Forms.Label()
        Me.pnlSignSettings = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbShowSignOptions = New System.Windows.Forms.CheckBox()
        Me.flowlayTS = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbCheckTimeStamp = New System.Windows.Forms.CheckBox()
        Me.flowlayNonRep = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbShowOnlyNonRepudiation = New System.Windows.Forms.CheckBox()
        Me.layoutTSURL = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblTSURL = New System.Windows.Forms.Label()
        Me.lblURL = New System.Windows.Forms.TextBox()
        Me.ddlSignAlgo = New System.Windows.Forms.ComboBox()
        Me.lblSigingAlgorithm = New System.Windows.Forms.Label()
        Me.pnlSignSettingsHeader = New System.Windows.Forms.Panel()
        Me.lblAdvancedSeetingsSign = New System.Windows.Forms.Label()
        Me.ddlProviders = New System.Windows.Forms.ComboBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.pnlVerifySettings = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanelcbCheckCRL = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbCheckCRL = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutCRL = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCRLExplain = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPath = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblPathExplain = New System.Windows.Forms.Label()
        Me.FlowLayoutTS = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblTSExplain = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel13 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel14 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanelcbDisplayTimeStamp = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbDisplayTimeStamp = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel10 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel11 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel12 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlVerifySettingsHeader = New System.Windows.Forms.Panel()
        Me.lblAdvanceSettingVerify = New System.Windows.Forms.Label()
        Me.FlowLayoutPanelcbVerifySignatureOnly = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbVerifySignatureOnly = New System.Windows.Forms.CheckBox()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.HelpButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cancel_Button = New SignVerify.GUI.RoundedButton()
        Me.OK_Button = New SignVerify.GUI.RoundedButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDottedLine = New System.Windows.Forms.Panel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        CType(Me.picboxSaveFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxAdvanceSettingSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxAdvanceSettingsVerify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectFile.SuspendLayout()
        Me.pnlSaveFile.SuspendLayout()
        Me.pnlProfile.SuspendLayout()
        Me.pnlProfileHeader.SuspendLayout()
        Me.pnlSignSettings.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.flowlayTS.SuspendLayout()
        Me.flowlayNonRep.SuspendLayout()
        Me.layoutTSURL.SuspendLayout()
        Me.pnlSignSettingsHeader.SuspendLayout()
        Me.pnlVerifySettings.SuspendLayout()
        Me.FlowLayoutPanelcbCheckCRL.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.FlowLayoutCRL.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPath.SuspendLayout()
        Me.FlowLayoutTS.SuspendLayout()
        Me.FlowLayoutPanel13.SuspendLayout()
        Me.FlowLayoutPanel14.SuspendLayout()
        Me.FlowLayoutPanelcbDisplayTimeStamp.SuspendLayout()
        Me.FlowLayoutPanel9.SuspendLayout()
        Me.FlowLayoutPanel10.SuspendLayout()
        Me.FlowLayoutPanel11.SuspendLayout()
        Me.FlowLayoutPanel12.SuspendLayout()
        Me.pnlVerifySettingsHeader.SuspendLayout()
        Me.FlowLayoutPanelcbVerifySignatureOnly.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tipQuestionMark
        '
        Me.tipQuestionMark.IsBalloon = True
        Me.tipQuestionMark.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tipQuestionMark.ToolTipTitle = "òæøä"
        '
        'picboxSaveFile
        '
        Me.picboxSaveFile.BackColor = System.Drawing.Color.Transparent
        Me.picboxSaveFile.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picboxSaveFile.Location = New System.Drawing.Point(4, 2)
        Me.picboxSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxSaveFile.Name = "picboxSaveFile"
        Me.picboxSaveFile.Size = New System.Drawing.Size(20, 21)
        Me.picboxSaveFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxSaveFile.TabIndex = 0
        Me.picboxSaveFile.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picboxSaveFile, "áçø àú äîé÷åí áå àúä øåöä ìùîåø àú ä÷åáõ")
        '
        'picBoxProfile
        '
        Me.picBoxProfile.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picBoxProfile.Location = New System.Drawing.Point(5, 2)
        Me.picBoxProfile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picBoxProfile.Name = "picBoxProfile"
        Me.picBoxProfile.Size = New System.Drawing.Size(20, 21)
        Me.picBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoxProfile.TabIndex = 2
        Me.picBoxProfile.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picBoxProfile, "áçø àú äôøåôéì áå àúä øåöä ìäùúîù ìáéöåò äçúéîä")
        '
        'picboxAdvanceSettingSign
        '
        Me.picboxAdvanceSettingSign.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picboxAdvanceSettingSign.Location = New System.Drawing.Point(5, 2)
        Me.picboxAdvanceSettingSign.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picboxAdvanceSettingSign.Name = "picboxAdvanceSettingSign"
        Me.picboxAdvanceSettingSign.Size = New System.Drawing.Size(20, 21)
        Me.picboxAdvanceSettingSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxAdvanceSettingSign.TabIndex = 2
        Me.picboxAdvanceSettingSign.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picboxAdvanceSettingSign, "áçø àú äâãøåú äçúéîä àéúí áøöåðê ìáöò çúéîä")
        '
        'picboxAdvanceSettingsVerify
        '
        Me.picboxAdvanceSettingsVerify.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picboxAdvanceSettingsVerify.Location = New System.Drawing.Point(5, -1)
        Me.picboxAdvanceSettingsVerify.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picboxAdvanceSettingsVerify.Name = "picboxAdvanceSettingsVerify"
        Me.picboxAdvanceSettingsVerify.Size = New System.Drawing.Size(20, 21)
        Me.picboxAdvanceSettingsVerify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxAdvanceSettingsVerify.TabIndex = 2
        Me.picboxAdvanceSettingsVerify.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picboxAdvanceSettingsVerify, "áçø àú äâãøåú äàéîåú àéúí áøöåðê ìáöò àéîåú")
        '
        'pnlSelectFile
        '
        Me.pnlSelectFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlSelectFile.Controls.Add(Me.lblSavingType)
        Me.pnlSelectFile.Controls.Add(Me.ddlSavingType)
        Me.pnlSelectFile.Controls.Add(Me.btnBrowseDestinationFile)
        Me.pnlSelectFile.Controls.Add(Me.RadioSame)
        Me.pnlSelectFile.Controls.Add(Me.tbDestinationFolder)
        Me.pnlSelectFile.Controls.Add(Me.RadioDifferent)
        Me.pnlSelectFile.Controls.Add(Me.pnlSaveFile)
        Me.pnlSelectFile.Location = New System.Drawing.Point(0, 31)
        Me.pnlSelectFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSelectFile.Name = "pnlSelectFile"
        Me.pnlSelectFile.Size = New System.Drawing.Size(583, 158)
        Me.pnlSelectFile.TabIndex = 22
        '
        'lblSavingType
        '
        Me.lblSavingType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSavingType.AutoSize = True
        Me.lblSavingType.Location = New System.Drawing.Point(457, 123)
        Me.lblSavingType.Name = "lblSavingType"
        Me.lblSavingType.Size = New System.Drawing.Size(103, 16)
        Me.lblSavingType.TabIndex = 28
        Me.lblSavingType.Text = "àåôï äëðú ÷áöéí:"
        Me.lblSavingType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ddlSavingType
        '
        Me.ddlSavingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSavingType.FormattingEnabled = True
        Me.ddlSavingType.Items.AddRange(New Object() {"חתימת כל קובץ בנפרד", "כווץ הקבצים (ZIP) וחתימת הקובץ המכווץ ", "חתימת כל קובץ בנפרד וכווץ הקבצים החתומים לקובץ ZIP"})
        Me.ddlSavingType.Location = New System.Drawing.Point(77, 119)
        Me.ddlSavingType.Name = "ddlSavingType"
        Me.ddlSavingType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ddlSavingType.Size = New System.Drawing.Size(344, 24)
        Me.ddlSavingType.TabIndex = 27
        '
        'btnBrowseDestinationFile
        '
        Me.btnBrowseDestinationFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnBrowseDestinationFile.FlatAppearance.BorderSize = 0
        Me.btnBrowseDestinationFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseDestinationFile.ForeColor = System.Drawing.SystemColors.Window
        Me.btnBrowseDestinationFile.Location = New System.Drawing.Point(17, 81)
        Me.btnBrowseDestinationFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseDestinationFile.Name = "btnBrowseDestinationFile"
        Me.btnBrowseDestinationFile.Size = New System.Drawing.Size(53, 26)
        Me.btnBrowseDestinationFile.TabIndex = 11
        Me.btnBrowseDestinationFile.Text = "עיון"
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, "çôù àú ä÷åáõ ìçúéîä \ àéîåú")
        Me.btnBrowseDestinationFile.UseVisualStyleBackColor = False
        '
        'RadioSame
        '
        Me.RadioSame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioSame.AutoSize = True
        Me.RadioSame.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.RadioSame.Location = New System.Drawing.Point(376, 51)
        Me.RadioSame.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioSame.Name = "RadioSame"
        Me.RadioSame.Size = New System.Drawing.Size(184, 20)
        Me.RadioSame.TabIndex = 26
        Me.RadioSame.TabStop = True
        Me.RadioSame.Text = "ùîåø áúé÷ééú ä÷åáõ äî÷åøé"
        Me.RadioSame.UseVisualStyleBackColor = True
        '
        'tbDestinationFolder
        '
        Me.tbDestinationFolder.BackColor = System.Drawing.SystemColors.Control
        Me.tbDestinationFolder.Location = New System.Drawing.Point(77, 81)
        Me.tbDestinationFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbDestinationFolder.Multiline = False
        Me.tbDestinationFolder.Name = "tbDestinationFolder"
        Me.tbDestinationFolder.ReadOnly = True
        Me.tbDestinationFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbDestinationFolder.Size = New System.Drawing.Size(344, 26)
        Me.tbDestinationFolder.TabIndex = 10
        Me.tbDestinationFolder.Text = ""
        '
        'RadioDifferent
        '
        Me.RadioDifferent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioDifferent.AutoSize = True
        Me.RadioDifferent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioDifferent.Location = New System.Drawing.Point(425, 83)
        Me.RadioDifferent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioDifferent.Name = "RadioDifferent"
        Me.RadioDifferent.Size = New System.Drawing.Size(135, 20)
        Me.RadioDifferent.TabIndex = 25
        Me.RadioDifferent.TabStop = True
        Me.RadioDifferent.Text = "ùîåø áúé÷ééä àçøú"
        Me.RadioDifferent.UseVisualStyleBackColor = True
        '
        'pnlSaveFile
        '
        Me.pnlSaveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSaveFile.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSaveFile.Controls.Add(Me.picboxSaveFile)
        Me.pnlSaveFile.Controls.Add(Me.lblChooseHeader)
        Me.pnlSaveFile.Location = New System.Drawing.Point(7, 12)
        Me.pnlSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSaveFile.Name = "pnlSaveFile"
        Me.pnlSaveFile.Size = New System.Drawing.Size(563, 24)
        Me.pnlSaveFile.TabIndex = 2
        '
        'lblChooseHeader
        '
        Me.lblChooseHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChooseHeader.AutoSize = True
        Me.lblChooseHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblChooseHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblChooseHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblChooseHeader.Location = New System.Drawing.Point(403, 4)
        Me.lblChooseHeader.Name = "lblChooseHeader"
        Me.lblChooseHeader.Size = New System.Drawing.Size(154, 15)
        Me.lblChooseHeader.TabIndex = 1
        Me.lblChooseHeader.Text = "הגדרות להכנת קבצים חתומים:"
        '
        'pnlProfile
        '
        Me.pnlProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlProfile.Controls.Add(Me.btnAdvancedSettings)
        Me.pnlProfile.Controls.Add(Me.lblProfile)
        Me.pnlProfile.Controls.Add(Me.ddlProfils)
        Me.pnlProfile.Controls.Add(Me.pnlProfileHeader)
        Me.pnlProfile.Location = New System.Drawing.Point(0, 188)
        Me.pnlProfile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlProfile.Name = "pnlProfile"
        Me.pnlProfile.Size = New System.Drawing.Size(581, 98)
        Me.pnlProfile.TabIndex = 24
        '
        'btnAdvancedSettings
        '
        Me.btnAdvancedSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnAdvancedSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdvancedSettings.ForeColor = System.Drawing.SystemColors.Window
        Me.btnAdvancedSettings.Location = New System.Drawing.Point(112, 59)
        Me.btnAdvancedSettings.Name = "btnAdvancedSettings"
        Me.btnAdvancedSettings.Size = New System.Drawing.Size(71, 26)
        Me.btnAdvancedSettings.TabIndex = 18
        Me.btnAdvancedSettings.Text = "äâãøåú"
        Me.btnAdvancedSettings.UseVisualStyleBackColor = False
        Me.btnAdvancedSettings.Visible = False
        '
        'lblProfile
        '
        Me.lblProfile.AutoSize = True
        Me.lblProfile.Location = New System.Drawing.Point(508, 59)
        Me.lblProfile.Name = "lblProfile"
        Me.lblProfile.Size = New System.Drawing.Size(45, 16)
        Me.lblProfile.TabIndex = 17
        Me.lblProfile.Text = "פרופיל:"
        '
        'ddlProfils
        '
        Me.ddlProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlProfils.FormattingEnabled = True
        Me.ddlProfils.Location = New System.Drawing.Point(189, 59)
        Me.ddlProfils.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ddlProfils.Name = "ddlProfils"
        Me.ddlProfils.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ddlProfils.Size = New System.Drawing.Size(245, 24)
        Me.ddlProfils.TabIndex = 1
        '
        'pnlProfileHeader
        '
        Me.pnlProfileHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProfileHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlProfileHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlProfileHeader.Controls.Add(Me.picBoxProfile)
        Me.pnlProfileHeader.Controls.Add(Me.lblSelectProfile)
        Me.pnlProfileHeader.Location = New System.Drawing.Point(5, 13)
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
        Me.lblSelectProfile.Size = New System.Drawing.Size(147, 15)
        Me.lblSelectProfile.TabIndex = 1
        Me.lblSelectProfile.Text = "בחר פרופיל הגדרות לחתימה:"
        '
        'pnlSignSettings
        '
        Me.pnlSignSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlSignSettings.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlSignSettings.Controls.Add(Me.flowlayTS)
        Me.pnlSignSettings.Controls.Add(Me.flowlayNonRep)
        Me.pnlSignSettings.Controls.Add(Me.layoutTSURL)
        Me.pnlSignSettings.Controls.Add(Me.ddlSignAlgo)
        Me.pnlSignSettings.Controls.Add(Me.lblSigingAlgorithm)
        Me.pnlSignSettings.Controls.Add(Me.pnlSignSettingsHeader)
        Me.pnlSignSettings.Controls.Add(Me.ddlProviders)
        Me.pnlSignSettings.Controls.Add(Me.lblFormat)
        Me.pnlSignSettings.Location = New System.Drawing.Point(0, 284)
        Me.pnlSignSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSignSettings.Name = "pnlSignSettings"
        Me.pnlSignSettings.Size = New System.Drawing.Size(580, 249)
        Me.pnlSignSettings.TabIndex = 25
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.cbShowSignOptions)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(98, 151)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(451, 26)
        Me.FlowLayoutPanel1.TabIndex = 27
        '
        'cbShowSignOptions
        '
        Me.cbShowSignOptions.AutoSize = True
        Me.cbShowSignOptions.Location = New System.Drawing.Point(220, 3)
        Me.cbShowSignOptions.Name = "cbShowSignOptions"
        Me.cbShowSignOptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbShowSignOptions.Size = New System.Drawing.Size(228, 20)
        Me.cbShowSignOptions.TabIndex = 23
        Me.cbShowSignOptions.Text = "äöâ îñê àôùøåéåú çúéîä áæîï çúéîä" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cbShowSignOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbShowSignOptions.UseVisualStyleBackColor = True
        '
        'flowlayTS
        '
        Me.flowlayTS.Controls.Add(Me.cbCheckTimeStamp)
        Me.flowlayTS.Location = New System.Drawing.Point(98, 182)
        Me.flowlayTS.Name = "flowlayTS"
        Me.flowlayTS.Size = New System.Drawing.Size(452, 28)
        Me.flowlayTS.TabIndex = 26
        '
        'cbCheckTimeStamp
        '
        Me.cbCheckTimeStamp.AutoSize = True
        Me.cbCheckTimeStamp.Enabled = False
        Me.cbCheckTimeStamp.Location = New System.Drawing.Point(323, 3)
        Me.cbCheckTimeStamp.Name = "cbCheckTimeStamp"
        Me.cbCheckTimeStamp.Size = New System.Drawing.Size(126, 20)
        Me.cbCheckTimeStamp.TabIndex = 21
        Me.cbCheckTimeStamp.Text = "äåñó çúéîä òì æîï"
        Me.cbCheckTimeStamp.UseVisualStyleBackColor = True
        '
        'flowlayNonRep
        '
        Me.flowlayNonRep.Controls.Add(Me.cbShowOnlyNonRepudiation)
        Me.flowlayNonRep.Location = New System.Drawing.Point(98, 120)
        Me.flowlayNonRep.Name = "flowlayNonRep"
        Me.flowlayNonRep.Size = New System.Drawing.Size(451, 26)
        Me.flowlayNonRep.TabIndex = 25
        '
        'cbShowOnlyNonRepudiation
        '
        Me.cbShowOnlyNonRepudiation.AutoSize = True
        Me.cbShowOnlyNonRepudiation.Location = New System.Drawing.Point(287, 3)
        Me.cbShowOnlyNonRepudiation.Name = "cbShowOnlyNonRepudiation"
        Me.cbShowOnlyNonRepudiation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbShowOnlyNonRepudiation.Size = New System.Drawing.Size(161, 20)
        Me.cbShowOnlyNonRepudiation.TabIndex = 23
        Me.cbShowOnlyNonRepudiation.Text = "äöâ ø÷ úòåãåú îàåùøåú"
        Me.cbShowOnlyNonRepudiation.UseVisualStyleBackColor = True
        '
        'layoutTSURL
        '
        Me.layoutTSURL.Controls.Add(Me.lblTSURL)
        Me.layoutTSURL.Controls.Add(Me.lblURL)
        Me.layoutTSURL.Location = New System.Drawing.Point(98, 216)
        Me.layoutTSURL.Name = "layoutTSURL"
        Me.layoutTSURL.Size = New System.Drawing.Size(452, 23)
        Me.layoutTSURL.TabIndex = 24
        '
        'lblTSURL
        '
        Me.lblTSURL.AutoSize = True
        Me.lblTSURL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTSURL.Location = New System.Drawing.Point(357, 0)
        Me.lblTSURL.Name = "lblTSURL"
        Me.lblTSURL.Size = New System.Drawing.Size(92, 16)
        Me.lblTSURL.TabIndex = 0
        Me.lblTSURL.Text = "כתובת שרת זמן:"
        '
        'lblURL
        '
        Me.lblURL.Enabled = False
        Me.lblURL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblURL.Location = New System.Drawing.Point(17, 3)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(334, 22)
        Me.lblURL.TabIndex = 1
        Me.lblURL.Text = "URL"
        '
        'ddlSignAlgo
        '
        Me.ddlSignAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSignAlgo.FormattingEnabled = True
        Me.ddlSignAlgo.Items.AddRange(New Object() {"RSA"})
        Me.ddlSignAlgo.Location = New System.Drawing.Point(188, 90)
        Me.ddlSignAlgo.Name = "ddlSignAlgo"
        Me.ddlSignAlgo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ddlSignAlgo.Size = New System.Drawing.Size(245, 24)
        Me.ddlSignAlgo.TabIndex = 18
        '
        'lblSigingAlgorithm
        '
        Me.lblSigingAlgorithm.AutoSize = True
        Me.lblSigingAlgorithm.Location = New System.Drawing.Point(454, 92)
        Me.lblSigingAlgorithm.Name = "lblSigingAlgorithm"
        Me.lblSigingAlgorithm.Size = New System.Drawing.Size(95, 16)
        Me.lblSigingAlgorithm.TabIndex = 19
        Me.lblSigingAlgorithm.Text = "àìâåøéúí çúéîä:"
        '
        'pnlSignSettingsHeader
        '
        Me.pnlSignSettingsHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSignSettingsHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlSignSettingsHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSignSettingsHeader.Controls.Add(Me.picboxAdvanceSettingSign)
        Me.pnlSignSettingsHeader.Controls.Add(Me.lblAdvancedSeetingsSign)
        Me.pnlSignSettingsHeader.Location = New System.Drawing.Point(4, 9)
        Me.pnlSignSettingsHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSignSettingsHeader.Name = "pnlSignSettingsHeader"
        Me.pnlSignSettingsHeader.Size = New System.Drawing.Size(563, 24)
        Me.pnlSignSettingsHeader.TabIndex = 2
        '
        'lblAdvancedSeetingsSign
        '
        Me.lblAdvancedSeetingsSign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdvancedSeetingsSign.AutoSize = True
        Me.lblAdvancedSeetingsSign.BackColor = System.Drawing.Color.Transparent
        Me.lblAdvancedSeetingsSign.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblAdvancedSeetingsSign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblAdvancedSeetingsSign.Location = New System.Drawing.Point(416, 5)
        Me.lblAdvancedSeetingsSign.Name = "lblAdvancedSeetingsSign"
        Me.lblAdvancedSeetingsSign.Size = New System.Drawing.Size(141, 15)
        Me.lblAdvancedSeetingsSign.TabIndex = 1
        Me.lblAdvancedSeetingsSign.Text = "הגדרות מתקדמות לחתימה:"
        '
        'ddlProviders
        '
        Me.ddlProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlProviders.FormattingEnabled = True
        Me.ddlProviders.Location = New System.Drawing.Point(188, 51)
        Me.ddlProviders.Name = "ddlProviders"
        Me.ddlProviders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ddlProviders.Size = New System.Drawing.Size(245, 24)
        Me.ddlProviders.TabIndex = 12
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(522, 54)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(30, 16)
        Me.lblFormat.TabIndex = 16
        Me.lblFormat.Text = "תקן:"
        '
        'pnlVerifySettings
        '
        Me.pnlVerifySettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutPanelcbCheckCRL)
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutCRL)
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutPath)
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutTS)
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutPanelcbDisplayTimeStamp)
        Me.pnlVerifySettings.Controls.Add(Me.pnlVerifySettingsHeader)
        Me.pnlVerifySettings.Controls.Add(Me.FlowLayoutPanelcbVerifySignatureOnly)
        Me.pnlVerifySettings.Location = New System.Drawing.Point(0, 533)
        Me.pnlVerifySettings.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlVerifySettings.Name = "pnlVerifySettings"
        Me.pnlVerifySettings.Size = New System.Drawing.Size(584, 200)
        Me.pnlVerifySettings.TabIndex = 27
        '
        'FlowLayoutPanelcbCheckCRL
        '
        Me.FlowLayoutPanelcbCheckCRL.Controls.Add(Me.cbCheckCRL)
        Me.FlowLayoutPanelcbCheckCRL.Controls.Add(Me.FlowLayoutPanel4)
        Me.FlowLayoutPanelcbCheckCRL.Controls.Add(Me.FlowLayoutPanel5)
        Me.FlowLayoutPanelcbCheckCRL.Location = New System.Drawing.Point(107, 92)
        Me.FlowLayoutPanelcbCheckCRL.Name = "FlowLayoutPanelcbCheckCRL"
        Me.FlowLayoutPanelcbCheckCRL.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanelcbCheckCRL.TabIndex = 34
        '
        'cbCheckCRL
        '
        Me.cbCheckCRL.AutoSize = True
        Me.cbCheckCRL.Location = New System.Drawing.Point(359, 3)
        Me.cbCheckCRL.Name = "cbCheckCRL"
        Me.cbCheckCRL.Size = New System.Drawing.Size(84, 20)
        Me.cbCheckCRL.TabIndex = 25
        Me.cbCheckCRL.Text = "áãå÷ CRL"
        Me.cbCheckCRL.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.CheckBox2)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(-3, 29)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel4.TabIndex = 36
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox2.TabIndex = 25
        Me.CheckBox2.Text = "áãå÷ CRL"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel5.Controls.Add(Me.FlowLayoutPanel6)
        Me.FlowLayoutPanel5.Controls.Add(Me.FlowLayoutPanel7)
        Me.FlowLayoutPanel5.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(-3, 59)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel5.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(406, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "CRL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.CheckBox3)
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(-3, 19)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel6.TabIndex = 36
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox3.TabIndex = 25
        Me.CheckBox3.Text = "áãå÷ CRL"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel7.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(-3, 49)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel7.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(406, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "CRL:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutCRL
        '
        Me.FlowLayoutCRL.Controls.Add(Me.lblCRLExplain)
        Me.FlowLayoutCRL.Controls.Add(Me.FlowLayoutPanel2)
        Me.FlowLayoutCRL.Controls.Add(Me.FlowLayoutPanel3)
        Me.FlowLayoutCRL.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutCRL.Location = New System.Drawing.Point(107, 122)
        Me.FlowLayoutCRL.Name = "FlowLayoutCRL"
        Me.FlowLayoutCRL.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutCRL.TabIndex = 32
        '
        'lblCRLExplain
        '
        Me.lblCRLExplain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCRLExplain.AutoSize = True
        Me.lblCRLExplain.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCRLExplain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblCRLExplain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblCRLExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCRLExplain.Location = New System.Drawing.Point(406, 0)
        Me.lblCRLExplain.Name = "lblCRLExplain"
        Me.lblCRLExplain.Size = New System.Drawing.Size(37, 16)
        Me.lblCRLExplain.TabIndex = 30
        Me.lblCRLExplain.Text = "CRL:"
        Me.lblCRLExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.CheckBox1)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(-3, 19)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel2.TabIndex = 36
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox1.TabIndex = 25
        Me.CheckBox1.Text = "áãå÷ CRL"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(-3, 49)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel3.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(406, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "CRL:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPath
        '
        Me.FlowLayoutPath.Controls.Add(Me.lblPathExplain)
        Me.FlowLayoutPath.Location = New System.Drawing.Point(107, 64)
        Me.FlowLayoutPath.Name = "FlowLayoutPath"
        Me.FlowLayoutPath.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPath.TabIndex = 31
        '
        'lblPathExplain
        '
        Me.lblPathExplain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPathExplain.AutoSize = True
        Me.lblPathExplain.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPathExplain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblPathExplain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblPathExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPathExplain.Location = New System.Drawing.Point(373, 0)
        Me.lblPathExplain.Name = "lblPathExplain"
        Me.lblPathExplain.Size = New System.Drawing.Size(70, 16)
        Me.lblPathExplain.TabIndex = 28
        Me.lblPathExplain.Text = "îñìåì úòåãä"
        Me.lblPathExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutTS
        '
        Me.FlowLayoutTS.Controls.Add(Me.lblTSExplain)
        Me.FlowLayoutTS.Controls.Add(Me.FlowLayoutPanel13)
        Me.FlowLayoutTS.Controls.Add(Me.FlowLayoutPanel14)
        Me.FlowLayoutTS.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutTS.Location = New System.Drawing.Point(108, 175)
        Me.FlowLayoutTS.Name = "FlowLayoutTS"
        Me.FlowLayoutTS.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutTS.TabIndex = 37
        '
        'lblTSExplain
        '
        Me.lblTSExplain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTSExplain.AutoSize = True
        Me.lblTSExplain.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTSExplain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblTSExplain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTSExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTSExplain.Location = New System.Drawing.Point(195, 0)
        Me.lblTSExplain.Name = "lblTSExplain"
        Me.lblTSExplain.Size = New System.Drawing.Size(248, 16)
        Me.lblTSExplain.TabIndex = 30
        Me.lblTSExplain.Text = "áãå÷ ùäæîï ùáå áåöòä äçúéîä ðîöà áçúéîä"
        Me.lblTSExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel13
        '
        Me.FlowLayoutPanel13.Controls.Add(Me.CheckBox4)
        Me.FlowLayoutPanel13.Location = New System.Drawing.Point(-3, 19)
        Me.FlowLayoutPanel13.Name = "FlowLayoutPanel13"
        Me.FlowLayoutPanel13.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel13.TabIndex = 36
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox4.TabIndex = 25
        Me.CheckBox4.Text = "áãå÷ CRL"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel14
        '
        Me.FlowLayoutPanel14.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel14.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel14.Location = New System.Drawing.Point(-3, 49)
        Me.FlowLayoutPanel14.Name = "FlowLayoutPanel14"
        Me.FlowLayoutPanel14.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel14.TabIndex = 35
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(406, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "CRL:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanelcbDisplayTimeStamp
        '
        Me.FlowLayoutPanelcbDisplayTimeStamp.Controls.Add(Me.cbDisplayTimeStamp)
        Me.FlowLayoutPanelcbDisplayTimeStamp.Controls.Add(Me.FlowLayoutPanel9)
        Me.FlowLayoutPanelcbDisplayTimeStamp.Controls.Add(Me.FlowLayoutPanel10)
        Me.FlowLayoutPanelcbDisplayTimeStamp.Location = New System.Drawing.Point(108, 147)
        Me.FlowLayoutPanelcbDisplayTimeStamp.Name = "FlowLayoutPanelcbDisplayTimeStamp"
        Me.FlowLayoutPanelcbDisplayTimeStamp.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanelcbDisplayTimeStamp.TabIndex = 37
        '
        'cbDisplayTimeStamp
        '
        Me.cbDisplayTimeStamp.AutoSize = True
        Me.cbDisplayTimeStamp.Location = New System.Drawing.Point(285, 3)
        Me.cbDisplayTimeStamp.Name = "cbDisplayTimeStamp"
        Me.cbDisplayTimeStamp.Size = New System.Drawing.Size(158, 20)
        Me.cbDisplayTimeStamp.TabIndex = 25
        Me.cbDisplayTimeStamp.Text = "áãå÷ ÷éåí çúéîä òì æîï "
        Me.cbDisplayTimeStamp.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.Controls.Add(Me.CheckBox5)
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(-3, 29)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel9.TabIndex = 36
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox5.TabIndex = 25
        Me.CheckBox5.Text = "áãå÷ CRL"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel10
        '
        Me.FlowLayoutPanel10.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel10.Controls.Add(Me.FlowLayoutPanel11)
        Me.FlowLayoutPanel10.Controls.Add(Me.FlowLayoutPanel12)
        Me.FlowLayoutPanel10.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel10.Location = New System.Drawing.Point(-3, 59)
        Me.FlowLayoutPanel10.Name = "FlowLayoutPanel10"
        Me.FlowLayoutPanel10.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel10.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(406, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "CRL:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel11
        '
        Me.FlowLayoutPanel11.Controls.Add(Me.CheckBox6)
        Me.FlowLayoutPanel11.Location = New System.Drawing.Point(-3, 19)
        Me.FlowLayoutPanel11.Name = "FlowLayoutPanel11"
        Me.FlowLayoutPanel11.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel11.TabIndex = 36
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(359, 3)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(84, 20)
        Me.CheckBox6.TabIndex = 25
        Me.CheckBox6.Text = "áãå÷ CRL"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel12
        '
        Me.FlowLayoutPanel12.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel12.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.FlowLayoutPanel12.Location = New System.Drawing.Point(-3, 49)
        Me.FlowLayoutPanel12.Name = "FlowLayoutPanel12"
        Me.FlowLayoutPanel12.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanel12.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(406, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "CRL:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlVerifySettingsHeader
        '
        Me.pnlVerifySettingsHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVerifySettingsHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlVerifySettingsHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlVerifySettingsHeader.Controls.Add(Me.picboxAdvanceSettingsVerify)
        Me.pnlVerifySettingsHeader.Controls.Add(Me.lblAdvanceSettingVerify)
        Me.pnlVerifySettingsHeader.Location = New System.Drawing.Point(8, 3)
        Me.pnlVerifySettingsHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlVerifySettingsHeader.Name = "pnlVerifySettingsHeader"
        Me.pnlVerifySettingsHeader.Size = New System.Drawing.Size(563, 24)
        Me.pnlVerifySettingsHeader.TabIndex = 2
        '
        'lblAdvanceSettingVerify
        '
        Me.lblAdvanceSettingVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdvanceSettingVerify.AutoSize = True
        Me.lblAdvanceSettingVerify.BackColor = System.Drawing.Color.Transparent
        Me.lblAdvanceSettingVerify.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblAdvanceSettingVerify.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblAdvanceSettingVerify.Location = New System.Drawing.Point(420, 5)
        Me.lblAdvanceSettingVerify.Name = "lblAdvanceSettingVerify"
        Me.lblAdvanceSettingVerify.Size = New System.Drawing.Size(137, 15)
        Me.lblAdvanceSettingVerify.TabIndex = 1
        Me.lblAdvanceSettingVerify.Text = "הגדרות מתקדמות לאימות:"
        '
        'FlowLayoutPanelcbVerifySignatureOnly
        '
        Me.FlowLayoutPanelcbVerifySignatureOnly.Controls.Add(Me.cbVerifySignatureOnly)
        Me.FlowLayoutPanelcbVerifySignatureOnly.Location = New System.Drawing.Point(107, 32)
        Me.FlowLayoutPanelcbVerifySignatureOnly.Name = "FlowLayoutPanelcbVerifySignatureOnly"
        Me.FlowLayoutPanelcbVerifySignatureOnly.Size = New System.Drawing.Size(446, 24)
        Me.FlowLayoutPanelcbVerifySignatureOnly.TabIndex = 33
        '
        'cbVerifySignatureOnly
        '
        Me.cbVerifySignatureOnly.AutoSize = True
        Me.cbVerifySignatureOnly.Location = New System.Drawing.Point(315, 3)
        Me.cbVerifySignatureOnly.Name = "cbVerifySignatureOnly"
        Me.cbVerifySignatureOnly.Size = New System.Drawing.Size(128, 20)
        Me.cbVerifySignatureOnly.TabIndex = 23
        Me.cbVerifySignatureOnly.Text = "áãå÷ îñìåì äúòåãä"
        Me.cbVerifySignatureOnly.UseVisualStyleBackColor = True
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(582, 31)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(582, 31)
        Me.ToolStripContainer1.TabIndex = 29
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Padding = New System.Windows.Forms.Padding(0, 0, 25, 25)
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.AutoSize = True
        Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblHeader.Location = New System.Drawing.Point(283, 6)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(293, 19)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "בחר את הגדרות המשתמש לחתימה ולאימות"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(582, 31)
        Me.ToolStrip1.TabIndex = 2
        '
        'HelpButton
        '
        Me.HelpButton.BackColor = System.Drawing.Color.Transparent
        Me.HelpButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HelpButton.ForeColor = System.Drawing.Color.DimGray
        Me.HelpButton.Image = CType(resources.GetObject("HelpButton.Image"), System.Drawing.Image)
        Me.HelpButton.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.HelpButton.Margin = New System.Windows.Forms.Padding(0)
        Me.HelpButton.Name = "HelpButton"
        Me.HelpButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.HelpButton.Size = New System.Drawing.Size(55, 31)
        Me.HelpButton.Text = "עזרה"
        Me.HelpButton.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.ForeColor = System.Drawing.SystemColors.Window
        Me.Cancel_Button.Location = New System.Drawing.Point(65, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(53, 25)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "בטל"
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, "áèì àú ùîéøú ääâãøåú")
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.Window
        Me.OK_Button.Location = New System.Drawing.Point(4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(53, 25)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "אשר"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "ùîåø àú ääâãøåú")
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 7)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(121, 32)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pnlDottedLine
        '
        Me.pnlDottedLine.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.pnlDottedLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDottedLine.Location = New System.Drawing.Point(0, 0)
        Me.pnlDottedLine.Name = "pnlDottedLine"
        Me.pnlDottedLine.Size = New System.Drawing.Size(582, 2)
        Me.pnlDottedLine.TabIndex = 31
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlButtons.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlButtons.Controls.Add(Me.pnlDottedLine)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 646)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(582, 47)
        Me.pnlButtons.TabIndex = 28
        '
        'OptionsDiag
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(582, 693)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlVerifySettings)
        Me.Controls.Add(Me.pnlSignSettings)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.pnlProfile)
        Me.Controls.Add(Me.pnlSelectFile)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "OptionsDiag"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "הגדרת משתמש"
        Me.ToolTip1.SetToolTip(Me, "çôù àú ä÷åáõ ìçúéîä \ àéîåú")
        CType(Me.picboxSaveFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxProfile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxAdvanceSettingSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxAdvanceSettingsVerify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectFile.ResumeLayout(False)
        Me.pnlSelectFile.PerformLayout()
        Me.pnlSaveFile.ResumeLayout(False)
        Me.pnlSaveFile.PerformLayout()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        Me.pnlProfileHeader.ResumeLayout(False)
        Me.pnlProfileHeader.PerformLayout()
        Me.pnlSignSettings.ResumeLayout(False)
        Me.pnlSignSettings.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.flowlayTS.ResumeLayout(False)
        Me.flowlayTS.PerformLayout()
        Me.flowlayNonRep.ResumeLayout(False)
        Me.flowlayNonRep.PerformLayout()
        Me.layoutTSURL.ResumeLayout(False)
        Me.layoutTSURL.PerformLayout()
        Me.pnlSignSettingsHeader.ResumeLayout(False)
        Me.pnlSignSettingsHeader.PerformLayout()
        Me.pnlVerifySettings.ResumeLayout(False)
        Me.FlowLayoutPanelcbCheckCRL.ResumeLayout(False)
        Me.FlowLayoutPanelcbCheckCRL.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.FlowLayoutCRL.ResumeLayout(False)
        Me.FlowLayoutCRL.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPath.ResumeLayout(False)
        Me.FlowLayoutPath.PerformLayout()
        Me.FlowLayoutTS.ResumeLayout(False)
        Me.FlowLayoutTS.PerformLayout()
        Me.FlowLayoutPanel13.ResumeLayout(False)
        Me.FlowLayoutPanel13.PerformLayout()
        Me.FlowLayoutPanel14.ResumeLayout(False)
        Me.FlowLayoutPanel14.PerformLayout()
        Me.FlowLayoutPanelcbDisplayTimeStamp.ResumeLayout(False)
        Me.FlowLayoutPanelcbDisplayTimeStamp.PerformLayout()
        Me.FlowLayoutPanel9.ResumeLayout(False)
        Me.FlowLayoutPanel9.PerformLayout()
        Me.FlowLayoutPanel10.ResumeLayout(False)
        Me.FlowLayoutPanel10.PerformLayout()
        Me.FlowLayoutPanel11.ResumeLayout(False)
        Me.FlowLayoutPanel11.PerformLayout()
        Me.FlowLayoutPanel12.ResumeLayout(False)
        Me.FlowLayoutPanel12.PerformLayout()
        Me.pnlVerifySettingsHeader.ResumeLayout(False)
        Me.pnlVerifySettingsHeader.PerformLayout()
        Me.FlowLayoutPanelcbVerifySignatureOnly.ResumeLayout(False)
        Me.FlowLayoutPanelcbVerifySignatureOnly.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserSaveSigned As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tipQuestionMark As System.Windows.Forms.ToolTip
    Friend WithEvents pnlSelectFile As System.Windows.Forms.Panel
    Friend WithEvents btnBrowseDestinationFile As RoundedButton
    Friend WithEvents RadioSame As System.Windows.Forms.RadioButton
    Friend WithEvents tbDestinationFolder As System.Windows.Forms.RichTextBox
    Friend WithEvents RadioDifferent As System.Windows.Forms.RadioButton
    Friend WithEvents pnlSaveFile As System.Windows.Forms.Panel
    Friend WithEvents picboxSaveFile As System.Windows.Forms.PictureBox
    Friend WithEvents lblChooseHeader As System.Windows.Forms.Label
    Friend WithEvents pnlProfile As System.Windows.Forms.Panel
    Friend WithEvents lblProfile As System.Windows.Forms.Label
    Friend WithEvents ddlProfils As System.Windows.Forms.ComboBox
    Friend WithEvents pnlProfileHeader As System.Windows.Forms.Panel
    Friend WithEvents picBoxProfile As System.Windows.Forms.PictureBox
    Friend WithEvents lblSelectProfile As System.Windows.Forms.Label
    Friend WithEvents pnlSignSettings As System.Windows.Forms.Panel
    Friend WithEvents flowlayTS As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbCheckTimeStamp As System.Windows.Forms.CheckBox
    Friend WithEvents flowlayNonRep As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbShowOnlyNonRepudiation As System.Windows.Forms.CheckBox
    Friend WithEvents layoutTSURL As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTSURL As System.Windows.Forms.Label
    Friend WithEvents lblURL As System.Windows.Forms.TextBox
    Friend WithEvents ddlSignAlgo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSigingAlgorithm As System.Windows.Forms.Label
    Friend WithEvents pnlSignSettingsHeader As System.Windows.Forms.Panel
    Friend WithEvents picboxAdvanceSettingSign As System.Windows.Forms.PictureBox
    Friend WithEvents lblAdvancedSeetingsSign As System.Windows.Forms.Label
    Friend WithEvents ddlProviders As System.Windows.Forms.ComboBox
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents pnlVerifySettings As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanelcbCheckCRL As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbCheckCRL As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutCRL As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblCRLExplain As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPath As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblPathExplain As System.Windows.Forms.Label
    Friend WithEvents pnlVerifySettingsHeader As System.Windows.Forms.Panel
    Friend WithEvents picboxAdvanceSettingsVerify As System.Windows.Forms.PictureBox
    Friend WithEvents lblAdvanceSettingVerify As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanelcbVerifySignatureOnly As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbVerifySignatureOnly As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As RoundedButton
    Friend WithEvents Cancel_Button As RoundedButton
    Friend WithEvents pnlDottedLine As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbShowSignOptions As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents HelpButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSavingType As System.Windows.Forms.Label
    Friend WithEvents ddlSavingType As System.Windows.Forms.ComboBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel7 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanelcbDisplayTimeStamp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbDisplayTimeStamp As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel9 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel10 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel11 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel12 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutTS As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTSExplain As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel13 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel14 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdvancedSettings As RoundedButton

End Class
