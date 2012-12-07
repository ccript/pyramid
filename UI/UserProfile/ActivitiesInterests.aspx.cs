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

        Userid =  SessionClass.getUserId();
        
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
        
        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_ACTIVITY_TEXT;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);

        LoadDataListActivities();
        LoadDataListInterests();
        imgSave.Visible = true;
        lblSave.Visible = true;

    }

    protected void SaveActivities()
    {
        ActivityBO objActivity = new ActivityBO();

        objActivity.UserId = Userid;
        objActivity.Name = txtActivities.Text;

        objActivity.Description = txtActivitiesDescription.Text;
        objActivity.Type = Global.ACTIVITIES;

        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtActivities.Text + Global.PICTURE_EXTENSION_JPG)))
            objActivity.Image = txtActivities.Text + Global.PICTURE_EXTENSION_JPG;
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtActivities.Text + ".png")))
            objActivity.Image = txtActivities.Text + ".png";
        else

        objActivity.Image = "DefaultActivities.png";
        string ActivityId = ActivityBLL.insertActivity(objActivity);
       
        txtActivities.Text = "";
        txtActivitiesDescription.Text = "";
        LoadDataListActivities();
    }
    protected void SaveActivitiesWith(int ActivityId)
    {
    }
    protected void SaveInterestsWith(int InterestsId)
    {
    }
    protected void SaveInterests()
    {
        ActivityBO objActivity = new ActivityBO();

        objActivity.UserId = Userid;
        objActivity.Name = txtInterests.Text;

        objActivity.Description = txtInterestsDescription.Text;
        objActivity.Type = Global.INTERESTS;
        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtInterests.Text + ".jpg")))
            objActivity.Image = txtInterests.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtInterests.Text + ".png")))
            objActivity.Image = txtInterests.Text + ".png";
        else

        objActivity.Image = "DefaultInterests.png";
        string ActivityId = ActivityBLL.insertActivity(objActivity);
       
        txtInterests.Text = String.Empty;
        txtInterestsDescription.Text = String.Empty;
        LoadDataListInterests();
    }

    protected void LoadDataListActivities()
    {

        DListActivities.DataSource = ActivityBLL.getActivityTop5(Global.ACTIVITIES, Userid);
        DListActivities.DataBind();

    }


    protected void LoadDataListInterests()
    {

        DListInterests.DataSource = ActivityBLL.getActivityTop5(Global.INTERESTS, Userid);
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