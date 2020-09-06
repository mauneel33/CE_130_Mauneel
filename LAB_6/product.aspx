<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="AdoDemo.product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Select the Products:<br />
            <br />
            <asp:GridView ID="gridprod" runat="server">
            </asp:GridView>
            <br />
            <asp:ListBox ID="listprod" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Place Order" />
        </div>
    </form>
</body>
</html>
