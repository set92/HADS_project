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
            <br />
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura (solo se ven las matriculadas)"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Instanciar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
