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

public partial class superadmin_Invoiceedit : System.Web.UI.Page
{
    int check = 0;
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, paypattern,instno,insdate;
    int noofins,insprimary;
    double tax1, instalamt, instal_tax, totinstal_tax, amtinitial, updtax, updinittax, splitamt, updsplitinitamt, splitinitamt;
    double count, cfee, splitamtpaid, splitamtpaidadd, splitamtpaidupd, splitamtnonpaidadd, totalsplitamt, cfeediff, cfeeupd;
    double cfeesplit, splitamtpaidadd1, sumoftotal1, instno11;
    int Invoice_no = 0;
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        Button2.Visible = false;
        Button3.Visible = true;
        if (!IsPostBack)
        {
            invoicefill();
            FillInstallments();
            _Qry = "select Invoice_No from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' And centre_code='" + Session["SA_centre_code"] + "'";

            SqlDataReader dr123;
            dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr123.HasRows)
            {
                dr123.Read();

                Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

                dr123.Close();
            }
            if (Invoice_no > 493)
            {
                if (lblpaymentpattern.Text == "Lump sum")
                {
                    Button1.Visible = false;
                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        TextBox txt = new TextBox();
                        txt = (TextBox)r.FindControl("txtupdinstal");
                        txt.Visible = false;

                        Label lb = new Label();

                        lb = (Label)r.FindControl("hdnAdjuststatus");
                        lb.Visible = true;

                        LinkButton lnk = new LinkButton();
                        lnk = (LinkButton)r.FindControl("lnkdelete");

                        lnk.Visible = false;
                    }
                }
                else
                {
                    Button1.Visible = true;
                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        TextBox txt = new TextBox();
                        txt = (TextBox)r.FindControl("txtupdinstal");
                        txt.Visible = true;

                        Label lb = new Label();

                        lb = (Label)r.FindControl("hdnAdjuststatus");
                        lb.Visible = false;
                    }
                }



                _Qry1 = "select sum(initialamount)as initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL";
                DataTable dt16 = new DataTable();
                dt16 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt16.Rows.Count > 0)
                {
                    Hidden1.Value = dt16.Rows[0]["initialamount"].ToString();

                }

                _Qry1 = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt.Rows.Count > 0)
                {
                    tax1 = Convert.ToDouble(dt.Rows[0]["tax"].ToString());

                }
                int sumoftotal = 0;
                foreach (GridViewRow grd in GridView1.Rows)
                {
                    TextBox updtxt = new TextBox();
                    updtxt = ((TextBox)grd.FindControl("txtupdinstal"));

                    Label lbl = new Label();
                    lbl = (Label)grd.FindControl("hdnlbl");

                    Label adjust = new Label();
                    adjust = (Label)grd.FindControl("hdnAdjuststatus");

                    Label Paidamt = new Label();
                    Paidamt = (Label)grd.FindControl("hdnamtpaid");


                    if (updtxt.Text == "" || updtxt.Text == null)
                    {
                        instalamt = 0;
                    }

                    else
                    {
                        instalamt = Convert.ToDouble(updtxt.Text);
                    }

                    instal_tax = instalamt * (tax1 / 100);

                    totinstal_tax = instalamt + instal_tax;



                    if (CheckIsInt(updtxt.Text) != 0)
                    {
                        if (updtxt.Text == adjust.Text)
                        {
                            _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='0' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                            //Response.Write("<br>1:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                            //Response.Write("<br>2:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        if (Paidamt.Text != "" || Paidamt.Text != null)
                        {
                            _Qry = "update install_amountdetails set Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NOT NULL";
                            //Response.Write("<br>3:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        //FillInstallments();
                        //lblerrmsg.Text = "The Installment Amount has been Updated Successfully";

                    }
                    else
                    {
                        //Response.Write("True");
                        _Qry = "delete from install_amountdetails  where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "'";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        lblerrmsg.Text = "The Installment has been Deleted Successfully";
                        FillInstallments();

                        //new
                        _Qry4 = "select instal_no from invoice_details where student_id ='" + Request.QueryString["studid"] + "'";
                        DataTable dt8 = new DataTable();
                        dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                        if (dt8.Rows.Count > 0)
                        {
                            lblnoofinstal.Text = dt8.Rows[0]["instal_no"].ToString();
                            noofins = Convert.ToInt32(lblnoofinstal.Text);
                        }
                        int noofins1 = noofins - 1;
                        lblnoofinstal.Text = Convert.ToString(noofins1);

                        //entered by
                        _Qry2 = "update invoice_details set instal_no='" + lblnoofinstal.Text + "' where student_id ='" + Request.QueryString["studid"] + "' and enteredby='" + Session["SA_Username"] + "'";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
                    }

                    

                    if (sumoftotal != 0)
                    {
                        if (CheckIsInt(updtxt.Text) != 0)
                        {
                            //Response.Write("<br/>Total IS:" + updtxt.Text);
                            sumoftotal = sumoftotal + Convert.ToInt32(updtxt.Text);
                        }
                    }

                    else
                    {
                        if (CheckIsInt(updtxt.Text) != 0)
                        {
                            sumoftotal = Convert.ToInt32(updtxt.Text);
                        }
                    }

                }
                //Response.Write("Value Is:" + sumoftotal);
                //Response.Write("Course Is:" + lblcoursefee.Text);
                //Response.End();

                if (sumoftotal == Convert.ToInt32(lblcoursefee.Text))
                {
                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = Convert.ToDouble(sumoftotal) - cfee;

                    _Qry = "Select Course_Fees from install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select sum(initialamount) as Pendingamount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select sum(initialamount) as PaidAmount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NOT NULL and Adjust_status!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    //Response.Write("Amount iS:" + splitamt);
                    //Response.End();

                    _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());
                        instno = dt11.Rows[k]["instal_number"].ToString();

                        //Response.Write("Split Amount Is:" + splitamt);
                        //Response.End();

                        //splitamtpaidadd = splitinitamt - Math.Floor(splitamt);

                        splitamtpaidadd = splitamt;
                        //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                        //Response.End();
                        if (splitamtpaidadd > 0)
                        {
                            updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                            updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                            _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal=round('" + splitamtpaidadd + "',0),monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "Delete From install_amountdetails where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                    }

                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Response.Redirect("Receiptdetails.aspx");
                    Button3.Visible = false;
                    Button2.Visible = true;
                }
                else if (sumoftotal > Convert.ToInt32(lblcoursefee.Text))
                {
                    //Response.Write("T2");
                    //Response.End();
                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = Convert.ToDouble(sumoftotal) - cfee;

                    _Qry = "Select Course_Fees from install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select sum(initialamount) as Pendingamount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select sum(initialamount) as PaidAmount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NOT NULL and Adjust_status!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    //Response.Write("Amount iS:" + splitamt);
                    //Response.End();

                    _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count ; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());
                        instno = dt11.Rows[k]["instal_number"].ToString();

                        //Response.Write("Split Amount Is:" + splitamt);
                        //Response.End();

                        //splitamtpaidadd = splitinitamt - Math.Floor(splitamt);

                        splitamtpaidadd = splitamt;
                        //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                        //Response.End();
                        if (splitamtpaidadd > 0)
                        {
                            updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                            updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                            _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal=round('" + splitamtpaidadd + "',0),monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "Delete From install_amountdetails where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                    }
                    //Response.End();
                    if (dt11.Rows.Count - 1 > 0)
                    {
                        int h = dt11.Rows.Count - 1;

                        splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                        instno = dt11.Rows[h]["instal_number"].ToString();


                        splitamtpaidadd = splitinitamt - Math.Floor(splitamt);
                        updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                        updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                        //Response.Write("Split Amount Initial Is:" + splitinitamt);
                        //Response.End();
                        //Response.Write("Split Amount  Is:" + splitamt);

                        //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                        //Response.End();


                        _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                        //Response.Write("<br>8:" + _Qry);
                        //Response.End();
                        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    }
                    //_Qry = "select sum(initialamount)as initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' ";
                    //DataTable dt15 = new DataTable();
                    //dt15 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    //if (dt15.Rows.Count > 0)
                    //{
                    //    sumoftotal1 = Convert.ToDouble(dt15.Rows[0]["initialamount"].ToString());
                    //}
                    ////Response.Write("Sum of overall total " + sumoftotal1 + "<br/>");
                    //if (cfee != Convert.ToDouble(sumoftotal1))
                    //{
                    //    int h = dt11.Rows.Count - 1;

                    //    splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                    //    instno = dt11.Rows[h]["instal_number"].ToString();


                    //    //splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
                    //    splitamtpaidadd = splitinitamt;

                    //    cfeediff = Convert.ToDouble(sumoftotal) - cfee;
                    //    //cfeediff = cfee - Convert.ToDouble(sumoftotal1);
                    //    instno = dt11.Rows[h]["instal_number"].ToString();

                    //    //Response.Write("Difference in course fee " + cfeediff + "<br/>");
                    //    splitamtpaidadd1 = splitamtpaidadd - cfeediff;

                    //    //Response.Write("<br>Value:" + splitamtpaidadd1 + "<br/>2:" + splitamtpaidadd + "<br/>3:" + cfeediff);
                    //    //Response.End();
                    //    //Response.Write("Difference in course fee After adding " + cfeediff + "<br/>");



                    //    updtax = Convert.ToDouble(splitamtpaidadd1 * (10.3 / 100));
                    //    updinittax = Convert.ToDouble(splitamtpaidadd1 + updtax);


                    //    _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd1 + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd1 + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                    //    Response.Write("<br>9:" + _Qry);
                    //    Response.End();
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    //    FillInstallments();
                    //}

                    FillInstallments();
                    //Shuffle

                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Response.Redirect("Receiptdetails.aspx");
                    Button3.Visible = false;
                    Button2.Visible = true;
                }
                else if (sumoftotal < Convert.ToInt32(lblcoursefee.Text))
                {
                    //Response.Write("T3");
                    //Response.End();
                    //Shuffle


                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = cfee - Convert.ToDouble(sumoftotal);

                    _Qry = "Select Course_Fees from install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select sum(initialamount) as Pendingamount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select sum(initialamount) as PaidAmount from install_amountdetails where student_id='" + lblstudid.Text + "' And tatamtpaidwithtax IS NOT NULL and Adjust_status!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    //Response.Write("Amount iS:" + splitamt);
                    //Response.End();


                    //cfee = Convert.ToDouble(lblcoursefee.Text);

                    //cfeediff = cfee - Convert.ToDouble(sumoftotal);

                    //_Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                    //if (count > 0)
                    //{

                    //    splitamt = Convert.ToDouble(cfeediff / count);


                    //}

                    _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());
                        instno = dt11.Rows[k]["instal_number"].ToString();

                        //splitamtpaidadd = splitinitamt + Math.Floor(splitamt);

                        splitamtpaidadd = splitamt;


                        updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                        updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                        _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal=round('" + splitamtpaidadd + "',0),monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                        //Response.Write("<br>7:" + _Qry);
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    }
                    //if (dt11.Rows.Count - 1 > 0)
                    //{
                    //    int h = dt11.Rows.Count - 1;

                    //    splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                    //    instno = dt11.Rows[h]["instal_number"].ToString();


                    //    splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
                    //    updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                    //    updinittax = Convert.ToDouble(splitamtpaidadd + updtax);
                    //    _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                    //    //Response.Write("<br>8:" + _Qry);
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //}
                    //_Qry = "select sum(initialamount)as initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' ";
                    //DataTable dt15 = new DataTable();
                    //dt15 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    //if (dt15.Rows.Count > 0)
                    //{
                    //    sumoftotal1 = Convert.ToDouble(dt15.Rows[0]["initialamount"].ToString());
                    //}
                    ////Response.Write("Sum of overall total " + sumoftotal1 + "<br/>");
                    //if (cfee != Convert.ToDouble(sumoftotal1))
                    //{
                    //    cfeediff = cfee - Convert.ToDouble(sumoftotal1);

                    //    //Response.Write("Difference in course fee " + cfeediff + "<br/>");
                    //    splitamtpaidadd1 = splitamtpaidadd + cfeediff;
                    //    //Response.Write("Difference in course fee After adding " + cfeediff + "<br/>");
                    //    updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                    //    updinittax = Convert.ToDouble(splitamtpaidadd + updtax);


                    //    _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd1 + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd1 + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                    //    //Response.Write("<br>9:" + _Qry);
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    //    FillInstallments();
                    //}
                    FillInstallments();
                    //Shuffle

                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Button3.Visible = false;
                    Button2.Visible = true;
                    Response.Redirect("Receiptdetails.aspx");
                }
            }
            else
            {
                //Response.Write("True:" + lblpaymentpattern.Text); ;
                //Response.End();
                if (lblpaymentpattern.Text == "Lump sum")
                {
                    Button1.Visible = false;
                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        TextBox txt = new TextBox();
                        txt = (TextBox)r.FindControl("txtupdinstal");
                        txt.Visible = false;

                        Label lb = new Label();

                        lb = (Label)r.FindControl("hdnAdjuststatus");
                        lb.Visible = true;

                        LinkButton lnk = new LinkButton();
                        lnk = (LinkButton)r.FindControl("lnkdelete");

                        lnk.Visible = false;
                    }
                }
                else
                {
                    Button1.Visible = true;
                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        TextBox txt = new TextBox();
                        txt = (TextBox)r.FindControl("txtupdinstal");
                        txt.Visible = true;

                        Label lb = new Label();

                        lb = (Label)r.FindControl("hdnAdjuststatus");
                        lb.Visible = false;
                    }
                }

                

                _Qry1 = "select sum(install_amount)as initialamount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_no=0";
                DataTable dt16 = new DataTable();
                dt16 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt16.Rows.Count > 0)
                {
                    Hidden1.Value = dt16.Rows[0]["initialamount"].ToString();

                }

                _Qry1 = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt.Rows.Count > 0)
                {
                    tax1 = Convert.ToDouble(dt.Rows[0]["tax"].ToString());

                }
                //Response.Write("testtrue:" + GridView1.Rows.Count);
                //Response.End();
                int sumoftotal = 0;
                foreach (GridViewRow grd in GridView1.Rows)
                {
                    //Response.Write("testtrue");
                    //Response.End();
                    TextBox updtxt = new TextBox();
                    updtxt = ((TextBox)grd.FindControl("txtupdinstal"));

                    Label lbl = new Label();
                    lbl = (Label)grd.FindControl("hdnlbl");

                    Label adjust = new Label();
                    adjust = (Label)grd.FindControl("hdnAdjuststatus");

                    Label Paidamt = new Label();
                    Paidamt = (Label)grd.FindControl("hdnamtpaid");


                    if (updtxt.Text == "" || updtxt.Text == null)
                    {
                        instalamt = 0;
                    }

                    else
                    {
                        instalamt = Convert.ToDouble(updtxt.Text);
                    }

                    instal_tax = instalamt * (tax1 / 100);

                    totinstal_tax = instalamt + instal_tax;

                    

                    if (CheckIsInt(updtxt.Text) != 0)
                    {
                        if (updtxt.Text == adjust.Text)
                        {
                            //_Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='0' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                            _Qry = "update Old_install_amountdetails set install_amount=round('" + updtxt.Text + "',0),install_amount_tax=round('" + instal_tax + "',0),total_install_amount=round('" + totinstal_tax + "',0) where install_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and Receipt_no=0";
                            //Response.Write("<br>1:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            //_Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                            _Qry = "update Old_install_amountdetails set install_amount=round('" + updtxt.Text + "',0),install_amount_tax=round('" + instal_tax + "',0),total_install_amount=round('" + totinstal_tax + "',0) where install_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and Receipt_no=0";
                            //Response.Write("<br>2:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        if (Paidamt.Text != "" || Paidamt.Text != null)
                        {
                            //_Qry = "update install_amountdetails set Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NOT NULL";
                            ////Response.Write("<br>3:" + _Qry);
                            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        //FillInstallments();
                        //lblerrmsg.Text = "The Installment Amount has been Updated Successfully";
                        //Response.End();
                    }
                    else
                    {
                        //Response.Write("True");
                        _Qry = "delete from Old_install_amountdetails  where install_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "'";
                        //Response.Write("<br1>1:" + _Qry);
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        lblerrmsg.Text = "The Installment has been Deleted Successfully";
                        FillInstallments();

                        //new
                        _Qry4 = "select install_numbers from Oldinvoice_details where student_id ='" + Request.QueryString["studid"] + "'";
                        DataTable dt8 = new DataTable();
                        dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                        if (dt8.Rows.Count > 0)
                        {
                            lblnoofinstal.Text = dt8.Rows[0]["install_numbers"].ToString();
                            noofins = Convert.ToInt32(lblnoofinstal.Text);
                        }
                        int noofins1 = noofins - 1;
                        lblnoofinstal.Text = Convert.ToString(noofins1);

                        //entered by
                        _Qry2 = "update Oldinvoice_details set install_numbers='" + lblnoofinstal.Text + "' where student_id ='" + Request.QueryString["studid"] + "' ";
                        //Response.Write("<br1>2:" + _Qry2);
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
                        //Response.End();
                    }
                    if (sumoftotal != 0)
                    {
                        if (CheckIsInt(updtxt.Text) != 0)
                        {
                            sumoftotal = sumoftotal + Convert.ToInt32(updtxt.Text);
                        }
                    }

                    else
                    {
                        if (CheckIsInt(updtxt.Text) != 0)
                        {
                            sumoftotal = Convert.ToInt32(updtxt.Text);
                        }
                    }

                }
                //Response.Write("Value Is:" + sumoftotal);
                //Response.Write("Course Is:" + lblcoursefee.Text);
                //Response.End();

                if (sumoftotal == Convert.ToInt32(lblcoursefee.Text))
                {
                    //Response.Write("T1");

                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = Convert.ToDouble(sumoftotal) - cfee;

                    _Qry = "Select replace(Course_Fees,'.00','') as Course_Fees from Old_install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as Pendingamount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No=0";
                    //Response.Write(_Qry);
                    //Response.End();
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as PaidAmount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }

                    _Qry = "select install_amount,install_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No=0";
                    //Response.Write(_Qry);
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["install_amount"].ToString());
                        instno = dt11.Rows[k]["install_number"].ToString();

                        //Response.Write("Split Amount Is:" + splitamt);
                        //Response.End();

                        //splitamtpaidadd = splitinitamt - Math.Floor(splitamt);
                        splitamtpaidadd = splitamt;

                        if (splitamtpaidadd > 0)
                        {
                            updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                            updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                            _Qry = "update Old_install_amountdetails set install_amount=Round('" + splitamtpaidadd + "',0),install_amount_tax=Round('" + updtax + "',0),total_install_amount=Round('" + updinittax + "',0) where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_no=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "Delete From Old_install_amountdetails where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_No=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                        updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                        updinittax = Convert.ToDouble(splitamtpaidadd + updtax);
                    }
                    

                    FillInstallments();
                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Response.Redirect("Receiptdetails.aspx");
                    Button3.Visible = false;
                    Button2.Visible = true;
                }
                else if (sumoftotal > Convert.ToInt32(lblcoursefee.Text))
                {

                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = Convert.ToDouble(sumoftotal) - cfee;

                    _Qry = "Select replace(Course_Fees,'.00','') as Course_Fees from Old_install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as Pendingamount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No=0";
                    //Response.Write(_Qry);
                    //Response.End();
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as PaidAmount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    
                    _Qry = "select install_amount,install_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No=0";
                    //Response.Write(_Qry);
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["install_amount"].ToString());
                        instno = dt11.Rows[k]["install_number"].ToString();

                        //Response.Write("Split Amount Is:" + splitamt);
                        //Response.End();

                        //splitamtpaidadd = splitinitamt - Math.Floor(splitamt);
                        splitamtpaidadd = splitamt;

                        //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                        //Response.End();

                        if (splitamtpaidadd > 0)
                        {
                            updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                            updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                            _Qry = "update Old_install_amountdetails set install_amount=Round('" + splitamtpaidadd + "',0),install_amount_tax=Round('" + updtax + "',0),total_install_amount=Round('" + updinittax + "',0) where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_no=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "Delete From Old_install_amountdetails where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_No=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                        updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                        updinittax = Convert.ToDouble(splitamtpaidadd + updtax);
                    }
                   

                    FillInstallments();
                    //Shuffle

                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Response.Redirect("Receiptdetails.aspx");
                    Button3.Visible = false;
                    Button2.Visible = true;
                }
                else if (sumoftotal < Convert.ToInt32(lblcoursefee.Text))
                {
                    int Course_Fees = 0;
                    int PaidAmount = 0;
                    int PendingAmount = 0;
                    int AmountPayable = 0;

                    cfee = Convert.ToDouble(lblcoursefee.Text);

                    cfeediff = cfee - Convert.ToDouble(sumoftotal);

                    _Qry = "Select replace(Course_Fees,'.00','') as Course_Fees from Old_install_amountdetails where student_id='" + lblstudid.Text + "'";
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        Course_Fees = Convert.ToInt32(dr["Course_Fees"].ToString());

                        dr.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as Pendingamount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No=0";
                    //Response.Write(_Qry);
                    //Response.End();
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        if (dr1["Pendingamount"].ToString() == "" || dr1["Pendingamount"].ToString() == null)
                        {
                            PendingAmount = 0;
                        }
                        else
                        {
                            PendingAmount = Convert.ToInt32(dr1["Pendingamount"].ToString());
                        }

                        dr1.Close();
                    }

                    _Qry = "select replace(sum(install_amount),'.00','') as PaidAmount from Old_install_amountdetails where student_id='" + lblstudid.Text + "' And Receipt_No!='0'";
                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr2.HasRows)
                    {
                        dr2.Read();

                        if (dr2["PaidAmount"].ToString() == "" || dr2["PaidAmount"].ToString() == null)
                        {
                            PaidAmount = 0;
                        }
                        else
                        {
                            PaidAmount = Convert.ToInt32(dr2["PaidAmount"].ToString());
                        }

                        dr2.Close();
                    }
                    AmountPayable = Course_Fees - PaidAmount;
                    Response.Write("<br/>Course Fees Is:" + Course_Fees);
                    Response.Write("<br/>PaidAmount Is:" + PaidAmount);
                    Response.Write("<br/>PendingAmount Is:" + PendingAmount);
                    Response.Write("<br/>Amount Payable Is:" + AmountPayable);
                    //Response.End();

                    if (AmountPayable > 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }
                    else if (AmountPayable == 0)
                    {
                        _Qry = "select count(install_number)as instal_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No='0'";
                        //Response.Write(_Qry);
                        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(count);
                        if (count > 0)
                        {
                            splitamt = System.Math.Round(Convert.ToDouble(AmountPayable / count), 0);
                        }
                    }


                    _Qry = "select install_amount,install_number from Old_install_amountdetails where student_id='" + lblstudid.Text + "' and Receipt_No=0";
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

                    for (int k = 0; k < dt11.Rows.Count; k++)
                    {
                        //splitinitamt = Convert.ToDouble(dt11.Rows[k]["install_amount"].ToString());
                        instno = dt11.Rows[k]["install_number"].ToString();

                        //splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
                        splitamtpaidadd = splitamt;

                        updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                        updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                        if (splitamtpaidadd > 0)
                        {
                            updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                            updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                            _Qry = "update Old_install_amountdetails set install_amount=Round('" + splitamtpaidadd + "',0),install_amount_tax=Round('" + updtax + "',0),total_install_amount=Round('" + updinittax + "',0) where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_no=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = "Delete From Old_install_amountdetails where student_id='" + lblstudid.Text + "' and install_number='" + instno + "' and Receipt_No=0 ";
                            //Response.Write("<br>7:" + _Qry);
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                    }
                    FillInstallments();
                    //Shuffle

                    lblerrmsg.Text = "The Invoice details updated successfully";
                    Button3.Visible = false;
                    Button2.Visible = true;
                    Response.Redirect("Receiptdetails.aspx");
                }
            }
        }
    }
    #endregion

    #region Go to Insert Installments
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Insertinvoice.aspx?studid="+Request.QueryString["studid"]+"");
    }
    #endregion


    #region for checking the Int or Not
    public static int CheckIsInt(string Id)
    {
        int OutNo = 0;
        int.TryParse(Id, out OutNo);
        return OutNo;
    }
    #endregion


    #region to fill the Invoice Details
    private void invoicefill()
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
        if (Invoice_no > 493)
        {
            try
            {
                _Qry = "select enq_personal_name,enq_number,permanant_phone from adm_personalparticulars where student_id='" + Request.QueryString["studid"] + " '";
                //Response.Write(_Qry);
                //Response.End();

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lblstudname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                    hdninvoiceID.Value = dt.Rows[0]["enq_number"].ToString();
                }
                _Qry1 = "select enq_permanant_address from Img_enquiryform where enq_number='" + hdninvoiceID.Value + "'";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                if (dt1.Rows.Count > 0)
                {
                    lbladdress.Text = dt1.Rows[0]["enq_permanant_address"].ToString();

                }
                _Qry2 = "select centre_code,payment_noofinstall,payment_initial_amt,payment_initial_amt,payment_coursefee,Batchtime,Track,Track1,student_id,payment_pattern from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                if (dt2.Rows.Count > 0)
                {
                    lblcentre.Text = dt2.Rows[0]["centre_code"].ToString();
                    lblpaymentpattern.Text = dt2.Rows[0]["payment_pattern"].ToString();
                    lblcoursefee.Text = dt2.Rows[0]["payment_coursefee"].ToString();
                    lblbatchtime.Text = dt2.Rows[0]["Batchtime"].ToString();
                    lbltrack.Text = dt2.Rows[0]["Track1"].ToString();
                    lblstudid.Text = dt2.Rows[0]["student_id"].ToString();
                }
                _Qry4 = "select instal_no from invoice_details where student_id ='" + Request.QueryString["studid"] + "'";

                DataTable dt8 = new DataTable();
                dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                if (dt8.Rows.Count > 0)
                {
                    lblnoofinstal.Text = dt8.Rows[0]["instal_no"].ToString();
                }
                _Qry3 = "select a.program,a.coursename,a.course_id from img_coursedetails a inner join adm_generalinfo b on b.coursename = a.course_id where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt3 = new DataTable();
                dt3 = MVC.DataAccess.ExecuteDataTable(_Qry3);

                if (dt3.Rows.Count > 0)
                {
                    lblcoursecode.Text = dt3.Rows[0]["coursename"].ToString();
                    lblcourse_id.Text = dt3.Rows[0]["program"].ToString();
                }
                _Qry4 = "select Invoice_id from invoice_details where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt4 = new DataTable();
                dt4 = MVC.DataAccess.ExecuteDataTable(_Qry4);

                if (dt4.Rows.Count > 0)
                {
                    lblinvoiceno.Text = dt4.Rows[0]["Invoice_id"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblerrmsg.Text = "Please Contact Admin";
            }
        }
        else
        {
            try
            {

                _Qry = "Select enq_name,Permanent_address,Mobile From OldEnquiry_Details where Enquiry_no=(Select Enquiry_no from OldEnrolled_Details where student_id='" + Request.QueryString["studid"] + "')";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lblstudname.Text = dt.Rows[0]["enq_name"].ToString();
                    //lblphone.Text = dt.Rows[0]["Mobile"].ToString();
                    lbladdress.Text = dt.Rows[0]["Permanent_address"].ToString();
                }

                _Qry2 = "select Payment_Type,center_code as centre_code,install_numbers as payment_noofinstall,initial_amount as payment_initial_amt,replace(total_amount,'.00','') as payment_coursefee,batch_time as Batchtime,track,student_id from OldEnrolled_Details where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                if (dt2.Rows.Count > 0)
                {
                    int centre_code = Convert.ToInt32(dt2.Rows[0]["centre_code"].ToString());
                    if (centre_code == 3)
                    {
                        lblcentre.Text = "ICH-103";
                        //lbl_centrename.Text = "Annanagar";
                    }
                    if (centre_code == 6)
                    {
                        lblcentre.Text = "ICH-106";
                        //lbl_centrename.Text = "Velachery";
                    }

                    lblcoursefee.Text = dt2.Rows[0]["payment_coursefee"].ToString();

                    double course_fee = Convert.ToDouble(dt2.Rows[0]["payment_coursefee"].ToString());
                    double course_tax = (course_fee * 10.3) / 100;

                    if (course_tax >= 10000000)
                    {
                        //lbltax.Text = course_tax.ToString("##\",\"00\",\"00\",\"000");
                    }
                    else if (course_tax >= 100000)
                    {
                        //lbltax.Text = course_tax.ToString("##\",\"00\",\"000");
                    }
                    else
                    {
                        //lbltax.Text = course_tax.ToString("#,000");
                    }
                    lblpaymentpattern.Text = dt2.Rows[0]["Payment_Type"].ToString();
                    lblbatchtime.Text = dt2.Rows[0]["Batchtime"].ToString();
                    lbltrack.Text = dt2.Rows[0]["Track"].ToString();
                    lblstudid.Text = dt2.Rows[0]["student_id"].ToString();

                }

                //_Qry2 = "select centre_code,payment_noofinstall,payment_initial_amt,payment_initial_amt,payment_coursefee,Batchtime,Track,Track1,student_id,payment_pattern from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
                //DataTable dt2 = new DataTable();
                //dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                //if (dt2.Rows.Count > 0)
                //{
                //    lblcentre.Text = dt2.Rows[0]["centre_code"].ToString();
                //    lblpaymentpattern.Text = dt2.Rows[0]["payment_pattern"].ToString();
                //    lblcoursefee.Text = dt2.Rows[0]["payment_coursefee"].ToString();
                //    lblbatchtime.Text = dt2.Rows[0]["Batchtime"].ToString();
                //    lbltrack.Text = dt2.Rows[0]["Track1"].ToString();
                //    lblstudid.Text = dt2.Rows[0]["student_id"].ToString();
                //}
                _Qry4 = "select install_numbers as instal_no from OldInvoice_details where student_id ='" + Request.QueryString["studid"] + "'";

                DataTable dt8 = new DataTable();
                dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                if (dt8.Rows.Count > 0)
                {
                    lblnoofinstal.Text = dt8.Rows[0]["install_numbers"].ToString();
                }
                //_Qry3 = "select a.program,a.coursename,a.course_id from img_coursedetails a inner join adm_generalinfo b on b.coursename = a.course_id where student_id='" + Request.QueryString["studid"] + "'";
                //DataTable dt3 = new DataTable();
                //dt3 = MVC.DataAccess.ExecuteDataTable(_Qry3);

                //if (dt3.Rows.Count > 0)
                //{
                //    lblcoursecode.Text = dt3.Rows[0]["coursename"].ToString();
                //    lblcourse_id.Text = dt3.Rows[0]["program"].ToString();
                //}

                _Qry3 = "select a.program,a.course_name,a.course_id from OldCourse_details a inner join OldEnrolled_Details b on substring(b.Course_Name,charindex(',',b.Course_Name)+1,len(b.Course_Name)) = a.Course_ID where student_id='" + Request.QueryString["studid"] + "'";
                //Response.Write(_Qry3);
                //Response.End();
                DataTable dt3 = new DataTable();
                dt3 = MVC.DataAccess.ExecuteDataTable(_Qry3);

                if (dt3.Rows.Count > 0)
                {

                    lblcoursecode.Text = dt3.Rows[0]["course_name"].ToString();
                    lblcourse_id.Text = dt3.Rows[0]["program"].ToString();
                }

                _Qry4 = "select Invoice_No from OldInvoice_details where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt4 = new DataTable();
                dt4 = MVC.DataAccess.ExecuteDataTable(_Qry4);

                if (dt4.Rows.Count > 0)
                {
                    lblinvoiceno.Text = dt4.Rows[0]["Invoice_No"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblerrmsg.Text = "Please Contact Admin";
            }
        }
    }
    #endregion

    #region to fill the installments
    private void FillInstallments()
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

        //try
        //{
                if (Invoice_no > 493)
                {
                //_Qry = "select a.instal_number,round(a.initialamount,0) as initialamount,round(a.initialamout_tax,1)as initialamout_tax,round(a.totinitialamt_tax,0)as totinitialamt_tax,invoice.totalinitial_tax,invoice.totalinstal_tax,convert(varchar,a.install_date, 103) AS install_date,invoice.totalamountpaid,a.Receipt_no,a.tatamtpaidwithtax from (install_amountdetails a inner join Receipt_Details receipt on a.Invoice_no=receipt.Invoice_no)inner join invoice_details invoice on a.student_id=invoice.student_id  where a.student_id='" + Request.QueryString["studid"] + "' group by a.instal_Id,a.initialamount,a.initialamout_tax,a.totinitialamt_tax,invoice.totalinitial_tax,invoice.totalinstal_tax,a.install_date,invoice.totalamountpaid,a.Receipt_no,a.tatamtpaidwithtax,a.instal_number";
                    _Qry = "select a.instal_number,replace(round(a.initialamount,0),'-','') as initialamount,replace(round(a.initialamout_tax,1),'-','')as initialamout_tax,replace(round(a.totinitialamt_tax,0),'-','') as totinitialamt_tax,replace(invoice.totalinitial_tax,'-','') as totalinitial_tax,replace(invoice.totalinstal_tax,'-','') as totalinstal_tax,convert(varchar,a.install_date, 103) AS install_date,replace(invoice.totalamountpaid,'-','') as totalamountpaid,a.Receipt_no,replace(a.tatamtpaidwithtax,'-','') as tatamtpaidwithtax from (install_amountdetails a inner join Receipt_Details receipt on a.Invoice_no=receipt.Invoice_no)inner join invoice_details invoice on a.student_id=invoice.student_id  where a.student_id='" + Request.QueryString["studid"] + "' group by a.instal_Id,a.initialamount,a.initialamout_tax,a.totinitialamt_tax,invoice.totalinitial_tax,invoice.totalinstal_tax,a.install_date,invoice.totalamountpaid,a.Receipt_no,a.tatamtpaidwithtax,a.instal_number";
                }
                else
                {
                    _Qry = "select a.install_number as instal_number,replace(round(a.Install_Amount,0),'.00','') as initialamount ,";
                    _Qry += " replace(ROUND(a.Install_Amount_tax,0),'.00','') as initialamout_tax,replace";
                    _Qry += " (round(a.total_install_amount,0),'.00','')as totinitialamt_tax,replace";
                    _Qry += " (round(a.total_install_amount,0),'.00','')as totalinstal_tax,replace";
                    _Qry += " (round(a.total_install_amount,0),'.00','')as totalinitial_tax,replace";
                    _Qry += " (round(a.total_install_amount,0),'.00','')as tatamtpaidwithtax,case when a.receipt_no=0 then NULL else a.receipt_no end as Receipt_no,case when a.receipt_no=0 THEN '' ELSE replace(convert(varchar,cast((round(a.total_install_amount,0)) as money),1),'.00','') ";
                _Qry += " END as totalamoutpaid,convert(varchar, DateAdd(month,(row_number() over (order by a.install_date))-1,a.install_date), 103) AS install_date,(select convert(varchar, date, 103) from OldReceipt_Details where rec_no=a.Receipt_no And student_id='" + Request.QueryString["studid"] + "' group by Rec_no,date) as dateins";
                _Qry += " from Old_install_amountdetails a inner join OldReceipt_Details receipt on a.student_id=";
                _Qry += " receipt.student_id inner join Oldinvoice_details invoice on a.student_id=invoice.student_id where a.student_id='" + Request.QueryString["studid"] + "'";
                _Qry += " group by a.ID,a.install_number,a.Install_Amount,Install_Amount_tax,total_install_amount,install_date,a.Receipt_no,a.total_install_amount";

                }
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                Hidden2.Value = dt.Rows.Count.ToString();

                GridView1.DataSource = dt;
                GridView1.DataBind();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)row.FindControl("lnkdelete");
                    Label lbl1 = new Label();
                    lbl1 = (Label)row.FindControl("hdnamtpaid");
                    if (lbl1.Text == null || lbl1.Text == "")
                    {
                        check = check + 1;
                        lnk.Visible = true;
                    }
                    else
                    {
                        lnk.Visible = false;
                    }

                }
            //}
            //catch (Exception ex)
            //{
            //    lblerrmsg.Text = "Please Contact Admin";
            //}

            if (check == 0)
            {
                Button1.Visible = false;
                Button3.Visible = false;
                Button2.Visible = true;
            }
        
        //Response.Write(GridView1.Rows.Count);
        //Response.End();
    }
    #endregion

    #region to Delete the Installments
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //try
        //{
            if (e.CommandName == "lnkdel")
            {
                _Qry = "select initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' and instal_number='" + e.CommandArgument.ToString() + "'";
                DataTable dt9 = new DataTable();
                dt9 = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dt9.Rows.Count > 0)
                {
                    amtinitial = Convert.ToDouble(dt9.Rows[0]["initialamount"].ToString());

                }

                _Qry = "delete from install_amountdetails where student_id='" + lblstudid.Text + "' and instal_number='" + e.CommandArgument.ToString() + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);


                FillInstallments();

                _Qry4 = "select instal_no from invoice_details where student_id ='" + Request.QueryString["studid"] + "'";

                DataTable dt8 = new DataTable();
                dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                if (dt8.Rows.Count > 0)
                {
                    lblnoofinstal.Text = dt8.Rows[0]["instal_no"].ToString();
                    noofins = Convert.ToInt32(lblnoofinstal.Text);
                }
                if (noofins > 1)
                {
                    int noofins1 = noofins - 1;
                    lblnoofinstal.Text = Convert.ToString(noofins1);
                }
                else
                {
                    lblnoofinstal.Text = Convert.ToString(noofins);
                }

                //entered by
                _Qry2 = "update invoice_details set instal_no='" + lblnoofinstal.Text + "',enteredby='" + Session["SA_Username"] + "' where student_id ='" + Request.QueryString["studid"] + "'";
                //Response.Write(_Qry2);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);


                _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL";


                count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);

                if (count > 0)
                {

                    splitamt = Convert.ToDouble(amtinitial / count);
                }

                _Qry = "select initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NOT NULL";
                DataTable dt11 = new DataTable();
                dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                splitamtpaidadd = 0;
                for (int k = 0; k < dt11.Rows.Count; k++)
                {
                    splitamtpaid = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());

                    splitamtpaidadd = splitamtpaidadd + splitamtpaid;

                }

                _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL";

                DataTable dt10 = new DataTable();
                dt10 = MVC.DataAccess.ExecuteDataTable(_Qry);

                for (int j = 0; j < dt10.Rows.Count; j++)
                {

                    splitinitamt = Convert.ToDouble(dt10.Rows[j]["initialamount"].ToString());
                    instno11 = Convert.ToDouble(dt10.Rows[j]["instal_number"].ToString());
                    updsplitinitamt = splitinitamt + splitamt;
                    updtax = Convert.ToDouble(updsplitinitamt * (10.3 / 100));
                    updinittax = Convert.ToDouble(updsplitinitamt + updtax);

                    _Qry = "update install_amountdetails set initialamount=round('" + updsplitinitamt.ToString() + "',0),initialamout_tax='" + updtax.ToString() + "',totinitialamt_tax='" + updinittax.ToString() + "',monthlyinstal=round('" + updsplitinitamt.ToString() + "',0),monthlyinstal_tax='" + updtax.ToString() + "',totalmonthly_tax='" + updinittax.ToString() + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno11 + "' and tatamtpaidwithtax IS NULL ";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                }

                _Qry = "select Count(*) from install_amountdetails where student_id='" + lblstudid.Text + "'";
                int insno = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                //int insno = Convert.ToInt32(lblnoofinstal.Text);
                //Response.Write("COunt Is:" + insno);
                //Response.End();
                for (int k = 0; k < insno - 1; k++)
                {
                    _Qry1 = "select instal_Id from install_amountdetails where student_id='" + lblstudid.Text + "'";
                    //Response.Write(_Qry1);
                    //Response.End();
                    DataTable dt17 = new DataTable();
                    dt17 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                    if (dt17.Rows.Count > 0)
                    {
                        insprimary = Convert.ToInt32(dt17.Rows[k]["instal_Id"].ToString());
                        //Response.Write("Test:" + insprimary);
                    }
                    _Qry = "select install_date from install_amountdetails where student_id='" + lblstudid.Text + "' and instal_number='0'";
                    //Response.Write(_Qry);
                    //Response.End();
                     dt17 = MVC.DataAccess.ExecuteDataTable(_Qry);
                     if (dt17.Rows.Count > 0)
                     {
                         string str1 = dt17.Rows[0]["install_date"].ToString();
                         string[] strSplitArr = str1.Split(' ');
                         string dob1 = strSplitArr[0].ToString();
                         string[] split1 = dob1.Split('/');
                         insdate = split1[2] + "-" + split1[0] + "-" + split1[1];

                         //insdate = dt17.Rows[0]["install_date"].ToString();
                         //Response.Write("Test:" + insdate);
                         //if (insdate == "01/01/00")
                         //{
                         //    insdate = System.DateTime.Now.ToString("dd/MM/yy");
                         //}
                     }
                     //else
                     //{
                     //    insdate = System.DateTime.Now.ToString("dd/MM/yy");
                     //}
                     _Qry = "update install_amountdetails set instal_number='" + k + "',install_date=DATEADD(MONTH," + k + ",'" + insdate + "') where student_id='" + lblstudid.Text + "' and instal_Id='" + insprimary + "' ";
                     //Response.Write(_Qry);
                     //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                //Response.Write(_Qry);
                //Response.End();
                FillInstallments();
                lblerrmsg.Text = "The Installment has been Deleted Successfully";

            }
        //}
        //catch (Exception ex)
        //{
        //    lblerrmsg.Text = "Please Contact Admin";
        //}
    }
    #endregion

    #region to Update the Installment
    protected void Button3_Click1(object sender, EventArgs e)
    {
       
        _Qry1 = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
        if (dt.Rows.Count > 0)
        {
            tax1 = Convert.ToDouble(dt.Rows[0]["tax"].ToString());

        }
        int sumoftotal = 0;
        foreach (GridViewRow grd in GridView1.Rows)
        {
            TextBox updtxt = new TextBox();
            updtxt = ((TextBox)grd.FindControl("txtupdinstal"));

            Label lbl = new Label();
            lbl = (Label)grd.FindControl("hdnlbl");

            Label adjust = new Label();
            adjust = (Label)grd.FindControl("hdnAdjuststatus");

            Label Paidamt = new Label();
            Paidamt = (Label)grd.FindControl("hdnamtpaid");


            if (updtxt.Text == "" || updtxt.Text == null)
            {
                instalamt = 0;
            }

            else
            {
                instalamt = Convert.ToDouble(updtxt.Text);
            }

            instal_tax = instalamt * (tax1 / 100);

            totinstal_tax = instalamt + instal_tax;


          
            if (CheckIsInt(updtxt.Text) != 0)
            {
                if (updtxt.Text == adjust.Text)
                {
                    _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='0' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                    //Response.Write("<br>1:" + _Qry);
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                else
                {
                    _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";
                    //Response.Write("<br>2:" + _Qry);
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                if (Paidamt.Text != "" || Paidamt.Text != null)
                {
                    _Qry = "update install_amountdetails set Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NOT NULL";
                    //Response.Write("<br>3:" + _Qry);
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                //FillInstallments();
                //lblerrmsg.Text = "The Installment Amount has been Updated Successfully";

            }
            else
            {
                //Response.Write("True");
                _Qry = "delete from install_amountdetails  where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                lblerrmsg.Text = "The Installment has been Deleted Successfully";
                FillInstallments();

                //new
                _Qry4 = "select instal_no from invoice_details where student_id ='" + Request.QueryString["studid"] + "'";
                DataTable dt8 = new DataTable();
                dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                if (dt8.Rows.Count > 0)
                {
                    lblnoofinstal.Text = dt8.Rows[0]["instal_no"].ToString();
                    noofins = Convert.ToInt32(lblnoofinstal.Text);
                }
                int noofins1 = noofins - 1;
                lblnoofinstal.Text = Convert.ToString(noofins1);

                //entered by
                _Qry2 = "update invoice_details set instal_no='" + lblnoofinstal.Text + "' where student_id ='" + Request.QueryString["studid"] + "' and enteredby='" + Session["SA_Username"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
            }
            if (sumoftotal != 0)
            {
                if (CheckIsInt(updtxt.Text) != 0)
                {
                    sumoftotal = sumoftotal + Convert.ToInt32(updtxt.Text);
                }
            }

            else

            {
                if (CheckIsInt(updtxt.Text) != 0)
                {
                    sumoftotal = Convert.ToInt32(updtxt.Text);
                }
            }

        }
        //Response.Write("Value Is:" + sumoftotal);
        //Response.End();
       
        if (sumoftotal == Convert.ToInt32(lblcoursefee.Text))
        {
            //Response.Write("T1");
            lblerrmsg.Text = "The Invoice details updated successfully";
            Button3.Visible = false;
            Button2.Visible = true;
        }
        else if (sumoftotal > Convert.ToInt32(lblcoursefee.Text))
        {
            //Response.Write("T2");
            cfee = Convert.ToDouble(lblcoursefee.Text);

            cfeediff = Convert.ToDouble(sumoftotal) - cfee;
            //cfeediff = cfee - Convert.ToDouble(sumoftotal);

            //Response.Write("Cfee:" + cfee);
            //Response.Write("<Br/>Sum:" + Convert.ToDouble(sumoftotal));

            _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
            //Response.Write(_Qry);
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (count > 0)
            {

                splitamt = Convert.ToDouble(cfeediff / count);


            }

            _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
            //Response.Write(_Qry);
            DataTable dt11 = new DataTable();
            dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

            for (int k = 0; k < dt11.Rows.Count - 1; k++)
            {
                splitinitamt = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());
                instno = dt11.Rows[k]["instal_number"].ToString();

                //Response.Write("Split Amount Is:" + splitamt);
                //Response.End();

                splitamtpaidadd = splitinitamt - Math.Floor(splitamt);

                //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                //Response.End();

                updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal=round('" + splitamtpaidadd + "',0),monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>7:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            }
            if (dt11.Rows.Count - 1 > 0)
            {
                int h = dt11.Rows.Count - 1;

                splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                instno = dt11.Rows[h]["instal_number"].ToString();


                splitamtpaidadd = splitinitamt - Math.Floor(splitamt);
                updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                //Response.Write("Split Amount Initial Is:" + splitinitamt);
                //Response.End();
                //Response.Write("Split Amount  Is:" + splitamt);

                //Response.Write("Split Amount Paid Is:" + splitamtpaidadd);
                //Response.End();


                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>8:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            _Qry = "select sum(initialamount)as initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' ";
            DataTable dt15 = new DataTable();
            dt15 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt15.Rows.Count > 0)
            {
                sumoftotal1 = Convert.ToDouble(dt15.Rows[0]["initialamount"].ToString());
            }
            //Response.Write("Sum of overall total " + sumoftotal1 + "<br/>");
            if (cfee != Convert.ToDouble(sumoftotal1))
            {
                int h = dt11.Rows.Count - 1;

                splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                instno = dt11.Rows[h]["instal_number"].ToString();


                //splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
                splitamtpaidadd = splitinitamt;

                cfeediff = Convert.ToDouble(sumoftotal) - cfee;
                //cfeediff = cfee - Convert.ToDouble(sumoftotal1);
                instno = dt11.Rows[h]["instal_number"].ToString();

                //Response.Write("Difference in course fee " + cfeediff + "<br/>");
                splitamtpaidadd1 = splitamtpaidadd - cfeediff;

                //Response.Write("<br>Value:" + splitamtpaidadd1 + "<br/>2:" + splitamtpaidadd + "<br/>3:" + cfeediff);
                //Response.End();
                //Response.Write("Difference in course fee After adding " + cfeediff + "<br/>");



                updtax = Convert.ToDouble(splitamtpaidadd1 * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd1 + updtax);


                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd1 + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd1 + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>9:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                FillInstallments();
            }

            FillInstallments();
            //Shuffle

            lblerrmsg.Text = "The Invoice details updated successfully";
            Button3.Visible = false;
            Button2.Visible = true;
        }
        else if (sumoftotal < Convert.ToInt32(lblcoursefee.Text))
        {
            //Response.Write("T3");
            //Shuffle
           
            cfee = Convert.ToDouble(lblcoursefee.Text);
          
            cfeediff = cfee - Convert.ToDouble(sumoftotal);

            _Qry = "select count(instal_number)as instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (count > 0)
            {

                splitamt = Convert.ToDouble(cfeediff / count);
             

            }

            _Qry = "select initialamount,instal_number from install_amountdetails where student_id='" + lblstudid.Text + "' and tatamtpaidwithtax IS NULL and Adjust_status='0'";
            DataTable dt11 = new DataTable();
            dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);

            for (int k = 0; k < dt11.Rows.Count-1; k++)
            {
                splitinitamt = Convert.ToDouble(dt11.Rows[k]["initialamount"].ToString());
                instno = dt11.Rows[k]["instal_number"].ToString();
              
                splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
               

                updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd + updtax);

                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd+ "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal=round('" + splitamtpaidadd + "',0),monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>7:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            }
            if (dt11.Rows.Count - 1 > 0)
            {
                int h = dt11.Rows.Count - 1;

                splitinitamt = Convert.ToDouble(dt11.Rows[h]["initialamount"].ToString());
                instno = dt11.Rows[h]["instal_number"].ToString();


                splitamtpaidadd = splitinitamt + Math.Floor(splitamt);
                updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd + updtax);
                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>8:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
             _Qry = "select sum(initialamount)as initialamount from install_amountdetails where student_id='" + lblstudid.Text + "' ";
            DataTable dt15 = new DataTable();
            dt15 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt15.Rows.Count > 0)
            {
                sumoftotal1 = Convert.ToDouble(dt15.Rows[0]["initialamount"].ToString());
            }
            //Response.Write("Sum of overall total " + sumoftotal1 + "<br/>");
            if (cfee != Convert.ToDouble(sumoftotal1))
            {
                cfeediff = cfee - Convert.ToDouble(sumoftotal1);

                //Response.Write("Difference in course fee " + cfeediff + "<br/>");
                splitamtpaidadd1 = splitamtpaidadd + cfeediff;
                //Response.Write("Difference in course fee After adding " + cfeediff + "<br/>");
                updtax = Convert.ToDouble(splitamtpaidadd * (10.3 / 100));
                updinittax = Convert.ToDouble(splitamtpaidadd + updtax);


                _Qry = "update install_amountdetails set initialamount='" + splitamtpaidadd1 + "',initialamout_tax='" + updtax + "',totinitialamt_tax='" + updinittax + "',monthlyinstal='" + splitamtpaidadd1 + "',monthlyinstal_tax='" + updtax + "',totalmonthly_tax='" + updinittax + "'  where student_id='" + lblstudid.Text + "' and instal_number='" + instno + "' and tatamtpaidwithtax IS NULL ";
                //Response.Write("<br>9:" + _Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                FillInstallments();
            }
            FillInstallments();
            //Shuffle

            lblerrmsg.Text = "The Invoice details updated successfully";
            Button3.Visible = false;
            Button2.Visible = true;
           
        }

    }
    #endregion

    #region to Continue to Next Page and check the amount with course fee
    protected void Button2_Click(object sender, EventArgs e)
    {
        //try
        //{
            _Qry1 = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
            if (dt.Rows.Count > 0)
            {
                tax1 = Convert.ToDouble(dt.Rows[0]["tax"].ToString());

            }
            int sumoftotal = 0;
            foreach (GridViewRow grd in GridView1.Rows)
            {
                TextBox updtxt = new TextBox();
                updtxt = ((TextBox)grd.FindControl("txtupdinstal"));

                Label lbl = new Label();
                lbl = (Label)grd.FindControl("hdnlbl");

                Label adjust = new Label();
                adjust = (Label)grd.FindControl("hdnAdjuststatus");

                Label Paidamt = new Label();
                Paidamt = (Label)grd.FindControl("hdnamtpaid");

                if (updtxt.Text == "" || updtxt.Text == null)
                {
                    instalamt = 0;
                }

                else
                {
                    instalamt = Convert.ToDouble(updtxt.Text);
                }

                instal_tax = instalamt * (tax1 / 100);

                totinstal_tax = instalamt + instal_tax;





                if (CheckIsInt(updtxt.Text) != 0)
                {
                    //if (updtxt.Text == adjust.Text)
                    //{
                    //    _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "'),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "'),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='0' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";

                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    //}
                    //else
                    //{
                    //    _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "'),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "'),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "',Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NULL";

                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    //}
                    //if (Paidamt.Text != "" || Paidamt.Text != null)
                    //{
                    //    _Qry = "update install_amountdetails set Adjust_status='1' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "' and tatamtpaidwithtax IS NOT NULL";

                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    //}

                    _Qry = "update install_amountdetails set initialamount=round('" + updtxt.Text + "',0),initialamout_tax='" + instal_tax + "',totinitialamt_tax='" + totinstal_tax + "',monthlyinstal=round('" + updtxt.Text + "',0),monthlyinstal_tax='" + instal_tax + "',totalmonthly_tax='" + totinstal_tax + "' where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    FillInstallments();
                    lblerrmsg.Text = "The Installment Amount has been Updated Successfully";

                }
                else
                {
                    _Qry = "delete from install_amountdetails  where instal_number='" + lbl.Text + "' and student_id='" + Request.QueryString["studid"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    lblerrmsg.Text = "The Installment has been Deleted Successfully";
                    FillInstallments();

                    //new
                    _Qry4 = "select instal_no from invoice_details where student_id ='" + Request.QueryString["studid"] + "'";
                    DataTable dt8 = new DataTable();
                    dt8 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                    if (dt8.Rows.Count > 0)
                    {
                        lblnoofinstal.Text = dt8.Rows[0]["instal_no"].ToString();
                        noofins = Convert.ToInt32(lblnoofinstal.Text);
                    }
                    int noofins1 = noofins - 1;
                    lblnoofinstal.Text = Convert.ToString(noofins1);

                    //updated entered by
                    _Qry2 = "update invoice_details set instal_no='" + lblnoofinstal.Text + "' where student_id ='" + Request.QueryString["studid"] + "' and enteredby='" + Session["SA_Username"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
                }
                if (sumoftotal != 0)
                {
                    if (CheckIsInt(updtxt.Text) != 0)
                    {
                        sumoftotal = sumoftotal + Convert.ToInt32(updtxt.Text);
                    }
                }

                else
                {
                    if (CheckIsInt(updtxt.Text) != 0)
                    {
                        sumoftotal = Convert.ToInt32(updtxt.Text);
                    }
                }

            }
            if (sumoftotal == Convert.ToInt32(lblcoursefee.Text))
            {
                Response.Redirect("InvoiceDetails.aspx?studid=" + Request.QueryString["studid"] + "");
            }
            else if (sumoftotal > Convert.ToInt32(lblcoursefee.Text))
            {
                lblerrmsg.Text = "The amount entered is greater than course fee!!Please click on the Update button";
                Button3.Visible = true;
            }
            else if (sumoftotal < Convert.ToInt32(lblcoursefee.Text))
            {
                lblerrmsg.Text = "The amount entered is lesser than course fee!!Please click on the Update button";
                Button3.Visible = true;
            }
        //}
        //catch (Exception ex)
        //{
        //    lblerrmsg.Text = "Please Contact Admin";
        //}
    }
    #endregion
}
