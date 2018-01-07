using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptionClassLibrary;

public partial class Users_SignUp : System.Web.UI.Page
{
    VerifierServiceReference.ServiceClient verifier = new VerifierServiceReference.ServiceClient();
    Class1 EncryptionDecryptionObject = new Class1();

    //static string genstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        try 
        {
            if (UNameTextBox.Text == null || UNameTextBox.Text == " " || Password1.Value == null || Password1.Value == " " || MailIdTextBox.Text == null || MailIdTextBox.Text == " ")
            {
                StatusLabel.Text = "Please enter valid Username, Password and email";
            }
            if (CaptchaStringTextBox.Text == null || CaptchaStringTextBox.Text == "")
            {
                StatusLabel.Text = "Please enter the string size";
            }
         if (ValidateTextBox.Text == null || ValidateTextBox.Text == "")
            {
                StatusLabel.Text = "Please verify the string";
            }   
        if (ValidateTextBox.Text == Session["genstr"].ToString())
            {

                String username = UNameTextBox.Text;
                String password = Password1.Value;
                string email = MailIdTextBox.Text;
                string bankaccountno = AccountNoTextBox.Text;
                string bankaddr = BankAddrTextBox.Text;

                LoginServiceReference.Service1Client login = new LoginServiceReference.Service1Client();
                string pwd = EncryptionDecryptionObject.Encrypt(password);
                bool check = login.Login(username, pwd);
                if (!check)
                {
                    login.SignUp(username, pwd, email, bankaccountno, bankaddr);
                    StatusLabel.Text = "Sign Up Successful";
                }
                else
                {
                    StatusLabel.Text = "User already exists..";
                }
            }
        else
            {
            StatusLabel.Text = "Strings do not match. Please try again..";
            }
        }
        catch(Exception ex)
        {
          //  StatusLabel.Text = ex.Message;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users/View Stocks Page.aspx");
    }
    protected void GenerateButton_Click(object sender, EventArgs e)
    {
        try
        {
            string genstr = verifier.GetVerifierString(CaptchaStringTextBox.Text);
            Image1.Visible = true;
            Session["genstr"] = genstr;
            Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + genstr;
        }
        catch(Exception ex) 
        {
           // StatusLabel.Text = ex.Message;
        }
    }
}