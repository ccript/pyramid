using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class User_Notification : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Notifications";
        try
        {

           
            userid = Session["UserId"].ToString();

        }

        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        LoadDataListMedia();
    }

    protected void LoadDataListMedia()
    {

        GridViewNotification.DataSource = NotificationBLL.getNotificationByUserId(userid);
        GridViewNotification.DataBind();

        foreach (GridViewRow gvr in GridViewNotification.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                HiddenField hfdate = (HiddenField)gvr.FindControl("HiddenFieldAddedDate");
                Label labeldate = (Label)gvr.FindControl("lblAddedDate");
        

                DateTime date = Convert.ToDateTime(hfdate.Value);
                labeldate.Text = TimeAgo(date);
                HiddenField hfStatus = (HiddenField)gvr.FindControl("HiddenFieldStatus");
                if (Convert.ToBoolean(hfStatus.Value) == false)
                {
                    gvr.BackColor = System.Drawing.Color.FromName("#EFD2D8");
                   
                }
                   // gvr.BackColor = System.Drawing.Color.FromName("#D0122B");
            }

        }
        NotificationBLL.updateNotificationStatus(userid);

    }
    protected void GridViewNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewNotification.PageIndex = e.NewPageIndex;
        LoadDataListMedia();
    }

    public static string TimeAgo(DateTime date)
    {

        date = date.AddHours(5);
        TimeSpan timeSince = DateTime.Now.Subtract(date);

        if (timeSince.TotalMilliseconds < 1)
            return "not yet";

        if (timeSince.TotalMinutes < 1)
            return "Just now";
        if (timeSince.TotalMinutes < 2)
            return "1 minute ago";
        if (timeSince.TotalMinutes < 60)
            return string.Format("{0} minutes ago", timeSince.Minutes);
        if (timeSince.TotalMinutes < 120)
            return "1 hour ago";
        if (timeSince.TotalHours < 24)
            return string.Format("{0} hours ago", timeSince.Hours);
        if (timeSince.TotalDays == 1)
            return "yesterday";
        if (timeSince.TotalDays < 7)
            return string.Format("{0} days ago", timeSince.Days);
        if (timeSince.TotalDays < 14)
            return "last week";
        if (timeSince.TotalDays < 21)
            return "2 weeks ago";
        if (timeSince.TotalDays < 28)
            return "3 weeks ago";
        if (timeSince.TotalDays < 60)
            return "last month";
        if (timeSince.TotalDays < 365)
            return string.Format("{0} months ago", Math.Round(timeSince.TotalDays / 30));
        if (timeSince.TotalDays < 730)
            return "last year";
        //last but not least...
        return string.Format("{0} years ago", Math.Round(timeSince.TotalDays / 365));
    }
 
}