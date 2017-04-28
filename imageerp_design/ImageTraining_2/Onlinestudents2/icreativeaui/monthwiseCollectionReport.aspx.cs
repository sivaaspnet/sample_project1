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
public partial class monthwiseCollectionReport : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_Master"] == null)
        {
            Response.Redirect("masterpassword.aspx");
        }
        if (!IsPostBack)
        {
            
            //int year = DateTime.Now.Year;
           // ddlyear.Items.Insert(0, new ListItem(year.ToString(), ""));
            
           fillyear();
            fillgrid();
        }

    }
    protected void fillyear()
    {
        int year = DateTime.Now.Year;
        string qry = @"select distinct year(dateins) as year from erp_receiptdetails order by year(dateins)";
        DataTable  dtyear = MVC.DataAccess.ExecuteDataTable(qry);
        ddlyear.DataSource = dtyear;
        ddlyear.DataTextField = "year";
        ddlyear.DataValueField = "year";
        ddlyear.DataBind();
        ddlyear.SelectedValue = year.ToString();
        //ddlyear.Items.Insert(0, new ListItem(year.ToString(), ""));

    }
    protected void Gridview_dashboard_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName != null && e.CommandName != "")
        //{
        //    string[] arg = e.CommandArgument.ToString().Split(',');
        //    if (arg.Length > 1)
        //    {
        //        Session["dashCentreName"] = arg[1];
        //        Session["dashCentrecode"] = arg[0];
        //        Session["dashboardType"] = e.CommandName.ToString();
        //        Session["dashfromdate"] = txtfromcalender2.Text;
        //        Session["dashtodate"] = txttocalender2.Text;
        //        Response.Redirect("dashboardV2detail.aspx");
        //    }
        //}

    }
    protected void Gridview_dashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_dashboard.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void fillgrid()
    {

        DataTable dtfinal=getdata(Convert.ToInt32(ddlyear.SelectedValue));
        Gridview_dashboard.DataSource = dtfinal;
        Gridview_dashboard.DataBind();
        

    }
    protected void fillgridExcel()
    {

        DataTable dtfinal = getdata(Convert.ToInt32(ddlyear.SelectedValue));
        GridviewExcel.DataSource = dtfinal;
        GridviewExcel.DataBind();


    }
    private string amts(string amount)
    {
        int amountvalue = Convert.ToInt32(amount);
        string words;
        if (amountvalue >= 10000000)
        {
            words =  amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = amountvalue.ToString("#,000");
        }
        return words;
    }
    protected DataTable getdata(int year)
    {
        int centretotal = 0; int monthtotal = 0; int sno = 0; int total = 0;
        string qry = @"select centre_location,sum(isnull(cast(rec.totalAmount as numeric),0)) as total,datename(month,dateins) as recmonth,year(dateins) as recyear,month(dateins) as recmonthno
          from erp_receiptdetails rec inner join img_centredetails cen on rec.centercode=cen.centre_code
           where year(dateins)='" + year + "' group by centre_location,month(dateins),datename(month,dateins),year(dateins) ";
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        DataTable dtcenters = new DataTable();
        string[] argcentre = new string[1];
        argcentre[0] = "centre_location";
        dtcenters = dt.DefaultView.ToTable(true, argcentre);
        DataView dvmonth = dt.DefaultView;
        dvmonth.Sort = "recmonthno asc";
        DataTable dtmonth = new DataTable();
        string[] argmonth = new string[1];
        argmonth[0] = "recmonth";
        dtmonth = dvmonth.ToTable(true, argmonth);
        DataTable dtfinal = new DataTable();
        dtfinal.Columns.Add("S.No");
        dtfinal.Columns.Add("Centers");
        foreach (DataRow drmonth in dtmonth.Rows)
        {
            dtfinal.Columns.Add(drmonth["recmonth"].ToString());
        }
        dtfinal.Columns.Add("Total");

        foreach (DataRow drcentre in dtcenters.Rows)
        {
            sno++;
            DataRow drfinal = dtfinal.NewRow();
            drfinal["S.No"] = sno.ToString();
            drfinal["Centers"] = drcentre["centre_location"].ToString();
            foreach (DataRow drmonth in dtmonth.Rows)
            {
                DataRow[] drtemp = dt.Select("centre_location='" + drcentre["centre_location"].ToString() + "' and recmonth='" + drmonth["recmonth"] + "'");
                if (drtemp.Length > 0)
                    drfinal[drmonth["recmonth"].ToString()] = amts(drtemp[0]["total"].ToString());
                else
                    drfinal[drmonth["recmonth"].ToString()] = "-";
            }
            centretotal = Convert.ToInt32(dt.Compute("SUM(total)", "centre_location='" + drcentre["centre_location"].ToString() + "'"));
            drfinal["Total"] = amts(centretotal.ToString());
            centretotal = 0;
            dtfinal.Rows.Add(drfinal);
        }
        DataRow drfinallast = dtfinal.NewRow();
        drfinallast["Centers"] = "Total";
        foreach (DataRow drmonth in dtmonth.Rows)
        {
            monthtotal = Convert.ToInt32(dt.Compute("SUM(total)", "recmonth='" + drmonth["recmonth"].ToString() + "'"));
            drfinallast[drmonth["recmonth"].ToString()] = amts(monthtotal.ToString());
            total = total + monthtotal;
            monthtotal = 0;
        }
        drfinallast["Total"] = amts(total.ToString());
        dtfinal.Rows.Add(drfinallast);
        return dtfinal;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        fillgridExcel();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=MonthwiseCollectionReport-"+ ddlyear.SelectedValue + ".xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridviewExcel.RenderControl(htmlWrite);
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}
