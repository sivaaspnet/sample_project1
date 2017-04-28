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

public partial class superadmin_ViewAlteredInvoice : System.Web.UI.Page
{
    string _Qry;
    DataTable dtgrid = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        { 
            fillgrid();
            ViewState.Clear();
        }
      
    }


    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]%+$");
        e.IsValid = rx.IsMatch(txt_stuid.Text);
    }
    private void fillgrid()
    {

        _Qry = @"select studentid,centercode,invoiceid,receiptno,track,coursefees,(select program from img_coursedetails where course_id=courseid) as course,installno,paymenttype,batchtime,enteredby,taxpercentage,remarks,convert(varchar(20),dateins,103) as dateins from erp_invoicedetails where remarks!='' and centercode='" + Session["SA_centre_code"] + "' order by id desc";

       
          
            //Response.Write(_Qry);
            //Response.End();
           
            dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);
			 
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            GridView2.DataSource = dtgrid;
            GridView2.DataBind();
          
         
           
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

     
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{

            ////    if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "active")
            ////    {

            ////    }
            ////    else
            ////    {
            ////        e.Row.BackColor = System.Drawing.Color.DarkSalmon;
            ////    }
            ////}
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message.ToString());
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (txt_stuid.Text.Trim() != "")
            {
                _Qry = @"select studentid,centercode,invoiceid,receiptno,track,coursefees,(select program from img_coursedetails where course_id=courseid) as course,installno,paymenttype,batchtime,enteredby,taxpercentage,remarks,convert(varchar(20),dateins,103) as dateins from erp_invoicedetails where remarks!='' and studentid='" + txt_stuid.Text + "' and centercode='" + Session["SA_centre_code"] + "' order by id desc";

            }
            else if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {

                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];


                _Qry = @"select studentid,centercode,invoiceid,receiptno,track,coursefees,(select program from img_coursedetails where course_id=courseid) as course,installno,paymenttype,batchtime,enteredby,taxpercentage,remarks,convert(varchar(20),dateins,103) as dateins from erp_invoicedetails where remarks!='' and centercode='" + Session["SA_centre_code"] + "' and dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') order by id desc";
            }

            //Response.Write(_Qry);
            //Response.End();

            dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);

            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            GridView2.DataSource = dtgrid;
            GridView2.DataBind();
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=AlterInvoiceDetail.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView2.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
