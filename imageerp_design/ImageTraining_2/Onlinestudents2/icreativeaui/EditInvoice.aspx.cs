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
using System.Data.SqlClient;

public partial class Onlinestudents2_superadmin_EditInvoice : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Double Course_Fees_details;

        Double Totalamount;



        _Qry = "Select count(*) from Install_AmountDetails where Receipt_no IS NULL And Student_id='" + TextBox1.Text + "'";
        int ccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (ccount > 0)
        {
            _Qry = "Delete From Install_amountdetails where student_id='" + TextBox1.Text + "' And Receipt_no IS NULL";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        _Qry = "Select totalCourse_fees,tatamtpaidwithtax as Amount From Install_amountdetails WHERE Receipt_no>0 And Receipt_no IS NOT NULL And Student_id='" + TextBox1.Text + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dttotal = new DataTable();
        dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
        double totalamt = 0;
        for (int i = 0; i < dttotal.Rows.Count; i++)
        {
            if (totalamt == 0)
            {
                totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
            }
            else
            {
                double dbval = 0;
                dbval = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                totalamt = totalamt + dbval;
            }
        }

        //Response.Write("cf:" + dttotal.Rows[0]["total_Course_fees"].ToString());
        //Response.Write("pf:" + totalamt);
        //Response.End();

        Course_Fees_details = Convert.ToDouble(dttotal.Rows[0]["totalCourse_fees"].ToString()) - totalamt;
        double inst_amt = (Course_Fees_details / Convert.ToInt32(TextBox2.Text));
        inst_amt = (inst_amt / 110.3) * 100;
        inst_amt = Math.Round(inst_amt, 0);
        double inst_tax = Math.Round(((inst_amt * 10.3) / 100), 0);
        double inst_totamt = inst_amt + inst_tax;

        _Qry = "Select * from Install_amountdetails WHERE Student_id='" + TextBox1.Text + "' order by instal_id desc";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            for (int i = 0; i < Convert.ToInt32(TextBox2.Text); i++)
            {
                int ins_no = Convert.ToInt32(dr["instal_number"]) + i + 1;
                _Qry = "insert into Install_amountdetails (Centre_code,Invoice_no,student_id,Course_ID,";
                _Qry += " COurse_Fees,COurse_tax,";
                _Qry += "totalcourse_fees,instalment_amount,instalamounTax,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date,status,course_name,install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax) values(";
                _Qry += "'" + dr["Centre_code"] + "'," + dr["Invoice_No"] + ",'" + TextBox1.Text + "','" + dr["Course_ID"] + "',";
                _Qry += "'" + dr["COurse_Fees"] + "','" + dr["COurse_tax"] + "','" + dr["totalcourse_fees"] + "',";
                _Qry += "'" + inst_amt + "','" + inst_tax + "','" + inst_totamt + "'," + ins_no + ",'" + inst_amt + "','" + inst_tax + "','" + inst_totamt + "',getdate(),'Pending','" + dr["Course_name"] + "',getdate(),'" + inst_amt + "','" + inst_tax + "','" + inst_totamt + "','" + inst_amt + "','" + inst_tax + "','" + inst_totamt + "')";

                //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            dr.Close();
        }
    }
}
