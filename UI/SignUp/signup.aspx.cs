using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BuinessLayer;
using ObjectLayer;
using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = "Sign Up";

        Year_month_label.Visible = false;
        Already_Email_Error.Visible = false;
        Age_Error.Visible = false;
        ePassword.Attributes.Add("value", ePassword.Text);
       
        if (MonthList.SelectedValue == "Month")
        {
            DateTime now = new DateTime(2010, 1, 18);
            for (int i = DateTime.Now.Month; i <= 13; i++)
            {                
                MonthList.Items.Add(new ListItem(now.ToString("MMM"), now.ToString("MM")));
                now = now.AddMonths(1);
            }
        }


        if (YearList.SelectedValue == "Year")
        {
            int year = DateTime.Now.Year - 70;
            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 70; i--)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        //DateList.Items.Add(new ListItem(DateTime.Now.Day.ToString(), DateTime.Now.Day.ToString()));
        //******  End of Date ***/
    }

    protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
    {
        MonthList.Visible = true;       
    }
    protected void MonthList_SelectedIndexChanged(object sender, EventArgs e)
    {
        /** Function For Select Date **/

        string month = MonthList.SelectedValue;
        string year = YearList.SelectedValue;

        DateList.Items.Clear();
        if (month != "Month" && year != "Year")
        {
            int total_days = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
            for (int i = 1; i <= total_days; i++)
            {
                DateList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            Year_month_label.Text = "Select Year And Month";
            Year_month_label.Visible = true;
        }


        DateList.Visible = true;

    }
    protected void Submit_Click(object sender, EventArgs e)
    {

          string start_date_str = MonthList.Text + "/" + DateList.Text + "/" + YearList.Text;
        //    DateTime birthDate = Convert.ToDateTime(start_date_str);

          int year = Convert.ToInt32(YearList.Text);
          int month = Convert.ToInt32(MonthList.Text);
          int day = Convert.ToInt32(DateList.Text);
          DateTime birthDate = new DateTime(year,month,day);
        int count = 0;

        //** calucating age below or above 13
        DateTime now = DateTime.Today;
        int age = now.Year - birthDate.Year;
        if (now < birthDate.AddYears(age)) age--;
       
            //For checking Already Exist Email
        string found = BuinessLayer.UserBLL.BLL_CheckUserEmail(Email.Text);
        


        if (age < 13)
        {
            Age_Error.Text = "Your Age is Below 13";
            Age_Error.Visible = true;


        }
        else if (found == "Yes")
        {
            Already_Email_Error.Text = "Email Already Exist";
            Already_Email_Error.Visible = true;
        }
        else
        {
            Session["UserEmail"] = Email.Text;
            Session["Password"]=ePassword.Text;
            Field_Panel.Visible = false;
            Security_Panel.Visible = true;
            //Response.Write("pass: " + ePassword.Text);
        }
        
    }
    protected void Security_Button_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            lblResult.Text = "Captcha sucessfull!";
            lblResult.ForeColor = System.Drawing.Color.Green;

            string Birthday_string = MonthList.SelectedValue + "/" + DateList.SelectedValue + "/" + YearList.SelectedValue;
            DateTime Birthday = Convert.ToDateTime(Birthday_string);

            UserBO objUser = new UserBO();
            //Response.Write("pass: "+ePassword.Text);
            objUser.Email = Email.Text;
            objUser.Password = ePassword.Text;
            objUser.FirstName = FirstName.Text;
            objUser.PhoneNumber = Phone_TextBox.Text;
            objUser.LastName = LastName.Text;
            objUser.Gender = GenderID.Text;
            objUser.DateOfBirth = Birthday;
            objUser.PasswordResetCode = GetRandomPasswordUsingGUID(6);
            objUser.UserStatus = false;
            string uid= BuinessLayer.UserBLL.insertUser(objUser);
            Session["SignUpUserId"] = uid;
            SendEmail(Email.Text,objUser.PasswordResetCode.ToString(),uid); /////////// sending email
            //usman
            //string oldfile = Server.MapPath("../Resources/images/"+GenderID.Text+".png");
            //string newfile = Server.MapPath("../UserProfile/profileimages/") +uid + ".jpg";
            string oldfile = Server.MapPath("../../Resources/images/" + GenderID.Text + ".png");
            string newfile = Server.MapPath(Global.PROFILE_PICTURE) + uid + ".jpg";

            if (!System.IO.File.Exists(newfile))
                System.IO.File.Copy(oldfile, newfile);

            Session["UserEmail"] = objUser.Email;
            Session["SignUpUserId"] = uid;
            Response.Redirect("ProfilePictures.aspx");

        }
        else
        {
            lblResult.Text = "Incorrect !! Enter Again";
            lblResult.ForeColor = System.Drawing.Color.Red;
        }

    }

    // for generating random numbers
    public static string GetRandomPasswordUsingGUID(int length)
    {
        // Get the GUID
        string guidResult = System.Guid.NewGuid().ToString();

        // Remove the hyphens
        guidResult = guidResult.Replace("-", string.Empty);

        // Make sure length is valid
        if (length <= 0 || length > guidResult.Length)
            throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

        // Return the first length bytes
        return guidResult.Substring(0, length);
    }

    // for generating Welcome Email
    public void SendEmail(string User_email,string confirm_code,string uid)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
        client.Host = emailHost;
        client.Port = 587;
        string myEmail = ConfigurationSettings.AppSettings["Email"];
        string Password = ConfigurationSettings.AppSettings["Password"];
        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential(myEmail, Password);
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        // for sending normal welcome email
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(myEmail);
        msg.To.Add(new MailAddress(User_email));  // user email address

        msg.Subject = "Welcome To Pyramid";
        msg.IsBodyHtml = true;
        msg.Body = "Dear User <br /> Welcome to Pyramid.";

        try
        {
            client.Send(msg);
            //lblResult.Text = "Your message has been successfully sent.";
            // txtSubject.Text = "";
            //FCKeditor1.Value = "";
            Response.Write("Ho Gya");
        }
        catch (Exception ex)
        {
            // lblResult.ForeColor = Color.Red;
            //lblResult.Text = "Error occured while sending your message." + ex.Message;
            Response.Write("NI hoa");
        }

        // for sending confirmation link
        msg = new MailMessage();
        msg.From = new MailAddress(myEmail);
        msg.To.Add(new MailAddress(User_email));  // user email address
        
        msg.Subject = "Confirm Your Account";
        msg.IsBodyHtml = true;
        string ahref = Global.Signup_Mail_Link+"confirm-account.aspx?confirm=" + confirm_code + "&uid=" + uid; // change localhost
        msg.Body = "Dear User <br /> Welcome to Pyramid. Click on Confirmation Link to confirm your account<br /> <a href='" + ahref + "'>"+ahref+"</a>";

        try
        {
            client.Send(msg);
            //lblResult.Text = "Your message has been successfully sent.";
            // txtSubject.Text = "";
            //FCKeditor1.Value = "";
            //Email_Sending_Error.Text = "Email Sending Fail";
            //Response.Write("Ho Gya");
        }
        catch (Exception ex)
        {
            // lblResult.ForeColor = Color.Red;
            //lblResult.Text = "Error occured while sending your message." + ex.Message;
            //Response.Write("NI hoa");
        }
    }

}

