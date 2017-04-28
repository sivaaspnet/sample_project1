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

public partial class Onlinestudents2_superadmin_home : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        

       
    }
    protected void login_Click(object sender, EventArgs e)
    {

        _Qry = "select masterPassword,username,userid,password,role,Centre_category,centre_code,centre_region,centre_loginstatus,(Select centre_location from img_centredetails where centre_id=img_centrelogin.centre_id) as CentreLocation,centre_id from img_centrelogin where userid COLLATE Latin1_general_CS_AS='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtusername.Text) + "' and password COLLATE Latin1_general_CS_AS='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpassword.Text) + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            Session["SA_Master"] = null;
            Session["SA_UserID"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["userid"].ToString());
            Session["SA_Username"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["username"].ToString());
            Session["SA_Centrerole"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["role"].ToString());
            Session["SA_centre_code"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_code"].ToString());
            Session["SA_Centre_category"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Centre_category"].ToString());
            Session["SA_centre_region"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_region"].ToString());
            Session["SA_centre_loginstatus"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_loginstatus"].ToString());
            Session["SA_Location"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["CentreLocation"].ToString());
            Session["SA_CenterID"] = dt.Rows[0]["centre_id"].ToString();
 

            Response.Redirect("welcome.aspx");
        }

        else
        {
            lblerrmsg.Text = "Invalid UserID & Password";
        }
    }
   
}
