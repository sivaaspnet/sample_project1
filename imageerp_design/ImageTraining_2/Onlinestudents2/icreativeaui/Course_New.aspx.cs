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


public partial class superadmin_Course_New : System.Web.UI.Page
{
    string _Qry;

    DataTable dt = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
           fillgrid();
            filldrop();
        }


        Lblfree.Text = "free";

       
    }
   public void fillgrid()
    {
        _Qry = "select UPPER(SUBSTRING(coursename,1,1))+ Lower(SUBSTRING(coursename,2,len(coursename)-1))  as coursename,UPPER(program) as program,course_id,courseType,Coursesegment from img_coursedetails where Status='Active' AND coursename!=''";

        if (ddl_Module.SelectedValue != "")
        {
            _Qry += "and  course_id = '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_Module.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'  or program like '" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(ddl_Module.SelectedValue, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "'";
        }
        _Qry += " order by course_id desc";

        //Response.Write(_Qry);
        //Response.End();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    public void filldrop()
    {
        _Qry = "select * from img_coursedetails where Status='Active'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
        ddl_Module.DataSource = dt;
        ddl_Module.DataTextField = "coursename";
        ddl_Module.DataValueField = "course_id";
        ddl_Module.DataBind();
        ddl_Module.Items.Insert(0, new ListItem("--Select--", ""));
        //}
    }

    private void refresh()
    {
        txt_Coursename.Text = "";
        txt_Coursecode.Text = "";
        ddlyear.SelectedValue = "";
        txtCourseType.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select coursename ,program, year,coursecode,course_id,coursetype,Coursesegment from img_coursedetails where course_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                txt_Coursename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["coursename"].ToString());
                txt_Coursecode.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["program"].ToString());
                ddlyear.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["year"].ToString());
                ddlCourseSep.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["coursetype"].ToString());
                txtCourseType.Text = dt.Rows[0]["Coursesegment"].ToString();
                hiddn_id.Value = dt.Rows[0]["course_id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update img_coursedetails set Status='Deactive' where course_id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "The Course details has been deleted successfully";
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
            _Qry = "select count(course_id) from img_coursedetails where coursename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursename.Text) + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Course name already exist";
            }
            else
            {
                //insert
               // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["username"] + "', NOW())";


                _Qry = " INSERT INTO img_coursedetails (coursename ,program, year,coursecode,Coursesegment,courseType)VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursename.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursecode.Text) + "','" + ddlyear.SelectedValue + "', 'course','" + txtCourseType.Text + "','" + ddlCourseSep.SelectedValue + "')";

              


                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                insertexam_course();
                fillgrid();
                lblmsg1.Text = "The Course Details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(course_id)from img_coursedetails where coursename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursename.Text) + "' and course_id <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Course Name already exist";
            }
            else
            {
                //update
                _Qry = "update img_coursedetails set coursetype='" + ddlCourseSep.SelectedValue + "',Coursesegment='" + txtCourseType.Text + "', coursename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursename.Text) + "',program='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursecode.Text) + "' ,year='" + ddlyear.SelectedValue + "' where course_id=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                updateexam_course();
                fillgrid();
                lblmsg1.Text = "The Course Details has been Updated successfully";
                refresh();
                hiddn_id.Value = "";
            }
        }
    }
    #region insert and update course details in Image Exam
    protected void insertexam_course()
    {
        string coursetype = ""; int courseid = 0;
        if (ddlCourseSep.SelectedValue == "Diploma")
            coursetype = "1";
        else if (ddlCourseSep.SelectedValue == "Certificate")
            coursetype = "2";
        courseid = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, "select course_id from img_coursedetails where coursename='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursename.Text) + "'");
        if (courseid > 0)
        {
            _Qry = "insert into exam_coursedetail(Exam_id,Erp_courseid,Course_name,dateins,datemod) values('" + coursetype + "','" + courseid + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursecode.Text) + "',current_date,current_date)";
            Exam_ctech.Mysqlconn.ExecuteMySqlCommand(_Qry);
        }
    }
    protected void updateexam_course()
    {
        int count = 0;
        count = Exam_ctech.Mysqlconn.ExecuteMysqlScalar("select count(*) from exam_coursedetail where Erp_courseid=" + hiddn_id.Value + "");
        if (count > 0)
        {
            _Qry = "update exam_coursedetail set Course_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Coursecode.Text) + "' where Erp_courseid=" + hiddn_id.Value + "";
            Exam_ctech.Mysqlconn.ExecuteMySqlCommand(_Qry);
        }

    }
    #endregion
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void txt_Coursename_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Linkdownload_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(dt);
    }

    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + "Course_Details.xls");
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
