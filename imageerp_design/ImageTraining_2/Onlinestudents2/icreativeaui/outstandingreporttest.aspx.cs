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
using System.Data.SqlClient;
using System.Globalization;


public partial class superadmin_outstandingreporttest : System.Web.UI.Page
{
    string _Qry; double balanamt = 0; double balantax = 0; double totbalan = 0;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_Master"] == null || Session["SA_Master"] == "")
        {
            Response.Redirect("masterpassword.aspx");
        }
        if (!IsPostBack)
        {

           txtfromdate.Text = String.Format("{0:01-MM-yyyy }", DateTime.Now).Trim();
           txttodate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now).Trim();
            fillgrid();
        }
         
        
    }

    string splitdate(string datevalue)
    {
        string res = "";
        string[] getdateval = datevalue.Split('-');
        res = getdateval[1] + "-" + getdateval[0] + "-" + getdateval[2];
        return res;
    }

    public void ExportTableData(DataTable dtdata)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Balancereport-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            for (int i = 0; i <= dtdata.Columns.Count - 1; i++)
            {
                Response.Write(dtdata.Columns[i].ToString() + "\t");
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i <= dtdata.Columns.Count-1; i++)
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
        DataTable dtname = new DataTable();
        DataTable dtamt = new DataTable();
        DataTable finalDt = new DataTable();
        DataView dvabove3 = new DataView();
        try
        {
            string fromdate = "";
            string todate = "";
            _Qry = @"select per.enq_personal_name as Name,enq_personal_mobile as Phone,course.program,inv.centercode,convert(varchar,inv.dateins,103) as doj,inv.studentid,inv.installno,inv.coursefees,inv.invoiceid,fee.tax,convert(varchar,round(isnull(receipt.amount,0),0),0) as paidamount,round(isnull(receipt.taxamount,0),0) as paidtax,round(isnull(receipt.totalamount,0),0) as paidtotal,receipt.installno,convert(varchar,receipt.dateins,103) as receiptdate  from erp_invoicedetails inv inner join 
img_centre_coursefee_details fee on fee.program=inv.courseid and inv.centercode=fee.centre_code and inv.track=fee.track  and inv.status='active'  and inv.studentstatus='active' and inv.centercode='" + Session["SA_centre_code"] + @"' inner join adm_personalparticulars per on inv.studentid=per.student_id and per.studentstatus!='Dropped' and per.centre_code=inv.centercode and inv.status='active'    and inv.centercode='" + Session["SA_centre_code"] + @"' inner join 
img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=inv.centerCode inner join img_coursedetails course on inv.courseid=course.course_id left join 
erp_receiptDetails receipt on  receipt.studentId=inv.studentId  and inv.invoiceid=receipt.invoiceno  where inv.coursefees>(select sum(amount) from erp_receiptdetails  where studentid=inv.studentId and invoiceno=inv.invoiceId) and inv.status='active'  and inv.studentstatus='active' ";
            if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                fromdate = splitdate(txtfromdate.Text.Trim());
                todate = splitdate(txttodate.Text.Trim());
                _Qry += " and inv.dateins between '" + fromdate + "' and dateadd(d,1,'" + todate + "')";
            }
            if (TextBox1.Text != "")
            {
                _Qry += " and inv.studentid like '%" + TextBox1.Text + "%'";
            }
            dtamt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

            finalDt.Columns.Add(new DataColumn("StudentId", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Program", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Phone", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balanceamount", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balancetax", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("totalbalance", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("invoice", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("coursefees", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("lastreceiptdate", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Totalpaidamount", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("dateofjoin", System.Type.GetType("System.String")));
            DataRow dr = finalDt.NewRow();
            DataTable dt2 = new DataTable();
            string[] args = new string[4];
            args[0] = "studentId";
            args[1] = "invoiceid";
            args[2] = "tax";
            args[3] = "coursefees";

            dt2 = dtamt.DefaultView.ToTable(true, args);
            foreach (DataRow drs in dt2.Rows)
            {
                double balacneAmt = Convert.ToDouble(drs["coursefees"].ToString()) - getBalanceAmt(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'");
                double taxAmt = Math.Round(balacneAmt * (Convert.ToDouble(drs["tax"]) / 100));
                double totalAmt = Math.Round(balacneAmt + taxAmt);
                string[] info = new string[0];
                if (balacneAmt > 0)
                {
                    dr = finalDt.NewRow();
                    dr["StudentId"] = drs["studentid"];
                    dr["dateofjoin"] = getValues(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "doj");
                    dr["Program"] = getValues(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "program");
                    dr["Name"] = getValues(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "Name");
                    dr["Phone"] = getValues(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "Phone");
                    dr["invoice"] = drs["invoiceid"];
                    dr["coursefees"] = drs["coursefees"];
                    dr["lastreceiptdate"] = getinstalldate(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "' ", "receiptdate");
                    dr["balanceamount"] = balacneAmt.ToString();
                    dr["balancetax"] = taxAmt.ToString();
                    dr["totalbalance"] = totalAmt.ToString();
                    dr["Totalpaidamount"] = gettotalpaidamount(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "' ", "paidamount");
                    finalDt.Rows.Add(dr);
                    balanamt += Convert.ToDouble(dr["balanceamount"]);
                    balantax += Convert.ToDouble(dr["balancetax"]);
                    totbalan += Convert.ToDouble(dr["totalbalance"]);
                }
            }
            lblAmount.Text = amts(balanamt);
            lblTax.Text = amts(balantax);
            lbltotalAmt.Text = amts(totbalan);
            dvabove3 = finalDt.DefaultView;
           // Response.Write(dvabove3.Count.ToString() + "<br>");
            string dtthree = DateTime.Now.AddMonths(-3).ToString("dd/MM/yyyy"); ;
        
            if (ddlsearchlastpaid.SelectedValue == "above3")
            {
                string s = String.Format(new CultureInfo("en-us").DateTimeFormat, "lastreceiptdate <= #{0:d}#", dtthree);
                dvabove3.RowFilter = s;// "lastreceiptdate<='" + dtthree + "'";
            }
            else if (ddlsearchlastpaid.SelectedValue == "below3")
            {
                string s = String.Format(new CultureInfo("en-us").DateTimeFormat, "lastreceiptdate >= #{0:d}#", dtthree);
                dvabove3.RowFilter = s;//"lastreceiptdate>='" + dtthree + "'";
            }
            else if (ddlsearchlastpaid.SelectedValue == "equal3")
            {
                string s = String.Format(new CultureInfo("en-us").DateTimeFormat, "lastreceiptdate = #{0:d}#", dtthree);
                dvabove3.RowFilter = s;//"lastreceiptdate='" + dtthree + "'";
            }
            lblcount.Text = dvabove3.Count.ToString()+" Students Found";
            Gridview_admission.DataSource = dvabove3;
            Gridview_admission.DataBind();
            Gridview1.DataSource = dvabove3;
            Gridview1.DataBind();
            foreach (GridViewRow gr in Gridview_admission.Rows)
            {
                HiddenField hdnlastreceiptdate = (HiddenField)gr.FindControl("hdnlastreceiptdate");

             
                int ischeck = 0;
                if (hdnlastreceiptdate.Value != "")
                {


                    string[] date = hdnlastreceiptdate.Value.Split('/');

                    hdnlastreceiptdate.Value = date[1] + '/' + date[0] + '/' + date[2];
                    DateTime lastdate = Convert.ToDateTime(hdnlastreceiptdate.Value);
                   
                    if (lastdate.AddMonths(3) <= DateTime.Now)
                    {
                        ischeck = 1;
                    }
                }
                if (ischeck == 1)
                {
                    foreach (TableCell tc in gr.Cells)
                    {
                        tc.Style.Add("color", "red");
                        tc.Style.Add("border-color", "#000000");
                    }
                }
            }
            LinkButton1.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
            Response.Write("Pleae Contact Admin");
        }
        finally
        {
            dtname = null;
            dtamt = null;
            finalDt = null;
            dvabove3 = null;
        }
    }
    string getValues(DataTable dt, string expression,string column)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            res = dr[0][column].ToString();
        }
        return res;
    }
    
     
    string getinstalldate(DataTable dt, string expression,string column)
    {
        string installdate = "";
        int res = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            res = dr.Length - 1;
            installdate=dr[res][column].ToString();
        }
        return installdate;
    }
    double gettotalpaidamount(DataTable dt, string expression, string column)
    { 
        double paidAmt = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                paidAmt += Convert.ToDouble(val[column].ToString());                 
            }
        }
        return paidAmt;
    }
   
    double  getBalanceAmt(DataTable dt, string expression)
    {
        double res = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            foreach(DataRow val in dr)
            {
                res += Convert.ToDouble(val["paidamount"].ToString());
            }
        }
        return res;
    }
    private string amts(double amountvalue)
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
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }   
   
   
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Balancereport-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Gridview1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void view_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(TextBox1.Text);
    }

}
