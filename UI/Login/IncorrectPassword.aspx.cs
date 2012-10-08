using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;

public partial class IncorrectPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Incorrect Password";

        string username = Request.QueryString.Get(0);
        lblUserName.Text = username;
        string fullUserName = ReenterBLL.getFullUserName(username);
        lblFullName.Text = fullUserName;
    }
    protected void btnTryAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReenterPassword.aspx?UserName=" + lblUserName.Text);
    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResetPassword.aspx?AccountEmail=" + lblUserName.Text);


    }
}