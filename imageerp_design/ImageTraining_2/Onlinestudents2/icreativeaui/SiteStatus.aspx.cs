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


public partial class superadmin_SiteStatus : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        //{
        //    Response.Redirect("Login.aspx");
        //}
        if (!IsPostBack)
        {
            fillgrid();
           // displayfacultyonload();
        }

        if (!IsPostBack)
        {
            FillCentre();

            ddlcentrename.Items.Insert(0, new ListItem("select", ""));
        }


    }


    private void FillCentre()
    {
        _Qry = "select centre_code,centre_location from img_centredetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddlcentrename.DataSource = dt;

            ddlcentrename.DataTextField = "centre_location";
            ddlcentrename.DataValueField = "centre_code";

            ddlcentrename.DataBind();
        }
    }

    void fillgrid()
    {

       // _Qry = "select replace(username,'~','''')as username,replace(userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id from img_centrelogin where role='Faculty' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centrelogin_id desc";


        _Qry = "select StatusId,ess.centre_code,case Status when 1  then 'Online' when 0 then  'Offline' end as Status,Message,centre_location from ERP_SiteStatus ess inner join img_centredetails cd on cd.centre_code=ess.centre_code order by StatusId desc ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    void refresh()
    {
        ddlcentrename.SelectedValue = "";

        ddlCentreStatus.SelectedValue = "";

        txtmessage.Text = "";
       
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        if (Hidn_centerloginid.Value == "" || Hidn_centerloginid.Value == null)
        {
            _Qry = "select count(centre_code) from ERP_SiteStatus where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlcentrename.SelectedValue) + " '";

            //Response.Write(_Qry);
            //Response.End();

            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Status already assiged to this centre";
            }
            else
            {
                //insert
                _Qry = "INSERT INTO ERP_SiteStatus (centre_code,Status,Message,DateIns,DateMod) values('" + ddlcentrename.SelectedValue + "','" + ddlCentreStatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmessage.Text) + "',getdate(),getdate())";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "Status details inserted sucessfully";
                refresh();
            }
        }
        else
        {
            //_Qry = "select count(centre_id) from ERP_SiteStatus where centre_id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlcentrename.SelectedValue) + " '";
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "Status details already exist";
            //}
            //else
            //{
                //update
            _Qry = "update ERP_SiteStatus set centre_code='" + ddlcentrename.SelectedValue + "',Status='" + ddlCentreStatus.SelectedValue + "',Message='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmessage.Text) + "',DateMod=getdate() where StatusId=" + Hidn_centerloginid.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "Site status details has been updated Successfully";
                refresh();
                Hidn_centerloginid.Value = "";
            //}
        }      
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select StatusId,centre_code,Status,Message from ERP_SiteStatus where StatusId=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                ddlcentrename.SelectedValue = dt.Rows[0]["centre_code"].ToString();
                ddlCentreStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                txtmessage.Text = dt.Rows[0]["Message"].ToString();
                Hidn_centerloginid.Value = dt.Rows[0]["StatusId"].ToString();
                lblmsg1.Text = "";
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from ERP_SiteStatus where StatusId='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "Status Details has been Deleted Successfully";
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
        //_Qry = "select FacultyName from Onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "'";

        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_facultyname.DataSource = dt;
        //ddl_facultyname.DataValueField = "FacultyName";
        //ddl_facultyname.DataTextField = "FacultyName";
        //ddl_facultyname.DataBind();
        //ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));     
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteStatus.aspx");
    }
}
