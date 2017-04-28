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
        if (Session["SA_centre_code"] != null)
        {
            _Qry = @"select distinct student_id,enq_personal_name from adm_personalparticulars where  centre_code='" + Session["SA_centre_code"].ToString() + "' and student_id='" + txt_studentid.Text + "' or enq_personal_name='" + txt_studentid.Text + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {

                HiddenField1.Value = dt.Rows[0]["student_id"].ToString();
                Response.Redirect("StudentReportDetails.aspx?StudentID=" + HiddenField1.Value + "");
            }
            else
            {
                lbl_error.Text = "No Records Available";
            }

        }
        //GridView1.DataSource = dt;
        //GridView1.DataBind();

       
    }
  
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_studentid.Text);
    }
}
