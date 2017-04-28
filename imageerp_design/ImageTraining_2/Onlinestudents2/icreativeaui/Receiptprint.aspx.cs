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
public partial class superadmin_Receiptprint : System.Web.UI.Page
{
    string _Qry;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if(! IsPostBack)
        {
            lblstudid.Value = Request.QueryString["studid"];
            lbl_recpno.Value = Request.QueryString["recptno"];
           lbl_inv.Value = Request.QueryString["invoiceno"];
            //lblstudid.Text = Request.QueryString["studid"];
            FillInvoice();
        }
        
    }
   private void FillInvoice()
    {
     
        //_Qry = "select rec.Id,rec.centerCode,rec.receiptNo,rec.invoiceNo,rec.amount,rec.taxAmount,rec.totalAmount,rec.paymentMode,rec.bankName,rec.ddNo,rec.ddDate,rec.paymentTowards,rec.studentId,rec.monthInstall,rec.installNo,rec.paymentWords,convert(varchar,rec.dateIns,103) as date,per.enq_personal_name,course.program from erp_receiptDetails rec inner join adm_personalparticulars per on per.student_id=rec.studentId inner join erp_invoicedetails inv on inv.invoiceId=rec.invoiceNo inner join img_coursedetails course on  inv.courseId=course.course_id where rec.receiptNo='" + Request.QueryString["recptno"] + "'";
        _Qry = @"if exists (select rec.studentid,invoiceid from erp_invoicedetails 
 inv inner join erp_receiptdetails rec on rec.invoiceno=inv.invoiceid and 
rec.studentid=inv.studentid where rec.studentid='"+@Request.QueryString["studid"]+@"' and rec.receiptno='"+@Request.QueryString["recptno"]+ @"') Begin
 select rec.Id,rec.centerCode,rec.receiptNo,logo,rec.paymentWords,rec.invoiceNo,
