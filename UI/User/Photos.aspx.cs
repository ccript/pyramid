using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class User_Photos : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Photos";        
        Userid = SessionClass.getUserIdOrTempUserId();
        Session["PhotoAlbumId"] = null;
        Session["HighResoultion"] = null;
        LoadDataListMediaAlbum();
        LoadDataListTagPhotos();
        LoadDataListTagAlbums();

        // for counting tag photo by friend if not found any then hide label
       List<Tags> lstphoto= TagsBLL.getTagsListbyFriendsId(Global.PHOTO, Userid);
       if (lstphoto.Count == 0)
       {
           tagphoto_Label.Visible = false;
       }
       // for counting tag album by friend if not found any then hide label
       List<Tags> lstalbum = TagsBLL.getTagsListbyFriendsId(Global.PHOTO_ALBUM, Userid);
       if (lstalbum.Count == 0)
       {
           Tags_Album_label.Visible = false;
       }

       List<MediaAlbum> for_more_album_count = MediaAlbumBLL.getMediaAlbumTop6(Userid, Global.PHOTO);
       if (for_more_album_count.Count < 5)
       {
           lbtnMore.Visible = false;
       }

    }

    protected void LoadDataListMediaAlbum()
    {

        DataList1.DataSource = MediaAlbumBLL.getMediaAlbumTop6(Userid, Global.PHOTO);
        DataList1.DataBind();

    }

    protected void lbtnMore_Click(object sender, EventArgs e)
    {

        DataList1.DataSource = MediaAlbumBLL.getAllMediaAlbum(Userid, Global.PHOTO);
        DataList1.DataBind();

    }

    protected void LoadDataListTagPhotos()
    {

        DataListTagPhotos.DataSource = TagsBLL.getTagsListbyFriendsId(Global.PHOTO, Userid);
        DataListTagPhotos.DataBind();

    }

    protected void LoadDataListTagAlbums()
    {

        DataListTagAlbums.DataSource = TagsBLL.getTagsListbyFriendsId(Global.PHOTO_ALBUM, Userid);
        DataListTagAlbums.DataBind();

    }
}

 