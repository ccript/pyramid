using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile_ProfilePictures : System.Web.UI.Page
{
    string userid=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Upload Profile Picture";

        string Email = Session["UserEmail"].ToString();

        if (Session["SignUpUserId"] == null)
            Response.Redirect("../../Default.aspx");


        userid = Session["SignUpUserId"].ToString();
        imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";

        string oldfile = Server.MapPath("../../Resources/images/Male.png");
        string newfile = Server.MapPath(Global.PROFILE_PICTURE) + userid + ".jpg";

        if (System.IO.File.Exists(newfile))
        {
            lbtnremove.Visible = true;
        }
    
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
                        FileUpload1.SaveAs(Server.MapPath(Global.PROFILE_PICTURE) + userid + ".jpg");
                    }
                    catch (Exception ex)
                    {
                        //  lblMsg.Text += ex;
                        lblMsg.Text = "Error Uploading Image !!";
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
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Write("wajooo");
        Post_ModalPopupExtender.Hide();
        Response.Redirect("../../Default.aspx");
    }
    protected void btnCamSave_Click(object sender, EventArgs e)
    {
        //Response.Write("user:" + userid);
        imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
    
      //  Response.Redirect("ImageConversions.aspx");
    }
    protected void lbtnremove_Click(object sender, EventArgs e)
    {
        string oldfile = Server.MapPath("../../Resources/images/Male.png");
        string newfile = Server.MapPath(Global.PROFILE_PICTURE) + userid + ".jpg";
       
        if (System.IO.File.Exists(newfile))
        {
            System.IO.File.Delete(newfile);

            System.IO.File.Copy(oldfile, newfile);
        }

        imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
    }
}