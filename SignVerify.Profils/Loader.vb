Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Collections
Imports System.Xml
Namespace SignVerify.Profils

    Public Class Loader

#Region "Privates members"

        Private _loadedProfils As Dictionary(Of String, XmlProfil)
        Private _registryProfil As RegistryProfil
        Private _profilsDirectory As String

#End Region

#Region "Public propertys"

        ' Gets the loaded profils.
        Public ReadOnly Property loadedProfils() As Dictionary(Of String, XmlProfil)
            Get
                Return _loadedProfils
            End Get
        End Property

        ' Gets the registry saved profil for current user.
        Public ReadOnly Property registryProfil() As RegistryProfil
            Get
                Return _registryProfil
            End Get
        End Property

        ' Gets the profils directory.
        Public ReadOnly Property profilsDirectory() As String
            Get
                Return _profilsDirectory
            End Get
        End Property

#End Region

#Region "Constructors"

        Public Sub New(ByVal profilsDirectory As String)
            'load registry profile
            Me._registryProfil = New RegistryProfil()
            Me._registryProfil.load()

            'load xml profiles
            Me._profilsDirectory = profilsDirectory
            _loadedProfils = New Dictionary(Of String, XmlProfil)
            LoadProfils()

        End Sub

        ' Load the profils.
        Private Sub LoadProfils()
            Dim dir As DirectoryInfo = New DirectoryInfo(_profilsDirectory)
            If Not Directory.Exists(_profilsDirectory) Then
                Return
            End If
            For Each file As FileInfo In dir.GetFiles("*.xml", SearchOption.AllDirectories)
                Dim prof As New XmlProfil
                prof.Load(file.FullName)
                If prof.FriendlyName <> "" Then
                    _loadedProfils.Add(prof.FriendlyName, prof)
                End If
            Next
        End Sub

#End Region

    End Class


End Namespace
