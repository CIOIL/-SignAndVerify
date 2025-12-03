Imports Microsoft.Win32
Imports System.Security.Permissions

<Assembly: RegistryPermissionAttribute( _
    SecurityAction.RequestMinimum, ViewAndModify:="HKEY_CURRENT_USER")> 
Namespace SignVerify.Profils

    Public Class RegistryProfil
        Inherits Profil

#Region "Public members"

        Private RegistryFolder As RegistryKey
        Public SelectedProfil As String
        Public AutoDestinationFolder As Boolean
        Public DestinationFolder As String
        Public ShowSignOption As Boolean
        Public LastCertificateSN As String

#End Region


#Region "Constructor"

        'constructor
        Public Sub New()
            MyBase.New()
            AutoDestinationFolder = True
            SavingType = SavingTypes.Separate
            If Not Configuration.ConfigurationManager.AppSettings("defaultSelectedProfil") Is Nothing Then
                SelectedProfil = Configuration.ConfigurationManager.AppSettings("defaultSelectedProfil")
            Else
                SelectedProfil = ""
            End If

            DestinationFolder = "C:\"
            RegistryFolder = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Sign&Verify")
            LastCertificateSN = ""
            initDefaultValues()
        End Sub

#End Region

#Region "Public methodes"

        'initialize the registry with defaults values
        Public Sub initDefaultValues()
            If getValueFromRegistry("SelectedProfil") = "" Then
                setValueToRegistry("SelectedProfil", SelectedProfil)
            End If
            If getValueFromRegistry("AutoDestinationFolder") = "" Then
                setValueToRegistry("AutoDestinationFolder", AutoDestinationFolder)
            End If
            If getValueFromRegistry("DestinationFolder") = "" Then
                setValueToRegistry("DestinationFolder", DestinationFolder)
            End If
            If getValueFromRegistry("ProviderName") = "" Then
                setValueToRegistry("ProviderName", ProviderName)
            End If
            If getValueFromRegistry("TimeStampURL") = "" Then
                setValueToRegistry("TimeStampURL", TimeStampURL)
            End If
            If getValueFromRegistry("ShowOnlyNonRepudiation") = "" Then
                setValueToRegistry("ShowOnlyNonRepudiation", ShowOnlyNonRepudiation)
            End If
            If getValueFromRegistry("ShowSignOption") = "" Then
                setValueToRegistry("ShowSignOption", ShowSignOption)
            End If
            If getValueFromRegistry("SignAlgorithm") = "" Then
                setValueToRegistry("SignAlgorithm", SignAlgorithm)
            End If
            If getValueFromRegistry("CheckTimeStamp") = "" Then
                setValueToRegistry("CheckTimeStamp", CheckTimeStamp)
            End If
            If getValueFromRegistry("CheckCertificationPath") = "" Then
                setValueToRegistry("CheckCertificationPath", CheckCertificationPath)
            End If
            If getValueFromRegistry("CheckCRL") = "" Then
                setValueToRegistry("CheckCRL", CheckCRL)
            End If
            If getValueFromRegistry("LastCertificateSN") = "" Then
                setValueToRegistry("LastCertificateSN", LastCertificateSN)
            End If
            If getValueFromRegistry("SavingType") = "" Then
                setValueToRegistry("SavingType", SavingType)
            End If
            If getValueFromRegistry("DisplayTimeStamp") = "" Then
                setValueToRegistry("DisplayTimeStamp", DisplayTimeStamp)
            End If
            ' If ProviderName.Equals("PDF crypto provider.") Then
            initPdfValues()
            ' End If
        End Sub

        'get all options values from registry
        Public Sub load()
            SelectedProfil = getValueFromRegistry("SelectedProfil")
            AutoDestinationFolder = Boolean.Parse(getValueFromRegistry("AutoDestinationFolder"))
            DestinationFolder = getValueFromRegistry("DestinationFolder")
            ProviderName = getValueFromRegistry("ProviderName")
            TimeStampURL = getValueFromRegistry("TimeStampURL")
            DisplayTimeStamp = getValueFromRegistry("DisplayTimeStamp")
            ShowSignOption = Boolean.Parse(getValueFromRegistry("ShowSignOption"))
            ShowOnlyNonRepudiation = Boolean.Parse(getValueFromRegistry("ShowOnlyNonRepudiation"))
            SignAlgorithm = getValueFromRegistry("SignAlgorithm")
            CheckTimeStamp = Boolean.Parse(getValueFromRegistry("CheckTimeStamp"))
            CheckCertificationPath = Boolean.Parse(getValueFromRegistry("CheckCertificationPath"))
            CheckCRL = Boolean.Parse(getValueFromRegistry("CheckCRL"))
            LastCertificateSN = getValueFromRegistry("LastCertificateSN")

            SavingType = [Enum].Parse(GetType(SavingTypes), getValueFromRegistry("SavingType"), True)
            'If ProviderName.Equals("PDF crypto provider.") Then
            loadPdfValues()
            'End If

        End Sub


        'save options to registry
        Public Sub save()
            setValueToRegistry("SelectedProfil", SelectedProfil)
            setValueToRegistry("AutoDestinationFolder", AutoDestinationFolder)
            setValueToRegistry("DestinationFolder", DestinationFolder)
            setValueToRegistry("ProviderName", ProviderName)
            setValueToRegistry("TimeStampURL", TimeStampURL)
            setValueToRegistry("ShowSignOption", ShowSignOption)
            setValueToRegistry("ShowOnlyNonRepudiation", ShowOnlyNonRepudiation)
            setValueToRegistry("SignAlgorithm", SignAlgorithm)
            setValueToRegistry("CheckTimeStamp", CheckTimeStamp)
            setValueToRegistry("CheckCertificationPath", CheckCertificationPath)
            setValueToRegistry("CheckCRL", CheckCRL)
            setValueToRegistry("LastCertificateSN", LastCertificateSN)
            setValueToRegistry("SavingType", SavingType)
            setValueToRegistry("DisplayTimeStamp", DisplayTimeStamp)

        End Sub

       
