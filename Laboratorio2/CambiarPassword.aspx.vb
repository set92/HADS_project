Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tb_email.Text = Session.Contents("mail")
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ln As New Logica_Negocio.EnviarEmail
        tb_codigo.Text = lbl_codigo.Text = ln.Cambiar_password(Session.Contents("mail"))

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim d As Array = {tb_email, tb_newPassword}
        MsgBox(Logica_Negocio.accesoBD.cambiarPassword(d))
    End Sub
End Class