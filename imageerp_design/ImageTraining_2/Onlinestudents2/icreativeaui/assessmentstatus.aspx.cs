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

public partial class ImageTraining_2_Onlinestudents2_superadmin_assessmentstatus : System.Web.UI.Page
{
    string _Qry, _Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            fillcentre();
        }
    }

    public void fillgrid()
    {
        _Qry = "select a.enq_personal_name,a.studentId,a.program,a.Module,a.batchCode,a.status,b.centre_location from view_assesment a inner join  img_centredetails b on a.centrecode=b.centre_code where a.status='Completed'";

        if (v.SelectedValue != "")
        {
            _Qry += " and a.centrecode='"+v.SelectedValue+"'";
        }
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
       
       
    }
    private void fillcentre()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        v.DataSource = dt;
        v.DataTextField = "Centre_location";
        v.DataValueField = "Centre_Code";
        v.DataBind();
        v.Items.Insert(0, new ListItem("Select", ""));
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