#End Region

#Region "Private methodes"
        'get value from registry
        Private Function getValueFromRegistry(ByVal name As String) As String
            Dim result As Object = RegistryFolder.GetValue(name)
            If result Is Nothing Then
                Return ""
            Else
                Return result.ToString
            End If
        End Function

        'save value to registry
        Private Sub setValueToRegistry(ByVal name As String, ByVal value As String)
            If value Is Nothing Then value = ""
            RegistryFolder.SetValue(name, value)
        End Sub
#End Region
#Region "PdfParams"

        Private Sub initPdfValues()
            PdfParameters = New PdfParams
            If getValueFromRegistry("PDFIsVisible") = "" Then
                setValueToRegistry("PDFIsVisible", PdfParameters.IsVisible)
            End If
            If getValueFromRegistry("PDFText") = "" Then
                setValueToRegistry("PDFText", PdfParameters.Text)
            End If
            If getValueFromRegistry("PDFContact") = "" Then
                setValueToRegistry("PDFContact", PdfParameters.Contact)
            End If
            If getValueFromRegistry("PDFLocation") = "" Then
                setValueToRegistry("PDFLocation", PdfParameters.Location)
            End If
            If getValueFromRegistry("PDFImagePath") = "" Then
                setValueToRegistry("PDFImagePath", PdfParameters.ImagePath)
            End If
            If getValueFromRegistry("PDFReason") = "" Then
                setValueToRegistry("PDFReason", PdfParameters.Reason)
            End If
            If getValueFromRegistry("PDFPosition") = "" Then
                setValueToRegistry("PDFPosition", PdfParameters.Position)
            End If
            If getValueFromRegistry("PDFShowImage") = "" Then
                setValueToRegistry("PDFShowImage", PdfParameters.ShowImage)
            End If
            If getValueFromRegistry("PDFUseDefaultImage") = "" Then
                setValueToRegistry("PDFUseDefaultImage", PdfParameters.UseDefaultImage)
            End If
            If getValueFromRegistry("PDFShowName") = "" Then
                setValueToRegistry("PDFShowName", PdfParameters.ShowName)
            End If
            
        End Sub

        Public Sub loadPdfValues()
            PdfParameters = New PdfParams
            PdfParameters.IsVisible = getValueFromRegistry("PDFIsVisible")
            PdfParameters.Text = getValueFromRegistry("PDFText")
            PdfParameters.Contact = getValueFromRegistry("PDFContact")
            PdfParameters.Location = getValueFromRegistry("PDFLocation")
            PdfParameters.ImagePath = getValueFromRegistry("PDFImagePath")
            PdfParameters.Reason = getValueFromRegistry("PDFReason")
            PdfParameters.UseDefaultImage = getValueFromRegistry("PDFUseDefaultImage")
            PdfParameters.ShowImage = getValueFromRegistry("PDFShowImage")
            PdfParameters.ShowName = getValueFromRegistry("PDFShowName")
            PdfParameters.Position = [Enum].Parse(GetType(PositionTypes), getValueFromRegistry("PDFPosition"), True)
        End Sub
        Public Sub savePdfParamsValues()
            setValueToRegistry("PDFIsVisible", PdfParameters.IsVisible)
            setValueToRegistry("PDFText", PdfParameters.Text)
            setValueToRegistry("PDFContact", PdfParameters.Contact)
            setValueToRegistry("PDFLocation", PdfParameters.Location)
            setValueToRegistry("PDFImagePath", PdfParameters.ImagePath)
            setValueToRegistry("PDFReason", PdfParameters.Reason)
            setValueToRegistry("PDFPosition", PdfParameters.Position)
            setValueToRegistry("PDFUseDefaultImage", PdfParameters.UseDefaultImage)
            setValueToRegistry("PDFShowImage", PdfParameters.ShowImage)
            setValueToRegistry("PDFShowName", PdfParameters.ShowName)
        End Sub
#End Region

    End Class
End Namespace