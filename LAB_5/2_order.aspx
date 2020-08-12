<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="StateManagDemo.order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your Order Summary:<br />
            <br />
            <asp:ListBox ID="lbbill" runat="server" Enabled="False"></asp:ListBox>
        </div>
        <p>
            Total Cost : Rs.
            <asp:Label ID="lcost" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
