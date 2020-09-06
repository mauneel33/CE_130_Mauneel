<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="AdoDemo.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Order Details:<br />
            <br />
            <asp:ListBox ID="listdetail" runat="server"></asp:ListBox>
        </div>
        <p>
            Total Amount to be Paid : <asp:Label ID="lbbill" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
