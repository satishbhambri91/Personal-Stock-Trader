using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stocks_Page : System.Web.UI.Page
{
    StockServiceReference.Service1Client cl = new StockServiceReference.Service1Client();
    ASUStockServiceReference.ServiceClient ASUclient = new ASUStockServiceReference.ServiceClient();
    StringBuilder sb = new StringBuilder();
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

            //List<string> list = new List<string>();
            string[][] list1 = cl.GetStockLiveData();
            //LivePricesLabel.Text = ASUclient.getStockquote("IBM");
            int counter = 0;
            List<StockData> StockList = new List<StockData>();
            foreach (var item in list1)
            {
                counter++;
                if (counter == 50)
                {
                    break;
                }
                StockData sd = new StockData(item[0].ToString(), item[1].ToString(), item[3].ToString(), item[5].ToString());
                StockList.Add(sd);
            }
            StockDataGridView.DataSource = StockList;
            StockDataGridView.DataBind();
        }
        catch (Exception ex)
        {
            LiveStockPricesLabel.Text = ex.Message;
        }
    }

    
    protected void HDataButton_Click(object sender, EventArgs e)
    {
        string hdata = cl.getHistData(HDataTextBox.Text);
        List<string[]> flst = new List<string[]>();
        List<string> hdlist = new List<string>();
        var secondlist = new List<string>(); 
        hdlist = hdata.Split('&').ToList();
        foreach (var item in hdlist)
        {
            secondlist = item.Split(';').ToList();   
        }
        //var reader = new StreamReader(hdata);
        //while(!reader.EndOfStream)
        //{
        //    var readitem = reader.ReadLine().Split('&');
        //    hdlist.Add(readitem);
        //}
        List<StockDataItem> hdsourcelist = new List<StockDataItem>();
        //foreach (var item in hdlist)
        //{
        //    StockDataItem sdi = new StockDataItem();
        //    hdsourcelist.Add(sdi);
        //}
        GridView1.DataSource = hdlist;
        GridView1.DataBind();
       // hdlist.Add(hdata.Split("////"));
        //HttpContext.Current.Response.Write(hdata);
        //g.DataSource = hdata;
        //g.Enabled = true;
    }

    protected void StockDataGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
       var val =  StockDataGridView.SelectedRow.Attributes["Symbol"];
       HttpContext.Current.Response.Write(val);
    }
    protected void BuySellButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Transact Service Page.aspx");
    }
    protected void AccountButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bank Account Page.aspx");
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

    protected void PriceButton_Click(object sender, EventArgs e)
    {
        try
        {
            LiveStockPricesLabel.Text = ASUclient.getStockquote(HDataTextBox.Text);
        }
        catch (Exception ex)
        {

            LiveStockPricesLabel.Text = ex.Message;
        }
        
        
    }
}

public class StockData
{
    public string StockSymbol { get; set; }
    public string StockName { get; set; }
    public string MarketCap { get; set; }
    public string StockSector { get; set; }
    //public string StockSector;
    public double currentprice = 0;

    public StockData()
    {

    }
    public StockData(string StockSymbol, string StockName, string MarketCap, string StockSector)
    {
        this.StockSymbol = StockSymbol;
        this.StockName = StockName;
        this.MarketCap = MarketCap;
        this.StockSector = StockSector;
    }
}

public class StockDataItem
{
    public string open { get; set; }
    public string high { get; set; }
    public string low { get; set; }
    public string close { get; set; }
    public string volume { get; set; }

    public StockDataItem()
    {

    }
    public StockDataItem(string open, string high, string low, string close, string volume)
    {
        this.open = open;
        this.high = high;
        this.low = low;
        this.close = close;
        this.volume = volume;
    }
}