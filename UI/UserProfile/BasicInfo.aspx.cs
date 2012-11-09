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
using System.Collections.Generic;
using System.Xml.Linq;
using BuinessLayer;
using ObjectLayer;
using DataLayer;
using System.Globalization;
public partial class BasicInfoPage : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        imgSave.Visible = false;
        lblSave.Visible = false;
        ((Label)Master.FindControl("lblTitle")).Text = "Basic Information";
     
        if (!IsPostBack)
        {
          
            LoadBasicInfo();
            LoadUserInfo();
            //Populate Start DropDownLists
             if (Session["UserId"] != null)
             {
                 lstMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                 {
                     MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a),

                     MonthNumber = a
                 });
                 lstMonth.DataBind();
                 lstYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
                 lstYear.DataBind();
                 lstDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstMonth.SelectedValue)));
                 lstDay.DataBind();

                 lstMonth.Visible = true;
                 lstDay.Visible = true;
                 lstYear.Visible = true;
             }
                
            // Hide dropdown if there is no data in them
             if (lstMonth.Items.Count == 0)
                 lstMonth.Visible = false;
             if (lstDay.Items.Count == 0)
                 lstDay.Visible = false;
             if (lstYear.Items.Count == 0)
                 lstYear.Visible = false;
             if (Session["lstDate"] != null)
                 lstDay.SelectedValue = Session["lstDate"].ToString();
          
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        int year = Convert.ToInt32(lstYear.SelectedValue);
        int month = Convert.ToInt32(lstMonth.SelectedValue);
        int day = Convert.ToInt32(lstDay.SelectedValue);
        DateTime birthDate = new DateTime(year, month, day);
        DateTime now = DateTime.Today;
        int age = now.Year - Convert.ToInt32(lstYear.SelectedValue);
        if (now < birthDate.AddYears(age)) age--;

        if (age < 13)
            CustomValidator1.IsValid = false;

        if (Page.IsValid)
        {
            BasicInfoBO objBasicInfo = new BasicInfoBO();

            objBasicInfo.UserId = userid;
            objBasicInfo.CurrentCity = txtCurrentCity.Text;
            objBasicInfo.HomeTown = txtHometown.Text;

            BasicInfoBLL.updateBasicInfoPage(objBasicInfo);
            // BasicInfoBLL.updateTownCity(txtCurrentCity.Text, txtHometown.Text, 1);
            UpdateUserInfo();
            LoadUserInfo();
            LoadBasicInfo();
            imgSave.Visible = true;
            lblSave.Visible = true;
            WallPost("Changed Basic Information");
        }


  
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
    protected void LoadBasicInfo()
    {
        BasicInfoBO objBasicInfo = new BasicInfoBO();
        objBasicInfo = BasicInfoBLL.getBasicInfoByUserId(userid);

      
            txtHometown.Text = objBasicInfo.HomeTown;
            txtCurrentCity.Text = objBasicInfo.CurrentCity; 
    }

    protected void UpdateUserInfo()
    {
        UserBO objUser = new UserBO();
       objUser.Id=userid;
      // objUser.Gender=rdGender.SelectedValue;

        string Birthday_string = lstMonth.SelectedValue + "/" + lstDay.SelectedValue + "/" + lstYear.SelectedValue;
       DateTime Birthday = Convert.ToDateTime(Birthday_string);
        objUser.DateOfBirth = Birthday;

      UserBLL.updateBasicInfoPage(objUser);

        
    }
    protected void LoadUserInfo()
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);
    
     lstYear.SelectedValue = objUser.DateOfBirth.Year.ToString();
      lstMonth.SelectedValue = objUser.DateOfBirth.Month.ToString();
     // Response.Write(objUser.DateOfBirth.Day.ToString());


    
       //lstDay.SelectedValue = objUser.DateOfBirth.ToString();

      // int day = objUser.DateOfBirth.Day;
       //day += 1;
       //lstDay.SelectedValue = day.ToString();
    }
    protected void lstMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstMonth.SelectedValue)));
        lstDay.DataBind();
        Session["lstDate"] = lstDay.SelectedValue;
        Response.Redirect("BasicInfo.aspx");
    }
    protected void lbtnAddLanguage_Click(object sender, EventArgs e)
    {

        if (lstLanguages.SelectedValue != "Select Languages:")
        {
            TemplateBO langObj = new LanguageBO();
            langObj.Name = lstLanguages.SelectedValue;
            langObj.UserId = userid;
            

            //elbll.insert(langObj);
        TemplateInfoBLL.insert(langObj, (new LanguageDAL())); 
           // LanguageBLL.insertLanguage(langObj);
            LoadLanguages();
        }
    }
    protected void DListLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {

        TemplateInfoBLL.delete(new LanguageDAL(), DListLanguage.DataKeys[DListLanguage.SelectedIndex].ToString());
        //LanguageBLL.deleteLanguage(DListLanguage.DataKeys[DListLanguage.SelectedIndex].ToString());
        LoadLanguages();
    }
    protected void LoadLanguages()
    {
        DListLanguage.DataSource = TemplateInfoBLL.SelectLanguageByid(new LanguageDAL(), userid);  //LanguageBLL.getLanguages(userid);
        DListLanguage.DataBind();
    }
}
