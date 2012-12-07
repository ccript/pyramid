using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BuinessLayer;
using ObjectLayer;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
using DataLayer;

public partial class Wall : System.Web.UI.Page
{
    string userid;
    string post = null;
    string location;
    string friendswith;
    int totaltop;
    string atid;
    public static bool isunfollow=false;
    public static List<string> lstTag = new List<string>();
    List<string> emailList = new List<string>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["TempUserId"] == null)
            {

                userid = Session["UserId"].ToString();
                Session["TempUserId"] = null;

            }
            else
            {
                userid = Session["TempUserId"].ToString();
            }

            atid=Session["EmailPostID"].ToString();
        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        

        if (Request.QueryString.Count != 0)
        {
            post = Request.QueryString.Get(0);
        }

        // Getting the user information
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        // Creating Share object
        ShareBO objClass = new ShareBO();
        objClass.AtId = post;
        objClass.Type = Global.WALL;
        objClass.UserId = Session["UserId"].ToString();
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;

        // Getting the post which is going to be shared
        WallBO wall = WallBLL.getWallByWallId(objClass.AtId);
        string p = txtUpdatePost.Text + " <br/>" + wall.Post;

        PostPreviewLinkButton.Text = p;
        int type = Convert.ToInt32(Session["PostType"]);
        if (type==Global.PHOTO || type==Global.TAG_PHOTO)
            ImagePreview.ImageUrl = "../../Resources/UserPhotos/"+Session["EmbedPost"].ToString()+".jpg";
        if(type==Global.POST_VIDEOLINK)
        ImagePreview.ImageUrl= Session["EmbedPost"].ToString();
     
        ((Label)Master.FindControl("lblTitle")).Text = "Share Post";
     
    }

    protected void LoadUserData()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        lblName.Text = objUser.FirstName+" "+objUser.LastName;

    }

    protected void btnSuggestFriends_Click(object sender, EventArgs e)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        lblName.Text = objUser.FirstName + " " + objUser.LastName;
        Response.Redirect("SuggestFriends.aspx?FriendFName=" + objUser.FirstName + "&FriendLName=" + objUser.LastName);
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {

        if (post != null)
        {

            // Getting the user information
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

            // Creating Share object
            ShareBO objClass = new ShareBO();
            objClass.AtId = post;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString();
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;

            // Getting the post which is going to be shared
            WallBO wall = WallBLL.getWallByWallId(objClass.AtId);
            string p = txtUpdatePost.Text + " <br/>" + wall.Post;

            // Sharing the post on the wall
            ShareStatus(p);                
        foreach (string item in lstTag)
        {

           
            WallBO objWall2 = new WallBO();
            string tagpost = p + "<br/><br/> Tag by <a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
            UserBO objUser2 = new UserBO();
            objUser2 = UserBLL.getUserByUserId(item);
            objWall2.PostedByUserId = item;
            objWall2.WallOwnerUserId = item;
            objWall2.FirstName = objUser2.FirstName;
            objWall2.LastName = objUser2.LastName;
            objWall2.Post = tagpost;
            objWall2.AddedDate = DateTime.Now;
            objWall2.Type = Convert.ToInt32(Session["PostType"]);
            objWall2.EmbedPost = Session["EmbedPost"].ToString();
            RWallPost(" tag post to <a  href=\"ViewProfile.aspx?UserId=" + item + "\">" + objUser2.FirstName + " " + objUser2.LastName + "</a>");
           
            WallBLL.insertWall(objWall2);
        }           
        // Registering the Share after successful completion of the above process
            ShareBLL.insertShare(objClass);
           
            RWallPost(" Share a Post");
            // Sending Notifications to the one with which post has been shared and the one who were tagged
            Response.Redirect("UserData.aspx");                
        }
    }

    protected void UpdateStatus()
    {
        
    }

    protected void LoadWall(int top)
    {
     
    }

    protected void txtComments_TextChanged(object sender, EventArgs e)
    {
       
        GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
       
        TextBox txtcomments = (TextBox)row.FindControl("txtComments");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = txtcomments.Text;
        objClass.AtId = hfId.Value;
        objClass.Type = Global.WALL;
        objClass.UserId = Session["UserId"].ToString();
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;

        if (!objClass.MyComments.Equals(""))
        {
           CommentsDAL.insertComments(objClass);
        }

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtcomments.ClientID + "').value = '';", true);

        GridView gridviewComments = (GridView)row.FindControl("GridViewComments");

        gridviewComments.DataSource = CommentsDAL.getCommentsTop(Global.WALL, hfId.Value, 2);
        gridviewComments.DataBind();

        LoadWall(50);
       
    }

    protected void GridViewWall_RowCommand(object sender, GridViewCommandEventArgs e)
    {

      
    }
    protected void GridViewWall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {     
        LoadWall(50);
    }

    protected void RWallPost(string post)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();
        objWall.WallOwnerUserId = Session["UserId"].ToString();
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.TEXT_POST;
        WallBLL.insertWall(objWall);

    }

    protected void lbtnLike_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        Label labelLike = (Label)row.FindControl("lblLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        if (linkLike.Text == "Like")
        {
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString()); 
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString(); 
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            LikesBLL.insertLikes(objClass);
            labelLike.Text = "You Like this";
            linkLike.Text = "UnLike";

        }
        else
        {
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString(); 
            LikesBLL.unLikes(objClass);
            labelLike.Text = "";
            linkLike.Text = "Like";
        }
        LoadWall(50);

    }

    // To share a post
    protected void ShareLinkButton_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkShare = (LinkButton)row.FindControl("ShareLinkButton");
        Label labelShare = (Label)row.FindControl("ShareLabel");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        Session["PostID"] = hfId;

        if (linkShare.Text == "Share")
        {
            // Getting the user information
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

            // Creating Share object
            ShareBO objClass = new ShareBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString();
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;

            // Getting the post which is going to be shared
            WallBO wall = WallBLL.getWallByWallId(objClass.AtId);
            string p = txtUpdatePost.Text + " <br/>" + wall.Post;
            
            // Sharing the post on the wall
            ShareStatus(p); 
            
            // Registering the Share after successful completion of the above process
            ShareBLL.insertShare(objClass);            
        }
        
        LoadWall(50);

    }
   
    protected void ShareStatus(string post)
    {
        string status = post;

        if (lblFriendsWith.Text != "")
            status += " with " + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));
        
        if (lblLocation.Text != "")
            status += lblLocation.Text;

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(SessionClass.getUserId());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = SessionClass.getUserId();

        if (SessionClass.getShareWithID() != null)
        {
            objWall.PostedByUserId = Session["UserId"].ToString();        
            if (SessionClass.getShareWithID() != "")
            {
                objWall.WallOwnerUserId = SessionClass.getShareWithID();
                UserBO objFriendObj = new UserBO();
                objFriendObj = UserBLL.getUserByUserId(SessionClass.getShareWithID());

                if (!CheckBox1.Checked)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objFriendObj.Email);
                    notif(SessionClass.getShareWithID(), SessionClass.getPostID());
                }

                List<string> temp = (List<string>)SessionClass.getTaggedFriends();

                if (temp != null)
                {
                    foreach (string str in temp)
                    {
                        UserBO objFriendObj1 = new UserBO();
                        objFriendObj1 = UserBLL.getUserByUserId(str);
                        //sendEmail(objFriendObj1.Email);
                        if (!CheckBox1.Checked)
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objFriendObj1.Email);
                            notif(str, SessionClass.getPostID());
                        }
                        //Inserting follow post record for each tagged user
                        FollowPostBO fp = new FollowPostBO();
                        fp.AtId = SessionClass.getPostID();
                        fp.UserId = objFriendObj1.Id;
                        fp.FirstName = objFriendObj1.FirstName;
                        fp.LastName = objFriendObj1.LastName;
                        fp.Type = Global.WALL;

                        FollowPostBLL.insertFollowPost(fp);
                    }
                }
            }
            else
            {
                objWall.WallOwnerUserId = SessionClass.getUserId();
                UserBO objUserEmail = new UserBO();
                objUserEmail = UserBLL.getUserByUserId(SessionClass.getUserId());

                // Sending notification with which the post is beind shared                 
                if (!CheckBox1.Checked)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserEmail.Email);
                    notif(SessionClass.getShareWithID(), SessionClass.getPostID());
                }
                //Sending notification to all tagged friends
                List<string> temp = (List<string>)SessionClass.getTaggedFriends();

                if (temp != null)
                {
                    foreach (string str in temp)
                    {
                        UserBO objFriendObj1 = new UserBO();
                        objFriendObj1 = UserBLL.getUserByUserId(str);

                        if (!CheckBox1.Checked)
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objFriendObj1.Email);
                        }
                        notif(str, SessionClass.getPostID());
                        //Inserting follow post record for each tagged user
                        FollowPostBO fp = new FollowPostBO();
                        fp.AtId = SessionClass.getPostID();
                        fp.UserId = objFriendObj1.Id;
                        fp.FirstName = objFriendObj1.FirstName;
                        fp.LastName = objFriendObj1.LastName;
                        fp.Type = Global.WALL;

                        FollowPostBLL.insertFollowPost(fp);
                    }
                }
            }
        }
        else
        {
            objWall.WallOwnerUserId = SessionClass.getUserId();
            UserBO objUserEmail = new UserBO();
            objUserEmail = UserBLL.getUserByUserId(SessionClass.getUserId());

            if (!CheckBox1.Checked)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objUserEmail.Email);
            }
            //Sending notification to all tagged friends
            List<string> temp = (List<string>)SessionClass.getTaggedFriends();
            if (temp != null)
            {
                foreach (string str in temp)
                {
                    UserBO objFriendObj1 = new UserBO();
                    objFriendObj1 = UserBLL.getUserByUserId(str);
                   // sendEmail(objFriendObj1.Email);
                    if (!CheckBox1.Checked)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(sendEmail), (object)objFriendObj1.Email);
                        notif(str, SessionClass.getPostID());
                    }
                    //Inserting follow post record for each tagged user
                    FollowPostBO fp = new FollowPostBO();
                    fp.AtId = SessionClass.getPostID();
                    fp.UserId = objFriendObj1.Id;
                    fp.FirstName = objFriendObj1.FirstName;
                    fp.LastName = objFriendObj1.LastName;
                    fp.Type = Global.WALL;

                    FollowPostBLL.insertFollowPost(fp);
                }
            }
        }

        TickerBLL.InsertBulkTickerDataAndWallPost(objWall, "Share a post " + status);

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtUpdatePost.ClientID + "').value = '';", true);
        lblLocation.Text = "";
        lblFriendsWith.Text = "";
        LoadWall(100);
        Session["ShareWithID"] = "";
        Session["TaggedFriends"] = null;
    }

    void notifTag(string uid, string atid)
    {

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        UserBO objUserNotify = new UserBO();
        objUserNotify = UserBLL.getUserByUserId(uid);
        NotificationBO objNotify = new NotificationBO();
        objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> Tag  a <a  href='UserData.aspx'>post</a>";
        objNotify.AtId = atid;
        objNotify.Type = Global.SHARE;
        objNotify.UserId = uid;
        objNotify.FirstName = objUserNotify.FirstName;
        objNotify.LastName = objUserNotify.LastName;
        objNotify.FriendId = userid;
        objNotify.FriendFName = objUser.FirstName;
        objNotify.FriendLName = objUser.LastName;

        NotificationBLL.insertNotification(objNotify);
    }
    void notif(string uid,string atid)
    {
        
         UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        UserBO objUserNotify = new UserBO();
        objUserNotify = UserBLL.getUserByUserId(uid);
        NotificationBO objNotify = new NotificationBO();
        objNotify.MyNotification = "<a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> Share  a <a  href='UserData.aspx'>post</a>";
        objNotify.AtId = atid;
        objNotify.Type = Global.SHARE;
        objNotify.UserId = uid;
        objNotify.FirstName = objUserNotify.FirstName;
        objNotify.LastName = objUserNotify.LastName;
        objNotify.FriendId = userid;
        objNotify.FriendFName = objUser.FirstName;
        objNotify.FriendLName = objUser.LastName;

        NotificationBLL.insertNotification(objNotify);
    }
    // Send Email to the email address given in the parameters
    public static void sendEmail(object o)
    {

        string toEmail = (string)o;
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
        
        msg.To.Add(new MailAddress(toEmail));

        msg.Subject = "Pyramid Plus | Someone has shared a post with you!";
        msg.IsBodyHtml = true;
        string id = 
        //string url = "<a  href=\"SharePost.aspx=" + atid + "\">" + "Click here to see the post." + "</a>,";

        msg.Body = "Dear Pyramid Plus user, You have got a share post notification. Please see the attached link to check the post on Pyramid Plus Website. " + "<br/><br/>" ;

        try
        {           
            client.Send(msg);            
        }
        catch (Exception ex)
        {

        }
            
    }

    protected void lbtnUser_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        GridView gridviewLikesUser = (GridView)row.FindControl("GridViewLikesUser"); 
        gridviewLikesUser.DataSource = LikesBLL.getLikesTop(Global.WALL, hfId.Value); 
        gridviewLikesUser.DataBind();       
    }

    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnViewComments_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        GridView gridviewComments = (GridView)row.FindControl("GridViewComments"); 
        gridviewComments.DataSource = CommentsDAL.getCommentsTop(Global.WALL, hfId.Value, 100); 
        gridviewComments.DataBind(); 

    }
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnCommentLike_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        LinkButton lbtnCommentLike = (LinkButton)row.FindControl("lbtnCommentLike");
        //GridView gv = (GridView)GridViewWall.Rows[RowIndex].FindControl("GridViewComments");

        if (lbtnCommentLike.Text == "Like")
        {
            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL_COMMENT;
            objClass.UserId = Session["UserId"].ToString();
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            LikesBLL.insertLikes(objClass);
            lbtnCommentLike.Text = "You Like this";
            lbtnCommentLike.Text = "UnLike";
            
        }
        else
        {
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL_COMMENT;
            objClass.UserId = Session["UserId"].ToString();
            LikesBLL.unLikes(objClass);
            lbtnCommentLike.Text = "";
            lbtnCommentLike.Text = "Like";
            
        }
       
        LoadWall(50);
    }

    

    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnCommentLikeUser_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
       // LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        GridView gridviewLikesUser = (GridView)row.FindControl("GridViewLikesCommentUser");
        gridviewLikesUser.DataSource = LikesBLL.getLikesTop(Global.WALL_COMMENT, hfId.Value);
        gridviewLikesUser.DataBind();       
    }

    protected void lbtnDeleteComment_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        CommentsDAL.deleteComments(hfId.Value);
        LoadWall(50);
    }

    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        if(txtLocation.Text !="") 
        lblLocation.Text = " in "+ txtLocation.Text;
        txtLocation.Text = "";
    }
    
    protected void txtFriendWith_TextChanged(object sender, EventArgs e)
    {
        if (txtFriendWith.Text != "" && HiddenField1.Value.Length > 20)
        {
            lblFriendsWith.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenField1.Value + "\">" + txtFriendWith.Text + "</a>,";
            lstTag.Add(HiddenField1.Value);
            txtFriendTag.Text = "";
            HiddenField1.Value = "";
        }

    }
   
    protected void txtFriendTag_TextChanged(object sender, EventArgs e)
    {
        if (txtFriendTag.Text != "" && HiddenFieldTagId.Value.Length > 20)
        {
            lblFriendsTag.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenFieldTagId.Value + "\">" + txtFriendTag.Text + "</a>,";
            //Getting name of a person with whom I will share this post
            Session["ShareWithID"] = HiddenFieldTagId.Value;
            SharingWithLiteral.Text = "Sharing with ";
            txtFriendTag.Text = "";
            txtFriendTag.ReadOnly = true;
            HiddenFieldTagId.Value = "";
        }

    }
    

    public void showmsg(string str)
    {
        string prompt =
        "<script>$(document).ready(function(){{$.prompt('{0}!',{1});}});</script>";
        string message = string.Format(prompt, str, "{ prefix: 'jqi' }");
        // registering the JavaScript on the page and controls with postback
        this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", message);
        string s = "var jqi = $.prompt('Hello World!');";
            str+=" jqi.bind('promptsubmit', function(event, val, msg, fields){";
    
            str+="});";
    }
  
    protected void btn_Click(object sender, EventArgs e)
    {
    }
    protected void lbtnAddPhotos_Click(object sender, EventArgs e)
    {
       showmsg("Hello");
    }

    protected void UpdatePhoto()
    {
        string status = txtUpdatePost.Text;

        if (lblFriendsWith.Text != "")
            status += " with " + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));

        if (lblLocation.Text != "")
            status += lblLocation.Text;    

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();
        objWall.WallOwnerUserId = userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = status;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.TEXT_POST;
        WallBLL.insertWall(objWall);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtUpdatePost.ClientID + "').value = '';", true);
        lblLocation.Text = "";
        lblFriendsWith.Text = "";
        LoadWall(100);

    }
    protected void lbtnAddPhoto_Click(object sender, EventArgs e)
    {
        
    }

   
    void showPostControl()
    { 
        
    }

    protected void generateThumbnail(HttpPostedFile postedFile, string fileid)
    {
        string thumpath = "";
        thumpath = Server.MapPath(Global.THUMBNAIL_PHOTOS);
        System.Drawing.Image sourceImaget = System.Drawing.Image.FromStream(postedFile.InputStream);
        PAB.ImageResizer.ImageResizer resizert = new PAB.ImageResizer.ImageResizer();
        resizert.MaxHeight = 200;
        resizert.MaxWidth = 200;
        resizert.ImgQuality = 50;
        resizert.OutputFormat = PAB.ImageResizer.ImageFormat.Jpeg;

        byte[] bytest = resizert.Resize(postedFile);
        File.WriteAllBytes(thumpath + @"\" + fileid + ".jpg", bytest);
    }

    public string SavePhotos()
    {
        string albumId;
        if (Session["PhotoAlbumId"] == null)
        {
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = userid;
            objAClass.Name = "My Pictures";
            objAClass.Type = Global.PHOTO;
            objAClass.isFollow = true;
            albumId = MediaAlbumBLL.insertDefaultAlbum(objAClass);

        }
        else
        {
            albumId = Session["PhotoAlbumId"].ToString();
        }
        MediaBO objClass = new MediaBO();

        objClass.UserId = userid;


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

    protected void WallPost(string photoid)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();

        try
        {
            if (Request.QueryString[0] != null)
            {
                objWall.WallOwnerUserId = Request.QueryString[0];
                objWall.Type = Global.SHARE;
            }
            else
            {
                objWall.WallOwnerUserId = userid;
                objWall.Type = Global.TEXT_POST;
            }
        }
        catch
        {
            objWall.WallOwnerUserId = userid;
            objWall.Type = Global.TEXT_POST;
        }

        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;

        if (txtUpdatePost.Text != "")
            objWall.Post = "added a new photo <br/>" + txtUpdatePost.Text + " </br></br><a href='ViewPhoto.aspx?PhotoId=" + photoid + "'><img src='../../Resources/ThumbnailPhotos/" + photoid + ".jpg' width='150' height='150' border='0' alt='No Image'/> <a/>";
        else
            objWall.Post = "added a new photo </br></br><a href='ViewPhoto.aspx?PhotoId=" + photoid + "'><img src='../../Resources/ThumbnailPhotos/" + photoid + ".jpg' width='150' height='150' border='0' alt='No Image'/> <a/>";
        
        objWall.AddedDate = DateTime.Now;
        
        WallBLL.insertWall(objWall);
    }

    protected void btnCamSave_Click(object sender, EventArgs e)
    {
        string fileid = null;
        if (Session["TempPhotoID"] != null)
            fileid = Session["TempPhotoID"].ToString();

        WallPost(fileid);
        LoadWall(100);
    }

    protected void UpdateImageButton_Click(object sender, ImageClickEventArgs e)
    {
        lblFriendsTag.Text = "";
        SharingWithLiteral.Text = "";
        txtFriendTag.ReadOnly = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnUnFollow_Click(object sender, EventArgs e)
    {
        isunfollow = true;
    }
}