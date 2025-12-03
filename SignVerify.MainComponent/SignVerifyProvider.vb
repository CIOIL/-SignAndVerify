Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports SignVerify.Common
Imports SignVerify.Common.Utils.ProvidersLoader
Imports SignVerify.Profils
Imports System.Collections

Namespace SignVerify.MainComponent
	Public Class SignVerifyProvider
		Implements IServiceProvider

#Region "Class-level variables"

        Private _updatesMonitorEnabled As Boolean = True
        Private _loadedPlugins As Dictionary(Of String, IBaseCryptoProvider) = Nothing
        Private _loadedProfils As Dictionary(Of String, XmlProfil) = Nothing
        Private _registryProfil As RegistryProfil
        Private _profilsDirectory As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profils")
        Private _pluginsDirectory As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")
        Private _raiseUpdatesAvailableEvent As Boolean = True
        Private _updateAvailable As Boolean = False

#Region "updater"


        'Private _updateManager As ApplicationUpdater.UpdaterManager = Nothing
        'Public Event UpdatesAvailable As SignVerify.Common.UpdaterCommon.UpdatesAvailableDelegate
        'Public Event UpdateProcessError As SignVerify.Common.UpdaterCommon.UpdateProcessErrorDelegate
        'Public Event UpdateCompleted As SignVerify.Common.UpdaterCommon.UpdateCompletedDelegate
        'Public Event UpdateProgress As SignVerify.Common.UpdaterCommon.UpdateProgressDelegate
        'Public Event UpdateApplyCpmpleted As SignVerify.Common.UpdaterCommon.UpdateApplyCompletedDelegate
        'Public Event ActivationInitializing As SignVerify.Common.UpdaterCommon.ActivationInitializingDelegate
        'Public Event UpdateDownloadCompleted As SignVerify.Common.UpdaterCommon.UpdateDownloadCompletedDelegate

#End Region
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

        ''' <summary>
        ''' Gets the loaded profils.
        ''' </summary>
        ''' <value>The loaded profils.</value>
        Public ReadOnly Property LoadedProfils() As Dictionary(Of String, XmlProfil)
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

        ' Gets the plugins directory.
        Public ReadOnly Property pluginsDirectory() As String
            Get
                Return _pluginsDirectory
            End Get
        End Property

        ' Gets the profils directory.
        Public ReadOnly Property profilsDirectory() As String
            Get
                Return _profilsDirectory
            End Get
        End Property


#End Region

