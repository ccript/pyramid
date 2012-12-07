using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

namespace BuinessLayer
{
    /// <summary>
    /// Summary description for DeviceBLL
    /// </summary>
    public class TickerBLL
    {
        public TickerBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
        //////////////////////////////////////////////////////////////
        public static string insertTicker(TickerBO objTicker)
        {
           

                return TickerDAL.insertTicker(objTicker);
       
        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteTicker(string TickerId)
        {
            TickerDAL.deleteTicker(TickerId);
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateTicker(TickerBO objTicker)
        {
            TickerDAL.updateTicker(objTicker);
        }

        ///////////////////////////////////////////////////////////////
        //                       SELECT ALL DATA
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getAllTickerList()
        {
            return TickerDAL.getAllTickerList();
        }
        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static TickerBO getTickerByTickerId(string TickerId)
        {
            return TickerDAL.getTickerByTickerId(TickerId);
        }
        public static void updateLiteral(string Tickerid, string postval,string embedval)
        {
            TickerDAL.updateLiteral(Tickerid, postval, embedval);
        }

        ///////////////////////////////////////////////////////////////
        //                        SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static List<Ticker> getTickerByUserId(string UserId,int top)
        {
            return TickerDAL.getTickerByUserId(UserId,top);
        }

        public static List<Ticker> getSeeFriendShipTicker(string FUserId, string UserId, int top)
        {
            return TickerDAL.getSeeFriendShipTicker(FUserId, UserId, top);

        }

        public static List<Ticker> getTickerByUserIdAndFriendID(string UserId, string FriendID, int top)
        {
            return TickerDAL.getTickerByUserIdAndFriendID(UserId, FriendID, top);
        }

    }
     
}