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

public partial class Onlinestudents2_superadmin_StudentReportDetails : System.Web.UI.Page
{
    string _Qry, moduleid="";
    int i = 0;
    int Course_ID = 0;
    string StudentID = "";
    int abc = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["StudentID"] == "" || Request.QueryString["StudentID"] == null)
            {
                Response.Redirect("StudentReport.aspx");
            }
            else
            {
                if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
                {
                    Response.Redirect("Login.aspx");
                }
                if (!IsPostBack)
                {
                    StudentID = Request.QueryString["StudentID"].ToString();
                    FillHeaderSection();
                    Content();
                    fillgrid1();
                    leavegrid();
                    breakreport();
                    fillproject();
                    txt_softwareid.Text = "";

                    if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
                    {
                        btn_req.Visible = true;
                        btn_acc.Visible = false;
                        drop1();
                    }
                    else if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
                    {
                        btn_req.Visible = false;
                        Label5.Visible = false;
                        btn_acc.Visible = true;
                        ddl_reason.Visible = false;
                        txt_reason.ReadOnly = true;
                        drop1();
                        
                    }

                }
            }
        }
        
    }

   

    #region headersection
    private void FillHeaderSection()
    {
        string res = "";
        _Qry = @"
select (select sum(amount) from erp_receiptdetails rep  inner join erp_invoicedetails inv on invoiceno=invoiceid and inv.status='active' and rep.studentId=inv.studentId  where rep.studentId=b.StudentId and receiptType='Invoice' and rep.status='1')as paidamt, b.courseFees,a.student_id,a.student_mothertongue,a.student_bloodgroup,a.student_maritalstatus,a.student_nationality,img.gender,img.enq_present_address,img.enq_personal_altmobile,img1.enq_parent_name,img1.enq_parent_designation,img1.enq_parent_mobile,img1.enq_parent_email,a.enq_personal_name,a.photo,student_lastname,invoiceId,c.program,b.track,convert(varchar ,d.dateins,103) as EnrolledDate ,e.tax,enq_personal_mobile,enq_personal_email,enq_personal_dob from  adm_personalparticulars a inner join erp_invoicedetails b on b.studentId=a.student_id and b.status='active' inner join img_coursedetails c on c.course_id=b.courseId
inner join adm_Generalinfo d on d.admission_id=a.admission_id inner join img_centre_coursefee_details e on e.program=c.course_id
inner join img_enquiryform img on img.enq_number=a.enq_number  inner join img_enquiryform1 img1 on img.enq_id=img1.enq_id
where b.StudentId='" + Request.QueryString["StudentID"].ToString() + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  program from erp_studentCourseDetails inner join 
img_coursedetails on course_id=courseid where studentid='" + Request.QueryString["StudentID"].ToString() + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow val in dt1.Rows)
            {

                if (res == "")
                {
                    res = val["program"].ToString();
                }
                else
                {
                    res = res + "," + (val["program"].ToString());
                }


                lblCourse.Text = res;
                lblcoursename.Text = res;
            }
               
          
        }

        double pendingamt;
        double paidamt;
        double tax;
        double tottax;
        if (dt.Rows.Count > 0)
        {
            lbl_no.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            lblblood.Text = dt.Rows[0]["student_bloodgroup"].ToString();
            lblmarital.Text = dt.Rows[0]["student_maritalstatus"].ToString();
            lblmother.Text = dt.Rows[0]["student_mothertongue"].ToString();
            lblnation.Text = dt.Rows[0]["student_nationality"].ToString();
            lblgender.Text = dt.Rows[0]["gender"].ToString();
            lbladdress.Text = dt.Rows[0]["enq_present_address"].ToString();
            lblano.Text = dt.Rows[0]["enq_personal_altmobile"].ToString();
            lblfname.Text = dt.Rows[0]["enq_parent_name"].ToString();
            lblfoccupation.Text = dt.Rows[0]["enq_parent_designation"].ToString();
            lblfno.Text = dt.Rows[0]["enq_parent_mobile"].ToString();
            lblfemail.Text = dt.Rows[0]["enq_parent_email"].ToString();
               
              

            lbldob.Text = dt.Rows[0]["enq_personal_dob"].ToString().Split(' ')[0].ToString();
            lblInv.Text = dt.Rows[0]["invoiceId"].ToString();
            lbl_mail.Text = dt.Rows[0]["enq_personal_email"].ToString();
          //  lbl_add.Text = dt.Rows[0]["address"].ToString();
            lblEnrDate.Text = dt.Rows[0]["EnrolledDate"].ToString();
          //  lblSId.Text = dt.Rows[0]["student_id"].ToString();
          //  LblSName.Text = dt.Rows[0]["enq_personal_name"].ToString();

            lblstudentname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            lblstudentid.Text = dt.Rows[0]["student_id"].ToString();
          

            lblTrack.Text = dt.Rows[0]["track"].ToString();
            lbl_coursefees.Text = dt.Rows[0]["courseFees"].ToString();
            paidamt = Convert.ToDouble(dt.Rows[0]["paidamt"]);
            pendingamt = Convert.ToDouble(dt.Rows[0]["courseFees"]) - (paidamt);
            lbl_pendingamt.Text = amts(pendingamt);
            lblpaidamount.Text = amts(paidamt);
            tax = Convert.ToDouble(dt.Rows[0]["tax"]);
            tottax = (pendingamt) + ((pendingamt * tax) / 100);
            lbl_pendingwithtax.Text =  amts(tottax);
            if (dt.Rows[0]["photo"].ToString()=="")
            {
                Image2.ImageUrl = "~/studentphoto/blank person.jpg";
            }
            else
            {
                Image2.ImageUrl = "~/studentphoto/" + dt.Rows[0]["photo"].ToString();
            }
           
        }
        else
        {
            lblInv.Text = "";
            lblEnrDate.Text = "";
            lblSId.Text = "";
            LblSName.Text = "";
            lblCourse.Text = "";
            lblTrack.Text = "";
            tr1.Visible = false;
           // tr2.Visible = false;
            //tr3.Visible = false;
            lnk_inv.Visible = false;
            lbl_error.Text = "StudentFees Details Not Found";
        }

       

    }
    #endregion
    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = "Rs " + amountvalue.ToString("#,000");
        }
        return words;
    }

    #region Content

    private void Content()
    {
        _Qry = @"select distinct inv.studentid,courseid,invoiceid,module_content,course.module_id,d.Software,d.Software_id from erp_invoicedetails inv inner join Onlinestudent_Coursesoftware course on course.course_id=inv.courseid and inv.status='active' inner join Submodule_details_new d on d.moduleId =course.module_id  where inv.studentid='" + Request.QueryString["studentid"] + "'";
        //if (txt_softwareid.Text != "")
        //{
        //    _Qry += " and d.Software like '" + txt_softwareid.Text.Trim() + "%'";
         
        //}
        _Qry += " order by module_id";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //Response.Write(_Qry);
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (moduleid == "")
                {
                    moduleid = dt1.Rows[i]["module_id"].ToString();
                }
                else
                {
                    moduleid = moduleid + "," + dt1.Rows[i]["module_id"].ToString();
                }
            }
        }
        else
        {
            moduleid = "0";
            lbl_error.Text = "Contact Admin,Course Data Improper";

        }
        _Qry = @"select distinct sce.batchcode,bat.moduleid,studentid,sce.status,sce.software_id
