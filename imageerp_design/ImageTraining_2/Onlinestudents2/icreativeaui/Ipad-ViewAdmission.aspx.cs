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
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
           
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
   
   private void fillgrid()
    {

        if (Session["SA_Centrerole"] .ToString() == "Ipad")
        {

            string headCentrecode = ConfigurationManager.AppSettings["Ipadcentrecode"].ToString();

            _Qry = @"
select a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,inv.invoiceId,b.centre_code,'invno='+inv.invoiceId+'&'+'centrecode='+b.centre_code as qrystringvariable
from adm_personalparticulars a inner join adm_generalinfo b on 
a.student_id=b.student_id inner join erp_invoicedetails inv on
 inv.studentId=a.student_id and inv.status='active' where a.Admission_id>0  ";

            if (txtkeyword.Text.Trim() != "")
            {
                _Qry += " and ( a.enq_personal_name  like '%" + txtkeyword.Text.Trim() + "%' or a.student_id   like '%" + txtkeyword.Text.Trim() + "%' )";
            }
            if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
            {
                string str = txtfromcalender1.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender1.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                _Qry = _Qry + " and b.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }

            if (Session["SA_centre_code"].ToString() == headCentrecode)
            {

                _Qry = _Qry + " and b.centre_code in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
            }
            else
            {
                _Qry = _Qry + " and b.centre_code ='" + Session["SA_centre_code"] + "'";
            }


            //if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
            //{
            //    _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
            //}
            _Qry = _Qry + " Order by a.Admission_id desc";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            Gridview_admission.DataSource = dt;
            Gridview_admission.DataBind();

        }
       
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_centrcode.DataSource = dt;
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
            Response.Redirect("Ipad-InvoiceDetails.aspx?" + e.CommandArgument.ToString() + " ");
        }
    }
}
