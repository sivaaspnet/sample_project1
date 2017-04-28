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

public partial class superadmin_ViewbatchDetails : System.Web.UI.Page
{
    string _Qry;
    string BatchCount, batch_code, couname, couid, todate, holdate;
    int noofcls;
    DateTime stdate, lastday;
    DataTable status = new DataTable();
   
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
            fillgrid();
            display_facultyddl();
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }

       
    }

    private void display_facultyddl()
    {
       // _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("All", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void fillgrid()
    {
//        _Qry = @"select  distinct bat.batchcode,mod.module_content,bat.slot,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
//(select  CONVERT(VARCHAR(10),min( classDate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
//(select  CONVERT(VARCHAR(10),max( classDate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
// from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
//on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
//onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
        _Qry = @"select distinct bat.batchid,bat.batchcode,dbo.weekdays1(bat.slotday) as slotday,bat.status,max(mod.module_content) as module_content,bat.slot,bat.batchtiming,max(bat.status) as status ,sce.labid,sce.facultyid,
max(lab.labname) as labname,max(facultyname) as facultyname, CONVERT(VARCHAR(10),min( sts.scheduledate ),103) as Startdate,
CONVERT(VARCHAR(10),max( sts.classDate ),103) as Enddate  from
 erp_batchdetails bat inner join module_details mod on moduleid=module_id inner join 
erp_batchschedule sce on sce.batchcode=bat.batchcode inner join 
online_students_labavail lab on lab.labid=sce.labid inner join 
erp_batchcontentstatus sts on sts.batchcode=bat.batchcode  inner join
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
 where  bat.centrecode='" + Session["SA_centre_code"].ToString() + "' and year(sce.classdate)='"+ddlyear.SelectedValue+"' ";
        if (ddlmonth.SelectedValue != "")
        {
            _Qry += "  and month(sce.classdate)='" + ddlmonth.SelectedValue + "' ";
        }

        if (Session["SA_Centrerole"].ToString() == "Faculty")
        {
            _Qry += "  and facultyname='" + Session["SA_Username"] + "' ";
            Label1.Visible = false;
            ddl_fac.Visible = false;

        }
        if (ddl_slot.SelectedValue != "")
        {
            _Qry += "  and bat.slot='" + ddl_slot.SelectedValue + "' ";
        }
        if (ddl_fac.SelectedValue != "")
        {
            _Qry += "  and facultyid='" + ddl_fac.SelectedValue + "' ";
        }

        if (DropDownList1.SelectedValue != "")
        {
            _Qry += "  and  bat.status='" + DropDownList1.SelectedValue + "' ";
        }


        _Qry += "  group by bat.batchcode,sce.facultyid,sce.labid,bat.batchtiming,bat.slot,bat.slotday,bat.status,bat.batchid  order by bat.batchid desc";
   //Response.Write(_Qry);
      //Response.End();
       

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);


        //_Qry = @"select * from erp_batchdetails";
        //if (DropDownList1.SelectedValue != "")
        //{
        //    _Qry += "  where  status='" + DropDownList1.SelectedValue + "' ";
        //}

        //Response.Write(_Qry);
        //DataTable dt2 = new DataTable();
        //dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id ";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);




        status.Columns.Add(new DataColumn("software", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("module_content", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("slot", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchtiming", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("labname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("facultyname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Startdate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("Enddate", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("slotday", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();


        DataTable dt21 = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] args = new string[4];
        args[0] = "batchcode";
        args[1] = "module_content";
        args[2] = "Startdate";
        args[3] = "Enddate";
       
      

        dt21 = dt.DefaultView.ToTable(true, args);


        foreach (DataRow drs in dt21.Rows)
        {

            dr = status.NewRow();
            dr["batchcode"] = drs["batchcode"];
            dr["software"] = getsoft(dt2, "batchcode='" + drs["batchcode"] + "'", "software_Name");
            dr["module_content"] = drs["module_content"];
            dr["slot"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "slot");
            dr["batchtiming"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "batchtiming"); 
            dr["labname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'","labname"); 
           // dr["facultyname"] = drs["facultyname"];
            dr["facultyname"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'","facultyname");
            dr["Startdate"] = drs["Startdate"];
            dr["Enddate"] = drs["Enddate"];
            dr["status"] = getstatus(dt, "batchcode='"+drs["batchcode"]+"'");
            dr["slotday"] = getfac(dt, "batchcode='" + drs["batchcode"] + "'", "slotday");
            status.Rows.Add(dr);

        }

        if (status.Rows.Count > 0)
        {
            GridView1.Visible = true;
            lnkdownload.Visible = true;
            GridView1.DataSource = status;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            lnkdownload.Visible = false;
            showBox("No Record Found...!");
            
        }
        
        
    }

    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    string getfac( DataTable dtexp,string expression,string column)

    {
        string faculty="";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if(dr.Length>0)
        {
            foreach( DataRow val in dr)
            {
                if (faculty == "")
                {
                    faculty = (val[column].ToString());
                }
                else if(faculty == (val[column].ToString()))
                {
                    faculty = (val[column].ToString());
                }
                else
                {
                    faculty = faculty + "<br>" + (val[column].ToString());
                }

            }
        }
        return faculty.ToString();

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
                    soft = soft + "<br>" + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

    }



    string getstatus(DataTable dtexp, string expression)
    {
        string res = "Completed";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {
                res = val["status"].ToString();
            }

            string value = res;

            if ((value == "pending") || (value == "Repending") || (value == "Pending"))
                {
                    res = "<span style='color:blue; font-weight:bold;'>Inprogress</span>";
                }
            else if ((value == "Completed") || (value == "completed") || (value == "Complete"))
                {
                    res = "<span style='color:green; font-weight:bold;'>Completed</span>";
                }
                else if ((value == "Dropped") || (value == "dropped") || (value == "drop"))
            {
                res = "<span style='color:red; font-weight:bold;'>Suspended</span>";
            }
             
           
        }
       
        return res.ToString();
    }
   
   private void refresh()
    {
        //txt_systems.Text = "";
        //txt_labname.Text = "";
    }
   
        //if (e.CommandName == "del")
        //{
        //    _Qry = "delete from online_students_labavail where LabId='" + e.CommandArgument.ToString() + "'";
        //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
        //    fillgrid();
        //    lblmsg1.Text = "The lab details has been deleted successfully";
        //    refresh();
        //}

    protected void btn_search_Click(object sender, EventArgs e)
    {
       
    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(status);
    }

    public void ExportTableData(DataTable dtdata)
    {
        
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Batch-details-of-"+ddlmonth.SelectedItem.Text+"-"+ddlyear.SelectedItem.Text+"-in-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }

}
