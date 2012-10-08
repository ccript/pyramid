using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;

public partial class User_ChangeFriendList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ListDropDownList
        string userid = Request.QueryString[0];

        if (ListDropDownList.Items.Count == 0)
        {
            foreach (ObjectLayer.ListViewBO obj in ListViewBLL.getList(userid, Global.CONFIRMED))
            {
                ListDropDownList.Items.Add(obj.ListName);
            }
        }
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        string userid = Request.QueryString["UserId"];
        string list = ListDropDownList.SelectedValue;
        ListViewBLL.UpdateFriendList(userid, list);
    }
}