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
using System.Data.SqlClient;

public partial class superadmin_UpdateOldStuddetails : System.Web.UI.Page
{
    string _Qry,studentid;
    int insno;
    static int re = 0;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCourse();
        }
        
    }

    private void FillCourse()
    {
        _Qry = "Select Program from OldCourse_details Order By Course_ID";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlCourse_Id.DataSource = dt;
        ddlCourse_Id.DataTextField = "Program";
        ddlCourse_Id.DataValueField = "Program";
        ddlCourse_Id.DataBind();
        ddlCourse_Id.Items.Insert(0, new ListItem("Select", ""));
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string enq_no = "";
        _Qry = "Select Enquiry_No From OldEnrolled_Details where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            enq_no = dr["Enquiry_No"].ToString();
            dr.Close();
        }

        _Qry = "Update OldEnquiry_Details set enq_Name='" + txt_studname.Text + "',Permanent_Address='" + txt_addr.Text + "',Mobile='" + txt_mob.Text + "'Where Enquiry_No='" + enq_no + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        _Qry = "Update OldReceipt_Details set Student_Name='" + txt_studname.Text + "' Where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        double calctax = 0;
        double amt = Convert.ToDouble(txt_coursefees.Text);
        calctax = System.Math.Round(((amt * 10.3) / 100), 0);

        double tot_tax = System.Math.Round((amt + calctax), 0);

        _Qry = "Update OldEnrolled_Details set Course_Id='" + ddlCourse_Id.SelectedValue + "', total_amount=" + amt + ",total_amount_tax=" + calctax + ",total_amount_paid=" + tot_tax + " where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        _Qry = "Update Old_Install_AmountDetails set Course_Id='" + ddlCourse_Id.SelectedValue + "',Course_Fees=" + amt + ",Course_tax=" + calctax + ",total_course_fees=" + tot_tax + " where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        _Qry = "Update OldReceipt_Details set Course_Code='" + ddlCourse_Id.SelectedValue + "' where student_id='" + txt_stuid.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        _Qry = "Update OldInvoice_Details set Course_Id='" + ddlCourse_Id.SelectedValue + "',Total_Amount=" + amt + ",total_amount_tax=" + calctax + ",total_amount_paid=" + tot_tax + " where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string enq_no = "";
        _Qry = "Select Enquiry_No From OldEnrolled_Details where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            enq_no = dr["Enquiry_No"].ToString();
            dr.Close();
        }

        _Qry = "Select Enq_Name,Permanent_Address,Mobile From OldEnquiry_Details Where Enquiry_No='" + enq_no + "' And center_code=" + txt_Centercode.Text + "";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_studname.Text = dt.Rows[0]["Enq_Name"].ToString();
            txt_addr.Text = dt.Rows[0]["Permanent_Address"].ToString();
            txt_mob.Text = dt.Rows[0]["Mobile"].ToString();
        }

        _Qry = "Select Course_Id,Replace(Round(total_amount,0),'.00','') as total_amount from OldEnrolled_Details where student_id='" + txt_stuid.Text + "' And center_code=" + txt_Centercode.Text + "";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            ddlCourse_Id.SelectedValue = dt1.Rows[0]["Course_Id"].ToString();
            txt_coursefees.Text = dt1.Rows[0]["total_amount"].ToString();
        }
    }
}
