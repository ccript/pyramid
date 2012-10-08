using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
public partial class CantIdentifyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Can't Idfentify Account";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ResetPassword.aspx?AccountEmail=" + txtAccountEmail.Text +"&AccountUserName="+txtAccountUserName.Text);
        
        LoginBLL.saveIdentifyAccountInfo(txtActiveEmail.Text,txtAccountEmail.Text,txtAccountUserName.Text,txtMobileNumber.Text,txtAccountLinkedEmailAddress.Text);
        Response.Redirect("../../Default.aspx");
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../../Default.aspx");
    }
}