Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bt_login_Click(sender As Object, e As EventArgs) Handles bt_login.Click
        Dim d As Array = {tb_email.Text, tb_password.Text}

        Logica_Negocio.accesoBD.conectar()
        If String.Compare(Logica_Negocio.accesoBD.loginUsuario(d), "LOGIN USUARIO OK") = 0 Then
            Session.Contents("mail") = d(0)
            Session.Contents("tipo") = Logica_Negocio.accesoBD.tipoUsuario(d)
            If String.Compare(Session.Contents("tipo"), "Profesor") = 0 Then
                Response.Redirect("~/TareasProfesor.aspx")
            ElseIf String.Compare(Session.Contents("tipo"), "Alumno") = 0 Then
                Response.Redirect("~/TareasAlumno.aspx")
            End If
        Else
            MesgBox("No se ha podido conectar")
        End If
        Logica_Negocio.accesoBD.cerrarConexion()
    End Sub

    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
End Class