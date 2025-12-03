<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallFW
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.layoutHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.layoutHeader.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.Panel2.Controls.Add(Me.btnReplace)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 122)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(466, 46)
        Me.Panel2.TabIndex = 2
        '
        'btnReplace
        '
        Me.btnReplace.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReplace.Location = New System.Drawing.Point(7, 11)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(59, 24)
        Me.btnReplace.TabIndex = 0
        Me.btnReplace.Text = "סגור"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.pnlHeader.Controls.Add(Me.layoutHeader)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(466, 39)
        Me.pnlHeader.TabIndex = 1
        '
        'layoutHeader
        '
        Me.layoutHeader.BackColor = System.Drawing.Color.Transparent
        Me.layoutHeader.ColumnCount = 2
        Me.layoutHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.587257!))
        Me.layoutHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.41274!))
        Me.layoutHeader.Controls.Add(Me.lblHeader, 1, 0)
        Me.layoutHeader.Controls.Add(Me.picError, 0, 0)
        Me.layoutHeader.Location = New System.Drawing.Point(4, 1)
        Me.layoutHeader.Name = "layoutHeader"
        Me.layoutHeader.RowCount = 1
        Me.layoutHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutHeader.Size = New System.Drawing.Size(459, 33)
        Me.layoutHeader.TabIndex = 2
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(3, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(414, 33)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "חסרה תשתית 3.5"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.Transparent
        Me.picError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picError.Image = Global.SignVerify.GUI.My.Resources.Resources.XErroMessage_copy
        Me.picError.Location = New System.Drawing.Point(423, 3)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(33, 27)
        Me.picError.TabIndex = 0
        Me.picError.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 75)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " לצורך ביצוע החתימה בתקן Xades  נדרשת תשתית Microsoft Framework 3.5 ."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "באפשרותך להוריד תשתית זו "
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(273, 36)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(32, 16)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "מכאן"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "או לבחור פרופיל חתימה אחר בתפריט אפשרויות."
        '
        'InstallFW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 168)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InstallFW"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "חסרה תשתית 3.5"
        Me.Panel2.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.layoutHeader.ResumeLayout(False)
        Me.layoutHeader.PerformLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents layoutHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
