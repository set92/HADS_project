<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareasXML.aspx.vb" Inherits="Laboratorio2.ImportarTareasXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <br />
    <p style="background-color: lightgray; font-weight: bold;">
        PROFESOR - IMPORTAR TAREAS GENERICAS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Profesor.aspx">MENU PROFESOR</asp:LinkButton>
    </p>
    <br />

    <table style="border-spacing: 80px;">
            <td>
                <h4>Importar Asignaturas</h4>
                <br />
                Asignaturas
            <br />
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" Width="240px" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS14-TAREASConnectionString %>" SelectCommand="SELECT codigoAsig FROM ((GruposClase INNER JOIN ProfesoresGrupo ON email=@profesor and codigogrupo=codigo))">
                    <SelectParameters>
                        <asp:SessionParameter Name="profesor" SessionField="mail" Type="String" DefaultValue="blanco@ehu.es" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />

                &nbsp;
            </td>

    <td>
        <br />
    </td>
    <td>
        <asp:Xml ID="Xml1" runat="server" TransformSource="~/App_Data/XSLTFile.xsl"></asp:Xml><br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Importar Tareas XMLD" />
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;      
    </td>
    </table>
        
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False">Ordenar por codigo</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False">Ordenar por descripcion</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False">Ordenar por horas estimadas</asp:LinkButton>
 </form>
</body>
</html>
