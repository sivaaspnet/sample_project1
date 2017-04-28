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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class superadmin_Receiptdetails : System.Web.UI.Page
{
    string Qry;
    int countincre,total;
    double balance;
    protected void Page_Load(object sender, EventArgs e)
    {
        summary();
        if (!IsPostBack)
        {
            
            int mm = System.DateTime.Now.Month;
            if (mm == 1)
            {
                ddl_month.SelectedValue = "Jan";
            }
            if (mm == 2)
            {
                ddl_month.SelectedValue = "Feb";
            }
            if (mm == 3)
            {
                ddl_month.SelectedValue = "Mar";
            }
            if (mm == 4)
            {
                ddl_month.SelectedValue = "Apr";
            }
            if (mm == 5)
            {
                ddl_month.SelectedValue = "May";
            }
            if (mm == 6)
            {
                ddl_month.SelectedValue = "Jun";
            }
            if (mm == 7)
            {
                ddl_month.SelectedValue = "Jul";
            }
            if (mm == 8)
            {
                ddl_month.SelectedValue = "Aug";
            }
            if (mm == 9)
            {
                ddl_month.SelectedValue = "Sep";
            }
            if (mm == 10)
            {
                ddl_month.SelectedValue = "Oct";
            }
            if (mm == 11)
            {
                ddl_month.SelectedValue = "Nov";
            }
            if (mm == 12)
            {
                ddl_month.SelectedValue = "Dec";
            }
            
            //Totalcourse_feeonload();
        }
 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Qry = "select count(status) from erp_installAmountDetails where studentid='" + Request.QueryString["studentid"].ToString()  + " ' and status='pending' and centerCode='" + Session["SA_centre_code"] + "'";
        int counta;
        counta = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
        if (counta > 0)
        {
            lbl_errormsg.Text = "You Have pending installments";
        }
        else
        {
            if(balance <=0)
            {
                lbl_errormsg.Text = "Amount Fully Paid";
            }
            else
            {

            Qry = "select count(studentid) from erp_installAmountDetails where studentid='" + Request.QueryString["studentid"].ToString() + "' and centerCode='" + Session["SA_centre_code"] + "'";

            int counta1;
            counta1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
            if (counta1 > 0)
            {

                Qry = "select top 1 installnumber from erp_installAmountDetails where studentid='" + Request.QueryString["studentid"].ToString() + "' and centerCode='" + Session["SA_centre_code"] + "' order by installnumber desc";
                int instnumbercount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
                countincre = instnumbercount + 1;
                //Response.Write(countincre);
                //Response.End();
                Qry = "select inv.studentid,max(coursefees) as coursefee,sum(amount) as Paidamount,max(coursefees)-sum(amount) as balance,max(inv.invoiceid) as invoiceno,max(inv.courseid) as courseid from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.studentid=inv.studentid and rec.centercode=inv.centercode and inv.centercode='" + Session["SA_centre_code"] + "' where inv.studentid='" + Request.QueryString["studentid"].ToString() + "' and inv.centerCode='" + Session["SA_centre_code"] + "'  group by inv.studentid";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(Qry);
                if (dt1.Rows.Count > 0)
                {
                    //TxtCenterCode.Text = dt1.Rows[0]["centercode"].ToString();
                    string invno = dt1.Rows[0]["invoiceno"].ToString();
                    string courseid1 = dt1.Rows[0]["CourseId"].ToString();
                    if (Convert.ToInt64(dt1.Rows[0]["Paidamount"]) > 0)
                    {
                       Qry += " INSERT INTO erp_installAmountDetails (centercode,invoiceno,studentId,installNumber,initialAmount,initialAmountTax,totalInitialAmount,courseId,status,installDate) values('" + Session["SA_centre_code"] + "','" + invno + "','" + Request.QueryString["studentid"].ToString() + "','" + countincre + "','0','0','0','" + courseid1 + "','pending',getdate())";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qry);
                               //try
                                //{
                                   SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.Connection = Conn;
                                    cmd.CommandText = "[spReceiptEdit]";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                   // double taxamount = Convert.ToDouble(txt_initialamt.Text) - Convert.ToDouble(lblamtwithtax.Text);
                                    cmd.Parameters.AddWithValue("centerCode", Session["SA_centre_code"]);
                                    cmd.Parameters.AddWithValue("invoiceNo", Label1.Text);
                                    cmd.Parameters.AddWithValue("totalAmount", total);
                                    cmd.Parameters.AddWithValue("paymentMode", ddl_paymode.SelectedValue);
                                    cmd.Parameters.AddWithValue("bankName", txt_bankname.Text);
                                    cmd.Parameters.AddWithValue("ddNo", txt_ddcc.Text);
                                    cmd.Parameters.AddWithValue("ddDate", dddate.Text);
                                    cmd.Parameters.AddWithValue("paymentTowards", "Installment");
                                    cmd.Parameters.AddWithValue("studentId", Request.QueryString["studentid"]);
                                    cmd.Parameters.AddWithValue("monthInstall", ddl_month.SelectedValue);
                                    cmd.Parameters.AddWithValue("installNo", countincre);
                                    cmd.Parameters.AddWithValue("receiptCutBy", Session["SA_UserID"]);
                                    cmd.Parameters.Add("@receiptNo", SqlDbType.VarChar, 50);
                                    cmd.Parameters["@receiptNo"].Direction = ParameterDirection.Output;
                                    Conn.Open();
                                    cmd.ExecuteNonQuery();
                                    string receiptNo = "";
                                    receiptNo = (string)cmd.Parameters["@receiptNo"].Value;
                                    string studentId = "";
                                    studentId = Request.QueryString["studentid"];
                                    Conn.Close();
                                    if (receiptNo == "E1")
                                    {
                                        lbl_errormsg.Text = "Receipt No Already Exist";
                                    }
                                    else if (receiptNo == "E2")
                                    {
                                        lbl_errormsg.Text = "No course tax in master table";
                                    }
                                    else
                                    {
                                        Response.Redirect("receiptprint.aspx?recptno=" + receiptNo + "&studid=" + studentId);
                                    }
                            
                        // fillgrid();
                        lbl_errormsg.Text = "Installment Added sucessfully";
                        
                    }
                    else
                    {
                        lbl_errormsg.Text = "Already Paid full amount1";
                    }
                    // refersh();
                }
                else
                {
                    lbl_errormsg.Text = "Already Paid full amount";
                }


            }

            else
            {
                lbl_errormsg.Text = "No record Found";
            }
        }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("receiptdetails.aspx");
    }

    private void summary()
    {
        Qry = @"select max(cen.tax) as tax,inv.studentid,max(coursefees) as coursefee,sum(amount) as 
Paidamount,max(coursefees)-sum(amount) as balance,max(inv.invoiceid) 
as invoiceno,max(inv.courseid) as courseid,
((max(coursefees)-sum(amount))*max(cen.tax))/100 as amounttax,
round((((max(coursefees)-sum(amount))*max(cen.tax))/100) + (max(coursefees)-sum(amount)),0) as total from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.studentid=inv.studentid and rec.centercode=inv.centercode and inv.centercode='" + Session["SA_centre_code"] + "'  inner join img_centre_coursefee_details cen on cen.program=inv.courseid and cen.centre_code=inv.centercode and cen.track=inv.track where inv.studentid='" + Request.QueryString["studentid"].ToString() + "' and inv.centerCode='" + Session["SA_centre_code"] + "'  group by inv.studentid";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(Qry);
                if (dt1.Rows.Count > 0)
                {
                    total = Convert.ToInt32(dt1.Rows[0]["total"]);
                    lbl_amt.Text = amts(total);
                    Label2.Text = amts(total);
                    Label1.Text = dt1.Rows[0]["invoiceno"].ToString();
                    balance = Convert.ToDouble(dt1.Rows[0]["balance"]);
                    
                }

    }
    private string amts(int amountvalue)
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
}
