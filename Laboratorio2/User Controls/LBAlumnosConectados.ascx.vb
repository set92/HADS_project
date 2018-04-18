Public Class LBAlumnosConectados
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ListBox1.Items.Clear()
        Label1.Text = Application("numA")
        Dim aux As New ListBox()
        aux = Application("listaalum")
        For Each el In aux.Items
            ListBox1.Items.Add(el)
        Next
    End Sub

End Class