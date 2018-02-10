Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ln As New Logica_Negocio.Enviar_email
        Debug.Write(TextBox1.Text)
        Dim datos_user As Object = {TextBox1.Text, TextBox2.Text, TextBox5.Text, TextBox6.Text, DropDownList1.SelectedValue}

        ln.registro_usuario(datos_user)
    End Sub

End Class