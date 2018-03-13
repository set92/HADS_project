Imports System.Data.SqlClient

Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bt_add_tarea_Click(sender As Object, e As EventArgs) Handles bt_add_tarea.Click
        Logica_Negocio.accesoBD.conectar()
        Dim dapt = Logica_Negocio.accesoBD.obtenerTareasGenericas_Profesor()
        Logica_Negocio.accesoBD.cerrarConexion()
        Dim bldMbrs As New SqlCommandBuilder(dapt)
        Dim dst = New DataSet()
        dapt.Fill(dst, "TareasGenericas") 'cargamos la tabla
        Dim tbTareas = New DataTable()
        tbTareas = dst.Tables("TareasGenericas")

        tbTareas.Columns("Codigo").Unique = True 'inserta en la tabla solo una vez cada tarea

        Try
            Dim tmp = tbTareas.NewRow()
            tmp("Codigo") = TextBox1.Text
            tmp("Descripcion") = TextBox2.Text
            tmp("CodAsig") = DropDownList1.SelectedValue
            tmp("HEstimadas") = TextBox3.Text
            tmp("Explotacion") = False
            tmp("TipoTarea") = DropDownList2.SelectedValue

            tbTareas.Rows.InsertAt(tmp, tbTareas.Rows.Count + 1)

            dapt.Update(dst, "TareasGenericas") 'commit
            dst.AcceptChanges()
            LabelError.Text = "Tarea insertada con éxito, cambios guardados en la BD"
        Catch ex As ConstraintException
            LabelError.ForeColor = Drawing.Color.Red
            LabelError.Text = "Otra Tarea ya contiene ese código"
        Catch x As Exception
            LabelError.Text = x.Message
        End Try

    End Sub

End Class