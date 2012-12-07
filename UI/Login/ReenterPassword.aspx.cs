using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using System.Data;
public partial class RenterPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Please Re-enter your Password";

        lblUserName.Text = Request.QueryString.Get(0);
        lblFullName.Text = ReenterBLL.getFullUserName(Request.QueryString.Get(0)); ;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["LoginAttempt"] = Convert.ToInt32(Session["LoginAttempt"]) + 1;
        if (LoginBLL.IsValidLogin(lblUserName.Text, txtPassword.Text))
        {
            Session["UserId"] = UserBLL.BLL_UserId(lblUserName.Text); // user email            
            Response.Redirect("../User/UserData.aspx");//the page to be opened on successful login
        }

        else //password not valid but username valid
        {
            if (Convert.ToInt32(Session["LoginAttempt"]) > 2)
            {
                Response.Redirect("IncorrectPassword.aspx?UserName=" + lblUserName.Text);
            }
            else
            {
                Response.Redirect("ReenterPassword.aspx?UserName=" + lblUserName.Text);
            }
        }

    }

}