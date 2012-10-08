using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using System.Collections;


public partial class User_AdvanceOptions : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count == 0)
            {
                userid = Session["UserId"].ToString();
            }
            else
            {
                userid = Request.QueryString.Get(0);
                Session["TempUserId"] = userid;
            }

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        ((Label)Master.FindControl("lblTitle")).Text = "Manage Your Friends";
        if (!IsPostBack)
        {

            LoadFriendsList();


        }

        if (ListDropDownList.Items.Count == 0)
        {
            foreach (ObjectLayer.ListViewBO obj in ListViewBLL.getList(userid, Global.CONFIRMED))
            {
                ListDropDownList.Items.Add(obj.ListName);
            }
        }

        Panel1.DefaultButton = "SearchButton";
    }


    protected void LoadFriendsList()
    {


        MultiSelectGrid.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.CONFIRMED);
        MultiSelectGrid.DataBind();

        // GridViewFriendsListRequest.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.PENDING);
        // GridViewFriendsListRequest.DataBind();
    }



    protected void GridViewFriendsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FriendsBLL.deleteFriends(MultiSelectGrid.DataKeys[MultiSelectGrid.SelectedIndex].Value.ToString());
        LoadFriendsList();
        // Response.Write(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value);
    }
    //protected void GridViewFriendsListRequest_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string friendid = GridViewFriendsListRequest.DataKeys[GridViewFriendsListRequest.SelectedIndex].Value.ToString();

    //    Response.Redirect("FriendofFriendsList.aspx?UserId=" + friendid + "&Type=Mutual");

    //}

    protected void btnPostback_Click(object sender, EventArgs e)
    {
        //string selectedName = "";

        //foreach (GridViewRow row in MultiSelectGrid.Rows)
        //{
        //    HiddenField selectionButton = (HiddenField)row.FindControl("hdnIsItemSelected");
        //    if (selectionButton.Value == "true")
        //    {
        //        selectedName += (selectedName == "" ? "" : " / ") + ((Label)row.FindControl("lblFirstName")).Text;
        //    }
        //}

        //lblSelectedName.Text = selectedName;
        
        //int[] arr = GetSelectedIndices();
        //List<int> lst = new List<int>();

    }

    

    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < MultiSelectGrid.Rows.Count; i++)
        {
            GridViewRow row = MultiSelectGrid.Rows[i];
            // 0 means the first column if your Select column is not first write it 's correct index
            CheckBox chk = row.Cells[0].FindControl("chkSelect") as CheckBox;
            chk.Checked = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < MultiSelectGrid.Rows.Count; i++)
        {
            GridViewRow row = MultiSelectGrid.Rows[i];
            // 0 means the first column if your Select column is not first write it 's correct index
            CheckBox chk = row.Cells[0].FindControl("chkSelect") as CheckBox;
            chk.Checked = false;
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string fieldValue = SearchTextBox.Text;

        string userid;
        userid = Session["UserId"].ToString();

        MultiSelectGrid.DataSource = FriendsBLL.FindByListName(userid, fieldValue, Global.CONFIRMED);
        MultiSelectGrid.DataBind();

    }

    protected void AddButton_Click(object sender, EventArgs e)
    {

        string userid = Request.QueryString["UserId"];
        string list = ListDropDownList.SelectedValue;

        //Response.Write(list);

        ArrayList indicesList = new ArrayList();
        for (int i = 0; i < MultiSelectGrid.Rows.Count; i++)
        {
            GridViewRow row = MultiSelectGrid.Rows[i];
            // 0 means the first column if your Select column is not first write it 's correct index
            CheckBox chk = row.Cells[0].FindControl("chkSelect") as CheckBox;
            if (chk != null && chk.Checked)
            {
                string value = MultiSelectGrid.Rows[i].Cells[1].Text;
                ListViewBLL.UpdateFriendListSearch(value,list);
            }
        }
        Response.Redirect("AdvanceOptions.aspx");
       // ListViewBLL.UpdateFriendList(userid, list);
    }

    private int[] GetSelectedIndices()
    {
        ArrayList indicesList = new ArrayList();
        for (int i = 0; i < MultiSelectGrid.Rows.Count; i++)
        {
            GridViewRow row = MultiSelectGrid.Rows[i];
            // 0 means the first column if your Select column is not first write it 's correct index
            CheckBox chk = row.Cells[0].FindControl("chkSelect") as CheckBox;
            if (chk != null && chk.Checked)
            {
                indicesList.Add(i);
                //Response.Write(i);
            }
        }
        return (int[])indicesList.ToArray(typeof(int));
    }

    protected void GridViewFriendsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MultiSelectGrid.PageIndex = e.NewPageIndex;
        LoadFriendsList();
    }
}