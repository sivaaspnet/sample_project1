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

public partial class superadmin_ProjectAssesment : System.Web.UI.Page
{
    string _Qry,_Qry1,_Qry2,_Qry3,_qry,centreid,batchcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

       
        
        if (!IsPostBack)
        {
            //fillcentre();
            //string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
            ////string yea = string.Format("{0:yyyy}", DateTime.Now).Trim();
            //TextBox4.Text = mon;
            

            //TextBox1.Text = DateTime.Now.ToString("01-MM-yyyy");
            //TextBox3.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtEvalDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtEvaluatedBy.Text = Session["SA_Username"].ToString();

            HiddenField2.Value = Session["SA_Centrerole"] .ToString();
            if (Request.QueryString["StudentID"] == "" || Request.QueryString["StudentID"] == null)
            {
                //Fillsearchmodule();
              
                if (Session["SA_Centrerole"] .ToString() == "R&D")
                {
                   // assesment1.Visible = false;
                    projecthead.Visible = false;
                    
                }
                if (Session["SA_Centrerole"] .ToString() == "Certificate")
                {
                    //assesment1.Visible = false;
                    projecthead.Visible = false;

                }

            }
           
            else
            {
               // projecthead.Visible = false;
                search.Visible = false;
                tblvis.Visible = true;
                //Fillsearchmodule();
                filltechnicalhead();
               
                Label7.Text = Request.QueryString["StudentID"].ToString();
                Session["SA_centre_code"] = Request.QueryString["centrecode"].ToString();
                
            }
            access(); 
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtstudentid.Text);
    }

    //private void Fillsearchmodule()
    //{
    //    _qry = "select module_content,module_Id from module_details order by Module_Id ";
    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_qry);
    //    ddlsearchmodname.DataSource = dt1;
    //    ddlsearchmodname.DataValueField = "module_Id";
    //    ddlsearchmodname.DataTextField = "module_content";
    //    ddlsearchmodname.DataBind();
    //    ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
       
    //}

    //private void fillcentre()
    //{
    //    _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);

    //    DropDownList1.DataSource = dt;
    //    DropDownList1.DataTextField = "Centre_location";
    //    DropDownList1.DataValueField = "Centre_Code";
    //    DropDownList1.DataBind();
    //    DropDownList1.Items.Insert(0, new ListItem("Select", ""));
    //}
 
    private void fillgrid()
    {
        _Qry = "select * from view_assesment where studentid='"+txtstudentid.Text.Trim()+"' and moduleid='"+ddl_module.SelectedValue+"'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_StudentName.Text = dt.Rows[0]["enq_personal_name"].ToString();
            txtCourse.Text = dt.Rows[0]["program"].ToString();
            txtModule.Text = dt.Rows[0]["module"].ToString();
            txtproject.Text=Session["SA_Username"].ToString();
            HiddenField1.Value = dt.Rows[0]["batchCode"].ToString();
            TextBox1.Text = ddl_projectname.SelectedItem.ToString();
            tblvis.Visible = true;

            
            btn_submit.Visible = false;
            txtstudentid.ReadOnly = true;


            if (Session["SA_Centrerole"] .ToString() == "Technical Head" )
            {
                
                
            }
            if (Session["SA_Centrerole"] .ToString() == "Certificate")
            {
                certificate.Visible = true;
                randd.Visible = false;
                tech.Visible = false;

            }
            if (Session["SA_Centrerole"] .ToString() == "R&D")
            {
                certificate.Visible = false;
                randd.Visible = true;
                tech.Visible = false;
            }




            
        }
        else
        {
            showBox("No Records Founds");
        }
   
    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddl_insert_Click(object sender, EventArgs e)
    {
        _Qry = "select studentid from erp_studentprogress where studentid='" + txtstudentid.Text + "' and projectid='" + ddl_projectname.SelectedValue + "' and status !='Rejected'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        
        if(dt.Rows.Count > 0)
        {
            showBox("Project Already Entered");
            lblmsg1.Text = "Project Already Entered";
        }
        else
        {
            if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
            {

                if (txtSenddate.Text != "")
                {
                    string str2 = txtSenddate.Text;
                    string[] split2 = str2.Split('-');
                    string txtSenddate11 = split2[2] + "-" + split2[1] + "-" + split2[0];
                    _Qry = @"INSERT INTO erp_studentprogress([batchcode],[projectid],[moduleid],[centrecode],[studentid],[projectguided_by],[Senddate])VALUES('" + HiddenField1.Value + "','" + ddl_projectname.SelectedValue + "','" + ddl_module.SelectedValue + "','" + Session["SA_centre_code"] + "','" + txtstudentid.Text + "','" + txtproject.Text + "','" + txtSenddate11 + "')";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    showBox("SuccessFully Entered Project Assesment..!");
                    
                    lblmsg1.Text = "SuccessFully Entered Project Assesment..!";
                    Response.Redirect("Assesment.aspx");
                }
                else
                {
                    showBox("please Enter Send Date!");
                    lblmsg1.Text = "please Enter Send Date..!";
                }
            }


            if (Session["SA_Centrerole"] .ToString() == "Faculty")
            {
                _Qry = @"INSERT INTO erp_studentprogress([batchcode],[projectid],[moduleid],[centrecode],[studentid],[projectguided_by])VALUES('" + HiddenField1.Value + "','" + ddl_projectname.SelectedValue + "','" + ddl_module.SelectedValue + "','" + Session["SA_centre_code"] + "','" + txtstudentid.Text + "','" + txtproject.Text + "')";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                showBox("SuccessFully Entered Project Assesment..!");
                //fillgrid1();
                lblmsg1.Text = "SuccessFully Entered Project Assesment..!";
                Response.Redirect("Assesment.aspx");

            }
        }
    }
   


 
    protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillproject();
    }

    private void fillproject()
    {
        _Qry = @"select * from erp_moduleproject where moduleid='" + ddl_module.SelectedValue + "' and projectid not in (select projectid from erp_studentprogress where studentid='" + txtstudentid.Text+ "' and moduleid='" + ddl_module.SelectedValue + "' and status='Approved' )";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_projectname.DataSource = dt1;
        ddl_projectname.DataValueField = "projectid";
        ddl_projectname.DataTextField = "projectname";
        ddl_projectname.DataBind();
        ddl_projectname.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
   {
      if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
       {
           if (txtSenddate.Text != "")
           {
               string str = txtSenddate.Text;
               string[] split = str.Split('-');
               string txtSenddate1 = split[2] + "-" + split[1] + "-" + split[0];
               _Qry = "update erp_studentprogress set Senddate='" + txtSenddate1 + "' where studentid='" + Request.QueryString["Studentid"] + "' and projectid='" + Request.QueryString["projectid"] + "'  and centrecode='" + Session["SA_centre_code"].ToString() + "'";
               MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
               showBox("SuccessFully Entered Project Assesment..!");
               lblmsg1.Text = "SuccessFully Entered Project Assesment..!";
           }
           else
           {
               showBox("Please Enter Send date..!");
           }
       }
       else if (Session["SA_Centrerole"] .ToString() == "R&D")
       {

           if (txtEvalDate.Text != "")
           {
               string str2 = txtEvalDate.Text;
               string[] split2 = str2.Split('-');
               string txtEvalDate1 = split2[2] + "-" + split2[1] + "-" + split2[0];
               _Qry = @"update erp_studentprogress set EvaluatedBy='" + txtEvaluatedBy.Text + "', EvaluatedDate='" + txtEvalDate1 + "',Mark='" + txtmark.Text + "',Remarks='" + txtRemarks.Text + "',Status='" + ddl_status.SelectedValue + "'  where studentid='" + Request.QueryString["Studentid"] + "' and projectid='" + Request.QueryString["projectid"] + "'  and centrecode='" + Request.QueryString["centrecode"] + "'";
               MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
               showBox("SuccessFully Entered Project Assesment..!");
               Response.Redirect("notification.aspx#Assesment");
           }
           else
           {
               showBox("please enter evaluate date..!");
           }
       }

       else if (Session["SA_Centrerole"] .ToString() == "Certificate")
       {
           if (txtDispatchdate.Text != "")
           {
               string str1 = txtDispatchdate.Text;
               string[] split1 = str1.Split('-');
               string txtDispatchdate1 = split1[2] + "-" + split1[1] + "-" + split1[0];
               _Qry = @"update erp_studentprogress set Dispatchdate='" + txtDispatchdate1 + "'  where studentid='" + Request.QueryString["Studentid"] + "' and projectid='" + Request.QueryString["projectid"] + "' and centrecode='" + Request.QueryString["centrecode"] + "'";
               MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
               showBox("SuccessFully Entered Project Assesment..!");
               //fillgrid1();
               lblmsg1.Text = "SuccessFully Entered Project Assesment..!";
           }
           else
           {
               showBox("Please Enter Dispatch Date..!");
           }
       }


    }

    private void filltechnicalhead()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Label4.Text = "Please Select Centre Location";

        }
        else
        {
            ddl_insert.Visible = false;
            ddl_update.Visible = true;
            _Qry = @"
SELECT DISTINCT 
                      erp_studentprogress.projectid,erp_studentprogress.id, erp_studentprogress.moduleid, erp_studentprogress.studentid, img_coursedetails.program, 
                      adm_personalparticulars.enq_personal_name, Submodule_details_new.Module, projectdetails.projectname, erp_studentprogress.projectguided_by, 
                      convert(varchar,erp_studentprogress.Senddate,103) as  Senddate
FROM         erp_studentprogress INNER JOIN
                      erp_invoiceDetails ON erp_studentprogress.studentid = erp_invoiceDetails.studentId INNER JOIN
                      img_coursedetails ON erp_invoiceDetails.courseId = img_coursedetails.course_id INNER JOIN
                      adm_personalparticulars ON erp_invoiceDetails.studentId = adm_personalparticulars.student_id AND 
                      erp_studentprogress.studentid = adm_personalparticulars.student_id INNER JOIN
                      Submodule_details_new ON erp_studentprogress.moduleid = Submodule_details_new.ModuleId INNER JOIN
                      projectdetails ON erp_studentprogress.projectid = projectdetails.projectid

 where erp_studentprogress.studentid='" + Request.QueryString["Studentid"] + "' and erp_studentprogress.projectid='" + Request.QueryString["projectid"] + "' and erp_studentprogress.centrecode='" + Request.QueryString["centrecode"] + "'";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            // Response.Write(_Qry);
            if (dt1.Rows.Count > 0)
            {

                txt_StudentName.Text = dt1.Rows[0]["enq_personal_name"].ToString();
                txtCourse.Text = dt1.Rows[0]["program"].ToString();
                txtModule.Text = dt1.Rows[0]["module"].ToString();
                TextBox1.Text = dt1.Rows[0]["projectname"].ToString();
                txtproject.Text = dt1.Rows[0]["projectguided_by"].ToString();
                string send = dt1.Rows[0]["Senddate"].ToString();
                txtSenddate.Text = send;
            }
        }
    }

    private void access()
    {
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            txt_StudentName.Enabled = false;
            txtCourse.Enabled = false;
            txtModule.Enabled = false;
            TextBox1.Enabled = false;
            //txtproject.Enabled = false;

            txtDispatchdate.Enabled = false;
            txtEvalDate.Enabled = false;
            txtmark.Enabled = false;
            ddl_status.Enabled = false;
            txtEvaluatedBy.Enabled = false;
            txtRemarks.Enabled = false;
            certificate.Visible = false;
            randd.Visible = false;
            tech.Visible = true;

        }
    if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            txt_StudentName.Enabled = false;
            txtCourse.Enabled = false;
            txtModule.Enabled = false;
            TextBox1.Enabled = false;
            txtproject.Enabled = false;
            txtSenddate.Enabled = false;
            txtDispatchdate.Enabled = false;
            certificate.Visible = true;
            randd.Visible = true;
            tech.Visible = true;
            name.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
        }

        if (Session["SA_Centrerole"] .ToString() == "Certificate")
        {
            txt_StudentName.Enabled = false;
            txtCourse.Enabled = false;
            txtModule.Enabled = false;
            TextBox1.Enabled = false;
            txtproject.Enabled = false;
            txtSenddate.Enabled = false;

            txtEvalDate.Enabled = false;
            txtmark.Enabled = false;
            ddl_status.Enabled = false;
            txtEvaluatedBy.Enabled = false;
            txtRemarks.Enabled = false;
            certificate.Visible = true;
            randd.Visible = false;
            tech.Visible = true;
            name.Visible = true;

        }
   if (Session["SA_Centrerole"] .ToString() == "Faculty")
        {
            txtSenddate.Enabled = false;
            txtDispatchdate.Enabled = false;
            txtEvalDate.Enabled = false;
            txtmark.Enabled = false;
            ddl_status.Enabled = false;
            txtEvaluatedBy.Enabled = false;
            txtRemarks.Enabled = false;
        }

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = @"select Courseid,enq_personal_name,program from erp_invoicedetails inner join img_coursedetails on courseid=course_id
inner join adm_personalparticulars on student_id=studentid where studentid='" + txtstudentid.Text.Trim() + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                name.Visible = true;
                txt_StudentName.Text = dt.Rows[0]["enq_personal_name"].ToString();
                txtCourse.Text = dt.Rows[0]["program"].ToString();
                _Qry = "select module_Id,module_content from Onlinestudent_Coursesoftware where Course_Id='" + dt.Rows[0]["Courseid"].ToString() + "'  ";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                ddl_module.DataSource = dt1;
                ddl_module.DataValueField = "module_Id";
                ddl_module.DataTextField = "module_content";
                ddl_module.DataBind();
                ddl_module.Items.Insert(0, new ListItem("Select", ""));
                a1.Visible = true;
                a2.Visible = true;
                a3.Visible = true;
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "sedit")
        {
            _qry="select * from erp_studentprogress where id='"+e.CommandArgument.ToString()+"'";
            DataTable d1 = new DataTable();
            d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (d1.Rows.Count > 0)
            {
                
                txtModule.Text = d1.Rows[0]["module"].ToString();
                TextBox1.Text = d1.Rows[0]["projectname"].ToString();
                txtproject.Text = d1.Rows[0]["projectguided_by"].ToString();
                string send = d1.Rows[0]["Senddate"].ToString();
                txtSenddate.Text = send;
            }
        }
    }
}
