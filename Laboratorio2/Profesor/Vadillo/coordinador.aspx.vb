Public Class coordinador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim temp As New ServiceDedicacion.WebService1SoapClient
        Dim res = temp.obtenerDedicacionMediaAsig(DropDownList1.SelectedValue)
        Label1.Text = "La dedicación media de horas no presenciales en <strong>" & DropDownList1.SelectedValue & " </strong> es: <strong>" & res & "</strong>"
    End Sub

End Class