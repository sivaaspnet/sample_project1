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

public partial class Onlinestudents2_superadmin_Database : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
       // MVC.DataAccess.ERP_Ashok.AccessDenied();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        DataTable dt = MVC.DataAccess.ExecuteDataTable(TextBox1.Text);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label1.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, TextBox1.Text);
        if (count == 1)
        {
            Label1.Text = "Inserted/Updated Successfully";
        }
        else
        {
            Label1.Text = "Insertion/Updation Failed";
        }
    }
}
