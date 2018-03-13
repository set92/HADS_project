<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="Laboratorio2.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <p style="background-color:lightgray;font-weight:bold;">ALUMNO - GESTION DE TAREAS GENERICAS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Inicio.aspx">CERRAR SESION</asp:LinkButton></p>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura (solo se ven las matriculadas)"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Instanciar" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
