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
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

public partial class superadmin_createnewBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, centrcode, couname, couid, todate, holdate;

  

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            displaycourseonload();
           
         
        }
       
    }




    private void displaycourseonload()
    {
        _Qry = "SELECT Module_Id,Replace(Module_Content,'~','''') as Module_Content from Module_Details ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
       // hdnModule.Value = dt.Rows[0]["Module_Content"].ToString();
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }




    //protected void btn_Movestudent_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        foreach (GridViewRow roww in Gridvw.Rows)
    //        {
    //            CheckBox chbox = new CheckBox();
    //            chbox = (CheckBox)roww.FindControl("CheckBox1");
    //            if (chbox.Checked == true)
    //            {
    //                Label lbl = new Label();
    //                lbl = (Label)roww.FindControl("lbl_stdid");
    //                stdid = lbl.Text;


    //                if (Convert.ToInt32(hdnfree.Value) <= 0)
    //                {
    //                    lblmsg1.Text = "System unavalaible";
    //                }
    //                else
    //                {
    //                    _Qry = "select subcontent_id,classdate from erp_batchcontentstatus where batchcode='" + ddl_batchcode2.SelectedValue + "'";
    //                    DataTable dt = new DataTable();
    //                    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //                    for (int i = 0; i < dt.Rows.Count; i++)
    //                    {
    //                        subcontentid = dt.Rows[i]["subcontent_id"].ToString();
    //                        clsdate = dt.Rows[i]["classdate"].ToString();
    //                        _Qry = @"INSERT INTO [erp_batchschedule] ([studentId],[facultyId],[labId],[classDate],[batchCode],[batchTiming] ,[subContentId],[centrecode],[status],[dateins]) VALUES ('" + stdid + "','" + fac_id.Text + "','" + lab_id.Text + "','" + clsdate + "','" + ddl_batchcode2.SelectedValue + "','" + lbl_timing.Text + "' ," + subcontentid + ",'" + Session["SA_centre_code"].ToString() + "','Pending',getdate())";
    //                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

    //                    }
    //                    _Qry = " update adm_generalinfo set Track='Batched' where student_id='" + stdid + "' and centre_code='" + Session["SA_centre_code"] + "'";
    //                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    //                    lblmsg1.Text = "Batch Created Successfully";
    //                    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert('Batched Changed !..');</script>");

    //                }

    //            }

    //        }
    //        lblmsg1.Text = "Batch Created Successfully";
    //        fillgrid();
    //        runningbatch();

    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg1.Text = ex.ToString();
    //    }


    //}

    protected void Gridvw_PageIndexChanging1(object sender, GridViewPageEventArgs e)
   {
    //    Gridvw.PageIndex = e.NewPageIndex;
    //    fillgrid();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        fillstudent();
    }

    private void fillstudent()
    {
        _Qry = @"  SELECT  distinct    erp_batchschedule.studentId, adm_personalparticulars.enq_personal_name, Submodule_details_new.Module, erp_batchschedule.status
FROM         erp_batchdetails INNER JOIN
                      Submodule_details_new ON erp_batchdetails.moduleId = Submodule_details_new.ModuleId INNER JOIN
                      erp_batchschedule ON erp_batchdetails.batchCode = erp_batchschedule.batchCode AND 
                      erp_batchdetails.centreCode = erp_batchschedule.centrecode and ((erp_batchschedule.status <> 'Pending') and (erp_batchschedule.status <> 'Repending')) INNER JOIN
                      adm_personalparticulars ON erp_batchschedule.studentId = adm_personalparticulars.student_id AND 
                      erp_batchschedule.centrecode = adm_personalparticulars.centre_code where erp_batchdetails.moduleId ='" + ddl_coursename.SelectedValue + "' and erp_batchschedule.centrecode='"+Session["SA_centre_code"]+"'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridvw.DataSource = dt;
        Gridvw.DataBind();
        tblstudent.Visible = true;
    }

}

