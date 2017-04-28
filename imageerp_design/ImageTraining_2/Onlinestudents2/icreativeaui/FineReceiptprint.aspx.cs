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
using System.Data.SqlClient;
public partial class superadmin_FineReceiptprint : System.Web.UI.Page
{
    string _Qry;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if(! IsPostBack)
        {
            lblstudid.Value = Request.QueryString["studid"];
            lbl_recpno.Value = Request.QueryString["recptno"];
          
            //lblstudid.Text = Request.QueryString["studid"];
            FillInvoice();
        }
        
    }
   private void FillInvoice()
    {

        _Qry = @" select centre.centre_code,centre.center_address,centre.insititueName,address1,address2,centre.receiptTemplate,centre.For_institute ,CAST(rec.amount AS NUMERIC(10,0)) as amount1,CAST(rec.taxAmount AS NUMERIC(10,0)) as taxAmount1,CAST(rec.totalAmount AS NUMERIC(10,0))
as totalAmount1,*,convert(varchar,rec.dateins,103)as date,studentname as enq_personal_name from erp_receiptdetails rec   inner join erp_finereceipt q on q.receiptno=rec.receiptno   
 inner join img_centredetails as centre on centre.centre_code=rec.centercode  where  centercode='" + @Session["SA_centre_code"].ToString() + @"' and rec.receiptno='" + @Request["recptno"].ToString() + @"'
  ";


   
       DataTable dts = new DataTable();
        dts = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dts.Rows.Count > 0)
        {
            string tabletemplate=dts.Rows[0]["receiptTemplate"].ToString();
            if (dts.Rows[0]["paymentMode"].ToString() == "Cheque" || dts.Rows[0]["paymentMode"].ToString() == "D.D" || dts.Rows[0]["paymentMode"].ToString() == "C.C")
            {
                tabletemplate = tabletemplate.Replace("##DDnumber##", dts.Rows[0]["paymentMode"].ToString() + "(" + dts.Rows[0]["ddNo"].ToString() + ")");
                //lbl_Bank.Visible = true;
                //lbl_BankName.Visible = true;
                tabletemplate = tabletemplate.Replace("##Bank##", "Bank ");
                tabletemplate = tabletemplate.Replace("##BankName##", dts.Rows[0]["bankName"].ToString() + " ");
            }
            else
            {
                tabletemplate = tabletemplate.Replace("##DDnumber## ", dts.Rows[0]["paymentMode"].ToString());
            }

            if (dts.Rows[0]["paymentMode"].ToString() == "Cash")
            {
                tabletemplate = tabletemplate.Replace("##DDnumber## ", dts.Rows[0]["paymentMode"].ToString());
                tabletemplate = tabletemplate.Replace("##Bank##", "");
                tabletemplate = tabletemplate.Replace("##BankName##", "");
            }
           tabletemplate = tabletemplate.Replace("##Receiptdate##", dts.Rows[0]["date"].ToString());
            tabletemplate = tabletemplate.Replace("##Receiptnumber##", Request.QueryString["recptno"]);
            tabletemplate = tabletemplate.Replace("##Amountinwords##", dts.Rows[0]["paymentWords"].ToString());
            tabletemplate = tabletemplate.Replace("##Monthinstallment##", ("<b>" + dts.Rows[0]["monthInstall"].ToString() + "</b>"));
            tabletemplate = tabletemplate.Replace("##FeesAmount##", dts.Rows[0]["amount1"].ToString());
            tabletemplate = tabletemplate.Replace("##sum##", dts.Rows[0]["totalAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Totalamount##", dts.Rows[0]["totalAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Invoicenumber##", "");
            tabletemplate = tabletemplate.Replace("##Coursecode##", "");
            tabletemplate = tabletemplate.Replace("##Studentname##", ("<b>"+dts.Rows[0]["enq_personal_name"].ToString()+"</b>"));
            tabletemplate = tabletemplate.Replace("##address 1##", dts.Rows[0]["address1"].ToString());
            tabletemplate = tabletemplate.Replace("##address 2##", dts.Rows[0]["address2"].ToString());
            //lbl_ddcc.Text = dts.Rows[0]["payment_mode"].ToString();
            tabletemplate = tabletemplate.Replace("## institue name##", dts.Rows[0]["insititueName"].ToString());
            tabletemplate = tabletemplate.Replace("##Tax##", dts.Rows[0]["taxAmount1"].ToString());
            tabletemplate = tabletemplate.Replace("##Paymenttowards##", ("<b>" + dts.Rows[0]["paymentTowards"].ToString() + "</b>"));
            tabletemplate = tabletemplate.Replace("##Image Infotainment Limited##", ("<b>"+dts.Rows[0]["For_institute"].ToString()+"</b>"));
            tabletemplate = tabletemplate.Replace("##CentreAddress##", ("<b>" + dts.Rows[0]["center_address"].ToString() + "</b>"));
            tabletemplate = tabletemplate.Replace("##lblstudid##", dts.Rows[0]["studentId"].ToString());
            tabletemplate = tabletemplate.Replace("##logo##","<img src='images/logo/image-infotainment-limited.png'/>");tabletemplate = tabletemplate.Replace("##logo1##","<img src='images/logo/logo2.png'/>");
            Label1.Text = tabletemplate.ToString();
        }
    //}
    //catch (Exception ex)
    //{
    //    Response.Write("Pleae Contact Admin");
    //}

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
            Response.Redirect("fineview.aspx");
        
    }
}
