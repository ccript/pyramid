using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Authentication;
using System.Net.Mail;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Net;
using BuinessLayer;
using ObjectLayer;
public partial class UI_User_ViewVideo : System.Web.UI.Page
{
    private string photoid;
    private string userid;
    private bool isfollow;
    static string msgtext;

    public string Photoid
    {
        get { return photoid; }
        set { photoid = value; }
    }
    
    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    
    public bool Isfollow
    {
        get { return isfollow; }
        set { isfollow = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        ((Label)Master.FindControl("lblTitle")).Text = "View Video";
        Photoid = QueryString.getQueryStringOnIndex(0);
        Userid = LoginClass.getUserId();
        LoadFollow();
        LoadDataListComments();
        YouLikes();
        string videotag="";
        MediaBO objMedia=new MediaBO();
        objMedia=MediaBLL.getMediaByMediaId(Photoid);

        videotag += "  <script  type= 'text/javascript'  >";
        videotag +=" jwplayer('container').setup({";
        videotag += " file: src='" + Global.USER_VIDEO + objMedia.Id + ".mp4' ,";
        videotag += " flashplayer: '../../Resources/jwplayer/player.swf',";
        videotag +=" width: 520";
        videotag +=" }); "; 
        videotag +="</script> ";
        this.LiteralVideo.Text = videotag ;  
        imgBtnComments.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
        Session["SpamPhoto"] = null;
        Session["AbusePhoto"] = null; 
    }

    protected void LoadDataListComments()
    {

        DataList1.DataSource = CommentsBLL.getComments(Global.VIDEO, Photoid);
        DataList1.DataBind();

    }
    protected void InsertComments()
    {
         UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = txtComments.Text;
        objClass.AtId = Photoid;
        objClass.Type = Global.VIDEO;
        objClass.UserId = Userid;
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;
        CommentsBLL.insertComments(objClass);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtComments.ClientID + "').value = '';", true);
        
        List<string> lst = new List<string>();
        lst = CommentsBLL.getCommentsUserIdbyAtId(Global.VIDEO, Photoid);
        if (Isfollow == true)
        {
            foreach (string item in lst)
            {

                UserBO objUserNotify = new UserBO();
                objUserNotify = UserBLL.getUserByUserId(item);
                msgtext = "Dear Pyramid Plus user, Comments on your video. ";
                NotificationBO objNotify = new NotificationBO();
                objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> comments on <a  href=\"ViewVideo.aspx?VideoId=" + Photoid + "\">video</a>";
                objNotify.AtId = Photoid;
                objNotify.Type = Global.VIDEO;
                objNotify.UserId = item;
                objNotify.FirstName = objUserNotify.FirstName;
                objNotify.LastName = objUserNotify.LastName;
                objNotify.FriendId = Userid;
                objNotify.FriendFName = objUser.FirstName;
                objNotify.FriendLName = objUser.LastName;
                objNotify.Status = false;
                //  ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserNotify.Email);
                NotificationBLL.insertNotification(objNotify);
            }
        }
        txtComments.Text = "";
        LoadDataListComments();

    }
    protected void YouLikes()
    {
    LikesBO objClass = new LikesBO();
    objClass.AtId = Photoid;
    objClass.Type = Global.VIDEO;
    objClass.UserId = Userid;
     bool islike= LikesBLL.youLikes(objClass);
     if (islike)
     {
         lblLike.Text = "You Like This";
         lbtnLike.Text = "UnLike";
     }

     else
     {
         lblLike.Text = "";
         lbtnLike.Text = "Like";
     }


    }
    protected void txtComments_TextChanged(object sender, EventArgs e)
    {
        InsertComments();
    }
    protected void imgBtnComments_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ViewProfile.aspx?UserId=" + Userid);
    }
    protected void lbtnLike_Click(object sender, EventArgs e)
    {
        if (lbtnLike.Text == "Like")
        {
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Userid);
            LikesBO objClass = new LikesBO();
            objClass.AtId = Photoid;
            objClass.Type = Global.VIDEO;
            objClass.UserId = Userid;
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            LikesBLL.insertLikes(objClass);
            lblLike.Text = "You Like this";
            lbtnLike.Text = "UnLike";

        }
        else
        {
            LikesBO objClass = new LikesBO();
            objClass.AtId = Photoid;
            objClass.Type = Global.VIDEO;
            objClass.UserId = Userid;
            LikesBLL.unLikes(objClass);
            lblLike.Text = "";
            lbtnLike.Text = "Like";
        }
    }
    protected void lbtnTag_Click(object sender, EventArgs e)
    {

    }

    public static void sendEmail(object o)
    {

        string email = (string)o;



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


        msg.To.Add(new MailAddress(email));

        msg.Subject = "Pyramid Plus Notification";
        msg.IsBodyHtml = true;

        msg.Body = msgtext;
        //Session["randomCode"] = randomCode;
        //generate the randomCode and place it in the c_User

        try
        {
            client.Send(msg);
            //Response.Redirect("CodesSent.aspx?UserEmail=" + lblEmail.Text);
            //lblResult.Text = "Your message has been successfully sent.";
            //txtSubject.Text = "";
            //FCKeditor1.Value = "";
        }
        catch (Exception ex)
        {
            // lblResult.ForeColor = Color.Red;
            //lblResult.Text = "Error occured while sending your message." + ex.Message + "with code " + randomCode;
        }

    }

    protected void LoadFollow()
    {
        MediaBO obj = new MediaBO();
        obj = MediaBLL.getMediaByMediaId(Photoid);
        Isfollow = obj.isFollow;
        if (Isfollow)
        {
            lbtnFollow.Text = "UnFollow";
        }

        else
        {
            lbtnFollow.Text = "Follow";
        }

    }
    protected void lbtnFollow_Click(object sender, EventArgs e)
    {
        if (lbtnFollow.Text.Equals("Follow"))
        {
            MediaBO obj = new MediaBO();
            obj.Id = Photoid;
            obj.isFollow = true;
            MediaBLL.updateFollow(obj);
        
        }
        else if (lbtnFollow.Text.Equals("UnFollow"))
        {
            MediaBO obj = new MediaBO();
            obj.Id = Photoid;
            obj.isFollow = false;
            MediaBLL.updateFollow(obj);
      
        }
        LoadFollow();
    }

    protected void txtFriendSearch_TextChanged(object sender, EventArgs e)
    {


        string fid = HiddenField1.Value;
        if (fid.Length > 20)
        {
            UserBO objFriend = new UserBO();
            objFriend = UserBLL.getUserByUserId(fid);
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Userid);


            //Response.Write(fid);

            TagsBO objTags = new TagsBO();
            objTags.AtId = Photoid;
            objTags.Type = Global.VIDEO;
            objTags.UserId = Userid;
            objTags.FirstName = objUser.FirstName;
            objTags.LastName = objUser.LastName;
            objTags.FriendId = fid;
            objTags.FriendFName = objFriend.FirstName;
            objTags.FriendLName = objFriend.LastName;

            TagsBLL.insertTags(objTags);
            LoadDataListTags();


            List<string> lst = new List<string>();
            lst = TagsBLL.getTagsFriendId(Global.VIDEO, Photoid);

            LoadDataListComments();

            foreach (string item in lst)
            {

                UserBO objUserNotify = new UserBO();
                objUserNotify = UserBLL.getUserByUserId(item);
                NotificationBO objNotify = new NotificationBO();
                objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> tags on <a  href=\"ViewVideo.aspx?VideoId=" + Photoid + "\">video</a>";
                objNotify.AtId = Photoid;
                objNotify.Type = Global.VIDEO;
                objNotify.UserId = item;
                objNotify.FirstName = objUserNotify.FirstName;
                objNotify.LastName = objUserNotify.LastName;
                objNotify.FriendId = Userid;
                objNotify.FriendFName = objUser.FirstName;
                objNotify.FriendLName = objUser.LastName;
                msgtext = "Dear Pyramid Plus user," + objUser.FirstName + " " + objUser.LastName + " tags you photo ";

               // ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserNotify.Email);
                //sendEmail(objUserNotify.Email);

                NotificationBLL.insertNotification(objNotify);
            }
        }
    }

    protected void LoadDataListTags()
    {

        DListTags.DataSource = TagsBLL.getTagsTop5(Global.VIDEO, Photoid);
        DListTags.DataBind();

    }
    protected void DListTags_SelectedIndexChanged(object sender, EventArgs e)
    {
        TagsBLL.deleteTags(DListTags.DataKeys[DListTags.SelectedIndex].ToString());
        LoadDataListTags();
    }
}