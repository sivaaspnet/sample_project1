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
    string qry,qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            centercode();
            program();
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        qry = "insert into img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,dateins) values('"+ddl_center.SelectedValue+"','"+ddl_program.SelectedValue+"','"+txt_normalduration.Text+"','Normal','"+txt_normallump.Text+"','"+txt_normalins.Text+"','"+txt_tax.Text+"','"+DateTime.Now+"')";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,qry);
        qry1 = "insert into img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,dateins) values('" + ddl_center.SelectedValue + "','" + ddl_program.SelectedValue + "','" + txt_fastduration.Text + "','Fast','" + txt_fastlump.Text + "','" + txt_fastins.Text + "','" + txt_tax.Text + "','" + DateTime.Now + "')";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry1);
        Label1.Text = "inserted";
    }
    private void centercode()
    {
        qry = "select centre_code,centre_location from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, qry);
        ddl_center.DataSource = dt;
        ddl_center.DataValueField = "centre_code";
        ddl_center.DataTextField = "centre_location";
        ddl_center.DataBind();
        ddl_center.Items.Insert(0, new ListItem("Select", ""));

    }
    private void program()
    {
        qry = "select course_id,program from img_coursedetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, qry);
        ddl_program.DataSource = dt;
        ddl_program.DataValueField = "course_id";
        ddl_program.DataTextField = "program";
        ddl_program.DataBind();
        ddl_program.Items.Insert(0, new ListItem("Select", ""));
        

    }
}
