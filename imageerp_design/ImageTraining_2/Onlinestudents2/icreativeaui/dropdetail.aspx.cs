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

            if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
            {
                Button1.Visible = true;
                Button3.Visible = false;
            }
            else if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
            {
                Button1.Visible = false;
                Button3.Visible = true;
                ddl_reason.Visible = false;
                txt_reason.ReadOnly = true;
                drop1();
             }
        }
    }
    


   
    private void fillgrid()
    {
        _Qry = @"select distinct student_id,enq_personal_name from adm_personalparticulars where student_id='" + Request.QueryString["StudentID"].ToString() + "' and centre_code='" + Session["SA_centre_code"] + "' and studentstatus='active'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
          
             _Qry = "insert into erp_studentdrop (studentid,reason,requesteddate,status,centercode) values('" + Request.QueryString["StudentID"].ToString() + "','" + TextBox1.Text + "'+'" + txt_reason.Text + "',getdate(),'Requested','" + Session["SA_centre_code"] + "')";
             MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
             lbl_error.Text = "Request Sent Successfully ";
        }
        else
        {
            lbl_error.Text = "No Records Available";
        }

    }
  
    
  
    protected void Button1_Click1(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
        {
            _Qry = "update erp_studentdrop set droppeddate=getdate(),status='Declined' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            lbl_error.Text = "you have declined it....!";
        }
        else
        {
            Response.Redirect("drop.aspx");
        }
    }
    protected void ddl_reason_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = ddl_reason.SelectedValue.ToString();
        if(ddl_reason.SelectedValue=="Others")
        {
            TextBox1.Text = "";
            TextBox1.Visible = true;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        drop();
    }

    private void drop()
    {
        
        _Qry = "select * from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_reason.Text = dt.Rows[0]["reason"].ToString();

            _Qry = "update adm_personalparticulars set studentstatus='Dropped',remarks='" + txt_reason.Text + "' where student_id='" + Request.QueryString["StudentID"].ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "update erp_batchschedule set remarks= 'Student Dropped - '+'" + txt_reason.Text + "' ,batchstatus='Dropped' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centrecode='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "update erp_studentdrop set droppeddate=getdate(),status='Dropped' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            lbl_error.Text = "Student Successfully Dropped From ERP System";
        }
        else
        {
            lbl_error.Text = "You can't drop student without getting request";

        }
    }
    private void drop1()
    {
        _Qry = "select * from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_reason.Text = dt.Rows[0]["reason"].ToString();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentReportDetails.aspx?StudentID=" + Request.QueryString["StudentID"].ToString() + "");
    }
}
