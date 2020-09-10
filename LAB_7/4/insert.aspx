<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="LINQdemo1.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Insert Student Details</h3>
            <br />
            Name :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            <br />
            Sem :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numsem" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            CPI:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcpi" runat="server"></asp:TextBox>
            <br />
            <br />
            Contact No.:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcontact" runat="server"></asp:TextBox>
            <br />
            <br />
            Email ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
        </div>
    </form>
</body>
</html>
