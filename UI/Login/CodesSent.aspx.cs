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

        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = Global.PASSWORD_RESET_CODES_SENT;

        lblEmail.Text = Request.QueryString.Get(0);        
        lblUserName.Text = ReenterBLL.getFullUserName(Request.QueryString.Get(0));

    }

    protected void Button1_Click(object sender, EventArgs e)
    {        
        if (LoginBLL.validateCode(lblEmail.Text, txtResetCode.Text))
        {            
            Session["UserEmail"] = lblEmail.Text;
            Response.Redirect("SetNewPassword.aspx");
        }        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Default.aspx");
    }
}