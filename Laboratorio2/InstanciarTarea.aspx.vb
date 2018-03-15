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

            Logica_Negocio.accesoBD.conectar()
            datos = Logica_Negocio.accesoBD.obtenerEstudiantesTareas(mail)
            table = datos.Tables("EstudiantesT")
            vista = New DataView(table)

            Session.Contents("DataSetEstudiantesT") = datos
            Session.Contents("DataViewEstudiantesT") = vista
            Session.Contents("DataTableEstudiantesT") = table

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
        Dim fila As DataRow
        fila = table.NewRow()
        fila("Email") = TextBox1.Text
        fila("CodTarea") = TextBox2.Text
        fila("HEstimadas") = TextBox3.Text
        fila("HReales") = TextBox4.Text
        table.Rows.Add(fila)
        Label6.Text = "Tarea del alumno " & TextBox1.Text & "instanciada con " & TextBox4.Text & "horas"
        GridView1.DataSource = table
        GridView1.DataBind()
        Button1.Enabled = False
        Logica_Negocio.accesoBD.instanciarTarea(datos)
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Logica_Negocio.accesoBD.cerrarConexion()
        Response.Redirect("~/TareasAlumno.aspx")
    End Sub
End Class