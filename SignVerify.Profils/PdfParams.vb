Imports System.Xml

Namespace SignVerify.Profils

#Region "Enum"

    Public Enum PositionTypes
        NotDefined = -1
        TopRight = 0
        TopMiddle = 1
        TopLeft = 2
        BottomRight = 10
        BottomMiddle = 11
        BottomLeft = 12
    End Enum

#End Region

    Public Class PdfParams

#Region "Public members"
        Public IsVisible As Boolean
        Public Text As String
        Public Reason As String
        Public ShowImage As Boolean
        Public UseDefaultImage As Boolean
        Public ImagePath As String
        Public Location As String
        Public Contact As String
        Public ShowName As Boolean
        Public Position As Nullable(Of PositionTypes)

#End Region

#Region "Constructor"

        Public Sub New()

            'Load default value
            IsVisible = False
            Text = "נחתם דיגיטלית על ידי."
            ShowName = True
            Reason = ""
            ShowImage = False
            UseDefaultImage = False
            ImagePath = ""
            Location = ""
            Contact = ""
            Position = PositionTypes.TopLeft
        End Sub

#End Region

#Region "Public methodes"

        'is equal , return true if the options aren't the sames
        Public Function isEqual(ByVal param As PdfParams) As Boolean
            If param.IsVisible <> Me.IsVisible Then Return False
            If param.Text <> Me.Text Then Return False
            If param.Reason <> Me.Reason Then Return False
            If param.ShowImage <> Me.ShowImage Then Return False
            If param.UseDefaultImage <> Me.UseDefaultImage Then Return False
            If param.ImagePath <> Me.ImagePath Then Return False
            If param.Location <> Me.Location Then Return False
            If param.Contact <> Me.Contact Then Return False
            If param.Position <> Me.Position Then Return False
            If param.ShowName <> Me.ShowName Then Return False
            Return True
        End Function

#End Region



    End Class
End Namespace