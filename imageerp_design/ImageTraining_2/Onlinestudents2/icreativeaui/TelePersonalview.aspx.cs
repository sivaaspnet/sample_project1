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

public partial class TelePersonalview : System.Web.UI.Page
{
    string _Qry,_Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            display_onload();
        }
    }
    private void display_onload()
    {
        _Qry = "select * from TeleEnquiry where TeleEnquiryId='" + Request.QueryString["enqno"] + "'";

        //Response.Write(_Qry);
        //Response.End();


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txtName.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["EnquiryName"].ToString());
            txtEmail.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["EmailID"].ToString());
            txtMobileNo.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["MobileNo"].ToString());
            txtPhone.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["PhoneNo"].ToString());
            txtAddr.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Addr"].ToString());
            txtRemarks.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Remarks"].ToString());
            txtenq_By.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Enquired_By"].ToString());
            txtmod_By.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Modified_By"].ToString());
            ddl_source.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["sourse"].ToString());
            ddl_profile.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["profile"].ToString());
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {

        _Qry = "update TeleEnquiry set EnquiryName='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtName.Text) + "',EmailID='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtEmail.Text) + "',MobileNo='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtMobileNo.Text) + "',PhoneNo='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtPhone.Text) + "',Addr='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtAddr.Text) + "',Remarks='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtRemarks.Text) + "',DateMod=getdate(),Modified_By='" + Session["SA_Username"].ToString() + "',sourse='" + ddl_source.SelectedValue + "',profile='"+ ddl_profile.SelectedValue+"' where TeleEnquiryId='" + Request.QueryString["enqno"] + "'";

        //Response.Write(_Qry);
        //Response.End();

        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

        //_Qry1 = "update img_enquiryform1 set enq_parent_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtMobileNo.Text) + "',enq_parent_company='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblcompany.Text) + "',enq_parent_designation='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbldesignatio.Text) + "',enq_parent_income='" + lblincome.Text + "',enq_parent_phone='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblphone.Text) + "',enq_parent_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblmobile.Text) + "',enq_parent_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblemailid.Text) + "'where enq_number='" + lblenq_id.Text + "'";
        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

        display_onload();
        lblerror.Text = "Enquiry details updated sucessfully";
        Response.Write("<script>window.parent.location.href = 'teleenquiry.aspx?res=upd'</script>");
        //Response.Write(window.parent.location.href = 'teleenquiry.aspx?res=upd');
    }
}
