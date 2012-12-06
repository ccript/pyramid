using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BuinessLayer;
using ObjectLayer;
public partial class UserProfile_ProfilePictures : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Profile Pictures";

        Userid = LoginClass.getUserId();

        imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
    }
    protected void btnSaveUpload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (FileUpload1.HasFile)
            {
                HttpPostedFile myFile = FileUpload1.PostedFile;
                int size =myFile.ContentLength/1024;
                if (size < 4000)
                {
                    try
                    {
                        FileUpload1.SaveAs(Server.MapPath(Global.PROFILE_PICTURE) + Userid + ".jpg");
                    }
                    catch (Exception ex)
                    {
                        //  lblMsg.Text += ex;
                        lblMsg.Text = "Error Uploading Image !!" ;
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "File Size Less than 4MB";
                    lblMsg.Visible = true;
                }
            }

        }
    }
    protected void btnCamSave_Click(object sender, EventArgs e)
    {
       imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
     //  Response.Redirect("ImageConversions.aspx");
      
    }
    protected void lbtnremove_Click(object sender, EventArgs e)
    {

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);
        
        string oldfile = Server.MapPath("../../Resources/images/"+objUser.Gender+".png");
        string newfile = Server.MapPath(Global.PROFILE_PICTURE) + Userid + ".jpg";
              string backup = Server.MapPath(Global.PROFILE_PICTURE) +"backup.jpg";
              if (System.IO.File.Exists(newfile))
              {
                  System.IO.File.Delete(newfile);

                  System.IO.File.Copy(oldfile, newfile);
              }

        imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
    }
}