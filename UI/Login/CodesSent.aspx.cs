using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;

public partial class CodesSent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.QueryString.HasKeys())
            Response.Redirect("../../Default.aspx");
        
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Password reset codes sent";

        string email = Request.QueryString.Get(0);//ReenterBLL.getFullUserName(username);
        lblEmail.Text = email;
        string fullUserName = ReenterBLL.getFullUserName(email);
        lblUserName.Text = fullUserName;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //on submit code check if code valid and then take user to home page
        bool isCodeValid=false;
        //string randomCode=LoginBLL.
        isCodeValid = LoginBLL.validateCode(lblEmail.Text,txtResetCode.Text);
        if (isCodeValid)
        {
            isCodeValid = true;
            Session["UserEmail"] = lblEmail.Text;
        }
        if (isCodeValid)
        {
            //
            Response.Redirect("SetNewPassword.aspx");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Default.aspx");
    }
}