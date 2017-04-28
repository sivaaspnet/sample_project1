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

public partial class superadmin_ManageInvoice : System.Web.UI.Page
{
    string _Qry;
    DataTable dtgrid = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            txtfromcalender.Text = mon;
            txttocalender.Text = DateTime.Now.ToString("dd-MM-yyyy");
            fillcourselist();
            fillgrid();
            ViewState.Clear();
        }
      
    }


    //select * from img_coursedetails
    private void fillcourselist()
    {

        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {           
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program  and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";

            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";
            }
            
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddlcourse.DataSource = dt;
            ddlcourse.DataValueField = "course_id";
            ddlcourse.DataTextField = "Program";
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("Select", ""));

        }
    }
    private void fillgrid()
    {

        _Qry = @"select id,centerCode,studentId,invoiceId,receiptNo,track,courseFees,(select program from img_coursedetails where course_id=courseId) as program,installNo,paymentType,batchTime,	enteredBy,taxPercentage,remarks,status,dateIns,studentstatus from erp_invoicedetails where centerCode ='" + Session["SA_centre_code"] + "' ";

       
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + "and  dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            _Qry = _Qry + " order by id desc";
            //Response.Write(_Qry);
            //Response.End();
           
            dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);
			 
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
           
            //Response.Write(_Qry);
            //Response.End();
         
           
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

     
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select centerCode,studentId,invoiceId,receiptNo,track,courseFees,courseId,installNo,paymentType,batchTime,enteredBy,taxPercentage,remarks,status,dateIns,studentstatus from erp_invoicedetails where id=" + e.CommandArgument.ToString() + "";
            DataTable dtEditInvoice = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtEditInvoice.Rows.Count > 0)
            {
                txtcentercode.Text = dtEditInvoice.Rows[0]["centerCode"].ToString();
                txtstudentid.Text = dtEditInvoice.Rows[0]["studentId"].ToString();
                txtinvoiceid.Text = dtEditInvoice.Rows[0]["invoiceId"].ToString();
                txtreceiptno.Text = dtEditInvoice.Rows[0]["receiptNo"].ToString();
                txttrack.Text = dtEditInvoice.Rows[0]["track"].ToString();
                txtcoursefees.Text = dtEditInvoice.Rows[0]["courseFees"].ToString();
                ddlcourse.SelectedValue = dtEditInvoice.Rows[0]["courseId"].ToString();
                txtinstallno.Text = dtEditInvoice.Rows[0]["installNo"].ToString();
                txtpaymenttype.Text = dtEditInvoice.Rows[0]["paymentType"].ToString();
                txtbatchtime.Text = dtEditInvoice.Rows[0]["batchTime"].ToString();
                txttaxpercent.Text = dtEditInvoice.Rows[0]["taxPercentage"].ToString();
                ViewState["uid"] = e.CommandArgument.ToString();
            }
            
        }
        if (e.CommandName == "del")
        {
            _Qry = "INSERT  INTO erp_deletedinvoice(centerCode,studentId,invoiceId,receiptNo,track,courseFees,courseId,installNo,paymentType,batchTime,enteredBy,taxPercentage,remarks,status,dateIns,studentstatus) SELECT centerCode,studentId,invoiceId,receiptNo,track,courseFees,courseId,installNo,paymentType,batchTime,enteredBy,taxPercentage,remarks,status,dateIns,studentstatus FROM erp_invoicedetails WHERE id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "delete from erp_invoicedetails where id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmessage.Text = "Invoice has been deleted successfully";
          
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{

            ////    if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "active")
            ////    {

            ////    }
            ////    else
            ////    {
            ////        e.Row.BackColor = System.Drawing.Color.DarkSalmon;
            ////    }
            ////}
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message.ToString());
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ViewState["uid"] != null)
        {
            if (Convert.ToInt32(ViewState["uid"].ToString()) > 0)
            {
                _Qry = "update erp_invoicedetails set  centerCode='" + txtcentercode.Text + "',studentId='" + txtstudentid.Text + "',invoiceId='" + txtinvoiceid.Text + "',receiptNo='" + txtreceiptno.Text + "',track='" + txttrack.Text + "',courseFees='" + txtcoursefees.Text + "',courseId='" + ddlcourse.SelectedValue + "',installNo='" + txtinstallno.Text + "',paymentType='" + txtpaymenttype.Text + "',taxPercentage='" + txttaxpercent.Text + "',dateIns=getdate()  where id=" + ViewState["uid"].ToString() + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                fillgrid();
                lblmessage.Text = "Invoice has been updated successfully";
                ClearFields();
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    private void ClearFields()
    {
        txtcentercode.Text = "";
        txtstudentid.Text = "";
        txtinvoiceid.Text = "";
        txtreceiptno.Text = "";
        txttrack.Text = "";
        txtcoursefees.Text = "";
        ddlcourse.SelectedIndex = 0;
        txtinstallno.Text = "";
        txtpaymenttype.Text = "";
        txtbatchtime.Text = "";
        txttaxpercent.Text = "";
        ViewState["uid"] = null;
        ViewState.Clear();
        lblmessage.Text = "";
    }
}
