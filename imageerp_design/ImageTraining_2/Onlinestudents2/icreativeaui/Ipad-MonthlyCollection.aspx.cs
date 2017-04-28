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

public partial class superadmin_MonthlyCollection : System.Web.UI.Page
{
    string _Qry;
    DataTable dt = new DataTable();
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
            TextBox1.Text = mon;
            //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            TextBox2.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            //ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
            //fillgrid();
            //Gridview_admission.DataSource = dt;
            //Gridview_admission.DataBind();
            fillddlcutby();
        }
         
         
    }

    private void fillddlcutby()
    {
        string headCentrecode = ConfigurationManager.AppSettings["Ipadcentrecode"].ToString();

        string query = " select userid from img_centrelogin where";
        if (Session["SA_centre_code"].ToString() == headCentrecode)
            {

                query = query + " centre_code in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
            }
            else
            {
                query = query + " centre_code='" + Session["SA_centre_code"] + "'";
            }
            query = query + " and (role='CentreManager' or role='Counselor') ";
        DataTable dtddl = new DataTable();
        dtddl = MVC.DataAccess.ExecuteDataTable(query);

        ddlcutby.DataSource = dtddl;
        ddlcutby.DataValueField = "userid";
        ddlcutby.DataTextField = "userid";
        ddlcutby.DataBind();
        ddlcutby.Items.Insert(0, new ListItem("All", ""));
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
    public void ExprotDatarow(DataRow[] dr)
    {
      
    }
    public void ExportTableData(DataTable dtdata)
    {
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

        Response.Clear();     
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Monthlycollection-of-"+ Session["SA_Location"] +"-center.xls");           
        Response.ContentEncoding = System.Text.Encoding.UTF8;   
        Response.ContentType = "application/ms-excel";   

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write("<b>"+dc.ColumnName + "</b>\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    
    private void fillgrid()
    {
        //try
        //{
        string headCentrecode1 = ConfigurationManager.AppSettings["Ipadcentrecode"].ToString();
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
            _Qry = @"select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as 
amount,cast(rec.receiptNo as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,
isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,
per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby 
from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id 
and rec.status='1' inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and 
inv.centercode=rec.centercode and inv.invoiceid=rec.invoiceno  inner join img_coursedetails 
course on course.course_id=inv.courseId and";
            if (Session["SA_centre_code"].ToString() == headCentrecode1)
            {

                _Qry = _Qry + " rec.centerCode in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode1 + "')";
            }
            else
            {
                _Qry = _Qry + " rec.centerCode='" + Session["SA_centre_code"] + "'";
            }





           // _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,'- ' as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno inner join img_coursedetails course on course.course_id=quick.coursecode and rec.centerCode='" + Session["SA_centre_code"] + "' ";
            if (TextBox1.Text != "" || TextBox2.Text != "")            
            {
                _Qry += "  and rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            
            if (ddlcollectype.SelectedValue == "initial")
            {
                if (ddlcutby.SelectedValue != "")
                {
                    _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                }
                _Qry += " and   rec.installNo='0'";
            }
            _Qry += @" union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0)
as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as 
tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone,course.program,
convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails 
rec on quick.receiptno=rec.receiptno inner join img_coursedetails course on course.course_id=quick.coursecode and ";
            if (Session["SA_centre_code"].ToString() == headCentrecode1)
            {

                _Qry = _Qry + " rec.centerCode in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode1 + "')";
            }
            else
            {
                _Qry = _Qry + " rec.centerCode='" + Session["SA_centre_code"] + "'";
            }
            _Qry = _Qry + " and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
            if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                _Qry += "  and rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
           
            if (ddlcollectype.SelectedValue == "initial")
            {
                if (ddlcutby.SelectedValue != "")
                {
                    _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                }
                _Qry += " and   rec.installNo='0'";
            }
            _Qry += "   order by cast(rec.receiptNo as int)";
            //Response.Write(_Qry);
            //Response.End();
            
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
            collectiongrid.Visible = true;
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();
            
            lblcollectamount.Text = amts(amount); 
            lblcollecttax.Text = amts(tax);
            lblamtpaid.Text = amts(total);
            
        }
    //}
    //catch (Exception ex)
    //{
    //    Response.Write("Pleae Contact Admin");
    //}
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
    protected void ddl_centrcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void downloadlink_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(dt);

        //if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=Imagedoc.xls");
        //    Response.Charset = "";
        //    // If you want the option to open the Excel file without saving than
        //    // comment out the line below
        //    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.xls";
        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    Gridview_admission.RenderControl(htmlWrite);

        //    Response.Write(stringWrite.ToString());
        //    Response.End();
        //}
        //else
        //{
        //    lblmessage.Text = "Please Contact Admin";
        //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void view_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void lnkmonthly_Click(object sender, EventArgs e)
    {
        Response.Redirect("Initialmonthlycollection.aspx");
    }
}
