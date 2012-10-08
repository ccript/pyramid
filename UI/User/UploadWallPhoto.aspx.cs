using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_User_UploadWallPhoto : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            
            if (FileUpload1.HasFile)
            {
                HttpPostedFile myFile = FileUpload1.PostedFile;
                int size = myFile.ContentLength / 1024;

                string temp = myFile.FileName;

                string temp2 = DateTime.Now.ToString();

                if (size < 4000)
                {
                    try
                    {
                        FileUpload1.SaveAs(Server.MapPath(Global.USER_PHOTOS) + FileUpload1.FileName.ToString());
                    }
                    catch (Exception ex)
                    {
                        //  lblMsg.Text += ex;

                    }
                }
                else
                {

                }
            }

        }
    }
}