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

public partial class superadmin_Enterbatchcode : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Student_Id"] == null || Session["Student_Id"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            dispaly_batchcode();
        }
    }
  
    private void dispaly_batchcode()
    {
        //select batch_code from view_batch where center_code=1 group by batch_code
       // _Qry = "select batch_code from batch_details where batch_Studentid='" + Session["Student_Id"] + "' And Batch_Status='Inprogress' And getdate() >= Batch_Startdate group by batch_code";
        _Qry = @"select sce.batchcode from erp_batchschedule sce inner join erp_batchcontentstatus  sts on 
sts.batchcode=sce.batchcode 
where studentid='" + Session["Student_Id"] + "' and sce.status='pending' and sts.batchstatus='active' group by sce.batchcode";
      //  _Qry = "select batchcode from erp_batchschedule where studentid='" + Session["Student_Id"] + "' and status='pending' and batchstatus='active' group by batchcode ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_batchcode.DataSource = dt;
        ddl_batchcode.DataValueField = "batchcode";
        ddl_batchcode.DataTextField = "batchcode";
        ddl_batchcode.DataBind();
        ddl_batchcode.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("attendance.aspx?batchcode=" + ddl_batchcode.SelectedValue + "");

    }
}
