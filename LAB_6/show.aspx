<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="AdoDemo.show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="insert.aspx">Insert</asp:LinkButton>
&nbsp;|
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="edit.aspx">Edit</asp:LinkButton>
            <br />
            Student Details</h3>
            <p>
                <asp:GridView ID="griddetail" runat="server">
                </asp:GridView>
            </p>
            <p>
                <asp:Label ID="lbconerr" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
