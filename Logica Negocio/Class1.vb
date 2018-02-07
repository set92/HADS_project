Imports System.Net.Mail
Imports System.Net.NetworkCredential

Public Class Class1

    Function generar_numAleatorio() As Integer
        Randomize()
        Return CLng(Rnd() * 9000000) + 1000000
    End Function

    Public Function enviarEmail() As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("@ikasle.ehu.eus", "stobal001")
            'Direccion de destino
            Dim to_address As New MailAddress("set.tobur@gmail.com")
            'Password de la cuenta
            Dim from_pass As String = "gz7!EkUvY"
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

            'Añadimos el asunto
            message.Subject = "subject"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "body" + "</body></html>"
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
