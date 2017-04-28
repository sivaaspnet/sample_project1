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

public partial class superadmin_Counselordetails : System.Web.UI.Page
{
    string _Qry, _Qry1,_Qry2;
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
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceQuoteWithTild(str);

    }
    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtsearchname.Text);
    }
    public string maskpasswordcharacters(string str)
    {
        string subStr = string.Empty;
        if (str.Length > 4)
        {
            subStr = str.Substring(0, str.Length - 4);
            subStr = subStr + "####";

        }
        else
        {
        }
        return subStr;

    }
    private void counselorinsert()
    {
        if (hdnID.Value == "")
        {
            _Qry1 = "select count(centrelogin_id) from img_centrelogin where role='Certificate' and userid='" + txtcounselor_id.Text + "' or centre_useremail='" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "'";

            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry1);
            if (count > 0)
            {
                lblmsg1.Text = "The UserID or Email Id Already Exist";
            }
            else
            {
                _Qry = "INSERT INTO img_centrelogin (centre_id,username,userid,password,role,centre_code,centre_category,centre_useremail,createdby,updatedby,dateins,dateupd,centre_loginstatus)values('" + Session["SA_CenterID"] + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_name.Text) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_id.Text) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_pwd.Text) + "','Certificate','14','" + Session["SA_Centre_category"] + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "','" + Session["SA_Username"] + "','Not Updated',getdate(),getdate(),'" + Session["SA_centre_loginstatus"] + "')";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The  Login Added Successfully";
            }
        }
        else
        {
            CounselorUpdate();
        }
    }
    private void fillgrid()
    {
        _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where role='Certificate'  and username like '%" + MVC.CommonFunction.ReplaceTildWithQuote(txtsearchname.Text) + "%' order by centrelogin_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcounselor.DataSource = dt;
        grdcounselor.DataBind();
    }
   
    protected void grdcounselor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkdel")
        {
            _Qry = "Delete from img_centrelogin where centrelogin_id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "The  Login deleted Successfully";
            refresh();
        }
        if (e.CommandName == "lnkedit")
        {
            _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where centrelogin_id="+e.CommandArgument.ToString()+"";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txtcounselor_name.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["username"].ToString());
                txtcounselor_id.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["userid"].ToString());
                txtcounselor_pwd.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["password"].ToString());
                txtcounselor_email.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centre_useremail"].ToString());
                hdnID.Value = dt.Rows[0]["centrelogin_id"].ToString();

            }
        }

    }
    private void CounselorUpdate()
    {
        if (hdnID.Value != "")
        {
            _Qry1 = "select count(centrelogin_id) from img_centrelogin where (role='Certificate' and userid='" + txtcounselor_id.Text + "' or centre_useremail='" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "') and centrelogin_id<>" + hdnID.Value + "";
           
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry1);
            if (count > 0)
            {
                lblmsg1.Text = "The UserID or Email Id Already Exist";

            }
            else
            {
                _Qry = "update img_centrelogin set centre_id='" + Session["SA_CenterID"] + "',username='" + txtcounselor_name.Text + "',userid='" + txtcounselor_id.Text + "',password='" + txtcounselor_pwd.Text + "',centre_useremail='" + txtcounselor_email.Text + "' where centrelogin_id=" + hdnID.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The  Login Has been updated Successfully";
                refresh();          
           }
           hdnID.Value = "";
        }
    
    }
    private void refresh()
    {
        txtcounselor_name.Text = "";
        txtcounselor_id.Text = "";
        txtcounselor_pwd.Text = "";
        txtcounselor_repwd.Text = "";
        txtcounselor_email.Text = "";
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    protected void grdcounselor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcounselor.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button_submit_Click(object sender, EventArgs e)
    {
        //CounselorUpdate();
        counselorinsert();
        refresh();
    }
}
