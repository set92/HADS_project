Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ln As New Logica_Negocio.EnviarEmail

        Dim datos_user As Array = {tb_email.Text, tb_nombre.Text, tb_apellidos.Text, ln.Generar_numAleatorio, 0, DropDownList1.SelectedValue, tb_pass2.Text}
        Dim url As String
        url = Context.Request.Url.Scheme & "://" & Context.Request.Url.Host & ":" & Request.Url.Port & "/Confirmar.aspx?mbr=" & tb_email.Text & "&numconf=" & datos_user(3)

        hl_linkRegistro.NavigateUrl = "" + url
        ln.Registro_usuario(datos_user, url)
    End Sub

End Class