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

public partial class Personalview : System.Web.UI.Page
{
    string _Qry,_Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            display_onload();
        }
    }
    private void display_onload()
    {
        _Qry = "select f2.Created_By,f2.modified_By,f1.enq_id,f1.enq_number,f1.enq_personal_name,f1.enq_personal_mobile,f1.enq_personal_email,f1.enq_permanant_address,convert(varchar,f1.enq_personal_dob,105) as enq_personal_dob,f1.enq_permanant_district,f1.enq_permanant_city,f1.enq_permanant_state,f1.enq_permanant_pincode,f2.enq_parent_name,f2.enq_parent_company,f2.enq_parent_designation,f2.enq_parent_income,f1.enq_aboutimage,f2.enq_parent_phone,f2.enq_parent_mobile,f2.enq_parent_email,f2.enq_student_profile from Img_enquiryform f1 join Img_enquiryform1 f2 on f1.enq_number=f2.enq_number where f1.enq_number='" + Request.QueryString["enqno"] + "'";

        //Response.Write(_Qry);
        //Response.End();


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblenq_id.Text = dt.Rows[0]["enq_number"].ToString();
            lblname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            lblparentname.Text = dt.Rows[0]["enq_parent_name"].ToString();
            lblcompany.Text = dt.Rows[0]["enq_parent_company"].ToString();
            lbldesignatio.Text = dt.Rows[0]["enq_parent_designation"].ToString();  
            lblincome.Text = dt.Rows[0]["enq_parent_income"].ToString();
            if (lblincome.Text == "0")
            {
                lblincome.Text = "";
            }
            txtmobile.Text=dt.Rows[0]["enq_personal_mobile"].ToString();
            txtemail.Text = dt.Rows[0]["enq_personal_email"].ToString();

            lbladdress.Text = dt.Rows[0]["enq_permanant_address"].ToString();
            lbldist.Text = dt.Rows[0]["enq_permanant_district"].ToString();
            lblcityy.Text = dt.Rows[0]["enq_permanant_city"].ToString();
            lblstate.Text = dt.Rows[0]["enq_permanant_state"].ToString();
            lblpincod.Text=dt.Rows[0]["enq_permanant_pincode"].ToString();

            lblphone.Text = dt.Rows[0]["enq_parent_phone"].ToString();
            lblmobile.Text = dt.Rows[0]["enq_parent_mobile"].ToString();
            lblemailid.Text = dt.Rows[0]["enq_parent_email"].ToString();

            ddl_profile.SelectedValue = dt.Rows[0]["enq_student_profile"].ToString();
            ddl_source.SelectedValue = dt.Rows[0]["enq_aboutimage"].ToString();
            txtenq_By.Text = dt.Rows[0]["Created_By"].ToString();
            txtmod_By.Text = dt.Rows[0]["modified_By"].ToString();
            txtdob.Text = dt.Rows[0]["enq_personal_dob"].ToString();
            //string dob = dt.Rows[0]["enq_personal_dob"].ToString();
            //string[] strSplitArr = dob.Split(' ');
            //string dob1 = strSplitArr[0].ToString();

            //string dob2 = dob1;
            ////Response.Write(dob2);
            //string[] strSplitArr1 = dob2.Split('/');

            //string smonth = "";
            //int smonth1 = Convert.ToInt32(strSplitArr1[0]);

            //if (smonth1 < 9)
            //{
            //    smonth = "0" + strSplitArr1[0].ToString();
            //}
            //else
            //{
            //    smonth = strSplitArr1[0].ToString();
            //}

            //string sdate = strSplitArr1[1].ToString();
            //string syear = strSplitArr1[2].ToString();
            ////Response.Write(smonth);
            //string apdate = sdate + "-" + smonth + "-" + syear;

            ////Response.Write(apdate);
            ////Response.End();
            //txtdob.Text = apdate;

        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (lblincome.Text == "")
        {
            lblincome.Text = "0";
        }
        string dob2 = txtdob.Text;
        string[] strSplitArr1 = dob2.Split('-');

        string smonth = strSplitArr1[1].ToString();
        string sdate = strSplitArr1[0].ToString();
        string syear = strSplitArr1[2].ToString();

        string apdate = syear + "-" + smonth + "-" + sdate;

        _Qry = "update Img_enquiryform set enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblname.Text) + "',enq_personal_dob='" + apdate + "',enq_present_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbladdress.Text) + "',enq_permanant_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbladdress.Text) + "',enq_permanant_district='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbldist.Text) + "',enq_permanant_city='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblcityy.Text) + "',enq_permanant_state='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblstate.Text) + "',enq_permanant_pincode='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblpincod.Text) + "',enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "',enq_aboutimage='" + ddl_source.SelectedValue + "' ,enq_personal_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtemail.Text) + "' where enq_number='" + lblenq_id.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

        _Qry1 = "update Img_enquiryform1 set enq_parent_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblparentname.Text) + "',enq_parent_company='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblcompany.Text) + "',enq_parent_designation='" + MVC.CommonFunction.ReplaceQuoteWithTild(lbldesignatio.Text) + "',enq_parent_income='" + lblincome.Text + "',enq_parent_phone='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblphone.Text) + "',enq_parent_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblmobile.Text) + "',enq_parent_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblemailid.Text) + "',enq_student_profile='" + ddl_profile.SelectedValue + "',Modified_By='" + Session["SA_Username"] + "' where enq_number='" + lblenq_id.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

        _Qry1 = "Select Student_Id from adm_generalinfo where enq_number='" + lblenq_id.Text + "'";
        SqlDataReader dr;

        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry1);

        if (dr.HasRows)
        {
            dr.Read();
            if (dr["Student_Id"].ToString() == "" || dr["Student_Id"].ToString() == null)
            {

            }
            else
            {
                string temp = FileUpload1.FileName;
                Random rand = new Random();
                int code = rand.Next(9999);
                temp = code + temp;
                string img = "~/studentphoto/" + temp;
                FileUpload1.SaveAs(Server.MapPath(img));
                //Image2.ImageUrl = img;
                string stud_id = dr["Student_Id"].ToString();
                _Qry1 = "Update adm_personalparticulars set photo='" + temp + "',enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblname.Text) + "' where student_id='" + stud_id + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
            }
            dr.Close();
        }


       
        display_onload();
        lblerror.Text = "Personal details updated sucessfully";
    }
}
