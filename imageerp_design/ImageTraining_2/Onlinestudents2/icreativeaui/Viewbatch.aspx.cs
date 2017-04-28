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
            remarks();
            _Qry = @"
select  distinct bat.batchcode,mod.module_content,bat.slot,dbo.weekdays1(bat.slotday) as slotday,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
(select  CONVERT(VARCHAR(10),min( scheduledate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
(select  CONVERT(VARCHAR(10),max( scheduledate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='" + Session["SA_centre_code"].ToString() + "' and bat.batchcode='" + Request.QueryString["batchcode"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id ";
            DataTable dtab= new DataTable();
            dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                tblbatch.Visible = true;
                txt_Module.Text = dt.Rows[0]["module_content"].ToString();
                txt_Faculty.Text = dt.Rows[0]["facultyname"].ToString();
                txt_Lab.Text = dt.Rows[0]["labname"].ToString();
                txt_BatchSlot.Text = dt.Rows[0]["slot"].ToString();
                txt_BatchSlot0.Text = dt.Rows[0]["slotday"].ToString();
                txt_BatchTime.Text = dt.Rows[0]["batchtiming"].ToString();
                txt_Bstart.Text = dt.Rows[0]["Startdate"].ToString();
                txt_Bend.Text = dt.Rows[0]["Enddate"].ToString();
                txt_Batchcode.Text = dt.Rows[0]["BatchCode"].ToString();
                lblsoft.Text = getsoft(dtab, "batchcode='" + Request.QueryString["batchcode"] + "'", "software_Name");
            }
            else
            {
                tblbatch.Visible = false;
            }
            ViewState["value"] = Request.ServerVariables["HTTP_REFERER"];
        }
    }
    #endregion

    #region to go to the enter batch code page
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewbatchDetails.aspx");
        //if (Request.QueryString["Info"] == "" || Request.QueryString["Info"] == null)
        //{
        //    if (Request.QueryString["LabName"] == "" || Request.QueryString["LabName"] == null)
        //    {
        //        Response.Redirect("ViewbatchDetails.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("LabDetails.aspx?LabName=" + Request.QueryString["LabName"].ToString() + "");
        //    }
        //}
        //else
        //{
        //    Response.Redirect("StudentReportdetails.aspx?StudentID=" + Request.QueryString["StudentID"] + "");
        //} 
    }
    #endregion


    #region for filling the student list
   private void fillgrid()
   {
       //student details in batch
       _Qry = @"select distinct bat.studentid,per.enq_personal_name,bat.batchcode from adm_personalparticulars per inner join erp_batchschedule bat 
on bat.studentid=per.student_id and bat.batchstatus='active' where batchcode='" + Request.QueryString["batchcode"] + "'";
       DataTable dt = new DataTable();
       dt = MVC.DataAccess.ExecuteDataTable(_Qry);
       _Qry = @"select distinct isnull(bat.remarks,'') as remarks,bat.studentid from adm_personalparticulars per inner join erp_batchschedule bat on bat.studentid=per.student_id and bat.batchstatus='active' where batchcode='" + Request.QueryString["batchcode"] + "' ";
       DataTable dt1 = new DataTable();
       dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
       DataTable dt3 = new DataTable();
       dt3.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
       dt3.Columns.Add(new DataColumn("enq_personal_name", System.Type.GetType("System.String")));
       dt3.Columns.Add(new DataColumn("remarks", System.Type.GetType("System.String")));
       dt3.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
       DataRow dr = dt3.NewRow();
       foreach (DataRow drs in dt.Rows)
       {
           dr = dt3.NewRow();
           dr["studentid"] = drs["studentid"];
           dr["batchcode"] = drs["batchcode"];
           dr["enq_personal_name"] = drs["enq_personal_name"];
           dr["remarks"] = getremarks(dt1, " studentid='" + drs["studentid"] + "'");
           dt3.Rows.Add(dr);
       }
       //Response.Write(_Qry);
       //Response.End();
       
       

        GridView1.DataSource = dt3;
        GridView1.DataBind();
    }
    #endregion

    string getremarks(DataTable dtexp, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
               
                if (res == "")
                {
                    res = (val["remarks"].ToString());
                    
                }
              
                else
                {
                    res = res + ",<br/>" + (val["remarks"].ToString());
                }

            }

        }


        return res.ToString();
    }

    private void remarks()
    {
        _Qry = @"select distinct case isnull(remarks,0) when '0' then 'No Remarks Found' else remarks end as remarks,convert(varchar,editdate,103) as editdate from erp_batchcontentstatus
 where batchcode='" + Request.QueryString["batchcode"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
            Label1.Visible = false;
        }
        else
        {
            GridView2.Visible = false;
            Label1.Visible = true;
        }

    }

    #region for paging Student grid
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    #endregion

    string getsoft(DataTable dtexp, string expression, string column)
    {
        string soft = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (soft == "")
                {
                    soft = (val[column].ToString());
                }
                else if (soft == (val[column].ToString()))
                {
                    soft = (val[column].ToString());

                }
                else
                {
                    soft = soft + "," + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

    }




}
