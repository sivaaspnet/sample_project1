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

public partial class superadmin_ViewProjectAssesment : System.Web.UI.Page
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
            //Fillcourse();
            //Fillmodule();
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
        _Qry = "select ProjectId,StudentId,CentreID,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when Mark!='' Then Mark Else 'Pending' End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId>0 ";
        
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
            _Qry += " And CentreID='" + ddlCentre.SelectedValue+ "'";
        }
        if (ddlstatus.SelectedValue == "" || ddlstatus.SelectedValue == null)
        {

        }
        else
        {
            _Qry += " And Status='" + ddlstatus.SelectedValue + "'";
        }
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
            Label lblpro = new Label();
            lblpro = (Label)gr.FindControl("lblProject");
            Label lblAppr = new Label();
            lblAppr = (Label)gr.FindControl("lblApprove");
            Label lblprocess = new Label();
            lblprocess = (Label)gr.FindControl("lblProcess");
            Label lblReject = new Label();
            lblReject = (Label)gr.FindControl("lblReject");
            DropDownList ddlpro = new DropDownList();
            ddlpro = (DropDownList)gr.FindControl("DropDownList1");
            Button btnAppr = new Button();
            btnAppr = (Button)gr.FindControl("Button1");

            if (ddlstatus.SelectedValue == "Completed")
            {
                btnAppr.Visible = false;
                lblAppr.Visible = true;
                lblprocess.Visible = false;
                lblReject.Visible = false;
            }
            if (ddlstatus.SelectedValue == "Process")
            {
                btnAppr.Visible = false;
                lblAppr.Visible = false;
                lblprocess.Visible = true;
                lblReject.Visible = false;
            }
            if (ddlstatus.SelectedValue == "Pending")
            {
                btnAppr.Visible = true;
                lblAppr.Visible = false;
                lblprocess.Visible = false;
                lblReject.Visible = false;
            }
            if (ddlstatus.SelectedValue == "Rejected")
            {
                btnAppr.Visible = false;
                lblAppr.Visible = false;
                lblprocess.Visible = false;
                lblReject.Visible = true;
            }
        }
        
    }
    
   
    //private void refresh()
    //{
    //    txt_StudentId.Text = "";
    //    txt_StudentName.Text = "";
    //    ddlmodname.SelectedValue = "";
    //    ddlcourse.SelectedValue = "";
    //    txtproject.Text = "";
    //    hdnID.Value = "";
    //    hdnID1.Value = "";
        
    //}
   
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Upd")
        {
            foreach (GridViewRow gr in grdcentre.Rows)
            {
                Label lblpro = new Label();
                lblpro = (Label)gr.FindControl("lblProject");
                if (lblpro.Text == e.CommandArgument.ToString())
                {
                    //DropDownList ddlpro = new DropDownList();
                    //ddlpro = (DropDownList)gr.FindControl("DropDownList1");

                    //if (ddlstatus.SelectedValue == "Process")
                    //{
                        _qry = "Update ProjectAssesment Set status='Process',DispatchDate='" + System.DateTime.Now.ToString("dd/MM/yyyy") + "' Where projectId=" + e.CommandArgument.ToString() + "";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _qry);
                        lblmsg1.Text = "Status Update Successfully";
                    //}
                }
            }
            fillgrid();
        }

        if (e.CommandName == "Cmdview")
        {
            tblvis.Visible = true;

            _Qry = "Select ProjectID,StudentId,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when Mark!='' Then Mark Else 'Pending' End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId=" + e.CommandArgument.ToString() + "";
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
                if (dt.Rows[0]["Mark"].ToString() == "" || dt.Rows[0]["Mark"].ToString() == null)
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
        else
        {
            tblvis.Visible = false;
        }
        
    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
