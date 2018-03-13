Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Private datos As DataSet
    Private vista As DataView
    Private table As DataTable
    Private query As IEnumerable(Of DataRow)
    Dim tbTareasAsig As DataTable

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
            GridView1.DataSource = vista
            GridView1.DataBind()
        Else
            datos = Session.Contents("DataSetTareasAlumno")
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Remove("email")
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        Dim table = New DataTable
        Dim v = table.AsDataView
        v.Sort = e.SortExpression   ''nombre de la columna y direction

        GridView1.DataSource = v.ToTable
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        'table = New DataTable()
        'table = datos.Tables("TareasG")
        'vista = New DataView(table)
        vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        'GridView1.DataSource = Nothing
        GridView1.DataSource = vista
        GridView1.DataBind()
    End Sub

End Class