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
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;



public partial class MonthlyCollectionMail : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["SA_Centrerole"] == null)
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
        */

        fillgrid();


    }

    /*   private void fillddlcutby()
       {
           string query = " select username from img_centrelogin where centre_code='" + Session["SA_centre_code"] + "' and (role='CentreManager' or role='Counselor') ";
           DataTable dtddl = new DataTable();
           dtddl = MVC.DataAccess.ExecuteDataTable(query);

           ddlcutby.DataSource = dtddl;
           ddlcutby.DataValueField = "username";
           ddlcutby.DataTextField = "username";
           ddlcutby.DataBind();
           ddlcutby.Items.Insert(0, new ListItem("All", ""));
       }*/
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
        Attachment[] attachment = new Attachment[10];
        string startdate = ""; string enddate = "";
        DataTable dt = new DataTable();
        DateTime currentdate = DateTime.Now;
        int day = currentdate.Day;
        string[] centres = { "ICH-102", "ICH-101", "IHY-102", "ICH-103", "ICA-101", "IBG-106", "IBG-101", "ICH-109", "ICH-108", "ICH-106" };//Adyar,alwarpet,ameerpet,annanagar,calicut,indiranagar,jaynagar,perambur,tnagar,velachery
        string[] centrename = { "Adyar", "Alwarpet", "Ameerpet", "Annanagar", "Calicut", "Indiranagar", "Jaynagar", "Perambur", "Tnagar", "Velachery" };
        string month = "";
        if (day < 15)//prev month record
        {

            DateTime firstdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            startdate = firstdate.AddMonths(-1).ToString();//prev month 1st date
            enddate = firstdate.ToString();//current month 1st date
            month = firstdate.AddMonths(-1).ToString("MMMM");
        }
        else if (day >= 15)//current month first 15 days record
        {
            DateTime firstdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            startdate = firstdate.ToString();//current month 1st date
            enddate = firstdate.AddDays(14).ToString();//current month 15th date
            month = currentdate.ToString("MMMM");
        }
        try
        {

            for (int j = 0; j < centres.Length; j++)
            {
                _Qry = "select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as amount,cast(rec.receiptNo as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id and rec.status='1' inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and inv.centercode=rec.centercode and inv.invoiceid=rec.invoiceno  inner join img_coursedetails course on course.course_id=inv.courseId and rec.centerCode='" + centres[j] + "'  ";
                if (startdate != "" || enddate != "")
                {
                    _Qry += "  and  rec.dateIns between ('" + startdate + "') and DATEADD(day,1,'" + enddate + "')";
                }

                _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno and quick.centrecode=rec.centerCode inner join img_coursedetails course on course.course_id=quick.coursecode and rec.centerCode='" + centres[j] + "'  and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
                if (startdate != "" || enddate != "")
                {
                    _Qry += "  and rec.dateIns between ('" + startdate + "') and DATEADD(day,1,'" + enddate + "')";
                }

                _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(fine.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone, '-' as program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_finereceipt fine inner join erp_receiptdetails rec on fine.receiptno=rec.receiptno and fine.centrecode=rec.centerCode  and rec.centerCode='" + Session["SA_centre_code"] + "'  and rec.studentid not in ((select distinct studentid from erp_invoicedetails))";
                if (startdate != "" || enddate != "")
                {
                    _Qry += "  and rec.dateIns between ('" + startdate + "') and DATEADD(day,1,'" + enddate + "')";
                }

                _Qry += "   order by cast(rec.receiptNo as int)";


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
                //lblcollectamount.Text = amts(amount);
                //lblcollecttax.Text = amts(tax);
                //lblamtpaid.Text = amts(total);
                collectiongrid.Visible = true;
                Gridview_admission.DataSource = dt;
                Gridview_admission.DataBind();

                #region create excel
                MemoryStream ms = new MemoryStream();
                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                Gridview_admission.RenderControl(htmlWriter);
                byte[] excelFile = System.Text.Encoding.ASCII.GetBytes(stringWriter.ToString());                  
                ms.Write(excelFile, 0, excelFile.Length);
                string Total = @"<Table><tr><td></td><td></td><td></td><td></td><td><bold>" + amts(amount) + "</bold></td><td><bold>" +amts( tax )+ "</bold></td><td><bold>" +amts( total) + "</bold></td></tr></Table>";
                byte[] totalFile = System.Text.Encoding.ASCII.GetBytes(Total);
                ms.Write(totalFile, 0, totalFile.Length);
                ms.Position = 0;
                attachment[j] = new Attachment(ms, "" + month + "_Month_Collection_Report_of_" + centrename[j] + ".xls", "application/vnd.xls");
                #endregion

            }
            SendMail(attachment, month);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            dt = null;
        }
    }
    private void SendMail(Attachment[] excels, string month)
    {


        MailMessage Mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "mail.image.edu.in";
       // client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        //client.Credentials = new System.Net.NetworkCredential("erp@image.edu.in", "!Mage35ttk");
        client.Credentials = new System.Net.NetworkCredential("info@image.edu.in", "!nf0@32LLkR0@d");
        Mail.From = new MailAddress("imageerp@gmail.com");
        Mail.To.Add("indunak@gmail.com");
        //Mail.To.Add("rmd@imageil.com");
       // Mail.CC.Add("rbi@imageil.com");
        //Mail.Bcc.Add("sumathi@imageil.com");
        Mail.Subject = "" + month + " Month Collection Report";
        Mail.Body = "Monthly collection report ";
        foreach (Attachment excel in excels)
        {
            Mail.Attachments.Add(excel);
        }
        Mail.IsBodyHtml = true;
        client.Send(Mail);
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
           // lblgridamount.Text = "<b>" + lblcollectamount.Text + "</b>";
           // lblgridtax.Text = "<b>" + lblcollecttax.Text + "</b>";
          //  lblgridtotal.Text = "<b>" + lblamtpaid.Text + "</b>";
        }
    }
}
