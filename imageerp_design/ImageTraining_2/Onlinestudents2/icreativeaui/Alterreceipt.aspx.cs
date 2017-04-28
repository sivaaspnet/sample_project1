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

public partial class superadmin_Alterreceipt : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        string strIP;
        strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //if(strIP !="115.249.237.125")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        //Response.Write(Request.ServerVariables["LOCAL_ADDR"].ToString());
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtstudentid.Text);
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        _Qry = "select count(*) from erp_invoicedetails where studentid='"+txtname.Text+"' and invoiceid='"+txtinvoice.Text+"' and centercode='"+Session["SA_centre_code"].ToString()+"'";
        int total = 0;
        total = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (total > 0)
        {
            string[] splitdate = txtrecdate.Text.Split('-');
            string dateval = splitdate[2] + "-" + splitdate[1] + "-" + splitdate[0];
            _Qry = "update erp_receiptdetails set remarks='"+MVC.CommonFunction.ReplaceTildWithQuote(txtchangereason.Text)+"',studentid='" + txtname.Text.Trim() + "',invoiceno='" + txtinvoice.Text.Trim() + "',amount='" + txtamount.Text.Trim() + "',taxamount='" + txttax.Text.Trim() + "',totalamount='" + txttotal.Text.Trim() + "',paymentmode='" + ddlpattern.SelectedValue + "',ddno='" + txtcheckno.Text.Trim() + "', bankname='" + txtbank.Text.Trim() + "',paymentwords=(select words from fnNumToWords1('" + txttotal.Text.Trim() + "','n')),installno='" + txtinstall.Text.Trim() + "',dateins='"+dateval+"' where centercode='" + Session["SA_centre_code"].ToString() + "' and receiptno='" + txtreceipt.Text.Trim() + "'";
            _Qry += " update erp_installamountdetails set status='Completed' where studentid='" + txtname.Text + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and invoiceno='" + txtinvoice.Text.Trim() + "' and installnumber='" + txtinstall.Text.Trim() + "'";
            int count = 0;
            //Response.Write(_Qry);
            count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg.Text = "Receipt Updated Successfully";
            }
        }
        else
        {
            lblmsg.Text = "This studentid does not have this invoicenumber";
        }
        

    }
    private void insertfacultydetails()
    {

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = "select enq_personal_name,studentid,installno,centercode,rec.invoiceno,receiptno,amount,taxamount,totalamount,paymentmode,bankname,ddno,dddate,paymenttowards,paymentwords,convert(varchar,dateins,105) as date,rec.remarks  from erp_receiptdetails rec inner join adm_personalparticulars p on p.student_id=rec.studentid and p.centre_code=rec.centercode where centercode='" + Session["SA_centre_code"].ToString() + "' ";
            if (txtstudentid.Text.Trim() != "")
            {
                _Qry += " and studentid='" + txtstudentid.Text.Trim() + "'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                gvreceipt.DataSource = dt;
                gvreceipt.DataBind();
            }
            if (txtreceipt.Text != "")
            {
                _Qry += " and receiptno='" + txtreceipt.Text.Trim() + "'";
                DataTable dtname = new DataTable();
                dtname = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dtname.Rows.Count > 0)
                {
                    details.Visible = true;
                    txtname.Text = dtname.Rows[0]["studentid"].ToString();
                    txtinvoice.Text = dtname.Rows[0]["invoiceno"].ToString();
                    txtamount.Text = dtname.Rows[0]["amount"].ToString();
                    txtbank.Text = dtname.Rows[0]["bankname"].ToString();
try
{
                    ddlpattern.SelectedValue = dtname.Rows[0]["paymentmode"].ToString();
}
catch(Exception ex)
{
}
                    txtcheckno.Text = dtname.Rows[0]["ddno"].ToString();
                    txttax.Text = dtname.Rows[0]["taxamount"].ToString();
                    txttotal.Text = dtname.Rows[0]["totalamount"].ToString();
                    txtinstall.Text = dtname.Rows[0]["installno"].ToString();
                    txtrecdate.Text = dtname.Rows[0]["date"].ToString();
                    txtchangereason.Text = dtname.Rows[0]["remarks"].ToString();
                }
            }
        }
    }
    protected void gvreceipt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select enq_personal_name,studentid,installno,centercode,rec.invoiceno,receiptno,amount,taxamount,totalamount,paymentmode,bankname,ddno,dddate,paymenttowards,paymentwords,convert(varchar,dateins,105) as date,rec.remarks  from erp_receiptdetails rec inner join adm_personalparticulars p on p.student_id=rec.studentid and p.centre_code=rec.centercode where centercode='" + Session["SA_centre_code"].ToString() + "'  and receiptno='" + e.CommandArgument.ToString() + "'";
            DataTable dtname = new DataTable();
            dtname = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtname.Rows.Count > 0)
            {
                details.Visible = true;
                txtname.Text = dtname.Rows[0]["studentid"].ToString();
                txtinvoice.Text = dtname.Rows[0]["invoiceno"].ToString();
                txtamount.Text = dtname.Rows[0]["amount"].ToString();
                txtbank.Text = dtname.Rows[0]["bankname"].ToString();
               // ddlpattern.SelectedValue = dtname.Rows[0]["paymentmode"].ToString();
try
{
                    ddlpattern.SelectedValue = dtname.Rows[0]["paymentmode"].ToString();
}
catch(Exception ex)
{
}
                txtcheckno.Text = dtname.Rows[0]["ddno"].ToString();
                 txttax.Text = dtname.Rows[0]["taxamount"].ToString();
                txttotal.Text = dtname.Rows[0]["totalamount"].ToString();
                txtreceipt.Text = dtname.Rows[0]["receiptno"].ToString();
                txtrecdate.Text = dtname.Rows[0]["date"].ToString();
                txtinstall.Text = dtname.Rows[0]["installno"].ToString();
                txtchangereason.Text = dtname.Rows[0]["remarks"].ToString();
            }

        }
    }
}
