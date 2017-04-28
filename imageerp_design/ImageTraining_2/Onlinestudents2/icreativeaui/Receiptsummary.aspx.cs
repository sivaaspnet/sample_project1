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

public partial class superadmin_Receiptsummary : System.Web.UI.Page
{
    string _Qry,_Qry1,_Qry2;
    Double Total;
    int Invoice_no = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Fillsummary();
            
        }
        btnconfirmit.Visible = false;
        btnmodify.Visible = true;
       
    }
   
    private void Fillsummary()
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
        if (Invoice_no > 2694)
        {
            try
            {
                _Qry = "select dateins,Receipt_no,Invoice_no,student_name,payment_mode,month_instal,payment_words from receipt_details where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";


                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    string installdate = dt.Rows[0]["dateins"].ToString();
                    string[] strSplitArr = installdate.Split(' ');
                    string installdate1 = strSplitArr[0].ToString();

                    string installdate2 = installdate1;
                    string[] strSplitArr1 = installdate2.Split('/');

                    if (Convert.ToInt32(strSplitArr1[1]) < 10)
                    {
                        strSplitArr1[1] = "0" + strSplitArr1[1];
                    }

                    string smonth = strSplitArr1[0].ToString();
                    string sdate = strSplitArr1[1].ToString();
                    string syear = strSplitArr1[2].ToString();



                    string apdate = sdate + "-" + smonth + "-" + syear;
                    lbl_date.Text = apdate;

                    lbl_recpno.Text = dt.Rows[0]["Receipt_no"].ToString();

                    lbl_invoicenum.Text = dt.Rows[0]["Invoice_no"].ToString();

                    lbl_studname.Text = dt.Rows[0]["student_name"].ToString();

                    lbl_paywords.Text = dt.Rows[0]["payment_words"].ToString();

                    lbl_monthinstall.Text = dt.Rows[0]["month_instal"].ToString();
                    lbl_paymenttype.Text = dt.Rows[0]["payment_mode"].ToString();


                }

                _Qry1 = "select replace(round(initialamount,0),'.00','') as initialamount,initialamout_tax,replace(round(totinitialamt_tax,0),'.00','') as totinitialamt_tax from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt1.Rows.Count > 0)
                {
                    lbl_amount.Text = dt1.Rows[0]["initialamount"].ToString();
                    //Calculate Total
                    double month_instal_amt = Convert.ToDouble(lbl_amount.Text);
                    double month_tx = Convert.ToDouble(dt1.Rows[0]["initialamout_tax"].ToString());
                    Total = month_instal_amt + month_tx;
                    lbltotamtwithtax.Text = dt1.Rows[0]["totinitialamt_tax"].ToString();

                }
                //_Qry2 = "select program from [Ipad_centre_coursefee_details] where ( Select count(*) from receipt_details where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "') >0";
                _Qry2 = "select a.program from receipt_details b inner join img_coursedetails a on b.course_code=a.course_id where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                if (dt2.Rows.Count > 0)
                {
                    lbl_coursecode.Text = dt2.Rows[0]["program"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblerrmsg.Text = "Please Contact Admin";
            }
        }
        else
        {
            //try
            //{
                _Qry = "select date,Rec_no,Inv_no,student_name,payment_mode,month_instal,payment_words from OldReceipt_Details where student_id='" + Request.QueryString["studid"] + "' and Rec_no='" + Request.QueryString["recptno"] + "'";

                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    string installdate = dt.Rows[0]["date"].ToString();
                    string[] strSplitArr = installdate.Split(' ');
                    string installdate1 = strSplitArr[0].ToString();

                    string installdate2 = installdate1;
                    string[] strSplitArr1 = installdate2.Split('/');

                    if (Convert.ToInt32(strSplitArr1[1]) < 10)
                    {
                        strSplitArr1[1] = "0" + strSplitArr1[1];
                    }

                    string smonth = strSplitArr1[0].ToString();
                    string sdate = strSplitArr1[1].ToString();
                    string syear = strSplitArr1[2].ToString();



                    string apdate = sdate + "-" + smonth + "-" + syear;
                    lbl_date.Text = apdate;

                    lbl_recpno.Text = dt.Rows[0]["Rec_no"].ToString();

                    lbl_invoicenum.Text = dt.Rows[0]["Inv_no"].ToString();

                    lbl_studname.Text = dt.Rows[0]["student_name"].ToString();

                    lbl_paywords.Text = dt.Rows[0]["payment_words"].ToString();

                    lbl_monthinstall.Text = dt.Rows[0]["month_instal"].ToString();

                    string paymode = dt.Rows[0]["payment_mode"].ToString();
                    string[] splitpaymode = paymode.Split('~');
                    if (splitpaymode.Length > 1)
                    {
                        lbl_paymenttype.Text = splitpaymode[0].ToString();
                    }
                    else
                    {
                        lbl_paymenttype.Text = dt.Rows[0]["payment_mode"].ToString();
                    }


                }

                _Qry1 = "select Course_ID,replace(round(install_amount,0),'.00','')as initialamount,install_amount_tax,replace(round(total_install_amount,0),'.00','') as total_install_amount from Old_Install_AmountDetails where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
                //Response.Write(_Qry1);
                //Response.End();
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt1.Rows.Count > 0)
                {
                    lbl_amount.Text = dt1.Rows[0]["initialamount"].ToString();
                    //Calculate Total
                    double month_instal_amt = Convert.ToDouble(lbl_amount.Text);
                    double month_tx = Convert.ToDouble(dt1.Rows[0]["install_amount_tax"].ToString());
                    Total = month_instal_amt + month_tx;
                    //if (Total >= 10000000)
                    //{
                    //    lbltotamtwithtax.Text = Total.ToString("##\",\"00\",\"00\",\"000");
                    //}
                    //else if (Total >= 100000)
                    //{
                    //    lbltotamtwithtax.Text = Total.ToString("##\",\"00\",\"000");
                    //}
                    //else
                    //{
                    //    lbltotamtwithtax.Text = Total.ToString("#,000");
                    //}
                    lbltotamtwithtax.Text = dt1.Rows[0]["total_install_amount"].ToString();

                }
                //_Qry2 = "select program from [Ipad_centre_coursefee_details] where ( Select count(*) from receipt_details where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "') >0";
                //DataTable dt2 = new DataTable();
                //dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                //if (dt2.Rows.Count > 0)
                //{
                lbl_coursecode.Text = dt1.Rows[0]["Course_ID"].ToString();
                //}
            //}
            //catch (Exception ex)
            //{
            //    lblerrmsg.Text = "Please Contact Admin";
            //}
        }
    }

    protected void btnmodify_Click(object sender, EventArgs e)
    {

        try
        {
            double initamt = Convert.ToDouble(lbl_amount.Text);
            double taxamt = initamt * (10.3 / 100);

            //_Qry1 = "update receipt_details set month_instal='" + lbl_monthinstall.Text + "',payment_mode='" + lbl_paymenttype.Text + "' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";

            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

            ////_Qry = "update install_amountdetails set initialamount='" + hdnpayinitial.Value + "',initialamout_tax='" + taxamt + "',totinitialamt_tax='" + hdnpaytax.Value + "',totalmonthly_tax='" + hdnpaytax.Value + "',monthlyinstal='" + hdnpayinitial.Value + "',tatamtpaidwithtax='" + hdnpaytax.Value + "',status='completed' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";

            //_Qry = "update install_amountdetails set initialamount='" + lbl_amount.Text + "',initialamout_tax='" + taxamt + "',totinitialamt_tax='" + lbltotamtwithtax.Text + "',totalmonthly_tax='" + lbltotamtwithtax.Text + "',monthlyinstal='" + lbl_amount.Text + "',tatamtpaidwithtax='" + lbltotamtwithtax.Text + "',status='completed' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";

     
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            ////lblerrmsg.Text = "The receipt details modified successfully";

            ////btnmodify.Visible = false;
            ////btnconfirmit.Visible = true;

            //_Qry1 = "update receipt_details set month_instal='" + lbl_monthinstall.Text + "',payment_mode='" + lbl_paymenttype.Text + "' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);


            //_Qry = "update install_amountdetails set initialamount='" + hdnpayinitial.Value + "',initialamout_tax='" + taxamt + "',totinitialamt_tax='" + hdnpaytax.Value + "',totalmonthly_tax='" + hdnpaytax.Value + "',monthlyinstal='" + hdnpayinitial.Value + "',tatamtpaidwithtax='" + hdnpaytax.Value + "',status='completed' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";

            // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            Response.Redirect("Receiptprint.aspx?studid=" + Request.QueryString["studid"] + "&recptno=" + Request.QueryString["recptno"] + "");
        }
        catch (Exception ex)
        {
            lblerrmsg.Text = "Please Contact Admin";
        }
       
    }
    protected void btnconfirmit_Click(object sender, EventArgs e)
    {
          try
        {
            double initamt = Convert.ToDouble(lbl_amount.Text);
        double taxamt = initamt * (10.3 / 100);

        //_Qry1 = "update receipt_details set month_instal='" + lbl_monthinstall.Text + "',payment_mode='" + lbl_paymenttype.Text + "' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

    
        //_Qry = "update install_amountdetails set initialamount='" + hdnpayinitial.Value + "',initialamout_tax='" + taxamt + "',totinitialamt_tax='" + hdnpaytax.Value + "',totalmonthly_tax='" + hdnpaytax.Value + "',monthlyinstal='" + hdnpayinitial.Value + "',tatamtpaidwithtax='" + hdnpaytax.Value + "',status='completed' where student_id='" + Request.QueryString["studid"] + "' and Receipt_no='" + Request.QueryString["recptno"] + "'";
           
         // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

        Response.Redirect("Receiptprint.aspx?studid=" + Request.QueryString["studid"] + "&recptno=" + Request.QueryString["recptno"] + "");
       }
        catch (Exception ex)
        {
            lblerrmsg.Text = "Please Contact Admin";
        }
          
    }
    
}
