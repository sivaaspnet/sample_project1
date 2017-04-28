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

public partial class ImageTraining_2_Onlinestudents2_superadmin_ExportOldtonew : System.Web.UI.Page
{
    string insertqry;
    double totalamt = 0;
    double totalinstall = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        if (!IsPostBack)
        {
            if(Request.QueryString["studentid"]!=null)
            {
                txtStudentId.Text=Request.QueryString["studentid"].ToString();
            }
            fillcourse();
            showtable.Visible = false;
            showtablehead.Visible = false;
        }
    }
    protected void fillcourse()
    {
        string qry = "select cd.course_id,cd.program from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and feed.centre_code='" + Session["SA_centre_code"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);

        ddlcourse.DataSource = dt;
        ddlcourse.DataValueField = "Course_Id";
        ddlcourse.DataTextField = "program";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandText = "[isExsistsINOld]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("studentId", txtStudentId.Text);
        cmd.Parameters.Add("@errorStatus", SqlDbType.Int).Value = 0;
        cmd.Parameters["@errorStatus"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        int errorStatus = 0;
        errorStatus = (int)cmd.Parameters["@errorStatus"].Value;
        Conn.Close();
        if (errorStatus == 1)
        {

            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 2)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 3)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 4)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 5)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 6)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 7)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 8)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 9)
        {
            Label1.Text = "StudentId already exists";
        }
        else if (errorStatus == 0)
        {
            showtable.Visible = true;
            showtablehead.Visible = true;
            txtStudentId.ReadOnly = true;
            TxtInstallNo.ReadOnly = true;
            DataTable dt = new DataTable();
            string _Qry = "select max(man.center_code), max(invoice.invoice_no) as invoiceNumber,max(replace(replace(convert(varchar,cast(( ROUND(invoice.total_amount,0)) as money),0),'.00',''),'-','')) as coursefees, a.install_number as instal_number,replace(replace(convert(varchar,cast((round(a.Install_Amount,0)) as money),0),'.00',''),'-','') as initamt , replace(replace(convert(varchar,cast(( ROUND(a.Install_Amount_tax,0)) as money),0),'.00',''),'-','') as init_tax,replace(convert(varchar,cast(  (round(a.total_install_amount,0)) as money),0),'.00','')as totinittax,replace(convert(varchar,cast(  (round(a.total_install_amount,0)) as money),0),'.00','')as totalinstal_tax,case when a.receipt_no=0 then NULL else a.receipt_no end as Receipt_no,case when a.receipt_no=0 THEN '' ELSE replace(convert(varchar,cast((round(a.total_install_amount,0)) as money),0),'.00','')  END as tamtpaid, DateAdd(month,(row_number() over (order by install_number))-1,(select convert(varchar,install_date,101) From Old_install_amountdetails where student_id='" + txtStudentId.Text + "' And install_number=1))  AS install_date,(select Top 1 convert(varchar, date, 101) from OldReceipt_Details where rec_no=a.Receipt_no And student_id='" + txtStudentId.Text + "' group by Rec_no,date) as dateins  from Old_install_amountdetails a inner join OldReceipt_Details receipt on a.student_id= receipt.student_id inner join Oldinvoice_details invoice on a.student_id=invoice.student_id inner join old_student_manual man on man.manual_code=invoice.center_code and man.center_code='" + Session["SA_centre_code"].ToString() + "' where a.student_id='" + txtStudentId.Text + "'  group by a.ID,a.install_number,a.Install_Amount,Install_Amount_tax,total_install_amount,install_date,a.Receipt_no,a.total_install_amount Order By a.install_number";
            string Qry = "Select enq.enquiry_no,man.center_code,enq.enq_date,enq.enq_name,enq.permanent_address,enq.temporary_address,enq.mobile,enq.e_mail, enq.enq_status,enq.date_ins,enr.student_id,enr.course_id,enr.track,enr.course_name,enr.payment_type,enr.Payment_mode,enr.batch_time from OldEnquiry_Details enq inner join OldEnrolled_Details enr on enq.enquiry_no=enr.enquiry_no and enq.center_code=enr.center_code and enr.student_id='" + txtStudentId.Text + "'  inner join old_student_manual man on man.manual_code=enr.center_code and man.center_code='" + Session["SA_centre_code"].ToString() + "' ";
            DataTable dtval = new DataTable();
            dtval = MVC.DataAccess.ExecuteDataTable(Qry);
            if (dtval.Rows.Count > 0)
            {
                lblcourse.Text = dtval.Rows[0]["course_id"].ToString();
                txt_name.Text = dtval.Rows[0]["enq_name"].ToString();
                txtcentercode.Text = dtval.Rows[0]["center_code"].ToString();
                txtcoursefees.Text = dtval.Rows[0]["enq_name"].ToString();
                txtenqno.Text = "old-" + dtval.Rows[0]["enquiry_no"].ToString();
                txtinstalltype.SelectedValue = dtval.Rows[0]["payment_type"].ToString();
                ddltrack.SelectedValue = dtval.Rows[0]["track"].ToString();
                txttempaddress.Text = dtval.Rows[0]["temporary_address"].ToString();
                txtpermaddress.Text = dtval.Rows[0]["permanent_address"].ToString();
                txtmobile.Text = dtval.Rows[0]["mobile"].ToString();
                txtemail.Text = dtval.Rows[0]["e_mail"].ToString();
                txtbatch.SelectedValue = dtval.Rows[0]["batch_time"].ToString();
            }
            else
            {
                txtenqno.Text = "old-" + txtStudentId.Text.ToString();
                txtcentercode.Text = Session["SA_centre_code"].ToString();
            }
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txtinvoice.Text = dt.Rows[0]["invoiceNumber"].ToString();
                txtcoursefees.Text = dt.Rows[0]["coursefees"].ToString();
            }
            int oldInstallNo = dt.Rows.Count;
            int newInstallNo = 0;
            int currentInstallNo = oldInstallNo;
            if (isInteger(TxtInstallNo.Text))
            {
                newInstallNo = Convert.ToInt32(TxtInstallNo.Text);
            }
            if (oldInstallNo < newInstallNo)
            {
                currentInstallNo = newInstallNo;

                dt.Columns.Add("InstallNo", Type.GetType("System.String"));

                for (int i = dt.Rows.Count; i < currentInstallNo; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = i.ToString();
                    dt.Rows.Add(dr);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["tamtpaid"].ToString() != "")
                    totalamt += Convert.ToDouble(dt.Rows[i]["tamtpaid"].ToString());

                if (dt.Rows[i]["initamt"].ToString() != "")
                    totalinstall += Convert.ToDouble(dt.Rows[i]["initamt"].ToString());

            }
            totalinstallamts.Text = totalinstall.ToString();
            totalpaidamount.Text = totalamt.ToString();

            GridView1.DataSource = dt;
            GridView1.DataBind();
            txtinstall.Text = dt.Rows.Count.ToString();


        }
}
    bool isInteger(string no)
    {
        bool res = true;
        try
        {
            int no1 = Convert.ToInt32(no);
        }
        catch (Exception ex)
        {
            res = false;
        }
        return res;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        
      
        //else
        //{
        //    lblerrormsg.Text = "";
        //}
        
        
        System.Text.StringBuilder sqlQry = new System.Text.StringBuilder();
        sqlQry.Append("");
        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandText = "[isExsistsINOld]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("studentId", txtStudentId.Text);
        cmd.Parameters.Add("@errorStatus", SqlDbType.Int).Value = 0; 
        cmd.Parameters["@errorStatus"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        int errorStatus = 0;
        errorStatus = (int)cmd.Parameters["@errorStatus"].Value;
        //Conn.Close();
        //if (errorStatus==1)
        //{
        //    lblerrormsg.Text = "StudentId already exists";
        //}
        //else if (errorStatus == 2)
        //{
        //    lblerrormsg.Text = "StudentId already exists";
        //}
        //else if (errorStatus == 3)
        //{
        //    lblerrormsg.Text = "StudentId already exists ";
        //}
        //else if (errorStatus == 4)
        //{
        //    lblerrormsg.Text = "StudentId already exists ";
        //}
        //else if (errorStatus == 5)
        //{
        //    lblerrormsg.Text = "StudentId already exists ";
        //}
        //else if (errorStatus == 6)
        //{
        //    lblerrormsg.Text = " StudentId   already exists ";
        //}
        //else if (errorStatus == 7)
        //{
        //    lblerrormsg.Text = " StudentId already exists ";
        //}
        //else if (errorStatus == 8)
        //{
        //    lblerrormsg.Text = " StudentId already exists ";
        //}
        //else if (errorStatus == 9)
        //{
        //    lblerrormsg.Text = " StudentId already exists ";
        //}
        //else if (errorStatus == 0)
        //{
        //   try
        //    {
                sqlQry.Append("declare @amt varchar(300)");
               
                sqlQry.Append(" Insert into adm_studentId (student_id,centre_code) values ('" + txtStudentId.Text + "','" + txtcentercode.Text + "')");
                sqlQry.Append(" Insert into adm_personalparticulars (student_id,centre_code,enq_number,enq_personal_name,student_lastname,present_phone,permanant_phone) values ('" + txtStudentId.Text + "','" + txtcentercode.Text + "','" + txtenqno.Text + "','" + txt_name.Text + "',' ','" + txtmobile.Text + "','" + txtmobile.Text + "')");
                sqlQry.Append(" Insert into adm_generalinfo (student_id,centre_code,enq_number,coursename,track,payment_pattern,payment_coursefee,payment_noofinstall,batchtime,password) values ('" + txtStudentId.Text + "','" + txtcentercode.Text + "','" + txtenqno.Text + "','" + ddlcourse.SelectedValue + "','" + ddltrack.SelectedValue + "','" + txtinstalltype.SelectedValue + "','" + txtcoursefees.Text + "','" + txtinstall.Text + "','" + txtbatch.SelectedValue + "','" + txtStudentId.Text + "')");
                sqlQry.Append(" Insert into adm_course_empdetails (student_id,centre_code,enq_number) values ('" + txtStudentId.Text + "','" + txtcentercode.Text + "','" + txtenqno.Text + "')");
                sqlQry.Append(" Insert into erp_invoicedetails (centercode,studentid,invoiceid,track,coursefees,courseid,installno,paymenttype,batchtime,taxpercentage,status) values ('" + txtcentercode.Text + "','" + txtStudentId.Text + "','" + txtinvoice.Text + "','" + ddltrack.SelectedValue + "','" + txtcoursefees.Text + "','" + ddlcourse.SelectedValue + "','" + txtinstall.Text + "','" + txtinstalltype.SelectedValue + "','" + txtbatch.SelectedValue + "','" + txttax.Text + "','active')");
                sqlQry.Append(" Insert into img_enquiryform (enq_number,centre_code,enq_personal_name,enq_personal_mobile,enq_personal_email,enq_present_address,enq_permanant_address) values ('" + txtenqno.Text + "','" + txtcentercode.Text + "','" + txt_name.Text + "','" + txtmobile.Text + "','" + txtemail.Text + "','" + txttempaddress.Text + "','" + txtpermaddress.Text + "') ");
                sqlQry.Append(" Insert into img_enquiryform1  (enq_number,centre_code) values ('" + txtenqno.Text + "','" + txtcentercode.Text + "')");
                sqlQry.Append(" Insert into erp_studentcoursedetails (studentid,centercode,invoiceno,courseid,coursefees,track,coursestartdate,batch,installnumber,status,dateins) values ('" + txtStudentId.Text + "','" + txtcentercode.Text + "','" + txtinvoice.Text + "','" + ddlcourse.SelectedValue + "','" + txtcoursefees.Text + "','" + ddltrack.SelectedValue + "',' ','" + txtbatch.SelectedValue + "','" + txtinstall.Text + "','1',getdate())");

                int rowcount = GridView1.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {
                    Label installnumber = (Label)(GridView1.Rows[i].Cells[0].FindControl("TextBox60"));
                    TextBox initialamount = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox61"));
                    TextBox initialamounttax = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox62"));
                    TextBox totalinitialamount = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox63"));
                    TextBox installdate = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox64"));
                    TextBox amtpaid = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox65"));
                    TextBox amtpaidtax = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox66"));
                    TextBox totamtpaid = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox67"));
                    TextBox receiptnumber = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox68"));
                    TextBox receiptdate = (TextBox)(GridView1.Rows[i].Cells[0].FindControl("TextBox69"));
                    string idate = installdate.Text;
                    string[] split = idate.Split('-');
                    idate = split[1] + "/" + split[0] + "/" + split[2];
                    string rdate = receiptdate.Text;
                    string[] split1 = rdate.Split('-');
                    rdate = split1[1] + "/" + split1[0] + "/" + split1[2];
                    //Response.Write(split);
                    //Response.Write(rdate);
                    
                    //        int rowID = i + 2; // ct102 default id for row index 0               
            //        int installnumber = Convert.ToInt32( Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox60"]);
            //        string initialamount = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox61"].ToString();
            //        string initialamounttax = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox62"].ToString();
            //        string totalinitialamount = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox63"].ToString();
            //        string installdate = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox64"].ToString();
            //        string amtpaid = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox65"].ToString();
            //        string amtpaidtax = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox66"].ToString();
            //        string totamtpaid = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox67"].ToString();
            //        string receiptnumber = Request.Form["ctl00$ContentPlaceHolder1$GridView1$ctl0" + rowID + "$TextBox68"].ToString();
                    if (amtpaid.Text != "" && amtpaidtax.Text != "" && totamtpaid.Text != "" && receiptnumber.Text != "")
                    {
                        sqlQry.Append(" select @amt=words from fnNumToWords1('" + totamtpaid.Text + "','')");
                        sqlQry.Append(" Insert into erp_receiptdetails (centercode,studentid,receiptno,dateIns,installNo,invoiceno,amount,taxamount,totalamount,paymenttowards,paymentwords,receipttype,status) values ('" + txtcentercode.Text + "','" + txtStudentId.Text + "','" + receiptnumber.Text + "','" + rdate + "','" + installnumber.Text + "','" + txtinvoice.Text + "','" + amtpaid.Text + "','" + amtpaidtax.Text + "','" + totamtpaid.Text + "','Image infotainment limited',@amt,'Invoice','1')");
                        sqlQry.Append(" Insert into erp_installamountdetails (centercode,invoiceno,studentid,installnumber,initialamount,initialamounttax,totalinitialamount,courseid,installdate,status,dateins) values ('" + txtcentercode.Text + "','" + txtinvoice.Text + "','" + txtStudentId.Text + "','" + installnumber.Text + "','" + initialamount.Text + "','" + initialamounttax.Text + "','" + totalinitialamount.Text + "','" + ddlcourse.SelectedValue + "','" + idate + "','Completed',getdate())");

                    }
                    else
                    {
                        sqlQry.Append(" Insert into erp_installamountdetails (centercode,invoiceno,studentid,installnumber,initialamount,initialamounttax,totalinitialamount,courseid,installdate,status,dateins) values ('" + txtcentercode.Text + "','" + txtinvoice.Text + "','" + txtStudentId.Text + "','" + installnumber.Text + "','" + initialamount.Text + "','" + initialamounttax.Text + "','" + totalinitialamount.Text + "','" + ddlcourse.SelectedValue + "','" + idate + "','Pending',getdate())");

                    }
                    // string val= "ctl00_ContentPlaceHolder1_GridView1_ctl02_TextBox63");


                    //sqlQry.Append("Insert into erp_receiptdetails ()");              

                }
            //Response.Write(sqlQry.ToString());
           MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, sqlQry.ToString());
            lblerrormsg.Text = "inserted successfully";
            //if (Request.QueryString["studentid"] != null)
            //{
            //    string _Qry = "update erp_studenttransfer set newstudentid='" + txtStudentId.Text + "',dateupt=getdate() where studentid=" + Request.QueryString["studentid"] + "";
            //    //Response.Write(_Qry);
            //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //}
            //}
            //catch (Exception ex)
            //{
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandText = "[isExsistsINOld]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("studentId", txtStudentId.Text);
        cmd.Parameters.Add("@errorStatus", SqlDbType.Int).Value = 0;
        cmd.Parameters["@errorStatus"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        int errorStatus = 0;
        errorStatus = (int)cmd.Parameters["@errorStatus"].Value;
        Conn.Close();
        if (errorStatus == 1)
        {
            lblerrormsg.Text = "StudentId already exists in table adm_studentId";
        }
        else if (errorStatus == 2)
        {
            lblerrormsg.Text = "StudentId already exists in table adm_personalparticulars";
        }
        else if (errorStatus == 3)
        {
            lblerrormsg.Text = "StudentId already exists in table adm_generalinfo ";
        }
        else if (errorStatus == 4)
        {
            lblerrormsg.Text = "StudentId already exists in table adm_course_empdetails ";
        }
        else if (errorStatus == 5)
        {
            lblerrormsg.Text = "StudentId already exists in table erp_receiptdetails ";
        }
        else if (errorStatus == 6)
        {
            lblerrormsg.Text = " StudentId   already exists in table erp_invoicedetails ";
        }
        else if (errorStatus == 7)
        {
            lblerrormsg.Text = " StudentId already exists in table erp_installamountdetails ";
        }
        else if (errorStatus == 8)
        {
            lblerrormsg.Text = " StudentId already exists in table img_enquiryform";
        }
        else if (errorStatus == 9)
        {
            lblerrormsg.Text = " StudentId already exists in table img_enquiryform1 ";
        }
        else if (errorStatus == 0)
        {
            lblerrormsg.Text = "Now you can export the data";
        }
         
    }
}
