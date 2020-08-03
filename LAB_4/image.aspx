<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="image.aspx.cs" Inherits="WebDemo.demoImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 421px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="img.jpg" Visible="False" />
        <p>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click here" />
        </p>
    </form>
</body>
</html>
