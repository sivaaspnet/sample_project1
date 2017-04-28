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

public partial class superadmin_Viewstudentpersonaldetails : System.Web.UI.Page
{
    string _Qry,_Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        fillgrid();
       
    }

    public void fillgrid()
    {
        _Qry = @"select student_id,communication,clarify,extra_assignments,feedback_assignments,
pace_class,interaction,examples,time,confidence_level,overall,suggestion from student_feedback 
where student_id='" + Request.QueryString["stuid"].ToString() + "' and batchcode='" + Request.QueryString["batch"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
  
   
           
        }
    

