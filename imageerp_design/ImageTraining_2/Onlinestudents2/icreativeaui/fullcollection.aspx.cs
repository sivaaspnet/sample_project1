
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
using System.Web.Mail;

public partial class ImageTraining_2_Onlinestudents2_superadmin_fullCollection : System.Web.UI.Page
{
    string _Qry,qry;
    string result = "";
    string initialresult = "";
    DataTable dt = new DataTable();
    DataTable dtinitial = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            fillgrid();


        }


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
    public void ExprotDatarow(DataRow[] dr)
    {

    }

    private void fillgrid()
    {
        _Qry = "select count(*) from erp_collectionsenddate where maildate<=datediff(d,7,getdate()) and status='1' ";
        int count = 0;
        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (count > 0)
        {

            _Qry = "select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as amount,cast(rec.receiptNo as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id and rec.status='1' inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and inv.centercode=rec.centercode and inv.status='active' inner join img_coursedetails course on course.course_id=inv.courseId where rec.dateins between datediff(d,6,getdate()) and getdate() ";
            _Qry += " union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno inner join img_coursedetails course on course.course_id=quick.coursecode    and rec.studentid not in ((select distinct studentid from erp_invoicedetails)) where rec.dateins between datediff(d,6,getdate()) and getdate() ";
            _Qry += "  order by rec.centercode,cast(rec.receiptNo as int) ";
            //Response.Write(_Qry+"<br>");
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            qry = "select rec.centerCode,rec.studentId as  student_id,isnull(cast(rec.amount AS numeric),0) as amount,cast(rec.receiptNo as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,per.enq_personal_name as student_name,per.present_phone,course.program,convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_receiptdetails rec inner join adm_personalparticulars per on rec.studentId=per.student_id and rec.status='1' inner join erp_invoiceDetails inv on rec.studentId=inv.studentId and inv.centercode=rec.centercode and inv.status='active' and   rec.installNo='0'  inner join img_coursedetails course on course.course_id=inv.courseId where rec.dateins between datediff(d,6,getdate()) and getdate()  union all select rec.centercode,rec.studentid as  student_id ,isnull(cast(rec.amount AS numeric),0) as amount,cast(quick.receiptno as int) as receipt_no,isnull(cast(rec.taxAmount as numeric),0) as tax,isnull(cast(rec.totalAmount as numeric),0) as total,studentname as student_name,'- ' as present_phone,course.program, convert(varchar,rec.dateIns,103) as date_ins,rec.receiptcutby from erp_quickreceipt quick inner join erp_receiptdetails rec on quick.receiptno=rec.receiptno inner join img_coursedetails course on course.course_id=quick.coursecode    and rec.studentid not in ((select distinct studentid from erp_invoicedetails)) where rec.dateins between datediff(d,6,getdate()) and getdate()  order by rec.centercode,cast(rec.receiptNo as int) ";
            dtinitial = MVC.DataAccess.ExecuteDataTable(qry);
            //Response.Write(qry);
           // Response.End();
            ArrayList centreDetails = new ArrayList();
            ArrayList centreName = new ArrayList();
            //string qry = "select distinct centercode from erp_receiptdetails";
            //DataTable dtcentre = new DataTable();
            //dtcentre = MVC.DataAccess.ExecuteDataTable(qry);
            //if (dtcentre.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtcentre.Rows.Count; i++)
            //    {
            //        centreDetails.Add(dtcentre.Rows[i]["centercode"].ToString());
            //    }

            //}
            centreDetails.Add("ICH-101");
            centreName.Add("Alwarpet");

            centreDetails.Add("ICH-102");
            centreName.Add("Adyar");


            centreDetails.Add("ICH-103");
            centreName.Add("Annanagar");


            centreDetails.Add("ICH-106");
            centreName.Add("Velachery");

            centreDetails.Add("ICH-107");
            centreName.Add("Santhome");


            centreDetails.Add("ICA-101");
            centreName.Add("Calicut");

            centreDetails.Add("IBG-104");
            centreName.Add("Ganganagar");

    

            MailMessage mess = new MailMessage();
            MailMessage initialmessage = new MailMessage();
            string initialfilename = "";
            string initialattach = "";
            string filename = "";
            string attachfile = "";
            int i = 0;
            foreach (string it in centreDetails)
            {

                // We have attached the fresh collection report from  02/03/2012  To  08/03/2012 
                initialfilename = "Initial_collection_of_" + centreName[i].ToString() + System.DateTime.Now.ToString("MM_dd_yyyy");
                DataRow[] drinitial = new DataRow[dtinitial.Rows.Count];
                initialresult = "";
                drinitial = dtinitial.Select("centercode='" + it + "'");
                initialresult += "  \n";
                initialresult += "Student Id \t Student Name \t Center Code \t Date \t Receipt Cut By \t Receipt No.  \t Amount \t Tax  \t Total \n";
                initialresult += "  \n";
                double amountinitial = 0;
                double taxinitial = 0;
                double totalinitial = 0;
                foreach (DataRow dr2 in drinitial)
                {
                    initialresult += dr2["student_id"].ToString() + "\t " + dr2["student_name"].ToString() + "\t " + dr2["centerCode"].ToString() + "\t " + dr2["date_ins"].ToString() + "\t " + dr2["receiptcutby"].ToString() + "\t " + dr2["receipt_no"].ToString() + "\t " + dr2["amount"].ToString() + "\t " + dr2["tax"].ToString() + "\t " + dr2["total"].ToString() + "\n";
                    amountinitial += Convert.ToDouble(dr2["amount"]);
                    taxinitial += Convert.ToDouble(dr2["tax"]);
                    totalinitial += Convert.ToDouble(dr2["total"]);
                }
                initialresult += "  \n";
                initialresult += "\t \t \t \t\t  Total : \t " + amts(amountinitial) + "\t " + amts(taxinitial) + "\t " + amts(totalinitial) + "\n";
                MVC.DataAccess.Log(initialresult, initialfilename);
                //SubMVC.ERP_Ashok.Log(result, filename);
                initialattach = "Monthlycollection/" + initialfilename + ".xls";
                initialmessage.Attachments.Add(new MailAttachment(Server.MapPath(initialattach)));



                filename = centreName[i].ToString() +System.DateTime.Now.ToString("MM_dd_yyyy");
                //Response.Write("<br>" +it);
                DataRow[] dr = new DataRow[dt.Rows.Count];
                result = "";
                dr = dt.Select("centercode='" + it + "'");
                result += "  \n";
                result += "Student Id \t Student Name \t Center Code \t Date \t Receipt Cut By \t Receipt No.  \t Amount \t Tax  \t Total \n";
                result += "  \n";
                double amount = 0;
                double tax = 0;
                double total = 0;
                foreach (DataRow dr1 in dr)
                {
                    result += dr1["student_id"].ToString() + "\t " + dr1["student_name"].ToString() + "\t " + dr1["centerCode"].ToString() + "\t " + dr1["date_ins"].ToString() + "\t " + dr1["receiptcutby"].ToString() + "\t " + dr1["receipt_no"].ToString() + "\t " + dr1["amount"].ToString() + "\t " + dr1["tax"].ToString() + "\t " + dr1["total"].ToString() + "\n";
                    amount += Convert.ToDouble(dr1["amount"]);
                    tax += Convert.ToDouble(dr1["tax"]);
                    total += Convert.ToDouble(dr1["total"]);

                }
                result += "  \n";
                result += "\t \t \t \t\t  Total : \t " + amts(amount) + "\t " + amts(tax) + "\t " + amts(total) + "\n";
                MVC.DataAccess.Log(result, filename);
                //SubMVC.ERP_Ashok.Log(result, filename);
                attachfile = "Monthlycollection/" + filename + ".xls";
                mess.Attachments.Add(new MailAttachment(Server.MapPath(attachfile)));
                i = i + 1;
            }

            // Response.Write("<br>" + filename);
           // initialmessage.To = "kathirvelindian@gmail.com";
            initialmessage.To = "rbi@imageil.com";
            //initialmessage.To = "kathirvelindian@gmail.com";
            initialmessage.From = "erp@imageil.com";
            initialmessage.Cc = "maildata909@gmail.com,prakash@imageil.com";
            //initialmessage.Cc += " akarthik1987@gmail.com";
            initialmessage.Body = @" Dear Sir,
                   We have attached the fresh collection report from " +System.DateTime.Today.AddDays(-6).ToString("dd/MM/yyyy") + " to " + System.DateTime.Now.ToString("dd/MM/yyyy");
            initialmessage.Subject = "Initial Collection Report From " +System.DateTime.Today.AddDays(-6).ToString("dd/MM/yyyy") + " to " + System.DateTime.Now.ToString("dd/MM/yyyy");
            // mess.Attachments.Add(new MailAttachment(Server.MapPath("ErrorLogs/Collection_Report_03_21_2012ak-test.xls")));

            initialmessage.BodyFormat = MailFormat.Html;
            SmtpMail.Send(initialmessage);

          mess.To = "rbi@imageil.com";
           // mess.To = "kathirvelindian@gmail.com";
            mess.From = "erp@imageil.com";
           mess.Cc = "maildata909@gmail.com,prakash@imageil.com";
           // mess.Cc += " akarthik1987@gmail.com";
          //  mess.Cc = "prakash@imageil.com";
            mess.Body = @" Dear Sir,
                    We have attached the collection report from " +System.DateTime.Today.AddDays(-6).ToString("dd/MM/yyyy") + " to " + System.DateTime.Now.ToString("dd/MM/yyyy");
            mess.Subject = "Weakly Collection Report From " +System.DateTime.Today.AddDays(-6).ToString("dd/MM/yyyy") + " to " + System.DateTime.Now.ToString("dd/MM/yyyy");
            // mess.Attachments.Add(new MailAttachment(Server.MapPath("ErrorLogs/Collection_Report_03_21_2012ak-test.xls")));

            mess.BodyFormat = MailFormat.Html;
            SmtpMail.Send(mess);
            _Qry = "update erp_collectionsenddate set status='0' where maildate<=datediff(d,7,getdate()) ";
            _Qry += " Insert into erp_collectionsenddate (maildate,status) values (convert(varchar,getdate(),101),1)";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //Gridview_admission.DataSource = dt;
            //Gridview_admission.DataBind();
        }

    }
    void exportExcel(DataTable dt)
    {
        ArrayList centreDetails = new ArrayList();
        string qry = "select distinct centercode from erp_receiptdetails";
        DataTable dtcentre = new DataTable();
        dtcentre = MVC.DataAccess.ExecuteDataTable(qry);
        if (dtcentre.Rows.Count > 0)
        {
            for (int i = 0; i < dtcentre.Rows.Count; i++)
            {
                centreDetails.Add(dtcentre.Rows[i]["centercode"].ToString());
            }

        }
        foreach (string it in centreDetails)
        {

            DataRow[] dr = new DataRow[dt.Rows.Count];

            dr = dt.Select("centercode='" + it + "'");
            result += "<table border=1><tr><td colspan='9' style='text-align: center; height:40px; font-weight:bold; '>Centre:" + it + "</td> </tr>";
            result += "<tr><th >Student Id </th><th >Student Name </th><th >centercode</th><th >Date</th><th >Receipt cut by</th> </th><th >receipt_no </th> <th >amount</td> </th><th >tax </th> <th >total</td> </th></tr>";
            double amount = 0;
            double tax = 0;
            double total = 0;
            foreach (DataRow dr1 in dr)
            {
                result += "<tr><td>" + dr1["student_id"].ToString() + "</td><td>" + dr1["student_name"].ToString() + "</td><td>" + dr1["centerCode"].ToString() + "</td><td>" + dr1["date_ins"].ToString() + "</td><td>" + dr1["receiptcutby"].ToString() + "</td><td>" + dr1["receipt_no"].ToString() + "</td><td>" + dr1["amount"].ToString() + "</td><td>" + dr1["tax"].ToString() + "</td><td>" + dr1["total"].ToString() + "</td> </tr>";
                amount += Convert.ToDouble(dr1["amount"]);
                tax += Convert.ToDouble(dr1["tax"]);
                total += Convert.ToDouble(dr1["total"]);
                Response.Write("");
            }
            result += "<tr ><td colspan='6' style='text-align: center; height:30px; font-weight:bold; '>Total</td><td style='text-align: center; font-weight:bold; '>" + amount + "</td><td style='text-align: center; font-weight:bold; '>" + tax + "</td><td style='text-align: center; font-weight:bold; '>" + total + "</td> ";
            result += "</table>";
            //           Response.Buffer=true;
            //Response.AddHeader( "content-disposition", "attachment;filename=report.xls");
            //Response.ContentType = "application/vnd.ms-excel";

        }
    }
}
