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

public partial class superadmin_Viewstudentcoursedetails : System.Web.UI.Page
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
            ddlmonth.SelectedValue = DateTime.Now.ToString("MM");
            ddlyear.SelectedValue = DateTime.Now.ToString("yyyy");
            stu_feedet();
            display_facultyddl();
        }       
    }
   
    private void stu_feedet()
    {
       // _Qry = "select distinct Batch_Code from Feedback_request where centrecode='" + Session["SA_centre_code"].ToString() + "'";
        _Qry = "select distinct bs.batchcode,bat.batchTiming,facultyname,slot  from erp_batchschedule bs inner join erp_batchdetails bat on bat.batchcode=bs.batchcode and bat.centrecode=bs.centrecode inner join onlinestudentsfacultydetails fac on fac.faculty_id=bs.facultyid where bs.centrecode='" + Session["SA_centre_code"].ToString() + "' and bs.batchcode in(select distinct fr.Batch_Code from Feedback_request fr where fr.centrecode='" + Session["SA_centre_code"].ToString() + "') and year(bs.classdate)='" + ddlyear.SelectedValue + "'  and month(bs.classdate)='" + ddlmonth.SelectedValue + "' ";
        if (Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            _Qry += "  and facultyname='" + Session["SA_Username"] + "' ";
            Label1.Visible = false;
            ddl_fac.Visible = false;
        }
        if (ddl_slot.SelectedValue != "")
        {
            _Qry += "  and bat.slot='" + ddl_slot.SelectedValue + "' ";
        }
        if (ddl_fac.SelectedValue != "")
        {
            _Qry += "  and bs.facultyid='" + ddl_fac.SelectedValue + "' ";
        }
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = dt.Rows.Count.ToString();

    }

    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("All", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        stu_feedet();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    { 
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Feedback-of-" +ddlmonth.SelectedValue+ "-"+ddlyear.SelectedValue+".xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //fillgrid();
        // ExportTableData(dtgrid);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
