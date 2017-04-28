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

public partial class ImageTraining_2_Onlinestudents2_superadmin_offline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _Qry;

        if (Request.QueryString["offline"] == "yes")
        {

            _Qry = "select Message from ERP_SiteStatus where centre_code='" + Session["SA_centre_code"] + "' and Status='0'";


            //Response.Write(_Qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lblofflinemessage.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Message"].ToString());


            }
        }
    }
}
