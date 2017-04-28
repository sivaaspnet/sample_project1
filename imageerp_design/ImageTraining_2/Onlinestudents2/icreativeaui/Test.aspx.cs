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

public partial class Onlinestudents2_superadmin_Test : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
      

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = @"SELECT     erp_receiptDetails.*, erp_invoiceDetails.courseFees
FROM         erp_invoiceDetails INNER JOIN
                      erp_receiptDetails ON erp_invoiceDetails.centerCode = erp_receiptDetails.centerCode AND erp_invoiceDetails.studentId = erp_receiptDetails.studentId  where erp_receiptDetails.studentid='" + TextBox1.Text + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select sum(amount) as total1,sum(totalAmount) as total,studentId from erp_receiptdetails  where studentId='" + TextBox1.Text + "' group by studentid";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);


        DataTable final = new DataTable();
        final.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("receipt", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("date", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("paidamount", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("Total", System.Type.GetType("System.String")));
        final.Columns.Add(new DataColumn("Pending", System.Type.GetType("System.String")));
        DataTable dtf = new DataTable();
        string[] arg = new string[1];
        arg[0] = "studentid";

        dtf = dt.DefaultView.ToTable(true, arg);
        DataRow finalrow = final.NewRow();
        foreach (DataRow drs in dtf.Rows)
        {
            finalrow = final.NewRow();
            finalrow["studentid"] = drs["studentid"];
            finalrow["date"] = getreceipt(dt, " studentid='" + drs["studentid"].ToString() + "'", "dateIns");
            finalrow["paidamount"] = getreceipt(dt, " studentid='" + drs["studentid"].ToString() + "'", "totalAmount");
            finalrow["receipt"] = getreceipt(dt, " studentid='" + drs["studentid"].ToString() + "'", "receiptno");
            finalrow["Total"] = getsum(dt1, " studentid='" + drs["studentid"].ToString() + "'");
            finalrow["Pending"] = getpending(dt, " studentid='" + drs["studentid"].ToString() + "'");
            final.Rows.Add(finalrow);
        }

        GridView1.DataSource = final;
        GridView1.DataBind();
       

    }

    string getreceipt(DataTable dtexp, string expression, string column)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if(res=="")
                {
                    res = (val[column].ToString());
                }
                else
                {
                    res = res + "," + (val[column].ToString());
                }
            }
           
        }
       

        return res.ToString();
    }

    string getsum(DataTable dtexp, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = (val["total"].ToString());
            }

        }


        return res.ToString();
    }


    double getpending(DataTable dtexp, string expression)
    {
        double res = 0;
        double coursefees = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                coursefees = Convert.ToDouble(val["courseFees"].ToString());
                res += Convert.ToDouble(val["amount"].ToString());
            }

        }
        res = (coursefees - res)+(((coursefees - res) * 12.36) / 100);

        return res;
    }


}