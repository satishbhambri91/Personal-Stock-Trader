<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Login Page<br />
        <br />
        <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter Username"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter Password"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <input id="Password1" type="password" runat="server"/><br />
        <br />
        <br />
        <br />
        <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" OnClick="SignUpButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
