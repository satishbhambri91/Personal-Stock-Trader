using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class UsersInfo : System.Web.UI.Page
{
    LoginServiceReference.Service1Client cl = new LoginServiceReference.Service1Client();
    protected void Page_Load(object sender, EventArgs e)
    {
        string datalist = cl.DisplayXmlData();
        string[] fdata = datalist.Split(';');
       // DataLabel.Text = fdata;
        GridView1.DataSource = fdata;
        GridView1.DataBind();
       
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin2/VerifyUserInfo.aspx");
    }
    protected void SetStatusButton_Click(object sender, EventArgs e)
    {
        string uname = TextBox1.Text;
        cl.setverificationstatus(uname);
        Response.Redirect("UsersInfo.aspx");
    }
}