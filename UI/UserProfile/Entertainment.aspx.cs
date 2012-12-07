using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuinessLayer;
using ObjectLayer;
public partial class Entertainment : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    public string ListBooks;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgSave.Visible = false;
        lblSave.Visible = false;

        Userid = SessionClass.getUserId();

        ((Label)Master.FindControl("lblTitle")).Text = "Arts & Entertainment";

        LoadDataListBooks();
        LoadDataListMusic();
        LoadDataListMovie();
        LoadDataListTelevision();
        LoadDataListGame();

     
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveBooks();
        SaveMusic();
        SaveMovie();
        SaveTelevision();
        SaveGame();
        imgSave.Visible = true;
        lblSave.Visible = true;        

        PostProperties postProp = new PostProperties();
        postProp.PostText = Global.POST_CHANGED_RELATIONSHIP_STATUS;
        postProp.WallOwnerUserId = Userid;
        postProp.PostedByUserId = Userid;
        postProp.PostType = Global.PROFILE_CHANGE;
        postProp.EmbedPost = null;
        PostOnWall.post(postProp);
    }

    protected void LoadDataListBooks()
    {

        DListBooks.DataSource = EntertainmentBLL.getEntertainmentTop(Global.BOOKS,Userid);
        DListBooks.DataBind();
       
    }
    protected void LoadDataListMusic()
    {

        DListMusic.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MUSIC, Userid);
        DListMusic.DataBind();

    }
    protected void LoadDataListMovie()
    {

        DListMovie.DataSource = EntertainmentBLL.getEntertainmentTop(Global.MOVIE, Userid);
        DListMovie.DataBind();

    }
    protected void LoadDataListTelevision()
    {

        DListTelevision.DataSource = EntertainmentBLL.getEntertainmentTop(Global.TELEVISION, Userid);
        DListTelevision.DataBind();

    }
    protected void LoadDataListGame()
    {

        DListGame.DataSource = EntertainmentBLL.getEntertainmentTop(Global.GAME, Userid);
        DListGame.DataBind();

    }
    protected void SaveBooks()
    {

        if (!txtBooks.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtBooks.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtBooks.Text + Global.PICTURE_EXTENSION_JPG)))
                objEntertainment.Image = txtBooks.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtBooks.Text + ".png")))
                objEntertainment.Image = txtBooks.Text + ".png";
            else


            objEntertainment.Image = "DefaultBooks.png";
            objEntertainment.Type = Global.BOOKS;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtBooks.Text = "";
            LoadDataListBooks();
        }

    }

    protected void SaveMusic()
    {

        if (!txtMusic.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtMusic.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMusic.Text + ".jpg")))
                objEntertainment.Image = txtMusic.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMusic.Text + ".png")))
                objEntertainment.Image = txtMusic.Text + ".png";
            else

            objEntertainment.Image = "DefaultMusic.png";
            objEntertainment.Type = Global.MUSIC;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtMusic.Text = "";
            LoadDataListMusic();
        }

    }

    protected void SaveMovie()
    {

        if (!txtMovie.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtMovie.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMovie.Text + ".jpg")))
                objEntertainment.Image = txtMovie.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMovie.Text + ".png")))
                objEntertainment.Image = txtMovie.Text + ".png";
            else

            objEntertainment.Image = "DefaultMovie.png";
            objEntertainment.Type = Global.MOVIE;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtMovie.Text = "";
            LoadDataListMovie();
        }

    }
    protected void SaveTelevision()
    {

        if (!txtTelevision.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtTelevision.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTelevision.Text + ".jpg")))
                objEntertainment.Image = txtTelevision.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTelevision.Text + ".png")))
                objEntertainment.Image = txtTelevision.Text + ".png";
            else

            objEntertainment.Image = "DefaultTelevision.png";
            objEntertainment.Type = Global.TELEVISION;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtTelevision.Text = "";
            LoadDataListTelevision();
        }

    }

    protected void SaveGame()
    {

        if (!txtGame.Text.Equals("") )
        {
            EntertainmentBO objEntertainment = new EntertainmentBO();

            objEntertainment.Name = txtGame.Text;
            objEntertainment.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtGame.Text + ".jpg")))
                objEntertainment.Image = txtGame.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtGame.Text + ".png")))
                objEntertainment.Image = txtGame.Text + ".png";
            else

            objEntertainment.Image = "DefaultGame.png";
            objEntertainment.Type = Global.GAME;
            EntertainmentBLL.insertEntertainment(objEntertainment);
            txtGame.Text = "";
            LoadDataListGame();
        }

    }
    protected void DListBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListBooks.DataKeys[DListBooks.SelectedIndex].ToString());
        LoadDataListBooks();
       
    }
    protected void DListMusic_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListMusic.DataKeys[DListMusic.SelectedIndex].ToString());
        LoadDataListMusic();

    }
    protected void DListMovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListMovie.DataKeys[DListMovie.SelectedIndex].ToString());
        LoadDataListMovie();

    }
    protected void DListTelevision_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListTelevision.DataKeys[DListTelevision.SelectedIndex].ToString());
        LoadDataListTelevision();

    }
    protected void DListGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntertainmentBLL.deleteEntertainment(DListGame.DataKeys[DListGame.SelectedIndex].ToString());
        LoadDataListGame();

    }
}