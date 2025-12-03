Imports SignVerify.Common
Imports SignVerify.GUI.SignVerfiy

Public Class FileRow
    Inherits Panel

#Region "Private members"

    Private _status As RowStatus
    Private _type As RowTypes
    Private _filePath As String
    Friend _index As Integer
    Private _tips As ToolTip
    Private _errorText As String
    Private _statusTooltip As String
    Private _globalSignaturesState As SignaturesStateType
    Private _globalSignaturesTimeStampState As SignaturesStateType
    Private _signedObject As CryptoSignedObject(Of Byte())
    Private WithEvents ctrStatus As Control
    Private WithEvents lblFilename As System.Windows.Forms.Label
    Private WithEvents imgSeparator As System.Windows.Forms.PictureBox
    Private WithEvents plStatusControl As Panel
    Friend WithEvents removePB As System.Windows.Forms.PictureBox
    Friend WithEvents rclickFilesMenu As System.Windows.Forms.ContextMenuStrip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents itemRemove As System.Windows.Forms.ToolStripMenuItem
    Private m_DisplayTS As Boolean

#End Region

#Region "Public properties"

#Region "Events declarations"
    Public Delegate Sub RowClickedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event RowClicked As RowClickedHandler

    Public Delegate Sub RowDeletedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event RowDeleted As RowDeletedHandler
#End Region

    Public Property Status() As RowStatus
        Get
            Return _status
        End Get
        Set(ByVal value As RowStatus)
            _status = value
            bindStatusControl()
            bindVerifiedFlag(m_DisplayTS)
        End Set
    End Property

    Public Property DisplayTS As Boolean
        Get
            Return m_DisplayTS
        End Get
        Set(value As Boolean)
            m_DisplayTS = value
        End Set
    End Property

    Public Property StatusTooltip() As String
        Get
            Return _statusTooltip
        End Get
        Set(ByVal value As String)
            _statusTooltip = value
            bindStatusTooltip()
        End Set
    End Property

    Public ReadOnly Property Type() As RowTypes
        Get
            Return _type
        End Get
    End Property

    Public Property FilePath() As String
        Get
            Return _filePath
        End Get
        Set(ByVal value As String)
            _filePath = value
            bindFilePathControl()
        End Set
    End Property

    Public Property ErrorText() As String
        Get
            Return _errorText
        End Get
        Set(ByVal value As String)
            _errorText = value
            bindStatusTooltip()
        End Set
    End Property

    Public Property SignedObject() As CryptoSignedObject(Of Byte())
        Get
            Return _signedObject
        End Get
        Set(ByVal value As CryptoSignedObject(Of Byte()))
            _signedObject = value
            If Not _signedObject Is Nothing Then
                _globalSignaturesState = Me._signedObject.signatureInfos.getGlobalSignatureState()
                _globalSignaturesTimeStampState = Me._signedObject.signatureInfos.getGlobalTimeStampState()
            End If
            bindVerifiedFlag(m_DisplayTS)
        End Set
    End Property

    Public ReadOnly Property GlobalSignatureState() As SignaturesStateType
        Get
            Return _globalSignaturesState
        End Get
    End Property
    Public ReadOnly Property GlobalSignatureTimeStampState() As SignaturesStateType
        Get
            Return _globalSignaturesTimeStampState
        End Get
    End Property
#End Region

