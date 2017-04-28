using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class testingConnection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connection = "Data Source=.;Initial Catalog=imageerpnew;Integrated Security=true;Max Pool Size=75000;connect timeout=200000";

        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand("select getdate()", con);
        con.Open();
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write(dr[0].ToString());
        }
        dr.Close();
        con.Close();
    }
}