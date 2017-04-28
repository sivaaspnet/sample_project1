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


public partial class superadmin_testregularcollectionreport : System.Web.UI.Page
{
    string _Qry; double balanamt = 0; double balantax = 0; double totbalan = 0;
   

    DataTable finalDt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        //if (Session["SA_Master"] == null || Session["SA_Master"] == "")
        //{
        //    Response.Redirect("masterpassword.aspx");
        //}
        // showdownload();
        if (!IsPostBack)
        {

            ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
            fillgrid();
            //getInstalmentDetails();
        }
         
        
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
        Response.AppendHeader("Content-Disposition", "attachment;filename=Regularcollectionreport-"+ddlmonth.SelectedItem.ToString()+"-"+ddlyear.SelectedValue+"-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            //foreach (DataColumn dc in dtdata.Columns)
            //{
                for (int i = 0; i < dtdata.Columns.Count - 1; i++)
                {
                    Response.Write(dtdata.Columns[i].ToString() + "\t");
                }
                //sep = ";";
           // }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count-1; i++)
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
        try
        {
            _Qry = @"select per.enq_personal_name as Name,enq_personal_mobile as Phone,course.program,inv.studentid,inv.invoiceid,inv.coursefees,convert(varchar,inv.dateins,103) as doj,inv.taxPercentage,ins.installNumber,ins.initialAmount,ins.initialAmountTax,ins.totalInitialAmount from erp_invoicedetails inv inner join erp_installamountdetails ins on ins.invoiceno=inv.invoiceid and inv.centercode=ins.centercode and inv.status='active' and studentstatus='active' inner join adm_personalparticulars per on inv.studentid=per.student_id and per.studentstatus!='Dropped' and per.centre_code=inv.centercode and inv.status='active'    and inv.centercode='" + Session["SA_centre_code"] + @"' inner join 
                    img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=inv.centerCode inner join img_coursedetails course on inv.courseid=course.course_id  where inv.centercode='" + Session["SA_centre_code"] + @"' and month(installDate)<='" + ddlmonth.SelectedValue + "' and year(installDate)<='" + ddlyear.SelectedValue + "'";
            DataTable dtins = new DataTable();
            dtins = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = @"select rec.invoiceno,max(inv.studentid) as studentid,sum(amount) as paidamount  from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.invoiceno=inv.invoiceid and inv.centercode=rec.centercode where inv.centercode='" + Session["SA_centre_code"] + @"' and inv.status='active' and studentstatus='active'  and inv.invoiceid in (select invoiceno from erp_installamountdetails where month(installdate)='" + ddlmonth.SelectedValue + "' and year(installdate)='" + ddlyear.SelectedValue + "') group by rec.invoiceno having max(inv.coursefees)>sum(amount) order by rec.invoiceno";
            DataTable dtrec = new DataTable();
            dtrec = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

            DataTable finalDt = new DataTable();
            finalDt.Columns.Add(new DataColumn("StudentId", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Program", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("dateofjoin", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Phone", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("invoice", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("coursefees", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Totalpaidamount", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balanceamount", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balancetax", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("totalbalance", System.Type.GetType("System.String")));
            DataRow dr = finalDt.NewRow();
            DataTable dt2 = new DataTable();
            string[] args=new string[4];
            args[0] = "studentId";
            args[1] = "invoiceid";
            args[2] = "taxPercentage";
            args[3] = "coursefees";

            dt2 = dtins.DefaultView.ToTable(true, args);
            foreach (DataRow drs in dt2.Rows)
            {
                dr = finalDt.NewRow();
                dr["StudentId"] = drs["studentid"];
                dr["Name"] = getcolumn(dtins, "studentid='"+drs["studentid"]+"' and invoiceid='"+drs["invoiceid"]+"'", "name");
                dr["Program"] = getcolumn(dtins, "studentid='" + drs["studentid"] + "' and invoiceid='" + drs["invoiceid"] + "'", "program");
                dr["dateofjoin"] = getcolumn(dtins, "studentid='" + drs["studentid"] + "' and invoiceid='" + drs["invoiceid"] + "'", "doj");
                dr["Phone"] = getcolumn(dtins, "studentid='" + drs["studentid"] + "' and invoiceid='" + drs["invoiceid"] + "'", "phone");
                dr["invoice"] = drs["invoiceid"];
                dr["coursefees"] = drs["coursefees"];
                dr["Totalpaidamount"] = getcolumn(dtrec, "studentid='" + drs["studentid"] + "' and invoiceno='" + drs["invoiceid"] + "'", "paidamount");
                dr["balanceamount"] = getbalancefeesamount(dtins, "studentid='" + drs["studentid"] + "' and invoiceid='" + drs["invoiceid"] + "' ", "initialAmount", Convert.ToDouble(dr["Totalpaidamount"]));
                dr["balancetax"] = "";
                dr["totalbalance"] = "";
                if (Convert.ToDouble(dr["coursefees"].ToString()) <= Convert.ToDouble(dr["Totalpaidamount"].ToString()))
                {
                    finalDt.Rows.Clear();
                }
                else
                {
                    finalDt.Rows.Add(dr);
                }
            }
            Gridview_admission.DataSource = finalDt;
            Gridview_admission.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
            //Response.Write("Pleae Contact Admin");
        }
    }

    string getcolumn(DataTable dt, string expression, string column)
    {
        string res = "0"; 
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
           res = dr[0][column].ToString();
        }
        return res;
    }

    string getbalancefeesamount(DataTable dt, string expression, string column, double paidamount)
    {
        string res = "";
        double installamounts = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                installamounts += Convert.ToDouble(val[column].ToString());
            }
        }
        double balance = installamounts - paidamount;
        if (balance > 0)
        {
            res = balance.ToString();
        }
        else
        {
            res = "0";
        }
        return res;
    }

   string getstatus(string val,string install,string inv)
   {
       string res = "";
       _Qry = "select totalamount  from erp_receiptdetails  where  studentid='" + val + "' and installNo='" + install + "' and invoiceNo='"+inv+"'";
       DataTable dt2 = new DataTable();
       dt2 = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);
       if (dt2.Rows.Count > 0)
       {
           res = dt2.Rows[0]["totalamount"].ToString();

       }
       else
       {
           res = "-----";
       }
       return res;
   }
   string getstatus1(string val, string install, string inv)
   {
       string res = "";
       _Qry = "select convert(varchar,dateIns,103)as paiddate  from erp_receiptdetails  where  studentid='" + val + "' and installNo='" + install + "' and invoiceNo='" + inv + "'";
       DataTable dt2 = new DataTable();
       dt2 = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);
       if (dt2.Rows.Count > 0)
       {
           res = dt2.Rows[0]["paiddate"].ToString();

       }
       else
       {
           res = "-----";
       }
       return res;
   }
   
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }   
   
   
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(finalDt);
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
}
