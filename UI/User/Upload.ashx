<%@ WebHandler Language="C#" Class="Upload" %>


using System.IO;


using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Web.SessionState;
using BuinessLayer;
using ObjectLayer;
using PAB;
public class Upload : IHttpHandler, IRequiresSessionState{
    string userid = "";
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";



        userid = context.Session["UserId"].ToString();

        
        
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string[] chk = context.Request.Form.GetValues("CheckBox1");
            string savepath = "";
            string tempPath = "";
         
            tempPath = Global.USER_PHOTOS;
        
			//If you prefer to use web.config for folder path, uncomment below line:
			//tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"]; 
            string fileid =  SavePhotos( context);
            WallPost(fileid, context);
                savepath = context.Server.MapPath(tempPath);
                
                string filename = postedFile.FileName;
                if (!Directory.Exists(savepath))
                    Directory.CreateDirectory(savepath);
                if (context.Session["HighResoultion"] == null)
                {
                    System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(postedFile.InputStream);
                    PAB.ImageResizer.ImageResizer resizer = new PAB.ImageResizer.ImageResizer();
                    resizer.MaxHeight = sourceImage.Height/2;
                    resizer.MaxWidth = sourceImage.Width/2;
                    resizer.ImgQuality = 50;
                    resizer.OutputFormat = PAB.ImageResizer.ImageFormat.Jpeg;

                    byte[] bytes = resizer.Resize(postedFile);
                    File.WriteAllBytes(savepath + @"\" + fileid + ".jpg", bytes);
                }
                else
                {

                   postedFile.SaveAs(savepath + @"\" + fileid + ".jpg");
                }

                /////////////////////////THUMBNAIL CODE////////////////////////////////////////////////
                generateThumbnail(postedFile,fileid, context);
                /////////////////////////////////////////////////////////////////////////
                context.Response.Write(tempPath + "/" + filename);
                context.Response.StatusCode = 200;
            
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
    protected void generateThumbnail(HttpPostedFile postedFile, string fileid, HttpContext context)
    {
        string thumpath = "";
        thumpath = context.Server.MapPath(Global.THUMBNAIL_PHOTOS);
        System.Drawing.Image sourceImaget = System.Drawing.Image.FromStream(postedFile.InputStream);
        PAB.ImageResizer.ImageResizer resizert = new PAB.ImageResizer.ImageResizer();
        resizert.MaxHeight = 200;
        resizert.MaxWidth = 200;
        resizert.ImgQuality = 50;
        resizert.OutputFormat = PAB.ImageResizer.ImageFormat.Jpeg;

        byte[] bytest = resizert.Resize(postedFile);
        File.WriteAllBytes(thumpath + @"\" + fileid + ".jpg", bytest);
    }
    public string SavePhotos(HttpContext context)
    {
        string albumId;
        if (context.Session["PhotoAlbumId"] == null)
        {
            MediaAlbumBO objAClass = new MediaAlbumBO();
            objAClass.UserId = userid;
            objAClass.Name = "My Pictures";
            objAClass.Type = Global.PHOTO;
            objAClass.isFollow = true;
         
            albumId = MediaAlbumBLL.insertDefaultAlbum(objAClass);
            context.Session["PhotoAlbumId"] = albumId;

        }
        else
        {
            albumId = context.Session["PhotoAlbumId"].ToString();
        }
        MediaBO objClass = new MediaBO();

        objClass.UserId = userid;
         
        
        objClass.AlbumId = albumId;
        objClass.Caption = "";
        objClass.Name = "";
        objClass.Description = "";
        objClass.AddedDate =DateTime.Now;
        objClass.Location = "";
        objClass.Type = Global.PHOTO;
        objClass.isFollow = true;
        return MediaBLL.insertMedia(objClass);
     
    }

    protected void WallPost(string photoid ,HttpContext context)
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
       string wid= WallBLL.insertWall(objWall);
        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
       List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(context.Session["UserId"].ToString(), Global.CONFIRMED);
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


        objTickerUserTag.PostedByUserId = context.Session["UserId"].ToString();
        objTickerUserTag.TickerOwnerUserId = context.Session["UserId"].ToString();
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
    public bool IsReusable {
        get {
            return false;
        }
    }
}