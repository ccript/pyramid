using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class User_ClassicUpload : System.Web.UI.Page
{
    string userid;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Upload Multiple Photos";
        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
    }
    private void upload_file(HttpPostedFile File)
    {
        int size = File.ContentLength / 1024;

        try
        {
            string fileid = SavePhotos();
            WallPost(fileid);
            generateThumbnail(File, fileid);
            FileUpload1.SaveAs(Server.MapPath(Global.USER_PHOTOS) + fileid + ".jpg");

        }
        catch (Exception ex)
        {
            //  lblMsg.Text += ex;
            lblMsg.Text = "Error Uploading Image !!";
            lblMsg.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            upload_file(FileUpload1.PostedFile);
        }

        if (FileUpload2.HasFile)
        {
            upload_file(FileUpload2.PostedFile);

        }
        if (FileUpload4.HasFile)
        {
            upload_file(FileUpload4.PostedFile);

        }
        if (FileUpload5.HasFile)
        {
            upload_file(FileUpload5.PostedFile);

        }
        Response.Redirect("ManagePhotos.aspx");
    }
    protected void generateThumbnail(HttpPostedFile postedFile, string fileid)
    {
        string thumpath = "";
        thumpath = Server.MapPath(Global.THUMBNAIL_PHOTOS);
        System.Drawing.Image sourceImaget = System.Drawing.Image.FromStream(postedFile.InputStream);
        PAB.ImageResizer.ImageResizer resizert = new PAB.ImageResizer.ImageResizer();
        resizert.MaxHeight = 200;
        resizert.MaxWidth = 200;
        resizert.ImgQuality = 50;
        resizert.OutputFormat = PAB.ImageResizer.ImageFormat.Jpeg;

        byte[] bytest = resizert.Resize(postedFile);
        File.WriteAllBytes(thumpath + @"\" + fileid + ".jpg", bytest);
    }
    public string SavePhotos()
    {
        string albumId;
        if (Session["PhotoAlbumId"] == null)
        {
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = userid;
            objAClass.Name = "My Pictures";
            objAClass.Type = Global.PHOTO;
            objAClass.isFollow = true;
            albumId = MediaAlbumBLL.insertDefaultAlbum(objAClass);

        }
        else
        {
            albumId = Session["PhotoAlbumId"].ToString();
        }
        MediaBO objClass = new MediaBO();

        objClass.UserId = userid;


        objClass.AlbumId = albumId;
        objClass.Caption = "";
        objClass.Name = "";
        objClass.Description = "";
        objClass.AddedDate = DateTime.Now;
        objClass.Location = "";
        objClass.Type = Global.PHOTO;
        objClass.isFollow = true;
        return MediaBLL.insertMedia(objClass);

    }

    protected void WallPost(string photoid)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = userid;
        objWall.WallOwnerUserId = userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = "added a new photo";
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.PHOTO;
        objWall.EmbedPost = photoid;
        string wid = WallBLL.insertWall(objWall);
        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in listtag)
        {
            TickerBO objTicker = new TickerBO();


            objTicker.PostedByUserId = objWall.PostedByUserId;
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objWall.FirstName;
            objTicker.LastName = objWall.LastName;
            objTicker.Post = objWall.Post;
            objTicker.Title = "added a new photo";
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = Global.PHOTO;
            objTicker.EmbedPost = objWall.EmbedPost;
            objTicker.WallId = wid;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUserTag = new TickerBO();


        objTickerUserTag.PostedByUserId = Session["UserId"].ToString();
        objTickerUserTag.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUserTag.FirstName = objUser.FirstName;
        objTickerUserTag.LastName = objUser.LastName;
        objTickerUserTag.Post = objWall.Post;
        objTickerUserTag.Title = "added a new photo";
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = Global.PHOTO;
        objTickerUserTag.EmbedPost = objWall.EmbedPost;
        objTickerUserTag.WallId = wid;
        TickerBLL.insertTicker(objTickerUserTag);

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

    }
}