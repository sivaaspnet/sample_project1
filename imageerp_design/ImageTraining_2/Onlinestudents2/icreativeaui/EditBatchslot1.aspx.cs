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

public partial class superadmin_EditBatchslot1 : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, centrcode, couname, couid, todate, holdate, qry111, os = "";
    string batchqry = "";
    string mainqry = "";
    int noofcls, weekday,endate;
    int yy = 0;
    string soft = "";
    string classdate = "";
    string classdatemwf = "";
    string classdatetts = "";
    DateTime stdate, lastday;
    string rr = "";
    string facid = "";
    string labtime = "";
    string labcode = "";
    DataTable status = new DataTable();
    string confirmation = "<table class='common' border='1px' width=350><tr><th>Class date</th><th>Content</th></tr> ";
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
            displaycourseonload();
            display_facultyddl();
            display_facultydd2();
            display_labddl();
            Button1.Visible = false;
            fillgrid();
         
        }
       
    }
    

        private void display_facultydd2()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("Select", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlfac.DataSource = dt;
        ddlfac.DataValueField = "faculty_id";
        ddlfac.DataTextField = "facultyname";
        ddlfac.DataBind();
        ddlfac.Items.Insert(0, new ListItem("All", ""));
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
        _Qry = @"select distinct bat.batchcode,bat.status,max(mod.module_id) as module_id,max(mod.module_content) as module_content,dbo.weekdays1(bat.slotday) as slotday,bat.slot,bat.batchtiming,max(bat.status) as status ,sce.labid,sce.facultyid,
max(lab.labname) as labname,max(facultyname) as facultyname, CONVERT(VARCHAR(10),min( sts.scheduledate ),103) as Startdate,
CONVERT(VARCHAR(10),max( sts.classDate ),103) as Enddate  from
 erp_batchdetails bat inner join module_details mod on moduleid=module_id   inner join 
erp_batchschedule sce on sce.batchcode=bat.batchcode inner join 
online_students_labavail lab on lab.labid=sce.labid inner join 
erp_batchcontentstatus sts on sts.batchcode=bat.batchcode and sts.batchstatus='active' inner join
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='" + Session["SA_centre_code"].ToString() + "' and year(sce.classdate)='" + ddlyear.SelectedValue + "' ";
        if (ddlmonth.SelectedValue != "")
        {
            _Qry += "  and month(sce.classdate)='" + ddlmonth.SelectedValue + "' ";
        }

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
            _Qry += "  and facultyid='" + ddl_fac.SelectedValue + "' ";
        }

        //if (DropDownList1.SelectedValue != "")
        //{
        //    _Qry += "  and  bat.status='" + DropDownList1.SelectedValue + "' ";
        //}


        _Qry += "  group by bat.batchcode,sce.facultyid,sce.labid,bat.batchtiming,bat.slot,bat.slotday,bat.status  order by batchcode desc";
        //Response.Write(_Qry);
        //Response.End();


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);


        //_Qry = @"select * from erp_batchdetails";
        //if (DropDownList1.SelectedValue != "")
        //{
        //    _Qry += "  where  status='" + DropDownList1.SelectedValue + "' ";
        //}

        //Response.Write(_Qry);
        //DataTable dt2 = new DataTable();
        //dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id where batchstatus='active'";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        status.Columns.Add(new DataColumn("software", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("software_id", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("module_content", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("module_id", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("slot", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchtiming", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("labname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("facultyname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Startdate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Enddate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("slotday", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();


        DataTable dt21 = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] args = new string[5];
        args[0] = "batchcode";
        args[1] = "module_content";
        args[2] = "Startdate";
        args[3] = "Enddate";
        args[4] = "module_id";



        dt21 = dt.DefaultView.ToTable(true, args);


        foreach (DataRow drs in dt21.Rows)
        {

            dr = status.NewRow();
            dr["batchcode"] = drs["batchcode"];
            dr["software_id"] = getsoft1(dt2, "batchcode='" + drs["batchcode"] + "'", "Software_id");
            dr["software"] = getsoft(dt2, "batchcode='" + drs["batchcode"] + "'", "software_Name");
            dr["module_content"] = drs["module_content"];
            dr["module_id"] = drs["module_id"];
            dr["slot"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "slot");
            dr["batchtiming"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "batchtiming");
            dr["labname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "labname");
            // dr["facultyname"] = drs["facultyname"];
            dr["facultyname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "facultyname");
            dr["Startdate"] = drs["Startdate"];
            dr["Enddate"] = drs["Enddate"];
           dr["status"] = getstatus(dt, "batchcode='" + drs["batchcode"] + "'");
           dr["slotday"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "slotday");
            status.Rows.Add(dr);

        }
        if (status.Rows.Count <= 0)
        {
            t1.Visible = false;
            d1.Visible = false;
            d2.Visible = false;
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
                Image img1 = new Image();
                img1 = (Image)gr.FindControl("suspend");
                img1.Visible = false;
                Image img2 = new Image();
                img2 = (Image)gr.FindControl("change");
                img2.Visible = false;
            }
            


        }

    }


    string getsoft(DataTable dtexp, string expression, string column)
    {
        string soft = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (soft == "")
                {
                    soft = (val[column].ToString());
                }
                else if (soft == (val[column].ToString()))
                {
                    soft = (val[column].ToString());

                }
                else
                {
                    soft = soft + "<br>" + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

    }

    string getsoft1(DataTable dtexp, string expression, string column)
    {
        string soft = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (soft == "")
                {
                    soft = (val[column].ToString());
                }
                else if (soft == (val[column].ToString()))
                {
                    soft = (val[column].ToString());

                }
                else
                {
                    soft = soft + "," + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

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
                if (split[i].ToString() == "pending" || split[i].ToString() == "Pending" || split[i].ToString() == "Repending")
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
       
        string values = "", valuesmwf = "", valuestts = "";

        string sdatetest = "";
        string strtest = txt_stratdate.Text;
        string[] splittest = strtest.Split('-');
        sdatetest = splittest[2] + "-" + splittest[1] + "-" + splittest[0];

        int chkcount = 0;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                values += CheckBoxList2.Items[i].Value + ",";


                if (Convert.ToInt32(CheckBoxList2.Items[i].Value) == 2 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 4 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 6)
                {
                    valuesmwf += CheckBoxList2.Items[i].Value + ",";
                }
                if (Convert.ToInt32(CheckBoxList2.Items[i].Value) == 3 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 5 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 7)
                {
                    valuestts = CheckBoxList2.Items[i].Value + ",";
                }



                chkcount += 1;
            }
        }


        values = values.TrimEnd(',');


      
            _Qry1 = "select convert(varchar,classdate,101) as classdate from [sppendingclassdate]('" + sdatetest + "','MWF','" + ViewState["batchcode"].ToString() + "')";
       
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

        // classdatemwf = classdatemwf.TrimEnd(',');
     
            _Qry1 = "select convert(varchar,classdate,101) as classdate from [sppendingclassdate]('" + sdatetest + "','MWF','" + ViewState["batchcode"].ToString() + "')";
      
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



        _Qry1 = " select batchtiming,max(ss)  as batched,max(facultyId) as facultyId,convert(varchar,classdate,101) as classdate from (select   convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(facultyid) as ss,facultyId from erp_batchSchedule sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf + "," + classdatetts + ")  and centrecode='" + Session["SA_centre_code"].ToString() + "' and sce.batchstatus='active' group by classdate,batchtiming,facultyid) as ss group by batchtiming,facultyId,convert(varchar,classdate,101)";
        //Response.Write(_Qry1);
        DataTable dtfac = new DataTable();
        dtfac = MVC.DataAccess.ExecuteDataTable(_Qry1);
        _Qry = " select faculty_id,ft.day,batchtime,facultyname from onlinestudentsfacultydetails fac inner join [erp_facultytimedetails] ft on ft.facultyid=fac.faculty_id  where  fac.centre_code='" + Session["SA_centre_code"].ToString() + "' and status='Enable'";
       // Response.Write("<br/>"+_Qry);
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



            valuesmwf = valuesmwf.TrimEnd(',');
            valuestts = valuestts.TrimEnd(',');
            HiddenField2.Value = values.ToString();

            slotdate = HiddenField2.Value;


            if (valuesmwf.ToString() == "")
            {
                valuesmwf = "0";
            }
            if (valuestts.ToString() == "")
            {
                valuestts = "0";
            }


            //Response.Write(valuesmwf);
            //Response.End();

            //Response.Write(valuestts);

            //else if (ddlslot.SelectedValue == "Daily")
            //{
            //    slotdate = "2,3,4,5,6,7";
            //}
            drfac = freefaculty.NewRow();
            drfac["facultyname1"] = drs["facultyname"];
            // dr["classdate1"] = "";
            drfac["sevenmwf"] = "-";
            drfac["seventts"] = "-";
            string mwfstring = "";
            string ttsstring = "";
            string res;
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='7AMto9AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["sevenmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='7AMto9AM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='9AMto11AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["ninemwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='9AMto11AM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='11AMto1PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["elevenmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='11AMto1PM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='1PMto3PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["onepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='1PMto3PM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='3PMto5PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["threepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='3PMto5PM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='5PMto7PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["fivepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='5PMto7PM'") > 0)
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
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='7PMto9PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    ttsstring = "MWF:" + res;
                    drfac["sevenpmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='7PMto9PM'") > 0)
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
        _Qry = "select convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(labId) as batchedlab,labId from erp_batchSchedule  sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf + ") and centrecode='" + Session["SA_centre_code"].ToString() + "' and sce.batchstatus='active' group by batchtiming,labId,convert(varchar(10),dateadd(d,0,classdate),101)";
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
        string[] args = new string[3];

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
            dr["sevenmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
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
        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spcustomclassdate]('" + sdate + "','" + values + "','" + os + "','" + ddl_coursename.SelectedValue + "')";
        // Response.Write(_Qry1);
        DataTable dtclass = new DataTable();
        dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);
        string qry = " select Submodule_id,ModuleId,software_id,Module,Software,Content from submodule_details_new where status='Active' and moduleid='" + ddl_coursename.SelectedValue + "' and software_id in (" + os + ") order by classOrder,submodule_id";
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
        string[] args1 = new string[2];

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
        //lbl_slotdetail.Text = ddlslot.SelectedItem.Text;
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
        string slotdate = "",values="";
        lblmsg1.Text = "";

        int chkcount = 0;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                values += CheckBoxList2.Items[i].Value + ",";
                chkcount += 1;
            }

        }

        // Response.Write(slotdate);
        values = values.TrimEnd(',');
        HiddenField2.Value = values.ToString();
        slotdate = values.ToString();

        int batchedsystem = 0;
        int totalsystem = 0;
        int freesystem = 0;
        string sdate = "";
        string str = txt_stratdate.Text;
        string[] split = str.Split('-');
        sdate = split[2] + "-" + split[1] + "-" + split[0];

        int n;
        for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
        {
            if (CheckBoxList1.Items[n].Selected)
            {
                if (os == "")
                {
                    os =  CheckBoxList1.Items[n].Value;
                }
                else
                {
                    os = os + "," + CheckBoxList1.Items[n].Value;
                }

            }
            //}
        }



        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spcustomclassdate]('" + sdate + "','" + values + "','" + os + "' ,'" + ddl_coursename.SelectedValue + "')";
        //Response.Write(_Qry1);
        //Response.End();
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
        _Qry = "select system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "' and labid='" + ddllab.SelectedValue + "'";
        DataTable dtsys = new DataTable();
        dtsys = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtsys.Rows.Count > 0)
        {
            totalsystem = Convert.ToInt32(dtsys.Rows[0]["system"]);
        }
        _Qry = "select batchtiming,min(ss)  as batchedsystem,min(labId) as labid from (select  classdate,batchtiming,count(labId) as ss,labId from erp_batchSchedule sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ") and labid='" + ddllab.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "'   and batchtiming='" + ddlbatch.SelectedValue + "' and sce.batchstatus='active'  group by classdate,batchtiming,labId) as ss group by batchtiming";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dtbatch = new DataTable();
        dtbatch = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtbatch.Rows.Count > 0)
        {
            batchedsystem = Convert.ToInt32(dtbatch.Rows[0]["batchedsystem"]);
        }
        freesystem = totalsystem - batchedsystem;
        hdnfreesystem.Value = freesystem.ToString();
        //hdnfreesystem.Value = "2";
        _Qry = "select count(batchtime) from erp_facultytimedetails where facultyid='" + ddlfac.SelectedValue + "' and batchtime='" + ddlbatch.SelectedValue.ToString() + "' and day in (" + slotdate + ")";
        //Response.Write(_Qry+"<br>");
        //Response.End();
        int count = 0;
        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (count == chkcount)
        {

            _Qry = "select count(facultyid) from erp_batchschedule sce inner join erp_batchcontentstatus sts on sts.batchcode=sce.batchcode where sce.batchtiming in ('" + ddlbatch.SelectedValue.ToString() + "','" + ddlbatch0.SelectedValue.ToString() + "')  and facultyid='" + ddlfac.SelectedValue + "' and sce.centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,sce.classdate),101)  in (" + classdate + ") and sts.status='Pending' and sce.batchstatus='active' and sce.batchcode !='" + ViewState["batchcode"] + "' ";
            //Response.Write(_Qry);
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                fillfree();
                showBox("Faculty Is Not Free..!");
                /// faculty does not exist
            }
            else
            {
                if (Convert.ToInt32(hdnfreesystem.Value) >= 0)
                {
                    tblfree.Visible = false;
                    tblstudent.Visible = false;
                    tblconform.Visible = true;
                    confrm();
                    getdetails.Visible = false;
                    //fillgrid();
                }
                else
                {
                    fillfree();
                    showBox("Lab Is Not Free..!");
                }

            }
        }
        else
        {
            fillfree();
            showBox("Faculty  Is Not Free...!");

        }
        
    }
     

     
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatchslot.aspx");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatchslot.aspx");
    }


    protected void btnconform_Click(object sender, EventArgs e)
    {
        string batchtime = "";
        string sdate = txt_stratdate.Text;
        string[] split = sdate.Split('-');
        sdate = split[2] + "-" + split[1] + "-" + split[0];
        string values="",slotdate="";


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
        else if (ddlslot.SelectedValue == "custom" || ddlslot.SelectedValue == "Zip")
        {

         for (int i = 0; i < CheckBoxList2.Items.Count; i++)
         {
             if (CheckBoxList2.Items[i].Selected)
             {
                 values += CheckBoxList2.Items[i].Value + ",";
                 
             }
         }


         // Response.Write(chkcount);
         values = values.TrimEnd(',');
         slotdate = values.ToString();

        }
        string timebatch = "";

        if (ddlslot.SelectedValue != "Zip")
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spcustompendingclassdate]('" + sdate + "','" + slotdate + "','" + ViewState["batchcode"] + "')";

            timebatch = ddlbatch.SelectedValue.ToString();
        }
        else
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spzipclassdatepending]('" + sdate + "','" + slotdate + "','" + ViewState["batchcode"] + "')";

            timebatch = ddlbatch.SelectedValue.ToString() + "," +ddlbatch0.SelectedValue.ToString();
        }
        
        
        
        DataTable dtdate = new DataTable();
        dtdate = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry1 = " select * from erp_batchcontentstatus where batchcode='" + ViewState["batchcode"] + "' and status='pending'";
        DataTable dtpend = new DataTable();
        dtpend = MVC.DataAccess.ExecuteDataTable(_Qry1);
        _Qry1 = "";
        int k = 0;
        string batch1 = "";
        for (int i = 0; i < dtpend.Rows.Count; i++)
        {
            if (k == 0)
            {
                batch1 = ddlbatch.SelectedValue;
                k += 1;
            }
            else
            {
                batch1 = ddlbatch0.SelectedValue;
                k = 0;
            }
            _Qry += " update erp_batchdetails set slot='" + ddlslot.SelectedValue + "',batchtiming='" + timebatch + "',slotday='" + slotdate + "' where batchcode='" + ViewState["batchcode"] + "' and status='pending'";
            _Qry += " update erp_batchcontentstatus set editdate=getdate(),remarks= 'Batch Edited : '+'" + TextBox1.Text + "', classdate='" + dtdate.Rows[i]["classdate"] + "' where batchcode='" + ViewState["batchcode"] + "' and subcontent_id='" + dtpend.Rows[i]["subcontent_id"] + "'  ";
            _Qry += " update erp_batchschedule set classdate='" + dtdate.Rows[i]["classdate"] + "',facultyid='" + ddlfac.SelectedValue + "',labid='" + ddllab.SelectedValue + "',batchtiming='" + batch1 + "'  where batchcode='" + ViewState["batchcode"] + "' and  subcontentid='" + dtpend.Rows[i]["subcontent_id"] + "'";
            
        }
     // Response.Write(_Qry);
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        Response.Redirect("EditBatchslot.aspx");

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBatchslot.aspx");
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
            ddl_coursename.Enabled = false;
            CheckBoxList1.Enabled = false;
            _Qry = @"select  distinct bat.batchcode,mod.module_content,bat.moduleid,bat.slot,bat.slotday,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
