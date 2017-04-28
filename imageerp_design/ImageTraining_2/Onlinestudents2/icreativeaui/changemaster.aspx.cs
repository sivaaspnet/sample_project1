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
    }
    protected void changepwd_Click(object sender, EventArgs e)
    {
         {
             _Qry = "select masterPassword from img_centrelogin where masterPassword='" + existingpwd.Text + "' and centre_code='" + Session["SA_centre_code"] + "' and userid='" + Session["SA_UserID"] + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            if (newpwd.Text == reenterpwd.Text)
            {
                _Qry = "update img_centrelogin set masterPassword='" + newpwd.Text + "' where userid='" + Session["SA_UserID"] + "' and centre_code='" + Session["SA_centre_code"] + "'";  
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                lblerrmsg.Text = "Your Password Changed sucessfully";
                existingpwd.Text = "";
                newpwd.Text = "";
                reenterpwd.Text = "";

            }
            else
            {
                lblerrmsg.Text = "Re-enter your password";
                newpwd.Text = "";
                reenterpwd.Text = "";
            }
        }
        else
        {
            lblerrmsg.Text = "Invalid Password";
            existingpwd.Text = "";
        }
    }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("changemaster.aspx");
    }
}
