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
        //if (!IsPostBack)
        //{
            fillgrid();
           // Fillsearchmodule();
        //}
    }
    


   
    private void fillgrid()
    {
        _Qry = @"select  student_id,enq_personal_name,remarks from adm_personalparticulars where  centre_code='" + Session["SA_centre_code"] + "' and studentstatus='dropped'"; 
if(txt_studentid.Text!="")
{
 _Qry+= " and student_id='" + txt_studentid.Text + "' ";
}

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //_Qry = "select student_id,enq_personal_name,studentstatus from adm_personalparticulars where centre_code='" + Session["SA_centre_code"] + "' and studentstatus='dropped'";
            //_Qry = "update adm_personalparticulars set studentstatus='active' where student_id='" + txt_studentid.Text + "' and centre_code='" + Session["SA_centre_code"] + "'";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //lbl_error.Text = "Student Successfully Resumed";
            //txt_studentid.Text = "";
        //}
        //else
        //{
        //    //lbl_error.Text = "No Records Available";
        //}


        //GridView1.DataSource = dt;
        //GridView1.DataBind();

       
    }
  
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if( e.CommandName=="lnkedit")
        {
            _Qry = "update adm_personalparticulars set studentstatus='active' where student_id='" + e.CommandArgument.ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //_Qry = "update erp_batchschedule set batchstatus='active' where studentid='" + e.CommandArgument.ToString() + "' and centrecode='" + Session["SA_centre_code"] + "'";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lbl_error.Text = "Student Successfully Resumed";
           

        }
    }
}
