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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class superadmin_InvoiceDetails : System.Web.UI.Page
{
    int cfee = 0;
    int tfee = 0;
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4;
    
    public string apppdate;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {           
            invoicefill();
        }
    }

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

    
    private void invoicefill()
    {
        



        _Qry = @"select install.initialAmount,install.initialAmountTax,install.totalInitialAmount,
        convert(varchar,install.installdate,103) as installdate,receipt.receiptNo,inv.studentId,per.centre_code,
        per.enq_personal_name,isnull(CAST(receipt.totalamount AS varchar(12)),0) as totalamtpaid,isnull
            (CAST(receipt.amount AS varchar(12)),0) as amtpaid,inv.batchTime,inv.taxPercentage,(
                round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)
*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.courseFees,(round((cast(inv.courseFees as int)
*cast(inv.taxPercentage as float)/100),0)) as courseTax,inv.courseId,cen.centre_location,cen.center_address,inv.track,inv.invoiceId,
dbo.getCourses(inv.studentId,inv.invoiceId) as program,enq_personal_mobile,enq_personal_email,enq_present_address,
convert(varchar,receipt.dateins,103) as date,convert(varchar,inv.dateins,103) as invoicedate,install.installNumber
from adm_personalparticulars per inner join erp_invoicedetails inv on per.student_id=inv.studentId and 
inv.centercode='" +Request.QueryString["centrecode"] + "' and inv.invoiceId='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' and inv.status='active' inner join img_coursedetails course on course.course_id=inv.courseId  inner join img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=per.centre_code inner join img_centredetails cen on inv.centerCode=cen.centre_code inner join erp_installAmountDetails install on install.studentId=inv.studentId and  install.invoiceno='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'  left join erp_receiptDetails receipt on  receipt.studentId=inv.studentId  and install.invoiceno=receipt.invoiceno and receipt.installNo=install.installNumber order by cast(install.installNumber as int)";
        //_Qry = "select install.initialAmount,install.initialAmountTax,install.totalInitialAmount,convert(varchar,install.installdate,103) as installdate,receipt.receiptNo,inv.studentId,per.centre_code,per.enq_personal_name,isnull(CAST(receipt.totalamount AS varchar(12)),0) as totalamtpaid,inv.batchTime,inv.taxPercentage,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.courseFees,(round((cast(inv.courseFees as int)*cast(inv.taxPercentage as float)/100),0)) as courseTax,inv.courseId,cen.centre_location,inv.track,inv.invoiceId, course.program,enq_personal_mobile,enq_personal_email,enq_present_address,convert(varchar,receipt.dateins,103) as date,convert(varchar,inv.dateins,103) as invoicedate,install.installNumber  from adm_personalparticulars per inner join erp_invoicedetails inv on per.student_id=inv.studentId inner join img_coursedetails course on course.course_id=inv.courseId  inner join img_enquiryform enq on enq.enq_number=per.enq_number inner join img_centredetails cen on inv.centerCode=cen.centre_code inner join erp_installAmountDetails install on install.studentId=inv.studentId and  inv.invoiceId='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'    left join erp_receiptDetails receipt on   receipt.studentId=inv.studentId and receipt.installNo=install.installNumber and install.centerCode=receipt.centerCode  where inv.centerCode='" + Session["SA_centre_code"] + "'";
        //Response.Write(_Qry);

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lbladdress.Text = dt.Rows[0]["enq_present_address"].ToString();
            lbl_centrename.Text = dt.Rows[0]["centre_location"].ToString();
            lblbatchtime.Text = dt.Rows[0]["batchTime"].ToString();
            lblcentre.Text = dt.Rows[0]["centre_code"].ToString();
            lblcourse_id.Text = dt.Rows[0]["program"].ToString();
            lblcoursecode.Text = dt.Rows[0]["program"].ToString();           
            lblcoursefee.Text = dt.Rows[0]["courseFees"].ToString();
            lblDate.Text = dt.Rows[0]["invoicedate"].ToString();
            lblinvoiceno.Text = dt.Rows[0]["invoiceId"].ToString();
            lblnoofinstal.Text = dt.Rows[0]["enq_present_address"].ToString();
            lblphone.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            lblstudid.Text = dt.Rows[0]["studentId"].ToString();
            lblstudname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            lbltax.Text = dt.Rows[0]["courseTax"].ToString();
            lbltrack.Text = dt.Rows[0]["track"].ToString();
            lbl_address.Text = dt.Rows[0]["center_address"].ToString();
           
            double totalfee = Convert.ToDouble(dt.Rows[0]["courseFees"]);
            double totalamt = 0;
            double totalpaid = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (totalamt == 0)
                {
                    totalamt = Convert.ToDouble(dt.Rows[i]["totalamtpaid"]);
                }
                else
                {
                    totalamt = totalamt + Convert.ToDouble(dt.Rows[i]["totalamtpaid"]);
                }
                if (totalpaid == 0)
                {
                    totalpaid = Convert.ToDouble(dt.Rows[i]["amtpaid"]);
                }
                else
                {
                    totalpaid = totalpaid + Convert.ToDouble(dt.Rows[i]["amtpaid"]);
                }
            }
            lblamtpaid.Text = amts(totalamt).ToString();
            if (totalfee <= totalpaid)
            {
                visbkimage.Style[HtmlTextWriterStyle.BackgroundImage] = ResolveClientUrl("images/fullly.jpg");
             }
             else
             {
                 visbkimage.Style[HtmlTextWriterStyle.BackgroundImage] = "";
             }
          
        }

        foreach(DataRow dr in dt.Rows)
        {
            if (dr["totalamtpaid"].ToString() == "0")
            {
                dr["totalamtpaid"] = "";
                dr["date"] = "";
            }
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //foreach(GridViewRow gvr in GridView1.Rows)
        //{
        //    Label lbl = new Label();
        //    lbl =(Label)gvr.FindControl("");
        //    if (lbl.Text == "0")
        //    {
        //        lbl.Text = "";
        //    }
        //}
        _Qry = @"select  a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,
b.enq_number,isnull(a.student_lastname,'.*.') as ExpressEnrollSt 
from adm_personalparticulars a inner join adm_generalinfo b on
 a.student_id=b.student_id where a.Admission_id>0  and isnull(a.student_lastname,'.*.')='.*.' and 
a.centre_code='" + Request.QueryString["centrecode"] + "' and  a.student_id='" + lblstudid.Text + "'";

        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt4.Rows.Count > 0)
        {
            print.Visible = false;
        }
       



    }  
   

    protected void btnhme_Click(object sender, EventArgs e)
    {
        Session["Stud_ID"] = "";
        Response.Redirect("Ipad-ViewAdmission.aspx");
    }


   
}
