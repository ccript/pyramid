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
using System.Net;
using DataLayer;


public partial class UI_User_SeeFriend : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    private string location;

    public string Location
    {
        get { return location; }
        set { location = value; }
    }
    private string friendswith;

    public string Friendswith
    {
        get { return friendswith; }
        set { friendswith = value; }
    }
    int totaltop;
    string friendID;

    List<string> emailList = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FriendID"] != null)
        {
            if (Session["FriendID"].ToString() != "")
            {
                friendID = Session["FriendID"].ToString();
            }
        }
        Userid = SessionClass.getUserId(); ;
        ((Label)Master.FindControl("lblTitle")).Text = "See Friendship";
        if (!IsPostBack)
        {
            LoadFriendsList();
            LoadBasicInfo();
            LoadLanguages();
            LoadUserData();
            LoadDataListTagPhotos();
            LoadWall(100);
            YouLikes();
            Comment_YouLikes();
        }


    }

    protected void LoadFriendsList()
    {

        GridViewFriendsList.DataSource = FriendsBLL.getMutualFriends(Userid, friendID, Global.CONFIRMED).Take(10).ToList();
        GridViewFriendsList.DataBind();
    }

    protected void LoadUserData()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);
        lblName.Text = objUser.FirstName + " " + objUser.LastName;
        UserBO objFriend = null;

        if (Session["FriendID"] != null)
        {
            if (Session["FriendID"].ToString() != "")
            {
                objFriend = new UserBO();
                objFriend = UserBLL.getUserByUserId(Session["FriendID"].ToString());

                lblFriendName.Text = objFriend.FirstName + " " + objFriend.LastName;
            }
        }

        lblBirthDay.Text = objUser.DateOfBirth.ToLongDateString() + " and " + objFriend.DateOfBirth.ToLongDateString();
        lblGender.Text = objUser.Gender + " and " + objFriend.Gender;
        
    }

    protected void LoadDataListTagPhotos()
    {

        DataListTagPhotos.DataSource = TagsBLL.getTagsListbyFriendsId(Global.PHOTO, Userid).Take(5).ToList();
        DataListTagPhotos.DataBind();

    }
    protected void LoadBasicInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Userid);

        BasicInfoBO objFriendBasicInfo = null;

        if (Session["FriendID"] != null)
        {
            if (Session["FriendID"].ToString() != "")
            {
                objFriendBasicInfo = new BasicInfoBO();
                objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Session["FriendID"].ToString());
            }
        }

        if (objFriendBasicInfo.HomeTown != null)
            lblHomeTown.Text = objBasicInfo.HomeTown + " and " + objFriendBasicInfo.HomeTown;
        else
            lblHomeTown.Text = objBasicInfo.HomeTown;

        if (objFriendBasicInfo.CurrentCity != null)
            lblCurrentCity.Text = objBasicInfo.CurrentCity + " and " + objFriendBasicInfo.CurrentCity;
        else
            lblCurrentCity.Text = objBasicInfo.CurrentCity;

    }
    protected void LoadUser()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Userid);
        lblHomeTown.Text = objBasicInfo.HomeTown;
        lblCurrentCity.Text = objBasicInfo.CurrentCity;
    }
    protected void LoadLanguages()
    {
        DListLanguage.DataSource = LanguageBLL.getLanguages(Userid);
        DListLanguage.DataBind();
    }


    protected void btnAddAsFriend_Click(object sender, EventArgs e)
    {
        btnAddAsFriend.Visible = false;
        btnAddAsFriend.Enabled = false;
        lblFriendRequestSent.Visible = true;
        string friendId = Userid;
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
        string friendId = Userid;
        string userId = Session["UserId"].ToString();
        FriendsBLL.cancelFriendRequest(userId, friendId);


    }
    protected void btnSuggestFriends_Click(object sender, EventArgs e)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);
        lblName.Text = objUser.FirstName + " " + objUser.LastName;
        Response.Redirect("SuggestFriends.aspx?FriendFName=" + objUser.FirstName + "&FriendLName=" + objUser.LastName);
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        UpdateStatus();

    }

    protected void UpdateStatus()
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
        objWall.WallOwnerUserId = Userid;
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
    protected void LoadWall(int top)
    {

        GridViewWall.DataSource = WallBLL.getWallByUserIdAndFriendID(Userid, friendID, top);
        GridViewWall.DataBind();
        
        LoadComments();
        YouLikes();
        CountShare();
        Comment_YouLikes();
    
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
    protected void LoadComments()
    {

        foreach (GridViewRow gvr in GridViewWall.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbutton = ((ImageButton)gvr.FindControl("imgCommentsUser"));
                string sValue = ((HiddenField)gvr.FindControl("HiddenFieldId")).Value;
                GridView gridviewComments = (GridView)gvr.FindControl("GridViewComments");

                gridviewComments.DataSource = CommentsDAL.getCommentsTop(Global.WALL, sValue, 2);
                gridviewComments.DataBind();
                imgbutton.ImageUrl = Global.PROFILE_PICTURE + Session["UserId"].ToString() + ".jpg";
                imgbutton.PostBackUrl = "ViewProfile.aspx?UserId=" + Session["UserId"].ToString();

            }
        }

    }
    protected void GridViewWall_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    protected void GridViewWall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewWall.PageIndex = e.NewPageIndex;
        LoadWall(50);
    }


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

                long likecount = LikesBLL.countPost(hfId.Value, Global.WALL);
                if (likecount > 0)
                    linkLikeCount.Text = likecount.ToString() + " Users";
                else
                    linkLikeCount.Visible = false;

                LinkButton linkcountComments = (LinkButton)gvr.FindControl("lbtnViewComments");
                long totalcomments = CommentsDAL.countComment(hfId.Value, Global.WALL);
                if (totalcomments > 2)
                    linkcountComments.Text = "View All " + totalcomments.ToString() + " Comments";
                else
                    linkcountComments.Visible = false;
                LikesBO objClass = new LikesBO();
                objClass.AtId = hfId.Value;
                objClass.Type = Global.WALL;
                objClass.UserId = Session["UserId"].ToString();
                bool islike = LikesBLL.youLikes(objClass);
                if (islike)
                {
                    labelLike.Text = "You Like This";
                    linkLike.Text = "UnLike";
                }

                else
                {
                    labelLike.Text = "";
                    linkLike.Text = "Like";
                }


            }
        }

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

        if (linkShare.Text == "Share")
        {

            //

            UserBO objUser = new UserBO();
            objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

            ShareBO objClass = new ShareBO();
            objClass.AtId = hfId.Value;
            objClass.Type = Global.WALL;
            objClass.UserId = Session["UserId"].ToString();
            objClass.FirstName = objUser.FirstName;
            objClass.LastName = objUser.LastName;
            ShareBLL.insertShare(objClass);

            ////////////////////////////////////////////////////////////////////////////
            // Put "follow" record for each user that has been tagged, traverse the list
            FollowPostBO objFollow = new FollowPostBO();
            objFollow.AtId = hfId.Value;
            objFollow.Type = Global.WALL;
            objFollow.UserId = Session["hello"].ToString();
            objFollow.FirstName = objUser.FirstName;
            objFollow.LastName = objUser.LastName;
            FollowPostBLL.insertFollowPost(objFollow);
            ////////////////////////////////////////////////////////////////////////////

            labelShare.Text = "You have shared this.";
            WallBO wall = WallBLL.getWallByWallId(objClass.AtId);
            string p = ShareDescriptionTextBox.Text + " <br/>" + wall.Post;
            ShareStatus(p);
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
            status += " with " + lblFriendsWith.Text.Remove(lblFriendsWith.Text.LastIndexOf(","));

        if (lblLocation.Text != "")
            status += lblLocation.Text;
        // if (lblFriendsTag.Text != "")

        // status += " and Tag to " + lblFriendsTag.Text.Remove(lblFriendsTag.Text.LastIndexOf(","));

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

        msg.Subject = "Pyramid Plus | Someone has shared a post with you!";
        msg.IsBodyHtml = true;

        msg.Body = "Dear Pyramid Plus user, You have got a post on your wall. ";
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
                Label labelLike = (Label)gvr.FindControl("ShareLabel");
                //LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnUser");
                HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldId");

                long likecount = ShareBLL.countPost(hfId.Value, Global.WALL);

                labelLike.Text = likecount.ToString();
            }
        }

    }

    //protected void lbtnLike_Click(object sender, EventArgs e)
    //{

    //    GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
    //    LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
    //    Label labelLike = (Label)row.FindControl("lblLike");
    //    HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");



    //    if (linkLike.Text == "Like")
    //    {
    //        UserBO objUser = new UserBO();
    //        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());
    //        LikesBO objClass = new LikesBO();
    //        objClass.AtId = hfId.Value;
    //        objClass.Type = Global.WALL;
    //        objClass.UserId = Session["UserId"].ToString();
    //        objClass.FirstName = objUser.FirstName;
    //        objClass.LastName = objUser.LastName;
    //        LikesBLL.insertLikes(objClass);
    //        labelLike.Text = "You Like this";
    //        linkLike.Text = "UnLike";

    //    }
    //    else
    //    {
    //        LikesBO objClass = new LikesBO();
    //        objClass.AtId = hfId.Value;
    //        objClass.Type = Global.WALL;
    //        objClass.UserId = Session["UserId"].ToString();
    //        LikesBLL.unLikes(objClass);
    //        labelLike.Text = "";
    //        linkLike.Text = "Like";
    //    }
    //    LoadWall(50);

    //}
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
        // 
        // Comment_YouLikes();

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
                    long likecount = LikesBLL.countPost(hfId.Value, Global.WALL_COMMENT);
                    if (likecount > 0)
                        linkLikeCount.Text = likecount.ToString() + " Users";
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
                        labelLike.Text = "You Like This";
                        linkLike.Text = "UnLike";
                    }

                    else
                    {
                        labelLike.Text = "";
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
        CommentsDAL.deleteComments(hfId.Value);
        LoadWall(50);
    }



    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        if (txtLocation.Text != "")
            lblLocation.Text = " in " + txtLocation.Text;
        txtLocation.Text = "";
    }

    protected void txtFriendWith_TextChanged(object sender, EventArgs e)
    {
        if (txtFriendWith.Text != "" && HiddenField1.Value.Length > 20)
        {

            lblFriendsWith.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenField1.Value + "\">" + txtFriendWith.Text + "</a>,";

            emailList.Add(HiddenField1.Value);

            Session["hello"] = HiddenField1.Value;

            txtFriendWith.Text = "";
            HiddenField1.Value = "";
        }

    }
    protected void txtFriendTag_TextChanged(object sender, EventArgs e)
    {
        if (txtFriendTag.Text != "" && HiddenFieldTagId.Value.Length > 20)
        {
            lblFriendsTag.Text += "<a  href=\"ViewProfile.aspx?UserId=" + HiddenFieldTagId.Value + "\">" + txtFriendTag.Text + "</a>,";
            Session["ShareWithID"] = HiddenFieldTagId.Value;
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

        str += " jqi.bind('promptsubmit', function(event, val, msg, fields){";
        // To hold the prompt open you can either:
        // event.preventDefault()
        // or
        // return false;
        str += "});";
        //ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "alert", "$.prompt('Your Post Successfully Post !!',{buttons: { Ok:false } , show:'slideDown' });return false;", true);
    }

    protected void btn_Click(object sender, EventArgs e)
    {
    }
    protected void lbtnAddPhotos_Click(object sender, EventArgs e)
    {
        showmsg("Hello");



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
        objWall.WallOwnerUserId = Userid;
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

    void showUploadPhotoControl()
    {
        FileUpload1.Visible = true;
        UploadButton.Visible = true;
        PhotoLabel.Visible = true;
        ShareDescriptionTextBox.Visible = true;
    }

    void hideUploadPhotoControl()
    {
        FileUpload1.Visible = false;
        UploadButton.Visible = false;
        PhotoLabel.Visible = false;
        ShareDescriptionTextBox.Visible = false;
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
            objAClass.UserId = Userid;
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
                objWall.WallOwnerUserId = Userid;
                objWall.Type = Global.TEXT_POST;
            }
        }
        catch
        {
            objWall.WallOwnerUserId = Userid;
            objWall.Type = Global.TEXT_POST;
        }

        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;

        if (ShareDescriptionTextBox.Text != "")
            objWall.Post = "added a new photo <br/>" + ShareDescriptionTextBox.Text + " </br></br><a href='ViewPhoto.aspx?PhotoId=" + photoid + "'><img src='../../Resources/ThumbnailPhotos/" + photoid + ".jpg' width='150' height='150' border='0' alt='No Image'/> <a/>";
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
}