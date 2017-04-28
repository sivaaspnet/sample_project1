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
                cmd.CommandText = @"select enq_personal_name from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_number=f2.enq_number and substring(enq.enq_number,1,3)<>'Old'
 and enq.centre_code=f2.centre_code left join adm_generalinfo as adm on
 enq.enq_number=adm.enq_number  inner join  img_coursedetails as c on
 c.course_id=f2.enq_coursepositioned where f2.centre_code='"+context.Session["SA_centre_code"].ToString()+"'" +
" and enq_personal_name like  @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        sb.Append(sdr["enq_personal_name"])
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