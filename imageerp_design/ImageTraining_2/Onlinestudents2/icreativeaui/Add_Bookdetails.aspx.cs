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


public partial class superadmin_Add_Moduledetails : System.Web.UI.Page
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
        _Qry = "select bookid,Replace(bookname,'~','''') as bookname,status from bookdetails where book_status='Active'";
        if (txtsearchname.Text != "")
        {
            _Qry += "and bookname like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%'";
        }
        _Qry += "order by bookid";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
   
   private void refresh()
    {
        txt_Modulename.Text = "";
        ddlstatus.SelectedValue = "";
        //DDlSoftwareStatus.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select bookid,bookname,status from bookdetails where bookid=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {

                string val = dt.Rows[0]["status"].ToString();

                //Response.Write(val);
                //Response.End();


                txt_Modulename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["bookname"].ToString());
                //DDlSoftwareStatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());
                ddlstatus.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["status"].ToString());

                hiddn_id.Value = dt.Rows[0]["bookid"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "update bookdetails set book_status='Deactive' where bookid='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "The Book details has been deleted successfully";
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
            _Qry = "select count(bookid) from bookdetails where bookname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Book name already exist";
            }
            else
            {
                //insert
                // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


                _Qry = " INSERT INTO bookdetails (bookname,status,dateins,datemod )VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "', '" + ddlstatus.SelectedValue + "', getdate(),getdate())";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The book details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(bookid)from bookdetails where bookname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "' and bookid <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Book name already exist";
            }
            else
            {
                //update
                _Qry = "update bookdetails set bookname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Modulename.Text) + "',status='" + ddlstatus.SelectedValue + "',datemod=getdate() where bookid=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmsg1.Text = "The Book details has been Updated successfully";
                refresh();
                hiddn_id.Value = "";

            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
