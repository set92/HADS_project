Imports System.Data.SqlClient

Public Class accesoBD
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = "Server=tcp:hads14-2018.database.windows.net,1433;Initial Catalog=HADS14-TAREAS;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
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
        Dim sql = "insert into Usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values('" & datos(0) & "', '" & datos(1) & "', '" & datos(2) & "', '" & datos(3) & "', " & datos(4) & ", '" & datos(5) & "')"
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
        Dim sql = "update confirmado from Usuarios where numconfir='" & datos(1) & "'"

        Try
            comando = New SqlCommand(sql, conexion)

            Else
            Return "NO EXISTE EL USUARIO"
            End If
        Catch ex As Exception
            Return "ERROR AL CONSULTAR EL USUARIO: " + ex.Message
        End Try
    End Function
End Class
