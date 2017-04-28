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

public partial class superadmin_Insertinvoice : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, coursefee, coursefeetax, totcoursefeetax, instalamt, instalamt_tax, totinstalamt_tax, initialamt,initialamttax,totinitialamt_tax, coursename;
    int instalno;
    string invoiceno, courseID, insdate;
    int instalmentno,instalmentno1;
    double checkcoursefee = 0;
    double totalamount = 0;
    double totalinstallamount = 0;
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            filladdinvoice();
        }
    }
    #endregion


    #region To Fill details in Adding Installments
    private void filladdinvoice()
    {
        try
        {
            _Qry = "select a.centre_code,a.invoice_no,a.student_id,a.course_id,a.course_fees,a.course_tax,a.totalcourse_fees,a.instalment_amount,a.instalamountax,a.totinstalamount_tax,a.initialamount,a.initialamout_tax,a.totinitialamt_tax,a.course_name,b.program from install_amountdetails a inner join img_coursedetails b on a.course_id=b.course_id where a.student_id='" + Request.QueryString["studid"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                courseID = dt.Rows[0]["course_id"].ToString();
                lblcentrecode.Text = dt.Rows[0]["centre_code"].ToString();
                lblinvoiceno.Text = dt.Rows[0]["invoice_no"].ToString();
                lblcourseid.Text = dt.Rows[0]["program"].ToString();
                lblstudentid.Text = dt.Rows[0]["student_id"].ToString();
                coursefee = dt.Rows[0]["course_fees"].ToString();
                coursefeetax = dt.Rows[0]["course_tax"].ToString();
                totcoursefeetax = dt.Rows[0]["totalcourse_fees"].ToString();
                instalamt = dt.Rows[0]["instalment_amount"].ToString();
                instalamt_tax = dt.Rows[0]["instalamountax"].ToString();
                totinstalamt_tax = dt.Rows[0]["totinstalamount_tax"].ToString();
                initialamt = dt.Rows[0]["initialamount"].ToString();
                initialamttax = dt.Rows[0]["initialamout_tax"].ToString();
                totinitialamt_tax = dt.Rows[0]["totinitialamt_tax"].ToString();
                coursename = dt.Rows[0]["course_name"].ToString();

            }
        }
        catch (Exception ex)
        {
            lblerrmsg.Text = "Please Contact Admin";
        }
    }
    #endregion


    #region to redirect to Invoice Edit Page
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Invoiceedit.aspx?studid=" + Request.QueryString["studid"] + "");
    }
    #endregion

    #region check amount
    private void checkamount()
    {
        _Qry2 = "select payment_coursefee from adm_generalinfo where student_id='" + lblstudentid.Text + "'";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
        if (dt2.Rows.Count > 0)
        {
            checkcoursefee = Convert.ToDouble(dt2.Rows[0]["payment_coursefee"].ToString());
        }

        if (ddlnoofinstal.SelectedValue == "" || ddlnoofinstal.SelectedValue == null)
        {

        }
        else
        {
            int Noofinstall = Convert.ToInt32(ddlnoofinstal.SelectedValue.ToString());
            int installamount = Convert.ToInt32(txtinstallmentamt.Text.ToString());
            totalamount = Convert.ToDouble(Noofinstall * installamount);
        }
        _Qry = " Select sum(initialamount) as initailamount from install_amountdetails where student_id='" + lblstudentid.Text + "'";
        DataTable dt20 = new DataTable();
        dt20 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt20.Rows.Count > 0)
        {
            totalinstallamount = Convert.ToDouble(dt20.Rows[0]["initailamount"].ToString());
        }
        //Response.Write("totalinstallamount:" + totalinstallamount);
        ////Response.Write("<br>TotalAmount:" + totalamount);
        //Response.End();
    }
    #endregion

    #region to Add Installments
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            checkamount();
            //double totamt = totalamount + totalinstallamount;
            //Response.Write("Total Amount:" + totamt);
            //Response.End();
            if (checkcoursefee < totalamount)
            {
                lblerrmsg.Text = "Total Instalment amount is greater than course fees !";
            }
            else if (checkcoursefee < (totalamount + totalinstallamount))
            {
                lblerrmsg.Text = "Total Instalment amount is greater than course fees !";
            }
            else
            {
                filladdinvoice();
                _Qry = "SELECT Top 1 instal_number,Invoice_no from install_amountdetails where student_id='" + lblstudentid.Text + "' order by instal_id desc";
                //_Qry = "SELECT instal_no,Invoice_id from invoice_details where student_id='" + lblstudentid.Text + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    instalmentno = Convert.ToInt32(dt.Rows[0]["instal_number"].ToString());

                    //instalmentno = Convert.ToInt32(dt.Rows[0]["instal_no"].ToString());
                    invoiceno = dt.Rows[0]["Invoice_no"].ToString();
                    //invoiceno = dt.Rows[0]["Invoice_id"].ToString();
                }


                _Qry = "select install_date from install_amountdetails where student_id='" + lblstudentid.Text + "' and instal_number='" + instalmentno + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt17 = new DataTable();
                dt17 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt17.Rows.Count > 0)
                {
                    string str1 = dt17.Rows[0]["install_date"].ToString();
                    //Response.Write(str1);
                    //Response.End();
                    string[] strSplitArr = str1.Split(' ');
                    string dob1 = strSplitArr[0].ToString();
                    string[] split1 = dob1.Split('/');
                    insdate = split1[2] + "-" + split1[0] + "-" + split1[1];

                    //insdate = dt17.Rows[0]["install_date"].ToString();
                    //Response.Write(insdate);
                    //Response.End();
                }
                //else
                //{
                //    insdate = System.DateTime.Now.ToString("yyyy/MM/dd");
                //    //Response.Write(insdate);
                //    //Response.End();
                //}
                //instalmentno = instalmentno + 1;
                int noofinstal = Convert.ToInt32(ddlnoofinstal.SelectedValue);
                int j = 1;
                for (int i = 1; i <= noofinstal; i++)
                {

                    if (i == 1)
                    {

                        _Qry1 = "insert into install_amountdetails(centre_code,Invoice_no,student_id,course_id,course_fees,course_tax,totalcourse_fees,instalment_amount,instalamountax,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date,status,course_name,install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax)values('" + lblcentrecode.Text + "','" + lblinvoiceno.Text + "','" + lblstudentid.Text + "','" + courseID + "','" + coursefee + "','" + coursefeetax + "','" + totcoursefeetax + "','" + instalamt + "','" + instalamt_tax + "','" + totinstalamt_tax + "','" + (instalmentno + i) + "','" + txtinstallmentamt.Text + "','" + hdntaxamt.Text + "','" + lbltotinstal_tax.Text + "',getdate(),'pending','" + coursename + "',DATEADD(MONTH," + j + ",'" + insdate + "'),'" + txtinstallmentamt.Text + "','" + hdntaxamt.Text + "','" + lbltotinstal_tax.Text + "')";
                        //Response.Write("Test1:"+_Qry1);
                        //Response.End();
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                    }
                    else
                    {

                        _Qry1 = "insert into install_amountdetails(centre_code,Invoice_no,student_id,course_id,course_fees,course_tax,totalcourse_fees,instalment_amount,instalamountax,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date,status,course_name,install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax)values('" + lblcentrecode.Text + "','" + lblinvoiceno.Text + "','" + lblstudentid.Text + "','" + courseID + "','" + coursefee + "','" + coursefeetax + "','" + totcoursefeetax + "','" + instalamt + "','" + instalamt_tax + "','" + totinstalamt_tax + "','" + (instalmentno + i) + "','" + txtinstallmentamt.Text + "','" + hdntaxamt.Text + "','" + lbltotinstal_tax.Text + "',getdate(),'pending','" + coursename + "',DATEADD(MONTH," + j + ",'" + insdate + "'),'" + txtinstallmentamt.Text + "','" + hdntaxamt.Text + "','" + lbltotinstal_tax.Text + "')";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                        //Response.Write("Test123:"+_Qry1);
                        //Response.End();
                    }
                    j = j + 1;
                }
                _Qry2 = "select instal_no from invoice_details where student_id='" + lblstudentid.Text + "'";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry2);
                if (dt1.Rows.Count > 0)
                {
                    instalno = Convert.ToInt32(dt1.Rows[0]["instal_no"].ToString());
                }
                int instalno1 = instalno + noofinstal;
                _Qry = "update invoice_details set instal_no='" + instalno1 + "' where student_id='" + lblstudentid.Text + "' and Invoice_id='" + invoiceno + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                //_Qry = "update receipt_details set instal_no='" + instalno1 + "' where student_id='" + lblstudentid.Text + "' and Invoice_no='" + invoiceno + "'";
                //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                Response.Redirect("ChangeInvoiceedit.aspx?studid=" + Request.QueryString["studid"] + "");
            }


        }
        catch (Exception ex)
        {
            lblerrmsg.Text = "Please Contact Admin";
        }
        
        }
    #endregion



    #region to calculate the tax
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            double instalamt = Convert.ToDouble(txtinstallmentamt.Text);
            double tax = Convert.ToDouble(txtinstal_tax.Text);
            double instal_tax = instalamt * (tax / 100);
            double totinstal_tax = instalamt + instal_tax;
            lbltotinstal_tax.Text = Convert.ToString(totinstal_tax);
            lblamountpaid.Text = Convert.ToString(totinstal_tax);
            hdntaxamt.Text = Convert.ToString(instal_tax);
        }
        catch (Exception ex)
        {
            lblerrmsg.Text = "Please Contact Admin";
        }
    }
    #endregion
}
