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
using System.Text.RegularExpressions;


public partial class superadmin_Facultydetails : System.Web.UI.Page
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
            displayfacultyonload();
        }
    }
    void fillgrid()
    {

        _Qry = "select distinct  masterPassword,replace(username,'~','''')as username,replace(a.userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id from img_centrelogin a  inner join onlinestudentsfacultydetails b on facultyname=username where role='Faculty' and b.Status='enable' and a.centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centrelogin_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    void refresh()
    {
        ddl_facultyname.SelectedValue = "";
        
        txtfaculty_id.Text = "";
        txtfaculty_pwd.Text = "";
        txtfaculty_repwd.Text = "";
        txtfaculty_email.Text = "";
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        if (Hidn_centerloginid.Value == "" || Hidn_centerloginid.Value == null)
        {
            _Qry = "select count(centrelogin_id) from img_centrelogin where role='Faculty' and userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_id.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_email.Text) + "'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Faculty UserID or Email Id Already Exist";
            }
            else
            {
                //insert
                _Qry = "INSERT INTO img_centrelogin (centre_id,username,userid,password,role,centre_code,centre_category,centre_region,centre_useremail,createdby,updatedby,dateins,centre_loginstatus)values('" + Session["SA_CenterID"] + "','" + ddl_facultyname.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_id.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_pwd.Text) + "','Faculty','" + Session["SA_centre_code"] + "','" + Session["SA_Centre_category"] + "','" + Session["SA_centre_region"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_email.Text) + "','" + Session["SA_Username"] + "','Not Updated',getdate(),'" + Session["SA_centre_loginstatus"] + "')";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "Faculty details inserted sucessfully";
                refresh();
            }
        }
        else
        {
            //_Qry = "select count(centrelogin_id)from img_centrelogin where (role='Faculty' and userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_id.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_email.Text) + "') and centrelogin_id<>" + Hidn_centerloginid.Value + "";
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "The Faculty UserID or Emailid Already Exist";
            //}
            //else
            //{
                //update
                _Qry = "update img_centrelogin set centre_id='" + Session["SA_CenterID"] + "',username='" + ddl_facultyname.SelectedValue + "',userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_id.Text) + "',password='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_pwd.Text) + "',centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfaculty_email.Text) + "',updatedby='" + Session["SA_Username"] + "',dateupd=getdate() where centrelogin_id=" + Hidn_centerloginid.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The Faculty details has been updated Successfully";
                refresh();
                Hidn_centerloginid.Value = "";
           // }
        }      
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where centrelogin_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt=MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                ddl_facultyname.SelectedValue = dt.Rows[0]["username"].ToString();
                txtfaculty_id.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["userid"].ToString());
                txtfaculty_pwd.Text = dt.Rows[0]["password"].ToString();
                txtfaculty_email.Text = dt.Rows[0]["centre_useremail"].ToString();
                Hidn_centerloginid.Value = dt.Rows[0]["centrelogin_id"].ToString();
                lblmsg1.Text = "";
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from img_centrelogin where centrelogin_id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "Faculty Details has been Deleted Successfully";
            refresh();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    void displayfacultyonload()
    {
        _Qry = "select FacultyName from Onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "'";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_facultyname.DataSource = dt;
        ddl_facultyname.DataValueField = "FacultyName";
        ddl_facultyname.DataTextField = "FacultyName";
        ddl_facultyname.DataBind();
        ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));     
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
