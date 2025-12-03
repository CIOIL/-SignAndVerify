<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class signatureView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblNameLabel = New System.Windows.Forms.Label()
        Me.lblExpirationDateLabel = New System.Windows.Forms.Label()
        Me.lblIssuerLabel = New System.Windows.Forms.Label()
        Me.lbladLabel = New System.Windows.Forms.Label()
        Me.lblChainLabel = New System.Windows.Forms.Label()
        Me.lblasdfeLabel = New System.Windows.Forms.Label()
        Me.lblTSStateLabel = New System.Windows.Forms.Label()
        Me.lblTSLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblExpire = New System.Windows.Forms.Label()
        Me.lblIssuer = New System.Windows.Forms.Label()
        Me.lblEndCertificate = New System.Windows.Forms.Label()
        Me.lblChain = New System.Windows.Forms.Label()
        Me.lblCRL = New System.Windows.Forms.Label()
        Me.lblTSState = New System.Windows.Forms.Label()
        Me.lblTS = New System.Windows.Forms.Label()
        Me.lblTSNameLabel = New System.Windows.Forms.Label()
        Me.lblTSName = New System.Windows.Forms.Label()
        Me.lblTSCertLabel = New System.Windows.Forms.Label()
        Me.lblTSCert = New System.Windows.Forms.Label()
        Me.lblStandardLabel = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.layoutSign = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblIsSignOk = New System.Windows.Forms.Label()
        Me.pixBoxIsVerifyed = New System.Windows.Forms.PictureBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.toolTipState = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblStandard = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.layoutSign.SuspendLayout()
        CType(Me.pixBoxIsVerifyed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNameLabel
        '
        Me.lblNameLabel.AutoSize = True
        Me.lblNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblNameLabel.Location = New System.Drawing.Point(461, 0)
        Me.lblNameLabel.Name = "lblNameLabel"
        Me.lblNameLabel.Size = New System.Drawing.Size(29, 16)
        Me.lblNameLabel.TabIndex = 0
        Me.lblNameLabel.Text = "שם:"
        '
        'lblExpirationDateLabel
        '
        Me.lblExpirationDateLabel.AutoSize = True
        Me.lblExpirationDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblExpirationDateLabel.Location = New System.Drawing.Point(453, 34)
        Me.lblExpirationDateLabel.Name = "lblExpirationDateLabel"
        Me.lblExpirationDateLabel.Size = New System.Drawing.Size(37, 16)
        Me.lblExpirationDateLabel.TabIndex = 1
        Me.lblExpirationDateLabel.Text = "תוקף:"
        '
        'lblIssuerLabel
        '
        Me.lblIssuerLabel.AutoSize = True
        Me.lblIssuerLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblIssuerLabel.Location = New System.Drawing.Point(448, 68)
        Me.lblIssuerLabel.Name = "lblIssuerLabel"
        Me.lblIssuerLabel.Size = New System.Drawing.Size(42, 16)
        Me.lblIssuerLabel.TabIndex = 2
        Me.lblIssuerLabel.Text = "מנפיק:"
        '
        'lbladLabel
        '
        Me.lbladLabel.AutoSize = True
        Me.lbladLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lbladLabel.Location = New System.Drawing.Point(180, 0)
        Me.lbladLabel.Name = "lbladLabel"
        Me.lbladLabel.Size = New System.Drawing.Size(47, 16)
        Me.lbladLabel.TabIndex = 4
        Me.lbladLabel.Text = "חתימה:"
        '
        'lblChainLabel
        '
        Me.lblChainLabel.AutoSize = True
        Me.lblChainLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblChainLabel.Location = New System.Drawing.Point(157, 34)
        Me.lblChainLabel.Name = "lblChainLabel"
        Me.lblChainLabel.Size = New System.Drawing.Size(70, 16)
        Me.lblChainLabel.TabIndex = 5
        Me.lblChainLabel.Text = "גורם מאשר:"
        '
        'lblasdfeLabel
        '
        Me.lblasdfeLabel.AutoSize = True
        Me.lblasdfeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblasdfeLabel.Location = New System.Drawing.Point(139, 68)
        Me.lblasdfeLabel.Name = "lblasdfeLabel"
        Me.lblasdfeLabel.Size = New System.Drawing.Size(88, 16)
        Me.lblasdfeLabel.TabIndex = 6
        Me.lblasdfeLabel.Text = "רשימות פסולות:"
        '
        'lblTSStateLabel
        '
        Me.lblTSStateLabel.AutoSize = True
        Me.lblTSStateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblTSStateLabel.Location = New System.Drawing.Point(123, 136)
        Me.lblTSStateLabel.Name = "lblTSStateLabel"
        Me.lblTSStateLabel.Size = New System.Drawing.Size(104, 16)
        Me.lblTSStateLabel.TabIndex = 13
        Me.lblTSStateLabel.Text = "סטטוס זמן חתימה:"
        '
        'lblTSLabel
        '
        Me.lblTSLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblTSLabel.Location = New System.Drawing.Point(425, 136)
        Me.lblTSLabel.Name = "lblTSLabel"
        Me.lblTSLabel.Size = New System.Drawing.Size(65, 32)
        Me.lblTSLabel.TabIndex = 14
        Me.lblTSLabel.Text = "זמן חתימה:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.98962!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.01038!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNameLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblExpirationDateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIssuerLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbladLabel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblChainLabel, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblasdfeLabel, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblExpire, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIssuer, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndCertificate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblChain, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCRL, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSStateLabel, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSState, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTS, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSNameLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSName, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSCertLabel, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTSCert, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStandardLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStandard, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 24)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(493, 223)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(374, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 16)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "לא ידוע"
        '
        'lblExpire
        '
        Me.lblExpire.AutoSize = True
        Me.lblExpire.BackColor = System.Drawing.Color.Transparent
        Me.lblExpire.Location = New System.Drawing.Point(368, 34)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(51, 16)
        Me.lblExpire.TabIndex = 8
        Me.lblExpire.Text = "לא נבדק"
        '
        'lblIssuer
        '
        Me.lblIssuer.AutoSize = True
        Me.lblIssuer.BackColor = System.Drawing.Color.Transparent
        Me.lblIssuer.Location = New System.Drawing.Point(368, 68)
        Me.lblIssuer.Name = "lblIssuer"
        Me.lblIssuer.Size = New System.Drawing.Size(51, 16)
        Me.lblIssuer.TabIndex = 9
        Me.lblIssuer.Text = "לא נבדק"
        '
        'lblEndCertificate
        '
        Me.lblEndCertificate.AutoSize = True
        Me.lblEndCertificate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndCertificate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndCertificate.Location = New System.Drawing.Point(47, 0)
        Me.lblEndCertificate.Name = "lblEndCertificate"
        Me.lblEndCertificate.Size = New System.Drawing.Size(51, 16)
        Me.lblEndCertificate.TabIndex = 10
        Me.lblEndCertificate.Text = "לא נבדק"
        Me.lblEndCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.toolTipState.SetToolTip(Me.lblEndCertificate, "הראה את החתימות")
        '
        'lblChain
        '
        Me.lblChain.AutoSize = True
        Me.lblChain.BackColor = System.Drawing.Color.Transparent
        Me.lblChain.Location = New System.Drawing.Point(47, 34)
        Me.lblChain.Name = "lblChain"
        Me.lblChain.Size = New System.Drawing.Size(51, 16)
        Me.lblChain.TabIndex = 11
        Me.lblChain.Text = "לא נבדק"
        '
        'lblCRL
        '
        Me.lblCRL.AutoSize = True
        Me.lblCRL.BackColor = System.Drawing.Color.Transparent
        Me.lblCRL.Location = New System.Drawing.Point(47, 68)
        Me.lblCRL.Name = "lblCRL"
        Me.lblCRL.Size = New System.Drawing.Size(51, 16)
        Me.lblCRL.TabIndex = 12
        Me.lblCRL.Text = "לא נבדק"
        '
        'lblTSState
        '
        Me.lblTSState.AutoSize = True
        Me.lblTSState.BackColor = System.Drawing.Color.Transparent
        Me.lblTSState.Location = New System.Drawing.Point(47, 136)
        Me.lblTSState.Name = "lblTSState"
        Me.lblTSState.Size = New System.Drawing.Size(51, 16)
        Me.lblTSState.TabIndex = 16
        Me.lblTSState.Text = "לא נבדק"
        '
        'lblTS
        '
        Me.lblTS.AutoSize = True
        Me.lblTS.Location = New System.Drawing.Point(368, 136)
        Me.lblTS.Name = "lblTS"
        Me.lblTS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTS.Size = New System.Drawing.Size(51, 16)
        Me.lblTS.TabIndex = 17
        Me.lblTS.Text = "לא נבדק"
        '
        'lblTSNameLabel
        '
        Me.lblTSNameLabel.AutoSize = True
        Me.lblTSNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblTSNameLabel.Location = New System.Drawing.Point(445, 170)
        Me.lblTSNameLabel.Name = "lblTSNameLabel"
        Me.lblTSNameLabel.Size = New System.Drawing.Size(45, 16)
        Me.lblTSNameLabel.TabIndex = 18
        Me.lblTSNameLabel.Text = "תעודה:"
        '
        'lblTSName
        '
        Me.lblTSName.AutoSize = True
        Me.lblTSName.BackColor = System.Drawing.Color.Transparent
        Me.lblTSName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblTSName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTSName.Location = New System.Drawing.Point(373, 170)
        Me.lblTSName.Name = "lblTSName"
        Me.lblTSName.Size = New System.Drawing.Size(46, 16)
        Me.lblTSName.TabIndex = 19
        Me.lblTSName.Text = "Label4"
        '
        'lblTSCertLabel
        '
        Me.lblTSCertLabel.AutoSize = True
        Me.lblTSCertLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblTSCertLabel.Location = New System.Drawing.Point(106, 170)
        Me.lblTSCertLabel.Name = "lblTSCertLabel"
        Me.lblTSCertLabel.Size = New System.Drawing.Size(121, 16)
        Me.lblTSCertLabel.TabIndex = 20
        Me.lblTSCertLabel.Text = "סטאטוס תעודת הזמן :"
        '
        'lblTSCert
        '
        Me.lblTSCert.AutoSize = True
        Me.lblTSCert.BackColor = System.Drawing.Color.Transparent
        Me.lblTSCert.Location = New System.Drawing.Point(47, 170)
        Me.lblTSCert.Name = "lblTSCert"
        Me.lblTSCert.Size = New System.Drawing.Size(51, 16)
        Me.lblTSCert.TabIndex = 21
        Me.lblTSCert.Text = "לא נבדק"
        '
        'lblStandardLabel
        '
        Me.lblStandardLabel.AutoSize = True
        Me.lblStandardLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.lblStandardLabel.Location = New System.Drawing.Point(425, 102)
        Me.lblStandardLabel.Name = "lblStandardLabel"
        Me.lblStandardLabel.Size = New System.Drawing.Size(65, 16)
        Me.lblStandardLabel.TabIndex = 22
        Me.lblStandardLabel.Text = "תקן חתימה"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.layoutSign)
        Me.pnlHeader.Controls.Add(Me.pixBoxIsVerifyed)
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(505, 24)
        Me.pnlHeader.TabIndex = 2
        '
        'layoutSign
        '
        Me.layoutSign.Controls.Add(Me.lblIsSignOk)
        Me.layoutSign.Location = New System.Drawing.Point(9, 3)
        Me.layoutSign.Name = "layoutSign"
        Me.layoutSign.Size = New System.Drawing.Size(390, 19)
        Me.layoutSign.TabIndex = 3
        '
        'lblIsSignOk
        '
        Me.lblIsSignOk.AutoSize = True
        Me.lblIsSignOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblIsSignOk.ForeColor = System.Drawing.Color.White
        Me.lblIsSignOk.Location = New System.Drawing.Point(292, 0)
        Me.lblIsSignOk.Name = "lblIsSignOk"
        Me.lblIsSignOk.Size = New System.Drawing.Size(95, 16)
        Me.lblIsSignOk.TabIndex = 1
        Me.lblIsSignOk.Text = "חתימה מאושרת"
        '
        'pixBoxIsVerifyed
        '
        Me.pixBoxIsVerifyed.InitialImage = Nothing
        Me.pixBoxIsVerifyed.Location = New System.Drawing.Point(471, 3)
        Me.pixBoxIsVerifyed.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pixBoxIsVerifyed.Name = "pixBoxIsVerifyed"
        Me.pixBoxIsVerifyed.Size = New System.Drawing.Size(19, 20)
        Me.pixBoxIsVerifyed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pixBoxIsVerifyed.TabIndex = 2
        Me.pixBoxIsVerifyed.TabStop = False
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(421, 4)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(37, 16)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "חותם"
        '
        'toolTipState
        '
        Me.toolTipState.AutoPopDelay = 5000
        Me.toolTipState.InitialDelay = 150
        Me.toolTipState.IsBalloon = True
        Me.toolTipState.ReshowDelay = 100
        '
        'lblStandard
        '
        Me.lblStandard.AutoSize = True
        Me.lblStandard.Location = New System.Drawing.Point(374, 102)
        Me.lblStandard.Name = "lblStandard"
        Me.lblStandard.Size = New System.Drawing.Size(45, 16)
        Me.lblStandard.TabIndex = 23
        Me.lblStandard.Text = "לא ידוע"
        '
        'signatureView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "signatureView"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(505, 250)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.layoutSign.ResumeLayout(False)
        Me.layoutSign.PerformLayout()
        CType(Me.pixBoxIsVerifyed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblExpire As System.Windows.Forms.Label
    Friend WithEvents lblIssuer As System.Windows.Forms.Label
    Friend WithEvents lblEndCertificate As System.Windows.Forms.Label
    Friend WithEvents lblChain As System.Windows.Forms.Label
    Friend WithEvents lblCRL As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblIsSignOk As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents pixBoxIsVerifyed As System.Windows.Forms.PictureBox
    Friend WithEvents toolTipState As System.Windows.Forms.ToolTip
    Friend WithEvents layoutSign As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTSState As System.Windows.Forms.Label
    Friend WithEvents lblNameLabel As System.Windows.Forms.Label
    Friend WithEvents lblExpirationDateLabel As System.Windows.Forms.Label
    Friend WithEvents lblIssuerLabel As System.Windows.Forms.Label
    Friend WithEvents lbladLabel As System.Windows.Forms.Label
    Friend WithEvents lblChainLabel As System.Windows.Forms.Label
    Friend WithEvents lblasdfeLabel As System.Windows.Forms.Label
    Friend WithEvents lblTSStateLabel As System.Windows.Forms.Label
    Friend WithEvents lblTSLabel As System.Windows.Forms.Label
    Friend WithEvents lblTS As System.Windows.Forms.Label
    Friend WithEvents lblTSNameLabel As System.Windows.Forms.Label
    Friend WithEvents lblTSName As System.Windows.Forms.Label
    Friend WithEvents lblTSCertLabel As System.Windows.Forms.Label
    Friend WithEvents lblTSCert As System.Windows.Forms.Label
    Friend WithEvents lblStandardLabel As System.Windows.Forms.Label
    Friend WithEvents lblStandard As System.Windows.Forms.Label

End Class
