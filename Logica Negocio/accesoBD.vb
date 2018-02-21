﻿Imports System.Data.SqlClient

Public Class accesoBD
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

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
End Class
