using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using ObjectLayer;


public class ReenterBLL
{
	public ReenterBLL()
	{
	}
    public static string getFullUserName(string UserName)
    {
        return ReenterDAL.getFullUserName(UserName);
    }
}
