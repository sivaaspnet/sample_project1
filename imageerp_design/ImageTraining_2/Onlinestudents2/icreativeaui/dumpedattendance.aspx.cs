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

public partial class Onlinestudents2_dumpedattendance : System.Web.UI.Page
{
    int noofcls;
    string BatchCount, batch_code, couname, couid, todate, holdate;
    DateTime stdate, lastday;
    string _Qry, os="", os1="", swa, os2="";
    DataTable dt = new DataTable();
    DataTable dtattendance = new DataTable();
    DataTable dtpending = new DataTable();
    DataTable dtnoofpending = new DataTable();
    int cancelledclass = 0;
    //string Ipaddr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {

            dispaly_batchcode();
         }
    }

    private void dispaly_batchcode()
    {

            _Qry = "select batchcode from erp_batchdetails where centrecode='" + Session["SA_centre_code"] + "' group by batchcode";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddlbatchcode.DataSource = dt;
            ddlbatchcode.DataValueField = "batchcode";
            ddlbatchcode.DataTextField = "batchcode";
            ddlbatchcode.DataBind();
            ddlbatchcode.Items.Insert(0, new ListItem("Select", ""));
        
    }


    private void fillgrid()
    {
        _Qry = " select subcontent_id,content,convert(varchar,scheduledate,103) as scheduledate,classdate from erp_batchcontentstatus cs inner join submodule_details_new sd on sd.submodule_id=cs.subcontent_id  where batchcode='" + ddlbatchcode.SelectedValue + "' and cs.status='Pending' ";
        //_Qry = "Select Software_Name,Class_Content,(Select convert(varchar(10),Date_Class,103) From Onlinestudent_ScheduleBatch Where Batch_Code='" + Request.QueryString["batchcode"] + "' And Content=ma.Class_Content) as ScheduledDate,(Select convert(varchar(10),Date_Class,103) From Onlinestudent_EditScheduleBatch Where Batch_Code='" + Request.QueryString["batchcode"] + "' And Content=ma.Class_Content) as ScheduleChangedDate,Class_Date,Reason from Onlinestudent_MasterAttendance as ma Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
        ////Response.Write(_Qry);
        ////Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        btnpost.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
 
    }





    protected void btnselectbatch_Click(object sender, EventArgs e)
    {
        _Qry = @"select distinct bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(scheduledate)),103) from 
erp_batchcontentstatus where batchcode='" + ddlbatchcode.SelectedValue + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(scheduledate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.SelectedValue + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where   bs.batchcode='" + ddlbatchcode.SelectedValue + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        //Response.Write(_Qry);

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            tblbatch.Visible = true;
             //txt_StudentId.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_StudentId"].ToString());
            //txt_StudentName.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Name"].ToString());
            //txt_Course.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Course_Name"].ToString());
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
            fillgrid();
        }
    }
    protected void btnpost_Click(object sender, EventArgs e)
    {
        string qry = "";
        string str = "";
        string tbl = "";
        string sdate = "";
        int balance = GridView1.Rows.Count;
        int k = 1;
        if (GridView1.Rows.Count != 0)
        {
            tbl += "<table>";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox classdate = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("txtdate"));
                Label contentid = (Label)(GridView1.Rows[i].Cells[0].FindControl("lblsubid"));
                if (classdate.Text.Trim() != "")
                {
                    str = classdate.Text;
                    string[] split = str.Split('-');
                    sdate = split[2] + "-" + split[1] + "-" + split[0];
                    qry += " update erp_batchcontentstatus set classdate='" + sdate + "',status='Completed' where batchcode='" + txt_BatchCode.Text.Trim() + "' and subcontent_id='" + contentid.Text + "'";
                    qry += " update erp_batchschedule set classdate='" + sdate + "',status='Repending' where batchcode='" + txt_BatchCode.Text.Trim() + "' and subcontentid='" + contentid.Text + "'";
                    tbl += "<tr><td>" + sdate + "</td><td>" + contentid.Text + "</td></tr>";
                    //balance = balance - i ;
                }
                else
                {
                    string clasdate = "-";
                    string _Qrydate = "select * from spbalanceclassdate (dateadd(d,1,'" + sdate + "'),'" + txt_BatchSlot.Text.Trim() + "','" + balance + "')";
                    //Response.Write(_Qry);
                    DataTable dtgetdate = new DataTable();
                    dtgetdate = MVC.DataAccess.ExecuteDataTable(_Qrydate);
                    if (dtgetdate.Rows.Count > 0)
                    {
                        for (int cd = 0; cd < dtgetdate.Rows.Count; cd++)
                        {
                            if (clasdate == "")
                            {
                                clasdate = dtgetdate.Rows[cd]["classdate"].ToString();
                            }
                            else
                            {
                                clasdate = clasdate + "," + dtgetdate.Rows[cd]["classdate"].ToString();
                            }
                        }
                    }
                    string[] split = clasdate.Split(',');
                    qry += " update erp_batchcontentstatus set classdate='" + split[k].ToString() + "' where batchcode='" + txt_BatchCode.Text.Trim() + "' and subcontent_id='" + contentid.Text + "'";
                    qry += " update erp_batchschedule set classdate='" + split[k].ToString() + "' where batchcode='" + txt_BatchCode.Text.Trim() + "' and subcontentid='" + contentid.Text + "'";
                    tbl += "<tr><td>" + split[k].ToString() + "</td><td>" + contentid.Text + "</td></tr>";
                    k += 1;

                }
                

            }
            tbl += "</table>";
        }
         MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);

       // ltrl.Text = tbl.ToString();
        //Response.Write(sdate);
        //Response.Write("<br>" + balance);
        //Response.Write("<br>" + GridView1.Rows.Count);
        //Response.Write("<br>" + qry);
    }
}
