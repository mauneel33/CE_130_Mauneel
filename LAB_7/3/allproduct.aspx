<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allproduct.aspx.cs" Inherits="LINQdemo1.allproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> All Product Details</h3>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="pid" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="pid" HeaderText="pid" InsertVisible="False" ReadOnly="True" SortExpression="pid" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                    <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [product] WHERE [pid] = @pid" InsertCommand="INSERT INTO [product] ([name], [description], [category], [price]) VALUES (@name, @description, @category, @price)" SelectCommand="SELECT * FROM [product]" UpdateCommand="UPDATE [product] SET [name] = @name, [description] = @description, [category] = @category, [price] = @price WHERE [pid] = @pid">
                <DeleteParameters>
                    <asp:Parameter Name="pid" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="price" Type="Int64" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="price" Type="Int64" />
                    <asp:Parameter Name="pid" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
