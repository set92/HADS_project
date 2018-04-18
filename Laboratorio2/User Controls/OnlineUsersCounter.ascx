<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OnlineUsersCounter.ascx.vb" Inherits="Laboratorio2.OnlineUsersCounter1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <span class="auto-style1"><strong>Usuarios Online</strong></span>:
        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>
<asp:Timer ID="Timer1" runat="server" Interval="2000">
</asp:Timer>
