using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class VerifyUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    public void SendMail()
{
    try
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(txtTo.Text);
        mail.From = new MailAddress(AdminMailTextBox.Text);
        mail.Subject = txtsubject.Text; ;
        string Body = txtmessage.Text;
        mail.Body = Body;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; 
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential
        (AdminMailTextBox.Text, Password1.Value);
        smtp.EnableSsl = true;
        smtp.Send(mail);
        Label1.Text = "Mail sent successfully..";
    }
        catch(Exception ex)
    {
        Label1.Text = ex.Message;
        }
}
protected void  Bttn_Send_Click(object sender, EventArgs e)
{
    SendMail();
}

}