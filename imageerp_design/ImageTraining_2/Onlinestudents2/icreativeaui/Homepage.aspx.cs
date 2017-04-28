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
        int val = 0;

        if (Request.QueryString["Val"] == "" || Request.QueryString["Val"] == null)
        {

        }
        else
        {
            val = Convert.ToInt32(Request.QueryString["Val"].ToString());
        }

        if (val == 1)
        {
            popup_name.Visible = true;
        }
        else
        {
            popup_name.Visible = false;
            wrapper.Visible = true;
        }
    }
    protected void login_Click(object sender, EventArgs e)
    {
        _Qry = "select username,userid,password,role,Centre_category,centre_code,centre_region,centre_loginstatus,centre_id from img_centrelogin where userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtusername.Text) + "' and password='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpassword.Text) + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            Session["SA_UserID"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["userid"].ToString());
            Session["SA_Username"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["username"].ToString());
            Session["SA_Centrerole"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["role"].ToString());
            Session["SA_centre_code"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_code"].ToString());
            Session["SA_Centre_category"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Centre_category"].ToString());
            Session["SA_centre_region"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_region"].ToString());
            Session["SA_centre_loginstatus"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_loginstatus"].ToString());
            Session["SA_CenterID"] = dt.Rows[0]["centre_id"].ToString();
            Response.Redirect("Menus.aspx");

        }
        else
        {
            lblerrmsg.Text = "Invalid UserID & Password";
        }
    }
}
