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

public partial class Onlinestudents2_superadmin_EnquiryType : System.Web.UI.Page
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
        Response.Redirect("AddEnquiry.aspx");
    }
    protected void btnviewdetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeleEnquiry.aspx");
    }
}
