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
using System.Collections.Generic;
using System.Web.Mail;

public partial class Onlinestudents2_directmultiinvoice : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1;
    string inv_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {



            txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));
        //  fillcoursedropdown();
          GetSubcategoryDetails();
           
        }

    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_studentid.Text);
    }
    
    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
       
    }

    #region GetSubcategory Details
    private void GetSubcategoryDetails()
    {
        int i = 0;
        string jss = "";
        string js = "";
        for (i = 0; i < 2; i++)
        {
            if (i == 0)
            {

                jss = GenerateJavascript();
                Page.RegisterClientScriptBlock("SubcategoryDetail", jss);
            }
            else
            {

                js = generatecoursefee();
                Page.RegisterClientScriptBlock("SubcategoryDetail1", js);
            }

        }


    }
    #endregion


    #region Genrating Javascript For Subcategory
    public string GenerateJavascript()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
            return "";
        }
        else
        {
            string qry1 = "";
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {
                qry1 = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.coursename,a.course_id,b.Program,a.Program";
            }
            else
            {
                qry1 = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";
            }

            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(qry1);
            string jss = "";
            if (dt1.Rows.Count > 0)
            {
                int j;
                jss = "<script language='javascript' type='text/javascript'>\n";
                jss += "var coursetrack=new Array();\n";
                for (j = 0; j < dt1.Rows.Count; j++)
                {
                    jss += "coursetrack[" + j + "]=new Array();\n";
                    //jss += "coursetrack[" + j + "]['track']='" + dt1.Rows[j]["track"].ToString() + "'\n";
                    jss += "coursetrack[" + j + "]['course_id']='" + dt1.Rows[j]["course_id"].ToString() + "'\n";
                    jss += "coursetrack[" + j + "]['coursename']='" + dt1.Rows[j]["Program"].ToString() + "'\n";
                }
                jss += "</script>";
            }
            return jss;
        }
    }

    #endregion

    private string generatecoursefee()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
            return "";
        }
        else
        {
            string qry = "";
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {
                qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='ICH-101'";
            }
            else
            {
                qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";
            }
            qry = "select program,lump_sum,instal_amount,tax,noofinstall,track  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1 ";


            //Response.Write(qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i, normalval = 0, fastval = 0;
                js = "<script language='javascript' type='text/javascript'>\n";
                js += "var courseFeesfast=new Array();\n";
                js += "var courseFeesnormal=new Array();\n";
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["track"].ToString().ToLower() == "fast")
                    {
                        js += "courseFeesfast[" + fastval + "]=new Array();\n";
                        js += "courseFeesfast[" + fastval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        fastval += 1;
                    }
                    if (dt.Rows[i]["track"].ToString().ToLower() == "normal")
                    {
                        js += "courseFeesnormal[" + normalval + "]=new Array();\n";
                        js += "courseFeesnormal[" + normalval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        normalval += 1;
                    }
                }
                js += "</script>";
            }
            return js;
        }
    }
    private void GetCoursefee()
    {
        string js = "";
        js = generatecoursefee();
        Page.RegisterClientScriptBlock("SubcategoryDetail", js);
    }

    private void fillcoursedropdown()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            
           
            //_Qry = "select top 1 a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year > '" + HiddenField2.Value + "' and  a.coursecode='" + Label2.Text + "' Group By a.coursename,a.course_id,b.Program,a.Program";

           // _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "'  Group By a.coursename,a.course_id,b.Program,a.Program";
            if (Label2.Text == "course")
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "'  Group By a.coursename,a.course_id,b.Program,a.Program";

            }
            else
            {
                _Qry = "select top 1 a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year > '" + HiddenField2.Value + "' and  a.coursecode='" + Label2.Text + "' Group By a.coursename,a.course_id,b.Program,a.Program";

            }
