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
public partial class superadmin_viewincentivedetails : System.Web.UI.Page
{
    string _Qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            lblmessage.Text = "";
            if (Request.QueryString["msg"] != null)
            {
                if (Request.QueryString["msg"].ToLower() == "in")
                {
                    lblmessage.Text = "Incentive Added Successfully";
                }
                if (Request.QueryString["msg"].ToLower() == "up")
                {
                    lblmessage.Text = "Incentive Updated Successfully";
                }
                fillIncentiveReport();
            }
        }
    }
  
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillIncentiveReport();
    }

    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtstudentid.Text);
    }
    private void fillIncentiveReport()
    {
        _Qry = @"select icid,studentid,studentname,invoicenum,receiptnum,referedstudentname,referedstaffname from erp_incentivedetails where centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        DataTable dt = new DataTable();

        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            
            string str = txtfromdate.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttodate.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
            _Qry = _Qry + " and dateins between ('" + dateFrom + "') and ('" + dateTo + "')";

        }

        if(txtstudentid.Text!="")
        {
            _Qry = _Qry + " and studentid ='" + txtstudentid.Text + "'";
        }
        _Qry = _Qry + " order by icid desc";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvIncentiveReport.DataSource = dt;
        gvIncentiveReport.DataBind();
       

    }
     
    protected void gvIncentiveReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIncentiveReport.PageIndex = e.NewPageIndex;
        fillIncentiveReport();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillIncentiveReport();
        }
    }
}
