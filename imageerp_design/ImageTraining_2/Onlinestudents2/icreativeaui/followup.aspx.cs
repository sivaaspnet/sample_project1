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

public partial class superadmin_followup : System.Web.UI.Page
{
    string _Qry;
    int TeleEnquiry = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["TeleEnquiry"]!=null)
        {
            TeleEnquiry = Convert.ToInt32(Request.QueryString["TeleEnquiry"].ToString());
        }
      
        if (!IsPostBack)
        {
            if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (Request.QueryString["viewenqno"] != null)
            {
                _Qry = "select * from img_enquiryform Where enq_number='" + Request.QueryString["viewenqno"].ToString() + "'";
                //Response.Write(_Qry);
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lblmobile.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
                    lblstuname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                    lblemail.Text = dt.Rows[0]["enq_personal_email"].ToString();
                }
            }
            else
            {
                //TeleEnquiry = Convert.ToInt32(Request.QueryString["TeleEnquiry"].ToString());
                _Qry = "select * from TeleEnquiry Where TeleEnquiryId=" + Request.QueryString["enqno"].ToString() + "";
                //Response.Write(_Qry);
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    lblmobile.Text = dt.Rows[0]["mobileno"].ToString();
                    lblstuname.Text = dt.Rows[0]["enquiryname"].ToString();
                    lblemail.Text = dt.Rows[0]["emailid"].ToString();
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string str = txtreminder.Text;
        string[] split = str.Split('-');

        string reminddate = split[2] + "-" + split[1] + "-" + split[0];      
        if (TeleEnquiry == 1)
        {
            _Qry = "insert into img_followups(enq_number,centre_code,Decision,remark,reminderdate,dateins)values('" + Request.QueryString["enqno"] + "','" + Session["SA_Centre_code"] + "','" + dddesicionstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtremarks.Text) + "','" + reminddate + "',getdate())";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = "Update TeleEnquiry Set ReminderDate='" + reminddate + "',Remarks='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtremarks.Text) + "',DateMod=getdate() Where TeleEnquiryId='" + Request.QueryString["enqno"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
           // Response.Redirect("TeleEnquiry.aspx?res=ins");
            Response.Write("<script>window.parent.location.href = 'TeleEnquiry.aspx?res=upd'</script>");
        }
        else
        {
            _Qry = "insert into img_followups(enq_number,centre_code,Decision,remark,reminderdate,dateins)values('" + Request.QueryString["viewenqno"] + "','" + Session["SA_Centre_code"] + "','" + dddesicionstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtremarks.Text) + "','" + reminddate + "',getdate())";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //Response.Redirect("ViewEnquiry.aspx?res=ins");
            Response.Write("<script>window.parent.location.href = 'ViewEnquiry.aspx?res=ins'</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TeleEnquiry == 1)
        {
           // Response.Redirect("TeleEnquiry.aspx");
            Response.Write("<script>window.parent.location.href = 'TeleEnquiry.aspx'</script>");
        }
        else
        {
            //Response.Redirect("ViewEnquiry.aspx");
            Response.Write("<script>window.parent.location.href = 'ViewEnquiry.aspx'</script>");
        }
    }
}
