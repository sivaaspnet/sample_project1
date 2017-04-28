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

public partial class Onlinestudents2_superadmin_Parallelbatch_allocation : System.Web.UI.Page
{
    string _Qry, _Qry1,bcode;
    string b_sftid, b_sftname, b_slt, b_facid, b_facname, b_labname, b_batchstatus;
    string courseid;
    //DAL obj = new DAL();

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
        }
    }
    #endregion

    /*  protected void ddl_studentid_SelectedIndexChanged(object sender, EventArgs e)
    {
      // show batchcode for the selected student and parallel batchcodes available to this course
        ddl_parallel_batchcode.Items.Clear();
        _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' and batch_coursename='" + ddlcourse.SelectedValue + "' and batch_studentid='"+ddl_studentid.SelectedValue+"' group by batch_code";
        DataTable dt = new DataTable();
        dt = obj.executedatatable(_Qry);
        lbl_bc1.Text = ""; 
        for (int i=0; i < dt.Rows.Count; i++)
        {
            //label
            lbl_bc1.Text += dt.Rows[i]["batch_code"].ToString() + "<br />";
            bcode += "AND batch_code!='" + dt.Rows[i]["batch_code"].ToString() + "' ";
        }
        //fill_parallel_batchcod()
            ddl_parallel_batchcode.Items.Clear();
            lbl_parallel_track.Text = "";
            lbl_parallel_time.Text = "";
            lbl_parallel_startdate.Text = "";
            lbl_parallel_enddate.Text = "";
            lbl_parallel_software.Text = "";
            lbox2.Items.Clear();

            _Qry = "SELECT distinct batch_code FROM batch_details as bd where 8>(SELECT count(batch_code)FROM batch_details where bd.batch_software_id=batch_software_id) "+bcode+" and batch_coursename='" + ddlcourse.SelectedValue + "' and batch_status='Inprogress'";
            Response.Write(_Qry);
            Response.End();
             DataTable dtt = new DataTable();
            dtt = obj.executedatatable(_Qry);
            if (dtt.Rows.Count > 0)
            {
                ddl_parallel_batchcode.DataSource = dtt;
                ddl_parallel_batchcode.DataValueField = "batch_code";
                ddl_parallel_batchcode.DataTextField = "batch_code";
                ddl_parallel_batchcode.DataBind();
                ddl_parallel_batchcode.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                ddl_parallel_batchcode.Items.Clear();
                lbl_parallel_track.Text = "";
                lbl_parallel_time.Text = "";
                lbl_parallel_startdate.Text = "";
                lbl_parallel_enddate.Text = "";
                lbl_parallel_software.Text = "";
                lbox2.Items.Clear();
                lblerrormsg.Text = "*No other batch available";
            }
    }*/

    #region for filling the 2nd list box
    private void fil_student()
    {
        try
        {
            lbox2.Items.Clear();
            //   _Qry = "select batch_studentid from batch_details where batch_softwarename='" + ddl_softwarelist.SelectedItem + "' and batch_software_id='"+ddl_softwarelist.SelectedValue+"' and batch_code='" + ddl_parallel_batchcode.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' group by batch_studentid";
            _Qry = "select batch_studentid from batch_details where batch_softwarename='" + lbl_parallel_software.Text + "' and batch_software_id='" + b_sftid + "' and batch_code='" + ddl_parallel_batchcode.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "' group by batch_studentid";
            //Response.Write(_Qry);
            //Response.End();
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

    #region for filling the Parallel batch details
    private void parallelbatch_details()
    {
        try
        {
            _Qry = "select batch_software_id,batch_softwarename,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,date_format(batch_startdate, '%d-%m-%Y' ) AS batch_startdate,date_format(batch_enddate, '%d-%m-%Y' ) AS batch_enddate,batch_labname,batch_status from batch_details where batch_status='Inprogress' and batch_code='" + ddl_parallel_batchcode.SelectedValue + "' ";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_parallel_track.Text = dt.Rows[0]["batch_track"].ToString();
                lbl_parallel_time.Text = dt.Rows[0]["batch_time"].ToString();
                lbl_parallel_startdate.Text = dt.Rows[0]["batch_startdate"].ToString();
                lbl_parallel_enddate.Text = dt.Rows[0]["batch_enddate"].ToString();
                lbl_parallel_software.Text = dt.Rows[0]["batch_softwarename"].ToString();

                b_sftid = dt.Rows[0]["batch_software_id"].ToString();
                b_slt = dt.Rows[0]["batch_slot"].ToString();
                b_facid = dt.Rows[0]["batch_facultyid"].ToString();
                b_facname = dt.Rows[0]["batch_faculty"].ToString();
                b_labname = dt.Rows[0]["batch_labname"].ToString();
                b_batchstatus = dt.Rows[0]["batch_status"].ToString();

                fil_student();//listbox
            }
            else
            {
                lbl_parallel_track.Text = "";
                lbl_parallel_time.Text = "";
                lbl_parallel_startdate.Text = "";
                lbl_parallel_enddate.Text = "";
                lbl_parallel_software.Text = "";
                lbox2.Items.Clear();
                lblerrormsg.Text = "*No batches available";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }

    }
    #endregion

    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + Request.QueryString["track"] + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT software_Id,software_name from onlinestudent_software ORDER by software_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_softwarelist.DataSource = dt;
        ddl_softwarelist.DataValueField = "software_Id";
        ddl_softwarelist.DataTextField = "software_name";
        ddl_softwarelist.DataBind();
        ddl_softwarelist.Items.Insert(0, new ListItem("Select", ""));
    }

    #region Selected Index change of Parallel batchcode
    protected void ddl_parallel_batchcode_SelectedIndexChanged(object sender, EventArgs e)
    {

        lblerrormsg.Text = "";

        //_Qry = "select batch_software_id,batch_softwarename,batch_track,batch_slot,batch_time,batch_facultyid,batch_faculty,date_format(batch_startdate, '%d-%m-%Y' ) AS batch_startdate,date_format(batch_enddate, '%d-%m-%Y' ) AS batch_enddate,batch_labname,batch_status from batch_details where batch_status='Inprogress' and batch_code='" + ddl_parallel_batchcode.SelectedValue + "' and batch_software_id='"+ddl_softwarelist.SelectedValue+"' and batch_softwarename='"+ddl_softwarelist.SelectedItem+"'";
        parallelbatch_details();
    }
    #endregion


    #region for Adding the student to the parallel batch that is available
    protected void btn_Movestudent_Click(object sender, EventArgs e)
    {
        try
        {
            parallelbatch_details();
            _Qry = "select coursename from adm_generalinfo where student_id='" + ddl_studentlist.SelectedValue + "' and centre_code='" + Session["SA_centre_code"] + "'";

            DataTable dtt = new DataTable();
            dtt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtt.Rows.Count > 0)
            {
                courseid = dtt.Rows[0]["coursename"].ToString();
            }

            _Qry = "Select batch_studentid from batch_details where batch_code='" + ddl_parallel_batchcode.SelectedValue + "' and batch_studentid='" + ddl_studentlist.SelectedValue + "'";
            dtt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtt.Rows.Count > 0)
            {
                lblerrormsg.Text = "This particular student is already in the batch";
            }
            else
            {
                //Insert student into parallel batch
                _Qry = "INSERT INTO batch_details(batch_code , centre_code , batch_studentid , batch_coursename , batch_software_id , batch_softwarename , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , batch_changestatus , dateins)VALUES ('" + ddl_parallel_batchcode.SelectedValue + "', '" + Session["SA_centre_code"] + "', '" + ddl_studentlist.SelectedValue + "', '" + courseid + "', '" + b_sftid + "', '" + lbl_parallel_software.Text + "', '" + lbl_parallel_track.Text + "', '" + b_slt + "', '" + lbl_parallel_time.Text + "', '" + b_facid + "', '" + b_facname + "',str_to_date('" + lbl_parallel_startdate.Text + "','%d-%m-%Y'), str_to_date('" + lbl_parallel_enddate.Text + "','%d-%m-%Y'), '" + b_labname + "', '" + b_batchstatus + "', 'Parallelbatch',NOW())";

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                lblerrormsg.Text = "*Parallel batch is allocated to the student you have selected";

                //Clear all 
                ddl_track.SelectedValue = "";
                ddl_softwarelist.SelectedValue = "";
                ddl_studentlist.Items.Clear();
                lbl_bc1.Text = "";
                //parallel batch details
                ddl_parallel_batchcode.Items.Clear();
                lbl_parallel_track.Text = "";
                lbl_parallel_time.Text = "";
                lbl_parallel_startdate.Text = "";
                lbl_parallel_enddate.Text = "";
                lbl_parallel_software.Text = "";
                lbox2.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion



    #region for Selected Index change of the Software list
    protected void ddl_softwarelist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //display studentids
            ddl_studentlist.Items.Clear();
            lbl_bc1.Text = "";
            lblerrormsg.Text = "";
            _Qry = "select batch_studentid from batch_details where batch_track='" + ddl_track.SelectedValue + "' and batch_software_id='" + ddl_softwarelist.SelectedValue + "' and batch_softwarename='" + ddl_softwarelist.SelectedItem + "' and centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' group by batch_studentid";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddl_studentlist.DataSource = dt;
            ddl_studentlist.DataValueField = "batch_studentid";
            ddl_studentlist.DataTextField = "batch_studentid";
            ddl_studentlist.DataBind();
            ddl_studentlist.Items.Insert(0, new ListItem("Select", ""));
            if (ddl_studentlist.Items.Count == 1)
            {
                lblerrormsg.Text = "*No student list available!";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion


    #region for Selected Index Change of the Student list in the current batch 
    protected void ddl_studentlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // show batchcode for the selected student and parallel batchcodes available to this course
            lblerrormsg.Text = "";
            ddl_parallel_batchcode.Items.Clear();
            _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' and batch_status='Inprogress' and batch_software_id='" + ddl_softwarelist.SelectedValue + "' and batch_softwarename = '" + ddl_softwarelist.SelectedItem + "' and batch_studentid='" + ddl_studentlist.SelectedValue + "' group by batch_code";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            lbl_bc1.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //label
                lbl_bc1.Text += dt.Rows[i]["batch_code"].ToString() + "<br />";
                bcode += " AND batch_code!='" + dt.Rows[i]["batch_code"].ToString() + "' ";
            }

            //fill_parallel_batchcod()

            lbl_parallel_track.Text = "";
            lbl_parallel_time.Text = "";
            lbl_parallel_startdate.Text = "";
            lbl_parallel_enddate.Text = "";
            lbl_parallel_software.Text = "";
            lbox2.Items.Clear();

            //   _Qry = "SELECT distinct batch_code FROM batch_details as bd where 8>(SELECT count(batch_code)FROM batch_details where bd.batch_software_id=batch_software_id) " + bcode + " and batch_softwarename='" + ddl_softwarelist.SelectedItem + "' and batch_software_id='" + ddl_softwarelist.SelectedValue + "' and batch_status='Inprogress' and centre_code='" + Session["SA_centre_code"] + "'";
            _Qry = "SELECT distinct batch_code FROM batch_details as bd where 8>(SELECT count(batch_code)FROM batch_details where bd.batch_software_id=batch_software_id) " + bcode + " and batch_status='Inprogress' and centre_code='" + Session["SA_centre_code"] + "'";
            DataTable dtt = new DataTable();
            dtt = obj.executedatatable(_Qry);
            if (dtt.Rows.Count > 0)
            {
                ddl_parallel_batchcode.DataSource = dtt;
                ddl_parallel_batchcode.DataValueField = "batch_code";
                ddl_parallel_batchcode.DataTextField = "batch_code";
                ddl_parallel_batchcode.DataBind();
                ddl_parallel_batchcode.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                ddl_parallel_batchcode.Items.Clear();
                lbl_parallel_track.Text = "";
                lbl_parallel_time.Text = "";
                lbl_parallel_startdate.Text = "";
                lbl_parallel_enddate.Text = "";
                lbl_parallel_software.Text = "";
                lbox2.Items.Clear();
                lblerrormsg.Text = "*No other batch available";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }
    #endregion

}
