Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Private datos As DataSet
    Private vista As DataView
    Private table As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Session("log") = False Or Session("rol") = "p") Then
        'Response.Redirect("~/Inicio.aspx")
        'End If
        If Not IsPostBack Then
            'Session.Contents("email")
            Dim mail = "pepe@ikasle.ehu.es"
            TextBox1.Text = "pepe@ikasle.ehu.es"
            TextBox2.Text = Session.Contents("Tarea")
            TextBox3.Text = Session.Contents("HEstimada")

            datos = Logica_Negocio.accesoOleBD.obtenerEstudiantesTareas(mail)
            table = datos.Tables("EstudiantesT")
            vista = New DataView(table)

            Session.Contents("DataSetEstudiantesT") = datos
            Session.Contents("DataViewTareas") = vista
            Session.Contents("DataTableTareas") = table

            GridView1.DataSource = Nothing
            GridView1.DataSource = vista.ToTable
            GridView1.DataBind()
        Else
            datos = Session.Contents("DataSetEstudiantesT")
            vista = Session.Contents("DataViewEstudiantesT")
            table = Session.Contents("DataTableEstudiantesT")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("~/TareasAlumno.aspx")
    End Sub
End Class