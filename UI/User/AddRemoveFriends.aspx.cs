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
using BuinessLayer;

public partial class User_AddRemoveFriends : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = LoginClass.getUserIdOrTempUserId();

        ((Label)Master.FindControl("lblTitle")).Text = "Remove Friends";
        if (!IsPostBack)
        {

            LoadFriendsList();


        }
        Panel1.DefaultButton = "SearchButton";
    }


    protected void LoadFriendsList()
    {


        GridViewFriendsList.DataSource = FriendsBLL.getAllFriendsListName(Userid, Global.CONFIRMED);
        GridViewFriendsList.DataBind();

        // GridViewFriendsListRequest.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.PENDING);
        // GridViewFriendsListRequest.DataBind();
    }



    protected void GridViewFriendsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FriendsBLL.deleteFriends(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value.ToString());
        LoadFriendsList();
        // Response.Write(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value);
    }
    protected void GridViewFriendsListRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        string friendid = GridViewFriendsListRequest.DataKeys[GridViewFriendsListRequest.SelectedIndex].Value.ToString();

        Response.Redirect("FriendofFriendsList.aspx?UserId=" + friendid + "&Type=Mutual");

    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string fieldValue = SearchTextBox.Text;
        string CheckBox = SearchDropDownList.Text;

        if (CheckBox == "Name")
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListName(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
        }

        if (CheckBox == "CurrrentCity")
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListCurrent(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
            //   Response.Write("current");
        }

        if (CheckBox == "HomeTown")
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListHomeTown(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
            //   Response.Write("current");
        }

        if (CheckBox == "School")
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListSchool(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
            //   Response.Write("current");
        }

        if (CheckBox == "WorkPlace")
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListWorkPlace(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();

        }
    }

    protected void GridViewFriendsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFriendsList.PageIndex = e.NewPageIndex;
        LoadFriendsList();
    }
}