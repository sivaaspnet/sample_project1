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

public partial class ImageTraining_2_Onlinestudents2_superadmin_Feedback_view : System.Web.UI.Page
{
    string _Qry = "";
    DataTable status = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

     
        if (!IsPostBack)
        {
            fillgrid();
        }
    }

    private void fillgrid()
    {
        _Qry = @"select distinct bat.batchcode,max(mod.module_content) as module_content,bat.slot,bat.batchtiming,max(facultyname) as facultyname,(select count (distinct student_id)  from feedback_request where batch_code=bat.batchcode)  as totalstudents,(select count (distinct student_id)  from feedback_request where batch_code=bat.batchcode and status='Completed')  as completed from
 erp_batchdetails bat inner join module_details mod on moduleid=module_id inner join 
erp_batchschedule sce on sce.batchcode=bat.batchcode inner join 
online_students_labavail lab on lab.labid=sce.labid inner join 
erp_batchcontentstatus sts on sts.batchcode=bat.batchcode  inner join
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid  inner join feedback_request fr on  bat.batchcode=fr.batch_code
 where  bat.centrecode='" + Session["SA_centre_code"].ToString() + "' ";
        _Qry += "  group by bat.batchcode,bat.batchtiming,bat.slot";
        //Response.Write(_Qry);
        //Response.End();


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();


      


    } 
}
