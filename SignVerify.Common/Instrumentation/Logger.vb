Imports log4net.Appender
Imports System.Text
Imports log4net.Layout
Imports log4net.Config
Imports System.Collections
Namespace SignVerify.Common
    Public Class Logger
        Implements log4net.ILog

#Region "Class member"
        ''' <summary>
        ''' The logger.
        ''' </summary>
        Private Shared m_oLog4NetInstance As log4net.ILog = Nothing

        ''' <summary>
        ''' Logger instance.
        ''' </summary>
        Private Shared m_oLoggerInstance As Logger = Nothing

        ''' <summary>
        ''' If we want to write to log.
        ''' </summary>
        Private Shared m_bWriteToLog As Boolean = False
#End Region

#Region "Ctor"
        ''' <summary>
        ''' Class ctor
        ''' </summary>
        Private Sub New()

        End Sub
#End Region

#Region "singleton"

        ''' <summary>
        ''' create logger instance.
        ''' </summary>
        ''' <returns>The logger instance.</returns>
        Public Shared Function Instance() As Logger
            If m_oLog4NetInstance Is Nothing Then
                m_oLog4NetInstance = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
                m_oLoggerInstance = New Logger()
                Init()
                Return m_oLoggerInstance
            End If
            Return m_oLoggerInstance
        End Function

        ''' <summary>
        ''' Init the log file and directory.
        ''' </summary>
        Private Shared Sub Init()
            If m_bWriteToLog Then
                Dim logFile As FileAppender = New FileAppender()
                Dim oDate As Date = Date.Now
                Dim sStringDateFormat As String = oDate.ToString("yyyyMMddhhmmss")
                logFile.File = String.Format("Log\\{1}_{0}.log", sStringDateFormat, m_oLog4NetInstance.Logger.Name)

                logFile.AppendToFile = True
                logFile.Encoding = Encoding.UTF8
                logFile.Layout = New PatternLayout("%date [%thread] %-5level [%logger] [%method] %message%newline%newline")
                logFile.ActivateOptions()
                BasicConfigurator.Configure(logFile)
            End If
        End Sub
#End Region

#Region "Public"
        Public Shared Sub SetState(ByVal p_bWriteToLog As Boolean)
            m_bWriteToLog = p_bWriteToLog
        End Sub
        Public ReadOnly Property Logger() As log4net.Core.ILogger Implements log4net.Core.ILoggerWrapper.Logger
            Get
                Return m_oLog4NetInstance.Logger
            End Get
        End Property

        Public Sub Debug(ByVal message As Object) Implements log4net.ILog.Debug
            If m_bWriteToLog Then
                m_oLog4NetInstance.Debug(message)
            End If
        End Sub

        Public Sub Debug(ByVal message As Object, ByVal exception As System.Exception) Implements log4net.ILog.Debug
            If m_bWriteToLog Then
                m_oLog4NetInstance.Debug(message, exception)
            End If
        End Sub

        Public Sub DebugFormat(ByVal format As String, ByVal arg0 As Object) Implements log4net.ILog.DebugFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.DebugFormat(format, arg0)
            End If
        End Sub

        Public Sub DebuFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) Implements log4net.ILog.DebugFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.DebugFormat(format, arg0)
            End If
        End Sub

        Public Sub DebugFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) Implements log4net.ILog.DebugFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.DebugFormat(format, arg0, arg1)
            End If
        End Sub

        Public Sub DebugFormat(ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.DebugFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.DebugFormat(format, args)
            End If
        End Sub

        Public Sub DebugFormat(ByVal provider As System.IFormatProvider, ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.DebugFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.DebugFormat(provider, format, args)
            End If
        End Sub

        Public Sub [Error](ByVal message As Object) Implements log4net.ILog.Error
            If m_bWriteToLog Then
                m_oLog4NetInstance.Error(message)
            End If
        End Sub

        Public Sub [Error](ByVal message As Object, ByVal exception As System.Exception) Implements log4net.ILog.Error
            If m_bWriteToLog Then
                m_oLog4NetInstance.Error(message, exception)
            End If
        End Sub

        Public Sub ErrorFormat(ByVal format As String, ByVal arg0 As Object) Implements log4net.ILog.ErrorFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.ErrorFormat(format, arg0)
            End If
        End Sub

        Public Sub ErrorFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) Implements log4net.ILog.ErrorFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.ErrorFormat(format, arg0, arg1)
            End If
        End Sub

        Public Sub ErrorFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) Implements log4net.ILog.ErrorFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.ErrorFormat(format, arg0, arg1, arg2)
            End If
        End Sub

        Public Sub ErrorFormat(ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.ErrorFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.ErrorFormat(format, args)
            End If
        End Sub

        Public Sub ErrorFormat(ByVal provider As System.IFormatProvider, ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.ErrorFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.ErrorFormat(provider, format, args)
            End If
        End Sub

        Public Sub Fatal(ByVal message As Object) Implements log4net.ILog.Fatal
            If m_bWriteToLog Then
                m_oLog4NetInstance.Fatal(message)
            End If
        End Sub

        Public Sub Fatal(ByVal message As Object, ByVal exception As System.Exception) Implements log4net.ILog.Fatal
            If m_bWriteToLog Then
                m_oLog4NetInstance.Fatal(message, exception)
            End If
        End Sub

        Public Sub FatalFormat(ByVal format As String, ByVal arg0 As Object) Implements log4net.ILog.FatalFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.FatalFormat(format, arg0)
            End If
        End Sub

        Public Sub FatalFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) Implements log4net.ILog.FatalFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.FatalFormat(format, arg0, arg1)
            End If
        End Sub

        Public Sub FatalFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) Implements log4net.ILog.FatalFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.FatalFormat(format, arg0, arg1, arg2)
            End If
        End Sub

        Public Sub FatalFormat(ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.FatalFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.FatalFormat(format, args)
            End If
        End Sub

        Public Sub FatalFormat(ByVal provider As System.IFormatProvider, ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.FatalFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.FatalFormat(provider, format, args)
            End If
        End Sub

        Public Sub Info(ByVal message As Object) Implements log4net.ILog.Info
            If m_bWriteToLog Then
                m_oLog4NetInstance.Info(message)
            End If
        End Sub

        Public Sub Info(ByVal message As Object, ByVal exception As System.Exception) Implements log4net.ILog.Info
            If m_bWriteToLog Then
                m_oLog4NetInstance.Info(message, exception)
            End If
        End Sub

        Public Sub InfoFormat(ByVal format As String, ByVal arg0 As Object) Implements log4net.ILog.InfoFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.InfoFormat(format, arg0)
            End If
        End Sub

        Public Sub InfoFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) Implements log4net.ILog.InfoFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.InfoFormat(format, arg0, arg1)
            End If
        End Sub

        Public Sub InfoFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) Implements log4net.ILog.InfoFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.InfoFormat(format, arg0, arg1, arg2)
            End If
        End Sub

        Public Sub InfoFormat(ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.InfoFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.InfoFormat(format, args)
            End If
        End Sub

        Public Sub InfoFormat(ByVal provider As System.IFormatProvider, ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.InfoFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.InfoFormat(provider, format, args)
            End If
        End Sub

        Public ReadOnly Property IsDebugEnabled() As Boolean Implements log4net.ILog.IsDebugEnabled
            Get
                Return m_oLog4NetInstance.IsDebugEnabled
            End Get
        End Property

        Public ReadOnly Property IsErrorEnabled() As Boolean Implements log4net.ILog.IsErrorEnabled
            Get
                Return m_oLog4NetInstance.IsErrorEnabled
            End Get
        End Property

        Public ReadOnly Property IsFatalEnabled() As Boolean Implements log4net.ILog.IsFatalEnabled
            Get
                Return m_oLog4NetInstance.IsFatalEnabled
            End Get
        End Property

        Public ReadOnly Property IsInfoEnabled() As Boolean Implements log4net.ILog.IsInfoEnabled
            Get
                Return m_oLog4NetInstance.IsInfoEnabled
            End Get
        End Property

        Public ReadOnly Property IsWarnEnabled() As Boolean Implements log4net.ILog.IsWarnEnabled
            Get
                Return m_oLog4NetInstance.IsWarnEnabled
            End Get
        End Property

        Public Sub Warn(ByVal message As Object) Implements log4net.ILog.Warn
            If m_bWriteToLog Then
                m_oLog4NetInstance.Warn(message)
            End If
        End Sub

        Public Sub Warn(ByVal message As Object, ByVal exception As System.Exception) Implements log4net.ILog.Warn
            If m_bWriteToLog Then
                m_oLog4NetInstance.Warn(message, exception)
            End If
        End Sub

        Public Sub WarnFormat(ByVal format As String, ByVal arg0 As Object) Implements log4net.ILog.WarnFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.WarnFormat(format, arg0)
            End If
        End Sub

        Public Sub WarnFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) Implements log4net.ILog.WarnFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.WarnFormat(format, arg0, arg1)
            End If
        End Sub

        Public Sub WarnFormat(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) Implements log4net.ILog.WarnFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.WarnFormat(format, arg0, arg1, arg2)
            End If
        End Sub

        Public Sub WarnFormat(ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.WarnFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.WarnFormat(format, args)
            End If
        End Sub

        Public Sub WarnFormat(ByVal provider As System.IFormatProvider, ByVal format As String, ByVal ParamArray args() As Object) Implements log4net.ILog.WarnFormat
            If m_bWriteToLog Then
                m_oLog4NetInstance.WarnFormat(provider, format, args)
            End If
        End Sub
#End Region

    End Class
End Namespace