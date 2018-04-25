<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="coordinador.aspx.vb" Inherits="Laboratorio2.coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="cont">
            <h4>Dedicaciones Medias con Ajax</h4>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <td>Asignaturas:<br />
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" Width="300px" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS14-TAREASConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas] ORDER BY [codigo]"></asp:SqlDataSource>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Obtener Dedicación" />
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
