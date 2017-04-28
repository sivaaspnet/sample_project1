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
using System.IO;
using System.Text;

public partial class ImageTraining_2_Onlinestudents2_superadmin_Popup10 : System.Web.UI.Page
{
    string _Qry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            date.Text = DateTime.Now.ToString("dd/MM/yyyy");
           fillfaculty();
        }
    }

    public void fillfaculty()
    {
        _Qry = "select * from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"].ToString() + "'";

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_faculty.DataSource = dt;
        ddl_faculty.DataTextField = "FacultyName";
        ddl_faculty.DataValueField = "Faculty_ID";
        ddl_faculty.DataBind();
        ddl_faculty.Items.Insert(0, new ListItem("All", ""));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {



        _Qry = "insert into erp_compensatedetails(Faculty_Id,student_id,compensate_date,centrecode,timing,action,reason,batchcode,content_id,module_id,software_id,dateins)values('" + ddl_faculty.SelectedValue + "','" + Request.QueryString["stuid"] + "','" + date.Text.ToString() + "','" + Session["SA_centre_code"].ToString() + "','" + ddl_batchtime.SelectedValue + "','" + ddl_status.SelectedValue + "','" + reason.Text + "','" + Request.QueryString["batchcode"] + "','" + Request.QueryString["content"] + "','" + Request.QueryString["module"] + "','" + Request.QueryString["software"] + "','" + date.Text.ToString() + "')";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);


        _Qry = "update erp_batchschedule set status ='Completed',pendingstatus='Compensated'  where studentid='" + Request.QueryString["stuid"] + "' and moduleid='" + Request.QueryString["module"] + "' and subContentId='" + Request.QueryString["content"] + "' and batchcode='" + Request.QueryString["batchcode"] + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        Response.Write("<script>window.parent.location.href = 'compensationbatch.aspx'</script>");
    }
}
