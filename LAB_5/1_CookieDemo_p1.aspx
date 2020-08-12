<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieDemo_p1.aspx.cs" Inherits="StateManagDemo.CookieDemo_p1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter Your name:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="41px" OnClick="Button1_Click" Text="Go" Width="98px" />
        </div>
    </form>
</body>
</html>
