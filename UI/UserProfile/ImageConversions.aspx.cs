using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ImageConversions : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Session["UserId"].ToString();
        CreatePhoto();
        Response.Redirect("ProfilePictures.aspx");
    }

    void CreatePhoto()
    {
        try
        {
            string strPhoto = Request.Form["imageData"]; //Get the image from flash file
            byte[] photo = Convert.FromBase64String(strPhoto);
            string imgpath = Server.MapPath(Global.PROFILE_PICTURE + userid + ".jpg");
            FileStream fs = new FileStream(imgpath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(photo);
          
            br.Flush();
            br.Close();
            fs.Close();
            
        }
        catch (Exception Ex)
        {

        }
    }


}
