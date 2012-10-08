using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectLayer;
using System.Globalization;
using System.Text.RegularExpressions;
using AjaxControlToolkit;
using System.Text;
using BuinessLayer;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectLayer;
using System.Globalization;
using System.Text.RegularExpressions;
using AjaxControlToolkit;
using System.Text;
using BuinessLayer;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;


public partial class UI_UserProfile_MasterPage : System.Web.UI.MasterPage
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["UserId"] = "4f37fdd8745cb305e42cd7a0";



        try
        {
            userid = Session["UserId"].ToString();
           
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }


     
        NotificationCount();
      
        /* LiteralNotify.Text = "Welcome to Pyramid Plus";
         if (!Page.ClientScript.IsStartupScriptRegistered("alert"))
         {
             Page.ClientScript.RegisterStartupScript
                 (this.GetType(), "alert", "insideJS();", true);
         }*/
    }

  

    /*protected void LoadLoginUserData(string id)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(id);
        lbluser.Text = objUser.FirstName + " " + objUser.LastName;
        ImgUser.ImageUrl = Global.PROFILE_PICTURE + id + ".jpg";

    }*/


    protected void imgBtnSearchFriends_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../User/SearchUserList.aspx?Search=" + txtFriendSearch.Text);
    }


    protected void NotificationCount()
    {
        // long nt = 0,newnt=0;
        // if (lblNotification.Text.Length > 0)
        //   nt = Convert.ToInt64(lblNotification.Text);

        long cnotif = Convert.ToInt64(NotificationBLL.countNotification(userid).ToString());

        lblNotification.Text = cnotif.ToString();
        if (cnotif == 000)
            lblNotification.Visible = false;
        long crequest = Convert.ToInt64(FriendsBLL.countFriendRequests(userid, Global.PENDING).ToString());
        lblFriendsRequest.Text = crequest.ToString();
        if (crequest == 000)
            lblFriendsRequest.Visible = false;
        //  newnt = Convert.ToInt64(lblNotification.Text);
        //if (newnt > nt)
        //{


        //ScriptManager.RegisterClientScriptBlock(UpdatePanel3, UpdatePanel3.GetType(), "script", "insideJS();", true);
        //}
    }
 
}




