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

public partial class Onlinestudents2_superadmin_CourseFeesInsert : System.Web.UI.Page
{

    string _Qry, _Qry1, _Qry2, _Qry3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCentre();
            FillCentreSearch();
            ddl_centre.Items.Insert(0, new ListItem("select", ""));
            ddl_runninginvoice.Items.Insert(0, new ListItem("select", ""));
            ddl_runningreceipt.Items.Insert(0, new ListItem("select", ""));
            Fillregion();            
        }

        if (!IsPostBack)
        {
            FillCourse();
            FillCourseSearch();
            Fillregion();
            ddl_course.Items.Insert(0, new ListItem("select", ""));
            ddl_course_search.Items.Insert(0, new ListItem("select", ""));
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_keyword.Text);
    }

   private void fillgrid()
    {

        // _Qry = "select replace(username,'~','''')as username,replace(userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id from img_centrelogin where role='Faculty' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centrelogin_id desc";


        _Qry = "select cen.centre_region,cen.centre_location,centrecourse_id,ccd.centre_code,cd.program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,runningReceiptCentreCode,case ccd.status when 1  then 'Enable' when 0 then  'Disable' end as status,noofinstall from img_centre_coursefee_details ccd inner join img_coursedetails cd on cd.course_id=ccd.program inner join img_centredetails cen on cen.centre_code=ccd.centre_code where cen.centre_code=ccd.centre_code  ";


        if (ddl_centre_search.SelectedValue != "" && ddl_course_search.SelectedValue != "")
        {
             //_Qry = _Qry + " where cen.centre_location like '%" + ddl_centre_search.SelectedItem + "%' and  cd.program like '%" + ddl_course_search.SelectedItem + "%' order by centrecourse_id desc";


            _Qry = _Qry + " and ccd.centre_code='" + ddl_centre_search.SelectedValue + "' and  ccd.program='" + ddl_course_search.SelectedValue + "' ";

            //Response.Write(_Qry);
            //Response.End();
        }

       if (ddl_centre_search.SelectedValue != "")
        {
            _Qry = _Qry + "and cen.centre_code like '%" + ddl_centre_search.SelectedValue + "%' ";


            //Response.Write(_Qry);
            //Response.End();

        }

       
       if (ddl_region.SelectedValue != "")
        {
            _Qry = _Qry + "and cen.centre_region like '%" + ddl_region.SelectedValue + "%' ";


            //Response.Write(_Qry);
            //Response.End();

        }
       
       if (ddl_course_search.SelectedValue != "")
        {
            //_Qry = _Qry + "where cd.course_id like '%" + ddl_course_search.SelectedValue + "%' order by centrecourse_id desc";

            _Qry = _Qry + "and ccd.program='" + ddl_course_search.SelectedValue + "' ";

            //Response.Write(_Qry);
            //Response.End();
        }

       
       if (txt_keyword.Text != "")
        {
            _Qry = _Qry + " and (cen.centre_location like '%" + txt_keyword.Text + "%' or cd.program like '%" + txt_keyword.Text + "%' or ccd.duration like '%" + txt_keyword.Text + "%' or ccd.track like '%" + txt_keyword.Text + "%' or ccd.lump_sum like '%" + txt_keyword.Text + "%' or ccd.instal_amount like '%" + txt_keyword.Text + "%') ";

            //Response.Write(_Qry);
            //Response.End();
        }


        //Response.Write(_Qry);
        //Response.End();
       

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void FillCentre()
    {
        _Qry = "select centre_code,centre_location from img_centredetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_centre.DataSource = dt;
            ddl_runninginvoice.DataSource = dt;
            ddl_runningreceipt.DataSource = dt;


            ddl_centre.DataTextField = "centre_location";
            ddl_runninginvoice.DataTextField = "centre_location";
            ddl_runningreceipt.DataTextField = "centre_location";

            
            ddl_centre.DataValueField = "centre_code";
            ddl_runninginvoice.DataValueField = "centre_code";
            ddl_runningreceipt.DataValueField = "centre_code";

            ddl_centre.DataBind();
            ddl_runninginvoice.DataBind();
            ddl_runningreceipt.DataBind();
        }
    }


    private void FillCentreSearch()
    {
        _Qry = "select centre_code,centre_location from img_centredetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_centre_search.DataSource = dt;


            ddl_centre_search.DataTextField = "centre_location";
            ddl_centre_search.DataValueField = "centre_code";

            ddl_centre_search.DataBind();

            ddl_centre_search.Items.Insert(0, new ListItem("select", ""));
           
        }
    }

    private void FillCourse()
    {
        _Qry = "select course_id,program from img_coursedetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_course.DataSource = dt;

            ddl_course.DataTextField = "program";
            ddl_course.DataValueField = "course_id";
            

            ddl_course.DataBind();
            
        }
    }


    private void Fillregion()
    {
        _Qry = "select distinct centre_region from img_centredetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        
        if (dt.Rows.Count > 0)
        {
             ddl_region.DataSource = dt;
             ddl_region.DataTextField = "centre_region";
             ddl_region.DataValueField = "centre_region";
             ddl_region.DataBind();
             ddl_region.Items.Insert(0, new ListItem("select", ""));
        }
    }


    private void FillCourseSearch()
    {
        _Qry = "select course_id,program from img_coursedetails";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_course_search.DataSource = dt;

            ddl_course_search.DataTextField = "program";
            ddl_course_search.DataValueField = "course_id";


            ddl_course_search.DataBind();

        }
    }


    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        if (Hidn_centerloginid.Value == "" || Hidn_centerloginid.Value == null)
        {


            _Qry3 = "select count(centre_code) from img_centre_coursefee_details where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_centre.SelectedValue) + " ' and program='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + " '";

            //Response.Write(_Qry3);
            //Response.End();

            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
            if (count > 0)
            {
                lblmsg1.Text = "Program already assiged to this centre";

                refresh();
            }


            else
            {
                //insert for Noraml
                _Qry = "INSERT INTO img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,runningReceiptCentreCode,status,dateins,dateupd,noofinstall) values('" + ddl_centre.SelectedValue + "','" + ddl_course.SelectedValue + "','" + ddl_duration.SelectedValue + "','Normal','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_lumpsum.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_installamount.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_tax.Text) + "','" + ddl_runninginvoice.SelectedValue + "','" + ddl_runningreceipt.SelectedValue + "','" + ddl_status.SelectedValue + "',getdate(),getdate(),'"+txtmaxinstall.Text.Trim()+"')";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                //insert for Fast
                _Qry1 = "INSERT INTO img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,runningReceiptCentreCode,status,dateins,dateupd,noofinstall) values('" + ddl_centre.SelectedValue + "','" + ddl_course.SelectedValue + "','" + ddl_duration.SelectedValue + "','Fast','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_lumpsum.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_installamount.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_tax.Text) + "','" + ddl_runninginvoice.SelectedValue + "','" + ddl_runningreceipt.SelectedValue + "','" + ddl_status.SelectedValue + "',getdate(),getdate(),'" + txtmaxinstall.Text.Trim() + "')";

                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                fillgrid();
                lblmsg1.Text = "Couse Fees Inserted sucessfully";
                refresh();
            }
        }
        else
        {
            //_Qry = "select count(centre_id) from ERP_SiteStatus where centre_id='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddlcentrename.SelectedValue) + " '";
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "Status details already exist";
            //}
            //else
            //{
            //update
            _Qry2 = "update img_centre_coursefee_details set centre_code='" + ddl_centre.SelectedValue + "',program='" + ddl_course.SelectedValue + "',duration='" + ddl_duration.SelectedValue + "',lump_sum='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_lumpsum.Text) + "',instal_amount='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_installamount.Text) + "',tax='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_tax.Text) + "',runningInvoiceCentreCode='" + ddl_runninginvoice.SelectedValue + "',runningReceiptCentreCode='" + ddl_runningreceipt.SelectedValue + "',status='" + ddl_status.SelectedValue + "',dateupd=getdate(),noofinstall='" + txtmaxinstall.Text.Trim() + "' where centrecourse_id=" + Hidn_centerloginid.Value + " ";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
            fillgrid();
            lblmsg1.Text = "Course details has been updated Successfully";
            refresh();
            Hidn_centerloginid.Value = "";
            //}
        } 

    }


   private void refresh()
    {
        ddl_centre.SelectedValue = "";

        ddl_course.SelectedValue = "";

        ddl_duration.SelectedValue = "";
        txtmaxinstall.Text = "";
       
        txt_lumpsum.Text = "";

        txt_installamount.Text = "";

        txt_tax.Text = "";

        ddl_runninginvoice.SelectedValue = "";

        ddl_runningreceipt.SelectedValue = "";

        ddl_status.SelectedValue = "";

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select centrecourse_id,centre_code,program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,noofinstall,runningReceiptCentreCode,status,convert(varchar, ccd.dateins, 103) as dateins from img_centre_coursefee_details ccd where centrecourse_id=" + e.CommandArgument.ToString() + "";


            //Response.Write(_Qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                Hidn_centerloginid.Value = dt.Rows[0]["centrecourse_id"].ToString();
                txtmaxinstall.Text = dt.Rows[0]["noofinstall"].ToString();
                ddl_centre.SelectedValue = dt.Rows[0]["centre_code"].ToString();
                ddl_course.SelectedValue = dt.Rows[0]["program"].ToString();
                ddl_duration.SelectedValue = dt.Rows[0]["duration"].ToString();
                txt_lumpsum.Text = dt.Rows[0]["lump_sum"].ToString();
                txt_installamount.Text = dt.Rows[0]["instal_amount"].ToString();
                txt_tax.Text = dt.Rows[0]["tax"].ToString();
                lbltrack.Text = "Track - "+ dt.Rows[0]["track"].ToString();
                ddl_runninginvoice.SelectedValue = dt.Rows[0]["runningInvoiceCentreCode"].ToString();
                ddl_runningreceipt.SelectedValue = dt.Rows[0]["runningReceiptCentreCode"].ToString();
                ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();                
                lblmsg1.Text = "";
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from img_centre_coursefee_details where centrecourse_id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "Course Details has been Deleted Successfully";
            refresh();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Course-Fees.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
