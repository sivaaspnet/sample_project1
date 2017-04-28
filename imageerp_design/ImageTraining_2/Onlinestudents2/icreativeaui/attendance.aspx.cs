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

public partial class Onlinestudents2_Attendance : System.Web.UI.Page
{
    string _Qry, os="", os1="", swa, os2="";
    //string Ipaddr = "";
    
    CultureInfo provider = CultureInfo.InvariantCulture;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //Response.Write("Client machine IP:-" + ipAddress);
            //Response.End();
            if(Session["Student_Id"] == null || Session["Student_Id"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            _Qry = "Select Attendance_Id from OnlineStudent_Attendance Where Student_Id='" + Session["student_id"].ToString() + "' ";
            _Qry += " And Batch_Code='" + Request.QueryString["batchcode"] + "' ";
            _Qry += " And Date_Attendance=convert(varchar(10),getdate(),111)";
            int Attendance_Id = 0;

            DataTable dt2 = new DataTable();
            dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt2.Rows.Count > 0)
            {
                Response.Redirect("AttendancePost.aspx?post=succ");
            }
            else
            {
                display_pageload();
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = "";
        Response.Write(gvattendance.Rows.Count);
        //Response.End();
        if (gvattendance.Rows.Count != 0)
        {
            for (int i = 0; i < gvattendance.Rows.Count; i++)
            {
                TextBox content = (TextBox)(gvattendance.Rows[i].Cells[0].FindControl("txtcont"));
                TextBox software = (TextBox)(gvattendance.Rows[i].Cells[0].FindControl("txtsoft"));
                TextBox classdate = (TextBox)(gvattendance.Rows[i].Cells[0].FindControl("txtclass"));
                TextBox reason = (TextBox)(gvattendance.Rows[i].Cells[0].FindControl("txtrea"));
                if (reason.Text.Trim() != "")
                {
                    _Qry += "update erp_batchschedule set status='Repending' where studentid='" + Session["Student_Id"] + "' and subcontentid=(select submodule_id from submodule_details_new smd where smd.content='" + content.Text + "' and smd.software='" + software.Text + "' and smd.module='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text.Trim()) + "') ";
                    _Qry += " insert into OnlineStudent_Attendance(Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
                    _Qry += " Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Student_Id,Student_Name,Attendance_Status,Date_Attendance,Date_Ins,Class_Content) ";
                    _Qry += "  Values('" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
                    _Qry += " '" + software.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentName.Text) + "',";
                    _Qry += " 'Absent',convert(varchar(10),getdate(),111),getdate(),'" + content.Text + "')";
                }
                else
                {
                    reason.Focus();
                    lblmsg1.Text = "Please enter the reason";
                }
            }
        }

        if (txtconten.Text != "")
        {
            _Qry += "update erp_batchschedule set status='Completed' where studentid='" + Session["Student_Id"] + "' and subcontentid=(select submodule_id from submodule_details_new smd where smd.content='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtconten.Text) + "' and smd.software='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsoft.Text.Trim()) + "' and smd.module='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text.Trim()) + "') ";

            _Qry += " insert into OnlineStudent_Attendance(Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
            _Qry += " Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Student_Id,Student_Name,Attendance_Status,Date_Attendance,Date_Ins,Class_Content, ";
            _Qry += " [The faculty is able to explain the concept clearly],[Satisfied with the quality of subject],";
            _Qry += " [Experiences in the class were interesting],[The Faculty appeared to be well prepared and presented in a well organised manner])";
            _Qry += "  Values('" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsoft.Text.Trim()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentName.Text) + "',";
            _Qry += " 'Present',convert(varchar(10),getdate(),111),getdate(),'" + MVC.CommonFunction.ReplaceQuoteWithTild(txtconten.Text) + "',";
            _Qry += "'" + ddl_Concept.SelectedValue + "','" + ddl_Experience.SelectedValue + "','" + ddl_faculty.SelectedValue + "','" + ddl_quality.SelectedValue + "')";
        }
            //Response.Write(_Qry);
           // Response.End();

            int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            if (count > 0)
            {
                Response.Redirect("AttendancePost.aspx?post=succ");
            }
            else
            {
                lblmsg1.Text = "";
            }
    }

    private void display_pageload()
    {
        int aa = 0;
        tblvis.Visible = true;
        _Qry = "Select Class_Date,Class_Content,Software_Name From Onlinestudent_MasterAttendance ma Where Batch_Code='" + Request.QueryString["batchcode"] + "' and class_content not in (select class_content from Onlinestudent_Attendance att where att.class_content=ma.class_content and  Batch_Code='" + Request.QueryString["batchcode"] + "' and student_id='" + Session["student_id"] + "') And convert(varchar(10),Class_Date,103)<convert(varchar(10),dateadd(d,0,getdate()),103)";
        DataTable dtabsent = new DataTable();
        Response.Write(_Qry +"<br>");
        dtabsent = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = "Select Class_Date,Class_Content,Software_Name From Onlinestudent_MasterAttendance ma Where Batch_Code='" + Request.QueryString["batchcode"] + "' and class_content not in (select class_content from Onlinestudent_Attendance att where att.class_content=ma.class_content and  Batch_Code='" + Request.QueryString["batchcode"] + "' and student_id='" + Session["student_id"] + "') And convert(varchar(10),Class_Date,103)=convert(varchar(10),dateadd(d,0,getdate()),103)";
        Response.Write(_Qry);
        DataTable dtcur = new DataTable();
        dtcur = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtcur.Rows.Count > 0)
        {
            todayclass.Visible = true;
            txtconten.Text = dtcur.Rows[dtcur.Rows.Count-1]["Class_Content"].ToString();
            txtclassdate.Text = dtcur.Rows[dtcur.Rows.Count - 1]["Class_Date"].ToString();
            txtsoft.Text = dtcur.Rows[dtcur.Rows.Count - 1]["Software_Name"].ToString();
            aa += 1;
        }
        else
        {
            todayclass.Visible = false;
        }

        _Qry = " select distinct batch.batchcode,batch.centrecode,studentid,subcontentid,bd.batchtiming,slot,enq_personal_name,facultyname,facultyid,labname,batch.labid,att.class_content,batch.subcontentid,att.module_name,mod.moduleid from erp_batchschedule batch inner join online_students_labavail lab on lab.Labid=batch.labid and lab.centre_code=batch.centrecode inner join onlinestudentsfacultydetails fac on faculty_id=facultyid and batch.centrecode=fac.centre_code inner join adm_personalparticulars per on per.student_id=batch.studentid and per.centre_code=batch.centrecode inner join erp_batchdetails bd on bd.batchcode=batch.batchcode and bd.centrecode=batch.centrecode inner join submodule_details_new mod on mod.submodule_id=batch.subcontentid inner join Onlinestudent_MasterAttendance att on mod.content=att.class_content and att.batch_code=batch.batchcode where  batch.batchcode='" + Request.QueryString["batchcode"] + "' And  batch.studentid='" + Session["Student_Id"] + "' and batch.status='pending'";
        DataTable dtstuname = new DataTable();
        dtstuname = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dtstuname.Rows.Count > 0)
        {            
            txt_StudentName.Text = dtstuname.Rows[0]["enq_personal_name"].ToString();
            txt_modulecontent.Text = dtstuname.Rows[0]["module_name"].ToString();
            lbl_Lab.Text = dtstuname.Rows[0]["labname"].ToString();
            lbl_Faculty.Text = dtstuname.Rows[0]["facultyname"].ToString();
            lbl_batchslot.Text = dtstuname.Rows[0]["slot"].ToString();
            lbl_BatchTime.Text = dtstuname.Rows[0]["batchtiming"].ToString();
            lbl_BatchTrack.Text = "Normal";
            lbl_Batchcode.Text = dtstuname.Rows[0]["batchcode"].ToString();
            lbl_Centrecode.Text = dtstuname.Rows[0]["centrecode"].ToString();
            aa += 1;
        }
       
        txt_StudentId.Text = Session["Student_Id"].ToString();
        gvattendance.DataSource = dtabsent;
        gvattendance.DataBind();
        if (aa == 0)
        {
            noclass.Visible = true;
            tblvis.Visible = false;
        }
    }
    protected void txt_Course_TextChanged(object sender, EventArgs e)
    {

    }
    //protected void gvattendance_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Present")
    //    {
    //        _Qry = " update erp_batchschedule set status='Completed' where studentid='" + Session["Student_Id"] + "' and subcontentid=(select submodule_id from submodule_details_new smd where smd.content='" + e.CommandArgument.ToString()+ "') ";
    //        Response.Write(_Qry);
    //    }
    //    if (e.CommandName == "Absent")
    //    {
    //        _Qry = " update erp_batchschedule set status='Repending' where studentid='" + Session["Student_Id"] + "' and subcontentid=(select submodule_id from submodule_details_new smd where smd.content='" + e.CommandArgument.ToString() + "') ";
    //        Response.Write(_Qry);
    //    }
    //}
}
