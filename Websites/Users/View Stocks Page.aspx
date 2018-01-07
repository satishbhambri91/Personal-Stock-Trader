<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View Stocks Page.aspx.cs" Inherits="View_Stocks_Page" %>

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
    
        Find the live prices of the stocks, their symbols and companies.
        <br />
        Enter the symbol of any particular stock to view the historical data of that stock.
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="LiveStockPricesLabel" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="HDataTextBox" runat="server" Height="53px" Width="395px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GetLiveStocks" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="HDataButton" runat="server" OnClick="HDataButton_Click" Text="Get Historical Data" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="PriceButton" runat="server" OnClick="PriceButton_Click" Text="Get Live Price" />
        <br />
        <br />        
        <asp:Label ID="LivePricesLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BuySellButton" runat="server" OnClick="BuySellButton_Click" Text="Buy/Sell Stocks" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="AccountButton" runat="server" OnClick="AccountButton_Click" Text="Account Information" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        <br />
        <br />
        <asp:GridView ID="StockDataGridView" runat="server" AllowSorting="True" OnSelectedIndexChanged="StockDataGridView_SelectedIndexChanged">
            <SelectedRowStyle BackColor="#33CCFF" />
        </asp:GridView>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True">
            <SelectedRowStyle BackColor="#33CCFF" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
    <%-- <form id="form2" runat="server">
    <div>
    <asp:Repeater id="testDataGrid" runat="server" >

        <ItemTemplate runat="server">
            <table>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="StockName" Text='<%# Eval("Name") %>' Visible="true" />
                    </td>
                </tr>
                <tr>
                    <td>SymBol</td>
                    <td>
                        <asp:TextBox ID="StockSymbol" Text='<%# Eval("Symbol") %>' Visible="true" /></td>
                </tr>
                <tr>
                    <td>MarketCap</td>
                    <td>
                        <asp:TextBox ID="MarketCap" Text='<%# Eval("MarketCap") %>' Visible="true" /></td>
                </tr>
            </table>
        </ItemTemplate>

    </asp:Repeater>
    </div>
    </form>--%>
</body>
</html>
