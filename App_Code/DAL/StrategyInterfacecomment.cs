using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;


/// <summary>
/// Summary description for AbstractCommentStrategy
/// </summary>
/// 

namespace DataLayer
{

    public interface StrategyInterfacecomment
    {
        string insertComments(CommentsBO objClass);
        void updateComments(CommentsBO objClass);
        List<Comments> getCommentsList(int Type, string AtId);
    }
}
