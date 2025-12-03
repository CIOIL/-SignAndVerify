Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Reflection
Imports SignVerify.Common
Imports System.Collections

Namespace SignVerify.Common.Utils

    Public Class ProvidersLoader

#Region "Private members"
        Private _loadedPlugins As Dictionary(Of String, IBaseCryptoProvider) = Nothing
        Private _pluginsDirectory As String

#End Region

#Region "Public propertys"

        ''' <summary>
        ''' Gets the loaded plugins.
        ''' </summary>
        ''' <value>The loaded plugins.</value>
        Public ReadOnly Property LoadedPlugins() As Dictionary(Of String, IBaseCryptoProvider)
            Get
                Return _loadedPlugins
            End Get
        End Property

        ' Gets the plugins directory.
        Public ReadOnly Property pluginsDirectory() As String
            Get
                Return _pluginsDirectory
            End Get
        End Property

#End Region

#Region "Constructor"

        'constructor
        Public Sub New(ByVal pluginsDirectory As String)
            Me._pluginsDirectory = pluginsDirectory
            _loadedPlugins = New Dictionary(Of String, IBaseCryptoProvider)
           
            LoadProviders()
        End Sub

        ''' <summary>
        ''' Loads the providers.
        ''' </summary>
        Private Sub LoadProviders()
            Dim _authorizedPlugins As New ArrayList
            _authorizedPlugins.Add("XmlDigSigProvider.dll".ToLower())
            _authorizedPlugins.Add("PKCS7Provider.dll".ToLower)
            _authorizedPlugins.Add("XadesProvider.dll".ToLower)
            _authorizedPlugins.Add("PDFProvider.dll".ToLower)
            Dim dir As DirectoryInfo = New DirectoryInfo(_pluginsDirectory)
            If Not Directory.Exists(_pluginsDirectory) Then
                Return
            End If



            For Each file As FileInfo In dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly)
                Dim ass As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(file.FullName)
                Dim types As Type()
                If (True) Then
                    Try
                        types = ass.GetTypes()
                    Catch ex As ReflectionTypeLoadException
                        If ex.LoaderExceptions.Length > 0 Then
                            Throw New Exception(String.Format("""{0}"" loading error.{1} Details: {2}", file.Name, vbCrLf, ex.LoaderExceptions(0).Message))
                        End If
                        'Throw ex
                        Continue For
                    Catch ex As Exception
                        Continue For
                    End Try
                End If

                For Each type As Type In types
                    If (Not type.IsClass) OrElse type.IsNotPublic Then
                        Continue For
                    End If
                    Dim objectType As Type = type.GetInterface(GetType(IBaseCryptoProvider).Name)
                    If Not objectType Is Nothing Then

                        'TODO: make the additional checks
                        'about the loaded dll digital signature
                        Dim instance As IBaseCryptoProvider = CType(Activator.CreateInstance(type), IBaseCryptoProvider)
                        _loadedPlugins.Add(instance.ProviderFriendlyName, instance)
                        Exit For

                    End If
                Next type
            Next file

        End Sub

#End Region

    End Class


End Namespace
