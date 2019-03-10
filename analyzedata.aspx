<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="analyzedata.aspx.cs" Inherits="analyzedata" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="vertical-align: top">
                <table style="height: 143px; width: 260px">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Total Number of Comment"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbltottestcase" runat="server" Text="............" 
                            ForeColor="#3333CC"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Number of Positive Comment"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblpassed" runat="server" Text="............" 
                            ForeColor="#009900"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Number of  Negative Comment"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblfailed" runat="server" Text="............" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Number of  Moderate Comment"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblmoderate" runat="server" Text="............" 
                            ForeColor="#FF9900"></asp:Label>
                    </td>
                </tr>
                 <tr>
                     <td>
                         <asp:Label ID="Label1" runat="server" Text="Total Number of Redundant Data"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblredundantdata" runat="server" Text="0" ForeColor="#000066"></asp:Label>
                     </td>
                 </tr>
                    <%--<tr>
                        <td>
                        <asp:Button ID="btnanalyzedata" runat="server" Text="ANALYZE DATA" BackColor="#006699" BorderColor="#003366" Font-Bold="True" Font-Names="Cambria" Width="183px" OnClick="btnanalyzedata_Click" ForeColor="White" />
                        </td>
                    </tr>--%>
            </table>
                <br />
                <asp:Label ID="lbltotcom" runat="server" ForeColor="White" Text="0" Visible="False"></asp:Label>
            </td>
            <td style="vertical-align: top"> 
                <asp:Chart ID="Chart1" runat="server" BackColor="0, 192, 192" DataSourceID="SqlDataSource2" Visible="False">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="analyse" YValueMembers="analysecount"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Data Count">
                            </AxisY>
                            <AxisX Title="Sentimental Data">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>                  
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [analysedatadet]"></asp:SqlDataSource>                
            </td>
            <td class="auto-style3" style="vertical-align: top">
                <table>
                    <tr>
                        <td>
                            -----------------USERS
                            ----------------</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource3" GridLines="Vertical" ForeColor="Black" Visible="False">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField DataField="uname" HeaderText="User Name" SortExpression="uname" />
                                    <asp:BoundField DataField="cnt" HeaderText="No of Comments" SortExpression="cnt" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [userdet]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ---------------COMMENTS
                            --------------</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSource4" ForeColor="Black" Visible="False">
                                <Columns>
                                    <asp:BoundField DataField="commentname" HeaderText="Comment Name" SortExpression="commentname" />
                                    <asp:BoundField DataField="notime" HeaderText="No of Time" SortExpression="notime" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [commentdet]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnremove" runat="server" Text="Remove & Analyze" Font-Bold="True" Font-Names="Cambria" OnClick="btnremove_Click" BackColor="#990000" BorderColor="Maroon" ForeColor="White"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView2_RowDataBound" Visible="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="postedby" HeaderText="Posted By" SortExpression="postedby" />
                        <asp:BoundField DataField="posteddate" HeaderText="Posted Date" SortExpression="posteddate" />
                        <asp:BoundField DataField="postedtime" HeaderText="Posted Time" SortExpression="postedtime" />
                        <asp:BoundField DataField="sharedto" HeaderText="Shared To" SortExpression="sharedto" />
                        <asp:BoundField DataField="post" HeaderText="Post" SortExpression="post" />
                        <asp:BoundField DataField="membername" HeaderText="Member Name" SortExpression="membername" />
                        <asp:BoundField DataField="comment" HeaderText="Comments" SortExpression="comment" />
                        <asp:BoundField DataField="memberdatetime" HeaderText="Member Datetime" SortExpression="memberdatetime" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [webdataset]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

