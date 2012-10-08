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
using System.Xml.Linq;
using System.Web.SessionState;
using BuinessLayer;
using ObjectLayer;
using PAB;
public class Upload : IHttpHandler, IRequiresSessionState{
    string userid = "";
    string filename;
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

            tempPath = Global.USER_VIDEO;
            savepath = context.Server.MapPath(tempPath);
            filename = postedFile.FileName;
			//If you prefer to use web.config for folder path, uncomment below line:
			//tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"]; 
            string fileid =  SaveVideo(context);
            WallPost(fileid);
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);

            postedFile.SaveAs(savepath + @"\" + fileid+".mp4");
            context.Response.Write(tempPath + "/" + filename);
            context.Response.StatusCode = 200;
            
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
    public string SaveVideo(HttpContext context)
    { string albumId;
        if (context.Session["VideoAlbumId"] == null)
        {
         
        MediaAlbumBO objAClass = new MediaAlbumBO();
        objAClass.UserId=userid;
        objAClass.Name="My Videos";
        objAClass.Type = Global.VIDEO;
        objAClass.isFollow = true;
        albumId = MediaAlbumBLL.insertDefaultAlbum(objAClass);
        }
        else
        {
            albumId = context.Session["VideoAlbumId"].ToString();
        }
        MediaBO objClass = new MediaBO();

        objClass.UserId = userid;
        objClass.AlbumId = albumId;
        objClass.Caption = "";
        objClass.Name = filename;
        objClass.Description = "";
        objClass.AddedDate =DateTime.Today;
        objClass.Location = "";
        objClass.Type = Global.VIDEO;
        return MediaBLL.insertMedia(objClass);
     
    }

    protected void WallPost(string videoid)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(userid);

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = userid;
        objWall.WallOwnerUserId = userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;

        string post;
        post="added a new <a href='ViewVideo.aspx?VideoId=" + videoid + "'>video <a/> </br></br>";
          post += " <div id= 'container' >Loading the player ...</div>   <script  type= 'text/javascript'  >";
    post +=" jwplayer('container').setup({";
     post += " file: src='" + Global.USER_VIDEO + videoid + ".mp4' ,";
     post+= " flashplayer: '../../Resources/jwplayer/player.swf',";
         post +=" width: 300";
         post += " ,height: 200";
     post +=" }); ";
     post += "</script> ";
     objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.VIDEO;
        WallBLL.insertWall(objWall);


    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}