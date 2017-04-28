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


public partial class Onlinestudents2_superadmin_Invoiceprint : System.Web.UI.Page
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
            if (Session["SA_centre_code"].ToString() == "IBG-104")
            {
                invoicefill();
                common.Visible = false;
                ganga.Visible = true;
                gangaaddress.Visible = true;
                lbl_ganga.Visible = true;
                lbl_img.Visible = false;
                commonaddress.Visible = false;
            }
            else
            {
                invoicefill();
                common.Visible = true;
                ganga.Visible = false;
                lbl_ganga.Visible = false;
                lbl_img.Visible = true;
                gangaaddress.Visible = false;
                commonaddress.Visible = true;
            }
            
        }
    }

    private string amts(double amountvalue)
    {
        string words="";
        if (amountvalue > 0)
        {        
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
        }
        return words;
    }

 
    private void invoicefill()
    {
        //_Qry = "select install.initialAmount,install.initialAmountTax,install.totalInitialAmount,convert(varchar,install.installdate,103) as installdate,receipt.receiptNo,inv.studentId,per.centre_code,per.enq_personal_name,isnull(CAST(receipt.totalamount AS varchar(12)),0) as totalamtpaid,inv.batchTime,inv.taxPercentage,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.courseFees,(round((cast(inv.courseFees as int)*cast(inv.taxPercentage as float)/100),0)) as courseTax,inv.courseId,cen.centre_location,inv.track,inv.invoiceId,dbo.getCourses(inv.studentId) as program,enq_personal_mobile,enq_personal_email,enq_present_address,convert(varchar,receipt.dateins,103) as date,convert(varchar,inv.dateins,103) as invoicedate,install.installNumber  from adm_personalparticulars per inner join erp_invoicedetails inv on per.student_id=inv.studentId and inv.centercode='" + Session["SA_centre_code"].ToString() + "' and  inv.status='active' inner join img_coursedetails course on course.course_id=inv.courseId  inner join img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=per.centre_code inner join img_centredetails cen on inv.centerCode=cen.centre_code inner join erp_installAmountDetails install on install.studentId=inv.studentId and  inv.invoiceId='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'  left join erp_receiptDetails receipt on   receipt.studentId=inv.studentId and receipt.installNo=install.installNumber";
        _Qry = "select install.initialAmount,install.initialAmountTax,install.totalInitialAmount,convert(varchar,install.installdate,103) as installdate,receipt.receiptNo,inv.studentId,per.centre_code,per.enq_personal_name,isnull(CAST(receipt.totalamount AS varchar(12)),0) as totalamtpaid,isnull(CAST(receipt.amount AS varchar(12)),0) as amtpaid,inv.batchTime,inv.taxPercentage,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.courseFees,(round((cast(inv.courseFees as int)*cast(inv.taxPercentage as float)/100),0)) as courseTax,inv.courseId,cen.centre_location,inv.track,inv.invoiceId,dbo.getCourses(inv.studentId,inv.invoiceId) as program,enq_personal_mobile,enq_personal_email,enq_present_address,convert(varchar,receipt.dateins,103) as date,convert(varchar,inv.dateins,103) as invoicedate,install.installNumber,cen.center_address,cen.franchisename,cen.centre_region  from adm_personalparticulars per inner join erp_invoicedetails inv on per.student_id=inv.studentId and inv.centercode='" + Session["SA_centre_code"].ToString() + "' and inv.invoiceId='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' inner join img_coursedetails course on course.course_id=inv.courseId  inner join img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=per.centre_code inner join img_centredetails cen on inv.centerCode=cen.centre_code inner join erp_installAmountDetails install on install.studentId=inv.studentId and  install.invoiceno='" + Regex.Replace(Request.QueryString["invno"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'  left join erp_receiptDetails receipt on  receipt.studentId=inv.studentId and receipt.status=1 and install.invoiceno=receipt.invoiceno and receipt.installNo=install.installNumber order by cast(install.installNumber as int)";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lbladdress.Text = dt.Rows[0]["enq_present_address"].ToString();
            lbl_centrename.Text = dt.Rows[0]["centre_location"].ToString();
            lblbatchtime.Text = dt.Rows[0]["batchTime"].ToString();
            lblcentre.Text = dt.Rows[0]["centre_code"].ToString();
            //lblcourse_id.Text = dt.Rows[0]["program"].ToString();
            if (dt.Rows[0]["program"].ToString().IndexOf('[') >= 0)
            {
                string coursecode = dt.Rows[0]["program"].ToString().Substring(0, dt.Rows[0]["program"].ToString().IndexOf('['));
                lblcourse_id.Text = coursecode;
            }
            else
            {
                lblcourse_id.Text = dt.Rows[0]["program"].ToString();
            } 
            
            lblcoursefee.Text = dt.Rows[0]["courseFees"].ToString();
            lblDate.Text = dt.Rows[0]["invoicedate"].ToString();
            lblinvoiceno.Text = dt.Rows[0]["invoiceId"].ToString();
            lblnoofinstal.Text = dt.Rows[0]["enq_present_address"].ToString();
            lblphone.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            lblstudid.Text = dt.Rows[0]["studentId"].ToString();
            lblstudname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            lbltax.Text = dt.Rows[0]["courseTax"].ToString();
            lbltrack.Text = dt.Rows[0]["track"].ToString();
            lbl_taxpercentage.Text = "("+dt.Rows[0]["taxPercentage"].ToString()+"%)";

            if (dt.Rows[0]["centre_region"].ToString().ToUpper().Trim() == "KERALA" || dt.Rows[0]["centre_region"].ToString().ToUpper().Trim() == "TAMILNADU")
            {
                if (dt.Rows[0]["courseId"].ToString() == "74" || dt.Rows[0]["courseId"].ToString() == "75" || dt.Rows[0]["courseId"].ToString() == "76")
                {
                    lbl_address.InnerHtml = "<span style='font-size: 9pt;font-family: Arial'>" + dt.Rows[0]["center_address"].ToString() + "</span>";
                }
                else if (dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-106" || dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-103" || dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-101" || dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-102" || dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICA-101" || dt.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "IBG-101")
                {
                    lbl_address.InnerHtml = "<span style='font-size: 9pt;font-family: Arial'> " + dt.Rows[0]["center_address"].ToString() + "</span>";
                }
                else
                {
                    lbl_address.InnerHtml = "<span style='font-size: 9pt;font-family: Arial'> " + dt.Rows[0]["franchisename"].ToString() + " <br/>" + dt.Rows[0]["center_address"].ToString() + "</span>";
                    //lbl_address.Text =  "Franchise :" + dt.Rows[0]["center_address"].ToString();
                }
            }
            else
            {
                lbl_address.InnerHtml = "<span style='font-size: 9pt;font-family: Arial'>" + dt.Rows[0]["center_address"].ToString() + "</span>";
            }
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

        foreach (DataRow dr in dt.Rows)
        {
            if (dr["totalamtpaid"].ToString() == "0")
            {
                dr["totalamtpaid"] = "";
                dr["date"] = "";
            }
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


}
