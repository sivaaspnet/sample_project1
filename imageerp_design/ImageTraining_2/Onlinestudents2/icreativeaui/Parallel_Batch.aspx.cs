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

public partial class OnlineStudents_superadmin_Parallel_Batch : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2;
    string b_cname, b_sid, b_sname, b_trk, b_slt, b_tim, b_ftyid, b_fty, b_sdate, b_edate, b_lab, b_status;
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
            FillBatch();
            //ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));
            ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
        }

    }
    #endregion

    private void FillBatch()
    {
        _Qry = "Select Batch_Code From Batch_Details where centre_code='" + Session["SA_centre_code"] + "' Group By Batch_Code,centre_code";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_batchcode1.DataSource = dt;
        ddl_batchcode1.DataTextField = "Batch_Code";
        ddl_batchcode1.DataValueField = "Batch_Code";
        ddl_batchcode1.DataBind();
        ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));
    }



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
        string dateFrom = "";
        string dateTo = "";
        _Qry1 = "select batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,CONVERT(VARCHAR(10),batch_startdate,111) as batch_startdate,CONVERT(VARCHAR(10),batch_enddate,111) as batch_enddate,batch_labname,batch_status from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and batch_status='Inprogress' group by batch_code,batch_Module_id,batch_Module_Content,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,batch_startdate,batch_enddate,batch_labname,batch_status";
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

                
                if (b_sdate != "")
                {
                    string str = b_sdate;
                    string[] split = str.Split('/');
                    dateFrom = split[0] + "-" + split[1] + "-" + split[2];
                }

                if (b_edate != "")
                {
                    string str1 = b_edate;
                    string[] split1 = str1.Split('/');
                    dateTo = split1[0] + "-" + split1[1] + "-" + split1[2];
                }
            }
            //Batch change
            int ii = 0;
            int abc = 0;
            foreach (GridViewRow roww in Gridvw.Rows)
            {
                CheckBox chbox = new CheckBox();
                chbox = (CheckBox)roww.FindControl("CheckBox1");
                if (chbox.Checked == true)
                {
                    Label lbl = new Label();
                    lbl = (Label)roww.FindControl("lbl_stdid");
                    string stdid = lbl.Text;

                    Label lblm = new Label();
                    lblm = (Label)roww.FindControl("lbl_Module");
                    string module = lblm.Text;
                    _Qry = "select coursename from adm_generalinfo where student_id='" + stdid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dt = new DataTable();
                    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt.Rows.Count > 0)
                    {
                        b_cname = dt.Rows[0]["coursename"].ToString();

                        _Qry = "select batch_studentid from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and batch_studentid='" + stdid + "'";
                        //Response.Write(_Qry);
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
                            }
                            else
                            {
                                //Insert into 
                                //update as empty fields in batchdetails except batch code
                                _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , batch_changestatus , dateins )VALUES ('" + ddl_batchcode2.SelectedValue + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + b_cname + "', '" + b_sid + "', '" + b_sname + "', '" + b_trk + "', '" + b_slt + "', '" + b_tim + "', '" + b_ftyid + "', '" + b_fty + "','"+dateFrom+"','"+dateTo+"', '" + b_lab + "','Inprogress','Parallelbatch',getdate())";
                                //Response.Write(_Qry);
                                //Response.End();
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                //_Qry1 = "Delete From batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and batch_software_id='" + ddl_softlist.SelectedValue + "' and batch_softwarename='" + ddl_softlist.SelectedItem + "' and batch_studentid='" + stdid + "'";
                                //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                                //Response.Write(_Qry1);
                                //lbox2.Items.Add(new ListItem(lbox1.Items[i].Text, lbox1.Items[i].Value));
                                ii = ii + 1;
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("");
                }

            }
            if (ii > 0)
            {
                _Qry = "select batch_studentid,Batch_Module_Content,(select enq_personal_name from adm_personalparticulars Where student_id=batch_studentid) as Name,Batch_Track from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and ";
                _Qry += " centre_code='" + Session["SA_centre_code"] + "' ";
                //_Qry+=" and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "'";
                _Qry += "  group by batch_studentid,Batch_Module_Content,Batch_Track";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                //ListBox1
                Gridvw.DataSource = dt;
                Gridvw.DataBind();

                fil_student();
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

    //#region for filling the Parallel batch details
    //private void parallelbatch_details()
    //{
    //    try
    //    {
    //        _Qry = "select batch_software_id,batch_softwarename,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,date_format(batch_startdate, '%d-%m-%Y' ) AS batch_startdate,date_format(batch_enddate, '%d-%m-%Y' ) AS batch_enddate,batch_labname,batch_status from batch_details where batch_status='Inprogress' and batch_code='" + ddl_parallel_batchcode.SelectedValue + "' ";

    //        Response.Write(_Qry);
    //        Response.End();

    //        DataTable dt = new DataTable();
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            lbl_parallel_track.Text = dt.Rows[0]["batch_track"].ToString();
    //            lbl_parallel_time.Text = dt.Rows[0]["batch_time"].ToString();
    //            lbl_parallel_startdate.Text = dt.Rows[0]["batch_startdate"].ToString();
    //            lbl_parallel_enddate.Text = dt.Rows[0]["batch_enddate"].ToString();
    //            lbl_parallel_software.Text = dt.Rows[0]["batch_softwarename"].ToString();

    //            b_sftid = dt.Rows[0]["batch_software_id"].ToString();
    //            b_slt = dt.Rows[0]["batch_slot"].ToString();
    //            b_facid = dt.Rows[0]["batch_facultyid"].ToString();
    //            b_facname = dt.Rows[0]["batch_faculty"].ToString();
    //            b_labname = dt.Rows[0]["batch_labname"].ToString();
    //            b_batchstatus = dt.Rows[0]["batch_status"].ToString();

    //            fil_student();//listbox
    //        }
    //        else
    //        {
    //            lbl_parallel_track.Text = "";
    //            lbl_parallel_time.Text = "";
    //            lbl_parallel_startdate.Text = "";
    //            lbl_parallel_enddate.Text = "";
    //            lbl_parallel_software.Text = "";
    //            lbox2.Items.Clear();
    //            lblerrormsg.Text = "*No batches available";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerrormsg.Text = "Please Contact Admin";
    //    }

    //}
    //#endregion


    protected void ddl_batchcode1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblerrormsg.Text = "";

            // * batch_change_status should be empty bcoz he should not exist in parallel batch while changing batch
            _Qry = "select batch_studentid,Batch_Module_Content,(select enq_personal_name from adm_personalparticulars Where student_id=batch_studentid) as Name,Batch_Track from batch_details where batch_code='" + ddl_batchcode1.SelectedValue + "' and ";
            _Qry += " centre_code='" + Session["SA_centre_code"] + "' ";
            //_Qry+=" and batch_Module_Content='" + ddl_softlist.SelectedItem + "' and batch_track='" + ddl_track.SelectedValue + "'";
            _Qry += "  group by batch_studentid,Batch_Module_Content,Batch_Track";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //ListBox1
            Gridvw.DataSource = dt;
            Gridvw.DataBind();

            if (dt.Rows.Count > 0)
            {
                Gridvw.Visible = true;
                //Function call
                hdnModule.Value = dt.Rows[0]["Batch_Module_Content"].ToString();
                lbl_Fmodule.Text = dt.Rows[0]["Batch_Module_Content"].ToString();
                lbl_Ftrack.Text = dt.Rows[0]["Batch_Track"].ToString();
                fill_batchcode2();//right ddl

                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbl_slot.Text = "";
                lbl_lab.Text = "";
                lbl_Faculty.Text = "";
                grdB2.Visible = false;
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
                grdB2.Visible = false;
                Gridvw.Visible = false;
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
                lbl_slot.Text = "";
                lbl_lab.Text = "";
                lbl_Faculty.Text = "";
                //lbox2.Items.Clear();
                _Qry = "SELECT distinct batch_code FROM batch_details as bd where batch_code<>'" + ddl_batchcode1.SelectedValue + "' And Batch_Module_Content<>'" + hdnModule.Value + "' and batch_status='Inprogress' and centre_code='" + Session["SA_centre_code"] + "'";

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
                }
                else
                {
                    ddl_batchcode2.Items.Clear();
                    ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
                    lbltime.Text = "";
                    lbltrack.Text = "";
                    lblsoftware.Text = "";
                    lbl_slot.Text = "";
                    lbl_lab.Text = "";
                    lbl_Faculty.Text = "";
                    //lbox2.Items.Clear();
                    lblerrormsg.Text = "No other batch available";
                }
            }
            else
            {
                ddl_batchcode2.Items.Clear();
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbl_slot.Text = "";
                lbl_lab.Text = "";
                lbl_Faculty.Text = "";
                //lbox2.Items.Clear();
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
                _Qry = "select batch_slot,batch_faculty,batch_labname,batch_track,batch_time,batch_Module_Content from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' group by batch_code,batch_track,batch_time,batch_Module_Content,batch_slot,batch_faculty,batch_labname";
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
                grdB2.Visible = true;
                fil_student();
            }
            else
            {
                lbltime.Text = "";
                lbltrack.Text = "";
                lblsoftware.Text = "";
                lbl_lab.Text = "";
                lbl_slot.Text = "";
                lbl_Faculty.Text = "";
                grdB2.Visible = false;
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
            //lbox2.Items.Clear();

            _Qry = "select batch_studentid,Batch_Module_Content,(select enq_personal_name from adm_personalparticulars Where student_id=batch_studentid) as Name,Batch_Track from batch_details where batch_code='" + ddl_batchcode2.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' group by batch_studentid,Batch_Module_Content,Batch_Track";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //ListBox2
            grdB2.DataSource = dt;
            grdB2.DataBind();
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion
}


