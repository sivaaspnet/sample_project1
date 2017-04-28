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

public partial class superadmin_AttendancePost : System.Web.UI.Page
{
    string _Qry;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Student_Id"] == null || Session["Student_Id"] == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (Request.QueryString["post"] == "succ")
        {

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
