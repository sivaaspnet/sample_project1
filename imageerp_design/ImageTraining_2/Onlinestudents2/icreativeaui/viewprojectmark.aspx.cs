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

public partial class ImageTraining_2_Onlinestudents2_superadmin_viewprojectmark : System.Web.UI.Page
{
    string Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        filltable();

    }

    private void filltable()
    {
        Qry = @"SELECT DISTINCT 
                      dbo.erp_studentprogress.Status,dbo.erp_studentprogress.projectid, dbo.Submodule_details_new.Module, dbo.adm_personalparticulars.enq_personal_name, 
                      dbo.erp_studentprogress.studentid, dbo.erp_studentprogress.projectguided_by, dbo.erp_studentprogress.centrecode, 
                      dbo.Submodule_details_new.ModuleId, dbo.projectdetails.projectname, CONVERT(varchar,dbo.erp_studentprogress.Senddate,103) AS Senddate, 
                      CONVERT(varchar, dbo.erp_studentprogress.Dispatchdate, 103) AS Dispatchdate, dbo.erp_studentprogress.Mark, 
                      dbo.erp_studentprogress.EvaluatedBy, CONVERT(varchar, dbo.erp_studentprogress.EvaluatedDate, 103) AS EvaluatedDate, 
                      dbo.erp_studentprogress.Remarks, dbo.erp_studentprogress.batchcode, dbo.erp_studentprogress.dateins
FROM         dbo.Submodule_details_new INNER JOIN
                      dbo.erp_studentprogress ON dbo.Submodule_details_new.ModuleId = dbo.erp_studentprogress.moduleid INNER JOIN
                      dbo.adm_personalparticulars ON dbo.erp_studentprogress.studentid = dbo.adm_personalparticulars.student_id AND 
                      dbo.erp_studentprogress.centrecode = dbo.adm_personalparticulars.centre_code INNER JOIN
                      dbo.projectdetails ON dbo.erp_studentprogress.projectid = dbo.projectdetails.projectid where 1=1 and studentid='" + Request.QueryString["studentid"] + "' and dbo.erp_studentprogress.projectid='" + Request.QueryString["projectid"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(Qry);
        DataList1.DataSource = dt;
        DataList1.DataBind();

    }
}
