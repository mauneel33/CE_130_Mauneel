<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="LINQdemo1.update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> Update Student Details</h3>
            <br />
            Enter the Student ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numsid" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
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
            <asp:Label ID="lbcpi" runat="server" Text="CPI:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcpi" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbcontact" runat="server" Text="Contact No.:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcontact" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbemail" runat="server" Text="Email ID:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" Visible="False" />
        </div>
    </form>
</body>
</html>
