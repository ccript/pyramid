using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BuinessLayer;
using ObjectLayer;
using System.Globalization;
using System.Collections.Generic;

public partial class UI_User_SuggestFriends : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    private string fname;

    public string Fname
    {
        get { return fname; }
        set { fname = value; }
    }
    private string lname;

    public string Lname
    {
        get { return lname; }
        set { lname = value; }
    }
    private List<UserFriendsBO> list = new List<UserFriendsBO>();
    private static List<UserFriendsBO> list2 = new List<UserFriendsBO>();
    private static string fid = "";//the person to whom suggestions are being given

    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = SessionClass.getUserId();
        Fname = QueryString.getQueryStringOnIndex(0);
        Lname = QueryString.getQueryStringOnIndex(1);
        ((Label)Master.FindControl("lblTitle")).Text = "Suggest Friends to " +Fname+" "+Lname;
        if (!IsPostBack)
        {

            LoadSuggestions("");

            if (ddl_FilterByList.Items.Count == 0)
            {
                ddl_FilterByList.Items.Add("None");
                foreach (ObjectLayer.ListViewBO obj in ListViewBLL.getDefaultListNames())
                {
                    ddl_FilterByList.Items.Add(obj.ListName);
                }
            }

        }


    }

    public List<UserFriendsBO> getfriends_list(string FilterByListName)
    {
        if (!FilterByListName.Equals("") && !FilterByListName.Equals("None"))
        {
            list = FriendsBLL.getAllFriendsFilterByList(Userid, Global.CONFIRMED, FilterByListName);// FriendsBLL.getAllSuggestions(userid);
        }
        else
        {
            list = FriendsBLL.getAllFriendsListName(Userid, Global.CONFIRMED);// FriendsBLL.getAllSuggestions(userid);
        }

        return list;
    }

    public Boolean VerifyUserItem(string fname, string lname)
    {
        if (fname.Equals(Fname) && lname.Equals(Lname))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected void LoadSuggestions(string FilterByListName)
    {
        list = new List<UserFriendsBO>();
        list2 = new List<UserFriendsBO>();
        List<UserFriendsBO> userlist = new List<UserFriendsBO>();
        List<UserFriendsBO> reclist = new List<UserFriendsBO>();
        
        list = getfriends_list(FilterByListName);

        foreach (UserFriendsBO Useritem in list)
        {

            if (VerifyUserItem(Useritem.FirstName, Useritem.LastName))
            {
                userlist.Add(Useritem);
                fid = Useritem.FriendUserId;
            }
            else
            {
                list2.Add(Useritem);
            }
        }

        List<UserFriendsBO> mutualfriendslist = FriendsBLL.getMutualFriends(Userid, fid, Global.CONFIRMED);
        IEqualityComparer<UserFriendsBO> comparer = new UserFriendsComparer();
        List<UserFriendsBO> l3 = list2.Except(mutualfriendslist, comparer).ToList();
        List<UserFriendsBO> PSlist = FriendsBLL.getPSFriends(fid);
        List<UserFriendsBO> l4 = l3.Except(PSlist, comparer).ToList();

        AllSuggestionsDataList.DataSource = l4;
        AllSuggestionsDataList.DataBind();
        MutualDataList.DataSource = mutualfriendslist;
        MutualDataList.DataBind();

        string belongsto = ListViewBLL.getListName(Userid, fid);

        foreach (UserFriendsBO Useritem in l4)
        {
            Useritem.Score = 0;
            string belongsto1 = ListViewBLL.getListName(Userid, Useritem.FriendUserId);
            string belongsto2 = ListViewBLL.getListName(Useritem.FriendUserId, Userid);

            if (belongsto1.Equals(belongsto) || belongsto2.Equals(belongsto))//if no value specified by user by default true
            {
                Useritem.Score += 1 * Global.WEIGHT_LIST;
            }

        }
        List<UserFriendsBO> scoredlist = FriendsBLL.RecommendationScoring(l4, fid);
        reclist = scoredlist.Take(6).ToList();
        RecSuggestionsDataList.DataSource = reclist;
        RecSuggestionsDataList.DataBind();

        l4 = l4.Except(reclist, comparer).ToList();

        PagedDataSource objPds = new PagedDataSource();

        objPds.DataSource = l4;
        objPds.AllowPaging = true;
        objPds.PageSize = 6;
        objPds.CurrentPageIndex = CurrentPage;
        lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "+ objPds.PageCount.ToString();

        cmdPrev.Enabled = !objPds.IsFirstPage;
        cmdNext.Enabled = !objPds.IsLastPage;

        AllSuggestionsDataList.DataSource = objPds;
        AllSuggestionsDataList.DataBind();
 
    }


    protected void cmdPrev_Click(object sender, System.EventArgs e)
    {
        CurrentPage -= 1;
        LoadSuggestions("");
    }

    protected void cmdNext_Click(object sender, System.EventArgs e)
    {
        CurrentPage += 1;
        LoadSuggestions("");
    }
    public int CurrentPage
    {

        get
        {

            object o = this.ViewState["_CurrentPage"];

            if (o == null)
                return 0; // default to showing the first page
            else
                return (int)o;

        }

        set
        {

            this.ViewState["_CurrentPage"] = value;

        }

    }

    public class UserFriendsComparer : IEqualityComparer<UserFriendsBO>
    {
        public bool Equals(UserFriendsBO x, UserFriendsBO y)
        {
            return x.FriendUserId == y.FriendUserId;
        }

        public int GetHashCode(UserFriendsBO obj)
        {
            return obj.FriendUserId.GetHashCode();
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string fieldValue = FindFriendsTextBox.Text;
        List<UserFriendsBO> searchlist = new List<UserFriendsBO>();//search list
        string userid;
        userid = Session["UserId"].ToString();
        foreach(UserFriendsBO u in list2)
        {
            if (fieldValue.Contains(u.FirstName) || fieldValue.Contains(u.LastName))
                searchlist.Add(u);

        }
        AllSuggestionsDataList.DataSource = searchlist;
        AllSuggestionsDataList.DataBind();
        RecSuggestionsDataList.DataSource = null;
        RecSuggestionsDataList.DataBind();
        MutualDataList.DataSource = null;
        MutualDataList.DataBind();
    }
    protected void GridViewFriendsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    
    protected void AllSuggestionsDataList_ItemCommand(object sender, DataListCommandEventArgs e)
    {

    }
    protected void RecSuggestionsDataList_ItemCommand(object sender, DataListCommandEventArgs e)
    {
    }
    protected void handle()
    { }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        ddl_FilterByList.Text = "None";
        LoadSuggestions("");

    }
    protected void btnSendSuggestions_Click(object sender, EventArgs e)
    {
        string Dl = "Items Checked:";
        foreach (DataListItem dli in RecSuggestionsDataList.Items)
        {
            CheckBox chk = (CheckBox)dli.FindControl("CheckBox2");
            if (chk != null)
            {
                if (chk.Checked)
                {
                    string friendid = RecSuggestionsDataList.DataKeys[dli.ItemIndex].ToString();
                    FriendsBLL.sendFriendSuggestion(friendid,fid);//send request to person for whom suggestions shown
                }
            }
        }


        foreach (DataListItem dli in AllSuggestionsDataList.Items)
        {
            CheckBox chk = (CheckBox)dli.FindControl("CheckBox2");
            if (chk != null)
            {
                if (chk.Checked)
                {
                    //get the userid of the checked person
                    string friendid = AllSuggestionsDataList.DataKeys[dli.ItemIndex].ToString();
                    FriendsBLL.sendFriendSuggestion(friendid, fid);//send request to person for whom suggestions shown
                    // Dl += friendid ;
                }
            }
        }
        //FindFriendsTextBox.Text = Dl;
        LoadSuggestions("");
    }


    protected void ddl_FilterByList_SelectedIndexChanged(object sender, EventArgs e)
    {
       // FindFriendsTextBox.Text = ddl_FilterByList.Text;
        LoadSuggestions(ddl_FilterByList.Text);

    }
}