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
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

public partial class superadmin_createnewBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, centrcode, couname, couid, todate, holdate, softid,qry111;
    string facultyid, labid, batchcode, batchtiming, batch1, content1, stdid, module, clsdate, subcontentid, contentid = "";
    int freesystem, batchedsystem, totalsystem;
    public string chk="";
    public string chk1 = "";
    string batchqry = "";
    string mainqry = "";
    int noofcls, weekday,endate;
    int yy = 0;
    string classdate = "";
    string classdatemwf = "";
    string classdatetts = "";
    DateTime stdate, lastday;
    string rr = "";
    string facid = "";
    string labtime = "";
    string labcode = "";
    string confirmation = "<table class='common' border='1px' width=350><tr><th>Class date</th><th>Content</th></tr> ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            ddlmonth.SelectedValue = DateTime.Now.ToString("MM");
            ddlyear.SelectedValue = DateTime.Now.ToString("yyyy");
            displaycourseonload();
            fillcoursedropdown();
            lbl_soft.Visible = false;
        }
       
    }



    private void fillcoursedropdown()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where  a.Status='Active' and centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        coursename_ddl.DataSource = dt;
        coursename_ddl.DataValueField = "course_id";
        coursename_ddl.DataTextField = "Program";
        coursename_ddl.DataBind();
        coursename_ddl.Items.Insert(0, new ListItem("Select", ""));



    }

    private void fillgrid()
    {
        try
        {
            getcheckbox();


            //            _Qry = @"select distinct p.enq_personal_name,p.student_id,Enqf.enq_personal_mobile,
            //G.Track,cou.program,cou.course_id,mod.module_content from 
            //adm_personalparticulars as p inner join adm_generalinfo G on 
            //p.student_id=G.student_id and p.studentstatus='active'  INNER JOIN  
            //img_enquiryform1 Enq on enq.enq_number=g.enq_number  and 
            //enq.centre_code=g.centre_code INNER JOIN img_enquiryform enqf on 
            //enqf.enq_number=enq.enq_number  and enqf.centre_code=g.centre_code
            //inner join img_coursedetails cou on cou.course_id=g.coursename 
            //inner join Onlinestudent_Coursesoftware mod  on cou.course_id=mod.course_id  
            //inner join submodule_details_new sub on sub.moduleid=mod.module_id
            // and sub.software_id not in (select old.software_id from erp_oldbatchdetails old 
            //where  old.studentid=p.student_id and old.status='active')  and 
            //g.student_id not in  (select bs.studentid from erp_batchdetails bd inner join 
            //erp_batchschedule bs on bs.batchcode=bd.batchcode and bd.centrecode=bs.centrecode  and bs.status='Pending' and bs.batchstatus='active'   and bs.studentid=p.student_id and bs.centrecode='" + Session["SA_centre_code"] + "')    and mod.module_id='" + ddl_coursename.SelectedValue + "' and p.centre_code='" + Session["SA_centre_code"] + "' and software_id in(" + chk + ")";
            _Qry = "select * from studentlist1 ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedValue + "','" + chk + " ','" + lbl_slot.Text + "','" + lbl_timing.Text + "')";

            // Response.Write(_Qry);
            //Response.End();
            DataTable dt12 = new DataTable();
            dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
            //Response.Write(_Qry);

            Gridvw.DataSource = dt12;
            Gridvw.DataBind();
            if (dt12.Rows.Count > 0)
            {
                tblBatch.Visible = true;
                // tblstudent.Visible = true;
                lblmsg1.Text = "";
            }
            else
            {
                lblmsg1.Text = "No Student Found";
                tblBatch.Visible = false;
                //  tblstudent.Visible = true;
            }

        }
        catch (Exception ex)
        {

        }

        }
       
   
      
        



    private void displaycourseonload()
    {
        _Qry = "SELECT a.Module_Id,Replace(a.Module_Content,'~','''') as Module_Content from Module_Details a inner join add_moduledetails b on a.module_id=b.module_id where b.mod_status='Active' ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        hdnModule.Value = dt.Rows[0]["Module_Content"].ToString();
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    
    protected void btn_submit_Click(object sender, EventArgs e)
     {
        


    
    }

    private void display_facultydd2()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
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

    protected void Button2_Click(object sender, EventArgs e)
    {
         _Qry = "select count(*) from  submodule_details_new where moduleid='" + ddl_coursename.SelectedValue + "' ";
        int countmod = 0;
        countmod = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (countmod > 0)
        {
            move.Visible = false;
            display_facultydd2();
            tblstudent.Visible = false;
            tblBatch.Visible = true;
            fillgrid();
        }
        else
        {
            lblmsg1.Text = "Please assign contents to the selected module";
        }

    }
  

    private void runningbatch()
    {
        _Qry = @"SELECT DISTINCT erp_batchschedule.batchCode
FROM         erp_batchdetails INNER JOIN
                      erp_batchschedule ON erp_batchdetails.batchCode = erp_batchschedule.batchCode AND 
                      erp_batchdetails.centreCode = erp_batchschedule.centrecode INNER JOIN
                      erp_batchcontentstatus ON erp_batchdetails.batchCode = erp_batchcontentstatus.Batchcode AND 
                      erp_batchdetails.moduleId = erp_batchcontentstatus.module_id  and erp_batchcontentstatus.batchstatus='active' where erp_batchdetails.moduleId='" + ddl_coursename.SelectedValue + "' and  erp_batchdetails.status='pending' and erp_batchdetails.centrecode='" + Session["SA_centre_code"] + "'  and year(erp_batchdetails.dateins)='" + ddlyear.SelectedValue + "' ";
        if (ddlmonth.SelectedValue != "")
        {
            _Qry += "  and month(erp_batchcontentstatus.scheduleDate)='" + ddlmonth.SelectedValue + "' ";
        }
        if (ddl_slot.SelectedValue != "")
        {
            _Qry += "  and erp_batchdetails.slot='" + ddl_slot.SelectedValue + "' ";
        }
        if (ddl_fac.SelectedValue != "")
        {
            _Qry += "  and erp_batchschedule.facultyid='" + ddl_fac.SelectedValue + "' ";
        }

    // Response.Write(_Qry);
      DataTable dt = new DataTable();
      dt = MVC.DataAccess.ExecuteDataTable(_Qry);
      //dt = getFilteredData(dt);
      //string[] arg = new string[1];

      //arg[0] = "batchcode";
      //dt = dt.DefaultView.ToTable(true, arg);
        if(dt.Rows.Count>0)
        {
        ddl_batchcode2.DataSource = dt;
        ddl_batchcode2.DataValueField = "batchcode";
        ddl_batchcode2.DataTextField = "batchcode";
        ddl_batchcode2.DataBind();
        ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
            move.Visible=true;
            btn_Movestudent.Visible = true;
            lblerror.Text = "";
            tblstudent.Visible = false;
        }
        else
        {
            lblerror.Text = "No Batch Found..!";
            tblstudent.Visible = false;
            move.Visible = false;
        }

    }
    DataTable getFilteredData(DataTable dt)
    {
        DataTable resDt = new DataTable();
        DataColumn dc = new DataColumn("BatchCode");
        resDt.Columns.Add(dc);

        foreach (DataRow dr in dt.Rows)
        {
            string softwareIds = chk;
            if(softwareIds!="")
            if (getBatchCode(dt, softwareIds, dr["batchCode"].ToString()))
            {
                DataRow dr1 = resDt.NewRow();
                dr1["BatchCode"] = dr["batchCode"].ToString();
                resDt.Rows.Add(dr1);
            }
       
        }
        return resDt;
    }
    bool getBatchCode(DataTable dt, string softwareids,string batchcode)
    {
        bool res = true;
        string[] softwareIdArray = new string[50];
        softwareIdArray = softwareids.Split(',');

        DataRow[] dr = new DataRow[20];
       
        if(softwareIdArray.Length >0)
        for (int i = 0; i < softwareIdArray.Length; i++)
        {
            dr = dt.Select("batchCode='" + batchcode + "' and software_id='" + softwareIdArray[i] + "'");
            if (dr.Length == 0)
            {
                res = false;
                break;
            }
        }

        return res;


    }
    protected void ddl_batchcode2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tblstudent.Visible = true;
            
            if (ddl_batchcode2.SelectedValue != "" && ddl_batchcode2.SelectedValue != null)
            {
                _Qry = @"
select lab.labid,fac.faculty_id,facultyname,labname,slot,bat.batchtiming,mod.module_content,mod.module_id,lab.labname,system from erp_batchdetails bat
 inner join module_details mod
on bat.moduleid= mod.module_id  inner join erp_batchschedule sce
 on sce.batchcode=bat.batchcode inner join erp_batchcontentstatus sts on sts.batchcode=sce.batchcode and sts.batchstatus='active' inner join online_students_labavail lab on
lab.labid=sce.labid  inner join onlinestudentsfacultydetails fac on sce.facultyid=fac.faculty_id
where  sce.centrecode='" + Session["SA_centre_code"] + "' and sce.batchCode ='" + ddl_batchcode2.SelectedValue + "'  and bat.moduleid='" + ddl_coursename.SelectedValue + "' and sce.status='pending'  group by sce.batchcode,slot,bat.batchtiming,system,mod.module_content,mod.module_id,labname,fac.facultyname,fac.faculty_id,lab.labid";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);


                _Qry = "select count(distinct studentid) as batched from erp_batchschedule where batchstatus='active' and batchcode='" + ddl_batchcode2.SelectedValue + "' ";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dt1.Rows.Count > 0)
                {
                    batchedsystem = Convert.ToInt32(dt1.Rows[0]["batched"].ToString());
                }


                if (dt.Rows.Count > 0)
                {
                    lab_id.Text = dt.Rows[0]["labid"].ToString();
                    fac_id.Text = dt.Rows[0]["faculty_id"].ToString();
                    lblsoftware.Text = dt.Rows[0]["module_content"].ToString();
                    Label5.Text = dt.Rows[0]["module_id"].ToString();
                    mod.Visible = true;
                    faculty.Visible = true;
                    lbl_slot.Text = dt.Rows[0]["slot"].ToString();
                    Slot.Visible = true;
                    lbl_timing.Text = dt.Rows[0]["batchtiming"].ToString();
                    BatchTiming.Visible = true;
                    totalsystem = Convert.ToInt32(dt.Rows[0]["system"].ToString());
                    FreeSystem.Visible = true;
                   // batchedsystem = Convert.ToInt32(dt.Rows[0]["batched"].ToString());
                    lbl_lab.Text = dt.Rows[0]["labname"].ToString();
                    Lab.Visible = true;
                    freesystem = totalsystem - batchedsystem;
                    name.Text = dt.Rows[0]["facultyname"].ToString();
                    faculty.Visible = true;
                    Label4.Visible = true;
                   
                    totalsys.Text = " <span style='color:red;font-weight:bold'> " + batchedsystem.ToString() + "&nbsp;Batched </span>";
                    hdnfree.Value = freesystem.ToString();
                    lbl_free.Text = "<span style='color:green;font-weight:bold'>" + freesystem.ToString() + "&nbsp;Available</span>";
                    fillgrid1();
                   // fillgrid();
                }

            }
            else
            {
                lblsoftware.Text = "";
                tblstudent.Visible = false;

            }
        }
        catch (Exception ex)
        {
            //lblmsg1.Text = ex.ToString();
        }



    }
    protected void btn_Movestudent_Click(object sender, EventArgs e)
       
    {
       
        try
        {
            foreach (GridViewRow roww in Gridvw.Rows)
            {
                CheckBox chbox = new CheckBox();
                chbox = (CheckBox)roww.FindControl("CheckBox1");
                if (chbox.Checked == true)
                {
                    Label lbl = new Label();
                    lbl = (Label)roww.FindControl("lbl_stdid");
                    stdid = lbl.Text;

                   


                    getcheckbox();
                    string qry1 = " select distinct ModuleId,software_id from submodule_details_new where moduleid='" + ddl_coursename.SelectedValue + "' and software_id in (" + chk + ") order by software_id";

                  
                        
                        DataTable dtmodule1 = new DataTable();
                    dtmodule1 = MVC.DataAccess.ExecuteDataTable(qry1);
                 
                    for (int j = 0; j < dtmodule1.Rows.Count; j++)
                    {
                        softid = dtmodule1.Rows[j]["software_id"].ToString();
                        qry111 = " insert into erp_oldbatchdetails ([software_id],[studentid],[moduleid],[centre_code],[status],[softwarestatus])values('" + softid + "','" + stdid + "','" + ddl_coursename.SelectedValue + "','" + Session["SA_centre_code"].ToString() + "','active','pending')";

                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry111);
                    
                    
                    }






                    if (Convert.ToInt32(hdnfree.Value) <= 0)
                    {
                        lblmsg1.Text = "System unavalaible";
                    }
                    else
                    {
                        _Qry = "select subcontent_id,classdate,software_id from erp_batchcontentstatus where batchcode='"+ddl_batchcode2.SelectedValue+"'";
                          DataTable dt = new DataTable();
                         dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                              subcontentid = dt.Rows[i]["subcontent_id"].ToString();
                              clsdate = dt.Rows[i]["classdate"].ToString();
                              softid = dt.Rows[i]["software_id"].ToString();
                              _Qry = @"INSERT INTO [erp_batchschedule] ([studentId],[facultyId],[labId],[classDate],[batchCode],[batchTiming] ,[subContentId],[centrecode],[status],[dateins],[Software_Id]) VALUES ('" + stdid + "','" + fac_id.Text + "','" + lab_id.Text + "','" + clsdate + "','" + ddl_batchcode2.SelectedValue + "','" + lbl_timing.Text + "' ," + subcontentid + ",'" + Session["SA_centre_code"].ToString() + "','Pending',getdate(),'"+softid+"')";
                              MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                         }
                   
                       _Qry=" update adm_generalinfo set Track='Batched' where student_id='" + stdid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                       MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                       lblmsg1.Text = "Student Successfully Added to the Batch";
                       Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert('Student Added To Running Batch !..');</script>");
                       
                    }

                }

            }
            lblmsg1.Text = "Student Successfully Added to the Batch";
            //fillgrid();
            runningbatch();
            ddl_coursename.SelectedValue = "";
            lbl_soft.Visible = false;
            CheckBoxList1.Visible = false;
            tblBatch.Visible = false;

        }
        catch (Exception ex)
        {
            lblmsg1.Text = ex.ToString();
        }


    }
    private void fillgrid1()
    {

        _Qry = @"select distinct convert(varchar ,sts.classdate,103)as classdate , sts.batchcode,sts.module_id,sts.subcontent_id,cnt.[content]
from erp_batchcontentstatus sts 
inner join  Submodule_details_new cnt on sts.subcontent_id=cnt.submodule_id 
inner join erp_batchschedule sce
 on sce.batchcode=sts.batchcode
where sts.status='Pending' 
and sts.batchcode='" + ddl_batchcode2.SelectedValue + "'";

        DataTable dt0 = new DataTable();
        dt0 = MVC.DataAccess.ExecuteDataTable(_Qry);
        for (int i = 0; i < dt0.Rows.Count; i++)
        {
            if (contentid == "")
            {
                contentid = dt0.Rows[i]["subcontent_id"].ToString();
            }
            else
            {
                contentid = contentid + "," + dt0.Rows[i]["subcontent_id"].ToString();
            }
            Session["subid"] = contentid.ToString();
        }

        GridView2.DataSource = dt0;
        GridView2.DataBind();

    }
 
    protected void Gridvw_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        Gridvw.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        fillgrid1();

    }

    private void fillsoft()
    {
        _Qry = "select distinct a.Software,a.Software_id from Submodule_details_new a inner join Onlinestudent_Software b on b.software_id=a.software_id where b.status='Enable' and ModuleId='" + ddl_coursename.SelectedValue + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CheckBoxList1.Items.Clear();
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "Software";
            CheckBoxList1.DataValueField = "Software_id";
            CheckBoxList1.DataBind();
        }

        //_Qry = "select software_id from module_details where module_id='" + ddl_coursename.SelectedValue + "'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{

        //    CheckBoxList1.Items.Clear();
        //    string soft = dt.Rows[0]["software_id"].ToString();
        //    _Qry = "select software_id,software_name from Onlinestudent_Software where software_id in (select data as dat from SplitString('" + soft + "',','))";
        //    DataTable dt1 = new DataTable();
        //    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //    CheckBoxList1.DataSource = dt1;
        //    CheckBoxList1.DataTextField = "software_name";
        //    CheckBoxList1.DataValueField = "software_id";
        //    CheckBoxList1.DataBind();
        //    //CheckBoxList1.Items.Insert(0, new ListItem("Select All", ""));

        //}


    }
    protected void ddl_coursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        tblBatch.Visible = false;
        lbl_soft.Visible = true;
        CheckBoxList1.Visible = true;
        fillsoft();
  
        foreach (ListItem li in CheckBoxList1.Items)
        {
            if (CheckBoxList1.Items.Count == 1)
            {
                li.Selected = true;
            }
        }    
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
        tblstudent.Visible = true;
        tblBatch.Visible = true;


    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //getcheckbox();
        runningbatch();
        //fillgrid();
       
     
          
        
    }

    public void getcheckbox()
    
    {
        
        int n;
        for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
        {
            if (CheckBoxList1.Items[n].Selected)
            {
               
                if (chk == "")
                {
                   chk = CheckBoxList1.Items[n].Value;
                }
                else
                {
                    chk = chk + "," + CheckBoxList1.Items[n].Value;
                }
              
            }
           
        }

       
    }

    public void soft()
    {
        int n;
        for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
        {
            if (CheckBoxList1.Items[n].Selected)
            {

                if (chk1 == "")
                {
                    chk1 = CheckBoxList1.Items[n].Value;
                }
                else
                {
                    chk1 = chk1 +"<br/>"+ CheckBoxList1.Items[n].Value;
                }

            }
            //}
        }

    }
   
}

