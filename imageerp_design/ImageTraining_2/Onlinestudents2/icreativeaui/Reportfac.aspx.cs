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

public partial class Onlinestudents2_superadmin_staff : System.Web.UI.Page
{
    string qry;
    DataTable reportfac = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            display_facultyddl();
        }
    }

    private void fillgrid()
    {

        string str = txtfromdate.Text;
        string[] split = str.Split('-');
        string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

        string str1 = txttodate.Text;
        string[] split1 = str1.Split('-');
        string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

        qry = @"select  distinct bat.batchcode,mod.module_content,bat.slot,bat.batchtiming,bat.status ,noofclass,sce.labid,sce.facultyid,lab.labname,facultyname

 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid inner join erp_batchcontentstatus sts
on sts.batchcode=sce.batchcode
where sts.classDate between '" + dateFrom + "' and '" + dateTo+ "' and sce.centrecode='"+Session["SA_centre_code"]+"'";

           if (ddl_fac.SelectedValue!="")
        {
            qry += " and sce.facultyid='" + ddl_fac.SelectedValue + "'";
        }
        qry += " order by sce.facultyid ";
        //(select  CONVERT(VARCHAR(10),min( classDate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
//(select  CONVERT(VARCHAR(10),max( classDate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate


        //Response.Write(qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);

        qry = "select count(distinct studentid)as noofstudent ,batchcode,CONVERT(VARCHAR(10),min(dateadd(d,0, classDate) ),103)as startdate,CONVERT(VARCHAR(10),max( dateadd(d,0,classDate)),103) as enddate   from erp_batchschedule group by batchcode";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(qry);

        //qry = " select bs.batchcode,bs.facultyid,max(noofclass) as noofclass from   erp_batchschedule bs inner join erp_batchdetails sts on sts.batchcode=bs.batchcode and sts.centrecode=bs.centrecode  where  bs.status<>'pending'  and sts.centrecode='"+Session["SA_centre_code"].ToString()+"'  group by bs.batchcode,subcontentid,facultyid ";
        qry = " select bs.batchcode,bs.facultyid,max(noofclass) as noofclass from erp_batchschedule bs inner join erp_batchdetails sts on sts.batchcode=bs.batchcode and sts.centrecode=bs.centrecode inner join erp_batchcontentstatus cs on cs.batchcode=sts.batchcode and cs.status='Completed' and cs.subcontent_id=bs.subcontentid  where  sts.centrecode='" + Session["SA_centre_code"].ToString() + "'  group by bs.batchcode,subcontentid,facultyid  ";
        DataTable dtcomplete = new DataTable();
        dtcomplete = MVC.DataAccess.ExecuteDataTable(qry);
        //Response.Write(qry);
        
        reportfac.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("module_content", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("slot", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("batchtiming", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("labname", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("facultyname", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("Startdate", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("Enddate", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("noofstudent", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));   
        reportfac.Columns.Add(new DataColumn("Content1", System.Type.GetType("System.String")));
        reportfac.Columns.Add(new DataColumn("Content", System.Type.GetType("System.String")));
        DataRow dr = reportfac.NewRow();

        foreach (DataRow drs in dt.Rows)
        {
            dr = reportfac.NewRow();
            dr["batchcode"] = drs["batchcode"];
            dr["module_content"] = drs["module_content"];
            dr["slot"] = drs["slot"];
            dr["batchtiming"] = drs["batchtiming"];
            dr["labname"] = drs["labname"];
            dr["facultyname"] = drs["facultyname"];
            dr["Startdate"] = getnoofstudent(dt1, "batchcode='" + drs["batchcode"] + "'", "Startdate");
            dr["Enddate"] = getnoofstudent(dt1, "batchcode='" + drs["batchcode"] + "'", "Enddate");
            dr["noofstudent"] = getnoofstudent(dt1, "batchcode='" + drs["batchcode"] + "'", "noofstudent");
            dr["status"] = drs["status"];
            dr["Content"] = getfaccontent(dtcomplete, "batchcode='" + drs["batchcode"] + "' and facultyid='" + drs["facultyid"] + "'", Convert.ToInt32(drs["noofclass"]));
            dr["Content1"] = getfaccontent1(dtcomplete, "batchcode='" + drs["batchcode"] + "' and facultyid='" + drs["facultyid"] + "'", Convert.ToInt32(drs["noofclass"]));
           
            reportfac.Rows.Add(dr);

        }
        if (reportfac.Rows.Count > 0)
        {
            lnkdownload.Visible = true;
            GridView1.DataSource = reportfac;
            GridView1.DataBind();
            lbl_error.Text = "";
        }
        else
        {
            lbl_error.Text = "No Record Found";
        }

    
    }

    public void ExportTableData(DataTable dtdata)
    {
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

//        System.Web.UI.Control ctl = this.GridView1;
////DataGrid1 (you created in the windowForm)
//HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=Excel.xls");
//HttpContext.Current.Response.Charset ="UTF-8";     
//HttpContext.Current.Response.ContentEncoding =System.Text.Encoding.Default;
//HttpContext.Current.Response.ContentType ="application/ms-excel";
//ctl.Page.EnableViewState =false;    
//System.IO.StringWriter  tw = new System.IO.StringWriter() ;
//System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter (tw);
//ctl.RenderControl(hw);
//HttpContext.Current.Response.Write(tw.ToString());
//HttpContext.Current.Response.End(); 

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Faculty-Report-Of-" + Session["SA_Location"] + "-center-between-" + txtfromdate.Text + "-and-" + txttodate.Text + ".xls");
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;
        
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                if (dc.ColumnName != "Content")
                {
                    Response.Write(dc.ColumnName + "\t");
                }
               
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count-1; i++)
                {
                    Response.Write(( dr[i].ToString()) + "\t");


                }
                Response.Write("\n");
            }
            Response.End();
        }
    }

    string getfaccontent(DataTable dtexp, string expression,int column)
    {
        string res = "";
        int completed = 0;
        int noofclass = column;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            completed = dr.Length;
            foreach (DataRow val in dr)
            {
                res = "<span style='color:green; font-weight:bold;'>" + completed + "</span>" + "/" + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Class Not start";
        }

        return res.ToString();
    }
    string getfaccontent1(DataTable dtexp, string expression, int column)
    {
        string res = "";
        int completed = 0;
        int noofclass = column;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            completed = dr.Length;
            foreach (DataRow val in dr)
            {
                res = "'"+completed + "" + "/" + noofclass;
            }

        }
        else
        {
            res = "Class Not start";
        }

        return res.ToString();
    }

    string getcontentstatus(DataTable dtexp, string expression)
    {
        string res = "";
        int pending = 0;
        int noofclass = 0;

        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                pending = (Convert.ToInt32(val["pending"]));
                noofclass = (Convert.ToInt32(val["noofclass"]));
                pending = noofclass - pending;
                res = "<span style='color:green; font-weight:bold;'>" + pending + "</span>" + "/" + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Batch Not Schedule";
        }

        return res.ToString();
    }

    string getnoofstudent(DataTable dtexp, string expression, string column)
    {
        string count = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (count == "")
                {
                    count = (val[column].ToString());
                }
              }
        }
        return count.ToString();

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        fillgrid(); 
    }
    private void display_facultyddl()
    {
        qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        ddl_fac.DataSource = dt;
        ddl_fac.DataValueField = "faculty_id";
        ddl_fac.DataTextField = "facultyname";
        ddl_fac.DataBind();
        ddl_fac.Items.Insert(0, new ListItem("All", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(reportfac);
    }
}
