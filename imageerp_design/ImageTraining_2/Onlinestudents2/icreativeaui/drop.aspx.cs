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

public partial class Onlinestudents2_superadmin_StudentReport : System.Web.UI.Page
{
    string _Qry, _qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
           // fillgrid();
           // Fillsearchmodule();
        }
    }
    


   
    private void fillgrid()
    {
        _Qry = @"select distinct student_id,enq_personal_name from adm_personalparticulars where student_id='" + txt_studentid.Text + "' and centre_code='" + Session["SA_centre_code"] + "' and  studentstatus='active'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            Response.Redirect("dropdetail.aspx?StudentID=" + txt_studentid.Text + "");
        }
        else
        {
            lbl_error.Text = "No Records Available";
        }


        //GridView1.DataSource = dt;
        //GridView1.DataBind();

       
    }
  
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
