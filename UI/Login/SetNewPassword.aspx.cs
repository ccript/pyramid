using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;

public partial class SetNewPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Set New Password";
    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        //code that saves the value of the new password for the user whose session is active
        string username=Session["UserEmail"].ToString();
        bool isReset = LoginBLL.resetPassword(username, txtPassword.Text);
        if (isReset)
        {
            Response.Redirect("../../Default.aspx");
        }
    }
}