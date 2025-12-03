Imports System.Windows.Forms
Imports SignVerify.Common
Imports System.IO
Imports System.Data


Public Class testDisplaySignatures


    Private verifiedObject As CryptoSignedObject(Of Byte())


#Region "Constructor"


    'constructor
    Public Sub New(ByVal verifiedObject As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'get the verified object
        Try
            Me.verifiedObject = CType(verifiedObject, CryptoSignedObject(Of Byte()))

        Catch
        End Try
        Create()

    End Sub

    'on form load 
    Public Sub verifyResultDiag_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

     

    End Sub


#End Region

#Region "user events (Open original file, close dialog)"

    'Ok clicked
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


#End Region

#Region "signatures display"

    Public Sub Create()
        SignaturesTreeGrid1.signatures = verifiedObject.signatureInfos

    End Sub

#End Region

 
End Class
