Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json

Public Class ExportarTareasXML
    Inherits System.Web.UI.Page

    Dim xml As XmlDocument
    Dim dapt As SqlDataAdapter
    Dim dst As DataSet
    Dim tbTareas As DataTable
    Dim tbTareasAsig As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session.Contents("mail") = "blanco@ehu.es"
        If Not IsPostBack Then
            Logica_Negocio.accesoBD.conectar()
            dst = Logica_Negocio.accesoBD.export_asignaturas(Session.Contents("mail"))
            Logica_Negocio.accesoBD.cerrarConexion()

            tbTareas = New DataTable()
            tbTareas = dst.Tables("Asignaturas")

            DropDownList1.DataSource = tbTareas
            DropDownList1.DataValueField = "codigoasig"
            DropDownList1.DataBind()
            DropDownList1.Items.Item(0).Selected = True

            Cargar_tareas()

            GridView1.DataSource = tbTareas
            GridView1.DataBind()
        Else
            tbTareas = Session("dst_T2A").Tables("TareasGenericas")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("dst_T2A").Tables("TareasGenericas").TableName = "tarea"
        Session("dst_T2A").DataSetName = "tareas"
        Try
            Session("dst_T2A").Tables("tarea").Columns(0).ColumnMapping = MappingType.Attribute
            Session("dst_T2A").WriteXml(Server.MapPath(("./App_Data/" & DropDownList1.SelectedValue & ".xml")))
            Label1.Text = "Tareas exportadas con exito a " & DropDownList1.SelectedValue & ".xml"
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
        Session("dst_T2A").Tables("tarea").TableName = "TareasGenericas"
    End Sub

    Private Sub Cargar_tareas()
        Logica_Negocio.accesoBD.conectar()
        dst = Logica_Negocio.accesoBD.export_2(DropDownList1.SelectedValue)
        Logica_Negocio.accesoBD.cerrarConexion()
        Session("dst_T2A") = dst
        tbTareas = New DataTable()
        tbTareas = dst.Tables("TareasGenericas")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Cargar_tareas()

        GridView1.DataSource = tbTareas
        GridView1.DataBind()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("dst_T2A").Tables("TareasGenericas").TableName = "tarea" 'Cambiamos nombres para que este los nombres bien en el XML
        Session("dst_T2A").DataSetName = "tareas"
        Try
            Session("dst_T2A").Tables("tarea").Columns(0).ColumnMapping = MappingType.Attribute
            Session("dst_T2A").WriteXml(Server.MapPath(("./App_Data/" & DropDownList1.SelectedValue & ".xml")))
            Label1.Text = "Tareas exportadas con exito a " & DropDownList1.SelectedValue & ".xml"
        Catch ex As Exception
            Label1.Text = "Error al exportar las tareas a XML"
        End Try

        Try
            Dim xd As XmlDocument = New XmlDocument()
            xd.Load(Server.MapPath(("./App_Data/" & DropDownList1.SelectedValue & ".xml")))
            xd.DocumentElement.SetAttribute("xmlns:" & DropDownList1.SelectedValue.ToLower, "http://ji.ehu.es/" & DropDownList1.SelectedValue.ToLower)
            xd.Save((Server.MapPath("./App_Data/" & DropDownList1.SelectedValue & ".xml")))
        Catch ex As Exception
            Label1.Text = "El archivo " & DropDownList1.SelectedValue & ".xml no existe, usa el boton de arriba"
        End Try

        Session("dst_T2A").Tables("tarea").TableName = "TareasGenericas"
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim serialDoc = JsonConvert.SerializeObject(Session("dst_T2A").Tables("TareasGenericas"))
            File.WriteAllText(Server.MapPath(("./App_Data/" & DropDownList1.SelectedValue & ".json")), serialDoc.ToString())

            Label1.Text = "Tareas exportadas con exito a " & DropDownList1.SelectedValue & ".json"
        Catch ex As Exception
            Label1.Text = "Error al exportar las tareas a JSON"
        End Try
    End Sub
End Class