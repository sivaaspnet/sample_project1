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

public partial class superadmin_Moduledetails : System.Web.UI.Page
{
    string _Qry;
    string os = "", os1 = "", swa, os2 = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            ddlcourse();
            listboxitems();
            Fillsearchcourse();
            fillgrid();
        }
    }
    private void Fillsearchcourse()
    {
        _Qry = "select distinct module_id,module_name from Add_moduledetails  where mod_status='Active'   order by module_id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddlsearchcourse.DataSource = dt1;
        ddlsearchcourse.DataValueField = "module_id";
        ddlsearchcourse.DataTextField = "module_name";
        ddlsearchcourse.DataBind();
        ddlsearchcourse.Items.Insert(0, new ListItem("Select", ""));
    }
    private void fillgrid()
    {

        _Qry = @"SELECT distinct add_moduledetails.Module_Id
,UPPER(SUBSTRING(add_moduledetails.module_name,1,1))+ Lower(SUBSTRING(add_moduledetails.module_name,2,len(add_moduledetails.module_name)-1)) as module_name,UPPER(SUBSTRING(erp_moduleproject.projectname,1,1))+ Lower(SUBSTRING(erp_moduleproject.projectname,2,len(erp_moduleproject.projectname)-1)) as projectname, erp_moduleproject.id

FROM add_moduledetails INNER JOIN
  erp_moduleproject ON add_moduledetails.Module_Id = erp_moduleproject.moduleid";
  
        if (ddlsearchcourse.SelectedValue == "" || ddlsearchcourse.SelectedValue == null)
        {
        }
        else
        {
            _Qry += "  where add_moduledetails.Module_Id='" + ddlsearchcourse.SelectedValue + "' ";
        }
      
       DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Linkdownload.Visible = false;
        }
     
    }

   
    private void listboxitems()
    {
        _Qry = "select projectId,projectname from projectdetails where project_status='Active' order by projectId ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {

            //if (Listbox_Software.DataValueField !="" && Listbox_Software.SelectedValue != null)
            //{

                lblsoftname.Text = Listbox_Software.DataTextField;
            //}



            Listbox_Software.DataSource = dt;
            Listbox_Software.DataTextField = "projectname";

            Listbox_Software.DataValueField = "projectId";

            Listbox_Software.DataBind();
        }
        
    }

    private void clear()
    {

        ddl_course.SelectedValue = "";
        for (int i = 0; i < Listbox_Software.Items.Count; i++)
        {
            Listbox_Software.Items[i].Selected = false;
        }


    }


    private void Refresh()
    {
        ddl_course.SelectedValue = "";
        for (int i = 0; i < Listbox_Software.Items.Count; i++)
        {
            Listbox_Software.Items[i].Selected = false;
        }
    }


    private void ddlcourse()
    {
        _Qry = "select distinct module_id,module_name from Add_moduledetails  where mod_status='Active'   order by module_id ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            ddl_course.DataSource = dt;
            ddl_course.DataTextField = "module_name";
            ddl_course.DataValueField = "module_id";
            ddl_course.DataBind();
            ddl_course.Items.Insert(0, new ListItem("--Select--", ""));
        }
       


    }

  
   
  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Id,moduleId,projectId,projectname from erp_moduleproject where Id =" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                ddl_course.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["moduleId"].ToString());
                Listbox_Software.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["projectId"].ToString());
                hiddn_id.Value = dt.Rows[0]["Id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from erp_moduleproject where Id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            lblmsg1.Text = "The Project details has been deleted successfully";
            fillgrid();
            Refresh();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
            {
                int xx = 0;
                    for (int n = 0; n < Listbox_Software.Items.Count; n++)
                    {
                        if (Listbox_Software.Items[n].Selected)
                        {
                            _Qry = "Select Count(*) from erp_moduleproject where moduleId=" + ddl_course.SelectedValue + " And projectid=" + Listbox_Software.Items[n].Value + "";

                            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            if (count == 0)
                            {
                                xx = xx + 1;
                                _Qry = "insert into erp_moduleproject(moduleId,projectid,projectname,DateIns,DateMod)values(" + ddl_course.SelectedValue + "," + Listbox_Software.Items[n].Value + ",'" + Listbox_Software.Items[n].Text + "',getdate(),getdate())";

                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                lblmsg1.Text = "The project details has been inserted successfully";
                                fillgrid();
                            }

                        }
                    }
                    Refresh();

                    if (xx == 0)
                    {
                        lblmsg1.Text = "The project details Already Exists";
                    }

                }

            else
            {
                int yy = 0;
                    //update
                for (int n = 0; n < Listbox_Software.Items.Count; n++)
                {
                    if (Listbox_Software.Items[n].Selected)
                    {

                        _Qry = "Delete from erp_moduleproject where Id=" + hiddn_id.Value + "";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                        _Qry = "Select Count(*) from erp_moduleproject where moduleId=" + ddl_course.SelectedValue + " And projectid=" + Listbox_Software.Items[n].Value + "";

                            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            if (count == 0)
                            {
                                yy = yy + 1;
                                //_Qry = "update Onlinestudent_Coursesoftware set Course_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "',Software_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(Listbox_Software.Items[n].Value) + "',Software_Name='"+Listbox_Software.Items[n].Text+"',DateMod=getdate() where CourseSoftware_Id=" + hiddn_id.Value + "";
                                _Qry = "insert into erp_moduleproject(moduleId,projectid,projectname,DateIns,DateMod)values(" + ddl_course.SelectedValue + "," + Listbox_Software.Items[n].Value + ",'" + Listbox_Software.Items[n].Text + "',getdate(),getdate())";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                lblmsg1.Text = "The project details has been Updated successfully";

                                fillgrid();
                            }
                    }
                }
                //Response.End();
                    Refresh();
                    hiddn_id.Value = "";

                    if (yy == 0)
                    {
                        lblmsg1.Text = "The project details Already Exists";
                    }
                }
            }
    

    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }



    protected void btnsoftsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Linkdownload_Click(object sender, EventArgs e)
    {

        _Qry = @"SELECT UPPER(SUBSTRING(add_moduledetails.module_name,1,1))+ Lower(SUBSTRING(add_moduledetails.module_name,2,len(add_moduledetails.module_name)-1)) as module_name,UPPER(SUBSTRING(erp_moduleproject.projectname,1,1))+ Lower(SUBSTRING(erp_moduleproject.projectname,2,len(erp_moduleproject.projectname)-1)) as projectname
FROM add_moduledetails INNER JOIN
  erp_moduleproject ON add_moduledetails.Module_Id = erp_moduleproject.moduleid";

        if (ddlsearchcourse.SelectedValue == "" || ddlsearchcourse.SelectedValue == null)
        {
        }
        else
        {
            _Qry += "  where add_moduledetails.Module_Id='" + ddlsearchcourse.SelectedValue + "' ";
        }

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        ExportTableData(dt);

    }
    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Assignproject-Details.xls");
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