from erp_batchdetails  bat inner join erp_batchschedule 
 sce on sce.batchcode=bat.batchcode inner join Onlinestudent_Software c on c.Software_Id=sce.Software_id  where sce.studentid='" + Request.QueryString["studentid"] + "' and bat.moduleid in (" + moduleid + ") order by sce.batchcode";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //Response.Write(_Qry);

        _Qry = @"select distinct sce.batchcode,bat.moduleid,studentid,count(sce.status) as pending,noofclass,
sce.software_id from erp_batchdetails bat 
inner join erp_batchschedule sce on sce.batchcode=bat.batchcode where sce.studentid='" + Request.QueryString["studentid"] + "' and bat.moduleid in (" + moduleid + ") and (sce.status='pending' or sce.status='repending')group by sce.batchcode,bat.moduleid,sce.Software_id,noofclass,studentid";
        //Response.Write(_Qry);
        DataTable dt3 = new DataTable();
        dt3 = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select distinct studentid,software_id,moduleid,softwarestatus from erp_oldbatchdetails where status='active' and centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(_Qry);



        DataTable status = new DataTable();
        status.Columns.Add(new DataColumn("module_content", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("software", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("software_id", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("batchcode", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("content", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("moduleid", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();
        foreach (DataRow drs in dt1.Rows)
        {
            dr = status.NewRow();
            //            dr["module"] = getmodule(dt1, "module_id='" + drs["moduleid"] + "' and studentid='" + Request.QueryString["studentid"] + "'");
            //dr["software"]=drs["Software_Name"];
            dr["module_content"] = drs["module_content"];
            dr["Software"] = drs["Software"];
            dr["software_id"] = drs["software_id"];
            dr["studentid"] = drs["studentid"];
            dr["moduleid"] = drs["module_id"];
            dr["content"] = getcontentstatus(dt3, " moduleid='" + drs["module_id"] + "'and software_id='" + drs["Software_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'");
            //dr["batchcode"] = getbatch(dt2, "moduleid='" + drs["module_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'", "batchcode");
            dr["status"] = getstatus(dt4, "moduleid='" + drs["module_id"] + "'and software_id='" + drs["Software_id"] + "' and studentid='" + Request.QueryString["studentid"] + "'");
            status.Rows.Add(dr);
        }

    

       
        GridView1.DataSource =status;
        GridView1.DataBind();
    }

    #endregion
    

    string getbatch(DataTable dtexp, string expression, string column)
    {
        string batch = "";
        string batch1 = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (batch1 != val[column].ToString())
                {
                     batch1 = val[column].ToString();
                    if(batch=="")
                    batch = "<a  href='studentbatch.aspx?batchcode=" + (val[column].ToString()) + "&studentid=" + Request.QueryString["studentid"] + "' >" + (val[column].ToString()) + "</a>";
                    else
                    batch = batch + "<br>" + "<a  href='studentbatch.aspx?batchcode=" + (val[column].ToString()) + "&studentid=" + Request.QueryString["studentid"] + "' >" + (val[column].ToString()) + "</a>";

                }
        
            }
        }

        else
        {
            batch = "Batch Not Schedule";
        }
        return batch.ToString();
       

    }
    string getsoft(DataTable dtexp, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = (val["Software_Name"].ToString());
            }

        }


        return res.ToString();
    }
    string getmodule(DataTable dtexp, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = (val["module_content"].ToString());
            }

        }


        return res.ToString();
    }
    string getstatus(DataTable dtexp, string expression)
    {
        string res = "<span style='color:green; font-weight:bold;'>Completed</span>";
    
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                res = res + "," + (val["softwarestatus"].ToString());
             
            }
            string value = res;
            string[] split = value.Split(',');
          
            for (int i = 0; i < split.Length; i++)
            {
                if ((split[i].ToString() == "Pending") || (split[i].ToString() == "pending") || (split[i].ToString() == "Repending"))
                {
                    res = "<span style='color:red; font-weight:bold;'>Inprogress</span>";

                }
                else
                {
                    res = "<span style='color:green; font-weight:bold;'>Completed</span>";
                }
               
            }
        }
        else
        {
            res = "Batch Not Schedule";
        }
        
        return res.ToString();
    }

    string getcontentstatus(DataTable dtexp, string expression)
    {
        string res = "";
        int pending = 0;
        //int noofclass = 0;
         
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                pending = (Convert.ToInt32(val["pending"]));
                //noofclass = (Convert.ToInt32(val["noofclass"]));
               // pending = noofclass - pending;
                res = "<span style='color:green; font-weight:bold;'>" + pending + "</span>";
                //+"/" + "<span style='color:red; font-weight:bold;'>" + noofclass + "</span>";
            }

        }
        else
        {
            res = "Batch Not Schedule";
        }
        
        return res.ToString();
    }
    protected void lnk_inv_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoiceDetails.aspx?invno= "+ lblInv.Text+ "");
    }
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
        
    //    GridView1.PageIndex = e.NewPageIndex;
    //    Content();
      
    //}



    //drop code starts


    private void fillgrid()
    {
        _Qry = @"select distinct student_id,enq_personal_name from adm_personalparticulars where student_id='" + Request.QueryString["StudentID"].ToString() + "' and centre_code='" + Session["SA_centre_code"] + "' and studentstatus='active'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {

            _Qry = "insert into erp_studentdrop (studentid,reason,requesteddate,status,centercode) values('" + Request.QueryString["StudentID"].ToString() + "','" + TextBox1.Text + "'+'" + txt_reason.Text + "',getdate(),'Requested','" + Session["SA_centre_code"] + "')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
             showBox("Request Sent Successfully...! ");
        }
        else
        {
             showBox("No Records Available");
        }

    }



    
    protected void btn_dec1(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
        {

            _Qry = "select * from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "' and status ='Requested'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "update erp_studentdrop set droppeddate=getdate(),status='Declined',reason_decline='"+txtdecline.Text+"' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                if (dt.Rows[0]["status"].ToString() == "Dropped")
                {
                    showBox( "student already dropped...!");

                }
                else if (dt.Rows[0]["status"].ToString() == "Declined")
                {
                    showBox("You already declined...!");

                }
                else
                {
                     showBox( "you have declined it....!");
                }
           
            }
             else
            {
               
                 showBox( "No Request Found");
                //Response.Redirect("drop.aspx");
            }
        }
        drop1();
        Response.Redirect("studentreportdetails.aspx?studentID=" + Request.QueryString["studentID"] + "#report4");
    }
    
    protected void btn_acc1(object sender, EventArgs e)
    {
        drop();
        drop1();
        Response.Redirect("studentreportdetails.aspx?studentID=" + Request.QueryString["studentID"] + "#report4");
    }

    private void drop()
    {

        _Qry = "select * from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "' and status ='Requested'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_reason.Text = dt.Rows[0]["reason"].ToString();

            _Qry = "update adm_personalparticulars set studentstatus='Dropped',remarks='" + txt_reason.Text + "' where student_id='" + Request.QueryString["StudentID"].ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "update erp_batchschedule set remarks= 'Student Dropped - '+'" + txt_reason.Text + "' ,batchstatus='Dropped' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "update erp_studentdrop set droppeddate=getdate(),status='Dropped' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "update erp_invoicedetails set studentstatus='deactive' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"] + "' and status='active'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            if (dt.Rows[0]["status"].ToString() == "Dropped")
            {
                 showBox("student already dropped...!");

            }
            else if (dt.Rows[0]["status"].ToString() == "Declined")
            {
                showBox("You already declined...!");

            }
            else
            {
                showBox("Student Successfully Dropped From ERP System...!");
            }


        }
        else
        {
             showBox("You can't drop student without getting request...!");

        }
    }
    private void drop1()
    {
        _Qry = "select convert(varchar,droppeddate,103) as droppeddate,reason,status,studentid,requesteddate,reason_decline  from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_reason.Text = dt.Rows[0]["reason"].ToString();
            Label6.Text = dt.Rows[0]["status"].ToString();
            txtdecline.Text = dt.Rows[0]["reason_decline"].ToString();
          
            if (Label6.Text=="Dropped")
            {
                
                Label6.Text = "Dropped";
                Label6.BackColor = System.Drawing.Color.Red;
                Label6.ForeColor = System.Drawing.Color.White;
                Image3.Visible = true;
                Image4.Visible = true;
               statuss.Visible = false;
               Table2.Visible = false;
                Image1.Visible = false;
                dropdate.Visible = true;
              dropdate.Text = dt.Rows[0]["droppeddate"].ToString();
              btn_acc.Visible = false;
              btn_dec.Visible = false;
              btn_req.Visible = false;
                Label4.Visible=false;
                Label7.Visible=false;
                Label5.Visible = false;
                ddl_reason.Visible = false;
                
               
                
            }
            else if (Label6.Text == "Requested")
            {
                Label6.Text = "Request Sent";
                Label6.BackColor = System.Drawing.Color.Yellow;
                Label6.ForeColor = System.Drawing.Color.Black;
            }
            else if (Label6.Text == "Declined")
            {
                Label6.Text = "Declined";
                Label6.BackColor = System.Drawing.Color.Red;
                Label6.ForeColor = System.Drawing.Color.Black;
                dropdate.Visible = true;
                dropdate.Text = dt.Rows[0]["droppeddate"].ToString();
                btn_acc.Visible = false;
                btn_dec.Visible = false;
                btn_req.Visible = false;
                Label5.Visible = false;
                ddl_reason.Visible = false;
                decline_reason.Style["display"] = "table-row";
                txtdecline.ReadOnly = true;
                
            }
            else
            {
                Label6.Text = "Active";
                Label6.BackColor = System.Drawing.Color.Green;
                Label6.ForeColor = System.Drawing.Color.White;
            }
           
            
        }
    }
   




    protected void btn_req1(object sender, EventArgs e)
    {
        _Qry = "select studentid from erp_studentdrop where studentid='" + Request.QueryString["StudentID"].ToString() + "'  and centercode='" + Session["SA_centre_code"] + "'";
         DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
      //  Response.Write(_Qry);
        if (dt.Rows.Count > 0)
        {
          
            showBox("Request Already Sent...!");
           
        }
        else
        {
            fillgrid();
        }
        drop1();
        Response.Redirect("studentreportdetails.aspx?studentID=" + Request.QueryString["studentID"] + "#report4");
    }

