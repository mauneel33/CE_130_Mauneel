<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="AdoDemo.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <h3>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="insert.aspx">Insert</asp:LinkButton>
&nbsp;|
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="show.aspx">Show</asp:LinkButton>
        <br />
        <br />
        Edit Student Details</h3>
        <br />
        Enter the Student ID whose details needs to changed:<br />
        <br />
        Student ID:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="numid" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="butedit" runat="server" Height="35px" OnClick="Button2_Click" Text="Edit" />
        <br />
        <br />
        <asp:Label ID="lbconerr1" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbname" runat="server" Text="Name:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtname" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbsem" runat="server" Text="Sem:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="numsem" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbmob" runat="server" Text="Mob No.:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nummob" runat="server" TextMode="Phone" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbemail" runat="server" Text="Email-ID:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtemail" runat="server" TextMode="Email" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="butupdate" runat="server" OnClick="butupdate_Click" Text="Update" Visible="False" />
        <br />
        <br />
        <asp:Label ID="lbconerr2" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbrow" runat="server"></asp:Label>
    </form>
</body>
</html>
