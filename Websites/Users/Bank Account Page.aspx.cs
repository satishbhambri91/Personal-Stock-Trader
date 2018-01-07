using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bank_Account_Page : System.Web.UI.Page
{
    //BankingServiceReference.Service1Client cl = new BankingServiceReference.Service1Client();
    Uri baseUri = new Uri("http://webstrar6.fulton.asu.edu/page6/Service1.svc/");
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
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            //AccountDetailsLabel.Text = cl.ViewAmount();
            //UriTemplate myTemplate = new UriTemplate("ViewAmount");

            //Uri completeUri = myTemplate.BindByPosition(baseUri,);
            Uri completeUri = new Uri("http://webstrar6.fulton.asu.edu/page6/Service1.svc/ViewAmount");
            WebClient proxy = new WebClient();

            byte[] abc = proxy.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string generatedString = obj.ReadObject(strm).ToString();

            string status = generatedString;
            AccountDetailsLabel.Text = generatedString;
        }
        catch (Exception ex)
        {
            StatusLabel.Text = ex.Message;
        }
    }
    protected void DepositButton_Click(object sender, EventArgs e)
    {
        try
        {
        if (AmountTextBox.Text == "")
        {
            StatusLabel.Text = "Please enter a valid amount";
        }
        else 
        {
            UriTemplate myTemplate = new UriTemplate("DepositAmount?value={value}");

            Uri completeUri = myTemplate.BindByPosition(baseUri, AmountTextBox.Text);

            WebClient proxy = new WebClient();

            byte[] abc = proxy.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string generatedString = obj.ReadObject(strm).ToString();

            string status  = generatedString;
            //= cl.DepositAmount(Convert.ToDouble(AmountTextBox.Text));
            StatusLabel.Text = status;
        }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = ex.Message;
        }
    }
    protected void WithdrawButton_Click(object sender, EventArgs e)
    {
        try { 
        if (AmountTextBox.Text == "")
        {
            StatusLabel.Text = "Please enter a valid amount";
        }
        else
        {
            UriTemplate myTemplate = new UriTemplate("WithdrawAmount?value={value}");

            Uri completeUri = myTemplate.BindByPosition(baseUri, AmountTextBox.Text);

            WebClient proxy = new WebClient();

            byte[] abc = proxy.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string generatedString = obj.ReadObject(strm).ToString();

            string status = generatedString;
            //string status = cl.WithdrawAmount(Convert.ToDouble(AmountTextBox.Text));
            StatusLabel.Text = status;
        }
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