#Region "Constructor  & loading methodes"

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SignVerifyProvider"/> class.
        ''' </summary>
        Public Sub New()
            '_updateManager = New SignVerify.ApplicationUpdater.UpdaterManager()
            'AddHandler _updateManager.UpdatesAvailable, AddressOf updateManager_UpdatesAvailable
            'AddHandler _updateManager.UpdateProgress, AddressOf updateManager_UpdateProgress
            'AddHandler _updateManager.UpdateProcessError, AddressOf updateManager_UpdateProcessError
            'AddHandler _updateManager.UpdateCompleted, AddressOf updateManager_UpdateCompleted
            'AddHandler _updateManager.ActivationInitializing, AddressOf updateManager_ActivationInitializing
            'AddHandler _updateManager.UpdateDownloadCompleted, AddressOf updateManager_UpdateDownloadCompleted
            LoadPlugins()
            LoadProfils()
        End Sub

        ''' <summary>
        ''' Loads the plugins.
        ''' </summary>
        Private Sub LoadPlugins()
            Dim loader As New SignVerify.Common.Utils.ProvidersLoader(pluginsDirectory)
            _loadedPlugins = loader.LoadedPlugins
        End Sub

        ''' <summary>
        ''' Loads the profils.
        ''' </summary>
        Private Sub LoadProfils()
            Dim loader As New SignVerify.Profils.Loader(_profilsDirectory)
            _loadedProfils = loader.loadedProfils
            _registryProfil = loader.registryProfil
        End Sub

#End Region

#Region "IServiceProvider Members"

        ''' <summary>
        ''' Gets the service object of the specified type.
        ''' </summary>
        ''' <param name="serviceType">An object that specifies the type of service object to get.</param>
        ''' <returns>
        ''' A service object of type serviceType.-or- null if there is no service object of type serviceType.
        ''' </returns>
        Public Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
            Return GetSpecificService(serviceType)
        End Function

        ''' <summary>
        ''' Gets the specific service.
        ''' </summary>
        ''' <param name="serviceType">Type of the service.</param>
        ''' <returns></returns>
        Private Function GetSpecificService(ByVal serviceType As Type) As Object
            For Each provider As IBaseCryptoProvider In _loadedPlugins.Values
                If CType(provider, Object).GetType().FullName = serviceType.FullName Then
                    Return provider
                End If
                'if (provider.GetType().Equals(serviceType))
                '{
                '    return provider;
                '}
            Next provider
            Return Nothing
        End Function

#End Region

#Region "Updater methods"
        '        Public Property UpdatesMonitorEnabled() As Boolean
        '            Get
        '                Return _updatesMonitorEnabled
        '            End Get
        '            Set(ByVal value As Boolean)
        '                _updatesMonitorEnabled = value
        '            End Set
        '        End Property

        '        Public Property RaiseUpdatesAvailableEvent() As Boolean
        '            Get
        '                Return _raiseUpdatesAvailableEvent
        '            End Get
        '            Set(ByVal value As Boolean)
        '                _raiseUpdatesAvailableEvent = value
        '            End Set
        '        End Property

        '        Public Property UpdateAvailable() As Boolean
        '            Get
        '                Return _updateAvailable
        '            End Get
        '            Set(ByVal value As Boolean)
        '                _updateAvailable = value
        '            End Set
        '        End Property

        '        Public Sub StartMonitorForUpdates()
        '            _updateManager.UpdaterServerUrl = "http://localhost/CryptoWebSite/Manifests/manifests.xml"
        '            _updateManager.StartMonitoring()
        '        End Sub

        '        Public Sub StopMonitorForUpdates()
        '            _updateManager.StopMonitoring()
        '        End Sub

        '        Public Sub ApplyUpdates()
        '            _updateManager.ApplyUpdates()
        '        End Sub


        '        Private Sub updateManager_UpdateCompleted(ByVal e As UpdateCompletedEventArguments)
        '            If Not Me.UpdateCompletedEvent Is Nothing Then
        '                RaiseEvent UpdateCompleted(e)
        '            End If
        '        End Sub

        '        Private Sub updateManager_UpdateProcessError(ByVal e As UpdateProcessErrorEventArguments)
        '            If Not Me.UpdateProcessErrorEvent Is Nothing Then
        '                RaiseEvent UpdateProcessError(e)
        '            End If
        '        End Sub

        '        Private Sub updateManager_UpdateProgress(ByVal e As UpdateProgressEventArguments)
        '            If Not Me.UpdateProgressEvent Is Nothing Then
        '                RaiseEvent UpdateProgress(e)
        '            End If
        '        End Sub

        '        Private Sub updateManager_UpdatesAvailable(ByVal e As UpdateAvailableEventArguments)
        '            If Me.RaiseUpdatesAvailableEvent Then
        '                If Not Me.UpdatesAvailableEvent Is Nothing Then
        '                    RaiseEvent UpdatesAvailable(e)
        '                End If
        '            End If
        '        End Sub

        '        Private Sub updateManager_UpdateDownloadCompleted()
        '            If Not Me.UpdateDownloadCompletedEvent Is Nothing Then
        '                RaiseEvent UpdateDownloadCompleted()
        '            End If
        '        End Sub

        '        Private Sub updateManager_ActivationInitializing()
        '            If Not Me.ActivationInitializingEvent Is Nothing Then
        '                RaiseEvent ActivationInitializing()
        '            End If
        '        End Sub
#End Region

    End Class
End Namespace
