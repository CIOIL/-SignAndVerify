Imports System.IO

Namespace SignVerify.Common
    Public Class CryptoExtractedEntry
        Public Property FileName() As String
            Get
                Return m_FileName
            End Get
            Set(value As String)
                m_FileName = value
            End Set
        End Property
        Private m_FileName As String
        
        Public ReadOnly Property DataBytes() As Byte()
            Get
                Return m_DataBytes
            End Get
        End Property
        Private m_DataBytes As Byte()
        Public Property hash() As Byte()
            Get
                Return m_hash
            End Get
            Set(value As Byte())
                m_hash = value
            End Set
        End Property
        Private m_hash As Byte()
        Public Property ParentFile() As String
            Get
                Return m_ParentFile
            End Get
            Set(value As String)
                m_ParentFile = value
            End Set
        End Property
        Private m_ParentFile As String

        Public Property ChildFile() As String
            Get
                Return m_ChildFile
            End Get
            Set(value As String)
                m_ChildFile = value
            End Set
        End Property
        Private m_ChildFile As String
      
        Public Sub New(p_FileName As String, p_DataBytes As Byte())
            Me.FileName = p_FileName
            Me.m_DataBytes = p_DataBytes
        End Sub
    End Class
End Namespace
