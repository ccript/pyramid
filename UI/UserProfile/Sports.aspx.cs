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
        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_USER_CHNAGED_SPORTS;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);
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
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtSports.Text;
            objEntertainment.UserId = Userid;

            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSports.Text + ".jpg")))
                objEntertainment.Image = txtSports.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtSports.Text + ".png")))
                objEntertainment.Image = txtSports.Text + ".png";
            else
                objEntertainment.Image = "DefaultSports.png";

            objEntertainment.Type = Global.SPORTS;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtSports.Text = "";
            LoadDataListSports();
        }

    }

    protected void SaveTeam()
    {

        if (!txtTeam.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtTeam.Text;
            objEntertainment.UserId = Userid;

            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTeam.Text + ".jpg")))
                objEntertainment.Image = txtTeam.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTeam.Text + ".png")))
                objEntertainment.Image = txtTeam.Text + ".png";
            else

            objEntertainment.Image = "DefaultTeam.png";
            objEntertainment.Type = Global.TEAM;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtTeam.Text = "";
            LoadDataListTeam();
        }

    }

    protected void SaveAthelete()
    {

        if (!txtAthelete.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtAthelete.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtAthelete.Text + ".jpg")))
                objEntertainment.Image = txtAthelete.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtAthelete.Text + ".png")))
                objEntertainment.Image = txtAthelete.Text + ".png";
            else


            objEntertainment.Image = "DefaultAthelete.png";
            objEntertainment.Type = Global.ATHELETE;
            EntertainmentBLL.insertEntertainment(objEntertainment);
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