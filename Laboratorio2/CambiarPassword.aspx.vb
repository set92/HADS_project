Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Contents("mail") = Nothing Then
            tb_email.Text = Session.Contents("mail")
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ln As New Logica_Negocio.EnviarEmail
        If Not Session.Contents("mail") = Nothing Then
            tb_email.Text = Session.Contents("mail")
        End If
        Dim codigo = ln.Cambiar_password(tb_email.Text)

        tb_codigo.Text = codigo
        lbl_codigo.Text = codigo
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim d As Array = {tb_email.Text, tb_newPassword.Text}
        Logica_Negocio.accesoBD.conectar()
        MsgBox(Logica_Negocio.accesoBD.cambiarPassword(d))
        Logica_Negocio.accesoBD.cerrarConexion()
    End Sub
End Class