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

public partial class superadmin_Followingstudentdetails : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalenderf.Text = mon;
            txttocalenderf.Text = DateTime.Now.ToString("dd-MM-yyyy");
            fillgrid();
        }
    }
   private void fillgrid()
    {
      //  _Qry = "select f1.enq_number,enq_personal_name,dateins from img_enquiryform f1 join img_enquiryform1 f2 on f1.enq_number=f2.enq_number where f1.centre_code='" + Session["SA_centre_code"] + "' and enq_enqstatus='Following' ";
        _Qry = "select f2.Created_By,enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''submit''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 103) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "' and f2.enq_enqstatus='Following'";

        if (txtfromcalenderf.Text != "" && txttocalenderf.Text != "")
        {
            //_Qry = _Qry + "and f2.dateins between str_to_date('" + txtfromcalenderf.Text + "','%d-%m-%Y') and DATE_ADD(str_to_date('" + txttocalenderf.Text + "','%d-%m-%Y'), INTERVAL 1 DAY)";
            string str = txtfromcalenderf.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalenderf.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
            _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
        }
    
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
  
    protected void btnsort_Click1(object sender, EventArgs e)
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
}