CAST(rec.amount AS NUMERIC(10,0)) as amount1,CAST(rec.taxAmount AS NUMERIC(10,0)) as taxAmount1,CAST(rec.totalAmount AS NUMERIC(10,0))
as totalAmount1,rec.paymentMode,rec.remarks as changereason,rec.bankName,rec.ddNo,rec.ddDate,rec.paymentTowards,rec.studentId,rec.monthInstall,rec.installNo,
rec.paymentWords,convert(varchar,rec.dateIns,103) as date,per.enq_personal_name,dbo.getCourses(inv.studentId,inv.invoiceId) as
program,centre.centre_code,centre.center_address,centre.franchisename,centre.centre_region,centre.insititueName,address1,address2,centre.receiptTemplate,centre.For_institute,course.course_id  
from erp_receiptDetails rec inner join adm_personalparticulars per on per.student_id=rec.studentId 
inner join erp_invoicedetails inv on inv.studentId=rec.studentId and inv.invoiceid='" + @Request.QueryString["invoiceno"]+@"'  inner join img_coursedetails course on inv.courseId=course.course_id  and inv.centercode=rec.centercode 
inner join img_centre_coursefee_details as fee on fee.program=inv.courseid and fee.track=inv.track and inv.centercode=fee.centre_code    
inner join img_centredetails as centre on centre.centre_code=fee.runningReceiptCentreCode and rec.centerCode='" + Session["SA_centre_code"].ToString() + "' and rec.receiptno='" + @Request["recptno"].ToString() + @"' end else
begin  select CAST(rec.amount AS NUMERIC(10,0)) as amount1,CAST(rec.taxAmount AS NUMERIC(10,0)) as taxAmount1,CAST(rec.totalAmount AS NUMERIC(10,0))
as totalAmount1,*,convert(varchar,rec.dateins,103)as date,studentname as enq_personal_name,rec.remarks as changereason from erp_receiptdetails rec  inner join img_centredetails
on centre_code=rec.centercode inner join erp_quickreceipt q on q.receiptno=rec.receiptno and q.centrecode=rec.centercode inner join img_coursedetails  c
on q.coursecode=c.course_id  where centercode='" + @Session["SA_centre_code"].ToString() + @"' and rec.receiptno='" + @Request["recptno"].ToString() + @"'
 end  ";


   
       DataTable dts = new DataTable();
        dts = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dts.Rows.Count > 0)
        {
            string tabletemplate=dts.Rows[0]["receiptTemplate"].ToString();
            if (dts.Rows[0]["paymentMode"].ToString() == "Cheque" || dts.Rows[0]["paymentMode"].ToString() == "D.D" || dts.Rows[0]["paymentMode"].ToString() == "C.C" || dts.Rows[0]["paymentMode"].ToString() == "Online Transfer")
            {
                tabletemplate = tabletemplate.Replace("##DDnumber##", dts.Rows[0]["paymentMode"].ToString() + "(" + dts.Rows[0]["ddNo"].ToString() + ")");
                //lbl_Bank.Visible = true;
                //lbl_BankName.Visible = true;
                tabletemplate = tabletemplate.Replace("##Bank##", "Bank ");
                tabletemplate = tabletemplate.Replace("##BankName##", dts.Rows[0]["bankName"].ToString() + " ");
            }
            else
            {
                tabletemplate = tabletemplate.Replace("##DDnumber## ", dts.Rows[0]["paymentMode"].ToString());
            }

            if (dts.Rows[0]["paymentMode"].ToString() == "Cash")
            {
                tabletemplate = tabletemplate.Replace("##DDnumber## ", dts.Rows[0]["paymentMode"].ToString());
                tabletemplate = tabletemplate.Replace("##Bank##", "");
                tabletemplate = tabletemplate.Replace("##BankName##", "");
            }
           tabletemplate = tabletemplate.Replace("##Receiptdate##", dts.Rows[0]["date"].ToString());
            tabletemplate = tabletemplate.Replace("##Receiptnumber##", Request.QueryString["recptno"]);
            tabletemplate = tabletemplate.Replace("##Amountinwords##", dts.Rows[0]["paymentWords"].ToString());
            tabletemplate = tabletemplate.Replace("##Monthinstallment##", ("<b>" + dts.Rows[0]["monthInstall"].ToString() + "</b>"));
            tabletemplate = tabletemplate.Replace("##FeesAmount##", dts.Rows[0]["amount1"].ToString());
            tabletemplate = tabletemplate.Replace("##sum##", dts.Rows[0]["totalAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Totalamount##", dts.Rows[0]["totalAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Invoicenumber##", dts.Rows[0]["invoiceNo"].ToString());
            tabletemplate = tabletemplate.Replace("##Coursecode##", dts.Rows[0]["program"].ToString());
            tabletemplate = tabletemplate.Replace("##Studentname##", ("<b>"+dts.Rows[0]["enq_personal_name"].ToString()+"</b>"));
            tabletemplate = tabletemplate.Replace("##address 1##", dts.Rows[0]["address1"].ToString());
            tabletemplate = tabletemplate.Replace("##address 2##", dts.Rows[0]["address2"].ToString());
            //lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString();
            tabletemplate = tabletemplate.Replace("## institue name##", dts.Rows[0]["insititueName"].ToString());
            tabletemplate = tabletemplate.Replace("##Tax##", dts.Rows[0]["taxAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Paymenttowards##", ("<b>" + dts.Rows[0]["paymentTowards"].ToString() + "</b>"));
            tabletemplate = tabletemplate.Replace("##Image Infotainment Limited##", ("<b>"+dts.Rows[0]["For_institute"].ToString()+"</b>"));
            
            if (dts.Rows[0]["centre_region"].ToString().ToUpper().Trim() == "KERALA" || dts.Rows[0]["centre_region"].ToString().ToUpper().Trim() == "TAMILNADU")
            {
                if (dts.Rows[0]["course_id"].ToString() == "74" || dts.Rows[0]["course_id"].ToString() == "75" || dts.Rows[0]["course_id"].ToString() == "76")
                {
                    tabletemplate = tabletemplate.Replace("##CentreAddress##", ("<span style='font-size: 9pt;font-family: Arial'>" + dts.Rows[0]["center_address"].ToString() + "</span>"));
                }
                else if (dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-106" || dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-103" || dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-101" || dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICH-102" || dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "ICA-101" || dts.Rows[0]["centre_code"].ToString().ToUpper().Trim() == "IBG-101")
                {
                    tabletemplate = tabletemplate.Replace("##CentreAddress##", ("<span style='font-size: 9pt;font-family: Arial'>" + dts.Rows[0]["center_address"].ToString() + "</span>"));
                }
                else 
                {
                    tabletemplate = tabletemplate.Replace("##CentreAddress##", ("<span style='font-size: 9pt;font-family: Arial'>" + dts.Rows[0]["franchisename"].ToString() + " <br/>" + dts.Rows[0]["center_address"].ToString() + "</span>"));
                }
            }
            else
            {
                tabletemplate = tabletemplate.Replace("##CentreAddress##", ("<span style='font-size: 9pt;font-family: Arial'>" + dts.Rows[0]["center_address"].ToString() + "</span>"));
            }
            tabletemplate = tabletemplate.Replace("##lblstudid##", dts.Rows[0]["studentId"].ToString());
            tabletemplate = tabletemplate.Replace("##logo##","<img src='images/logo/image-infotainment-limited.png'/>");
tabletemplate = tabletemplate.Replace("##logo1##","<img src='images/logo/logo2.png'/>");
            Label1.Text = tabletemplate.ToString();
            lblreason.Text = dts.Rows[0]["changereason"].ToString();
            if (dts.Rows[0]["changereason"].ToString() != "")
            {
                trreason.Visible = true;
            }
            else
            {
                trreason.Visible = false;
            }
        }
    //}
    //catch (Exception ex)
    //{
    //    Response.Write("Pleae Contact Admin");
    //}

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request["adm"]==null)
        {
             Response.Redirect("Receiptdetails.aspx");
        }
        else if (Request["adm"].ToString() == "quick")
        {
            Response.Redirect("quickadmission.aspx");
        }
       
    }
}
