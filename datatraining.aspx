<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="datatraining.aspx.cs" Inherits="datatraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            height: 20px;
        }
    .auto-style4 {
        height: 20px;
        width: 428px;
    }
    .auto-style5 {
        width: 428px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <table style="height: 114px; width: 426px">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Upload Positive Words" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" Font-Bold="True" Font-Names="Cambria" OnClick="btnsubmit_Click" />
                        </td>
                        <td>
                             <asp:Button ID="btncancel" runat="server" Text="Cancel" Font-Bold="True" Font-Names="Cambria" OnClick="btncancel_Click" />
                        &nbsp; <asp:Label ID="lblack" runat="server" ForeColor="#CC0000" Text="Uploaded Successfully !!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table style="height: 114px; width: 426px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Upload Negative Words" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnnegsubmit" runat="server" Text="Submit" Font-Bold="True" Font-Names="Cambria" OnClick="btnnegsubmit_Click" />
                        </td>
                        <td>
                             <asp:Button ID="btnnegcancel" runat="server" Text="Cancel" Font-Bold="True" Font-Names="Cambria" OnClick="btnnegcancel_Click" />
                        &nbsp; <asp:Label ID="lblack1" runat="server" ForeColor="#CC0000" Text="Uploaded Successfully !!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table style="width: 847px; height: 172px;">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label3" runat="server" Text="List of Positive Words" ForeColor="#CC0000"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label4" runat="server" Text="List of Negative Words" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="pword" OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="pword" HeaderText="List of Positive Words" SortExpression="pword" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [positive]"></asp:SqlDataSource>
            </td>
            <td style="vertical-align: top">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="nword" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView2_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nword" HeaderText="List of Negative Words" SortExpression="nword" />
                        <asp:CommandField ShowDeleteButton="True" />
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connection %>" SelectCommand="SELECT * FROM [negative]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

