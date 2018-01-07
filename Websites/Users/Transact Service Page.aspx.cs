using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transact_Service_Page : System.Web.UI.Page
{
    TransactServiceReference.Service1Client cl = new TransactServiceReference.Service1Client();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookies = Request.Cookies["myCookieId"];
        if ((myCookies == null) || (myCookies["UserName"] == ""))
        {
            WelcomeLabel.Text = "Welcome new user!";

        }
        else
        {
            WelcomeLabel.Text = "Welcome" + " " + myCookies["UserName"];
        }
    }
    protected void BuyButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (StockSymbolTextBox.Text == "" || StockSymbolTextBox.Text == null)
            {
                StatusLabel.Text = "Please enter the stock symbol";
            }
            else
            {
                string abc = cl.BuyStock(StockSymbolTextBox.Text, Convert.ToInt32(AmountTextBox.Text));
                StatusLabel.Text = abc;
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = ex.Message;
        }
    }
    protected void SellStockButton_Click(object sender, EventArgs e)
    {
        try
        {
            string def = cl.SellStock(StockSymbolTextBox.Text, Convert.ToInt32(AmountTextBox.Text));
            StatusLabel.Text = def;
        }
        catch (Exception ex)
        {
            StatusLabel.Text = ex.Message;
        }
    }
    protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("View Stocks Page.aspx");
    }
    protected void SignOutButton_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        //Server.Transfer("IndexPage.aspx");
        Response.Redirect("~/IndexPage.aspx");
        HttpCookie myCookies = Request.Cookies["myCookieId"];
        myCookies["UserName"] = "";
        myCookies = null;
    }
}