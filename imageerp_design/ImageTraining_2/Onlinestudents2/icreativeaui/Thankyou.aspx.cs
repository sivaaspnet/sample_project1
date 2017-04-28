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

public partial class Onlinestudents2_superadmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

    }

    protected void btnenquiry_Click(object sender, EventArgs e)
    {
        Session["ENQ_ID"] = "";
        Session["Enqno"] = "";
        Response.Redirect("AddEnquiry.aspx");
       

    }
    protected void btnviewdetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEnquiry.aspx");
    }
    protected void btnregistration_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["enqno"] != null)
        {
            Response.Redirect("quickadmission.aspx?enqno=" + Request.QueryString["enqno"].ToString() + "#tabs-6");
        }
        else
        {
            Response.Redirect("quickadmission.aspx#tabs-6");
        }
        Response.Redirect("quickadmission.aspx#tabs-6");
    }
    protected void btnerollment_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["enqno"] != null)
        {
            Response.Redirect("quickadmission.aspx?enqno=" + Request.QueryString["enqno"].ToString() + "#tabs-6");
        }
        else
        {
            Response.Redirect("quickadmission.aspx#tabs-5");
        }
    }
}
