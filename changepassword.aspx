<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="height: 177px; width: 760px">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Old Password" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtoldpassword" ErrorMessage="Old Password Required" Font-Bold="True" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="New Password" Width="200px" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpassword" ErrorMessage="New Password Required" Font-Bold="True" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Retype Password" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtretypepassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpassword" ControlToValidate="txtretypepassword" ErrorMessage="Password Not Matched" Font-Bold="True" ForeColor="Red" ValidationGroup="validate"></asp:CompareValidator>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtretypepassword" ErrorMessage="Retype Passwprd Required" Font-Bold="True" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="btnchange" runat="server" Text="Change" ValidationGroup="validate" OnClick="btnchange_Click" Font-Bold="True" Font-Names="Cambria"/>
                &nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" Font-Bold="True" Font-Names="Cambria" OnClick="btnback_Click"/>
            &nbsp;<asp:Label ID="lblmes" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
                &nbsp;<asp:Label ID="lblusername" runat="server" Text="username" Visible="False"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

