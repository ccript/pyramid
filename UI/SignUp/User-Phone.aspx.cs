using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BuinessLayer;
using ObjectLayer;

public partial class SignUp_User_Email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SignUpUserId"] == null)
            Response.Redirect("../../Default.aspx");
       

        try{

            Session["SignUpUserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Enter Phone Number";

    }
    protected void SubmitPhoneNo_Click(object sender, EventArgs e)
    {
        string Email = Session["UserEmail"].ToString();
        string phone = phoneNo.Text;

        UserBO objUser = new UserBO();
        objUser.Id = Session["SignUpUserId"].ToString();
        objUser.PhoneNumber = phone;
        BuinessLayer.UserBLL.UpdatePhoneNo(objUser); //update phone no
        
        Session["UserEmail"] = null;
        

        // for sending sms request to js
        string sms = "Please Check your INBOX by Clicking on Confirmation Link. ";

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Test", "sending_sms('" + phoneNo.Text + "','" + sms + "');", true);
        
         //Response.Redirect("../../Default.aspx");
    }
}