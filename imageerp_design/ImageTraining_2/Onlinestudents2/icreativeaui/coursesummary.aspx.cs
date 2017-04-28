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
using System.Text;
using System.IO;
public partial class superadmin_coursesummary : System.Web.UI.Page
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
            fillcoursename();
            
        }
    }
    
   
   private void fillcoursename()
    {
        _Qry = "select a.course_id,replace(a.coursename,'~','''') as coursename  from img_coursedetails a inner join img_centre_coursefee_details b on a.course_id=b.program and a.status='active' and b.status=1 where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,coursename,b.Program ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlcourse.DataSource = dt;
        ddlcourse.DataValueField = "course_id";
        ddlcourse.DataTextField = "coursename";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("Select", ""));
    } 
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcourse.SelectedIndex > 0)
        {
            GetCourseProgramCode(ddlcourse.SelectedValue.ToString());
            _BindModuleDetails(ddlcourse.SelectedValue.ToString());
            _BindBookDetails(ddlcourse.SelectedValue.ToString());
            _BindProjectDetails(ddlcourse.SelectedValue.ToString());
            _BindCourseContents(ddlcourse.SelectedValue.ToString());
        }
    }
    private void GetCourseProgramCode(string cid)
    {
        _Qry = "select c.program, d.track, d.duration,d.lump_sum,d.instal_amount from img_centre_coursefee_details as d inner join img_coursedetails as c on c.course_id=d.program  and c.status='active' and d.status=1 where c.course_id=" + cid + " and centre_code='" + Session["SA_centre_code"].ToString() + "' order by d.track asc";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblcourse.Text = ddlcourse.SelectedItem.Text.ToString();
            lblprogramcode.Text = dt.Rows[0]["program"].ToString();
            if (dt.Rows[0]["track"].ToString() == "Fast")
            {
                lbltrackfast.Text = dt.Rows[0]["track"].ToString();
                lbldurationfast.Text = dt.Rows[0]["duration"].ToString();
            }

            lbltrack.Text = dt.Rows[1]["track"].ToString();
            lblduration.Text = dt.Rows[1]["duration"].ToString();

            lbllumpsum.Text = dt.Rows[0]["lump_sum"].ToString();
            lblinstallment.Text = dt.Rows[0]["instal_amount"].ToString();
        }
    }
    private void _BindBookDetails(string cid)
    {
        _Qry = "select book_id,Replace(cs.book_content,'~','''') as book_content from  Onlinestudent_Coursebook as cs inner join img_coursedetails c on cs.Course_Id=c.course_id where c.course_id=" + cid + "";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvCourseBook.DataSource = dt;
        gvCourseBook.DataBind();
    }
    private void _BindModuleDetails(string cid)
    {
        _Qry="select coursesoftware_id,module_id,UPPER(SUBSTRING(module_content,1,1))+ Lower(SUBSTRING(module_content,2,len(module_content)-1)) as module_content from Onlinestudent_Coursesoftware where course_id=" + cid + "";
          dt = MVC.DataAccess.ExecuteDataTable(_Qry);
          gvCourseModule.DataSource = dt;
          gvCourseModule.DataBind();
    }
    private void _BindProjectDetails(string cid)
    {
        _Qry = "select  UPPER(SUBSTRING(m.module_content,1,1))+ Lower(SUBSTRING(m.module_content,2,len(m.module_content)-1)) as module_content,p.projectname from Onlinestudent_Coursesoftware as m inner join erp_moduleproject as p on m.module_id=p.moduleid where m.course_id=" + cid + " order by m.module_id";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvModuleProject.DataSource = dt;
        gvModuleProject.DataBind();
    }
    private void _BindCourseContents(string cid)
    {
        _Qry = "select UPPER(SUBSTRING(c.Module,1,1))+ Lower(SUBSTRING(c.Module,2,len(c.Module)-1)) as Module,UPPER(SUBSTRING(c.Software,1,1))+ Lower(SUBSTRING(c.Software,2,len(c.Software)-1)) as Software,UPPER(SUBSTRING(c.Content,1,1))+ Lower(SUBSTRING(c.Content,2,len(c.Content)-1)) as Content from img_coursedetails a inner join Onlinestudent_Coursesoftware b on a.course_id=b.Course_Id inner join Submodule_details_new c on b.module_Id=c.ModuleId where 1=1 and c.Status='active' and a.course_id=" + cid + "  order by c.Submodule_id ";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Label5.Text = dt.Rows.Count.ToString();
        gvCourseContent.DataSource = dt;
        gvCourseContent.DataBind();
    }
    protected void gvCourseContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourseContent.PageIndex = e.NewPageIndex;
        _BindCourseContents(ddlcourse.SelectedValue.ToString());
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=CourseSummary.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

        divSummary.RenderControl(hw);

        Response.Write(sw.ToString());
        Response.End();
    }
    public override void  VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}
