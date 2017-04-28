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
using System.Collections.Generic;

public partial class dashboardV2detail : System.Web.UI.Page
{
    string dashtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if(!IsPostBack)
        fillgrid();
    }
    protected void fillgrid()
    {
        dashtype = Session["dashboardType"].ToString();
        SqlCommand comm = new SqlCommand("spDashboardData");
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.AddWithValue("fromdate", Session["dashfromdate"].ToString());
        comm.Parameters.AddWithValue("todate", Session["dashtodate"].ToString());
        comm.Parameters.AddWithValue("centrecode", Session["dashCentrecode"].ToString());
        comm.Parameters.AddWithValue("dashboardType", dashtype);
        DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);
     
        switch (dashtype)
        {
            case "billedvalue":
                headertext.InnerText = "Enrollment Details of " + Session["dashCentreName"].ToString() + " Centre";
                 Gridview_dashboard.DataSource = dt;
                 Gridview_dashboard.DataBind();
                 break;
            case "diploma":
                 headertext.InnerText = "Enrollment Details of " + Session["dashCentreName"].ToString() + " Centre (Diploma)";
                  Gridview_dashboard.DataSource = dt;
                  Gridview_dashboard.DataBind(); 
                  break;
            case "certificate":
                  headertext.InnerText = "Enrollment Details of " + Session["dashCentreName"].ToString() + " Centre (Certificate)";
                  Gridview_dashboard.DataSource = dt;
                  Gridview_dashboard.DataBind();
                  break;
            case "totalcollection":
                  headertext.InnerText = "Total Collection of " + Session["dashCentreName"].ToString() + " Centre";
                  Gridview_dashboard1.DataSource = dt;
                  Gridview_dashboard1.DataBind();
                  break;
            case "feesreceivable":
                  headertext.InnerText = "Fees Receivable Details of " + Session["dashCentreName"].ToString() + " Centre";
                  Gridview_dashboard.DataSource = dt;
                  Gridview_dashboard.DataBind();
                  break;
            case "dropoutamount":
                  headertext.InnerText = "DropOut Student Details of " + Session["dashCentreName"].ToString() + " Centre";
                  Gridview_dashboard2.DataSource = dt;
                  Gridview_dashboard2.DataBind();
                  break;
        }
     

    }
     protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Gridview_dashboard.AllowPaging = false;
        Gridview_dashboard1.AllowPaging = false;
        fillgrid();
            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            switch (dashtype)
            {
                case "billedvalue":
                    Response.AddHeader("content-disposition", "attachment;filename=Enrollment-details-of-" + Session["dashCentreName"] + "-center.xls");
                    Gridview_dashboard.RenderControl(htmlWrite);
                    break;
                case "diploma":
                    Response.AddHeader("content-disposition", "attachment;filename=Enrollment-details-of-" + Session["dashCentreName"] + "-center(Diploma).xls");
                    Gridview_dashboard.RenderControl(htmlWrite);
                    break;
                case "certificate":
                    Response.AddHeader("content-disposition", "attachment;filename=Enrollment-details-of-" + Session["dashCentreName"] + "-center(Certificate).xls");
                    Gridview_dashboard.RenderControl(htmlWrite);
                    break;
                case "totalcollection":
                    Response.AddHeader("content-disposition", "attachment;filename=Total-Collection-Details-of-" + Session["dashCentreName"] + "-center.xls");
                    Gridview_dashboard1.RenderControl(htmlWrite);
                    break;
                case "feesreceivable":
                    Response.AddHeader("content-disposition", "attachment;filename=FeesReceivable-Details-of-" + Session["dashCentreName"] + "-center.xls");
                    Gridview_dashboard.RenderControl(htmlWrite);
                    break;
                case "dropoutamount":
                    Response.AddHeader("content-disposition", "attachment;filename=DropOut-Details-of-" + Session["dashCentreName"] + "-center.xls");
                    Gridview_dashboard2.RenderControl(htmlWrite);
                    break;
            }
            //Gridview_dashboard.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();            
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    protected void Gridview_dashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_dashboard.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Gridview_dashboard1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_dashboard1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Gridview_dashboard2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_dashboard2.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
