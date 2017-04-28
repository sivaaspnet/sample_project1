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

public partial class superadmin_Viewbatch : System.Web.UI.Page
{

    string _Qry;

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


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    private void fillgrid()
    {
        _Qry = @"select sce.batchtiming,slot,sce.batchcode,labname,facultyname,[content],sce.status,convert(varchar(10),dateadd(d,0,sce.classdate),103)as classdate from erp_batchschedule sce inner join onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid
inner join online_students_labavail lab on lab.labid=sce.labid inner join Submodule_details_new sub on sub.submodule_id=sce.subcontentid
inner join erp_batchdetails bat on bat.batchcode=sce.batchcode
where studentid='" + Request.QueryString["studentid"] + "' and sce.batchcode='" + Request.QueryString["batchcode"] + "' and sce.software_id='" + Request.QueryString["softwareid"].ToString() + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            lbl_fac.Text = dt1.Rows[0]["facultyname"].ToString();
            lbl_lab.Text = dt1.Rows[0]["labname"].ToString();
            lbl_batch.Text = dt1.Rows[0]["batchtiming"].ToString();
            lbl_slot.Text = dt1.Rows[0]["slot"].ToString();
        }
        GridView1.DataSource = dt1;
        GridView1.DataBind();
        fillprogress();

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentReportDetails.aspx?StudentID="+Request.QueryString["studentid"]+"");
    }
    private void fillprogress()
    {
        _Qry = "select * from erp_facultyfeedback where studentid='" + Request.QueryString["studentid"].ToString() + "'  and batchcode='" + Request.QueryString["batchcode"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lbl_listening.Text = dt.Rows[0]["rate_listening"].ToString();
            lbl_tardiness.Text = dt.Rows[0]["rate_Tardiness"].ToString();
            lbl_using.Text = dt.Rows[0]["rate_UsingTimeWisely"].ToString();
            lbl_work.Text = dt.Rows[0]["rate_CompletingWork"].ToString();
            lbl_conduct.Text = dt.Rows[0]["rate_Conduct"].ToString();
        }

        if (lbl_listening.Text == "poor")
        {
            Label9.BackColor = System.Drawing.Color.Red;
            Label9.Text = "&nbsp;";
        }
        else if (lbl_listening.Text == "fair")
        {
            Label9.BackColor = System.Drawing.Color.Orange;
            Label9.Text = "&nbsp;";

        }
        else if (lbl_listening.Text == "good")
        {
            Label9.BackColor = System.Drawing.Color.Yellow;
            Label9.Text = "&nbsp;";

        }
        else if (lbl_listening.Text == "very good")
        {
            Label9.BackColor = System.Drawing.Color.SkyBlue;
            Label9.Text = "&nbsp;";

        }
        else if (lbl_listening.Text == "excellent")
        {
            Label9.BackColor = System.Drawing.Color.Green;
            Label9.Text = "&nbsp;";

        }


        if (lbl_tardiness.Text == "poor")
        {
            Label10.BackColor = System.Drawing.Color.Red;
            Label10.Text = "&nbsp;";
        }
        else if (lbl_tardiness.Text == "fair")
        {
            Label10.BackColor = System.Drawing.Color.Orange;
            Label10.Text = "&nbsp;";

        }
        else if (lbl_tardiness.Text == "good")
        {
            Label10.BackColor = System.Drawing.Color.Yellow;
            Label10.Text = "&nbsp;";

        }
        else if (lbl_tardiness.Text == "very good")
        {
            Label10.BackColor = System.Drawing.Color.SkyBlue;
            Label10.Text = "&nbsp;";

        }
        else if (lbl_tardiness.Text == "excellent")
        {
            Label10.BackColor = System.Drawing.Color.Green;
            Label10.Text = "&nbsp;";

        }



        if (lbl_using.Text == "poor")
        {
            Label11.BackColor = System.Drawing.Color.Red;
            Label11.Text = "&nbsp;";
        }
        else if (lbl_using.Text == "fair")
        {
            Label11.BackColor = System.Drawing.Color.Orange;
            Label11.Text = "&nbsp;";

        }
        else if (lbl_using.Text == "good")
        {
            Label11.BackColor = System.Drawing.Color.Yellow;
            Label11.Text = "&nbsp;";

        }
        else if (lbl_using.Text == "very good")
        {
            Label11.BackColor = System.Drawing.Color.SkyBlue;
            Label11.Text = "&nbsp;";

        }
        else if (lbl_using.Text == "excellent")
        {
            Label11.BackColor = System.Drawing.Color.Green;
            Label11.Text = "&nbsp;";

        }


        if (lbl_work.Text == "poor")
        {
            Label12.BackColor = System.Drawing.Color.Red;
            Label12.Text = "&nbsp;";
        }
        else if (lbl_work.Text == "fair")
        {
            Label12.BackColor = System.Drawing.Color.Orange;
            Label12.Text = "&nbsp;";

        }
        else if (lbl_work.Text == "good")
        {
            Label12.BackColor = System.Drawing.Color.Yellow;
            Label12.Text = "&nbsp;";

        }
        else if (lbl_work.Text == "very good")
        {
            Label12.BackColor = System.Drawing.Color.SkyBlue;
            Label12.Text = "&nbsp;";

        }
        else if (lbl_work.Text == "excellent")
        {
            Label12.BackColor = System.Drawing.Color.Green;
            Label12.Text = "&nbsp;";

        }


        if (lbl_conduct.Text == "poor")
        {
            Label13.BackColor = System.Drawing.Color.Red;
            Label13.Text = "&nbsp;";
        }
        else if (lbl_conduct.Text == "fair")
        {
            Label13.BackColor = System.Drawing.Color.Orange;
            Label13.Text = "&nbsp;";

        }
        else if (lbl_conduct.Text == "good")
        {
            Label13.BackColor = System.Drawing.Color.Yellow;
            Label13.Text = "&nbsp;";

        }
        else if (lbl_conduct.Text == "very good")
        {
            Label13.BackColor = System.Drawing.Color.SkyBlue;
            Label13.Text = "&nbsp;";

        }
        else if (lbl_conduct.Text == "excellent")
        {
            Label13.BackColor = System.Drawing.Color.Green;
            Label13.Text = "&nbsp;";

        }
    }
}
