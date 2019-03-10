<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="performance.aspx.cs" Inherits="performance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Performance Grid"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Performance Chart"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Timing Chart"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="pform" HeaderText="Performance" SortExpression="pform" />
                        <asp:BoundField DataField="pval" HeaderText="Performance Value" SortExpression="pval" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [performdet]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Chart ID="Chart1" runat="server" BackColor="255, 128, 128" BackGradientStyle="HorizontalCenter" DataSourceID="SqlDataSource2" Palette="EarthTones">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="pform" YValueMembers="pval" YValuesPerPoint="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Performance in sec">
                            </AxisY>
                            <AxisX Title="Performance">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [performdet]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Chart ID="Chart2" runat="server" BackColor="128, 255, 128" BackGradientStyle="HorizontalCenter" DataSourceID="SqlDataSource3" Palette="Excel">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="tname" YValueMembers="tval"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Performance in sec">
                            </AxisY>
                            <AxisX Title="Analyzed Data">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [trainchart]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                Data Chart
            </td>
            <td>
                Redundant Chart
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource4" BackColor="Plum" Palette="Excel">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="dataname" YValueMembers="dataval"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT [dataname], [dataval] FROM [reportchart]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource5" BackColor="PaleTurquoise" Palette="Berry">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="reddata" YValueMembers="redval"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT [reddata], [redval] FROM [redreport]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

