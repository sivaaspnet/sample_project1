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

public partial class ImageTraining_2_Onlinestudents2_superadmin_batchrep : System.Web.UI.Page
{
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }

    }
    private void fillgrid()
    {
        qry = @"
select distinct sub.submodule_id,module,[content],batchcode,status from erp_batchcontentstatus sts inner join 
Submodule_details_new sub on sts.subcontent_id=sub.submodule_id inner join 
module_details mod on sts.module_id=mod.module_id
where batchcode='" + Request.QueryString["batchcode"] + "' order by sub.submodule_id asc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);

        if(dt.Rows.Count>0)
        {
            lbl_batch.Text = dt.Rows[0]["batchcode"].ToString();
            lbl_module.Text = dt.Rows[0]["module"].ToString();
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();

    }
}
