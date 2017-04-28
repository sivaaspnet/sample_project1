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

public partial class superadmin_insertoldreceipt : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtname.Text);
    }
    
    protected void btn_add_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = " select studentid,enq_personal_name,receiptno,rec.invoiceno,cast(amount as varchar) as amount,cast(taxamount as varchar) as taxamount,cast(totalamount as varchar) as totalamount,convert(varchar,rec.dateins,103) as date from erp_receiptdetails rec inner join adm_personalparticulars p on studentid=student_id and centercode=centre_code where receiptno='" + txtreceipt.Text.Trim() + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = "Receipt No already exists";
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                _Qry = "select count(*) from erp_invoicedetails where studentid='" + txtname.Text + "' and invoiceid='" + txtinvoice.Text + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
                int total = 0;
                total = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (total > 0)
                {
                    string[] splitdate = txtrecdate.Text.Split('-');
                    string dateval = splitdate[2] + "-" + splitdate[1] + "-" + splitdate[0];
                    // _Qry = "update erp_receiptdetails set studentid='" + txtname.Text.Trim() + "',invoiceno='" + txtinvoice.Text.Trim() + "',amount='" + txtamount.Text.Trim() + "',taxamount='" + txttax.Text.Trim() + "',totalamount='" + txttotal.Text.Trim() + "',paymentmode='" + ddlpattern.SelectedValue + "',ddno='" + txtcheckno.Text.Trim() + "', bankname='" + txtbank.Text.Trim() + "',paymentwords=(select words from fnNumToWords1('" + txttotal.Text.Trim() + "','n')),installno='" + txtinstall.Text.Trim() + "',dateins='" + dateval + "' where centercode='" + Session["SA_centre_code"].ToString() + "' and receiptno='" + txtreceipt.Text.Trim() + "'";
                    _Qry = @"declare @paymentWords varchar(200)
	select @paymentWords=words from fnNumToWords1(cast('" + txttotal.Text.Trim() + @"' as numeric),'n')
      insert into erp_receiptdetails (studentid,invoiceno,amount,taxamount,totalamount,paymentmode,ddno,bankname,paymentwords,installno,dateins,centercode,receiptno,status,paymenttowards,receipttype) values ('" + txtname.Text.Trim() + "','" + txtinvoice.Text.Trim() + "','" + txtamount.Text.Trim() + "','" + txttax.Text.Trim() + "','" + txttotal.Text.Trim() + "','" + ddlpattern.SelectedValue + "','" + txtcheckno.Text.Trim() + "','" + txtbank.Text.Trim() + "',@paymentWords,'" + txtinstall.Text.Trim() + "','" + dateval + "','" + Session["SA_centre_code"].ToString() + "','" + txtreceipt.Text.Trim() + "',1,'" + txttowards.Text.Trim() + "','" + ddltype.SelectedValue + "') ";
                    _Qry += " update erp_installamountdetails set status='Completed' where studentid='" + txtname.Text + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and invoiceno='" + txtinvoice.Text.Trim() + "' and installnumber='" + txtinstall.Text.Trim() + "'";
                    int count = 0;
                    // Response.Write(_Qry);
                    count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (count > 0)
                    {
                        lblmsg.Text = "Receipt Added  Successfully";
                    }
                }
                else
                {
                    lblmsg.Text = "This studentid does not have this invoicenumber";
                }
            }
        }

    }
   

     
}