//            _Qry = @"select distinct a.Program,a.course_id from img_centre_coursefee_details b 
//inner join img_coursedetails a on a.course_id=b.program where 
//centre_code='IBG-104'";
           // Response.Write(_Qry);
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            txt_coursenamee.DataSource = dt;
            txt_coursenamee.DataValueField = "course_id";
            txt_coursenamee.DataTextField = "Program";
            txt_coursenamee.DataBind();
            txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));
        }
    }




    protected void btnsubmit5_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            string str = txt_coursedatedate.Text;
            string[] split = str.Split('-');
            string datet = split[2] + "-" + split[1] + "-" + split[0];
            string str1 = txt_installdate.Text;
            string[] split1 = str1.Split('-');
            string datet2 = split1[2] + "-" + split1[1] + "-" + split1[0];
            cmd.CommandText = "[sp_dualinvoice]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
            cmd.Parameters.AddWithValue("studentid",txt_studentid.Text);
            cmd.Parameters.AddWithValue("course", txt_coursenamee.SelectedValue);
            cmd.Parameters.AddWithValue("track", ddtrack.SelectedValue);
            cmd.Parameters.AddWithValue("installmenttype", ddl_payment.SelectedValue);
            cmd.Parameters.AddWithValue("initialAmt", txt_netamount.Text);
            cmd.Parameters.AddWithValue("taxinitialAmt", txt_vat.Text);
            cmd.Parameters.AddWithValue("totalinitialAmt", netamount.Value);
            cmd.Parameters.AddWithValue("noofInstallment", txt_instalamt1.Text);
            cmd.Parameters.AddWithValue("cashType", ddlpaymentmode.SelectedValue);
            cmd.Parameters.AddWithValue("bankname", txtbankname.Text);
            cmd.Parameters.AddWithValue("chequeNo", txtchequeno.Text);
            cmd.Parameters.AddWithValue("chequeDt", txtchequeno.Text);
            cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
            cmd.Parameters.AddWithValue("installmentDate", datet2);
            cmd.Parameters.AddWithValue("coursestartdate", datet);
            cmd.Parameters.Add("@invoiceNo", SqlDbType.VarChar, 50);
            cmd.Parameters["@invoiceNo"].Direction = ParameterDirection.Output;
            Conn.Open();
            cmd.ExecuteNonQuery();
            inv_id = (string)cmd.Parameters["@invoiceNo"].Value;
            Conn.Close();
            switch (inv_id)
            {
                case "E1":
                    Label1.Text = "No running number in receipt";
                    break;
                case "E2":
                    Label1.Text = "No running number in invoice";
                    break;
                case "E3":
                    Label1.Text = "No Coursefees";
                    break;
                case "E4":
                    Label1.Text = "No details of user";
                    break;
                case "E5":
                    Label1.Text = "No centre code";
                    break;
                case "E6":
                    Label1.Text = "student still have pending";
                    break;
                case "E7":
                    Label1.Text = "wrong course";
                    break;
                default:
                  
                    Response.Redirect("InvoiceDetails.aspx?invno=" + inv_id);
                  
                    break;


            }
           
           
        }
        catch (Exception ex)
        {
          Label1.Text = ex.ToString();
            //Label1.Text = "Input Data Is Not In Correct Format";
        }

    }




    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // 30 Days mimimum different for installment for course
            // _Qry = "select coursecode,program,course_id,year from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "' and a.status='active'    and DATEDIFF(day,dateins,getdate())>30";
            // _Qry = "select coursecode,program,course_id,year from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "' and a.status='active' and month(dateins)!=month(getdate()) and year(dateins)!=year(getdate()) ";

            //Query to check last inserted month and year are not same with current month and year
            //_Qry = @"select coursecode,program,course_id,year,dateins from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "'  and a.status='active' and  (SELECT DateDiff(month,CAST(CONVERT(varchar, year(getdate())) + '-' + CONVERT(varchar, month(getdate())) +  '-01' AS DATETIME),CAST(CONVERT(varchar, year(dateins )) + '-' + CONVERT(varchar, month(dateins)) +  '-01' AS DATETIME))) =0 AND (SELECT DateDiff(year,CAST(CONVERT(varchar, year(getdate())) + '-' + CONVERT(varchar, month(getdate())) +  '-01' AS DATETIME),CAST(CONVERT(varchar, year(dateins )) + '-' + CONVERT(varchar, month(dateins)) +  '-01' AS DATETIME))) =0";
            _Qry = @"select coursecode,program,course_id,year,dateins from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "'  and a.status='active' ";
            //Response.Write(_Qry);
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_coursename.Text = dt.Rows[0]["program"].ToString();
                //  HiddenField1.Value = dt.Rows[0]["course_id"].ToString();
                //  HiddenField2.Value = dt.Rows[0]["year"].ToString();
                // Label2.Text = dt.Rows[0]["coursecode"].ToString();
                Label2.Text = "course";
                fillcoursedropdown();
                GetSubcategoryDetails();
            }
            else
            {
                Label1.Text = "Student Enrolled in current month,Use Extend To New Course option to add another course..!";
            }
        }
    }
}
