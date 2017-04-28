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

public partial class Onlinestudents2_Default : System.Web.UI.Page
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
            
                expressupdate();
            
        }
    }
    private void expressupdate()
    {
        _Qry = "select a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,b.enq_number,isnull(a.student_lastname,'.*.') as ExpressEnrollSt from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where a.Admission_id>0  and isnull(a.student_lastname,'.*.')='.*.'";


        if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
        {
            _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
        }
        _Qry = _Qry + " Order by a.Admission_id desc";
        // _Qry = _Qry + " Order by a.Admission_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
       // lbl_count.Text = dt.Rows.Count.ToString();
        if (dt.Rows.Count > 0)
        {
            if (Session["SA_Centrerole"] .ToString() == "Counselor")
            {

                Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert('Please..Your are recommended to update the quick Enrolled Student details..');</script>");
            }
        }
      



    }
    
}
