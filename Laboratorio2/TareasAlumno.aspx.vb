﻿Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Private Shared datos As New DataSet
    Private Shared vista As New DataView
    Private Shared table As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Session("log") = False Or Session("rol") = "p") Then
        'Response.Redirect("~/Inicio.aspx")
        'End If
        If Not IsPostBack Then
            ' Dim mail = Session.Contents("email")
            Dim mail = "pepe@ikasle.ehu.es"

            datos = Logica_Negocio.accesoOleBD.obtenerTareas(mail)
            table = datos.Tables("TareasG")
            vista = New DataView(table)

            DropDownList1.DataSource = vista.ToTable(True, "CodAsig")
            DropDownList1.DataValueField = "CodAsig"
            DropDownList1.DataBind()

            vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
            GridView1.DataSource = vista.ToTable
            GridView1.DataBind()

            Session.Contents("DataSetTareasAlumno") = datos
            Session.Contents("DataViewTareas") = vista
            Session.Contents("DataTableTareas") = table
            Session.Contents("flagDesc") = True
            Session.Contents("flagH") = True
            Session.Contents("FlagT") = True
        Else
            datos = Session.Contents("DataSetTareasAlumno")
            vista = Session.Contents("DataViewTareas")
            table = Session.Contents("DataTableTareas")
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Protected Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        Dim v = vista
        v.Sort = e.SortExpression
        'vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        GridView1.DataSource = v.ToTable
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        vista.RowFilter = "CodAsig='" & DropDownList1.SelectedValue & "'"
        GridView1.DataSource = Nothing
        GridView1.DataSource = vista.ToTable
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session.Contents("Tarea") = table.Rows(GridView1.SelectedIndex).Item(0).ToString
        Session.Contents("HEstimada") = table.Rows(GridView1.SelectedIndex).Item(2).ToString
        Session.Contents("DataSetTareasAlumno") = Nothing
        Session.Contents("DataViewTareas") = Nothing
        Session.Contents("DataTableTareas") = Nothing
        Response.Redirect("~/InstanciarTarea.aspx")
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