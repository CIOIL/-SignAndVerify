Public Class testGlobalization


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        generateText()

    End Sub


    Private Sub generateText()

        'lblCurrentCulture.Text = My.Resources.Strings.currentCulture
        lblCulture.Text = Threading.Thread.CurrentThread.CurrentUICulture.Name

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-US")

        generateText()
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("he-IL")
        generateText()

    End Sub
End Class