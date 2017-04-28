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

public partial class superadmin_Submodule_Details_New : System.Web.UI.Page
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

            module_display();

            ddl_software.Items.Insert(0, new ListItem("Select", ""));
            DDlModule.Items.Insert(0, new ListItem("Select", ""));
            DDlSoftware.Items.Insert(0, new ListItem("Select", ""));
            Fillsearchmodule();
            //Fillsearchsoftware();
        }
       
    }

    private void Fillsearchmodule()
    {
        _Qry = "select module_name,module_Id from add_moduledetails where mod_status='Active' order by Module_Id Desc";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_name";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }
   public void Fillsearchsoftware()
    {
        ddl_software.Items.Clear();

        _Qry = "select distinct Software,Software_id  from Submodule_details_new where ModuleId='" + ddlsearchmodname.SelectedValue + "' and status='active'";
       // Response.Write(_Qry);
       DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_software.DataSource = dt1;
        ddl_software.DataValueField = "Software_id";
        ddl_software.DataTextField = "Software";
        ddl_software.DataBind();
        ddl_software.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillgrid()
    {
        _Qry = "select Submodule_id,UPPER(SUBSTRING(Module,1,1))+ Lower(SUBSTRING(Module,2,len(Module)-1)) as Module,UPPER(SUBSTRING(Software,1,1))+ Lower(SUBSTRING(Software,2,len(Software)-1)) as Software,UPPER(SUBSTRING(Content,1,1))+ Lower(SUBSTRING(Content,2,len(Content)-1)) as Content from Submodule_details_new where status='Active' ";
       

        if(ddl_software.SelectedValue != "")
        {
            _Qry += " and Software_id = '" + ddl_software.SelectedValue + "'  ";
        }
        if (ddlsearchmodname.SelectedValue != "")
        {
            _Qry += " And Moduleid='" + ddlsearchmodname.SelectedValue + "' ";
        }
        _Qry += "order by Submodule_id";


    
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Linkdownload.Visible = true;
        }
        else 
            
            if (dt.Rows.Count <= 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Linkdownload.Visible = false;
        }
            
        
        
    }
   
   private void refresh()
    {
        DDlModule.SelectedValue = "";
        DDlSoftware.SelectedValue = "";
        TxtContent.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Submodule_id,ModuleId,Module,Software,Content from Submodule_details_new where Submodule_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {

                //string val = dt.Rows[0]["Status"].ToString();

                //Response.Write(val);
                //Response.End();


                //DDlModule.SelectedItem.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Module"].ToString());
                DDlModule.SelectedValue = dt.Rows[0]["ModuleId"].ToString();
                //DDlSoftware.SelectedItem.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Software"].ToString());
                software_display();
                DDlSoftware.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Software"].ToString());
                TxtContent.Text= MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Content"].ToString());

                hiddn_id.Value = dt.Rows[0]["Submodule_id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update Submodule_details_new set status='Deactive'  where Submodule_id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "The module details has been deleted successfully";
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
            _Qry = "select count(Submodule_id) from Submodule_details_new where ModuleId='" + MVC.CommonFunction.ReplaceQuoteWithTild(DDlModule.SelectedValue) + "' and Software='" + MVC.CommonFunction.ReplaceQuoteWithTild(DDlSoftware.SelectedValue) + "' And Content='"+TxtContent.Text+"'";
            //Response.Write(_Qry);
            //Response.End();
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Content Already exist";
            }
            else
            {
                //insert
                // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";
                _Qry = "select software_id from onlinestudent_software where software_Name='" + DDlSoftware.SelectedValue + "' ";
                DataTable ddt = new DataTable();
                ddt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (ddt.Rows.Count > 0)
                {
                    HiddenField1.Value = ddt.Rows[0]["software_id"].ToString();
                }

                _Qry = " INSERT INTO Submodule_details_new (ModuleId,Module,Software,Content,DateIns,DateMod,Software_id,status)VALUES ('" + DDlModule.SelectedValue + "','" + DDlModule.SelectedItem + "', '" + DDlSoftware.SelectedItem + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(TxtContent.Text) + "',getdate(),getdate(),'" + HiddenField1.Value + "','Active')";


                



                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The module details has been inserted successfully";
                //refresh();
                TxtContent.Text = "";
            }
        }
        else
        {
            _Qry = "select count(Submodule_id) from Submodule_details_new where Module='" + DDlModule.SelectedValue + "' and  Software='" + DDlSoftware.SelectedValue + "' and Submodule_id <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Already exist";
            }
            else
            {
                //update
                _Qry = "select software_id from onlinestudent_software where software_Name='" + DDlSoftware.SelectedValue + "' ";
                DataTable ddt = new DataTable();
                ddt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (ddt.Rows.Count > 0)
                {
                    HiddenField1.Value = ddt.Rows[0]["software_id"].ToString();
                }
                _Qry = "update Submodule_details_new set Module='" + DDlModule.SelectedItem + "',status='Active',Software='" + DDlSoftware.SelectedItem + "',Software_id='" + HiddenField1.Value + "',Content='" + MVC.CommonFunction.ReplaceQuoteWithTild(TxtContent.Text) + "',DateMod=getdate() where Submodule_id=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The module details has been Updated successfully";
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



    private void module_display()
    {

        _Qry = "select module_name,module_Id from add_moduledetails where mod_status='Active' order by Module_Id Desc";
         DataTable dt = new DataTable();
          dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            DDlModule.DataSource = dt;
            DDlModule.DataTextField = "module_name";
            DDlModule.DataValueField = "module_id";
           
            DDlModule.DataBind();
        }
        //DDlModule.Items.Insert(0, new ListItem("Select", ""));
    }

    protected void DDlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        software_display();
    }


    private void software_display()
    {
        DDlSoftware.Items.Clear();

        //_Qry = "Select distinct software,software_id from Submodule_details_new where moduleid='" + DDlModule.SelectedValue + "'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
        //    DDlSoftware.DataSource = dt;
        //    DDlSoftware.DataTextField = "software";
        //    DDlSoftware.DataValueField = "software_id";

        //    DDlSoftware.DataBind();
        //}
        //DDlSoftware.Items.Insert(0, new ListItem("Select", ""));
        _Qry = "Select module_id,software_name,software_id from module_details where module_id='" + DDlModule.SelectedValue + "'";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            string str = dr["software_name"].ToString();
            string[] softwarename = str.Split(',');
            int i = 0;
            string str1 = dr["software_id"].ToString();
            string[] softwareid = str1.Split(',');
            int j = 0;
            foreach (string soft in softwarename)
            {

                DDlSoftware.Items.Insert(i, new ListItem(soft, soft));

                i = i + 1;
            }


            dr.Close();

            DDlSoftware.Items.Insert(0, new ListItem("Select", ""));
        }

    }


    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Submodule_Details_New.aspx");
    }
    protected void Linkdownload_Click(object sender, EventArgs e)
    {
        _Qry = "select UPPER(SUBSTRING(Module,1,1))+ Lower(SUBSTRING(Module,2,len(Module)-1)) as Module,UPPER(SUBSTRING(Software,1,1))+ Lower(SUBSTRING(Software,2,len(Software)-1)) as Software,UPPER(SUBSTRING(Content,1,1))+ Lower(SUBSTRING(Content,2,len(Content)-1)) as Content from Submodule_details_new where 1=1 ";


        if (ddl_software.SelectedValue != "")
        {
            _Qry += " and Software_id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedValue) + "'  ";
        }
        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {
            _Qry += "order by ModuleId";
        }
        else
        {
            _Qry += " And Module='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlsearchmodname.SelectedItem.Text) + "' order by ModuleId";
        }


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ExportTableData(dt);
      
      
    }
    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Submodule-Details.xls");
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
    protected void ddlsearchmodname_SelectedIndexChanged(object sender, EventArgs e)
    {
       Fillsearchsoftware();
      //  software_display1();
    }

    private void software_display1()
    {
        ddl_software.Items.Clear();

        _Qry = "Select module_id,software_name,software_id from module_details where module_id='" + ddlsearchmodname.SelectedValue + "'";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            string str = dr["software_name"].ToString();
            string[] softwarename = str.Split(',');
            int i = 0;
            string str1 = dr["software_id"].ToString();
            string[] softwareid = str1.Split(',');
            int j = 0;
            foreach (string soft in softwarename)
            {

                ddl_software.Items.Insert(i, new ListItem(soft, soft));

                i = i + 1;
            }


            dr.Close();

            ddl_software.Items.Insert(0, new ListItem("Select", ""));
        }

    }
}
