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

public partial class Onlinestudents2_superadmin_Batch_change : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2;
    string b_cname, b_sid, b_sname, b_trk, b_slt, b_tim, b_ftyid, b_fty, b_sdate, b_edate, b_lab, b_status;
    string b_cname1, b_sid1, b_sname1, b_trk1, b_slt1, b_tim1, b_ftyid1, b_fty1, b_sdate1, b_edate1, b_lab1, b_status1;
    int i;

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            displaycourseonload();
            ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));
            ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
        }

    }
    #endregion

    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + Request.QueryString["track"] + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        //_Qry = "SELECT software_Id,software_name from onlinestudent_software ORDER by software_Id";

        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_softlist.DataSource = dt;
        //ddl_softlist.DataValueField = "software_Id";
        //ddl_softlist.DataTextField = "software_name";
        //ddl_softlist.DataBind();
        //ddl_softlist.Items.Insert(0, new ListItem("Select", ""));

        _Qry = "SELECT Module_Id,Module_Content from Module_Details ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_softlist.DataSource = dt;
        ddl_softlist.DataValueField = "Module_Id";
        ddl_softlist.DataTextField = "Module_Content";
        ddl_softlist.DataBind();
        ddl_softlist.Items.Insert(0, new ListItem("Select", ""));
    }


    #region for Selected Index Change of Software
    protected void ddl_softlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblerrormsg.Text = "";
            ddl_batchcode1.Items.Clear();
            _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "' group by batch_code";


            DataTable dt = new DataTable();
            dt =MVC.DataAccess.ExecuteDataTable(_Qry);
            ddl_batchcode1.DataSource = dt;
            ddl_batchcode1.DataValueField = "batch_code";
            ddl_batchcode1.DataTextField = "batch_code";
            ddl_batchcode1.DataBind();
            ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));


            if (ddl_batchcode1.Items.Count > 1)
            {
                lblerrormsg.Text = "";
                //ddl_batchcode2.Items.Clear();
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                lbox1.Items.Clear();
            }
            else
            {
                lbox1.Items.Clear();

                //change batch details
                ddl_batchcode2.Items.Clear();
                ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                lbox1.Items.Clear();
                lblerrormsg.Text = "No batches available";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }

    }
    #endregion


    //#region for Moving the Student from One batch to another
    //#endregion


    #region for Refresh
    private void refresh_all()
    {
        //left
        //ddl_track.SelectedValue = "";
        //ddl_softlist.Items.Clear();
        //ddl_batchcode1.Items.Clear();
        ////lbox1.Items.Clear();
        ////right
        //ddl_batchcode2.Items.Clear();
        //lbltime.Text = "";
        //lbltrack.Text = "";
        //lblsoftware.Text = "";
        //lbox2.Items.Clear();
    }
    #endregion

    #region for Moving the Student from One batch to another
    protected void btn_Movestudent_Click1(object sender, EventArgs e)
    {
        try
        {
            int ii = 0;
            int abc=0;
            int hold = 0;
            _Qry1 = "select batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,batch_startdate,batch_enddate,batch_labname,batch_status from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_status='Inprogress' group by batch_code,batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,batch_startdate,batch_enddate,batch_labname,batch_status";
            //Response.Write(_Qry1);
            //Response.End();
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
            if (dt1.Rows.Count > 0)
            {
                b_sid = dt1.Rows[0]["batch_Module_id"].ToString();
                b_sname = dt1.Rows[0]["batch_Module_Content"].ToString();
                b_trk = dt1.Rows[0]["batch_track"].ToString();
                b_slt = dt1.Rows[0]["batch_slot"].ToString();
                b_tim = dt1.Rows[0]["batch_time"].ToString();
                b_ftyid = dt1.Rows[0]["batch_facultyid"].ToString();
                b_fty = dt1.Rows[0]["batch_faculty"].ToString();
                b_sdate = dt1.Rows[0]["batch_startdate"].ToString();
                b_edate = dt1.Rows[0]["batch_enddate"].ToString();

                b_lab = dt1.Rows[0]["batch_labname"].ToString();
                b_status = dt1.Rows[0]["batch_status"].ToString();
            }

            _Qry1 = "select batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,batch_startdate,batch_enddate,batch_labname,batch_status from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_status='Inprogress' group by batch_code,batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,batch_startdate,batch_enddate,batch_labname,batch_status";
            //Response.Write(_Qry1);
            //Response.End();
            DataTable dt10 = new DataTable();
            dt10 = MVC.DataAccess.ExecuteDataTable(_Qry1);
            if (dt10.Rows.Count > 0)
            {
                b_sid1 = dt10.Rows[0]["batch_Module_id"].ToString();
                b_sname1 = dt10.Rows[0]["batch_Module_Content"].ToString();
                b_trk1 = dt10.Rows[0]["batch_track"].ToString();
                b_slt1 = dt10.Rows[0]["batch_slot"].ToString();
                b_tim1 = dt10.Rows[0]["batch_time"].ToString();
                b_ftyid1 = dt10.Rows[0]["batch_facultyid"].ToString();
                b_fty1 = dt10.Rows[0]["batch_faculty"].ToString();
                b_sdate1 = dt10.Rows[0]["batch_startdate"].ToString();
                b_edate1 = dt10.Rows[0]["batch_enddate"].ToString();

                b_lab1 = dt10.Rows[0]["batch_labname"].ToString();
                b_status1 = dt10.Rows[0]["batch_status"].ToString();
            }

            //Batch change
            for (int i = 0; i < lbox1.Items.Count; i++)
            {
                if (lbox1.Items[i].Selected == true)
                {
                    _Qry = "select coursename from adm_generalinfo where student_id='" + lbox1.Items[i].ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dt = new DataTable();
                    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt.Rows.Count > 0)
                    {
                        b_cname = dt.Rows[0]["coursename"].ToString();

                        _Qry = "select batch_studentid from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and batch_studentid='" + lbox1.Items[i].ToString() + "'";
                        //Response.Write(_Qry);
                        //Response.End();
                        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                        if (dt.Rows.Count > 0)
                        {
                            lblerrormsg.Text = "The student is already there in this batch";
                        }
                        else
                        {
                            _Qry = "Select System from online_students_labavail where Labname='" + lbl_lab.Text + "'";
                            int countss = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            int noofstudents = 0;

                            _Qry = "Select Count(*) from Batch_Details where Batch_Code='" + ddl_batchcode2.SelectedValue + "'";
                            int countbb = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                            //Response.Write(_Qry);
                            //Response.Write("Count Is:" + countbb);
                            //Response.End();

                            int totalcount = countbb;
                            int displayCount = countss - countbb;

                            //Response.Write("Total Count Is:" + totalcount);
                            //Response.Write("Countbb Is:" + countss);
                            //Response.End();

                            if (totalcount >= countss)
                            {
                                //lblmsg1.Text = "Batch Full";
                                abc = 1;
                                hold = ii;
                            }
                            else
                            {
                                //Insert into 
                                //update as empty fields in batchdetails except batch code

                                _Qry = "Select count(*) from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "'";
                                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                                if (count > 1)
                                {
                                    _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , batch_changestatus , dateins )VALUES ('" + ddl_batchcode2.SelectedValue + "', '" + Session["SA_centre_code"] + "', '" + lbox1.Items[i].ToString() + "', '" + b_cname + "', '" + b_sid + "', '" + b_sname + "', '" + b_trk + "', '" + b_slt + "', '" + b_tim + "', '" + b_ftyid + "', '" + b_fty + "','" + b_sdate + "','" + b_edate + "', '" + b_lab + "','Inprogress','batchchange',getdate())";
                                    //Response.Write(_Qry);
                                    //Response.End();
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                    _Qry1 = "Delete From batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_studentid='" + lbox1.Items[i].ToString() + "'";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                                    //Response.Write(_Qry1);
                                    lbox2.Items.Add(new ListItem(lbox1.Items[i].Text, lbox1.Items[i].Value));
                                    ii = ii + 1;
                                }
                                else
                                {
                                    _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , batch_changestatus , dateins )VALUES ('" + ddl_batchcode2.SelectedValue + "', '" + Session["SA_centre_code"] + "', '" + lbox1.Items[i].ToString() + "', '" + b_cname + "', '" + b_sid + "', '" + b_sname + "', '" + b_trk + "', '" + b_slt + "', '" + b_tim + "', '" + b_ftyid + "', '" + b_fty + "','" + b_sdate + "','" + b_edate + "', '" + b_lab + "','Inprogress','batchchange',getdate())";
                                    //Response.Write(_Qry);
                                    //Response.End();
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                    //_Qry1 = "Delete From batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_studentid='" + lbox1.Items[i].ToString() + "'";
                                    _Qry1 = "Update batch_details set Batch_StudentID='',Batch_Status='Completed' where batch_code='" + ddl_batchcode1.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_studentid='" + lbox1.Items[i].ToString() + "'";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                                    //Response.Write(_Qry1);
                                    lbox2.Items.Add(new ListItem(lbox1.Items[i].Text, lbox1.Items[i].Value));
                                    ii = ii + 1;
                                    string Labtime = "";
                                    
                                    if (b_trk1 == "Fast")
                                    {
                                        _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                        _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else if (b_trk1 == "Normal")
                                    {
                                        
                                        if (b_slt1 == "MWF")
                                        {
                                            _Qry = "Select [" + b_tim1 + "] as labtime From online_students_labavail Where Labname='" + b_lab1 + "'";
                                            DataTable dt11 = new DataTable();
                                            dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                                            if (dt11.Rows.Count > 0)
                                            {
                                                Labtime = dt11.Rows[0]["labtime"].ToString();
                                            }
                                            //Response.Write("Test:" + Labtime);
                                            //Response.End();
                                            if (Labtime == "MWF")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "TTS")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "Daily")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='TTS' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='TTS' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                        }
                                        if (b_slt1 == "TTS")
                                        {
                                            //string Labtime = "";
                                            _Qry = "Select [" + b_tim1 + "] as labtime From online_students_labavail Where Labname='" + b_lab1 + "'";
                                            DataTable dt12 = new DataTable();
                                            dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
                                            if (dt12.Rows.Count > 0)
                                            {
                                                Labtime = dt12.Rows[0]["labtime"].ToString();
                                            }
                                            //Response.Write("Test:" + Labtime);
                                            //Response.End();
                                            if (Labtime == "MWF")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "TTS")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "Daily")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='MWF' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='MWF' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                        }

                                    }
                                    else if (b_trk1 == "Zip")
                                    {
                                        if (b_slt1 == "MWF")
                                        {
                                            //string Labtime = "";
                                            _Qry = "Select [" + b_tim1 + "] as labtime From online_students_labavail Where Labname='" + b_lab1 + "'";
                                            DataTable dt13 = new DataTable();
                                            dt13 = MVC.DataAccess.ExecuteDataTable(_Qry);
                                            if (dt13.Rows.Count > 0)
                                            {
                                                Labtime = dt13.Rows[0]["labtime"].ToString();
                                            }
                                            //Response.Write("Test:" + Labtime);
                                            //Response.End();
                                            if (Labtime == "MWF")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "TTS")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "Daily")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='TTS' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='TTS' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                        }
                                        if (b_slt == "TTS")
                                        {
                                            //string Labtime = "";
                                            _Qry = "Select [" + b_tim1 + "] as labtime From online_students_labavail Where Labname='" + b_lab1 + "'";
                                            DataTable dt14 = new DataTable();
                                            dt14 = MVC.DataAccess.ExecuteDataTable(_Qry);
                                            if (dt14.Rows.Count > 0)
                                            {
                                                Labtime = dt14.Rows[0]["labtime"].ToString();
                                            }
                                            //Response.Write("Test:" + Labtime);
                                            //Response.End();
                                            if (Labtime == "MWF")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "TTS")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='free' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='free' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                            else if (Labtime == "Daily")
                                            {
                                                _Qry = "Update online_students_labavail set [" + b_tim1 + "]='MWF' Where Labname='" + b_lab1 + "'";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                                _Qry = "Update Onlinestudentsfacultydetails set [" + b_tim1 + "]='MWF' Where FacultyName='" + b_fty1 + "' And Faculty_Id=" + b_ftyid1 + "";
                                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    Response.Write("");
                }
            }
            //Response.End();
            ///*  foreach (ListItem li in lbox1.Items)
            //  {
            //      if (li.Selected == true)
            //      {
            //          _Qry = "select coursename from adm_generalinfo where student_id='" + lbox1.SelectedItem + "' and centre_code='" + Session["SA_centre_code"] + "'";
            //          DataTable dt = new DataTable();
            //          dt = obj.executedatatable(_Qry);
            //          if (dt.Rows.Count > 0)
            //          {
            //              b_cname = dt.Rows[0]["coursename"].ToString();
            //              Response.Write(b_cname);

            //              //update student to new batch
            //              _Qry = "update batch_details set batch_code='" + ddl_batchcode2.SelectedValue + "',batch_studentid='" + lbox1.SelectedItem + "',batch_coursename='" + b_cname + "',batch_software_id='" + b_sid + "',batch_softwarename='" + b_sname + "',batch_track='" + b_trk + "',batch_slot='" + b_slt + "',batch_time='" + b_tim + "',batch_facultyid='" + b_ftyid + "',batch_faculty='" + b_fty + "',batch_startdate=str_to_date('" + b_sdate + "','%d-%m-%Y'),batch_enddate=str_to_date('" + b_edate + "','%d-%m-%Y'),batch_labname='" + b_lab + "',batch_status='" + b_status + "',batch_changestatus='batchchange',dateins=NOW() where  batch_status='Inprogress' and batch_code='" + ddl_batchcode2.SelectedValue + "'";
            //              Response.Write(_Qry);

            //              //obj.executenonquery(_Qry);

            //              //in b4 batches
            //              //_Qry1 = "update batch_details set batch_changestatus='batchchange' where batch_studentid='" + lbox1.SelectedItem + "' and batch_code='" + ddlbatchcode.SelectedValue + "'";
            //              //obj.executenonquery(_Qry1);
            //              lbox2.Items.Add(new ListItem(li.Text, li.Value));
            //          }
            //      }
           
            //  }*/
            if (abc > 0)
            {
                lblerrormsg.Text = "This Batch is Full";
            }
            else
            {
                int[] a = new int[50];
                int cnt = 1;
                int index = 1;
                foreach (ListItem li in lbox1.Items)
                {
                    if (li.Selected == true)
                    {
                        a[cnt] = index;
                        cnt += 1;
                    }
                    index += 1;
                }
                for (int z = 49; z >= 0; z--)
                {
                    if (a[z] != 0)
                    {
                        lbox1.Items.RemoveAt((a[z] - 1));
                    }
                }
                lblerrormsg.Text = "Student moved to the selected batch sucessfully";
            }
            if (abc > 0)
            {
                lblerrormsg.Text = "This Batch is Full";
            }
            refresh_all();
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion

    protected void ddl_batchcode1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblerrormsg.Text = "";
            lbox1.Items.Clear();
            // * batch_change_status should be empty bcoz he should not exist in parallel batch while changing batch
            _Qry = "select batch_studentid from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and ";
            _Qry+=" centre_code='" + Session["SA_centre_code"] + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "'";
            _Qry+=" and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "'";
            _Qry+="  group by batch_studentid";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //ListBox1
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbox1.Items.Add(new ListItem(dt.Rows[i]["batch_studentid"].ToString(), dt.Rows[i]["batch_studentid"].ToString()));
            }
            if (lbox1.Items.Count > 0)
            {
                //Function call
                fill_batchcode2();//right ddl

                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                //ddl_batchcode2.Items.RemoveAt(0);
                //ddl_batchcode2.Items.Clear();
                //ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                lblerrormsg.Text = "No students available";
                ddl_batchcode2.Items.Clear();
                ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbl_slot.Text = "";
                lbl_lab.Text = "";
                lbl_Faculty.Text = "";
                lbox2.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }

    #region for Filling the Changing batch
    private void fill_batchcode2()
    {
        try
        {
            if (ddl_batchcode1.SelectedValue != "" && ddl_batchcode1.SelectedValue != null)
            {
                ddl_batchcode2.Items.Clear();
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                _Qry = "SELECT distinct batch_code FROM batch_details as bd where batch_code<>'" + ddl_batchcode1.SelectedValue + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "' and batch_status='Inprogress' and centre_code='" + Session["SA_centre_code"] + "'";

                // _Qry = "SELECT distinct batch_code FROM batch_details as bd where 8>(SELECT count(batch_code)FROM batch_details where batch_software_id='" + ddl_softlist.SelectedValue + "' and batch_code<>'" + ddl_batchcode1.SelectedValue + "') and batch_code<>'" + ddl_batchcode1.SelectedValue + "' and batch_software_id='" + ddl_softlist.SelectedValue + "' and batch_softwarename='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "' and batch_status='Inprogress' and centre_code='" + Session["SA_centre_code"] + "'";


                // _Qry = "select batch_code from batch_details where batch_coursename='"+ddlcourse.SelectedValue+"' and centre_code='" + Session["SA_centre_code"] + "' group by batch_code";

                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    ddl_batchcode2.DataSource = dt;
                    ddl_batchcode2.DataValueField = "batch_code";
                    ddl_batchcode2.DataTextField = "batch_code";
                    ddl_batchcode2.DataBind();
                    ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));

            //        _Qry = "select batch_studentid from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and ";
            //        _Qry+=" centre_code='" + Session["SA_centre_code"] + "' and batch_Module_id='" + ddl_softlist.SelectedValue + "'";
            //        _Qry+=" and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "'";
            //        _Qry+="  group by batch_studentid";

            //DataTable dt12 = new DataTable();
            //dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
            ////ListBox1
            //for (int i = 0; i < dt12.Rows.Count; i++)
            //{
            //    lbox2.Items.Add(new ListItem(dt12.Rows[i]["batch_studentid"].ToString(), dt12.Rows[i]["batch_studentid"].ToString()));
            //}
                }
                else
                {
                    ddl_batchcode2.Items.Clear();
                    ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
                    lbltime.Text = "";
                    lbltrack.Text = "";
                    lblsoftware.Text = "";
                    lbox2.Items.Clear();
                    lblerrormsg.Text = "No other batch available";
                }
            }
            else
            {
                ddl_batchcode2.Items.Clear();
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                lblerrormsg.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion
    protected void ddl_batchcode2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblerrormsg.Text = "";
            //show batch details
            if (ddl_batchcode2.SelectedValue != "" && ddl_batchcode2.SelectedValue != null)
            {
                _Qry = "select batch_slot,batch_faculty,batch_labname,batch_track,batch_time,batch_Module_Content from batch_details where batch_Module_id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_code='" + ddl_batchcode2.SelectedValue + "' and batch_track='" + ddl_track.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' group by batch_code,batch_track,batch_time,batch_Module_Content,batch_slot,batch_faculty,batch_labname";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lbltime.Text = dt.Rows[0]["batch_time"].ToString();
                    lbltrack.Text = dt.Rows[0]["batch_track"].ToString();
                    lblsoftware.Text = dt.Rows[0]["batch_Module_Content"].ToString();
                    lbl_slot.Text = dt.Rows[0]["batch_slot"].ToString();
                    lbl_lab.Text = dt.Rows[0]["batch_labname"].ToString();
                    lbl_Faculty.Text = dt.Rows[0]["batch_faculty"].ToString();
                }

                fil_student();
            }
            else
            {
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbox2.Items.Clear();
                lbl_lab.Text = "";
                lbl_slot.Text = "";
                lbl_Faculty.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }

    #region to fill the Changing batch student list box
    private void fil_student()
    {
        try
        {
            lbox2.Items.Clear();

            _Qry = "select batch_studentid from batch_details where batch_Module_Id='" + ddl_softlist.SelectedValue + "' and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "' and batch_code='" + ddl_batchcode2.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' group by batch_studentid";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //ListBox2
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbox2.Items.Add(new ListItem(dt.Rows[i]["batch_studentid"].ToString(), dt.Rows[i]["batch_studentid"].ToString()));
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion
}


