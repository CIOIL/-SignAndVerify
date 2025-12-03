Imports System.ComponentModel

Public Class FileList
    Inherits TableLayoutPanel

#Region "Privates members"
    Private _rows As List(Of FileRow)
    Private _DisplayTS As Boolean
#End Region

#Region "Publics properties"

#Region "Events declarations"
    Public Delegate Sub RowClickedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event RowClicked As RowClickedHandler
    Public Delegate Sub RowDeletedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event RowDeleted As RowClickedHandler
#End Region

    Public ReadOnly Property Rows() As List(Of FileRow)
        Get
            Return _rows
        End Get
    End Property

    Public Property DisplayTS As Boolean
        Set(value As Boolean)
            _DisplayTS = value
            For Each r As FileRow In Me.Rows
                r.DisplayTS = _DisplayTS
            Next
        End Set
        Get
            Return _DisplayTS
        End Get
    End Property

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()


        'set the table properties
        RowCount = 0
        ColumnCount = 2
        DoubleBuffered = True
        _rows = New List(Of FileRow)

        Me.SetStyle(ControlStyles.DoubleBuffer, True)


        ' This enables mouse support such as the Mouse Wheel
        SetStyle(ControlStyles.UserMouse, True)


    End Sub

#End Region

#Region "Publics methodes"

    Public Function addRow(ByVal filepath As String) As Boolean
        If Me.Rows.Exists((Function(r) (r.FilePath.Equals(filepath)))) Then
            Return False
        Else
            Me.SuspendLayout()


            'create the row element
            Dim row As New FileRow(filepath, RowTypes.PhysicalFile)
            row.DisplayTS = Me.DisplayTS
            row.Size = New System.Drawing.Size(627, 55)
            AddHandler row.RowClicked, AddressOf onRowClicked
            AddHandler row.RowDeleted, AddressOf onRowDeleted
            Dim lblPosition As New TableLayoutPanelCellPosition(0, Me.RowCount)

            'add the controls to the table
            Me.SetCellPosition(row, lblPosition)
            Me.Controls.Add(row)
            Me.Rows.Add(row)
            SetRowStyle()
            RowCount += 1
            Me.Parent.BackgroundImage = Nothing
            Me.ResumeLayout()
        End If
        Return True
    End Function



    Public Sub removeRow(ByVal rowIndex As Integer)

        If rowIndex > RowCount Or rowIndex = -1 Then Return

        Me.SuspendLayout()

        'remove the control
        Me.Controls.Remove(Me.GetControlFromPosition(0, rowIndex))
        Me.Rows.RemoveAt(rowIndex)

        'replace others controls
        For Each cont As Control In Me.Controls
            Dim pos As TableLayoutPanelCellPosition = Me.GetCellPosition(cont)
            If pos.Row > rowIndex Then Me.SetCellPosition(cont, New TableLayoutPanelCellPosition(pos.Column, pos.Row - 1))
        Next


        Me.ResumeLayout()
        Me.RowCount -= 1
        If Me.RowCount < 1 Then
            Me.Parent.BackgroundImage = Global.SignVerify.GUI.My.Resources.Resources.letter
        End If
    End Sub


    Public Sub clear()
        Me.Controls.Clear()
        Me.Rows.Clear()
        Me.RowCount = 0
    End Sub

#End Region

#Region "Privates methodes"

    Private Sub SetRowStyle()
        Dim style As New RowStyle
        style.Height = 59
        style.SizeType = SizeType.Absolute
        RowStyles.Add(style)
    End Sub

#End Region

#Region "event"

    'propagate the row clicked event
    Private Sub onRowClicked(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent RowClicked(sender, e)
    End Sub

    Private Sub onRowDeleted(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent RowDeleted(sender, e)
       

    End Sub

#End Region

   


End Class
