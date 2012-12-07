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
using DataLayer;
public partial class EducationWork : System.Web.UI.Page
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
        ((Label)Master.FindControl("lblTitle")).Text = "Education & Work";
        if (!IsPostBack)
        {
           
            LoadDataListEmployer();
            LoadDataListProject();
            LoadDataListUniversity();
            LoadDataListSchool();

          
                //Populate Start DropDownLists
                lstStartMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                {
                    MonthName =  CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a),

                    MonthNumber = a
                });
                lstStartMonth.DataBind();
                lstStartYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
                lstStartYear.DataBind();
                lstStartDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstStartMonth.SelectedValue)));
                lstStartDay.DataBind();




                //Populate End DropDownLists
                lstEndMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                {
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a),

                    MonthNumber = a
                });
                lstEndMonth.DataBind();
                lstEndYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
                lstEndYear.DataBind();
                lstEndDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstStartMonth.SelectedValue)));
                lstEndDay.DataBind();



                //Populate Start Project DropDownLists
                lstPStartMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                {
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a),

                    MonthNumber = a
                });
                lstPStartMonth.DataBind();
                lstPStartYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
                lstPStartYear.DataBind();
                lstPStartDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstPStartMonth.SelectedValue)));
                lstPStartDay.DataBind();




                //Populate End Project DropDownLists
                lstPEndMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                {
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a),

                    MonthNumber = a
                });
                lstPEndMonth.DataBind();
                lstPEndYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
                lstPEndYear.DataBind();
                lstPEndDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstPStartMonth.SelectedValue)));
                lstPEndDay.DataBind();
        }

        if(Session["lstPStartDay"] != null)
            lstPStartDay.SelectedValue = Session["lstPStartDay"].ToString();


        if (Session["lstPEndDay"] != null)
            lstPEndDay.SelectedValue = Session["lstPEndDay"].ToString();


        if (Session["lstStartDay"] != null)
            lstStartDay.SelectedValue = Session["lstStartDay"].ToString();

        if (Session["lstEndDay"] != null)
            lstEndDay.SelectedValue = Session["lstEndDay"].ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       // BasicInfoBO objBasicInfo = new BasicInfoBO();

        //objBasicInfo.UserId = 1;
        //objBasicInfo.CurrentCity = txtCurrentCity.Text;
       // objBasicInfo.HomeTown = txtHometown.Text;

       // BasicInfoBLL.updateBasicInfoPage(objBasicInfo);
       // BasicInfoBLL.updateTownCity(txtCurrentCity.Text, txtHometown.Text, 1);
       // LoadBasicInfo();
        SaveEmployer();
        SaveProject();
        SaveUniversity();
        SaveSchool();
        LoadDataListEmployer();
        LoadDataListProject();
        LoadDataListUniversity();
        LoadDataListSchool();
        imgSave.Visible = true;
        lblSave.Visible = true;        

        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_CHANGED_EDUCATION_WORK;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);
    }

    protected void SaveEmployer()
    {
        TemplateBO objEmployer = new EmployerBO();

        objEmployer.UserId = Userid;
  
        objEmployer.Organization =txtEmployer.Text;
        objEmployer.Position = txtEmployerPosition.Text;
        objEmployer.Town = txtEmployerTown.Text;
        objEmployer.Description = txtEmployerDescription.Text;
        objEmployer.EndYear = Convert.ToInt32(lstEndYear.SelectedValue);
        objEmployer.EndMonth = Convert.ToInt32(lstEndMonth.SelectedValue);
        objEmployer.EndDay = Convert.ToInt32(lstEndDay.SelectedValue);
        objEmployer.StartDay = Convert.ToInt32(lstStartDay.SelectedValue);
        objEmployer.StartMonth = Convert.ToInt32(lstStartMonth.SelectedValue);
        objEmployer.StartYear = Convert.ToInt32(lstStartYear.SelectedValue);
        objEmployer.IsCurrentlyWork = chkEmployerCurrentlyWork.Checked;
        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtEmployer.Text + ".jpg")))
            objEmployer.Image = txtEmployer.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtEmployer.Text + ".png")))
            objEmployer.Image = txtEmployer.Text + ".png";
        else
             objEmployer.Image = "DefaultEmployer.png";

       // EmployerBLL.insertEmployer(objEmployer);
        TemplateInfoBLL.insert(objEmployer, new EmployerDAL());
        LoadDataListEmployer();
    }
    protected void SaveProject()
    {
        ProjectBO objProject = new ProjectBO();

        objProject.UserId = Userid;
        objProject.ProjectName = txtProject.Text;
        objProject.EmployerId = "4f366d5c745cb3006cb76079";
        objProject.Description = txtProjectDescription.Text;
        objProject.EndYear = Convert.ToInt32(lstPEndYear.SelectedValue);
        objProject.EndMonth = Convert.ToInt32(lstPEndMonth.SelectedValue);
        objProject.EndDay = Convert.ToInt32(lstPEndDay.SelectedValue);
        objProject.StartDay = Convert.ToInt32(lstPStartDay.SelectedValue);
        objProject.StartMonth = Convert.ToInt32(lstPStartMonth.SelectedValue);
        objProject.StartYear = Convert.ToInt32(lstPStartYear.SelectedValue);
        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtProject.Text + ".jpg")))
            objProject.Image = txtProject.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtProject.Text + ".png")))
            objProject.Image = txtProject.Text + ".png";
        else
            objProject.Image = "DefaultProject.png";
      
      
        string ProjectId =ProjectBLL.insertProject(objProject);
       // if (ProjectId!=-1)
       // SaveProjectWith(ProjectId);
        LoadDataListProject();
    }

    protected void SaveProjectWith(int ProjectId)
    {

    }
    protected void SaveUniversity()
    {
       UniversityBO objUniversity = new UniversityBO();

        objUniversity.UserId = Userid;
        objUniversity.UniversityName = txtUniversity.Text;

        objUniversity.AttendedFor = txtAttendFor.Text;
        objUniversity.ClassYear = Convert.ToInt32(lstClassYear.SelectedValue);
        objUniversity.Degree = txtDegree.Text;
        objUniversity.Purpose = txtPurpose.Text;


        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtUniversity.Text + ".jpg")))
            objUniversity.Image = txtUniversity.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtUniversity.Text + ".png")))
            objUniversity.Image = txtUniversity.Text + ".png";
        else
            objUniversity.Image = "DefaultUniversity.png";

        if (!objUniversity.UniversityName.Equals(""))
        {
            string UniversityId = UniversityDAL.insertUniversity(objUniversity);
        }
         
        LoadDataListUniversity();
    }

    protected void SaveUniversityWith(int UniversityId)
    {

    }
    protected void SaveSchool()
    {
        SchoolBO objSchool = new SchoolBO();

        objSchool.UserId = Userid;
        objSchool.Name = txtSchool.Text;
        objSchool.Description = txtSchoolDescription.Text;


        if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSchool.Text + ".jpg")))
            objSchool.Image = txtSchool.Text + ".jpg";
        else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSchool.Text + ".png")))
            objSchool.Image = txtSchool.Text + ".png";
        else
            objSchool.Image = "DefaultSchool.png";
        SchoolBLL.insertSchool(objSchool);
        LoadDataListUniversity();
    }
    protected void LoadDataListEmployer()
    {

        DListEmployer.DataSource=TemplateInfoBLL.SelectEmployerTop5(new EmployerDAL(), Userid);
        DListEmployer.DataBind();

    }
    protected void LoadDataListProject()
    {

       DListProject.DataSource = ProjectBLL.getProjectTop5(Userid);
       DListProject.DataBind();

    }

    protected void LoadDataListUniversity()
    {

        DListUniversity.DataSource = UniversityDAL.getUniversityTop5(Userid);
       DListUniversity.DataBind();

    }
    protected void LoadDataListSchool()
    {

        DListSchool.DataSource = SchoolBLL.getSchoolTop5(Userid);
        DListSchool.DataBind();

    }
    protected void DListEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        TemplateInfoBLL.delete(new EmployerDAL(), DListEmployer.DataKeys[DListEmployer.SelectedIndex].ToString());       
        LoadDataListEmployer();
    }
    protected void DListProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProjectBLL.deleteProject(DListProject.DataKeys[DListProject.SelectedIndex].ToString());
       LoadDataListProject();
    }
    protected void DListEmployer_DeleteCommand(object source, DataListCommandEventArgs e)
    {         
    }
    protected void DListUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        UniversityDAL.deleteUniversity(DListUniversity.DataKeys[DListUniversity.SelectedIndex].ToString());
       LoadDataListUniversity();
    }
    protected void DListSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        SchoolBLL.deleteSchool(DListSchool.DataKeys[DListSchool.SelectedIndex].ToString());
        LoadDataListSchool();
    }
    protected void lstStartMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

     lstStartDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstStartMonth.SelectedValue)));
     lstStartDay.DataBind();

     Session["lstStartDay"] = lstStartDay.SelectedValue;
     Response.Redirect("EducationWork.aspx");


    }
    protected void lstEndMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstEndDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstEndMonth.SelectedValue)));
        lstEndDay.DataBind();

        Session["lstEndDay"] = lstEndDay.SelectedValue;
        Response.Redirect("EducationWork.aspx");

    }
    protected void lstPStartMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstPStartDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstPStartMonth.SelectedValue)));
        lstPStartDay.DataBind();
        
        Session["lstPStartDay"] = lstPStartDay.SelectedValue;
        Response.Redirect("EducationWork.aspx");

    }
    protected void lstPEndMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstPEndDay.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(lstPEndMonth.SelectedValue)));
        lstPEndDay.DataBind();


        Session["lstPEndDay"] = lstPEndDay.SelectedValue;
        Response.Redirect("EducationWork.aspx");
    }
}