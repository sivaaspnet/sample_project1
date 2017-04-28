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

public partial class Onlinestudents2_Default2 : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1;
    string inv_id = "";
    string rec_id = "";

    string manual;   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["res"]=="upt")
    {
        Label1.Text = "Student Already Enrolled..!";

    }

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            hdncentrecode.Value=Session["SA_centre_code"].ToString();

            int mm = System.DateTime.Now.Month;
            if (mm == 1)
            {
                ddl_month.SelectedValue = "Jan";
            }
            if (mm == 2)
            {
                ddl_month.SelectedValue = "Feb";
            }
            if (mm == 3)
            {
                ddl_month.SelectedValue = "Mar";
            }
            if (mm == 4)
            {
                ddl_month.SelectedValue = "Apr";
            }
            if (mm == 5)
            {
                ddl_month.SelectedValue = "May";
            }
            if (mm == 6)
            {
                ddl_month.SelectedValue = "Jun";
            }
            if (mm == 7)
            {
                ddl_month.SelectedValue = "Jul";
            }
            if (mm == 8)
            {
                ddl_month.SelectedValue = "Aug";
            }
            if (mm == 9)
            {
                ddl_month.SelectedValue = "Sep";
            }
            if (mm == 10)
            {
                ddl_month.SelectedValue = "Oct";
            }
            if (mm == 11)
            {
                ddl_month.SelectedValue = "Nov";
            }
            if (mm == 12)
            {
                ddl_month.SelectedValue = "Dec";
            }

            
            fillgrid();
           fillcoursedropdown();
          GetSubcategoryDetails();
                  
           
           
        }

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
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
            }
            else
            {
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
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
                    jss += "coursetrack[" + j + "]['coursetype']='" + dt1.Rows[j]["coursetype"].ToString() + "'\n";
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
            qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";


            //Response.Write(qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i;
                js = "<script language='javascript' type='text/javascript'>\n";
                js += "var courseFees=new Array();\n";

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    js += "courseFees[" + i + "]=new Array();\n";
                    js += "courseFees[" + i + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                    js += "courseFees[" + i + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                    js += "courseFees[" + i + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                    js += "courseFees[" + i + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";


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
            _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' and   a.status='Active' and a.year=1 Group By a.coursename,a.course_id,b.Program,a.Program";
          
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            txt_coursenamee.DataSource = dt;
            txt_coursenamee.DataValueField = "course_id";
            txt_coursenamee.DataTextField = "Program";
            txt_coursenamee.DataBind();
            txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));
            txt_coursepositioned.DataSource = dt;
            txt_coursepositioned.DataValueField = "course_id";
            txt_coursepositioned.DataTextField = "Program";
            txt_coursepositioned.DataBind();
            txt_coursepositioned.Items.Insert(0, new ListItem("Select", ""));

        }
    }




    protected void btnsubmit5_Click1(object sender, EventArgs e)
    {
        //_Qry = "select count(*) from img_enquiryform  where enq_personal_name='" + txtname.Text + "' and enq_personal_mobile='" + txtmobile.Text + "' and centre_code='"+Session["SA_centre_code"]+"'";

        _Qry = @"select count(*) from img_enquiryform im1 inner join img_enquiryform1 im2 on im1.enq_number=im2.enq_number 
inner join adm_personalparticulars adm on adm.enq_number=im2.enq_number  where
enq_personal_mobile='" + txtmobile.Text + "' and im1.enq_personal_name='" + txtname.Text + "' and im1.centre_code='" + Session["SA_centre_code"] + "'";
        int checkcount = 0;
            checkcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (checkcount > 0)
            {
             
            Response.Redirect("QuickAdmission.aspx?res=upt#tabs-5");
     
            }
            else
            
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
                cmd.CommandText = "[spQuickEnrollmentNew]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
                cmd.Parameters.AddWithValue("studName", txtname.Text);
                cmd.Parameters.AddWithValue("stuprofile", ddl_profile.SelectedValue);
                cmd.Parameters.AddWithValue("aboutimage", ddl_aboutimage.SelectedValue);
                cmd.Parameters.AddWithValue("mobileNo", txtmobile.Text);
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
                cmd.Parameters.AddWithValue("chequeDt", txtchequeno0.Text);
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
                        Label1.Text = "Student Already Enrolled";
                        break;
                    default:
                        // ToTechnical();
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
       


    }


   
    private void ToTechnical()
    {
        MailMessage SendMail = new MailMessage();
        _Qry = "select centre_location from img_centredetails where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dtcenloc = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dtcenloc.Rows.Count > 0)
        {
            SendMail.From = dtcenloc.Rows[0]["centre_location"].ToString() + "@imageil.com";
           
        }
        else
        {
            SendMail.From = "ERP@imageil.com";
        }

        _Qry = "select  studentid,coursename from erp_invoicedetails inner join img_coursedetails on courseId=course_id where invoiceId='" + inv_id.ToString() + "' and  centerCode='" + Session["SA_centre_code"] + "'";
        DataTable dtcour = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = "select centre_useremail from img_centrelogin  where centre_code='" + Session["SA_centre_code"] + "' and role='Technical Head' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string send = dt.Rows[0]["centre_useremail"].ToString();
            SendMail.To = send;
            SendMail.Subject = "Student Enrolled";
            SendMail.BodyFormat = MailFormat.Html;
            string GetTxt = "The Student " + txtname.Text + " (" + dtcour.Rows[0]["studentid"].ToString() + ") " + " Has Got Enrolled For " + dtcour.Rows[0]["coursename"].ToString() + "";
            SendMail.Body = GetTxt;
            SmtpMail.Send(SendMail);
        }
    }









    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;

        cmd.CommandText = "[quickreceipt]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);

        cmd.Parameters.AddWithValue("mode", ddl_paymode.SelectedValue);
        cmd.Parameters.AddWithValue("bankname", txt_bankname.Text);
        cmd.Parameters.AddWithValue("dddate",dddate.Text);
        cmd.Parameters.AddWithValue("ddno",txt_ddcc.Text);
        cmd.Parameters.AddWithValue("contact", TextBox1.Text);




        cmd.Parameters.AddWithValue("course", txt_coursepositioned.SelectedValue);
        cmd.Parameters.AddWithValue("totalinitialAmt", txt_initialamt.Text);
        double b = Convert.ToDouble(txt_initialamt.Text) / (Convert.ToDouble(HiddenField2.Value) + 100);
     
        double a = b * 100;
        double c = a * Convert.ToDouble(HiddenField2.Value) / 100;
        cmd.Parameters.AddWithValue("initialAmt", Math.Round(a));
        cmd.Parameters.AddWithValue("taxinitialAmt", c);
        cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
        cmd.Parameters.AddWithValue("studentname", txt_studname.Text);
        cmd.Parameters.AddWithValue("month", ddl_month.SelectedValue);
        cmd.Parameters.AddWithValue("paywords", hdnpayinword.Value);
        cmd.Parameters.Add("@runningReceipt", SqlDbType.VarChar, 50);
        cmd.Parameters["@runningReceipt"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@student", SqlDbType.VarChar, 50);
        cmd.Parameters["@student"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        rec_id = (string)cmd.Parameters["@runningReceipt"].Value;
        string student = (string)cmd.Parameters["@student"].Value;
        Conn.Close();
        Response.Redirect("receiptprint.aspx?recptno=" + rec_id + "&studid=" + student + "&adm=quick");
    }

    private void fillgrid()
    {


        _Qry = @"select  c.receiptno,case isnull(studentidno,'') when '' then 'quickenquiry.aspx?recptno='+c.receiptNo else 'quickpreInvoice.aspx?receiptno='+c.receiptNo+'&studid='+studentidno end as link,studentname,studentid,contactno from 
erp_receiptdetails a inner join erp_quickreceipt c on c.receiptNo=a.receiptno inner join img_coursedetails on 
course_id=c.coursecode where centercode='" + Session["SA_centre_code"] + @"' and
 substring(studentid,1,5)='Quick' and a.installno=0 order by a.id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

   
    protected void txt_coursepositioned_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txt_coursepositioned.SelectedValue != "")
        {
            _Qry = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "' and track='Normal' and program='" + txt_coursepositioned.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            HiddenField2.Value = dt.Rows[0]["tax"].ToString();
        }

    }
}
