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

public partial class Onlinestudents2_superadmin_home : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();

       
    }

    private void fillgrid()
    {
        _Qry = @"select distinct sce.batchcode,sce.studentid,sce.Software_id from erp_batchcontentstatus sts inner join erp_batchschedule sce
on sce.batchcode=sts.batchcode where module_id='" + Request.QueryString["moduleid"].ToString() + "' and sce.software_id='" + Request.QueryString["softwareid"].ToString() + "' and studentid='" + Request.QueryString["studentid"].ToString() + "'";
       // Response.Write(_Qry);
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt1.Rows.Count > 0)
        {
            
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            
        }
        else
        {
            error.Text = "Batch Not Schedule...!";
        }
    }


  
   
}
