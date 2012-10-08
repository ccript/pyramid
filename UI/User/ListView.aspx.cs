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
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label l = (Label)Page.Master.FindControl("lblTitle");
        l.Text = "View List";

        try
        {
            userid = Session["UserId"].ToString();
        }
        catch (Exception ex) { Response.Redirect("../../Default.aspx"); }
     
       
        ListViewGrid.DataSource = ListViewBLL.getList(userid, Global.CONFIRMED);
        ListViewGrid.DataBind();
   

    }
    protected void btnAddListName_Click(object sender, EventArgs e)
    {
        ListViewBO obj=new ListViewBO();
        obj.ListName=txtListName.Text;
        ListViewBLL.insertListName(obj);
        ListViewGrid.DataSource = ListViewBLL.getList(userid, Global.CONFIRMED);
        ListViewGrid.DataBind();
    }
}