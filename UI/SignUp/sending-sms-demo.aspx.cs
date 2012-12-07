using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sending_sms_demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = Global.TERMS_AND_CONDITIONS;
    }
}