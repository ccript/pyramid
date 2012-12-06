using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BuinessLayer;
using ObjectLayer;
public partial class UserProfile_ProfilePictures : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Profile Pictures";
        Userid = SessionClass.getUserId();
        imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
    }
    protected void btnSaveUpload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (FileUpload1.HasFile)
            {
                HttpPostedFile myFile = FileUpload1.PostedFile;
                int size =myFile.ContentLength/1024;
                if (size < 4000)
                {
                    try
                    {
                        FileUpload1.SaveAs(Server.MapPath(Global.PROFILE_PICTURE) + Userid + ".jpg");
                        WallPost("Profile Picture Change");
                    }
                    catch (Exception ex)
                    {
                        //  lblMsg.Text += ex;
                        lblMsg.Text = "Error Uploading Image !!" ;
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "File Size Less than 4MB";
                    lblMsg.Visible = true;
                }
            }

        }
    }
    protected void btnCamSave_Click(object sender, EventArgs e)
    {
       imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
       WallPost("Profile Picture Change");
     //  Response.Redirect("ImageConversions.aspx");
      
    }
    protected void lbtnremove_Click(object sender, EventArgs e)
    {

        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);
        
        string oldfile = Server.MapPath("../../Resources/images/"+objUser.Gender+".png");
        string newfile = Server.MapPath(Global.PROFILE_PICTURE) + Userid + ".jpg";
              string backup = Server.MapPath(Global.PROFILE_PICTURE) +"backup.jpg";
              if (System.IO.File.Exists(newfile))
              {
                  System.IO.File.Delete(newfile);

                  System.IO.File.Copy(oldfile, newfile);
              }

        imgProfile.ImageUrl = Global.PROFILE_PICTURE + Userid + ".jpg";
        WallPost("Profile Picture Change");
    }

    protected void WallPost(string post)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Userid;
        objWall.WallOwnerUserId = Userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.PROFILE_CHANGE;
        string wid=WallBLL.insertWall(objWall);
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
            objTicker.Title = objWall.Post;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = objWall.Type;
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
        objTickerUserTag.Title = objWall.Post;
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = objWall.Type;
        objTickerUserTag.EmbedPost = objWall.EmbedPost;
        objTickerUserTag.WallId = wid;
        TickerBLL.insertTicker(objTickerUserTag);

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////

    }
}