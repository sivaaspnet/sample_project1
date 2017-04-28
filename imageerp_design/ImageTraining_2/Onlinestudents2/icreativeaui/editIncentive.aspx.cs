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

public partial class superadmin_editIncentive : System.Web.UI.Page
{
    string _Qry, _Qry1,_Qry2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            if(Request.QueryString["stdid"]!=null && Request.QueryString["icid"]!=null)
            {
            string stid=Request.QueryString["stdid"].ToString();
            int id=Convert.ToInt32(Request.QueryString["icid"].ToString());
            GetStudentDetail(id, stid);
            }
        }
        
    }

     
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    private void GetStudentDetail(int icid,string StudentID)
    {
        string sQry = "select top 1 invoiceId from erp_invoicedetails where studentid='" + StudentID + "' order by id desc";
        DataTable dtInvoice = new DataTable();
        dtInvoice = MVC.DataAccess.ExecuteDataTable(sQry);

        if (dtInvoice.Rows.Count > 0)
        {
           
            _Qry = @"select install.initialAmount,install.initialAmountTax,install.totalInitialAmount,
                        convert(varchar,install.installdate,103) as installdate,receipt.receiptNo,inv.studentId,per.centre_code,
                        per.enq_personal_name,isnull(CAST(receipt.totalamount AS varchar(12)),0) as totalamtpaid,isnull
                            (CAST(receipt.amount AS varchar(12)),0) as amtpaid,inv.batchTime,inv.taxPercentage,(
                                round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)
                *cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.courseFees,(round((cast(inv.courseFees as int)
                *cast(inv.taxPercentage as float)/100),0)) as courseTax,inv.courseId,cen.centre_location,cen.center_address,inv.track,inv.invoiceId,
                dbo.getCourses(inv.studentId,inv.invoiceId) as program,enq_personal_mobile,enq_personal_email,enq_present_address,
                convert(varchar,receipt.dateins,103) as date,convert(varchar,inv.dateins,103) as invoicedate,install.installNumber,inv.remarks,referedstudentname
                from adm_personalparticulars per inner join erp_invoicedetails inv on per.student_id=inv.studentId and 
                inv.centercode='" + Session["SA_centre_code"].ToString() + "' and inv.invoiceId='" + dtInvoice.Rows[0]["invoiceId"].ToString() + "'  inner join img_coursedetails course on course.course_id=inv.courseId  inner join img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=per.centre_code inner join img_centredetails cen on inv.centerCode=cen.centre_code inner join erp_installAmountDetails install on install.studentId=inv.studentId and  install.invoiceno='" + dtInvoice.Rows[0]["invoiceId"].ToString() + "'  left join erp_receiptDetails receipt on  receipt.studentId=inv.studentId and receipt.status=1 and install.invoiceno=receipt.invoiceno and receipt.installNo=install.installNumber order by cast(install.installNumber as int)";

            DataTable dtInfo = new DataTable();
            dtInfo = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtInfo.Rows.Count > 0)
            {
                txtstudentid.Text = dtInfo.Rows[0]["studentId"].ToString();
                txtstudentname.Text = dtInfo.Rows[0]["enq_personal_name"].ToString();
                txtinvoicenum.Text = dtInvoice.Rows[0]["invoiceId"].ToString();
                txtreceiptnum.Text = dtInfo.Rows[0]["receiptNo"].ToString();

                txtreferstudentname.Text = dtInfo.Rows[0]["referedstudentname"].ToString();
                double totalamt = 0;

                for (int i = 0; i < dtInfo.Rows.Count; i++)
                {
                    if (totalamt == 0)
                    {
                        totalamt = Convert.ToDouble(dtInfo.Rows[i]["totalamtpaid"].ToString());
                    }
                    else
                    {
                        totalamt = totalamt + Convert.ToDouble(dtInfo.Rows[i]["totalamtpaid"].ToString());
                    }

                }
                txtamountpaid.Text = totalamt.ToString();
            }
        }
        else
        {
            lblalert.Text = "Student Record Not Found";
        }
        _Qry1 = "select referencetype,studentid,studentname,centrecode,invoicenum,receiptnum,amountpaid,referedstudentname,referstudentid,referedstaffname,studentincentiveamt,staffincentiveamt,approvedby,paymentby,studentchequeno,studentchequedate,studentbankname,staffchequeno,staffchequedate,staffbankname,dateins from erp_incentivedetails where icid="+icid+"";
        DataTable dtIncentive = new DataTable();
        dtIncentive = MVC.DataAccess.ExecuteDataTable(_Qry1);

        if (dtIncentive.Rows.Count > 0)
        {
            ddlIncentiveType.SelectedValue = dtIncentive.Rows[0]["referencetype"].ToString();

            if(ddlIncentiveType.SelectedValue=="Student")
            {
                tblstudent.Style.Add("display", "block");
                tblstaff.Style.Add("display", "none");
            }
            else if(ddlIncentiveType.SelectedValue=="Staff")
            {
                tblstudent.Style.Add("display", "none");
                tblstaff.Style.Add("display", "block");
            }
             else if(ddlIncentiveType.SelectedValue=="Both")
            {
                tblstudent.Style.Add("display", "block");
                tblstaff.Style.Add("display", "block");
            }
            txtstudentid.Text = dtIncentive.Rows[0]["studentid"].ToString();
            txtinvoicenum.Text = dtIncentive.Rows[0]["invoicenum"].ToString();
            txtreceiptnum.Text = dtIncentive.Rows[0]["receiptnum"].ToString();
            txtamountpaid.Text = dtIncentive.Rows[0]["amountpaid"].ToString();
            txtreferstudentname.Text = dtIncentive.Rows[0]["referedstudentname"].ToString();
            txtreferstudentid.Text = dtIncentive.Rows[0]["referstudentid"].ToString();
            txtreferstaffname.Text = dtIncentive.Rows[0]["referedstaffname"].ToString();
            txtstudentincentamt.Text = dtIncentive.Rows[0]["studentincentiveamt"].ToString();
            txtstaffincentamt.Text = dtIncentive.Rows[0]["staffincentiveamt"].ToString();
            txtapproveby.Text = dtIncentive.Rows[0]["approvedby"].ToString();
            txtpaymentissueby.Text = dtIncentive.Rows[0]["paymentby"].ToString();
            txtstudentchequeno.Text = dtIncentive.Rows[0]["studentchequeno"].ToString();
            txtstudentchequedate.Text = dtIncentive.Rows[0]["studentchequedate"].ToString();
            txtstudentbankname.Text = dtIncentive.Rows[0]["studentbankname"].ToString();
            txtstaffchequeno.Text = dtIncentive.Rows[0]["staffchequeno"].ToString();
            txtstaffchequedate.Text = dtIncentive.Rows[0]["staffchequedate"].ToString();
            txtstaffbankname.Text = dtIncentive.Rows[0]["staffbankname"].ToString();
        }
    }
   
    private string amts(double amountvalue)
    {
        string words = "";
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtstudentincentamt.Text = "";
        txtstaffincentamt.Text = "";
        txtstudentchequeno.Text = "";
        txtstudentchequedate.Text = "";
        txtstudentbankname.Text = "";
        txtstaffchequeno.Text = "";
        txtstaffchequedate.Text = "";
        txtstaffbankname.Text = "";
        txtapproveby.Text = "";
        txtpaymentissueby.Text = "";
        txtreferstaffname.Text = "";
    }
    protected void btnUpdateIncentive_Click(object sender, EventArgs e)
    {
        int existcount = 0, uptid = 0;

        _Qry2 = @"UPDATE erp_incentivedetails set referencetype='" + ddlIncentiveType.SelectedValue.ToString() + "',studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentid.Text) + "',studentname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentname.Text) + "',invoicenum='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinvoicenum.Text) + "',receiptnum='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreceiptnum.Text) + "',amountpaid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtamountpaid.Text) + "',referedstudentname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentname.Text) + "',referstudentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentid.Text) + "',referedstaffname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstaffname.Text) + "',studentincentiveamt='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentincentamt.Text) + "',staffincentiveamt='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffincentamt.Text) + "',approvedby='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtapproveby.Text) + "',paymentby='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpaymentissueby.Text) + "',studentchequeno='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentchequeno.Text) + "',studentchequedate='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentchequedate.Text) + "',studentbankname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentbankname.Text) + "',staffchequeno='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffchequeno.Text) + "',staffchequedate='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffchequedate.Text) + "',staffbankname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffbankname.Text) + "',dateins=getdate() where centrecode='" + Session["SA_centre_code"].ToString() + "' and icid=" + Request.QueryString["icid"].ToString() + "";
               
        uptid = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);

        if (uptid > 0)
        {
            Response.Redirect("viewincentivedetails.aspx?msg=UP");
        }
    }
}
