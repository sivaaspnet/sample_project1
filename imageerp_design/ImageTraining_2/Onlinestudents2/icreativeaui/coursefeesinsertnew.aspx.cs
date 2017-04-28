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

public partial class coursefeesinsertnew : System.Web.UI.Page
{

    string _Qry;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            FillCentre(); 
            Fillregion();  
            FillCourse(); 
            ddl_course.Items.Insert(0, new ListItem("select", ""));
            ddl_course_search.Items.Insert(0, new ListItem("select", ""));
            fillnew();
        }
    }

    private void fillnew()
    {
        DataTable dtcourse = new DataTable();
        DataTable dtfees = new DataTable();
        DataTable dtfinal = new DataTable();
        DataView dvfinal = new DataView();
        try
        {
           // _Qry = "select * from img_centre_coursefee_details ccd inner join img_coursedetails cd on cd.course_id=ccd.program inner join img_centredetails cen on cen.centre_code=ccd.centre_code where cen.centre_code=ccd.centre_code ";
            _Qry = "select * from img_coursedetails where course_id>0";
            if (ddl_course_search.SelectedValue != "")
            {
                _Qry += " and course_id="+ddl_course_search.SelectedValue+"";
            }
            if (txt_keyword.Text != "")
            {
                _Qry += " and (program like '%" + txt_keyword.Text.Trim() + "%' or coursename like '%" + txt_keyword.Text.Trim() + "%')";
            }
           // Response.Write(_Qry + "<br>");
            dtcourse = MVC.DataAccess.ExecuteDataTable(_Qry);
            _Qry = "select *,case ccd.status when 1  then 'Enable' when 0 then  'Disable' end as centrestatus from img_centre_coursefee_details ccd inner join img_coursedetails cd on cd.course_id=ccd.program inner join img_centredetails cen on cen.centre_code=ccd.centre_code  where cd.course_id>0";
            if (ddl_course_search.SelectedValue != "")
            {
                _Qry += " and cd.course_id=" + ddl_course_search.SelectedValue + "";
            }
            if (ddl_centre_search.SelectedValue != "")
            {
                _Qry += " and ccd.centre_code='"+ddl_centre_search.SelectedValue+"'";
            }
            if (txt_keyword.Text != "")
            {
                _Qry += " and (cd.program like '%" + txt_keyword.Text.Trim() + "%' or cd.coursename like '%" + txt_keyword.Text.Trim() + "%')";
            }
           // Response.Write(_Qry + "<br>");
            dtfees = MVC.DataAccess.ExecuteDataTable(_Qry);

            dtfinal.Columns.Add(new DataColumn("coursename", System.Type.GetType("System.String")));
            dtfinal.Columns.Add(new DataColumn("program", System.Type.GetType("System.String")));
            dtfinal.Columns.Add(new DataColumn("courseid", System.Type.GetType("System.String")));
            dtfinal.Columns.Add(new DataColumn("coursedetails", System.Type.GetType("System.String")));
            DataRow dr = dtfinal.NewRow();
            foreach (DataRow drs in dtcourse.Rows)
            {
                dr = dtfinal.NewRow();
                dr["program"] = drs["program"];
                dr["coursename"] = drs["coursename"];// getfollodate(dtfillgrid, "EnquiryNumber='" + drs["EnquiryNumber"] + "'", "enqnumber");
                dr["courseid"] = drs["course_id"];// getfollodate(dtfillgrid, "EnquiryNumber='" + drs["EnquiryNumber"] + "'", "studentname");
                dr["coursedetails"] = getdetails(dtfees,"course_id="+drs["course_id"]+"");//getfollodate(dtfillgrid, "EnquiryNumber='" + drs["EnquiryNumber"] + "'", "Id");
                dtfinal.Rows.Add(dr);
            }
            Cache["dtfinal"] = dtfinal;
            gvcourse.DataSource = (DataTable)Cache["dtfinal"];
            gvcourse.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            dtcourse = null;
            dtfees = null;
            dtfinal = null;
            dvfinal = null;
        }        
    }

    string getdetails(DataTable dt, string expression)
    {
        string res = "<div style='max-height:213px; overflow:auto; padding:0px;'><table class='in-tbl'><tr><th>Centre </th><th>Track </th><th>Lump </th><th>Installment </th><th>Duration </th><th>Max.Install </th><th>Tax </th><th>Initial Amount </th><th>Status </th></tr>";
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res += "<tr><td>" + val["centre_location"] + " </td><td>" + val["track"] + " </td><td>" + val["lump_sum"] + " </td><td>" + val["instal_amount"] + " </td><td>" + val["duration"] + " </td><td>" + val["noofinstall"] + " </td><td>" + val["tax"] + " </td><td>" + val["initial_amount"] + " </td><td>" + val["centrestatus"] + " </td></tr>";
            }
			res += "</table>";
        }
        else
        {
            res = "<div style='font-weight:bold; text-align:center; padding:0px; color:#d00101; border: 1px solid #d1d1d1; border-top:0px; color: #d00101; height: 40px; line-height: 35px;'>No Centres assigned for this course";
        }
        res += "</div>";
        return res;
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
    }

    private void FillCentre()
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
            chk_centre.DataSource = dt;
            chk_centre.DataTextField = "centre_location";
            chk_centre.DataValueField = "centre_code";
            chk_centre.DataBind();
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
            ddl_course_search.DataSource = dt;
            ddl_course_search.DataTextField = "program";
            ddl_course_search.DataValueField = "course_id";
            ddl_course_search.DataBind();
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

    protected void Btnsubmit_Click(object sender, EventArgs e)
    { 
        if(ddl_course.SelectedValue!="")
        {
            foreach (ListItem ltcentre in chk_centre.Items)
            {
                if (ltcentre.Selected == true)
                {
                    if (chkfast.Checked)
                    {
                        _Qry = " select count(centre_code) from img_centre_coursefee_details where track='fast' and centre_code='" + ltcentre.Value + "' and program='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "'";
                        int countfast;
                        countfast = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        if (countfast > 0)
                        {
                            _Qry = @" UPDATE img_centre_coursefee_details set centre_code='" + ltcentre.Value + @"',program='" + ddl_course.SelectedValue + "',duration='" + ddlfastduration.SelectedValue + "',track='Fast',lump_sum='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfastlumpsum.Text) + "',instal_amount='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfastinstallamt.Text) + @"',initial_amount='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinitial_amount.Text) + "',tax='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfasttax.Text) + @"',
                            runningInvoiceCentreCode='" + ltcentre.Value + "',runningReceiptCentreCode='" + ltcentre.Value + "',status='" + ddlfaststatus.SelectedValue + "',dateupd=getdate(),noofinstall='" + txtfastmaxinstall.Text + @"'
                            where  track='fast' and centre_code='" + ltcentre.Value + "' and program='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "'";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = @"INSERT INTO img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,runningReceiptCentreCode,status,dateins,dateupd,noofinstall,initial_amount) values
                             ('" + ltcentre.Value + "','" + ddl_course.SelectedValue + "','" + ddlfastduration.SelectedValue + "','Fast','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfastlumpsum.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfastinstallamt.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfasttax.Text) + "','" + ltcentre.Value + "','" + ltcentre.Value + "','" + ddlfaststatus.SelectedValue + "',getdate(),getdate(),'" + txtfastmaxinstall.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinitial_amount.Text) + "')";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }

                    }
                    if (chknormal.Checked)
                    {
                        _Qry = " select count(centre_code) from img_centre_coursefee_details where track='normal' and centre_code='" + ltcentre.Value + " ' and program='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + " '";
                        int countnormal;
                        countnormal = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        if (countnormal > 0)
                        {
                            _Qry = @" UPDATE img_centre_coursefee_details set centre_code='" + ltcentre.Value + @"',program='" + ddl_course.SelectedValue + "',duration='" + ddlnormalduration.SelectedValue + "',track='Normal',lump_sum='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormallump.Text) + "',instal_amount='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormalinstallamt.Text) + @"',initial_amount='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinitial_amount.Text) + "',tax='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormaltax.Text) + @"',
                            runningInvoiceCentreCode='" + ltcentre.Value + "',runningReceiptCentreCode='" + ltcentre.Value + "',status='" + ddlnormalstatus.SelectedValue + "',dateupd=getdate(),noofinstall='" + txtnormalmaxinstall.Text + @"'
                            where  track='Normal' and centre_code='" + ltcentre.Value + "' and program='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_course.SelectedValue) + "'";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                        else
                        {
                            _Qry = @"INSERT INTO img_centre_coursefee_details (centre_code,program,duration,track,lump_sum,instal_amount,tax,runningInvoiceCentreCode,runningReceiptCentreCode,status,dateins,dateupd,noofinstall,initial_amount) values
                            ('" + ltcentre.Value + "','" + ddl_course.SelectedValue + "','" + ddlnormalduration.SelectedValue + "','Normal','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormallump.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormalinstallamt.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnormaltax.Text) + "','" + ltcentre.Value + "','" + ltcentre.Value + "','" + ddlnormalstatus.SelectedValue + "',getdate(),getdate(),'" + txtnormalmaxinstall.Text + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinitial_amount.Text) + "')";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                    }
                }
                else
                {
                    lblmsg1.Text = " Please Fill All The Values! ";
                }            
            }
        }
        else
        {
            lblmsg1.Text = " Please Fill All The Values! ";
        }
        refresh();
        fillnew();
    }


   private void refresh()
    {
        try
        {
            ddl_course.SelectedValue = "";
            chkfast.Checked = false;
            chknormal.Checked = false;
            txtfastinstallamt.Text = "";
            txtfastlumpsum.Text = "";
            txtfastmaxinstall.Text = "";
            txtfasttax.Text = "";
            txtnormalinstallamt.Text = "";
            txtnormallump.Text = "";
            txtnormalmaxinstall.Text = "";
            txtnormaltax.Text = "";
            ddl_course.SelectedValue = "";
            ddlfastduration.SelectedValue = "";
            ddlfaststatus.SelectedIndex = 0;
            ddlnormalduration.SelectedValue = "";
            ddlnormalstatus.SelectedIndex = 0;
            txtinitial_amount.Text = "";
            foreach (ListItem ltcentre in chk_centre.Items)
            {
                if (ltcentre.Selected == true)
                {
                    ltcentre.Selected = false;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillnew();
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
     //   GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void gvcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcourse.PageIndex = e.NewPageIndex;
        gvcourse.DataSource = (DataTable)Cache["dtfinal"];
        gvcourse.DataBind();
    }
    protected void gvcourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dtedit = new DataTable();
        refresh();
        try
        {
            if (e.CommandName == "edt")
            {
                ddl_course.SelectedValue = e.CommandArgument.ToString();
                _Qry = " select * from img_centre_coursefee_details where program=" + e.CommandArgument.ToString() + " ";
                dtedit = MVC.DataAccess.ExecuteDataTable(_Qry);
                int normalval=0, fastval = 0;
                if (dtedit.Rows.Count > 0)
                {
                    for (int i = 0; i < dtedit.Rows.Count; i++)
                    {
                        foreach (ListItem ltcentre in chk_centre.Items)
                        {
                            if (ltcentre.Value == dtedit.Rows[i]["centre_code"].ToString())
                            {
                                ltcentre.Selected = true;
                            }
                        }
                        if (normalval == 0 && dtedit.Rows[i]["track"].ToString().ToLower() == "normal")
                        {
                            chknormal.Checked = true;
                            txtnormalinstallamt.Text = dtedit.Rows[i]["instal_amount"].ToString();
                            txtnormallump.Text = dtedit.Rows[i]["lump_sum"].ToString();
                            txtnormalmaxinstall.Text = dtedit.Rows[i]["noofinstall"].ToString();
                            txtnormaltax.Text = dtedit.Rows[i]["tax"].ToString();
                            ddlnormalduration.SelectedValue = dtedit.Rows[i]["duration"].ToString();
                            ddlnormalstatus.SelectedValue = dtedit.Rows[i]["status"].ToString();
                            txtinitial_amount.Text=dtedit.Rows[0]["initial_amount"].ToString();
                            normalval = 1;
                        }
                        if (fastval == 0 && dtedit.Rows[i]["track"].ToString().ToLower() == "fast")
                        {
                            chkfast.Checked = true;
                            txtfastinstallamt.Text = dtedit.Rows[i]["instal_amount"].ToString();
                            txtfastlumpsum.Text = dtedit.Rows[i]["lump_sum"].ToString();
                            txtfastmaxinstall.Text = dtedit.Rows[i]["noofinstall"].ToString();
                            txtfasttax.Text = dtedit.Rows[i]["tax"].ToString();
                            ddlfastduration.SelectedValue = dtedit.Rows[i]["duration"].ToString();
                            ddlfaststatus.SelectedValue = dtedit.Rows[i]["status"].ToString();
                            txtinitial_amount.Text = dtedit.Rows[0]["initial_amount"].ToString();
                            fastval = 1;
                        }
                    }
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
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            dtedit = null;
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        refresh();
    }
}
