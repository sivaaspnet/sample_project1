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
using System.Data.SqlClient;
using System.Globalization;

public partial class superadmin_ViewbatchDetails : System.Web.UI.Page
{
    string _Qry;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldrop();
            fillgrid();
        }
       
       
    }

    public void fillgrid()
    {
        _Qry = "select a.studentId,a.subContentId,a.batchcode,b.enq_personal_name,c.Content,a.moduleid,c.Module,d.Software_Name,d.Software_Id from erp_batchschedule a inner join adm_personalparticulars b on a.studentId=b.student_id inner join Submodule_details_new c on c.Submodule_id=a.subContentId inner join Onlinestudent_Software d on d.Software_Id=a.Software_id  Where a.status !='Completed' and a.batchstatus='active' and b.studentstatus='active' and a.classDate<=getdate() and a.centrecode='" + Session["SA_centre_code"].ToString() + "'";
        if (stuid.Text != "")
        {
            _Qry += " and a.studentId = '" + stuid.Text.ToString() + "'";
        }
        if (ddl_module.SelectedValue != "")
        {
            _Qry += " and a.moduleid = '" + ddl_module.SelectedValue.ToString() + "'";
        }

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    public void filldrop()
    {
        _Qry = "select * from module_details";

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_module.DataSource = dt;
        ddl_module.DataTextField = "module_content";
        ddl_module.DataValueField = "module_Id";
        ddl_module.DataBind();
        ddl_module.Items.Insert(0, new ListItem("All", ""));
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
