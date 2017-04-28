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

public partial class superadmin_preInvoicedetails : System.Web.UI.Page
{                                                                                                                        
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, Invoiceno, CentreCount, CentreCount1, Receiptno,vartrack;
    string varpaypattern, varpaymode, batch_time,payinword;
    double totcoursefee_tax, totcoursefee, totmonthlyinstall, lumpinitial_tax, totamount, txtpaidtax, txtpaidtax1;
    int CID;
    double tax7 = 10.3;
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
        _Qry = "select enq_personal_name,enq_number,permanant_phone from adm_personalparticulars where student_id='" + Request.QueryString["studid"] + "' ";
 
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            //txtphone.Text = dt.Rows[0]["permanant_phone"].ToString();
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
        //Response.Write(_Qry2);
        //Response.End();
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
          // lbllumpamt.Text = dt2.Rows[0]["payment_coursefee"].ToString();

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
            //Response.Write(dt3.Rows[0]["coursename"].ToString());
            //Response.End();

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
            txtinstalldate.Visible = false;
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
    {
        double tax4 = 10.3;
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
                double txtpaidtax = Convert.ToDouble(amtpaid * (tax7 / 100));
                double totfeepaid_tax = amtpaid + txtpaidtax;
                lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
            }

        }
        return lumpinitial_tax;
    }
    private double calculate()
    {
        double taxx = 10.3;
        double totamount=0;
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
            lblmonthlyinstal.Text = Convert.ToString(Math.Round(monthlyinstall,0));

            string moninstall = lblmonthlyinstal.Text.ToString();

            string[] strsplit = moninstall.Split('.');
            string dissue = strsplit[0].ToString();



            totmonthlyinstall = monthlyinstall * (taxx / 100);
            lblmonthlytotal.Text = Convert.ToString(Math.Round((monthlyinstall + totmonthlyinstall),0));



            //calculation for full coursefee with tax
            double coursefee = Convert.ToDouble(txtcoursefee.Text);
            totcoursefee = coursefee * (tax7 / 100);
            totcoursefee_tax = coursefee + totcoursefee;

            //Calculation for totalamount paid
            string amttotpaid=txtamountpaid.Text;
           
            if (amttotpaid != "")
            {
                double amtpaid = Convert.ToDouble(amttotpaid);
                double txtpaidtax = Convert.ToDouble(amtpaid * (tax7 / 100));
                double totfeepaid_tax = amtpaid + txtpaidtax;
                lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
            }
           
        }
        return totamount;

    }
    private void update()
    {
        string amttotpaid = txtamountpaid.Text;

      
            double amtpaid = Convert.ToDouble(amttotpaid);
            double txtpaidtax = Convert.ToDouble(amtpaid * (tax7 / 100));
            double totfeepaid_tax = amtpaid + txtpaidtax;
            lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));

        
        //_Qry = "update adm_personalparticulars set enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "',permanant_phone='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtphone.Text) + "' where student_id='" + Request.QueryString["studid"] + "'";
        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        //_Qry1 = "update Ipad_enquiryform set enq_permanant_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtaddress.Text) + "' where enq_number='" + hdnsummary.Value + "'";
        //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);

        string dateFrom = "";
        string dateTo = "";
        if (txtdate.Text.Trim() != "" || txtinstalldate.Text.Trim() != "")
        {
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
            //Button1.Visible = false;
            //Button2.Visible = true;
            //txtamountpaid.ReadOnly = true;
            if (txtinstall.Text == null || txtinstall.Text == "")
            {
                lumpcalculate();
            }
            else
            {
                calculate();
            }
            confirmbutton();
        }
        else
        {
            lblerrormsg.Text = "Select date field correctly";
        }
    }
  
   
    private void fillcoursedropdown()
    {
        _Qry = "select a.CourseName,a.Program,a.course_id from adm_generalinfo b inner join [Img_Coursedetails] a on a.Course_ID=b.coursename where b.centre_code='" + Session["SA_centre_code"] + "' and b.student_id='" + Request.QueryString["studid"] + "'";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txtcoursename.DataSource = dt;
        txtcoursename.DataValueField = "Program";
        txtcoursename.DataTextField = "Program";
        txtcoursename.DataBind();

        txtCName.Text = dt.Rows[0]["CourseName"].ToString();
        lblCID.Text = dt.Rows[0]["Program"].ToString();
        //txtcoursename.Items.Insert(0, new ListItem("Select", ""));

    }

    private void Checkamount()
    {
        double coursefee = Convert.ToDouble(txtcoursefee.Text);
        double installfee = Convert.ToDouble(txtamountpaid);
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        _Qry = "Select count(*) from Invoice_details where student_Id='" + Request.QueryString["studid"] + "'";

        int invcount = 0;
        invcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        if (invcount > 0)
        {
            Response.Redirect("InvoiceDetails.aspx?studid=" + Request.QueryString["studid"] + "");
        }
        else
        {
            //Checkamount();
            update();
            //Calculation for totalamount paid
            string amttotpaid = txtamountpaid.Text;
            double amtpaid = Convert.ToDouble(amttotpaid);
            double txtpaidtax = Convert.ToDouble(amtpaid * (tax7/ 100));
            double totfeepaid_tax = amtpaid + txtpaidtax;
            lbltotamountpaid_tax.Text = Convert.ToString(Math.Round(totfeepaid_tax, 0));
        } 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
            confirmbutton();
       
    }
    private void confirmbutton()
    {
        _Qry2 = "select (select Centre_Location From Img_Centredetails where Img_Centredetails.centre_code=adm_generalinfo.centre_code) as centre_code,payment_noofinstall,payment_coursefee,Batchtime,track,payment_pattern,paymentmode from adm_generalinfo where student_id='" + Request.QueryString["studid"] + "'";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry2);
        if (dt2.Rows.Count > 0)
        {
            batch_time = dt2.Rows[0]["Batchtime"].ToString();
            varpaypattern = dt2.Rows[0]["payment_pattern"].ToString();
            varpaymode = dt2.Rows[0]["paymentmode"].ToString();
            vartrack = dt2.Rows[0]["track"].ToString();
            txtcentre.Text = dt2.Rows[0]["centre_code"].ToString();
            txtinstall.Text = dt2.Rows[0]["payment_noofinstall"].ToString();
            txtcoursefee.Text = dt2.Rows[0]["payment_coursefee"].ToString();
            
        }
        //_Qry = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "'";
        //dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt2.Rows.Count > 0)
        //{
        //     tax7 = Convert.ToDouble(dt2.Rows[0]["tax"].ToString());
        //}
        //tax7 = "10.3";
        double coursefee = Convert.ToDouble(txtcoursefee.Text);

        totcoursefee = coursefee * (tax7/ 100);
        totcoursefee_tax = coursefee + totcoursefee;

       
        //Invoice no generation - Centre Specific
        _Qry = "select count(*) as cnt from adm_studentid";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CentreCount = dt.Rows[0]["cnt"].ToString();
        }
        else
        {
            CentreCount = "1";
        }
        Invoiceno = CentreCount;

        //Session["Invoice_no"] = Invoiceno;

        //Receipt No Generation -Centre Specific
        _Qry1 = "select Rec_Total+1 as cnt from Receipt_Total_No where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
        if (dt1.Rows.Count > 0)
        {
            CentreCount1 = dt1.Rows[0]["cnt"].ToString();
            _Qry = "Update Receipt_Total_No set Rec_Total=Rec_Total+1 where centre_code='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        else
        {
            CentreCount1 = "5000";
            _Qry = "insert into Receipt_Total_No values(" + (CentreCount1) + ",'" + Session["SA_centre_code"] + "')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }

        //_Qry1 = "select Totalreceipt+1 as cnt from receipt_details where centre_code='" + Session["SA_centre_code"] + "'";
        //DataTable dt1 = new DataTable();
        //dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
        //if (dt1.Rows.Count > 0)
        //{
        //    CentreCount1 = dt1.Rows[0]["cnt"].ToString();
        //}
        //else
        //{
        //    CentreCount1 = "5000";
        //}
        Receiptno = CentreCount1;
        
        Session["Receipt_no"] = Receiptno;

        string curentmonth = System.DateTime.Now.ToString("MMM");

        //Insert in invoice_details,receipt_details,install_amountdetails

        string moninstall = lblmonthlyinstal.Text.ToString();

        string[] strsplit = moninstall.Split('.');
        string dissue = strsplit[0].ToString();


        _Qry = "insert into invoice_details(Centre_code , student_id , Invoice_id , Receipt_no , course_id , Track , course_fee , Lumpsum , lumpsum_tax , totlumpsum_tax , lumpinitial , lumpinitial_tax , totlumpinitial_tax , initial_amount , totalinitial_tax , instal_amount , totalinstal_tax , totalamountpaid ,totamtpaid_tax, instal_no , payment_type , payment_mode , dateins , batch_time , course_name , enteredby )values('" + Session["SA_centre_code"] + "','" + Request.QueryString["studid"] + "','" + Session["Invoice_no"] + "','" + Session["Receipt_no"] + "','" + txtcourseid.SelectedValue + "','" + vartrack + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + lbllumpamt.Text + "','" + lbllumptax.Text + "','" + lbltotlump_tax.Text + "','" + lbllumpinitial.Text + "','" + lbllumpinitialtax.Text + "','" + lbltotlumpinitial_tax.Text + "','" + lblinitialpay.Text + "','" + lbltotamt.Text + "','" + dissue + "',round('" + lblmonthlytotal.Text + "',2),'" + txtamountpaid.Text + "',round('" + lbltotamountpaid_tax.Text + "',0),'" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstall.Text) + "','" + varpaypattern + "','" + varpaymode + "',getdate(),'" + batch_time + "','" + lblCID.Text + "','" + Session["SA_Username"] + "')";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

       // payinword = eng.changeNumericToWords(lbltotamountpaid_tax.Text.ToString());

       

        _Qry1 = "insert into receipt_details(centre_code,Receipt_no,Invoice_no,course_code,student_name,amount,total_amount,payment_mode,payment_towards,student_id,month_instal,instal_no,payment_words,tax_amount,dateins)values('" + Session["SA_centre_code"] + "','" + Session["Receipt_no"] + "','" + Session["Invoice_no"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee_tax + "','" + varpaymode + "','"+txtpaytowards.Text+"','" + Request.QueryString["studid"] + "','" + curentmonth + "','0','"+hdnpayinword.Value+"','" + totcoursefee + "',getdate())";
        //Response.Write(_Qry);
        //Response.End();
        
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

        if (txtinstall.Text != "")
        {
            double totamt=calculate();
            int noofinstal = Convert.ToInt32(txtinstall.Text);
            int noofinstal1 = noofinstal + 1;
            int noofins = Convert.ToInt32(txtinstall.Text);
            //Response.Write("Values Is:" + Session["Receipt_no"].ToString());
            //Response.End();
            int j = Convert.ToInt32(Session["Receipt_no"].ToString());

            //string moninstall = lblmonthlyinstal.Text.ToString();

            //string[] strsplit = moninstall.Split('.');
            //string dissue = strsplit[0].ToString();
            //double totalcoursefees = txtcoursefee.Text;
            double amount=0;
            double installmentAmt = 0;
            double installmentAmttaxval = 0;
            double installmentAmttaxtot = 0;
            for (int i = 0; i < noofinstal1; i++)
            {
                //double totalcoursefees = txtcoursefee.Text;
               
                if (i == 0)
                {
                    string dateTo = "";
                    if (txtinstalldate.Text != "")
                    {
                        string str1 = txtinstalldate.Text;
                        string[] split1 = str1.Split('-');
                        dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    }
                    else
                    {
                        //dateTo = System.DateTime.Now.ToString();
                        string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                        //string[] split1 = str1.Split('-');
                        dateTo = str1;
                    }
                    _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , Receipt_no , student_id , course_id , course_fees , course_tax , totalcourse_fees , instalment_amount , instalamountax ,totinstalamount_tax, instal_number ,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name , install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax)values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + j + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "','" + lblinstallment.Text + "',round('" + totmonthlyinstall + "',2),round('" + lblmonthlytotal.Text + "',2),'" + i + "','" + lblinitialpay.Text + "','" + totamt + "','" + lbltotamt.Text + "',getdate(),'completed','" + lblCID.Text + "',getdate(),'" + dissue + "','" + lblamt_tax.Text + "',round('" + lblmonthlytotal.Text + "',2),'" + txtamountpaid.Text + "','" + totamt + "',round('" + lbltotamountpaid_tax.Text + "',0))";
                    //Response.Write("Test1:"+_Qry2);
                    amount += Convert.ToDouble(lblinitialpay.Text);
                }
                else if (i == 1)
                {
                    string dateTo = "";
                    if (txtinstalldate.Text != "")
                    {
                        string str1 = txtinstalldate.Text;
                        string[] split1 = str1.Split('-');
                        dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    }
                    else
                    {
                        //dateTo = System.DateTime.Now.ToString();
                        string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                        //string[] split1 = str1.Split('-');
                        dateTo = str1;
                    }
                    _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , student_id , course_id , course_fees , course_tax , totalcourse_fees , instalment_amount , instalamountax ,totinstalamount_tax, instal_number ,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name , install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax )values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "','" + lblinstallment.Text + "',round('" + totmonthlyinstall + "',2),round('" + lblmonthlytotal.Text + "',2),'" + i + "','" + dissue + "',round('" + totmonthlyinstall + "',2),round('" + lblmonthlytotal.Text + "',2),getdate(),'pending','" + lblCID.Text + "',DATEADD(month," + 0 + ",'" + dateTo + "'),'" + dissue + "','" + lblamt_tax.Text + "',round('" + lblmonthlytotal.Text + "',2))";
                    //Response.Write("Test2:" + _Qry2);
                    amount += Convert.ToDouble(dissue);
                    installmentAmt = Convert.ToDouble(dissue);

                }
                else
                {
                    int jj = i - 1;
                    string dateTo = "";
                    if (txtinstalldate.Text != "")
                    {
                        string str1 = txtinstalldate.Text;
                        string[] split1 = str1.Split('-');
                        dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    }
                    else
                    {
                        //dateTo = System.DateTime.Now.ToString();
                        string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                        //string[] split1 = str1.Split('-');
                        dateTo = str1;
                    }
                    _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , student_id , course_id , course_fees , course_tax , totalcourse_fees , instalment_amount , instalamountax ,totinstalamount_tax, instal_number ,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name , install_date,monthlyinstal,monthlyinstal_tax,totalmonthly_tax )values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "','" + lblinstallment.Text + "',round('" + totmonthlyinstall + "',2),round('" + lblmonthlytotal.Text + "',2),'" + i + "','" + dissue + "',round('" + totmonthlyinstall + "',2),round('" + lblmonthlytotal.Text + "',2),getdate(),'pending','" + lblCID.Text + "',DATEADD(month," + jj + ",'" + dateTo + "'),'" + dissue + "','" + lblamt_tax.Text + "',round('" + lblmonthlytotal.Text + "',2))";
                    //Response.Write("Test2:" + _Qry2);
                    amount += Convert.ToDouble(dissue);

                }
                //Response.Write(_Qry2);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
                j = j + 1;

            }
            
            double iniamount;
            
            if(coursefee > amount)
            {
               iniamount=coursefee-amount;
               installmentAmt = installmentAmt + iniamount;               
               installmentAmttaxval = Math.Round((installmentAmt*tax7/100), 0);
               installmentAmttaxtot = installmentAmt + installmentAmttaxval;
               string Qryupd = "update install_amountdetails set initialamount=" + installmentAmt + ",	initialamout_tax=" + installmentAmttaxval + ",totinitialamt_tax=" + installmentAmttaxtot + " where student_id='" + Request.QueryString["studid"] + "' and instal_number='" + txtinstall.Text + "' ";
               MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qryupd);
            }
            else if (coursefee < amount)
            {
                iniamount = amount-coursefee;
                installmentAmt = installmentAmt - iniamount;
                installmentAmttaxval = Math.Round((installmentAmt * tax7 / 100), 0);
                installmentAmttaxtot = installmentAmt + installmentAmttaxval;
                string Qryupd = "update install_amountdetails set initialamount=" + installmentAmt + ",	initialamout_tax=" + installmentAmttaxval + ",totinitialamt_tax="+installmentAmttaxtot +" where student_id='" + Request.QueryString["studid"] + "' and instal_number='" + txtinstall.Text + "' ";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qryupd);
            }
            
            //Response.End();
            Response.Redirect("InvoiceDetails.aspx?studid=" + Request.QueryString["studid"] + "");
        }
        else
        {
           double lumpinitial_tax=lumpcalculate();
           double totlump=Convert.ToDouble(lbltotlump_tax.Text);
           double totlumpinitial = Convert.ToDouble(lbltotlumpinitial_tax.Text);
        
        
           if (totlump == totlumpinitial)
           {
               string dateTo = "";
               if (txtinstalldate.Text != "")
               {
                   
                   string str1 = txtinstalldate.Text;
                   string[] split1 = str1.Split('-');
                   dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
               }
               else
               {
                   //dateTo = System.DateTime.Now.ToString();
                   string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                   //string[] split1 = str1.Split('-');
                   dateTo = str1;
               }

               _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , Receipt_no , student_id , course_id , course_fees , course_tax , totalcourse_fees ,instalment_amount , instalamountax ,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name ,install_date,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax)values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + Session["Receipt_no"] + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "',Round('" + lbllumpinitial.Text + "',0),Round('" + lumpinitial_tax + "',0),Round('" + lbltotlumpinitial_tax.Text + "',0),'0','" + lbllumpinitial.Text + "','" + lumpinitial_tax + "','" + lbltotlumpinitial_tax.Text + "',getdate(),'completed','" + lblCID.Text + "','" + dateTo + "','" + txtamountpaid.Text + "','" + lumpinitial_tax + "',round('" + lbltotamountpaid_tax.Text + "',0))";
               //Response.Write("Test3:" + _Qry2);
               MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
               //Response.End();
               Response.Redirect("InvoiceDetails.aspx?studid=" + Request.QueryString["studid"] + "");
           }
           else
           {

               for (int i = 0; i < 2; i++)
               {
                   
                   
                   if (i == 0)
                   {
                       string dateTo = "";
                       if (txtinstalldate.Text != "")
                       {
                           string str1 = txtinstalldate.Text;
                           string[] split1 = str1.Split('-');
                           dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                       }
                       else
                       {
                           //dateTo = System.DateTime.Now.ToString();
                           string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                           //string[] split1 = str1.Split('-');
                           dateTo = str1;
                       }
                       ////Response.Write("Date:" + dateTo);

                       _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , Receipt_no , student_id , course_id , course_fees , course_tax , totalcourse_fees ,instalment_amount , instalamountax ,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name ,install_date,totalamtpaid,totamtpaid_tax,tatamtpaidwithtax)values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + Session["Receipt_no"] + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "',Round('" + lbllumpinitial.Text + "',0),Round('" + lumpinitial_tax + "',0),Round('" + lbltotlumpinitial_tax.Text + "',0),'0','" + lbllumpinitial.Text + "','" + lumpinitial_tax + "','" + lbltotlumpinitial_tax.Text + "',getdate(),'completed','" + lblCID.Text + "','" + dateTo + "','" + txtamountpaid.Text + "','" + lumpinitial_tax + "',round('" + lbltotamountpaid_tax.Text + "',0))";
                      //Response.Write("Test4:" + _Qry2);
                   }
                   else
                   {
                       double lumpamt =Convert.ToDouble(lbllumpamt.Text);
                       double lumpinit = Convert.ToDouble(lbllumpinitial.Text);
                       double subtract = lumpamt - lumpinit;
                       double subtract_tax = subtract * (tax7 / 100);
                       double totsubtract_tax = subtract + subtract_tax;

                       string dateTo = "";
                       if (txtinstalldate.Text != "")
                       {
                           string str1 = txtinstalldate.Text;
                           string[] split1 = str1.Split('-');
                           dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                       }
                       else
                       {
                           //dateTo = System.DateTime.Now.ToString();
                           string str1 = System.DateTime.Now.ToString("yyyy-MM-dd");
                           //string[] split1 = str1.Split('-');
                           dateTo = str1;
                       }

                       _Qry2 = "INSERT INTO install_amountdetails(centre_code , Invoice_no , student_id , course_id , course_fees , course_tax , totalcourse_fees ,instalment_amount , instalamountax ,totinstalamount_tax,instal_number,initialamount,initialamout_tax,totinitialamt_tax,date , status , course_name ,install_date)values('" + Session["SA_centre_code"] + "','" + Session["Invoice_no"] + "','" + Request.QueryString["studid"] + "','" + txtcourseid.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcoursefee.Text) + "','" + totcoursefee + "','" + totcoursefee_tax + "',Round('" + subtract + "',0),Round('" + subtract_tax + "',0),Round('" + totsubtract_tax + "',0),'1','" + subtract + "','" + subtract_tax + "','" + totsubtract_tax + "',getdate(),'pending','" + lblCID.Text + "',DATEADD(month,1,'" + dateTo + "'))";
                       //Response.Write("Test5:" + _Qry2);
                   }

                   MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
                 
               }

               //Response.End();
               Response.Redirect("InvoiceDetails.aspx?studid=" + Request.QueryString["studid"] + "");
                  
             
           }
        }
    }
    
    private void fillprogramdropdown(int id)
    {
        _Qry = "select program,course_id from img_coursedetails where course_id=" +id+ "";
        //Response.Write(_Qry);
        //Response.End();
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
}
