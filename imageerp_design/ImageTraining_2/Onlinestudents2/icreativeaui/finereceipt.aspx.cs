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

public partial class superadmin_finereceipt : System.Web.UI.Page
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
   



    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("breakage.aspx");
    }
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        string rec_id = "";
        try
        {
            if (TextBox1.Text !="" && ddl_paymode.SelectedValue != "" && ddl_month.SelectedValue!="" )
            { 
                    //Response.Redirect("finereceiptprint.aspx?studid=0&recptno=" + receiptNo + "&invoiceno=0");
                
                SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;

                cmd.CommandText = "[finereceipt]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]); 
                cmd.Parameters.AddWithValue("mode", ddl_paymode.SelectedValue);
                cmd.Parameters.AddWithValue("bankname", txt_bankname.Text);
                cmd.Parameters.AddWithValue("dddate", txt_dddate.Text);
                cmd.Parameters.AddWithValue("ddno", txt_ddcc.Text);   
                cmd.Parameters.AddWithValue("totalinitialAmt", TextBox1.Text); 
                cmd.Parameters.AddWithValue("initialAmt", TextBox1.Text);
                cmd.Parameters.AddWithValue("taxinitialAmt", 0);
                cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
                cmd.Parameters.AddWithValue("studentname", txt_studname.Text);
                cmd.Parameters.AddWithValue("month", ddl_month.SelectedValue);
                cmd.Parameters.AddWithValue("reason", txtreason.Text); 
                cmd.Parameters.Add("@runningReceipt", SqlDbType.VarChar, 50);
                cmd.Parameters["@runningReceipt"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@student", SqlDbType.VarChar, 50);
                cmd.Parameters["@student"].Direction = ParameterDirection.Output;
                Conn.Open();
                cmd.ExecuteNonQuery();
                rec_id = (string)cmd.Parameters["@runningReceipt"].Value;
                string student = (string)cmd.Parameters["@student"].Value;
                Conn.Close();
                Response.Redirect("finereceiptprint.aspx?recptno=" + rec_id + "&studid=" + student + "&adm=fine");
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
