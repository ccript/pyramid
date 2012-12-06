using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Authentication;
using System.Net.Mail;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Net;
using BuinessLayer;
using ObjectLayer;

public partial class UI_User_ViewPhotos : System.Web.UI.Page
{
    private string photoid;

    public string Photoid
    {
        get { return photoid; }
        set { photoid = value; }
    }
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    static string msgtext;
    private bool isfollow;

    public bool Isfollow
    {
        get { return isfollow; }
        set { isfollow = value; }
    }
    static string albumid;
    protected void Page_Load(object sender, EventArgs e)
    {

        ((Label)Master.FindControl("lblTitle")).Text = "View Photos";
        Photoid = QueryString.getQueryStringOnIndex(0);
        Userid = LoginClass.getUserId();

        LoadFollow();
        LoadDataListComments();
        YouLikes();
        LoadDataListTags();
           
        imgBtnComments.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
        imgPhoto.ImageUrl = Global.USER_PHOTOS + Photoid + ".jpg";
        System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(Server.MapPath(Global.USER_PHOTOS + Photoid + ".jpg"));

        if (sourceImage.Width > 500)
        {
            imgPhoto.Width = sourceImage.Width / 2;
            imgPhoto.Height = sourceImage.Height / 2;

        }

        Session["SpamPhoto"] = imgPhoto.ImageUrl;
        Session["CropPhoto"] = imgPhoto.ImageUrl.Split('/')[3].ToString();
        Session["AbusePhoto"] = imgPhoto.ImageUrl;

        GetPhotoDesc();
     }

    public void GetPhotoDesc()
    {
        MediaBO mediaobj = new MediaBO();
        mediaobj = MediaBLL.getMediaByMediaId(Photoid);
        LabelGetCaption.Text = mediaobj.Caption;
        LabelGetDesc.Text = mediaobj.Description;
        LabelGetLocation.Text = mediaobj.Location;
        imgBack.PostBackUrl="ViewPhotoAlbum.aspx?" + mediaobj.AlbumId;
    }
  
    protected void LoadDataListComments()
    {

        DataList1.DataSource = CommentsBLL.getComments(Global.PHOTO, Photoid);
        DataList1.DataBind();

    }
    protected void InsertComments()
    {
         UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = txtComments.Text;
        objClass.AtId = Photoid;
        objClass.Type = Global.PHOTO;
        objClass.UserId = Userid;
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;
        
        CommentsBLL.insertComments(objClass);

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtComments.ClientID + "').value = '';", true);
        List<string> lst = new List<string>();
        lst = CommentsBLL.getCommentsUserIdbyAtId( Global.PHOTO,Photoid);
      
