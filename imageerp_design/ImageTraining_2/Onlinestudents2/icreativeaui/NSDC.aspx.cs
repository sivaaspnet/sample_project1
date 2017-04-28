using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class NSDC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //non nsdc centers:IHY-101,IKN-101,IVR-101,IMY-101,ICH-107
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        //string centreID = "ICH-101";
         string centreID = Session["centre_code"].ToString();       
     
    Response.Redirect("imageNSDC.aspx?centreID=" + centreID);
    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        //string centreID = "ICH-101";
         string centreID = Session["centre_code"].ToString();       
     
        Response.Redirect("NSDC_candidatelist.aspx?centreID=" + centreID);
    }

}
