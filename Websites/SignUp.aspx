<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Users_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Password1 {
            width: 466px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong>Sign Up here<br />
        <br />
        Admin accounts cannot be created here. Only for users account. </strong><br />
        <br />
        UserName :
        <asp:TextBox ID="UNameTextBox" runat="server" Width="451px"></asp:TextBox>
        <br />
        <br />
        Password :
        <input id="Password1" type="password" runat="server" /><br />
        <br />
        Please input the password again after generating the image verifier.<br />
        <br />
        Email Id :
        <asp:TextBox ID="MailIdTextBox" runat="server" Width="444px"></asp:TextBox>
        <br />
        <br />
        Bank Account Number :
        <asp:TextBox ID="AccountNoTextBox" runat="server" Width="514px"></asp:TextBox>
        <br />
        <br />
        Bank Address :
        <asp:TextBox ID="BankAddrTextBox" runat="server" Height="97px" Width="812px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
        <br />
        <br />
        Enter the length of string for image verification<br />
        <asp:TextBox ID="CaptchaStringTextBox" runat="server" Width="415px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="GenerateButton" runat="server" OnClick="GenerateButton_Click" Text="Generate Image Verifier" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <br />
        <asp:TextBox ID="ValidateTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SignUpButton" runat="server" OnClick="SignUpButton_Click" Text="Sign Up" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
