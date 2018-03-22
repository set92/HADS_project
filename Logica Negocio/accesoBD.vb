Imports System.Data.Common
Imports System.Data.SqlClient

Public Class accesoBD
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Private Shared dataAdapET As New SqlDataAdapter
    Private Shared dataAdapTG As New SqlDataAdapter

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = "Server=tcp:hads14-2018.database.windows.net,1433;Initial Catalog=HADS14-TAREAS;Persist Security Info=False;User ID=admin14;Password=admin_hads18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
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

    Public Shared Function insertarUsuario(ByVal datos As Array) As String
        Dim sql = "insert into Usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values('" & datos(0) & "', '" & datos(1) & "', '" & datos(2) & "', " & datos(3) & ", " & datos(4) & ", '" & datos(5) & "', '" & datos(6) & "')"
        Dim numRegistro As Integer

        Try
            comando = New SqlCommand(sql, conexion)
            numRegistro = comando.ExecuteNonQuery()
            Return "USUARIO INSERTADO OK"
        Catch ex As Exception
            Return "ERROR INSERCION USUARIO: " + ex.Message
        End Try
    End Function

    Public Shared Function existeUsuario(ByVal datos As Array) As String
        Dim sql = "update Usuarios set confirmado=1 where email='" & datos(0) & "' and numconfir=" & datos(1)

        Try
            comando = New SqlCommand(sql, conexion)

            If comando.ExecuteNonQuery() = 1 Then
                Return "USUARIO CONFIRMADO OK"
            Else
                Return "NO EXISTE EL USUARIO"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "ERROR AL IDENTIFICAR EL USUARIO: " + ex.Message
        End Try
    End Function

    Public Shared Function existeMail(ByVal mail As String) As String
        Dim sql = "select count(email) from Usuarios where email='" & mail & "'"

        Try
            comando = New SqlCommand(sql, conexion)
            If comando.ExecuteScalar() = 1 Then
                Return "EXISTE MAIL OK"
            Else
                Return "NO EXISTE EL MAIL"
            End If
        Catch ex As Exception
            Return "ERROR AL COMPROBAR EL MAIL: " + ex.Message
        End Try
    End Function

    Public Shared Function cambiarPassword(ByVal datos As Array) As String
        Dim sql = "update Usuarios set pass='" & datos(1) & "' where email='" & datos(0) & "'"

        Try
            comando = New SqlCommand(sql, conexion)
            If comando.ExecuteNonQuery() = 1 Then
                Return "CONTRASEÑA CAMBIADA OK"
            Else
                Return "NO EXISTE UN USUARIO CON ESA CONTRASEÑA"
            End If
        Catch ex As Exception
            Return "ERROR AL CAMBIAR LA CONTRASEÑA DEL USUARIO: " + ex.Message
        End Try
    End Function

    Public Shared Function loginUsuario(ByVal datos As Array) As String
        Dim sql = "select count(email) from Usuarios where email='" & datos(0) & "' and pass='" & datos(1) & "' and confirmado=1"

        Try
            comando = New SqlCommand(sql, conexion)
            If comando.ExecuteScalar() = 1 Then
                Return "LOGIN USUARIO OK"
            Else
                Return "NO EXISTE ESE USUARIO"
            End If
        Catch ex As Exception
            Return "ERROR AL ACCEDER EL USUARIO: " + ex.Message
        End Try
    End Function

    Public Shared Function tipoUsuario(ByVal datos As Array) As String
        Dim sql = "select * from Usuarios where email='" & datos(0) & "'"
        Dim vDatos As SqlDataReader
        Dim tipo As String = ""
        comando = New SqlCommand(sql, conexion)
        vDatos = comando.ExecuteReader
        While vDatos.Read
            tipo = vDatos.Item("tipo")
        End While
        vDatos.Close()
        Return tipo

    End Function

    Public Shared Function obtenerTareasGenericas_Profesor() As SqlDataAdapter
        Dim st = "SELECT * FROM TareasGenericas"
        Dim dapt = New SqlDataAdapter(st, conexion)
        cerrarConexion()
        Return dapt
    End Function

    Public Shared Function obtenerTareas(ByVal mail As String) As DataSet
        Dim sql = "select Codigo, Descripcion, HEstimadas, TipoTarea, CodAsig from TareasGenericas where Explotacion=1 and Codigo not in (select CodTarea from EstudiantesTareas where Email='" & mail & "')"
        Dim dataset As New DataSet
        dataAdapTG = New SqlDataAdapter(sql, conexion)

        dataAdapTG.Fill(dataset, "TareasG")
        Return dataset
    End Function

    Public Shared Function export_asignaturas(ByVal mail As String) As DataSet
        Dim sql = "SELECT codigoasig FROM ((GruposClase INNER JOIN ProfesoresGrupo ON email='" & mail & "'and codigogrupo=codigo))"
        Dim dataset As New DataSet
        dataAdapTG = New SqlDataAdapter(sql, conexion)

        dataAdapTG.Fill(dataset, "Asignaturas")
        Return dataset
    End Function

    Public Shared Function export_2(ByVal codigo As String) As DataSet
        Dim sql = "SELECT codigo,descripcion,hestimadas,explotacion,tipotarea FROM TareasGenericas WHERE CodAsig='" & codigo & "'"
        Dim dataset As New DataSet
        dataAdapTG = New SqlDataAdapter(sql, conexion)
        Dim bldMbrs As New SqlCommandBuilder(dataAdapTG)
        dataAdapTG.Fill(dataset, "TareasGenericas")
        Return dataset
    End Function

    Public Shared Function import_tareasGenericas() As DataAdapter
        Dim sql = "Select * FROM TareasGenericas"
        Dim dataset As New DataSet
        dataAdapTG = New SqlDataAdapter(sql, conexion)
        Dim bldMbrs As New SqlCommandBuilder(dataAdapTG)
        dataAdapTG.Fill(dataset, "TareasGenericas")
        Return dataAdapTG
    End Function

    Public Shared Function import_tareasGenericas_porCodAsig(ByVal codigo As String) As DataAdapter
        Dim sql = "Select * FROM TareasGenericas WHERE CodAsig='" & codigo & "'"
        Dim dataset As New DataSet
        dataAdapTG = New SqlDataAdapter(sql, conexion)
        Dim bldMbrs As New SqlCommandBuilder(dataAdapTG)
        dataAdapTG.Fill(dataset, "TareasGenericas")
        Return dataAdapTG
    End Function


    Public Shared Function obtenerEstudiantesTareas(ByVal mail As String) As DataSet
        Dim sql = "select Email, CodTarea, HEstimadas, HReales from EstudiantesTareas where Email='" & mail & "'"
        Dim dataset As New DataSet
        dataAdapET = New SqlDataAdapter(sql, conexion)
        Dim blabla As New SqlCommandBuilder(dataAdapET)

        dataAdapET.Fill(dataset, "EstudiantesT")
        Return dataset
    End Function

    Public Shared Sub instanciarTarea(ByVal datos As DataTable)
        dataAdapET.Update(datos.DataSet, "EstudiantesT")
        datos.DataSet.AcceptChanges()
    End Sub
End Class
