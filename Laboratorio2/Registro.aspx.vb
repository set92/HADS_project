Public Class Registro
    Inherits System.Web.UI.Page
    Public matriculado As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not matriculado Then
            Label8.Text = tb_email.Text & " no esta matriculado en la asignatura"
            Return
        End If

        Dim ln As New Logica_Negocio.EnviarEmail
        Dim datos_user As Array = {tb_email.Text, tb_nombre.Text, tb_apellidos.Text, ln.Generar_numAleatorio(), 0, DropDownList1.SelectedValue, tb_pass2.Text}
        Dim url As String
        url = Context.Request.Url.Scheme & "://" & Context.Request.Url.Host & ":" & Request.Url.Port & "/Confirmar.aspx?mbr=" & tb_email.Text & "&numconf=" & datos_user(3)

        hl_linkRegistro.NavigateUrl = "" & url
        ln.Registro_usuario(datos_user, url)
    End Sub

    Protected Sub tb_email_TextChanged(sender As Object, e As EventArgs) Handles tb_email.TextChanged
        Dim x As New service1.Matriculas
        Dim resp = x.comprobar(tb_email.Text)
        If resp = "SI" Then
            matriculado = True
            Label8.Text = "El usuario esta matriculado y se puede registrar"
            Label8.ForeColor = Drawing.Color.Green
        Else
            Label8.Text = "Usuario no matriculado en la asignatura"
            Label8.ForeColor = Drawing.Color.Red
            matriculado = False
        End If
    End Sub
End Class