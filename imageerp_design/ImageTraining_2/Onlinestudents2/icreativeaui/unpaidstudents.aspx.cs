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
using System.IO;
using System.Text;
using System.Globalization;

public partial class unpaidstudents : System.Web.UI.Page
{
    string _Qry; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }

    private string amts(double amountvalue)
    {
        string words;
        amountvalue = Math.Round(amountvalue);
        if (amountvalue >= 10000000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = "Rs " + amountvalue.ToString("#,000");
        }
        return words;
    }

    #region fill grid
    private void fillgrid()
    {
        DataTable dtstudents = new DataTable();
        try
        {
            _Qry = @"select * from erp_installamountdetails ins inner join erp_receiptdetails rec on rec.studentid=ins.studentid and rec.invoiceno=ins.invoiceno and ins.status='pending' and datediff(d,ins.installdate,getdate())>=60 where rec.studentid in ( 
                select rec.studentid from erp_receiptdetails rec inner join erp_invoicedetails inv on inv.studentid=rec.studentid and inv.invoiceid=rec.invoiceno  where inv.centercode='" + Session["SA_centre_code"].ToString() + @"' group by rec.studentid,invoiceid having max(coursefees)>sum(amount))";
            _Qry = @"select convert(varchar,max(inv.dateins),103) as doj,rec.studentid,max(enq_personal_name) as Studentname,rec.invoiceno,max(cou.program) as coursename,max(inv.coursefees) as coursefees,sum(rec.amount) as paidamount,convert(varchar,max(rec.dateins),103) as lastpaiddate,max(rec.dateins) as dateindb,max(inv.coursefees)-sum(rec.amount) as pendingamount from 
                    erp_receiptdetails rec inner join erp_invoicedetails inv on inv.invoiceid=rec.invoiceno and inv.studentid=rec.studentid and inv.status='active' and inv.studentstatus='active' inner join adm_personalparticulars per on per.student_id=inv.studentid 
                    inner join img_coursedetails cou on inv.courseid=cou.course_id where rec.studentid in 
                    ( select rec.studentid from erp_receiptdetails rec inner join erp_invoicedetails inv on inv.studentid=rec.studentid and inv.invoiceid=rec.invoiceno where inv.centercode='" + Session["SA_centre_code"].ToString() + @"' and rec.studentid not in (select studentid from erp_unpaidlist where status=0 and invoiceno=rec.invoiceno and inv.status='active') group by rec.studentid,invoiceid having max(coursefees)>sum(amount)) group by rec.studentid,rec.invoiceno having datediff(d,max(rec.dateins),getdate())>=60 ";
            //Response.Write(_Qry);
            dtstudents = MVC.DataAccess.ExecuteDataTable(_Qry);
            lblcount.Text = dtstudents.Rows.Count.ToString()+" Students Found";
            Cache["dtstudents"] = dtstudents;
            Gridview_admission.DataSource = (DataTable)Cache["dtstudents"];
            Gridview_admission.DataBind();
            gv_download.DataSource = (DataTable)Cache["dtstudents"];
            gv_download.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            dtstudents = null;
        }
    }
    #endregion

    #region grid view page index changing
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        Gridview_admission.DataSource = (DataTable)Cache["dtstudents"];
        Gridview_admission.DataBind();
    }
    #endregion

    #region splitdate function
    string splitdate(string datevalue)
    {
        string res = "";
        string[] getdateval = datevalue.Split('-');
        res = getdateval[1] + "-" + getdateval[0] + "-" + getdateval[2];
        return res;
    }
    #endregion

   
    #region button search click event
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataTable dtstudents = new DataTable();
            DataView dvstudents = new DataView();
            try
            {
                dtstudents = (DataTable)Cache["dtstudents"];
                dvstudents = dtstudents.DefaultView;
                if (txtkeywords.Text.Trim() != "")
                {
                    dvstudents.RowFilter = "studentname like '%" + txtkeywords.Text + "%' or studentid like '%" + txtkeywords.Text + "%'";
                }
                if (txtfromdate.Text != "" && txttodate.Text != "")
                {
                    string fromdate = splitdate(txtfromdate.Text.Trim());
                    string todate = splitdate(txttodate.Text.Trim());
                    string s = String.Format(new CultureInfo("en-us").DateTimeFormat, "dateindb >=#{0:d}# and dateindb <=#{1:d}#", fromdate, todate);
                    dvstudents.RowFilter = s;
                }
                if (txtkeywords.Text.Trim() == "" && txtfromdate.Text == "" && txttodate.Text == "")
                {
                    dvstudents.RowFilter = "";
                }
                Gridview_admission.DataSource = dvstudents;
                Gridview_admission.DataBind();
                lblcount.Text = dvstudents.Count.ToString() + " Students Found";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                dtstudents = null;
                dvstudents = null;
            }
        }
    }
    #endregion

    #region gridview row command
    protected void Gridview_admission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Break")
        {
            string[] commandargs = e.CommandArgument.ToString().Split('~');
            string studentid = commandargs[1].ToString();
            string invoiceid = commandargs[0].ToString();
            DataTable dtstudents = new DataTable();
            DataView dvstudents = new DataView();
            try
            {
                dtstudents = (DataTable)Cache["dtstudents"];
                DataRow[] drr = dtstudents.Select("invoiceno='" + invoiceid + "' ");
                for (int i = 0; i < drr.Length; i++)
                {
                    _Qry = " update erp_invoicedetails set status='NP',studentstatus='NP' where  studentid='" + studentid + "' and invoiceid='" + invoiceid + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
                    _Qry += " if not exists(select studentid from erp_unpaidlist where studentid='" + studentid + "' and invoiceno='" + invoiceid + "') begin insert into erp_unpaidlist(studentid,centrecode,invoiceno,status,dateins,datemod) values ('" + studentid + "','" + Session["SA_centre_code"].ToString() + @"','"+invoiceid+"',0,getdate(),getdate()) end";
                    int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (count > 0)
                    {
                        drr[i].Delete();
                    }
                }
                dtstudents.AcceptChanges();
                Cache["dtstudents"] = dtstudents;
                dvstudents = dtstudents.DefaultView;
                Gridview_admission.DataSource = dvstudents;
                Gridview_admission.DataBind();
                lblcount.Text = dvstudents.Count.ToString() + " Students Found";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                dtstudents = null;
                dvstudents = null;
            }
        }
        else if (e.CommandName == "drop")
        {
            reason.Style.Add("display", "block");
            lblreason.Text = " Drop";
            hdntype.Value = "single";
            txtreason.Focus();
            btnfinal.Text = " Drop Student";
            btnfinal.CommandArgument = e.CommandArgument.ToString();
        }
        else if (e.CommandName == "bre")
        {
            reason.Style.Add("display", "block");
            lblreason.Text = " Break";
            hdntype.Value = "single";
            txtreason.Focus();
            btnfinal.Text = " Break Student";
            btnfinal.CommandArgument = e.CommandArgument.ToString();
        }
    }
    #endregion

    #region button send unpaid click event
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dtstudents = new DataTable();
        DataView dvstudents = new DataView();
        try
        {
            if (Gridview_admission.Rows.Count > 0)
            {
                foreach (GridViewRow gr in Gridview_admission.Rows)
                {
                    CheckBox chkstudent = (CheckBox)gr.FindControl("chkstudent");
                    HiddenField hdnstudentid = (HiddenField)gr.FindControl("hdnstudentid");
                    HiddenField hdninvoiceid = (HiddenField)gr.FindControl("hdninvoiceid");
                    dtstudents = (DataTable)Cache["dtstudents"];
                    if (chkstudent.Checked)
                    {
                        DataRow[] drr = dtstudents.Select("invoiceno="+ hdninvoiceid.Value +" and studentid='"+hdnstudentid.Value+"' ");
                        for (int i = 0; i < drr.Length; i++)
                        {
                            _Qry = " update erp_invoicedetails set status='NP',studentstatus='NP' where  studentid='" + hdnstudentid.Value + "' and invoiceid='" + hdninvoiceid.Value + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
                            _Qry += " if not exists(select studentid from erp_unpaidlist where studentid='" + hdnstudentid.Value + "' and invoiceno='" + hdninvoiceid.Value + "') begin insert into erp_unpaidlist(studentid,centrecode,invoiceno,status,dateins,datemod) values ('" + hdnstudentid.Value + "','" + Session["SA_centre_code"].ToString() + @"','" + hdninvoiceid.Value + "',0,getdate(),getdate()) end";
                            int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            if (count > 0)
                            {
                                drr[i].Delete();
                            }
                        }
                        dtstudents.AcceptChanges();
                    }
                }
                Cache["dtstudents"] = dtstudents;
                dvstudents = dtstudents.DefaultView;
                Gridview_admission.DataSource = dvstudents;
                Gridview_admission.DataBind();
                lblcount.Text = dvstudents.Count.ToString() + " Students Found";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            dtstudents = null;
            dvstudents = null;
        }
    }
    #endregion

    #region button break and drop click
    protected void btnfinal_Click(object sender, EventArgs e)
    {
        string typevalue = lblreason.Text.ToLower().Trim();
        if (hdntype.Value.ToLower() == "multi")
        {
            typevalue = hdnreason.Value.ToLower().Trim();
            DataTable dtstudents = new DataTable();
            DataView dvstudents = new DataView();
            try
            {
                if (Gridview_admission.Rows.Count > 0)
                {
                    foreach (GridViewRow gr in Gridview_admission.Rows)
                    {
                        CheckBox chkstudent = (CheckBox)gr.FindControl("chkstudent");
                        HiddenField hdnstudentid = (HiddenField)gr.FindControl("hdnstudentid");
                        HiddenField hdninvoiceid = (HiddenField)gr.FindControl("hdninvoiceid");
                        string studentid = hdnstudentid.Value;
                        dtstudents = (DataTable)Cache["dtstudents"];
                        if (chkstudent.Checked)
                        {
                            DataRow[] drr = dtstudents.Select("invoiceno='" + hdninvoiceid.Value + "' and studentid='" + hdnstudentid.Value + "' ");
                            for (int i = 0; i < drr.Length; i++)
                            {
                                if (typevalue == "drop")
                                {
                                    _Qry = "update adm_personalparticulars set studentstatus='Dropped',remarks='" + txtreason.Text + "' where student_id='" + studentid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                                    _Qry += "update erp_batchschedule set remarks= 'Student Dropped - '+'" + txtreason.Text + "' ,batchstatus='Dropped' where studentid='" + studentid + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
                                    _Qry += "insert into erp_studentdrop (studentid,reason,droppeddate,requesteddate,status,centercode,invoiceno) values ('" + studentid + "','" + txtreason.Text + "',getdate(),getdate(),'Dropped','" + Session["SA_centre_code"] + "' ,'"+hdninvoiceid.Value+"') ";
                                    _Qry += "update erp_invoicedetails set status='deactive',studentstatus='deactive' where studentid='" + studentid + "' and centercode='" + Session["SA_centre_code"] + "' and status='active'";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                }
                                else if (typevalue == "break")
                                {
                                    _Qry = "update adm_personalparticulars set studentstatus='Break',remarks='" + txtreason.Text + "' where student_id='" + studentid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                                    _Qry += "update erp_batchschedule set remarks= 'Student Break - '+'" + txtreason.Text + "' ,batchstatus='Break' where studentid='" + studentid + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
                                    _Qry += "insert into erp_studentdrop (studentid,reason,droppeddate,requesteddate,status,centercode,invoiceno) values ('" + studentid + "','" + txtreason.Text + "',getdate(),getdate(),'Break','" + Session["SA_centre_code"] + "' ,'"+hdninvoiceid.Value+"') ";
                                    _Qry += "update erp_invoicedetails set status='deactive',studentstatus='deactive' where studentid='" + studentid + "' and centercode='" + Session["SA_centre_code"] + "' and status='active'";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                }
                                drr[i].Delete();
                            }
                            dtstudents.AcceptChanges();
                        }
                    }
                    Cache["dtstudents"] = dtstudents;
                    dvstudents = dtstudents.DefaultView;
                    Gridview_admission.DataSource = dvstudents;
                    Gridview_admission.DataBind();
                    lblcount.Text = dvstudents.Count.ToString() + " Students Found";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                dtstudents = null;
                dvstudents = null;
            }
        }
        else if (hdntype.Value.ToLower() == "single")
        {
            string[] commandargs = btnfinal.CommandArgument.ToString().Split('~');
            string studentid = commandargs[1].ToString();
            string invoiceid = commandargs[0].ToString();
            DataTable dtstudents = new DataTable();
            DataView dvstudents = new DataView();
            try
            {
                if (typevalue.Trim() == "drop")
                {
                    _Qry = "update adm_personalparticulars set studentstatus='Dropped',remarks='" + txtreason.Text + "' where student_id='" +studentid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                    _Qry += "update erp_batchschedule set remarks= 'Student Dropped - '+'" + txtreason.Text + "' ,batchstatus='Dropped' where studentid='" + studentid + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
                    _Qry += "insert into erp_studentdrop (studentid,reason,droppeddate,requesteddate,status,centercode,invoiceno) values ('" + studentid + "','" + txtreason.Text + "',getdate(),getdate(),'Dropped','" + Session["SA_centre_code"] + "' ,'"+invoiceid+"') ";
                    _Qry += "update erp_invoicedetails  set status='deactive',studentstatus='deactive' where studentid='" + studentid + "' and centercode='" + Session["SA_centre_code"] + "' and status='active'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);                   
                }
                else if (typevalue.Trim() == "break")
                {
                    _Qry = "update adm_personalparticulars set studentstatus='Break',remarks='" + txtreason.Text + "' where student_id='" + studentid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                    _Qry += "update erp_batchschedule set remarks= 'Student Break - '+'" + txtreason.Text + "' ,batchstatus='Break' where studentid='" + studentid + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
                    _Qry += "insert into erp_studentdrop (studentid,reason,droppeddate,requesteddate,status,centercode,invoiceno) values ('" + studentid + "','" + txtreason.Text + "',getdate(),getdate(),'Break','" + Session["SA_centre_code"] + "' ,'" + invoiceid + "') ";
                    _Qry += "update erp_invoicedetails set status='deactive',studentstatus='deactive' where studentid='" + studentid + "' and centercode='" + Session["SA_centre_code"] + "' and status='active'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                }
                dtstudents = (DataTable)Cache["dtstudents"];
                DataRow[] drr = dtstudents.Select("invoiceno='" + invoiceid + "' ");
                for (int i = 0; i < drr.Length; i++)
                {                  
                     drr[i].Delete();
                }
                dtstudents.AcceptChanges();
                Cache["dtstudents"] = dtstudents;
                dvstudents = dtstudents.DefaultView;
                Gridview_admission.DataSource = dvstudents;
                Gridview_admission.DataBind();
                lblcount.Text = dvstudents.Count.ToString() + " Students Found";
               
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                dtstudents = null;
                dvstudents = null;
            }
        }
        reason.Style.Add("display", "none");
    }
    #endregion
    protected void downloadlink_Click(object sender, EventArgs e)
    {

    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]%+$");
        e.IsValid = rx.IsMatch(txtkeywords.Text);
    }
    protected void LnkDownlaodExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=UnPaid-Student-List-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gv_download.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
