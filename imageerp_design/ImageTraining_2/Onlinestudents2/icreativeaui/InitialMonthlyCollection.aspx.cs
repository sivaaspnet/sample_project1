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
using System.IO;
using System.Text;

public partial class superadmin_InitialMonthlyCollection : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
        //showdownload();
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            //string yea = string.Format("{0:yyyy}", DateTime.Now).Trim();
            TextBox1.Text =mon;
           //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            TextBox2.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            //ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
           fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            //viewby_admin.Visible = true;//row id
            //ddl_centrcode
            if (!IsPostBack)
            {
                
            }
        }
        else
        {
            viewby_admin.Visible = false;
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

    private void fillgrid()
    {
        try
        {
        if (Session["SA_centre_code"].ToString() == "0" || Session["SA_centre_code"].ToString() == "" || Session["SA_centre_code"].ToString() == null)
        {
            lblmessage.Text = "Please select the center";
        }
        else
        {
            string str = TextBox1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[1] + "-" + split[0] + "-" + split[2];

            string str1 = TextBox2.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[1] + "-" + split1[0] + "-" + split1[2];
            _Qry = "select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as amount,rec.receiptNo as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and inv.centercode=rec.centercode and inv.status='active' inner join img_coursedetails course on course.course_id=inv.courseId and rec.centerCode='" + Session["SA_centre_code"] + "' and rec.installNo='0' ";
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
            }
            else
            {
                _Qry += " where rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            
            //_Qry = "select  student_id,student_name,receipt_no,course_code,isnull(breakfees,0) as amount, 0  as tax,isnull(breakfees,0) as Total,date_ins from receipt_breakfee where date_ins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centre_code='" + Session["SA_centre_code"] + "'  union all ";
            //_Qry += " select  rec.student_id,rec.student_name,rec.receipt_no,rec.course_code,isnull(ins.totalamtpaid,0) as amount,isnull(cast(totamtpaid_tax as numeric),0) as tax,isnull(ins.tatamtpaidwithtax,0) as total,dateins from Receipt_Details rec inner join install_amountdetails ins on ins.student_id=rec.student_id and ins.receipt_no=rec.receipt_no where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and rec.centre_code='" + Session["SA_centre_code"] + "'   ";
            // _Qry += " union all select student_id,student_name,rec_no as receipt_no,course_code,isnull(amount,0) as amount,isnull(tax_amt,0) as tax,isnull(total_amt,0) as total,date as dateins from oldreceipt_details rec inner join old_student_manual man on man.manual_code=rec.center_code where date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and man.center_code='" + Session["SA_centre_code"] + "'";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            int amount = 0;
            int tax = 0;
            int total = 0;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                amount = amount + Convert.ToInt32(dt.Rows[i]["amount"]);
                tax = tax + Convert.ToInt32(dt.Rows[i]["tax"]);
                total = total + Convert.ToInt32(dt.Rows[i]["total"]);
            }
            
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();

            lblcollectamount.Text = amts(amount); 
            lblcollecttax.Text = amts(tax);
            lblamtpaid.Text = amts(total);
            
        }
    }
    catch (Exception ex)
    {
        Response.Write("Pleae Contact Admin");
    }
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Gridview_admission.PageIndex = e.NewPageIndex;
        //fillgrid();
    }
    protected void ddl_centrcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void downloadlink_Click(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Imagedoc.xls");
            Response.Charset = "";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Gridview_admission.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.End();
        }
        else
        {
            lblmessage.Text = "Please Contact Admin";
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void view_Click(object sender, EventArgs e)
    {
        //fillgrid();
    }
    protected void lnkmonthly_Click(object sender, EventArgs e)
    {
        Response.Redirect("Monthlycollection.aspx");
    }
}
