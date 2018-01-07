using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptionClassLibrary;

public partial class Login : System.Web.UI.Page
{
    Class1 EncrytionDecryptionObject = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            String username = TextBox1.Text;
            String password = Password1.Value;
            String mpwd = EncrytionDecryptionObject.Encrypt(password);
            if (username == null || username == "" || password == null || password == "")
            {
                Label3.Text = "Please enter valid credentials";
            }
            LoginServiceReference.Service1Client login = new LoginServiceReference.Service1Client();
            // Login.Service1Client login = new Login.Service1Client();
            bool result = login.Login(username, mpwd);

            HttpCookie myCookies = new HttpCookie("myCookieId");
            myCookies["UserName"] = TextBox1.Text;
            myCookies.Expires = DateTime.Now.AddDays(20);
            Response.Cookies.Add(myCookies);

            if (result)
            {

                Label3.Text = "Login Successful..";
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);

                // Response.Redirect("View Stocks Page.aspx");

            }
            else
            {
                Label3.Text = "Please Check The credentials ";
            }
        }
        catch (Exception ex) 
        {
            Label3.Text = ex.Message;
        }

    }
    protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexPage.aspx");
    }
}