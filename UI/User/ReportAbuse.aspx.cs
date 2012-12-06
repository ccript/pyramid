using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;

public partial class UI_User_ReportAbuse : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Report Abuse";

        Userid = SessionClass.getUserId();
        AboutDropDownList.Items.Add("I don't like this");
        AboutDropDownList.Items.Add("It's harassing me");
        AboutDropDownList.Items.Add("It's harassing a friend");
        if (Session["SpamPhoto"] != null)
            Photo.ImageUrl = Session["SpamPhoto"].ToString();
        else
            Photo.ImageUrl = "../../Resources/Images/Icon/DefaultVideo.png";
        SomethingElseDropDownList.Items.Add("Spam or scam");
        SomethingElseDropDownList.Items.Add("Nudity or pornography");
        SomethingElseDropDownList.Items.Add("Graphic violence");
        SomethingElseDropDownList.Items.Add("Hate speech or symbol");
        SomethingElseDropDownList.Items.Add("Illegal drug use");
    }

    protected void ReportButton_Click(object sender, EventArgs e)
    {
        string isItYou = AboutDropDownList.SelectedValue;
        string reason = SomethingElseDropDownList.SelectedValue;

        string emailHost = ConfigurationSettings.AppSettings["EmailHost"];
        SmtpClient client = new SmtpClient(emailHost);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;

        client.Host = emailHost;
        client.Port = 587;
        string myEmail = ConfigurationSettings.AppSettings["Email"];
        string Password = ConfigurationSettings.AppSettings["Password"];
        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential(myEmail, Password);
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(myEmail);
        //Get email address of person whose request was accepted

        //Mail must be sent to administrator
        msg.To.Add(new MailAddress("hafizfahadhassan@gmail.com"));

        msg.Subject = "Pyramid Plus | Spam Report Alert";
        msg.IsBodyHtml = true;

        msg.Body = "Dear Pyramid Plus Admin, <br/> One of our user" + Userid + " has reported this photo as abusive. <br/>  Photo Location: " + Session["SpamPhoto"].ToString() + " <br/> Is it him? <br/>" + isItYou + "<br/> Reason: "+ reason +" <br/> Thank you.";


        try
        {
            client.Send(msg);
            ReportConfirmLabel.Text = "You have successfully reported this as spam. We will seriously consider this. Thank you.";

        }
        catch (Exception ex)
        {

            ReportConfirmLabel.Text = "There is some problem in sending this email. Please try later. Thank you.";
        }
    }
}
