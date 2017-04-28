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

public partial class superadmin_FacultyBatchDetails : System.Web.UI.Page
{
    string _Qry;
    string batchtrak;

    #region Page Load
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
    #endregion

    #region to go to the enter batch code page
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacultyAvail.aspx");
    }
    #endregion

    private void fillgrid()
    {
        _Qry = "select batch_code,batch_labname,batch_faculty,batch_time,batch_slot from batch_details";

        _Qry += " Where batch_Faculty='" + Request.QueryString["FacultyName"] + "'";
        _Qry += " Group by batch_slot,batch_time,batch_labname,batch_faculty,batch_code";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
