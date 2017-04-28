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
    string _Qry,_Qry1,_Qry2,_Qry3,_qry,centreid,batchcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

       
        
        if (!IsPostBack)
        {
            //fillcentre();
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            //string yea = string.Format("{0:yyyy}", DateTime.Now).Trim();
            TextBox4.Text = mon;
            

            //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            TextBox3.Text = DateTime.Now.ToString("dd-MM-yyyy");
          //  txtEvalDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //txtEvaluatedBy.Text = Session["SA_Username"].ToString();

           // HiddenField2.Value = Session["SA_Centrerole"] .ToString();
            if (Request.QueryString["StudentID"] == "" || Request.QueryString["StudentID"] == null)
            {
                Fillsearchmodule();
                fillgrid1();
               

            }
           
            else
            {
               // projecthead.Visible = false;
               // search.Visible = false;
               // tblvis.Visible = true;
                Fillsearchmodule();
              
                fillgrid1();
               // Label7.Text = Request.QueryString["StudentID"].ToString();
               // Session["SA_centre_code"] = Request.QueryString["centrecode"].ToString();
                
            }
          
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
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(TextBox2.Text);
    }
    //private void fillcentre()
    //{
    //    _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);

    //    DropDownList1.DataSource = dt;
    //    DropDownList1.DataTextField = "Centre_location";
    //    DropDownList1.DataValueField = "Centre_Code";
    //    DropDownList1.DataBind();
    //    DropDownList1.Items.Insert(0, new ListItem("Select", ""));
    //}
 
  
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
   
    
   
    private void fillgrid1()
    {
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Faculty" || Session["SA_Centrerole"] .ToString() == "Region Head")
        {
            _Qry = @"SELECT DISTINCT 
                      dbo.erp_studentprogress.Status,dbo.erp_studentprogress.projectid,dbo.erp_studentprogress.id, dbo.Submodule_details_new.Module, dbo.adm_personalparticulars.enq_personal_name, 
                      dbo.erp_studentprogress.studentid, dbo.erp_studentprogress.projectguided_by, dbo.erp_studentprogress.centrecode, 
                      dbo.Submodule_details_new.ModuleId, dbo.projectdetails.projectname, CONVERT(varchar,dbo.erp_studentprogress.Senddate,103) AS Senddate, 
                      CONVERT(varchar, dbo.erp_studentprogress.Dispatchdate, 103) AS Dispatchdate, dbo.erp_studentprogress.Mark, 
                      dbo.erp_studentprogress.EvaluatedBy, CONVERT(varchar, dbo.erp_studentprogress.EvaluatedDate, 103) AS EvaluatedDate, 
                      dbo.erp_studentprogress.Remarks, dbo.erp_studentprogress.batchcode, dbo.erp_studentprogress.dateins
FROM         dbo.Submodule_details_new INNER JOIN
                      dbo.erp_studentprogress ON dbo.Submodule_details_new.ModuleId = dbo.erp_studentprogress.moduleid INNER JOIN
                      dbo.adm_personalparticulars ON dbo.erp_studentprogress.studentid = dbo.adm_personalparticulars.student_id AND 
                      dbo.erp_studentprogress.centrecode = dbo.adm_personalparticulars.centre_code INNER JOIN
                      dbo.projectdetails ON dbo.erp_studentprogress.projectid = dbo.projectdetails.projectid where 1=1 and centrecode='" + Session["SA_centre_code"] + "'  ";
        }
        else if (Session["SA_Centrerole"] .ToString() == "R&D" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            _Qry = @"SELECT DISTINCT 
                      dbo.erp_studentprogress.Status,dbo.erp_studentprogress.id,dbo.erp_studentprogress.projectid, dbo.Submodule_details_new.Module, dbo.adm_personalparticulars.enq_personal_name, 
                      dbo.erp_studentprogress.studentid, dbo.erp_studentprogress.projectguided_by, dbo.erp_studentprogress.centrecode, 
                      dbo.Submodule_details_new.ModuleId, dbo.projectdetails.projectname, CONVERT(varchar,dbo.erp_studentprogress.Senddate,103) AS Senddate, 
                      CONVERT(varchar, dbo.erp_studentprogress.Dispatchdate, 103) AS Dispatchdate, dbo.erp_studentprogress.Mark, 
                      dbo.erp_studentprogress.EvaluatedBy, CONVERT(varchar, dbo.erp_studentprogress.EvaluatedDate, 103) AS EvaluatedDate, 
                      dbo.erp_studentprogress.Remarks, dbo.erp_studentprogress.batchcode, dbo.erp_studentprogress.dateins
FROM         dbo.Submodule_details_new INNER JOIN
                      dbo.erp_studentprogress ON dbo.Submodule_details_new.ModuleId = dbo.erp_studentprogress.moduleid INNER JOIN
                      dbo.adm_personalparticulars ON dbo.erp_studentprogress.studentid = dbo.adm_personalparticulars.student_id AND 
                      dbo.erp_studentprogress.centrecode = dbo.adm_personalparticulars.centre_code INNER JOIN
                      dbo.projectdetails ON dbo.erp_studentprogress.projectid = dbo.projectdetails.projectid where 1=1";

        }
        if (ddlstatus.SelectedValue!="")
        {
            _Qry += " and erp_studentprogress.status='" + ddlstatus.SelectedValue + "'";
        }
        if (ddlsearchmodname.SelectedValue!="")
        {
            _Qry += " and Submodule_details_new.moduleid='" + ddlsearchmodname.SelectedValue + "'";
        }
        if(TextBox2.Text!="")
        {
            _Qry += " and studentid like '%" + TextBox2.Text + "%'";
        }
        string stdate = "";
        stdate = TextBox4.Text;
        string[] split = stdate.Split('-');
        stdate = split[2] + "/" + split[1] + "/" + split[0];
        string enddate = "";
        enddate = TextBox3.Text;
        string[] split2 = enddate.Split('-');
        enddate = split2[2] + "/" + split2[1] + "/" + split2[0];
        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            if (TextBox3.Text != "" && TextBox4.Text != "")
            {
                _Qry += " and EvaluatedDate between '" + stdate + "' and '" + enddate + "'";
            }
        }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            if (TextBox3.Text != "" && TextBox4.Text != "")
            {
                _Qry += " and senddate between '" + stdate + "' and '" + enddate + "'";
            }
        }
        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {

            _Qry += " and centrecode='" + Session["SA_centre_code"].ToString() + "'";
            
        }

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            if (GridView1.Columns.Count > 0)
            {
                GridView1.Columns[6].Visible = false;
            }
            else
            {
                GridView1.HeaderRow.Cells[6].Visible = false;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[6].Visible = false;
                }
            }
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Request.QueryString["studentid"] != "" || Request.QueryString["studentid"] != null)
            {
                fillgrid1();
                // Response.Write(" <script type='text/javascript'>jQuery(document).ready(function(){   jQuery('#ViewAssesment').tabs(); $('#ViewAssesment').tabs('select', 1);     });</script>");

                //Response.Redirect("Assesment.aspx?StudentID=" + Request.QueryString["studentid"] + "&&Projectid=" + Request.QueryString["projectid"] + "&&centrecode=" + Request.QueryString["centrecode"] + "#ViewAssesment");
            }
            else
            {
                fillgrid1();
            }
        }
    }


    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Faculty" || Session["SA_Centrerole"] .ToString() == "Region Head")
        {
            _Qry = @"SELECT DISTINCT 
                       dbo.Submodule_details_new.Module, dbo.adm_personalparticulars.enq_personal_name, 
                      dbo.erp_studentprogress.studentid, dbo.erp_studentprogress.projectguided_by, dbo.erp_studentprogress.centrecode, 
                      dbo.projectdetails.projectname, CONVERT(varchar,dbo.erp_studentprogress.Senddate,103) AS Senddate, 
                      CONVERT(varchar, dbo.erp_studentprogress.Dispatchdate, 103) AS Dispatchdate, dbo.erp_studentprogress.Mark, 
                      dbo.erp_studentprogress.EvaluatedBy, CONVERT(varchar, dbo.erp_studentprogress.EvaluatedDate, 103) AS EvaluatedDate, 
                      dbo.erp_studentprogress.Remarks, dbo.erp_studentprogress.batchcode, dbo.erp_studentprogress.Status,dbo.erp_studentprogress.dateins
FROM         dbo.Submodule_details_new INNER JOIN
                      dbo.erp_studentprogress ON dbo.Submodule_details_new.ModuleId = dbo.erp_studentprogress.moduleid INNER JOIN
                      dbo.adm_personalparticulars ON dbo.erp_studentprogress.studentid = dbo.adm_personalparticulars.student_id AND 
                      dbo.erp_studentprogress.centrecode = dbo.adm_personalparticulars.centre_code INNER JOIN
                      dbo.projectdetails ON dbo.erp_studentprogress.projectid = dbo.projectdetails.projectid where 1=1 and centrecode='" + Session["SA_centre_code"] + "'  ";
        }
        else if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            _Qry = @"SELECT DISTINCT 
                       dbo.Submodule_details_new.Module, dbo.adm_personalparticulars.enq_personal_name, 
                      dbo.erp_studentprogress.studentid, dbo.erp_studentprogress.projectguided_by, dbo.erp_studentprogress.centrecode, 
                       dbo.projectdetails.projectname, CONVERT(varchar,dbo.erp_studentprogress.Senddate,103) AS Senddate, 
                      CONVERT(varchar, dbo.erp_studentprogress.Dispatchdate, 103) AS Dispatchdate, dbo.erp_studentprogress.Mark, 
                      dbo.erp_studentprogress.EvaluatedBy, CONVERT(varchar, dbo.erp_studentprogress.EvaluatedDate, 103) AS EvaluatedDate, 
                      dbo.erp_studentprogress.Remarks, dbo.erp_studentprogress.batchcode,dbo.erp_studentprogress.Status, dbo.erp_studentprogress.dateins
