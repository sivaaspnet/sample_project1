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

public partial class QuickAdmission : System.Web.UI.Page
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
            hdncentrecode.Value = Session["SA_centre_code"].ToString();

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

          if (Request.QueryString["teleid"] != null)
          {
              DataTable dt = new DataTable();
              dt = MVC.DataAccess.ExecuteDataTable("select cou.coursetype,course_id,EnquiryName,MobileNo,PhoneNo,CourseInterested,Addr,EmailId,sourse,profile from TeleEnquiry te inner join img_coursedetails cou on te.CourseInterested=cou.program where TeleEnquiryID=" + Request.QueryString["teleid"].ToString() + "");
              if (dt.Rows.Count > 0)
              {
                  txt_studname.Text = dt.Rows[0]["EnquiryName"].ToString();
                  txtname.Text = dt.Rows[0]["EnquiryName"].ToString();
                  TextBox1.Text = dt.Rows[0]["MobileNo"].ToString();
                  txtmobile.Text = dt.Rows[0]["MobileNo"].ToString();
                  DropDownList1.SelectedValue = dt.Rows[0]["sourse"].ToString();
                  ddl_profile0.SelectedValue = dt.Rows[0]["profile"].ToString();
                  ddl_aboutimage.SelectedValue = dt.Rows[0]["sourse"].ToString();
                  ddl_profile.SelectedValue = dt.Rows[0]["profile"].ToString();
                  txt_coursepositioned.SelectedValue = dt.Rows[0]["course_id"].ToString();
                  txt_coursenamee.SelectedValue = dt.Rows[0]["course_id"].ToString();
                  hdncoursetype.Value = dt.Rows[0]["coursetype"].ToString();
                  //txt_coursepositioned.Items.FindByText(dt.Rows[0]["CourseInterested"].ToString()).Selected = true;
                  //txt_coursepositioned.Items.FindByText(dt.Rows[0]["CourseInterested"].ToString()).Selected = true;
                  filltax();
              }
              dt.Dispose();
          }
          else if (Request.QueryString["enqno"] != null)
          {
              DataTable dt = new DataTable();
              string enqnum = Request.QueryString["enqno"].ToString().Split('#')[0].ToString();
              dt = MVC.DataAccess.ExecuteDataTable("select c.coursetype,c.course_id,e.enq_personal_name,e.enq_personal_mobile,e.enq_personal_email,e2.enq_coursepositioned,e.enq_aboutimage from img_enquiryform e inner join img_enquiryform1 e2 on e.enq_number=e2.enq_number inner join  img_coursedetails as c on c.course_id=e2.enq_coursepositioned where e.enq_number='" + enqnum + "'");
              if (dt.Rows.Count > 0)
              {
                  txt_studname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                  txtname.Text = dt.Rows[0]["enq_personal_name"].ToString();
                  TextBox1.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
                  txtmobile.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
                  DropDownList1.SelectedValue = dt.Rows[0]["enq_aboutimage"].ToString();
                  //  ddl_profile0.SelectedValue = dt.Rows[0]["profile"].ToString();
                  ddl_aboutimage.SelectedValue = dt.Rows[0]["enq_aboutimage"].ToString();
                  // ddl_profile.SelectedValue = dt.Rows[0]["profile"].ToString();
                  txt_coursepositioned.SelectedValue = dt.Rows[0]["course_id"].ToString();
                  txt_coursenamee.SelectedValue = dt.Rows[0]["course_id"].ToString();
                  hdncoursetype.Value = dt.Rows[0]["coursetype"].ToString();
                  //txt_coursepositioned.Items.FindByText(dt.Rows[0]["enq_coursepositioned"].ToString()).Selected = true;
                  //txt_coursepositioned.Items.FindByText(dt.Rows[0]["enq_coursepositioned"].ToString()).Selected = true;
              }
              dt.Dispose();
          }
           
        }
        GetSubcategoryDetails();
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
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' and b.status=1 Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
            }
            else
            {
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' and b.status=1 Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
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
                qry = "SElect program,lump_sum,instal_amount,tax,noofinstall  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1";
            }
            qry = "select program,lump_sum,instal_amount,tax,noofinstall,track  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1 ";


            //Response.Write(qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i, normalval = 0,fastval=0 ;
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
                    if(dt.Rows[i]["track"].ToString().ToLower() == "normal")
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
            _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and   a.status='Active' and b.status=1 and a.year=1 Group By a.coursename,a.course_id,b.Program,a.Program";
          
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
enq_personal_mobile='" + txtmobile.Text + "' and im1.enq_personal_name='" + txtname.Text + "' ";
        int checkcount = 0;
            checkcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            string qyr = "select count(*) from erp_quickreceipt where studentName='" + txtname.Text + "' and contactno='" + txtmobile.Text + "' and  (studentIdNo='' or studentIdNo is NULL)";
        int chkRegistrationstu=0;
        chkRegistrationstu = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qyr);
            if (checkcount > 0)
            {
             
            Response.Redirect("QuickAdmission.aspx?res=upt#tabs-5");
     
            }
            else if (chkRegistrationstu > 0)
            {
                Label1.Text = "Student Enrolled in Registeration.";
            
            }
            else
            
            {
            try
            {
                if ((txt_instalamt1.Text == "0" && ddl_payment.SelectedValue == "Installment") || (txt_instalamt1.Text == "" && ddl_payment.SelectedValue == "Installment"))
            {
                Label1.Text = "Please Enter Valid Installment No..";

               
                
                
                }
                else
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
                cmd.Parameters.AddWithValue("referedstudentname", txtenrollreferstudent.Text);
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
                cmd.Parameters.AddWithValue("userId", Session["SA_userID"]);
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
                        Label1.Text = "Student Already Enrolled.";
                        break;
                    default:
                        // ToTechnical();
                        if (Request.QueryString["teleid"] != null)
                        {
                            _Qry = " delete from TeleEnquiry Where TeleEnquiryId='" + Request.QueryString["teleid"].ToString() + "'";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }                        
                        Response.Redirect("InvoiceDetails.aspx?invno=" + inv_id);

                        break;

                }
    
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
        cmd.Parameters.AddWithValue("sourse", DropDownList1.SelectedValue);
        cmd.Parameters.AddWithValue("profile",ddl_profile0.SelectedValue);
        cmd.Parameters.AddWithValue("referstudent", txtreferstudent.Text);  
         
        cmd.Parameters.AddWithValue("course", txt_coursepositioned.SelectedValue);
        cmd.Parameters.AddWithValue("totalinitialAmt", txt_initialamt.Text);
        double b = Convert.ToDouble(txt_initialamt.Text) / (Convert.ToDouble(HiddenField2.Value) + 100);
     
        double a = b * 100;
        double c = a * Convert.ToDouble(HiddenField2.Value) / 100;
        cmd.Parameters.AddWithValue("initialAmt", Math.Round(a));
        cmd.Parameters.AddWithValue("taxinitialAmt", c);
        cmd.Parameters.AddWithValue("userId", Session["SA_userID"]);
        cmd.Parameters.AddWithValue("studentname", txt_studname.Text);
        cmd.Parameters.AddWithValue("month", ddl_month.SelectedValue);
        cmd.Parameters.AddWithValue("paywords", hdnpayinword.Value);
        cmd.Parameters.Add("@runningReceipt", SqlDbType.VarChar, 50);
        cmd.Parameters["@runningReceipt"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@student", SqlDbType.VarChar, 50);
        cmd.Parameters["@student"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@qrystatus", SqlDbType.VarChar, 50);
        cmd.Parameters["@qrystatus"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        rec_id = (string)cmd.Parameters["@runningReceipt"].Value;
        string student = (string)cmd.Parameters["@student"].Value;
        string qrystatus = (string)cmd.Parameters["@qrystatus"].Value;
        Conn.Close();
        if (qrystatus == "1")
        {
            if (Request.QueryString["teleid"] != null)
            {
                _Qry = " delete from TeleEnquiry Where TeleEnquiryId='" + Request.QueryString["teleid"].ToString() + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            if (Request.QueryString["enqno"] != null)
            {
                _Qry = " insert into adm_generalinfo (centre_code,enq_number) values ('" + Session["SA_centre_code"].ToString() + "','" + Request.QueryString["enqno"].ToString() + "')";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            Response.Redirect("receiptprint.aspx?recptno=" + rec_id + "&studid=" + student + "&adm=quick");
        }
        else
        {
            Label2.Text = "Student already exist";
        }
    }

    private void fillgrid()
    {


        _Qry = @"select  c.receiptno,case isnull(studentidno,'') when '' then 'quickenquiry.aspx?recptno='+c.receiptNo+'&studid='+a.studentId+'&cid='+c.coursecode else 'quickpreInvoice.aspx?receiptno='+c.receiptNo+'&studid='+studentidno end as link,studentname,studentid,contactno from 
erp_receiptdetails a inner join erp_quickreceipt c on c.receiptNo=a.receiptno inner join img_coursedetails on 
course_id=c.coursecode  and c.centrecode=a.centercode  where centercode='" + Session["SA_centre_code"].ToString() + @"' and
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
        filltax();

    }
    private void filltax()
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
