using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectLayer;
using BuinessLayer;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Session.Clear();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
       // Session["UserId"] = "4f37fdd8745cb305e42cd7a0";
       bool isValidUserName = LoginBLL.IsValidUserName(txtUserName.Text);

        if (isValidUserName)
        {
            bool isValidPassword = LoginBLL.IsValidPassword(txtPassword.Text);

            if (isValidPassword)
            {
                bool isValid = LoginBLL.IsValidLogin(txtUserName.Text, txtPassword.Text);
                if (isValid)
                {
                    


                        Session["UserEmail"] = txtUserName.Text;

                        string Email = Session["UserEmail"].ToString();

                        Session["UserId"] = UserBLL.BLL_UserId(Email);

                    

                        Response.Redirect("UI/User/UserData.aspx");//the page to be opened on successful login
                    
                }
            }
            else //password not valid but username valid
            {
                //Login1.PasswordRequiredErrorMessage = "oye pass";
                // ValidationSummary1.HeaderText = "oye pass";
                Session["LoginAttempt"] = "1";
                Response.Redirect("UI/Login/ReenterPassword.aspx?UserName=" + txtUserName.Text);

            }
        }

        
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

        bool isValidUserName = LoginBLL.IsValidUserName(txtUserName.Text);

        if (!isValidUserName)
        {
            string suggestion = LoginBLL.spellingSuggestion(txtUserName.Text);
            if (suggestion == "")
            {

                args.IsValid = false;
            }
            else
            {
                Response.Redirect("UI/Login/MisspellingCorrection.aspx?Email=" + suggestion);

            }
        }


    }
}