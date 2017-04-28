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

public partial class Onlinestudents2_superadmin_Receiptprintpage : System.Web.UI.Page
{
    string _Qry;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
            DataTable dt87 = new DataTable();
            dt87 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt87.Rows.Count > 0)
            {
                string val = dt87.Rows[0]["center_code"].ToString();
                if (Session["SA_centre_code"].ToString() == val)
                {
                    //lbl_address.Text = dt87.Rows[0]["center_address"].ToString();
                    //lbl_address1.Text = dt87.Rows[0]["center_address"].ToString();
                    //lbl_address.Visible = true;
                    //lbl_address1.Visible = true;


                }
            }
        }

        FillInvoice();
    }
    private void FillInvoice()
    {
        if (Request.QueryString["page"] == "" || Request.QueryString["page"] == null)
        {
            _Qry = "select Invoice_No from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' And centre_code='" + Session["SA_centre_code"] + "'";

            SqlDataReader dr123;
            dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr123.HasRows)
            {
                dr123.Read();

                Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

                dr123.Close();
            }
            //   _Qry = "select date_format( rec.dateins, '%d-%m-%Y' ) AS dateins,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards,round(install.monthlyinstal)as monthlyinstal,gen.Bankname,gen.creditddno,install.initialamount,install.initialamout_tax,install.totinitialamt_tax from (Receipt_Details rec INNER JOIN install_amountdetails install on rec.student_id=install.student_id) Inner JOIN adm_generalinfo gen on gen.student_id=rec.student_id where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Receipt_no='" + Request.QueryString["recptno"] + "' group by rec.Receipt_Id";
            if (Invoice_no > 0)
            {
                _Qry = "select convert(varchar,rec.dateins, 3) as dateins,rec.Bank_name,rec.dd_no,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards from Receipt_Details rec where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Receipt_no='" + Request.QueryString["recptno"] + "' group by rec.Receipt_Id,rec.Bank_name,rec.dd_no,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards,rec.dateins";

                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dt.Rows.Count > 0)
                {
                    //date format
                    lbl_date.Text = dt.Rows[0]["dateins"].ToString();
                    lbl_date1.Text = dt.Rows[0]["dateins"].ToString();
                    //lbl_paydate.Text = dt.Rows[0]["dateins"].ToString();
                    //lbl_paydate1.Text = dt.Rows[0]["dateins"].ToString();

                    lbl_recpno.Text = Request.QueryString["recptno"];
                    lbl_recpno1.Text = Request.QueryString["recptno"];

                    lbl_invoice.Text = dt.Rows[0]["Invoice_no"].ToString();
                    lbl_invoice1.Text = dt.Rows[0]["Invoice_no"].ToString();

                    lbl_studname.Text = dt.Rows[0]["student_name"].ToString();
                    lbl_studname1.Text = dt.Rows[0]["student_name"].ToString();

                    lbl_inwords.Text = dt.Rows[0]["payment_words"].ToString();
                    lbl_inwords1.Text = dt.Rows[0]["payment_words"].ToString();

                    if (dt.Rows[0]["payment_mode"].ToString() == "Cash")
                    {
                        lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();
                        lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString();
                        lbl_Bank.Visible = false;
                        lbl_Bank1.Visible = false;
                        lbl_BankName.Visible = false;
                        lbl_BankName1.Visible = false;
                    }
                    _Qry = "Select Count(*) From Receipt_Details Where student_id='" + Request.QueryString["studid"] + "' And Receipt_no<='" + Request.QueryString["recptno"] + "' And Centre_Code='" + Session["SA_centre_code"] + "'";
                    int reccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                    if (reccount > 1)
                    {
                        lbl_paymenttowards.Text = "Installment";
                        lbl_paymenttowards1.Text = "Installment";
                    }
                    else
                    {
                        lbl_paymenttowards.Text = "Enrollment";
                        lbl_paymenttowards1.Text = "Enrollment";
                    }
                    if (dt.Rows[0]["payment_mode"].ToString() == "Cheque" || dt.Rows[0]["payment_mode"].ToString() == "D.D" || dt.Rows[0]["payment_mode"].ToString() == "C.C")
                    {
                        if (reccount > 1)
                        {
                            lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
                            lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
                            lbl_Bank.Visible = true;
                            lbl_Bank1.Visible = true;
                            lbl_BankName.Visible = true;
                            lbl_BankName1.Visible = true;
                            lbl_Bank.Text = "Bank ";
                            lbl_Bank1.Text = "Bank ";
                            lbl_BankName.Text = dt.Rows[0]["Bank_name"].ToString() + " ";
                            lbl_BankName1.Text = dt.Rows[0]["Bank_name"].ToString() + " ";
                        }
                        else
                        {
                            _Qry = "Select Creditddno,Bankname From Adm_Generalinfo where student_id='" + Request.QueryString["studid"] + "'";
                            DataTable dtcredit = new DataTable();
                            dtcredit = MVC.DataAccess.ExecuteDataTable(_Qry);

                            lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dtcredit.Rows[0]["Creditddno"].ToString() + ")";
                            lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dtcredit.Rows[0]["Creditddno"].ToString() + ")";
                            lbl_Bank.Visible = true;
                            lbl_Bank1.Visible = true;
                            lbl_BankName.Visible = true;
                            lbl_BankName1.Visible = true;
                            lbl_Bank.Text = "Bank ";
                            lbl_Bank1.Text = "Bank ";
                            lbl_BankName.Text = dtcredit.Rows[0]["Bankname"].ToString() + " ";
                            lbl_BankName1.Text = dtcredit.Rows[0]["Bankname"].ToString() + " ";
                        }
                    }

                    //if (dt.Rows[0]["payment_mode"].ToString() == "Cheque")
                    //{
                    //    lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
                    //    lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString() + "(" + dt.Rows[0]["dd_no"].ToString() + ")";
                    //}
                    //else
                    //{
                    //    lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();
                    //    lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString();
                    //}

                    //lbl_bankname.Text = dt.Rows[0]["Bank_name"].ToString();
                    //lbl_bankname1.Text = dt.Rows[0]["Bank_name"].ToString();



                    //lbl_paymenttowards.Text = dt.Rows[0]["payment_towards"].ToString();
                    //lbl_paymenttowards1.Text = dt.Rows[0]["payment_towards"].ToString();

                    lbl_monthinstallment.Text = dt.Rows[0]["month_instal"].ToString();
                    lbl_monthinstallment1.Text = dt.Rows[0]["month_instal"].ToString();

                    //fee calc


                    //_Qry = "select monthlyinstal_tax,round(totalmonthly_tax,0)as totalmonthly_tax,round(initialamount,0) as initialamount,round(initialamout_tax,2)as initialamout_tax,round(totinitialamt_tax,0)as totinitialamt_tax from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                    _Qry = "select monthlyinstal_tax,replace(convert(varchar,cast((round(totalamtpaid,0)) as money),1),'.00','') as initialamount,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','') as totalmonthly_tax,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','')as initialamout_tax,replace(convert(varchar,cast((round(tatamtpaidwithtax,0)) as money),1),'.00','')as totinitialamt_tax from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";

                    DataTable dt1 = new DataTable();
                    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt1.Rows.Count > 0)
                    {
                        lbl_sum.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        lbl_sum1.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();

                        lbl_tax.Text = dt1.Rows[0]["initialamout_tax"].ToString();
                        lbl_tax1.Text = dt1.Rows[0]["initialamout_tax"].ToString();

                        lbl_total.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        lbl_total1.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();

                        lbl_fees.Text = dt1.Rows[0]["initialamount"].ToString();
                        lbl_fees1.Text = dt1.Rows[0]["initialamount"].ToString();
                    }
                }
                //_Qry = "select a.program from [Ipad_centre_coursefee_details] a where ( Select count(*) from Ipad_generalinfo where student_id='" + Request.QueryString["studid"] + "') >0";
                //_Qry = "select CourseName from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
                _Qry = "select a.program,a.coursename,a.course_id from img_coursedetails a inner join adm_generalinfo b on b.coursename = a.Course_ID where student_id='" + Request.QueryString["studid"] + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lbl_coursecode.Text = dt2.Rows[0]["program"].ToString();
                    lbl_coursecode1.Text = dt2.Rows[0]["program"].ToString();
                }
            }
            else
            {
                _Qry = "select convert(varchar,rec.[date], 3) as dateins,rec.Rec_no as Receipt_no,rec.Inv_no as Invoice_No,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards from OldReceipt_Details rec where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Rec_no='" + Request.QueryString["recptno"] + "' ";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dt.Rows.Count > 0)
                {
                    //date format

                    lbl_date.Text = dt.Rows[0]["dateins"].ToString();
                    lbl_date1.Text = dt.Rows[0]["dateins"].ToString();
                    //lbl_paydate.Text = dt.Rows[0]["dateins"].ToString();
                    //lbl_paydate1.Text = dt.Rows[0]["dateins"].ToString();

                    lbl_recpno.Text = Request.QueryString["recptno"];
                    lbl_recpno1.Text = Request.QueryString["recptno"];

                    lbl_invoice.Text = dt.Rows[0]["Invoice_no"].ToString();
                    lbl_invoice1.Text = dt.Rows[0]["Invoice_no"].ToString();

                    lbl_studname.Text = dt.Rows[0]["student_name"].ToString();
                    lbl_studname1.Text = dt.Rows[0]["student_name"].ToString();

                    lbl_inwords.Text = dt.Rows[0]["payment_words"].ToString();
                    lbl_inwords1.Text = dt.Rows[0]["payment_words"].ToString();

                    //lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();
                    //lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString();

                    //lbl_bankname.Text = dt.Rows[0]["Bank_name"].ToString();
                    //lbl_bankname1.Text = dt.Rows[0]["Bank_name"].ToString();


                    string pay_mode = dt.Rows[0]["payment_mode"].ToString();
                    string[] splitpaymode = pay_mode.Split('~');
                    if (splitpaymode.Length > 1)
                    {
                        lbl_ddcc.Text = splitpaymode[0].ToString() + "(" + splitpaymode[1].ToString() + ")";
                        lbl_ddcc1.Text = splitpaymode[0].ToString() + "(" + splitpaymode[1].ToString() + ")";
                        //lbl_bankname.Text = splitpaymode[2].ToString();
                        //lbl_bankname1.Text = splitpaymode[2].ToString();
                        lbl_Bank.Visible = true;
                        lbl_Bank1.Visible = true;
                        lbl_BankName.Visible = true;
                        lbl_BankName1.Visible = true;
                        lbl_Bank.Text = "Bank ";
                        lbl_Bank1.Text = "Bank ";
                        lbl_BankName.Text = splitpaymode[2].ToString();
                        lbl_BankName1.Text = splitpaymode[2].ToString();
                    }
                    else
                    {
                        lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();
                        lbl_ddcc1.Text = dt.Rows[0]["payment_mode"].ToString();
                        lbl_Bank.Visible = false;
                        lbl_Bank1.Visible = false;
                        lbl_BankName.Visible = false;
                        lbl_BankName1.Visible = false;
                    }



                    //lbl_ddcc.Text = dt.Rows[0]["payment_mode"].ToString();

                    //lbl_paydate.Text = dt.Rows[0]["dateins"].ToString();

                    //lbl_bankname.Text = dt.Rows[0]["Bank_name"].ToString();

                    _Qry = "Select Count(*) From OldReceipt_Details Where student_id='" + Request.QueryString["studid"] + "' And Rec_no<='" + Request.QueryString["recptno"] + "'";
                    int reccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                    if (reccount > 1)
                    {
                        lbl_paymenttowards.Text = "Installment";
                        lbl_paymenttowards1.Text = "Installment";
                    }
                    else
                    {
                        lbl_paymenttowards.Text = "Enrollment";
                        lbl_paymenttowards1.Text = "Enrollment";
                    }

                    lbl_monthinstallment.Text = dt.Rows[0]["month_instal"].ToString();
                    lbl_monthinstallment1.Text = dt.Rows[0]["month_instal"].ToString();

                    if (lbl_monthinstallment.Text == "Initial")
                    {
                        _Qry = "select DATENAME(month, date_ins) as month from OldEnrolled_Details where student_id='" + Request.QueryString["studid"] + "'";
                        SqlDataReader drmon;
                        drmon = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                        if (drmon.HasRows)
                        {
                            drmon.Read();
                            lbl_monthinstallment.Text = drmon["month"].ToString();
                            lbl_monthinstallment1.Text = drmon["month"].ToString();
                            drmon.Close();
                        }
                    }

                    //fee calc

                    int recep_no = Convert.ToInt32(lbl_recpno.Text);
                    int checkrec_no = 0;

                    _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
                    DataTable dt89 = new DataTable();
                    dt89 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt89.Rows.Count > 0)
                    {
                        string val = dt89.Rows[0]["center_code"].ToString();
                        if (Session["SA_centre_code"].ToString() == val)
                        {
                            checkrec_no = Convert.ToInt32( dt89.Rows[0]["last_receipt"].ToString());

                        }
                        else
                        {
                            checkrec_no = 5000;
                        }
                    }




                    if (recep_no >= checkrec_no)
                    {
                        _Qry = "select '10.3%' as monthlyinstal_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','') as totalmonthly_tax,replace(convert(varchar,cast((round(totalamtpaid,0)) as money),1),'.00','') as initialamount,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','')as initialamout_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','')as totinitialamt_tax from Old_install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                    }
                    else
                    {
                        _Qry = "select '10.3%' as monthlyinstal_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','') as totalmonthly_tax,replace(convert(varchar,cast((round(totalamtpaid,0)) as money),1),'.00','') as initialamount,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','')as initialamout_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','')as totinitialamt_tax from Old_install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                    }

                    //_Qry = "select '10.3%' as monthlyinstal_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','') as totalmonthly_tax,replace(convert(varchar,cast((round(totalamtpaid,0)) as money),1),'.00','') as initialamount,replace(convert(varchar,cast((round(totamtpaid_tax,0)) as money),1),'.00','')as initialamout_tax,replace(convert(varchar,cast((round(total_Install_amount,0)) as money),1),'.00','')as totinitialamt_tax from Old_install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                    //Response.Write("<br>"+_Qry);
                    //Response.End();
                    DataTable dt1 = new DataTable();
                    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt1.Rows.Count > 0)
                    {
                        //lbl_sum.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        //lbl_tax.Text = dt1.Rows[0]["initialamout_tax"].ToString();
                        //lbl_total.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        //lbl_fees.Text = dt1.Rows[0]["initialamount"].ToString();

                        lbl_sum.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        lbl_sum1.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();

                        lbl_tax.Text = dt1.Rows[0]["initialamout_tax"].ToString();
                        lbl_tax1.Text = dt1.Rows[0]["initialamout_tax"].ToString();

                        lbl_total.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();
                        lbl_total1.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();

                        lbl_fees.Text = dt1.Rows[0]["initialamount"].ToString();
                        lbl_fees1.Text = dt1.Rows[0]["initialamount"].ToString();
                    }
                }
                _Qry = "select Course_Id as CourseName from OldEnrolled_Details where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lbl_coursecode.Text = dt2.Rows[0]["CourseName"].ToString();
                    lbl_coursecode1.Text = dt2.Rows[0]["CourseName"].ToString();
                }
            }
        }
        else
        {
            HiddenField1.Value = Request.QueryString["page"].ToString();
            _Qry = "select id,student_id,receipt_no,Invoice_no,student_name,course_code,replace(convert(varchar,cast((round(breakfees,0)) as money),1),'.00','') as breakfees,amount_words,month,payment_mode,cheque_no,bank_name,convert(varchar,date_ins,103) as date_ins from receipt_breakfee where student_id='" + Request.QueryString["studId"] + "' and receipt_no='" + Request.QueryString["recptno"] + "'";

            DataTable dts = new DataTable();
            dts = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dts.Rows.Count > 0)
            {
                if (dts.Rows[0]["payment_mode"].ToString() == "Cheque" || dts.Rows[0]["payment_mode"].ToString() == "D.D" || dts.Rows[0]["payment_mode"].ToString() == "C.C")
                {
                    lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString() + "(" + dts.Rows[0]["cheque_no"].ToString() + ")";
                    lbl_BankName.Text = dts.Rows[0]["bank_name"].ToString();

                    lbl_ddcc1.Text = dts.Rows[0]["payment_mode"].ToString() + "(" + dts.Rows[0]["cheque_no"].ToString() + ")";
                    //lbl_BankName1.Text = dts.Rows[0]["bank_name"].ToString();

                    lbl_Bank.Visible = true;
                    lbl_BankName.Visible = true;

                    lbl_Bank1.Visible = true;
                    lbl_BankName1.Visible = true;

                    lbl_Bank.Text = "Bank ";
                    lbl_BankName.Text = dts.Rows[0]["bank_name"].ToString() + " ";

                    lbl_Bank1.Text = "Bank ";
                    lbl_BankName1.Text = dts.Rows[0]["bank_name"].ToString() + " ";
                }
                else
                {
                    lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString();
                    lbl_ddcc1.Text = dts.Rows[0]["payment_mode"].ToString();
                }

                if (dts.Rows[0]["payment_mode"].ToString() == "Cash")
                {
                    lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString();
                    lbl_Bank.Visible = false;
                    lbl_BankName.Visible = false;

                    lbl_ddcc1.Text = dts.Rows[0]["payment_mode"].ToString();
                    lbl_Bank1.Visible = false;
                    lbl_BankName1.Visible = false;
                }
                lbl_date.Text = dts.Rows[0]["date_ins"].ToString();
                lbl_date1.Text = dts.Rows[0]["date_ins"].ToString();
                lbl_recpno.Text = Request.QueryString["recptno"];
                lbl_recpno1.Text = Request.QueryString["recptno"];
                lbl_inwords.Text = dts.Rows[0]["amount_words"].ToString();
                lbl_inwords1.Text = dts.Rows[0]["amount_words"].ToString();
                lbl_monthinstallment.Text = dts.Rows[0]["month"].ToString();
                lbl_monthinstallment1.Text = dts.Rows[0]["month"].ToString();
                lbl_fees.Text = dts.Rows[0]["breakfees"].ToString();
                lbl_fees1.Text = dts.Rows[0]["breakfees"].ToString();
                lbl_sum.Text = dts.Rows[0]["breakfees"].ToString();
                lbl_sum1.Text = dts.Rows[0]["breakfees"].ToString();
                lbl_total.Text = dts.Rows[0]["breakfees"].ToString();
                lbl_total1.Text = dts.Rows[0]["breakfees"].ToString();
                //lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString();
                lbl_BankName.Text = dts.Rows[0]["bank_name"].ToString();
                lbl_BankName1.Text = dts.Rows[0]["bank_name"].ToString();

                lbl_invoice.Text = dts.Rows[0]["Invoice_no"].ToString();
                lbl_invoice1.Text = dts.Rows[0]["Invoice_no"].ToString();
                lbl_coursecode.Text = dts.Rows[0]["course_code"].ToString();
                lbl_coursecode1.Text = dts.Rows[0]["course_code"].ToString();
                lbl_studname.Text = dts.Rows[0]["student_name"].ToString();
                lbl_studname1.Text = dts.Rows[0]["student_name"].ToString();

                lbl_tax.Text = "0";
                lbl_tax1.Text = "0";
                lbl_paymenttowards.Text = "Breakage";
                lbl_paymenttowards1.Text = "Breakage";
            }
            // _Qry = "select Invoice_No from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' And centre_code='" + Session["SA_centre_code"] + "'";

            //SqlDataReader dr123;
            //dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            //if (dr123.HasRows)
            //{
            //    dr123.Read();

            //    Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

            //    dr123.Close();
            //}
            ////   _Qry = "select date_format( rec.dateins, '%d-%m-%Y' ) AS dateins,rec.Receipt_no,rec.Invoice_no,rec.course_code,rec.student_name,rec.payment_mode,rec.month_instal,rec.payment_words,rec.payment_towards,round(install.monthlyinstal)as monthlyinstal,gen.Bankname,gen.creditddno,install.initialamount,install.initialamout_tax,install.totinitialamt_tax from (Receipt_Details rec INNER JOIN install_amountdetails install on rec.student_id=install.student_id) Inner JOIN adm_generalinfo gen on gen.student_id=rec.student_id where rec.student_id='" + Request.QueryString["studid"] + "' and rec.Receipt_no='" + Request.QueryString["recptno"] + "' group by rec.Receipt_Id";
            //if (Invoice_no > 493)
            //{
            //    _Qry = "select recp.Receipt_no,recp.Invoice_no,recp.course_code,recp.student_name,round(totinstalamount_tax,0) as totinstalment,round(instal.initialamount,2)as initialamount,instal.monthlyinstal_tax,a.program from receipt_details recp inner join install_amountdetails instal on recp.student_id=instal.student_id inner join img_coursedetails a on a.course_id=recp.course_code where recp.student_id='" + Request.QueryString["studId"] + "'";
            //    DataTable dt = new DataTable();
            //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //    if (dt.Rows.Count > 0)
            //    {
            //        lbl_invoice.Text = dt.Rows[0]["Invoice_no"].ToString();
            //        lbl_invoice1.Text = dt.Rows[0]["Invoice_no"].ToString();
            //        lbl_coursecode.Text = dt.Rows[0]["program"].ToString();
            //        lbl_coursecode1.Text = dt.Rows[0]["program"].ToString();
            //        lbl_studname.Text = dt.Rows[0]["student_name"].ToString();
            //        lbl_studname1.Text = dt.Rows[0]["student_name"].ToString();

            //    }
            //}
            //else
            //{
            //    _Qry = "select a.inv_no,a.COurse_Code,a.Student_Name ,replace(replace(Round(total_install_amount,0),'.00',''),'-','') as installamount,replace(replace(round(b.Install_Amount,0),'.00',''),'-','') as initialamount,replace(replace(round(b.Install_Amount_tax,0),'.00',''),'-','') as monthlyinstal_tax from OldReceipt_Details a inner join Old_Install_AmountDetails b on a.student_id=b.student_id where a.student_id='" + Request.QueryString["studid"] + "' Group by  a.inv_no,a.COurse_Code,a.Student_Name,round(b.Install_Amount,0),round(b.Install_Amount_tax,0),Round(total_install_amount,0)";
            //    DataTable dt2 = new DataTable();
            //    dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
            //    if (dt2.Rows.Count > 0)
            //    {
            //        lbl_invoice.Text = dt2.Rows[0]["inv_no"].ToString();
            //        lbl_invoice1.Text = dt2.Rows[0]["inv_no"].ToString();
            //        lbl_coursecode.Text = dt2.Rows[0]["COurse_Code"].ToString();
            //        lbl_coursecode1.Text = dt2.Rows[0]["COurse_Code"].ToString();
            //        lbl_studname.Text = dt2.Rows[0]["Student_Name"].ToString();
            //        lbl_studname1.Text = dt2.Rows[0]["Student_Name"].ToString();
            //    }
            //}
        }
    }
}
