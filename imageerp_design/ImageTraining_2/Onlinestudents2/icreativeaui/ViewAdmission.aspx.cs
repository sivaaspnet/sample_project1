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

public partial class superadmin_ViewAdmission : System.Web.UI.Page
{
    string _Qry;
    DataTable dt=new DataTable();
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
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalender1.Text = mon;
            txttocalender1.Text = DateTime.Now.ToString("dd-MM-yyyy");

            downloadexcel();
            fillgrid();
            filltype();
        }
        if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
        {
            //viewby_admin.Visible = true;//row id
            //ddl_centrcode
            if (!IsPostBack)
            {
                fill_cencode();//fill centre code
            }
        }
        else
        {
            viewby_admin.Visible = false;
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtkeyword.Text);
    }
    private void filltype()
    {



        _Qry = @"select coursetype as course,count(coursetype) as studentsjoined  from 
(select coursetype
from erp_invoicedetails inv inner join img_coursedetails cou on inv.courseid=cou.course_id and inv.status<>'deactive' and inv.centercode='"+Session["SA_centre_code"].ToString()+"' inner join adm_personalparticulars p on p.student_id=inv.studentid and p.centre_code=inv.centercode and substring(p.enq_number,1,3)<>'old' inner join adm_generalinfo b on inv.studentid=b.student_id ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry += " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            // _Qry += " and convert(varchar,inv.dateins,105) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "' ";
        }
        _Qry += " )  as sts  group by coursetype";
        DataTable dttype = new DataTable();
        dttype = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvtype.DataSource = dttype;
        gvtype.DataBind();



        _Qry = @"select isnull(sum(cast(coursefees as int)),0) as summed from erp_invoicedetails inv inner join img_coursedetails cou on 
inv.courseid=cou.course_id  and inv.centercode='"+Session["SA_centre_code"].ToString()+"' inner join adm_personalparticulars p on p.student_id=inv.studentid and p.centre_code=inv.centercode and substring(p.enq_number,1,3)<>'old' inner join adm_generalinfo b on inv.studentid=b.student_id "; 
        
           if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
           string str = txtfromcalender1.Text;
        string[] split = str.Split('-');
        string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

        string str1 = txttocalender1.Text;
        string[] split1 = str1.Split('-');
        string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
        _Qry += " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
           }
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            double a = Convert.ToDouble(dt.Rows[0]["summed"]);
            //billed.Text = amts(a).ToString();
        }



    }
   private void fillgrid()
    {
        //  _Qry = "select  *  from adm_personalparticulars  where substring(enq_number,1,3)='Old'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
        //    lbl_errormsg.Text = "No Records Found";
        //}
        //else
        //{
            if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
            {
                _Qry = "select img1.enq_student_profile,case when img.enq_aboutimage='Others' then  img.enq_aboutimage_others else img.enq_aboutimage end as about,inv.coursefees,ccc.reason,a.studentstatus,enq_present_address,enq_present_city,enq_present_district,enq_present_state,enq_present_pincode,a.student_id,program,case when a.studentstatus='active' then a.student_id else '<span style=''color:#ff0000; font-weight:bold;''>'+a.student_id+'</span>' end as studid,Enrolled_By,a.enq_personal_name,b.coursename,isnull(inv.invoiceId,0) as invoiceId,convert(varchar(10),inv.dateins,101) as dateofenroll,student_enrolledStatus,(select convert(varchar,max(rec.dateins),101) as lastpaiddate from erp_receiptdetails rec where rec.studentid=inv.studentid and rec.invoiceno=inv.invoiceid) as lastpaiddate  from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id and substring(a.enq_number,1,3)<>'Old' left join erp_invoicedetails inv on inv.studentId=a.student_id  inner join img_coursedetails on b.coursename=course_id inner join img_enquiryform  img on img.enq_number=a.enq_number inner join img_enquiryform1  img1 on img1.enq_number=a.enq_number  left join (select studentId,max(reason) as reason from erp_studentdrop where  centercode='" + Session["SA_centre_code"].ToString() + "'  group by studentId) as ccc   on ccc.studentid=a.student_id where a.Admission_id>0";
                if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
                {
                    string str = txtfromcalender1.Text;
                    string[] split = str.Split('-');
                    string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                    string str1 = txttocalender1.Text;
                    string[] split1 = str1.Split('-');
                    string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                    _Qry = _Qry + " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
                }
                if (txtkeyword.Text.Trim() != "")
                {
                    _Qry += " and (a.student_id like '%" + txtkeyword.Text.Trim() + "%' or a.enq_personal_name like '%" + txtkeyword.Text.Trim() + "%' or program  like '%" + txtkeyword.Text.Trim() + "%' )";
                }
                if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
                {
                    _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
                }
               // _Qry = _Qry + " Order by a.Admission_id desc";
                _Qry = _Qry + " Order by inv.invoiceid desc";
             // Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                Gridview_admission.DataSource = dt;
                Gridview_admission.DataBind();
        
                lblcount.Text = dt.Rows.Count.ToString();
            }
            else
            {
                _Qry = "select img1.enq_student_profile,case when img.enq_aboutimage='Others' then  img.enq_aboutimage_others else img.enq_aboutimage end as about,inv.coursefees,ccc.reason,a.studentstatus,enq_present_address,enq_present_city,enq_present_district,enq_present_state,enq_present_pincode,a.student_id,program,case when a.studentstatus='active' then a.student_id else '<span style=''color:#ff0000; font-weight:bold;''>'+a.student_id+'</span>' end as studid,Enrolled_By,a.enq_personal_name,b.coursename,isnull(inv.invoiceId,0) as invoiceId,convert(varchar(10),inv.dateins,101) as dateofenroll,(select convert(varchar,max(rec.dateins),101) as lastpaiddate from erp_receiptdetails rec where rec.studentid=inv.studentid and rec.invoiceno=inv.invoiceid) as lastpaiddate  from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id and substring(a.enq_number,1,3)<>'Old' left join erp_invoicedetails inv on inv.studentId=a.student_id  inner join img_coursedetails on b.coursename=course_id inner join img_enquiryform  img on img.enq_number=a.enq_number inner join img_enquiryform1  img1 on img1.enq_number=a.enq_number  left join (select studentId,max(reason) as reason from erp_studentdrop where  centercode='" + Session["SA_centre_code"].ToString() + "'  group by studentId) as ccc   on ccc.studentid=a.student_id where a.Admission_id>0";
                if (txtkeyword.Text.Trim() != "")
                {
                    _Qry += " and (a.student_id like '%" + txtkeyword.Text.Trim() + "%' or a.enq_personal_name like '%" + txtkeyword.Text.Trim() + "%' or program  like '%" + txtkeyword.Text.Trim() + "%' )";
                }
                if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
                {
                    string str = txtfromcalender1.Text;
                    string[] split = str.Split('-');
                    string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                    string str1 = txttocalender1.Text;
                    string[] split1 = str1.Split('-');
                    string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    _Qry = _Qry + " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";

                }
                if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
                {
                    _Qry = _Qry + " and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
                }
                // _Qry = _Qry + " Order by a.Admission_id desc";
                _Qry = _Qry + " Order by inv.invoiceid desc";
                // Response.Write(_Qry);
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                Gridview_admission.DataSource = dt;
                Gridview_admission.DataBind();

                lblcount.Text = dt.Rows.Count.ToString();
            }
        
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
            filltype();
        }
    }
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    private void downloadexcel()
    {

        if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
        {
            _Qry = @"select img1.enq_student_profile,case when img.enq_aboutimage='Others' then  img.enq_aboutimage_others else img.enq_aboutimage end as about,inv.coursefees,round(((inv.coursefees * taxpercentage)/100+inv.coursefees),0) as coursefeeswithtax,(select sum(totalamount) as paidamount from erp_receiptdetails rec where centercode='" + Session["SA_centre_code"].ToString() + "' and studentid=inv.studentId and receipttype='Invoice' and status=1 and rec.invoiceNo=inv.invoiceId) as totpaid,(round(((inv.coursefees * taxpercentage)/100+inv.coursefees),0)-(select sum(totalamount) as paidamount from erp_receiptdetails rec where centercode='" + Session["SA_centre_code"].ToString() + "' and studentid=inv.studentId and receipttype='Invoice' and status=1 and rec.invoiceNo=inv.invoiceId)) as peinding_amount,ccc.reason,a.studentstatus,enq_present_address,enq_present_city,enq_present_district,enq_present_state,enq_present_pincode,a.student_id,(select program from img_coursedetails cou  where inv.courseId=cou.course_id) as program,case when a.studentstatus='active' then a.student_id else '<span style=''color:#ff0000; font-weight:bold;''>'+a.student_id+'</span>' end as studid,Enrolled_By,a.enq_personal_name,b.coursename,isnull(inv.invoiceId,0) as invoiceId,convert(varchar(10),inv.dateins,101) as dateofenroll,student_enrolledStatus,student_enrolledStatus_remarks,(select convert(varchar,max(rec.dateins),101) as lastpaiddate from erp_receiptdetails rec where rec.studentid=inv.studentid and rec.invoiceno=inv.invoiceid) as lastpaiddate  from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id and substring(a.enq_number,1,3)<>'Old' left join erp_invoicedetails inv on inv.studentId=a.student_id  inner join img_coursedetails on b.coursename=course_id inner join img_enquiryform1 img1 on img1.enq_number=a.enq_number inner join img_enquiryform  img on img.enq_number=a.enq_number left join (select studentId,max(reason) as reason from erp_studentdrop where  centercode='" + Session["SA_centre_code"].ToString() + "'  group by studentId) as ccc   on ccc.studentid=a.student_id where a.Admission_id>0";
            if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
            {
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                _Qry = _Qry + " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            if (txtkeyword.Text.Trim() != "")
            {
                _Qry += " and (a.student_id like '%" + txtkeyword.Text.Trim() + "%' or a.enq_personal_name like '%" + txtkeyword.Text.Trim() + "%' or program  like '%" + txtkeyword.Text.Trim() + "%' )";
            }
            if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
            {
                _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
            }
            // _Qry = _Qry + " Order by a.Admission_id desc";
            _Qry = _Qry + " Order by inv.invoiceid desc";
          // Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblcount.Text = dt.Rows.Count.ToString();
        }
        else
        {
            _Qry = @"select img1.enq_student_profile,case when img.enq_aboutimage='Others' then  img.enq_aboutimage_others else img.enq_aboutimage end as about,inv.coursefees,round(((inv.coursefees * taxpercentage)/100+inv.coursefees),0) as coursefeeswithtax,(select sum(totalamount) as paidamount from erp_receiptdetails rec where centercode='" + Session["SA_centre_code"].ToString() + "' and studentid=inv.studentId and receipttype='Invoice' and status=1 and rec.invoiceNo=inv.invoiceId) as totpaid,(round(((inv.coursefees * taxpercentage)/100+inv.coursefees),0)-(select sum(totalamount) as paidamount from erp_receiptdetails rec where centercode='" + Session["SA_centre_code"].ToString() + "' and studentid=inv.studentId and receipttype='Invoice' and status=1 and rec.invoiceNo=inv.invoiceId)) as peinding_amount,ccc.reason,a.studentstatus,enq_present_address,enq_present_city,enq_present_district,enq_present_state,enq_present_pincode,a.student_id,(select program from img_coursedetails cou  where inv.courseId=cou.course_id) as program,case when a.studentstatus='active' then a.student_id else '<span style=''color:#ff0000; font-weight:bold;''>'+a.student_id+'</span>' end as studid,Enrolled_By,a.enq_personal_name,b.coursename,isnull(inv.invoiceId,0) as invoiceId,convert(varchar(10),inv.dateins,101) as dateofenroll from erp_receiptdetails rec where rec.studentid=inv.studentid and rec.invoiceno=inv.invoiceid),(select convert(varchar,max(rec.dateins),101) as lastpaiddate from erp_receiptdetails rec where rec.studentid=inv.studentid and rec.invoiceno=inv.invoiceid) as lastpaiddate   from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id and substring(a.enq_number,1,3)<>'Old' left join erp_invoicedetails inv on inv.studentId=a.student_id  inner join img_coursedetails on b.coursename=course_id inner join img_enquiryform1 img1 on img1.enq_number=a.enq_number inner join img_enquiryform  img on img.enq_number=a.enq_number left join (select studentId,max(reason) as reason from erp_studentdrop where  centercode='" + Session["SA_centre_code"].ToString() + "'  group by studentId) as ccc   on ccc.studentid=a.student_id where a.Admission_id>0";
            if (txtkeyword.Text.Trim() != "")
            {
                _Qry += " and (a.student_id like '%" + txtkeyword.Text.Trim() + "%' or a.enq_personal_name like '%" + txtkeyword.Text.Trim() + "%' or program  like '%" + txtkeyword.Text.Trim() + "%' )";
            }
            if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
            {
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + " and inv.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";

            }
            if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
            {
                _Qry = _Qry + " and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
            }
            // _Qry = _Qry + " Order by a.Admission_id desc";
            _Qry = _Qry + " Order by inv.invoiceid desc";
       //  Response.Write(_Qry);
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblcount.Text = dt.Rows.Count.ToString();
        }



    }

    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";

        DataTable dtddl = new DataTable();
        dtddl = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_centrcode.DataSource = dtddl;
        ddl_centrcode.DataValueField = "centre_code";
        ddl_centrcode.DataTextField = "centre_code";
        ddl_centrcode.DataBind();
        ddl_centrcode.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void ddl_centrcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Gridview_admission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
   
        if (e.CommandName == "Inv")
        {
            string[] commandArgs =e.CommandArgument.ToString().Split(new char[] {','}) ;
            string invoiceid = commandArgs[0];
            string studentid= commandArgs[1];
            if (invoiceid != "0")
            {
                Server.Transfer("InvoiceDetails.aspx?invno=" + invoiceid.ToString() + "");
            }
            else
            {
                _Qry = "select isnull(receiptno,0) as receiptno from erp_quickreceipt where studentidno='" + studentid.ToString() + "'";
                int receiptno=0;
                DataTable dtrec = new DataTable();
                dtrec = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dtrec.Rows.Count > 0)
                {
                    receiptno = Convert.ToInt32(dtrec.Rows[0]["receiptno"]);
                    Server.Transfer("quickpreInvoice.aspx?receiptno=" + receiptno + "&studid=" + studentid + "");
                }
                else
                {
                    Server.Transfer("preInvoicedetail.aspx?studid=" + studentid.ToString() + "");
                }
            }
        }
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        downloadexcel();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Admission-of-" + Session["SA_Location"] + "-center.xls");
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
        //fillgrid();
        // ExportTableData(dtgrid);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

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
        Response.AppendHeader("Content-Disposition", "attachment;filename=Admission-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write( dc.ColumnName + "\t");
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
    protected void btnsear_Click(object sender, EventArgs e)
    {
        //filltype();
    }

    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = amountvalue.ToString("#,000");
        }
        return words;
    }

}