        LoadDataListComments();
        if (Isfollow == true)
        {
            foreach (string item in lst)
            {

                UserBO objUserNotify = new UserBO();
                objUserNotify = UserBLL.getUserByUserId(item);
                msgtext = "Dear Pyramid Plus user, Comments on your photos. ";
                NotificationBO objNotify = new NotificationBO();
                objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> comments on <a  href=\"ViewPhoto.aspx?PhotoId=" + Photoid + "\">photo</a>";
               
                
                
                objNotify.AtId = Photoid;
                objNotify.Type = Global.PHOTO;
                objNotify.UserId = item;
                objNotify.FirstName = objUserNotify.FirstName;
                objNotify.LastName = objUserNotify.LastName;
                objNotify.FriendId = Userid;
                objNotify.FriendFName = objUser.FirstName;
                objNotify.FriendLName = objUser.LastName;
                objNotify.Status= false;
               // ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserNotify.Email);
                //sendEmail(objUserNotify.Email);
                NotificationBLL.insertNotification(objNotify);
            }
        }

    }
    protected void YouLikes()
    {
    LikesBO objClass = new LikesBO();
    objClass.AtId = Photoid;
    objClass.Type = Global.PHOTO;
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
        if (lbtnFollow.Text.Equals("UnFollow"))
        {
            MediaBO obj = new MediaBO();
            obj.Id = Photoid;
            obj.isFollow = false;
            MediaBLL.updateFollow(obj);
           
        }
        else if (lbtnFollow.Text.Equals("Follow"))
        {
            MediaBO obj = new MediaBO();
            obj.Id = Photoid;
            obj.isFollow =true ;
            MediaBLL.updateFollow(obj);
           
        }

        LoadFollow();
    }

    protected void txtComments_TextChanged(object sender, EventArgs e)
    {
        InsertComments();
        txtComments.Text = "";
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
            objClass.Type = Global.PHOTO;
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
            objClass.Type = Global.PHOTO;
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

        msg.Body = msgtext;// "Dear Pyramid Plus user, Comments on your photos. ";
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(imgPhoto.ImageUrl);
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipXY);
       
        img.Save(path);
        img.Dispose();
        imgPhoto.Attributes.Add("ImageUrl", path);
       
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(imgPhoto.ImageUrl);
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipXY);
        
        img.Save(path);
        img.Dispose();
        imgPhoto.Attributes.Add("ImageUrl", path);
       
    }
  
    private void DownloadFile(string fname, bool forceDownload)
    {
        string path = MapPath(fname);
        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;
            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    protected void DownloadLinkButton_Click(object sender, EventArgs e)
    {
        DownloadFile(imgPhoto.ImageUrl, true);
    }

    protected void DeleteLinkButton_Click(object sender, EventArgs e)
    {
        MediaBLL.deleteMedia(Photoid);
        Response.Redirect("Photos.aspx");
    }

    protected void SetProfileLinkButton_Click(object sender, EventArgs e)
    {

       string fid= SavePhotos();
       string newf= Server.MapPath(Global.USER_PHOTOS + fid + ".jpg");
       string thum = Server.MapPath(Global.THUMBNAIL_PHOTOS + Photoid + ".jpg");
       string thumnew = Server.MapPath(Global.THUMBNAIL_PHOTOS + fid + ".jpg");
        string path = Server.MapPath(imgPhoto.ImageUrl);
        if (File.Exists(path))
        {
            string pro = Server.MapPath(Global.PROFILE_PICTURE + Userid + ".jpg");
            if (File.Exists(pro))
            {
                File.Delete(pro);
            }
            File.Copy(path, pro);
            File.Copy(path, newf);
            File.Copy(thum, thumnew);
        }
        Response.Redirect("Photos.aspx");
    }

    public string SavePhotos()
    {
        string albumId;
      
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = Userid;
            objAClass.Name = "Profile Pictures";
            objAClass.Type = Global.PHOTO;
            objAClass.isFollow = true;
            albumId = MediaAlbumBLL.insertDefaultAlbum(objAClass);
           

       
        MediaBO objClass = new MediaBO();

        objClass.UserId = Userid;


        objClass.AlbumId = albumId;
        objClass.Caption = "";
        objClass.Name = "";
        objClass.Description = "";
        objClass.AddedDate = DateTime.Now;
        objClass.Location = "";
        objClass.Type = Global.PHOTO;
        objClass.isFollow = true;
        return MediaBLL.insertMedia(objClass);

    }

  
    protected void txtFriendSearch_TextChanged(object sender, EventArgs e)
    {
       
        
        string fid = HiddenField1.Value;
        if (fid.Length>20)
        {
            UserBO objFriend = new UserBO();
            objFriend = UserBLL.getUserByUserId(fid);
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Userid);


            //Response.Write(fid);

            TagsBO objTags = new TagsBO();
            objTags.AtId = Photoid;
            objTags.Type = Global.PHOTO;
            objTags.UserId = Userid;
            objTags.FirstName = objUser.FirstName;
            objTags.LastName = objUser.LastName;
            objTags.FriendId = fid;
            objTags.FriendFName = objFriend.FirstName;
            objTags.FriendLName = objFriend.LastName;

            TagsBLL.insertTags(objTags);
            LoadDataListTags();


            List<string> lst = new List<string>();
            lst = TagsBLL.getTagsFriendId(Global.PHOTO, Photoid);

            LoadDataListComments();
            if (Isfollow == true)
            {
                foreach (string item in lst)
                {

                    UserBO objUserNotify = new UserBO();
                    objUserNotify = UserBLL.getUserByUserId(item);
                    NotificationBO objNotify = new NotificationBO();
                    objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> tags on <a  href=\"ViewPhoto.aspx?PhotoId=" + Photoid + "\">photo</a>";
                    objNotify.AtId = Photoid;
                    objNotify.Type = Global.PHOTO;
                    objNotify.UserId = item;
                    objNotify.FirstName = objUserNotify.FirstName;
                    objNotify.LastName = objUserNotify.LastName;
                    objNotify.FriendId = Userid;
                    objNotify.FriendFName = objUser.FirstName;
                    objNotify.FriendLName = objUser.LastName;
                    msgtext = "Dear Pyramid Plus user," + objUser.FirstName + " " + objUser.LastName + " tags you photo ";

                   // ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserNotify.Email);
                   

                    NotificationBLL.insertNotification(objNotify);
                }
            }
        }
    }

    protected void LoadDataListTags()
    {

        DListTags.DataSource = TagsBLL.getTagsTop5(Global.PHOTO, Photoid);
        DListTags.DataBind();

    }
    protected void DListTags_SelectedIndexChanged(object sender, EventArgs e)
    {
        TagsBLL.deleteTags(DListTags.DataKeys[DListTags.SelectedIndex].ToString());
        LoadDataListTags();
    }
    protected void SetCoverPictureButton_Click(object sender, EventArgs e)
    {   string albumid="";
        try
        {

        
                albumid=Session["PhotoAlbumId"].ToString() ;
    
        MediaAlbumBO obj = new MediaAlbumBO();
        obj.Id = albumid;
        obj.CoverPictureId = Photoid;

        MediaAlbumBLL.UpdateCoverPicture(obj);
        }

        catch (Exception ex) { Response.Redirect("Photos.aspx"); }
    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
   {
        
      string path = Server.MapPath(imgPhoto.ImageUrl);
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipXY);
       
        img.Save(path);
        img.Dispose();
        imgPhoto.Attributes.Add("ImageUrl", path);
    }
    protected void Button2_Click(object sender, ImageClickEventArgs e)
    {
          string path = Server.MapPath(imgPhoto.ImageUrl);
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipXY);
        
        img.Save(path);
        img.Dispose();
        imgPhoto.Attributes.Add("ImageUrl", path);
    }

       
   
}