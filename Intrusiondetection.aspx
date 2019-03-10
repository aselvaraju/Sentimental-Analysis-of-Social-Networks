<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="Intrusiondetection.aspx.cs" Inherits="Intrusiondetection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting" Width="701px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="uname" HeaderText="Username" SortExpression="uname" />
                        <asp:BoundField DataField="triedpwd" HeaderText="Tried Password" SortExpression="triedpwd" />
                        <asp:BoundField DataField="triedip" HeaderText="Tried IP" SortExpression="triedip" />
                        <asp:BoundField DataField="adate" HeaderText="Attack Date" SortExpression="adate" />
                        <asp:BoundField DataField="atime" HeaderText="Attack Time" SortExpression="atime" />
                        <asp:BoundField DataField="matchper" HeaderText="Match Percentage" SortExpression="matchper" />
                        <asp:CommandField ShowDeleteButton="True" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [hackerdet]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

