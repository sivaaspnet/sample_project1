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
            _Qry = "Select Class_Date,Class_Content,Software_Name From Onlinestudent_MasterAttendance Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
            _Qry += "  And convert(varchar(10),Class_Date,103)<=convert(varchar(10),dateadd(d,0,getdate()),103)";

           // Response.Write(_Qry);

            DataTable dtattend = new DataTable();
            dtattend = MVC.DataAccess.ExecuteDataTable(_Qry);
            if(dtattend.Rows.Count>0)
            {
            //SqlDataReader dr10;
            //dr10 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            //if (dr10.HasRows)
            //{
                tblvis.Visible = true;
               // dr10.Read();
                txt_Class.Text = dtattend.Rows[dtattend.Rows.Count-1]["Class_Content"].ToString();
                txt_Software.Text = dtattend.Rows[dtattend.Rows.Count - 1]["Software_Name"].ToString();
                _Qry = "select distinct batch.batchcode,batch.centrecode,studentid,subcontentid,bd.batchtiming,slot,enq_personal_name,facultyname,facultyid,labname,batch.labid,att.class_content,batch.subcontentid,att.module_name,mod.moduleid from erp_batchschedule batch inner join online_students_labavail lab on lab.Labid=batch.labid and lab.centre_code=batch.centrecode inner join onlinestudentsfacultydetails fac on faculty_id=facultyid and batch.centrecode=fac.centre_code inner join adm_personalparticulars per on per.student_id=batch.studentid and per.centre_code=batch.centrecode inner join erp_batchdetails bd on bd.batchcode=batch.batchcode and bd.centrecode=batch.centrecode inner join submodule_details_new mod on mod.submodule_id=batch.subcontentid inner join Onlinestudent_MasterAttendance att on mod.content=att.class_content and att.batch_code=batch.batchcode where  batch.batchcode='" + Request.QueryString["batchcode"] + "' And  batch.studentid='" + Session["Student_Id"] + "' and batch.status='pending'";
                ///Response.Write(_Qry);
                 
                //_Qry = "Select Batch_StudentId,(select enq_personal_name from adm_personalparticulars where Student_Id=Batch_Studentid ";
                //_Qry += " group by Student_ID,enq_personal_name)as Name,";
                ////_Qry += "(Select Course_Name From Module_Details where Module_Id=Batch_Module_Id) as Course_Name,";
                //_Qry += "Batch_Module_Content,Batch_Code,Centre_Code,Batch_Faculty,Batch_labname,Batch_track,batch_slot,batch_time From Batch_Details Where Batch_code='" + Request.QueryString["batchcode"] + "'";
                //_Qry += " And batch_StudentId='" + Session["Student_Id"] + "' And Batch_Status='Inprogress'";

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    txt_StudentId.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["studentid"].ToString());
                    txt_StudentName.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["enq_personal_name"].ToString());
                    //txt_Course.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Course_Name"].ToString());
                    txt_modulecontent.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["module_name"].ToString());
                    lbl_Centrecode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["CentreCode"].ToString());
                    lbl_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["facultyname"].ToString());
                    lbl_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
                    lbl_BatchTrack.Text = "Normal";//MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
                    lbl_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
                    lbl_batchslot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
                    lbl_Batchcode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchcode"].ToString());

                    _Qry = "Select Class_Date,Class_Content,Software_Name From Onlinestudent_MasterAttendance Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
                    DataTable dt12 = new DataTable();
                    dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    int xx = 0;
                    for (int i = 0; i < dt12.Rows.Count; i++)
                    {
                        if (xx == 0)
                        {

                            _Qry = "Select Software_Name,Class_Content From Onlinestudent_Attendance where Batch_code='" + Request.QueryString["batchcode"] + "'";
                            _Qry += " And Class_COntent='" + dt12.Rows[i]["Class_Content"].ToString() + "' And Student_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["StudentId"].ToString()) + "'";

                            //Response.Write(_Qry);
                            //Response.End();

                            DataTable dt13 = new DataTable();
                            dt13 = MVC.DataAccess.ExecuteDataTable(_Qry);
                            if (dt13.Rows.Count == 0)
                            {
                                string todaydate = System.DateTime.Now.ToString("yyyyMMdd");

                                int toddate = Convert.ToInt32(todaydate);

                                string classdate = dt12.Rows[i]["Class_Date"].ToString();
                                //Response.Write(classdate);
                                //Response.End();
                               // classdate = DateTime.Now.ToString("MM/dd/yyyy");
                                string[] split = classdate.Split('/');
                                classdate = split[2] + "/" + split[1] + "/" + split[0];
                                DateTime date1 = DateTime.ParseExact(classdate, "yyyy/MM/dd", provider);

                                classdate = date1.ToString("yyyyMMdd");

                                int classdat = Convert.ToInt32(classdate);

                               // Response.Write("<br>Today Date Is:" + toddate);
                               // Response.Write("<br>Class Date Is:" + classdate);
                                //Response.End();

                                //if (toddate == classdat)
                                //{
                                //    xx = 1;
                                //    reasonvis.Visible = false;
                                //}
                                 if (toddate > classdat)
                                {
                                    xx = 1;
                                    reasonvis.Visible = true;
                                }
                            }
                        }
                    }
                }

                _Qry = "Select Attendance_Id from OnlineStudent_Attendance Where Student_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "' ";
                _Qry += " And Batch_Code='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "' ";
                _Qry += " and class_content='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Class.Text) + "' And Date_Attendance=convert(varchar(10),getdate(),111)";
                //Response.Write(_Qry);
               // Response.End();
                int Attendance_Id = 0;

                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dt2.Rows.Count > 0)
                {
                    Response.Redirect("AttendancePost.aspx?post=succ");
                }
               // dr10.Close();
            }
            else
            {
                tblvis.Visible = false;
                lblmsg1.Text = "Contact Your Faculty";
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = "";
        if (txt_Reason.Text.Trim() == "")
        {
            _Qry += " if( exists (select class_date=convert(varchar(10),getdate(),111) from Onlinestudent_MasterAttendance where class_content='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Class.Text) + "' and batch_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "' and class_date=convert(varchar(10),getdate(),103)) )";
            _Qry += " begin";
            _Qry += " update erp_batchschedule set status='Completed' where studentid='" + Session["Student_Id"] + "' and subcontentid=(select submodule_id from submodule_details_new smd where smd.content='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Class.Text.Trim()) + "' and smd.software='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Software.Text.Trim()) + "' and smd.module='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text.Trim()) + "') ";
            _Qry += " end";
        }
        _Qry += " insert into OnlineStudent_Attendance(Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
        _Qry += " Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Student_Id,Student_Name,Attendance_Status,Date_Attendance,Date_Ins,Class_Content, ";
        _Qry += " [The faculty is able to explain the concept clearly],[Satisfied with the quality of subject],";
        _Qry += " [Experiences in the class were interesting],[The Faculty appeared to be well prepared and presented in a well organised manner])";
        _Qry += "  Values('"+MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text)+"','"+MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text)+"',";
        _Qry +=" '"+MVC.CommonFunction.ReplaceQuoteWithTild(txt_Software.Text)+"','"+MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text)+"',";
        _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild (lbl_Faculty.Text)+ "',";
        _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild (lbl_BatchTime.Text)+ "',";
        _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild (lbl_BatchTrack.Text)+ "',";
        _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild (txt_StudentName.Text)+ "',";
        _Qry += " 'Present',convert(varchar(10),getdate(),111),getdate(),'" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Class.Text) + "',";
        _Qry += "'"+ddl_Concept.SelectedValue+"','"+ddl_Experience.SelectedValue+"','"+ddl_faculty.SelectedValue+"','"+ddl_quality.SelectedValue+"')";
       
        //Response.Write(_Qry);
        //Response.End();

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

    protected void txt_Course_TextChanged(object sender, EventArgs e)
    {

    }
}
