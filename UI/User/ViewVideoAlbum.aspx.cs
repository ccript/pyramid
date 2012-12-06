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
    private string userid;
    private string albumid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }

    public string Albumid
    {
        get { return albumid; }
        set { albumid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Video Album";

        Albumid = QueryString.getQueryStringOnIndex(0);
        Userid = SessionClass.getUserId();
        Session["VideoAlbumId"] = Albumid;
        LoadDataListMedia();
    }

    protected void LoadDataListMedia()
    {
        // ***  Proxy driver to get image     **********/
        ProxyVirtualVideoSubject proxyobj = new ProxyVirtualVideoSubject();
        DataList1.DataSource = proxyobj.getVideo(Albumid);
        DataList1.DataBind();

        //DataList1.DataSource = MediaBLL.getMediaByAlbum(albumid);
        //DataList1.DataBind();
    }

}