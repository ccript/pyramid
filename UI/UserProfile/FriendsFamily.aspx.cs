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
public partial class FriendsFamily : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        imgSave.Visible = false;
        lblSave.Visible = false;

        Userid = SessionClass.getUserId();
        ((Label)Master.FindControl("lblTitle")).Text = "Friends and Family";
        if (!IsPostBack)
        {


            LoadBasicInfo();
            LoadFriendsList();
        }

        if (lstFriends.Items.Count == 1)
            lstFriends.Visible = false;
        else
            lstFriends.Visible = true;
    }

    protected void LoadBasicInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Userid);
        lstRelationshipStatus.SelectedValue = objBasicInfo.RelationshipStatus;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {       
        saveRelationshipStatus();
        imgSave.Visible = true;
        lblSave.Visible = true;
        WallPost("Changed Relationship Status");

        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_CHANGED_ENTERTAINMENT;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);

    }

    protected void WallPost(string post)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Userid;
        objWall.WallOwnerUserId = Userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.PROFILE_CHANGE;
        string wid=WallBLL.insertWall(objWall);
        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in listtag)
        {
            TickerBO objTicker = new TickerBO();


            objTicker.PostedByUserId = objWall.PostedByUserId;
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objWall.FirstName;
            objTicker.LastName = objWall.LastName;
            objTicker.Post = objWall.Post;
            objTicker.Title = objWall.Post;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = objWall.Type;
            objTicker.EmbedPost = objWall.EmbedPost;
            objTicker.WallId = wid;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUserTag = new TickerBO();


        objTickerUserTag.PostedByUserId = Session["UserId"].ToString();
        objTickerUserTag.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUserTag.FirstName = objUser.FirstName;
        objTickerUserTag.LastName = objUser.LastName;
        objTickerUserTag.Post = objWall.Post;
        objTickerUserTag.Title = objWall.Post;
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = objWall.Type;
        objTickerUserTag.EmbedPost = objWall.EmbedPost;
        objTickerUserTag.WallId = wid;
        TickerBLL.insertTicker(objTickerUserTag);

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

    }

    protected void saveRelationshipStatus()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();

        objBasicInfo.UserId = Userid;
        objBasicInfo.RelationshipStatus = lstRelationshipStatus.SelectedValue;

        BasicInfoBLL.updateFamilyPage(objBasicInfo);
        // BasicInfoBLL.updateTownCity(txtCurrentCity.Text, txtHometown.Text, 1);
        LoadBasicInfo();

    }
    protected void LoadFriendsList()
    {


        DataListFriends.DataSource = FriendsBLL.getAllFriendsListName(Userid, Global.CONFIRMED);
        DataListFriends.DataBind();



    }
}