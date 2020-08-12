<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="StateManagDemo.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
            Welcome
            <asp:Label ID="lusr" runat="server"></asp:Label>
            ,<br />
            <br />
        </h3>
        <div>
            Select type of Item:<br />
            <br />
        </div>
        <asp:RadioButtonList ID="rblitem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblitem_SelectedIndexChanged">
            <asp:ListItem>Electronics</asp:ListItem>
            <asp:ListItem>Books</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Select the item:<br />
        <br />
        <asp:ListBox ID="lbitem" runat="server" OnSelectedIndexChanged="lbitem_SelectedIndexChanged" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="40px" OnClick="Button1_Click" Text="Place Order" Width="138px" />
    </form>
</body>
</html>
