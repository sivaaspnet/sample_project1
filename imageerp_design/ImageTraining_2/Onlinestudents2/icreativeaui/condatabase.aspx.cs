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


public partial class Onlinestudents2_superadmin_condatabase : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
      //SubMVC.ERP_Ashok.AccessDenied();
        //if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
        //}
        //else
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        string conn = ConfigurationManager.ConnectionStrings["Connect"].ToString();
        SqlConnection cn = new SqlConnection(conn);
        SqlDataAdapter da = new SqlDataAdapter(TextBox1.Text,cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Label1.Text = ds.Tables[0].Rows.Count.ToString();
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
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}
