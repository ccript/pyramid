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
public partial class UI_User_ViewPhotoAlbumGallery1 : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    private string albumid;

    public string Albumid
    {
        get { return albumid; }
        set { albumid = value; }
    }
    private bool isfollow;

    public bool Isfollow
    {
        get { return isfollow; }
        set { isfollow = value; }
    }
    static string msgtext;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Photos Album";

        Albumid = QueryString.getQueryStringOnIndex(0);
        Userid = LoginClass.getUserId();
        imgBtnComments.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
        LoadDataListMedia();
        LoadDataListComments();
        YouLikes();
        LoadDataAlbum();
       Session["HighResoultion"] = null;
    }
    protected void LoadDataAlbum()
    {

        MediaAlbumBO obj = new MediaAlbumBO();

        obj=MediaAlbumBLL.getMediaAlbumByMediaAlbumId(Albumid);
        lblDescription.Text = obj.Description;
        lblTitle.Text = obj.Name;

        if (obj.Name.Equals("My Pictures")||obj.Name.Equals("Profile Pictures"))
            lnkDelete.Visible = false;

         Isfollow = obj.isFollow;
        if (Isfollow)
        {
            lbtnFollow.Text = "UnFollow Post";
        }

        else
        {
            lbtnFollow.Text = "Follow Post";
        }

     
    }
    protected void LoadDataListMedia()
    {

        DataList1.DataSource = MediaBLL.getMediaByAlbum(Albumid);
        DataList1.DataBind();

    }

    protected void LoadDataListComments()
    {

        DataListComments.DataSource = CommentsBLL.getComments(Global.PHOTO_ALBUM, Albumid);
        DataListComments.DataBind();

    }
    protected void InsertComments()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = txtComments.Text;
        objClass.AtId = Albumid;
        objClass.Type = Global.PHOTO_ALBUM;
        objClass.UserId = Userid;
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;
        CommentsBLL.insertComments(objClass);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtComments.ClientID + "').value = '';", true);
        
        txtComments.Text = "";
        List<string> lst = new List<string>();
        lst = CommentsBLL.getCommentsUserIdbyAtId(Global.PHOTO, Albumid);
        if (Isfollow == true)
        {
            foreach (string item in lst)
            {

                UserBO objUserNotify = new UserBO();
                objUserNotify = UserBLL.getUserByUserId(item);
                msgtext = "Dear Pyramid Plus user, Comments on your album. ";
                NotificationBO objNotify = new NotificationBO();
                objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> comments on <a  href=\"ViewPhotoAlbum.aspx?AlbumId=" + Albumid + "\">photo album</a>";
                objNotify.AtId = Albumid;
                objNotify.Type = Global.PHOTO_ALBUM;
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
        LoadDataListComments();

    }
    protected void YouLikes()
    {
        LikesBO objClass = new LikesBO();
        objClass.AtId = Albumid;
        objClass.Type = Global.PHOTO_ALBUM;
        objClass.UserId = Userid;
        bool islike = LikesBLL.youLikes(objClass);
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
            objClass.AtId = Albumid;
            objClass.Type = Global.PHOTO_ALBUM;
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
            objClass.AtId = Albumid;
            objClass.Type = Global.PHOTO_ALBUM;
            objClass.UserId = Userid;
            LikesBLL.unLikes(objClass);
            lblLike.Text = "";
            lbtnLike.Text = "Like";
        }
    }
    protected void lbtnTag_Click(object sender, EventArgs e)
    {
       
    }
    protected void lbtnFollow_Click(object sender, EventArgs e)
    {
        if (lbtnFollow.Text == "Follow Post")
        {
            MediaAlbumBO obj=new MediaAlbumBO();
            obj.isFollow=true;
            obj.Id = Albumid;
            MediaAlbumBLL.EditFollowAlbum(obj);
            lbtnFollow.Text = "UnFollow Post";
        }
        else
        {
            MediaAlbumBO obj = new MediaAlbumBO();
            obj.isFollow = false;
            obj.Id = Albumid;
            MediaAlbumBLL.EditFollowAlbum(obj);
            lbtnFollow.Text = "Follow Post";
        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        MediaAlbumBLL.deleteMediaAlbum(Albumid);
        Response.Redirect("Photos.aspx"); 
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
            objTags.AtId = Albumid;
            objTags.Type = Global.PHOTO_ALBUM;
            objTags.UserId = Userid;
            objTags.FirstName = objUser.FirstName;
            objTags.LastName = objUser.LastName;
            objTags.FriendId = fid;
            objTags.FriendFName = objFriend.FirstName;
            objTags.FriendLName = objFriend.LastName;

            TagsBLL.insertTags(objTags);
            LoadDataListTags();


            List<string> lst = new List<string>();
            lst = TagsBLL.getTagsFriendId(Global.PHOTO_ALBUM, Albumid);

            LoadDataListComments();

            foreach (string item in lst)
            {

                UserBO objUserNotify = new UserBO();
                objUserNotify = UserBLL.getUserByUserId(item);
                NotificationBO objNotify = new NotificationBO();
                objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> tags on  <a  href=\"ViewPhotoAlbum.aspx?AlbumId=" + Albumid + "\">photo album</a>";
                objNotify.AtId = Albumid;
                objNotify.Type = Global.VIDEO;
                objNotify.UserId = item;
                objNotify.FirstName = objUserNotify.FirstName;
                objNotify.LastName = objUserNotify.LastName;
                objNotify.FriendId = Userid;
                objNotify.FriendFName = objUser.FirstName;
                objNotify.FriendLName = objUser.LastName;
                msgtext = "Dear Pyramid Plus user," + objUser.FirstName + " " + objUser.LastName + " tags you video ";

               // ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserNotify.Email);
                //sendEmail(objUserNotify.Email);

                NotificationBLL.insertNotification(objNotify);
            }
        }
    }

    protected void LoadDataListTags()
    {

        DListTags.DataSource = TagsBLL.getTagsTop5(Global.PHOTO_ALBUM, Albumid);
        DListTags.DataBind();

    }
    protected void DListTags_SelectedIndexChanged(object sender, EventArgs e)
    {
        TagsBLL.deleteTags(DListTags.DataKeys[DListTags.SelectedIndex].ToString());
        LoadDataListTags();
    }
    protected void lbtnViewSlideShow_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPhotoAlbumGallery1.aspx?AlbumId=" + Albumid);
    }
}