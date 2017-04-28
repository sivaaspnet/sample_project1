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
            _Qry = @"select * from erp_studenttransfer  where newstudentid <> null and transferedfrom ='" + Session["SA_centre_code"].ToString() + "' ";
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
                _Qry = _Qry + " and dateupt between ('" + dateFrom + "') and ('" + dateTo + "')";

            }

            if (TextBox2.Text != "")
            {
                _Qry = _Qry + " and studentid ='" + TextBox2.Text + "'";
            }
            _Qry = _Qry + " order by id desc";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        leavegrid();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "lnkedit")
        //{
        //    _Qry = "update adm_personalparticulars set studentstatus='active' where student_id='" + e.CommandArgument.ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
        //    _Qry += "update erp_studentdrop set action='deactive' where studentid='" + e.CommandArgument.ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
        //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //    //_Qry = "update erp_batchschedule set batchstatus='active' where studentid='" + e.CommandArgument.ToString() + "' and centrecode='" + Session["SA_centre_code"] + "'";
        //    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //    leavegrid();
        //    lblmessage.Text = "Student Successfully Resumed";


        //}
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
