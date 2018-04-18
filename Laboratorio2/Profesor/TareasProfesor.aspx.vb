Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Application.Lock()

        Dim temp As ListBox
        temp = Application("listaprof")
        temp.Items.Remove(Session.Contents("mail"))
        Application("listaprofs") = temp
        Application("numP") = Application("numP") - 1
        FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("~/Inicio.aspx")

        Application.UnLock()
    End Sub

    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub bt_insertar_Click(sender As Object, e As EventArgs) Handles bt_insertar.Click
        Response.Redirect("~/Profesor/InsertarTarea.aspx")
    End Sub
End Class