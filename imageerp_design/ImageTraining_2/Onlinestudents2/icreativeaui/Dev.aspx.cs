using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();
    }

    private void fillgrid()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string qry="select * from img_centrelogin";
        SqlCommand cmd=new SqlCommand(qry,con);
        SqlDataAdapter da=new SqlDataAdapter(cmd);
        DataTable dt=new DataTable();
        da.Fill(dt);
        ASPxGridView1.DataSource=dt;
        ASPxGridView1.DataBind();
        con.Close();
   }
}
