using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class UI_User_ViewVideoAlbum : System.Web.UI.Page
{
    string userid;
    string albumid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Video Album";
        try
        {

            albumid = Request.QueryString.Get(0);
                userid = Session["UserId"].ToString();
                Session["VideoAlbumId"] = albumid;
        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        LoadDataListMedia();
    }

    protected void LoadDataListMedia()
    {
        // ***  Proxy driver to get image     **********/
        ProxyVirtualVideoSubject proxyobj = new ProxyVirtualVideoSubject();
        DataList1.DataSource = proxyobj.getVideo(albumid);
        DataList1.DataBind();

        //DataList1.DataSource = MediaBLL.getMediaByAlbum(albumid);
        //DataList1.DataBind();
    }

}