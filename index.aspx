<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Styles/StyleSheet.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>                                                                       
    
         <table style="width:1340px;height:100px; background-color: #666666;">
        <tr>
            <td style="text-align: center;font-size: x-large; font-weight: bold;color: #FFFFFF;">
                <asp:Label ID="Label1" runat="server" Text="SENTIMENTAL DATA ANALYSIS" Font-Bold="True" Font-Names="Cambria"></asp:Label>
            </td>
        </tr>
    </table>
        <table style="width:1340px;height:30px; background-color: #000000;">
            <tr>
                <td>

                </td>
            </tr>
        </table>
        <center>

                         <br />
                         <br />

                         <fieldset style="width:423px; " >
                        <legend>Login</legend>
                    
        <table>
            <tr>
               
                <td>
                    <table style="height: 152px; width: 334px; background-color: #C0C0C0;">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Username" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" Font-Bold="True" Font-Names="Cambria" />
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btncancel" runat="server" Text="Cancel" Font-Bold="True" Font-Names="Cambria" OnClick="btncancel_Click" />
                            &nbsp;<asp:Label ID="lblmes" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label></td>
                        </tr>
                    </table>
                </td>               
            </tr>
        </table>
                             <br />
</fieldset>  
            </center>
    </div>
    </form>
</body>
</html>
