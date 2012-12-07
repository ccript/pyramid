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
        if (LoginBLL.resetPassword(SessionClass.getUserEmail(), txtPassword.Text))
        {
            Response.Redirect("../../Default.aspx");
        }
    }
}