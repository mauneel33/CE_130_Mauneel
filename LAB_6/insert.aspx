<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="AdoDemo.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="edit.aspx">Edit</asp:LinkButton>
&nbsp;|
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="show.aspx">Show</asp:LinkButton>
        </h3>
        <h3>Add Student</h3>
        <asp:Label ID="Label1" runat="server" Text="Name (First+Last):"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtname" runat="server" Height="29px" Width="199px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Sem:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="numsem" runat="server" Width="63px" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Mob No. :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nummob" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Email-ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtemail" runat="server" Width="201px" TextMode="Email"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Reset1" type="reset" value="Reset" /><br />
        <br />
        <asp:Label ID="lconerr" runat="server"></asp:Label>
    </form>
</body>
</html>
