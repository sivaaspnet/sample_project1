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

public partial class superadmin_InvoiceMenu_info : System.Web.UI.Page
{
    string _Qry, student_id;
    int Invoice_no = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
         if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
        if (!IsPostBack)
            erp_students();
    }
    protected void erp_students()
    {
        if (Session["SA_centre_code"] != null && Session["SA_centre_code"] != "")
        {
            _Qry = "select id,studentid,studentname,coursename,centrecode from erp_infostudentlist where centrecode='" + Session["SA_centre_code"].ToString() + "' order by studentname desc";
        }        
        //_Qry = "select studentid,studentname,coursename,centrecode from erp_infostudentlist order by studentname desc";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridview_info.DataSource = dt;
        Gridview_info.DataBind();
    }
    protected void gridviewinfo_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string studentid = (e.Row.FindControl("hdnstudentid") as HiddenField).Value;
            string centrecode = (e.Row.FindControl("hdncentrecode") as HiddenField).Value;
            DataTable dt = info.DataAccess.ExecuteDataTable("select distinct invoiceid from erp_invoicedetails where studentid='" + studentid + "' and centercode='" + centrecode + "'");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            LinkButton lnk = e.Row.FindControl("linkbutton1") as LinkButton;
                            lnk.CommandArgument = dt.Rows[i]["invoiceid"].ToString();
                            lnk.Text = dt.Rows[i]["invoiceid"].ToString();
                            lnk.Visible = true;
                            break;
                        case 1:
                            LinkButton lnk1 = e.Row.FindControl("linkbutton2") as LinkButton;
                            lnk1.CommandArgument = dt.Rows[i]["invoiceid"].ToString();
                            lnk1.Text = dt.Rows[i]["invoiceid"].ToString();
                            lnk1.Visible = true;
                            break;
                        case 2:
                            LinkButton lnk2 = e.Row.FindControl("linkbutton3") as LinkButton;
                            lnk2.CommandArgument = dt.Rows[i]["invoiceid"].ToString();
                            lnk2.Text = dt.Rows[i]["invoiceid"].ToString();
                            lnk2.Visible = true;
                            break;
                        case 3:
                            LinkButton lnk3 = e.Row.FindControl("linkbutton4") as LinkButton;
                            lnk3.CommandArgument = dt.Rows[i]["invoiceid"].ToString();
                            lnk3.Text = dt.Rows[i]["invoiceid"].ToString();
                            lnk3.Visible = true;
                            break;
                    }

                }
            }

        }
    }
    protected void gridviewinfo_command(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Inv")
        {
            //Response.Redirect("InvoiceDetails.aspx?invno="+e.CommandArgument.ToString()+"");
            Server.Transfer("InvoiceDetails_info.aspx?invno=" + e.CommandArgument.ToString() + "");
        }
        if (e.CommandName == "del")
        {
            string id = e.CommandArgument.ToString();
            string qry = "delete from erp_infostudentlist where id='"+id+"'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,qry);
            erp_students();
        }
    }
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_info.PageIndex = e.NewPageIndex;
        erp_students();
    }


}
