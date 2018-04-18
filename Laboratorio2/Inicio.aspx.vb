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
            Application("NUsuarios") = Application("NUsuarios") + 1
            If tb_email.Text = "vadillo@ehu.es" Then
                FormsAuthentication.SetAuthCookie("vadillo@ehu.es", False)
            Else
                FormsAuthentication.SetAuthCookie(Session.Contents("tipo"), False)
            End If
            If String.Compare(Session.Contents("tipo"), "Profesor") = 0 Then
                Dim temp As New ListBox()
                temp = Application("listaprof")
                temp.Items.Add(Session.Contents("mail"))
                Application("listaprof") = temp
                Application("numP") = Application("numP") + 1
                Response.Redirect("~/Profesor/Profesor.aspx")
            ElseIf String.Compare(Session.Contents("tipo"), "Alumno") = 0 Then
                Dim temp As New ListBox
                temp = Application("listaalum")
                temp.Items.Add(Session.Contents("mail"))
                Application("listaalum") = temp
                Application("numA") = Application("numA") + 1
                Response.Redirect("~/Alumno/Alumno.aspx")
            Else
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