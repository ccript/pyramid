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
        ((Label)Master.FindControl("lblTitle")).Text = Global.FRIEND_AND_FAMILY;
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

        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_CHANGED_ENTERTAINMENT;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);
    }

    protected void saveRelationshipStatus()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo.UserId = Userid;
        objBasicInfo.RelationshipStatus = lstRelationshipStatus.SelectedValue;
        BasicInfoBLL.updateFamilyPage(objBasicInfo);        
        LoadBasicInfo();
    }
    protected void LoadFriendsList()
    {
        DataListFriends.DataSource = FriendsBLL.getAllFriendsListName(Userid, Global.CONFIRMED);
        DataListFriends.DataBind();
    }
}