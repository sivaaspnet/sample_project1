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

public partial class Onlinestudents2_superadmin_Change_Receipt_Status : System.Web.UI.Page
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

        // _Qry = "select replace(username,'~','''')as username,replace(userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id from img_centrelogin where role='Faculty' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centrelogin_id desc";


        _Qry = "select Id,receiptNo,invoiceNo,installNo,case status when 1  then 'Active' when 0 then  'Deactive' end as status,remarks from erp_receiptDetails order by Id desc ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Id,receiptNo,invoiceNo,installNo,status,remarks from erp_receiptDetails where Id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_receiptno.Text = dt.Rows[0]["receiptNo"].ToString();
               txt_invoieno.Text = dt.Rows[0]["invoiceNo"].ToString();
               txt_installno.Text = dt.Rows[0]["installNo"].ToString();
               ddl_receiptstatus.SelectedValue = dt.Rows[0]["status"].ToString();
                txt_remarks.Text = dt.Rows[0]["remarks"].ToString();
                Hdn_ReceiptId.Value = dt.Rows[0]["Id"].ToString();
                lblmsg1.Text = "";
            }
        }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        if (Hdn_ReceiptId.Value != "" || Hdn_ReceiptId.Value != null)
        {

            _Qry = "update erp_receiptDetails set receiptNo='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_receiptno.Text) + "',invoiceNo='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_invoieno.Text) + "',installNo='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_installno.Text) + "',status='" + ddl_receiptstatus.SelectedValue + "',remarks='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_remarks.Text) + "',datemod=getdate() where Id=" + Hdn_ReceiptId.Value + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "Receipt status details has been updated Successfully";
            refresh();
            
            //}
        }
      
    }
   private void refresh()
    {
        txt_receiptno.Text = "";
        txt_invoieno.Text = "";
        txt_installno.Text = "";
        ddl_receiptstatus.SelectedValue = "";
        txt_remarks.Text = "";
        Hdn_ReceiptId.Value = "";

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        refresh();
    }
}
