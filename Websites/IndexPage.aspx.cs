using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void NormalUsersButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users/View Stocks Page.aspx");
    }
    protected void StaffButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin1/UsersInfo.aspx");
    }
}