FROM         dbo.Submodule_details_new INNER JOIN
                      dbo.erp_studentprogress ON dbo.Submodule_details_new.ModuleId = dbo.erp_studentprogress.moduleid INNER JOIN
                      dbo.adm_personalparticulars ON dbo.erp_studentprogress.studentid = dbo.adm_personalparticulars.student_id AND 
                      dbo.erp_studentprogress.centrecode = dbo.adm_personalparticulars.centre_code INNER JOIN
                      dbo.projectdetails ON dbo.erp_studentprogress.projectid = dbo.projectdetails.projectid where 1=1";

        }
        if (ddlstatus.SelectedValue != "")
        {
            _Qry += " and erp_studentprogress.status='" + ddlstatus.SelectedValue + "'";
        }
        if (ddlsearchmodname.SelectedValue != "")
        {
            _Qry += " and Submodule_details_new.moduleid='" + ddlsearchmodname.SelectedValue + "'";
        }
        if (TextBox2.Text != "")
        {
            _Qry += " and studentid like '%" + TextBox2.Text + "%'";
        }
        string stdate = "";
        stdate = TextBox4.Text;
        string[] split = stdate.Split('-');
        stdate = split[2] + "/" + split[1] + "/" + split[0];
        string enddate = "";
        enddate = TextBox3.Text;
        string[] split2 = enddate.Split('-');
        enddate = split2[2] + "/" + split2[1] + "/" + split2[0];
        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            if (TextBox3.Text != "" && TextBox4.Text != "")
            {
                _Qry += " and EvaluatedDate between '" + stdate + "' and '" + enddate + "'";
            }
        }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            if (TextBox3.Text != "" && TextBox4.Text != "")
            {
                _Qry += " and senddate between '" + stdate + "' and '" + enddate + "'";
            }
        }
        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {

            _Qry += " and centrecode='" + Session["SA_centre_code"].ToString() + "'";

        }

        DataTable dtgrid = new DataTable();
        dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);


       
      ExportTableData(dtgrid);

    }

    public void ExportTableData(DataTable dtdata)
    {
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Assesment.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid1();
    }
}
