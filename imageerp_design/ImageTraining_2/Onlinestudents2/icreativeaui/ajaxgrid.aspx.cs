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

public partial class ImageTraining_2_Onlinestudents2_superadmin_ajaxgrid : System.Web.UI.Page
{
    string _Qry;
    DataTable status = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        test();

    }

    private void test()
    {
        _Qry = "select batchcode from erp_batchdetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        

    }

    private void fillgrid()
    {
        //        _Qry = @"select  distinct bat.batchcode,mod.module_content,bat.slot,bat.batchtiming,bat.status ,sce.labid,sce.facultyid,lab.labname,facultyname,
        //(select  CONVERT(VARCHAR(10),min( classDate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
        //(select  CONVERT(VARCHAR(10),max( classDate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate
        // from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
        //on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
        //onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid 
        _Qry = @"select  distinct bat.batchid,bat.batchcode,bat.status,max(mod.module_content) as module_content,bat.slot,bat.batchtiming,max(bat.status) as status ,sce.labid,sce.facultyid,
max(lab.labname) as labname,max(facultyname) as facultyname, CONVERT(VARCHAR(10),min( sts.scheduledate ),103) as Startdate,
CONVERT(VARCHAR(10),max( sts.classDate ),103) as Enddate  from
 erp_batchdetails bat inner join module_details mod on moduleid=module_id inner join 
erp_batchschedule sce on sce.batchcode=bat.batchcode inner join 
online_students_labavail lab on lab.labid=sce.labid inner join 
erp_batchcontentstatus sts on sts.batchcode=bat.batchcode  inner join
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid where bat.centrecode='ICH-101' ";


        _Qry += "  group by bat.batchcode,sce.facultyid,sce.labid,bat.batchtiming,bat.slot,bat.status,bat.batchid  order by bat.batchid desc";
        //Response.Write(_Qry);
        //Response.End();


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);



        GridView1.DataSource = dt;
        GridView1.DataBind();
        

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
     
        fillgrid();
    }
    
    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        
    }
}
