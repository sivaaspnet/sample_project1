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

public partial class superadmin_AddCoursedetails : System.Web.UI.Page
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
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        if (Hidn_courseid.Value == "" || Hidn_courseid.Value == null)
        {
            _Qry = "select count(course_id) from img_coursedetails where program='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseprogarm.Text) + "'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Program name already exists";
            }
            else
            {
                _Qry = "insert into img_coursedetails(program,coursename) values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseprogarm.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_coursename.Text) + "')";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "Course added sucessfully";
                refresh();
            }
        }
        else
        {
            //update
            _Qry = "select count(course_id) from img_coursedetails where program='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseprogarm.Text) + "' and course_id<>"+Hidn_courseid.Value+"";
            
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Program name already exists";
            }
            else
            {
                _Qry = "update img_coursedetails set program='"+ MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseprogarm.Text) +"',coursename='"+ MVC.CommonFunction.ReplaceQuoteWithTild(txt_coursename.Text) +"' where course_id="+Hidn_courseid.Value+"";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                refresh();
                lblmsg1.Text = "Course details updated sucessfully";
                fillgrid();
                Hidn_courseid.Value = "";
            }

        }
    }
   private void fillgrid()
    {
        _Qry = "select course_id ,replace(program,'~','''')as program,replace(coursename,'~','''')as coursename from img_coursedetails order by course_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    void refresh()
    {
        txt_coursename.Text = "";
        txt_courseprogarm.Text = "";
       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            lblmsg1.Text = "";
            _Qry = "select course_id,program,coursename from img_coursedetails where course_id="+e.CommandArgument.ToString()+"";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_courseprogarm.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["program"].ToString());
                txt_coursename.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["coursename"].ToString());
               
                Hidn_courseid.Value = e.CommandArgument.ToString();
            }
        }
        if (e.CommandName == "del")
        {
            lblmsg1.Text = "";
            _Qry = "delete from img_coursedetails where course_id="+e.CommandArgument.ToString()+"";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            _Qry = "delete from module_details where course_id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            _Qry = "delete from submodule_details where course_id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            fillgrid();
            lblmsg1.Text = "Course deleted sucessfully";
            refresh();
        }
    }
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
