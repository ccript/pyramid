using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class User_WebPhotos : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Upload Picture from your webcam";

        Userid = SessionClass.getUserId();
     
    }

    protected void btnCamSave_Click(object sender, EventArgs e)
    {
       //imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
       Response.Redirect("ManagePhotos.aspx");
      
    }
  
}