Imports System.Net.Mail

Public Class EnviarEmail

    Function Registro_usuario(objUser As Array, url As String) As Integer
        'el num aleatorio ha sido generado en registrar para poder visualizar la url alli tambien
        accesoBD.conectar()

        If String.Compare(accesoBD.insertarUsuario(objUser), "USUARIO INSERTADO OK") = 0 Then
            MsgBox("Entrar")
            Return Enviar_email("registro", objUser(0), url)
        Else
            MsgBox("Usuario ya existe en BD")
            Return "Error"
        End If
        accesoBD.cerrarConexion()
        Return Enviar_email("registro", objUser(0), url)
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
                Case "cambiarPassword"
                    message.Subject = "Cambiar password"
                    message.Body = "El codigo es: " & url
            End Select

            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
            Return url
        Catch e As Exception
            MsgBox(e.Message)
            Return False
        End Try
        Return True
    End Function

End Class
