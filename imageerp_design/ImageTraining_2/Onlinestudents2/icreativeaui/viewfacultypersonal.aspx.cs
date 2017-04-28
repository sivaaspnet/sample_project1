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

public partial class superadmin_viewfacultypersonal : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            displayonload();
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            _Qry = "update faculty_details set fac_permanentaddress='" + txt_peraddress.Text + "',fac_tempaddress='" + txt_tempadd.Text + "',fac_mobile='" + txt_mobile.Text + "',fac_landline='" + txt_landline.Text + "',fac_email='" + txt_email.Text + "' where faculty_id='" + Request.QueryString["fac_id"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            lbl_error.Text = "Faculty details updated sucessfully";
        }
        catch (Exception ex)
        {
            lbl_error.Text = "Please Contact Admin";
        }
    }
   private void displayonload()
    {
        try
        {
            _Qry = "select fac_name,fac_dob AS fac_dob,fac_permanentaddress,fac_tempaddress,fac_mobile,fac_landline,fac_email from faculty_details where faculty_id='" + Request.QueryString["fac_id"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txt_facname.Text = dt.Rows[0]["fac_name"].ToString();
                //txt_dob.Text = datetdob;

                string dateofbirth = dt.Rows[0]["fac_dob"].ToString();
                string[] splitdob = dateofbirth.Split('/');
                
                string[] splitdob1 = splitdob[2].Split(' ');
                string datetdob = splitdob[1] + "-" + splitdob[0] + "-" + splitdob1[0];
                //Response.Write(datetdob);
                //Response.End();

                txt_dob.Text = datetdob;
                txt_peraddress.Text = dt.Rows[0]["fac_permanentaddress"].ToString();
                txt_tempadd.Text = dt.Rows[0]["fac_tempaddress"].ToString();
                txt_mobile.Text = dt.Rows[0]["fac_mobile"].ToString();
                txt_landline.Text = dt.Rows[0]["fac_landline"].ToString();
                txt_email.Text = dt.Rows[0]["fac_email"].ToString();
            }
        }
        catch (Exception ex)
        {
            lbl_error.Text = "Please Contact Admin";
        }
    }
}
