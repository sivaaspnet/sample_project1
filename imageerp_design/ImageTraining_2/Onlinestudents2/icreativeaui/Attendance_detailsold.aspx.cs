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

public partial class Onlinestudents2_Attendance_detailsold : System.Web.UI.Page
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
        if (!IsPostBack)
        {

            if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
            {
                Response.Redirect("Login.aspx");
            }

            _Qry = @"select * from Onlinestudent_MasterAttendance where batch_code='"+Request.QueryString["batchcode"].ToString()+"' and convert(varchar,date_ins,103)=convert(varchar,getdate(),103)";
            //Response.Write(_Qry);
            DataTable dty = new DataTable();
            dty = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (0 >= dty.Rows.Count)
            {


                filltable();

             
            }
            else
            {
                tblatt.Visible = true;
                visclassdaily.Visible = false;
                tblbatch.Visible = true;
                data();
                fillgrid();
                lblmsg1.Visible = true;
               lblmsg1.Text = "Attendance Already Posted....!";

            }
        }
       
        }


    private void data()
    {

        _Qry = "select distinct bs.software_id,bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where fac.facultyname='" + Session["SA_Username"] + "' and   bs.batchcode='" + Request.QueryString["batchcode"] + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            HiddenField1.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["moduleid"].ToString());
            HiddenField2.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["software_id"].ToString());
            HiddenField3.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["subcontentid"].ToString());
            tblbatch.Visible = true;
            tblatt.Visible = true;
            txt_modulecontent.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["module"].ToString());
            txt_BatchCode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["BatchCode"].ToString());
            txt_BatchSlot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
            txt_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
            txt_BatchTrack.Text = "Normal";// MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
            txt_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Facultyname"].ToString());
            txt_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
            lbl_Centrecode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centrecode"].ToString());
            lbl_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["FacultyName"].ToString());
            lbl_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
            lbl_BatchTrack.Text = "Normal";// MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
            lbl_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
            lbl_batchslot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
            lbl_Batchcode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["BatchCode"].ToString());
            txt_startdate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["startdate"].ToString());
            txt_enddate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["enddate"].ToString());
            hiddencontentid.Value = dt.Rows[0]["classdate"].ToString();
            _Qry += " and bs.classdate<=getdate() and bs.status='pending'  order by  bs.subcontentid,bs.classdate";
            dtattendance = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtattendance.Rows.Count > 0)
            {
                hiddendtattendanceid.Value = dtattendance.Rows.Count.ToString();
               // visclassdaily.Visible = true;
                txt_Software.Text = dtattendance.Rows[0]["software"].ToString();
                txt_Content.Text = dtattendance.Rows[0]["content"].ToString();
                HiddenField2.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["software_id"].ToString());

                hiddenmoduleid.Value = dtattendance.Rows[0]["moduleid"].ToString();
                hiddencontentid.Value = dtattendance.Rows[0]["subcontentid"].ToString();
                if (Convert.ToDateTime(dtattendance.Rows[0]["correctdate"]) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                {
                  //  btnconcan.Visible = true;
                    tdaddbutton.Visible = false;
                    // reasonvis.Visible = true;
                }
                _Qry = "";
                //if (txtreasonnotpost.Text != "")
                //{

                for (int i = 0; i < dtattendance.Rows.Count; i++)
                {
                    _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + dtattendance.Rows[i]["moduleid"].ToString() + "' and  subcontent_id='" + dtattendance.Rows[i]["subcontentid"].ToString() + "'";

                    _Qry += " insert into Onlinestudent_MasterAttendance(software_id,module_id,content_id,Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
                    _Qry += "Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Class_Content,Class_Date,Date_Ins,Reason) ";
                    _Qry += " Values('" + MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[i]["software_id"].ToString()) + "','" + hiddenmoduleid.Value + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["subcontentid"].ToString()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["software"].ToString()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
                    _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["content"].ToString()) + "',";
                    _Qry += " convert(varchar(10),getdate(),103),getdate(),'#######')";
                }
                lblconductedqry.Text = _Qry.ToString();
                //}
                //else if (txt_Reason.Text != "")
                //{


                _Qry = "select  id,batchcode,module_id,subcontent_id,classdate,status,dateins from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and status='pending' order by classdate";
                dtpending = MVC.DataAccess.ExecuteDataTable(_Qry);

                _Qry = "select count(classdate) as classdate,count(*) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and status='pending' and classdate<=dateadd(d,0,getdate())";
                dtnoofpending = MVC.DataAccess.ExecuteDataTable(_Qry);
                cancelledclass = Convert.ToInt32(dtnoofpending.Rows[0]["classdate"]);
                int cancel = cancelledclass;
                _Qry = "";
                DateTime lastclassdate = DateTime.Now;
                int k = 1;
                for (int pending = 0; pending <= Convert.ToInt32(dtpending.Rows.Count) - cancel; pending++)
                {

                    lastclassdate = Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]);
                    _Qry += " update erp_batchcontentstatus set classdate='" + Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]) + "' where subcontent_id='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                    _Qry += " update erp_batchschedule set classdate='" + Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]) + "' where subcontentid='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                    cancelledclass += 1;
                    if (k == 1)
                    {
                        _Qry += " update erp_batchcontentstatus set status='Completed' where subcontent_id='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                    }
                    k += 1;
                }
                //Response.Write(lastclassdate);
                //Response.End();
                int noofpendingclass = Convert.ToInt32(dtpending.Rows.Count) - ((Convert.ToInt32(dtpending.Rows.Count) - cancel) + 1);
                string classdate = "-";
                string _Qrydate = "select * from spbalanceclassdate (dateadd(d,1,'" + lastclassdate + "'),'" + txt_BatchSlot.Text.Trim() + "','" + noofpendingclass + "')";
                //Response.Write(_Qry);
                DataTable dtgetdate = new DataTable();
                dtgetdate = MVC.DataAccess.ExecuteDataTable(_Qrydate);
                if (dtgetdate.Rows.Count > 0)
                {
                    for (int cd = 0; cd < dtgetdate.Rows.Count; cd++)
                    {
                        if (classdate == "")
                        {
                            classdate = dtgetdate.Rows[cd]["classdate"].ToString();
                        }
                        else
                        {
                            classdate = classdate + "," + dtgetdate.Rows[cd]["classdate"].ToString();
                        }
                    }
                }
                string[] split = classdate.Split(',');

                for (int balancepending = ((Convert.ToInt32(dtpending.Rows.Count) - cancel) + 1); balancepending < dtpending.Rows.Count; balancepending++)
                {
                    int i = 1;
                    _Qry += " update erp_batchcontentstatus set classdate='" + split[i] + "' where subcontent_id='" + dtpending.Rows[balancepending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                    _Qry += " update erp_batchschedule set classdate='" + split[i] + "' where subcontentid='" + dtpending.Rows[balancepending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                    i += 1;
                    // cancelledclass += 1;
                }
                // _Qry = " cancelled <br>";

                //if (dtattendance.Rows.Count > 1)
                //{
                //    int j = dtattendance.Rows.Count-1;
                //    _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + dtattendance.Rows[j]["moduleid"].ToString() + "' and  subcontent_id='" + dtattendance.Rows[j]["subcontentid"].ToString() + "'";

                //}
                lblcancelqry.Text = _Qry.ToString();
                //}
                //else if (txt_Reason.Text == "" && txtreasonnotpost.Text == "")
                //{
                _Qry = " ";
                _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + hiddenmoduleid.Value + "' and  subcontent_id='" + hiddencontentid.Value + "'";

                lblqry.Text = _Qry.ToString();

                // }
            }
        }
        else
        {
            tblbatch.Visible = false;
           // tblatt.Visible = false;
            lblmsg1.Text = "Batch is not in progress";
        }


        //fillgrid();




    }
    private void filltable()
    {
 _Qry = "select distinct bs.software_id,bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduleDate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where fac.facultyname='" + Session["SA_Username"] + "' and   bs.batchcode='" + Request.QueryString["batchcode"] + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";

                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    HiddenField1.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["moduleid"].ToString());
                    HiddenField2.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["software_id"].ToString());
                    HiddenField3.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["subcontentid"].ToString());
                    tblbatch.Visible = true;
                    tblatt.Visible = true;
                    txt_modulecontent.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["module"].ToString());
                    txt_BatchCode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["BatchCode"].ToString());
                    txt_BatchSlot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
                    txt_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
                    txt_BatchTrack.Text = "Normal";// MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
                    txt_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Facultyname"].ToString());
                    txt_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
                    lbl_Centrecode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centrecode"].ToString());
                    lbl_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["FacultyName"].ToString());
                    lbl_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["labname"].ToString());
                    lbl_BatchTrack.Text = "Normal";// MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
                    lbl_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batchtiming"].ToString());
                    lbl_batchslot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["slot"].ToString());
                    lbl_Batchcode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["BatchCode"].ToString());
                    txt_startdate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["startdate"].ToString());
                    txt_enddate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["enddate"].ToString());
                    hiddencontentid.Value = dt.Rows[0]["classdate"].ToString();
                    _Qry += " and bs.classdate<=getdate() and bs.status='pending'  order by  bs.subcontentid,bs.classdate";
                    dtattendance = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dtattendance.Rows.Count > 0)
                    {
                        hiddendtattendanceid.Value = dtattendance.Rows.Count.ToString();
                        visclassdaily.Visible = true;
                        txt_Software.Text = dtattendance.Rows[0]["software"].ToString();
                        txt_Content.Text = dtattendance.Rows[0]["content"].ToString();
                        HiddenField2.Value = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["software_id"].ToString());

                        hiddenmoduleid.Value = dtattendance.Rows[0]["moduleid"].ToString();
                        hiddencontentid.Value = dtattendance.Rows[0]["subcontentid"].ToString();
                        if (Convert.ToDateTime(dtattendance.Rows[0]["correctdate"]) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                        {
                            btnconcan.Visible = true;
                            tdaddbutton.Visible = false;
                            // reasonvis.Visible = true;
                        }
                        _Qry = "";
                        //if (txtreasonnotpost.Text != "")
                        //{

                        for (int i = 0; i < dtattendance.Rows.Count; i++)
                        {
                            _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + dtattendance.Rows[i]["moduleid"].ToString() + "' and  subcontent_id='" + dtattendance.Rows[i]["subcontentid"].ToString() + "'";

                            _Qry += " insert into Onlinestudent_MasterAttendance(software_id,module_id,content_id,Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
                            _Qry += "Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Class_Content,Class_Date,Date_Ins,Reason) ";
                            _Qry += " Values('" + MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[i]["software_id"].ToString()) + "','" + hiddenmoduleid.Value + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["subcontentid"].ToString()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
                            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["software"].ToString()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
                            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
                            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
                            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
                            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(dtattendance.Rows[i]["content"].ToString()) + "',";
                            _Qry += " convert(varchar(10),getdate(),103),getdate(),'#######')";
                        }
                        lblconductedqry.Text = _Qry.ToString();
                        //}
                        //else if (txt_Reason.Text != "")
                        //{


                        _Qry = "select  id,batchcode,module_id,subcontent_id,classdate,status,dateins from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and status='pending' order by classdate";
                        dtpending = MVC.DataAccess.ExecuteDataTable(_Qry);

                        _Qry = "select count(classdate) as classdate,count(*) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and status='pending' and classdate<=dateadd(d,0,getdate())";
                        dtnoofpending = MVC.DataAccess.ExecuteDataTable(_Qry);
                        cancelledclass = Convert.ToInt32(dtnoofpending.Rows[0]["classdate"]);
                        int cancel = cancelledclass;
                        _Qry = "";
                        DateTime lastclassdate = DateTime.Now;
                        int k = 1;
                        for (int pending = 0; pending <= Convert.ToInt32(dtpending.Rows.Count) - cancel; pending++)
                        {

                            lastclassdate = Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]);
                            _Qry += " update erp_batchcontentstatus set classdate='" + Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]) + "' where subcontent_id='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                            _Qry += " update erp_batchschedule set classdate='" + Convert.ToDateTime(dtpending.Rows[cancelledclass - 1]["classdate"]) + "' where subcontentid='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                            cancelledclass += 1;
                            if (k == 1)
                            {
                                _Qry += " update erp_batchcontentstatus set status='Completed' where subcontent_id='" + dtpending.Rows[pending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                            }
                            k += 1;
                        }
                        //Response.Write(lastclassdate);
                        //Response.End();
                        int noofpendingclass = Convert.ToInt32(dtpending.Rows.Count) - ((Convert.ToInt32(dtpending.Rows.Count) - cancel) + 1);
                        string classdate = "-";
                        string _Qrydate = "select * from spbalanceclassdate (dateadd(d,1,'" + lastclassdate + "'),'" + txt_BatchSlot.Text.Trim() + "','" + noofpendingclass + "')";
                        //Response.Write(_Qry);
                        DataTable dtgetdate = new DataTable();
                        dtgetdate = MVC.DataAccess.ExecuteDataTable(_Qrydate);
                        if (dtgetdate.Rows.Count > 0)
                        {
                            for (int cd = 0; cd < dtgetdate.Rows.Count; cd++)
                            {
                                if (classdate == "")
                                {
                                    classdate = dtgetdate.Rows[cd]["classdate"].ToString();
                                }
                                else
                                {
                                    classdate = classdate + "," + dtgetdate.Rows[cd]["classdate"].ToString();
                                }
                            }
                        }
                        string[] split = classdate.Split(',');

                        for (int balancepending = ((Convert.ToInt32(dtpending.Rows.Count) - cancel) + 1); balancepending < dtpending.Rows.Count; balancepending++)
                        {
                            int i = 1;
                            _Qry += " update erp_batchcontentstatus set classdate='" + split[i] + "' where subcontent_id='" + dtpending.Rows[balancepending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                            _Qry += " update erp_batchschedule set classdate='" + split[i] + "' where subcontentid='" + dtpending.Rows[balancepending]["subcontent_id"].ToString() + "' and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                            i += 1;
                            // cancelledclass += 1;
                        }
                        // _Qry = " cancelled <br>";

                        //if (dtattendance.Rows.Count > 1)
                        //{
                        //    int j = dtattendance.Rows.Count-1;
                        //    _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + dtattendance.Rows[j]["moduleid"].ToString() + "' and  subcontent_id='" + dtattendance.Rows[j]["subcontentid"].ToString() + "'";

                        //}
                        lblcancelqry.Text = _Qry.ToString();
                        //}
                        //else if (txt_Reason.Text == "" && txtreasonnotpost.Text == "")
                        //{
                        _Qry = " ";
                        _Qry += " update erp_batchcontentstatus set status='Completed' where  batchcode='" + Request.QueryString["batchcode"] + "' and module_id='" + hiddenmoduleid.Value + "' and  subcontent_id='" + hiddencontentid.Value + "'";

                        lblqry.Text = _Qry.ToString();

                        // }
                    }
                }
                else
                {
                    tblbatch.Visible = false;
                    tblatt.Visible = false;
                    lblmsg1.Visible = true;
                    lblmsg1.Text = "Batch is not in progress";
                   
                }


                fillgrid();
    }
    string getcontents(DataTable dtexp, string expression, string column)
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
                    res = (val[column].ToString());
                }
                else
                {
                    res = res + "," + (val[column].ToString());
                }
            }
        }

        return res.ToString();
    }

    private void fillgrid()
    {
        _Qry = "Select Software_Name,Class_Content,isnull(Reason,'-') as Reason from Onlinestudent_MasterAttendance as ma Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
   
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = "Select count(*) from Onlinestudent_MasterAttendance Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
        _Qry += " And Class_Date=convert(varchar(10),getdate(),103)";

        int count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        //if (count1 <= 0)
        //{
            _Qry = "Select count(*) from Onlinestudent_MasterAttendance Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
            _Qry += " And Software_Name='" + txt_Software.Text + "' And Class_Content='" + txt_Content.Text + "'";
            _Qry = "select count(masterattendanceid) from Onlinestudent_MasterAttendance where Batch_code='" + Request.QueryString["batchcode"] + "' and module_name='" + txt_modulecontent.Text + "' and Software_Name='" + txt_Software.Text + "' and class_content='" + txt_Content.Text + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
            int count12 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (count12 <= 0)
            {               
                //Response.End();
                int count = 0;                
                //Response.Write(lblqry.Text);
                _Qry = " insert into Onlinestudent_MasterAttendance(software_id,module_id,content_id,Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
                _Qry += "Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Class_Content,Class_Date,Date_Ins,Reason) ";
                _Qry += " Values('" + HiddenField2.Value + "','" + HiddenField1.Value + "','" + hiddencontentid.Value + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Software.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
                _Qry += "'" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Content.Text) + "',";
                _Qry += " convert(varchar(10),getdate(),103),getdate(),'" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Reason.Text) + "')";
                count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lblqry.Text);
                if (count > 0)
                {
                    lblmsg1.Text = "Today's class Details inserted successfully";
                }
                else
                {
                    lblmsg1.Text = "";
                }
                lblqry.Text = "";
                lblconductedqry.Text = "";
                lblcancelqry.Text = "";
            }
            else
            {
                lblmsg1.Text = "Class Content already exists";
            }
        fillgrid();
    }
  

    protected void ddl_software_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fillContent();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnconducted_Click(object sender, EventArgs e)
    {
        reasonconducted.Visible = true;
        reasonvis.Visible = false;
        btnconcan.Visible = false;
        tdaddbutton.Visible = false;
    }
    protected void btncancelled_Click(object sender, EventArgs e)
    {
        reasonvis.Visible = true;
        reasonconducted.Visible = false;
        btnconcan.Visible = false;
        tdaddbutton.Visible = false;
    }
    protected void btnnotpost_Click(object sender, EventArgs e)
    {
        
      
     
        _Qry = "select count(masterattendanceid) from Onlinestudent_MasterAttendance where Batch_code='" + Request.QueryString["batchcode"] + "' and module_name='" + txt_modulecontent.Text + "' and Software_Name='" + txt_Software.Text + "' and class_content='" + txt_Content.Text + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
        int count12 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (count12 <= 0)
        {
            int count = 0;
           // Response.Write(lblconductedqry.Text);
             lblconductedqry.Text=lblconductedqry.Text.Replace("#######",MVC.CommonFunction.ReplaceQuoteWithTild(txtreasonnotpost.Text));
            count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lblconductedqry.Text);
            if (count > 0)
            {
                lblmsg1.Text = "Today's class Details inserted successfully";
            }
            else
            {
                lblmsg1.Text = "";
            }
            lblqry.Text = "";
            lblconductedqry.Text = "";
            lblcancelqry.Text = "";
        }
        else
        {
            lblmsg1.Text = "Class Content already exists";
        }
        fillgrid();
    }
    protected void btncan_Click(object sender, EventArgs e)
    {
        _Qry = "Select count(*) from Onlinestudent_MasterAttendance Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
        _Qry += " And Class_Date=convert(varchar(10),getdate(),103)";

        int count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        //if (count1 <= 0)
        //{
        _Qry = "Select count(*) from Onlinestudent_MasterAttendance Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
        _Qry += " And Software_Name='" + txt_Software.Text + "' And Class_Content='" + txt_Content.Text + "'";
        _Qry = "select count(masterattendanceid) from Onlinestudent_MasterAttendance where Batch_code='" + Request.QueryString["batchcode"] + "' and module_name='" + txt_modulecontent.Text + "' and Software_Name='" + txt_Software.Text + "' and class_content='" + txt_Content.Text + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
        int count12 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (count12 <= 0)
        {

            //Response.End();
            int count = 0;
            //Response.Write(lblcancelqry.Text);
            _Qry = " insert into Onlinestudent_MasterAttendance(software_id,module_id,content_id,Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
            _Qry += "Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Class_Content,Class_Date,Date_Ins,Reason) ";
            _Qry += " Values('" + HiddenField2.Value + "','" + HiddenField1.Value + "','" + hiddencontentid.Value + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Software.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
            _Qry += "'" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Content.Text) + "',";
            _Qry += " convert(varchar(10),getdate(),103),getdate(),'" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Reason.Text) + "')";
            count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);  
            count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lblcancelqry.Text);            
            if (count > 0)
            {
                lblmsg1.Text = "Today's class Details inserted successfully";
            }
            else
            {
                lblmsg1.Text = "";
            }
            lblqry.Text = "";
            lblconductedqry.Text = "";
            lblcancelqry.Text = "";
 
        }
        else
        {
            lblmsg1.Text = "Class Content already exists";
        }        
        //txt_Software.Text = "";
        //txt_Content.Text = "";
        //txt_Reason.Text = "";
        fillgrid();
    }
}
