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

public partial class OnlineStudents_superadmin_ChangeBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2;
    string facultyid, labid, batchcode, batchtiming, batch1, content1, stdid, module, subcontentid, contentid="",softid="" ;
    int freesystem, batchedsystem, totalsystem;
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
            if (Request.QueryString["batchcode"] == null)
            {
                ddlmonth.SelectedValue = DateTime.Now.ToString("MM");
                ddlyear.SelectedValue = DateTime.Now.ToString("yyyy");
                display_facultyddl();
                ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
            }

            else
            {
                tr1.Visible = false;
                tr2.Visible = false;
                batch.Visible = false;
                move.Visible = true;
                ddlbatch1.Value = Request.QueryString["batchcode"].ToString();
                hdnModule.Value = Request.QueryString["module"].ToString();
                hdnsoft.Value = Request.QueryString["software"].ToString();
                ddlmonth1.SelectedValue = DateTime.Now.ToString("MM");
                ddlyear1.SelectedValue = DateTime.Now.ToString("yyyy");
                display_facultyddl();
                fill_batchcode2();
                grid1();
            }
        }

    }
    #endregion
    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        DropDownList1.DataSource = dt;
        DropDownList1.DataValueField = "faculty_id";
        DropDownList1.DataTextField = "facultyname";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", ""));

        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("All", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void FillBatch()
    {
       


        _Qry = @"SELECT DISTINCT erp_batchdetails.batchCode  from
        erp_batchdetails INNER JOIN
                      erp_batchschedule ON erp_batchdetails.batchCode = erp_batchschedule.batchCode AND 
                      erp_batchdetails.centreCode = erp_batchschedule.centrecode INNER JOIN
                      erp_batchcontentstatus ON erp_batchdetails.batchCode = erp_batchcontentstatus.Batchcode AND 
                      erp_batchdetails.moduleId = erp_batchcontentstatus.module_id where   erp_batchdetails.centrecode='" + Session["SA_centre_code"] + "' and erp_batchdetails.status='Pending' and year(erp_batchcontentstatus.scheduledate)='" + ddlyear.SelectedValue + "' ";

        if (ddlmonth.SelectedValue != "")
        {
            _Qry += "  and month(erp_batchcontentstatus.scheduledate)='" + ddlmonth.SelectedValue + "' ";
        }
        if (ddl_fac.SelectedValue != "")
        {
            _Qry += "  and erp_batchschedule.facultyid='" + ddl_fac.SelectedValue + "' ";
        }
        if (ddl_slot.SelectedValue != "")
        {
            _Qry += "  and erp_batchdetails.slot='" + ddl_slot.SelectedValue + "' ";
        }
        
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Response.Write(_Qry);
        if (dt.Rows.Count > 0)
        {
            batch.Visible = true;
            ddl_batchcode1.DataSource = dt;
            ddl_batchcode1.DataTextField = "batchCode";
            ddl_batchcode1.DataValueField = "batchCode";
            ddl_batchcode1.DataBind();
            ddl_batchcode1.Items.Insert(0, new ListItem("Select", ""));
           
        }
        else
        {
            lblerrormsg.Text = "No Batch Found";
        }
    }


    protected void ddl_batchcode1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            _Qry = @"select count(subcontentId) as pendingclass from erp_batchschedule where batchcode='" + ddl_batchcode1.SelectedValue + "'  and status ='Pending'";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            lblerrormsg.Text = "";
            ddlbatch1.Value = ddl_batchcode1.SelectedValue;
            grid1();
            fill_batchcode2();
            move.Visible = true;
           
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = ex.ToString();
        }
    }

    private void grid1()
    {
        _Qry = @" select  sce.batchcode,sce.studentid,enq_personal_name ,count(sce.status)as PendingClasses,mod.module_content,mod.module_id  from erp_batchschedule sce inner join erp_batchdetails
 bat on sce.batchcode=bat.batchcode  inner join module_details mod on 
bat.moduleid= mod.module_id  inner join adm_personalparticulars adm on sce.studentid=adm.student_id and adm.studentstatus='active'  where sce.centrecode='" + Session["SA_centre_code"] + "' and sce.batchcode='" + ddlbatch1.Value + "' and sce.status='Pending' group by sce.studentid,mod.module_id,mod.module_content,sce.batchcode,enq_personal_name";
       // Response.Write(_Qry);
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridvw.DataSource = dt;
        Gridvw.DataBind();
        if (dt.Rows.Count > 0)
        {
            
            Gridvw.Visible = true;
            gridshow.Visible = true;
            hdnModule.Value = dt.Rows[0]["module_id"].ToString();
            lbl_Fmodule.Text = dt.Rows[0]["module_content"].ToString();
            lbl_mod.Visible = true;
            lbl_stu.Visible = true;
            lblstu.Visible = true;
          
        }
        else
        {
            lblerrormsg.Text = "No students available";
            ddl_batchcode2.Items.Clear();
            ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
            lbl_mod.Visible = false;
            Gridvw.Visible = false;
            lbl_stu.Visible = false;
            lblstu.Visible = false;
        }

    }

    private void fill_batchcode2()
    {
        try
        {

            //_Qry = "select distinct a.Software_id as Software,b.batchCode from erp_batchcontentstatus a inner join erp_batchdetails b on a.Batchcode=b.batchCode order by batchCode";
            //DataTable dtab = new DataTable();
            //dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
            //string str = getsoft(dtab, "batchCode='" + ddl_batchcode2.SelectedValue + "'", "Software_id");
           


            //if (ddl_batchcode1.SelectedValue != "" && ddl_batchcode1.SelectedValue != null)
            //{
                ddl_batchcode2.Items.Clear();
               _Qry = @"SELECT DISTINCT erp_batchdetails.batchCode FROM         erp_batchdetails INNER JOIN
                      erp_batchschedule ON erp_batchdetails.batchCode = erp_batchschedule.batchCode AND 
                      erp_batchdetails.centreCode = erp_batchschedule.centrecode INNER JOIN
                      erp_batchcontentstatus ON erp_batchdetails.batchCode = erp_batchcontentstatus.Batchcode AND 
                      erp_batchdetails.moduleId = erp_batchcontentstatus.module_id  and erp_batchcontentstatus.batchstatus='active' where  erp_batchdetails.moduleId='" + hdnModule.Value + "' and  erp_batchdetails.batchCode<>'" + ddlbatch1.Value + "' and erp_batchdetails.status='pending' and erp_batchdetails.centrecode='" + Session["SA_centre_code"] + "' and year(erp_batchcontentstatus.scheduledate)='" + ddlyear1.SelectedValue + "' and erp_batchcontentstatus.Software_id in("+hdnsoft.Value+")";

               if (ddlmonth1.SelectedValue != "")
               {
                   _Qry += "  and month(erp_batchcontentstatus.scheduledate)='" + ddlmonth1.SelectedValue + "' ";
               }
               if (DropDownList1.SelectedValue != "")
               {
                   _Qry += "  and erp_batchschedule.facultyid='" +DropDownList1.SelectedValue + "' ";
               }
               if (DropDownList2.SelectedValue != "")
               {
                   _Qry += "  and erp_batchdetails.slot='" +DropDownList2.SelectedValue+ "' ";
               }
        


              //Response.Write(_Qry);
              //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lblerror.Text = "";
                    
                    move.Visible = true;

                    ddl_batchcode2.DataSource = dt;
                    ddl_batchcode2.DataValueField = "batchcode";
                    ddl_batchcode2.DataTextField = "batchcode";
                    ddl_batchcode2.DataBind();
                    ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));

                }
                else
                {
                  
                    ddl_batchcode2.Items.Clear();
                    ddl_batchcode2.Items.Insert(0, new ListItem("Select", ""));
                    lblerror.Text = "No other batch available";
                    gridshow.Visible = false;
                    lblstu.Visible = false;
                    t1.Visible = false;
                    t2.Visible = false;
                    move.Visible = false;
                   
                }
            }
            //else
            //{
            //    ddl_batchcode2.Items.Clear();
              
            //}
       // }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }

    protected void ddl_batchcode2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            lblerrormsg.Text = "";
            if (ddl_batchcode2.SelectedValue != "" && ddl_batchcode2.SelectedValue != null)
            {
                _Qry = @"
select facultyname,labname,slot,bat.batchtiming,mod.module_content,lab.labname,system from erp_batchdetails bat
 inner join module_details mod
on bat.moduleid= mod.module_id  inner join erp_batchschedule sce
 on sce.batchcode=bat.batchcode inner join online_students_labavail lab on
lab.labid=sce.labid  inner join onlinestudentsfacultydetails fac on sce.facultyid=fac.faculty_id
where  sce.centrecode='" + Session["SA_centre_code"] + "' and sce.batchCode ='" + ddl_batchcode2.SelectedValue + "' and mod.module_id='" + hdnModule.Value + "' and sce.status='pending'  group by sce.batchcode,slot,bat.batchtiming,system,mod.module_content,labname,fac.facultyname";
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
                    lblsoftware.Text = dt.Rows[0]["module_content"].ToString();
                    mod.Visible = true;
                    lbl_slot.Text = dt.Rows[0]["slot"].ToString();
                    Slot.Visible = true;
                    lbl_timing.Text = dt.Rows[0]["batchtiming"].ToString();
                    BatchTiming.Visible = true;
                    totalsystem = Convert.ToInt32(dt.Rows[0]["system"].ToString());
                    FreeSystem.Visible = true;
                  //  batchedsystem = Convert.ToInt32(dt.Rows[0]["batched"].ToString());
                    lbl_lab.Text = dt.Rows[0]["labname"].ToString();
                    Lab.Visible = true;
                    freesystem = totalsystem - batchedsystem;
                    name.Text = dt.Rows[0]["facultyname"].ToString();

                    faculty.Visible = true;
                    totalsys.Text = "( <span style='color:red;font-weight:bold'> " + batchedsystem.ToString() + "&nbsp;Batched </span>)";
                    hdnfree.Value = freesystem.ToString();
                    lbl_free.Text = "<span style='color:green;font-weight:bold'>" + freesystem.ToString() + "&nbsp;Available</span>";
                    //_Qry = "select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id where batchstatus='active'";
                    //DataTable dtab = new DataTable();
                    //dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
                    //Label6.Text = getsoft(dtab, "batchCode='" + ddl_batchcode2.SelectedValue + "'", "Software_Name");
                    fillgrid1();
                    if (ddl_batchcode2.SelectedItem .ToString()== "Select")
                    {
                        gridshow.Visible = false;
                        lblstu.Visible = false;
                        t1.Visible = false;
                        t2.Visible = false;
                       

                    }

                    else
                    {
                        t1.Visible = true;
                        t2.Visible = true;
                    }
                   
                   
                }
                else
                {
                    lblerrormsg.Text = "Please Contact Admin";
                }
                 
            }
            else
            {
                lblsoftware.Text = "";
                lblerrormsg.Text = "Please Contact Admin";
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = "Please Contact Admin";
        }
    }



    #region for Moving the Student from One batch to another
    
   


    protected void btn_Movestudent_Click(object sender, EventArgs e)
    {
        try
        {
            _Qry = "select distinct facultyid,labid,batchcode,batchtiming  from erp_batchschedule where batchcode='" + ddl_batchcode2.SelectedValue + "' and centrecode='" + Session["SA_centre_code"] + "'";
            DataTable dt6 = new DataTable();
            dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt6.Rows.Count > 0)
            {
                facultyid = dt6.Rows[0]["facultyid"].ToString();
                labid = dt6.Rows[0]["labid"].ToString();
                batchcode = dt6.Rows[0]["batchcode"].ToString();
                batchtiming = dt6.Rows[0]["batchtiming"].ToString();

            }

            //Batch change
           

            foreach (GridViewRow roww in Gridvw.Rows)
            {
                CheckBox chbox = new CheckBox();
                chbox = (CheckBox)roww.FindControl("CheckBox1");
                if (chbox.Checked == true)
                {
                    Label lbl = new Label();
                    lbl = (Label)roww.FindControl("lbl_stdid");
                    stdid = lbl.Text;
                    Label lblm = new Label();
                    lblm = (Label)roww.FindControl("lbl_Module");
                    module = lblm.Text;

                    if (Convert.ToInt32(hdnfree.Value) <= 0)
                    {
                        lblerrormsg.Text = "System unavalaible";
                    }
                    else
                    {
                                _Qry = @"select distinct sts.Software_id, sts.classdate, sts.batchcode,sts.module_id,sts.subcontent_id,cnt.[content]
                                from erp_batchcontentstatus sts 
                                inner join  Submodule_details_new cnt on sts.subcontent_id=cnt.submodule_id 
                                inner join erp_batchschedule sce
                                on sce.batchcode=sts.batchcode
                                where sts.status='pending' 
                                and sts.batchcode='" +ddl_batchcode2.SelectedValue+"'";

                                        DataTable dt0 = new DataTable();
                                        dt0 = MVC.DataAccess.ExecuteDataTable(_Qry);
                                        for (int i = 0; i < dt0.Rows.Count; i++)
                                        {
                                            string date=dt0.Rows[i]["classdate"].ToString();
                                            contentid = dt0.Rows[i]["subcontent_id"].ToString();
                                             softid = dt0.Rows[i]["Software_id"].ToString();
                                            string remark = "Batch Changed From  " + ddlbatch1.Value.ToString();
                                            _Qry = " update erp_batchschedule set batchstatus='Deactive' where centrecode='" + Session["SA_centre_code"] + "' and studentid='" + stdid + "'  and batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            _Qry = "update erp_batchschedule set classdate='" + date + "',batchstatus='active', remarks='" + remark + "',facultyid='" + facultyid + "',labid='" + labid + "',batchcode='" + batchcode + "',batchtiming='" + batchtiming + "' where status='pending' and centrecode='" + Session["SA_centre_code"] + "' and studentid='" + stdid + "'  and batchcode='" + ddlbatch1.Value + "'  and subcontentid ='" + contentid + "'and Software_id ='"+softid+"'";
                                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                          
                                            // _Qry = "update erp_batchschedule set status='Repending',remarks='batch changed'   where status='Pending' and centrecode='" + Session["SA_centre_code"] + "' and studentid='" + stdid + "'  and batchcode='" + ddl_batchcode1.SelectedValue + "' ";
                                            // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                            DropDownList1.SelectedValue = "";
                                            DropDownList2.SelectedValue = "";
                                            
                                            ddlmonth1.SelectedValue = "";
                                            ddlyear1.SelectedValue = "";
                                            batch.Visible = false;
                                            t1.Visible = false;
                                            t2.Visible = false;
                                            lblerrormsg.Text = "Batch changed";
                                            

                                        }
                       
                                
                    }

                    }

                }
           
          
            grid1();

            
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = ex.ToString();
        }
    }
    #endregion
    
    private void fillgrid1()
    {

        _Qry = @"select distinct convert(varchar,sts.classdate,103)as classdate, sts.batchcode,sts.module_id,sts.subcontent_id,cnt.[content]
from erp_batchcontentstatus sts 
inner join  Submodule_details_new cnt on sts.subcontent_id=cnt.submodule_id 
inner join erp_batchschedule sce
 on sce.batchcode=sts.batchcode
where sts.status='Pending' 
and sts.batchcode='" +ddl_batchcode2.SelectedValue+"'";
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(_Qry);  
        GridView2.DataSource = dt4;
        GridView2.DataBind();
      
        

    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        fillgrid1();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        FillBatch();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fill_batchcode2();
    }

    string getsoft(DataTable dtexp, string expression, string column)
    {
        string faculty = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (faculty == "")
                {
                    faculty = (val[column].ToString());
                }
                else if (faculty == (val[column].ToString()))
                {
                    faculty = (val[column].ToString());
                }
                else
                {
                    faculty = faculty + ",<br>" + (val[column].ToString());
                }

            }
        }
        return faculty.ToString();

    }
    public void dad()
    {
        
    }
   
}
