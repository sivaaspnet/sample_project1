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

public partial class superadmin_Changeyourpassword : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            ViewState["value"] = Request.ServerVariables["HTTP_REFERER"];
        }
    }
    protected void changepwd_Click(object sender, EventArgs e)
    {


        //if (Session["Captcha"].ToString() == TextBox1.Text)
        //{
        if (Page.IsValid)
        {

            _Qry = "select masterPassword from img_centrelogin where masterPassword='" + masterpass.Text + "' and (centre_code='" + Session["SA_centre_code"] + "' or centre_code='11' or centre_code='12') and userid='" + Session["SA_UserID"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                Session["SA_Master"] = dt.Rows[0]["masterPassword"].ToString();
                Response.Redirect("welcome.aspx");
            }
            else
            {
                lblerrmsg.Text = "Invalid Password";
                masterpass.Text = "";
            }
        }
        //}
        //else
        //{
        //    lblerrmsg.Text = "Captcha Wrong";

        //}
   
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(masterpass.Text);
    }

}
