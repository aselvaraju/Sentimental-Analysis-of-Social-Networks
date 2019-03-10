<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="ranking.aspx.cs" Inherits="ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style3 {
        width: 342px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="vertical-align: top">           
    <table>
        <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text="Enter Ranking Keyword"></asp:Label>
              </td>
                <td>
                  <asp:TextBox ID="txtranking" runat="server"></asp:TextBox>                        
                  <asp:Button ID="btnsubmit" runat="server" Text="Submit" Font-Bold="True" Font-Names="Cambria" OnClick="btnsubmit_Click" />                                 
                   </td>
           <%-- <td>
                 <asp:Button ID="btnshow" runat="server" Text="Show Result" Font-Bold="True" Font-Names="Cambria" OnClick="btnshow_Click" />                                 
            </td>--%>
        </tr>
    </table>

                 </td>
            <td class="auto-style3">
                <asp:Button ID="btnclear" runat="server" Text="Clear Ranking" Font-Bold="True" Font-Names="Cambria" OnClick="btnclear_Click"/>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" DataKeyNames="rword" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="rword" HeaderText="List of Ranking Keyword" SortExpression="rword" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT [rword] FROM [ranking]"></asp:SqlDataSource>
            </td>
            <td class="auto-style3">
                <asp:Chart ID="Chart1" runat="server" BackColor="Sienna" BackGradientStyle="HorizontalCenter" DataSourceID="SqlDataSource4" Palette="Bright" Visible="False">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="rankkeyword" YValueMembers="numtime"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="No of Occurence">
                            </AxisY>
                            <AxisX Title="Ranking Keyword">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [rankkeyselect]"></asp:SqlDataSource>
            </td>
            <td style="vertical-align: top">
                <asp:Chart ID="Chart2" runat="server" BackColor="Silver" BackGradientStyle="HorizontalCenter" DataSourceID="SqlDataSource5" Visible="False">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="analyse" YValueMembers="analysecount"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Analyse Count">
                            </AxisY>
                            <AxisX Title="Analyse Data">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [analysedatadet]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td class="auto-style3">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource2" GridLines="None" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="rankkeyword" HeaderText="Rank Key Word" SortExpression="rankkeyword" />
                        <asp:BoundField DataField="numtime" HeaderText="Occurence Time" SortExpression="numtime" />
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT [rankkeyword], [numtime] FROM [rankkeyselect]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource6" GridLines="Vertical" Visible="False">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="analyse" HeaderText="analyse" SortExpression="analyse" />
                        <asp:BoundField DataField="analysecount" HeaderText="analysecount" SortExpression="analysecount" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [analysedatadet]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                          <asp:Button ID="btnview" runat="server" Text="View Ranking" Font-Bold="True" Font-Names="Cambria" OnClick="btnview_Click"/>
                        </td>
                        <td>
                            <asp:Button ID="btnanalyse" runat="server" Text="Analyse Data" Font-Bold="True" Font-Names="Cambria" OnClick="btnanalyse_Click"/>
                        </td>
                    </tr>
                </table>                
            </td>
        </tr>
        <tr>            
            <td>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Vertical" Visible="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="postedby" HeaderText="postedby" SortExpression="postedby" />
                        <asp:BoundField DataField="posteddate" HeaderText="posteddate" SortExpression="posteddate" />
                        <asp:BoundField DataField="postedtime" HeaderText="postedtime" SortExpression="postedtime" />
                        <asp:BoundField DataField="sharedto" HeaderText="sharedto" SortExpression="sharedto" />
                        <asp:BoundField DataField="post" HeaderText="post" SortExpression="post" />
                        <asp:BoundField DataField="membername" HeaderText="membername" SortExpression="membername" />
                        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                        <asp:BoundField DataField="memberdatetime" HeaderText="memberdatetime" SortExpression="memberdatetime" />
                        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [rankdet]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