(select  CONVERT(VARCHAR(10),min( classDate ),105) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
(select  CONVERT(VARCHAR(10),max( classDate),105) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='"+Session["SA_centre_code"]+"' and bat.batchcode='" + e.CommandArgument.ToString() + "'  ";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "pending" || dt.Rows[0]["status"].ToString() == "Pending")
                {
                    ViewState.Clear();
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
                    ViewState["batchcode"] = e.CommandArgument.ToString();



                    string sw = dt.Rows[i]["slotday"].ToString();
                    string sw1 = sw;
                    string[] strSplit = sw1.Split(',');


                    foreach (ListItem list in CheckBoxList2.Items)
                    {
                        list.Selected = false;
                    }

                    for (int k = 0; k < strSplit.Length; k++)
                    {
                        if (strSplit[k] != "")
                        {

                         string   swa = strSplit[k].ToString();

                            foreach (ListItem list in CheckBoxList2.Items)
                            {
                                ListItem lst = new ListItem();

                                lst = CheckBoxList2.Items.FindByValue(swa);

                                lst.Selected = true;
                            }
                        }

                    }











                     fillsoft();
                     tblstudent.Visible = false;

                }
                else
                {
                  getdetails.Visible = false;
                    Label1.Text = "Batch Completed, You can't do any changes";

                }
            }
            _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id ";
            DataTable dt2 = new DataTable();
            dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
            string value = getsoft1(dt2, "batchcode='" + e.CommandArgument.ToString() + "'", "software_id");

            string[] strSplitArr = value.Split(',');

         
           
            for (int k = 0; k < strSplitArr.Length; k++)
            {
                if (strSplitArr[k] != "")
                {

                  string  swa = strSplitArr[k].ToString();

                  foreach (ListItem item in CheckBoxList1.Items)
                  {
                      if (item.Value == swa)
                      {
                          item.Selected = true;
                          //CheckBoxList1.Items[0].Selected = true;
                      }
                  }

                }

            }


            
        }

        //
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
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddl_coursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsoft();
    }
    private void fillsoft()
    {

        _Qry = "select software_id from module_details where module_id='" + ddl_coursename.SelectedValue + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {

            CheckBoxList1.Items.Clear();
            soft = dt.Rows[0]["software_id"].ToString();
            _Qry = "select software_id,software_name from Onlinestudent_Software where software_id in (select data as dat from SplitString('" + soft + "',','))";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            CheckBoxList1.DataSource = dt1;
            CheckBoxList1.DataTextField = "software_name";
            CheckBoxList1.DataValueField = "software_id";
            CheckBoxList1.DataBind();
            //CheckBoxList1.Items.Insert(0, new ListItem("Select All", ""));

        }


    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkedit_Click(object sender, EventArgs e)
    {

    }
}

