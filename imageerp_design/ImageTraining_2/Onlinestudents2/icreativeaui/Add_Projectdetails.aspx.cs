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


public partial class superadmin_Add_Moduledetails : System.Web.UI.Page
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
            Fillsearchproject();
        }
    }
    private void fillgrid()
    {
        _Qry = "select projectId,UPPER(SUBSTRING(projectName,1,1))+ Lower(SUBSTRING(projectName,2,len(projectName)-1)) as projectName,Status from projectdetails where project_status='Active'";
        if (ddl_project.SelectedValue != "")
        {
            _Qry += "and projectId = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_project.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'";
        }
        _Qry += "order by projectId";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void Fillsearchproject()
    {
        _Qry = "select *  from projectdetails where project_status='Active'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddl_project.DataSource = dt1;
        ddl_project.DataValueField = "projectId";
        ddl_project.DataTextField = "projectName";
        ddl_project.DataBind();
        ddl_project.Items.Insert(0, new ListItem("Select", ""));
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
            _Qry = "select ProjectId,projectName,Status from projectdetails where projectId=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {

                string val = dt.Rows[0]["Status"].ToString();

                //Response.Write(val);
                //Response.End();


                txt_Modulename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["projectName"].ToString());
                //DDlSoftwareStatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());
                ddlstatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());

                hiddn_id.Value = dt.Rows[0]["ProjectId"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update projectdetails set project_status='Deactive' where  ProjectId='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "The Project details has been deleted successfully";
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
            _Qry = "select count(projectid) from projectdetails where projectname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Project name already exist";
            }
            else
            {
                //insert
                // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


                _Qry = " INSERT INTO projectdetails (ProjectName,Status,DateIns,DateMod )VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "', '" + ddlstatus.SelectedValue + "', getdate(),getdate())";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The project details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(projectid)from projectdetails where projectname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' and projectId <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The project name already exist";
            }
            else
            {
                //update
                _Qry = "update projectdetails set projectname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "',Status='" + ddlstatus.SelectedValue + "',DateMod=getdate() where projectId=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The Project details has been Updated successfully";
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
    protected void Linkdownlod_Click(object sender, EventArgs e)
    {
        _Qry = "select UPPER(SUBSTRING(projectName,1,1))+ Lower(SUBSTRING(projectName,2,len(projectName)-1)) as projectName,Status from projectdetails where project_status='Active'";
        if (ddl_project.SelectedValue != "")
        {
            _Qry += "and projectId = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_project.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'";
        }
        _Qry += "order by projectId";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ExportTableData(dt);
    }

    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Project-Details.xls");
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
