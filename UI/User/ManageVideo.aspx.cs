using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
using GrayMatterSoft;
public partial class UI_User_ManageVideo : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Manage Video";
        try
        {
           

                userid = Session["UserId"].ToString();
             
        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        if(!IsPostBack)
        LoadDataListMedia();
    }

    protected void LoadDataListMedia()
    {

        DataList1.DataSource = MediaBLL.getMediaTop5(userid, Global.VIDEO);
        DataList1.DataBind();

    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
    
        TextBox captionText = new TextBox();
        TextBox locationText = new TextBox();
        TextBox despText = new TextBox();
        TextBox titleText = new TextBox();
        GMDatePicker datep = new GMDatePicker();
        string caption = null;
        string location = null;
        string desp = null;
        string title = null;
        string id = null;
        DateTime adddate;
    

        foreach (DataListItem dataItem in DataList1.Items)
        {

            
            captionText = (TextBox)dataItem.FindControl("txtCaption");
            locationText = (TextBox)dataItem.FindControl("txtLocation");
            despText = (TextBox)dataItem.FindControl("txtDescription");
            titleText = (TextBox)dataItem.FindControl("txtName");
            datep = (GMDatePicker)dataItem.FindControl("GMDatePicker1");
            caption = captionText.Text.ToString().Trim();
            location = locationText.Text.ToString().Trim();
            desp = despText.Text.ToString().Trim();
            title = titleText.Text.ToString().Trim();
            adddate = datep.Date;
            string Id = ((HiddenField)dataItem.FindControl("HiddenField1")).Value;
           
            MediaBO objClass = new MediaBO();
           objClass.Id = Id;
           objClass.Location = location;
           objClass.Caption = caption;
           objClass.Name = title;
           objClass.Description = desp;
           objClass.AddedDate = adddate;
           objClass.Type= Global.VIDEO;
           MediaBLL.updateEditVideoMedia(objClass);
          
        }

        LoadDataListMedia();
    }
}