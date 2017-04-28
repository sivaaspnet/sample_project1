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

public partial class superadmin_ManageReceipt : System.Web.UI.Page
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
            fillgrid();  
        }
      
    }



    private void fillgrid()
    {

        _Qry = @"select id,studentId,receiptno,invoiceno,amount,taxamount,totalamount,paymentmode,dateIns,receiptType,status from erp_receiptdetails where centerCode ='" + Session["SA_centre_code"] + "' ";

       
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
            if (txt_stuid.Text.Trim() != "")
            {
                _Qry = _Qry + "and  studentId='" + txt_stuid.Text + "'";
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
        if (e.CommandName == "del")
        {

            _Qry = "INSERT  INTO erp_deletedreceipt(studentId,centerCode,receiptno,invoiceno,amount,taxamount,totalamount,paymentmode,dateIns,receiptType,status,bankName,ddNo,ddDate,paymentTowards,monthInstall,installNo,paymentWords) SELECT studentId,centerCode,receiptno,invoiceno,amount,taxamount,totalamount,paymentmode,dateIns,receiptType,status,bankName,ddNo,ddDate,paymentTowards,monthInstall,installNo,paymentWords FROM erp_receiptdetails WHERE id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "delete from erp_receiptdetails where id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmessage.Text = "The Receipt has been disabled successfully";
          
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{
               
            ////    if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "1")
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
}
