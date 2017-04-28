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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        if (Session["SA_Master"] == null)
        {
            Response.Redirect("masterpassword.aspx");
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
        string query = " select username from img_centrelogin where centre_code='" + Session["SA_centre_code"] + "' and (role='CentreManager' or role='Counselor') ";
        DataTable dtddl = new DataTable();
        dtddl = MVC.DataAccess.ExecuteDataTable(query);

        ddlcutby.DataSource = dtddl;
        ddlcutby.DataValueField = "username";
        ddlcutby.DataTextField = "username";
        ddlcutby.DataBind();
        ddlcutby.Items.Insert(0, new ListItem("All", ""));
    }
    private string amts(int amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = amountvalue.ToString("#,000");
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
        DataTable dt = new DataTable();
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
                _Qry = "select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as amount,cast(rec.receiptNo as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id and rec.status='1' inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and inv.centercode=rec.centercode and inv.invoiceid=rec.invoiceno  inner join img_coursedetails course on course.course_id=inv.courseId and rec.centerCode='" + Session["SA_centre_code"] + "'  ";
                // _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,'- ' as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno inner join img_coursedetails course on course.course_id=quick.coursecode and rec.centerCode='" + Session["SA_centre_code"] + "' ";
                if (TextBox1.Text != "" || TextBox2.Text != "")
                {
                    _Qry += "  and  rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
                }

                if (ddlcollectype.SelectedValue == "Paid-Initial-Alone")
                {
                    if (ddlcutby.SelectedValue != "")
                    {
                        _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                    }
                    _Qry += " and   rec.installNo='0' and rec.studentId in(select studentid from erp_installamountdetails where installnumber=1 and status='pending' and centerCode='" + Session["SA_centre_code"] + "') ";
                }

                if (ddlcollectype.SelectedValue == "Regular-Fees")
                {
                    if (ddlcutby.SelectedValue != "")
                    {
                        _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                    }
                    _Qry += @" and  paymentTowards !='Breakage(Fine/Miscellaneous)' and  ((rec.installNo !='0' and month(inv.dateins)!=month(rec.dateins)) or course.year='2') ";
                    //_Qry += " and   rec.installNo !='0' ";
                }
                if (ddlcollectype.SelectedValue == "Quick")
                {
                    if (ddlcutby.SelectedValue != "")
                    {
                        _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                    }
                    _Qry += " and   rec.studentId like '%Quick%'";
                }

                if (ddlcollectype.SelectedValue == "Fresh")
                {
                    if (ddlcutby.SelectedValue != "")
                    {
                        _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                    }
                    _Qry += " and    paymentTowards !='Breakage(Fine/Miscellaneous)' and  ((rec.installNo='0' or month(inv.dateins)=month(rec.dateins)) and course.year='1' ) ";
                   // _Qry += " and   rec.installNo='0' ";
                }

                if (ddlcollectype.SelectedValue == "Others")
                {
                    if (ddlcutby.SelectedValue != "")
                    {
                        _Qry += " and rec.receiptcutby='" + ddlcutby.SelectedValue + "'";
                    }
                    _Qry += " and  paymentTowards ='Breakage(Fine/Miscellaneous)'";
                    _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(fine.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone, '-' as program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_finereceipt fine inner join erp_receiptdetails rec on fine.receiptno=rec.receiptno and fine.centrecode=rec.centerCode  and rec.centerCode='" + Session["SA_centre_code"] + "'  and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
                    // _Qry += " and   rec.installNo='0' ";
                }
                if (ddlcollectype.SelectedValue != "Others" && ddlcollectype.SelectedValue != "Regular-Fees" && ddlcollectype.SelectedValue != "Fresh" && ddlcollectype.SelectedValue != "Paid-Initial-Alone")
                {

                    _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno and quick.centrecode=rec.centerCode inner join img_coursedetails course on course.course_id=quick.coursecode and rec.centerCode='" + Session["SA_centre_code"] + "'  and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
                    if (TextBox1.Text != "" || TextBox2.Text != "")
                    {
                        _Qry += "  and rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
                    }
                }
                if (ddlcollectype.SelectedValue == "all")
                {
                    _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(fine.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone, '-' as program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_finereceipt fine inner join erp_receiptdetails rec on fine.receiptno=rec.receiptno and fine.centrecode=rec.centerCode  and rec.centerCode='" + Session["SA_centre_code"] + "'  and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
                }
                if (TextBox1.Text != "" || TextBox2.Text != "")
                {
                    _Qry += "  and rec.dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
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
                lblcollectamount.Text = amts(amount);
                lblcollecttax.Text = amts(tax);
                lblamtpaid.Text = amts(total);
                collectiongrid.Visible = true;
                //Cache["monthlycollection"] = (DataTable)dt;
                //Gridview_admission.DataSource = (DataTable)Cache["monthlycollection"];
                //Gridview_admission.DataBind();
                //GridView1.DataSource = (DataTable)Cache["monthlycollection"];
                //GridView1.DataBind();

                Gridview_admission.DataSource = dt;
                Gridview_admission.DataBind();
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }
        catch (Exception ex)
        {
            Response.Write("Pleae Contact Admin");
        }
        finally
        {
            dt = null;
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
    protected void ddl_centrcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void downloadlink_Click(object sender, EventArgs e)
    {
        //fillgrid();
        //ExportTableData(dt);

        //if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Monthlycollection-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblgridamount = (Label)e.Row.FindControl("lblgridamount");
            Label lblgridtax = (Label)e.Row.FindControl("lblgridtax");
            Label lblgridtotal = (Label)e.Row.FindControl("lblgridtotal");
           lblgridamount.Text= "<b>"+lblcollectamount.Text+"</b>";
           lblgridtax.Text = "<b>" + lblcollecttax.Text + "</b>";
           lblgridtotal.Text = "<b>" + lblamtpaid.Text + "</b>";
        }
    }
}
