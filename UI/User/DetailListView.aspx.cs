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

public partial class User_DetailListView : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        try
        {
            userid = Session["UserId"].ToString();

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        
        string listname=Request.QueryString["ListName"];
        ((Label)Page.Master.FindControl("lblTitle")).Text = "Friends in " + listname + " list";
        GridViewFriendsList.DataSource = ListViewBLL.getFreindByList(userid, Global.CONFIRMED,listname);
        GridViewFriendsList.DataBind();

        Panel1.DefaultButton = "SearchButton";
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string fieldValue = SearchTextBox.Text;

        string userid;
        userid = Session["UserId"].ToString();

            GridViewFriendsList.DataSource = FriendsBLL.FindByListName(userid, fieldValue, Global.CONFIRMED);
            GridViewFriendsList.DataBind();
        
    }


    protected void GridViewFriendsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFriendsList.PageIndex = e.NewPageIndex;
        string fieldValue = SearchTextBox.Text;

        string userid;
        userid = Session["UserId"].ToString();

        GridViewFriendsList.DataSource = FriendsBLL.FindByListName(userid, fieldValue, Global.CONFIRMED);
        GridViewFriendsList.DataBind();
        
    }
}