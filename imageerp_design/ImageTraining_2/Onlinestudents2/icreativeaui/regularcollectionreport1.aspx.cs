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


public partial class superadmin_outstandingreport1 : System.Web.UI.Page
{
    string _Qry; double balanamt = 0; double balantax = 0; double totbalan = 0;
   

    DataTable finalDt = new DataTable();
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
        DateTime today = new DateTime(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue), 1);
        DateTime lastdate = today.AddMonths(1).AddDays(-1);
        string lastday = lastdate.ToShortDateString();
        _Qry = @"select 
sum(round(initialAmount,0)) as initialAmount,
sum(round(initialAmountTax,0)) as initialAmountTax,
sum(round(totalInitialAmount,0)) as totalInitialAmount
from erp_installamountdetails ins inner join 
img_coursedetails img on img.course_id=ins.courseId 
inner join adm_personalparticulars adm on adm.student_id=
ins.studentId and adm.centre_code=ins.centerCode where adm.studentstatus='active' and datepart(month,installdate)='" + ddlmonth.SelectedValue + "' and centerCode='" + Session["SA_centre_code"].ToString() + "' and datepart(year,installdate)='" + ddlyear.SelectedValue + "' ";

        if (ddl_status.SelectedValue != "")
        {
            _Qry += " and ins.status='" + ddl_status.SelectedValue + "'";
        }

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

        if (dt.Rows.Count > 0)
        {
            lblAmount.Text = amts(Convert.ToDouble(dt.Rows[0]["initialAmount"]));
            lblTax.Text = amts(Convert.ToDouble(dt.Rows[0]["initialAmountTax"]));
            lbltotalAmt.Text = amts(Convert.ToDouble(dt.Rows[0]["totalInitialAmount"]));
        }
       int initialamnt=0;int initialamnttax=0;int totalinitialamnt=0;
       int initialamnt_ind=0;int initialamnttax_ind=0;int totalinitialamnt_ind=0;
        try
        {

            _Qry = @"select ins.installNumber,adm.studentstatus,enq.enq_personal_mobile,ins.invoiceno,adm.enq_personal_name,studentId,initialAmount,initialAmountTax,totalInitialAmount,ins.status,convert(varchar,installdate,103)as installdate,program from erp_installamountdetails ins inner join img_coursedetails img on img.course_id=ins.courseId inner join adm_personalparticulars adm on adm.student_id=ins.studentId and adm.centre_code=ins.centerCode   inner join img_enquiryform enq on enq.enq_number=adm.enq_number  where  datepart(month,installdate)='" + ddlmonth.SelectedValue + "' and centerCode='" + Session["SA_centre_code"].ToString() + "' and datepart(year,installdate)='" + ddlyear.SelectedValue + "' and adm.studentstatus='active'";
            if (ddl_status.SelectedValue != "")
            {
                _Qry += " and ins.status='" + ddl_status.SelectedValue + "'";
            }
            
            
            finalDt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

           Gridview_admission.DataSource = finalDt;
            Gridview_admission.DataBind();

            _Qry = @"select ins.centerCode,ins.invoiceno,ins.studentid,ins.installnumber,isnull(cast(ins.initialAmount as numeric),0) as initialAmount,isnull(cast(ins.initialamounttax as numeric),0) as initialamounttax,isnull(cast(ins.totalinitialamount as numeric),0) as totalinitialamount,ins.courseid,
                 month(ins.installdate) as installmonth,year(ins.installdate) as installyear ,ins.status 
             from erp_installamountdetails ins inner join img_coursedetails img on img.course_id=ins.courseId inner join adm_personalparticulars adm on 
           adm.student_id=ins.studentId and adm.centre_code=ins.centerCode   inner join img_enquiryform enq on enq.enq_number=adm.enq_number
               where ins.installdate<='"+lastdate+"' and ins.status='Pending' and adm.studentstatus='active' and ins.centerCode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable dtpending = MVC.DataAccess.ExecuteDataTable(_Qry);

            foreach (GridViewRow dvr in Gridview_admission.Rows)
            {
                HiddenField hdn = new HiddenField();
                HiddenField hdn1 = new HiddenField();
                HiddenField hdn2 = new HiddenField();
                Label lbl = new Label();
                Label lbl1 = new Label();
                hdn = (HiddenField)dvr.FindControl("hdn1");
                hdn1 = (HiddenField)dvr.FindControl("hdn2");
                hdn2 = (HiddenField)dvr.FindControl("hdn3");
                lbl = (Label)dvr.FindControl("paid");
                lbl1 = (Label)dvr.FindControl("paidDate");
                lbl.Text = getstatus(hdn.Value.ToString(), hdn1.Value.ToString(),hdn2.Value.ToString());
                lbl1.Text = getstatus1(hdn.Value.ToString(), hdn1.Value.ToString(), hdn2.Value.ToString());
                string status = ((Label)dvr.FindControl("lblstatus") as Label).Text;
                Label lblinitial = (Label)dvr.FindControl("lblinitial") as Label;
                Label lblinitialtax = (Label)dvr.FindControl("lblinitialtax") as Label;
                Label lbltotalinitial = (Label)dvr.FindControl("lbltotalinitial") as Label;
                if (status.ToLower() == "pending")
                {
                    initialamnt_ind = Convert.ToInt32(dtpending.Compute("sum(initialAmount)", "studentid='"+hdn.Value+"' and invoiceno='"+hdn2.Value+"'"));
                    initialamnttax_ind = Convert.ToInt32(dtpending.Compute("sum(initialamounttax)", "studentid='" + hdn.Value + "' and invoiceno='" + hdn2.Value + "'"));
                    totalinitialamnt_ind = Convert.ToInt32(dtpending.Compute("sum(totalinitialamount)", "studentid='" + hdn.Value + "' and invoiceno='" + hdn2.Value + "'"));
                    lblinitial.Text = initialamnt_ind.ToString();
                    lblinitialtax.Text = initialamnttax_ind.ToString();
                    lbltotalinitial.Text = totalinitialamnt_ind.ToString();

                }                
                    initialamnt = initialamnt +Convert.ToInt32(lblinitial.Text);
                    initialamnttax = initialamnttax + Convert.ToInt32(lblinitialtax.Text);
                    totalinitialamnt = totalinitialamnt + Convert.ToInt32(lbltotalinitial.Text);                

            }
            lblAmount.Text += amts(initialamnt);
            lblTax.Text += amts(initialamnttax);
            lbltotalAmt.Text += amts(totalinitialamnt);
            LinkButton1.Visible = true;

            

           
        }
        catch (Exception ex)
        {
           // Response.Write(ex.Message.ToString());
            //Response.Write("Pleae Contact Admin");
        }
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
