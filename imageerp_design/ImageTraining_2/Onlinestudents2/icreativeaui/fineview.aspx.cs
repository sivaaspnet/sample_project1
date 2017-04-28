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

public partial class fineview : System.Web.UI.Page
{
    string qry;
    string _Qry;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        
        if (!IsPostBack)
        {
            
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalender2.Text = mon;
            txttocalender2.Text = DateTime.Now.ToString("dd-MM-yyyy");
            fillgrid();
        }
    }
    private void fillgrid()
    {
        _Qry = @"
  select distinct rec.id,rec.studentId,Amount,taxAmount,cast (totalAmount as int) as totalAmount,receiptType,rec.receiptNo,f.studentname,f.finereason  from erp_receiptDetails rec inner join erp_finereceipt f on f.receiptno=rec.receiptno where receiptType='fine' and rec.CenterCode='" + Session["SA_centre_code"].ToString() + "' ";
      
        //Response.Write(_Qry);
        //Response.End();
       

        if (txtfromcalender2.Text != "" && txttocalender2.Text != "")
        {
            string str = txtfromcalender2.Text;
            string[] split = str.Split('-');
          string  fromdate = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender2.Text;
            string[] split1 = str1.Split('-');
            string todate = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry += " and rec.dateins between ('" + fromdate + "') and DATEADD(day,1,'" + todate + "')";

        }
        if (txt_search.Text != "" )
        {
            _Qry += " And rec.studentId = '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "'";
          
        }
 
        _Qry += " order by rec.id desc";

     //  Response.Write(_Qry);
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
            
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
       
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=BreakageReceipt.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
