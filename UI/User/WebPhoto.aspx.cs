using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class User_WebPhotos : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Upload Picture from your webcam";
       
        try
        {
            userid = Session["UserId"].ToString();
           
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
     
    }

    protected void btnCamSave_Click(object sender, EventArgs e)
    {
       //imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
       Response.Redirect("ManagePhotos.aspx");
      
    }
  
}