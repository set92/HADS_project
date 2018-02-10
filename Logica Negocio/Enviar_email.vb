﻿Imports System.Net.Mail
Imports System.Net.NetworkCredential

Public Class Enviar_email

    Function registro_usuario(objUser As Object) As Integer
        Dim num_random As Integer = generar_numAleatorio()
        'metodo insertar bd

        Return enviarEmail("registro", objUser(0), num_random)
    End Function

    Function generar_numAleatorio() As Integer
        Randomize()
        Return CLng(Rnd() * 9000000) + 1000000
    End Function

    Public Function enviarEmail(tipo As String, toWho As String, num As Integer) As Boolean
        toWho = "set.tobur@gmail.com"
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("@ikasle.ehu.eus", "stobal001")
            'Password de la cuenta
            Dim from_pass As String = ""
            'Direccion de destino
            Dim to_address As New MailAddress(toWho)
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ikasle.ehu.eus"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)

            Select Case tipo
                Case "registro"
                    message.Subject = "Confirmacion de registro"
                    message.Body = "<html><head></head><body>" + "http://localhost:55505/Confirmar.aspx?mbr=" + toWho + "&numconf=" + num + "</body></html>"
                Case "cambiarPassword"
                    message.Subject = "Cambiar password"
                    message.Body = "<html><head></head><body>" + "body" + "</body></html>"
            End Select

            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

End Class
