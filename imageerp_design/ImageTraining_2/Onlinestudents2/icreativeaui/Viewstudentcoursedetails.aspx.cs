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

public partial class superadmin_Viewstudentcoursedetails : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        stu_coursedet();
        stu_feedet();
    }
    private void stu_coursedet()
    {
        //_Qry = "select a.program,gen.track1 from [Ipad_centre_coursefee_details] a inner join adm_generalinfo gen on gen.coursename=a.Program where gen.student_id='" + Request.QueryString["stuid"] + "'";
        _Qry = "select a.coursename,a.program,gen.track from img_coursedetails a inner join adm_generalinfo gen on gen.coursename=a.course_id where gen.student_id='" + Request.QueryString["stuid"] + "'";
        // _Qry = "select gen.coursename,fee.program,fee.track from adm_generalinfo gen JOIN img_centre_coursefee_details fee on gen.centre_code=fee.centre_code where student_id='"+Request.QueryString["stuid"]+"'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lblcourse_program.Text = dt.Rows[0]["program"].ToString();
            lblcourse_name.Text = dt.Rows[0]["program"].ToString();
            lblcourse_track.Text = dt.Rows[0]["track"].ToString();
        }
    }
    private void stu_feedet()
    {
        //_Qry = "select gen.payment_pattern,gen.payment_coursefee,gen.payment_installments,gen.payment_noofinstall,fee.tax from adm_generalinfo gen JOIN img_centre_coursefee_details fee on gen.centre_code=fee.centre_code where student_id='" + Request.QueryString["stuid"] + "'";
        _Qry = "select gen.payment_pattern,gen.payment_coursefee,gen.payment_installments,gen.payment_noofinstall,'12.36' as tax from adm_generalinfo as gen where student_id='" + Request.QueryString["stuid"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lblfee_mode.Text = dt.Rows[0]["payment_pattern"].ToString();
            lblfee_installment.Text = dt.Rows[0]["payment_noofinstall"].ToString();
            if (dt.Rows[0]["payment_noofinstall"].ToString() == "" || dt.Rows[0]["payment_noofinstall"].ToString()==null)
            {
                lblfee_installment.Text = "0";
            }
            else
            {
                lblfee_installment.Text = dt.Rows[0]["payment_noofinstall"].ToString();
            }
            lblfee_amount.Text = dt.Rows[0]["payment_coursefee"].ToString();
            lblfee_tax.Text = dt.Rows[0]["tax"].ToString();
            double fee = Convert.ToDouble(lblfee_amount.Text);
            double tx = fee * (12.36 / 100);
            double totfeetx = fee + tx;
            lblfee_Total.Text = Convert.ToString(totfeetx);
        }

    }
}
