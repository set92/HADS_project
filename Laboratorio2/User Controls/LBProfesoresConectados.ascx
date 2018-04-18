<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LBProfesoresConectados.ascx.vb" Inherits="Laboratorio2.LBProfesoresConectados" %>
<asp:UpdatePanel ID="UpdatePanel1" width="250px" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <span class="auto-style1">Profesores Conectados: </span>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server" Height="79px" Width="220px">
            <asp:ListItem>0 conectados</asp:ListItem>
        </asp:ListBox>
        <br />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>
<asp:Timer ID="Timer1" runat="server" Interval="2000">
</asp:Timer>
