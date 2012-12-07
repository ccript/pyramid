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
            return HttpContext.Current.Session[Global.SESSION_USER_ID].ToString();
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
            return HttpContext.Current.Session[Global.SESSION_PHOTO_ALBUM_ID].ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/UI/User/Photos.aspx");
        }
        return null;
    }

    public static void clearSession()
    {        
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }
    public static string getUserIdOrTempUserId()
    {
        try
        {
            if (HttpContext.Current.Request.QueryString.Count == 0)
            {
                HttpContext.Current.Session[Global.SESSION_TEMP_USER_ID] = null;
                return SessionClass.getUserId();
            }
            else
            {
                HttpContext.Current.Session[Global.SESSION_TEMP_USER_ID] = HttpContext.Current.Request.QueryString.Get(0);
                return HttpContext.Current.Request.QueryString.Get(0);
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
        return null;
    }

    public static int getPostType()
    {
        return Convert.ToInt32(HttpContext.Current.Session[Global.SESSION_POST_TYPE]);
    }

    public static string getEmbedPost()
    {
        return Convert.ToString(HttpContext.Current.Session[Global.SESSION_EMBED_POST]);
    }

    public static string getShareWithID()
    {
        return Convert.ToString(HttpContext.Current.Session[Global.SESSION_SHARE_WITH_ID]);
    }

    public static string getPostID()
    {
        return Convert.ToString(HttpContext.Current.Session[Global.SESSION_POST_ID]);
    }

    public static object getTaggedFriends()
    {
        return HttpContext.Current.Session[Global.SESSION_TAGGED_FRIENDS];
    }

    public static string getUserEmail()
    {
        return Convert.ToString(HttpContext.Current.Session[Global.SESSION_USER_EMIAL]);
    }
}