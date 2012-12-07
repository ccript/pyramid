using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using BuinessLayer;

/// <summary>
/// Summary description for WallPost
/// </summary>
public class PostOnWall
{
    public PostOnWall()
	{		

	}

    public static void post(PostProperties post)
    {
        UserBO objUser = UserBLL.getUserByUserId(SessionClass.getUserId());
        WallBO objWall = new WallBO();

        objWall.WallOwnerUserId = post.WallOwnerUserId;
        objWall.PostedByUserId = post.PostedByUserId;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post.PostText;
        objWall.EmbedPost = post.EmbedPost;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = post.PostType;
        string wid = WallBLL.insertWall(objWall);

        List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(SessionClass.getUserId(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in listtag)
        {
            TickerBO objTicker = new TickerBO();
            objTicker.PostedByUserId = objWall.PostedByUserId;
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objWall.FirstName;
            objTicker.LastName = objWall.LastName;
            objTicker.Post = objWall.Post;
            objTicker.Title = Global.SHARE_A_POST;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = objWall.Type;
            objTicker.EmbedPost = objWall.EmbedPost;
            objTicker.WallId = wid;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUserTag = new TickerBO();

        objTickerUserTag.PostedByUserId = SessionClass.getUserId();
        objTickerUserTag.TickerOwnerUserId = SessionClass.getUserId();
        objTickerUserTag.FirstName = objUser.FirstName;
        objTickerUserTag.LastName = objUser.LastName;
        objTickerUserTag.Post = objWall.Post;
        objTickerUserTag.Title = Global.SHARE_A_POST;
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = objWall.Type;
        objTickerUserTag.EmbedPost = objWall.EmbedPost;
        objTickerUserTag.WallId = wid;
        TickerBLL.insertTicker(objTickerUserTag);
        
    }
}

public class PostProperties
{    
    public string PostText { get; set; }
    public int PostType { get; set; }
    public string EmbedPost { get; set; }
    public string WallOwnerUserId { get; set; }
    public string PostedByUserId { get; set; }    
}