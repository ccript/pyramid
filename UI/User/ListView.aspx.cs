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
using BuinessLayer;

public partial class User_ListView : System.Web.UI.Page
{
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "View List";

        Userid = SessionClass.getUserId();
       
        ListViewGrid.DataSource = ListViewBLL.getList(Userid, Global.CONFIRMED);
        ListViewGrid.DataBind();
   

    }
    protected void btnAddListName_Click(object sender, EventArgs e)
    {
        ListViewBO obj=new ListViewBO();
        obj.ListName=txtListName.Text;
        ListViewBLL.insertListName(obj);
        ListViewGrid.DataSource = ListViewBLL.getList(Userid, Global.CONFIRMED);
        ListViewGrid.DataBind();
    }
}