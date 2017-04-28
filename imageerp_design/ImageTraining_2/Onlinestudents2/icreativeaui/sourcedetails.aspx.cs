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


public partial class superadmin_sourcedetails : System.Web.UI.Page
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
            fillgrid();
        }
    }
    private void fillgrid()
    {
        _Qry = "select sourceid,sourcename,case status when 1 then 'Active'  when 0 then 'Deactive' when 2 then 'Delete' end as status from erp_sourcedetails where  status<>2";
        if (txtsearch.Text!="")
        {
            _Qry += "and  sourcename like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearch.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%'";
        }
        _Qry += " order by status asc ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

   
   private void refresh()
    {
        txt_Modulename.Text = "";
        ddlstatus.SelectedValue = "";
        //DDlSoftwareStatus.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select sourcename,sourceid,status from erp_sourcedetails where sourceid=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {

                string val = dt.Rows[0]["Status"].ToString();

                //Response.Write(val);
                //Response.End();


                txt_Modulename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["sourcename"].ToString());
                //DDlSoftwareStatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());
                ddlstatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["status"].ToString());

                hiddn_id.Value = dt.Rows[0]["sourceid"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update erp_sourcedetails set status=2 where sourceid='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "The source details has been deleted successfully";
            refresh();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            _Qry = "select count(sourceid) from erp_sourcedetails where sourcename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' and status<>2 ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The source name already exist";
            }
            else
            {
                //insert
                // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


                _Qry = " INSERT INTO erp_sourcedetails (sourcename,status,dateins)VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "', '" + ddlstatus.SelectedValue + "', getdate())";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The source details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(sourceid)from erp_sourcedetails where sourcename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' and sourceid <> " + hiddn_id.Value + "  and status<>2";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The source name already exist";
            }
            else
            {
                //update
                _Qry = "update erp_sourcedetails set sourcename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "',status='" + ddlstatus.SelectedValue + "'  where sourceid=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The source details has been Updated successfully";
                refresh();
                hiddn_id.Value = "";

            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Linkdownload_Click(object sender, EventArgs e)
    {
        _Qry = "select sourcename,case status when 1 then 'Active'  when 0 then 'Deactive' when 2 then 'Delete' end as status from erp_sourcedetails where status<>2 order by status desc, sourceid";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ExportTableData(dt);

    }
    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Source-Details.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }


}
