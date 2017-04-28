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

public partial class superadmin_leaverequest : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Student_Id"].ToString() == null || Session["Student_Id"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgridleave();
        }
    }

    private void fillgridleave()
    {
        _Qry = "select studentid,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen,case status when 'Pending' then 'Pending' when 'Approved' then case status_cen when 'Approved' then 'Approved' when 'Pending' then 'Pending' else 'Rejected'  end else 'Rejected' end as finalstatus from erp_studentleave where centercode='" + Session["centrecode"].ToString() + "' and studentid='" + Session["student_id"].ToString() + "' order by id desc";
     DataTable dt = new DataTable();
       // Response.Write(_Qry);
      dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //DataTable status = new DataTable();
        //status.Columns.Add(new DataColumn("fromdate", System.Type.GetType("System.String")));
        //status.Columns.Add(new DataColumn("todate", System.Type.GetType("System.String")));
        //status.Columns.Add(new DataColumn("reason", System.Type.GetType("System.String")));
        //status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        //DataRow dr = status.NewRow();
        //foreach (DataRow drs in dt.Rows)
        //{

        //    dr = status.NewRow();
        //    dr["fromdate"] = drs["fromdate"];
        //    dr["todate"] = drs["todate"];
        //    dr["reason"] = drs["reason"];
        //    dr["status"] = getstatus(dt, "studentid='" + drs["studentid"] + "'");
        //    status.Rows.Add(dr);

        //}



        gvleave.DataSource = dt;
        gvleave.DataBind();
    }

    //string getstatus(DataTable dtexp, string expression)
    //{
    //    string res = "Pending";
    //    string tech="";
    //     string cen ="";
    //    DataRow[] dr = new DataRow[100];
    //    dr = dtexp.Select(expression);
    //    if (dr.Length > 0)
    //    {
    //        foreach (DataRow val in dr)
    //        {
    //            tech = val["status"].ToString();
    //           cen = val["status_cen"].ToString();
    //           if (tech == "Approved" && cen == "Approved")
    //           {
    //               res = "Approved";
    //           }
    //           else
    //           {
    //               res = "Rejected";
    //           }
    //        }
            

    //    }
       
    //    return res.ToString();

    //}

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string[] fromdate = txtfromdate.Text.Split('-');
        string from = fromdate[2] + "/" + fromdate[1] + "/" + fromdate[0];
        string[] todate = txttodate.Text.Split('-');
        string to = todate[2] + "/" + todate[1] + "/" + todate[0];
        _Qry = "select * from erp_studentleave where  fromdate='" + from + "' and todate='" + to + "' and studentid='" + Session["student_id"].ToString() + "'";

           DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            showBox("Request already sent...!");
           // lblerrormsg.Text = "Request already sent...!";
        }
        else
        {

          
            _Qry = " Insert into erp_studentleave (studentid,centercode,fromdate,todate,reason,status,requestdate,status_cen) values ('" + Session["student_id"].ToString() + "','" + Session["centrecode"].ToString() + "','" + from + "','" + to + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtreason.Text) + "','Pending',getdate(),'Pending')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            showBox("Leave Request Send Successfully");
           // lblerrormsg.Text = "Leave Request Send Successfully";
            fillgridleave();
        }
    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
}
