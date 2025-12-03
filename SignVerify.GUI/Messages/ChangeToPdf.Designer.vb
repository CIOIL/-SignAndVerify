<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeToPdf
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
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.layoutHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutMeesasge = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.layoutHeader.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutMeesasge.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.Panel2.Controls.Add(Me.btnYes)
        Me.Panel2.Controls.Add(Me.btnNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(367, 46)
        Me.Panel2.TabIndex = 2
        '
        'btnYes
        '
        Me.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnYes.Location = New System.Drawing.Point(71, 11)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(58, 24)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "כן"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnNo.Location = New System.Drawing.Point(7, 11)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(58, 24)
        Me.btnNo.TabIndex = 0
        Me.btnNo.Text = "לא"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.blueBack
        Me.pnlHeader.Controls.Add(Me.layoutHeader)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(367, 39)
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
        Me.layoutHeader.Size = New System.Drawing.Size(361, 33)
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
        Me.lblHeader.Size = New System.Drawing.Size(325, 33)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "קובץ קיים"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.Transparent
        Me.picError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picError.Image = Global.SignVerify.GUI.My.Resources.Resources.question
        Me.picError.Location = New System.Drawing.Point(334, 3)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(24, 27)
        Me.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picError.TabIndex = 0
        Me.picError.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.grayFooterBack
        Me.Panel1.Controls.Add(Me.FlowLayoutMeesasge)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(367, 46)
        Me.Panel1.TabIndex = 3
        '
        'FlowLayoutMeesasge
        '
        Me.FlowLayoutMeesasge.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutMeesasge.Controls.Add(Me.lblMessage)
        Me.FlowLayoutMeesasge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutMeesasge.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutMeesasge.Name = "FlowLayoutMeesasge"
        Me.FlowLayoutMeesasge.Size = New System.Drawing.Size(367, 46)
        Me.FlowLayoutMeesasge.TabIndex = 21
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Location = New System.Drawing.Point(34, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(330, 32)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "פרופיל זה מאפשר חתימה על קבצי PDF בלבד. בחירת הפרופיל תבטל את בחירת הקבצים הנוכחי" & _
    "ת. האם להמשיך?"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(367, 46)
        Me.FlowLayoutPanel1.TabIndex = 22
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.Dots
        Me.Panel3.Location = New System.Drawing.Point(7, 44)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(352, 2)
        Me.Panel3.TabIndex = 20
        '
        'ChangeToPdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 126)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangeToPdf"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "קובץ קיים"
        Me.Panel2.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.layoutHeader.ResumeLayout(False)
        Me.layoutHeader.PerformLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutMeesasge.ResumeLayout(False)
        Me.FlowLayoutMeesasge.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents picError As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutMeesasge As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents layoutHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnYes As System.Windows.Forms.Button

End Class
