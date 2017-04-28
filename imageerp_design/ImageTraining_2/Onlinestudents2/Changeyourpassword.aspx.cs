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
        if (Session["Student_Id"] == null || Session["Student_Id"] == "")
        {
            Response.Redirect("Login.aspx");
        } 
    }
    protected void changepwd_Click(object sender, EventArgs e)
    {
        _Qry = "select password from adm_generalinfo where password='" + existingpwd.Text + "' and student_id='" + Session["Student_Id"] + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            if (newpwd.Text == reenterpwd.Text)
            {
                _Qry = "update adm_generalinfo set password='" + newpwd.Text + "' where student_id='" + Session["Student_Id"] + "'";  
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
