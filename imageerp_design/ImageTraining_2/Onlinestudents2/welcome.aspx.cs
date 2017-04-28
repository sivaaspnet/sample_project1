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

public partial class Onlinestudents2_Default : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillfeedback();
        }
      
    }

    public void fillfeedback()
    {
        _Qry = "select Batch_Code from Feedback_request where Student_id='" + Session["Student_Id"].ToString() + "' and Status='Pending'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            feedback.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    
    
}
