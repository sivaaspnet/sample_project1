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

public partial class superadmin_AddIncentive : System.Web.UI.Page
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
            MultiView1.ActiveViewIndex = 0;
        }
        
    }

    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_stuid.Text);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string sQry = "select top 1 invoiceId from erp_invoicedetails where studentid='" + txt_stuid.Text + "' order by id desc";
            DataTable dtInvoice = new DataTable();
            dtInvoice = MVC.DataAccess.ExecuteDataTable(sQry);

            if (dtInvoice.Rows.Count > 0)
            {
                MultiView1.ActiveViewIndex = 1;
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

                    string sReceiptNums = string.Empty;


                    txtreferstudentname.Text = dtInfo.Rows[0]["referedstudentname"].ToString();
                    double totalamt = 0;

                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        if (dtInfo.Rows[i]["receiptNo"].ToString() != "")
                        {
                            sReceiptNums = sReceiptNums + dtInfo.Rows[i]["receiptNo"].ToString();
                            sReceiptNums += (i < dtInfo.Rows.Count - 1) ? "," : string.Empty;
                        }
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
                    txtreceiptnum.Text = sReceiptNums;
                }
            }
            else
            {
                lbl_errormsg.Text = "Student Record Not Found";
            }
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
    protected void btnAddIncentive_Click(object sender, EventArgs e)
    {
        _Qry1 = "select count(*) as icid from erp_incentivedetails where studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentid.Text) + "' and referedstudentname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentname.Text) + "' And centrecode='" + Session["SA_centre_code"] + "'";
       
        int existcount = 0,insertid=0;

        existcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry1);

        if (existcount > 0)
        {
            lbl_errormsg.Text = "Student Incentive Details Already Exists";
        }
        else
        {
            _Qry2 = @"INSERT INTO erp_incentivedetails(referencetype,studentid,studentname,centrecode,invoicenum,receiptnum,amountpaid,referedstudentname,referstudentid,referedstaffname,studentincentiveamt,staffincentiveamt,approvedby,paymentby,studentchequeno,studentchequedate,studentbankname,staffchequeno,staffchequedate,staffbankname,dateins)
                    VALUES('" + ddlIncentiveType.SelectedValue.ToString() + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentid.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentname.Text) + "','" + Session["SA_centre_code"].ToString() + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinvoicenum.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreceiptnum.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtamountpaid.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentid.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstaffname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentincentamt.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffincentamt.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtapproveby.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpaymentissueby.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentchequeno.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentchequedate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstudentbankname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffchequeno.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffchequedate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstaffbankname.Text) + "',getdate())";
            insertid = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);

            if (insertid > 0)
            {
                Response.Redirect("viewincentivedetails.aspx?msg=IN");
            }
        }
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
}
