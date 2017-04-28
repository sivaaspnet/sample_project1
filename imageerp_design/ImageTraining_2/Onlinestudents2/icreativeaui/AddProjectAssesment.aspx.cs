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

public partial class superadmin_AddProjectAssesment : System.Web.UI.Page
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
            FillBatchCode();
        }
    }
    private void FillBatchCode()
    {
        _Qry = "Select Batch_Code From Batch_Details Where Batch_StudentId Not In (Select StudentId From ProjectAssesment Where StudentId=Batch_StudentId And Module=Batch_Module_Content) Group By Batch_Code ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlsearchBatch.DataSource = dt;
        ddlsearchBatch.DataTextField = "Batch_Code";
        ddlsearchBatch.DataValueField = "Batch_Code";
        ddlsearchBatch.DataBind();
        ddlsearchBatch.Items.Insert(0, new ListItem("Select", ""));
    }
    public string removetilde(string str)
    {
       return MVC.CommonFunction.ReplaceQuoteWithTild(str);
      
    }
    private void fillgrid()
    {
        _Qry = "Select Batch_StudentId,Batch_Module_Content,(select (enq_personal_name+' '+student_lastname) as StudentName From ";
        _Qry += " adm_personalparticulars Where student_id=Batch_StudentId) as StudentName,";
        _Qry += "(Select Program From img_coursedetails Where Course_id=Batch_Coursename) as Course";
        _Qry += " From Batch_Details";
        _Qry += " Where Batch_Code='" + ddlsearchBatch.SelectedValue + "' And Batch_StudentId Not In (Select StudentId From ";
        _Qry += " ProjectAssesment Where StudentId=Batch_StudentId And Module=Batch_Module_Content)";
        _Qry += " Group By Batch_StudentId,Batch_Module_Content,Batch_Coursename";


        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            btnstudents.Visible = true;
            provis.Visible = true;
        }
        else
        {
            tblbatch.Visible = false;
            FillBatchCode();
            provis.Visible = false;
            btnstudents.Visible = false;
        }
        //Response.Write(_Qry);
        //Response.End();
        Gridvw.DataSource = dt;
        Gridvw.DataBind();
        if (dt.Rows.Count > 0)
        {
            //Gridvw.PageSize = dt.Rows.Count;
        }
    }
    //private void insertcentre()
    //{
    //    if ((hdnID.Value == "" || hdnID.Value == null) && (hdnID1.Value == "" || hdnID1.Value == null))
    //    {
    //        _Qry = "select count(ProjectId) from ProjectAssesment where StudentId='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "' And Module='" + ddlmodname.SelectedItem.ToString() + "'";
    //        //Response.Write(_Qry);
    //        //Response.End();
    //        int count;
    //        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
    //        if (count > 0)
    //        {
    //            lblmsg1.Text = "The ProjectAssesment Already Exist";

    //        }
    //        else
    //        {
    //            _Qry = "insert into ProjectAssesment(StudentId,StudentName,CentreID,Course,Module,ProjectGuidedBy,Senddate,Dispatchdate,EvaluatedBy,EvaluatedDate,Remarks,Status)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentName.Text) + "','" + Session["SA_centre_code"] + "','" + ddlcourse.SelectedItem.ToString() + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlmodname.SelectedItem.ToString()) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtproject.Text) + "',getdate(),'','','','','Pending')";
    //            //Response.Write(_Qry);
    //            //Response.End();
    //            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    //            lblmsg1.Text = "ProjectAssesment Inserted Successfully";
    //        }
    //    }
    //    fillgrid();
    //}
    
   
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
    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{
    //    //centreupdate();
    //    _Qry = "Select count(*) from Batch_details where Batch_studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "' And Batch_Module_Id=" + ddlmodname.SelectedValue + " And Centre_Code='" + Session["SA_centre_code"] + "'";
       
    //    int bbcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

    //    if (bbcount > 0)
    //    {
    //        _Qry = "Select Course_Id From img_coursedetails Where Program='" + ddlcourse.SelectedItem.ToString() + "'";
    //        DataTable dt1 = new DataTable();
    //        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt1.Rows.Count > 0)
    //        {
    //            _Qry = "Select Count(*) From adm_generalinfo Where Student_Id='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_StudentId.Text) + "' And Coursename=" + dt1.Rows[0]["Course_Id"].ToString() + "";
    //            //Response.Write(_Qry);
    //            //Response.End();
    //            int cccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
    //            if (cccount > 0)
    //            {
    //                insertcentre();
    //                refresh();
    //            }
    //            else
    //            {
    //                lblmsg1.Text = "The Mentioned Student Information is wrong";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblmsg1.Text = "The Mentioned Student Information is wrong";
    //    }

    //    //insertcentre();
    //    //refresh();
    //}
    //protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdcentre.PageIndex = e.NewPageIndex;
    //    fillgrid();
    //}
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        _Qry = "Select Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,Batch_Time,convert(varchar(10),Batch_Startdate,111) as Batch_Startdate,convert(varchar(10),Batch_enddate,111) as Batch_Enddate ";
        _Qry += " From Batch_Details Where Batch_Code='" + ddlsearchBatch.SelectedValue + "' And Batch_Status<>'Completed' Group By Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,";
        _Qry += "Batch_Time,Batch_Startdate,Batch_Enddate";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            txt_BatchTrack.Text = dt.Rows[0]["Batch_Track"].ToString();
            txt_Module.Text = dt.Rows[0]["batch_Module_content"].ToString();
            txt_Faculty.Text = dt.Rows[0]["batch_Faculty"].ToString();
            txt_Lab.Text = dt.Rows[0]["batch_LabName"].ToString();
            txt_BatchSlot.Text = dt.Rows[0]["Batch_Slot"].ToString();
            txt_BatchTime.Text = dt.Rows[0]["Batch_Time"].ToString();
            txt_Bstart.Text = dt.Rows[0]["Batch_Startdate"].ToString();
            txt_Bend.Text = dt.Rows[0]["Batch_Enddate"].ToString();
        }
        else
        {
            tblbatch.Visible = false;
        }
        fillgrid();
    }
    protected void Gridvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //Find the checkbox control in header and add an attribute
            ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
                    ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
        }

    }
    
    protected void btnstudents_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow roww in Gridvw.Rows)
        {
            CheckBox chbox = new CheckBox();
            chbox = (CheckBox)roww.FindControl("CheckBox1");
            if (chbox.Checked == true)
            {
                Label lbl = new Label();
                lbl = (Label)roww.FindControl("lbl_stdid");
                string stdid = lbl.Text;

                Label lblname = new Label();
                lblname = (Label)roww.FindControl("lbl_stdname");
                string stdname = lblname.Text;

                Label lblm = new Label();
                lblm = (Label)roww.FindControl("lbl_Module");
                string module = lblm.Text;

                Label lb_course = new Label();
                lb_course = (Label)roww.FindControl("lbl_coursename");
                string course = lb_course.Text;

                _Qry = "select count(ProjectId) from ProjectAssesment where StudentId='" + MVC.CommonFunction.ReplaceQuoteWithTild(stdid) + "' And Module='" + module + "'";
                //Response.Write(_Qry);
                //Response.End();
                int count;
                count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count > 0)
                {
                    lblmsg1.Text = "The ProjectAssesment Already Exist";

                }
                else
                {
                    _Qry = "insert into ProjectAssesment(StudentId,StudentName,CentreID,Course,Module,ProjectGuidedBy,Senddate,Dispatchdate,EvaluatedBy,EvaluatedDate,Remarks,Status,Mark)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(stdid) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(stdname) + "','" + Session["SA_Location"] + "','" + course + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(module) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtProjectGuide.Text) + "',getdate(),'','','','','Pending','')";
                    //Response.Write(_Qry);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    lblmsg1.Text = "ProjectAssesment Inserted Successfully";
                }
            }
        }
        txtProjectGuide.Text = "";
        //FillBatchCode();
        fillgrid();
    }
    protected void Gridvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridvw.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
