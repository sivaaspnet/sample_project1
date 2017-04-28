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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
public partial class superadmin_IncentiveDetail : System.Web.UI.Page
{
    int cfee = 0;
    int tfee = 0;
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4;
    
    public string apppdate;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Session["SA_centre_code"].ToString() == "IBG-104")
            {
                IncentiveDetailFill();
                common.Visible = false;
               // ganga.Visible = true;
              //  gangaaddress.Visible = true;
              //  lbl_ganga.Visible = true;
              //  lbl_img.Visible = false;
               // commonaddress.Visible = false;
            }
            else
            {
                IncentiveDetailFill();
                common.Visible = true;
               // ganga.Visible = false;
              //  lbl_ganga.Visible = false;
               // lbl_img.Visible = true;
              //  gangaaddress.Visible = false;
             //   commonaddress.Visible = true;
            }           

        }
    }

    private string amts(double amountvalue)
    {
        string words="";
        if (amountvalue > 0)
        {
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
        }
        return words;
    }

    
    private void IncentiveDetailFill()
    {
        _Qry = @"select i.referencetype,i.studentname,i.studentid,i.centrecode,c.centre_location,i.invoicenum,i.receiptnum,
                i.amountpaid,i.referedstudentname, i.referstudentid,i.referedstaffname,i.studentincentiveamt,i.staffincentiveamt,
                i.approvedby,i.paymentby,i.studentchequeno,i.studentchequedate,i.studentbankname,i.staffchequeno,
                i.staffchequedate,i.staffbankname,dbo.getCourses(d.studentId,d.invoiceId) as program,convert(varchar,d.dateins,103) as dateofjoin from erp_incentivedetails i inner join img_centredetails c on i.centrecode=c.centre_code inner join erp_invoiceDetails d on i.invoicenum=d.invoiceid inner join img_coursedetails p on d.courseid=p.course_id where d.centercode='" + Session["SA_centre_code"].ToString() + "' and i.icid='" + Regex.Replace(Request.QueryString["icid"], "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
  
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lblDate.Text = dt.Rows[0]["dateofjoin"].ToString();
            string sbContent = "";
           
            lblstudname.Text = dt.Rows[0]["studentname"].ToString();
            lblstudid.Text = dt.Rows[0]["studentid"].ToString();
            lblcentrecode.Text = dt.Rows[0]["centrecode"].ToString();
            lbllocation.Text = dt.Rows[0]["centre_location"].ToString();
            lblinvoiceno.Text = dt.Rows[0]["invoicenum"].ToString();
            lblreceiptnum.Text = dt.Rows[0]["receiptnum"].ToString();
            lblamountpaid.Text = dt.Rows[0]["amountpaid"].ToString();
            lblreferstudentid.Text = dt.Rows[0]["referstudentid"].ToString();
            lblcourse.Text = dt.Rows[0]["program"].ToString();
            lbldoj.Text = dt.Rows[0]["dateofjoin"].ToString();
          
            if (dt.Rows[0]["referencetype"].ToString() == "Student")
            {
                lblreferestudentname.Text = dt.Rows[0]["referedstudentname"].ToString();           
                lblreferstudentid.Text = dt.Rows[0]["referstudentid"].ToString();
                tblreferstudent.Style.Add("display", "block");
                tblreferstaff.Style.Add("display", "none");
              
              //  lblstudentamount.Text =dt.Rows[0]["studentincentiveamt"].ToString();
              //  lblstudchequeno.Text= dt.Rows[0]["studentchequeno"].ToString();
              //  lblstudchequedate.Text= dt.Rows[0]["studentchequedate"].ToString();
               // lblstudbankname.Text= dt.Rows[0]["studentbankname"].ToString();
            }
            else if (dt.Rows[0]["referencetype"].ToString() == "Staff")
            {
                lblreferstaffname.Text = dt.Rows[0]["referedstaffname"].ToString();

                tblreferstudent.Style.Add("display", "none");
                tblreferstaff.Style.Add("display", "block");
              //  lblstaffincenamount.Text= dt.Rows[0]["staffincentiveamt"].ToString();
               // lblstaffchequeno.Text= dt.Rows[0]["staffchequeno"].ToString();
               // lblstaffchequedate.Text=  dt.Rows[0]["staffchequedate"].ToString();
               // lblstaffbankname.Text=  dt.Rows[0]["staffbankname"].ToString();
            }
            else if (dt.Rows[0]["referencetype"].ToString() == "Both")
            {
                lblreferestudentname.Text = dt.Rows[0]["referedstudentname"].ToString();
                lblreferstaffname.Text = dt.Rows[0]["referedstaffname"].ToString(); 
                lblreferstudentid.Text = dt.Rows[0]["referstudentid"].ToString();
                tblreferstudent.Style.Add("display", "block");
                tblreferstaff.Style.Add("display", "block");
              
                //lblstudentamount.Text = dt.Rows[0]["studentincentiveamt"].ToString();
               // lblstudchequeno.Text = dt.Rows[0]["studentchequeno"].ToString();
               // lblstudchequedate.Text = dt.Rows[0]["studentchequedate"].ToString();
               // lblstudbankname.Text = dt.Rows[0]["studentbankname"].ToString();

                ///lblstaffincenamount.Text = dt.Rows[0]["staffincentiveamt"].ToString();
               // lblstaffchequeno.Text = dt.Rows[0]["staffchequeno"].ToString();
                //lblstaffchequedate.Text = dt.Rows[0]["staffchequedate"].ToString();
               // lblstaffbankname.Text = dt.Rows[0]["staffbankname"].ToString();
            }
            
         
            lblapprove.Text = dt.Rows[0]["approvedby"].ToString();
            lblpayment.Text = dt.Rows[0]["paymentby"].ToString();
             
 
          
        } 

    }  
   

    protected void btnhme_Click(object sender, EventArgs e)
    {
        Session["Stud_ID"] = "";
        Response.Redirect("viewincentivedetails.aspx");
    }


   
}
