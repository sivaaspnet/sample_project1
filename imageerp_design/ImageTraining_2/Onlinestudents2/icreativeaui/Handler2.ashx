<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using  System.Data.SqlClient;
using System.Web.SessionState;

public class Handler : IHttpHandler, IReadOnlySessionState {

    public void ProcessRequest(HttpContext context)
    {
      
        string prefixText = context.Request.QueryString["q"];
        using (SqlConnection conn = new SqlConnection())
        {
            
            conn.ConnectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["Connect"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select inv.studentid,enq_personal_name from erp_invoicedetails inv inner join adm_personalparticulars  adm on studentid=student_id where inv.centercode='" + context.Session["SA_centre_code"].ToString() + "'" +
" and studentid like  @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        sb.Append(sdr["studentid"])
                            .Append(Environment.NewLine);
                    }
                }
                conn.Close();
                context.Response.Write(sb.ToString());
               // context.Response.Write(context.Session["SA_centre_code"].ToString());
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}