using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ManageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "Manage List";

        Label1.Text = "Current list name:";
        ListButton.Text = "Rename";
        string listname = Request.QueryString["ListName"];
        ListTextBox.Text = listname;
    }

    protected void ListButton_Click(object sender, EventArgs e)
    {
        Response.Write(ListTextBox.Text);
        BuinessLayer.ListViewBLL.UpdateList(Request.QueryString["ListName"], newTextBox.Text);
        Response.Redirect("ListView.aspx");
    }
}