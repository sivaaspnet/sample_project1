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

public partial class superadmin_updatepreviousattendance : System.Web.UI.Page
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
            fillabsentstudents();
        }
    }
    private void fillabsentstudents()
    {
        _Qry = @" select enq_personal_name,att.software_name,bd.batchcode,bc.module_id,bc.subcontent_id,convert(varchar,bc.classdate,103) as clsdate,bc.software_id,bs.batchtiming,bs.studentid,att.attendance_id,att.class_content 
            from erp_batchcontentstatus bc inner join erp_batchdetails bd on bd.batchcode=bc.batchcode and bd.centrecode='" + Session["SA_centre_code"] + @"' and bc.status='completed'
            inner join erp_batchschedule bs on bs.batchcode=bc.batchcode and bc.subcontent_id=bs.subcontentid and bs.status='pending' inner join adm_personalparticulars per on per.student_id=bs.studentid 
            left join onlinestudent_attendance att on att.batch_code=bd.batchcode and bs.studentid=att.student_id and att.content_id=bs.subcontentid and attendance_status='Absent' and (student_reason is null or student_reason='')
            where bd.batchcode='" +Request.QueryString["batchcode"]+"' and bs.status='pending' and bc.status='completed' and attendance_status='Absent' and (student_reason is null or student_reason='')";
        DataTable dtgetstudents = new DataTable();
        dtgetstudents= MVC.DataAccess.ExecuteDataTable(_Qry);
        gvclasscontent.DataSource = dtgetstudents;
        gvclasscontent.DataBind();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvclasscontent.Rows)
        {
            HiddenField hdnattendanceid = (HiddenField)gr.FindControl("hdnattendanceid");
            TextBox txtreason = (TextBox)gr.FindControl("txtreason");
            if (txtreason.Text.Trim() != "")
            {
                _Qry = " update onlinestudent_attendance set student_reason='"+MVC.CommonFunction.ReplaceQuoteWithTild(txtreason.Text)+"' where attendance_id="+hdnattendanceid.Value+"";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
        }
        fillabsentstudents();
    }
}
