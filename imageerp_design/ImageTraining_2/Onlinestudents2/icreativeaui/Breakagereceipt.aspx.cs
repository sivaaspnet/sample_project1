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

         if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "")
         {
             Response.Redirect("Login.aspx");
         }

         if (Request.QueryString["studid"] == "" || Request.QueryString["studid"] == null)
         {
             Response.Redirect("breakageinvoice.aspx");
         }

        if(!IsPostBack)
         {
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
            displayonload();
            fillcoursedropdown();
          //  fillamount();
            //Totalcourse_feeonload();
         }
       
    }

    private void fillamount()
    {
        
ddl_breakage.Items.Add(new ListItem("Select",""));
    for(int i = 500; i <= 20000; i+=500)
    {
        ddl_breakage.Items.Add(new ListItem(i.ToString(), i.ToString()));
    }

    }
    private void fillcoursedropdown()
    {
        //_Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program Group By a.Program,a.course_id,b.Program";
        ////Response.Write(_Qry);
        ////Response.End();
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //txt_coursecode.DataSource = dt;
        //txt_coursecode.DataValueField = "Program";
        //txt_coursecode.DataTextField = "Program";
        //txt_coursecode.DataBind();
        //txt_coursecode.Items.Insert(0, new ListItem("Select", ""));

    }

   private void displayonload()
    {
       _Qry = "select enq_personal_name,ins.initialAmount,ins.initialAmountTax,ins.invoiceNo,ins.studentId,ins.totalinitialamount,installNumber,inv.courseFees,(round(cast(isnull(inv.courseFees,0) as int)+(cast(isnull(inv.courseFees,0) as int)*cast(inv.taxPercentage as float)/100),0)) as totalCourseFees,inv.taxPercentage,course.program from erp_installAmountdetails ins inner join erp_invoicedetails inv on inv.studentId=ins.studentId inner join adm_personalparticulars per on  per.student_id=ins.studentId inner join img_coursedetails course on course.course_id=inv.courseId where ins.studentId='" + Request.QueryString["studid"] + "' And ins.centerCode='" + Session["SA_centre_code"] + "' ";
       // Response.Write(_Qry);
        DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_Invoiceno.Text = dt.Rows[0]["invoiceNo"].ToString();
                txt_studname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                txt_coursecode.Text = dt.Rows[0]["program"].ToString();
            }
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("breakageinvoice.aspx?Stud_Id=" + Request.QueryString["studid"] + "");
    }
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
       
        try
        {
            if (txt_Invoiceno.Text != "" && TextBox1.Text != "" && ddl_paymode.SelectedValue != "" && ddl_month.SelectedValue!="" )
            {
                SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = "[spbreakagereceipt]";
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.AddWithValue("centerCode", Session["SA_centre_code"]);
                cmd.Parameters.AddWithValue("invoiceNo", txt_Invoiceno.Text);
                cmd.Parameters.AddWithValue("amount", TextBox1.Text);
                cmd.Parameters.AddWithValue("paymentMode", ddl_paymode.SelectedValue);
                cmd.Parameters.AddWithValue("bankName", txt_bankname.Text);
                cmd.Parameters.AddWithValue("ddNo", txt_ddcc.Text);
                cmd.Parameters.AddWithValue("ddDate", txt_dddate.Text);
                cmd.Parameters.AddWithValue("paymentTowards", ddlpaymenttowards.SelectedValue);
                cmd.Parameters.AddWithValue("studentId", Request.QueryString["studid"]);
                cmd.Parameters.AddWithValue("monthInstall", ddl_month.SelectedValue);
                cmd.Parameters.AddWithValue("receiptCutBy", Session["SA_UserID"]);
                cmd.Parameters.AddWithValue("remarks", txtreason.Text);
                cmd.Parameters.Add("@receiptNo", SqlDbType.VarChar, 50);
                cmd.Parameters["@receiptNo"].Direction = ParameterDirection.Output;
                Conn.Open();
                cmd.ExecuteNonQuery();
                string receiptNo = "";
                receiptNo = (string)cmd.Parameters["@receiptNo"].Value;
                Conn.Close();
                if (receiptNo == "E1")
                {
                    lblerrorMsg.Text = "Receipt No Already Exist";
                }
                else
                {
                    Response.Redirect("breakreceiptprint.aspx?studid=" + Request.QueryString["studid"] + "&recptno=" + receiptNo +"&invoiceno="+txt_Invoiceno.Text+"");
                }
            }
            else
            {
                lblerrorMsg.Text = "Please fill all the details";
            }
        }
        catch (Exception ex)
        {
            lblerrorMsg.Text = "Input Data is Not in correct Format";
         
        }

        //Response.Redirect("Receiptprint.aspx?studId=" + Request.QueryString["studid"] + "&rec_no=" + txt_receptno.Text + "&page=breakfee");
    }
}
