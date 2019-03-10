<%@ Page Title="" Language="C#" MasterPageFile="~/sentimental.master" AutoEventWireup="true" CodeFile="uploaddata.aspx.cs" Inherits="uploaddata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table>
                        <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" Height="117px" ImageUrl="~/Pictures/excel.jpg" 
                                Width="141px" />
                        </td>
                        <td>
                        <table style="height: 117px; width: 387px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Upload Dataset:" 
                                        ForeColor="#CC0000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="True" 
                                        Font-Names="Cambria" />
                                    <br />
                                    <br />
                                    <asp:Button ID="Button4" runat="server" Font-Bold="True" Font-Names="Cambria" 
                                        onclick="Button4_Click" Text="Upload" style="height: 26px" />
                                    &nbsp;
                                    <asp:Button ID="Button5" runat="server" Font-Bold="True" Font-Names="Cambria" 
                                        Text="Cancel" OnClick="Button5_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lblack" runat="server" ForeColor="#CC0000" 
                                        Text="Uploaded Successfully !!" Visible="False"></asp:Label>
                                </td>
                            </tr>
                         </table>                         
                        
                        </td>
                        </tr>
                       </table>
</asp:Content>

