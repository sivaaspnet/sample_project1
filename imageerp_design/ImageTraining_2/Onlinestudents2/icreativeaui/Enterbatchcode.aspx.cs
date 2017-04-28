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

public partial class superadmin_Enterbatchcode : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            dispaly_batchcode();
        }
    }
  
    private void dispaly_batchcode()
    {
        //select batch_code from view_batch where center_code=1 group by batch_code
        _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' And Batch_Status='Inprogress' group by batch_code";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_batchcode.DataSource = dt;
        ddl_batchcode.DataValueField = "batch_code";
        ddl_batchcode.DataTextField = "batch_code";
        ddl_batchcode.DataBind();
        ddl_batchcode.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Viewbatch.aspx?batchcode=" + ddl_batchcode.SelectedValue + "");
   

    }
}
