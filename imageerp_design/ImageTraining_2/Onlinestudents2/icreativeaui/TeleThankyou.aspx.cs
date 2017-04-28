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

public partial class Onlinestudents2_superadmin_TeleThankyou : System.Web.UI.Page
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
        Response.Redirect("TeleEnquiry.aspx?p=N");
       

    }
    protected void btnviewdetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeleEnquiry.aspx");
    }
    protected void btnregistration_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["teleid"] != null)
        {
            Response.Redirect("quickadmission.aspx?teleid=" + Request.QueryString["teleid"].ToString() + "#tabs-6");
        }
        else
        {
            Response.Redirect("quickadmission.aspx#tabs-6");
        }
    }
    protected void btnerollment_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["teleid"] != null)
        {
            Response.Redirect("quickadmission.aspx?teleid=" + Request.QueryString["teleid"].ToString() + "#tabs-5");
        }
        else
        {
            Response.Redirect("quickadmission.aspx#tabs-5");
        }
    }
    protected void btnWalkin_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["teleid"] != null)
        {
            Response.Redirect("addenquiry.aspx?teleid=" + Request.QueryString["teleid"].ToString() + "");
        }
        else
        {
            Response.Redirect("addenquiry.aspx");
        }
    }
}
