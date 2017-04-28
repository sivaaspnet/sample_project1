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
    string manual;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

            fillreceipt();

        }
     
    }

    private void fillreceipt()
    {
        _Qry = "select manual_code from old_student_manual where center_code='" + Session["SA_centre_code"] + "'";
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt4.Rows.Count > 0)
        {
            manual = dt4.Rows[0]["manual_code"].ToString();

        }
        else
        {
            manual = Session["SA_centre_code"].ToString();
        }
        _Qry = @"select round (amount,0)as fees,round(tax_amt,0)as tax ,round(total_amt,0)as total     ,* ,convert (varchar,date,103) as date1 from 
oldreceipt_details  a inner join img_coursedetails on 
course_id=course_code where student_id='" + Request.QueryString["student_id"] + "' and center_code='" + manual + "' and rec_no='" + Request.QueryString["rec_no"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if(dt.Rows.Count>0)
        {
            lbl_recpno.Text = dt.Rows[0]["rec_no"].ToString();
            lbl_date.Text = dt.Rows[0]["date1"].ToString();
            lbl_coursecode.Text = dt.Rows[0]["program"].ToString();
            lbl_studname.Text = dt.Rows[0]["student_name"].ToString();
            lbl_sum.Text = dt.Rows[0]["total"].ToString();
            lbl_inwords.Text = dt.Rows[0]["payment_words"].ToString();
            lbl_monthinstallment.Text = dt.Rows[0]["month_instal"].ToString();
            lbl_fees.Text = dt.Rows[0]["amount"].ToString();
            lbl_tax.Text = dt.Rows[0]["tax"].ToString();
            lbl_total.Text = dt.Rows[0]["total"].ToString();
            lblstudentid.Text = dt.Rows[0]["student_id"].ToString();

        }
       


    }
 

}
