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
public partial class ImageTraining_2_Onlinestudents2_icreative_studentStatus : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _Qry = "select ic.program,ei.student_enrolledStatus,ei.student_enrolledStatus_remarks from erp_invoiceDetails ei inner join img_coursedetails ic on ei.courseId=ic.course_id where ei.studentId='" + Request.QueryString["enrollno"] + "' and ei.invoiceId='" + Request.QueryString["invoiceid"] + "'";
            SqlDataReader dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            dr.Read();
            if (dr.HasRows)
            {
                lblcourse_name.Text = dr["program"].ToString();
                ddlstatus.SelectedValue = dr["student_enrolledStatus"].ToString();
                txtremarks.Text = dr["student_enrolledStatus_remarks"].ToString();
            }
            dr.Close();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        _Qry = "update erp_invoiceDetails set student_enrolledStatus='" + ddlstatus.SelectedValue + "',student_enrolledStatus_remarks='" + txtremarks.Text + "' where studentId='" + Request.QueryString["enrollno"] + "' and invoiceId='" + Request.QueryString["invoiceid"] + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //Response.Write("<script>window.parent.location.href = 'ViewAdmission.aspx'</script>");
        lblmsg.Text = "Status Updated";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.parent.location.href = 'ViewAdmission.aspx'</script>");
    
    }
}
