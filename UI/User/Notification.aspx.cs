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
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("lblTitle")).Text = "Notifications";
        Userid = SessionClass.getUserId();
        LoadDataListMedia();
    }

    protected void LoadDataListMedia()
    {

        GridViewNotification.DataSource = NotificationBLL.getNotificationByUserId(Userid);
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
        NotificationBLL.updateNotificationStatus(Userid);

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
            return Global.NOT_YET;

        if (timeSince.TotalMinutes < 1)
            return Global.JUST_NOW;
        if (timeSince.TotalMinutes < 2)
            return Global.ONE_MINUTE_AGO;
        if (timeSince.TotalMinutes < 60)
            return string.Format(Global.MINTUES_AGO, timeSince.Minutes);
        if (timeSince.TotalMinutes < 120)
            return Global.ONE_HOUR_AGO;
        if (timeSince.TotalHours < 24)
            return string.Format(Global.HOURS_AGO, timeSince.Hours);
        if (timeSince.TotalDays == 1)
            return Global.YESTERDAY;
        if (timeSince.TotalDays < 7)
            return string.Format(Global.DAYS_AGO, timeSince.Days);
        if (timeSince.TotalDays < 14)
            return Global.LAST_WEEK;
        if (timeSince.TotalDays < 21)
            return Global.TWO_WEEKS_AGO;
        if (timeSince.TotalDays < 28)
            return Global.THREE_WEEKS_AGO;
        if (timeSince.TotalDays < 60)
            return Global.LAST_MONTH;
        if (timeSince.TotalDays < 365)
            return string.Format(Global.MONTHS_AGO, Math.Round(timeSince.TotalDays / 30));
        if (timeSince.TotalDays < 730)
            return Global.LAST_YEAR;

        return string.Format(Global.YEARS_AGO, Math.Round(timeSince.TotalDays / 365));
    }
 
}