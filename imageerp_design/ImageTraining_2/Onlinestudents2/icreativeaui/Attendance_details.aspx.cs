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

public partial class Onlinestudents2_Attendance_details : System.Web.UI.Page
{
    int noofcls;
    string BatchCount, batch_code, couname, couid, todate, holdate,moduleid,sotwareid,contentid;
    DateTime stdate, lastday;
    string _Qry, os="", os1="", swa, os2="";
    DataTable dt = new DataTable();
    DataTable dtattendance = new DataTable();
    DataTable dtpending = new DataTable();
    DataTable dtnoofpending = new DataTable();
    int cancelledclass = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["batchcode"] != null)
            {  
                fillpageloaddata();       
                fillabsentstudents();          
            }
        }
    }

    private void fillabsentstudents()
    {
        _Qry = @" select enq_personal_name,att.software_name,bd.batchcode,bc.module_id,bc.subcontent_id,convert(varchar,bc.classdate,103) as clsdate,bc.software_id,bs.batchtiming,bs.studentid,att.attendance_id,att.class_content 
            from erp_batchcontentstatus bc inner join erp_batchdetails bd on bd.batchcode=bc.batchcode and bd.centrecode='" + Session["SA_centre_code"] + @"' and bc.status='completed'
            inner join erp_batchschedule bs on bs.batchcode=bc.batchcode and bc.subcontent_id=bs.subcontentid and bs.status='pending' inner join adm_personalparticulars per on per.student_id=bs.studentid 
            left join onlinestudent_attendance att on att.batch_code=bd.batchcode and bs.studentid=att.student_id and att.content_id=bs.subcontentid and attendance_status='Absent' and (student_reason is null or student_reason='')
            where bd.batchcode='" + Request.QueryString["batchcode"] + "' and bs.status='pending' and bc.status='completed' and attendance_status='Absent' and (student_reason is null or student_reason='')";
        //Response.Write(_Qry);
        DataTable dtgetstudents = new DataTable();
        dtgetstudents = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvclasscontent.DataSource = dtgetstudents;
        gvclasscontent.DataBind();
        if (dtgetstudents.Rows.Count > 0)
        {
            divupdateprevious.Visible = true;
        }
        else
        {
            divupdateprevious.Visible = false;
        }
    }

    private void fillpageloaddata()
    {
        _Qry = "select distinct bd.slotday,bs.software_id,bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where fac.facultyname='" + Session["SA_Username"] + "' and   bs.batchcode='" + Request.QueryString["batchcode"] + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_modulecontent.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["module"].ToString());
            hdnslotday.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slotday"].ToString());
            txt_BatchCode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["BatchCode"].ToString());
            txt_BatchSlot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
            txt_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
            txt_BatchTrack.Text = "Normal";// MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
            txt_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Facultyname"].ToString());
            txt_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
            txt_startdate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["startdate"].ToString());
            txt_enddate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["enddate"].ToString());
            _Qry += " and bs.classdate<=getdate() and bs.status='pending'  order by  bs.subcontentid,bs.classdate";
            dtattendance = MVC.DataAccess.ExecuteDataTable(_Qry);
            gvattendance.DataSource = dtattendance;
            gvattendance.DataBind();
            hdnclasscount.Value = gvattendance.Rows.Count.ToString();
            if (dtattendance.Rows.Count > 0)
            {
                if (Convert.ToDateTime(dtattendance.Rows[0]["correctdate"]) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                {
                    trattendancegrid.Visible = false;
                    trconductcancel.Visible = true;
                }
                //else if (Convert.ToDateTime(dtattendance.Rows[0]["correctdate"]) == Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                //{
                //    trattendancegrid.Visible = true;
                //    trconductcancel.Visible = false;
                //}
            }
            else
            {
                lblmsg1.Text = " No class today Or Already attendance posted";
                trattendancegrid.Visible = false;
            }
        }
        fillstudents();
        fillgrid();
    }

    private void fillgrid()
    {
        _Qry = "Select Software_Name,Class_Content,isnull(Reason,'-') as Reason from Onlinestudent_MasterAttendance as ma Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Session["fillgriddata"] = (DataTable)dt;
        GridView1.DataSource = Session["fillgriddata"];
        GridView1.DataBind();
    }

    private void fillstudents()
    {
        _Qry = "select distinct studentid,enq_personal_name from erp_batchschedule bs inner join adm_personalparticulars p on p.student_id=bs.studentid and p.centre_code=bs.centrecode and bs.batchstatus='active' where batchcode='" + Request.QueryString["batchcode"].ToString() + "'  and centrecode='" + Session["SA_centre_code"] + "'";
        DataTable dtfillstudents = new DataTable();
        dtfillstudents = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvstudents.DataSource = dtfillstudents;
        gvstudents.DataBind();
        hdntotalcount.Value = dtfillstudents.Rows.Count.ToString();
    }

    protected void btnconducted_Click(object sender, EventArgs e)
    {
        hdncoductorcancel.Value = "conducted";
        trattendancegrid.Visible = true;
        trconductcancel.Visible = false;
    }
    protected void btncancelled_Click(object sender, EventArgs e)
    {
        hdncoductorcancel.Value = "postponed";
        string sdate = DateTime.Now.ToString("MM-dd-yyyy");
        if (txt_BatchSlot.Text != "Zip")
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spcustompendingclassdate]('" + sdate + "','" + hdnslotday.Value + "','" + Request.QueryString["batchcode"] + "')";
        }
        else
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spzipclassdatepending]('" + sdate + "','" + hdnslotday.Value + "','" + Request.QueryString["batchcode"] + "')";
        }
        DataTable dtdate = new DataTable();
        dtdate = MVC.DataAccess.ExecuteDataTable(_Qry);
        string _Qry1 = " select * from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "' and status='pending'";
        DataTable dtpend = new DataTable();
        dtpend = MVC.DataAccess.ExecuteDataTable(_Qry1);
        _Qry1 = "";
        for (int i = 0; i < dtpend.Rows.Count; i++)
        {
            _Qry1 = " update erp_batchcontentstatus set classdate='" + dtdate.Rows[i]["classdate"] + "' where batchcode='" + Request.QueryString["batchcode"] + "' and subcontent_id='" + dtpend.Rows[i]["subcontent_id"] + "'  ";
            _Qry1 += " update erp_batchschedule set classdate='" + dtdate.Rows[i]["classdate"] + "'  where batchcode='" + Request.QueryString["batchcode"] + "' and  subcontentid='" + dtpend.Rows[i]["subcontent_id"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
        }
        //fillpageloaddata(); 
        Response.Redirect("Attendance_details.aspx?batchcode=" + Request.QueryString["batchcode"] + "");
    }
    protected void btnpostattendance_Click(object sender, EventArgs e)
    {
        if (gvattendance.Rows.Count > 0)
        {
            foreach (GridViewRow gratt in gvattendance.Rows)
            {
                HiddenField gvatt_hdnsoftware = (HiddenField)gratt.FindControl("gvatt_hdnsoftware");
                HiddenField gvatt_hdnmodule = (HiddenField)gratt.FindControl("gvatt_hdnmodule");
                HiddenField gvatt_hdnmodulename = (HiddenField)gratt.FindControl("gvatt_hdnmodulename");
                HiddenField gvatt_hdncontent = (HiddenField)gratt.FindControl("gvatt_hdncontent");
                HiddenField gvatt_classdate = (HiddenField)gratt.FindControl("gvatt_classdate");
                Label gvatt_lblsoftware = (Label)gratt.FindControl("gvatt_lblsoftware");
                Label gvatt_lblcontent = (Label)gratt.FindControl("gvatt_lblcontent");
                Label gvatt_lblbatchtime = (Label)gratt.FindControl("gvatt_lblbatchtime");
                TextBox gvatt_txtreason = (TextBox)gratt.FindControl("gvatt_txtreason");
                _Qry = "select count(masterattendanceid) from Onlinestudent_MasterAttendance where Batch_code='" + Request.QueryString["batchcode"] + "' and module_name='" + gvatt_hdnmodule.Value + "' and Software_Name='" + gvatt_lblsoftware.Text + "' and class_content='" + gvatt_lblcontent.Text + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count > 0)
                {
                }
                else
                {
                    _Qry = @"insert into Onlinestudent_MasterAttendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,class_content,reason,class_date,Date_ins,software_id,content_id,module_id) values 
                            ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                            '" +gvatt_lblbatchtime.Text+"','"+txt_BatchSlot.Text+"','"+gvatt_lblcontent.Text+"','"+MVC.CommonFunction.ReplaceQuoteWithTild(gvatt_txtreason.Text)+"','"+gvatt_classdate.Value+"',getdate(),"+gvatt_hdnsoftware.Value+","+gvatt_hdncontent.Value+","+gvatt_hdnmodule.Value+")";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //Response.Write(_Qry + "<br>");
                    _Qry = " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id=" + gvatt_hdnmodule.Value + " and  subcontent_id=" + gvatt_hdncontent.Value + "";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //Response.Write(_Qry + "<br>");
                }
                foreach (GridViewRow grstu in gvstudents.Rows)
                {
                    CheckBox gvstu_chkstudent = (CheckBox)grstu.FindControl("gvstu_chkstudent");
                    Label gvstu_lblstudent = (Label)grstu.FindControl("gvstu_lblstudent");
                    TextBox gvstu_txtstureason = (TextBox)grstu.FindControl("gvstu_txtstureason");
                    if (gvstu_chkstudent.Checked)
                    {
                        _Qry = @"insert into Onlinestudent_Attendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,Batch_track,student_id,student_name,attendance_status,Date_attendance,date_ins,class_content,student_reason,module_id,content_id,software_id) values 
                                ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                                '" + gvatt_lblbatchtime.Text + "','" + txt_BatchSlot.Text + "','Normal','" + gvstu_chkstudent.Text + "','" + gvstu_lblstudent.Text + "','Present',convert(varchar(10),getdate(),111),getdate(),'" + gvatt_lblcontent.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(gvstu_txtstureason.Text) + "'," + gvatt_hdnmodule.Value + "," + gvatt_hdncontent.Value + "," + gvatt_hdnsoftware.Value + ") ";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(_Qry + "<br>");

                        _Qry = "update erp_batchschedule set status='Completed' where batchcode='" + Request.QueryString["batchcode"] + "' and studentId='" + gvstu_chkstudent.Text + "' and subContentId=" + gvatt_hdncontent.Value + " and centrecode='" + Session["SA_centre_code"].ToString() + "'";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        // Response.Write(_Qry + "<br>");
                    }
                    else
                    {
                        _Qry = @"insert into Onlinestudent_Attendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,Batch_track,student_id,student_name,attendance_status,Date_attendance,date_ins,class_content,student_reason,module_id,content_id,software_id) values 
                                ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                                '" + gvatt_lblbatchtime.Text + "','" + txt_BatchSlot.Text + "','Normal','" + gvstu_chkstudent.Text + "','" + gvstu_lblstudent.Text + "','Absent',convert(varchar(10),getdate(),111),getdate(),'" + gvatt_lblcontent.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(gvstu_txtstureason.Text) + "'," + gvatt_hdnmodule.Value + "," + gvatt_hdncontent.Value + "," + gvatt_hdnsoftware.Value + ") ";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        //Response.Write(_Qry + "<br>");
                    }
                }
            }
            fillabsentstudents();
            fillpageloaddata();
            lblmsg1.Text = "Attendance Posted Successfully";
        }
    }
    protected void gvattendance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "post")
        {
            TextBox gvatt_txtreason = (TextBox)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_txtreason");
            HiddenField gvatt_hdnsoftware = (HiddenField)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_hdnsoftware");
            HiddenField gvatt_hdnmodule = (HiddenField)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_hdnmodule");
            HiddenField gvatt_hdnmodulename = (HiddenField)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_hdnmodulename");
            HiddenField gvatt_hdncontent = (HiddenField)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_hdncontent");
            HiddenField gvatt_classdate = (HiddenField)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_classdate");
            Label gvatt_lblsoftware = (Label)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_lblsoftware");
            Label gvatt_lblcontent = (Label)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_lblcontent");
            Label gvatt_lblbatchtime = (Label)gvattendance.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("gvatt_lblbatchtime");
            _Qry = "select count(masterattendanceid) from Onlinestudent_MasterAttendance where Batch_code='" + Request.QueryString["batchcode"] + "' and module_name='" + gvatt_hdnmodule.Value + "' and Software_Name='" + gvatt_lblsoftware.Text + "' and class_content='" + gvatt_lblcontent.Text + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
            }
            else
            {
                _Qry = @"insert into Onlinestudent_MasterAttendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,class_content,reason,class_date,Date_ins,software_id,content_id,module_id) values 
                            ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                            '" + gvatt_lblbatchtime.Text + "','" + txt_BatchSlot.Text + "','" + gvatt_lblcontent.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(gvatt_txtreason.Text) + "','" + gvatt_classdate.Value + "',getdate()," + gvatt_hdnsoftware.Value + "," + gvatt_hdncontent.Value + "," + gvatt_hdnmodule.Value + ")";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                //Response.Write(_Qry + "<br>");
                _Qry = " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id=" + gvatt_hdnmodule.Value + " and  subcontent_id=" + gvatt_hdncontent.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
               // Response.Write(_Qry + "<br>");
            }
            foreach (GridViewRow grstu in gvstudents.Rows)
            {
                CheckBox gvstu_chkstudent = (CheckBox)grstu.FindControl("gvstu_chkstudent");
                Label gvstu_lblstudent = (Label)grstu.FindControl("gvstu_lblstudent");
                TextBox gvstu_txtstureason = (TextBox)grstu.FindControl("gvstu_txtstureason");
                if (gvstu_chkstudent.Checked)
                {
                    _Qry = @"insert into Onlinestudent_Attendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,Batch_track,student_id,student_name,attendance_status,Date_attendance,date_ins,class_content,student_reason,module_id,content_id,software_id) values 
                                ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                                '" + gvatt_lblbatchtime.Text + "','" + txt_BatchSlot.Text + "','Normal','" + gvstu_chkstudent.Text + "','" + gvstu_lblstudent.Text + "','Present',convert(varchar(10),getdate(),111),getdate(),'" + gvatt_lblcontent.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(gvstu_txtstureason.Text) + "'," + gvatt_hdnmodule.Value + "," + gvatt_hdncontent.Value + "," + gvatt_hdnsoftware.Value + " )";
                   MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //  Response.Write(_Qry + "<br>");
                    _Qry = "update erp_batchschedule set status='Completed' where batchcode='" + Request.QueryString["batchcode"] + "' and studentId='" + gvstu_chkstudent.Text + "' and subContentId=" + gvatt_hdncontent.Value + " and centrecode='" + Session["SA_centre_code"].ToString() + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                     // Response.Write(_Qry + "<br>");
                }
                else
                {
                    _Qry = @"insert into Onlinestudent_Attendance (centre_code,software_name,module_name,batch_code,faculty_name,lab_name,batch_timing,batch_slot,Batch_track,student_id,student_name,attendance_status,Date_attendance,date_ins,class_content,student_reason,module_id,content_id,software_id) values 
                                ('" + Session["SA_centre_code"].ToString() + "','" + gvatt_lblsoftware.Text + "','" + gvatt_hdnmodulename.Value + "','" + Request.QueryString["batchcode"] + "','" + txt_Faculty.Text + "','" + txt_Lab.Text + @"',
                                '" + gvatt_lblbatchtime.Text + "','" + txt_BatchSlot.Text + "','Normal','" + gvstu_chkstudent.Text + "','" + gvstu_lblstudent.Text + "','Absent',convert(varchar(10),getdate(),111),getdate(),'" + gvatt_lblcontent.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(gvstu_txtstureason.Text) + "'," + gvatt_hdnmodule.Value + "," + gvatt_hdncontent.Value + "," + gvatt_hdnsoftware.Value + " )";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //Response.Write(_Qry + "<br>");
                }
            }
            fillpageloaddata();
            fillabsentstudents();
            lblmsg1.Text = "Attendance Posted Successfully";
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvclasscontent.Rows)
        {
            HiddenField hdnattendanceid = (HiddenField)gr.FindControl("hdnattendanceid");
            TextBox txtreason = (TextBox)gr.FindControl("txtreason");
            if (txtreason.Text.Trim() != "")
            {
                _Qry = " update onlinestudent_attendance set student_reason='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreason.Text) + "' where attendance_id=" + hdnattendanceid.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
        }
        fillabsentstudents();
        fillpageloaddata();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = (DataTable)Session["fillgriddata"];
        GridView1.DataBind();
    }
}
