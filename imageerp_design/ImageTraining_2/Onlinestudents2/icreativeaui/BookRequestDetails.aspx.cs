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

public partial class superadmin_BookRequestDetails : System.Web.UI.Page
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
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            viewby_admin.Visible = true;//row id
            //ddl_centrcode
            if (!IsPostBack)
            {
                fill_cencode();//fill centre code
            }
        }
        else
        {
            viewby_admin.Visible = false;
        }

    }
   
   private void fillgrid()
    {


        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            //_Qry = "select a.student_id,a.enq_personal_name,b.coursename from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where b.centre_code='" + ddl_centrcode.SelectedValue + "'";

            _Qry = "select a.student_id,a.enq_personal_name,c.coursename,case when isnull(a.bookstatus,'')='' ";
            _Qry += " then 'Pending'";
            _Qry += " else bookstatus end as bookstatus from adm_personalparticulars a ";
            _Qry += " inner join adm_generalinfo b on a.student_id=b.student_id inner join img_coursedetails c";
            _Qry += " on b.coursename=c.course_id where ";
            _Qry += "  a.Student_Id in (Select StudentId From CourseWare)";
            if (txtrolesearch.SelectedValue != "")
            {
                _Qry += " And BookReceived='" + txtrolesearch.SelectedValue + "' ";
            }
            else
            {
                _Qry += " And BookReceived<>'Yes' ";
            }


            if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
            {
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                _Qry = _Qry + " and dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            if (ddl_centrcode.SelectedValue != "" && ddl_centrcode.SelectedValue != null)
            {
                _Qry = _Qry + "and b.centre_code like '%" + ddl_centrcode.SelectedValue + "%'";
           
            }
            _Qry += " Order by DateMod desc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        else
        {
            //_Qry = "select a.student_id,a.enq_personal_name,b.coursename from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where b.centre_code='" + Session["SA_centre_code"] + "'";


            _Qry = "select a.student_id,a.enq_personal_name,c.coursename,case when isnull(a.bookstatus,'')='' ";
            _Qry += " then 'Pending'";
            _Qry += " else bookstatus end as bookstatus from adm_personalparticulars a ";
            _Qry += " inner join adm_generalinfo b on a.student_id=b.student_id inner join img_coursedetails c";
            _Qry += " on b.coursename=c.course_id where b.centre_code='" + Session["SA_centre_code"] + "'";
            _Qry += " And a.Student_Id in (Select StudentId From CourseWare)";

            if (txtrolesearch.SelectedValue != "")
            {
                _Qry += " And BookReceived='" + txtrolesearch.SelectedValue + "' ";
            }
            else
            {
                _Qry += " And BookReceived<>'Yes' ";
            }


            if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
            {
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + " and dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";

            }
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    //protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    fillgrid();
    //}
    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_centrcode.DataSource = dt;
        ddl_centrcode.DataValueField = "centre_code";
        ddl_centrcode.DataTextField = "centre_code";
        ddl_centrcode.DataBind();
        ddl_centrcode.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Course")
        {
            Response.Redirect("BookApproval.aspx?student_id=" + e.CommandArgument.ToString() + "");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookRequestDetails.aspx");
    }
}
