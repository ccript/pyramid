using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;

public partial class Recover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = Global.IDENTIFY_YPUR_ACCOUNT;

        string accountNotFound = Request.QueryString.Get(0);
        if (accountNotFound == "true1")
        {
            lblAccountNotFound.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResetPassword.aspx?AccountPhone=" + txtEmailPhone.Text + "&AccountEmail=" + txtEmailPhone.Text);
    }
}