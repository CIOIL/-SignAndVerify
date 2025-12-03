Imports SignVerify.Common
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.ComponentModel
Imports SignVerify.GUI.CollapsePanel


Public Class SignaturesTreeGrid
    Inherits UserControl

#Region "Variables and Enumerations"

    'the signatures list
    Private _signatures As CryptoSignatureInfoCollection
    'the panels collection
    Private _panelsCollection As List(Of CollapsePanel)

    'the controls properties
    Private _InitialState As PanelStateType
    Private _ExpandedImage As Drawing.Image
    Private _CollapsedImage As Drawing.Image
    Private _HeaderHeight As Integer
    Private _ExpandedRowHeight As Integer
    Private _PanelBackGroundImage As Drawing.Image

    Private _IsAllClosed As Boolean
    Private _IsAllOpen As Boolean
    Public DisplayTS As Boolean
#End Region

#Region "Control Properties"

    'the signatures list
    <Browsable(False)> _
    Public Property signatures() As CryptoSignatureInfoCollection
        Get
            Return _signatures
        End Get
        Set(ByVal value As CryptoSignatureInfoCollection)
            _signatures = value
        End Set
    End Property

    'If all signature are closed
    <Browsable(False)> _
    Public ReadOnly Property IsAllClosed() As Boolean
        Get
            Return _IsAllClosed
        End Get
    End Property

    'If all signature are open
    <Browsable(False)> _
    Public ReadOnly Property IsAllOpen() As Boolean
        Get
            Return _IsAllOpen
        End Get
    End Property

    'the generals properties
    <Category("General")> _
    Public Property InitialState() As PanelStateType
        Get
            Return _InitialState
        End Get
        Set(ByVal value As PanelStateType)
            _InitialState = value
        End Set
    End Property

    'the header properties
    'the back ground image of each row 
    <Category("Header")> _
    Public Property PanelBackGroundImage() As Drawing.Image
        Get
            Return _PanelBackGroundImage
        End Get
        Set(ByVal value As Drawing.Image)
            _PanelBackGroundImage = value
        End Set
    End Property


    'the header properties
    'the expanded image
    <Category("Header")> _
    Public Property ExpandedImage() As Drawing.Image
        Get
           
            Return _ExpandedImage
        End Get
        Set(ByVal value As Drawing.Image)
            _ExpandedImage = value
        End Set
    End Property

    'the collapsed image
    <Category("Header")> _
    Public Property CollapsedImage() As Drawing.Image
        Get
            Return _CollapsedImage
        End Get
        Set(ByVal value As Drawing.Image)
            _CollapsedImage = value
        End Set
    End Property


    'the header height
    <Category("Header")> _
    Public Property HeaderHeight() As Integer
        Get
            Return _HeaderHeight
        End Get
        Set(ByVal value As Integer)
            _HeaderHeight = value
        End Set
    End Property

    'the row properties
    'the expanded row height
    <Category("Row")> _
    Public Property ExpandedRowHeight() As Integer
        Get
            Return _ExpandedRowHeight
        End Get
        Set(ByVal value As Integer)
            _ExpandedRowHeight = value
        End Set
    End Property

#End Region

#Region "Constructor"

    'constructor
    Public Sub New()

        InitializeComponent()
        _signatures = New CryptoSignatureInfoCollection
        _panelsCollection = New List(Of CollapsePanel)
        'set default properties value
        _InitialState = PanelStateType.Collapsed
        _ExpandedImage = Global.SignVerify.GUI.My.Resources.Minus1
        _PanelBackGroundImage = Global.SignVerify.GUI.My.Resources.HeaderBack
        _CollapsedImage = Global.SignVerify.GUI.My.Resources.Plus1
      
        _HeaderHeight = 24
    End Sub

#End Region

