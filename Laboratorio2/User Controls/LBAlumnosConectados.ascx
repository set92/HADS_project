<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LBAlumnosConectados.ascx.vb" Inherits="Laboratorio2.LBAlumnosConectados" %>

<asp:UpdatePanel ID="UpdatePanel1" width="250px" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <strong><span class="auto-style1">Alumnos Conectados: </span></strong><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server" Height="79px" Width="220px">
            <asp:ListItem>Nadie Conectado</asp:ListItem>
        </asp:ListBox>
        <br />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>
<asp:Timer ID="Timer1" runat="server" Interval="4000">
</asp:Timer>