using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BuinessLayer;
using ObjectLayer;
public partial class ImageConversions : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Session["UserId"].ToString();
        CreatePhoto();
       // Response.Redirect("Photos.aspx");
    }

    void CreatePhoto()
    {
        try
        {
            string strPhoto = Request.Form["imageData"]; //Get the image from flash file
            byte[] photo = Convert.FromBase64String(strPhoto);
            string fileid = SaveInterests();
            WallPost(fileid);
            string imgpath = Server.MapPath(Global.USER_PHOTOS + fileid + ".jpg");
            string imgthumbpath = Server.MapPath(Global.THUMBNAIL_PHOTOS + fileid + ".jpg");
            FileStream fs = new FileStream(imgpath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(photo);
            Session["WebCamPhotoId"] = fileid;

            fs = new FileStream(imgthumbpath, FileMode.OpenOrCreate, FileAccess.Write);
             br = new BinaryWriter(fs);
            br.Write(photo);
           
        
            br.Flush();
            br.Close();
            fs.Close();
            
        }
        catch (Exception Ex)
        {

        }
    }
 
    public string SaveInterests()
    {
        string albumId;
        if (Session["PhotoAlbumId"] == null)
        {
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = userid;
            objAClass.Name = "My Pictures";
            objAClass.Type = Global.PHOTO;
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
