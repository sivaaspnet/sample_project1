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

public partial class viewunpaidstudents : System.Web.UI.Page
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
        if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
        {
            btnsubmit.Visible = true;
        }
        else
        {
            btnsubmit.Visible = false;
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }

    private string amts(int amountvalue)
    {
        string words;
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
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtkeywords.Text);
    }
    private void fillgrid()
    {
        DataTable dtstudents = new DataTable();
        try
        {
            _Qry = @" select upl.unpaidid,upl.studentid,enq_personal_name as studentname,upl.invoiceno,coursename,convert(varchar,upl.dateins,103) as removedate from erp_unpaidlist upl inner join erp_invoicedetails inv on inv.invoiceid=upl.invoiceno and inv.studentid=upl.studentid inner join adm_personalparticulars per on per.student_id=inv.studentid inner join img_coursedetails cou on inv.courseid=cou.course_id where upl.centrecode='" + Session["SA_centre_code"] + "' ";
            _Qry = @"select convert(varchar,max(inv.dateins),103) as doj,rec.studentid,max(enq_personal_name) as Studentname,
                    rec.invoiceno,max(cou.program) as coursename,max(inv.coursefees) as coursefees,sum(rec.amount) as paidamount,
                    convert(varchar,max(rec.dateins),103) as lastpaiddate,max(rec.dateins) as dateindb,
                    max(inv.coursefees)-sum(rec.amount) as pendingamount,convert(varchar,max(unp.dateins),103) as removedate from erp_unpaidlist unp inner join erp_invoicedetails inv on unp.studentid=inv.studentid and unp.invoiceno=inv.invoiceid
                    inner join erp_receiptdetails rec on rec.studentid=unp.studentid and unp.invoiceno=rec.invoiceno 
                    inner join adm_personalparticulars per on per.student_id=inv.studentid 
                    inner join img_coursedetails cou on inv.courseid=cou.course_id where unp.centrecode='" + Session["SA_centre_code"] + @"' group by rec.studentid,rec.invoiceno ";
            //Response.Write(_Qry);
            dtstudents = MVC.DataAccess.ExecuteDataTable(_Qry);
            lblcount.Text = dtstudents.Rows.Count.ToString()+" Students Found";
            Cache["dtstudents"] = dtstudents;
            Gridview_admission.DataSource = (DataTable)Cache["dtstudents"];
            Gridview_admission.DataBind();
            gv_downloadadmission.DataSource = (DataTable)Cache["dtstudents"];
            gv_downloadadmission.DataBind();
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

    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        Gridview_admission.DataSource = (DataTable)Cache["dtstudents"];
        Gridview_admission.DataBind();
    }

    
    protected void downloadlink_Click(object sender, EventArgs e)
    {
        
    }

    #region splitdate function
    string splitdate(string datevalue)
    {
        string res = "";
        string[] getdateval = datevalue.Split('-');
        res = getdateval[1] + "-" + getdateval[0] + "-" + getdateval[2];
        return res;
    }
    #endregion

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
    protected void Gridview_admission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "resume")
        {
            string[] commandargs = e.CommandArgument.ToString().Split('~');
            string studentid = commandargs[1].ToString();
            string invoiceid = commandargs[0].ToString();
            DataTable dtstudents = new DataTable();
            DataView dvstudents = new DataView();
            try
            {
                dtstudents = (DataTable)Cache["dtstudents"];
                DataRow[] drr = dtstudents.Select("invoiceno=" + invoiceid + " ");
                for (int i = 0; i < drr.Length; i++)
                {
                    _Qry = " update erp_invoicedetails set status='active',studentstatus='active' where studentid='" + studentid + "' and invoiceid='" + invoiceid + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
                    _Qry += " delete from erp_unpaidlist where studentid='" + studentid + "' and invoiceno='" + invoiceid + "' ";
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
    }
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
                            _Qry = " update erp_invoicedetails set status='active',studentstatus='active' where  studentid='" + hdnstudentid.Value + "' and invoiceid='" + hdninvoiceid.Value + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
                            _Qry += " delete from erp_unpaidlist where studentid='" + hdnstudentid.Value + "' and invoiceno='" + hdninvoiceid.Value + "' ";
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
    protected void LnkDownlaodExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=View-UnPaid-Student-List-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gv_downloadadmission.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
    protected void Gridview_admission_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
        {
        }
        else
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
        }
    }
}
