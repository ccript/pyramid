using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class User_Video : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Videos";
        
        try
        {
            if (Session["TempUserId"] == null)
            {

                userid = Session["UserId"].ToString();
                Session["TempUserId"] = null;

            }
            else
            {
                userid = Session["TempUserId"].ToString();
            }
        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        LoadDataListMediaAlbum();
    }

    protected void LoadDataListMediaAlbum()
    {

        DataList1.DataSource = MediaAlbumBLL.getMediaAlbumTop6(userid,Global.VIDEO);
        DataList1.DataBind();

    }
}

 