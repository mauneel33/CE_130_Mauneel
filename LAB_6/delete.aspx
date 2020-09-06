<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="AdoDemo.delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="show.aspx">Show</asp:LinkButton>
            </h3>
            <h3>Delete Student details</h3>
            <p>Student ID:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="numid" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete" />
            </p>
            <p>
                <asp:Label ID="lbmsg" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lbrow" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
