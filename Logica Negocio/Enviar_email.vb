Imports System.Net.Mail

Public Class EnviarEmail

    Function Registro_usuario(objUser As Array, url As String) As Integer
        'el num aleatorio ha sido generado en registrar para poder visualizar la url alli tambien
        accesoBD.conectar()

        If String.Compare(accesoBD.insertarUsuario(objUser), "USUARIO INSERTADO OK") = 0 Then
            accesoBD.cerrarConexion()
            Return Enviar_email("registro", objUser(0), url)
        Else
            accesoBD.cerrarConexion()
            Return -1
        End If
    End Function

    Function Cambiar_password(email As String) As Integer
        'Usar mismo generador?pero este no daba numeros de 7 cifras?en el powerpoint usa de 6 cifras
        Dim num_random As Integer = Generar_numAleatorio()

        Return Enviar_email("cambiarPassword", email, num_random)
    End Function

    Public Function Generar_numAleatorio() As Integer
        Randomize()
        Return CLng(Rnd() * 9000000) + 1000000
    End Function

    Public Function Enviar_email(tipo As String, toWho As String, url As String) As Integer
        Try
            Dim from_address As New MailAddress("pruebahads@zoho.eu")
            Dim to_address As New MailAddress(toWho)
            Dim smtp As New SmtpClient With {
                .Host = "smtp.zoho.eu",
                .Port = 587,
                .EnableSsl = True,
                .UseDefaultCredentials = False,
                .Credentials = New System.Net.NetworkCredential(from_address.Address, "pruebahads2018")
            }

            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)

            Select Case tipo
                Case "registro"
                    message.Subject = "Confirmacion de registro"
                    message.Body = " Visita este link para terminar tu registro : " & url
                    message.IsBodyHtml = True
                    smtp.Send(message)
                    Return True
                Case "cambiarPassword"
                    message.Subject = "Cambiar password"
                    message.Body = "El codigo es: " & url
                    message.IsBodyHtml = True
                    smtp.Send(message)
                    Return url
            End Select
        Catch e As Exception
            MsgBox(e.Message)
            Return False
        End Try
        Return True
    End Function

End Class
