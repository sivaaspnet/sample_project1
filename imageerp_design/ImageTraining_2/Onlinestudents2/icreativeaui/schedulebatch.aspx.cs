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

public partial class Onlinestudents2_superadmin_schedulebatch : System.Web.UI.Page
{
    string _Qry;
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
            tblstudent.Visible = false;
            scheduleload();
            ddlmonth1.SelectedValue = DateTime.Now.ToString("MM");
            ddlyear1.SelectedValue = DateTime.Now.ToString("yyyy");
            display_facultydd2();
            ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
            ViewState["vv"] = Request.ServerVariables["HTTP_REFERER"];
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
    }

    private void display_facultydd2()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
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

    private void Fillclassdetails()
    {
        _Qry = "select sts.batchcode,software,content,convert(varchar,scheduledate,103) as scheduledate,case when sts.status='Completed' then convert(varchar,classdate,103) else '' end as classheld,Reason,remarks from erp_batchcontentstatus sts inner join submodule_details_new sd on sts.subcontent_id=sd.submodule_id and sts.batchcode='" + Request.QueryString["batchcode"] + "' left join onlinestudent_masterattendance att on att.batch_code=sts.batchcode and software=software_name and class_content=content  order by sd.Submodule_id asc";
        //_Qry = "Select Software_Name,Class_Content,(Select convert(varchar(10),Date_Class,103) From Onlinestudent_ScheduleBatch Where Batch_Code='" + Request.QueryString["batchcode"] + "' And Content=ma.Class_Content) as ScheduledDate,(Select convert(varchar(10),Date_Class,103) From Onlinestudent_EditScheduleBatch Where Batch_Code='" + Request.QueryString["batchcode"] + "' And Content=ma.Class_Content) as ScheduleChangedDate,Class_Date,Reason from Onlinestudent_MasterAttendance as ma Where Batch_Code='" + Request.QueryString["batchcode"] + "'";
       // Response.Write(_Qry);
        ////Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvclassdetails.DataSource = dt;
        gvclassdetails.DataBind();
    }

    private void FillBatchCode()
    {
        if (Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            _Qry = "select distinct sch.batchcode from erp_batchschedule sch inner join erp_batchdetails det on sch.batchcode=det.batchcode and det.status='pending' and sch.centrecode=det.centrecode inner join onlinestudentsfacultydetails fac on faculty_id=facultyid and sch.centrecode=fac.centre_code inner join  img_centrelogin cl on cl.username=fac.facultyname  where sch.centrecode='" + Session["SA_centre_code"].ToString() + "' and cl.username='" + Session["SA_Username"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddlbatchcode.DataSource = dt;
            ddlbatchcode.DataValueField = "batchcode";
            ddlbatchcode.DataTextField = "batchcode";
            ddlbatchcode.DataBind();
            ddlbatchcode.Items.Insert(0, new ListItem("Select", ""));
            ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
        }
        else
        {
            _Qry = @"SELECT DISTINCT erp_batchdetails.batchCode
FROM         erp_batchdetails INNER JOIN
                      erp_batchschedule ON erp_batchdetails.batchCode = erp_batchschedule.batchCode AND 
                      erp_batchdetails.centreCode = erp_batchschedule.centrecode INNER JOIN
                      erp_batchcontentstatus ON erp_batchdetails.batchCode = erp_batchcontentstatus.Batchcode AND 
                      erp_batchdetails.moduleId = erp_batchcontentstatus.module_id  and erp_batchcontentstatus.batchstatus='active' where erp_batchdetails.centrecode='" + Session["SA_centre_code"] + "'  and year(erp_batchcontentstatus.scheduledate)='" + ddlyear1.SelectedValue + "' ";

            //Response.Write(_Qry);
            //Response.End();
            if (ddlmonth.SelectedValue != "")
            {
                _Qry += "  and month(erp_batchcontentstatus.scheduledate)='" + ddlmonth1.SelectedValue + "' ";
            }
            if (ddl_slot.SelectedValue!= "")
            {
                _Qry += "  and erp_batchdetails.slot='" + ddl_slot.SelectedValue + "' ";
            }
            if (ddl_fac.SelectedValue != "")
            {
                _Qry += "  and erp_batchschedule.facultyid='" + ddl_fac.SelectedValue + "' ";
            }

            //Response.Write(_Qry);
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                ddlbatchcode.DataSource = dt;
                ddlbatchcode.DataValueField = "batchcode";
                ddlbatchcode.DataTextField = "batchcode";
                ddlbatchcode.DataBind();
                ddlbatchcode.Items.Insert(0, new ListItem("Select", ""));
                ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
                t1.Visible = true;
                tblbatch.Visible = false;
                attendance.Visible = false;
            }
            else
            {
              //  t1.Visible = true;
                lblerror.Text = "No Batch Found";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //_Qry = " Select Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,Batch_Time,convert(varchar(10),Batch_Startdate,103) as Batch_Startdate,convert(varchar(10),Batch_enddate,103) as Batch_Enddate ";
        //_Qry += " From Batch_Details Where Batch_Code='" + ddlbatchcode.SelectedValue + "' Group By Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,";
        //_Qry += "Batch_Time,Batch_Startdate,Batch_Enddate";
        _Qry = " select distinct bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(classdate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.SelectedValue + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(classdate)),103) from erp_batchcontentstatus where batchcode='" + ddlbatchcode.SelectedValue + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where  bs.batchcode='" + ddlbatchcode.SelectedValue + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        //Response.Write(_Qry);
        DataTable dt10 = new DataTable();
        dt10 = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt10.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            _Qry = @"select count(*) as total ,(select count(*)  from erp_batchcontentstatus 
where batchcode=sts.batchcode and status='Completed') as completed from erp_batchcontentstatus  sts
where sts.batchcode='"+ddlbatchcode.SelectedValue+"'  group by sts.batchcode ";
            DataTable dt100 = new DataTable();
            dt100 = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dt100.Rows.Count - 1; i++)
            {
                dt100.Rows.RemoveAt(i);
            }
            lbl_completed.Text = dt100.Rows[0]["completed"].ToString();
            lbl_totalclass.Text = dt100.Rows[0]["total"].ToString();


            
            txt_BatchTrack.Text = "Normal"; //dt10.Rows[0]["Batch_Track"].ToString();
            // txt_software.Text = ddlsoftwre.SelectedValue;
            txt_Module.Text = dt10.Rows[0]["module"].ToString();
            txt_Faculty.Text = dt10.Rows[dt10.Rows.Count - 1]["facultyname"].ToString();
            txt_Lab.Text = dt10.Rows[dt10.Rows.Count - 1]["labName"].ToString();
            txt_BatchSlot.Text = dt10.Rows[dt10.Rows.Count - 1]["Slot"].ToString();
            txt_BatchTime.Text = dt10.Rows[dt10.Rows.Count-1]["batchtiming"].ToString();
            txt_Bstart.Text = dt10.Rows[0]["startdate"].ToString();
            txt_Bend.Text = dt10.Rows[0]["Enddate"].ToString();
          
            
        }
        
            else
        {
            tblbatch.Visible = false;
           
        }
       
        attendance.Visible = true;
        Fillclassdetails();
    }
   
    //protected void ddlbatchcode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //_Qry = "select Software_Name from OnlineStudent_Attendance where centre_code='" + Session["SA_centre_code"] + "' And Batch_Code='" + ddlbatchcode.SelectedValue + "' group by batch_code,Software_Name";
    //    //DataTable dt = new DataTable();
    //    //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    //ddlsoftwre.DataSource = dt;
    //    //ddlsoftwre.DataValueField = "Software_Name";
    //    //ddlsoftwre.DataTextField = "Software_Name";
    //    //ddlsoftwre.DataBind();
    //    //ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
    //    tblbatch.Visible = false;
    //    attendance.Visible = false;
    //    ddlsoftwre.Items.Clear();
    //    ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
    //    _Qry = "Select software_name from module_details where Module_Content=(Select Batch_Module_Content From Batch_Details Where Batch_Code='" + ddlbatchcode.SelectedValue + "' group by batch_code,Batch_Module_Content)";

    //    SqlDataReader dr;
    //    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
    //    if (dr.HasRows)
    //    {
    //        dr.Read();
    //        string str = dr["software_name"].ToString();
    //        string[] softwarename = str.Split(',');
    //        int i = 1;
    //        foreach (string soft in softwarename)
    //        {
    //            ddlsoftwre.Items.Insert(i, new ListItem(soft, soft));
    //            i = i + 1;
    //        }
    //        dr.Close();
    //        //ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
    //    }
    //}
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("schedulebatch.aspx");
    }
    protected void gvclassdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvclassdetails.PageIndex = e.NewPageIndex;
        Fillclassdetails();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        FillBatchCode();
      
    }
    protected void gvclassdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string d = DateTime.Now.ToString("dd/MM/yyyy");

      // Response.Write("<br>"+DataBinder.Eval(e.Row.DataItem, "scheduledate"));
       // Response.Write("<br>"+d);

        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "scheduledate")) == d)
        {
            e.Row.BackColor = System.Drawing.Color.YellowGreen; // Full row color
            e.Row.ForeColor = System.Drawing.Color.Red; // Change the row's Text color
            e.Row.Font.Italic = true; 
            e.Row.BorderColor = System.Drawing.Color.Red;
     

        }


    }

    private void scheduleload()
    {

        _Qry = " select distinct bs.classdate,convert(varchar,bs.classdate,101) as correctdate,lab.labname,bs.labid,bs.facultyid,bs.centrecode,bs.batchtiming,bs.subcontentid,mod.moduleid,mod.module,fac.facultyname,bs.facultyid,bd.batchcode,bd.slot,module,software,content,(select convert(varchar(10),dateadd(d,0,min(classdate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as startdate,(select convert(varchar(10),dateadd(d,0,max(classdate)),103) from erp_batchcontentstatus where batchcode='" + Request.QueryString["batchcode"] + "') as Enddate  from erp_batchschedule bs inner join onlinestudentsfacultydetails fac on bs.facultyid=fac.faculty_id and bs.centrecode=fac.centre_code and bs.status='pending' inner join  online_students_labavail lab on lab.labid=bs.labid and lab.centre_code=bs.centrecode inner join submodule_details_new mod on mod.submodule_id=bs.subcontentid  inner join erp_batchcontentstatus cs on cs.batchcode=bs.batchcode and cs.subcontent_id=bs.subcontentid and cs.status='Pending' inner join erp_batchdetails bd on bd.batchcode=bs.batchcode and bd.centrecode=bs.centrecode and bd.status='pending' where  bs.batchcode='" + Request.QueryString["batchcode"] + "' and bs.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        //Response.Write(_Qry);
        DataTable dt10 = new DataTable();
        dt10 = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id where batchstatus='active'";
        DataTable dtab = new DataTable();
        dtab = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt10.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            _Qry = @"select count(*) as total ,(select count(*)  from erp_batchcontentstatus 
where batchcode=sts.batchcode and status='Completed') as completed from erp_batchcontentstatus  sts
where sts.batchcode='" + Request.QueryString["batchcode"] + "'  group by sts.batchcode ";
            DataTable dt100 = new DataTable();
            dt100 = MVC.DataAccess.ExecuteDataTable(_Qry);
            lbl_completed.Text = dt100.Rows[0]["completed"].ToString();
            lbl_totalclass.Text = dt100.Rows[0]["total"].ToString();



            txt_BatchTrack.Text = "Normal"; //dt10.Rows[0]["Batch_Track"].ToString();
            // txt_software.Text = ddlsoftwre.SelectedValue;
            txt_Module.Text = dt10.Rows[0]["module"].ToString();
            txt_Faculty.Text = dt10.Rows[dt10.Rows.Count - 1]["facultyname"].ToString();
            txt_Lab.Text = dt10.Rows[dt10.Rows.Count - 1]["labName"].ToString();
            txt_BatchSlot.Text = dt10.Rows[dt10.Rows.Count - 1]["Slot"].ToString();
            txt_BatchTime.Text = dt10.Rows[dt10.Rows.Count - 1]["batchtiming"].ToString();
            txt_Bstart.Text = dt10.Rows[0]["startdate"].ToString();
            txt_Bend.Text = dt10.Rows[0]["Enddate"].ToString();
            txt_software.Text = getsoft(dtab, "batchcode='" + Request.QueryString["batchcode"] + "'", "software_Name");


        }

        else
        {
            tblbatch.Visible = false;

        }

        attendance.Visible = true;
        Fillclassdetails();

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("" + ViewState["vv"] + "");
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

    protected System.Web.UI.HtmlControls.HtmlForm Form1;
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        //Form1.FindControl("gvclassdetails");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=batch.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

        
       
        parent.RenderControl(hw);

        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}
