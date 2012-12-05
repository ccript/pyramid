using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using System.Collections;

public partial class MultiSelect : System.Web.UI.Page
{

    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count == 0)
            {
                userid = Session["UserId"].ToString();
                Session["TempUserId"] = null;
            }
            else
            {
                userid = Request.QueryString.Get(0);
                Session["TempUserId"] = userid;
            }

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }

        ((Label)Master.FindControl("lblTitle")).Text = "FriendsList";
        if (!IsPostBack)
        {

            LoadFriendsList();
        }
        
    }


    protected void LoadFriendsList()
    {
        MultiSelectGrid.DataSource = FriendsBLL.getAllFriendsListName(userid, Global.CONFIRMED);
        MultiSelectGrid.DataBind();
    }



    protected void GridViewFriendsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FriendsBLL.deleteFriends(MultiSelectGrid.DataKeys[MultiSelectGrid.SelectedIndex].Value.ToString());
        LoadFriendsList();

    }


    protected void btnPostback_Click(object sender, EventArgs e)
    {

        int[] arr = GetSelectedIndices();
        List<int> lst = new List<int>();
        
    }

    private int[] GetSelectedIndices()
    {
        ArrayList indicesList = new ArrayList();
        for (int i = 0; i < MultiSelectGrid.Rows.Count; i++)
        {
            GridViewRow row = MultiSelectGrid.Rows[i];
            CheckBox chk = row.Cells[0].FindControl("chkSelect") as CheckBox;
            if (chk != null && chk.Checked)
            {
                indicesList.Add(i);
                Response.Write(i);
            }
        }
        return (int[])indicesList.ToArray(typeof(int));
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
}