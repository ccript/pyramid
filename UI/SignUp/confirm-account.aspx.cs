using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BuinessLayer;
using ObjectLayer;


public partial class confirm_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = Global.ACCOUNT_ACTIVATION;

        string comfirm_code = Request.QueryString["confirm"];
        string userId = Request.QueryString["uid"];

        UserBO objUser = new UserBO();
        objUser.PasswordResetCode = comfirm_code;
        objUser.Id = userId;

        if (BuinessLayer.UserBLL.BLL_ConfirmUser(objUser) == "No")
        {
            Activation_Message.Text = "Not able to Activate Account";    
        }
        else if (BuinessLayer.UserBLL.BLL_ConfirmUser(objUser) == "Yes")
        {         
            Login_Click.NavigateUrl = "../../Default.aspx";
            Login_Click.Visible = true;
            Activation_Message.Text = "Your Account Activated Successfully";            
        }
    }
}