using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonClass
/// </summary>
public class SessionClass
{
    public static string getUserId()
    {
        try
        {
            return HttpContext.Current.Session["UserId"].ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
        return null;
    }

    public static string getPhotoAlbumId()
    {
        try
        {
            return HttpContext.Current.Session["PhotoAlbumId"].ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/UI/User/Photos.aspx");
        }
        return null;
    }

    public static void clearSession()
    {
        HttpContext.Current.Session["UserId"] = null;
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }
    public static string getUserIdOrTempUserId()
    {
        try
        {
            if (HttpContext.Current.Request.QueryString.Count == 0)
            {
                HttpContext.Current.Session["TempUserId"] = null;
                return SessionClass.getUserId();
            }
            else
            {
                HttpContext.Current.Session["TempUserId"] = HttpContext.Current.Request.QueryString.Get(0);
                return HttpContext.Current.Request.QueryString.Get(0);
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
        return null;
    }

}