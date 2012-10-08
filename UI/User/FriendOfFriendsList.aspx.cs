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
using BuinessLayer;
using ObjectLayer;
using System.Globalization;

public partial class User_FriendOfFriendsList : System.Web.UI.Page
{
    private string friendid;
    string userid;
    string friendsoffriend;
    string type;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userid = Session["UserId"].ToString();
            friendsoffriend = Request.QueryString.Get(0);
            type = Request.QueryString.Get(1);
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        if(type.Equals("FOF"))
        {
        ((Label)Master.FindControl("lblTitle")).Text = "Friends Of Friend";
        }
        else
        {
            ((Label)Master.FindControl("lblTitle")).Text = "Mutual Friends";
        }
        if (!IsPostBack)
        {

            LoadFriendsList();


        }

    }
    protected void LoadFriendsList()
    {


        GridViewFriendsOfFriend.DataSource = FriendsBLL.getMutualFriends(userid,friendsoffriend, Global.CONFIRMED).ToList();
        GridViewFriendsOfFriend.DataBind();

    }
    protected void GridViewFriendsOfFriend_SelectedIndexChanged(object sender, EventArgs e)
    {
        //friendid = GridViewFriendsOfFriend.DataKeys[GridViewFriendsOfFriend.SelectedIndex].Value.ToString();
        //FriendsBLL.sendFriendRequest(userid, friendid);

        //Response.Redirect("../../Default.aspx?ID=" + id);
    }

    protected void GridViewFriendsOfFriend_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        GridViewRow row = GridViewFriendsOfFriend.Rows[Convert.ToInt32(e.CommandArgument)];

        friendid = GridViewFriendsOfFriend.DataKeys[row.RowIndex].Value.ToString();
        string s = ((LinkButton)(row.Cells[0].Controls[0])).Text;
        if (s.Equals("Add Friend"))
        {

            FriendsBLL.sendFriendRequest(userid, friendid);
            
            ((LinkButton)(row.Cells[0].Controls[0])).Text = "Cancel Request";
           

        }
        else if (s.Equals("Cancel Request"))
        {
            FriendsBLL.cancelFriendRequest(userid, friendid);
            
            ((LinkButton)(row.Cells[0].Controls[0])).Text = "Add Friend";
          

        }
    }
    protected void GridViewFriendsOfFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFriendsOfFriend.PageIndex = e.NewPageIndex;
        LoadFriendsList();
    }

}