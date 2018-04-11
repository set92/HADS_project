<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VerEstadisticas.aspx.vb" Inherits="Laboratorio2.VerEstadisticas" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="784px" Width="1000px">
                <series>
                    <asp:Series Name="Series1" XValueMember="Codigo" YValueMembers="HEstimadas">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Horas estimadas" TitleFont="Microsoft Sans Serif, 10.125pt">
                        </AxisY>
                        <AxisX Interval="1" Title="Tareas" TitleFont="Microsoft Sans Serif, 10.125pt">
                            <MajorGrid Enabled="false" />
                        </AxisX>
                        <AxisX2 LineColor="DarkRed">
                        </AxisX2>
                        <AxisY2 LineColor="Red">
                        </AxisY2>
                    </asp:ChartArea>
                </chartareas>
                <Titles>
                    <asp:Title BackColor="224, 224, 224" Font="Microsoft Sans Serif, 16.125pt" Name="Title1" Text="Tareas genericas">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS14-TAREASConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
