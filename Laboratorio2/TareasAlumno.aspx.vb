Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Private datos As DataSet
    Private vista As DataView
    Private table As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Dim mail = Session.Contents("email")

            Dim mail = "pepe@ikasle.ehu.es"

            datos = Logica_Negocio.accesoOleBD.obtenerTareas(mail)
            Session.Contents("DataSetTareasAlumno") = datos
            table = datos.Tables("TareasG")

            DropDownList1.DataSource = table
            DropDownList1.DataValueField = "CodAsig"
            DropDownList1.DataBind()

            vista = New DataView(table)
            vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
            GridView1.DataSource = vista.ToTable
            GridView1.DataBind()

            Session.Contents("flagDesc") = True
            Session.Contents("flagH") = True
            Session.Contents("FlagT") = True
        Else
            datos = Session.Contents("DataSetTareasAlumno")
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        Dim table = New DataTable
        table = datos.Tables("TareasG")
        vista = New DataView(table)
        vista.Sort = e.SortExpression
        'vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        GridView1.DataSource = vista.ToTable
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        table = New DataTable()
        table = datos.Tables("TareasG")
        vista = New DataView(table)
        vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        'GridView1.DataSource = Nothing
        GridView1.DataSource = vista.ToTable
        GridView1.DataBind()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (Session.Contents("flagDesc")) Then
            Session.Contents("flagDesc") = False
        Else
            Session.Contents("flagDesc") = True
        End If
        GridView1.Columns(2).Visible = Session.Contents("flagDesc")
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If (Session.Contents("flagH")) Then
            Session.Contents("flagH") = False
        Else
            Session.Contents("flagH") = True
        End If
        GridView1.Columns(3).Visible = Session.Contents("flagH")
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If (Session.Contents("FlagT")) Then
            Session.Contents("FlagT") = False
        Else
            Session.Contents("FlagT") = True
        End If
        GridView1.Columns(4).Visible = Session.Contents("FlagT")
    End Sub
End Class