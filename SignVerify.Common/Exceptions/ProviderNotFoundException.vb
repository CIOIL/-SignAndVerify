Namespace SignVerify.Common
    Public Class ProvidersNotFoundException
        Inherits System.ApplicationException

        Public FolderPath As String

        Public Sub New(ByVal FolderPath As String)
            MyBase.New()
            Me.FolderPath = FolderPath
        End Sub
    End Class
End Namespace
