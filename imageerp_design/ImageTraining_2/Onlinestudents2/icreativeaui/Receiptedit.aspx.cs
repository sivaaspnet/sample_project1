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

public partial class superadmin_Receiptedit : System.Web.UI.Page
{
    string _Qry, _Qry1,_Qry2,_Qry3, CentreCount1, Receiptno,coursefees,course_tax,corse_code,paypattern;
    double Total, month_tx,Total1,month_tx1;
    int Invoice_no = 0;
    int cen_code = 0;
    int instalnum = 0;
    int zzz = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
         {
            Response.Redirect("Login.aspx");
         }

        

        if(!IsPostBack)
         {
             hdnTax.Value = "0";
             int mm = System.DateTime.Now.Month;
             if (mm == 1)
             {
                 ddl_month.SelectedValue = "Jan";
             }
             if (mm == 2)
             {
                 ddl_month.SelectedValue = "Feb";
             }
             if (mm == 3)
             {
                 ddl_month.SelectedValue = "Mar";
             }
             if (mm == 4)
             {
                 ddl_month.SelectedValue = "Apr";
             }
             if (mm == 5)
             {
                 ddl_month.SelectedValue = "May";
             }
             if (mm == 6)
             {
                 ddl_month.SelectedValue = "Jun";
             }
             if (mm == 7)
             {
                 ddl_month.SelectedValue = "Jul";
             }
             if (mm == 8)
             {
                 ddl_month.SelectedValue = "Aug";
             }
             if (mm == 9)
             {
                 ddl_month.SelectedValue = "Sep";
             }
             if (mm == 10)
             {
                 ddl_month.SelectedValue = "Oct";
             }
             if (mm == 11)
             {
                 ddl_month.SelectedValue = "Nov";
             }
             if (mm == 12)
             {
                 ddl_month.SelectedValue = "Dec";
             }
           lblbalanceamount.Text=Request.QueryString["balance"].ToString();
            displayonload();
            //Totalcourse_feeonload();
         }
       
    }
   

   private void displayonload()
    {
        //_Qry = "select enq_personal_name,ins.initialAmount,ins.initialAmountTax,ins.invoiceNo,ins.studentId,ins.totalinitialamount,installNumber,inv.courseFees,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.taxPercentage,course.program from erp_installAmountdetails ins inner join erp_invoicedetails inv on inv.studentId=ins.studentId inner join adm_personalparticulars per on  per.student_id=ins.studentId inner join img_coursedetails course on course.course_id=inv.courseId where ins.studentId='" + Request.QueryString["studid"] + "' And ins.centerCode='" + Session["SA_centre_code"] + "' and ins.installnumber='" + Request.QueryString["instlno"] + "'";
        _Qry = "select enq_personal_name,ins.initialAmount,ins.initialAmountTax,inv.invoiceId,ins.studentId,round(ins.totalinitialamount,0) as totalinitialamount,installNumber,inv.courseFees,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.taxPercentage,fee.tax,course.program from erp_installAmountdetails ins inner join erp_invoicedetails inv on inv.studentId=ins.studentId  and inv.status='active' and inv.studentId='" + Request.QueryString["studid"] + "'  inner join adm_personalparticulars per on per.student_id=ins.studentId inner join img_coursedetails course on course.course_id=inv.courseId inner join img_centre_coursefee_details fee on inv.courseid=fee.program and inv.track=fee.track and inv.centercode=fee.centre_code  where ins.studentId='" + Request.QueryString["studid"] + "' And ins.centerCode='" + Session["SA_centre_code"] + "' and ins.installnumber='" + Request.QueryString["instlno"] + "'";
       //Response.Write(_Qry);
        DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_Invoiceno.Text = dt.Rows[0]["invoiceid"].ToString();
                txt_coursecode.Text = dt.Rows[0]["program"].ToString();
                lbl_TOTALCOURSE_FEE.Text = dt.Rows[0]["courseFees"].ToString();
                txt_studname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                lbldisplaytax.Text = dt.Rows[0]["tax"].ToString()+"%";
                hdnTax.Value = dt.Rows[0]["tax"].ToString();// it is used to calculate part in js
                txt_initialamt.Text=dt.Rows[0]["totalinitialamount"].ToString();
                lblamtwithtax.Text = dt.Rows[0]["initialAmount"].ToString();
                //double tax = Convert.ToDouble(lblbalanceamount.Text) * Convert.ToDouble(dt.Rows[0]["tax"].ToString()) / 100;
                //double balwithouttax = Convert.ToDouble(lblbalanceamount.Text) - tax;
                //lbl_balwithouttax.Text = Convert.ToString(Math.Round(balwithouttax));
                double tax = Convert.ToDouble(dt.Rows[0]["tax"].ToString());
                double balwithouttax = Convert.ToDouble(lblbalanceamount.Text) / (Convert.ToDouble(dt.Rows[0]["tax"].ToString()) + 100);
                lbl_balwithouttax.Text = Convert.ToString(Math.Round(balwithouttax) * 100);
            }      
       
       
     
    }
    protected void Btnupdate_Click(object sender, EventArgs e)
    {


        _Qry = "select count(*) as count from erp_installamountdetails where studentid='" + Request.QueryString["studid"] + "' and installnumber='" + Request.QueryString["instlno"] + "' and status='Completed' and invoiceNo='"+txt_Invoiceno.Text+"'";
        DataTable dt0 = new DataTable();
        dt0 = MVC.DataAccess.ExecuteDataTable(_Qry);
        int cnt = Convert.ToInt32(dt0.Rows[0]["count"].ToString());
        if (cnt > 0)
        {
            lblerrorMsg.Text = "Installment Already paid";

        }
        else
        {
            if (Convert.ToDouble(txt_initialamt.Text) > Convert.ToDouble(lblbalanceamount.Text))
            {
                lblerrorMsg.Text = "Fees greater than balance amount";
            }
            else
            {
                try
                {
                    SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "[spReceiptEdit]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (hdnAmtWithTax.Value=="")
                    {
                        hdnAmtWithTax.Value = "0";
                    }
                    double taxamount = Convert.ToDouble(txt_initialamt.Text) - Convert.ToDouble(hdnAmtWithTax.Value);
                  
                   //////Response.Write("centerCode" +Session["SA_centre_code"] +"<br/>");
                   //////Response.Write("invoiceNo" + txt_Invoiceno.Text + "<br/>");
                   //////Response.Write("totalAmount" + txt_initialamt.Text + "<br/>");
                   //////Response.Write("paymentMode" + ddl_paymode.SelectedValue + "<br/>");
                   //////Response.Write("bankName" + txt_bankname.Text + "<br/>");
                   //////Response.Write("ddNo" + txt_ddcc.Text + "<br/>");
                   //////Response.Write("ddDate" + dddate.Text + "<br/>");
                   //////Response.Write("paymentTowards" + "Installment" + "<br/>");
                   //////Response.Write("studentId" + Request.QueryString["studid"] + "<br/>");
                   //////Response.Write("monthInstall" + ddl_month.SelectedValue + "<br/>");
                   //////Response.Write("installNo" + Request.QueryString["instlno"] + "<br/>");
                   //////Response.Write("receiptCutBy" + Session["SA_userID"] + "<br/>");
                   //////Response.Write("@receiptNo"+"");
                    

                    cmd.Parameters.AddWithValue("centerCode", Session["SA_centre_code"]);
                    cmd.Parameters.AddWithValue("invoiceNo", txt_Invoiceno.Text);
                    cmd.Parameters.AddWithValue("totalAmount", txt_initialamt.Text);
                    cmd.Parameters.AddWithValue("paymentMode", ddl_paymode.SelectedValue);
                    cmd.Parameters.AddWithValue("bankName", txt_bankname.Text);
                    cmd.Parameters.AddWithValue("ddNo", txt_ddcc.Text);
                    cmd.Parameters.AddWithValue("ddDate", dddate.Text);
                    cmd.Parameters.AddWithValue("paymentTowards", "Installment");
                    cmd.Parameters.AddWithValue("studentId", Request.QueryString["studid"]);
                    cmd.Parameters.AddWithValue("monthInstall", ddl_month.SelectedValue);
                    cmd.Parameters.AddWithValue("installNo", Request.QueryString["instlno"]);
                    cmd.Parameters.AddWithValue("receiptCutBy", Session["SA_userID"]);
                    cmd.Parameters.Add("@receiptNo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@receiptNo"].Direction = ParameterDirection.Output;

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    string receiptNo = "";
                    receiptNo = (string)cmd.Parameters["@receiptNo"].Value;
                    string studentId = "";
                    studentId = Request.QueryString["studid"];
                    Conn.Close();
                    if (receiptNo == "E1")
                    {
                        lblerrorMsg.Text = "Receipt No Already Exist";
                    }
                    else if (receiptNo == "E2")
                    {
                        lblerrorMsg.Text = "No course tax in master table";
                    }
                    else
                    {
                        Response.Redirect("receiptprint.aspx?recptno=" + receiptNo + "&studid=" + studentId + "&invoiceno=" + txt_Invoiceno.Text);
                    }
                }
                catch (Exception ex)
                {
                    //lblerrorMsg.Text = "Input Data is Not in correct Format";
                    lblerrorMsg.Text = ex.Message.ToString();
                }
            }
        }
    }
   
  private void Totalcourse_feeonload()
    {
      _Qry = "select Invoice_No from install_amountdetails where student_id='" + Request.QueryString["studid"] + "' And centre_code='" + Session["SA_centre_code"] + "'";

        SqlDataReader dr123;
        dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr123.HasRows)
        {
            dr123.Read();

            Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

            dr123.Close();
        }
        if (Invoice_no > 0)
        {
            _Qry = "select course_fees as totalcourse_fees,course_fees,course_tax from install_amountdetails where student_id='" + Request.QueryString["studid"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            lbl_TOTALCOURSE_FEE.Text = dt.Rows[0]["totalcourse_fees"].ToString();
            coursefees = dt.Rows[0]["course_fees"].ToString();
            course_tax = dt.Rows[0]["course_tax"].ToString();
        }
        else
        {
            //_Qry = "select replace(convert(varchar,cast(total_course_fees as money),1),'.00','') as total_course_fees,replace(convert(varchar,cast(course_fees as money),1),'.00','') as course_fees,replace(convert(varchar,cast(course_tax as money),1),'.00','') as course_tax from Old_install_amountdetails where student_id='" + Request.QueryString["studid"] + "'";
            _Qry = "select replace(replace(total_course_fees,'.00',''),'-','') as total_course_fees,replace(replace(course_fees,'.00',''),'-','') as course_fees,replace(replace(course_tax,'.00',''),'-','') as course_tax from Old_install_amountdetails where student_id='" + Request.QueryString["studid"] + "'";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            lbl_TOTALCOURSE_FEE.Text = dt.Rows[0]["total_course_fees"].ToString();
            coursefees = dt.Rows[0]["course_fees"].ToString();
            course_tax = dt.Rows[0]["course_tax"].ToString();
        }
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receiptdetails.aspx?Stud_Id=" + Request.QueryString["studid"] + "");
    }
}
