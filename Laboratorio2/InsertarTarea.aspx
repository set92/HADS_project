<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="Laboratorio2.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Inserción de Tareas Genéricas</h4>
            <br />
       
        Codigo:
        <asp:TextBox ID="TextBox1" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Rellena el codigo de la Tarea" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Descripcion:
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="402px" TextMode="MultiLine" Height="64px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Rellena algun Detalle de la Tarea" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Asignatura:
        <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS14-TAREASConnectionString %>" SelectCommand="SELECT codigoAsig FROM ((GruposClase INNER JOIN ProfesoresGrupo ON email=@email and codigogrupo=codigo))">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="mail" DefaultValue="blanco@ehu.es" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        Horas Estimadas:
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number" Width="76px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Asigna las horas estimadas de la Tarea" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Tipo de tarea:
        <asp:DropDownList ID="DropDownList2" CssClass="form-control" Width="200px" runat="server">
            <asp:ListItem Selected="True">Laboratorio</asp:ListItem>
            <asp:ListItem>Examen</asp:ListItem>
            <asp:ListItem>Trabajo</asp:ListItem>
            <asp:ListItem>Ejercicio</asp:ListItem>
            <asp:ListItem>Otros</asp:ListItem>
            </asp:DropDownList>
        <br />

            <asp:Button ID="bt_add_tarea" runat="server" Text="Añadir Tarea" />
            <br />
               
            <asp:Label ID="LabelError" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
            <br />
       
            <br />
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareasProfesor.aspx">Ver Tareas</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
