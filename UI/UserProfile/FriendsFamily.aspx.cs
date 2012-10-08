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
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgSave.Visible = false;
        lblSave.Visible = false;
       
        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
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
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);
        lstRelationshipStatus.SelectedValue = objBasicInfo.RelationshipStatus;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
       /* if (lstFriends.SelectedValue != "" && lstRelation.SelectedValue != "")
        {

            FamilyBO familyObj = new FamilyBO();
            familyObj.UserId = userid;
            familyObj.FriendUserId = Convert.ToInt32(lstFriends.SelectedValue);
            familyObj.Relation = lstRelation.SelectedValue;
            familyObj.AcceptStatus = false;

            FamilyBLL.insertFamily(familyObj);
        }*/
        saveRelationshipStatus();
        imgSave.Visible = true;
        lblSave.Visible = true;
        WallPost("Changed Relationship Status");
    }

    protected void WallPost(string post)
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

        objBasicInfo.UserId = userid;
        objBasicInfo.RelationshipStatus = lstRelationshipStatus.SelectedValue;

        BasicInfoBLL.updateFamilyPage(objBasicInfo);
        // BasicInfoBLL.updateTownCity(txtCurrentCity.Text, txtHometown.Text, 1);
        LoadBasicInfo();

    }
    protected void LoadFriendsList()
    {


        DataListFriends.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.CONFIRMED);
        DataListFriends.DataBind();



    }
}