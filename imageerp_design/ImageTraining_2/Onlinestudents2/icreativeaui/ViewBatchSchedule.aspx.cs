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

public partial class Onlinestudents2_superadmin_ViewBatchSchedule : System.Web.UI.Page
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
            FillBatchCode();
            //ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
    }
    private void FillBatchCode()
    {
        _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' And Batch_Status<>'Completed' group by batch_code";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlbatchcode.DataSource = dt;
        ddlbatchcode.DataValueField = "batch_code";
        ddlbatchcode.DataTextField = "batch_code";
        ddlbatchcode.DataBind();
        ddlbatchcode.Items.Insert(0, new ListItem("Select", ""));
        ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int abc = 0;
        _Qry = "Select Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,Batch_Time,convert(varchar(10),Batch_Startdate,103) as Batch_Startdate,convert(varchar(10),Batch_enddate,103) as Batch_Enddate ";
        _Qry += " From Batch_Details Where Batch_Code='" + ddlbatchcode.SelectedValue + "' And Batch_Status<>'Completed' Group By Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,";
        _Qry += "Batch_Time,Batch_Startdate,Batch_Enddate";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            txt_software.Text = ddlsoftwre.SelectedValue;
            txt_BatchTrack.Text = dt.Rows[0]["Batch_Track"].ToString();
            txt_Module.Text = dt.Rows[0]["batch_Module_content"].ToString();
            txt_Faculty.Text = dt.Rows[0]["batch_Faculty"].ToString();
            txt_Lab.Text = dt.Rows[0]["batch_LabName"].ToString();
            txt_BatchSlot.Text = dt.Rows[0]["Batch_Slot"].ToString();
            txt_BatchTime.Text = dt.Rows[0]["Batch_Time"].ToString();
            txt_Bstart.Text = dt.Rows[0]["Batch_Startdate"].ToString();
            txt_Bend.Text = dt.Rows[0]["Batch_Enddate"].ToString();
        }
        else
        {
            abc = 1;
            tblbatch.Visible = false;
        }

        //_Qry = "Select software_name,Content,convert(varchar(10),Date_Class,111) as Dateofclass, ";
        //_Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as ClassHeld,(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as Reason From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + ddlbatchcode.SelectedValue + "' And ";
        //_Qry += " sa.software_name='" + ddlsoftwre.SelectedValue + "'";

        _Qry = "Select Content,convert(varchar(10),Date_Class,103) as ScheduledDate,(Select convert(varchar(10),Date_Class,103) as ChangedDate From onlinestudent_Editschedulebatch as ma Where ma.Content=sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as ScheduleChangedDate, ";
        _Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        _Qry += "sa.Content And Batch_Code=sa.Batch_Code And Centre_Code='" + Session["SA_centre_code"] + "' And Batch_Code='" + ddlbatchcode.SelectedValue + "' And software_name='" + ddlsoftwre.SelectedValue + "') as ClassHeld,(Select Reason From onlinestudent_Editschedulebatch as ma Where ma.Content= ";
        _Qry += "sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id And Centre_Code='" + Session["SA_centre_code"] + "' And Batch_Code='" + ddlbatchcode.SelectedValue + "' And software_name='" + ddlsoftwre.SelectedValue + "') as ScheduleChangedReason,";
        _Qry += "(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        _Qry += "sa.Content And Batch_Code=sa.Batch_Code And Centre_Code='" + Session["SA_centre_code"] + "' And Batch_Code='" + ddlbatchcode.SelectedValue + "' And software_name='" + ddlsoftwre.SelectedValue + "') as ReasonForCancellation";
        _Qry +=" From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + ddlbatchcode.SelectedValue + "' And ";
        _Qry += " sa.software_name='" + ddlsoftwre.SelectedValue + "' ";
        _Qry += " And (Select count(*) from batch_details where Batch_Code='" + ddlbatchcode.SelectedValue + "' And Batch_Status<>'Completed')>0";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {
            if (abc == 0)
            {
                lblerror.Text = "This Batch is not yet scheduled";
            }
            else
            {
                lblerror.Text = "This Batch is Completed";
            }
        }
    }
    protected void ddlbatchcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlsoftwre.Items.Clear();
        ddlsoftwre.Items.Clear();
        ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
        tblbatch.Visible = false;
        _Qry = "Select software_name from module_details where Module_Content=(Select Batch_Module_Content From Batch_Details Where Batch_Code='" + ddlbatchcode.SelectedValue + "' group by batch_code,Batch_Module_Content)";

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            string str = dr["software_name"].ToString();
            string[] softwarename = str.Split(',');
            int i = 1;
            foreach (string soft in softwarename)
            {
                ddlsoftwre.Items.Insert(i, new ListItem(soft, soft));
                i = i + 1;
            }
            dr.Close();
            //ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //_Qry = "Select software_name,Content,convert(varchar(10),Date_Class,111) as ScheduledDate,(Select convert(varchar(10),Date_Class,111) as ChangedDate From onlinestudent_Editschedulebatch as ma Where ma.Content=sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as SchedulePostponedDate, ";
        //_Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as ClassHeld,(Select Reason From onlinestudent_Editschedulebatch as ma Where ma.Content= ";
        //_Qry += "sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as SchedulePostponedReason,";
        //_Qry += "(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as Reason";
        //_Qry += "From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + ddlbatchcode.SelectedValue + "' And ";
        //_Qry += " sa.software_name='" + ddlsoftwre.SelectedValue + "'";

        //_Qry = "Select Content,convert(varchar(10),Date_Class,103) as ScheduledDate,(Select convert(varchar(10),Date_Class,103) as ChangedDate From onlinestudent_Editschedulebatch as ma Where ma.Content=sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as ScheduleChangedDate, ";
        //_Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as ClassHeld,(Select Reason From onlinestudent_Editschedulebatch as ma Where ma.Content= ";
        //_Qry += "sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as ScheduleChangedReason,";
        //_Qry += "(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as ReasonForCancellation";
        //_Qry += " From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + ddlbatchcode.SelectedValue + "' And ";
        //_Qry += " sa.software_name='" + ddlsoftwre.SelectedValue + "'";
        //_Qry += " And (Select count(*) from batch_details where Batch_Code='" + ddlbatchcode.SelectedValue + "' And Batch_Status<>'Completed')>0";

        _Qry = "Select Content,convert(varchar(10),Date_Class,103) as ScheduledDate,(Select convert(varchar(10),Date_Class,103) as ChangedDate From onlinestudent_Editschedulebatch as ma Where ma.Content=sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as ScheduleChangedDate, ";
        _Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        _Qry += "sa.Content And Batch_Code=sa.Batch_Code) as ClassHeld,(Select Reason From onlinestudent_Editschedulebatch as ma Where ma.Content= ";
        _Qry += "sa.Content And ma.Batch_Code=sa.Batch_Code And ma.Schedule_Id=sa.Schedule_Id) as ScheduleChangedReason,";
        _Qry += "(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        _Qry += "sa.Content And Batch_Code=sa.Batch_Code) as ReasonForCancellation";
        _Qry += " From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + ddlbatchcode.SelectedValue + "' And ";
        _Qry += " sa.software_name='" + ddlsoftwre.SelectedValue + "' ";
        _Qry += " And (Select count(*) from batch_details where Batch_Code='" + ddlbatchcode.SelectedValue + "' And Batch_Status<>'Completed')>0";


        //Response.Write(_Qry);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewBatchSchedule.aspx");
    }
}
