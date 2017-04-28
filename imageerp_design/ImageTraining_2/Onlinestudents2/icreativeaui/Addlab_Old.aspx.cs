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

public partial class superadmin_Addlab : System.Web.UI.Page
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
    private void fillgrid()
    {
        _Qry = "select lab_id,replace(lab_name,'~','''')as lab_name,replace(sys_count,'~','''')as sys_count from img_labdetails where centre_code='" + Session["SA_centre_code"] + "' and lab_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by lab_id desc";
       
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
   
   private void refresh()
    {
        txt_systems.Text = "";
        txt_labname.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select lab_name,lab_id,sys_count from img_labdetails where lab_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                txt_labname.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["lab_name"].ToString());
                txt_systems.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["sys_count"].ToString());
                
                hiddn_id.Value = dt.Rows[0]["lab_id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from img_labdetails where lab_id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            lblmsg1.Text = "The lab details has been deleted successfully";
            refresh();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            _Qry = "select count(lab_id) from img_labdetails where lab_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' and centre_code='"+Session["SA_centre_code"]+"'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The lab name already exist";
            }
            else
            {
                //insert
                _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The lab details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(lab_id)from img_labdetails where lab_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' and centre_code='" + Session["SA_centre_code"] + "' and lab_id <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The lab name already exist";
            }
            else
            {
                //update
                _Qry = "update img_labdetails set centre_code='" + Session["SA_centre_code"] + "',lab_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "',sys_count='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "',createdby='" + Session["SA_Username"] + "',dateins=NOW() where lab_id=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The lab details has been Updated successfully";
                refresh();
             
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
