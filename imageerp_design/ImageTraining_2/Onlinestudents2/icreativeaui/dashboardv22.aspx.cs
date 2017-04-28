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
public partial class dashboardv22 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
           Response.Redirect("Login.aspx");
       }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:MM-01-yyyy}", DateTime.Now).Trim();
            txtfromcalender2.Text = mon;
            txttocalender2.Text = DateTime.Now.ToString("MM-dd-yyyy");
            ddlregionfill();
            fillgrid();
        }

    }
    protected void ddlregionfill()
    {
        string qry = "select distinct centre_region from img_centredetails order by centre_region";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
        ddlregion.DataSource = dt;
        ddlregion.DataTextField = "centre_region";
        ddlregion.DataValueField = "centre_region";
        ddlregion.DataBind();
        ddlregion.Items.Insert(0, new ListItem("Select", ""));


    }

    protected void Gridview_dashboard_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != null && e.CommandName != "")
        {
            string[] arg = e.CommandArgument.ToString().Split(',');
            if (arg.Length > 1)
            {
                Session["dashCentreName"] = arg[1];
                Session["dashCentrecode"] = arg[0];
                Session["dashboardType"] = e.CommandName.ToString();
                Session["dashfromdate"] = txtfromcalender2.Text;
                Session["dashtodate"] = txttocalender2.Text;
                Response.Redirect("dashboardV2detail.aspx");
            }
        }

    }
    protected void Gridview_dashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_dashboard.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void fillgrid()
    {

        if (ddlregion.SelectedValue != "" && txtfromcalender2.Text.Trim() != "" && txttocalender2.Text.Trim() != "")
        {
            SqlCommand comm = new SqlCommand("spDashboardOpt");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("fromdate", txtfromcalender2.Text.Trim());
            comm.Parameters.AddWithValue("todate", txttocalender2.Text.Trim());
            comm.Parameters.AddWithValue("region", ddlregion.SelectedValue);
            DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);
            Gridview_dashboard.DataSource = dt;
            Gridview_dashboard.DataBind();
        }

    }
    protected string getdata()
    {
        string htmlstr = "";
        if (ddlregion.SelectedValue != "" && txtfromcalender2.Text.Trim() != "" && txttocalender2.Text.Trim() != "")
        {
            SqlCommand comm = new SqlCommand("spDashboard");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("fromdate", txtfromcalender2.Text.Trim());
            comm.Parameters.AddWithValue("todate", txttocalender2.Text.Trim());
            comm.Parameters.AddWithValue("region", ddlregion.SelectedValue);
            DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    htmlstr += " <tr><td>" + (i + 1).ToString() + "</td><td >" + dt.Rows[i]["centreName"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["BilledValue"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["DiplomaCount"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["CertificateCount"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["TotalCollection"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["FeesReceivable"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["DropoutAmount"].ToString() + "</td></tr>";
                }
            }
        }
        return htmlstr;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        wrap.Visible = true;
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Dashboard.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        wrap.RenderControl(htmlWrite);
        //string style = @"<style> .textmode { } </style>";
        //Response.Write(style);
        Response.Write(stringWrite.ToString());
        Response.Flush();
        Response.End();
    }
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
