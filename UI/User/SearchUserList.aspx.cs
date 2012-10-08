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
using System.Drawing;

public partial class FriendsList : System.Web.UI.Page
{
    private string friendid;
    string userid;
    string search;
    bool requestsent = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        try
        {
            userid = Session["UserId"].ToString();
            search= Request.QueryString.Get(0);
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        ((Label)Master.FindControl("lblTitle")).Text = "Search User";
        if (!IsPostBack)
        {

            LoadFriendsList();
            
          
        }

        Panel1.DefaultButton = "imgBtnSearchFriends";
    }


    protected void LoadFriendsList()
    {


        GridViewSearchUser.DataSource = UserBLL.SearchUserList(search,true,userid);
        GridViewSearchUser.DataBind();
             inVisibleAddFriends();
    }



    protected void imgBtnSearchFriends_Click(object sender, ImageClickEventArgs e)
    {
       
        if (lstSearchBy.SelectedValue == "Location")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyLocation(txtSearchBy.Text,true);
            GridViewSearchUser.DataBind();

        }
        else if (lstSearchBy.SelectedValue == "Name")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserList(txtSearchBy.Text, true, userid);
            GridViewSearchUser.DataBind();
        }
        else if (lstSearchBy.SelectedValue == "Education")
        {

            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyEducation(txtSearchBy.Text, Convert.ToInt32( lstClassYear.Text),true);
            GridViewSearchUser.DataBind();
        }
        else if (lstSearchBy.SelectedValue == "Workplace")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyWorkSpace(txtSearchBy.Text,true);
            GridViewSearchUser.DataBind();
        }


        else if (lstSearchBy.SelectedValue == "Location & Work")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyLocation(txtSearchBy.Text, true);
            GridViewSearchUser.DataBind();
        }

        else if (lstSearchBy.SelectedValue == "Education & Work")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyEducation(txtSearchBy.Text, Convert.ToInt32(lstClassYear.Text), true);
            GridViewSearchUser.DataBind();
        }

        else if (lstSearchBy.SelectedValue == "Education & Location")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyEducation(txtSearchBy.Text, Convert.ToInt32(lstClassYear.Text), true);
            GridViewSearchUser.DataBind();
        }

        else if (lstSearchBy.SelectedValue == "All")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = true;
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyWorkSpace(txtSearchBy.Text, true);
            GridViewSearchUser.DataBind();
        }
    }
    protected void lstSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (lstSearchBy.SelectedValue == "Education")
        {
            lstClassYear.Visible = true;

        }
        else
        {

            lstClassYear.Visible = false ;
        }
        if (lstSearchBy.SelectedValue == "Location")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;

            TextBoxWatermarkExtender1.WatermarkText = "Search By Location";
        }
        else if (lstSearchBy.SelectedValue == "Name")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Name";
        }
        else if (lstSearchBy.SelectedValue == "Education")
        {
            lstClassYear.Visible = true;
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Education";
  
        }
        else if (lstSearchBy.SelectedValue == "Workplace")
        {
            txtSearchBy2.Visible = false;
            txtSearchBy3.Visible = false;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Workplace";
        }


        else if (lstSearchBy.SelectedValue == "Location & Work")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Location";
            TextBoxWatermarkExtender2.WatermarkText = "Search By Workspace";
        }

        else if (lstSearchBy.SelectedValue == "Education & Work")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            lstClassYear.Visible = true;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Education ";
            TextBoxWatermarkExtender2.WatermarkText = "Search By Workspace";
        }

        else if (lstSearchBy.SelectedValue == "Education & Location")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = false;
            lstClassYear.Visible = true;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Education";
            TextBoxWatermarkExtender2.WatermarkText = "Search By Location ";
     
        }

        else if (lstSearchBy.SelectedValue == "All")
        {
            txtSearchBy2.Visible = true;
            txtSearchBy3.Visible = true;
            lstClassYear.Visible = true;
            TextBoxWatermarkExtender1.WatermarkText = "Search By Workspace";
            TextBoxWatermarkExtender2.WatermarkText = "Search By Location ";
            TextBoxWatermarkExtender3.WatermarkText = "Search By Education";
        }


    }

    protected void GridViewSearchUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       

        GridViewRow row = GridViewSearchUser.Rows[Convert.ToInt32(e.CommandArgument)];

        friendid = GridViewSearchUser.DataKeys[row.RowIndex].Value.ToString();
        string s = ((LinkButton)(row.Cells[1].Controls[0])).Text;
        if (s.Equals("Add Friend"))
        {

            FriendsBLL.sendFriendRequest(userid, friendid);
            requestsent = true;
            //e.Row.Cells[0].Controls[0].Attributes.Add("onclick", "alert(‘An alert’);")
            //row.Cells[0].Controls[0].Visible=false;
            //row.Cells[1].Controls[0].Visible = true;
            ((LinkButton)(row.Cells[1].Controls[0])).Text = "Cancel Request";
            //row.FindControl("btnAddFriend").Visible = true;

            //row.FindControl("btnCancelRequest").Visible = false;

        }
        else if (s.Equals("Cancel Request"))
        {
            FriendsBLL.cancelFriendRequest(userid, friendid);
            requestsent = false;
            //row.Cells[1].Controls[0]. = false;
            //row.Cells[0].Controls[0].Visible = true;
            ((LinkButton)(row.Cells[1].Controls[0])).Text = "Add Friend";
            //row.FindControl("btnAddFriend").Visible = false;
            //row.FindControl("btnCancelRequest").Visible = true;

        }
    }
    protected void lbtnMore_Click(object sender, EventArgs e)
    {
        if (lstSearchBy.SelectedValue == "Location")
        {
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyLocation(txtSearchBy.Text,false);
            GridViewSearchUser.DataBind();

        }
        else if (lstSearchBy.SelectedValue == "Name")
        {
            GridViewSearchUser.DataSource = UserBLL.SearchUserList(txtSearchBy.Text, false,userid);
            GridViewSearchUser.DataBind();
        }
        else if (lstSearchBy.SelectedValue == "Education")
        {

            GridViewSearchUser.DataSource = UserBLL.SearchUserbyEducation(txtSearchBy.Text, Convert.ToInt32(lstClassYear.Text),false);
            GridViewSearchUser.DataBind();
        }
        else if (lstSearchBy.SelectedValue == "Workplace")
        {
            GridViewSearchUser.DataSource = UserBLL.SearchUserbyWorkSpace(txtSearchBy.Text,false);
            GridViewSearchUser.DataBind();
        }
        inVisibleAddFriends();
    }

    protected void inVisibleAddFriends()
    {

        foreach (GridViewRow gvr in GridViewSearchUser.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                string sValue = ((HiddenField)gvr.FindControl("HiddenField1")).Value;
                if (FriendsBLL.isExistingFriend(userid, sValue))
                {
                    gvr.Cells[1].Visible = true;
                    gvr.Cells[1].Text = "Already Friend";
                    gvr.Cells[1].ForeColor = ColorTranslator.FromHtml("#808080");

                }
                else
                {
                    gvr.Cells[1].ForeColor = ColorTranslator.FromHtml("#808080");
                }

            }
        }
    }
    
}