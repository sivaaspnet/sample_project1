using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class superadmin_Viewfacultydetails : System.Web.UI.Page
{
    string _Qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {
        _Qry = "select faculty_id,facultyname,ShiftTiiming,Specialisation from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "' and facultyname like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by Faculty_ID desc";
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource=dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            _Qry = "delete from onlinestudentsfacultydetails where Faculty_ID='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "Faculty details deleted sucesfully";
        }
    }
}
