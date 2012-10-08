using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;

namespace BuinessLayer
{
    public class ListViewBLL
    {
        public static void insertListName(ListViewBO objClass)
        {

            ListViewDAL.insertListName(objClass);
        }
        public static List<ListViewBO> getList(string userid, string status)
        {
            return ListViewDAL.getAllListView(userid,status);
        }
        public static List<ListViewBO> getDefaultListNames()
        {
            return ListViewDAL.getDefaultListNames();
        }

        public static List<UserFriendsBO> getFreindByList(string userid, string status, string listname)
        {
            return ListViewDAL.getFriendsByList(userid, status,listname);
        }

        public static void UpdateList(string oldListName, string newListName)
        {
            ListViewDAL.UpdateListDAL(oldListName, newListName);
        }

        public static void UpdateFriendList(string userid, string newListName)
        {
            ListViewDAL.UpdateFriendList(userid, newListName);
        }

        public static void UpdateFriendListSearch(string id, string newListName)
        {
            ListViewDAL.UpdateFriendListBySelect(id, newListName);
        }
        public static string getListName(string userid,string frienduserid)

        {
            return ListViewDAL.getListName(userid,frienduserid);
        }

    }
}