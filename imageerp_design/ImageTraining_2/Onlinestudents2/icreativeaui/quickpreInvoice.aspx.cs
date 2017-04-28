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
using System.Web.Mail;

public partial class superadmin_preInvoicedetails : System.Web.UI.Page
{                                                                                                                        
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, Invoiceno, CentreCount, CentreCount1, Receiptno,vartrack ,no;
    string varpaypattern, varpaymode, batch_time,payinword;
    double totcoursefee_tax, totcoursefee, totmonthlyinstall, lumpinitial_tax, totamount, txtpaidtax, txtpaidtax1;
    int CID;
  //  double tax7 = Convert.ToDouble(HiddenField2.Value);
    string installType, CashType, bank, dd,time;
    MVC.DataAccess.NumberToEnglish eng = new MVC.DataAccess.NumberToEnglish();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            hdnpay.Value = "0";
           fillcoursedropdown();
          
                summaryfill();
                Button2.Visible = false;
          
     
        }

    }

    public static int CheckIsInt(string Id)
    {
        int OutNo = 0;
        int.TryParse(Id, out OutNo);
        return OutNo;
    } 
    private void summaryfill()
    {

        _Qry = "select round(totalAmount,0) as totalAmount from erp_receiptdetails where receiptNo='" + Request.QueryString["receiptno"] + "' and paymentTowards='Registration'";
        DataTable dt6 = new DataTable();
        dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt6.Rows.Count > 0)
        {
            lbl_registration.Text = dt6.Rows[0]["totalAmount"].ToString();
        }



        _Qry = "select enq_personal_name,enq_number,permanant_phone from adm_personalparticulars where student_id='" + Request.QueryString["studid"] + "' ";
 
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            hdnsummary.Value = dt.Rows[0]["enq_number"].ToString();
        }
      
        _Qry1 = "select enq_permanant_address,enq_present_city,enq_present_pincode,enq_personal_mobile from Img_enquiryform where enq_number='" + hdnsummary.Value + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
        if (dt1.Rows.Count > 0)
        {
            txtaddress.Text = dt1.Rows[0]["enq_permanant_address"].ToString() + "," + dt1.Rows[0]["enq_present_city"].ToString() + "-" + dt1.Rows[0]["enq_present_pincode"].ToString();
            txtphone.Text = dt1.Rows[0]["enq_personal_mobile"].ToString();

        }
        _Qry2 = "select (select Centre_Location From Img_Centredetails where Img_Centredetails.centre_code=adm_generalinfo.centre_code) as centre_code,payment_noofinstall,payment_coursefee,Batchtime,track,payment_pattern,paymentmode from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
        DataTable dt2 = new DataTable();
        dt2= MVC.DataAccess.ExecuteDataTable(_Qry2);
        if (dt2.Rows.Count > 0)
        {
            batch_time = dt2.Rows[0]["Batchtime"].ToString();
            varpaypattern = dt2.Rows[0]["payment_pattern"].ToString();
            varpaymode = dt2.Rows[0]["paymentmode"].ToString();
            vartrack = dt2.Rows[0]["track"].ToString();
            txtcentre.Text = dt2.Rows[0]["centre_code"].ToString();
            txtinstall.Text = dt2.Rows[0]["payment_noofinstall"].ToString();

            if (txtinstall.Text == "" || txtinstall.Text ==null)
            {
                hdnpay.Value = "1";
            }
            else
            {
                if (Convert.ToInt32(txtinstall.Text) > 0)
                {
                    hdnpay.Value = "2";
                }
            }

            txtcoursefee.Text = dt2.Rows[0]["payment_coursefee"].ToString();
           }
          _Qry3 = "select a.program,b.coursename,a.course_id from [Img_Coursedetails] a inner join adm_generalinfo b on b.coursename = a.Course_ID where student_id='" + Request.QueryString["studid"] + "'";

        //Response.Write(_Qry3);
        //Response.End();
          DataTable dt3 = new DataTable();
          dt3 = MVC.DataAccess.ExecuteDataTable(_Qry3);

       
         
        if (dt3.Rows.Count > 0)
        {

            fillcoursedropdown();
            txtcoursename.SelectedValue = dt3.Rows[0]["coursename"].ToString();
           if (CheckIsInt(dt3.Rows[0]["coursename"].ToString()) != 0)
             {

                 CID = CheckIsInt(dt3.Rows[0]["coursename"].ToString());

             }
             fillprogramdropdown(CID);
            txtcourseid.SelectedValue = dt3.Rows[0]["coursename"].ToString();
        }
    
        if (txtinstall.Text == null || txtinstall.Text == "")
        {
           txtinstall.Visible = false;
    
           //txtinstalldate.Visible = false;
          //  string today= System.DateTime.Now.ToString("dd-m-yyyy");
           // txtinstalldate.Text = today;
            hdnpay.Value = "1";
            lumpcalculate();
        }
        else
        {
            hdnpay.Value = "2";
            calculate();
        }

    }
    private double lumpcalculate()
    { try
        {
        double tax4 = Convert.ToDouble(HiddenField2.Value);
        double lumpinitial_tax = 0;
        if (txtinstall.Text == null || txtinstall.Text == "")
        {
            _Qry = "select b.payment_initial_amt,b.payment_coursefee from  adm_generalinfo b  where student_id='" + Request.QueryString["studid"] + "'";
           
            DataTable dt5 = new DataTable();
            dt5 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt5.Rows.Count > 0)
            {
                lbllumpamt.Text = dt5.Rows[0]["payment_coursefee"].ToString();
                lbllumpinitial.Text = dt5.Rows[0]["payment_initial_amt"].ToString();
                lbllumpinitialtax.Text = Convert.ToString(tax4);
                lbllumptax.Text = Convert.ToString(tax4);
                lblamt_tax.Text = Convert.ToString(tax4);
                txtamountpaid.Text = dt5.Rows[0]["payment_initial_amt"].ToString();                
            }
          
            //Calculation for Lump amount
           
            double lumpamt = Convert.ToDouble(lbllumpamt.Text);
            txtpaidtax1 = Convert.ToDouble(lumpamt * (tax4 / 100));
            double totfeepaid_tax1 = lumpamt + txtpaidtax1;
            lbltotlump_tax.Text = totfeepaid_tax1.ToString();

            //calculation for Lump Initial Amount
           
            double lumpinitial = Convert.ToDouble(lbllumpinitial.Text);
            lumpinitial_tax = Convert.ToDouble(lumpinitial * (tax4 / 100));
            double totlumpinitial_tax = lumpinitial + lumpinitial_tax;
            lbltotlumpinitial_tax.Text = Convert.ToString(totlumpinitial_tax);

            lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totlumpinitial_tax,0));

            //Calculation for totalamount paid
            string amttotpaid = txtamountpaid.Text;

            if (amttotpaid != "")
            {
                double amtpaid = Convert.ToDouble(amttotpaid);
                double txtpaidtax = Convert.ToDouble(amtpaid * (tax4 / 100));
                double totfeepaid_tax = amtpaid + txtpaidtax;
                lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
            }

        }
        return lumpinitial_tax;
        }

    catch (Exception ex)
    {
        string scrip = "$(document).ready(function () {alert('" + ex.ToString() + "')});";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", scrip, true);
        return lumpinitial_tax;
    }
       
    }
    private double calculate()
    {
        try
        {
            double taxx = Convert.ToDouble(HiddenField2.Value);
            double totamount = 0;
            if (txtinstall.Text != "")
            {
                _Qry4 = "select Round(b.payment_coursefee,0) as payment_coursefee,Round(b.payment_initial_amt,0) as payment_initial_amt from adm_generalinfo b where student_id='" + Request.QueryString["studid"] + "'";
                ////Response.Write(_Qry4);
                ////Response.End();
                DataTable dt4 = new DataTable();
                dt4 = MVC.DataAccess.ExecuteDataTable(_Qry4);
                if (dt4.Rows.Count > 0)
                {
                    lblinitialpay.Text = dt4.Rows[0]["payment_initial_amt"].ToString();
                    txtamountpaid.Text = dt4.Rows[0]["payment_initial_amt"].ToString();
                    lbltax.Text = Convert.ToString(taxx);
                    lblinstallment.Text = dt4.Rows[0]["payment_coursefee"].ToString();
                    lblinstaltax.Text = Convert.ToString(taxx);
                    lblmonthlytax.Text = Convert.ToString(taxx);
                    lblamt_tax.Text = Convert.ToString(taxx);
                }


                //Calculation for initial pay


                int initialpay = Convert.ToInt32(lblinitialpay.Text);
                totamount = initialpay * (taxx / 100);
                double totamt = totamount + initialpay;
                lbltotamt.Text = Convert.ToString(Math.Round(totamt, 0));


                //Calculation for Total Installment

                int installpay = Convert.ToInt32(lblinstallment.Text);
                double totinstall = installpay * (taxx / 100);
                double totins = totinstall + installpay;
                lblinstalltotal.Text = Convert.ToString(Math.Round(totins, 0));


                //Calculation for Monthly Installment
                double amt_ex_initial = installpay - initialpay;
                double noofinstallments = Convert.ToDouble(txtinstall.Text);
                double monthlyinstall = amt_ex_initial / noofinstallments;
                lblmonthlyinstal.Text = Convert.ToString(Math.Round(monthlyinstall, 0));

                string moninstall = lblmonthlyinstal.Text.ToString();

                string[] strsplit = moninstall.Split('.');
                string dissue = strsplit[0].ToString();



                totmonthlyinstall = monthlyinstall * (taxx / 100);
                lblmonthlytotal.Text = Convert.ToString(Math.Round((monthlyinstall + totmonthlyinstall), 0));



                //calculation for full coursefee with tax
                double coursefee = Convert.ToDouble(txtcoursefee.Text);
                totcoursefee = coursefee * (taxx / 100);
                totcoursefee_tax = coursefee + totcoursefee;

                //Calculation for totalamount paid
                string amttotpaid = txtamountpaid.Text;

                if (amttotpaid != "")
                {
                    double amtpaid = Convert.ToDouble(amttotpaid);
                    double txtpaidtax = Convert.ToDouble(amtpaid * (taxx / 100));
                    double totfeepaid_tax = amtpaid + txtpaidtax;
                    lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
                }

            }
            return totamount;
            
        }
        
         catch (Exception ex)
        {
            string scrip = "$(document).ready(function () {alert('"+ex.ToString()+"')});";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", scrip, true);
            return totamount;
        }

      

    }
    private void update()
    {
        try
        {
            double taxx1 = Convert.ToDouble(HiddenField2.Value);

            string amttotpaid = txtamountpaid.Text;


            double amtpaid = Convert.ToDouble(amttotpaid);
            double txtpaidtax = Convert.ToDouble(amtpaid * (taxx1 / 100));
            double totfeepaid_tax = amtpaid + txtpaidtax;
            lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
            string dateFrom = "";
            string dateTo = "";
            if (txtdate.Text != "")
            {
                string str = txtdate.Text;
                string[] split = str.Split('-');
                dateFrom = split[2] + "-" + split[1] + "-" + split[0];
            }

            if (txtinstalldate.Text != "")
            {
                string str1 = txtinstalldate.Text;
                string[] split1 = str1.Split('-');
                dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
            }

            _Qry2 = "update adm_generalinfo set payment_noofinstall='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstall.Text) + "',payment_coursefee='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "',coursestartdate='" + dateFrom + "',payment_initial_amt='" + amtpaid + "',installmentdate='" + dateTo + "' where student_id='" + Request.QueryString["studid"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
            lblerrormsg.Text = "Admission details updated successfully";

            if (txtinstall.Text == null || txtinstall.Text == "")
            {
                lumpcalculate();
                //lblerrormsg.Text = "lumpcal";
            }
            else
            {
                calculate();
                //lblerrormsg.Text = "cal";
            }
        }
        catch (Exception ex)
        {
            string scrip = "$(document).ready(function () {alert('"+ex.ToString()+"')});";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", scrip, true);
        }
    }
  
   
    private void fillcoursedropdown()
    {
        _Qry = "select a.CourseName,a.Program,a.course_id,a.coursetype from adm_generalinfo b inner join [Img_Coursedetails] a on a.Course_ID=b.coursename  and a.status='active' where b.centre_code='" + Session["SA_centre_code"] + "' and b.student_id='" + Request.QueryString["studid"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txtcoursename.DataSource = dt;
        txtcoursename.DataValueField = "course_id";
        txtcoursename.DataTextField = "Program";
        txtcoursename.DataBind();
        txtCName.Text = dt.Rows[0]["CourseName"].ToString();
        lblCID.Text = dt.Rows[0]["Program"].ToString();
        hdncoursetype.Value = dt.Rows[0]["coursetype"].ToString();
        _Qry = @"select tax from img_centre_coursefee_details 
            b inner join img_coursedetails a on a.course_id=b.program 
            where track='Normal' and centre_code='" + Session["SA_centre_code"] + "' and b.program='" + dt.Rows[0]["course_id"].ToString() + "'";
        DataTable tax = new DataTable();
        tax = MVC.DataAccess.ExecuteDataTable(_Qry);

        HiddenField2.Value = tax.Rows[0]["tax"].ToString();
       

    }

    private void Checkamount()
    {
        double coursefee = Convert.ToDouble(txtcoursefee.Text);
        double installfee = Convert.ToDouble(txtamountpaid);
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _Qry = "select count(*) as count  from erp_invoicedetails where studentid='" + Request.QueryString["studid"] + "'";
            DataTable dt0 = new DataTable();
            dt0 = MVC.DataAccess.ExecuteDataTable(_Qry);
            int cnt = Convert.ToInt32(dt0.Rows[0]["count"].ToString());
            //Response.Write(cnt);
            if (cnt < 1)
            {

                string datet2;
                update();
                no = invoice();
                no=no.TrimStart('0');
                _Qry = "select batchtime,payment_pattern,bankname,creditddno,paymentmode,student_id from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
                DataTable dt66 = new DataTable();
                dt66 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt66.Rows.Count > 0)
                {

                    installType = dt66.Rows[0]["payment_pattern"].ToString();
                    CashType = dt66.Rows[0]["paymentmode"].ToString();
                    bank = dt66.Rows[0]["bankname"].ToString();
                    dd = dt66.Rows[0]["creditddno"].ToString();
                    time = dt66.Rows[0]["batchtime"].ToString();
                    
                }
                if (txtinstall.Text == "0" && installType == "Installment")
                {
                    lblerrormsg.Text = "Invalid Installment amount";

                    
                }
                else
                {
                  

                    if (txtinstalldate.Text != "" && txtdate.Text != "")
                    {
                        if (txtamountpaid.Text != "")
                        {
                            SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = Conn;
                            string str = txtdate.Text;
                            string[] split = str.Split('-');
                            string datet = split[2] + "-" + split[1] + "-" + split[0];
                            string str1 = txtinstalldate.Text;
                            string[] split1 = str1.Split('-');
                            datet2 = split1[2] + "-" + split1[1] + "-" + split1[0];
                            cmd.CommandText = "[quickreceiptinvoice]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
                            cmd.Parameters.AddWithValue("studName", txtname.Text);
                            cmd.Parameters.AddWithValue("course", txtcourseid.SelectedValue);
                            cmd.Parameters.AddWithValue("installmenttype", installType);
                            cmd.Parameters.AddWithValue("initialAmt", txtamountpaid.Text);
                            cmd.Parameters.AddWithValue("studentid", Request.QueryString["studid"]);
                            cmd.Parameters.AddWithValue("invoiceNo", no);
                            cmd.Parameters.AddWithValue("noofInstallment", txtinstall.Text);
                            cmd.Parameters.AddWithValue("batchTime", time);
                            cmd.Parameters.AddWithValue("cashType", CashType);
                            cmd.Parameters.AddWithValue("bankname", bank);
                            cmd.Parameters.AddWithValue("chequeNo", dd);
                            cmd.Parameters.AddWithValue("chequeDt", dd);
                            cmd.Parameters.AddWithValue("userId", Session["SA_userID"]);
                            cmd.Parameters.AddWithValue("installmentDate", datet2);
                            cmd.Parameters.AddWithValue("coursestartdate", datet);
                            cmd.Parameters.AddWithValue("receiptno", Request.QueryString["receiptno"]);
                            Conn.Open();
                            ////Response.Write("centrecode", Session["SA_centre_code"] +"<br/>");
                            ////Response.Write("studName", txtname.Text + "<br/>");
                            ////Response.Write("course", txtcourseid.SelectedValue + "<br/>");
                            ////Response.Write("installmenttype", installType + "<br/>");
                            ////Response.Write("initialAmt", txtamountpaid.Text + "<br/>");
                            ////Response.Write("studentid", Request.QueryString["studid"] + "<br/>");
                            ////Response.Write("invoiceNo", no + "<br/>");
                            ////Response.Write("noofInstallment", txtinstall.Text + "<br/>");
                            ////Response.Write("batchTime", time + "<br/>");
                            ////Response.Write("cashType", CashType + "<br/>");
                            ////Response.Write("bankname", bank + "<br/>");
                            ////Response.Write("chequeNo", dd + "<br/>");
                            ////Response.Write("chequeDt", dd + "<br/>");
                            ////Response.Write("userId", Session["SA_userID"] + "<br/>");
                            ////Response.Write("installmentDate", datet2 + "<br/>");
                            ////Response.Write("coursestartdate", datet + "<br/>");
                            ////Response.Write("receiptno", Request.QueryString["receiptno"] + "<br/>");
                            ////Response.End();
                            cmd.ExecuteNonQuery();
                            Conn.Close();
                            //ToStudent();

                            // ToTechnical();

                            // int invno = Convert.ToInt32(Session["Invoice_no"]);
                            Response.Redirect("InvoiceDetails.aspx?invno=" + no);
                        }
                        else
                        {
                            lblerrormsg.Text = "Invalid Installment amount";
                        }
                    }

                    else
                    {
                        lblerrormsg.Text = "Invalid  amount";
                    }


                    
                }


            }
            else
            {
                lblerrormsg.Text = "Student Already Enrolled";
                Response.Redirect("viewadmission.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
          
       
    }
 
    
    private void fillprogramdropdown(int id)
    {
        _Qry = "select program,course_id from img_coursedetails where course_id=" +id+ "";
    
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txtcourseid.DataSource = dt;
        txtcourseid.DataValueField = "course_id";
        txtcourseid.DataTextField = "program";
        txtcourseid.DataBind();
        txtcourseid.Items.Insert(0, new ListItem("Select", ""));
        
    }
    protected void txtcoursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        _Qry = "select program,course_id from img_coursedetails where course_id='" + txtcoursename.SelectedValue + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txtcourseid.DataSource = dt;
        txtcourseid.DataValueField = "course_id";
        txtcourseid.DataTextField = "program";
        txtcourseid.DataBind();
    }

    private void ToStudent()
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

        //_Qry = "select Coursename from img_coursedetails where Course_ID=" + hdncou_id.Value + "";
        //DataTable dtcour = MVC.DataAccess.ExecuteDataTable(_Qry);

        //SendMail.From = "universityimage.project@gmail.com";
        _Qry = @"select enq_personal_email from adm_personalparticulars a  inner join 
img_enquiryform  b on a.enq_number =b.enq_number where student_id='" + Request.QueryString["studid"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string send = dt.Rows[0]["enq_personal_email"].ToString();
            // string send = "maildata909@gmail.com";
            SendMail.To = send;
            SendMail.Subject = "Successfully Registered";
            SendMail.BodyFormat = MailFormat.Html;
            string GetTxt = "Thank you for joining " + txtCName.Text + " In Image";
            SendMail.Body = GetTxt;
            SmtpMail.Send(SendMail);
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

        //_Qry = "select Coursename from img_coursedetails where Course_ID=" + hdncou_id.Value + "";
        //DataTable dtcour = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select centre_useremail from img_centrelogin  where centre_code='" + Session["SA_centre_code"] + "' and role='Technical Head' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string send = dt.Rows[0]["centre_useremail"].ToString();
           
             SendMail.To = send;
           // SendMail.To = "maildata909@gmail.com";
            SendMail.Subject = "Student Enrolled";
            SendMail.BodyFormat = MailFormat.Html;
            string GetTxt = "The Student " + txtname.Text + " (" + Session["Stud_ID"].ToString() + ") " + " Has Got Enrolled For " + txtCName.Text + "";
            SendMail.Body = GetTxt;
            SmtpMail.Send(SendMail);
        }
    }
    private string invoice()
    {

        _Qry = " select case isnull(invoiceno,'') when '' then '0' else invoiceno end as invno from adm_personalparticulars where  student_id='" + Request.QueryString["studid"] + " ' ";
        DataTable dte = new DataTable();
        dte = MVC.DataAccess.ExecuteDataTable(_Qry);
        int invoice = Convert.ToInt32(dte.Rows[0]["invno"].ToString());
        if (invoice == 0)
        {
            string invoice1 = Request.QueryString["studid"].ToString();
            string[] invoiceNumber = invoice1.Split('-');
            return invoiceNumber[3].ToString();
        }
        else
        {
            string invoice2 = dte.Rows[0]["invno"].ToString();
            return invoice2;

        }

    }
}