//drop tab code ends here


    // student leave option tab starts here


    private void fillgrid1()
    {

        leavegrid();
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            int leave = 0;
            _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and (status='Pending' or status_cen='pending') ";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                leave = Convert.ToInt32(dt1.Rows[0]["noofdays"]);
            }
            else
            {
                leave = 0;
            }
            
            if (leave < 4)
            {
                _Qry = " update erp_studentleave set status_cen='Approved' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and  status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and status='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grdcentre.DataSource = dt;
                grdcentre.DataBind();
                foreach (GridViewRow gr in grdcentre.Rows)
                {
                    Label lbl = new Label();
                    lbl = (Label)gr.FindControl("lblstatus");
                    LinkButton lnkapprove = new LinkButton();
                    lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
                    LinkButton lnkdecline = new LinkButton();
                    lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                    if (lbl.Text == "Pending")
                    {
                        lnkapprove.Visible = true;
                        lnkdecline.Visible = true;
                        lbl.Visible = false;
                    }
                    else
                    {
                        lnkapprove.Visible = false;
                        lnkdecline.Visible = false;
                        lbl.Visible = true;
                    }
                }


            }
            else
            {
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and status='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grdcentre.DataSource = dt;
                grdcentre.DataBind();
                foreach (GridViewRow gr in grdcentre.Rows)
                {
                    Label lbl = new Label();
                    lbl = (Label)gr.FindControl("lblstatus");
                    LinkButton lnkapprove = new LinkButton();
                    lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
                    LinkButton lnkdecline = new LinkButton();
                    lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                    if (lbl.Text == "Pending")
                    {
                        lnkapprove.Visible = true;
                        lnkdecline.Visible = true;
                        lbl.Visible = false;
                    }
                    else
                    {
                        lnkapprove.Visible = false;
                        lnkdecline.Visible = false;
                        lbl.Visible = true;
                    }
                }

            }


            if (grdcentre.Columns.Count > 0)
            {
                grdcentre.Columns[7].Visible = false;
            }
            else
            {
                grdcentre.HeaderRow.Cells[7].Visible = false;
                foreach (GridViewRow gvr in grdcentre.Rows)
                {
                    gvr.Cells[7].Visible = false;
                }
            }
        }

        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
        {
            int leave = 0;
            _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and (status='Pending' or status_cen='pending') ";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                leave = Convert.ToInt32(dt1.Rows[0]["noofdays"]);
            }
            else
            {
                leave = 0;
            }

            if (leave < 4)
            {
                _Qry = " update erp_studentleave set status_cen='Approved' where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and  status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and status_cen='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
              //  lnkapprove1.Visible = false;
              //  lnkdecline1.Visible = false;
                grdcentre.DataSource = dt;
                grdcentre.DataBind();
               
                foreach (GridViewRow gr in grdcentre.Rows)
                {
                    Label lbl1 = new Label();
                    lbl1 = (Label)gr.FindControl("lblstatus1");
                    LinkButton lnkapprove1 = new LinkButton();
                    lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
                    LinkButton lnkdecline1 = new LinkButton();
                    lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
                    if (lbl1.Text == "Pending")
                    {
                        lnkapprove1.Visible = true;
                        lnkdecline1.Visible = true;
                        lbl1.Visible = false;
                    }
                    else
                    {
                        lnkapprove1.Visible = false;
                        lnkdecline1.Visible = false;
                        lbl1.Visible = true;
                    }
                }
              
                
            }
            else
            {
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "' and status_cen='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grdcentre.DataSource = dt;
                grdcentre.DataBind();
                foreach (GridViewRow gr in grdcentre.Rows)
                {
                    Label lbl1 = new Label();
                    lbl1 = (Label)gr.FindControl("lblstatus1");
                    LinkButton lnkapprove1 = new LinkButton();
                    lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
                    LinkButton lnkdecline1 = new LinkButton();
                    lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
                    if (lbl1.Text == "Pending")
                    {
                        lnkapprove1.Visible = true;
                        lnkdecline1.Visible = true;
                        lbl1.Visible = false;
                    }
                    else
                    {
                        lnkapprove1.Visible = false;
                        lnkdecline1.Visible = false;
                        lbl1.Visible = true;
                    }
                }


              
            }


            if (grdcentre.Columns.Count > 0)
            {
                grdcentre.Columns[6].Visible = false;
            }
            else
            {
                grdcentre.HeaderRow.Cells[6].Visible = false;
                foreach (GridViewRow gvr in grdcentre.Rows)
                {
                    gvr.Cells[6].Visible = false;
                }
            }
        }


    }
    private void leavegrid()
    {
        _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where studentid='" + Request.QueryString["StudentID"].ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl1 = new Label();
            lbl1 = (Label)gr.FindControl("lblstatus1");
            LinkButton lnkapprove1 = new LinkButton();
            lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
            LinkButton lnkdecline1 = new LinkButton();
            lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
            Label lbl = new Label();
            lbl = (Label)gr.FindControl("lblstatus");
            LinkButton lnkapprove = new LinkButton();
            lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
            LinkButton lnkdecline = new LinkButton();
            lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                lnkapprove1.Visible = false;
                lnkdecline1.Visible = false;
                lbl1.Visible = true;
                lnkapprove.Visible = false;
                lnkdecline.Visible = false;
                lbl.Visible = true;
          
        }

    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
            if (e.CommandName == "approve1")
            {
                _Qry = " update erp_studentleave set status_cen='Approved',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            }
            else if (e.CommandName == "decline1")
            {
                _Qry = " update erp_studentleave set status_cen='Rejected',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            if (e.CommandName == "approve")
            {
                _Qry = " update erp_studentleave set status='Approved',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (e.CommandName == "decline")
            {
                _Qry = " update erp_studentleave set status='Rejected',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
        fillgrid1();
        //Response.Redirect("studentreportdetails.aspx?studentID=" + Request.QueryString["studentID"] + "#report3");

    }

    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid1();
    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    // student leave option Ended



    private void breakreport()
    {
        _Qry = @"select id,enq_personal_name,studentid,reason,convert(varchar,droppeddate,101) as breakdate 
from erp_studentdrop inner join adm_personalparticulars on student_id=studentid
 where status='Break' and action='active' and centercode='" + Session["SA_centre_code"].ToString() + "' and studentid='"+Request.QueryString["studentID"]+"' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView3.DataSource = dt;
        GridView3.DataBind();

    }
    protected void GridView3_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkedit")
        {
            _Qry = "update adm_personalparticulars set studentstatus='active' where student_id='" + e.CommandArgument.ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
            _Qry += "update erp_studentdrop set action='deactive' where studentid='" + e.CommandArgument.ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //_Qry = "update erp_batchschedule set batchstatus='active' where studentid='" + e.CommandArgument.ToString() + "' and centrecode='" + Session["SA_centre_code"] + "'";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            breakreport();

            lbl_error.Text = "Student Successfully Resumed";


        }

    }

    private void fillproject()
    {
        _Qry = "select * from view_progress where centrecode='" + Session["SA_centre_code"] + "' and studentid='" + Request.QueryString["studentID"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        fillassesment.DataSource = dt;
        fillassesment.DataBind();
    }
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    Content();
  
    //    //Response.Redirect("http://localhost:1389/ERP1/ImageTraining_2/Onlinestudents2/superadmin/StudentReportDetails.aspx?StudentID=" + Request.QueryString["studentID"] + "#report2");
    //}
}
