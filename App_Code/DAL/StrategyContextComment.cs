using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;


namespace DataLayer
{
    public class StrategyContextComment
    {
        private StrategyInterfacecomment strategyInterface;

        public StrategyContextComment(StrategyInterfacecomment strategy)
        {
            strategyInterface = strategy;
        }

        //Executes the strategy
        public string insertComments(CommentsBO objClass)
        {
            return strategyInterface.insertComments(objClass);
        }

        public void updateComments(CommentsBO objClass)
        {
            strategyInterface.updateComments(objClass);
        }

        public List<Comments> getCommentsList(int Type, string AtId)
        {
            return strategyInterface.getCommentsList(Type, AtId);
        }

    }
}