using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using ObjectLayer;

/// <summary>
/// Summary description for ReenterBLL
/// </summary>
public class ReenterBLL
{
	public ReenterBLL()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    public static string getFullUserName(string UserName)
    {
        return ReenterDAL.getFullUserName(UserName);

    }
}