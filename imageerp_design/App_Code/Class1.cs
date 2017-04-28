using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Power_products
{
    public class Class_PP
    {
        public Class_PP()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable exedatatable(string s)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connect"].ToString());

            SqlDataAdapter da = new SqlDataAdapter(s, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void exenonquery(string s)
        {
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connect"].ToString());
            SqlCommand cmd = new SqlCommand(s, con1);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
        }
        public int exescalar(string s)
        {
            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connect"].ToString());
            SqlCommand cm = new SqlCommand(s, con2);
            con2.Open();
            int i = Convert.ToInt32(cm.ExecuteScalar());
            con2.Close();
            return i;
        }
        public string addTild(string str)
        {
            string res = str;
            if (res != "")
            {
                res = res.Replace("'", "~");
            }
            return res;
        }
        public string removetild(string str)
        {
            string ret = str;
            if (ret != "")
            {
                ret = ret.Replace("~", "'");
            }
            return ret;

        }
        public void sessioncheck()
        {
            if (HttpContext.Current.Session["ADMIN_ID"] == "" || HttpContext.Current.Session["ADMIN_ID"] == null)
            {
                HttpContext.Current.Response.Redirect("Admin_login.aspx");
            }
        }
    }
}

    