using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using BuinessLayer;
using ObjectLayer;

using System.IO;
using System.Net;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.QueryString.HasKeys())
            Response.Redirect("../../Default.aspx");

        Label lblTitle = (Label)Page.Master.FindControl("lblTitle");
        lblTitle.Text = Global.RESET_YOUR_PASSWORD;

        if (Request.QueryString.Get(0).Contains("@"))//if email provided
        {
            lblEmail.Text = Request.QueryString.Get(0);
            LoginBO user = new LoginBO();
            user = LoginBLL.getUserbyEmail(Request.QueryString.Get(0));
            if (user != null)
            {
                lblUserName.Text = user.FirstName + user.LastName;
                lblPhone.Visible = true;
                lblPhoneValue.Visible = true;
                lblPhoneValue.Text = user.PhoneNumber;
            }
            else
            {                
                Response.Redirect("Recover.aspx?AccountNotfound=" + "true1");
            }
        }
        else//phone provided
        {
            lblPhone.Visible = true;
            lblPhoneValue.Visible = true;
            lblPhoneValue.Text = Request.QueryString.Get(0);
            LoginBO user = new LoginBO();
            user = LoginBLL.getUserbyPhone(lblPhoneValue.Text);
            if (user != null)
            {
                lblEmail.Text = user.Email;
                lblUserName.Text = user.FirstName + " " + user.LastName;
            }
            else
            {             
                Response.Redirect("Recover.aspx?AccountNotfound=" + "true1");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {        
        Response.Redirect("Recover.aspx?Show=normal");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //logic to send email or sms to provided email or phone
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
        msg.To.Add(new MailAddress(lblEmail.Text));

        msg.Subject = "Pyramid Plus Password Reset Code";
        msg.IsBodyHtml = true;
        string randomCode = LoginBLL.genCode(lblEmail.Text);
        msg.Body = "Dear Pyramid Plus user, use the code provided to reset your password. Code is: " + randomCode;
        //Session["randomCode"] = randomCode;
        //generate the randomCode and place it in the c_User

        try
        {
            client.Send(msg);
            Response.Redirect("CodesSent.aspx?UserEmail=" + lblEmail.Text);
            //lblResult.Text = "Your message has been successfully sent.";
            //txtSubject.Text = "";
            //FCKeditor1.Value = "";
        }
        catch (Exception ex)
        {
            // lblResult.ForeColor = Color.Red;
            lblResult.Text = "Error occured while sending your message." + ex.Message + "with code " + randomCode;
        }

        sendsms(randomCode);
    }
    protected void sendsms(string randomCode)
    {

        string sms = "Please Check your INBOX by Clicking on Confirmation Link. ";

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Test", "sending_sms(' 03149558625 ','Hello ');", true);

        //string senderusername = "xxxxx";
        //string senderpassword = "xxxx";
        //string senderid = "xxx";        
        /* string sURL;
         StreamReader objReader;
         sURL = "http://smsurdu.net/dssd/send-sms.php?sms=" + "Dear Pyramid Plus user. Your Password Reset Code is: " + randomCode + "&phone=" + 03004650094;
         WebRequest wrGETURL;
         wrGETURL = WebRequest.Create(sURL);
         try
         {
             Stream objStream;
             objStream = wrGETURL.GetResponse().GetResponseStream();
             objReader = new StreamReader(objStream);
             objReader.Close();
         }
         catch (Exception ex)
         {
             ex.ToString();
         }

         Response.ContentType = "text/xml; charset=utf-8";
         String url = "http://smsurdu.net/dssd/send-sms.php?sms=" + "Dear User" + "&phone=" + 03004650094;
         HttpWebRequest request =(System.Net.HttpWebRequest)WebRequest.Create(url);
         request.Method = "POST";
         String postData;// = "FromNumber=" + FromNumber;
         //postData += "&"
         postData = "sms=" +"Dear User";
         //postData += "&"
         postData += "& phone="+ 03004650094;
        
         UriBuilder urlBuilder = new UriBuilder();
         urlBuilder.Host = "http://smsurdu.net/dssd/send-sms.php";
         //urlBuilder.Port = 8800;

         string PhoneNumber = "03004650094";
         string message = "Just a simple text";

         urlBuilder.Query = string.Format("sms=" + message + "&phone=" + PhoneNumber);
          //String url = "http://smsurdu.net/dssd/send-sms.php?sms=" + "Dear User" + "&phone=" + "03004650094";

         HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(urlBuilder.ToString(),false));
         httpReq.Method = "POST";
         HttpWebResponse httpResponse = (HttpWebResponse)(httpReq.GetResponse()); 
         /*
         //byte[] buffer = Encoding.UTF8.GetBytes(str);
         //UTF8Encoding utf8 = new UTF8Encoding();
         byte[] buffer = Encoding.UTF8.GetBytes(postData);
         //Byte byteArray = UTF8Encoding.GetBytes(postData);
         request.ContentType = "application/x-www-form-urlencoded";
         //request.Headers.Add("APIToken", "API Token")   ' Signup for a free trial to get one
         request.ContentLength = buffer.Length;
         Stream dataStream= request.GetRequestStream();
         dataStream.Write(buffer, 0, buffer.Length);
         dataStream.Close();
         WebResponse _webresponse = request.GetResponse();
         dataStream = _webresponse.GetResponseStream();
         StreamReader reader= new StreamReader(dataStream);
          String responseFromServer= reader.ReadToEnd();
         Response.Write(responseFromServer);
         reader.Close();
         dataStream.Close();*/
    }

}