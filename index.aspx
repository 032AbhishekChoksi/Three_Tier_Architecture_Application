<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Three_Tier_Architecture_Application.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Managment System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>&emsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="lblEmailID" runat="server" Text="Email ID"></asp:Label>&emsp;
            <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="bttnSubmit" runat="server" Text="Add" OnClick="BttnSubmit_Click" />            
        </div>
    </form>
</body>
</html>
