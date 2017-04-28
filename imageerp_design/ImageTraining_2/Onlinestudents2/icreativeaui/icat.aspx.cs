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
using System.Text.RegularExpressions;

public partial class superadmin_addcentre : System.Web.UI.Page
{
    string _Qry;
    double tax;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
           
                Response.Redirect("Login.aspx");
           
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if( TextBox1.Text=="")
        {
            Label2.Text = "Enter Student ID";
        }
        else
        {
      
        fillgrid();
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select initialamount,initialamounttax,id,studentid, convert(varchar,installdate,105) as installdate  from erp_installamountdetails where id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                TextBox2.Text = dt.Rows[0]["installdate"].ToString();
                txt_amount.Text = dt.Rows[0]["initialamount"].ToString();
                Label1.Text = dt.Rows[0]["studentid"].ToString();
                HiddenField1.Value = dt.Rows[0]["id"].ToString();
            }
            studentid.Visible = false;
            date.Visible = true;
            amount.Visible = true;
            update.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string[] date = TextBox2.Text.Split('-');
        string install = date[2] + "-" + date[1] + "-" + date[0];
        double tax1 = ((Convert.ToDouble(txt_amount.Text)) * (Convert.ToDouble(HiddenField2.Value)) / 100);
     double total =Convert.ToDouble(txt_amount.Text)+tax1;
         _Qry = "update erp_installamountdetails set totalinitialamount=round("+total+",0), initialamounttax=round("+tax1+",0), initialamount=round("+txt_amount.Text+",0), installdate='" + install + "' where studentid='" + Label1.Text + "' and centercode='" + Session["SA_centre_code"] + "' and id='" + HiddenField1.Value + "' and status='pending' ";
         //Response.Write(_Qry);
       MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
       _Qry = "update erp_invoicedetails set batchTime='"+txt_time.Text+"' where studentid='" + Label1.Text + "' and centercode='" + Session["SA_centre_code"] + "'";
       //Response.Write(_Qry);
       MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        fillgrid();
        Label2.Text = "updated";
    }

    private void fillgrid()
    {
        try
        {
            _Qry = "select  tax,courseid,initialamount,initialamounttax,id,installNumber,convert(varchar,installdate,103) as installdate from erp_installamountdetails ins inner join img_centre_coursefee_details fee on courseid=program and ins.centerCode=fee.centre_code  and centerCode='" + Session["SA_centre_code"] + "' and ins.status='pending' and track='Normal'  where studentid='" + TextBox1.Text.Trim() + "' ";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                HiddenField2.Value = dt.Rows[0]["tax"].ToString();
            }
            else
            {
                Label2.Text = "Tax details missing";
                date.Visible = false;
                amount.Visible = false;
                update.Visible = false;
            }
            _Qry = "select track,batchTime from erp_invoicedetails  where studentid='" + TextBox1.Text.Trim() + "' and centercode='" + Session["SA_centre_code"] + "' ";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                txt_time.Text = dt1.Rows[0]["batchTime"].ToString();
                txt_track.Text = dt1.Rows[0]["track"].ToString();
            }
            else
            {
                Label2.Text = "Contact Admin";
                date.Visible = false;
                amount.Visible = false;
                update.Visible = false;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Label2.Text = "contact admin";
            date.Visible = false;
            amount.Visible = false;
            update.Visible = false;
        }
    }

}
