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

public partial class ImageTraining_2_Onlinestudents2_Courseware : System.Web.UI.Page
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

            fillgrid();
            Fillsearchcourse();
            Button1.Visible = false;
           
        }
    }
    private void Fillsearchcourse()
    {
        _Qry = "select program,course_id from img_coursedetails order by program ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddlsearchcourse.DataSource = dt1;
        ddlsearchcourse.DataValueField = "course_id";
        ddlsearchcourse.DataTextField = "program";
        ddlsearchcourse.DataBind();
        ddlsearchcourse.Items.Insert(0, new ListItem("All", ""));
        ddlsearchmodule.Items.Insert(0, new ListItem("All", ""));
        ddl_software.Items.Insert(0, new ListItem("All", ""));
    }

    private void Fillsearchmodule()
    {
        _Qry = "select module_Id,module_content from Onlinestudent_Coursesoftware where Course_Id='"+ddlsearchcourse.SelectedValue.ToString()+"'  ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlsearchmodule.DataSource = dt1;
        ddlsearchmodule.DataValueField = "module_Id";
        ddlsearchmodule.DataTextField = "module_content";
        ddlsearchmodule.DataBind();
        ddlsearchmodule.Items.Insert(0, new ListItem("All", ""));
    }
    private void Fillsearchsoftware()
    {
        _Qry = "select distinct Software,Software_id  from Submodule_details_new where ModuleId='" + ddlsearchmodule.SelectedValue + "' and  Status='active'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        ddl_software.DataSource = dt1;
        ddl_software.DataValueField = "Software_id";
        ddl_software.DataTextField = "Software";
        ddl_software.DataBind();
        ddl_software.Items.Insert(0, new ListItem("All", ""));
    }
    private void fillgrid()
    {

        _Qry = "select   UPPER(SUBSTRING(a.program,1,1))+ Lower(SUBSTRING(a.program,2,len(a.program)-1)) as program,UPPER(SUBSTRING(c.Module,1,1))+ Lower(SUBSTRING(c.Module,2,len(c.Module)-1)) as Module,UPPER(SUBSTRING(c.Software,1,1))+ Lower(SUBSTRING(c.Software,2,len(c.Software)-1)) as Software,UPPER(SUBSTRING(c.Content,1,1))+ Lower(SUBSTRING(c.Content,2,len(c.Content)-1)) as Content from img_coursedetails a inner join Onlinestudent_Coursesoftware b on a.course_id=b.Course_Id inner join Submodule_details_new c on b.module_Id=c.ModuleId where 1=1 and c.Status='active'";
    
        if (ddlsearchcourse.SelectedValue !="")
        {
            _Qry += " and a.course_id='"+ddlsearchcourse.SelectedValue+"'";
        }
        if (ddlsearchmodule.SelectedValue != "")
        {
            _Qry += " and module_id='" + ddlsearchmodule.SelectedValue + "'";
        }
        if (ddl_software.SelectedValue != "")
        {
            _Qry += " and software_id='" + ddl_software.SelectedValue + "'";
        }
        _Qry += " order by c.Submodule_id asc"; 
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
  

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }



    protected void btnsoftsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
        Button1.Visible = true;
    }
    protected void ddlsearchcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillsearchmodule();
       
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=CourseDetails.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.AllowPaging = false;
        fillgrid();
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }


    protected void ddlsearchmodule_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillsearchsoftware();
    }
}
