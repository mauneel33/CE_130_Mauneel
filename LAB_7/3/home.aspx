<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="LINQdemo1.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> Select Product:</h3>
            <br />
            Enter the Product ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numpid" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
