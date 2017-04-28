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

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("breakageinvoice.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("breakageview.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("finereceipt.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("fineview.aspx");
    }
}
