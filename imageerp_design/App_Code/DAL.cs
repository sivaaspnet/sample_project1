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
/// <summary>
/// Summary description for DAL
/// </summary>
/// 
namespace MVC
{
    public static  class SQLDAL
    {
        
        public static DataTable executeDatatable(SqlCommand cmd, string conn)
        {
            DataTable dt = new DataTable();
            cmd.Connection = new SqlConnection(conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
   
}