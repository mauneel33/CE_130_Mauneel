<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StateManagDemo.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 89px;
        }
        .auto-style2 {
            width: 89px;
            height: 47px;
        }
        .auto-style3 {
            height: 47px;
        }
        .auto-style4 {
            height: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="linvalid" runat="server" ForeColor="Red"></asp:Label>
            <br />
            Username : user1 and Password : user1</div>
        <table class="auto-style4">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtusnm" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log in" />
                </td>
                <td>
                    <input id="Reset1" type="reset" value="reset" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