#Region "Constructor"

    Public Sub New(ByVal filepath As String, ByVal type As RowTypes)
        InitializeComponent()
        _tips = New ToolTip
        _type = type

        Me.FilePath = filepath
        Me.Status = RowStatus.None

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.plStatusControl = New System.Windows.Forms.Panel()
        Me.imgSeparator = New System.Windows.Forms.PictureBox()
        Me.removePB = New System.Windows.Forms.PictureBox()
        Me.rclickFilesMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemRemove = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.imgSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.removePB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rclickFilesMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFilename
        '
        Me.lblFilename.BackColor = System.Drawing.Color.White
        Me.lblFilename.ForeColor = System.Drawing.Color.Black
        Me.lblFilename.Location = New System.Drawing.Point(40, 0)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Padding = New System.Windows.Forms.Padding(5)
        Me.lblFilename.Size = New System.Drawing.Size(590, 50)
        Me.lblFilename.TabIndex = 0
        Me.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plStatusControl
        '
        Me.plStatusControl.BackColor = System.Drawing.Color.White
        Me.plStatusControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plStatusControl.Location = New System.Drawing.Point(0, 0)
        Me.plStatusControl.Name = "plStatusControl"
        Me.plStatusControl.Size = New System.Drawing.Size(50, 50)
        Me.plStatusControl.TabIndex = 0
        '
        'imgSeparator
        '
        Me.imgSeparator.Image = Global.SignVerify.GUI.My.Resources.Resources.separator
        Me.imgSeparator.Location = New System.Drawing.Point(0, 199)
        Me.imgSeparator.Name = "imgSeparator"
        Me.imgSeparator.Size = New System.Drawing.Size(400, 1)
        Me.imgSeparator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgSeparator.TabIndex = 0
        Me.imgSeparator.TabStop = False
        '
        'removePB
        '
        Me.removePB.BackColor = System.Drawing.Color.White
        Me.removePB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.removePB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.removePB.Image = Global.SignVerify.GUI.My.Resources.Resources.del_small
        Me.removePB.Location = New System.Drawing.Point(0, 0)
        Me.removePB.Name = "removePB"
        Me.removePB.Size = New System.Drawing.Size(50, 50)
        Me.removePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.removePB.TabIndex = 0
        Me.removePB.TabStop = False
        '
        'rclickFilesMenu
        '
        Me.rclickFilesMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemRemove})
        Me.rclickFilesMenu.Name = "rclickFilesMenu"
        Me.rclickFilesMenu.Size = New System.Drawing.Size(165, 26)
        '
        'itemRemove
        '
        Me.itemRemove.Name = "itemRemove"
        Me.itemRemove.Size = New System.Drawing.Size(164, 22)
        Me.itemRemove.Text = "Remove from list"
        '
        'FileRow
        '
        Me.ContextMenuStrip = Me.rclickFilesMenu
        Me.Controls.Add(Me.plStatusControl)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.imgSeparator)
        CType(Me.imgSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.removePB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rclickFilesMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private methodes"


    Private Sub bindFilePathControl()
        Me.lblFilename.Text = IO.Path.GetFileName(FilePath)
        _tips.SetToolTip(lblFilename, FilePath)
    End Sub

    Private Sub bindStatusControl()

        Select Case Status

            'on row inactive
            Case RowStatus.None
                Dim dummyLabel As New Label
                ctrStatus = dummyLabel
                Me._statusTooltip = ""
                Dim imgBtn As New Button
                imgBtn.Image = My.Resources.del_small

                imgBtn.Size = New Point(50, 50)


                removePB.Image = My.Resources.del_small

                ctrStatus = removePB
                Me._statusTooltip = ErrorText
                Me.StatusTooltip += "" + My.Resources.ControlStrings.OptionDiagCancel_Button
                'on row active
            Case RowStatus.Active
                Dim activationCircle As New SignVerify.GUI.Controls.LoadingCircle
                With activationCircle

                    .Active = True
                    .Color = System.Drawing.Color.FromArgb(0, 66, 135)
                    .InnerCircleRadius = 8
                    .NumberSpoke = 9
                    .OuterCircleRadius = 12
                    .RotationSpeed = 100
                    .SpokeThickness = 4
                    .Location = New System.Drawing.Point(0, 0)
                    .Size = New System.Drawing.Size(32, 32)

                End With
                ctrStatus = activationCircle
                Me._statusTooltip = "processing"

                'on row action ended with error
            Case RowStatus.Error
                Dim imgBtn As New Button
                imgBtn.Image = My.Resources.XErroMessage_copy
                imgBtn.Size = New Point(50, 50)

                Dim img As New PictureBox
                img.Image = My.Resources.XErroMessage_copy
                img.Size = New Point(50, 50)
                img.SizeMode = PictureBoxSizeMode.CenterImage
                img.Location = New System.Drawing.Point(0, 0)
                imgBtn.Location = New System.Drawing.Point(0, 0)
                ctrStatus = img
                Me._statusTooltip = ErrorText
                Me.StatusTooltip += "." + My.Resources.ControlStrings.SignVerifyClickForDetails


            Case RowStatus.Zipped
                Dim img As New PictureBox
                img.Image = My.Resources.zipped
                ctrStatus = img
                Me._statusTooltip = My.Resources.ControlStrings.SignVerifyFileZipped


            Case RowStatus.ZipResult
                Dim img As New PictureBox
                img.Image = My.Resources.zipped
                ctrStatus = img
                Me._statusTooltip = My.Resources.ControlStrings.SignVerifyFileResultZipped

        End Select

        plStatusControl.Controls.Clear()
        plStatusControl.Controls.Add(ctrStatus)
        bindStatusTooltip()
    End Sub

    Private Sub bindStatusTooltip()
        If Not ctrStatus Is Nothing Then
            _tips.SetToolTip(ctrStatus, StatusTooltip)
        End If
    End Sub

    Private Sub bindVerifiedFlag(ByVal DisplayTS As Boolean)
        If Me.Status = RowStatus.Verified AndAlso Not SignedObject Is Nothing Then

            Dim img As New PictureBox
            Dim imgBtn As New Button
            imgBtn.Size = New Point(50, 50)
            img.Size = New Point(50, 50)
            img.SizeMode = PictureBoxSizeMode.CenterImage
            img.Location = New System.Drawing.Point(0, 0)
            imgBtn.Location = New System.Drawing.Point(0, 0)
            img.Image = My.Resources.SignYellow

            'set the flag image according to the signatures state
            Select Case Me.GlobalSignatureState
                Case SignaturesStateType.Valid
                    img.Image = My.Resources.SignGreen
                    imgBtn.Image = My.Resources.SignGreen
                    Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationStatusGreenplural
                Case SignaturesStateType.Unchecked
                    img.Image = My.Resources.SignYellow
                    imgBtn.Image = My.Resources.SignYellow
                    Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationStatusUncheckedPlural
                Case SignaturesStateType.UnValid
                    img.Image = My.Resources.SignRed
                    imgBtn.Image = My.Resources.SignRed
                    Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationStatusUnvalidPlural
            End Select
            Me.StatusTooltip += Environment.NewLine
            Select Case Me.GlobalSignatureTimeStampState
                Case SignaturesStateType.Valid
                    Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusGreenPlural
                Case SignaturesStateType.Unchecked
                    If m_DisplayTS Then
                        img.Image = My.Resources.SignYellow
                        imgBtn.Image = My.Resources.SignYellow
                        Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusEmptyPlural
                    End If
                Case SignaturesStateType.UnValid
                    img.Image = My.Resources.SignRed
                    imgBtn.Image = My.Resources.SignRed
                    Me.StatusTooltip = My.Resources.ControlStrings.successDiaglblVerificationTimeStampStatusUnvalidPlural
            End Select
            Me.StatusTooltip += " " + My.Resources.ControlStrings.SignVerifyClickForDetails
            ctrStatus = img
            plStatusControl.Controls.Clear()
            plStatusControl.Controls.Add(ctrStatus)
            bindStatusTooltip()
        End If
    End Sub

#End Region

#Region "events"

    Private Sub OnRowEnter(ByVal sender As Object, ByVal e As EventArgs) Handles lblFilename.MouseEnter, plStatusControl.MouseEnter, imgSeparator.MouseEnter, Me.MouseEnter, ctrStatus.MouseEnter
        lblFilename.ForeColor = Color.Black
        lblFilename.BackColor = System.Drawing.Color.White
        If Me.Status = RowStatus.Verified Or Me.Status = RowStatus.Error Or Me.Status = RowStatus.ZipResult Or Me.Status = RowStatus.Zipped Then
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub onRowLeave(ByVal sender As Object, ByVal e As EventArgs) Handles lblFilename.MouseLeave, plStatusControl.MouseLeave, imgSeparator.MouseLeave, Me.MouseLeave, ctrStatus.MouseLeave
        lblFilename.ForeColor = Color.Black
        lblFilename.BackColor = Color.White
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub onRowClick(ByVal sender As Object, ByVal e As EventArgs) Handles plStatusControl.Click, imgSeparator.Click, Me.Click, ctrStatus.Click
        RaiseEvent RowClicked(Me, New EventArgs)
    End Sub


#End Region

    Private Sub removePB_Click(sender As System.Object, e As System.EventArgs) Handles removePB.Click
        RaiseEvent RowDeleted(Me, New EventArgs)
    End Sub

    Private Sub rclickFilesMenu_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles rclickFilesMenu.ItemClicked
        Select e.ClickedItem.ToString()
            Case "Remove from list"
                RaiseEvent RowDeleted(Me, New EventArgs)
        End Select
    End Sub
End Class

#Region "enums"

'row status types
Public Enum RowStatus
    None
    Active
    [Error]
    Zipped
    ZipResult
    Verified
End Enum

'row types
Public Enum RowTypes
    PhysicalFile
    StreamZip
End Enum

#End Region



