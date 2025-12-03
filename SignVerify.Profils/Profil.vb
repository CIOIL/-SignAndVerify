Imports System.Xml

Namespace SignVerify.Profils

#Region "Enum"

    Public Enum SavingTypes
        Separate = 0
        Zip = 1
        SeparateAndZip = 2
    End Enum

#End Region

    Public Class Profil

#Region "Public members"

        Public FriendlyName As String
        Public ProviderName As String
        Public ShowOnlyNonRepudiation As Boolean
        Public SignAlgorithm As String
        Public CheckTimeStamp As Boolean
        Public CheckCertificationPath As Boolean
        Public CheckCRL As Boolean
        Public DisplayTimeStamp As Boolean
        Public TimeStampURL As String
        Public SavingType As Nullable(Of SavingTypes)
        Public PdfParameters As PdfParams

#End Region

#Region "Constructor"

        Public Sub New()

            'Load default value
            FriendlyName = "Default"
            ProviderName = "XmlDigSig crypto provider."
            ShowOnlyNonRepudiation = False
            SignAlgorithm = "RSA"
            CheckTimeStamp = False
            CheckCertificationPath = True
            CheckCRL = True
            DisplayTimeStamp = False
            TimeStampURL = ""
            SavingType = Nothing
            PdfParameters = Nothing
        End Sub

#End Region

#Region "Public methodes"

        'is equal , return true if the options aren't the sames
        Public Function isEqual(ByVal prof As Profil) As Boolean
            If prof.ProviderName <> Me.ProviderName Then Return False
            If prof.SignAlgorithm <> Me.SignAlgorithm Then Return False
            If prof.ShowOnlyNonRepudiation <> Me.ShowOnlyNonRepudiation Then Return False
            If prof.CheckCertificationPath <> Me.CheckCertificationPath Then Return False
            If prof.CheckCRL <> Me.CheckCRL Then Return False
            If prof.CheckTimeStamp <> Me.CheckTimeStamp Then Return False
            If prof.DisplayTimeStamp <> Me.DisplayTimeStamp Then Return False
            'If prof.TimeStampURL <> Me.TimeStampURL Then Return False
            If prof.SavingType <> Me.SavingType Then Return False
            If PdfParameters Is Nothing And Me.PdfParameters IsNot Nothing Then Return False
            If PdfParameters IsNot Nothing And Me.PdfParameters Is Nothing Then Return False
            If PdfParameters Is Nothing And Me.PdfParameters Is Nothing Then Return True
            Return prof.PdfParameters.isEqual(Me.PdfParameters)
        End Function

#End Region



    End Class
End Namespace