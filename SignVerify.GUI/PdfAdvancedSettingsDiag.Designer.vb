
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PdfAdvancedSettingsDiag
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PdfAdvancedSettingsDiag))
        Me.tipQuestionMark = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picboxAppareance = New System.Windows.Forms.PictureBox()
        Me.pnlSelectFile = New System.Windows.Forms.Panel()
        Me.lblDataEx = New System.Windows.Forms.Label()
        Me.pnlSaveFile = New System.Windows.Forms.Panel()
        Me.lblAppearanceHeader = New System.Windows.Forms.Label()
        Me.cbShowSig = New System.Windows.Forms.CheckBox()
        Me.pnlVisibleSigOptions = New System.Windows.Forms.Panel()
        Me.lblShowImage = New System.Windows.Forms.Label()
        Me.lblShowName = New System.Windows.Forms.Label()
        Me.cbShowName = New System.Windows.Forms.CheckBox()
        Me.lblText = New System.Windows.Forms.Label()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.pnlShowImage = New System.Windows.Forms.Panel()
        Me.lblUseDefaultImage = New System.Windows.Forms.Label()
        Me.pnlUseDefaultImage = New System.Windows.Forms.Panel()
        Me.lblImagePath = New System.Windows.Forms.Label()
        Me.btnBrowseDestinationFile = New System.Windows.Forms.Button()
        Me.tbImagePath = New System.Windows.Forms.TextBox()
        Me.cbUseDefaultImage = New System.Windows.Forms.CheckBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.rtbContact = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.rtbLocation = New System.Windows.Forms.TextBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.rtbReason = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDataHeader = New System.Windows.Forms.Label()
        Me.lblPositionForAlign = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.cbShowImage = New System.Windows.Forms.CheckBox()
        Me.ddlAlignType = New System.Windows.Forms.ComboBox()
        Me.lblPositionForTitle = New System.Windows.Forms.Label()
        Me.ddlTopType = New System.Windows.Forms.ComboBox()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.HelpButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDottedLine = New System.Windows.Forms.Panel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.fileImage = New System.Windows.Forms.OpenFileDialog()
        Me.lblDataEx2 = New System.Windows.Forms.Label()
        Me.lblDataEx3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxAppareance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectFile.SuspendLayout()
        Me.pnlSaveFile.SuspendLayout()
        Me.pnlVisibleSigOptions.SuspendLayout()
        Me.pnlShowImage.SuspendLayout()
        Me.pnlUseDefaultImage.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tipQuestionMark
        '
        Me.tipQuestionMark.IsBalloon = True
        Me.tipQuestionMark.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tipQuestionMark.ToolTipTitle = "עזרה"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.PictureBox1.Location = New System.Drawing.Point(4, 2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.PictureBox1, "במסך זה ניתן להגדיר את אופן הצגת החתימה בקבצי PDF חתומים- מאפיינים וכן גרפיקה")
        '
        'picboxAppareance
        '
        Me.picboxAppareance.BackColor = System.Drawing.Color.Transparent
        Me.picboxAppareance.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picboxAppareance.Location = New System.Drawing.Point(4, 2)
        Me.picboxAppareance.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxAppareance.Name = "picboxAppareance"
        Me.picboxAppareance.Size = New System.Drawing.Size(20, 21)
        Me.picboxAppareance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxAppareance.TabIndex = 0
        Me.picboxAppareance.TabStop = False
        Me.tipQuestionMark.SetToolTip(Me.picboxAppareance, "במסך זה ניתן להגדיר את אופן הצגת החתימה בקבצי PDF חתומים- מאפיינים וכן גרפיקה")
        '
        'pnlSelectFile
        '
        Me.pnlSelectFile.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectFile.Controls.Add(Me.lblDataEx3)
        Me.pnlSelectFile.Controls.Add(Me.lblDataEx2)
        Me.pnlSelectFile.Controls.Add(Me.lblDataEx)
        Me.pnlSelectFile.Controls.Add(Me.pnlSaveFile)
        Me.pnlSelectFile.Controls.Add(Me.cbShowSig)
        Me.pnlSelectFile.Controls.Add(Me.pnlVisibleSigOptions)
        Me.pnlSelectFile.Location = New System.Drawing.Point(0, 30)
        Me.pnlSelectFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSelectFile.Name = "pnlSelectFile"
        Me.pnlSelectFile.Size = New System.Drawing.Size(572, 648)
        Me.pnlSelectFile.TabIndex = 22
        '
        'lblDataEx
        '
        Me.lblDataEx.AutoSize = True
        Me.lblDataEx.Location = New System.Drawing.Point(70, 1)
        Me.lblDataEx.Name = "lblDataEx"
        Me.lblDataEx.Size = New System.Drawing.Size(488, 16)
        Me.lblDataEx.TabIndex = 42
        Me.lblDataEx.Text = "סימון הוספת חתימה ויזואלית מאפשר הצגת החתימה בהתאם למוגדר בחלק של תצוגת החתימה."
        '
        'pnlSaveFile
        '
        Me.pnlSaveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSaveFile.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.pnlSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSaveFile.Controls.Add(Me.picboxAppareance)
        Me.pnlSaveFile.Controls.Add(Me.lblAppearanceHeader)
        Me.pnlSaveFile.Location = New System.Drawing.Point(8, 85)
        Me.pnlSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSaveFile.Name = "pnlSaveFile"
        Me.pnlSaveFile.Size = New System.Drawing.Size(556, 24)
        Me.pnlSaveFile.TabIndex = 41
        '
        'lblAppearanceHeader
        '
        Me.lblAppearanceHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAppearanceHeader.AutoSize = True
        Me.lblAppearanceHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblAppearanceHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblAppearanceHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblAppearanceHeader.Location = New System.Drawing.Point(448, 2)
        Me.lblAppearanceHeader.Name = "lblAppearanceHeader"
        Me.lblAppearanceHeader.Size = New System.Drawing.Size(80, 15)
        Me.lblAppearanceHeader.TabIndex = 1
        Me.lblAppearanceHeader.Text = "תצוגת חתימה :"
        '
        'cbShowSig
        '
        Me.cbShowSig.AutoSize = True
        Me.cbShowSig.Location = New System.Drawing.Point(132, 59)
        Me.cbShowSig.Name = "cbShowSig"
        Me.cbShowSig.Size = New System.Drawing.Size(423, 20)
        Me.cbShowSig.TabIndex = 40
        Me.cbShowSig.Text = "הוסף הצגה ויזואלית של פרטי החותם בנוסף לסימון החתימה ב Adobe Reader"
        Me.cbShowSig.UseVisualStyleBackColor = True
        '
        'pnlVisibleSigOptions
        '
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblShowImage)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblShowName)
        Me.pnlVisibleSigOptions.Controls.Add(Me.cbShowName)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblText)
        Me.pnlVisibleSigOptions.Controls.Add(Me.txtText)
        Me.pnlVisibleSigOptions.Controls.Add(Me.pnlShowImage)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblContact)
        Me.pnlVisibleSigOptions.Controls.Add(Me.rtbContact)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblLocation)
        Me.pnlVisibleSigOptions.Controls.Add(Me.rtbLocation)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblReason)
        Me.pnlVisibleSigOptions.Controls.Add(Me.rtbReason)
        Me.pnlVisibleSigOptions.Controls.Add(Me.Panel1)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblPositionForAlign)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblPosition)
        Me.pnlVisibleSigOptions.Controls.Add(Me.cbShowImage)
        Me.pnlVisibleSigOptions.Controls.Add(Me.ddlAlignType)
        Me.pnlVisibleSigOptions.Controls.Add(Me.lblPositionForTitle)
        Me.pnlVisibleSigOptions.Controls.Add(Me.ddlTopType)
        Me.pnlVisibleSigOptions.Location = New System.Drawing.Point(0, 114)
        Me.pnlVisibleSigOptions.Name = "pnlVisibleSigOptions"
        Me.pnlVisibleSigOptions.Size = New System.Drawing.Size(572, 438)
        Me.pnlVisibleSigOptions.TabIndex = 39
        '
        'lblShowImage
        '
        Me.lblShowImage.AutoSize = True
        Me.lblShowImage.Location = New System.Drawing.Point(162, 61)
        Me.lblShowImage.Name = "lblShowImage"
        Me.lblShowImage.Size = New System.Drawing.Size(375, 16)
        Me.lblShowImage.TabIndex = 75
        Me.lblShowImage.Text = "הוסף הצגה ויזואלית של חותמת בנוסף לסימון החתימה ב Adobe Reader"
        '
        'lblShowName
        '
        Me.lblShowName.AutoSize = True
        Me.lblShowName.Location = New System.Drawing.Point(435, 36)
        Me.lblShowName.Name = "lblShowName"
        Me.lblShowName.Size = New System.Drawing.Size(101, 16)
        Me.lblShowName.TabIndex = 74
        Me.lblShowName.Text = "הוסף פרטי החותם"
        '
        'cbShowName
        '
        Me.cbShowName.AutoSize = True
        Me.cbShowName.Checked = True
        Me.cbShowName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowName.Location = New System.Drawing.Point(540, 38)
        Me.cbShowName.Name = "cbShowName"
        Me.cbShowName.Size = New System.Drawing.Size(15, 14)
        Me.cbShowName.TabIndex = 73
        Me.cbShowName.UseVisualStyleBackColor = True
        '
        'lblText
        '
        Me.lblText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText.AutoSize = True
        Me.lblText.Location = New System.Drawing.Point(394, 8)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(142, 16)
        Me.lblText.TabIndex = 72
        Me.lblText.Text = "טקסט להצגה ליד החתימה"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtText
        '
        Me.txtText.BackColor = System.Drawing.SystemColors.Control
        Me.txtText.Enabled = False
        Me.txtText.Location = New System.Drawing.Point(93, 6)
        Me.txtText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtText.Name = "txtText"
        Me.txtText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtText.Size = New System.Drawing.Size(300, 22)
        Me.txtText.TabIndex = 71
        Me.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlShowImage
        '
        Me.pnlShowImage.Controls.Add(Me.lblUseDefaultImage)
        Me.pnlShowImage.Controls.Add(Me.pnlUseDefaultImage)
        Me.pnlShowImage.Controls.Add(Me.cbUseDefaultImage)
        Me.pnlShowImage.Location = New System.Drawing.Point(0, 88)
        Me.pnlShowImage.Name = "pnlShowImage"
        Me.pnlShowImage.Size = New System.Drawing.Size(572, 71)
        Me.pnlShowImage.TabIndex = 68
        '
        'lblUseDefaultImage
        '
        Me.lblUseDefaultImage.AutoSize = True
        Me.lblUseDefaultImage.Location = New System.Drawing.Point(309, 1)
        Me.lblUseDefaultImage.Name = "lblUseDefaultImage"
        Me.lblUseDefaultImage.Size = New System.Drawing.Size(229, 16)
        Me.lblUseDefaultImage.TabIndex = 63
        Me.lblUseDefaultImage.Text = "השתמש בתמונת ברירת מחדל של המערכת"
        '
        'pnlUseDefaultImage
        '
        Me.pnlUseDefaultImage.Controls.Add(Me.lblImagePath)
        Me.pnlUseDefaultImage.Controls.Add(Me.btnBrowseDestinationFile)
        Me.pnlUseDefaultImage.Controls.Add(Me.tbImagePath)
        Me.pnlUseDefaultImage.Location = New System.Drawing.Point(3, 33)
        Me.pnlUseDefaultImage.Name = "pnlUseDefaultImage"
        Me.pnlUseDefaultImage.Size = New System.Drawing.Size(541, 36)
        Me.pnlUseDefaultImage.TabIndex = 62
        '
        'lblImagePath
        '
        Me.lblImagePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImagePath.AutoSize = True
        Me.lblImagePath.Location = New System.Drawing.Point(459, 6)
        Me.lblImagePath.Name = "lblImagePath"
        Me.lblImagePath.Size = New System.Drawing.Size(77, 16)
        Me.lblImagePath.TabIndex = 66
        Me.lblImagePath.Text = "הוסף תמונה :"
        Me.lblImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBrowseDestinationFile
        '
        Me.btnBrowseDestinationFile.Enabled = False
        Me.btnBrowseDestinationFile.Location = New System.Drawing.Point(14, 6)
        Me.btnBrowseDestinationFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseDestinationFile.Name = "btnBrowseDestinationFile"
        Me.btnBrowseDestinationFile.Size = New System.Drawing.Size(53, 24)
        Me.btnBrowseDestinationFile.TabIndex = 65
        Me.btnBrowseDestinationFile.Text = "עיון"
        Me.ToolTip1.SetToolTip(Me.btnBrowseDestinationFile, " בחר את התמונה שברצונך להציג ליד החתימה")
        Me.btnBrowseDestinationFile.UseVisualStyleBackColor = True
        '
        'tbImagePath
        '
        Me.tbImagePath.BackColor = System.Drawing.SystemColors.Control
        Me.tbImagePath.Enabled = False
        Me.tbImagePath.Location = New System.Drawing.Point(90, 4)
        Me.tbImagePath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbImagePath.Multiline = True
        Me.tbImagePath.Name = "tbImagePath"
        Me.tbImagePath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbImagePath.Size = New System.Drawing.Size(300, 22)
        Me.tbImagePath.TabIndex = 64
        '
        'cbUseDefaultImage
        '
        Me.cbUseDefaultImage.AutoSize = True
        Me.cbUseDefaultImage.Location = New System.Drawing.Point(540, 3)
        Me.cbUseDefaultImage.Name = "cbUseDefaultImage"
        Me.cbUseDefaultImage.Size = New System.Drawing.Size(15, 14)
        Me.cbUseDefaultImage.TabIndex = 61
        Me.cbUseDefaultImage.UseVisualStyleBackColor = True
        '
        'lblContact
        '
        Me.lblContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(421, 408)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(126, 16)
        Me.lblContact.TabIndex = 65
        Me.lblContact.Text = "פרטי קשר של החותם :"
        Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbContact
        '
        Me.rtbContact.BackColor = System.Drawing.SystemColors.Control
        Me.rtbContact.Enabled = False
        Me.rtbContact.Location = New System.Drawing.Point(103, 405)
        Me.rtbContact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbContact.Name = "rtbContact"
        Me.rtbContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbContact.Size = New System.Drawing.Size(300, 22)
        Me.rtbContact.TabIndex = 64
        Me.rtbContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLocation
        '
        Me.lblLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(458, 374)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(89, 16)
        Me.lblLocation.TabIndex = 63
        Me.lblLocation.Text = "מקום החתימה :"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbLocation
        '
        Me.rtbLocation.BackColor = System.Drawing.SystemColors.Control
        Me.rtbLocation.Enabled = False
        Me.rtbLocation.Location = New System.Drawing.Point(103, 368)
        Me.rtbLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbLocation.Name = "rtbLocation"
        Me.rtbLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbLocation.Size = New System.Drawing.Size(300, 22)
        Me.rtbLocation.TabIndex = 62
        Me.rtbLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReason
        '
        Me.lblReason.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(498, 340)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(49, 16)
        Me.lblReason.TabIndex = 61
        Me.lblReason.Text = "הערות :"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbReason
        '
        Me.rtbReason.BackColor = System.Drawing.SystemColors.Control
        Me.rtbReason.Enabled = False
        Me.rtbReason.Location = New System.Drawing.Point(103, 337)
        Me.rtbReason.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbReason.Name = "rtbReason"
        Me.rtbReason.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbReason.Size = New System.Drawing.Size(300, 22)
        Me.rtbReason.TabIndex = 60
        Me.rtbReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.HeaderBack
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblDataHeader)
        Me.Panel1.Location = New System.Drawing.Point(11, 298)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 24)
        Me.Panel1.TabIndex = 41
        '
        'lblDataHeader
        '
        Me.lblDataHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDataHeader.AutoSize = True
        Me.lblDataHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblDataHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDataHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblDataHeader.Location = New System.Drawing.Point(438, 2)
        Me.lblDataHeader.Name = "lblDataHeader"
        Me.lblDataHeader.Size = New System.Drawing.Size(92, 15)
        Me.lblDataHeader.TabIndex = 1
        Me.lblDataHeader.Text = "מאפייני החתימה :"
        '
        'lblPositionForAlign
        '
        Me.lblPositionForAlign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPositionForAlign.AutoSize = True
        Me.lblPositionForAlign.Location = New System.Drawing.Point(504, 246)
        Me.lblPositionForAlign.Name = "lblPositionForAlign"
        Me.lblPositionForAlign.Size = New System.Drawing.Size(33, 16)
        Me.lblPositionForAlign.TabIndex = 59
        Me.lblPositionForAlign.Text = "יישור"
        Me.lblPositionForAlign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPosition.Location = New System.Drawing.Point(414, 182)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(123, 16)
        Me.lblPosition.TabIndex = 58
        Me.lblPosition.Text = "מיקום הצגת החתימה"
        '
        'cbShowImage
        '
        Me.cbShowImage.AutoSize = True
        Me.cbShowImage.Location = New System.Drawing.Point(540, 64)
        Me.cbShowImage.Name = "cbShowImage"
        Me.cbShowImage.Size = New System.Drawing.Size(15, 14)
        Me.cbShowImage.TabIndex = 54
        Me.cbShowImage.UseVisualStyleBackColor = True
        '
        'ddlAlignType
        '
        Me.ddlAlignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlAlignType.Enabled = False
        Me.ddlAlignType.FormattingEnabled = True
        Me.ddlAlignType.Items.AddRange(New Object() {"מייושר ימינה", "מייושר לאמצע", "מייושר שמאלה"})
        Me.ddlAlignType.Location = New System.Drawing.Point(93, 243)
        Me.ddlAlignType.Name = "ddlAlignType"
        Me.ddlAlignType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ddlAlignType.Size = New System.Drawing.Size(300, 24)
        Me.ddlAlignType.TabIndex = 50
        '
        'lblPositionForTitle
        '
        Me.lblPositionForTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPositionForTitle.AutoSize = True
        Me.lblPositionForTitle.Location = New System.Drawing.Point(497, 212)
        Me.lblPositionForTitle.Name = "lblPositionForTitle"
        Me.lblPositionForTitle.Size = New System.Drawing.Size(40, 16)
        Me.lblPositionForTitle.TabIndex = 42
        Me.lblPositionForTitle.Text = "כותרת"
        Me.lblPositionForTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ddlTopType
        '
        Me.ddlTopType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTopType.Enabled = False
        Me.ddlTopType.FormattingEnabled = True
        Me.ddlTopType.Items.AddRange(New Object() {"כותרת עליונה", "כותרת תחתונה"})
        Me.ddlTopType.Location = New System.Drawing.Point(93, 209)
        Me.ddlTopType.Name = "ddlTopType"
        Me.ddlTopType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ddlTopType.Size = New System.Drawing.Size(300, 24)
        Me.ddlTopType.TabIndex = 41
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(572, 31)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(572, 31)
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
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblHeader.Location = New System.Drawing.Point(360, 6)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(199, 19)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "הגדרות חתימה על קבצי PDF"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(572, 31)
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
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(65, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(53, 24)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "בטל"
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, "בטל את שמירת ההגדרות")
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(53, 24)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "אשר"
        Me.ToolTip1.SetToolTip(Me.OK_Button, "שמור את ההגדרות")
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
        Me.pnlDottedLine.Size = New System.Drawing.Size(572, 2)
        Me.pnlDottedLine.TabIndex = 31
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.Transparent
        Me.pnlButtons.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlButtons.Controls.Add(Me.pnlDottedLine)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 585)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(572, 47)
        Me.pnlButtons.TabIndex = 28
        '
        'fileImage
        '
        Me.fileImage.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Fi" & _
    "les (*.gif)|*.gif"
        '
        'lblDataEx2
        '
        Me.lblDataEx2.AutoSize = True
        Me.lblDataEx2.Location = New System.Drawing.Point(163, 20)
        Me.lblDataEx2.Name = "lblDataEx2"
        Me.lblDataEx2.Size = New System.Drawing.Size(395, 16)
        Me.lblDataEx2.TabIndex = 43
        Me.lblDataEx2.Text = "ניתן להגדיר מאפייני חתימה בהתאם לערכים שיוזנו בחלק של מאפייני חתימה."
        '
        'lblDataEx3
        '
        Me.lblDataEx3.AutoSize = True
        Me.lblDataEx3.Location = New System.Drawing.Point(50, 40)
        Me.lblDataEx3.Name = "lblDataEx3"
        Me.lblDataEx3.Size = New System.Drawing.Size(508, 16)
        Me.lblDataEx3.TabIndex = 44
        Me.lblDataEx3.Text = "מאפיינים אלו מוצגים במסך מאפייני החתימה ב ADOBE  אשר זמין בלחיצה על החתימה הויזוא" & _
    "לית ."
        '
        'PdfAdvancedSettingsDiag
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(572, 632)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.pnlSelectFile)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PdfAdvancedSettingsDiag"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "הגדרות משתמש"
        Me.ToolTip1.SetToolTip(Me, "חפש את הקובץ לחתימה \ אימות")
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxAppareance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectFile.ResumeLayout(False)
        Me.pnlSelectFile.PerformLayout()
        Me.pnlSaveFile.ResumeLayout(False)
        Me.pnlSaveFile.PerformLayout()
        Me.pnlVisibleSigOptions.ResumeLayout(False)
        Me.pnlVisibleSigOptions.PerformLayout()
        Me.pnlShowImage.ResumeLayout(False)
        Me.pnlShowImage.PerformLayout()
        Me.pnlUseDefaultImage.ResumeLayout(False)
        Me.pnlUseDefaultImage.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tipQuestionMark As System.Windows.Forms.ToolTip
    Friend WithEvents pnlSelectFile As System.Windows.Forms.Panel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnlDottedLine As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents HelpButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlVisibleSigOptions As System.Windows.Forms.Panel
    Friend WithEvents ddlAlignType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPositionForTitle As System.Windows.Forms.Label
    Friend WithEvents ddlTopType As System.Windows.Forms.ComboBox
    Friend WithEvents cbShowImage As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowSig As System.Windows.Forms.CheckBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents rtbContact As System.Windows.Forms.TextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents rtbLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents rtbReason As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDataHeader As System.Windows.Forms.Label
    Friend WithEvents lblPositionForAlign As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents pnlShowImage As System.Windows.Forms.Panel
    Friend WithEvents pnlUseDefaultImage As System.Windows.Forms.Panel
    Friend WithEvents lblImagePath As System.Windows.Forms.Label
    Friend WithEvents btnBrowseDestinationFile As System.Windows.Forms.Button
    Friend WithEvents tbImagePath As System.Windows.Forms.TextBox
    Friend WithEvents cbUseDefaultImage As System.Windows.Forms.CheckBox
    Friend WithEvents fileImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents cbShowName As System.Windows.Forms.CheckBox
    Friend WithEvents lblShowImage As System.Windows.Forms.Label
    Friend WithEvents lblShowName As System.Windows.Forms.Label
    Friend WithEvents lblUseDefaultImage As System.Windows.Forms.Label
    Friend WithEvents pnlSaveFile As System.Windows.Forms.Panel
    Friend WithEvents picboxAppareance As System.Windows.Forms.PictureBox
    Friend WithEvents lblAppearanceHeader As System.Windows.Forms.Label
    Friend WithEvents lblDataEx As System.Windows.Forms.Label
    Friend WithEvents lblDataEx3 As System.Windows.Forms.Label
    Friend WithEvents lblDataEx2 As System.Windows.Forms.Label

End Class
