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
            ddl_module.Items.Insert(0, new ListItem("Select", ""));
            //Fillsearchmodule();
        }
    }
    private void Fillsearchcourse()
    {
        _Qry = "select program,course_id from img_coursedetails where status='Active'  order by course_id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlsearchcourse.DataSource = dt1;
        ddlsearchcourse.DataValueField = "course_id";
        ddlsearchcourse.DataTextField = "program";
        ddlsearchcourse.DataBind();
        ddlsearchcourse.Items.Insert(0, new ListItem("Select", ""));
    }
    private void Fillsearchmodule()
    {
        ddl_module.Items.Clear();
        _Qry = "select * from Onlinestudent_Coursesoftware where course_id='" +ddlsearchcourse.SelectedValue+ "' ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_module.DataSource = dt1;
        ddl_module.DataValueField = "module_id";
        ddl_module.DataTextField = "module_content";
        ddl_module.DataBind();
        ddl_module.Items.Insert(0, new ListItem("Select", ""));
    }
    private void fillgrid()
    {
        //_Qry = "select CourseSoftware_Id,Course_Name,s.Software_Name from Onlinestudent_Coursesoftware cs inner join Onlinestudent_Course c on  c.Course_Id=cs.Course_Id inner join Onlinestudent_Software s on s.Software_Id=cs.Software_Id where  Software_Name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by CourseSoftware_Id desc";



        //_Qry = "select CourseSoftware_Id,Replace(Course_Name,'~','''') as Course_Name,Replace(Course_Code,'~','''') as Course_Code,Replace(s.Software_Name,'~','''') as Software_Name from Onlinestudent_Coursesoftware cs inner join Onlinestudent_Course c on c.Course_Id=cs.Course_Id inner join Onlinestudent_Software s on s.Software_Id=cs.Software_Id ";
        //_Qry+=" where  c.Course_Name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' And s.Software_Name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsoftsearch.Text) + "%'  order by CourseSoftware_Id";

        _Qry = "Select CourseSoftware_Id,UPPER(SUBSTRING(coursename,1,1))+ Lower(SUBSTRING(coursename,2,len(coursename)-1)) as coursename,Replace(program,'~','''') as program,";
        _Qry += "module_id,UPPER(SUBSTRING(cs.module_content,1,1))+ Lower(SUBSTRING(cs.module_content,2,len(cs.module_content)-1)) as module_content from ";
        _Qry += "Onlinestudent_Coursesoftware as cs inner join ";
        _Qry += "img_coursedetails c on cs.Course_Id=c.course_id where c.status='Active' ";

        if (ddlsearchcourse.SelectedValue != "")
        {
            _Qry += " And program = '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlsearchcourse.SelectedItem.Text) + "'";
          
        }
        if (ddl_module.SelectedValue != "")
        {
            _Qry += " and module_id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_module.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'  ";
        }
        _Qry += " order by coursename";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

   
    private void listboxitems()
    {
        _Qry = "select distinct module_id,module_name from Add_moduledetails  where mod_status='Active'   order by module_id ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {

            //if (Listbox_Software.DataValueField !="" && Listbox_Software.SelectedValue != null)
            //{

                lblsoftname.Text = Listbox_Software.DataTextField;
            //}



            Listbox_Software.DataSource = dt;
            Listbox_Software.DataTextField = "module_name";

            Listbox_Software.DataValueField = "module_Id";

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
        _Qry = "select Replace(coursename,'~','''') as coursename,Replace(program,'~','''') as program,course_id from img_coursedetails where Status='Active' order by course_id";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            ddl_course.DataSource = dt;
            ddl_course.DataTextField = "coursename";
            ddl_course.DataValueField = "course_id";
            ddl_course.DataBind();
            ddl_course.Items.Insert(0, new ListItem("--Select--", ""));
        }
       


    }

  
   
  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select CourseSoftware_Id,Course_Id,module_Id,module_content from Onlinestudent_Coursesoftware where CourseSoftware_Id =" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                ddl_course.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Course_Id"].ToString());

                //string sw = dt.Rows[0]["module_Id"].ToString();
                //string sw1 = sw;
                //string[] strSplitArr = sw1.Split(',');

                //foreach (ListItem list in Listbox_Software.Items)
                //{
                //    list.Selected = false;
                //}

                //for (int k = 0; k < strSplitArr.Length; k++)
                //{
                //    if (strSplitArr[k] != "")
                //    {

                //        swa = strSplitArr[k].ToString();

                //        foreach (ListItem list in Listbox_Software.Items)
                //        {
                //            ListItem lst = new ListItem();

                //            lst = Listbox_Software.Items.FindByValue(swa);

                //            lst.Selected = true;
                //        }
                //    }

                //}

                Listbox_Software.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["module_Id"].ToString());


                hiddn_id.Value = dt.Rows[0]["CourseSoftware_Id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from Onlinestudent_Coursesoftware where CourseSoftware_Id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            lblmsg1.Text = "The Module details has been deleted successfully";
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
                            _Qry = "Select Count(*) from Onlinestudent_Coursesoftware where Course_Id=" + ddl_course.SelectedValue + " And module_id=" + Listbox_Software.Items[n].Value + "";

                            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            if (count == 0)
                            {
                                xx = xx + 1;
                                _Qry = "insert into Onlinestudent_Coursesoftware(Course_Id,module_id,module_content,DateIns,DateMod)values(" + ddl_course.SelectedValue + "," + Listbox_Software.Items[n].Value + ",'" + Listbox_Software.Items[n].Text + "',getdate(),getdate())";

                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                lblmsg1.Text = "The Module details has been inserted successfully";
                                fillgrid();
                            }

                        }
                    }

                    Refresh();

                    if (xx == 0)
                    {
                        lblmsg1.Text = "The Module details Already Exists";
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

                        _Qry = "Delete from Onlinestudent_Coursesoftware where CourseSoftware_Id=" + hiddn_id.Value + "";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                        _Qry = "Select Count(*) from Onlinestudent_Coursesoftware where Course_Id=" + ddl_course.SelectedValue + " And module_id=" + Listbox_Software.Items[n].Value + "";

                            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            if (count == 0)
                            {
                                yy = yy + 1;
                                //_Qry = "update Onlinestudent_Coursesoftware set Course_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "',Software_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(Listbox_Software.Items[n].Value) + "',Software_Name='"+Listbox_Software.Items[n].Text+"',DateMod=getdate() where CourseSoftware_Id=" + hiddn_id.Value + "";
                                _Qry = "insert into Onlinestudent_Coursesoftware(Course_Id,module_id,module_content,DateIns,DateMod)values(" + ddl_course.SelectedValue + "," + Listbox_Software.Items[n].Value + ",'" + Listbox_Software.Items[n].Text + "',getdate(),getdate())";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                lblmsg1.Text = "The Module details has been Updated successfully";

                                fillgrid();
                            }
                    }
                }
                //Response.End();
                    Refresh();
                    hiddn_id.Value = "";

                    if (yy == 0)
                    {
                        lblmsg1.Text = "The Module details Already Exists";
                    }
                }
            }
    



                //if (hiddn_id.Value == "" || hiddn_id.Value == null)
        //{
        //    int i;
        //    for (i = 0; i <= Listbox_Software.Items.Count - 1; i++)
        //    {
        //        if (Listbox_Software.Items[i].Selected)
        //        {
        //            if (os2 == "")
        //            {
        //                os2 = Listbox_Software.Items[i].Text;
        //            }
        //            else
        //            {
        //                os2 = os2 + "," + Listbox_Software.Items[i].Text;
        //            }

        //        }
        //    }
        //    _Qry = "select Count(*) from Onlinestudent_Coursesoftware where Course_Id=" + ddl_course.SelectedValue + "";
        //    //Response.Write(_Qry);
        //    //Response.End();
        //    int count;
        //    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        //    if (count > 0)
        //    {
        //        lblmsg1.Text = "The course details already exist";
        //        //ddlcoursename.SelectedValue = "";

        //        ddl_course.SelectedValue = "";
        //        //txtNoDays.Text = "";
        //    }
        //    else
        //    {
        //        int n;
        //        for (n = 0; n <= Listbox_Software.Items.Count - 1; n++)
        //        {
        //            if (Listbox_Software.Items[n].Selected)
        //            {
        //                if (os == "")
        //                {
        //                    os = Listbox_Software.Items[n].Value;
        //                }
        //                else
        //                {
        //                    os = os + "," + Listbox_Software.Items[n].Value;
        //                }

        //            }
        //            //}
        //        }
        //        int j;
        //        for (j = 0; j <= Listbox_Software.Items.Count - 1; j++)
        //        {
        //            if (Listbox_Software.Items[j].Selected)
        //            {
        //                if (os1 == "")
        //                {
        //                    os1 = Listbox_Software.Items[j].Text;
        //                }
        //                else
        //                {
        //                    os1 = os1 + "," + Listbox_Software.Items[j].Text;
        //                }
        //            }
        //        }

        //        _Qry = "insert into Onlinestudent_Coursesoftware(Course_Id,module_id,module_content,DateIns,DateMod) values (" + ddl_course.SelectedValue + ",'" + os + "','" + os1 + "',getdate(),getdate())";
        //        //Response.Write(_Qry);
        //        //Response.End();

        //        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //        fillgrid();
        //        //Fillsearchmodule();
        //        //fillsearchcourse();
        //        lblmsg1.Text = "Module details has been added successfully";
        //        //ddlcoursename.SelectedValue = "";
        //        //ddl_course.SelectedValue = "";
        //        _Qry = "select module_Id,module_content from module_details order by Module_Id";
        //        //Response.Write(_Qry);
        //        //Response.End();
        //        DataTable dt = new DataTable();
        //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //        //if (dt.Rows.Count > 0)
        //        //{
        //        Listbox_Software.DataSource = dt;
        //        Listbox_Software.DataValueField = "module_Id";
        //        Listbox_Software.DataTextField = "module_content";
        //        Listbox_Software.DataBind();
        //        ddl_course.SelectedValue = "";
        //        //txtNoDays.Text = "";

        //        foreach (ListItem list in Listbox_Software.Items)
        //        {
        //            list.Selected = false;
        //        }
        //    }
        //}

        //else
        //{
        //    int m;
        //    for (m = 0; m <= Listbox_Software.Items.Count - 1; m++)
        //    {
        //        if (Listbox_Software.Items[m].Selected)
        //        {
        //            if (os2 == "")
        //            {
        //                os2 = Listbox_Software.Items[m].Text;
        //            }
        //            else
        //            {
        //                os2 = os2 + "," + Listbox_Software.Items[m].Text;
        //            }
        //        }
        //    }
        //    _Qry = "select count(*) from Onlinestudent_Coursesoftware where module_content='" + os2 + "' and course_id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "' and CourseSoftware_Id <> " + hiddn_id.Value + "";

        //    int count;
        //    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        //    if (count > 0)
        //    {
        //        lblmsg1.Text = "The module details already exist";
        //        //ddl_course.SelectedValue = "";
        //        ddl_course.SelectedValue = "";
        //        //txtNoDays.Text = "";
        //        hiddn_id.Value = "";
        //    }
        //    else
        //    {
        //        int i;
        //        for (i = 0; i <= Listbox_Software.Items.Count - 1; i++)
        //        {
        //            if (Listbox_Software.Items[i].Selected)
        //            {
        //                if (os == "")
        //                {
        //                    os = Listbox_Software.Items[i].Value;
        //                }
        //                else
        //                {
        //                    os = os + "," + Listbox_Software.Items[i].Value;
        //                }
        //            }
        //        }
        //        int j;
        //        for (j = 0; j <= Listbox_Software.Items.Count - 1; j++)
        //        {
        //            if (Listbox_Software.Items[j].Selected)
        //            {
        //                if (os1 == "")
        //                {
        //                    os1 = Listbox_Software.Items[j].Text;
        //                }
        //                else
        //                {
        //                    os1 = os1 + "," + Listbox_Software.Items[j].Text;
        //                }
        //            }
        //        }

        //        _Qry = "update Onlinestudent_Coursesoftware set  module_id='" + os + "',module_content='" + os1 + "',course_id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "' where CourseSoftware_Id = " + hiddn_id.Value + "";

        //        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //        fillgrid();
        //        //Fillsearchmodule();
        //        ddl_course.SelectedValue = "";
        //        //txtNoDays.Text = "";
        //        hiddn_id.Value = "";
        //        //ddl_course.SelectedValue = "";
        //        listboxitems();
        //        foreach (ListItem list in Listbox_Software.Items)
        //        {
        //            list.Selected = false;
        //        }
        //        lblmsg1.Text = "The module details has been updated successfully";
        //        fillgrid();
        //    }

        //}
    
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
        _Qry = "Select UPPER(SUBSTRING(coursename,1,1))+ Lower(SUBSTRING(coursename,2,len(coursename)-1)) as coursename,";
        _Qry += "UPPER(SUBSTRING(cs.module_content,1,1))+ Lower(SUBSTRING(cs.module_content,2,len(cs.module_content)-1)) as module_content from ";
        _Qry += "Onlinestudent_Coursesoftware as cs inner join ";
        _Qry += "img_coursedetails c on cs.Course_Id=c.course_id where c.status='Active' ";

        if (ddlsearchcourse.SelectedValue != "")
        {
            _Qry += " And program = '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlsearchcourse.SelectedItem.Text) + "'";

        }
        if (ddl_module.SelectedValue != "")
        {
            _Qry += " and module_id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_module.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'  ";
        }
        _Qry += " order by coursename";

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
        Response.AppendHeader("Content-Disposition", "attachment;filename=Assignmodule-Details.xls");
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
    protected void ddlsearchcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillsearchmodule();
    }
}
