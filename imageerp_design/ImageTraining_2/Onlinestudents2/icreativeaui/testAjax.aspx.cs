using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ImageTraining_2_Onlinestudents2_superadmin_testAjax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();

    }
    private void fillgrid()
    {
        string _Qry = "select batchcode from erp_batchdetails where centrecode='ich-101'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ASPxGridView1.DataSource = dt;
        ASPxGridView1.DataBind();
    }
}
