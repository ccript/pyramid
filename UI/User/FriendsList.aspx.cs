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
public partial class FriendsList : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = SessionClass.getUserIdOrTempUserId();

        ((Label)Master.FindControl("lblTitle")).Text = "View Friends";
        if (!IsPostBack)
        {
            LoadFriendsList();          
        }

        if (GridViewFriendsListRequest.Rows.Count == 0)
            pendinglabel.Visible = false;
        else
            pendinglabel.Visible = true;

        Panel1.DefaultButton = "SearchButton";
    }


    protected void LoadFriendsList()
    {

        GridViewFriendsList.DataSource = FriendsBLL.getAllFriendsListName(Userid, Global.CONFIRMED);
        GridViewFriendsList.DataBind();
        GridViewFriendsListRequest.DataSource = FriendsBLL.getAllFriendsListName(Userid, Global.PENDING);
        GridViewFriendsListRequest.DataBind();
        if (Userid != Session["UserId"].ToString())
            GridViewFriendsList.Columns[2].Visible = false;

    }


  

    protected void GridViewFriendsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FriendsBLL.deleteFriends(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value.ToString());
        LoadFriendsList();
       
    }

    protected void GridViewFriendsListRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        string friendid = GridViewFriendsListRequest.DataKeys[GridViewFriendsListRequest.SelectedIndex].Value.ToString();

        Response.Redirect("FriendofFriendsList.aspx?UserId=" + friendid + "&Type=Mutual");
        
    }

    protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridViewFriendsList.PageIndex = GridViewFriendsList.PageIndex + 1;
       
    }
    private Boolean validate_checkbox(string CheckBox)
    {
        return (CheckBox == "Name" || CheckBox == "CurrrentCity" || CheckBox == "HomeTown" || CheckBox == "School" || CheckBox == "WorkPlace");
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string fieldValue = SearchTextBox.Text;
        if (validate_checkbox(SearchDropDownList.Text))
        {
            GridViewFriendsList.DataSource = FriendsBLL.FindByListName(Userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
        }

    }

    protected void GridViewFriendsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFriendsList.PageIndex = e.NewPageIndex;
        LoadFriendsList();
    }
}