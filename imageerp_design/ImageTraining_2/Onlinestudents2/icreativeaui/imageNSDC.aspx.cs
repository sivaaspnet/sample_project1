using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

public partial class imageNSDC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["centreID"] == "")
              Response.Redirect("NSDC.aspx");
        else
        {
            if (!IsPostBack)
                gridfill();
        }
       
          
    }
    protected void btnexcel_click(object sender, EventArgs e)
    {
       
    }
    protected void gridfill()
    {
        // string centreID = Request.QueryString["centreID"];
        string centreID = Session["centre_code"].ToString();       
     
        hf_centreID.Value = centreID;
       // string query = "select  a1.centre_code,a1.student_id,a1.enq_personal_name,i1.coursename FROM erp_invoiceDetails,adm_personalparticulars a1,adm_generalinfo a2,img_coursedetails i1 where a1.student_id=a2.student_id AND a2.coursename=i1.course_id AND a1.centre_code='" + centreID + "'";
        DataTable dt = nsdc.DataAccess.ExecuteDataTable(" select erp_i.dateIns, erp_i.centerCode,erp_i.studentId,a1.enq_personal_name,i1.coursename FROM erp_invoiceDetails erp_i,adm_personalparticulars a1,img_coursedetails i1 where erp_i.studentId=a1.student_id AND erp_i.courseId=i1.course_id AND erp_i.centerCode='" + centreID + "' AND erp_i.dateIns>= Convert(datetime, '2015-05-01' )");
        gd_candidates.DataSource = dt;
        gd_candidates.DataBind();
        
    }
   
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label centername = (e.Row.FindControl("lblcenter") as Label);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int check = nsdc.DataAccess.ExecuteScalar_int("select count(*) from NSDC_registration_details where enrollment_no='" + DataBinder.Eval(e.Row.DataItem, "studentId").ToString() + "'");
       
            if (check!=0)
            {
                e.Row.Cells[3].Text = "NSDC Completed";
            }
            else
            {
                e.Row.Cells[3].Text = "";
                HyperLink link = new HyperLink();
                link.Text = "NSDC REGISTRATION";
                link.NavigateUrl = "NSDC_registration.aspx?id=insert&student_id=" + DataBinder.Eval(e.Row.DataItem, "studentId").ToString() + "&centreID=" + hf_centreID.Value;
                e.Row.Cells[3].Controls.Add(link);

            }
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gd_candidates.PageIndex = e.NewPageIndex;
        gridfill();

    }
}
