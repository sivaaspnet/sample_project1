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

public partial class Onlinestudents2_superadmin_module_details : System.Web.UI.Page
{
    string _Qry, os="", os1="", swa, os2="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        
        if (!IsPostBack)
        {
            //fillcoursedropdown();
            //fillsoftwarelist();
            //fillsearchcoursedropdown();
            //fillsearchcourse();
            //ddlcourse();
            fillgrid();
            fillmodule();
            //ddl_Module.Items.Insert(0, new ListItem("--Select--", ""));
            Fillsearchmodule();
            fillsoftware();
            
        }
    }

    private void fillmodule()
    {
        _Qry = "select Replace(Module_Name,'~','''') as Module_Name,Module_Id from Add_moduledetails where mod_status='Active' order by Module_Id";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
            ddl_Module.DataSource = dt;
            ddl_Module.DataTextField = "Module_Name";
            ddl_Module.DataValueField = "Module_Id";
            ddl_Module.DataBind();
            ddl_Module.Items.Insert(0, new ListItem("--Select--", ""));
        //}
    }

    private void fillgrid()
    {
        //_Qry = "select a.module_Id,a.software_name,replace(a.module_content,'~','''')as module_content,b.program from module_details a inner join img_coursedetails b on a.course_id=b.course_id";

        _Qry = "Select Module_Id,Software_Id,UPPER(SUBSTRING(Software_name,1,1))+ Lower(SUBSTRING(Software_name,2,len(Software_name)-1)) as Software_Name,UPPER(SUBSTRING(Module_Content,1,1))+ Lower(SUBSTRING(Module_Content,2,len(Module_Content)-1)) as Module_Content From module_details where Software_Name like '%%' ";

        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {
            
        }
        else
        {
            _Qry = _Qry + " and Module_id = '" + ddlsearchmodname.SelectedValue + "'";
        }
        //if (ddlsearchcourse_name.SelectedValue != "")
        //{
        //    _Qry = _Qry + " And Course_Id = '" + ddlsearchcourse_name.SelectedValue + "'";
        //}

        _Qry = _Qry + " order by module_id ";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //private void ddlcourse()
    //{
    //    _Qry = "select Replace(Course_Name,'~','''') as Course_Name,Replace(Course_Code,'~','''') as Course_Code,Course_Id from onlinestudent_course order by COurse_Id";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    if (dt.Rows.Count > 0)
    //    {
    //        ddl_course.DataSource = dt;
    //        ddl_course.DataTextField = "Course_Name";
    //        ddl_course.DataValueField = "Course_Id";
    //        ddl_course.DataBind();
    //        ddl_course.Items.Insert(0, new ListItem("--Select--", ""));
    //    }
    //}

    //private void fillsearchcourse()
    //{
    //    _Qry = "select Replace(Course_Name,'~','''') as Course_Name,Replace(Course_Code,'~','''') as Course_Code,Course_Id from onlinestudent_course order by COurse_Id";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    if (dt.Rows.Count > 0)
    //    {
    //        ddlsearchcourse_name.DataSource = dt;
    //        ddlsearchcourse_name.DataTextField = "Course_Name";
    //        ddlsearchcourse_name.DataValueField = "Course_Id";
    //        ddlsearchcourse_name.DataBind();
    //        ddlsearchcourse_name.Items.Insert(0, new ListItem("--Select--", ""));
    //    }
    //}

    private void fillsoftwarelist()
    {
        _Qry = "SELECT software_Id,Replace(software_name,'~','''') as Software_Name from onlinestudent_software where status='Enable' ORDER by software_Id";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        listsoftwares.DataSource = dt;
        listsoftwares.DataValueField = "software_id";
        listsoftwares.DataTextField = "software_name";
        listsoftwares.DataBind(); 
    }
    private void insertmodule()
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            int i;
            for (i = 0; i <= listsoftwares.Items.Count - 1; i++)
            {
                    if (listsoftwares.Items[i].Selected)
                    {
                        if (os2 == "")
                        {
                            os2 = listsoftwares.Items[i].Text;
                        }
                        else
                        {
                            os2 = os2 + "," + listsoftwares.Items[i].Text;
                        }
                        
                    }
            }
            _Qry = "select count(module_id) from module_details where module_content='" +MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedValue) + "'";
            //Response.Write(_Qry);
            //Response.End();
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The module details already exist";
                //ddlcoursename.SelectedValue = "";
               
                ddl_Module.SelectedValue = "";
                //txtNoDays.Text = "";
            }
            else
            {
                int n; 
                for (n = 0; n <= listsoftwares.Items.Count - 1; n++)
                {
                        if (listsoftwares.Items[n].Selected)
                        {
                            if (os == "")
                            {
                                os = listsoftwares.Items[n].Value;
                            }
                            else
                            {
                                os = os + "," + listsoftwares.Items[n].Value;
                            }
                            
                        }
                    //}
                }
                int j;
                for (j = 0; j <= listsoftwares.Items.Count - 1; j++)
                {
                        if (listsoftwares.Items[j].Selected)
                        {
                            if (os1 == "")
                            {
                                os1 = listsoftwares.Items[j].Text;
                            }
                            else
                            {
                                os1 = os1 + "," + listsoftwares.Items[j].Text;
                            }
                        }
                }

                _Qry = "insert into module_details(software_id,software_name,module_content,dateins,module_id)values('" + os + "','" + os1 + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedItem.ToString()) + "',getdate(),'" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedValue) + "')";
                //Response.Write(_Qry);
                //Response.End();
         
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                Fillsearchmodule();
                //fillsearchcourse();
                lblmsg1.Text = "Module details has been added successfully";
                //ddlcoursename.SelectedValue = "";
                //ddl_course.SelectedValue = "";
                //_Qry = "Select Software_Id,Software_Name From Onlinestudent_Coursesoftware";
                ////Response.Write(_Qry);
                ////Response.End();
                //DataTable dt = new DataTable();
                //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                ////if (dt.Rows.Count > 0)
                ////{
                //listsoftwares.DataSource = dt;
                //listsoftwares.DataValueField = "Software_Id";
                //listsoftwares.DataTextField = "Software_Name";
                //listsoftwares.DataBind();
                //ddl_Module.SelectedValue = "";
                //txtNoDays.Text = "";

                foreach (ListItem list in listsoftwares.Items)
                {
                    list.Selected = false;
                }
            }
        }
        else
        {
            int m;
            for (m = 0; m <= listsoftwares.Items.Count - 1; m++)
            {
                    if (listsoftwares.Items[m].Selected)
                    {
                        if (os2 == "")
                        {
                            os2 = listsoftwares.Items[m].Text;
                        }
                        else
                        {
                            os2 = os2 + "," + listsoftwares.Items[m].Text;
                        }
                    }
            }
            //_Qry = "select count(module_id)from module_details where software_name='" + os2 + "' and module_content='" +MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedValue) + "' and module_id <> " + hiddn_id.Value + "";


            _Qry = "select count(module_id)from module_details where  module_content='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedValue) + "' and module_id <> " + hiddn_id.Value + "";


            //Response.Write(_Qry);
            //Response.End();

            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The module details already exist";
                //ddl_course.SelectedValue = "";
                ddl_Module.SelectedValue = "";
                //txtNoDays.Text = "";
                hiddn_id.Value = "";
            }
            else
            {
                int i;
                for (i = 0; i <= listsoftwares.Items.Count - 1; i++)
                {
                        if (listsoftwares.Items[i].Selected)
                        {
                            if (os == "")
                            {
                                os = listsoftwares.Items[i].Value;
                            }
                            else
                            {
                                os = os + "," + listsoftwares.Items[i].Value;
                            }
                        }
                }
                int j;
                for (j = 0; j <= listsoftwares.Items.Count - 1; j++)
                {
                        if (listsoftwares.Items[j].Selected)
                        {
                            if (os1 == "")
                            {
                                os1 = listsoftwares.Items[j].Text;
                            }
                            else
                            {
                                os1 = os1 + "," + listsoftwares.Items[j].Text;
                            }
                        }
                }

                _Qry = "update module_details set  software_id='" + os + "',software_name='"+os1+"',module_content='" +MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Module.SelectedItem.ToString()) + "' where module_id = " + hiddn_id.Value + "";
              
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                Fillsearchmodule();
                //fillsearchcourse();
                //ddlcoursename.SelectedValue = "";
                //ddl_course.SelectedValue = "";
        //        _Qry = "Select Software_Id,Software_Name From Onlinestudent_Coursesoftware where Course_ID='"+ddl_course.SelectedValue+"'";
        ////Response.Write(_Qry);
        ////Response.End();
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ////if (dt.Rows.Count > 0)
        ////{
        //    listsoftwares.DataSource = dt;
        //    listsoftwares.DataValueField = "Software_Id";
        //    listsoftwares.DataTextField = "Software_Name";
        //    listsoftwares.DataBind();
            ddl_Module.SelectedValue = "";
                //txtNoDays.Text = "";
                hiddn_id.Value = "";
                //ddl_course.SelectedValue = "";
                foreach (ListItem list in listsoftwares.Items)
                {
                    list.Selected = false;
                }
                lblmsg1.Text = "The module details has been updated successfully";
                fillgrid();
            }

        }
    
    }

    private void Fillsearchmodule()
    {
        _Qry = "select distinct module_id,module_name from Add_moduledetails  where mod_status='Active'   order by module_id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_id";
        ddlsearchmodname.DataTextField = "module_name";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillsoftware()
    {
        _Qry = "Select Software_Id,Software_Name From Onlinestudent_Software Group By Software_Id,Software_Name";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
        listsoftwares.DataSource = dt;
        listsoftwares.DataValueField = "Software_Id";
        listsoftwares.DataTextField = "Software_Name";
        listsoftwares.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        insertmodule();
        ddl_Module.SelectedValue = "";
        foreach (ListItem list in listsoftwares.Items)
        {
            list.Selected = false;
        }
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            
            _Qry = "select module_Id,software_id,module_content from module_details where module_Id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
               // ddlcoursename.SelectedValue = dt.Rows[0]["course_id"].ToString();
               

               //ddl_course.SelectedValue = dt.Rows[0]["Course_ID"].ToString();
               //_Qry = "Select Software_Id,Software_Name From Onlinestudent_Coursesoftware where Course_ID=" + ddl_course.SelectedValue + "";
               ////Response.Write(_Qry);
               ////Response.End();
               //DataTable dt12 = new DataTable();
               //dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
               //if (dt12.Rows.Count > 0)
               //{
               //    listsoftwares.DataSource = dt12;
               //    listsoftwares.DataValueField = "Software_Id";
               //    listsoftwares.DataTextField = "Software_Name";
               //    listsoftwares.DataBind();
               //}
               string sw = dt.Rows[0]["software_id"].ToString();
               string sw1 = sw;
               string[] strSplitArr = sw1.Split(',');

               foreach (ListItem list in listsoftwares.Items)
               {
                   list.Selected = false;
               }

               for (int k = 0; k < strSplitArr.Length; k++)
               {
                   if (strSplitArr[k] != "")
                   {

                       swa = strSplitArr[k].ToString();

                       foreach (ListItem list in listsoftwares.Items)
                       {
                           ListItem lst = new ListItem();

                           lst = listsoftwares.Items.FindByValue(swa);

                           lst.Selected = true;
                       }
                   }

               }
                ddl_Module.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["module_id"].ToString());
                //txtNoDays.Text = dt.Rows[0]["Numberofdays"].ToString();
                hiddn_id.Value = dt.Rows[0]["module_Id"].ToString();
                lblmsg1.Text = "";

            }

        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from module_details where module_Id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            //_Qry = "delete from submodule_details where module_Id=" + e.CommandArgument.ToString() + "";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            lblmsg1.Text = "The Module details has been deleted successfully";
            //ddlsearchcourse_name.SelectedValue = "";
            Fillsearchmodule();
            fillgrid();
            Fillsearchmodule();
            //fillsearchcourse();

        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    //protected void ddlsearchcourse_name_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    _Qry = "select module_content,module_Id from module_details where course_id='" + ddlsearchcourse_name.SelectedValue + "'";
    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

    //    ddlsearchmodname.DataSource = dt1;
    //    ddlsearchmodname.DataValueField = "module_Id";
    //    ddlsearchmodname.DataTextField = "module_content";
    //    ddlsearchmodname.DataBind();
    //    ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    //}
    //protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    _Qry = "Select Software_Id,Software_Name From Onlinestudent_Coursesoftware where Course_ID='"+ddl_course.SelectedValue+"'";
    //    //Response.Write(_Qry);
    //    //Response.End();
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    //if (dt.Rows.Count > 0)
    //    //{
    //        listsoftwares.DataSource = dt;
    //        listsoftwares.DataValueField = "Software_Id";
    //        listsoftwares.DataTextField = "Software_Name";
    //        listsoftwares.DataBind(); 
    //    //}
    //}
    protected void ddlsearchcourse_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void Linkdownload_Click(object sender, EventArgs e)
    {
        _Qry = "Select UPPER(SUBSTRING(Software_name,1,1))+ Lower(SUBSTRING(Software_name,2,len(Software_name)-1)) as Software_Name,UPPER(SUBSTRING(Module_Content,1,1))+ Lower(SUBSTRING(Module_Content,2,len(Module_Content)-1)) as Module_Content From module_details where Software_Name like '%%' ";

        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {

        }
        else
        {
            _Qry = _Qry + " and Module_id = '" + ddlsearchmodname.SelectedValue + "'";
        }
        //if (ddlsearchcourse_name.SelectedValue != "")
        //{
        //    _Qry = _Qry + " And Course_Id = '" + ddlsearchcourse_name.SelectedValue + "'";
        //}

        _Qry = _Qry + " order by module_id ";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ExportTableData(dt);
    }

    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Assignsoftware-Details.xls");
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
