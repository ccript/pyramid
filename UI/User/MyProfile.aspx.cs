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
public partial class MyProfile : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
      
        ((Label)Master.FindControl("lblTitle")).Text = "View Profile";
        if (!IsPostBack)
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
        }
    }

    protected void LoadDataListEmployer()
    {

        DListEmployer.DataSource = EmployerBLL.getEmployerTop5(userid);
        DListEmployer.DataBind();

    }
    protected void LoadDataListProject()
    {

        DListProject.DataSource = ProjectBLL.getProjectTop5(userid);
        DListProject.DataBind();

    }

    protected void LoadDataListUniversity()
    {

        DListUniversity.DataSource = UniversityBLL.getUniversityTop5(userid);
        DListUniversity.DataBind();

    }
    protected void LoadDataListSchool()
    {

        DListSchool.DataSource = SchoolBLL.getSchoolTop5(userid);
        DListSchool.DataBind();

    }
    protected void LoadDataListBooks()
    {

        DListBooks.DataSource = EntertainmentBLL.getEntertainmentTop(Global.BOOKS, userid);
        DListBooks.DataBind();

    }
    protected void LoadDataListMusic()
    {

        DListMusic.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MUSIC, userid);
        DListMusic.DataBind();

    }
    protected void LoadDataListMovie()
    {

        DListMovie.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MOVIE, userid);
        DListMovie.DataBind();

    }
    protected void LoadDataListTelevision()
    {

        DListTelevision.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TELEVISION, userid);
        DListTelevision.DataBind();

    }
    protected void LoadDataListGame()
    {

        DListGame.DataSource = EntertainmentBLL.getEntertainmentTop(Global.GAME, userid);
        DListGame.DataBind();

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


    protected void LoadOthersEmail()
    {

        GridViewEmail.DataSource = ContactInfoBLL.getContactInfo("Email", userid);
        GridViewEmail.DataBind();

    }

    protected void LoadWebsites()
    {

        GridViewWebsites.DataSource = ContactInfoBLL.getContactInfo("Website", userid);
        GridViewWebsites.DataBind();

    }

    protected void LoadPhoneNumber()
    {

        GridViewPhone.DataSource = ContactInfoBLL.getContactInfo("PhoneNumber", userid);
        GridViewPhone.DataBind();

    }

    protected void LoadContactInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);


        lblTownCity.Text = objBasicInfo.CityTown;
          lblAddress.Text = objBasicInfo.Address;
        lblZipCode.Text = objBasicInfo.ZipCode;
        lblNeighbourhood.Text = objBasicInfo.Neighbourhood;
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

    protected void LoadLanguages()
    {
        DListLanguage.DataSource = LanguageBLL.getLanguages(userid);
        DListLanguage.DataBind();
    }
}