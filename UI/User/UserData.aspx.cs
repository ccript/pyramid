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
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using BuinessLayer;
using ObjectLayer;
using System.Globalization;
using System.Net.Mail;
using AjaxControlToolkit;

public partial class Wall : System.Web.UI.Page
{
    string userid;
    string location;
    string friendswith;
    static string youtubeurl;
    public static List<string> lstTag = new List<string>();
    static string ds;//default youtube thumbnail image path
    public VideoLinkBO vlo = new VideoLinkBO();
    public static bool vidthumbdisp = false;
    public static string uploadedvideoembedliteral;
    public static string uploadedPhotoliteral;
    public static string photoid;
    public static string currentLocation;
    int totaltop;

    string postedfilename, SavePath, Filenamewithpath;
    public static bool videofileuploaded = false;
    public static bool photofileuploaded = false;
    public static bool isphotoalbum = false;
    public static string uploadedvideothumbname;
    public static string uploadedvideoname;
    public static bool isSeeFriendshipPage = false;
    public static bool isWall = false;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (Request.QueryString.Count == 2)
            {
                Session["FriendID"] = Request.QueryString.Get(0);
            }
            if (Request.QueryString.Count == 0)
            {

                    btnAddAsFriend.Visible = false;
                    btnCancelRequest.Visible = false;
                    userid = Session["UserId"].ToString();
                    Session["TempUserId"] = null;
                    isSeeFriendshipPage = false;
                    isWall = false;
                    btnPost.Visible = false;
                    PanelPostContent.Visible = false;
                    pnlUserInfo.Visible = false;
                    btnAddAsFriend.Visible = false;
                    btnSuggestFriends.Visible = false;
                    DataListTagPhotos.Visible = false;
                    Session["FirstLoad"] = "Ok";
            }

            else 
            {

                userid = Request.QueryString.Get(0);
                if(userid.Equals(Session["UserId"].ToString()))
                {
                    btnAddAsFriend.Visible = false;
                    btnCancelRequest.Visible = false;
                    userid = Session["UserId"].ToString();
                    Session["TempUserId"] = null;
                    isSeeFriendshipPage = false;
                    isWall = true;
                    Session["FirstLoad"] = "Ok";
                }

                else
                {

                    isWall = true;
                Session["TempUserId"] = userid;
                if (FriendsBLL.isExistingFriend(Session["UserId"].ToString(), userid))
                {
                    btnAddAsFriend.Visible = false;
                    btnSuggestFriends.Visible = true;
                }
                else
                {
                    btnAddAsFriend.Visible = true;
                    btnSuggestFriends.Visible = false;
                }

                if (Session["UserId"].ToString() == userid)
                     btnAddAsFriend.Visible = false;
                if (Request.QueryString.Count == 2)
                {
                    isSeeFriendshipPage = true;
                    isWall = false;
                    if (Session["FirstLoad"] != null)
                    {
                        LoadWall(100);
                        LoadUserData();
                        Session["FirstLoad"] = null;
                    }
                    pnlUserInfo.Visible = false;
                    btnAddAsFriend.Visible = false;
                    btnSuggestFriends.Visible = false;
                    DataListTagPhotos.Visible = false;
                   
                }
                else
                {
                    isSeeFriendshipPage = false;
                    isWall = true;
                    if (Session["FirstLoad"] != null)
                    {
                        LoadWall(100);
                        LoadUserData();
                        Session["FirstLoad"] = null;
                    }
                    pnlUserInfo.Visible = true;
             
                    DataListTagPhotos.Visible = true;

                    
                }
                }
             
            }

   
            ((Image)Master.FindControl("imgProfile")).ImageUrl = "../UserProfile/profileimages/" + userid + ".jpg";


        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
      
        ((Label)Master.FindControl("lblTitle")).Text = "";
      

