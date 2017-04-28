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

public partial class superadmin_ProjectEvaluation : System.Web.UI.Page
{
    string _Qry,_Qry1,_Qry2,_Qry3,_qry,centreid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
            fillgrid();
            Fillsearchmodule();
            FillsearchCentre();
        }
    }

    private void FillsearchCentre()
    {
        _qry = "select Centre_Code,Centre_Location from img_centredetails order by Centre_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlCentre.DataSource = dt1;
        ddlCentre.DataValueField = "Centre_Location";
        ddlCentre.DataTextField = "Centre_Location";
        ddlCentre.DataBind();
        ddlCentre.Items.Insert(0, new ListItem("Select", ""));
    }

    private void Fillsearchmodule()
    {
        _qry = "select module_content,module_Id from module_details order by Module_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_content";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }

    public string removetilde(string str)
    {
       return MVC.CommonFunction.ReplaceQuoteWithTild(str);
      
    }
    private void fillgrid()
    {
        tblvis.Visible = false;
        _Qry = "select ProjectId,StudentId,CentreID,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when IsNull(Mark,0)=0 Then 0 Else Mark End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId>0 ";
        
        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {

        }
        else
        {
            _Qry += " And Module='" + ddlsearchmodname.SelectedItem.ToString() + "'";
        }
        if (ddlCentre.SelectedValue == "" || ddlCentre.SelectedValue == null)
        {

        }
        else
        {
            _Qry += " And CentreID='" + ddlCentre.SelectedValue + "'";
        }
        
        _Qry += " And Status='Process'";
      
        _Qry += " Order By ProjectId desc";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

        if (dt.Rows.Count > 0)
        {
            //grdcentre.PageSize = dt.Rows.Count;
        }

        foreach (GridViewRow gr in grdcentre.Rows)
        {
            Label lblsta = new Label();
            lblsta = (Label)gr.FindControl("lblStatus");
            if (lblsta.Text == "Completed")
            {
                Label lblAppr = new Label();
                lblAppr = (Label)gr.FindControl("lblApprove");
                lblAppr.Visible = true;
                lblAppr.Text = "Completed";

                LinkButton lnkApprove = new LinkButton();
                lnkApprove = (LinkButton)gr.FindControl("LinkButton1");
                lnkApprove.Visible = false;
            }
            else if (lblsta.Text == "Pending")
            {
                Label lblAppr = new Label();
                lblAppr = (Label)gr.FindControl("lblApprove");
                lblAppr.Visible = true;
                lblAppr.Text = "Pending";

                LinkButton lnkApprove = new LinkButton();
                lnkApprove = (LinkButton)gr.FindControl("LinkButton1");
                lnkApprove.Visible = false;
            }
            else
            {
                Label lblAppr = new Label();
                lblAppr = (Label)gr.FindControl("lblApprove");
                lblAppr.Visible = false;

                LinkButton lnkApprove = new LinkButton();
                lnkApprove = (LinkButton)gr.FindControl("LinkButton1");
                lnkApprove.Visible = true;
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        _Qry = "Update ProjectAssesment Set EvaluatedDate='" + System.DateTime.Now.ToString("dd/MM/yyyy") + "',EvaluatedBy='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtEvaluatedBy.Text) + "',Mark='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmark.Text) + "',Remarks='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtRemarks.Text) + "',Status='" + ddlstatus.SelectedValue + "' Where projectId=" + lblProjectId.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        fillgrid();
        tblvis.Visible = false;
        refresh();
    }
    private void refresh()
    {
        txt_StudentId.Text = "";
        txt_StudentName.Text = "";
        txtCourse.Text = "";
        txtModule.Text = "";
        txtSenddate.Text = "";
        txtDispatchdate.Text = "";
        txtproject.Text = "";
        txtEvalDate.Text = "";
        txtEvaluatedBy.Text = "";
        txtmark.Text = "";
        txtRemarks.Text = "";
    }
    
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdApprove")
        {
            refresh();
            tblvis.Visible = true;
            btnvis.Visible = true;

            _Qry = "Select ProjectID,StudentId,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when IsNull(Mark,0)=0 Then 0 Else Mark End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_StudentId.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["StudentId"].ToString());
                txt_StudentName.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["StudentName"].ToString());
                txtCourse.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Course"].ToString());
                txtModule.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Module"].ToString());
                txtSenddate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Senddate"].ToString());
                txtproject.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["ProjectGuidedBy"].ToString());
                txtDispatchdate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["DispatchDate"].ToString());
                //if (dt.Rows[0]["Mark"].ToString() == "0")
                //{
                //    txtmark.Text = "Pending";
                //}
                //else
                //{
                //    txtmark.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Mark"].ToString());
                //}
                //txtEvalDate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Evaluateddate"].ToString());
                //txtEvaluatedBy.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["EvaluatedBy"].ToString());
                //txtRemarks.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Remarks"].ToString());
                evaldate.Visible = false;
                lblProjectId.Text = e.CommandArgument.ToString();
            }
        }
        if (e.CommandName == "Cmdview")
        {
            refresh();
            tblvis.Visible = true;
            btnvis.Visible = false;
            evaldate.Visible = true;
            _Qry = "Select ProjectID,StudentId,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when IsNull(Mark,0)=0 Then 0 Else Mark End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_StudentId.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["StudentId"].ToString());
                txt_StudentName.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["StudentName"].ToString());
                txtCourse.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Course"].ToString());
                txtModule.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Module"].ToString());
                txtSenddate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Senddate"].ToString());
                if (dt.Rows[0]["ProjectGuidedBy"].ToString() == "" || dt.Rows[0]["ProjectGuidedBy"].ToString() == null)
                {
                    txtproject.Text = "Pending";
                }
                else
                {
                    txtproject.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["ProjectGuidedBy"].ToString());
                }
                txtDispatchdate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["DispatchDate"].ToString());
                if (dt.Rows[0]["Mark"].ToString() == "0")
                {
                    txtmark.Text = "Pending";
                }
                else
                {
                    txtmark.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Mark"].ToString());
                }
                txtEvalDate.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Evaluateddate"].ToString());
                txtEvaluatedBy.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["EvaluatedBy"].ToString());
                txtRemarks.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Remarks"].ToString());
                //lblProjectId.Text = e.CommandArgument.ToString();
            }
        }
        //else
        //{
        //    tblvis.Visible = false;
        //}
    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
