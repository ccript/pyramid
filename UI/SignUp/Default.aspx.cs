using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string oldfile=Server.MapPath("../Resources/images/male.png");
         string newfile=Server.MapPath("../UserProfile/profileimages/") + 666 + ".jpg";
         if (!System.IO.File.Exists(newfile))
             System.IO.File.Copy(oldfile, newfile);
    }
}