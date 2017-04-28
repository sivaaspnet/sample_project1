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

public partial class superadmin_leaveapprove : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
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
        return MVC.CommonFunction.ReplaceTildWithQuote(str);
      
    }
    private void fillgrid()
    {
        _Qry = " select leave.id,enq_personal_name,studentid,centercode,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where centercode='" + Session["SA_centre_code"].ToString() + "' ";
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();
        foreach (GridViewRow gr in grdcentre.Rows)
        {
            Label lbl = new Label();
            lbl = (Label)gr.FindControl("lblstatus");
            LinkButton lnkapprove = new LinkButton();
            lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
            LinkButton lnkdecline = new LinkButton();
            lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
            if (lbl.Text == "Pending")
            {
                lnkapprove.Visible = true;
                lnkdecline.Visible = true;
                lbl.Visible = false;
            }
            else
            {
                lnkapprove.Visible = false;
                lnkdecline.Visible = false;
                lbl.Visible = true;
            }
        }
    }
     
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "approve")
        {
            _Qry = " update erp_studentleave set status='Approved',approvedate=getdate() where id='"+e.CommandArgument.ToString()+"'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        else if (e.CommandName == "decline")
        {
            _Qry = " update erp_studentleave set status='Rejected',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        fillgrid();
    }
    
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
     }
}
