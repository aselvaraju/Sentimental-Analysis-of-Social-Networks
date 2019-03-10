<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="deepanalysis.aspx.cs" Inherits="deepanalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.hilight 
{
/*text-decoration:none; 
font-weight:bold;
color:black;*/
 background-color:yellow;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Button ID="btnpositive" runat="server" Text="Positive" Font-Bold="True" Font-Names="Cambria" OnClick="btnpositive_Click" />
            </td>
             <td>
                <asp:Button ID="btnnegative" runat="server" Text="Negative" Font-Bold="True" Font-Names="Cambria" OnClick="btnnegative_Click1" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
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
                        <asp:BoundField DataField="positive" HeaderText="positive" SortExpression="positive" />
                        <asp:BoundField DataField="negative" HeaderText="negative" SortExpression="negative" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [webdataset]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

