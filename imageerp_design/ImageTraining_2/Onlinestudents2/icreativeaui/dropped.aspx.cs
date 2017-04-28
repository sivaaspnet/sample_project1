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
public partial class superadmin_Droppedstudentdetails : System.Web.UI.Page
{
    string _Qry;

    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
   public void fillgrid()
    {
        if (Session["SA_centre_code"] != null)
        {
            //_Qry = "select f1.enq_number,enq_personal_name,dateins from img_enquiryform f1 join img_enquiryform1 f2 on f1.enq_number=f2.enq_number where f1.centre_code='" + Session["SA_centre_code"] + "' and enq_enqstatus='Dropped'  ";
            _Qry = @"select coursefees,program,drp.id,enq_personal_name,student_id,adm.studentstatus,convert(varchar,droppeddate,103) as droppeddate ,reason,invoiceId from adm_personalparticulars adm inner
join erp_studentdrop drp on student_id=studentid inner join erp_invoicedetails erp on erp.studentid=drp.studentid  inner join img_coursedetails on course_id=courseId where adm.studentstatus='Dropped' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                //_Qry = _Qry + "and f2.dateins between str_to_date('" + txtfromcalender.Text + "','%d-%m-%Y') and DATE_ADD(str_to_date('" + txttocalender.Text + "','%d-%m-%Y'), INTERVAL 1 DAY)";

                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + " and droppeddate between ('" + dateFrom + "') and ('" + dateTo + "')";

            }

            if (TextBox2.Text != "")
            {
                _Qry += " and student_id = '" + TextBox2.Text + "' or enq_personal_name='" + TextBox2.Text + "' ";
            }
            _Qry = _Qry + " Order by id desc";


            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEnquiry.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        
        fillgrid();
        ExportTableData(dt);
    }

    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Dropped-Student-details-" + "-center.xls");
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(TextBox2.Text);
    }

}
