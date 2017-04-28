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
using System.Data.SqlClient;

public partial class Onlinestudents2_superadmin_CourseWare : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        fillgrid();

        if (!IsPostBack)
        {
            if (Request.QueryString["Bookreq"] == "Succ")
            {
                lblmsg1.Text = "Books Requested Successfully";
            }
        }
    }

    void fillgrid()
    {

        _Qry = "select a.student_id,a.enq_personal_name,c.coursename,case when isnull(a.bookstatus,'')='' ";
        _Qry+=" then 'Pending'";
        _Qry+=" else bookstatus end as bookstatus from adm_personalparticulars a ";
        _Qry+=" inner join adm_generalinfo b on a.student_id=b.student_id inner join img_coursedetails c";
        _Qry += " on b.coursename=c.course_id where b.centre_code='" + Session["SA_centre_code"] + "' ";
        _Qry += " And a.enq_personal_name like '%" + txtnamesearch.Text + "%'";
        if (txtrolesearch.SelectedValue != "")
        {
            _Qry += " And BookReceived='" + txtrolesearch.SelectedValue + "' Order by DateMod desc";
        }
        else
        {
            _Qry += " And BookReceived<>'Yes' Order by DateMod desc";
        }

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        lblmsg1.Text = "";
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Course")
        {
            Response.Redirect("BookReq.aspx?student_id=" + e.CommandArgument.ToString() + "");
        }


    }
}
