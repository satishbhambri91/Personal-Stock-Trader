<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bank Account Page.aspx.cs" Inherits="Bank_Account_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        <br />
        <br />
    
        Your Bank Account details are as given below:<br />
        <br />
        <asp:Label ID="AccountDetailsLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Account" />
        <br />
        <br />
        <br />
        Enter the Amount to deposit or withdraw :<br />
        <br />
        <asp:TextBox ID="AmountTextBox" runat="server" Height="60px" style="margin-top: 0px" Width="662px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="DepositButton" runat="server" OnClick="DepositButton_Click" Text="Deposit" Width="293px" />
        <br />
        <br />
        <asp:Button ID="WithdrawButton" runat="server" OnClick="WithdrawButton_Click" Text="Withdraw" Width="290px" />
        <br />
        <br />
        <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        <br />
        <br />
        <asp:Label ID="StatusLabel" runat="server" Text="Status"></asp:Label>
    
    </div>
    </form>
</body>
</html>
