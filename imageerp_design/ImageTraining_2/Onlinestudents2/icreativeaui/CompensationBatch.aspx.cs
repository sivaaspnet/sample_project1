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
using System.Globalization;

public partial class superadmin_ViewbatchDetails : System.Web.UI.Page
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
            filldrop();
            fillgrid();
            display_facultyddl();
        } 
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(stuid.Text);
    }
    public void fillgrid()
    {
        _Qry = "select a.studentId,a.subContentId,a.batchcode,b.enq_personal_name,c.Content,a.moduleid,c.Module,d.Software_Name,d.Software_Id,a.batchTiming,e.slot,f.FacultyName from erp_batchschedule a inner join adm_personalparticulars b on a.studentId=b.student_id inner join Submodule_details_new c on c.Submodule_id=a.subContentId and c.status='Active' inner join Onlinestudent_Software d on d.Software_Id=a.Software_id inner join erp_batchdetails e on a.batchcode=e.batchcode inner join onlinestudentsfacultydetails f on a.facultyId=f.Faculty_ID  Where a.status !='Completed' and a.batchstatus='active' and b.studentstatus='active' and a.classDate<=getdate() and a.centrecode='" + Session["SA_centre_code"].ToString() + "'";
        if (stuid.Text != "")
        {
            _Qry += " and a.studentId = '" + stuid.Text.ToString() + "'";
        }                                                                                                                                                                   
        if (ddl_module.SelectedValue != "")
        {
            _Qry += " and a.moduleid = '" + ddl_module.SelectedValue.ToString() + "'";
        }
        if (ddl_faculty.SelectedValue != "")
        {
            _Qry += " and a.facultyId = '" + ddl_faculty.SelectedValue.ToString() + "'";
        }
        if (ddl_slot.SelectedValue != "")
        {
            _Qry += " and e.slot = '" + ddl_slot.SelectedValue.ToString() + "'";
        }
        if (ddl_timing.SelectedValue != "")
        {
            _Qry += " and a.batchTiming = '" + ddl_timing.SelectedValue.ToString() + "'";
        }
        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }

    public void filldrop()
    {
        _Qry = "select * from module_details";

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_module.DataSource = dt;
        ddl_module.DataTextField = "module_content";
        ddl_module.DataValueField = "module_Id";
        ddl_module.DataBind();
        ddl_module.Items.Insert(0, new ListItem("All", ""));
    }
    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_faculty.DataSource = dt;
        ddl_faculty.DataValueField = "faculty_id";
        ddl_faculty.DataTextField = "facultyname";
        ddl_faculty.DataBind();
        ddl_faculty.Items.Insert(0, new ListItem("All", ""));
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Componsation-Batch-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView2.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
