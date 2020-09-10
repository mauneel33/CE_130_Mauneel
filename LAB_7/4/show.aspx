<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="LINQdemo1.show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Student Details</h3>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" DataKeyNames="sid" >
            </asp:GridView>
            <br />
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LINQdemo1.DataClasses1DataContext" EntityTypeName="" TableName="students" Where="sid == @sid">
                <WhereParameters>
                    <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="sid" PropertyName="SelectedValue" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
            <br />
            <br />
            <h3>Details View</h3>
            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="sid" DataSourceID="LinqDataSource1">
                <Fields>
                    <asp:BoundField DataField="sid" HeaderText="sid" ReadOnly="True" SortExpression="sid" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="sem" HeaderText="sem" SortExpression="sem" />
                    <asp:BoundField DataField="cpi" HeaderText="cpi" SortExpression="cpi" />
                    <asp:BoundField DataField="contactno" HeaderText="contactno" SortExpression="contactno" />
                    <asp:BoundField DataField="emailid" HeaderText="emailid" SortExpression="emailid" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
