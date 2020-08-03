<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebDemo.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Full Name:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtfname" runat="server" Height="29px" Width="238px"></asp:TextBox>
&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname" ErrorMessage="This field is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Age:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numage" runat="server" Width="75px" TextMode="Number"></asp:TextBox>
            &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="numage" ErrorMessage="Range 18 to 50*" ForeColor="Red" MaximumValue="50" MinimumValue="18" Type="Integer"></asp:RangeValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpass1" runat="server" Width="230px" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpass2" runat="server" Width="230px" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass1" ControlToValidate="txtpass2" ErrorMessage="Passwords does not match*" ForeColor="Red"></asp:CompareValidator>
            <br />
        </div>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Gender:"></asp:Label>
&nbsp;<div style=" width: 118px;">
&nbsp;&nbsp;
            <asp:RadioButtonList ID="radgender" runat="server" Height="16px" Width="123px">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
            </asp:RadioButtonList>
        &nbsp;
        </div>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Mobile No:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nummob" runat="server" TextMode="Number"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="nummob" ErrorMessage="Should be a 10 digit number*" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Hobbies:"></asp:Label>
        &nbsp;
        <br />
&nbsp;<asp:CheckBoxList ID="checkbhob" runat="server" Width="124px">
            <asp:ListItem>Coding</asp:ListItem>
            <asp:ListItem>Sports</asp:ListItem>
            <asp:ListItem>Books</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="State:"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:DropDownList ID="ddstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="Maharashtra">Maharashtra</asp:ListItem>
            <asp:ListItem Value="Gujarat" Selected="True">Gujarat</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="City:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddcity" runat="server" AutoPostBack="True">
            <asp:ListItem Value="Ahemdabad">Ahemdabad</asp:ListItem>
            <asp:ListItem Value="Vadodara">Vadodara</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="PAN number:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="numpan" runat="server"></asp:TextBox>
&nbsp;
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="numpan" EnableClientScript="False" ErrorMessage="Should be 10 Digit and start with either letter ‘B” or ‘A’*" ForeColor="Red" SetFocusOnError="True" BorderStyle="None" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <p>
            <asp:Button ID="go" runat="server" Height="35px" Text="Submit" Width="112px" OnClick="Button1_Click" />
        &nbsp;</p>
        <p>
            ---------------------------------------------------------------------------------------</p>
           <h3> Your Details:</h3>
            Full name :
            <asp:Label ID="lfname" runat="server"></asp:Label>
        <p>
            Age :
            <asp:Label ID="lage" runat="server"></asp:Label>
        </p>
        <p>
            Gender :
            <asp:Label ID="lgender" runat="server"></asp:Label>
        </p>
        <p>
            Mobile No :
            <asp:Label ID="lmob" runat="server"></asp:Label>
        </p>
        <p>
            Hobbies :
            <asp:Label ID="lhob" runat="server"></asp:Label>
        </p>
        <p>
            State :
            <asp:Label ID="lstate" runat="server"></asp:Label>
        </p>
        <p>
            City :
            <asp:Label ID="lcity" runat="server"></asp:Label>
        </p>
        <p>
            PAN no :
            <asp:Label ID="lpan" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
