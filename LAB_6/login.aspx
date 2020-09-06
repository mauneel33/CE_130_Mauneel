<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdoDemo.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> Log in</h3>
            <br />
            ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numid" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Butlog" runat="server" Text="Log in" OnClick="Butlog_Click" />
        </div>
    </form>
</body>
</html>
