﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="Laboratorio2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Inicio</asp:HyperLink>
            <br />
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="bt_login" runat="server" Text="Login" />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Registro.aspx">Registrar</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CambiarPassword.aspx">Modificar password</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
