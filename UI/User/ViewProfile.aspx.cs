using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BuinessLayer;
using ObjectLayer;
using System.Globalization;
public partial class ViewProfile : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            
            if (Request.QueryString.Count == 0)
            {

                    btnAddAsFriend.Visible = false;
                    btnCancelRequest.Visible = false;
                    userid = Session["UserId"].ToString();
                    Session["TempUserId"] = null;
                   
            }
            else
            {
                userid = Request.QueryString.Get(0);
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
                {
                    btnAddAsFriend.Visible = false;
                    lblsub.Visible = false;
                }
               
          
            }
            ((Image)Master.FindControl("imgProfile")).ImageUrl = "../UserProfile/profileimages/" + userid + ".jpg";


        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
      
        ((Label)Master.FindControl("lblTitle")).Text = "View Profile";


        if (!IsPostBack)
        {

            LoadAllData();

        }
           // ((Image)Master.FindControl("imgProfile")).ImageUrl = Global.PROFILE_PICTURE + userid + "2.jpg";
        
       
    }


    protected void LoadAllData()
    {
        LoadDataListEmployer();
        LoadDataListProject();
        LoadDataListUniversity();
        LoadDataListSchool();
        LoadDataListBooks();
        LoadDataListMusic();
        LoadDataListMovie();
        LoadDataListTelevision();
        LoadDataListGame();
        LoadDataListActivities();
        LoadDataListInterests();
        LoadContactInfo();
        LoadPhoneNumber();
        LoadOthersEmail();
        LoadWebsites();
        LoadBasicInfo();
        LoadLanguages();
        LoadUserData();
        LoadDataListSports();
        LoadDataListTeam();
        LoadDataListAthelete();
        LoadSubscription();
        imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
    }

    protected void LoadSubscription()
    {
        string FriendId = Session["TempUserId"].ToString();
        string UserId = Session["UserId"].ToString();
        SubscriptionsBO sbo = WallBLL.getSubscriptions(UserId, FriendId);
           if (sbo.Links == 0)
            CheckBoxList1.Items.FindByValue("Links").Selected = true;
        if (sbo.Photos == 0)
            CheckBoxList1.Items.FindByValue("Photos").Selected = true;
        if (sbo.Status == 0)
            CheckBoxList1.Items.FindByValue("Status").Selected = true;
        if (sbo.VideoLinks == 0)
            CheckBoxList1.Items.FindByValue("VideoLinks").Selected = true;
        if (sbo.Videos == 0)
            CheckBoxList1.Items.FindByValue("Videos").Selected = true;
    }

    protected void LoadUserData()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
        lblName.Text = objUser.FirstName+" "+objUser.LastName;
        lblBirthDay.Text= objUser.DateOfBirth.ToLongDateString();
        lblGender.Text = objUser.Gender;

    }
    protected void LoadDataListEmployer()
    {

        DListEmployer.DataSource = EmployerBLL.getEmployerTop5(userid);
        DListEmployer.DataBind();
        if (DListEmployer.Items.Count <= 0)
        {
            lblEmployer.Visible = false;
            DListEmployer.Visible = false;
        }

    }
    protected void LoadDataListProject()
    {

        DListProject.DataSource = ProjectBLL.getProjectTop5(userid);
        DListProject.DataBind();
        if (DListProject.Items.Count <= 0)
        {
            lblProjects.Visible = false;
            DListProject.Visible = false;
        }
    }

    protected void LoadDataListUniversity()
    {

        DListUniversity.DataSource = UniversityBLL.getUniversityTop5(userid);
        DListUniversity.DataBind();
        if (DListUniversity.Items.Count <= 0)
        {
            lblUniversity.Visible = false;
            DListUniversity.Visible = false;
        }

    }
    protected void LoadDataListSchool()
    {

        DListSchool.DataSource = SchoolBLL.getSchoolTop5(userid);
        DListSchool.DataBind();
        if (DListSchool.Items.Count <= 0)
        {
            lblSchool.Visible = false;
            DListSchool.Visible = false;
        }

    }
    protected void LoadDataListBooks()
    {

        DListBooks.DataSource = EntertainmentBLL.getEntertainmentTop(Global.BOOKS, userid);
        DListBooks.DataBind();
        if (DListBooks.Items.Count <= 0)
        {
            lblBooks.Visible = false;
            DListBooks.Visible = false;
        }

    }
    protected void LoadDataListMusic()
    {

        DListMusic.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MUSIC, userid);
        DListMusic.DataBind();
        if (DListMusic.Items.Count <= 0)
        {
            lblMusic.Visible = false;
            DListMusic.Visible = false;
        }

    }
    protected void LoadDataListMovie()
    {

        DListMovie.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MOVIE, userid);
        DListMovie.DataBind();
        if (DListMovie.Items.Count <= 0)
        {
            lblMovies.Visible = false;
            DListMovie.Visible = false;
        }

    }
    protected void LoadDataListTelevision()
    {

        DListTelevision.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TELEVISION, userid);
        DListTelevision.DataBind();
        if (DListTelevision.Items.Count <= 0)
        {
            lblTelevision.Visible = false;
            DListTelevision.Visible = false;
        }

    }
    protected void LoadDataListGame()
    {

        DListGame.DataSource = EntertainmentBLL.getEntertainmentTop(Global.GAME, userid);
        DListGame.DataBind();
        if (DListGame.Items.Count <= 0)
        {
            lblGame.Visible = false;
            DListGame.Visible = false;
        }

    }

    protected void LoadDataListActivities()
    {

        DListActivities.DataSource = ActivityBLL.getActivityTop5(Global.ACTIVITIES, userid);
        DListActivities.DataBind();
        if (DListActivities.Items.Count <= 0)
        {
            lblActivities.Visible = false;
            DListActivities.Visible = false;
        }
    }


    protected void LoadDataListInterests()
    {

        DListInterests.DataSource = ActivityBLL.getActivityTop5(Global.INTERESTS, userid);
        DListInterests.DataBind();
        if (DListInterests.Items.Count <= 0)
        {
            lblInterests.Visible = false;
            DListInterests.Visible = false;
        }

    }


    protected void LoadOthersEmail()
    {

        GridViewEmail.DataSource = ContactInfoBLL.getContactInfo("Email", userid);
        GridViewEmail.DataBind();
        if (GridViewEmail.Rows.Count <= 0)
        {
            lblOthersEmails.Visible = false;
            GridViewEmail.Visible = false;
        }

    }

    protected void LoadWebsites()
    {

        GridViewWebsites.DataSource = ContactInfoBLL.getContactInfo("Website", userid);
        GridViewWebsites.DataBind();
        if (GridViewWebsites.Rows.Count <= 0)
        {
            lblWebsitesLabel.Visible = false;
            GridViewWebsites.Visible = false;
        }

    }

    protected void LoadPhoneNumber()
    {

        GridViewPhone.DataSource = ContactInfoBLL.getContactInfo("PhoneNumber", userid);
        GridViewPhone.DataBind();
        if (GridViewPhone.Rows.Count <= 0)
        {
            lblPhoneNumbers.Visible = false;
            GridViewPhone.Visible = false;
        }

    }

    protected void LoadDataListSports()
    {

        DListSports.DataSource = EntertainmentBLL.getEntertainmentTop(Global.SPORTS, userid);
        DListSports.DataBind();
        if (DListSports.Items.Count <= 0)
        {
            lblSports.Visible = false;
            DListSports.Visible = false;
        }
    }
    protected void LoadDataListTeam()
    {

        DListTeam.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TEAM, userid);
        DListTeam.DataBind();
        if (DListTeam.Items.Count <= 0)
        {
            lblTeam.Visible = false;
            DListTeam.Visible = false;
        }

    }
    protected void LoadDataListAthelete()
    {

        DListAthelete.DataSource = EntertainmentBLL.getEntertainmentTop(Global.ATHELETE, userid);
        DListAthelete.DataBind();
        if (DListAthelete.Items.Count <= 0)
        {
            lblAthelete.Visible = false;
            DListAthelete.Visible = false;
        }

    }
    protected void LoadContactInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);


        lblTownCity.Text = objBasicInfo.CityTown;
        if (lblTownCity.Text == "")
        {
            lblTownCity.Visible = false;
            lblTownCiylabel.Visible = false;
        }
        lblAddress.Text = objBasicInfo.Address;
        if (lblAddress.Text == "")
        {
            lblAddress.Visible = false;
            lblAddressLabel.Visible = false;
        }
        lblZipCode.Text = objBasicInfo.ZipCode;
        if (lblZipCode.Text == "")
        {
            lblZipCode.Visible = false;
            lblZipCodeLabel.Visible = false;
        }
        lblNeighbourhood.Text = objBasicInfo.Neighbourhood;
        if (lblNeighbourhood.Text == "")
        {
            lblNeighbourhood.Visible = false;
            lblNeighbourhoodLabel.Visible = false;
        }
        lblRelationshipStatus.Text = objBasicInfo.RelationshipStatus;
        //UserBO userObj= new UserBO();
        // userObj = UserBLL.getUserByUserId(userid);
        // txtPrimaryEmail.Text = userObj.Email;

    }

    protected void LoadBasicInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);
        lblHomeTown.Text = objBasicInfo.HomeTown;
  
        lblCurrentCity.Text = objBasicInfo.CurrentCity;
  
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
        {
            lblLanguages.Visible = false;
            DListLanguage.Visible = false;
        }
    }


    protected void btnAddAsFriend_Click(object sender, EventArgs e)
    {
        btnAddAsFriend.Visible = false;
        btnAddAsFriend.Enabled = false;
        lblFriendRequestSent.Visible = true;
        string friendId = userid;
        string userId = Session["UserId"].ToString();
        FriendsBLL.sendFriendRequest(userId, friendId);
        UserBLL userbll = new UserBLL();
        userbll.registerSubscriber(friendId, userId);
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
    protected void btnSubSave_Click(object sender, EventArgs e)
    {
        string FriendId = Session["TempUserId"].ToString();
        string UserId = Session["UserId"].ToString();
        SubscriptionsBO sbo = new SubscriptionsBO();

        //sbo.All = CheckBoxList1.Items.FindByValue("All").Selected == true ? 0 : 1;

        sbo.Links = CheckBoxList1.Items.FindByValue("Links").Selected == true ? 0 : 1;

        sbo.Photos = CheckBoxList1.Items.FindByValue("Photos").Selected == true ? 0 : 1;

        sbo.Status = CheckBoxList1.Items.FindByValue("Status").Selected == true ? 0 : 1;

        sbo.VideoLinks = CheckBoxList1.Items.FindByValue("VideoLinks").Selected == true ? 0 : 1;

        sbo.Videos = CheckBoxList1.Items.FindByValue("Videos").Selected == true ? 0 : 1;

        WallBLL.saveSubscriptions(UserId, FriendId, sbo);

    }
}