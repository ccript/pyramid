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
using BuinessLayer;
using ObjectLayer;
using System.Globalization;

public partial class User_FriendRequests : System.Web.UI.Page
{
    string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = SessionClass.getUserId();

        ((Label)Master.FindControl("lblTitle")).Text = "Friend Requests";
        if (!IsPostBack)
        {
            LoadFriendRequests();
        }
    }


    protected void LoadFriendRequests()
    {
        GridViewFriendsListRequest.DataSource = FriendsBLL.getAllFriendRequests(Userid, Global.PENDING);
        GridViewFriendsListRequest.DataBind();
        GridViewSuggestions.DataSource = FriendsBLL.getAllFriendRequests(Userid, Global.SUGGESTED);
        GridViewSuggestions.DataBind();
    }


 
    protected void GridViewFriendsListRequest_RowCommand(object sender,  GridViewCommandEventArgs e)
    {
                FriendsBO objClass = new FriendsBO();
                GridViewRow row = GridViewFriendsListRequest.Rows[Convert.ToInt32(e.CommandArgument)];
                objClass.Id = GridViewFriendsListRequest.DataKeys[row.RowIndex].Value.ToString();

        if (e.CommandName == "notnow")
         {
                objClass.Status = Global.NOTNOW;
                Response.Write(objClass.FriendUserId);
                FriendsBLL.delayRequest(objClass);
                LoadFriendRequests(); 
          }
          else if(e.CommandName=="confirmnow")
          {
                objClass.Status = Global.CONFIRMED;
                string sValue = ((HiddenField)row.FindControl("HiddenField1")).Value;
                objClass.FriendUserId = sValue;
                UserBO objUser = new UserBO();
                objUser = UserBLL.getUserByUserId(sValue);
              
                FriendsBLL.confirmRequest(objClass);
                WallPost(" accept friend request of  <a  href=\"ViewProfile.aspx?UserId=" + Userid + "\">" + objUser.FirstName + " " + objUser.LastName + "</a> ");
                LoadFriendRequests();
           }
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
    protected void GridViewSuggestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        FriendsBO objClass = new FriendsBO();
        GridViewRow row = GridViewFriendsListRequest.Rows[Convert.ToInt32(e.CommandArgument)];
        objClass.Id = GridViewFriendsListRequest.DataKeys[row.RowIndex].Value.ToString();

        if (e.CommandName == "notnow")
        {
            objClass.Status = Global.NOTNOW;   
            Response.Write(objClass.FriendUserId);
            FriendsBLL.delayRequest(objClass);
            LoadFriendRequests();

        }
        else if (e.CommandName == "confirmnow")
        {
                objClass.Status = Global.CONFIRMED;
                string sValue = ((HiddenField)row.FindControl("HiddenField1")).Value;
                objClass.FriendUserId = sValue;
                FriendsBLL.confirmRequest(objClass);
                LoadFriendRequests();
         }
    }
}