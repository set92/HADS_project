Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim mail = Session.Contents("email")
        Dim mail = "pepe@ikasle.ehu.es"

        Logica_Negocio.accesoOleBD.conectar()

        GridView1.DataSource = Logica_Negocio.accesoOleBD.obtenerTareas(mail).Tables("TareasG")
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Remove("email")
    End Sub
End Class