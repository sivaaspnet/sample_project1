using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ImageTraining_2_Onlinestudents2_img_auth_Moveoldstudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        fillgrid();
    }
    private void fillgrid()
    {
        string Qry = @"select * from [oldstudentdetails] where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='Disable'";
        if (txtsearchid.Text != "")
        {
            Qry = Qry + " and oldstudentid like '%" + txtsearchid.Text + "%'";
        }
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(Qry);
        GridView1.DataSource = dt4;
        GridView1.DataBind();
        lblerror.Text = "";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        if (e.CommandName == "lnkhide")
        {
            string Qry1 = @"update [oldstudentdetails] set status='pending' where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='disable' and id= " + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qry1);
            fillgrid();
        }
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}