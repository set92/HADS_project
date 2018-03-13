Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class accesoOleBD
    Private Shared conexion As New OleDbConnection
    Private Shared adapter As New OleDbDataAdapter
    Private Shared datos As New DataSet

    Public Shared Function conectar() As String
        Try
            conexion = New OleDbConnection("Server=tcp:hads14-2018.database.windows.net,1433;Initial Catalog=HADS14-TAREAS;Persist Security Info=False;User ID=admin14;Password=admin_hads18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            conexion.Open()

            Return "CONEXION OK"
        Catch ex As Exception
            Return "ERROR DE CONEXION: " + ex.Message
        End Try
    End Function

    Public Shared Function cerrarConexion() As String
        Try
            conexion.Close()

            Return "CONEXION CERRADA OK"
        Catch ex As Exception
            Return "ERROR DE CIERRE DE CONEXION: " + ex.Message
        End Try
    End Function

    Public Shared Function obtenerTareas(ByVal mail As String) As DataSet
        Dim sql = "select Codigo, Descripcion, TareasGenericas.HEstimadas, TipoTarea, CodAsig from TareasGenericas inner join EstudiantesTareas on (TareasGenericas.Codigo=EstudiantesTareas.CodTarea)  where EstudiantesTareas.Email='" & mail & "' and TareasGenericas.Explotacion=1 and EstudiantesTareas.HReales=0"

        conexion = New OleDbConnection("Provider=SQLNCLI11;Server=tcp:hads14-2018.database.windows.net,1433;Initial Catalog=HADS14-TAREAS;Persist Security Info=False;User ID=admin14;Password=admin_hads18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        conexion.Open()

        adapter = New OleDbDataAdapter(sql, conexion)
        adapter.Fill(datos, "TareasG")

        conexion.Close()

        Return datos
    End Function

End Class