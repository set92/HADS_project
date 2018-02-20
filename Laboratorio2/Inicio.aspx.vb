Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bt_login_Click(sender As Object, e As EventArgs)
        Dim d As Array = {tb_email.Text, tb_password.Text}

        Logica_Negocio.accesoBD.conectar()
        If String.Compare(Logica_Negocio.accesoBD.loginUsuario(d), "LOGIN USUARIO OK") = 0 Then
            Session("mail") = d(0)
        Else
            MsgBox("No se ha podido conectar", MsgBoxStyle.Information, "Error")
        End If
        Logica_Negocio.accesoBD.cerrarConexion()
    End Sub
End Class