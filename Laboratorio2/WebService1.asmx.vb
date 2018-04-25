Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Logica_Negocio.accesoBD
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function obtenerDedicacionMediaAsig(asig As String) As Integer
        Dim horas = 0
        conectar()
        Dim st = "SELECT avg(HReales) FROM EstudiantesTareas INNER JOIN TareasGenericas on CodTarea=Codigo and CodAsig='" & asig & "'"
        Dim comm As New SqlCommand(st, conexion)
        Dim resp = comm.ExecuteScalar()
        cerrarConexion()
        If resp Is DBNull.Value Then
            Return horas
        End If
        Return resp
    End Function


End Class