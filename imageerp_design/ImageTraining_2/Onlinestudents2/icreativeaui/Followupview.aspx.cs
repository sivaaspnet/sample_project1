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

public partial class superadmin_Followupview : System.Web.UI.Page
{
    string _Qry;
    int TeleEnquiry = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["TeleEnquiry"] == "" || Request.QueryString["TeleEnquiry"] == null)
        {

        }
        else
        {
            TeleEnquiry = Convert.ToInt32(Request.QueryString["TeleEnquiry"].ToString());
        }

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    private void fillgrid()
    {
        DataTable dt = new DataTable();
        if (TeleEnquiry == 1)
        {
            //_Qry = "select f.folloup_id,f.Decision,f.remark,f.centre_code,f.enq_number,convert(varchar,f.dateins,103) as dateins,convert(varchar,f.reminderdate,103) as reminderdate,e.enq_personal_name from img_followups f inner join img_enquiryform e on e.enq_number=f.enq_number where f.enq_number='" + Request.QueryString["enqno"] + "'";
            _Qry = "select f.folloup_id,f.Decision,f.remark,f.centre_code,f.enq_number,convert(varchar,f.dateins,103) as dateins,convert(varchar,f.reminderdate,103) as reminderdate,t.enquiryname as name  from img_followups f inner join teleenquiry t on cast(t.teleenquiryid as varchar)=f.enq_number where enq_number='" + Request.QueryString["enqno"] + "' order by f.folloup_id desc";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.Visible = false;
            grdTele.Visible = true;
            grdTele.DataSource = dt;
            grdTele.DataBind();    
            GvExport.DataSource = dt;
            GvExport.DataBind();
        }
        else
        {
            _Qry = "select f.folloup_id,f.Decision,f.remark,f.centre_code,f.enq_number,convert(varchar,f.dateins,103) as dateins,convert(varchar,f.reminderdate,103) as reminderdate,e.enq_personal_name from img_followups f inner join img_enquiryform e on e.enq_number=f.enq_number where f.enq_number='" + Request.QueryString["viewenqno"] + "'";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.Visible = true;
            grdTele.Visible = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GvExport.DataSource = dt;
            GvExport.DataBind();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkdel")
        {
            _Qry = "delete from img_followups where folloup_id="+e.CommandArgument.ToString()+"";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg.Text = "The Followup Detail Deleted Successfully ";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdTele_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTele.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdTele_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkdel")
        {
            _Qry = "delete from img_followups where folloup_id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg.Text = "The Followup Detail Deleted Successfully ";
        }
    }

    protected void LnkDownlaodExcel_Click(object sender, EventArgs e)
    {
        if (GvExport.Rows.Count > 0)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Followup-" + Session["SA_Location"] + "-center.xls");
            Response.Charset = "";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GvExport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            //fillgrid();
            // ExportTableData(dtgrid);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
