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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {

            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            //string yea = string.Format("{0:yyyy}", DateTime.Now).Trim();
            txtfromcalender.Text = mon;

            //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            txttocalender.Text = DateTime.Now.ToString("dd-MM-yyyy");

            leavegrid();
        }
    }
  
    protected void btnsort_Click(object sender, EventArgs e)
    {
        leavegrid();
    }
   
   
    private void leavegrid()
    {
        if (Session["SA_centre_code"] != null)
        {
            _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where centercode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable dt = new DataTable();

            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                //_Qry = _Qry + "and f2.dateins between str_to_date('" + txtfromcalender.Text + "','%d-%m-%Y') and DATE_ADD(str_to_date('" + txttocalender.Text + "','%d-%m-%Y'), INTERVAL 1 DAY)";

                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + " and fromdate between ('" + dateFrom + "') and ('" + dateTo + "')";

            }

            if (TextBox2.Text != "")
            {
                _Qry = _Qry + " and studentid ='" + TextBox2.Text + "' or enq_personal_name = '" + TextBox2.Text + "'  ";
            }

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl1 = new Label();
                lbl1 = (Label)gr.FindControl("lblstatus1");
                LinkButton lnkapprove1 = new LinkButton();
                lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
                LinkButton lnkdecline1 = new LinkButton();
                lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
                Label lbl = new Label();
                lbl = (Label)gr.FindControl("lblstatus");
                LinkButton lnkapprove = new LinkButton();
                lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
                LinkButton lnkdecline = new LinkButton();
                lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                lnkapprove1.Visible = false;
                lnkdecline1.Visible = false;
                lbl1.Visible = true;
                lnkapprove.Visible = false;
                lnkdecline.Visible = false;
                lbl.Visible = true;

            }
        }

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        leavegrid();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            leavegrid();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(TextBox2.Text);
    }
}
