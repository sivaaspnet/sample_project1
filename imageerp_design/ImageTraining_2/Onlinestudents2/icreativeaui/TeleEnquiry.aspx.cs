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

public partial class superadmin_TeleEnquiry : System.Web.UI.Page
{
    string _Qry, _Qry1,_Qry2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Request.QueryString["res"] == "upd")
        {
            fillgrid();
            lblmessage.Text = "Enquiry Details Updated Successfully";
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalender.Text = mon;
            txttocalender.Text = DateTime.Now.ToString("dd-MM-yyyy");
            if (Request.QueryString["p"] != null)
            {
                if (Request.QueryString["p"].ToString() == "N")
                {
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    MultiView1.ActiveViewIndex = 1;
                }
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
            }
            fillcoursedropdown();
            fill_cencode();
            fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            viewonly_to_sa.Visible = true;//row id
            if (!IsPostBack)
            {
                fill_cencode();//fill centre code
                ddl_sa_cencode.SelectedValue = Session["SA_centre_code"].ToString();
                fillgrid();
            }
        }
        else
        {
            viewonly_to_sa.Visible = false;
        }
    }

    private void fillgrid()
    {
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            //viewonly_to_sa.Visible = true;
            //ddl_sa_cencode.Visible = true;
            //_Qry = "select enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + ddl_sa_cencode.SelectedValue + "' ";

            _Qry = "Select *,convert(varchar,max(reminderdate), 103)as reminderdate from TeleEnquiry a where PhoneNo NOT in (select enq_personal_mobile from img_enquiryform b where b.enq_personal_mobile=a.PhoneNo and b.enq_personal_name=a.EnquiryName  ) and centrecode='" + ddl_sa_cencode.SelectedValue + "' ";
             
            if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Student Name")
            {
                _Qry += " and enquiryname like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "About Image")
            {
                _Qry += " and sourse like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Profile")
            {
                _Qry += " and profile like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Mobile")
            {
                _Qry += " and MobileNo like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Area")
            {
                _Qry += " and Addr like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                _Qry = _Qry + " and dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }

            if (ddlStatus.SelectedValue != "")
            {
                _Qry += " And Status='" + ddlStatus.SelectedValue + "'";
            }

            _Qry = _Qry + "group by TeleEnquiryID,CentreCode,EnquiryName,EmailID,MobileNo,PhoneNo,Addr,CourseInterested,VisitCentre,Remarks,Status,Enquired_By,Modified_By,DateIns,DateMod,sourse,profile,reminderdate,referedstudentname order by TeleEnquiryID desc ";
          //Response.Write(_Qry);
           // Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Label5.Text = dt.Rows.Count.ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gvDownload.DataSource = dt;
            gvDownload.DataBind();
        }
        else
        {


            //string _Qry100 = " select '<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>' as enqno from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number";
            // Response.Write(_Qry100);
            // Response.End();
            _Qry = "Select *,convert(varchar,max(reminderdate), 103)as reminderdate from TeleEnquiry a where MobileNo NOT in (select enq_personal_mobile from img_enquiryform b where b.enq_personal_mobile=a.MobileNo  and b.enq_personal_name=a.EnquiryName  ) and centrecode='" + Session["SA_centre_code"] + "'";

            //  _Qry = "SELECT enq.enq_number,f1.enq_personal_name,enq.enq_enqstatus,enq.dateins,case when  ifnull(nri.enq_number,0) = '0' THEN case when  ifnull(adm.enq_number,0) = '0' THEN CONCAT('<a  href=''Admission.aspx?end_id=',enq.enq_number,'&iframe=true&amp;width=600&amp;height=325'' class=''link''>',enq.enq_number,'</a>')  ELSE  enq.enq_number end ELSE enq.enq_number   end as enqno from img_enquiryform1 enq inner join img_enquiryform f1 on enq.enq_number=f1.enq_number LEFT join adm_generalinfo adm on enq.enq_number=adm.enq_number LEFT join adm_nridetails nri on enq.enq_number=nri.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

            if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Student Name")
            {
                _Qry += " and enquiryname like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "About Image")
            {
                _Qry += " and sourse like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Profile")
            {
                _Qry += " and profile like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Mobile")
            {
                _Qry += " and MobileNo like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            else if (txtkeyword.Text.Trim() != "" && RadioButtonList1.SelectedValue == "Area")
            {
                _Qry += " and Addr like '%" + txtkeyword.Text.Trim() + "%' ";
            }
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + "and dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }

            if (ddlStatus.SelectedValue != "" && ddlStatus.SelectedValue != null)
            {
                _Qry += " And Status='" + ddlStatus.SelectedValue + "'";
            }

            _Qry = _Qry + "group by TeleEnquiryID,CentreCode,EnquiryName,EmailID,MobileNo,PhoneNo,Addr,CourseInterested,VisitCentre,Remarks,Status,Enquired_By,Modified_By,DateIns,DateMod,sourse,profile,reminderdate,referedstudentname order by TeleEnquiryID desc ";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Label5.Text = dt.Rows.Count.ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            gvDownload.DataSource = dt;
            gvDownload.DataBind();
            //Response.Write(_Qry);
            //Response.End();

        }

        //foreach (GridViewRow row in GridView1.Rows)
        //{

        //    DropDownList ddlstatus = new DropDownList();
        //    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
        //    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

        //    ddlstatus.SelectedValue = lbl;
        //}
    }


    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_sa_cencode.DataSource = dt;
        ddl_sa_cencode.DataValueField = "centre_code";
        ddl_sa_cencode.DataTextField = "centre_code";
        ddl_sa_cencode.DataBind();
        ddl_sa_cencode.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillcoursedropdown()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1 where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlCourse.DataSource = dt;
        ddlCourse.DataValueField = "Program";
        ddlCourse.DataTextField = "Program";
        ddlCourse.DataBind();
        ddlCourse.Items.Insert(0, new ListItem("Select", ""));

    }

    //public string removetilde(string str)
    //{
    //    return MVC.CommonFunction.ReplaceQuoteWithTild(str);

    //}
    //private void counselorinsert()
    //{
    //    if (hdnID.Value == "")
    //    {
    //        _Qry1 = "select count(centrelogin_id) from img_centrelogin where role='Counselor' and userid='" + txtcounselor_id.Text + "' or centre_useremail='" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "'";

    //        int count;
    //        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry1);
    //        if (count > 0)
    //        {
    //            lblmsg1.Text = "The Counselor UserID or Email Id Already Exist";
    //        }
    //        else
    //        {
    //            _Qry = "INSERT INTO img_centrelogin (centre_id,username,userid,password,role,centre_code,centre_category,centre_region,centre_useremail,createdby,updatedby,dateins,dateupd,centre_loginstatus)values('" + Session["SA_CenterID"] + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtEnquiryName.Text) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_id.Text) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_pwd.Text) + "','Counselor','" + Session["SA_centre_code"] + "','" + Session["SA_Centre_category"] + "','" + Session["SA_centre_region"] + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "','" + Session["SA_Username"] + "','Not Updated',getdate(),getdate(),'" + Session["SA_centre_loginstatus"] + "')";
    //            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
    //            fillgrid();
    //            lblmsg1.Text = "The Counselor Login Added Successfully";
    //        }
    //    }
    //    else
    //    {
    //        CounselorUpdate();
    //    }
    //}
    //private void fillgrid()
    //{
    //    _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where role='counselor' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceTildWithQuote(txtsearchname.Text) + "%' order by centrelogin_id desc";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    grdcounselor.DataSource = dt;
    //    grdcounselor.DataBind();
    //}
   
    //protected void grdcounselor_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "lnkdel")
    //    {
    //        _Qry = "Delete from img_centrelogin where centrelogin_id=" + e.CommandArgument.ToString() + "";
    //        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
    //        fillgrid();
    //        lblmsg1.Text = "The Counselor Login DELETED Successfully";
    //        refresh();
    //    }
    //    if (e.CommandName == "lnkedit")
    //    {
    //        _Qry = "select username,userid,password,centre_useremail,centrelogin_id from img_centrelogin where centrelogin_id="+e.CommandArgument.ToString()+"";
    //        DataTable dt = new DataTable();
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            txtEnquiryName.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["username"].ToString());
    //            txtcounselor_id.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["userid"].ToString());
    //            txtcounselor_pwd.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["password"].ToString());
    //            txtcounselor_email.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centre_useremail"].ToString());
    //            hdnID.Value = dt.Rows[0]["centrelogin_id"].ToString();

    //        }
    //    }

    //}
    //private void CounselorUpdate()
    //{
    //    if (hdnID.Value != "")
    //    {
    //        _Qry1 = "select count(centrelogin_id) from img_centrelogin where (role='Counselor' and userid='" + txtcounselor_id.Text + "' or centre_useremail='" + MVC.CommonFunction.ReplaceTildWithQuote(txtcounselor_email.Text) + "') and centrelogin_id<>" + hdnID.Value + "";
           
    //        int count;
    //        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry1);
    //        if (count > 0)
    //        {
    //            lblmsg1.Text = "The Counselor UserID or Email Id Already Exist";

    //        }
    //        else
    //        {
    //            _Qry = "update img_centrelogin set centre_id='" + Session["SA_CenterID"] + "',username='" + txtEnquiryName.Text + "',userid='" + txtcounselor_id.Text + "',password='" + txtcounselor_pwd.Text + "',centre_useremail='" + txtcounselor_email.Text + "' where centrelogin_id=" + hdnID.Value + "";
    //            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
    //            fillgrid();
    //            lblmsg1.Text = "The Counselor Login Has been UPDATED Successfully";
    //            refresh();          
    //       }
    //       hdnID.Value = "";
    //    }
    
    //}
    private void refresh()
    {
        txtEnquiryName.Text = "";
        txtEmailID.Text = "";
        txtMobile.Text = "";
        txtPhone.Text = "";
        txtAddr.Text = "";
        ddlCourse.SelectedValue = "";
        txtVisitcentre.Text = "";
        txtRemarks.Text = "";
        ddl_status.SelectedValue = "";
    }

    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
        _Qry = "Select Count(*) from TeleEnquiry Where (EnquiryName='" + MVC.CommonFunction.ReplaceTildWithQuote(txtEnquiryName.Text) + "' And EmailID='" + MVC.CommonFunction.ReplaceTildWithQuote(txtEmailID.Text) + "') OR (MobileNo='" + MVC.CommonFunction.ReplaceTildWithQuote(txtMobile.Text) + "')";

        int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        if (count > 0)
        {
            lblmsg1.Text = "Enquiry Details /Mobile Number Already Exists";
        }
        else
        {
            _Qry = "Insert into TeleEnquiry(CentreCode,EnquiryName,EmailID,MobileNo,PhoneNo,Addr,CourseInterested,VisitCentre,Remarks,Status,Enquired_By,DateIns,DateMod,sourse,profile,ReferedStudentName) values";
            _Qry += " ('" + Session["SA_centre_code"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtEnquiryName.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtEmailID.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtMobile.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtPhone.Text) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtAddr.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlCourse.SelectedValue) + "',";
            _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtVisitcentre.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtRemarks.Text) + "',";
            _Qry += " '" + ddl_status.SelectedValue + "','" + Session["SA_Username"].ToString() + "',getdate(),getdate(),'" + ddl_aboutimage.SelectedValue + "','" + ddl_profile.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentname.Text) + "')";

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            lblmessage.Text = "Enquiry Details Inserted Successfully";
            refresh();
            Response.Redirect("telethankyou.aspx");
           // MultiView1.ActiveViewIndex = 1;
          //  fillgrid();
        }
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            Session["SA_centre_code"] = ddl_sa_cencode.SelectedValue.ToString();
        }
        fillgrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void lnkManageProduct_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void lnkAddProduct_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnupd_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            DropDownList ddlsta = new DropDownList();
            ddlsta = (DropDownList)row.FindControl("ddlfollowstatus");
            string lbl = ((Label)row.FindControl("lblhdnmsg")).Text;

            if (ddlsta.SelectedValue == "0")
            {
                
            }
            else
            {
                _Qry = "update TeleEnquiry set Status='" + ddlsta.SelectedValue + "',DateMod=getdate() where TeleEnquiryID='" + lbl + "'";
                //Response.Write(_Qry);
                
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmessage.Text = "The Enquiry Status has been Updated Successfully";
                MultiView1.ActiveViewIndex = 1;
            }
        }
        //Response.End();
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"(`~=]+$");
        e.IsValid = rx.IsMatch(txtkeyword.Text);
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        fillgrid();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=TeleEnquiry-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvDownload.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
