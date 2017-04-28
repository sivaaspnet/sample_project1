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

public partial class superadmin_viewfacultyexpdetails : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        display();
    }
    void display()
    {
         _Qry = "select fac_exp_company,fac_exp_desg,fac_exp_fromdate AS fac_exp_fromdate,fac_exp_todate AS fac_exp_todate,fac_exp_description,fac_exp_reason from faculty_details where faculty_id='" + Request.QueryString["fac_id"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lbl_company.Text = dt.Rows[0]["fac_exp_company"].ToString();
            lbl_designation.Text = dt.Rows[0]["fac_exp_desg"].ToString();

            string fromdate = dt.Rows[0]["fac_exp_fromdate"].ToString();
            string[] splitdob = fromdate.Split('/');

            string[] splitdob1 = splitdob[2].Split(' ');
            string fromtdate = splitdob[1] + "-" + splitdob[0] + "-" + splitdob1[0];

            lbl_fromdate.Text = fromtdate;

            string Todate = dt.Rows[0]["fac_exp_todate"].ToString();
            string[] splitdob12 = Todate.Split('/');

            string[] splitdob112 = splitdob12[2].Split(' ');
            string Totdate = splitdob12[1] + "-" + splitdob12[0] + "-" + splitdob112[0];

            lbl_todate.Text = Totdate;
            lbl_description.Text = dt.Rows[0]["fac_exp_description"].ToString();
            lbl_reason.Text = dt.Rows[0]["fac_exp_reason"].ToString();
            if (lbl_company.Text == "" && lbl_designation.Text=="")
            {
                lbl_designation.Text = "";
                lbl_company.Text = "";
                lbl_fromdate.Text = "";
                lbl_todate.Text = "";
                lbl_description.Text = "";
                lbl_reason.Text = "";
                lbl_error.Text = "No details available";
            }
        }
    }
    
}
