Imports System.ComponentModel

Public Enum PanelStateType
    Collapsed = 0
    Expanded = 1
    None = 2
End Enum

Friend Class CollapsePanel
    Inherits UserControl

#Region "Variables and Enumerations"

    Private _Index As Long
    Private _State As PanelStateType
    Private WithEvents _lblHeader As Label
    Private WithEvents _plHeader As Panel
    Private _plSignatures As Panel
    Private WithEvents _CollapsedImage As PictureBox
    Private WithEvents _ExpandedImage As PictureBox
    Private _ExpandedRowHeight As Integer
    Private WithEvents _signaturesViews As List(Of signatureView)
    Private _PanelBackGroundImage As Drawing.Image

#End Region

#Region "Event declarations"

    'event declarations
    Public Delegate Sub CollapseHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Delegate Sub ExpandHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Collapse As CollapseHandler
    Public Event Expand As ExpandHandler

#End Region

#Region "Control Properties"

    'the panel index
    '(for panel collection)
    Public Property Index() As Long
        Get
            Return _Index
        End Get
        Set(ByVal value As Long)
            _Index = value
        End Set
    End Property

    'the panel state (collapsed, expanded..)
    Public Property State() As PanelStateType
        Get
            Return _State
        End Get
        Set(ByVal value As PanelStateType)

            _State = value
            If value = PanelStateType.Expanded Then
                RaiseEvent Expand(Me, New EventArgs)
            Else
                RaiseEvent Collapse(Me, New EventArgs)
            End If

        End Set
    End Property

    'the header label
    Public Property HeaderLabel() As Label
        Get
            Return _lblHeader
        End Get
        Set(ByVal value As Label)
            _lblHeader = value
        End Set
    End Property

    'the header height
    Public Property HeaderHeight() As Integer
        Get
            Return _plHeader.Height
        End Get
        Set(ByVal value As Integer)
            __plHeader.Height = value
        End Set
    End Property

    'the collapsed image
    Public Property CollapsedImage() As PictureBox
        Get
            Return _CollapsedImage
        End Get
        Set(ByVal value As PictureBox)
            _CollapsedImage = value
        End Set
    End Property

    'the expanded image
    Public Property ExpandedImage() As PictureBox
        Get
            Return _ExpandedImage
        End Get
        Set(ByVal value As PictureBox)
            _ExpandedImage = value
        End Set
    End Property

    'the actual header image(for internal use only)
    Private ReadOnly Property _HeaderImage() As PictureBox
        Get
            Select Case State
                Case PanelStateType.Collapsed
                    Return CollapsedImage
                Case PanelStateType.Expanded
                    Return ExpandedImage
            End Select
        End Get
    End Property

    'the expanded row height
    Public Property ExpandedRowHeight() As Integer
        Get
            Return _ExpandedRowHeight
        End Get
        Set(ByVal value As Integer)
            _ExpandedRowHeight = value
        End Set
    End Property

    'the signatures views
    Public Property SignaturesViews() As List(Of signatureView)
        Get
            Return _signaturesViews
        End Get
        Set(ByVal value As List(Of signatureView))
            _signaturesViews = value
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
#End Region

#Region "Constructor"

    Public Sub New()
        _signaturesViews = New List(Of signatureView)

        'panel header 
        _plHeader = New Panel
        _plHeader.BackgroundImage = PanelBackGroundImage

        'image header
        _CollapsedImage = New PictureBox
        _ExpandedImage = New PictureBox

        'label header
        _lblHeader = New Label
        _lblHeader.ForeColor = Color.White
        _lblHeader.Image = _CollapsedImage.Image
        _lblHeader.ImageAlign = ContentAlignment.MiddleLeft
        _plHeader.Controls.Add(_lblHeader)
        _plHeader.BackgroundImage = PanelBackGroundImage

        'panel signatures
        _plSignatures = New Panel
        _plSignatures.Width = Me.Width
        _plSignatures.BackgroundImage = PanelBackGroundImage

        Me.Controls.Add(_plHeader)
        Me.Controls.Add(_plSignatures)

    End Sub

#End Region

#Region "Event Handlers"

    'on the panel clicked
    Friend Sub on_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _plHeader.Click, _lblHeader.Click, _CollapsedImage.Click, _ExpandedImage.Click
        If _State = PanelStateType.Collapsed Then
            DoExpand()
        Else
            DoCollapse()
        End If
    End Sub

    'on the size changed
    Private Sub on_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        _plHeader.Width = Me.Width
        _lblHeader.Width = _plHeader.Width - _HeaderImage.Width
        _plSignatures.Width = Me.Width
    End Sub

#End Region

#Region "Drawing Functions"

    'on created
    Protected Overrides Sub OnCreateControl()

        Select Case State

            Case PanelStateType.Collapsed
                DoCollapse()

            Case PanelStateType.Expanded
                DoExpand()

        End Select

        'signatures panel options
        _plSignatures.Location = New Point(0, _plHeader.Height)
        _plSignatures.BackColor = Color.White

        'add the signatures view to the panel
        Dim height As Long = 0
        For Each sign As signatureView In _signaturesViews
            sign.Location = New Point(0, height)
            _plSignatures.Controls.Add(sign)

            height = height + sign.Height
            'height = height + _ExpandedRowHeight
        Next
        _plSignatures.Height = height


    End Sub

    Friend Sub DoExpand()
        State = PanelStateType.Expanded
        _lblHeader.Image = _ExpandedImage.Image
        _plSignatures.Show()
    End Sub

    Friend Sub DoCollapse()
        State = PanelStateType.Collapsed
        _lblHeader.Image = _CollapsedImage.Image
        _plSignatures.Hide()
    End Sub
#End Region

#Region "Initialize"
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'CollapsePanel
        '
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Name = "CollapsePanel"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class

