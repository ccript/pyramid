using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using System.Data;
public partial class MisspellingCorrection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Request.QueryString.HasKeys())
            Response.Redirect("../../Default.aspx");
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Misspelling Fixed";

        string username = Request.QueryString.Get(0);
        lblUserName.Text = username;
        string fullUserName = ReenterBLL.getFullUserName(username);
        lblFullName.Text = fullUserName;

    }
    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        int loginAttempt = Convert.ToInt32(Session["LoginAttempt"]);


        loginAttempt += 1;

        Session["LoginAttempt"] = loginAttempt;

        bool isValid = LoginBLL.IsValidLogin(lblUserName.Text, txtPassword.Text);
        if (isValid)
        {


            string Email = lblUserName.Text;
            Session["UserId"] = UserBLL.BLL_UserId(Email); // user email
            /*
            DataSet ds = BuinessLayer.UserBLL.BLL_UserId(Email); // user email
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                Session["UserId"] = myRow["UserId"];
                break;
            }*/
            Response.Redirect("../User/UserData.aspx");//the page to be opened on successful login
        }

        else //password not valid but username valid
        {
            //Login1.PasswordRequiredErrorMessage = "oye pass";
            // ValidationSummary1.HeaderText = "oye pass";
            if (Convert.ToInt32(Session["LoginAttempt"]) > 2)
            {
                Response.Redirect("IncorrectPassword.aspx?UserName=" + lblUserName.Text);
            }
            else
                Response.Redirect("ReenterPassword.aspx?UserName=" + lblUserName.Text);

        }

    }
}