        if (!IsPostBack)
        {

            LoadBasicInfo();
            LoadLanguages();
            LoadUserData();
            LoadDataListTagPhotos();
            LoadWall(100);
            YouLikes();
            LoadBirthdayAlerts();
            Comment_YouLikes();
            CountShare();
            Session["WebCamPhotoId"] = null;
            videofileuploaded = false;
            photofileuploaded = false;
            isphotoalbum = false;
           
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      USER INFO MODULE                                             ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void LoadUserData()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        lblName.Text = objUser.FirstName+" "+objUser.LastName;
        lblBirthDay.Text= objUser.DateOfBirth.ToLongDateString();
        lblGender.Text = objUser.Gender;
        if (isSeeFriendshipPage)
        {
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());
            lblName.Text += " & " +objUser.FirstName + " " + objUser.LastName;

        }

    }
    protected void LoadBirthdayAlerts()
    {
        dlBirthday.DataSource = FriendsBLL.getBirthdayAlertFriends(userid);
        dlBirthday.DataBind();
        if (dlBirthday.Items.Count < 1)
            dlBirthday.Visible = false;
    }
    protected void LoadDataListTagPhotos()
    {

        DataListTagPhotos.DataSource = TagsBLL.getTagsListbyFriendsId(Global.PHOTO, userid).Take(3).ToList();
        DataListTagPhotos.DataBind();

    }
    protected void LoadBasicInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);
        lblHomeTown.Text = objBasicInfo.HomeTown;
        lblCurrentCity.Text = objBasicInfo.CurrentCity;
        currentLocation = lblCurrentCity.Text;
    }
    protected void LoadUser()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);
        lblHomeTown.Text = objBasicInfo.HomeTown;
        lblCurrentCity.Text = objBasicInfo.CurrentCity;
    }
    protected void LoadLanguages()
    {
        DListLanguage.DataSource = LanguageBLL.getLanguages(userid);
        DListLanguage.DataBind();
        
        if (DListLanguage.Items.Count <= 0)
           pnlUserInfo.FindControl( "pnlLanguages").Visible = false;
    }


    protected void btnAddAsFriend_Click(object sender, EventArgs e)
    {
        btnAddAsFriend.Visible = false;
        btnAddAsFriend.Enabled = false;
        lblFriendRequestSent.Visible = true;
        string friendId = userid;
        string userId = Session["UserId"].ToString();
        FriendsBLL.sendFriendRequest(userId, friendId);
        btnCancelRequest.Visible = true;
        btnCancelRequest.Enabled = true;


    }
  
    protected void btnCancelRequest_Click(object sender, EventArgs e)
    {
        btnCancelRequest.Visible = false;
        btnCancelRequest.Enabled = false;
        btnAddAsFriend.Visible = true;
        btnAddAsFriend.Enabled = true;
        lblFriendRequestSent.Visible = false;
        string friendId = userid;
        string userId = Session["UserId"].ToString();
        FriendsBLL.cancelFriendRequest(userId, friendId);


    }
    protected void btnSuggestFriends_Click(object sender, EventArgs e)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        lblName.Text = objUser.FirstName + " " + objUser.LastName;
        Response.Redirect("SuggestFriends.aspx?FriendFName=" + objUser.FirstName + "&FriendLName=" + objUser.LastName);
    }

    protected void GridViewWall_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // add a separator between rows (Pick your own style)

       
          //  foreach (TableCell cell in e.Row.Cells)

               // cell.Attributes.Add("Style", "border-top: #CCCCCC 1px double");



        // odd...this didn't work 
        //if (e.Row.RowIndex == 3) 
        // e.Row.Attributes.Add("Style", "border-top: black 5px double"); 


    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      WALL MODULE                                                    ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void LoadWall(int top)
    {
        pnlVideoLink.Visible = false;
        if (isSeeFriendshipPage)
        {
            GridViewWall.DataSource = WallBLL.getSeeFriendShipWall(userid,Session["UserId"].ToString(), top);
            PanelSort.Visible = false;
        }
        else if (isWall)
        {
            GridViewWall.DataSource = WallBLL.getWallByUserId(userid, top);
            PanelSort.Visible = false;
        }

        else
        {
            GridViewWall.DataSource = WallBLL.getNewsfeedByUserId(Session["UserId"].ToString(), top, 1);//1 is for topstories
        }
        GridViewWall.DataBind();
        LoadComments();
        YouLikes();
        Comment_YouLikes();
        CountShare();

    }

    protected void GridViewWall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewWall.PageIndex = e.NewPageIndex;
        LoadWall(50);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      ADD VIDEO MODULE                                                  ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void lbtnAddVideos_Click(object sender, EventArgs e)
    {        
        if (FileUpload1.HasFile )
        {            
            Video.Upload(FileUpload1);
            Thumbnail.Build(FileUpload1);
            videofileuploaded = true;            
            LiteralUploadVideo.Text = Video.uploadedVideoLiteral(FileUpload1);            
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      POST MODULE                                                  ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnPost_Click(object sender, EventArgs e)
    {
        UpdateStatus();
    }
    
    protected void UpdateStatus()
    {
        string status = txtUpdatePost.Text;
        bool isVideoLink = false;
        UserBLL userbll = new UserBLL();
        
        if(lblFriendsWith.Text!="")
            status += " <font color='#838181'> -- with <font/>" + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));
        if (lblLocation.Text != "")
            status += lblLocation.Text;

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();
        objWall.WallOwnerUserId = userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = ConvertUrlsToLinks(status);
        objWall.AddedDate = DateTime.UtcNow;
        objWall.Type = Global.TEXT_POST;

        if (ConvertUrlsToLinks(status).IndexOf("http") > 0)
        {
            objWall.Type = Global.LINK;
            status = "post a link";
        }

        string imagesrc="";

        if (!GetYouTubeURL(txtUpdatePost.Text).Equals(""))
        {
            string url = GetYouTubeURL(txtUpdatePost.Text);
            objWall.Post = "<br/><br/><a href='" + url + "'>" + url + "</a><br/><br/>";

        }
        if (pnlVideoLink.Visible == true)
        {

            string url = GetYouTubeURL(txtUpdatePost.Text);
            string id = GetYouTubeID(txtUpdatePost.Text);
            string embedsrc = "http://www.youtube.com/embed/" + id + "?rel=0";
            objWall.Type = Global.POST_VIDEOLINK;
            objWall.Post = "<br/><br/><a href='" + url + "'>" + url + "</a><br/><br/>";
            if (!chkThumbnail.Checked)
            {
                imagesrc = getCurrentSelectedVideoThumbnail(id);
                vidthumbdisp = true;
                objWall.EmbedPost = imagesrc;
            }
            objWall.Type = Global.POST_VIDEOLINK;
            txtUpdatePost.Text = "";
            isVideoLink = true;
            status = " added a new video";
        }
        if (videofileuploaded)
        {
            objWall.Type = Global.VIDEO;
            string wallpost = objWall.Post;
            objWall.EmbedPost = Global.PATH_COMPRESSED_USER_VIDEO + "Thumb/" + uploadedvideothumbname;
            uploadedvideoembedliteral = wallpost + "<br/><br/><embed src='" + Global.PATH_COMPRESSED_USER_VIDEO + "Players/flvplayer.swf' width='320' height='215' bgcolor='#FFFFFF' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' flashvars='file=" + Global.PATH_COMPRESSED_USER_VIDEO + "SWF/" + uploadedvideoname + "&autostart=true&frontcolor=0xCCCCCC&backcolor=0x000000&lightcolor=0x996600&showdownload=false&showeq=false&repeat=false&volume=100&useaudio=false&usecaptions=false&usefullscreen=true&usekeys=true'></embed>";
            LiteralUploadVideo.Text = "";
            status = " added a new video";
        }
        if (photofileuploaded)
        {
            objWall.Type = Global.PHOTO;
            LiteralUploadPhoto .Text= "";
            uploadedPhotoliteral = "";
            objWall.EmbedPost = photoid;
            status = " added a new photo";
        }

        if (Session["WebCamPhotoId"] != null)
        {

            objWall.Type = Global.PHOTO;
            objWall.EmbedPost = Session["WebCamPhotoId"].ToString();
            status = " added a new photo";
        }
        if (isphotoalbum)
        {
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = userid;
            objAClass.Name = txtName.Text;
            objAClass.Description = txtDescription.Text;
            objAClass.CoverPictureId = "0000000000000b0000000900";
            objAClass.Type = Global.PHOTO;
            objAClass.isFollow = true;
            string aid=MediaAlbumBLL.insertMediaAlbum(objAClass);
            objWall.Post = objWall.Post + " add new <a  href=\"ViewPhotoAlbum.aspx?AlbumId=" + aid + "\">photo album</a>.";
            objWall.Type = Global.PHOTO_ALBUM;
            status = " added a new photo album";
        }
        //////////////////////////////////////////////////////////////////////
        foreach (string item in lstTag)
        {
            string tagstatus;
            if (photofileuploaded || videofileuploaded || Session["WebCamPhotoId"] != null || isVideoLink || isphotoalbum)
            {
            WallBO objWall2 = new WallBO();
            string tagpost = objWall.Post + "<br/> <font color='#838181'> was tagged by <font/><a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
            UserBO objUser2 = new UserBO();
            objUser2 = UserBLL.getUserByUserId(item);
            objWall2.PostedByUserId = item;
            objWall2.WallOwnerUserId = item;
            objWall2.FirstName = objUser2.FirstName;
            objWall2.LastName = objUser2.LastName;
            objWall2.Post = tagpost;
            tagstatus = "tagged a post";
            objWall2.AddedDate = DateTime.Now;

            if (isphotoalbum)
            {
                objWall2.Type = Global.TAG_PHOTO_ALBUM;
                objWall2.Post = objWall.Post + " <font color='#838181'> was tagged by <font/><a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
                notifTag(item, userid);
                tagstatus = "tagged a photo album";
            }

            if (videofileuploaded)
            {
                objWall2.Type = Global.TAG_VIDEO;
                objWall2.EmbedPost = Global.PATH_COMPRESSED_USER_VIDEO + "Thumb/" + uploadedvideothumbname;
                objWall2.Post = objWall.Post + "<font color='#838181'> was tagged by <font/><a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
                notifTag(item, userid);
                tagstatus = "tagged a video";
            }
           if (isVideoLink)
            {
                objWall2.Type = Global.TAG_VIDEOLINK;
                objWall2.EmbedPost = imagesrc;
                objWall2.Post = objWall.Post + "<font color='#838181'> was tagged by <font/> <a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
                notifTag(item, userid);
                tagstatus = "tagged a video";
           
           }
            if (photofileuploaded)
            {
                TagsBO objTags = new TagsBO();
                objTags.AtId = photoid;
                objTags.Type = Global.PHOTO;
                objTags.UserId = Session["UserId"].ToString();
                objTags.FirstName = objUser.FirstName;
                objTags.LastName = objUser.LastName;
                objTags.FriendId = item;
                objTags.FriendFName = objUser2.FirstName;
                objTags.FriendLName = objUser2.LastName;
                notifTag(item, photoid);
                TagsBLL.insertTags(objTags);
                objWall2.Type = Global.TAG_PHOTO;
                objWall2.EmbedPost = photoid;
                tagstatus = "tagged a photo";
            }
            if (Session["WebCamPhotoId"] != null)
            {
                TagsBO objTags = new TagsBO();
                objTags.AtId = Session["WebCamPhotoId"].ToString();
                objTags.Type = Global.PHOTO;
                objTags.UserId = Session["UserId"].ToString();
                objTags.FirstName = objUser.FirstName;
                objTags.LastName = objUser.LastName;
                objTags.FriendId = item;
                objTags.FriendFName = objUser2.FirstName;
                objTags.FriendLName = objUser2.LastName;
                TagsBLL.insertTags(objTags);
                objWall2.Type = Global.TAG_PHOTO;
                objWall2.EmbedPost = Session["WebCamPhotoId"].ToString();
                notifTag(item, Session["WebCamPhotoId"].ToString());
                tagstatus = "tagged a photo";
            }
            
            RWallPost(" tag post to <a  href=\"ViewProfile.aspx?UserId=" + item + "\">" + objUser2.FirstName + " " + objUser2.LastName + "</a>");
            string twid= WallBLL.insertWall(objWall2);
            
            userbll.notify_subscribers(Session["UserId"].ToString(), objWall2, ConvertUrlsToLinks(tagstatus), twid);
        }
        }
        string wid= WallBLL.insertWall(objWall);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtUpdatePost.ClientID + "').value = '';", true);
        lblLocation.Text = "";
        lblFriendsWith.Text = "";
        lblFriendsTag.Text = "";
        LiteralUploadPhoto.Text = "";
        LiteralUploadVideo.Text = "";
        uploadedPhotoliteral = "";
        Session["WebCamPhotoId"] = null;
        videofileuploaded = false;
        photofileuploaded = false;
        isVideoLink = false;
        isphotoalbum = false;
        lstTag.Clear();
        userbll.notify_subscribers(Session["UserId"].ToString(), objWall, ConvertUrlsToLinks(ConvertUrlsToLinks(status)), wid);
        LoadWall(100); 
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
        objNotify.Type = Global.TAG_POST;
        objNotify.UserId = uid;
        objNotify.FirstName = objUserNotify.FirstName;
        objNotify.LastName = objUserNotify.LastName;
        objNotify.FriendId = userid;
        objNotify.FriendFName = objUser.FirstName;
        objNotify.FriendLName = objUser.LastName;
        NotificationBLL.insertNotification(objNotify);
    }
    protected void RWallPost(string post)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        WallBO objWall = new WallBO();
        objWall.PostedByUserId = userid;
        objWall.WallOwnerUserId = userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.PROFILE_CHANGE;
        WallBLL.insertWall(objWall);
    }
    private string ConvertUrlsToLinks(string msg)
    {
        string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
        Regex r = new Regex(regex, RegexOptions.IgnoreCase);
        return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      COMMENTS MODULE                                                    ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
    protected void txtComments_TextChanged(object sender, EventArgs e)
    {
       
        GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
       
        TextBox txtcomments = (TextBox)row.FindControl("txtComments");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        Literal literalpost = (Literal)row.FindControl("LiteralPost");
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfEmbedPost = (HiddenField)row.FindControl("HiddenFieldEmbedPost");
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = ConvertUrlsToLinks( txtcomments.Text);
        objClass.AtId = hfId.Value;
        objClass.Type = Global.WALL;
        objClass.UserId = Session["UserId"].ToString();
        objClass.FirstName = objUser.FirstName;
        objClass.LastName = objUser.LastName;

        CommentsBLL.insertComments(objClass);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtcomments.ClientID + "').value = '';", true);

        GridView gridviewComments = (GridView)row.FindControl("GridViewComments");

        gridviewComments.DataSource = CommentsBLL.getCommentsTop(Global.WALL,hfId.Value,2);
        gridviewComments.DataBind();

        pnlVideoLink.Visible = false;
        //LoadComments();
        Comment_YouLikes();
        YouLikes();
        pnlVideoLink.Visible = false;


         /////////////////////////////////////Friends recent activities
        if (!userid.Equals(Session["UserId"].ToString()))
        {

            UserBO objFUser = new UserBO();
            objFUser = UserBLL.getUserByUserId(userid);

            WallBO objWall = new WallBO();
            objWall.PostedByUserId = Session["UserId"].ToString();
            objWall.WallOwnerUserId = Session["UserId"].ToString();
            objWall.FirstName = objUser.FirstName;
            objWall.LastName = objUser.LastName;
            objWall.Post = " Comments on <a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objFUser.FirstName + " " + objFUser.LastName + "</a> Wall Post";
            objWall.AddedDate = DateTime.Now;
            objWall.Type = Global.TEXT_POST;
            WallBLL.insertWall(objWall);
        }
        ////////////////////////////////////////

        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

        List<UserFriendsBO> list = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in list)
        {
            TickerBO objTicker = new TickerBO();
        

            objTicker.PostedByUserId = Session["UserId"].ToString();
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objUser.FirstName;
            objTicker.LastName = objUser.LastName;
            objTicker.Post = literalpost.Text;
            objTicker.Title = "comments on post";
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = Global.TEXT_POST;
            objTicker.EmbedPost = hfEmbedPost.Value;
            objTicker.WallId = hfId.Value;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUser = new TickerBO();


        objTickerUser.PostedByUserId = Session["UserId"].ToString();
        objTickerUser.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUser.FirstName = objUser.FirstName;
        objTickerUser.LastName = objUser.LastName;
        objTickerUser.Post = literalpost.Text;
        objTickerUser.Title = "comments on post";
        objTickerUser.AddedDate = DateTime.UtcNow;
        objTickerUser.Type = Global.TEXT_POST;
        objTickerUser.EmbedPost = hfEmbedPost.Value;
        objTickerUser.WallId = hfId.Value;

        TickerBLL.insertTicker(objTickerUser);
        ////////////////////////////////////////////////////////////////////////////////////
  
    }
    protected void LoadComments()
    {

        foreach (GridViewRow gvr in GridViewWall.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbutton = ((ImageButton)gvr.FindControl("imgCommentsUser"));
                string sValue = ((HiddenField)gvr.FindControl("HiddenFieldId")).Value;
                GridView gridviewComments = (GridView)gvr.FindControl("GridViewComments");
                //LinkButton btn = (LinkButton)gvr.FindControl("LinkButton2");
                WallBO objWall = new WallBO();
                objWall = WallBLL.getWallByWallId(sValue);

                if (objWall.Type == Global.POST_VIDEOLINK || objWall.Type == Global.VIDEO)
                {
                    //ButtonField bf = (ButtonField) gvr.FindControl("Link");                    
                   // btn.Visible = true;

                }
                gridviewComments.DataSource = CommentsBLL.getCommentsTop(Global.WALL, sValue, 2);
                gridviewComments.DataBind();
                imgbutton.ImageUrl = Global.PROFILE_PICTURE + Session["UserId"].ToString() + ".jpg";
                imgbutton.PostBackUrl = "ViewProfile.aspx?UserId=" + Session["UserId"].ToString();

            }
        }



    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      VIDEO MODULE                                             ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void GridViewWall_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        
        if (e.CommandName == "show")
        {
            //GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;


            HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
            ImageButton imgbtn = (ImageButton)row.FindControl("ImageButton1");
           imgbtn.Visible = false;

            WallBO objWall = new WallBO();
            objWall = WallBLL.getWallByWallId(hfId.Value);
            int type = objWall.Type;
            string embedval = objWall.EmbedPost;
            if (type == Global.POST_VIDEOLINK || type == Global.TAG_VIDEOLINK)
            {
                string original_literal = objWall.Post;
                string literal = original_literal.Substring(44);
                int ind = literal.IndexOf('&');
                string id = literal.Substring(0, ind);
                string embedsrc = "http://www.youtube.com/embed/" + id + "?autoplay=1&rel=0";

                string literalval = "<br/><br/><iframe width='320' height='215' src=" + embedsrc + " frameborder='0' allowfullscreen></iframe>";

                WallBLL.updateLiteral(hfId.Value, literalval, "");
                //WallBLL.updateLiteral(hfId.Value, objWall.EmbedPost);


                //WallBLL.insertWall(objWall);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtUpdatePost.ClientID + "').value = '';", true);

                LoadWall(100);
             
                WallBLL.updateLiteral(hfId.Value, original_literal, embedval);
            }
            if (type == Global.VIDEO || type == Global.TAG_VIDEO)
            {
                string vidname = objWall.EmbedPost;
                int i = vidname.LastIndexOf('/');
                vidname = vidname.Substring(i + 1, 4) + ".swf";

                string original_literal = objWall.Post;
                string literalval = objWall.Post + "<br/><br/><embed src='" + Global.PATH_COMPRESSED_USER_VIDEO + "Players/flvplayer.swf' width='320' height='215' bgcolor='#FFFFFF' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' flashvars='file=" + Global.PATH_COMPRESSED_USER_VIDEO + "SWF/" + vidname + "&autostart=true'></embed>";
                WallBLL.updateLiteral(hfId.Value, literalval, "");

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myScript", "document.getElementById('" + txtUpdatePost.ClientID + "').value = '';", true);

               LoadWall(100);
            
                WallBLL.updateLiteral(hfId.Value, objWall.Post, embedval);


            }

        }
        
    }

    public string getCurrentSelectedVideoThumbnail(string id)
    {
        string imagepath = "";
        switch (CurrentPage)
        {
            case 0:
                imagepath = "http://img.youtube.com/vi/" + id + "/default.jpg";

                break;
            case 1:
                imagepath = "http://img.youtube.com/vi/" + id + "/1.jpg";
                break;
            case 2:
                imagepath = "http://img.youtube.com/vi/" + id + "/2.jpg";
                break;
            case 3:
                imagepath = "http://img.youtube.com/vi/" + id + "/3.jpg";
                break;
            default:
                break;


        }


        return imagepath;
    }
    public void test()
    {
        Response.Redirect("../../Default.aspx");
    }
    protected void txtUpdatePost_TextChanged(object sender, EventArgs e)
    {

      VideoLinkPanelLoad();



    }
    protected void VideoLinkPanelLoad()
    {


        youtubeurl = GetYouTubeURL(txtUpdatePost.Text);
        vlo.YouTubeURL = youtubeurl;
        //Label1.Text = youtubeurl;
        hlVideoLink.Text = youtubeurl;
        hlVideoLink.NavigateUrl = youtubeurl;


        string youtubeid = GetYouTubeID(txtUpdatePost.Text);
        vlo.YouTubeId = youtubeid;

        if (youtubeurl == "")
        {
            //txtUpdatePost.Text = "Not a youtube url";
        }
        else
        {

            pnlVideoLink.Visible = true;

            List<VideoLinkBO> vidlist = new List<VideoLinkBO>();
            ds = "http://img.youtube.com/vi/" + youtubeid + "/default.jpg";

            vlo.ImgSrc = ds;
            vlo.EmbedSrc = "http://www.youtube.com/embed/" + youtubeid + "?rel=0";

            vidlist.Add(vlo);

            VideoLinkBO vlo2 = new VideoLinkBO();
            vlo2.ImgSrc = "http://img.youtube.com/vi/" + youtubeid + "/1.jpg";
            vidlist.Add(vlo2);

            VideoLinkBO vlo3 = new VideoLinkBO();
            vlo3.ImgSrc = "http://img.youtube.com/vi/" + youtubeid + "/2.jpg";
            vidlist.Add(vlo3);

            VideoLinkBO vlo4 = new VideoLinkBO();
            vlo4.ImgSrc = "http://img.youtube.com/vi/" + youtubeid + "/3.jpg";
            vidlist.Add(vlo4);

            PagedDataSource objPds = new PagedDataSource();

            objPds.DataSource = vidlist;

            objPds.AllowPaging = true;

            objPds.PageSize = 1;

            objPds.CurrentPageIndex = CurrentPage;

            lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "

            + objPds.PageCount.ToString();

            // Disable Prev or Next buttons if necessary

            cmdPrev.Enabled = !objPds.IsFirstPage;

            cmdNext.Enabled = !objPds.IsLastPage;


            //AllSuggestionsDataList.DataSource = objPds;
            //AllSuggestionsDataList.DataBind();
            dlThumbnail.DataSource = objPds;
            dlThumbnail.DataBind();
            //txtUpdatePost.Text = ds;
        }
    }

    protected bool isVideoLink(string postid)
    {
        bool isvideolink = false;
        WallBO objWall = new WallBO();
        objWall = WallBLL.getWallByWallId(postid);
        if (objWall.Type == Global.POST_VIDEOLINK)
        {
            isvideolink = true;

        }
        return isvideolink;



    }
    protected void cmdPrev_Click(object sender, System.EventArgs e)
    {

        // Set viewstate variable to the previous page

        CurrentPage -= 1;

        // Reload control

        // LoadSuggestions("");
        //dlThumbnail.DataBind();
        VideoLinkPanelLoad();

    }

    protected void cmdNext_Click(object sender, System.EventArgs e)
    {

        // Set viewstate variable to the next page

        CurrentPage += 1;

        // Reload control

        //LoadSuggestions("");
        // dlThumbnail.DataBind();
        VideoLinkPanelLoad();
    }
    public int CurrentPage
    {

        get
        {

            // look for current page in ViewState

            object o = this.ViewState["_CurrentPage"];

            if (o == null)

                return 0; // default to showing the first page

            else

                return (int)o;

        }

        set
        {

            this.ViewState["_CurrentPage"] = value;

        }

    }

    protected void txtUpdatePost_Enter(object sender, EventArgs e)
    {
        txtUpdatePost_TextChanged((object)sender, (EventArgs)e);
    }

    private string GetYouTubeURL(string youTubeUrl)
    {
        //RegEx to Find YouTube ID
        Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                           RegexOptions.IgnoreCase);
        if (regexMatch.Success)
        {
            return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value +
                   "&hl=en&fs=0";
        }
        else
        {
            youTubeUrl = "";
        }
        return youTubeUrl;
    }
    private string GetYouTubeID(string youTubeUrl)
    {
        //RegEx to Find YouTube ID
        Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                           RegexOptions.IgnoreCase);
        if (regexMatch.Success)
        {
            return regexMatch.Groups[1].Value;
        }

        return youTubeUrl;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlVideoLink.Visible = false;
    }

    protected void chkThumbnail_CheckedChanged(object sender, EventArgs e)
    {
        // bool val = dlThumbnail.Visible;
        // dlThumbnail.Visible = !val;
        //LoadWall(100);
    }
 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      POST LIKE MODULE                                         ////
     ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    protected void YouLikes()
    {

        foreach (GridViewRow gvr in GridViewWall.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkLike = (LinkButton)gvr.FindControl("lbtnLike");
                Label labelLike = (Label)gvr.FindControl("lblLike");
                LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnUser");
                HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldId");
                HiddenField hfuserId = (HiddenField)gvr.FindControl("HiddenFieldUserId");
                HiddenField hfdate = (HiddenField)gvr.FindControl("HiddenFieldAddedDate");
                Label labeldate = (Label)gvr.FindControl("lblAddedDate");
                Literal literalpost = (Literal)gvr.FindControl("LiteralPost");
                ImageButton imgbtn = (ImageButton)gvr.FindControl("ImageButton1");
                LinkButton linkSeeFriendShip = (LinkButton)gvr.FindControl("lbtnSeeFriendShip");
                LinkButton linkShare = (LinkButton)gvr.FindControl("ShareLinkButton");
                HiddenField hfType = (HiddenField)gvr.FindControl("HiddenFieldType");
                DateTime date = Convert.ToDateTime(hfdate.Value);
                labeldate.Text=TimeAgo(date);

                if (Convert.ToInt32(hfType.Value) == Global.TEXT_POST || Convert.ToInt32(hfType.Value) == Global.PROFILE_CHANGE)

                    linkShare.Visible = false;

                if (FriendsBLL.isExistingFriend(hfuserId.Value, Session["UserId"].ToString()))
              
                    linkSeeFriendShip.Visible = true;
                  
                if(literalpost.Text.IndexOf("width")>0)
                imgbtn.Visible = false;

                long likecount = LikesBLL.countPost(hfId.Value, Global.WALL);
                if (likecount > 0)
                    linkLikeCount.Text = likecount.ToString() + " Likes";
                else
                    linkLikeCount.Visible = false;

                LinkButton linkcountComments = (LinkButton)gvr.FindControl("lbtnViewComments");
                long totalcomments = CommentsBLL.countComments(hfId.Value, Global.WALL);
                if (totalcomments > 2)
                    linkcountComments.Text = "View All " + totalcomments.ToString() + " Comments";
                else
                    linkcountComments.Text =   totalcomments.ToString() + " Comments";
                if (totalcomments <= 0)
                    linkcountComments.Visible = false;
                HiddenField Userownid = (HiddenField)gvr.FindControl("HiddenFieldUserId");
                LinkButton lbtnDelete = (LinkButton)gvr.FindControl("lbtnDelete");

                if (Userownid.Value.Equals(Session["UserId"].ToString()))
                {
                    lbtnDelete.Visible = true;
                }

                LikesBO objClass = new LikesBO();
                objClass.AtId = hfId.Value;
                objClass.Type = Global.WALL;
                objClass.UserId = Session["UserId"].ToString();
                bool islike = LikesBLL.youLikes(objClass);
                if (islike)
                {
                 
                    linkLike.Text = "Unlike";
                }

                else
                {
                   
                    linkLike.Text = "Like";
                }


            }
        }

    }

    protected void lbtnLike_Click(object sender, EventArgs e)
    {
        string statuslike = "like a post";
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        Label labelLike = (Label)row.FindControl("lblLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        Literal literalpost = (Literal)row.FindControl("LiteralPost");
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfEmbedPost = (HiddenField)row.FindControl("HiddenFieldEmbedPost");
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString()); 
        if (linkLike.Text == "Like")
        {
            
            
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString(); 
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            LikesBLL.insertLikes(objClass);
            
            linkLike.Text = "Unlike";
            statuslike = "like a post";

        }
        else
        {
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString(); 
            LikesBLL.unLikes(objClass);
             
            linkLike.Text = "Like";
            statuslike = "unlike a post";
        }
        LoadWall(50);


        /////////////////////////////////////Friends recent activities
        if (!userid.Equals(Session["UserId"].ToString()))
        {
            UserBO objFUser = new UserBO();
            objFUser = UserBLL.getUserByUserId(userid);

            WallBO objWall = new WallBO();
            objWall.PostedByUserId = Session["UserId"].ToString();
            objWall.WallOwnerUserId = Session["UserId"].ToString();
            objWall.FirstName = objUser.FirstName;
            objWall.LastName = objUser.LastName;
            objWall.Post = "Like a <a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objFUser.FirstName + " " + objFUser.LastName + "</a> Wall Post";
            objWall.AddedDate = DateTime.Now;
            objWall.Type = Global.TEXT_POST;
            WallBLL.insertWall(objWall);
        }
        ////////////////////////////////////////

        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

        List<UserFriendsBO> list = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in list)
        {
            TickerBO objTicker = new TickerBO();


            objTicker.PostedByUserId = Session["UserId"].ToString();
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objUser.FirstName;
            objTicker.LastName = objUser.LastName;
            objTicker.Post = literalpost.Text;
            objTicker.Title = statuslike;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = Convert.ToInt32(hfType.Value);
            objTicker.EmbedPost = hfEmbedPost.Value;
            objTicker.WallId = hfId.Value;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUser = new TickerBO();


        objTickerUser.PostedByUserId = Session["UserId"].ToString();
        objTickerUser.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUser.FirstName = objUser.FirstName;
        objTickerUser.LastName = objUser.LastName;
        objTickerUser.Post = literalpost.Text;
        objTickerUser.Title = statuslike;
        objTickerUser.AddedDate = DateTime.UtcNow;
        objTickerUser.Type = Convert.ToInt32(hfType.Value);
        objTickerUser.EmbedPost = hfEmbedPost.Value;
        objTickerUser.WallId = hfId.Value;

        TickerBLL.insertTicker(objTickerUser);
        ////////////////////////////////////////////////////////////////////////////////////

    }
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnUser_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

       
        GridView gridviewLikesUser = (GridView)row.FindControl("GridViewLikesUser"); 
        gridviewLikesUser.DataSource = LikesBLL.getLikesTop(Global.WALL, hfId.Value); 
        gridviewLikesUser.DataBind();
       // LoadWall(50);

    }
    protected void lbtnShareHistory_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("ShareLinkButton");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");


        GridView gridviewShareHistory = (GridView)row.FindControl("GridViewShareHistory");
        gridviewShareHistory.DataSource = ShareBLL.getShareHistory(Global.WALL, hfId.Value);
        gridviewShareHistory.DataBind();
        // LoadWall(50);

    }



    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnViewComments_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

        GridView gridviewComments = (GridView)row.FindControl("GridViewComments"); 
        gridviewComments.DataSource = CommentsBLL.getCommentsTop(Global.WALL, hfId.Value, 100); 
        gridviewComments.DataBind();
        Comment_YouLikes();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      COMMENTS LIKE MODULE                                         ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnCommentLike_Click(object sender, EventArgs e)
    {
        string statuslike = "like a post";
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        LinkButton lbtnCommentLike = (LinkButton)row.FindControl("lbtnCommentLike");
   
        //GridView gv = (GridView)GridViewWall.Rows[RowIndex].FindControl("GridViewComments");
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());
        if (lbtnCommentLike.Text == "Like")
        {
           
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL_COMMENT;
            objClass.UserId = Session["UserId"].ToString();
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            LikesBLL.insertLikes(objClass);
            lbtnCommentLike.Text = "Like this";
            lbtnCommentLike.Text = "Unlike";
            statuslike = "like a post comment";
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
            statuslike = "unlike a post comment";
        }
          WallBO objWall = new WallBO();

       // Comment_YouLikes();
        /////////////////////////////////////Friends recent activities
        //if (!userid.Equals(Session["UserId"].ToString()))
       // {

            UserBO objFUser = new UserBO();
            objFUser = UserBLL.getUserByUserId(userid);

        
            objWall.PostedByUserId = Session["UserId"].ToString();
            objWall.WallOwnerUserId = Session["UserId"].ToString();
            objWall.FirstName = objUser.FirstName;
            objWall.LastName = objUser.LastName;
            objWall.Post = " Like a Comments on <a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objFUser.FirstName + " " + objFUser.LastName + "</a> Wall Post";
            objWall.AddedDate = DateTime.Now;
            objWall.Type = Global.TEXT_POST;
            WallBLL.insertWall(objWall);
       // }
        ////////////////////////////////////////

        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

        List<UserFriendsBO> list = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in list)
        {
            TickerBO objTicker = new TickerBO();


            objTicker.PostedByUserId = Session["UserId"].ToString();
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objUser.FirstName;
            objTicker.LastName = objUser.LastName;
            objTicker.Post = objWall.Post;
            objTicker.Title = statuslike;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = Global.TEXT_POST;
            objTicker.EmbedPost = "";
            objTicker.WallId = hfId.Value;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUser = new TickerBO();


        objTickerUser.PostedByUserId = Session["UserId"].ToString();
        objTickerUser.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUser.FirstName = objUser.FirstName;
        objTickerUser.LastName = objUser.LastName;
        objTickerUser.Post = objWall.Post;
        objTickerUser.Title = statuslike;
        objTickerUser.AddedDate = DateTime.UtcNow;
        objTickerUser.Type = Global.TEXT_POST;
        objTickerUser.EmbedPost = "";
        objTickerUser.WallId = hfId.Value;

        TickerBLL.insertTicker(objTickerUser);
        ////////////////////////////////////////////////////////////////////////////////////
        LoadWall(50);

       // Response.Redirect("main.aspx?c="+hfId.Value);
    }

    protected void Comment_YouLikes()
    {

        foreach (GridViewRow gvrmain in GridViewWall.Rows)
        {
            GridView gridviewcomment = (GridView)gvrmain.FindControl("GridViewComments");

            foreach (GridViewRow gvr in gridviewcomment.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {

                    LinkButton linkLike = (LinkButton)gvr.FindControl("lbtnCommentLike");
                    Label labelLike = (Label)gvr.FindControl("lblCommentLike");
                    LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnCommentLikeUser");
                    HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldId");

                    HiddenField hfdate = (HiddenField)gvr.FindControl("HiddenFieldCommentAddedDate");
                    Label labeldate = (Label)gvr.FindControl("lblCommentAddedDate");
           
                  

                    DateTime date = Convert.ToDateTime(hfdate.Value);
                    labeldate.Text = TimeAgo(date);


                    long likecount = LikesBLL.countPost(hfId.Value, Global.WALL_COMMENT);
                    if (likecount > 0)
                        linkLikeCount.Text = likecount.ToString() + " Likes";
                    else
                        linkLikeCount.Visible = false;

                    HiddenField Userownid = (HiddenField)gvr.FindControl("HiddenFieldCommentUserId");
                    LinkButton lbtnDeleteComment = (LinkButton)gvr.FindControl("lbtnDeleteComment");

                    if (Userownid.Value.Equals(Session["UserId"].ToString()))
                    {
                        lbtnDeleteComment.Visible = true;
                    }

                    LikesBO objClass = new LikesBO();
                    objClass.AtId = hfId.Value;
                    objClass.Type = Global.WALL_COMMENT;
                    objClass.UserId = Session["UserId"].ToString();
                    bool islike = LikesBLL.youLikes(objClass);
                    if (islike)
                    {
                        
                        linkLike.Text = "Unlike";
                    }

                    else
                    {
                         
                        linkLike.Text = "Like";
                    }
                    

                }
            }
        }

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
       // LoadWall(50);

    }

    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnDeleteComment_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        // LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        CommentsBLL.deleteComments(hfId.Value);
        LoadWall(50);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      LOCATION FRIENDS WITH TAG MODULE                                         ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        WallBLL.deleteWall(hfId.Value);
        LoadWall(50);
    }

    protected void lbtnRemoveTag_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
       
        WallBLL.deleteWall(hfId.Value);
        LoadWall(50);
    }
    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        if(txtLocation.Text !="")
            lblLocation.Text = " <span class='GrayText'>in <span/>" + txtLocation.Text;
        txtLocation.Text = "";
    }
    protected void txtFriendWith_TextChanged(object sender, EventArgs e)
    {
        if( txtFriendWith.Text !="" &&  HiddenField1.Value.Length>20)
        {

            lblFriendsWith.Text += "<a   href=\"ViewProfile.aspx?UserId=" + HiddenField1.Value + "\">" + txtFriendWith.Text + "</a>,";
        txtFriendWith.Text = "";
        HiddenField1.Value = "";
        }

    }
    protected void txtFriendTag_TextChanged(object sender, EventArgs e)
    {
        if (txtFriendTag.Text != "" && HiddenFieldTagId.Value.Length > 20)
        {
            lblFriendsTag.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenFieldTagId.Value + "\">" + txtFriendTag.Text + "</a>,";
            lstTag.Add(HiddenFieldTagId.Value);
            txtFriendTag.Text = "";
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
    // To hold the prompt open you can either:
    // event.preventDefault()
    // or
    // return false;
str+="});";
//ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "alert", "$.prompt('Your Post Successfully Post !!',{buttons: { Ok:false } , show:'slideDown' });return false;", true);
    }
  
    protected void btn_Click(object sender, EventArgs e)
    {
    }
    protected void lbtnAddPhotos_Click(object sender, EventArgs e)
    {
       //showmsg("Hello");
       //MessageBox1.ShowSuccess("Success, page processed.", 1000);
       if (FileUploadPhoto.HasFile)
       {
           HttpPostedFile postedFile = FileUploadPhoto.PostedFile;
           

           try
           {
               string fileid = SavePhotos();
               generateThumbnail(postedFile, fileid);

               System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(postedFile.InputStream);
               PAB.ImageResizer.ImageResizer resizer = new PAB.ImageResizer.ImageResizer();

               if (sourceImage.Width > 1000)
               {
                   resizer.MaxHeight = sourceImage.Height / 2;
                   resizer.MaxWidth = sourceImage.Width / 2;
               }
               resizer.ImgQuality = 50;
               resizer.OutputFormat = PAB.ImageResizer.ImageFormat.Jpeg;

               byte[] bytes = resizer.Resize(postedFile);
               File.WriteAllBytes(Server.MapPath(Global.USER_PHOTOS) + @"\" + fileid + ".jpg", bytes);
               //FileUpload1.SaveAs(Server.MapPath(Global.USER_PHOTOS) + fileid + ".jpg");
               //WallPost(fileid);
               uploadedPhotoliteral = "";
               LiteralUploadPhoto.Text = "<img name='image' id='image' src='../../Resources/ThumbnailPhotos/" + fileid + ".jpg" + "'/>";
               videofileuploaded = false;
               photofileuploaded = true;
               uploadedPhotoliteral += "<br/><br/><img name='image' id='image' src='../../Resources/ThumbnailPhotos/" + fileid + ".jpg" + "'/>";
               //uploadedPhotoliteral += "<br/><br/>  <a  href=\"ViewPhoto.aspx?PhotoId=" + fileid + "\">photo</a> ";
              // LoadWall(100);
               photoid = fileid;
           }
           catch (Exception ex)
           {

           }

       }
       
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
    protected void lbtnWebCamPhoto_Click(object sender, EventArgs e)
    {
      
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      SHARE MODULE                                                  ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // To share a post
    protected void ShareLinkButton_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkShare = (LinkButton)row.FindControl("ShareLinkButton");
        Label labelShare = (Label)row.FindControl("ShareLabel");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfEmbedPost = (HiddenField)row.FindControl("HiddenFieldEmbedPost");
        Session["PostID"] = hfId.Value;
        Session["EmailPostID"] = hfId.Value;
        Session["PostType"] = hfType.Value;
        Session["EmbedPost"] = hfEmbedPost.Value;
        if (linkShare.Text == ".&nbsp;Share")
        {
           
            Response.Redirect("SharePost.aspx?Post=" + hfId.Value);

            //////// Getting the user information
            //////UserBO objUser = new UserBO();
            //////objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

            //////// Creating Share object
            //////ShareBO objClass = new ShareBO();
            //////objClass.AtId = hfId.Value;
            //////objClass.Type = Global.WALL;
            //////objClass.UserId = Session["UserId"].ToString();
            //////objClass.FirstName = objUser.FirstName;
            //////objClass.LastName = objUser.LastName;

            //////// Getting the post which is going to be shared
            //////WallBO wall = WallBLL.getWallByWallId(objClass.AtId);
            //////string p = txtUpdatePost.Text + " <br/>" + wall.Post;

            //////// Sharing the post on the wall
            //////ShareStatus(p); 

            //////// Registering the Share after successful completion of the above process
            //////ShareBLL.insertShare(objClass);

            // Sending Notifications to the one with which post has been shared and the one who were tagged

            ////////////////////////////////////////////////////////////////////////////
            // Put "follow" record for each user that has been tagged, traverse the list
            //FollowPostBO objFollow = new FollowPostBO();
            //objFollow.AtId = hfId.Value;
            //objFollow.Type = Global.WALL;
            //objFollow.UserId = Session["hello"].ToString(); //////////////////////////////////
            //objFollow.FirstName = objUser.FirstName;
            //objFollow.LastName = objUser.LastName;
            //FollowPostBLL.insertFollowPost(objFollow);
            ////////////////////////////////////////////////////////////////////////////

        }
        else
        {
            LikesBO objClass = new LikesBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString();
            LikesBLL.unLikes(objClass);
            labelShare.Text = "";
            linkShare.Text = "Like";
        }
        LoadWall(50);

    }


    protected void ShareStatus(string post)
    {
        string status = post;

        if (lblFriendsWith.Text != "")
            status += "-- with " + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));

        if (lblLocation.Text != "")
            status += lblLocation.Text;

        if (lblFriendsTag.Text != "")
            status += " and Tag to " + lblFriendsTag.Text.Remove(lblFriendsTag.Text.LastIndexOf(","));

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();

        //string temp = Session["ShareWithID"].ToString();
        //string temp = Session["ShareWithID"].ToString();

        string id = Session["hello"].ToString();

        if (Session["ShareWithID"] != null)
        {
            if (Session["ShareWithID"].ToString() != "")
            {
                objWall.WallOwnerUserId = Session["ShareWithID"].ToString();
                UserBO objFriendObj = new UserBO();
                objFriendObj = UserBLL.getUserByUserId(Session["ShareWithID"].ToString());

                // Sending notification with which the post is beind shared 
                sendEmail(objFriendObj.Email);
            }
            else
            {
                objWall.WallOwnerUserId = Session["UserId"].ToString();
                UserBO objUserEmail = new UserBO();
                objUserEmail = UserBLL.getUserByUserId(Session["UserId"].ToString());
                sendEmail(objUserEmail.Email);
            }
        }
        else
        {
            objWall.WallOwnerUserId = Session["UserId"].ToString();
            UserBO objUserEmail = new UserBO();
            objUserEmail = UserBLL.getUserByUserId(Session["UserId"].ToString());
            sendEmail(objUserEmail.Email);
        }

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
        Session["ShareWithID"] = "";
    }

    // Send Email to the email address given in the parameters
    void sendEmail(string toEmail)
    {
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

        msg.Subject = "Pyramid Plus | Notification for a post has been recieved!";
        msg.IsBodyHtml = true;

        string url = "<a  href=\"SharePost.aspx?Post=" + Session["EmailPostID"].ToString() + "\">" + "Click here to see the post." + "</a>,";

        msg.Body = "Dear Pyramid Plus user, You have got a post notification. Please see the attached link to check the post on Pyramid Plus Website. " + "<br/><br/>" + url;
        //Session["randomCode"] = randomCode;
        //generate the randomCode and place it in the c_User

        try
        {
            client.Send(msg);

        }
        catch (Exception ex)
        {
            // lblResult.ForeColor = Color.Red;
            //lblResult.Text = "Error occured while sending your message." + ex.Message + "with code " + randomCode;
        }

    }

    protected void CountShare()
    {

        foreach (GridViewRow gvr in GridViewWall.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkLike = (LinkButton)gvr.FindControl("ShareLinkButton");
                LinkButton linkShareHistory = (LinkButton)gvr.FindControl("lbtnShareHistory");
                Label labelLike = (Label)gvr.FindControl("ShareLabel");
                LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnUser");
                HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldId");

                long likecount = ShareBLL.countPost(hfId.Value, Global.WALL);
                if (likecount > 0)
                {
                    //labelLike.Text = likecount.ToString();
                    linkShareHistory.Text = likecount.ToString()+ " Shares";
                }
                else 
                {
                    linkShareHistory.Visible = false;
 
                }
            }
        }

    }

    protected void UploadPhotos_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            HttpPostedFile myFile = FileUpload1.PostedFile;
            int size = myFile.ContentLength / 1024;

            try
            {
                string fileid = SavePhotos();
                generateThumbnail(myFile, fileid);
                FileUpload1.SaveAs(Server.MapPath(Global.USER_PHOTOS) + fileid + ".jpg");
                WallPost(fileid);
                LoadWall(100);
            }
            catch (Exception ex)
            {

            }

        }
    }

    protected void UpdatePhoto()
    {
        string status = txtUpdatePost.Text;

        if (lblFriendsWith.Text != "")
            status += " with " + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));

        if (lblLocation.Text != "")
            status += lblLocation.Text;
        // if (lblFriendsTag.Text != "")

        // status += " and Tag to " + lblFriendsTag.Text.Remove(lblFriendsTag.Text.LastIndexOf(","));

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

    protected void WallPost(string photoid)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Session["UserId"].ToString();

        // Whether the wall is owned by some other person or by me

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

    protected void lbtnAlbum_Click(object sender, EventArgs e)
    {
       // pnlAddAlbum.Visible = true;
        isphotoalbum = true;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      TAG MODULE                                                  ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void TagExsitingPost_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        // LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        TextBox TagExsitingFreindsPost = (TextBox)row.FindControl("txtFriendWallTag");
        TagExsitingFreindsPost.Visible = true;

        //    Response.Redirect("~/main.aspx");
    }

    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void txtFriendWallTag_TextChanged(object sender, EventArgs e)
    {
        string tagstatus="tagged a post";
        GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfEmbedPost = (HiddenField)row.FindControl("HiddenFieldEmbedPost");
        Literal post = (Literal)row.FindControl("LiteralPost");
        TextBox TagExsitingFreindsPost = (TextBox)row.FindControl("txtFriendWallTag");
        WallBO objWall2 = new WallBO();
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());
        string tagpost = post.Text + "<br/><font color='#838181'> was Tagged by <font/> <a  href=\"ViewProfile.aspx?UserId=" + Session["UserId"].ToString() + "\">" + objUser.FirstName + " " + objUser.LastName + "</a>.";
        UserBO objUser2 = new UserBO();
        objUser2 = UserBLL.getUserByUserId(HiddenFieldWallTagId.Value);
        objWall2.PostedByUserId = HiddenFieldWallTagId.Value;
        objWall2.WallOwnerUserId = HiddenFieldWallTagId.Value;
        objWall2.FirstName = objUser2.FirstName;
        objWall2.LastName = objUser2.LastName;
        objWall2.Post = tagpost;
        objWall2.AddedDate = DateTime.Now;
        objWall2.Type = Global.TAG_POST;

        if (hfType.Value.Equals(Global.VIDEO.ToString()))
        {
            objWall2.Type = Global.TAG_VIDEO;
            objWall2.EmbedPost = Global.PATH_COMPRESSED_USER_VIDEO + "Thumb/" + uploadedvideothumbname;
            notifTag(HiddenFieldWallTagId.Value, userid);
            tagstatus = "tagged a video";
        }
        if (hfType.Value.Equals(Global.POST_VIDEOLINK.ToString()))
        {
            objWall2.Type = Global.TAG_VIDEOLINK;
            objWall2.EmbedPost = hfEmbedPost.Value;
            notifTag(HiddenFieldWallTagId.Value, userid);
            tagstatus = "tagged a video";
        }

        if (hfType.Value.Equals(Global.PHOTO.ToString()))
        {
            TagsBO objTags = new TagsBO();
            objTags.AtId = hfEmbedPost.Value;
            objTags.Type = Global.PHOTO;
            objTags.UserId = Session["UserId"].ToString();
            objTags.FirstName = objUser.FirstName;
            objTags.LastName = objUser.LastName;
            objTags.FriendId = HiddenFieldWallTagId.Value;
            objTags.FriendFName = objUser2.FirstName;
            objTags.FriendLName = objUser2.LastName;
            notifTag(HiddenFieldWallTagId.Value, hfEmbedPost.Value);
            TagsBLL.insertTags(objTags);
            objWall2.Type = Global.TAG_PHOTO;
            objWall2.EmbedPost = hfEmbedPost.Value;
            tagstatus = "tagged a photo";
        }
        RWallPost(" Tag post to <a  href=\"ViewProfile.aspx?UserId=" + HiddenFieldWallTagId.Value + "\">" + objUser2.FirstName + " " + objUser2.LastName + "</a>");
           

        string twid=WallBLL.insertWall(objWall2);
        TagExsitingFreindsPost.Visible = false;
        //Response.Redirect("~main.aspx?a=" + HiddenFieldWallTagId.Value + "b=" + aa);

        //if (txtFriendTag.Text != "" && HiddenFieldTagId.Value.Length > 20)
        //{
        //    lblFriendsTag.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenFieldTagId.Value + "\">" + txtFriendTag.Text + "</a>,";
        //    lstTag.Add(HiddenFieldTagId.Value);
        //    txtFriendTag.Text = "";
        //    HiddenFieldTagId.Value = "";
        //}

        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in listtag)
        {
            TickerBO objTicker = new TickerBO();
            objTicker.PostedByUserId = objWall2.PostedByUserId;
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objWall2.FirstName;
            objTicker.LastName = objWall2.LastName;
            objTicker.Post = objWall2.Post;
            objTicker.Title = ConvertUrlsToLinks(tagstatus);
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = objWall2.Type;
            objTicker.EmbedPost = objWall2.EmbedPost;
            objTicker.WallId = twid;
            TickerBLL.insertTicker(objTicker);
          
        }
        TickerBO objTickerUserTag = new TickerBO();


        objTickerUserTag.PostedByUserId = Session["UserId"].ToString();
        objTickerUserTag.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUserTag.FirstName = objUser.FirstName;
        objTickerUserTag.LastName = objUser.LastName;
        objTickerUserTag.Post = objWall2.Post;
        objTickerUserTag.Title = "you tag a post";
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = objWall2.Type;
        objTickerUserTag.EmbedPost = objWall2.EmbedPost;
        objTickerUserTag.WallId = twid;
        TickerBLL.insertTicker(objTickerUserTag);

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

    }


     public static string TimeAgo(DateTime date)
 {

       date=  date.AddHours(5);
     TimeSpan timeSince = DateTime.Now.Subtract(date) ;

 if (timeSince.TotalMilliseconds < 1)
 return "not yet";
 
 if (timeSince.TotalMinutes < 1)
 return "Just now";
 if (timeSince.TotalMinutes < 2)
 return "1 minute ago";
 if (timeSince.TotalMinutes < 60)
 return string.Format("{0} minutes ago", timeSince.Minutes);
 if (timeSince.TotalMinutes < 120)
 return "1 hour ago";
 if (timeSince.TotalHours < 24)
 return string.Format("{0} hours ago", timeSince.Hours);
 if (timeSince.TotalDays == 1)
 return "yesterday";
 if (timeSince.TotalDays < 7)
 return string.Format("{0} days ago", timeSince.Days);
 if (timeSince.TotalDays < 14)
 return "last week";
 if (timeSince.TotalDays < 21)
 return "2 weeks ago";
 if (timeSince.TotalDays < 28)
 return "3 weeks ago";
 if (timeSince.TotalDays < 60)
 return "last month";
 if (timeSince.TotalDays < 365)
 return string.Format("{0} months ago", Math.Round(timeSince.TotalDays / 30));
 if (timeSince.TotalDays < 730)
 return "last year";
 //last but not least...
 return string.Format("{0} years ago", Math.Round(timeSince.TotalDays / 365));
 }


     protected void lbtnOK_Click(object sender, EventArgs e)
     {

         GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
         HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
         WallBLL.deleteWall(hfId.Value);
         LoadWall(50);
         ModalPopupExtender mp = (ModalPopupExtender)row.FindControl("lnkDelete_ModalPopupExtender");
         mp.Hide();
     }
     protected void btnlargePhoto_Click(object sender, EventArgs e)
     {

         GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
         HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");

         ModalPopupExtender mp = (ModalPopupExtender)row.FindControl("ModalpopupextenderlargePhoto");
         mp.Hide();
     }

     protected void btnPostOkay_Click(object sender, EventArgs e)
     {
      
        // Post_ModalPopupExtender.Hide();

     }
    //shamsas newsfeed stuff
     protected void btnTopStories_Click(object sender, EventArgs e)
     {


     }
     protected void lbtnTopStories_Click(object sender, EventArgs e)
     {
         GridViewWall.DataSource = WallBLL.getNewsfeedByUserId(userid, 30, 1);//1 is for topstories
         GridViewWall.DataBind();



         LoadComments();
         YouLikes();
         Comment_YouLikes();
         CountShare();

     }
     protected void lbtnRecent_Click(object sender, EventArgs e)
     {
         GridViewWall.DataSource = WallBLL.getNewsfeedByUserId(userid, 30, 2);//2 is for recent
         GridViewWall.DataBind();



         LoadComments();
         YouLikes();
         Comment_YouLikes();
         CountShare();
     }
     protected void lbtnHideStory_Click(object sender, EventArgs e)
     {
         //

         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         HiddenField hfwallid = (HiddenField)clickedRow.FindControl("HiddenFieldId");
         string postedbyid = hf.Value;
         string wallid = hfwallid.Value;
         bool done = WallBLL.setPostStatus(userid, postedbyid, wallid, Global.POST_HIDDEN);
         LoadWall(50);
         int n = 0;
     }
     protected void lbtnReportStory_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         HiddenField hfwallid = (HiddenField)clickedRow.FindControl("HiddenFieldId");
         string postedbyid = hf.Value;
         string wallid = hfwallid.Value;
         bool done = WallBLL.setPostStatus(userid, postedbyid, wallid, Global.POST_SPAM);
         LoadWall(50);
         int n = 0;
     }
     protected void lbtnAllUpdates_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         HiddenField hfwallid = (HiddenField)clickedRow.FindControl("HiddenFieldId");
         string postedbyid = hf.Value;
         string wallid = hfwallid.Value;
         bool done = WallBLL.setPostUpdatesType(userid, postedbyid, Global.POST_ALL);
         LoadWall(50);


     }
     protected void lbtnMostUpdates_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         HiddenField hfwallid = (HiddenField)clickedRow.FindControl("HiddenFieldId");
         string postedbyid = hf.Value;
         string wallid = hfwallid.Value;
         bool done = WallBLL.setPostUpdatesType(userid, postedbyid, Global.POST_MOST);
         LoadWall(50);

     }
     protected void lbtnOnlyImp_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         HiddenField hfwallid = (HiddenField)clickedRow.FindControl("HiddenFieldId");
         string postedbyid = hf.Value;
         string wallid = hfwallid.Value;
         bool done = WallBLL.setPostUpdatesType(userid, postedbyid, Global.POST_ONLYIMP);
         LoadWall(50);

     }
     protected void lbtnUnSubscribeAll_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         //clickedRow.Visible = false;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         string friendid = hf.Value;
         bool done = WallBLL.Unsubscribe(userid, friendid, "All");
         LoadWall(50);

     }
     protected void lbtnUnsubscribe_Click(object sender, EventArgs e)
     {
         GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
         //clickedRow.Visible = false;
         HiddenField hf = (HiddenField)clickedRow.FindControl("HiddenFieldType");
         string type = hf.Value;
         HiddenField hf2 = (HiddenField)clickedRow.FindControl("HiddenFieldUserId");
         string friendid = hf2.Value;


         bool done = WallBLL.Unsubscribe(userid, friendid, type);
         LoadWall(50);
     }
     public string getTypeName(object myValue)
     {
         string name = "Unsubscribe to ";
         int i = (int)myValue;
         switch (i)
         {
             case 15:
                 name += "video links";
                 break;
 case 16:
                 name += "links";
                 break;

             case 6:
                 name += "text posts";
                 break;
             case 1:
                   name += "photos and albums";
                 break;
             case 3:
                  name += "photos and albums";
                 break;
             case 2:
                 name += "videos";
                 break;
             case 4:
                 name += "video albums";
                 break;

             default:
                 name = "";
                 break;



         }
         return name;
     }
     public bool getVisibilityForPost(object id)
     {
         string postedbyid = id.ToString();

         string signedinuser = Session["UserId"].ToString();
         if (signedinuser.Equals(postedbyid))
         {
             return false;
         }
         else
             return true;
     }
     public bool getcheckmarkVisibilityAll(object id)
     {
         string postedbyid = id.ToString();

         string signedinuser = Session["UserId"].ToString();
         int PostUpdatesType = WallBLL.getUpdatesType(signedinuser, postedbyid);
         if (PostUpdatesType == Global.POST_ALL || PostUpdatesType == 0)
             return true;
         else
             return false;

     }
     public bool getcheckmarkVisibilityMost(object id)
     {
         string postedbyid = id.ToString();

         string signedinuser = Session["UserId"].ToString();
         int PostUpdatesType = WallBLL.getUpdatesType(signedinuser, postedbyid);
         if (PostUpdatesType == Global.POST_MOST)
             return true;
         else
             return false;

     }
     public bool getcheckmarkVisibilityImp(object id)
     {
         string postedbyid = id.ToString();

         string signedinuser = Session["UserId"].ToString();
         int PostUpdatesType = WallBLL.getUpdatesType(signedinuser, postedbyid);
         if (PostUpdatesType == Global.POST_ONLYIMP)
             return true;
         else
             return false;

     }


     protected void GridViewWall_RowCreated(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             PopupControlExtender pce = e.Row.FindControl("PopupControlExtenderPanelWallUser") as PopupControlExtender;

             string behaviorID = "pce3_" + e.Row.RowIndex;
             pce.BehaviorID = behaviorID;

             Image img = (Image)e.Row.FindControl("Image1");

             string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
             string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

             img.Attributes.Add("onmouseover", OnMouseOverScript);
             img.Attributes.Add("onmouseout", OnMouseOutScript);
         }
     }
}