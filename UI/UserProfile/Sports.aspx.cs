using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class Sports : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        imgSave.Visible = false;
        lblSave.Visible = false;
        Userid = SessionClass.getUserId(); 
        ((Label)Master.FindControl("lblTitle")).Text = "Sports";
    
        LoadDataListSports();
        LoadDataListTeam();
        LoadDataListAthelete();

  
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveSports();
        SaveTeam();
        SaveAthelete();
        imgSave.Visible = true;
        lblSave.Visible = true;
        WallPost("User Changed Sports");
    }

    protected void WallPost(string post)
    {
        UserBO objUser = new UserBO();
        objUser = UserBLL.getUserByUserId(Userid);

        WallBO objWall = new WallBO();
        objWall.PostedByUserId = Userid;
        objWall.WallOwnerUserId = Userid;
        objWall.FirstName = objUser.FirstName;
        objWall.LastName = objUser.LastName;
        objWall.Post = post;
        objWall.AddedDate = DateTime.Now;
        objWall.Type = Global.PROFILE_CHANGE;
        string wid=WallBLL.insertWall(objWall);

        ////////////////////////////////////TICKER CODE //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        List<UserFriendsBO> listtag = FriendsBLL.getAllFriendsListName(Session["UserId"].ToString(), Global.CONFIRMED);
        //get the education,hometown and employer of people in list
        foreach (UserFriendsBO Useritem in listtag)
        {
            TickerBO objTicker = new TickerBO();


            objTicker.PostedByUserId = objWall.PostedByUserId;
            objTicker.TickerOwnerUserId = Useritem.FriendUserId;
            objTicker.FirstName = objWall.FirstName;
            objTicker.LastName = objWall.LastName;
            objTicker.Post = objWall.Post;
            objTicker.Title = objWall.Post;
            objTicker.AddedDate = DateTime.UtcNow;
            objTicker.Type = objWall.Type;
            objTicker.EmbedPost = objWall.EmbedPost;
            objTicker.WallId = wid;
            TickerBLL.insertTicker(objTicker);

        }
        TickerBO objTickerUserTag = new TickerBO();


        objTickerUserTag.PostedByUserId = Session["UserId"].ToString();
        objTickerUserTag.TickerOwnerUserId = Session["UserId"].ToString();
        objTickerUserTag.FirstName = objUser.FirstName;
        objTickerUserTag.LastName = objUser.LastName;
        objTickerUserTag.Post = objWall.Post;
        objTickerUserTag.Title = objWall.Post;
        objTickerUserTag.AddedDate = DateTime.UtcNow;
        objTickerUserTag.Type = objWall.Type;
        objTickerUserTag.EmbedPost = objWall.EmbedPost;
        objTickerUserTag.WallId = wid;
        TickerBLL.insertTicker(objTickerUserTag);

        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
    }
    protected void LoadDataListSports()
    {

        DListSports.DataSource = EntertainmentBLL.getEntertainmentTop(Global.SPORTS, Userid);
        DListSports.DataBind();
       
    }
    protected void LoadDataListTeam()
    {

        DListTeam.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TEAM, Userid);
        DListTeam.DataBind();

    }
    protected void LoadDataListAthelete()
    {

        DListAthelete.DataSource = EntertainmentBLL.getEntertainmentTop(Global.ATHELETE, Userid);
        DListAthelete.DataBind();

    }
   
    protected void SaveSports()
    {

        if (!txtSports.Text.Equals(""))
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtSports.Text;
            objClass.UserId = Userid;

            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSports.Text + ".jpg")))
                objClass.Image = txtSports.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSports.Text + ".png")))
                objClass.Image = txtSports.Text + ".png";
            else
                objClass.Image = "DefaultSports.png";
          
            objClass.Type = Global.SPORTS;
            EntertainmentBLL.insertEntertainment(objClass);
            txtSports.Text = "";
            LoadDataListSports();
        }

    }

    protected void SaveTeam()
    {

        if (!txtTeam.Text.Equals("") )
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtTeam.Text;
            objClass.UserId = Userid;

            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTeam.Text + ".jpg")))
                objClass.Image = txtTeam.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTeam.Text + ".png")))
                objClass.Image = txtTeam.Text + ".png";
            else
           
            objClass.Image = "DefaultTeam.png";
            objClass.Type = Global.TEAM;
            EntertainmentBLL.insertEntertainment(objClass);
            txtTeam.Text = "";
            LoadDataListTeam();
        }

    }

    protected void SaveAthelete()
    {

        if (!txtAthelete.Text.Equals("") )
        {
          EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtAthelete.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtAthelete.Text + ".jpg")))
                objClass.Image = txtAthelete.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtAthelete.Text + ".png")))
                objClass.Image = txtAthelete.Text + ".png";
            else

               
            objClass.Image = "DefaultAthelete.png";
            objClass.Type = Global.ATHELETE;
            EntertainmentBLL.insertEntertainment(objClass);
            txtAthelete.Text = "";
            LoadDataListAthelete();
        }

    }
   
    protected void DListSports_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListSports.DataKeys[DListSports.SelectedIndex].ToString());
        LoadDataListSports();
       
    }
    protected void DListTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListTeam.DataKeys[DListTeam.SelectedIndex].ToString());
        LoadDataListTeam();

    }
    protected void DListAthelete_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListAthelete.DataKeys[DListAthelete.SelectedIndex].ToString());
        LoadDataListAthelete();

    }
   
}