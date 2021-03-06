﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="Laboratorio2.Alumno" %>

<%@ Register Src="~/User Controls/OnlineUsersCounter.ascx" TagPrefix="uc1" TagName="OnlineUsersCounter" %>
<%@ Register Src="~/User Controls/LBProfesoresConectados.ascx" TagPrefix="uc1" TagName="LBProfesoresConectados" %>
<%@ Register Src="~/User Controls/LBAlumnosConectados.ascx" TagPrefix="uc1" TagName="LBAlumnosConectados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex;">
            <div>
                <br />
                <br />
                <br />
            </div>
            <div style="width: 200px;background-color:#FFFBD6">
                <br />
                <br />
                <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.4em" ForeColor="#990000" StaticSubMenuIndent="10px" Height="200px">
                    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#FFFBD6" />
                    <DynamicSelectedStyle BackColor="#FFCC66" />
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Alumno/TareasAlumno.aspx" Text="Tareas Genericas" Value="Tareas Genericas"></asp:MenuItem>
                        <asp:MenuItem Text="Tareas Propias" Value="Tareas Propias"></asp:MenuItem>
                        <asp:MenuItem Text="Grupos" Value="Grupos"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#FFCC66" />
                </asp:Menu>
            </div>
            <div style="flex-grow: 1;font-size:xx-large;text-align:center;background-color:lightcyan;margin-left:40px;font-weight:bold">
                <br />
                <br />
                Gestion Web de Tareas-Dedicacion 

                <br />
                <br />
                Alumnos

                <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
            
           

            <uc1:OnlineUsersCounter runat="server" ID="OnlineUsersCounter" />
            <uc1:LBProfesoresConectados runat="server" ID="LBProfesoresConectados" />
            <uc1:LBAlumnosConectados runat="server" ID="LBAlumnosConectados" />
            <br />
           
            </div>
        </div>
        
    </form>
</body>
</html>
