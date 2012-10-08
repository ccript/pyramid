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
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Account Activation";

        string comfirm_code = Request.QueryString["confirm"];
        string id = Request.QueryString["uid"];

        UserBO objUser = new UserBO();
        objUser.PasswordResetCode = comfirm_code;
        objUser.Id = id;

        
        string check = BuinessLayer.UserBLL.BLL_ConfirmUser(objUser);


        if (check == "No")
        {
            Activation_Message.Text = "Not able to Activate Account";    
        }

        else if (check == "Yes")
        {
         
            Login_Click.NavigateUrl = "../../Default.aspx";
            Login_Click.Visible = true;
            Activation_Message.Text = "Your Account Activated Successfully";
            
        } 
    }
}