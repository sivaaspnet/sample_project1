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

public partial class Onlinestudents2_superadmin_WrongEntry : System.Web.UI.Page
{
    string _Qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["offline"] == "yes")
        {
           
            lblofflinemessage.Visible = true;
            
            lblpagerestrictionmessage.Visible = false;
            lblunauthroziedmessage.Visible = false;


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
        else if (Request.QueryString["unauthorized"] == "yes")
        {
            lblofflinemessage.Visible = false;

            lblpagerestrictionmessage.Visible = false;
            lblunauthroziedmessage.Visible = true;

        }
        else if (Request.QueryString["PageRestrict"] == "yes")
        {
            lblofflinemessage.Visible = false;

            lblpagerestrictionmessage.Visible = true;
            lblunauthroziedmessage.Visible = false  ;
        }
    }
}
