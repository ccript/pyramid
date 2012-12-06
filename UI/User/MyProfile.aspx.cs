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
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = SessionClass.getUserId();
      
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

        DListEmployer.DataSource = EmployerBLL.getEmployerTop5(Userid);
        DListEmployer.DataBind();

    }
    protected void LoadDataListProject()
    {

        DListProject.DataSource = ProjectBLL.getProjectTop5(Userid);
        DListProject.DataBind();

    }

    protected void LoadDataListUniversity()
    {

        DListUniversity.DataSource = UniversityBLL.getUniversityTop5(Userid);
        DListUniversity.DataBind();

    }
    protected void LoadDataListSchool()
    {

        DListSchool.DataSource = SchoolBLL.getSchoolTop5(Userid);
        DListSchool.DataBind();

    }
    protected void LoadDataListBooks()
    {

        DListBooks.DataSource = EntertainmentBLL.getEntertainmentTop(Global.BOOKS, Userid);
        DListBooks.DataBind();

    }
    protected void LoadDataListMusic()
    {

        DListMusic.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MUSIC, Userid);
        DListMusic.DataBind();

    }
    protected void LoadDataListMovie()
    {

        DListMovie.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MOVIE, Userid);
        DListMovie.DataBind();

    }
    protected void LoadDataListTelevision()
    {

        DListTelevision.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TELEVISION, Userid);
        DListTelevision.DataBind();

    }
    protected void LoadDataListGame()
    {

        DListGame.DataSource = EntertainmentBLL.getEntertainmentTop(Global.GAME, Userid);
        DListGame.DataBind();

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


    protected void LoadOthersEmail()
    {

        GridViewEmail.DataSource = ContactInfoBLL.getContactInfo("Email", Userid);
        GridViewEmail.DataBind();

    }

    protected void LoadWebsites()
    {

        GridViewWebsites.DataSource = ContactInfoBLL.getContactInfo("Website", Userid);
        GridViewWebsites.DataBind();

    }

    protected void LoadPhoneNumber()
    {

        GridViewPhone.DataSource = ContactInfoBLL.getContactInfo("PhoneNumber", Userid);
        GridViewPhone.DataBind();

    }

    protected void LoadContactInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Userid);


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
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(Userid);
        lblHomeTown.Text = objBasicInfo.HomeTown;
        lblCurrentCity.Text = objBasicInfo.CurrentCity;
    }

    protected void LoadLanguages()
    {
        DListLanguage.DataSource = LanguageBLL.getLanguages(Userid);
        DListLanguage.DataBind();
    }
}