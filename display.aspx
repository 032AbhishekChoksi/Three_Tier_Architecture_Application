<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="display.aspx.cs" Inherits="Three_Tier_Architecture_Application.display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Customer</title>
</head>
<body>
    <a href="index.aspx">Add Record</a><br/>
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table collspan="10">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            
            <tr>               
                <td><%# Eval("id") %></td>
                <td><%# Eval("name") %></td>
                <td><%# Eval("emailid") %></td>
                <td><a href='index.aspx?id=<%# Eval("id") %>&type=update'>Edit</a>&emsp;
                    <a href='display.aspx?id=<%# Eval("id") %>&type=delete'>Delete</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>
</body>
</html>
