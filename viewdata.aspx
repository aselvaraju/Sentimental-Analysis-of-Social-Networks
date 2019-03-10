<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="viewdata.aspx.cs" Inherits="viewdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT [postedby], [posteddate], [postedtime], [sharedto], [post], [membername], [comment], [memberdatetime] FROM [webdataset]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

