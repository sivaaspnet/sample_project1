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

public partial class Onlinestudents2_superadmin_ChangeOldInvoice : System.Web.UI.Page
{
    string _Qry = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Double Course_Fees_details;

        Double Totalamount;

        

        _Qry = "Select count(*) from Old_install_amountdetails where Receipt_no=0 And Student_id='" + TextBox1.Text + "'";
        int ccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (ccount > 0)
        {
            _Qry = "Delete From Old_install_amountdetails where student_id='" + TextBox1.Text + "' And Receipt_no=0";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        _Qry = "Select total_Course_fees,total_install_amount as Amount From Old_install_amountdetails WHERE Receipt_no>0 And Student_id='" + TextBox1.Text + "'";
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

        Course_Fees_details = Convert.ToDouble(dttotal.Rows[0]["total_Course_fees"].ToString()) - totalamt;
        double inst_amt = (Course_Fees_details / Convert.ToInt32(TextBox2.Text));
        inst_amt = (inst_amt / 110.3) * 100;
        inst_amt = Math.Round(inst_amt, 0);
        double inst_tax = Math.Round(((inst_amt * 10.3) / 100), 0);
        double inst_totamt = inst_amt + inst_tax;

            _Qry = "Select * from Old_install_amountdetails WHERE Student_id='" + TextBox1.Text + "' order by ID desc";
            SqlDataReader dr;
            dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString,_Qry);
            if (dr.HasRows)
            {
                dr.Read();
                for (int i = 0; i < Convert.ToInt32(TextBox2.Text); i++)
                {
                    int ins_no = Convert.ToInt32(dr["install_number"]) + i + 1;
                    _Qry = "insert into Old_Install_AMountDetails (Center_code,Invoice_no,Receipt_no,student_id,Course_ID,";
                    _Qry += " COurse_Fees,COurse_tax,";
                    _Qry += "total_course_fees,install_amount,install_amount_Tax,install_number,total_install_amount,status) values(";
                    _Qry += "" + dr["Center_Code"] + "," + dr["Invoice_No"] + ",0,'" + TextBox1.Text + "','" + dr["Course_ID"] + "',";
                    _Qry += "'" + dr["COurse_Fees"] + "','" + dr["COurse_tax"] + "','" + dr["total_course_fees"] + "',";
                    _Qry += "'" + inst_amt + "','" + inst_tax + "'," + ins_no + ",'" + inst_totamt + "','Pending')";

                    //Response.Write(_Qry);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                }
                dr.Close();
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = "Select * from Old_install_amountdetails WHERE Student_id='" + TextBox1.Text + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        _Qry = TextBox3.Text;
        //Response.Write(_Qry);
        //Response.End();
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        _Qry = "select * from Oldreceipt_details where rec_no='" + TextBox4.Text + "'";

        int cccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (cccount > 0)
        {
            _Qry = "select count(*) from Old_Install_AMountDetails where student_Id='" + TextBox1.Text + "' And receipt_no='" + TextBox4.Text + "'";
            int checkins = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (checkins > 0)
            {

            }
            else
            {
                _Qry = "Select * from OldReceipt_Details where Student_id='" + TextBox1.Text + "' And rec_no='" + TextBox4.Text + "'";

                SqlDataReader dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();

                    _Qry = "select count(*) from Old_Install_AMountDetails where Receipt_no=0 And student_Id='" + TextBox1.Text + "'";
                    int cccountold = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                    if (cccountold > 0)
                    {
                        _Qry = "select count(*) from Old_Install_AMountDetails where Receipt_no<=" + dr["rec_no"] + " And Receipt_No<>0 And student_Id='" + TextBox1.Text + "'";
                        int reccount1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        reccount1 = reccount1 + 1;

                        _Qry = "Update Old_Install_AMountDetails set install_amount=" + dr["amount"] + ",install_amount_tax=" + dr["tax_amt"] + ",install_number=" + reccount1 + ",";
                        _Qry += "total_install_amount=" + dr["total_amt"] + ",status='Completed',Receipt_no=" + dr["rec_no"] + " where student_Id='" + TextBox1.Text + "' And ID=(Select Top 1 ID from Old_Install_AMountDetails where student_id='" + TextBox1.Text + "' And Receipt_No=0 Order By ID Desc)";

                        //Response.Write(_Qry);
                        //Response.End();

                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    }
                    else
                    {
                        _Qry = "select count(*) from Old_Install_AMountDetails where Receipt_no<=" + dr["rec_no"] + " And Receipt_No<>0 And student_Id='" + TextBox1.Text + "'";
                        int reccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                        reccount = reccount + 1;

                        _Qry = "select * from Old_Install_AMountDetails where student_Id='" + TextBox1.Text + "'";
                        SqlDataReader drr;
                        drr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                        if (drr.HasRows)
                        {
                            drr.Read();
                            _Qry = "Insert into Old_Install_AMountDetails(Center_code,Invoice_no,Receipt_no,student_id,Course_ID,COurse_Fees,COurse_tax,total_course_fees,install_amount,install_amount_Tax,install_number,total_install_amount,status) Values";
                            _Qry += "(" + drr["Center_code"] + "," + drr["Invoice_no"] + "," + dr["rec_no"] + ",'" + drr["student_id"] + "','" + drr["Course_ID"] + "'," + drr["COurse_Fees"] + "," + drr["COurse_tax"] + "," + drr["total_course_fees"] + "," + dr["amount"] + "," + dr["tax_amt"] + "," + reccount + "," + dr["total_amt"] + ",'Completed')";
                            //Response.Write(_Qry);
                            //Response.End();
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            drr.Close();
                        }
                    }
                    dr.Close();
                }
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        double amount;
        double tax;
        double totamt;
        _Qry = "select total_amount from OldEnrolled_Details where student_Id='" + TextBox1.Text + "'";
        SqlDataReader dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            amount = Convert.ToDouble(dr["total_amount"]);
            tax = (amount * 10.3) / 100;
            totamt = amount + tax;

            _Qry = "Update OldEnrolled_Details set total_amount_tax=" + tax + ",total_amount_paid=" + totamt + " where student_Id='" + TextBox1.Text + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = "Update Old_Install_AMountDetails set Course_Tax=" + tax + ",total_Course_fees=" + totamt + " where student_Id='" + TextBox1.Text + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = "Update OldInvoice_Details set total_amount_tax=" + tax + ",total_amount_paid=" + totamt + " where student_Id='" + TextBox1.Text + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            dr.Close();
        }
    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        _Qry = "Update OldEnrolled_Details set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And Center_Code=" + txtcencode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update Old_Install_Amountdetails set Student_ID='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And Center_Code=" + txtcencode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update OldReceipt_details set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And Center_Code=" + txtcencode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update OldInvoice_Details set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And Center_Code=" + txtcencode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        _Qry = "Update adm_studentid set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update adm_generalinfo set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update adm_personalparticulars set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update adm_course_empdetails set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        //_Qry = "Update img_followups set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        _Qry = "Update install_amountdetails set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update Receipt_Details set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update Invoice_Details set student_id='" + txtchgstuid.Text + "' where student_id='" + TextBox1.Text + "' And centre_code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        _Qry = "Update adm_generalinfo set payment_coursefee=" + txtCoursefees.Text + ",payment_installments=" + txtCoursefees.Text + " where student_id='" + TextBox1.Text + "' And Centre_Code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        double tax = Convert.ToDouble(txtCoursefees.Text);
        double tax1;
        tax1 = System.Math.Round(((tax * 10.3) / 100), 0);
        double totfee = tax + tax1;
        _Qry = "Update install_amountdetails set course_fees=" + txtCoursefees.Text + ",course_tax=" + tax1 + ",totalcourse_fees=" + totfee + " where student_id='" + TextBox1.Text + "' And Centre_Code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update Receipt_Details set amount=" + txtCoursefees.Text + ",tax_amount=" + tax1 + ",total_amount=" + totfee + " where student_id='" + TextBox1.Text + "' And Centre_Code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "Update Invoice_Details set course_fee=" + txtCoursefees.Text + " where student_id='" + TextBox1.Text + "' And Centre_Code='" + txtcencode.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    }
}
