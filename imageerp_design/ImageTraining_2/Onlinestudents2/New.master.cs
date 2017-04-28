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

public partial class Onlinestudents2_New : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["userID"] = "";
        Session["username"] = "";
        Session["Centrerole"] = "";
        Session["centre_code"] = "";
        Session["centre_region"] = "";
        Session["centre_loginstatus"] = "";
        Session["ENQ_ID"] = "";
        Session["Enqno"] = "";
        Response.Redirect("Login.aspx");
    }
}
