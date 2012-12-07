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

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = SessionClass.getUserId();
        CreatePhoto();
        Response.Redirect("ProfilePictures.aspx");
    }

    void CreatePhoto()
    {
        try
        {            
            FileStream fs = new FileStream(Server.MapPath(Global.PROFILE_PICTURE + Userid + Global.PICTURE_EXTENSION_JPG), FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(Convert.FromBase64String(Request.Form["imageData"]));
          
            br.Flush();
            br.Close();
            fs.Close();            
        }
        catch (Exception Ex)
        {

        }
    }
}
