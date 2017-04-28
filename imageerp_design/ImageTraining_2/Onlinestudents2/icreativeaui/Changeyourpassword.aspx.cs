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
using System.Web.Mail;
using System.Text;
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

        _Qry = "select password,username,role,centre_code,centre_useremail from img_centrelogin where password='" + existingpwd.Text + "' and centre_code='" + Session["SA_centre_code"] + "' and userid='" + Session["SA_UserID"] + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            if (newpwd.Text == reenterpwd.Text)
            {
                _Qry = "update img_centrelogin set password='" + newpwd.Text + "' where userid='" + Session["SA_UserID"] + "' and centre_code='" + Session["SA_centre_code"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                lblerrmsg.Text = "Your Password Changed sucessfully";
                MailMessage SendMail = new MailMessage();

                SendMail.From = "ERP@imageil.com";
                SendMail.To = "maildata909@gmail.com;sumathi@imageil.com";
                SendMail.Subject = "User Password - Changed";
                SendMail.BodyFormat = MailFormat.Html;              
                StringBuilder sbContent = new StringBuilder();
                sbContent.Append("<table><tr><td>User name : </td><td>" + dt.Rows[0]["username"].ToString() + "</td></tr>");
                sbContent.Append("<tr><td>Old Password : </td><td>" + dt.Rows[0]["password"].ToString() + "</td></tr>");
                sbContent.Append("<tr><td>Changed(Current) Password : </td><td>" + newpwd.Text + "</td></tr>");
                sbContent.Append("<tr><td>Email : </td><td>" + dt.Rows[0]["centre_useremail"].ToString() + "</td></tr>");
                sbContent.Append("<tr><td>Centre Code : </td><td>" + dt.Rows[0]["centre_code"].ToString() + "</td></tr>");
                sbContent.Append("</table>");
                SendMail.Body = sbContent.ToString();
                SmtpMail.Send(SendMail);
                SendMail = null;
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
    
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Changeyourpassword.aspx");
    }
    protected void Validate_Special1(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(existingpwd.Text);
    }
    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(newpwd.Text);
    }
    protected void Validate_Special3(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(reenterpwd.Text);
    }
}
