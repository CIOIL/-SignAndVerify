Public Class frmAbout
    'Set the version when form about is loaded
    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sVersion As String = Application.ProductVersion
        Me.lblVersion.Text = String.Format("Sign and Verify Version {0}", sVersion)

    End Sub
 
End Class