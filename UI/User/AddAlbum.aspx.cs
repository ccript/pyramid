using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class User_AddAlbum : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Create new Album";
        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MediaAlbumBO objAClass = new MediaAlbumBO();
        objAClass.UserId = userid;
        objAClass.Name = txtName.Text;
        objAClass.Description = txtDescription.Text;
        objAClass.CoverPictureId = "0000000000000b0000000900";
        objAClass.Type = Global.PHOTO;
        objAClass.isFollow = true;
         MediaAlbumBLL.insertMediaAlbum(objAClass);
         Response.Redirect("Photos.aspx");
    }
}