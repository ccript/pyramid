using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BuinessLayer;
using ObjectLayer;
public partial class ActivitiesInterests : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgSave.Visible = false;
        lblSave.Visible = false;
        
        try
        {
            userid =Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        ((Label)Master.FindControl("lblTitle")).Text = "Activities & Interests";
        if (!IsPostBack)
        {
         
            LoadDataListActivities();
            LoadDataListInterests();
     
        }


        if (lstActivitiesFriend.Items.Count == 1)
            lstActivitiesFriend.Visible = false;
        else
            lstActivitiesFriend.Visible = true;


        if (lstInterestsFriend.Items.Count == 1)
            lstInterestsFriend.Visible = false;
        else
            lstInterestsFriend.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        SaveActivities();
        SaveInterests();
        WallPost("Changed Activities & Interests" );
        LoadDataListActivities();
        LoadDataListInterests();
        imgSave.Visible = true;
        lblSave.Visible = true;

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
    protected void SaveActivities()
    {
        ActivityBO objClass = new ActivityBO();

        objClass.UserId = userid;
        objClass.Name = txtActivities.Text;

        objClass.Description = txtActivitiesDescription.Text;
        objClass.Type = Global.ACTIVITIES;

        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtActivities.Text + ".jpg")))
            objClass.Image = txtActivities.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtActivities.Text + ".png")))
            objClass.Image = txtActivities.Text + ".png";
        else
  
        objClass.Image = "DefaultActivities.png";
        string ActivityId = ActivityBLL.insertActivity(objClass);
        //if (ActivityId != null && lstActivitiesFriend.SelectedValue != null)
       // SaveActivitiesWith(ActivityId);
        txtActivities.Text = "";
        txtActivitiesDescription.Text = "";
        LoadDataListActivities();
    }
    protected void SaveActivitiesWith(int ActivityId)
    {
       /* if (lstActivitiesFriend.SelectedValue != "-1")
        {
            ActivityWithBO objActivityWith = new ActivityWithBO();

            objActivityWith.UserId = userid;
            objActivityWith.ActivityId = ActivityId;

            objActivityWith.FriendUserId = Convert.ToInt32(lstActivitiesFriend.SelectedValue);

            ActivityWithBLL.insertActivityWith(objActivityWith);
            LoadDataListActivities();
        }*/
    }
    protected void SaveInterestsWith(int InterestsId)
    {

       /* if (lstInterestsFriend.SelectedValue != "-1")
        {
            InterestsWithBO objInterestsWith = new InterestsWithBO();

            objInterestsWith.UserId = userid;
            objInterestsWith.InterestsId = InterestsId;

            objInterestsWith.FriendUserId = Convert.ToInt32(lstInterestsFriend.SelectedValue);

            InterestsWithBLL.insertInterestsWith(objInterestsWith);
            LoadDataListActivities();
        }*/
    }
    protected void SaveInterests()
    {
        ActivityBO objClass = new ActivityBO();

        objClass.UserId = userid;
        objClass.Name = txtInterests.Text;

        objClass.Description = txtInterestsDescription.Text;
        objClass.Type = Global.INTERESTS;
        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtInterests.Text + ".jpg")))
            objClass.Image = txtInterests.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtInterests.Text + ".png")))
            objClass.Image = txtInterests.Text + ".png";
        else

        objClass.Image = "DefaultInterests.png";
        string ActivityId = ActivityBLL.insertActivity(objClass);
        //if (InterestsId != -1 )
       // SaveInterestsWith(InterestsId);
        txtInterests.Text = "";
        txtInterestsDescription.Text = "";
        LoadDataListInterests();
    }

    protected void LoadDataListActivities()
    {

        DListActivities.DataSource = ActivityBLL.getActivityTop5(Global.ACTIVITIES, userid);
        DListActivities.DataBind();

    }


    protected void LoadDataListInterests()
    {

        DListInterests.DataSource = ActivityBLL.getActivityTop5(Global.INTERESTS, userid);
        DListInterests.DataBind();

    }
   

    protected void DListActivities_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActivityBLL.deleteActivity(DListActivities.DataKeys[DListActivities.SelectedIndex].ToString());
        LoadDataListActivities();
    }
    protected void DListInterests_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActivityBLL.deleteActivity(DListInterests.DataKeys[DListInterests.SelectedIndex].ToString());
        LoadDataListInterests();
    }
    protected void lbtnAddInterestsPeople_Click(object sender, EventArgs e)
    {

    }
}