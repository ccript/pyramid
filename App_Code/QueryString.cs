using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonClass
/// </summary>
public class QueryString
{
    public static string getQueryStringOnIndex(int index)
    {
        try
        {
            return HttpContext.Current.Request.QueryString.Get(index);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
        return null;
    }
}