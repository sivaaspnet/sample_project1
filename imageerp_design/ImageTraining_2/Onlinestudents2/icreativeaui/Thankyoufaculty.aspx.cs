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

public partial class superadmin_Thankyoufaculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnadmission_Click(object sender, EventArgs e)
    {

        Response.Redirect("addfaculty.aspx");
    }
    protected void btnviewdetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("Viewfacultydetails.aspx");
      
    }
   
}
