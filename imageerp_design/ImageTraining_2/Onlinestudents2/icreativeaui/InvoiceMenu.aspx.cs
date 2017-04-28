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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class superadmin_InvoiceMenu : System.Web.UI.Page
{
    string _Qry,student_id;
    int Invoice_no = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = "select  distinct studentid   from erp_invoicedetails  where (studentstatus='active' or studentstatus='NP') and  (studentid='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' or invoiceId='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "') ";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count <= 0)
            {
                lbl_errormsg.Text = "No Records Found";
            }
            else
            {
                _Qry = "select invoiceid,studentid,program from erp_invoicedetails inner join img_coursedetails on course_id=courseid where centerCode='" + Session["SA_centre_code"] + "' and   (studentid='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' or invoiceId='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "')  ";
                //Response.Write(_Qry);
                //Response.End();


                //DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows.Count == 1)
                    {
                       Server.Transfer("InvoiceDetails.aspx?invno=" + dt.Rows[0]["invoiceid"].ToString() + "");
                    }
                    else
                    {
                        //Invoice_no = Convert.ToInt32(dt.Rows[0]["invoiceid"].ToString());
                        //student_id = dt.Rows[0]["studentId"].ToString();
                        //Response.Redirect("InvoiceDetails.aspx?invno=" + Invoice_no + "");
                      //  GridView1.DataSource = dt;//
                       // GridView1.DataBind();//
                    }

                }

                else
                {
                    lbl_errormsg.Text = "No Records Found";
                }

            }
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_stuid.Text);
    }
   
}
