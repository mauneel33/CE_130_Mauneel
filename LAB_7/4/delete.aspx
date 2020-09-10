<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="LINQdemo1.delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Delete Student Details</h3>Enter the Student ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numsid" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete" />
            <br/>
            <br />
        </div>
    </form>
</body>
</html>
