<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transact Service Page.aspx.cs" Inherits="Transact_Service_Page" %>

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
    
        Transact Stocks here :<br />
        Enter the Stock Symbol and Number of Stocks you want to buy or sell.<br />
        In case of Insufficient funds, go back to home and add the amount in your account. <br />
        <br />
        Stock Symbol :
        <asp:TextBox ID="StockSymbolTextBox" runat="server" Height="54px"></asp:TextBox>
        <br />
        <br />
        Amount :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="AmountTextBox" runat="server" Height="51px" Width="299px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BuyButton" runat="server" OnClick="BuyButton_Click" Text="Buy Stocks" />
        <br />
        <br />
        <asp:Button ID="SellStockButton" runat="server" OnClick="SellStockButton_Click" Text="Sell Stocks" />
        <br />
        <br />
        <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        <br />
        <br />
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
