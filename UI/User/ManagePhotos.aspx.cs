using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrayMatterSoft;
using BuinessLayer;
using ObjectLayer;
public partial class UI_User_ManagePhotos : System.Web.UI.Page
{
    string userid;
    string albumid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Manage Photos";
        try
        {
           

                userid = Session["UserId"].ToString();
     
            
        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        try
        {


           

            albumid = Session["PhotoAlbumId"].ToString();
        }

        catch (Exception ex) { Response.Redirect("Photos.aspx"); }
        if (!IsPostBack)
        {
            LoadDataListMedia();
            LoadDataAlbum();
        }
    }
    protected void LoadDataAlbum()
    {

        MediaAlbumBO obj = new MediaAlbumBO();

        obj = MediaAlbumBLL.getMediaAlbumByMediaAlbumId(albumid);
        txtDescription.Text = obj.Description;
        txtTitle.Text = obj.Name;
        lblTitle.Text = obj.Name;
        if (obj.Name.Equals("My Pictures"))
            PanelDefault.Visible = true;
      
        else
            PanelOthers.Visible = true;
    }

    protected void EditAlbum()
    {

        MediaAlbumBO obj = new MediaAlbumBO();
        obj.Description=txtDescription.Text;
        obj.Name=txtTitle.Text;
        obj.Id = albumid;
        MediaAlbumBLL.EditAlbum(obj);

    }
    protected void LoadDataListMedia()
    {

        DataList1.DataSource = MediaBLL.getMediaTop5(userid, Global.PHOTO, albumid);
        DataList1.DataBind();

    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
    
        TextBox captionText = new TextBox();
        TextBox locationText = new TextBox();
        TextBox despText = new TextBox();
        GMDatePicker datep = new GMDatePicker();
        string caption = null;
        string location = null;
        string desp = null;
        string id = null;
        DateTime adddate;
    

        foreach (DataListItem dataItem in DataList1.Items)
        {

            captionText = (TextBox)dataItem.FindControl("txtCaption");
            captionText = (TextBox)dataItem.FindControl("txtCaption");
            locationText = (TextBox)dataItem.FindControl("txtLocation");
            datep = (GMDatePicker)dataItem.FindControl("GMDatePicker1");
            //despText = (TextBox)dataItem.FindControl("txtDescription");

            caption = captionText.Text.ToString().Trim();
            location = locationText.Text.ToString().Trim();
           //desp = despText.Text.ToString().Trim();
            adddate = datep.Date;
            string Id = ((HiddenField)dataItem.FindControl("HiddenField1")).Value;

            MediaBO objClass = new MediaBO();
           objClass.Id = Id;
           objClass.Location = location;
           objClass.Caption = caption;
           objClass.AddedDate = adddate;
           objClass.Type= Global.PHOTO;
           MediaBLL.updateEditMedia(objClass);
          
        }
        EditAlbum();
        LoadDataListMedia();
        LoadDataAlbum();
    }
}