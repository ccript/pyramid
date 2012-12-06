using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectLayer;
using System.Globalization;
using System.Text.RegularExpressions;
using AjaxControlToolkit;
using System.Text;
using BuinessLayer;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DataLayer;

public partial class UI_User_MasterPage : System.Web.UI.MasterPage
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if ((Session["UserId"] == null) || (String.Empty.Equals(Session["UserId"].ToString())))
            Response.Redirect("../../Default.aspx");

        try
        {
            userid = Session["UserId"].ToString();            
            if (Session["TempUserId"] == null)
            {
                imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
                LoadUserData(userid);

            }
            else
            {
                imgProfile.ImageUrl = Global.PROFILE_PICTURE + Session["TempUserId"].ToString() + ".jpg";
                LoadUserData(Session["TempUserId"].ToString());

            }
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }


        LoadListView();
        LoadFriendsList();
        LoadSuggestions();
        NotificationCount();
        LoadSeeFriendship();
        LoadTicker();        
    }

    protected void LoadUserData(string id)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(id);
        lblName.Text = objUser.FirstName + " " + objUser.LastName;
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Session.Clear();
        Response.Redirect("../../Default.aspx");
    }
    protected void imgBtnSearchFriends_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SearchUserList.aspx?Search=" + txtFriendSearch.Text);
    }

    protected void lbtnNewsFeed_Click(object sender, EventArgs e)
    {

        Response.Redirect("UserData.aspx");


    }
    protected void lbtnWall_Click(object sender, EventArgs e)
    {
        if (Session["TempUserId"] == null)
            Response.Redirect("UserData.aspx?UserId=" + Session["UserId"].ToString());
        else
            Response.Redirect("UserData.aspx?UserId=" + Session["TempUserId"].ToString());

    }
    protected void lbtnViewProfile_Click(object sender, EventArgs e)
    {
        if (Session["TempUserId"] == null)
            Response.Redirect("ViewProfile.aspx?UserId=" + userid);
        else
            Response.Redirect("ViewProfile.aspx?UserId=" + Session["TempUserId"].ToString());
    }
    protected void lbtnFriendsList_Click(object sender, EventArgs e)
    {
        if (Session["TempUserId"] == null)
            Response.Redirect("FriendsList.aspx?UserId=" + userid);
        else
            Response.Redirect("FriendsList.aspx?UserId=" + Session["TempUserId"].ToString());
    }
    protected void lbtnListMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListView.aspx");
    }
    protected void LoadListView()
    {
        ListViewGrid0.DataSource = ListViewBLL.getList(userid, Global.CONFIRMED).Take(5).ToList();
        ListViewGrid0.DataBind();
    }

    protected void NotificationCount()
    {
        // long nt = 0,newnt=0;
        // if (lblNotification.Text.Length > 0)
        //   nt = Convert.ToInt64(lblNotification.Text);

        long cnotif = Convert.ToInt64(NotificationBLL.countNotification(userid).ToString());

        lblNotification.Text = cnotif.ToString();
        if (cnotif == 000)
            lblNotification.Visible = false;
        long crequest = Convert.ToInt64(FriendsBLL.countFriendRequests(userid, Global.PENDING).ToString());
        lblFriendsRequest.Text = crequest.ToString();
        if (crequest == 000)
            lblFriendsRequest.Visible = false;
        //  newnt = Convert.ToInt64(lblNotification.Text);
        //if (newnt > nt)
        //{


        //ScriptManager.RegisterClientScriptBlock(UpdatePanel3, UpdatePanel3.GetType(), "script", "insideJS();", true);
        //}
    }
    protected void LoadFriendsList()
    {


        GridViewFriendsList.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.CONFIRMED).Take(10).ToList();
        GridViewFriendsList.DataBind();

        lbtnFriends.Text = "Friends(" + FriendsBLL.countFriends(userid, Global.CONFIRMED).ToString() + ")";
        //lbtnRequest.Text = "Requests(" + FriendsBLL.countFriendRequests(userid, Global.PENDING).ToString() + ")";

    }

    protected void LoadSeeFriendship()
    {


        GridViewSeeFriendship.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.CONFIRMED).Take(5).ToList();
        GridViewSeeFriendship.DataBind();


    }


    protected void LoadSuggestions()
    {


        List<UserFriendsBO> list = FriendsBLL.getAllSuggestions(userid).Take(4).ToList();
        List<UserFriendsBO> scoredlist = FriendsBLL.RecommendationScoring(list, userid);
        if (scoredlist.Count == 0)
        {
            GridViewSuggestions.DataSource = list;

        }
        else
        {
            GridViewSuggestions.DataSource = scoredlist;
        }
        GridViewSuggestions.DataBind();

        //lbtnFriends.Text = "Friends(" + FriendsBLL.countFriends(userid, Global.CONFIRMED).ToString() + ")";
        //lbtnRequest.Text = "Requests(" + FriendsBLL.countFriendRequests(userid, Global.PENDING).ToString() + ")";


    }
    protected void lbtnFriends_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendsList.aspx?UserId=" + userid);
    }

    protected void lbtnRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendRequests.aspx");
    }
    protected void lbtnPhotos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Photos.aspx");
    }
    protected void lbtnSuggestions_Click(object sender, EventArgs e)
    {
        Response.Redirect("Suggestions.aspx");
    }
    protected void lbtnNotification_Click(object sender, EventArgs e)
    {
        Response.Redirect("Notification.aspx");
    }
    protected void lbtnVideo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Video.aspx");
    }

    protected void LoadTicker()
    {


        GridViewTicker.DataSource = TickerBLL.getTickerByUserId(userid, 50);
        GridViewTicker.DataBind();


    }
    protected void GridViewFriendsList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PopupControlExtender pce = e.Row.FindControl("PopupControlExtenderFriendsList") as PopupControlExtender;

            string behaviorID = "pce_" + e.Row.RowIndex;
            pce.BehaviorID = behaviorID;

            Image img = (Image)e.Row.FindControl("Image1");

            string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
            string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

            img.Attributes.Add("onmouseover", OnMouseOverScript);
            img.Attributes.Add("onmouseout", OnMouseOutScript);
        }
    }
    protected void GridViewSuggestions_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PopupControlExtender pce = e.Row.FindControl("PopupControlExtenderViewSuggestions") as PopupControlExtender;

            string behaviorID = "pce2_" + e.Row.RowIndex;
            pce.BehaviorID = behaviorID;

            Image img = (Image)e.Row.FindControl("ImageSuggestions");

            string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
            string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

            img.Attributes.Add("onmouseover", OnMouseOverScript);
            img.Attributes.Add("onmouseout", OnMouseOutScript);
        }
    }
    protected void TimerTicker_Tick(object sender, EventArgs e)
    {
        // GridViewTicker.DataSource = TickerBLL.getTickerByUserId(userid, 100);
        // GridViewTicker.DataBind();
        UpdatePanelTicker.Update();
    }

    protected void GridViewTicker_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {

            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#C8CCB6';this.style.cursor='pointer'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");


        }
        foreach (TableCell cell in e.Row.Cells)

            cell.Attributes.Add("Style", "border-top: #CCCCCC 1px double");
    }

    protected void GridViewTicker_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //PopupControlExtender pce = e.Row.FindControl("PopupControlExtender1") as PopupControlExtender;

            //string behaviorID = "pce_" + e.Row.RowIndex;
            //pce.BehaviorID = behaviorID;

            //Image img = (Image)e.Row.FindControl("Image1");

            //string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
            //string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

            //img.Attributes.Add("onmouseover", OnMouseOverScript);
            //img.Attributes.Add("onmouseout", OnMouseOutScript);
        }
    }

    protected void GridViewTicker_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        if (e.CommandName == "show")
        {
            //GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;


            HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");
            ImageButton imgbtn = (ImageButton)row.FindControl("imbtnVideo");
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



                WallBLL.updateLiteral(hfId.Value, objWall.Post, embedval);


            }

        }

    }




    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      POST LIKE MODULE                                         ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    protected void YouLikes(GridViewRow gvr)
    {


        if (gvr.RowType == DataControlRowType.DataRow)
        {

            LinkButton linkLike = (LinkButton)gvr.FindControl("lbtnLike");
            Label labelLike = (Label)gvr.FindControl("lblLike");
            LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnUser");
            HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldWallId");
            HiddenField hfuserId = (HiddenField)gvr.FindControl("HiddenFieldUserId");
            HiddenField hfdate = (HiddenField)gvr.FindControl("HiddenFieldAddedDate");
            Label labeldate = (Label)gvr.FindControl("lblAddedDate");
            //  Literal literalpost = (Literal)gvr.FindControl("LiteralPost");
            //ImageButton imgbtn = (ImageButton)gvr.FindControl("ImageButton1");


            DateTime date = Convert.ToDateTime(hfdate.Value);
            labeldate.Text = TimeAgo(date);



            //if (literalpost.Text.IndexOf("width") > 0)
            //   imgbtn.Visible = false;

            long likecount = LikesBLL.countPost(hfId.Value, Global.WALL);
            if (likecount > 0)
                linkLikeCount.Text = likecount.ToString() + " Likes";
            else
                linkLikeCount.Visible = false;

            LinkButton linkcountComments = (LinkButton)gvr.FindControl("lbtnViewComments");
            long totalcomments = CommentsDAL.countComment(hfId.Value, Global.WALL); 
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
                labelLike.Text = "";
                linkLike.Text = "UnLike";
            }

            else
            {
                labelLike.Text = "";
                linkLike.Text = "Like";
            }


        }


    }

    protected void lbtnLike_Click(object sender, EventArgs e)
    {
        string statuslike = "like a post";
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        Label labelLike = (Label)row.FindControl("lblLike");
        Literal literalpost = (Literal)row.FindControl("Literal1");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");
        HiddenField hfType = (HiddenField)row.FindControl("HiddenFieldType");
        HiddenField hfEmbedPost = (HiddenField)row.FindControl("HiddenFieldEmbedTickerPost");
        PopupControlExtender pce = row.FindControl("PopupControlExtenderTicker") as PopupControlExtender;
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
            labelLike.Text = "";
            linkLike.Text = "UnLike";
            statuslike = "like a post";
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
            statuslike = "unlike a post";
        }

        pce.DataBind();

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
            objWall.Type = Global.PROFILE_CHANGE;
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
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnUser_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");


        GridView gridviewLikesUser = (GridView)row.FindControl("GridViewLikesUser");
        gridviewLikesUser.DataSource = LikesBLL.getLikesTop(Global.WALL, hfId.Value);
        gridviewLikesUser.DataBind();
        // LoadWall(50);

    }
    protected void lbtnShareHistory_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        LinkButton linkLike = (LinkButton)row.FindControl("ShareLinkButton");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");


        GridView gridviewShareHistory = (GridView)row.FindControl("GridViewShareHistory");
        gridviewShareHistory.DataSource = ShareBLL.getShareHistory(Global.WALL, hfId.Value);
        gridviewShareHistory.DataBind();
        // LoadWall(50);

    }

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
        if (linkShare.Text == "Share")
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
        

    }

    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnViewComments_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");

        GridView gridviewComments = (GridView)row.FindControl("GridViewComments");
        gridviewComments.DataSource = CommentsDAL.getCommentsTop(Global.WALL, hfId.Value, 100);
        gridviewComments.DataBind();

    }
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void TagExsitingPost_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        // LinkButton linkLike = (LinkButton)row.FindControl("lbtnLike");
        TextBox TagExsitingFreindsPost = (TextBox)row.FindControl("txtFriendWallTag");
        TagExsitingFreindsPost.Visible = true;

        //    Response.Redirect("~/main.aspx");
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");
        WallBLL.deleteWall(hfId.Value);
        HiddenField hfTId = (HiddenField)row.FindControl("HiddenFieldId");
        TickerBLL.deleteTicker(hfTId.Value);

    }
    protected void CountShare(GridViewRow gvr)
    {

            if (gvr.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkLike = (LinkButton)gvr.FindControl("ShareLinkButton");
                LinkButton linkShareHistory = (LinkButton)gvr.FindControl("lbtnShareHistory");
                Label labelLike = (Label)gvr.FindControl("ShareLabel");
                LinkButton linkLikeCount = (LinkButton)gvr.FindControl("lbtnUser");
                HiddenField hfId = (HiddenField)gvr.FindControl("HiddenFieldWallId");

                long likecount = ShareBLL.countPost(hfId.Value, Global.WALL);
                if (likecount > 0)
                {
                    //labelLike.Text = likecount.ToString();
                    linkShareHistory.Text = likecount.ToString() + " Shares";
                }
                else
                {
                    linkShareHistory.Visible = false;

                }
            
        }

    }

    protected void txtFriendWallTag_TextChanged(object sender, EventArgs e)
    {
        string tagstatus = "tagged a post";
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

       

        string twid = WallBLL.insertWall(objWall2);
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
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                      COMMENTS LIKE MODULE                                         ////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // @@@@@@@@@@@@@@@@@@@@ by Nabeel
    protected void lbtnCommentLike_Click(object sender, EventArgs e)
    {
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
            lbtnCommentLike.Text = "";
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
            objWall.Post = " Like a Comments on <a  href=\"ViewProfile.aspx?UserId=" + userid + "\">" + objFUser.FirstName + " " + objFUser.LastName + "</a> Wall Post";
            objWall.AddedDate = DateTime.Now;
            objWall.Type = Global.PROFILE_CHANGE;
            WallBLL.insertWall(objWall);
        }
        ////////////////////////////////////////


        // Response.Redirect("main.aspx?c="+hfId.Value);
    }

    protected void Comment_YouLikes(GridViewRow row)
    {


        GridView gridviewcomment = (GridView)row.FindControl("GridViewComments");

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
                    labelLike.Text = "";
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

    }
    public static string TimeAgo(DateTime date)
    {

        date = date.AddHours(5);
        TimeSpan timeSince = DateTime.Now.Subtract(date);

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
    protected void txtComments_TextChanged(object sender, EventArgs e)
    {

        GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

        TextBox txtcomments = (TextBox)row.FindControl("txtComments");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldWallId");

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Session["UserId"].ToString());

        CommentsBO objClass = new CommentsBO();
        objClass.MyComments = ConvertUrlsToLinks(txtcomments.Text);
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
            objWall.Type = Global.PROFILE_CHANGE;
            WallBLL.insertWall(objWall);
        }
        ////////////////////////////////////////
    }
    private string ConvertUrlsToLinks(string msg)
    {
        string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
        Regex r = new Regex(regex, RegexOptions.IgnoreCase);
        return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
    }

    //////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////


    protected void lbtnFeedDetail_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        PopupControlExtender pce = row.FindControl("PopupControlExtenderTicker") as PopupControlExtender;

        ImageButton imbtnPhoto = (ImageButton)row.FindControl("imbtnPhoto");
        ImageButton imbtnVideo = (ImageButton)row.FindControl("imbtnVideo");
        HiddenField hfId = (HiddenField)row.FindControl("HiddenFieldId");
        HiddenField hfWallId = (HiddenField)row.FindControl("HiddenFieldWallId");

        TickerBO objClass = new TickerBO();
        objClass = TickerBLL.getTickerByTickerId(hfId.Value);




        string sValue = hfWallId.Value;
        GridView gridviewComments = (GridView)row.FindControl("GridViewComments");
        //LinkButton btn = (LinkButton)gvr.FindControl("LinkButton2");
        WallBO objWall = new WallBO();
        objWall = WallBLL.getWallByWallId(sValue);

        if (objWall.Type == Global.PHOTO || objWall.Type == Global.TAG_PHOTO)
        {
            imbtnPhoto.ImageUrl = "../../Resources/ThumbnailPhotos/" + objClass.EmbedPost + ".jpg";
            imbtnPhoto.Visible = true;

        }
        if (objWall.Type == Global.VIDEO || objWall.Type == Global.TAG_VIDEO || objWall.Type == Global.POST_VIDEOLINK || objWall.Type == Global.TAG_VIDEOLINK)
        {

            imbtnVideo.Visible = true;

        }


        YouLikes(row);
        CountShare(row);
        gridviewComments.DataSource = CommentsDAL.getCommentsTop(Global.WALL, sValue, 2);
        gridviewComments.DataBind();
        Comment_YouLikes(row);

        pce.DataBind();

    }

    protected void lbtnHide_Click(object sender, EventArgs e)
    {
        if (lbtnHide.Text == "Hide Ticker")
        {
            PanelTicker.Visible = false;
            lbtnHide.Text = "Show Ticker";
        }
        else
        {
            PanelTicker.Visible = true;
            lbtnHide.Text = "Hide Ticker";
        }

    }


   
}



    