#Region "Private builder"

    Private Sub InitializeLevels()

        'panel properties
        Dim plWidth As Long = Me.Width

        Me.SuspendLayout()


        'navigation into signatures for controls creating
        Dim counter As Integer = _signatures.getLevelCount()
        Dim index As Integer = 1
        While counter >= 1


            'get element counter for this level
            Dim count As Long = signatures.getLevel(counter - 1).Count

            'container panel creation
            Dim pl As New CollapsePanel

            pl.Index = index
            pl.Width = plWidth
            pl.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            pl.HeaderHeight = _HeaderHeight
            pl.BackgroundImage = PanelBackGroundImage
            pl.State = _InitialState
            pl.ExpandedImage.Image = ExpandedImage
            pl.PanelBackGroundImage = My.Resources.HeaderBack
            pl.ExpandedImage.SizeMode = PictureBoxSizeMode.AutoSize
            pl.CollapsedImage.Image = CollapsedImage
            pl.CollapsedImage.SizeMode = PictureBoxSizeMode.AutoSize
            pl.HeaderLabel.Text = "     " + My.Resources.ControlStrings.SignaturesTreeGridLevel + " " + GetLevelHeaderLetter(counter)
            pl.HeaderLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
            pl.ExpandedRowHeight = _ExpandedRowHeight

            'events attach
            AddHandler pl.Collapse, AddressOf onCollapse
            AddHandler pl.Expand, AddressOf onExpand

            Dim NumOfSignerCounter As Integer = 1
            'add signatures views
            For Each sign As CryptoSignatureInfo In signatures.getLevel(counter - 1)
                pl.SignaturesViews.Add(New signatureView(sign, NumOfSignerCounter, DisplayTS))
                NumOfSignerCounter += 1
            Next

            'add panel
            _panelsCollection.Add(pl)
            Controls.Add(pl)

            'counting
            counter = counter - 1
            index = index + 1
        End While

        'set the location for each panel
        setPanelsLocation()

        Me.ResumeLayout(False)
    End Sub

    Private Function GetLevelHeaderLetter(ByVal LevelCount As Integer) As String
        GetLevelHeaderLetter = LevelCount.ToString
    End Function

    'p

    'set the location for each panel
    Private Sub setPanelsLocation()
        Dim positionY As Long = 0

        For Each pl As CollapsePanel In _panelsCollection
            positionY = positionY + pl.Height
        Next


        Dim positionX As Long = 0
        If Me.Parent.Size.Height < positionY Then
            positionX = -17
        End If
        positionY = 0
        For Each pl As CollapsePanel In _panelsCollection
            pl.Location = New Point(positionX, positionY)
            positionY = positionY + pl.Height
            pl.Refresh()
        Next
        'resize the control's height 
        Me.Height = positionY
    End Sub

#End Region

#Region "Event Handlers"

    'on panel collased
    Public Sub onCollapse(ByVal sender As Object, ByVal e As EventArgs)
        Dim cpl As CollapsePanel = CType(sender, CollapsePanel)

        cpl.Height = _HeaderHeight
        setPanelsLocation()

        If IsAllCollapsed() Then
            _IsAllClosed = True
            _IsAllOpen = False
        End If
    End Sub
    'checks if all signature panels are collapsed
    Private Function IsAllCollapsed() As Boolean
        For Each PanelCollapse As CollapsePanel In _panelsCollection
            If PanelCollapse.Height <> _HeaderHeight Then
                Return False
            End If
        Next
        Return True
    End Function

    'on panel expanded
    Public Sub onExpand(ByVal sender As Object, ByVal e As EventArgs)
        Dim cpl As CollapsePanel = CType(sender, CollapsePanel)
        cpl.Height = cpl.SignaturesViews.Count * (_ExpandedRowHeight + 40) + _HeaderHeight
        setPanelsLocation()

        If IsAllExpanded() Then
            _IsAllOpen = True
            _IsAllClosed = False
        End If
    End Sub


    'checks if all signature panels are expanded
    Private Function IsAllExpanded() As Boolean
        For Each PanelExpand As CollapsePanel In _panelsCollection
            If PanelExpand.Height = _HeaderHeight Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Sub CollapseAll()
        For Each PanelCollapse As CollapsePanel In _panelsCollection
            PanelCollapse.DoCollapse()
        Next
        _IsAllClosed = True
        _IsAllOpen = False
    End Sub
    Public Sub ExpandAll()
        For Each PanelExpand As CollapsePanel In _panelsCollection
            PanelExpand.DoExpand()
        Next
        _IsAllOpen = True
        _IsAllClosed = False
    End Sub
#End Region

#Region "Drawing Functions"

    'on control rendered
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    'on control created
    Protected Overrides Sub OnCreateControl()
        InitializeLevels()
        MyBase.OnCreateControl()
    End Sub

#End Region

End Class
