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

public partial class superadmin_InvoiceMenu : System.Web.UI.Page
{
    string _Qry,student_id;
    int Invoice_no = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Request.QueryString["Stud_Id"] == "" || Request.QueryString["Stud_Id"] == null)
        {

        }
        else
        {
            txt_stuid.Text = Request.QueryString["Stud_Id"].ToString();
        }

    }
    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=%]+$");
        e.IsValid = rx.IsMatch(txt_stuid.Text);
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = @"select distinct student_id,enq_personal_name from adm_personalparticulars where student_id='" + txt_stuid.Text + "' and centre_code='" + Session["SA_centre_code"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = @"select count(*) as cnt  from erp_receiptdetails where studentid='" + txt_stuid.Text + "' and centercode='" + Session["SA_centre_code"] + "' and substring(paymentTowards,1,8)='Breakage'";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                int cnt = Convert.ToInt32(dt1.Rows[0]["cnt"].ToString());
                //Response.Write(cnt.ToString());
                if (3 > cnt)
                {
                    Response.Redirect("Breakagereceipt.aspx?studid=" + txt_stuid.Text + "");
                }
                else
                {
                    lbl_errormsg.Text = "You Can Pay Breakage Only Three Times.";
                }
            }
            else
            {
                lbl_errormsg.Text = "No Records Available";
            }
            //_Qry = "select Invoice_No from install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And centre_code='" + Session["SA_centre_code"] + "'";
            //SqlDataReader dr123;
            //dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            //if (dr123.HasRows)
            //{
            //    dr123.Read();

            //    Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

            //    dr123.Close();
            //}
            //if (Invoice_no > 493)
            //{

            //    _Qry = "select student_id from adm_generalinfo where centre_code='" + Session["SA_centre_code"] + "' and student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
            //    //Response.Write(_Qry);
            //    //Response.End();
            //    DataTable dt = new DataTable();
            //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);


            //    if (dt.Rows.Count > 0)
            //    {
            //        if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
            //        {
            //            student_id = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
            //            //Response.Redirect("Invoiceedit.aspx?studid=" + student_id + "");
            //            Response.Redirect("Breakagereceipt.aspx?studid=" + student_id + "");
            //        }

            //    }
            //    else
            //    {
            //        lbl_errormsg.Text = "No Records Found";
            //    }

            //}
            //else
            //{
            //    int CENTER_CODE = 0;

            //    if (Session["SA_centre_code"].ToString() == "ICH-106")
            //    {
            //        CENTER_CODE = 6;
            //    }
            //    if (Session["SA_centre_code"].ToString() == "ICH-103")
            //    {
            //        CENTER_CODE = 3;
            //    }
            //    if (Session["SA_centre_code"].ToString() == "ICH-101")
            //    {
            //        CENTER_CODE = 1;
            //    }
            //    if (Session["SA_centre_code"].ToString() == "ICH-102")
            //    {
            //        CENTER_CODE = 2;
            //    }
            //    _Qry = "select student_id from OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And center_Code='" + CENTER_CODE + "'";
            //    //Response.Write(_Qry);
            //    //Response.End();
            //    DataTable dt = new DataTable();
            //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);


            //    if (dt.Rows.Count > 0)
            //    {
            //        //if (Regex.Replace(txt_stuid.Text,"^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
            //        //{
            //            student_id = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
            //            //Response.Redirect("Invoiceedit.aspx?studid=" + student_id + "");
            //            Response.Redirect("Breakagereceipt.aspx?studid=" + student_id + "");
            //        //}

            //    }
            //    else
            //    {
            //        lbl_errormsg.Text = "No Records Found";
            //    }
            //}

        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("InvoiceMenu.aspx");
        //}
    }
}
