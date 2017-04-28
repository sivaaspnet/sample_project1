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
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

public partial class Onlinestudents2_superadmin_facultyreport : System.Web.UI.Page
{
    string qry, _Qry;
    DataTable reportfac = new DataTable();
    string littable = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            //string yea = string.Format("{0:yyyy}", DateTime.Now).Trim();
            txtfromdate.Text = mon;
           
            //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            display_facultyddl();
        }
    }

    private void fillgrid()
    {

        string stdate = "";
        stdate = txtfromdate.Text;
        string[] split = stdate.Split('-');
        stdate = split[1] + "/" + split[0] + "/" + split[2];
        string enddate = "";
        enddate = txttodate.Text;
        string[] split2 = enddate.Split('-');
        enddate = split2[1] + "/" + split2[0] + "/" + split2[2];
        string classdatemwf = "";
        string classdatetts = "";

        if (stdate != enddate)
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spstartendclassdate]('" + stdate + "','" + enddate + "','MWF')";
            DataTable dtmwf = new DataTable();
            dtmwf = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dtmwf.Rows.Count; i++)
            {
                if (classdatemwf == "")
                {
                    classdatemwf = "'" + dtmwf.Rows[i]["classdate"].ToString() + "'";
                }
                else
                {
                    classdatemwf = classdatemwf + ",'" + dtmwf.Rows[i]["classdate"].ToString() + "'";
                }
            }
            // Response.Write(classdatemwf+"<br>");
            _Qry = " select convert(varchar,classdate,101) as classdate from [spstartendclassdate]('" + stdate + "','" + enddate + "','TTS')";
            DataTable dttts = new DataTable();
            dttts = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dttts.Rows.Count; i++)
            {
                if (classdatetts == "")
                {
                    classdatetts = "'" + dttts.Rows[i]["classdate"].ToString() + "'";
                }
                else
                {
                    classdatetts = classdatetts + ",'" + dttts.Rows[i]["classdate"].ToString() + "'";
                }
            }
            // Response.Write(classdatetts + "<br>");

            qry = @" select convert(varchar(10),dateadd(d,0,classdate),101) as clsdate,* from erp_batchschedule bs inner join online_students_labavail lab on lab.labid=bs.labid and centre_code=centrecode where convert(varchar(10),dateadd(d,0,classdate),101) between '" + stdate + "' and '" + enddate + "'  and centrecode='" + Session["SA_centre_code"] + "'  and bs.batchstatus='active'";
            // Response.Write(qry + "<br>");
            //   if (ddl_fac.SelectedValue!="")
            //{
            //    qry += " and sce.facultyid='" + ddl_fac.SelectedValue + "'";
            //}
            //(select  CONVERT(VARCHAR(10),min( classDate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
            //(select  CONVERT(VARCHAR(10),max( classDate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate


            // Response.Write(qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);

            qry = "select distinct batchcode,faculty_id,ft.day,batchtime,facultyname from onlinestudentsfacultydetails fac inner join [erp_facultytimedetails] ft on ft.facultyid=fac.faculty_id left join erp_batchschedule bs on bs.facultyid=faculty_id and fac.centre_code=bs.centrecode where fac.centre_code='" + Session["SA_centre_code"].ToString() + "'";
            if (ddl_fac.SelectedValue != "")
            {
                qry += " and faculty_id='" + ddl_fac.SelectedValue + "'";
            }
            //Response.Write(qry+"<br>");
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(qry);



            qry = "select count(distinct studentid)as noofstudent ,batchcode,CONVERT(VARCHAR(10),min(dateadd(d,0, classDate) ),103)as startdate,CONVERT(VARCHAR(10),max( dateadd(d,0,classDate)),103) as enddate   from erp_batchschedule where centrecode='" + Session["SA_centre_code"].ToString() + "' group by batchcode ";
            DataTable dt2 = new DataTable();
            dt2 = MVC.DataAccess.ExecuteDataTable(qry);

            reportfac.Columns.Add(new DataColumn("facultyname", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("seventtsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("seventtssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("seventtsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("seventtsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("seventtsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("ninemwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninemwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninemwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninemwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninemwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("ninettsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninettssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninettsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninettsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("ninettsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("elevenmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("elevenmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("elevenmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("elevenmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("elevenmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("eleventtsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("eleventtssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("eleventtsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("eleventtsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("eleventtsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("onepmmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("onepmttsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmttssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmttsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmttsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("onepmttsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("threepmmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("threepmttsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmttssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmttsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmttsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("threepmttsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("fivepmmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("fivepmttsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmttssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmttsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmttsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("fivepmttsnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("sevenpmmwfbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmmwfsd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmmwfed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmmwfln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmmwfnos", System.Type.GetType("System.String")));

            reportfac.Columns.Add(new DataColumn("sevenpmttsbc", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmttssd", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmttsed", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmttsln", System.Type.GetType("System.String")));
            reportfac.Columns.Add(new DataColumn("sevenpmttsnos", System.Type.GetType("System.String")));

            DataRow drfac = reportfac.NewRow();

            DataTable dtf = new DataTable();
            // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] arg = new string[2];

            arg[0] = "faculty_id";
            arg[1] = "facultyname";
            // arg[2] = "batchcode";
            dtf = dt1.DefaultView.ToTable(true, arg);
            foreach (DataRow drs in dtf.Rows)
            {
                drfac = reportfac.NewRow();
                drfac["facultyname"] = UppercaseFirst(drs["Facultyname"].ToString());

                drfac["sevenmwfbc"] = "-";
                drfac["sevenmwfsd"] = "-";
                drfac["sevenmwfed"] = "-";
                drfac["sevenmwfln"] = "-";
                drfac["sevenmwfnos"] = "-";
                drfac["seventtsbc"] = "-";
                drfac["seventtssd"] = "-";
                drfac["seventtsed"] = "-";
                drfac["seventtsln"] = "-";
                drfac["seventtsnos"] = "-";
                string res;
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7AMto9AM'") > 0)
                {
                    drfac["sevenmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='7AMto9AM'");
                    drfac["sevenmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["sevenmwfbc"].ToString() + "'", "startdate");
                    drfac["sevenmwfed"] = getcolumn(dt2, " batchcode='" + drfac["sevenmwfbc"].ToString() + "'", "enddate");
                    drfac["sevenmwfln"] = getcolumn(dt, " batchcode='" + drfac["sevenmwfbc"].ToString() + "'", "labname");
                    drfac["sevenmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["sevenmwfbc"].ToString() + "'", "noofstudent");
                    drfac["sevenmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='7AMto9AM'");
                }
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7AMto9AM'") > 0)
                {
                    drfac["seventtsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='7AMto9AM'");
                    drfac["seventtssd"] = getcolumn(dt2, " batchcode='" + drfac["seventtsbc"].ToString() + "'", "startdate");
                    drfac["seventtsed"] = getcolumn(dt2, " batchcode='" + drfac["seventtsbc"].ToString() + "'", "enddate");
                    drfac["seventtsln"] = getcolumn(dt, " batchcode='" + drfac["seventtsbc"].ToString() + "'", "labname");
                    drfac["seventtsnos"] = getcolumn(dt2, " batchcode='" + drfac["seventtsbc"].ToString() + "'", "noofstudent");
                    drfac["seventtsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='7AMto9AM'");
                }
                drfac["ninemwfbc"] = "-";
                drfac["ninemwfsd"] = "-";
                drfac["ninemwfed"] = "-";
                drfac["ninemwfln"] = "-";
                drfac["ninemwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='9AMto11AM'") > 0)
                {
                    drfac["ninemwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='9AMto11AM'");
                    drfac["ninemwfsd"] = getcolumn(dt2, " batchcode='" + drfac["ninemwfbc"].ToString() + "'", "startdate");
                    drfac["ninemwfed"] = getcolumn(dt2, " batchcode='" + drfac["ninemwfbc"].ToString() + "'", "enddate");
                    drfac["ninemwfln"] = getcolumn(dt, " batchcode='" + drfac["ninemwfbc"].ToString() + "'", "labname");
                    drfac["ninemwfnos"] = getcolumn(dt2, " batchcode='" + drfac["ninemwfbc"].ToString() + "'", "noofstudent");
                    drfac["ninemwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='9AMto11AM'");
                }
                drfac["ninettsbc"] = "-";
                drfac["ninettssd"] = "-";
                drfac["ninettsed"] = "-";
                drfac["ninettsln"] = "-";
                drfac["ninettsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='9AMto11AM'") > 0)
                {
                    drfac["ninettsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='9AMto11AM'");
                    drfac["ninettssd"] = getcolumn(dt2, " batchcode='" + drfac["ninettsbc"].ToString() + "'", "startdate");
                    drfac["ninettsed"] = getcolumn(dt2, " batchcode='" + drfac["ninettsbc"].ToString() + "'", "enddate");
                    drfac["ninettsln"] = getcolumn(dt, " batchcode='" + drfac["ninettsbc"].ToString() + "'", "labname");
                    drfac["ninettsnos"] = getcolumn(dt2, " batchcode='" + drfac["ninettsbc"].ToString() + "'", "noofstudent");
                    drfac["ninettsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='9AMto11AM'");
                }
                drfac["elevenmwfbc"] = "-";
                drfac["elevenmwfsd"] = "-";
                drfac["elevenmwfed"] = "-";
                drfac["elevenmwfln"] = "-";
                drfac["elevenmwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='11AMto1PM'") > 0)
                {
                    drfac["elevenmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='11AMto1PM'");
                    drfac["elevenmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["elevenmwfbc"].ToString() + "'", "startdate");
                    drfac["elevenmwfed"] = getcolumn(dt2, " batchcode='" + drfac["elevenmwfbc"].ToString() + "'", "enddate");
                    drfac["elevenmwfln"] = getcolumn(dt, " batchcode='" + drfac["elevenmwfbc"].ToString() + "'", "labname");
                    drfac["elevenmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["elevenmwfbc"].ToString() + "'", "noofstudent");
                    drfac["elevenmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='11AMto1PM'");
                }
                drfac["eleventtsbc"] = "-";
                drfac["eleventtssd"] = "-";
                drfac["eleventtsed"] = "-";
                drfac["eleventtsln"] = "-";
                drfac["eleventtsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='11AMto1PM'") > 0)
                {
                    drfac["eleventtsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='11AMto1PM'");
                    drfac["eleventtssd"] = getcolumn(dt2, " batchcode='" + drfac["eleventtsbc"].ToString() + "'", "startdate");
                    drfac["eleventtsed"] = getcolumn(dt2, " batchcode='" + drfac["eleventtsbc"].ToString() + "'", "enddate");
                    drfac["eleventtsln"] = getcolumn(dt, " batchcode='" + drfac["eleventtsbc"].ToString() + "'", "labname");
                    drfac["eleventtsnos"] = getcolumn(dt2, " batchcode='" + drfac["eleventtsbc"].ToString() + "'", "noofstudent");
                    drfac["eleventtsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='11AMto1PM'");
                }
                drfac["onepmmwfbc"] = "-";
                drfac["onepmmwfsd"] = "-";
                drfac["onepmmwfed"] = "-";
                drfac["onepmmwfln"] = "-";
                drfac["onepmmwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='1PMto3PM'") > 0)
                {
                    drfac["onepmmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='1PMto3PM'");
                    drfac["onepmmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["onepmmwfbc"].ToString() + "'", "startdate");
                    drfac["onepmmwfed"] = getcolumn(dt2, " batchcode='" + drfac["onepmmwfbc"].ToString() + "'", "enddate");
                    drfac["onepmmwfln"] = getcolumn(dt, " batchcode='" + drfac["onepmmwfbc"].ToString() + "'", "labname");
                    drfac["onepmmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["onepmmwfbc"].ToString() + "'", "noofstudent");
                    drfac["onepmmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='1PMto3PM'");
                }
                drfac["onepmttsbc"] = "-";
                drfac["onepmttssd"] = "-";
                drfac["onepmttsed"] = "-";
                drfac["onepmttsln"] = "-";
                drfac["onepmttsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='1PMto3PM'") > 0)
                {
                    drfac["onepmttsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='1PMto3PM'");
                    drfac["onepmttssd"] = getcolumn(dt2, " batchcode='" + drfac["onepmttsbc"].ToString() + "'", "startdate");
                    drfac["onepmttsed"] = getcolumn(dt2, " batchcode='" + drfac["onepmttsbc"].ToString() + "'", "enddate");
                    drfac["onepmttsln"] = getcolumn(dt, " batchcode='" + drfac["onepmttsbc"].ToString() + "'", "labname");
                    drfac["onepmttsnos"] = getcolumn(dt2, " batchcode='" + drfac["onepmttsbc"].ToString() + "'", "noofstudent");
                    drfac["onepmttsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='1PMto3PM'");
                }
                drfac["threepmmwfbc"] = "-";
                drfac["threepmmwfsd"] = "-";
                drfac["threepmmwfed"] = "-";
                drfac["threepmmwfln"] = "-";
                drfac["threepmmwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='3PMto5PM'") > 0)
                {
                    drfac["threepmmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='3PMto5PM'");
                    drfac["threepmmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["threepmmwfbc"].ToString() + "'", "startdate");
                    drfac["threepmmwfed"] = getcolumn(dt2, " batchcode='" + drfac["threepmmwfbc"].ToString() + "'", "enddate");
                    drfac["threepmmwfln"] = getcolumn(dt, " batchcode='" + drfac["threepmmwfbc"].ToString() + "'", "labname");
                    drfac["threepmmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["threepmmwfbc"].ToString() + "'", "noofstudent");
                    drfac["threepmmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='3PMto5PM'");
                }
                drfac["threepmttsbc"] = "-";
                drfac["threepmttssd"] = "-";
                drfac["threepmttsed"] = "-";
                drfac["threepmttsln"] = "-";
                drfac["threepmttsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='3PMto5PM'") > 0)
                {
                    drfac["threepmttsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='3PMto5PM'");
                    drfac["threepmttssd"] = getcolumn(dt2, " batchcode='" + drfac["threepmttsbc"].ToString() + "'", "startdate");
                    drfac["threepmttsed"] = getcolumn(dt2, " batchcode='" + drfac["threepmttsbc"].ToString() + "'", "enddate");
                    drfac["threepmttsln"] = getcolumn(dt, " batchcode='" + drfac["threepmttsbc"].ToString() + "'", "labname");
                    drfac["threepmttsnos"] = getcolumn(dt2, " batchcode='" + drfac["threepmttsbc"].ToString() + "'", "noofstudent");
                    drfac["threepmttsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='3PMto5PM'");
                }
                drfac["fivepmmwfbc"] = "-";
                drfac["fivepmmwfsd"] = "-";
                drfac["fivepmmwfed"] = "-";
                drfac["fivepmmwfln"] = "-";
                drfac["fivepmmwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='5PMto7PM'") > 0)
                {
                    drfac["fivepmmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='5PMto7PM'");
                    drfac["fivepmmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["fivepmmwfbc"].ToString() + "'", "startdate");
                    drfac["fivepmmwfed"] = getcolumn(dt2, " batchcode='" + drfac["fivepmmwfbc"].ToString() + "'", "enddate");
                    drfac["fivepmmwfln"] = getcolumn(dt, " batchcode='" + drfac["fivepmmwfbc"].ToString() + "'", "labname");
                    drfac["fivepmmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["fivepmmwfbc"].ToString() + "'", "noofstudent");
                    drfac["fivepmmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='5PMto7PM'");
                }
                drfac["fivepmttsbc"] = "-";
                drfac["fivepmttssd"] = "-";
                drfac["fivepmttsed"] = "-";
                drfac["fivepmttsln"] = "-";
                drfac["fivepmttsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='5PMto7PM'") > 0)
                {
                    drfac["fivepmttsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='5PMto7PM'");
                    drfac["fivepmttssd"] = getcolumn(dt2, " batchcode='" + drfac["fivepmttsbc"].ToString() + "'", "startdate");
                    drfac["fivepmttsed"] = getcolumn(dt2, " batchcode='" + drfac["fivepmttsbc"].ToString() + "'", "enddate");
                    drfac["fivepmttsln"] = getcolumn(dt, " batchcode='" + drfac["fivepmttsbc"].ToString() + "'", "labname");
                    drfac["fivepmttsnos"] = getcolumn(dt2, " batchcode='" + drfac["fivepmttsbc"].ToString() + "'", "noofstudent");
                    drfac["fivepmttsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='5PMto7PM'");
                }
                drfac["sevenpmmwfbc"] = "-";
                drfac["sevenpmmwfsd"] = "-";
                drfac["sevenpmmwfed"] = "-";
                drfac["sevenpmmwfln"] = "-";
                drfac["sevenpmmwfnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7PMto9PM'") > 0)
                {
                    drfac["sevenpmmwfbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='7PMto9PM'");
                    drfac["sevenpmmwfsd"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmmwfbc"].ToString() + "'", "startdate");
                    drfac["sevenpmmwfed"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmmwfbc"].ToString() + "'", "enddate");
                    drfac["sevenpmmwfln"] = getcolumn(dt, " batchcode='" + drfac["sevenpmmwfbc"].ToString() + "'", "labname");
                    drfac["sevenpmmwfnos"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmmwfbc"].ToString() + "'", "noofstudent");
                    drfac["sevenpmmwfbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatemwf + ") and batchtiming='7PMto9PM'");
                }
                drfac["sevenpmttsbc"] = "-";
                drfac["sevenpmttssd"] = "-";
                drfac["sevenpmttsed"] = "-";
                drfac["sevenpmttsln"] = "-";
                drfac["sevenpmttsnos"] = "-";
                if (getfreeclassdetails(dt1, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7PMto9PM'") > 0)
                {
                    drfac["sevenpmttsbc"] = getbatchcode(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='7PMto9PM'");
                    drfac["sevenpmttssd"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmttsbc"].ToString() + "'", "startdate");
                    drfac["sevenpmttsed"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmttsbc"].ToString() + "'", "enddate");
                    drfac["sevenpmttsln"] = getcolumn(dt, " batchcode='" + drfac["sevenpmttsbc"].ToString() + "'", "labname");
                    drfac["sevenpmttsnos"] = getcolumn(dt2, " batchcode='" + drfac["sevenpmttsbc"].ToString() + "'", "noofstudent");
                    drfac["sevenpmttsbc"] = getbatchcodeval(dt, " facultyid='" + drs["faculty_id"].ToString() + "' and clsdate in (" + classdatetts + ") and batchtiming='7PMto9PM'");
                }

                reportfac.Rows.Add(drfac);
            }


            if (reportfac.Rows.Count > 0)
            {
                rpfac.DataSource = reportfac;
                rpfac.DataBind();
                lnkdownload.Visible = true;
            }
        }
    }


    int getfreeclassdetails(DataTable dtexp, string expression)
    {
        int count = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            count += 1;
        }
        return count;
    }

    string getbatchcode(DataTable dtexp, string expression)
    {
        string res = "Free";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {                
                res = (val["batchcode"].ToString());                 
            }
        }
         
        return res.ToString();
    }

    string getbatchcodeval(DataTable dtexp, string expression)
    {
        string res = "";
        string valu = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = (val["batchcode"].ToString());
            }
        }
        if (res == "")
        {
            valu = "<span style='color:green; font-weight:bold;'>  Free </span>";
        }
        else
        {
            valu = "<a style='color:blue; font-weight:bold;'  href='Viewbatch.aspx?batchcode=" + res + "'> View </a>";
        }
        return valu.ToString();
        return res.ToString();
    }

    string getcolumn(DataTable dtexp, string expression, string column)
    {
        string res = "";
        string valu = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                //if (res == "")
                //{
                    res = (val[column].ToString());
                //}
                //else if(res==(val[column].ToString()))
                //{
                //    res = (val[column].ToString());
                //}
                //else
                //{
                //    res =res+","+ (val[column].ToString());
                //}
            }
        }
        if (res == "")
        {
            valu= "<span style='color:green; font-weight:bold;'>  Free </span>";
        }
        else
        {
            valu = "<span style='color:red; font-weight:bold;'>"+res+"</span>";
        }
        return valu.ToString();
    }


    public void ExportTableData(DataTable dtdata)
    {
        string fulltable = "";
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

//        System.Web.UI.Control ctl = this.GridView1;
////DataGrid1 (you created in the windowForm)
//HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=Excel.xls");
//HttpContext.Current.Response.Charset ="UTF-8";     
//HttpContext.Current.Response.ContentEncoding =System.Text.Encoding.Default;
//HttpContext.Current.Response.ContentType ="application/ms-excel";
//ctl.Page.EnableViewState =false;    
//System.IO.StringWriter  tw = new System.IO.StringWriter() ;
//System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter (tw);
//ctl.RenderControl(hw);
//HttpContext.Current.Response.Write(tw.ToString());
//HttpContext.Current.Response.End(); 

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Faculty-Report-Of-" + Session["SA_Location"] + "-center-between-" + txtfromdate.Text + "-and-" + txttodate.Text + ".xls");
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                if (dc.ColumnName != "Content")
                {
                    Response.Write(dc.ColumnName + "\t");
                }

                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count - 1; i++)
                {
                    Response.Write((dr[i].ToString()) + "\t");


                }
                Response.Write("\n");
            }
            Response.End();
        }

        //Response.Clear();
        //Response.ContentType = "application/ms-excel";
        //Response.AddHeader("Content-disposition", "attachment;filename=Book1.xlsx");
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //if (dtdata != null)
        //{
        //    fulltable += "<table><th>";
        //    foreach (DataColumn dc in dtdata.Columns)
        //    {
        //        fulltable += "<td>"+dc.ColumnName+"</td>";
        //       // Response.Write(dc.ColumnName + "\t");
        //    }
        //    fulltable += "</th>";
        //    foreach (DataRow dr in dtdata.Rows)
        //    {
        //        fulltable += "<tr>";
        //        for (int i = 0; i < dtdata.Columns.Count; i++)
        //        {
        //            fulltable += "<td>"+(dr[i].ToString())+"</td>";
        //            //Response.Write((dr[i].ToString()) + "\t");
        //        }
        //        fulltable+="<tr>";
        //    }
        //}
        //literals1.Text=fulltable.ToString();
        //literals1.RenderControl(hw);
        //Response.Write(sw.ToString());
        //Response.End();
    }

    string getfaccontent(DataTable dtexp, string expression,int column)
    {
        string res = "";
        int completed = 0;
        int noofclass = column;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            completed = dr.Length;
            foreach (DataRow val in dr)
            {
                res = "<span style='color:green; font-weight:bold;'>" + completed + "</span>" + " / " + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Class Not start";
        }

        return res.ToString();
    }
    string getfaccontent1(DataTable dtexp, string expression, int column)
    {
        string res = "";
        int completed = 0;
        int noofclass = column;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            completed = dr.Length;
            foreach (DataRow val in dr)
            {
                res = "'"+completed + "" + " / " + noofclass;
            }

        }
        else
        {
            res = "Class Not start";
        }

        return res.ToString();
    }

    string getcontentstatus(DataTable dtexp, string expression)
    {
        string res = "";
        int pending = 0;
        int noofclass = 0;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                pending = (Convert.ToInt32(val["pending"]));
                noofclass = (Convert.ToInt32(val["noofclass"]));
                pending = noofclass - pending;
                res = "<span style='color:green; font-weight:bold;'>" + pending + "</span>" + "/" + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Batch Not Schedule";
        }

        return res.ToString();
    }

    string getnoofstudent(DataTable dtexp, string expression, string column)
    {
        string count = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (count == "")
                {
                    count = (val[column].ToString());
                }
            }
        }
        return count.ToString();

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        fillgrid(); 
    }
    private void display_facultyddl()
    {
      //  qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("All", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    static string UppercaseFirst(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
          
        //Response.Clear();
        //Response.AddHeader("content-disposition", "attachment;filename=Faculty-Report-of-" + Session["SA_Location"] + "-center.xlsx");
        //Response.Charset = "";
        //// If you want the option to open the Excel file without saving than
        //// comment out the line below
        //// Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.xls";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //rpfac.RenderControl(htmlWrite);
        //// GridView1.RenderControl(htmlWrite);

        //Response.Write(stringWrite.ToString());
        //Response.End();

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        rpfac.RenderControl(writer);
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment;filename=Faculty-Report-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentType = "Application/msexcel";
        Response.Write(sb.ToString());
        Response.End();        

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
