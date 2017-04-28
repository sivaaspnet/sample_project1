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


public partial class superadmin_outstandingreport : System.Web.UI.Page
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
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromdate.Text = mon;
            txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            //ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
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
        Response.AppendHeader("Content-Disposition", "attachment;filename=Enrolled&Unbatched-report-of="+txtfromdate.Text.ToString()+"-To-"+txttodate.Text.ToString()+"-" + Session["SA_Location"] + "-center.xls");
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

            _Qry = @"select convert(varchar,DateMod,103)as DateMod,program,adm.student_id,adm.enq_personal_name,adm.studentstatus,inv.courseFees,inv.invoiceid from adm_personalparticulars adm inner join erp_invoicedetails inv on adm.student_id=inv.studentid inner join img_coursedetails on inv.courseId=course_id  where adm.student_id not in (select distinct studentid from erp_batchschedule) and adm.centre_code='" + Session["SA_centre_code"].ToString() + "' and adm.studentstatus='active' ";

            if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            string str = txtfromdate.Text;
            string[] split = str.Split('-');
          string  fromdate = split[2] + "-" + split[1] + "-" + split[0];

          string str1 = txttodate.Text;
            string[] split1 = str1.Split('-');
            string todate = split1[2] + "-" + split1[1] + "-" + split1[0];
            _Qry += " and DateMod between  ('" + fromdate + "') and DATEADD(day,1,'" + todate + "')";
         
            }

            if (TextBox1.Text != "")
            {
                _Qry += " and adm.student_id='"+TextBox1.Text+"'";
            }

       
            if (ddl_status.SelectedValue != "")
            {
                _Qry += " and adm.studentstatus='" + ddl_status.SelectedValue + "'";
            }
            
            
            finalDt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

           Gridview_admission.DataSource = finalDt;
            Gridview_admission.DataBind();
            LinkButton1.Visible = true;

          

           
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message.ToString());
            //Response.Write("Pleae Contact Admin");
        }
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
        //if (Session["SA_Centrerole"].ToString() == "CentreManager" || Session["SA_Centrerole"].ToString() == "SuperAdmin")
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
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(TextBox1.Text);
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
