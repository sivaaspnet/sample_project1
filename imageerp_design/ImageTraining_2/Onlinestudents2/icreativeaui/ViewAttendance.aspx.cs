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

public partial class Onlinestudents2_superadmin_ViewAttendance : System.Web.UI.Page
{
    string _Qry,pages="";
    int total_days = 0;
    int count = 0;
    string presentcount = "";
    string AbsentCount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
            {
                Response.Redirect("Login.aspx");
            }
          
         
            fillbatchdetails();
            ViewState["value1"] = Request.ServerVariables["HTTP_REFERER"];
           
         
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
    }
  
   
    private void fillbatchdetails()
    {
        //_Qry = "Select Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,Batch_Time,convert(varchar(10),Batch_Startdate,103) as Batch_Startdate,convert(varchar(10),Batch_enddate,103) as Batch_Enddate ";
        //_Qry += " From Batch_Details Where Batch_Code='" + ddlbatchcode.Text + "' Group By Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,";
        //_Qry += "Batch_Time,Batch_Startdate,Batch_Enddate";
        ddlbatchcode.Text = Request.QueryString["batchcode"];
        _Qry = " select distinct bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduledate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.Text + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduledate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.Text + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid  inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode  where  bs.batchcode='" + ddlbatchcode.Text + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        //Response.Write(_Qry);
        DataTable dt10 = new DataTable();
        dt10 = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id where batchstatus='active'";
        DataTable dtab = new DataTable();
        dtab = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt10.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            txt_BatchTrack.Text = "Normal"; //dt10.Rows[0]["Batch_Track"].ToString();
            // txt_software.Text = ddlsoftwre.SelectedValue;
            txt_Module.Text = dt10.Rows[0]["module"].ToString();
            txt_Faculty.Text = dt10.Rows[0]["facultyname"].ToString();
            txt_Lab.Text = dt10.Rows[0]["labName"].ToString();
            txt_BatchSlot.Text = dt10.Rows[0]["Slot"].ToString();
            txt_BatchTime.Text = dt10.Rows[0]["batchtiming"].ToString();
            txt_Bstart.Text = dt10.Rows[0]["startdate"].ToString();
            txt_Bend.Text = dt10.Rows[0]["Enddate"].ToString();
            txt_software.Text = getsoft(dtab, "batchcode='" + ddlbatchcode.Text + "'", "software_Name");

        }
        else
        {
            tblbatch.Visible = false;
        }

        lblerror.Text = "";
        //  DataList1.Visible = false;
        Repeater1.Visible = false;
        //   Repeater2.Visible = false;
        attendance.Visible = false;
        //trvis.Visible = true;
        ArrayList StudentID = new ArrayList();
        ArrayList TotalHours = new ArrayList();
        ArrayList PresentHours = new ArrayList();

        int seelctedmonth;
        int selectedyear;
        if (ddlmonth.SelectedValue == "" || ddlmonth.SelectedValue == null)
        {
            seelctedmonth = System.DateTime.Now.Month;
        }
        else
        {
            seelctedmonth = Convert.ToInt32(ddlmonth.SelectedValue);
        }

        if (ddlyear.SelectedValue == "" || ddlyear.SelectedValue == null)
        {
            selectedyear = System.DateTime.Now.Year;
        }
        else
        {
            selectedyear = Convert.ToInt32(ddlyear.SelectedValue);
        }

        if (seelctedmonth < 10)
        {
            ddlmonth.SelectedValue = "0" + seelctedmonth.ToString();
        }
        else
        {
            ddlmonth.SelectedValue = seelctedmonth.ToString();
        }

        ddlyear.SelectedValue = selectedyear.ToString();

        _Qry = " select DATENAME(DAY,DATEADD(DAY,-1,DATEADD(Month," + ddlmonth.SelectedValue + ",'" + ddlyear.SelectedValue + "'))) as count";
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt12.Rows.Count > 0)
        {
            total_days = Convert.ToInt32(dt12.Rows[0]["count"]);
        }
        //total_days = 29;
        if (total_days == 31)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;

        }
        else if (total_days == 30)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
            //  DataList1.Visible = true;
        }
        else if (total_days == 28)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
            // Repeater2.Visible = true;
        }
        else if (total_days == 29)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
            // Repeater2.Visible = true;
        }

        TotalHours.Clear();
        // _Qry = "select batchcode,module_id,status,subcontent_id,classdate,month(classdate) as monthatt,day(classdate) as dateofatt from erp_batchcontentstatus where status='completed'  and batchcode='" + ddlbatchcode.Text + "'  and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "' ";
        _Qry = "select bs.pendingstatus,bs.studentid,bs.status as ststatus,bcs.batchcode,bcs.module_id,bcs.status,bcs.subcontent_id,bcs.classdate,month(bcs.classdate) as monthatt,day(bcs.classdate) as dateofatt,isnull(d.Student_Reason,'Not Yet Post') as Student_Reason from erp_batchcontentstatus bcs inner join erp_batchschedule bs on bs.batchcode=bcs.batchcode  and bcs.subcontent_id=bs.subcontentid left join OnlineStudent_Attendance d on d.Batch_Code=bs.batchcode and d.Student_Id=bs.studentid  and d.content_id=bcs.subcontent_id   where bs.batchstatus='active' and bcs.status='completed' and bcs.batchcode='" + ddlbatchcode.Text + "' and month(bcs.classdate)='" + ddlmonth.SelectedValue + "' and year(bcs.classdate)='" + ddlyear.SelectedValue + "' ";
        // Response.Write(_Qry);
        DataTable dtat = new DataTable();
        dtat = MVC.DataAccess.ExecuteDataTable(_Qry);
        // _Qry = "select distinct status,bs.studentid,enq_personal_name,batchcode,isnull(attendance_status,'Absent') as attendance_status,day(date_attendance) as dateofatt, month(date_attendance) as monthatt,date_attendance,date_ins from  erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid and bs.centrecode=per.centre_code left join OnlineStudent_Attendance att  on bs.batchcode=att.batch_code and bs.centrecode=att.centre_code and  bs.studentid=att.student_id where centrecode='" + Session["SA_centre_code"] + "'  and batchcode='" + ddlbatchcode.Text + "' and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "'";


        //_Qry = "select  distinct studentid,batchcode,enq_personal_name from erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid and bs.centrecode=per.centre_code where centrecode='" + Session["SA_centre_code"].ToString() + "' and batchcode='" + ddlbatchcode.Text + "'  and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "'";
        _Qry = "select bs.batchcode,bs.studentid,bs.status,enq_personal_name,subcontentid,bs.classdate,month(bs.classdate) as classmonth,day(bs.classdate) as classday from erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid  inner join erp_batchcontentstatus bcs on bcs.batchcode=bs.batchcode and bcs.subcontent_id=bs.subcontentid and bcs.status='completed' where bs.batchstatus='active' and centrecode='" + Session["SA_centre_code"].ToString() + "' and bs.batchcode='" + ddlbatchcode.Text + "'  and month(bs.classdate)='" + ddlmonth.SelectedValue + "'  and year(bs.classdate)='" + ddlyear.SelectedValue + "'";
        //Response.Write(_Qry);
        DataTable dtstudent = new DataTable();
        dtstudent = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select count(distinct subContentId) as tdays,batchcode from erp_batchschedule  group by batchcode";
        DataTable dtable = new DataTable();
        dtable = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select count(studentid) as pdays,batchcode,studentid from erp_batchschedule where  status !='Completed' and classDate <=getdate() group by studentid,batchcode";
        DataTable dtable1 = new DataTable();
        dtable1 = MVC.DataAccess.ExecuteDataTable(_Qry);




        DataTable dtattendance = new DataTable();

        dtattendance.Columns.Add(new DataColumn("Studentid", System.Type.GetType("System.String")));
        // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("studentname", System.Type.GetType("System.String")));

        dtattendance.Columns.Add(new DataColumn("pdays", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("tdays", System.Type.GetType("System.String")));

        dtattendance.Columns.Add(new DataColumn("one", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("two", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("three", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("four", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("five", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("six", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("seven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eight", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("nine", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("ten", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eleven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twelve", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("fourteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("fifteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("sixteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("seventeen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eighteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("ninteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twenty", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyone", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentytwo", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentythree", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyfour", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyfive", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentysix", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyseven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyeight", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentynine", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirty", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirtyone", System.Type.GetType("System.String")));

        DataRow dratt = dtattendance.NewRow();

        DataTable dtf = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] arg = new string[2];

        arg[0] = "studentid";
        arg[1] = "enq_personal_name";
        // arg[2] = "batchcode";
        // arg[3] = "status";
        //arg[4] = "subcontentid";
        dtf = dtstudent.DefaultView.ToTable(true, arg);


        foreach (DataRow drs in dtf.Rows)
        {
            dratt = dtattendance.NewRow();
            dratt["studentid"] = drs["studentid"];
            dratt["studentname"] = drs["enq_personal_name"];//studentid='" + drs["StudentID"].ToString() + "'  batchcode='" + drs["batchcode"].ToString() + "'  and  and subcontent_id='" + drs["subcontentid"].ToString() + "' and   and '" + drs["status"].ToString() + "'='Completed' , drs["status"].ToString()


            dratt["pdays"] = getcount(dtable1, "batchcode='" + Request.QueryString["batchcode"] + "' and studentid='" + drs["studentid"] + "'", "pdays");
            dratt["tdays"] = getcount(dtable, "batchcode='" + Request.QueryString["batchcode"] + "'", "tdays");


            dratt["one"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='1' and monthatt='" + ddlmonth.SelectedValue + "'");
            dratt["two"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='2' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["three"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='3' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["four"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='4' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["five"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='5' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["six"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='6' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["seven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='7' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eight"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='8' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["nine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='9' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["ten"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='10' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eleven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='11' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twelve"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='12' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["thirteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='13' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["fourteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='14' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["fifteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='15' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["sixteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='16' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["seventeen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='17' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eighteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='18' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["ninteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='19' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twenty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='20' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyone"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='21' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentytwo"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='22' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentythree"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='23' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyfour"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='24' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyfive"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='25' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentysix"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='26' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyseven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='27' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyeight"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='28' and monthatt='" + ddlmonth.SelectedValue + "' ");
            if (total_days == 29)
            {
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            if (total_days == 30)
            {
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='30' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            if (total_days == 31)
            {
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='30' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirtyone"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='31' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            dtattendance.Rows.Add(dratt);
        }
        if (dtattendance.Rows.Count > 0)
        {
            attendance.Visible = true;
            Repeater1.DataSource = dtattendance;
            Repeater1.DataBind();
        }
        else
        {
            lblerror.Text = "Attendance Status for the Selected batch is not in progress ";
            attendance.Visible = false;
        }
        //Response.Write("<br>"+DateTime.Now.Month+"<br>");
        //Response.Write("<br>" + DateTime.Now.Day + "<br>");













    }

    string getcount(DataTable dtexp, string expression, string column)
    {
        string count = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {


                count = (val[column].ToString());



            }
        }
        else
        {
            count = "0";
        }
        return count.ToString();

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
                    soft = soft + "," + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
       
        _Qry = " select distinct bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduledate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.Text + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduledate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.Text + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid  inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode  where  bs.batchcode='" + ddlbatchcode.Text + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
       // Response.Write(_Qry);
        DataTable dt10 = new DataTable();
        dt10 = MVC.DataAccess.ExecuteDataTable(_Qry);
        for (int i = 0; i < dt10.Rows.Count-1; i++)
        {
            dt10.Rows.RemoveAt(i);
        }
        if (dt10.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            txt_BatchTrack.Text = "Normal"; 
            txt_Module.Text = dt10.Rows[0]["module"].ToString();
            txt_Faculty.Text = dt10.Rows[0]["facultyname"].ToString();
            txt_Lab.Text = dt10.Rows[0]["labName"].ToString();
            txt_BatchSlot.Text = dt10.Rows[0]["Slot"].ToString();
            txt_BatchTime.Text = dt10.Rows[0]["batchtiming"].ToString();
            txt_Bstart.Text = dt10.Rows[0]["startdate"].ToString();
            txt_Bend.Text = dt10.Rows[0]["Enddate"].ToString();
        }
        else
        {
            tblbatch.Visible = false;
        }

        lblerror.Text = "";
    
        Repeater1.Visible = false;
    
        attendance.Visible = false;
      
        ArrayList StudentID = new ArrayList();
        ArrayList TotalHours = new ArrayList();
        ArrayList PresentHours = new ArrayList();

        int seelctedmonth;
        int selectedyear;
        if (ddlmonth.SelectedValue == "" || ddlmonth.SelectedValue == null)
        {
            seelctedmonth = System.DateTime.Now.Month;
        }
        else
        {
            seelctedmonth = Convert.ToInt32(ddlmonth.SelectedValue);
        }

        if (ddlyear.SelectedValue == "" || ddlyear.SelectedValue == null)
        {
            selectedyear = System.DateTime.Now.Year;
        }
        else
        {
            selectedyear = Convert.ToInt32(ddlyear.SelectedValue);
        }

        if (seelctedmonth < 10)
        {
            ddlmonth.SelectedValue ="0"+ seelctedmonth.ToString();
        }
        else
        {
            ddlmonth.SelectedValue = seelctedmonth.ToString();
        }

        ddlyear.SelectedValue = selectedyear.ToString();

        _Qry = " select DATENAME(DAY,DATEADD(DAY,-1,DATEADD(Month," + ddlmonth.SelectedValue + ",'" + ddlyear.SelectedValue + "'))) as count";
       // Response.Write(_Qry);
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt12.Rows.Count > 0)
        {
            total_days = Convert.ToInt32(dt12.Rows[0]["count"]);
        }
        //total_days = 29;
        if (total_days == 31)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
           
        }
        else if (total_days == 30)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
          //  DataList1.Visible = true;
        }
        else if (total_days == 28)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
           // Repeater2.Visible = true;
        }
        else if (total_days == 29)
        {
            attendance.Visible = true;
            Repeater1.Visible = true;
            // Repeater2.Visible = true;
        }
        
        TotalHours.Clear();
       // _Qry = "select batchcode,module_id,status,subcontent_id,classdate,month(classdate) as monthatt,day(classdate) as dateofatt from erp_batchcontentstatus where status='completed'  and batchcode='" + ddlbatchcode.Text + "'  and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "' ";
       _Qry = "select bs.studentid,bs.status as ststatus,bcs.batchcode,bcs.module_id,bcs.status,bcs.subcontent_id,bcs.classdate,month(bcs.classdate) as monthatt,day(bcs.classdate) as dateofatt,d.Student_Reason,bs.pendingstatus from erp_batchcontentstatus bcs inner join erp_batchschedule bs on bs.batchcode=bcs.batchcode   and bcs.subcontent_id=bs.subcontentid left join OnlineStudent_Attendance d on d.Batch_Code=bs.batchcode and d.Student_Id=bs.studentid   and d.content_id=bcs.subcontent_id  where bs.batchstatus='active' and bcs.status='completed' and bcs.batchcode='" + ddlbatchcode.Text + "' and month(bcs.classdate)='" + ddlmonth.SelectedValue + "' and year(bcs.classdate)='" + ddlyear.SelectedValue + "' ";
       // Response.Write(_Qry);
        DataTable dtat = new DataTable();
       dtat = MVC.DataAccess.ExecuteDataTable(_Qry);
       // _Qry = "select distinct status,bs.studentid,enq_personal_name,batchcode,isnull(attendance_status,'Absent') as attendance_status,day(date_attendance) as dateofatt, month(date_attendance) as monthatt,date_attendance,date_ins from  erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid and bs.centrecode=per.centre_code left join OnlineStudent_Attendance att  on bs.batchcode=att.batch_code and bs.centrecode=att.centre_code and  bs.studentid=att.student_id where centrecode='" + Session["SA_centre_code"] + "'  and batchcode='" + ddlbatchcode.Text + "' and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "'";

        
        //_Qry = "select  distinct studentid,batchcode,enq_personal_name from erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid and bs.centrecode=per.centre_code where centrecode='" + Session["SA_centre_code"].ToString() + "' and batchcode='" + ddlbatchcode.Text + "'  and month(classdate)='" + ddlmonth.SelectedValue + "'  and year(classdate)='" + ddlyear.SelectedValue + "'";
        _Qry = "select bs.batchcode,bs.studentid,bs.status,enq_personal_name,subcontentid,bs.classdate,month(bs.classdate) as classmonth,day(bs.classdate) as classday from erp_batchschedule bs inner join adm_personalparticulars per on per.student_id=bs.studentid  inner join erp_batchcontentstatus bcs on bcs.batchcode=bs.batchcode and bcs.subcontent_id=bs.subcontentid and bcs.status='completed' where  bs.batchstatus='active' and centrecode='" + Session["SA_centre_code"].ToString() + "' and bs.batchcode='" + ddlbatchcode.Text + "'  and month(bs.classdate)='" + ddlmonth.SelectedValue + "'  and year(bs.classdate)='" + ddlyear.SelectedValue + "'";
        //Response.Write(_Qry);
        DataTable dtstudent = new DataTable();
        dtstudent = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select count(distinct subContentId) as tdays,batchcode from erp_batchschedule  group by batchcode";
        DataTable dtable = new DataTable();
        dtable = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select count(status) as pdays,batchcode,studentid from erp_batchschedule where  status !='completed' and classDate <=getdate() group by studentid,batchcode";
        DataTable dtable1 = new DataTable();
        dtable1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        

        DataTable dtattendance = new DataTable();

        dtattendance.Columns.Add(new DataColumn("Studentid", System.Type.GetType("System.String")));
        // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("studentname", System.Type.GetType("System.String")));

        dtattendance.Columns.Add(new DataColumn("pdays", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("tdays", System.Type.GetType("System.String")));

        dtattendance.Columns.Add(new DataColumn("one", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("two", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("three", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("four", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("five", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("six", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("seven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eight", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("nine", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("ten", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eleven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twelve", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("fourteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("fifteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("sixteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("seventeen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("eighteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("ninteen", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twenty", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyone", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentytwo", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentythree", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyfour", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyfive", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentysix", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyseven", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentyeight", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("twentynine", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirty", System.Type.GetType("System.String")));
        dtattendance.Columns.Add(new DataColumn("thirtyone", System.Type.GetType("System.String")));
       
        DataRow dratt = dtattendance.NewRow();

        DataTable dtf = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] arg = new string[2];

        arg[0] = "studentid";
        arg[1] = "enq_personal_name";
       // arg[2] = "batchcode";
       // arg[3] = "status";
        //arg[4] = "subcontentid";
        dtf = dtstudent.DefaultView.ToTable(true, arg);


        foreach (DataRow drs in dtf.Rows)
        {
            dratt = dtattendance.NewRow();
            dratt["studentid"] = drs["studentid"];
            dratt["studentname"] = drs["enq_personal_name"];//studentid='" + drs["StudentID"].ToString() + "'  batchcode='" + drs["batchcode"].ToString() + "'  and  and subcontent_id='" + drs["subcontentid"].ToString() + "' and   and '" + drs["status"].ToString() + "'='Completed' , drs["status"].ToString()


            dratt["pdays"] = getcount(dtable1, "batchcode='" + Request.QueryString["batchcode"] + "' and studentid='" + drs["studentid"] + "'", "pdays");
            dratt["tdays"] = getcount(dtable, "batchcode='" + Request.QueryString["batchcode"] + "'", "tdays");

            dratt["one"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='1' and monthatt='" + ddlmonth.SelectedValue + "'");
            dratt["two"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='2' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["three"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='3' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["four"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='4' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["five"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='5' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["six"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='6' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["seven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='7' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eight"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='8' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["nine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='9' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["ten"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='10' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eleven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='11' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twelve"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='12' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["thirteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='13' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["fourteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='14' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["fifteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='15' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["sixteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='16' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["seventeen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='17' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["eighteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='18' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["ninteen"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='19' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twenty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='20' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyone"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='21' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentytwo"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='22' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentythree"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='23' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyfour"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='24' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyfive"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='25' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentysix"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='26' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyseven"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='27' and monthatt='" + ddlmonth.SelectedValue + "' ");
            dratt["twentyeight"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='28' and monthatt='" + ddlmonth.SelectedValue + "' ");
            if (total_days == 29)
            {             
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            if (total_days == 30)
            {
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='30' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            if (total_days == 31)
            {
                dratt["twentynine"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='29' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirty"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='30' and monthatt='" + ddlmonth.SelectedValue + "' ");
                dratt["thirtyone"] = getattendancedetails(dtat, "studentid='" + drs["StudentID"].ToString() + "' and dateofatt='31' and monthatt='" + ddlmonth.SelectedValue + "' ");
            }
            dtattendance.Rows.Add(dratt);
        }
        if (dtattendance.Rows.Count > 0)
        {
            attendance.Visible = true;
            Repeater1.DataSource = dtattendance;
            Repeater1.DataBind();
        }
        else
        {
            lblerror.Text = "Attendance Status for the Selected batch is not in progress ";
            attendance.Visible = false;
        }
        //Response.Write("<br>"+DateTime.Now.Month+"<br>");
        //Response.Write("<br>" + DateTime.Now.Day + "<br>");

    }
    string getsts(DataTable dtexp, string expression)
    {
        string res = "";
         DataRow[] dr = new DataRow[100];
         dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (res == "")
                {
                    res = val["status"].ToString();
                }
                else
                {
                    res=res+","+val["status"].ToString();
                }
            }
        }
        return res.ToString();
    }

    string getattendancedetails(DataTable dtexp, string expression)
    {
        string attend = "-";
        string reason = "";
        string pstatus = "";
        DataRow[] dr = new DataRow[100];
       // string status = column;
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                attend = (val["ststatus"].ToString().Trim());
                reason = (val["Student_Reason"].ToString().Trim());
                pstatus = (val["pendingstatus"].ToString().Trim());
                if (pstatus=="Pending" && attend == "Completed" || attend == "completed")
                {
                    attend = "<span style='color:Green; font-weight:bold;'>P</span>";
                }
                else if (pstatus == "Pending" && attend == "Pending" || attend == "pending" || attend == "Repending" || attend == "repending")
                {
                   // attend = "<a href='' rel='htmltooltip' style='color:Red; font-weight:bold;'><div class='htmltooltip'>" + val["Student_Reason"] + "</div>A</a>"; //attend + "," + 
                    attend = "<span style='color:Red; font-weight:bold;'>A</span>"; //attend + "," + 
                }
                else 
                {
                    attend = "<span style='color:Orange; font-weight:bold;'>C</span>";
                }
               
            }
        }


        return attend.ToString();
    }
  
  

 
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAttendance.aspx");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("" + ViewState["value1"] + "");
    }
}
