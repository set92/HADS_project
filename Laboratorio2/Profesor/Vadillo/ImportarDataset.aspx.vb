﻿Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO

Public Class ImportarDataset
    Inherits System.Web.UI.Page

    Dim xml As XmlDocument
    Dim dapt As SqlDataAdapter
    Dim dst As DataSet
    Dim tbAsig As DataTable
    Dim tbTareas As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session.Contents("mail") = "blanco@ehu.es"
        If Not IsPostBack Then

            Logica_Negocio.accesoBD.conectar()
            dst = Logica_Negocio.accesoBD.export_asignaturas(Session.Contents("mail"))
            Logica_Negocio.accesoBD.cerrarConexion()

            tbAsig = New DataTable()
            tbAsig = dst.Tables("Asignaturas")

            DropDownList1.DataSource = tbAsig
            DropDownList1.DataValueField = "codigoasig"
            DropDownList1.DataBind()
            DropDownList1.Items.Item(0).Selected = True

            Logica_Negocio.accesoBD.conectar()
            dapt = Logica_Negocio.accesoBD.import_tareasGenericas_porCodAsig(DropDownList1.SelectedValue)
            Logica_Negocio.accesoBD.cerrarConexion()

            Dim bldMbrs As New SqlCommandBuilder(dapt)
            dst = New DataSet()
            dapt.Fill(dst, "TareasGenericas")

            Session("dapt_tg") = dapt
            Session("dst_tg") = dst
            tbTareas = New DataTable()
            tbTareas = dst.Tables("TareasGenericas")

            GridView1.DataSource = tbTareas
            GridView1.DataBind()
        Else
            tbTareas = Session("dst_tg").Tables("TareasGenericas")
            dst = Session("dst_tg")
            dapt = Session("dapt_tg")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists(Server.MapPath("./App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
            Label1.ForeColor = Drawing.Color.Black
            Label1.Text = ""
            Dim ds As New DataSet
            ds.ReadXml(Server.MapPath("./App_Data/" & DropDownList1.SelectedValue & ".xml"))
            Dim bldMbrs As New SqlCommandBuilder(Session("dapt"))
            Dim tmp As DataColumn = New DataColumn
            tmp.ColumnName = "CodAsig"
            tmp.DefaultValue = DropDownList1.SelectedValue
            ds.Tables(0).Columns.Add(tmp)
            ds.Tables(0).Columns("Codigo").Unique = True

            Try
                GridView1.DataSource = Session("dst_tg").Tables(0)
                GridView1.DataBind()
            Catch ex As Exception
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "Hay tareas con el mismo codigo, no se pueden insertar"
            End Try

            Try
                Session("dapt_tg").update(ds.Tables(0))
                Session("dst_tg").AcceptChanges()
                Label1.Text = "Tareas Añadidas con exito"
            Catch ex As Exception
                Label1.Text = "Hay tareas con el cógigo clave repetído en el xml"
            End Try
        Else
            Label1.Text = "No hay XML(Tareas) en App_Data de esta asignatura "
        End If
    End Sub

    Private Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        Logica_Negocio.accesoBD.conectar()
        dapt = Logica_Negocio.accesoBD.import_tareasGenericas_porCodAsig(DropDownList1.SelectedValue)
        Logica_Negocio.accesoBD.cerrarConexion()

        Dim bldMbrs As New SqlCommandBuilder(Session("dapt_tg"))
        dst = New DataSet()
        dapt.Fill(dst, "TareasGenericas")
        Session("dapt_tg") = dapt
        Session("dst_tg") = dst

        tbTareas = New DataTable()
        tbTareas = dst.Tables("TareasGenericas")

        GridView1.DataSource = tbTareas
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Logica_Negocio.accesoBD.conectar()
        dapt = Logica_Negocio.accesoBD.import_tareasGenericas_porCodAsig(DropDownList1.SelectedValue)
        Logica_Negocio.accesoBD.cerrarConexion()

        Dim bldMbrs As New SqlCommandBuilder(dapt)
        dst = New DataSet()
        dapt.Fill(dst, "TareasGenericas")

        Session("dapt_tg") = dapt
        Session("dst_tg") = dst
        tbTareas = New DataTable()
        tbTareas = dst.Tables("TareasGenericas")
        GridView1.DataSource = tbTareas
        GridView1.DataBind()
    End Sub
End Class