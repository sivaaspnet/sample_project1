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

public partial class superadmin_Attendancebatchcode : System.Web.UI.Page
{
    string _Qry;
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
       
        //if (Session["SA_Centrerole"] .ToString() == "Faculty")
        //{
         _Qry = "select distinct sch.batchcode from erp_batchschedule sch inner join erp_batchdetails det on sch.batchcode=det.batchcode and det.status='Completed'  and sch.centrecode=det.centrecode inner join erp_batchcontentstatus sts on sts.batchcode=sch.batchcode and sch.subcontentid=sts.subcontent_id  and sts.status='Completed' and sts.batchstatus='active' inner join onlinestudentsfacultydetails fac on fac.faculty_id=facultyid and sch.centrecode=fac.centre_code inner join img_centrelogin cl on cl.username=fac.facultyname  where sch.centrecode='" + Session["SA_centre_code"].ToString() + "' and cl.username='" + Session["SA_Username"] + "' ";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddl_batchcode.DataSource = dt;
            ddl_batchcode.DataValueField = "batchcode";
            ddl_batchcode.DataTextField = "batchcode";
            ddl_batchcode.DataBind();
            ddl_batchcode.Items.Insert(0, new ListItem("Select", ""));
      //  }
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        head.Visible = true;
        _Qry = @"select distinct count(distinct sce.studentid) as noofstudent,bat.noofclass,bat.batchcode,max(mod.module_content) as module_content,bat.slot,bat.batchtiming,max(bat.status) as status ,sce.labid,sce.facultyid,
max(lab.labname) as labname,max(facultyname) as facultyname, CONVERT(VARCHAR(10),min( sts.classDate ),103) as Startdate,
CONVERT(VARCHAR(10),max( sts.classDate ),103) as Enddate  from
 erp_batchdetails bat inner join module_details mod on moduleid=module_id inner join 
erp_batchschedule sce on sce.batchcode=bat.batchcode inner join 
online_students_labavail lab on lab.labid=sce.labid inner join 
erp_batchcontentstatus sts on sts.batchcode=bat.batchcode inner join
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid where bat.batchcode='"+ddl_batchcode.SelectedValue +"'group by bat.noofclass,bat.batchcode,sce.facultyid,sce.labid,bat.batchtiming,bat.slot  order by batchcode desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if(dt.Rows.Count>0)
        {
            lbl_noofclass.Text = dt.Rows[0]["noofclass"].ToString();
            lbl_noofstudent.Text = dt.Rows[0]["noofstudent"].ToString();
            lbl_start.Text = dt.Rows[0]["Startdate"].ToString();
            lbl_end.Text = dt.Rows[0]["Enddate"].ToString();
        }
        fillprogress();

    }
    private void fillprogress()
    {
        _Qry = @"select distinct studentid,enq_personal_name,admission_id from erp_batchschedule  inner join 
adm_personalparticulars on student_id =studentid  where batchcode='" + ddl_batchcode.SelectedValue + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);


        _Qry = "select count(*) as present,studentid,status from erp_batchschedule group by studentid,status";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);


        DataTable final = new DataTable();
        final.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("present", System.Type.GetType("System.String")));
        DataRow finalrow = final.NewRow();
        foreach (DataRow drs in dt.Rows)
        {
            finalrow = final.NewRow();
            finalrow["studentid"] = drs["studentid"];
            finalrow["name"] = drs["enq_personal_name"];
            finalrow["present"] = getpresent(dt1, " studentid='" + drs["studentid"].ToString() + "' and status='Completed'");
            final.Rows.Add(finalrow);
        }

        GridView1.DataSource = final;
        GridView1.DataBind();
    }
    string getpresent(DataTable dtexp, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = val["present"].ToString();
            }
        }
        
        return res.ToString();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "rate")
        {
                int index = Convert.ToInt32(e.CommandArgument);

               
                DropDownList rate_listening = new DropDownList();
                 rate_listening = (DropDownList)GridView1.Rows[index].FindControl("Listening");
                DropDownList rate_Tardiness = new DropDownList();
                rate_Tardiness = (DropDownList)GridView1.Rows[index].FindControl("Tardiness");
                DropDownList rate_UsingTimeWisely = new DropDownList();
                rate_UsingTimeWisely = (DropDownList)GridView1.Rows[index].FindControl("UsingTimeWisely");
                DropDownList rate_CompletingWork = new DropDownList();
                rate_CompletingWork = (DropDownList)GridView1.Rows[index].FindControl("CompletingWork");
                DropDownList rate_Conduct = new DropDownList();
                rate_Conduct = (DropDownList)GridView1.Rows[index].FindControl("Conduct");
                Label lbl = new Label();
                lbl = (Label)GridView1.Rows[index].FindControl("Label1");
                if (rate_listening.SelectedValue != "" && rate_Tardiness.SelectedValue != "" && rate_UsingTimeWisely.SelectedValue != "" && rate_CompletingWork.SelectedValue != "" && rate_Conduct.SelectedValue != "")
                {
                    //_Qry = "update erp_studentprogress set batchcode='" + ddl_batchcode.SelectedValue + "', rate_listening='" + rate_listening.SelectedValue + "',rate_Tardiness='" + rate_Tardiness.SelectedValue + "',rate_UsingTimeWisely='" + rate_UsingTimeWisely.SelectedValue + "',rate_CompletingWork='" + rate_CompletingWork.SelectedValue + "',rate_Conduct='" + rate_Conduct.SelectedValue + "' where student_id='" + lbl.Text + "'";
                    //showBox("Thanks For Rating");
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into erp_facultyfeedback (batchcode,studentid,centrecode,rate_listening,rate_Tardiness,rate_UsingTimeWisely,rate_CompletingWork,rate_Conduct)values ('" + ddl_batchcode.SelectedValue + "','" + lbl.Text + "','" + Session["SA_centre_code"].ToString() + "','" + rate_listening.SelectedValue + "','" + rate_Tardiness.SelectedValue + "','" + rate_UsingTimeWisely.SelectedValue + "','" + rate_CompletingWork.SelectedValue + "','" + rate_Conduct.SelectedValue + "')";
                    showBox("Thanks For Rating");
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                }
                else
                {
                    showBox("Please Select Rating..!");
                }
                      
        }
    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
}
