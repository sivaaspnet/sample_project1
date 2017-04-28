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

public partial class superadmin_ProjectAssesment : System.Web.UI.Page
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
            //Fillsearchcourse();
            //Fillcourse();
            //Fillmodule();
        }
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

    //private void Fillcourse()
    //{
    //    _qry = "select Course_Code,Course_Id from onlinestudent_course order by Course_Id ";
    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

    //    ddlcourse.DataSource = dt1;
    //    ddlcourse.DataValueField = "Course_Id";
    //    ddlcourse.DataTextField = "Course_Code";
    //    ddlcourse.DataBind();
    //    ddlcourse.Items.Insert(0, new ListItem("Select", ""));
    //}

    //private void Fillmodule()
    //{
    //    _qry = "select module_content,module_Id from module_details order by Module_Id ";
    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

    //    ddlmodname.DataSource = dt1;
    //    ddlmodname.DataValueField = "module_Id";
    //    ddlmodname.DataTextField = "module_content";
    //    ddlmodname.DataBind();
    //    ddlmodname.Items.Insert(0, new ListItem("Select", ""));
    //}

    public string removetilde(string str)
    {
       return MVC.CommonFunction.ReplaceQuoteWithTild(str);
      
    }
    private void fillgrid()
    {
        tblvis.Visible = false;
        _Qry = "select ProjectID,StudentId,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when Mark!='' Then Mark Else 'Pending' End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId>0 ";
        
        if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
        {

        }
        else
        {
            _Qry += " And Module='" + ddlsearchmodname.SelectedItem.ToString() + "'";
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
        
    }
    
   
   
   
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Cmdview")
        {
            tblvis.Visible = true;

            _Qry = "Select ProjectID,StudentId,StudentName,Course,Module,ProjectGuidedBy,convert(varchar, Senddate, 103) as Senddate,case when Dispatchdate!='' then Dispatchdate Else 'Pending' End as DispatchDate,case when Mark='' Then Mark Else 'Pending' End as Mark,case when EvaluatedBy!='' then EvaluatedBy Else 'Pending' End as EvaluatedBy,case when Evaluateddate!='' then Evaluateddate Else 'Pending' End as Evaluateddate,case when Remarks!='' then Remarks Else 'Pending' End as Remarks,Status from ProjectAssesment Where ProjectId=" + e.CommandArgument.ToString() + "";
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
    protected void txtmark_TextChanged(object sender, EventArgs e)
    {

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
