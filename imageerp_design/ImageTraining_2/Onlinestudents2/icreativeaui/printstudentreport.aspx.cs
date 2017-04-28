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


public partial class Onlinestudents2_superadmin_StudentReportDetails : System.Web.UI.Page
{
    string _Qry, moduleid="";
    int i = 0;
    int Course_ID = 0;
    string StudentID = "";
    int abc = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["StudentID"] == "" || Request.QueryString["StudentID"] == null)
            {
                Response.Redirect("StudentReport.aspx");
            }
            else
            {
                if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
                {
                    Response.Redirect("Login.aspx");
                }
                if (!IsPostBack)
                {
                    StudentID = Request.QueryString["StudentID"].ToString();
                    FillHeaderSection();
                    Content();
                }
            }
        }
        
    }

   

    #region headersection
    private void FillHeaderSection()
    {

        _Qry = @"
select (select sum(amount) from erp_receiptdetails where studentId=b.StudentId and receiptType='Invoice' and status='1')as paidamt, b.courseFees,a.student_id,a.enq_personal_name,student_lastname,invoiceId,c.program,b.track,convert(varchar ,d.dateins,103) as EnrolledDate ,e.tax,enq_personal_mobile,enq_personal_email,enq_personal_dob from  adm_personalparticulars a inner join erp_invoicedetails b on b.studentId=a.student_id inner join img_coursedetails c on c.course_id=b.courseId
inner join adm_Generalinfo d on d.admission_id=a.admission_id inner join img_centre_coursefee_details e on e.program=c.course_id
inner join img_enquiryform img on img.enq_number=a.enq_number
where b.StudentId='" + StudentID + "' " ;
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        double pendingamt;
        double paidamt;
        double tax;
        double tottax;
        if (dt.Rows.Count > 0)
        {
            lbl_no.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            lblInv.Text = dt.Rows[0]["invoiceId"].ToString();
            lbl_mail.Text = dt.Rows[0]["enq_personal_email"].ToString();
          //  lbl_add.Text = dt.Rows[0]["address"].ToString();
            lblEnrDate.Text = dt.Rows[0]["EnrolledDate"].ToString();
            lblSId.Text = dt.Rows[0]["student_id"].ToString();
            LblSName.Text = dt.Rows[0]["enq_personal_name"].ToString();
            lblCourse.Text = dt.Rows[0]["program"].ToString();
            lblTrack.Text = dt.Rows[0]["track"].ToString();
            lbl_coursefees.Text = dt.Rows[0]["courseFees"].ToString();
            paidamt = Convert.ToDouble(dt.Rows[0]["paidamt"]);
            pendingamt = Convert.ToDouble(dt.Rows[0]["courseFees"]) - (paidamt);
            lbl_pendingamt.Text = amts(pendingamt);
            tax = Convert.ToDouble(dt.Rows[0]["tax"]);
            tottax = (pendingamt) + ((pendingamt * tax) / 100);
            lbl_pendingwithtax.Text =  tottax.ToString();
           
        }
        else
        {
            lblInv.Text = "";
            lblEnrDate.Text = "";
            lblSId.Text = "";
            LblSName.Text = "";
            lblCourse.Text = "";
            lblTrack.Text = "";
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            lnk_inv.Visible = false;
            lbl_error.Text = "StudentFees Details Not Found";
        }
    }
    #endregion
    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = "Rs " + amountvalue.ToString("#,000");
        }
        return words;
    }

    #region Content

    private void Content()
    {
        _Qry = @"select courseid,invoiceid,module_content,module_id from erp_invoicedetails inv inner join Onlinestudent_Coursesoftware course 
on course.course_id=inv.courseid  where inv.studentid='"+Request.QueryString["studentid"]+"' order by module_id";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (moduleid == "")
                {
                    moduleid = dt1.Rows[i]["module_id"].ToString();
                }
                else
                {
                    moduleid = moduleid + "," + dt1.Rows[i]["module_id"].ToString();
                }
            }
        }
        else
        {
            moduleid = "0";
            lbl_error.Text = "Contact Admin,Course Data Improper";
            
        }
        _Qry = @"select sce.batchcode,moduleid,studentid,sce.status
from erp_batchdetails  bat inner join erp_batchschedule 
 sce on sce.batchcode=bat.batchcode where sce.studentid='" + Request.QueryString["studentid"] + "' and bat.moduleid in (" + moduleid + ") order by sce.batchcode";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = @"select  sce.batchcode,moduleid,studentid,count(sce.status) as pending,noofclass 
from erp_batchdetails  bat inner join erp_batchschedule 
 sce on sce.batchcode=bat.batchcode where sce.studentid='" + Request.QueryString["studentid"] + "' and bat.moduleid in (" + moduleid + ") and sce.status='pending' group by sce.batchcode,moduleid,noofclass,studentid";
        DataTable dt3 = new DataTable();
        dt3 = MVC.DataAccess.ExecuteDataTable(_Qry);



        DataTable status = new DataTable();
        status.Columns.Add(new DataColumn("module", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("content", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();
        foreach (DataRow drs in dt1.Rows)
        {
            dr = status.NewRow();
            dr["module"] = drs["module_content"];
            dr["content"] = getcontentstatus(dt3, " moduleid='" + drs["module_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'");
            dr["batchcode"] = getbatch(dt2, "moduleid='" + drs["module_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'", "batchcode");
            dr["status"] = getstatus(dt2, " moduleid='" + drs["module_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'");
            status.Rows.Add(dr);
        }
        GridView1.DataSource = status;
        GridView1.DataBind();
    }

    #endregion

    string getbatch(DataTable dtexp, string expression, string column)
    {
        string batch = "";
        string batch1 = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (batch1 != val[column].ToString())
                {
                     batch1 = val[column].ToString();
                    if(batch=="")
                    batch = "" + (val[column].ToString()) + "";
                    else
                    batch = batch + "<br>" + "" + (val[column].ToString()) + "";

                }
                //else if (batch == (val[column].ToString()))
                //{
                //    batch = "<a  href='studentbatch.aspx?batchcode=" + (val[column].ToString()) + "&studentid="+Request.QueryString["studentid"]+"' >" + (val[column].ToString()) + "</a>";
                //}
                //else
                //{
                //    batch = batch + "<br>" + "<a  href='studentbatch.aspx?batchcode=" + (val[column].ToString()) + "&studentid=" + Request.QueryString["studentid"] + "' >" + (val[column].ToString()) + "</a>";
                //}

            }
        }

        else
        {
            batch = "Batch Not Schedule";
        }
        return batch.ToString();
       

    }
    string getstatus(DataTable dtexp, string expression)
    {
        string res = "<span style='color:green; font-weight:bold;'>Completed</span>";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = res + "," + (val["status"].ToString());
            }
            string value = res;
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].ToString() == "Pending")
                {
                   res = "<span style='color:red; font-weight:bold;'>Inprogress</span>";
                   
                }
               
            }
        }
        else
        {
            res = "Batch Not Schedule";
        }
        
        return res.ToString();
    }

    string getcontentstatus(DataTable dtexp, string expression)
    {
        string res = "";
        int pending = 0;
        int noofclass = 0;
         
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                pending = (Convert.ToInt32(val["pending"]));
                noofclass = (Convert.ToInt32(val["noofclass"]));
                pending = noofclass - pending;
                res = "<span style='color:green; font-weight:bold;'>" + pending + "</span>" + "/" + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Batch Not Schedule";
        }
        
        return res.ToString();
    }
    protected void lnk_inv_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoiceDetails.aspx?invno= "+ lblInv.Text+ "");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Content();

    }
}
