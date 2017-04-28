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
using System.Text.RegularExpressions;


public partial class superadmin_Software_Details_New : System.Web.UI.Page
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
            Fillsearchmodule();
            Fillsearchsoftware();
        }
    }

    private void Fillsearchmodule()
    {
        _Qry = "select distinct UPPER(SUBSTRING(module_content,1,1))+ Lower(SUBSTRING(module_content,2,len(module_content)-1)) as module_content,module_Id from module_details order by Module_Id Desc";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_content";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }

 public void Fillsearchsoftware()
    {
        _Qry = "select *  from Onlinestudent_Software where status='Enable'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddl_software.DataSource = dt1;
        ddl_software.DataValueField = "Software_Id";
        ddl_software.DataTextField = "Software_Name";
        ddl_software.DataBind();
        ddl_software.Items.Insert(0, new ListItem("Select", ""));
    }
    private void fillgrid()
    {
        _Qry = "select Software_Id,UPPER(SUBSTRING(Software_Name,1,1))+ Lower(SUBSTRING(Software_Name,2,len(Software_Name)-1)) as Software_Name,Noofdays,Status from Onlinestudent_Software where status='Enable'";

        if (ddl_software.SelectedValue != "")
        {
            _Qry += " and  Software_Id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_software.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'";
        }
        _Qry += "order by Software_Name";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
   
   private void refresh()
    {
        txt_SoftwareName.Text = "";
        txtNoDays.Text = "";
        //DDlSoftwareStatus.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Software_Id,Software_Name,Noofdays,Status from Onlinestudent_Software where  Software_Id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {

                string val = dt.Rows[0]["Status"].ToString();

                //Response.Write(val);
                //Response.End();


                txt_SoftwareName.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Software_Name"].ToString());
                //DDlSoftwareStatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());
                txtNoDays.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Noofdays"].ToString());

                hiddn_id.Value = dt.Rows[0]["Software_Id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update Onlinestudent_Software set status='Disable' where Software_Id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "The Software details has been deleted successfully";
            refresh();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();

        _Qry = "Select software_id from module_details where module_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlsearchmodname.SelectedValue) + "'";
        string soft_id = "";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();

            soft_id = dr["software_id"].ToString();

            dr.Close();
        }

        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {
            fillgrid();
        }
        else
        {
            _Qry = "select Software_Id,Replace(Software_Name,'~','''') as Software_Name,Noofdays,Status from Onlinestudent_Software";
            _Qry += " where Software_Id in(" + soft_id + ") And Software_Name = '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedItem.ToString()) + "'  order by Software_Name";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

       

        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            _Qry = "select count(Software_Id) from Onlinestudent_Software where Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_SoftwareName.Text) + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The software name already exist";
            }
            else
            {
                //insert
               // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


                _Qry = " INSERT INTO Onlinestudent_Software (Software_Name ,Noofdays, Status,DateIns,DateMod )VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_SoftwareName.Text) + "','"+MVC.CommonFunction.ReplaceQuoteWithTild(txtNoDays.Text)+"', 'Enable', getdate(),getdate())";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The software details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(Software_Id)from Onlinestudent_Software where Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_SoftwareName.Text) + "' and Software_Id <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The software name already exist";
            }
            else
            {
                //update
                _Qry = "update Onlinestudent_Software set Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_SoftwareName.Text) + "',Noofdays='"+MVC.CommonFunction.ReplaceQuoteWithTild(txtNoDays.Text)+"',Status='Enable',DateMod=getdate() where Software_Id=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The software details has been Updated successfully";
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
     
        _Qry = "select UPPER(SUBSTRING(Software_Name,1,1))+ Lower(SUBSTRING(Software_Name,2,len(Software_Name)-1)) as Software_Name,Noofdays from Onlinestudent_Software where status='Enable'";

        if (ddl_software.SelectedValue != "")
        {
            _Qry += " and  Software_Id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_software.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'";
        }
        _Qry += "order by Software_Name";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ExportTableData(dt);

    }
    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Software-Details.xls");
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
