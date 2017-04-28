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

public partial class superadmin_balancereport : System.Web.UI.Page
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

            ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();            
            fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            //viewby_admin.Visible = true;//row id
            //ddl_centrcodes
            if (!IsPostBack)
            {
                
            }
        }
        else
        {
            viewby_admin.Visible = false;
        }
    }
    
   
   private void fillgrid()
    {
        try
        {
            _Qry = " select i.course_name,instal_number,round((cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end),0) as Amount,round((cast(totalmonthly_tax as float)-case isnull(tatamtpaidwithtax,'') when '' then 0 else tatamtpaidwithtax end),0)-round((cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end),0) as tax,round((cast(totalmonthly_tax as float)-case isnull(tatamtpaidwithtax,'') when '' then 0 else tatamtpaidwithtax end),0) as Total,convert(varchar,i.install_date,103)as Duedate,(p.enq_personal_name+' ' +p.student_lastname) as Name, p.student_id,i.centre_code, monthlyinstal,monthlyinstal_tax,totalmonthly_tax,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax,p.present_phone   from install_amountdetails i inner join adm_personalparticulars p on p.student_id=i.student_id and(cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end)>0 where instal_number>0 ";

            if (ddlmonth.SelectedValue == "" && ddlyear.SelectedValue == "")
            {

            }
            else
            {
                _Qry += " and year(install_date)='" + ddlyear.SelectedValue + "' and month(install_date)='" + ddlmonth.SelectedValue + "'";
            }
            if (Session["SA_Centrerole"] .ToString() == "CentreManager")
            {
                _Qry += "  and i.centre_code='" + Session["SA_centre_code"].ToString() + "'";
            }
            else if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
            {
            }
            else
            {
                _Qry = "";
            }
            //Response.Write(_Qry);
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();
            LinkButton1.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("Pleae Contact Admin");
        }
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        try
        {
            _Qry = " select i.course_name,instal_number,round((cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end),0) as Amount,round((cast(totalmonthly_tax as float)-case isnull(tatamtpaidwithtax,'') when '' then 0 else tatamtpaidwithtax end),0)-round((cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end),0) as tax,round((cast(totalmonthly_tax as float)-case isnull(tatamtpaidwithtax,'') when '' then 0 else tatamtpaidwithtax end),0) as Total,convert(varchar,i.install_date,103)as Duedate,(p.enq_personal_name+' ' +p.student_lastname) as Name, p.student_id,i.centre_code, monthlyinstal,monthlyinstal_tax,totalmonthly_tax,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax,p.present_phone   from install_amountdetails i inner join adm_personalparticulars p on p.student_id=i.student_id and(cast(monthlyinstal as int)-case isnull(totalamtpaid,'') when '' then 0 else totalamtpaid end)>0 where instal_number>0   ";
            if (Session["SA_Centrerole"] .ToString() == "CentreManager")
            {
                _Qry += "  and i.centre_code='" + Session["SA_centre_code"].ToString() + "'";
            }
            else
            {
            }
            if (txtfromcalender1.Text == "" || txttocalender1.Text == "")
            {
            }
            else
            {
                ddlyear.SelectedValue = "";
                ddlmonth.SelectedValue = "";
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];


                _Qry += " and i.install_date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            //Response.Write(_Qry);
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();
            LinkButton1.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("Pleae Contact Admin");
        }
       
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
    protected void view_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Gridview_admission_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
