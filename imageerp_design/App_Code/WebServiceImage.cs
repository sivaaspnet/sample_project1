using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for WebServiceImage
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebServiceImage : System.Web.Services.WebService {
    SqlConnection scon;
    SqlCommand scmd;
    SqlDataAdapter da;
    DataSet ds;  
    public WebServiceImage () {

        scon = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=imagetraining_TestDB;Data Source=NS6\SQLEXPRESS");

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public string GetUserDetails(string username)
    {
        scon.Open();
        //HttpContext.Current.Response.Write("select * from Registration_Ipad where First_Name='" + username + "'");
        //HttpContext.Current.Response.End();
        da = new SqlDataAdapter("select * from Registration_Ipad where First_Name='" + username + "'", scon);
        ds = new DataSet();
        da.Fill(ds);
        string xmlstring = ds.GetXml();
        scon.Close();
        return xmlstring;

    }
}

