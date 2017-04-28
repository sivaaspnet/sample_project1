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

public partial class superadmin_createnewBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, centrcode, couname, couid, todate, holdate;
    string batchqry = "";
    string mainqry = "";
    int noofcls, weekday,endate;
    int yy = 0;
    string classdate = "";
    string classdatemwf = "";
    string classdatetts = "";
    DateTime stdate, lastday;
    string rr = "";
    string facid = "";
    string labtime = "";
    string labcode = "";
    string confirmation = "<table class='common' border='1px' width=350><tr><th>Class date</th><th>Content</th></tr> ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            fillgrid();
            displaycourseonload();
            display_facultyddl();
            display_labddl();
            Button1.Visible = false;
        }
       
    }

    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlfac.DataSource = dt;
        ddlfac.DataValueField = "faculty_id";
        ddlfac.DataTextField = "facultyname";
        ddlfac.DataBind();
        ddlfac.Items.Insert(0, new ListItem("Select", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void display_labddl()
    {
        _Qry = "select LabId,LabName  from online_students_labavail where centre_Code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);       
        ddllab.DataSource = dt;
        ddllab.DataTextField = "LabName";
        ddllab.DataValueField = "LabId";
        ddllab.DataBind();
        ddllab.Items.Insert(0, new ListItem("Select", ""));
    }
    
    private void display_facultygrid()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvfaculty.DataSource = dt;
        gvfaculty.DataBind();
        ddlfac.DataSource = dt;      
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void display_labgrid()
    {
        _Qry = "select LabId,LabName,LabName+' ('+ systemcount+')' as labwithsys from erp_labdetails where centreCode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvlab.DataSource = dt;
        gvlab.DataBind();       
    }
    private void display_faculty()
    {
        //_Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "'";
       
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_facultyname.DataSource = dt;
        //ddl_facultyname.DataValueField = "faculty_id";
        //ddl_facultyname.DataTextField = "facultyname";
        //ddl_facultyname.DataBind();
        //ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    }
    private void display_lab()
    {
        //_Qry = "select LabId,LabName from online_students_labavail where centre_code='" + Session["SA_centre_code"] + "'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_labname.DataSource = dt;
        //ddl_labname.DataValueField = "LabId";
        //ddl_labname.DataTextField = "LabName";
        //ddl_labname.DataBind();
        //ddl_labname.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillgrid()
    {
        _Qry = @"select  distinct bat.batchcode,mod.module_content,bat.slot,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
(select  CONVERT(VARCHAR(10),min( classDate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
(select  CONVERT(VARCHAR(10),max( classDate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='" + Session["SA_centre_code"].ToString() + "'";
        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);


        _Qry = @"select * from erp_batchcontentstatus";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);




        DataTable status = new DataTable();
        status.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("module_content", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("slot", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchtiming", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("labname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("facultyname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Startdate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Enddate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();


        DataTable dt21 = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] args = new string[4];
        args[0] = "batchcode";
        args[1] = "module_content";
        args[2] = "Startdate";
        args[3] = "Enddate";
        dt21 = dt.DefaultView.ToTable(true, args);


        foreach (DataRow drs in dt21.Rows)
        {

            dr = status.NewRow();
            dr["batchcode"] = drs["batchcode"];
            dr["module_content"] = drs["module_content"];
            dr["slot"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "slot");
            dr["batchtiming"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "batchtiming");
            dr["labname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "labname");
            // dr["facultyname"] = drs["facultyname"];
            dr["facultyname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "facultyname");
            dr["Startdate"] = drs["Startdate"];
            dr["Enddate"] = drs["Enddate"];
            dr["status"] = getstatus(dt2, "batchcode='" + drs["batchcode"] + "'");
            status.Rows.Add(dr);

        }





        GridView1.DataSource = status;
        GridView1.DataBind();

        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl = new Label();
            lbl=(Label)gr.FindControl("lblstatus");
            if (lbl.Text.ToString() == "Completed")
            {
                LinkButton lnk = new LinkButton();
                lnk = (LinkButton)gr.FindControl("lnkedit");
                lnk.Visible = false;
                Image img = new Image();
                img = (Image)gr.FindControl("Image1");
                img.Visible = true;


            }
            


        }







    }

    string getfac(DataTable dtexp, string expression, string column)
    {
        string faculty = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (faculty == "")
                {
                    faculty = (val[column].ToString());
                }
                else if (faculty == (val[column].ToString()))
                {
                    faculty = (val[column].ToString());
                }
                else
                {
                    faculty = faculty + ",<br>" + (val[column].ToString());
                }

            }
        }
        return faculty.ToString();

    }
    string getstatus(DataTable dtexp, string expression)
    {
        string res = "Complete";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {
                res = res + "," + (val["status"].ToString());
            }

            string value = res;
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].ToString() == "pending")
                {
                    res = "Inprogress";
                }

            }
        }
        if (res != "Inprogress")
        {
            res = "Completed";
        }
        return res.ToString();
    }
   


    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + ddl_Track.SelectedValue + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT Module_Id,Replace(Module_Content,'~','''') as Module_Content from Module_Details ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    
    protected void btn_submit_Click(object sender, EventArgs e)
     {        
        
 
}   


    private void fillfree()
    {
        tblfree.Visible = true;
        //tblBatch.Visible = false;


        string sdatetest = "";
        string strtest = txt_stratdate.Text;
        string[] splittest = strtest.Split('-');
        sdatetest = splittest[2] + "-" + splittest[1] + "-" + splittest[0];
        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdatetest + "','MWF','" + ddl_coursename.SelectedValue.ToString() + "')";
        // Response.Write(_Qry1);

        DataTable dtclassmwf = new DataTable();
        dtclassmwf = MVC.DataAccess.ExecuteDataTable(_Qry1);
        for (int i = 0; i < dtclassmwf.Rows.Count; i++)
        {
            if (classdatemwf == "")
            {
                classdatemwf = "'" + dtclassmwf.Rows[i]["classdate"].ToString() + "'";
            }
            else
            {
                classdatemwf = classdatemwf + ",'" + dtclassmwf.Rows[i]["classdate"].ToString() + "'";
            }
        }

        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdatetest + "','TTS','" + ddl_coursename.SelectedValue.ToString() + "')";
        // Response.Write(_Qry1);

        DataTable dtclasstts = new DataTable();
        dtclasstts = MVC.DataAccess.ExecuteDataTable(_Qry1);
        for (int i = 0; i < dtclasstts.Rows.Count; i++)
        {
            if (classdatetts == "")
            {
                classdatetts = "'" + dtclasstts.Rows[i]["classdate"].ToString() + "'";
            }
            else
            {
                classdatetts = classdatetts + ",'" + dtclasstts.Rows[i]["classdate"].ToString() + "'";
            }
        }



        _Qry1 = " select batchtiming,max(ss)  as batched,max(facultyId) as facultyId,convert(varchar,classdate,101) as classdate from (select   convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(facultyid) as ss,facultyId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf + "," + classdatetts + ")  and centrecode='" + Session["SA_centre_code"].ToString() + "' group by classdate,batchtiming,facultyid) as ss group by batchtiming,facultyId,convert(varchar,classdate,101)";
        DataTable dtfac = new DataTable();
        dtfac = MVC.DataAccess.ExecuteDataTable(_Qry1);
        _Qry = " select faculty_id,ft.day,batchtime,facultyname from onlinestudentsfacultydetails fac inner join [erp_facultytimedetails] ft on ft.facultyid=fac.faculty_id  where  fac.centre_code='" + Session["SA_centre_code"].ToString() + "'";
        DataTable dtfacname = new DataTable();
        dtfacname = MVC.DataAccess.ExecuteDataTable(_Qry);
        DataTable freefaculty = new DataTable();

        freefaculty.Columns.Add(new DataColumn("facultyname1", System.Type.GetType("System.String")));
        // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));
        DataRow drfac = freefaculty.NewRow();

        DataTable dtf = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] arg = new string[2];

        arg[0] = "faculty_id";
        arg[1] = "facultyname";
        dtf = dtfacname.DefaultView.ToTable(true, arg);
        foreach (DataRow drs in dtf.Rows)
        {
            string slotdate = "";
            if (ddlslot.SelectedValue == "MWF")
            {
                slotdate = "2,4,6";
            }
            else if (ddlslot.SelectedValue == "TTS")
            {
                slotdate = "3,5,7";
            }
            //else if (ddlslot.SelectedValue == "Daily")
            //{
            //    slotdate = "2,3,4,5,6,7";
            //}
            drfac = freefaculty.NewRow();
            drfac["facultyname1"] = drs["facultyname"];
            // dr["classdate1"] = "";
             drfac["sevenmwf"]="-";
             drfac["seventts"] = "-";
            string mwfstring = "";
            string ttsstring = "";
            string res;
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7AMto9AM'") > 0)
            {
                res=getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatemwf + ")");
                if(res!="")
                {
                    mwfstring="MWF:"+res+"/";
                    drfac["sevenmwf"] = res; 
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7AMto9AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["seventts"] = res;
                }               
            }
            //drfac["seven1"] = mwfstring + ttsstring;

            mwfstring = "";
            ttsstring = "";
            drfac["ninemwf"] = "-";
            drfac["ninetts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='9AMto11AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["ninemwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='9AMto11AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["ninetts"] = res;
                }               
            }
            //drfac["nine1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["elevenmwf"] = "-";
            drfac["eleventts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='11AMto1PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["elevenmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='11AMto1PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["eleventts"] = res;
                }                
            }
            //drfac["eleven1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["onepmmwf"] = "-";
            drfac["onepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='1PMto3PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["onepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='1PMto3PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["onepmtts"] = res;
                }                
            }
            //drfac["onepm1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["threepmmwf"] = "-";
            drfac["threepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='3PMto5PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["threepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='3PMto5PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["threepmtts"] = res;
                }               
            }
            //drfac["threepm1"] = mwfstring + ttsstring;

            mwfstring = "";
            ttsstring = "";
            drfac["fivepmmwf"] = "-";
            drfac["fivepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='5PMto7PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["fivepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='5PMto7PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["fivepmtts"] = res;
                }                
            }
           // drfac["fivepm1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["sevenpmmwf"] = "-";
            drfac["sevenpmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7PMto9PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    ttsstring = "MWF:" + res ;
                    drfac["sevenpmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7PMto9PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["sevenpmtts"] = res;

                }                
            }
            //drfac["sevenpm1"] = mwfstring + ttsstring;
 
            freefaculty.Rows.Add(drfac);
        }
        rpfac.DataSource = freefaculty;
        rpfac.DataBind();
        //gvfaculty.DataSource = freefaculty;
        //gvfaculty.DataBind();
     //   _Qry = "select batch.labid,max(lab.labname) as labname,batch.classdate,count(batch.batchtiming) as batchedsystem,system,batch.batchtiming from erp_batchschedule batch inner join online_students_labavail lab on lab.labid=batch.labid and lab.centre_code=batch.centrecode and  centrecode='" + Session["SA_centre_code"].ToString() + "' where  (convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + "))  group by classdate,batch.labid,batch.batchtiming,system ";

       // _Qry = "select batchtiming,max(ss)  as batchedsystem,labid from (select  classdate,batchtiming,count(labId) as ss,labId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ") and centrecode='" + Session["SA_centre_code"].ToString() + "' group by classdate,batchtiming,labId) as ss group by batchtiming,labid";
        _Qry = "select convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(labId) as batchedlab,labId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf + "," + classdatetts + ") and centrecode='" + Session["SA_centre_code"].ToString() + "' group by batchtiming,labId,convert(varchar(10),dateadd(d,0,classdate),101)";
       // Response.Write(_Qry+"<br>");
        DataTable dtlab = new DataTable();
        dtlab = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry1 = " select labid,labname,system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "'";
       // Response.Write(_Qry1);
        DataTable dtlabcount = new DataTable();
        dtlabcount = MVC.DataAccess.ExecuteDataTable(_Qry1);
            
        DataTable freelab = new DataTable();

            freelab.Columns.Add(new DataColumn("labname1", System.Type.GetType("System.String")));
           // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));

            DataRow dr = freelab.NewRow();
           
            DataTable dt2 = new DataTable();
           // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args=new string[3];
           
            args[0] = "labid";
            args[1] = "labname";
            args[2] = "system";

            dt2 = dtlabcount.DefaultView.ToTable(true, args);
            foreach (DataRow drs in dt2.Rows)
            {
                //string datecls = drs["classdate"].ToString();
                //string[] split = datecls.Split(',');
                //for (int i = 0; i < split.Length; i++)
                //{
                    dr = freelab.NewRow();
                    dr["labname1"] = drs["labname"];
                   // dr["classdate1"] = "";
                    dr["sevenmwf"] =  getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                    dr["seventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                    dr["ninemwf"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                    dr["ninetts"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                    dr["elevenmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                    dr["eleventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                    dr["onepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                    dr["onepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                    dr["threepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                    dr["threepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                    dr["fivepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                    dr["fivepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                    dr["sevenpmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"]));
                    dr["sevenpmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"])); // and batchtiming='" + drs["batchtiming"].ToString() + "'
                    freelab.Rows.Add(dr);
               // }
            }
            rplab.DataSource = freelab;
            rplab.DataBind();
            //gvlab.DataSource = freelab;
           // gvlab.DataBind();

            string dateclass = classdate;           
            string sdate = txt_stratdate.Text;
            string[] split = sdate.Split('-');
            sdate = split[2] + "-" + split[1] + "-" + split[0];
            _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdate + "','" + ddlslot.SelectedValue.ToString() + "','" + ddl_coursename.SelectedValue.ToString() + "')";
            // Response.Write(_Qry1);
            DataTable dtclass = new DataTable();
            dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);            
            string qry = " select Submodule_id,ModuleId,Module,Software,Content from submodule_details_new where moduleid='" + ddl_coursename.SelectedValue + "' order by classOrder,submodule_id";
            DataTable dtmodule = new DataTable();
            dtmodule = MVC.DataAccess.ExecuteDataTable(qry);

            DataTable dtcontent = new DataTable();
            dtcontent.Columns.Add(new DataColumn("Classdate", System.Type.GetType("System.String")));
            dtcontent.Columns.Add(new DataColumn("Content", System.Type.GetType("System.String")));
            DataRow drfree = dtcontent.NewRow();
            for (int i = 0; i < dtmodule.Rows.Count; i++)
            {
                drfree = dtcontent.NewRow();
                drfree["Classdate"] = dtclass.Rows[i]["classdate"].ToString();
                drfree["Content"] = dtmodule.Rows[i]["Content"].ToString();
                dtcontent.Rows.Add(drfree);
            }
            _Qry = "select  convert(varchar(10),dateadd(d,0,classdate),101) as classdate,facultyid,ba.labid,batchtiming,subcontentid,system from erp_batchschedule ba inner join  online_students_labavail lab on lab.Labid=ba.labid and lab.centre_code=ba.centrecode where (facultyid='" + ddlfac.SelectedValue + "' or ba.labid='" + ddllab.SelectedValue + "') and batchtiming='" + ddlbatch.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ")";
           // Response.Write(_Qry);
            DataTable dtdetails = new DataTable();
            dtdetails = MVC.DataAccess.ExecuteDataTable(_Qry);

            DataTable dtfullcontent = new DataTable();
            dtfullcontent.Columns.Add(new DataColumn("Classdate", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Content", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Faculty", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Lab", System.Type.GetType("System.String")));
            DataRow drfreecontent = dtfullcontent.NewRow();
            DataTable dt3 = new DataTable();
           // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args1=new string[2];
           
            args1[0] = "classdate";
            args1[1] = "Content";


            dt3 = dtcontent.DefaultView.ToTable(true, args1);
            foreach (DataRow drs in dt3.Rows)
            {
                drfreecontent = dtfullcontent.NewRow();
                drfreecontent["Classdate"] = drs["classdate"].ToString();
                drfreecontent["Content"] = drs["content"].ToString();
                drfreecontent["Faculty"] = getfreedetails(dtdetails, " classdate='" + drs["classdate"].ToString() + "'", "facultyid");
                drfreecontent["Lab"] = getfreelabcount(dtdetails, " classdate='" + drs["classdate"].ToString() + "'", "labid");
                dtfullcontent.Rows.Add(drfreecontent);
            }
            lblbatch_time.Text = ddlbatch.SelectedItem.Text;
            lbl_slotdetail.Text = ddlslot.SelectedItem.Text;
            lblfac_name.Text = ddlfac.SelectedItem.Text;
            lbllab_name.Text = ddllab.SelectedItem.Text;
           lblst_date.Text = txt_stratdate.Text;
            lblen_date.Text = txt_enddate.Text;
            gvclass.DataSource = dtfullcontent;
            gvclass.DataBind();
    }

    

    string getfreelabcount(DataTable dtexp, string expression, string column)
    {
        string res = "free";
        int count = 0;
        string labid = "";
        int system = 0;
        int freesys = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                labid = (val[column].ToString());
                system = Convert.ToInt32(val["system"]);
                count += 1;
            }
        }
        freesys = system - count;
        if (count > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'> " + count + " Batched </span> / <span style='color:green; font-weight:bold;'> " + freesys + " Free </span>";
        }
        else
        {
            res = "<span style='color:green; font-weight:bold;'>  Free </span>";
        }
       
        return res.ToString();
    }


    string getfreedetails(DataTable dtexp, string expression,string column)
    {
        string res = "<span style='color:green; font-weight:bold;'> Free </span>";
        int count = 0;
        string facultyid = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                facultyid = (val[column].ToString());
                count += 1;
            }
        }
        if (count>0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>  Batched </span>";
        }
        return res.ToString();
    }

    string getfreefaculty(DataTable dtexp, string expression)
    {
        string res = "<span style='color:green; font-weight:bold;'>Free</span>";
        int batched = 0;
        DataRow[] dr = new DataRow[100];

        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                batched  = Convert.ToInt32(val["batched"]);              
            }
        }
        if (batched > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>Batched</span>";
        }
        return res.ToString();
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

    string getfreebatchedsystem(DataTable dtexp, string expression,int column)
    {
        string res = "";
        int batchedsystem = 0;
        int totalsystem = column;
        int freesystem = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {             
            foreach (DataRow val in dr)
            {
                batchedsystem = Convert.ToInt32(val["batchedlab"]);
                freesystem = totalsystem - batchedsystem;
            }
                       
        }
        if (batchedsystem > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>" + batchedsystem + " Batched </span>/<span style='color:green; font-weight:bold;'>" + freesystem + " free </span>";
        }
        else
        {
            res = "<span style='color:green; font-weight:bold;'>" + totalsystem + " Free </span>";
        }
        return res.ToString();
    }



    string getCount1(DataTable dtexp, string expression, string column)
    {
        string res = "";
        string emp = ""; 
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {                 
                res = res+","+ (val[column].ToString());
            }

            string value = res;
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].ToString() == "batched")
                {
                    res = "Batched";
                }                 
            }
        }

        if (res != "batched")
        {
            res = "Free";
        }
        return res.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enterbatchcode.aspx");
    }
  

    protected void Button2_Click(object sender, EventArgs e)
    {
        string slotdate = "";
        if (ddlslot.SelectedValue == "MWF")
        {
            slotdate = "2,4,6";
        }
        else if (ddlslot.SelectedValue == "TTS")
        {
            slotdate = "3,5,7";
        }
        else if (ddlslot.SelectedValue == "Daily")
        {
            slotdate = "2,3,4,5,6,7";
        }
        int batchedsystem = 0;
        int totalsystem = 0;
        int freesystem = 0;
        string sdate = "";
        string str = txt_stratdate.Text;
        string[] split = str.Split('-');
        sdate = split[2] + "-" + split[1] + "-" + split[0];
        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdate + "','" + ddlslot.SelectedValue.ToString() + "','" + ddl_coursename.SelectedValue.ToString() + "')";
       // Response.Write(_Qry1);

        DataTable dtclass = new DataTable();
        dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);
        for (int i = 0; i < dtclass.Rows.Count; i++)
        {
            if (classdate == "")
            {
                classdate = "'" + dtclass.Rows[i]["classdate"].ToString() + "'";
            }
            else
            {
                classdate = classdate + ",'" + dtclass.Rows[i]["classdate"].ToString() + "'";
            }
            txt_enddate.Text = dtclass.Rows[i]["classdate"].ToString();
            string[] spenddate = txt_enddate.Text.Split('/');
            txt_enddate.Text = spenddate[1] + "/" + spenddate[0] + "/" + spenddate[2];
        }
        _Qry = "select system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "' and labid='"+ddllab.SelectedValue+"'";
        DataTable dtsys = new DataTable();
        dtsys = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtsys.Rows.Count > 0)
        {
            totalsystem =Convert.ToInt32( dtsys.Rows[0]["system"]);
        }
        _Qry = "select batchtiming,max(ss)  as batchedsystem,max(labId) as labid from (select  classdate,batchtiming,count(labId) as ss,labId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ") and labid='" + ddllab.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "'   and batchtiming='" + ddlbatch.SelectedValue + "'  group by classdate,batchtiming,labId) as ss group by batchtiming";
        DataTable dtbatch = new DataTable();
        dtbatch = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtbatch.Rows.Count > 0)
        {
            batchedsystem = Convert.ToInt32(dtbatch.Rows[0]["batchedsystem"]);
        }
        freesystem = totalsystem - batchedsystem;
     hdnfreesystem.Value = freesystem.ToString();
       // hdnfreesystem.Value = "2";
        _Qry = "select count(batchtime) from erp_facultytimedetails where facultyid='" + ddlfac.SelectedValue + "' and batchtime='" + ddlbatch.SelectedValue.ToString() + "' and day in (" + slotdate + ")";
      // Response.Write(_Qry+"<br>");
        //Response.End();
        int count = 0;
         count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
         if ((count == 6 && ddlslot.SelectedValue == "Daily") || (count == 3 && ddlslot.SelectedValue == "MWF") || (count == 3 && ddlslot.SelectedValue == "TTS"))
         {
             _Qry = "select count(facultyid) from erp_batchschedule where batchtiming='" + ddlbatch.SelectedValue.ToString() + "' and facultyid='" + ddlfac.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,classdate),101)  in (" + classdate + ")";
          // Response.Write(_Qry);
             count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
             if (count > 0)
             {
                 fillfree();
                
                
             }
             else
             {
                 if (Convert.ToInt32(hdnfreesystem.Value) > 0)
                 {


                     _Qry = @"select count(distinct studentid) from erp_batchschedule where batchcode='"+lblbatchcode.Text+"' and centrecode='"+Session["SA_centre_code"]+"'";
                     int count1 ;
                     count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                     if (count1 > Convert.ToInt32(hdnfreesystem.Value))
                     {

                         lblmsg1.Text = "Lab doesn't have enough system.";

                     }
                     else
                     {
                         tblfree.Visible = false;
                         tblstudent.Visible = false;
                         tblconform.Visible = true;
                         confrm();
                         getdetails.Visible = false;

                     }



                 }
                 else
                 {
                     fillfree();
                     
                 }

             }
         }
         else
         {
             fillfree();
             
         }
        
    }
     

     
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatch.aspx");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatch.aspx");
    }


    protected void btnconform_Click(object sender, EventArgs e)
    {
        _Qry = " update erp_batchdetails set slot='" + ddlslot.SelectedValue + "',batchtiming='" + ddlbatch.SelectedValue + "' where batchcode='" + lblbatchcode.Text + "' and status='pending'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = " update erp_batchschedule set facultyid='" + ddlfac.SelectedValue + "',labid='" + ddllab.SelectedValue + "',batchtiming='" + ddlbatch.SelectedValue + "'  where batchcode='" + lblbatchcode.Text + "' and status='pending'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        Response.Redirect("EditBatch.aspx");
       

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatch.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {


            _Qry = @"select  distinct bat.batchcode,mod.module_content,bat.moduleid,bat.slot,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
(select  CONVERT(VARCHAR(10),min( classDate ),105) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
(select  CONVERT(VARCHAR(10),max( classDate),105) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='"+Session["SA_centre_code"]+"' and bat.batchcode='" + e.CommandArgument.ToString() + "'  ";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

           
          //  Response.Write(_Qry);
            //Response.End();
          

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "pending")
                {
                    int i = dt.Rows.Count - 1;
                    getdetails.Visible = true;
                    ddlfac.SelectedValue = dt.Rows[i]["facultyid"].ToString();
                    ddllab.SelectedValue = dt.Rows[i]["labid"].ToString();
                    ddlbatch.SelectedValue = dt.Rows[i]["batchtiming"].ToString();
                    ddlslot.SelectedValue = dt.Rows[i]["slot"].ToString();
                    ddl_coursename.SelectedValue = dt.Rows[i]["moduleid"].ToString().Trim();
                    txt_stratdate.Text = dt.Rows[i]["Startdate"].ToString();
                    txt_enddate.Text = dt.Rows[i]["Enddate"].ToString();
                    lblbatchcode.Text = e.CommandArgument.ToString();
                }
                else
                {
                    getdetails.Visible = false;
                    Label1.Text = "Batch Completed, You can't do any changes";

                }
            }
        }
    }


    private void confrm()
    {
        //lblbatchcode.Text = "";
        lblmodule_name.Text = ddl_coursename.SelectedItem.ToString();
        lblslot.Text = ddlslot.SelectedItem.ToString();
        lblstartdate.Text = txt_stratdate.Text;
        lblenddate.Text = txt_enddate.Text;
        lblfac.Text = ddlfac.SelectedItem.ToString();
        lbllab.Text = ddllab.SelectedItem.ToString();
        lblbatch.Text = ddlbatch.SelectedValue;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}

