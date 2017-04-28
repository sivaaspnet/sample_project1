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

public partial class superadmin_balancereport_old : System.Web.UI.Page
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
            //ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
            //ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            //Response.Write(String.Format("{0:MM}", DateTime.Now));
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
            //viewby_admin.Visible = false;
        }
    }
   
   private void fillgrid()
    {
        try
        {
       // _Qry = "select enq.enquiry_no,man.center_code,convert(varchar,old.install_date,103) as Date,enq.enq_name,old.student_id,old.course_id,round(old.course_fees,0) as Totalfee,old.receipt_no,old.invoice_no,round(old.install_amount,0) as Amount,round(old.install_amount_tax,0) as Tax,round(old.total_install_amount,0) as Total,old.install_number,old.status from oldenquiry_details enq inner join oldenrolled_details enr on enq.enquiry_no=enr.enquiry_no inner join old_install_amountdetails old on old.student_id=enr.student_id inner join old_student_manual man on man.manual_code=enq.center_code where old.status='pending'";
        _Qry = "select * from (select inv.student_id,max(total_amount)as fees,max(student_name) as name,max(course_code) as course,max(man.center_code) as center, sum(amount)as paidamt,max(total_amount)-sum(amount) as balance from OldReceipt_Details as receipt inner join OldInvoice_Details as inv on inv.student_id=receipt.student_id inner join old_student_manual man on man.manual_code=receipt.center_code group by inv.student_id ) as sss where balance>0 ";
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {
            _Qry += "  and center='" + Session["SA_centre_code"].ToString() + "'";
        }

        _Qry += " order by student_id ";
       
           // Response.Write(_Qry);
            //Response.End();
            // _Qry = _Qry + " Order by a.Admission_id desc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();
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
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
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
}
