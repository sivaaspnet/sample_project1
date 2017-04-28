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

public partial class superadmin_ViewEnquiry : System.Web.UI.Page
{
    string _Qry;
    DataTable dtgrid = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalender.Text = mon;
            txttocalender.Text = DateTime.Now.ToString("dd-MM-yyyy");
            fillgrid();  
        }
        if (Request.QueryString["res"] == "ins")
        {
            lblmessage.Text = "The Follow up Details Inserted Successfully";
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            viewonly_to_sa.Visible = false;//row id
            //ddl_sa_cencode.Visible = true;
            if (!IsPostBack)
            {
                fill_cencode();//fill centre code
            }
        }
        else
        {
            viewonly_to_sa.Visible = false;
        }

       
    }



    private void fillgrid()
    {
        //if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
        //    //viewonly_to_sa.Visible = true;
        //    //ddl_sa_cencode.Visible = true;
        //    //_Qry = "select enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + ddl_sa_cencode.SelectedValue + "' ";

        //    _Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + ddl_sa_cencode.SelectedValue + "' ";

        //    if (txtfromcalender.Text != "" && txttocalender.Text != "")
        //    {
        //        string str = txtfromcalender.Text;
        //        string[] split = str.Split('-');
        //        string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

        //        string str1 = txttocalender.Text;
        //        string[] split1 = str1.Split('-');
        //        string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

        //        _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
        //    }
        //    if (ddl_sa_cencode.SelectedValue != "" && ddl_sa_cencode.SelectedValue != null)
        //    {
        //        _Qry = _Qry + "and f2.centre_code like '%" + ddl_sa_cencode.SelectedValue + "%'";
        //    }
        //    _Qry = _Qry + " order by enq.enq_id desc";
        //    //Response.Write(_Qry);
        //    //Response.End();
        //    DataTable dt = new DataTable();
        //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //    int ii = 0;
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        string Enq_Number = dt.Rows[ii]["enq_number"].ToString();

        //        _Qry = "Select * from adm_personalparticulars where enq_number='" + Enq_Number + "'";

        //        int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        //        if (count > 0)
        //        {
        //            DropDownList ddlstatus = new DropDownList();
        //            ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
        //            ddlstatus.Visible = false;

        //            Label lblstatus = new Label();
        //            lblstatus = (Label)row.FindControl("hdnstatus");
        //            lblstatus.Visible = true;

        //            Button btnupd = new Button();
        //            btnupd = (Button)row.FindControl("btnupd");
        //            btnupd.Visible = false;
        //        }
        //        else
        //        {
        //            DropDownList ddlstatus = new DropDownList();
        //            ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
        //            ddlstatus.Visible = true;

        //            Label lblstatus = new Label();
        //            lblstatus = (Label)row.FindControl("hdnstatus");
        //            lblstatus.Visible = false;

        //            Button btnupd = new Button();
        //            btnupd = (Button)row.FindControl("btnupd");
        //            btnupd.Visible = true;


        //            string lbl = ((Label)row.FindControl("hdnstatus")).Text;

        //            ddlstatus.SelectedValue = lbl;
        //        }
        //        ii = ii + 1;
        //    }
        //}
        //else
        //{


        //string _Qry100 = " select '<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>' as enqno from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number";
        // Response.Write(_Qry100);
        // Response.End();
        //        _Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,case enq.enq_personal_mobile when 'NULL' THEN ('<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link1''>'+enq.enq_number+'</a>') ELSE  enq.enq_number end  as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";


        //_Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,case enq.enq_personal_mobile when 'NULL' THEN ('<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link1''>'+enq.enq_number+'</a>')  end  as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

        /// _Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,case enq.enq_personal_mobile when 'NULL' THEN ('<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link1''>'+enq.enq_number+'</a>')  end  as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

        // _Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') when NULL THEN ('<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link1''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

        //_Qry = "select f2.Created_By,enq.enq_number,case enq.enq_personal_mobile when 'Ashok' THEN ('<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link1''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";
        //_Qry = "select  *  from adm_personalparticulars  where  ";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
             
        //}
        //else
        //{
        _Qry = @"select enq.enq_present_address,enq_present_city,enq_present_district,(select top 1 remark from img_followups where enq_number=enq.enq_number order by folloup_id desc)as remark,case when enq.enq_aboutimage='Others' then  enq.enq_aboutimage_others else enq.enq_aboutimage end as about ,f2.enq_student_profile,enq.enq_aboutimage,enq.enq_aboutimage_others,enq.enq_high_institution,enq.enq_high_qualification,enq.enq_personal_mobile,enq.enq_personal_email,c.program ,f2.Created_By,(select convert(varchar,max(reminderdate), 103) from img_followups where enq_number=enq.enq_number)as reminderdate,enq.enq_number,case isnull(adm.enq_number,'0')
 when '0' THEN '<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&width=600&height=325'' class=''link''>'+enq.enq_number+'</a>'
 ELSE case isnull(f2.enq_ref_name,'0') when '0' then '<a href=''UpdateEnquiry.aspx?end_id='+enq.enq_number+'&iframe=true&width=600&height=325'' class=''link1''>'+enq.enq_number+'</a>' 
else enq.enq_number end  end as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,
convert(varchar, f2.dateins, 103) as dateins 
from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_number=f2.enq_number and substring(enq.enq_number,1,3)<>'Old'
 and enq.centre_code=f2.centre_code left join adm_generalinfo as adm on
 enq.enq_number=adm.enq_number  inner join  img_coursedetails as c on
 c.course_id=f2.enq_coursepositioned  where f2.centre_code='" + Session["SA_centre_code"] + "'";

        if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Student Name")
        {
            _Qry += " and (enq.enq_personal_name like '%" + txtkeyword.Text.Trim() + "%') ";
        }
        else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "About Image")
        {
            _Qry += " and (enq.enq_aboutimage_others like '%" + txtkeyword.Text.Trim() + "%' or enq.enq_aboutimage like '%" + txtkeyword.Text.Trim() + "%') ";
        }
        else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Qualification")
        {
            _Qry += " and (enq.enq_high_qualification like '%" + txtkeyword.Text.Trim() + "%') ";
        }
        else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Institution")
        {
            _Qry += " and (enq.enq_high_institution like '%" + txtkeyword.Text.Trim() + "%') ";
        }
        else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Profile")
        {
            _Qry += " and (f2.enq_student_profile like '%" + txtkeyword.Text.Trim() + "%') ";
        }
        else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Area")
        {
            _Qry += " and (enq.enq_present_address like '%" + txtkeyword.Text.Trim() + "%' or enq_present_district like '%" + txtkeyword.Text.Trim() + "%' or enq_present_city like '%" + txtkeyword.Text.Trim() + "%') ";
        }
            //if (txtkeyword.Text.Trim() != "")
            //{
            //    _Qry += " and ( enq.enq_number like '%" + txtkeyword.Text.Trim() + "%' or enq_personal_name like '%" + txtkeyword.Text.Trim() + "%') ";
            //}
       
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            _Qry = _Qry + " order by enq.enq_id desc";

           // Response.Write(_Qry);
           // Response.End();
           
            dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);
			 if(dtgrid.Rows.Count<=0)
			{
			LnkDownlaodExcel.Visible=false;
			note.Visible=false;
			}
             else
             {
                 LnkDownlaodExcel.Visible = true;
                 note.Visible = true;
             }
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
            GridView2.DataSource = dtgrid;
            GridView2.DataBind();
            lblcount.Text = dtgrid.Rows.Count.ToString();
            //Response.Write(_Qry);
            //Response.End();

            int ii = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                string Enq_Number = dtgrid.Rows[ii]["enq_number"].ToString();

                _Qry = "Select count(*) from adm_personalparticulars where enq_number='" + Enq_Number + "'";
                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count > 0)
                {
                    DropDownList ddlstatus = new DropDownList();
                    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
                    ddlstatus.Visible = false;

                    Label lblstatus = new Label();
                    lblstatus = (Label)row.FindControl("hdnstatus");
                    lblstatus.Visible = true;
                    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

                    Button btnupd = new Button();
                    btnupd = (Button)row.FindControl("btnupd");
                    btnupd.Visible = false;
                }
                else
                {
                    DropDownList ddlstatus = new DropDownList();
                    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
                    ddlstatus.Visible = true;

                    Label lblstatus = new Label();
                    lblstatus = (Label)row.FindControl("hdnstatus");
                    lblstatus.Visible = false;

                    Button btnupd = new Button();
                    btnupd = (Button)row.FindControl("btnupd");
                    btnupd.Visible = true;


                    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

                    ddlstatus.SelectedValue = lbl;
					
                }
                ii = ii + 1;
            }

            //}



            //foreach (GridViewRow row in GridView1.Rows)
            //{

            //    DropDownList ddlstatus = new DropDownList();
            //    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
            //    ddlstatus.Visible = true;

            //    Label lblstatus = new Label();
            //    lblstatus = (Label)row.FindControl("hdnstatus");
            //    lblstatus.Visible = false;

            //    Button btnupd = new Button();
            //    btnupd = (Button)row.FindControl("btnupd");
            //    btnupd.Visible = true;

            //    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

            //    ddlstatus.SelectedValue = lbl;
            //}
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void btnupd_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string lbl = ((Label)row.FindControl("lblhdnmsg")).Text;
            _Qry = "Select count(*) from adm_personalparticulars where enq_number='" + lbl + "'";
                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count == 0)
                {
                    DropDownList ddlsta = new DropDownList();
                    ddlsta = (DropDownList)row.FindControl("ddlfollowstatus");
                    

                    //Response.Write("Status Is:" + ddlsta.SelectedValue);
                    //Response.Write("Msg Is:" + lbl);

                    if (ddlsta.Visible == true)
                    {
                        if (ddlsta.SelectedValue == "0" || ddlsta.SelectedValue == "" || ddlsta.SelectedValue == null)
                        {
                            Response.Write("");
                        }
                        else
                        {
                            _Qry = "update img_enquiryform1 set enq_enqstatus='" + ddlsta.SelectedValue + "' where enq_number='" + lbl + "'";
                            //Response.Write(_Qry);
                            //Response.End();
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            fillgrid();
                            lblmessage.Text = "The Enquiry Status has been Updated Successfully";
                        }
                    }
                }
        }
        //Response.End();
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    private void disablelink()
    {
        _Qry = "SELECT ifnull(adm.enq_number,0),case isnull(adm.enq_number,0) when '0' THEN enq.enq_number ELSE  ('<a> rel=''modal[]'' href=''WelcomeAdmission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') end  as enqno  from img_enquiryform AS enq LEFT join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.enq_number='"+hdnenqID.Value+"'";
   
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
       
    }
    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";
        DataTable dtddl = new DataTable();
        dtddl = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_sa_cencode.DataSource = dtddl;
        ddl_sa_cencode.DataValueField = "centre_code";
        ddl_sa_cencode.DataTextField = "centre_code";
        ddl_sa_cencode.DataBind();
        ddl_sa_cencode.Items.Insert(0, new ListItem("Select", ""));
    }





    protected void LnkDownlaodExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Enquiry-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView2.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //fillgrid();
       // ExportTableData(dtgrid);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtkeyword.Text);
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
        Response.AppendHeader("Content-Disposition", "attachment;filename=Enquiry-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write("" + dc.ColumnName + "\t");
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
}
