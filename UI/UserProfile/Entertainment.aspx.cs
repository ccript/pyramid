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
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtBooks.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtBooks.Text + Global.PICTURE_EXTENSION_JPG)))
                objClass.Image = txtBooks.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtBooks.Text + ".png")))
                objClass.Image = txtBooks.Text + ".png";
            else

           
            objClass.Image = "DefaultBooks.png";
            objClass.Type = Global.BOOKS;
            EntertainmentBLL.insertEntertainment(objClass);
            txtBooks.Text = "";
            LoadDataListBooks();
        }

    }

    protected void SaveMusic()
    {

        if (!txtMusic.Text.Equals("") )
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtMusic.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMusic.Text + ".jpg")))
                objClass.Image = txtMusic.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMusic.Text + ".png")))
                objClass.Image = txtMusic.Text + ".png";
            else

            objClass.Image = "DefaultMusic.png";
            objClass.Type = Global.MUSIC;
            EntertainmentBLL.insertEntertainment(objClass);
            txtMusic.Text = "";
            LoadDataListMusic();
        }

    }

    protected void SaveMovie()
    {

        if (!txtMovie.Text.Equals("") )
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtMovie.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMovie.Text + ".jpg")))
                objClass.Image = txtMovie.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtMovie.Text + ".png")))
                objClass.Image = txtMovie.Text + ".png";
            else

            objClass.Image = "DefaultMovie.png";
            objClass.Type = Global.MOVIE;
            EntertainmentBLL.insertEntertainment(objClass);
            txtMovie.Text = "";
            LoadDataListMovie();
        }

    }
    protected void SaveTelevision()
    {

        if (!txtTelevision.Text.Equals("") )
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtTelevision.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTelevision.Text + ".jpg")))
                objClass.Image = txtTelevision.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtTelevision.Text + ".png")))
                objClass.Image = txtTelevision.Text + ".png";
            else

            objClass.Image = "DefaultTelevision.png";
            objClass.Type = Global.TELEVISION;
            EntertainmentBLL.insertEntertainment(objClass);
            txtTelevision.Text = "";
            LoadDataListTelevision();
        }

    }

    protected void SaveGame()
    {

        if (!txtGame.Text.Equals("") )
        {
            EntertainmentBO objClass = new EntertainmentBO();

            objClass.Name = txtGame.Text;
            objClass.UserId = Userid;
            if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtGame.Text + ".jpg")))
                objClass.Image = txtGame.Text + ".jpg";
            else if (System.IO.File.Exists(Server.MapPath("../../Resources/images/ProfileIcons/" + txtGame.Text + ".png")))
                objClass.Image = txtGame.Text + ".png";
            else

            objClass.Image = "DefaultGame.png";
            objClass.Type = Global.GAME;
            EntertainmentBLL.insertEntertainment(objClass);
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