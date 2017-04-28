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

public partial class superadmin_TechnicalHead : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    void fillgrid()
    {
        _Qry = "select masterPassword,replace(username,'~','''')as username,replace(userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id,login_status from img_centrelogin where role='Technical Head' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by centrelogin_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Btnupdate_Click1(object sender, EventArgs e)
    {
        if (Hidn_centerloginid.Value == "")
        {
            _Qry = "select count(centrelogin_id) from img_centrelogin where role='Technical Head' and userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_userid.Text) + "' or centre_useremail='" + txttech_emailid.Text+ "'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Technical Head's UserID or Email Id Already Exist";
            }
            else
            {
                _Qry = "INSERT INTO img_centrelogin (centre_id,username,userid,password,role,centre_code,centre_category,centre_region,centre_useremail,createdby,updatedby,dateins,dateupd,centre_loginstatus,masterPassword,login_status)values('" + Session["SA_CenterID"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_name.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_userid.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_password.Text) + "','Technical Head','" + Session["SA_centre_code"] + "','" + Session["SA_Centre_category"] + "','" + Session["SA_centre_region"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_emailid.Text) + "','" + Session["SA_Username"] + "','Not Updated',getdate(),getdate(),'" + Session["SA_centre_loginstatus"] + "','" + txttech_masterpassword.Text + "','"+ddlloginstatus.SelectedValue+"')";
               //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The technical head Details has been inserted Successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(centrelogin_id)from img_centrelogin where (role='Technical Head' and userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_userid.Text) + "' or centre_useremail='" + txttech_emailid.Text + "') and centrelogin_id<>" + Hidn_centerloginid.Value + "";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Technical UserID or Email id Already Exist";
            }
            else
            {
                //update
                _Qry = "update img_centrelogin set centre_id='" + Session["SA_CenterID"] + "',username='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_name.Text) + "',userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_userid.Text) + "',password='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_password.Text) + "',centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttech_emailid.Text) + "',login_status='"+ddlloginstatus.SelectedValue+"',updatedby='" + Session["SA_Username"] + "',dateupd=getdate() ,masterPassword='" + txttech_masterpassword.Text + "' where centrelogin_id=" + Hidn_centerloginid.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The Technical head details has been updated Successfully";
                refresh();
                Hidn_centerloginid.Value = "";
            }
            
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where centrelogin_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                txttech_name.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["username"].ToString());
                txttech_userid.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["userid"].ToString());
                txttech_password.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["password"].ToString());
                txttech_emailid.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_useremail"].ToString());
                Hidn_centerloginid.Value = dt.Rows[0]["centrelogin_id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from img_centrelogin where centrelogin_id='" + e.CommandArgument.ToString() +"'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "Technical Head Details has been Deleted Successfully";
            refresh();
        }
        if (e.CommandName == "lnkstatus")
        {
            string status = "";
            string[] comm_arg = e.CommandArgument.ToString().Split(',');
            if (comm_arg[1] == "Enable")
                status = "Disable";
            else if (comm_arg[1] == "Disable")
                status = "Enable";
            _Qry = "update  img_centrelogin set login_status='" + status + "' where centrelogin_id='" + comm_arg[0] + "'";


            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();

            lblmsg1.Text = "Technical Head login status has been  updated Successfully";


        }
    }
    private void refresh()
    {
        txttech_userid.Text = "";
        txttech_password.Text = "";
        txttech_name.Text = "";
        txttech_comfirmpassword.Text = "";
        txttech_emailid.Text = "";
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
