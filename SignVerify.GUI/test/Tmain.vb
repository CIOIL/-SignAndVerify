Public Class Tmain

    Private Delegate Function DoWorkDel() As String
    Private Delegate Sub ChangeLabelDel(ByVal text As String)
    Private Delegate Sub HidePBDel()

    Private DoWorkAsync As New DoWorkDel(AddressOf DoWork)


    Private Tprogress As Tprogress

    Private ii As IAsyncResult

    
    Private Sub Tmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = "Begin work"
        ii = DoWorkAsync.BeginInvoke(AddressOf CallBack, New Object)
        Tprogress = New Tprogress("New Progress")
        Tprogress.ShowDialog()
    End Sub

    Private Function DoWork() As String
        Threading.Thread.Sleep(5000)
        DoWork = "return " + Guid.NewGuid.ToString
    End Function

    Private Sub CallBack()
        Me.Invoke(New ChangeLabelDel(AddressOf ChangeLabel), New Object() {"End work"})
        Me.Invoke(New HidePBDel(AddressOf HidePB), New Object() {})
        Dim sss As String = CType(DoWorkAsync.EndInvoke(ii), String)
        Dim i As Integer = 0
    End Sub

    Private Sub ChangeLabel(ByVal text As String)

        Label1.Text = text

    End Sub

    Private Sub HidePB()
        Me.Tprogress.Hide()
    End Sub

End Class