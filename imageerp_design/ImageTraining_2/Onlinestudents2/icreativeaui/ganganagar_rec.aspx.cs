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
public partial class superadmin_Receiptprint : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        lblstudid.Text = Request.QueryString["studid"];
        FillInvoice();
    }
   private void FillInvoice()
    {
       
    //   _Qry = "select date_format( rec.dateins, '%d-%m-%Y' ) AS dateins,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards,round(install.monthlyinstal)as monthlyinstal,gen.Bankname,gen.creditddno,install.initialamount,install.initialamout_tax,install.totinitialamt_tax from (Ipadreceipt_details rec INNER JOIN Ipadinstall_amountdetails install on rec.student_id=install.student_id) Inner JOIN adm_generalinfo gen on gen.student_id=rec.student_id where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Receipt_no='" + Request.QueryString["recptno"] + "' group by rec.Receipt_Id";

        _Qry = "select convert(varchar,rec.dateins,103) as dateins,rec.Bank_name,rec.dd_no,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards from Ipadreceipt_details rec where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Receipt_no='" + Request.QueryString["recptno"] + "' group by rec.Receipt_Id,rec.Bank_name,rec.dd_no,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards,rec.dateins";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            //date format
            lbl_date.Text = dt.Rows[0]["dateins"].ToString();
            lbl_recpno.Text = Request.QueryString["recptno"];
            lbl_invoice.Text = dt.Rows[0]["Invoice_no"].ToString();

            lbl_date.Text = dt.Rows[0]["dateins"].ToString();  
            lbl_studname.Text = dt.Rows[0]["student_name"].ToString();
            lbl_inwords.Text = dt.Rows[0]["payment_words"].ToString();


            if (dt.Rows[0]["payment_mode"].ToString() == "Cash")
            {
                lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();
                lbl_Bank.Visible = false;
                lbl_BankName.Visible = false;
            }
            //if (dt.Rows[0]["payment_mode"].ToString() == "Cheque")
            //{
            //    lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
            //    lbl_Bank.Visible = true;
            //    lbl_BankName.Visible = true;
            //    lbl_Bank.Text = "Bank ";
            //    lbl_BankName.Text = dt.Rows[0]["Bank_name"].ToString() + " ";
            //}

            //lbl_paydate.Text = dt.Rows[0]["dateins"].ToString();

            //lbl_bankname.Text = dt.Rows[0]["Bank_name"].ToString();

            _Qry = "Select Count(*) From IpadReceipt_Details Where student_id='" + Request.QueryString["studid"] + "' And Receipt_no<=" + Request.QueryString["recptno"] + " And Centre_Code='" + Session["SA_centre_code"] + "'";
            //Response.Write(_Qry);
            //Response.End();
            int reccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //Response.Write(reccount);
            //Response.End();
            if (reccount > 1)
            {
                lbl_paymenttowards.Text = "Installment";
            }
            else
            {
                lbl_paymenttowards.Text = "Enrollment";
            }

            if (dt.Rows[0]["payment_mode"].ToString() != "Cash")
            {
                if (reccount > 1)
                {
                    lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
                    lbl_Bank.Visible = true;
                    lbl_BankName.Visible = true;
                    lbl_Bank.Text = "Bank ";
                    lbl_BankName.Text = dt.Rows[0]["Bank_name"].ToString() + " ";
                }
                else
                {
                    _Qry = "Select Creditddno,Bankname From Ipad_GeneralInfo where student_id='" + Request.QueryString["studid"] + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dtcredit = new DataTable();
                    dtcredit = MVC.DataAccess.ExecuteDataTable(_Qry);
                    lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dtcredit.Rows[0]["Creditddno"].ToString() + ")";
                    lbl_Bank.Visible = true;
                    lbl_BankName.Visible = true;
                    lbl_Bank.Text = "Bank ";
                    lbl_BankName.Text = dtcredit.Rows[0]["Bankname"].ToString() + " ";
                }
            }
           
           lbl_monthinstallment.Text = dt.Rows[0]["month_instal"].ToString();

            //fee calc


           _Qry = "select monthlyinstal_tax,replace(convert(varchar,cast((round(totalmonthly_tax,0)) as money),1),'.00','') as totalmonthly_tax,replace(convert(varchar,cast((round(totalamtpaid,0)) as money),1),'.00','') as initialamount,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','')as initialamout_tax,replace(convert(varchar,cast((round(tatamtpaidwithtax,0)) as money),1),'.00','')as totinitialamt_tax from Ipadinstall_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
           //Response.Write(_Qry);
           //Response.End();
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                lbl_sum.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                lbl_tax.Text = dt1.Rows[0]["initialamout_tax"].ToString();
                lbl_total.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                lbl_fees.Text = dt1.Rows[0]["initialamount"].ToString();
            }
        }
        _Qry = "select CourseName from Ipad_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lbl_coursecode.Text = dt2.Rows[0]["CourseName"].ToString();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Invoiceedit.aspx?studid=" + lblstudid.Text + "");
    }
}
