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
using System.Collections;
using System.Collections.Generic;
//using System.Linq;//

public partial class UI_User_Suggestions : System.Web.UI.Page
{
    string userid;
    bool requestsent = false;
    public static ArrayList mutualFriends = new ArrayList();
    bool mutualFriendsFetched = false;

    //
    //protected int currentPageNumber = 1;
    //private const int PAGE_SIZE = 5;

    //private List<UserFriendsBO> list = new List<UserFriendsBO>();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            if (Request.QueryString.Count == 0)
            {
                userid = Session["UserId"].ToString();
                Session["TempUserId"] = null;
            }
            else
            {
                userid = Request.QueryString.Get(0);
                Session["TempUserId"] = userid;
            }

        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
        ((Label)Master.FindControl("lblTitle")).Text = "Suggestions";
        if (!IsPostBack)
        {

            LoadSuggestions();
            LoadUserEmployersFilterItems(userid);
            LoadUserUnisFilterItems(userid);
            LoadUserSchoolsFilterItems(userid);
            LoadMutualFriends();
        }

    }
   
    //protected void GridViewFriendsList_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //FriendsBLL.deleteFriends(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value.ToString());
      //  LoadSuggestions();
        // Response.Write(GridViewFriendsList.DataKeys[GridViewFriendsList.SelectedIndex].Value);
    //}
    protected void LoadUserEmployersFilterItems(string userid)
    {
        ArrayList sEmployers;
        //List<UserFriendsBO> list = FriendsBLL.getAllSuggestions(userid).Take(4).ToList();
        sEmployers = EmployerBLL.getEmployersByUserId(userid);
        GridViewEmps.DataSource = sEmployers;
            
        GridViewEmps.DataBind();
 
    }
    protected void LoadUserUnisFilterItems(string userid)
    {
        ArrayList sUnis;
        //List<UserFriendsBO> list = FriendsBLL.getAllSuggestions(userid).Take(4).ToList();
        sUnis = UniversityBLL.getUnisByUserId(userid);
        GridViewUnis.DataSource = sUnis;

        GridViewUnis.DataBind();

    }

    protected void LoadUserSchoolsFilterItems(string userid)
    {
        ArrayList sSchools;
        //List<UserFriendsBO> list = FriendsBLL.getAllSuggestions(userid).Take(4).ToList();
        sSchools = SchoolBLL.getSchoolsByUserId(userid);
        GridViewSchool.DataSource = sSchools;

        GridViewSchool.DataBind();

    }
    protected void LoadMutualFriends()
    {
        ArrayList mFriends;
        //List<UserFriendsBO> list = FriendsBLL.getAllSuggestions(userid).Take(4).ToList();
        mFriends = mutualFriends;
        GridViewMutualFriends.DataSource = mFriends;

        GridViewMutualFriends.DataBind();

    }
    protected void LoadSuggestions()
    {
        GetSuggestionsByCriteria();
/*
        List<UserFriendsBO> list = new List<UserFriendsBO>();
        list = FriendsBLL.getAllSuggestions(userid);
        List<UserFriendsBO> scoredlist = FriendsBLL.RecommendationScoring(list,userid);
        if (scoredlist.Count == 0)
        {
            GridViewFriendsList.DataSource = list;

        }
        else
        {
            GridViewFriendsList.DataSource = scoredlist;// FriendsBLL.getAllSuggestions(userid);
        }
        GridViewFriendsList.DataBind();
 * */
       // gridStuff(list);


       //if friends are being shown for a user other than logged in user then dont show the column in grid for add/remove friends
        //if (userid != Session["UserId"].ToString())
        //    GridViewFriendsList.Columns[2].Visible = false;

    }
   
   
    protected void GridViewFriendsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string friendid;
        
       
        if (e.CommandName == "add")
        {
            GridViewRow row = GridViewFriendsList.Rows[Convert.ToInt32(e.CommandArgument)];
            friendid = GridViewFriendsList.DataKeys[row.RowIndex].Value.ToString();
            string s = ((LinkButton)(row.Cells[3].Controls[0])).Text;
            if (s.Equals("Add Friend"))
            {

                FriendsBLL.sendFriendRequest(userid, friendid);
                requestsent = true;

                ((LinkButton)(row.Cells[3].Controls[0])).Text = "Cancel Request";

            }
            else if (s.Equals("Cancel Request"))
            {
                FriendsBLL.cancelFriendRequest(userid, friendid);
                requestsent = false;
                ((LinkButton)(row.Cells[3].Controls[0])).Text = "Add Friend";


            }
 
        }else
            if (e.CommandName == "viewmutual")
            {
                GridViewRow row = GridViewFriendsList.Rows[Convert.ToInt32(e.CommandArgument)];
                friendid = GridViewFriendsList.DataKeys[row.RowIndex].Value.ToString();

                Response.Redirect("FriendofFriendsList.aspx?UserId=" + friendid + "&Type=Mutual");
            }
           
        
       
    }
    protected void GetSuggestionsByCriteria()
    {
        string HomeTownValue = HomeTownTextBox.Text;
        string EmployerValue = EmployerTextBox.Text;
        string UniversityValue = EducationTextBox.Text;
        string LocationValue = LocationTextBox.Text;
        string SchoolValue = SchoolTextBox.Text;
        
        bool hometownmatches = false;
        bool employermatches = false;
        bool unimatches = false;
        bool locationmatches = false;
        bool schoolmatches = false;
        bool mutualfriendmatches = false;
        

        //uEmployers = EmployerBLL.getEmployersByUserId(userid);
        //uUniversity = UniversityBLL.getUnisByUserId(userid);

        List<UserFriendsBO> filteredlist = new List<UserFriendsBO>();
        List<UserFriendsBO> list = new List<UserFriendsBO>();
        list = FriendsBLL.getAllSuggestions(userid);
        List<UserFriendsBO> scoredlist = FriendsBLL.RecommendationScoring(list, userid);
        foreach (UserFriendsBO Useritem in scoredlist)
        {
            ArrayList uEmployers = new ArrayList();
            ArrayList uUniversity=new ArrayList();
            ArrayList uSchool = new ArrayList();
            ArrayList sEmployers=new ArrayList();
            ArrayList sUniversity = new ArrayList();
            ArrayList sSchool = new ArrayList();
            ArrayList uMF = new ArrayList();

            hometownmatches = false;
            employermatches = false;
            unimatches = false;
            locationmatches = false;
            schoolmatches = false;
            mutualfriendmatches = false;

            sEmployers = EmployerBLL.getEmployersByUserId(Useritem.FriendUserId);
            sUniversity = UniversityBLL.getUnisByUserId(Useritem.FriendUserId);
            sSchool = SchoolBLL.getSchoolsByUserId(Useritem.FriendUserId);

            if (HomeTownValue.Equals(""))//if no value specified by user by default true
            {
                hometownmatches = true;
            }
            else
            {
                if (Useritem.Hometown != null)
                {

                    hometownmatches = Useritem.Hometown.Equals(HomeTownValue);
                }
            }
            bool mfchecked = false;

            for (int i = 0; i < GridViewMutualFriends.Rows.Count; i++)
            {
                GridViewRow row = GridViewMutualFriends.Rows[i];
                // 0 means the first column if your Select column is not first write it 's correct index
                CheckBox chk = row.Cells[0].FindControl("CheckBox1") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    mfchecked = true;
                    Label lbl = (Label)GridViewMutualFriends.Rows[i].Cells[0].FindControl("Label1");
                    string value = lbl.Text;
                    uMF.Add(value);

                    //ListViewBLL.UpdateFriendListSearch(value, list);

                }
            }
            
                foreach (string umf in uMF)
                {
                    if (Useritem.MutualFriendName.Equals(umf))
                    {
                        mutualfriendmatches = true;

                    }
                }



            
            //}
            if (mfchecked == false)
            {
                
                    mutualfriendmatches = true;

                
               
            }
            //else
            //{
                /*
                if (Useritem.Employer != null)
                {
                    employermatches = Useritem.Employer.Equals(EmployerValue);

                }*/
                //string Dl = "Items Checked:";
            bool empchecked=false;

                for (int i = 0; i < GridViewEmps.Rows.Count; i++)
                {
                    GridViewRow row = GridViewEmps.Rows[i];
                    // 0 means the first column if your Select column is not first write it 's correct index
                    CheckBox chk = row.Cells[0].FindControl("CheckBox1") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        empchecked = true;
                        Label lbl=(Label)GridViewEmps.Rows[i].Cells[0].FindControl("Label1");
                        string value = lbl.Text;
                        uEmployers.Add(value);

                        //ListViewBLL.UpdateFriendListSearch(value, list);
                        
                    }
                }
                foreach (string semp in sEmployers)
                {
                    foreach (string uemp in uEmployers)
                    {
                        if (semp.Equals(uemp))
                        {
                            employermatches = true;

                        }
                    }

                   

                }
            //}
                if (empchecked == false)
                {
                    if (EmployerValue.Equals(""))
                    {
                        employermatches = true;

                    }
                    else
                    {
                        foreach (string semp in sEmployers)
                        {
                            if (semp.Equals(EmployerValue))
                            {
                                employermatches = true;

                            }

                        }

                    }
                }
                bool unichecked = false;

                for (int i = 0; i < GridViewUnis.Rows.Count; i++)
                {
                    GridViewRow row = GridViewUnis.Rows[i];
                    // 0 means the first column if your Select column is not first write it 's correct index
                    CheckBox chk = row.Cells[0].FindControl("CheckBox1") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        unichecked = true;
                        Label lbl = (Label)GridViewUnis.Rows[i].Cells[0].FindControl("Label1");
                        string value = lbl.Text;
                        uUniversity.Add(value);

                        //ListViewBLL.UpdateFriendListSearch(value, list);

                    }
                }
                foreach (string suni in sUniversity)
                {
                    foreach (string uuni in uUniversity)
                    {
                        if (suni.Equals(uuni))
                        {
                            unimatches = true;

                        }
                    }



                }
                //}
                if (unichecked == false)
                {
                    if (UniversityValue.Equals(""))
                    {
                        unimatches = true;

                    }
                    else
                    {
                        foreach (string sUni in sUniversity)
                        {
                            if (sUni.Equals(UniversityValue))
                            {
                                unimatches = true;

                            }

                        }

                    }
                }
            /*
            if (UniversityValue.Equals(""))
            {
                unimatches = true;

            }
            else
            {
                
               
                    foreach (string sUni in sUniversity)
                    {
                        if (sUni.Equals(UniversityValue))
                        {
                            unimatches = true;

                        }

                    }


                
            }
        */
                bool schoolchecked = false;

                for (int i = 0; i < GridViewSchool.Rows.Count; i++)
                {
                    GridViewRow row = GridViewSchool.Rows[i];
                    // 0 means the first column if your Select column is not first write it 's correct index
                    CheckBox chk = row.Cells[0].FindControl("CheckBox1") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        schoolchecked = true;
                        Label lbl = (Label)GridViewSchool.Rows[i].Cells[0].FindControl("Label1");
                        string value = lbl.Text;
                        uSchool.Add(value);

                        //ListViewBLL.UpdateFriendListSearch(value, list);

                    }
                }
                foreach (string sschool in sSchool)
                {
                    foreach (string uschool in uSchool)
                    {
                        if (sschool.Equals(uSchool))
                        {
                            schoolmatches = true;

                        }
                    }



                }
                //}
                if (schoolchecked == false)
                {
                    if (SchoolValue.Equals(""))
                    {
                        schoolmatches = true;

                    }
                    else
                    {
                        foreach (string sschool in sSchool)
                        {
                            if (sschool.Equals(SchoolValue))
                            {
                                schoolmatches = true;

                            }

                        }

                    }
                }

            if (LocationValue.Equals(""))
            {
                locationmatches = true;

            }
            else
            {
                if (Useritem.Location != null)
                {
                    locationmatches = Useritem.Location.Equals(LocationValue);
                }
            }
            if (hometownmatches && employermatches && unimatches && locationmatches && schoolmatches && mutualfriendmatches)
            {
                filteredlist.Add(Useritem);

            }
        }
        GridViewFriendsList.DataSource = null;
        GridViewFriendsList.DataBind();
        if (!mutualFriendsFetched)
        {
            //get the top 2 mutual friends for filter options//only for the first time
            foreach (UserFriendsBO uitem in filteredlist)
            {
                if (uitem.MutualFriendsCount > 0)
                {
                    if (!mutualFriends.Contains(uitem.MutualFriendName))
                        mutualFriends.Add(uitem.MutualFriendName);

                }

            }
            mutualFriendsFetched = true;
        }
        GridViewFriendsList.DataSource = filteredlist;
        GridViewFriendsList.DataBind();
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        GetSuggestionsByCriteria();
      
      //  gridStuff(filteredlist);


       
    }
    protected void GridViewFriendsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFriendsList.PageIndex = e.NewPageIndex;
        GetSuggestionsByCriteria();
    }
}