Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim d As Array = {Request.QueryString("mbr"), Convert.ToInt32(Request.QueryString("numconf"))}

        Logica_Negocio.accesoBD.conectar()
        If String.Compare(Logica_Negocio.accesoBD.existeUsuario(d), "USUARIO CONFIRMADO OK") = 0 Then
            lbOk.Text = "Hola, ya estas registrado en el sistema!!"
            hpLink.Text = "Pulsa aqui para identificarte en el sistema"
            hpLink.NavigateUrl = "~/Inicio.aspx"
        Else
            lbOk.Text = "No te has registrado en el sistema!!"
            hpLink.Text = "Pulsa aqui para registrarte en el sistema"
            hpLink.NavigateUrl = "~/Registro.aspx"
        End If
        Logica_Negocio.accesoBD.cerrarConexion()
    End Sub

End Class