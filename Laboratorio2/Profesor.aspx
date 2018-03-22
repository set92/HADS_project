<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Laboratorio2.Profesor" %>

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
                        <asp:MenuItem NavigateUrl="~/VerEstadisticas.aspx" Text="Estadisticas" Value="Estadisticas"></asp:MenuItem>
                        <asp:MenuItem Text="Asignaturas" Value="Asignaturas"></asp:MenuItem>
                        <asp:MenuItem Text="Tareas" Value="Tareas" NavigateUrl="~/TareasProfesor.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Grupos" Value="Grupos"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ImportarTareasXML.aspx" Text="Importar XML" Value="Importar XML"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ExportarTareasXML.aspx" Text="Exportar XML" Value="Exportar XML"></asp:MenuItem>
                        <asp:MenuItem Text="Importar Dataset" Value="Importar Dataset" NavigateUrl="~/ImportarDataset.aspx"></asp:MenuItem>
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
                Profesores
                
            </div>
        </div>
        
    </form>
</body>
</html>
