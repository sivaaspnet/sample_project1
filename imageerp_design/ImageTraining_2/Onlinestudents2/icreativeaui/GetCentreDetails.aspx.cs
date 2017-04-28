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

public partial class Onlinestudents2_superadmin_GetCentreDetails : System.Web.UI.Page
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
            lblerrmsg.Text = "Please select the centre to view details";
            //fillcentre();
        }
    }

    private void fillcentre()
    {
        _Qry = "Select Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_Centre.DataSource = dt;
        ddl_Centre.DataTextField = "Centre_location";
        ddl_Centre.DataValueField = "Centre_Code";
        ddl_Centre.DataBind();
        ddl_Centre.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddl_Centre.SelectedValue == "")
        {
            lblerrmsg.Text = "Please select centre location";
        }
        else
        {
            Session["SA_centre_code"] = ddl_Centre.SelectedValue.ToString();
            lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
        }
    }
}
