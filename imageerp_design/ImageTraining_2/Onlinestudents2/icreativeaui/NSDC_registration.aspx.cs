using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Services;
using System.Text.RegularExpressions;

public partial class NSDC_registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string student_id = Request.QueryString["student_id"];
        string id = Request.QueryString["id"];

        if (student_id == "" || student_id == null)
            Response.Redirect("NSDC.aspx");
        else
        {

            if (!IsPostBack)
            {
                state_fill();
                ddl_texperiencefill();
                ddl_tsectorfill();
                ddl_skillsfill();
                ddl_data_yearfill();
                ddl_trainerid_fill();
                
                if (id == "insert")
                {   
                    hf_id.Value = "insert";
                    fieldfill_insert(student_id);


                }
                else if (id == "edit")
                {
                    hf_id.Value = "edit";
                    fieldfill_edit(student_id);
                    btnsubmit.Text = "Update";


                }
                default_data();
            }
        }

    }
    protected string getcentreID()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("centre_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        //  dr = dt.Select("Center_Code='" + Request.QueryString["centreID"] + "'");     
    
        dr = dt.Select("Center_Code='" + Session["centre_code"].ToString() + "'");
         
        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt1.Rows)
            {
                
                return dtrow["SDMS_CenterID"].ToString();
            }
        }
        return "";



    }
    protected string gettrainerID()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("centre_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        // dr = dt.Select("Center_Code='" + Request.QueryString["centreID"] + "'");

         dr = dt.Select("Center_Code='" + Session["centre_code"].ToString() + "'");

        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt1.Rows)
            {
                return dtrow["TrainerID"].ToString();
            }
        }
        return "";



    }
    protected string getstate()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("centre_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        // dr = dt.Select("Center_Code='" + Request.QueryString["centreID"] + "'");

          dr = dt.Select("Center_Code='" + Session["centre_code"].ToString() + "'");

        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt1.Rows)
            {

                return dtrow["TCState"].ToString();
            }
        }
        return "";



    }
    protected string getdistrict()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("centre_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        //  dr = dt.Select("Center_Code='" + Request.QueryString["centreID"] + "'");

         dr = dt.Select("Center_Code='" + Session["centre_code"].ToString() + "'");

        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt1.Rows)
            {

                return dtrow["TCDistrict"].ToString();
            }
        }
        return "";



    }
    protected DataTable getcourse_details(string courseid)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("course_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        // dr = dt.Select("ERPcourse_id='" + courseid + "'");

        dr = dt.Select("ERPcourse_id='" + Session["centre_code"].ToString() + "'");

        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            return dt1;
        }
        return dt1;



    }
    protected string getcourse_name(string nsdc_courseid)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();

        string filepath = Server.MapPath("course_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        //  dr = dt.Select("NSDCCourseid='" + nsdc_courseid + "'");

        dr = dt.Select("NSDCCourseid='" + Session["centre_code"].ToString() + "'");

        dt1 = dr.CopyToDataTable();


        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt1.Rows)
            {

                return dtrow["coursename"].ToString();
            }
        }
        return "";



    }
    protected void ddl_trainerid_fill()
    {   int i=0;
        ddl_trainerid.Items.Insert(i, new ListItem("select", ""));
     
        string trainerids = gettrainerID();
        string[] trainerid = trainerids.Split(',');
        foreach (var t in trainerid)
        {
            i++;
            ddl_trainerid.Items.Insert(i, new ListItem(t, t));
        }
    }
    protected void default_data()
    {
        if(txt_pob.Text=="")
        txt_pob.Text = getdistrict();       
        string state = getstate();
        if (state != "")
        {
            ddl_tcstate.ClearSelection();
            ddl_tcstate.Items.FindByText(state).Selected = true;
        }
        string district = getdistrict();
        if (district != "")
            hf_tcdistrict.Value = district;
        if (ddl_disability.SelectedValue == "")
        {
            ddl_disability.ClearSelection();
            ddl_disability.Items.FindByText("NO").Selected = true;
        }
        if (ddl_feepaid.SelectedValue == "")
        {
            ddl_feepaid.ClearSelection();
            ddl_feepaid.Items.FindByText("Self-Paid").Selected = true;
        }
        if (ddl_train_status.SelectedValue == "")
        {
            ddl_train_status.ClearSelection();
            ddl_train_status.Items.FindByText("Enrolled").Selected = true;
        }
        if (ddl_ttechnical.SelectedValue == "")
        {
            ddl_ttechnical.ClearSelection();
            ddl_ttechnical.Items.FindByText("YES").Selected = true;
        }
        if (ddl_tsector.SelectedValue == "")
        {
            ddl_tsector.ClearSelection();
            ddl_tsector.Items.FindByText("Media and Entertainment").Selected = true;
        }
        if (ddl_skills.SelectedValue == "")
        {
            ddl_skills.ClearSelection();
            ddl_skills.Items.FindByText("Training Partner - General").Selected = true;
        }
        if (ddl_ttraining_status.SelectedValue == "")
        {
            ddl_ttraining_status.ClearSelection();
            ddl_ttraining_status.Items.FindByText("Fresher").Selected = true;
        }

    }
    public void fieldfill_insert(string student_id)
    {
        hf_sdmscenterid.Value = getcentreID();       
        txt_enroll.Text = student_id;
        try
        {

            #region personal information
            txt_first_name.Text = nsdc.DataAccess.ExecuteScalar_str("select enq_personal_name from adm_personalparticulars where student_id='" + student_id + "'");
            string query = "select i.gender,i.enq_permanant_address,i.enq_permanant_district,i.enq_permanant_city,i.enq_permanant_state,i.enq_permanant_pincode,i.enq_personal_dob,i.enq_personal_mobile,i.enq_personal_email from img_enquiryform i inner join adm_personalparticulars ap on i.enq_number=ap.enq_number  where ap.enq_personal_name='" + txt_first_name.Text + "'";
            DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string gender = dt.Rows[0]["gender"].ToString();
                if (gender != "")
                {
                    ddl_gender.ClearSelection();
                    if (gender == "Male")
                        gender = "M";
                    else if (gender == "Female")
                        gender = "F";
                    else if (gender == "Transgender")
                        gender = "T";
                    ddl_gender.Items.FindByValue(gender).Selected = true;

                }
                string dob = dt.Rows[0]["enq_personal_dob"].ToString();
                string[] arr_dob = dob.Split('/');
                string[] year = arr_dob[2].Split(' ');
                txt_dob.Text = arr_dob[0] + "/" + arr_dob[1] + "/" + year[0];
                txt_taddress.Text = dt.Rows[0]["enq_permanant_address"].ToString() + "," + dt.Rows[0]["enq_permanant_district"].ToString();
                if (dt.Rows[0]["enq_permanant_district"].ToString() != dt.Rows[0]["enq_permanant_city"].ToString())
                    txt_taddress.Text += "," + dt.Rows[0]["enq_permanant_city"].ToString();
                txt_taddress.Text += "," + dt.Rows[0]["enq_permanant_state"].ToString();
                if (dt.Rows[0]["enq_permanant_pincode"].ToString() != "")
                    txt_taddress.Text += "-" + dt.Rows[0]["enq_permanant_pincode"].ToString();

                txt_tpincode.Text = dt.Rows[0]["enq_permanant_pincode"].ToString();
                txt_tmobileno.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
                txt_temail.Text = dt.Rows[0]["enq_personal_email"].ToString();

            }

            #endregion

            #region course details
            DataTable dt1 = nsdc.DataAccess.ExecuteDataTable("select courseId,courseFees,dateIns from erp_invoiceDetails where studentId='" + student_id + "'");
            //lbl_courseid.Text = dt1.Rows[0]["courseId"].ToString();
            if (dt1.Rows.Count > 0)
            {
                DataTable dt_course = getcourse_details(dt1.Rows[0]["courseId"].ToString());
                if (dt_course.Rows.Count > 0)
                {
                    lbl_courseid.Text = dt_course.Rows[0]["NSDCCourseid"].ToString();
                    txt_coursename.Text = dt_course.Rows[0]["coursename"].ToString();
                }
                txt_coursefee.Text = dt1.Rows[0]["courseFees"].ToString();
                string doj = dt1.Rows[0]["dateIns"].ToString();
                string[] arr_doj = doj.Split('/');
                string[] year1 = arr_doj[2].Split(' ');
                txt_joindate.Text = arr_doj[0] + "/" + arr_doj[1] + "/" + year1[0];
                //txt_coursename.Text = nsdc.DataAccess.ExecuteScalar_str("select coursename from img_coursedetails where course_id='" + lbl_courseid.Text + "'");
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }


    }
    protected void fieldfill_edit(string student_id)
    {
        try
        {
            string query = "select nsdc_regno,proposal_no,sdms_enrolno,centerID,enrollment_no,salutation,first_name,last_name,guardian_type,date_birth,place_birth,firstname_guardian,lastname_guardian,mother_name,aadhar_enrollno,aadhar_no,ration_cardno,grade,gender,caste,disability,religion,trainee_address,tc_state,tc_district,tc_pincode,trainee_mobile,trainee_type_mobile,trainee_emailid,pretraining_status,experience_year,experience_month,education_level,technical_education,sector_covered,courseID,course_fee,trainerID,fee_paidby,batch_start_date,batch_end_date,training_status,data_month,data_year,attendance,passedout_date,certified,";
            query += "certification_date,certificate_name,certificate_no,assesment_date,agency,assessor,certifying_Agency,placement_status,employment_type,apprenticeship,undertaking_selfemployed,proof_upskill,proof_type,joining_date,employer_name,employer_person_designation,employer_person_name,employer_contactno,employer_state,employer_district,employer_freq_feedback,employer_feedback,work_state,work_district,CTC_before_training,current_CTC,skilling_category ,poverty_line,passport_no,annual_income,passport_validity,fund_source,bank_name,ifsc_code,bank_account_no,bank_branch_name from NSDC_registration_details  where enrollment_no='" + student_id + "'   ";
            DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
            if (dt.Rows.Count > 0)
            {
                hf_sdmscenterid.Value = dt.Rows[0]["centerID"].ToString();
                txt_enroll.Text = dt.Rows[0]["enrollment_no"].ToString();
                string salutation = dt.Rows[0]["salutation"].ToString().Replace(" ", "");
                if (salutation != "")
                {
                    ddl_salutation.ClearSelection();
                    ddl_salutation.Items.FindByText(salutation).Selected = true;
                }
                txt_first_name.Text = dt.Rows[0]["first_name"].ToString();
                txt_last_name.Text = dt.Rows[0]["last_name"].ToString();
                if (dt.Rows[0]["gender"].ToString() != "")
                {
                    ddl_gender.ClearSelection();
                    ddl_gender.Items.FindByValue(dt.Rows[0]["gender"].ToString()).Selected = true;
                }
                txt_dob.Text = dt.Rows[0]["date_birth"].ToString();
                txt_pob.Text = dt.Rows[0]["place_birth"].ToString();
                if (dt.Rows[0]["guardian_type"].ToString() != "")
                {
                    ddl_guardian.ClearSelection();
                    ddl_guardian.Items.FindByText(dt.Rows[0]["guardian_type"].ToString()).Selected = true;
                }
                txt_fguardian.Text = dt.Rows[0]["firstname_guardian"].ToString();
                txt_lguardian.Text = dt.Rows[0]["lastname_guardian"].ToString();
                txt_mother.Text = dt.Rows[0]["mother_name"].ToString();
                if (dt.Rows[0]["caste"].ToString() != "")
                {
                    ddlcaste.ClearSelection();
                    ddlcaste.Items.FindByText(dt.Rows[0]["caste"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["religion"].ToString() != "")
                {
                    ddlreligion.ClearSelection();
                    ddlreligion.Items.FindByText(dt.Rows[0]["religion"].ToString()).Selected = true;
                }
                txt_aadhar_en.Text = dt.Rows[0]["aadhar_enrollno"].ToString();
                txt_aadhar_no.Text = dt.Rows[0]["aadhar_no"].ToString();
                txt_ration.Text = dt.Rows[0]["ration_cardno"].ToString();
                if (dt.Rows[0]["disability"].ToString() != "")
                {
                    ddl_disability.ClearSelection();
                    ddl_disability.Items.FindByText(dt.Rows[0]["disability"].ToString()).Selected = true;
                }
                txt_taddress.Text = dt.Rows[0]["trainee_address"].ToString();
                if (dt.Rows[0]["tc_state"].ToString() != "")
                {
                    ddl_tcstate.ClearSelection();
                    ddl_tcstate.Items.FindByText(dt.Rows[0]["tc_state"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["tc_district"].ToString() != "")
                    hf_tcdistrict.Value = dt.Rows[0]["tc_district"].ToString();
                txt_tpincode.Text = dt.Rows[0]["tc_pincode"].ToString();
                txt_tmobileno.Text = dt.Rows[0]["trainee_mobile"].ToString();
                if (dt.Rows[0]["trainee_type_mobile"].ToString() != "")
                {
                    ddl_tmobile.ClearSelection();
                    ddl_tmobile.Items.FindByText(dt.Rows[0]["trainee_type_mobile"].ToString()).Selected = true;
                }
                txt_temail.Text = dt.Rows[0]["trainee_emailid"].ToString();
                if (dt.Rows[0]["pretraining_status"].ToString() != "")
                {
                    ddl_ttraining_status.ClearSelection();
                    ddl_ttraining_status.Items.FindByText(dt.Rows[0]["pretraining_status"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["experience_year"].ToString() != "")
                {
                    ddl_texp_year.ClearSelection();
                    ddl_texp_year.Items.FindByText(dt.Rows[0]["experience_year"].ToString()).Selected = true;

                }
                if (dt.Rows[0]["experience_month"].ToString() != "")
                {
                    ddl_texp_month.ClearSelection();
                    ddl_texp_month.Items.FindByText(dt.Rows[0]["experience_month"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["education_level"].ToString() != "")
                {
                    ddl_teducation.ClearSelection();
                    ddl_teducation.Items.FindByText(dt.Rows[0]["education_level"].ToString()).Selected = true;

                }
                if (dt.Rows[0]["technical_education"].ToString() != "")
                {
                    ddl_ttechnical.ClearSelection();
                    ddl_ttechnical.Items.FindByText(dt.Rows[0]["technical_education"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["sector_covered"].ToString() != "")
                    ddl_tsector.Items.FindByText(dt.Rows[0]["sector_covered"].ToString()).Selected = true;
                lbl_courseid.Text = dt.Rows[0]["courseID"].ToString();
                //txt_coursename.Text = nsdc.DataAccess.ExecuteScalar_str("select coursename from img_coursedetails where course_id='" + lbl_courseid.Text + "'");
                txt_coursename.Text = getcourse_name(lbl_courseid.Text);

                txt_coursefee.Text = dt.Rows[0]["course_fee"].ToString();
                if (dt.Rows[0]["trainerID"].ToString() != "")
                    ddl_trainerid.Items.FindByText(dt.Rows[0]["trainerID"].ToString()).Selected = true;


                if (dt.Rows[0]["fee_paidby"].ToString() != "")
                    ddl_feepaid.Items.FindByText(dt.Rows[0]["fee_paidby"].ToString()).Selected = true;
                txt_batch_start.Text = dt.Rows[0]["batch_start_date"].ToString();
                txt_batch_end.Text = dt.Rows[0]["batch_end_date"].ToString();

                if (dt.Rows[0]["training_status"].ToString() != "")
                    ddl_train_status.Items.FindByText(dt.Rows[0]["training_status"].ToString()).Selected = true;
                if (dt.Rows[0]["data_year"].ToString() != "")
                {
                    ddl_data_year.ClearSelection();
                    ddl_data_year.Items.FindByText(dt.Rows[0]["data_year"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["data_month"].ToString() != "")
                {
                    ddl_data_month.ClearSelection();
                    ddl_data_month.Items.FindByText(dt.Rows[0]["data_month"].ToString()).Selected = true;
                }
                txt_attendance.Text = dt.Rows[0]["attendance"].ToString();
                txt_passedout.Text = dt.Rows[0]["passedout_date"].ToString();
                if (dt.Rows[0]["grade"].ToString() != "")
                    ddl_grade.Items.FindByText(dt.Rows[0]["grade"].ToString()).Selected = true;
                if (dt.Rows[0]["certified"].ToString() != "")
                    ddl_certified.Items.FindByText(dt.Rows[0]["certified"].ToString()).Selected = true;
                txt_certfn_date.Text = dt.Rows[0]["certification_date"].ToString();
                txt_certfn_name.Text = dt.Rows[0]["certificate_name"].ToString();
                txt_certfn_no.Text = dt.Rows[0]["certificate_no"].ToString();
                txt_assesmnt_date.Text = dt.Rows[0]["assesment_date"].ToString();
                txt_agency.Text = dt.Rows[0]["agency"].ToString();
                txt_Assessor.Text = dt.Rows[0]["assessor"].ToString();
                txt_certfn_agency.Text = dt.Rows[0]["certifying_agency"].ToString();
                int difference = day_difference(txt_batch_end.Text);
                if (difference < 1)
                {
                    placement.Visible = false;
                }
                else
                {
                    placement.Visible = true;
                    if (dt.Rows[0]["placement_status"].ToString() != "")
                        ddl_place_status.Items.FindByText(dt.Rows[0]["placement_status"].ToString()).Selected = true;
                    if (dt.Rows[0]["employment_type"].ToString() != "")
                        ddl_emplymnt_type.Items.FindByText(dt.Rows[0]["employment_type"].ToString()).Selected = true;
                    if (dt.Rows[0]["apprenticeship"].ToString() != "")
                        ddl_Apprenticeship.Items.FindByText(dt.Rows[0]["apprenticeship"].ToString()).Selected = true;
                    if (dt.Rows[0]["proof_upskill"].ToString() != "")
                        ddl_upskill.Items.FindByText(dt.Rows[0]["proof_upskill"].ToString()).Selected = true;
                    if (dt.Rows[0]["proof_type"].ToString() != "")
                        ddl_proof.Items.FindByText(dt.Rows[0]["proof_type"].ToString()).Selected = true;
                    txt_joindate.Text = dt.Rows[0]["joining_date"].ToString();
                    txt_empname.Text = dt.Rows[0]["employer_name"].ToString();
                    txt_empcontact_name.Text = dt.Rows[0]["employer_person_name"].ToString();
                    txt_empcontact_desgtn.Text = dt.Rows[0]["employer_person_designation"].ToString();
                    txt_empcontact_no.Text = dt.Rows[0]["employer_contactno"].ToString();
                    if (dt.Rows[0]["employer_state"].ToString() != "")
                    {
                        ddl_emploc_state.Items.FindByText(dt.Rows[0]["employer_state"].ToString()).Selected = true;
                    }
                    if (dt.Rows[0]["employer_district"].ToString() != "")
                        hf_emploc_district.Value = dt.Rows[0]["employer_district"].ToString();
                    if (dt.Rows[0]["employer_feedback"].ToString() != "")
                        ddl_feedback.Items.FindByText(dt.Rows[0]["employer_feedback"].ToString()).Selected = true;
                    if (dt.Rows[0]["employer_freq_feedback"].ToString() != "")
                        ddl_freq_feedback.Items.FindByText(dt.Rows[0]["employer_freq_feedback"].ToString()).Selected = true;
                    if (dt.Rows[0]["work_state"].ToString() != "")
                    {
                        ddl_work_state.Items.FindByText(dt.Rows[0]["work_state"].ToString()).Selected = true;
                    }
                    if (dt.Rows[0]["work_district"].ToString() != "")
                        hf_work_district.Value = dt.Rows[0]["work_district"].ToString();
                    txt_earning_b4.Text = dt.Rows[0]["CTC_before_training"].ToString();
                    txt_earning_after.Text = dt.Rows[0]["current_CTC"].ToString();
                    if (dt.Rows[0]["undertaking_selfemployed"].ToString() != "")
                        ddl_undertaking.Items.FindByText(dt.Rows[0]["undertaking_selfemployed"].ToString()).Selected = true;
                }
                if (dt.Rows[0]["poverty_line"].ToString() != "")
                    ddl_poverty.Items.FindByText(dt.Rows[0]["poverty_line"].ToString()).Selected = true;
                if (dt.Rows[0]["annual_income"].ToString() != "")
                    ddl_annual_income.Items.FindByText(dt.Rows[0]["annual_income"].ToString()).Selected = true;
                txt_passport.Text = dt.Rows[0]["passport_no"].ToString();
                txt_pport_val.Text = dt.Rows[0]["passport_validity"].ToString();
                if (dt.Rows[0]["skilling_category"].ToString() != "")
                    ddl_skills.Items.FindByText(dt.Rows[0]["skilling_category"].ToString()).Selected = true;
                if (dt.Rows[0]["fund_source"].ToString() != "")
                    ddl_fund_source.Items.FindByText(dt.Rows[0]["fund_source"].ToString()).Selected = true;
                txt_bank_name.Text = dt.Rows[0]["bank_name"].ToString();
                txt_bank_branchadd.Text = dt.Rows[0]["bank_branch_name"].ToString();
                txt_ifsc.Text = dt.Rows[0]["ifsc_code"].ToString();
                txt_accno.Text = dt.Rows[0]["bank_account_no"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }


    }
    protected int day_difference(string batch_end)
    {
        string[] end_date = batch_end.Split('/');
        DateTime endDate = new DateTime(Convert.ToInt32(end_date[2]), Convert.ToInt32(end_date[0]), Convert.ToInt32(end_date[1]));
        DateTime today = DateTime.Today;
        double diff = (today - endDate).TotalDays;
        return Convert.ToInt32(diff);
    }
    protected void state_fill()
    {
        string filePath = Server.MapPath("nsdc.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(filePath);
        ddl_tcstate.DataSource = ds;
        ddl_tcstate.DataTextField = "States";
        ddl_tcstate.DataBind();
        ddl_tcstate.Items.Insert(0, new ListItem("Select", ""));
        ddl_emploc_state.DataSource = ds;
        ddl_emploc_state.DataTextField = "States";
        ddl_emploc_state.DataBind();
        ddl_emploc_state.Items.Insert(0, new ListItem("Select", ""));
        ddl_work_state.DataSource = ds;
        ddl_work_state.DataTextField = "States";
        ddl_work_state.DataBind();
        ddl_work_state.Items.Insert(0, new ListItem("Select", ""));

    }



    protected void ddl_texperiencefill()
    {
        for (int i = 42; i >= 0; i--)
            ddl_texp_year.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        ddl_texp_year.Items.Insert(0, new ListItem("Select", ""));
        for (int i = 11; i >= 0; i--)
            ddl_texp_month.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        ddl_texp_month.Items.Insert(0, new ListItem("Select", ""));

    }
    protected void ddl_tsectorfill()
    {
        string filePath = Server.MapPath("nsdc.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(filePath);
        ds.Tables[0].DefaultView.RowFilter = "Sector_Covered <>''";
        ddl_tsector.DataSource = ds.Tables[0];
        ddl_tsector.DataTextField = "Sector_Covered";
        ddl_tsector.DataBind();
        ddl_tsector.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void ddl_skillsfill()
    {
        string filePath = Server.MapPath("nsdc.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(filePath);
        ds.Tables[0].DefaultView.RowFilter = "Skilling_Category <>''";
        ddl_skills.DataSource = ds.Tables[0];
        ddl_skills.DataTextField = "Skilling_Category";
        ddl_skills.DataBind();
        ddl_skills.Items.Insert(0, new ListItem("Select", ""));

    }
    protected void ddl_data_yearfill()
    {
        string fin_year="";
        ddl_data_year.Items.Insert(0, new ListItem("Select", ""));
        int curr_year = DateTime.Now.Year;
        int pre_year = curr_year - 1;
        for (int i = 1; i < 11; i++)
        {
            ddl_data_year.Items.Insert(i, new ListItem(pre_year + "-" + curr_year, pre_year + "-" + curr_year));
            pre_year++;
            curr_year++;
        }
        int curr_month = DateTime.Now.Month;       
        curr_year = DateTime.Now.Year;
        pre_year = curr_year - 1;
        if (curr_month >= 4)//april
            fin_year = curr_year + "-" + ++curr_year;
        else
            fin_year = pre_year + "-" + curr_year;
        ddl_data_year.Items.FindByText(fin_year).Selected = true;
        ddl_data_month.ClearSelection();
        ddl_data_month.Items.FindByValue((--curr_month).ToString()).Selected = true;
    }

    [WebMethod]
    public static data1[] BindDatatoDropdown(data1 data1)
    {

        List<data1> details = new List<data1>();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();
        //Here i load all xml data in to dataset
        string filepath = HttpContext.Current.Server.MapPath("States_district_list.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        //Filter here 
        dr = dt.Select("States='" + data1.state + "'");
        dt1 = dr.CopyToDataTable();
        foreach (DataRow dtrow in dt1.Rows)
        {
            data1 _data = new data1();
            _data.district = dtrow["Districts"].ToString();
            details.Add(_data);
        }

        return details.ToArray();
    }
    [WebMethod]
    public static string create_cmnd(data1 data)
    {
        string result;
        string query = "[gd_candidates1]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", data.pageindex);
        cmd.Parameters.AddWithValue("@PageSize", data.pagesize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        result = GetData(cmd, data.pageindex, data.pagesize).GetXml();
        return result;


    }

    private static DataSet GetData(SqlCommand cmd, string pageIndex, string pageSize)
    {
        string strConnString = nsdc.DataAccess.ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "enquiry");
                    DataTable dt = new DataTable("Pager");
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = pageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    ds.Tables.Add(dt);
                    return ds;
                }
            }
        }
    }


    public class data1
    {
        public string state { get; set; }
        public string district { get; set; }
        public string pageindex { get; set; }
        public string pagesize { get; set; }

    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txt_first_name.Text == "" || txt_last_name.Text == "" || txt_fguardian.Text == "" || txt_lguardian.Text == "" || ddl_gender.SelectedValue == "" || txt_tpincode.Text == "" || txt_tmobileno.Text == "" || ddl_ttraining_status.SelectedValue == "" || ddl_teducation.SelectedValue == "" || ddl_tsector.SelectedValue == "" ||txt_coursefee.Text == "" || ddl_trainerid.SelectedValue == "" || ddl_feepaid.SelectedValue == "" || ddl_train_status.SelectedValue == "" || ddl_skills.SelectedValue == "")
            ScriptManager.RegisterStartupScript(this, typeof(string), "isActive", "null_alert();", true);

        else if (Request.QueryString["id"] == "edit")
        {

            int result = add_parameters_edit();
            if (result == -1)
                Response.Redirect("NSDC_candidatelist.aspx?centreID=" + Request.QueryString["centreID"]);
        }

        else if (Request.QueryString["id"] == "insert")
        {
           string result = add_parameters_insert();
            if (result == "101")
            {
                Response.Redirect("imageNSDC.aspx?centreID=" + Request.QueryString["centreID"]);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "System" + DateTime.Now.ToString("hhmmss"), "$(document).ready(function () {alert('Traniee contact number already exsit!')});", true);

                //Response.Write(result.ToString());
            }
           // int result = add_parameters_insert();
            //if (result == -1)
              //  Response.Redirect("imageNSDC.aspx?centreID=" + Request.QueryString["centreID"]);
        
        }
    }
    protected string add_parameters_insert()
    {
        
        //int result;  
 
       // return result = nsdc.DataAccess.ExecuteNonQuery(cmd);
        string result;
        SqlCommand cmd = new SqlCommand("[NSDC_registration_insert]");
        cmd.CommandType = CommandType.StoredProcedure;
        parameters(cmd);
        nsdc.DataAccess.ExecuteNonQuery(cmd);
        return result = (string)cmd.Parameters["@retval"].Value;

    }

    protected int add_parameters_edit()
    {
        int result;
        SqlCommand cmd = new SqlCommand("[NSDC_registration_edit]");
        cmd.CommandType = CommandType.StoredProcedure;
        parameters(cmd);
        return result = nsdc.DataAccess.ExecuteNonQuery(cmd);

    }
    protected void parameters(SqlCommand cmd)
    {

        try
        {

            cmd.Parameters.AddWithValue("@nsdc_regno", "NSDC-REGNo-7786");
            cmd.Parameters.AddWithValue("@proposal_no", "18R/2013-14/24");
            cmd.Parameters.AddWithValue("@sdms_enrolno", "");           
            cmd.Parameters.AddWithValue("@centerID",hf_sdmscenterid.Value);
            cmd.Parameters.AddWithValue("@enrollment_no", txt_enroll.Text);

            string a = ddl_salutation.SelectedItem.Text;
            if (a.ToLower() == "select")
            {
                a = "";
            }
            cmd.Parameters.AddWithValue("@salutation", a);
            cmd.Parameters.AddWithValue("@first_name", txt_first_name.Text);
            cmd.Parameters.AddWithValue("@last_name", txt_last_name.Text);

            string b = ddl_guardian.SelectedItem.Text;
            if (b.ToLower() == "select")
            {
                b = "";
            }
            cmd.Parameters.AddWithValue("@guardian_type", b);
            cmd.Parameters.AddWithValue("@date_birth", hf_dob.Value);
            cmd.Parameters.AddWithValue("@place_birth", txt_pob.Text);
            cmd.Parameters.AddWithValue("@firstname_guardian", txt_fguardian.Text);
            cmd.Parameters.AddWithValue("@lastname_guardian", txt_lguardian.Text);
            cmd.Parameters.AddWithValue("@mother_name", txt_mother.Text);
            cmd.Parameters.AddWithValue("@aadhar_enrollno", txt_aadhar_en.Text);
            cmd.Parameters.AddWithValue("@aadhar_no", txt_aadhar_no.Text);
            cmd.Parameters.AddWithValue("@ration_cardno", txt_ration.Text);


           /* string c = ddl_gender.SelectedItem.Text;
            if (c.ToLower() == "select")
            {
                c = "";
            }*/
            cmd.Parameters.AddWithValue("@gender",ddl_gender.SelectedValue);


           // cmd.Parameters.AddWithValue("@gender", c);

            string d = ddlcaste.SelectedItem.Text;
            if (d.ToLower() == "select")
            {
                d = "";
            }

            cmd.Parameters.AddWithValue("@caste", d);
            string e = ddl_disability.SelectedItem.Text;
            if (e.ToLower() == "select")
            {
                e = "";
            }


            cmd.Parameters.AddWithValue("@disability", e);

            string f = ddlreligion.SelectedItem.Text;
            if (f.ToLower() == "select")
            {
                f = "";
            }
            cmd.Parameters.AddWithValue("@religion", f);
            cmd.Parameters.AddWithValue("@trainee_address", txt_taddress.Text);

            string g = ddl_tcstate.SelectedItem.Text;
            if (g.ToLower() == "select")
            {
                g = "";
            }


            cmd.Parameters.AddWithValue("@tc_state", g);
            cmd.Parameters.AddWithValue("@tc_district", hf_tcdistrict.Value);
            cmd.Parameters.AddWithValue("@tc_pincode", txt_tpincode.Text);
            cmd.Parameters.AddWithValue("@trainee_mobile", txt_tmobileno.Text);
            string h = ddl_tmobile.SelectedItem.Text;
            if (h.ToLower() == "select")
            {
                h = "";
            }



            cmd.Parameters.AddWithValue("@trainee_type_mobile", h);
            cmd.Parameters.AddWithValue("@trainee_emailid", txt_temail.Text);



            string t = ddl_ttraining_status.SelectedItem.Text;
            if (t.ToLower() == "select")
            {
                t = "";
            }


            cmd.Parameters.AddWithValue("@pretraining_status", t);
            string u = ddl_texp_year.SelectedItem.Text;
            if (u.ToLower() == "select")
            {
                u = "";
            }


            cmd.Parameters.AddWithValue("@experience_year", u);
            string v = ddl_texp_month.SelectedItem.Text;
            if (v.ToLower() == "select")
            {
                v = "";
            }


            cmd.Parameters.AddWithValue("@experience_month", v);




            string x = ddl_teducation.SelectedItem.Text;
            if (x.ToLower() == "select")
            {
                x = "";
            }


            cmd.Parameters.AddWithValue("@education_level", x);
            cmd.Parameters.AddWithValue("@technical_education", ddl_ttechnical.SelectedItem.Text);

            string w = ddl_tsector.SelectedItem.Text;
            if (w.ToLower() == "select")
            {
                w = "";
            }
            cmd.Parameters.AddWithValue("@sector_covered", w);            
            cmd.Parameters.AddWithValue("@courseID", lbl_courseid.Text);           
            cmd.Parameters.AddWithValue("@course_fee", txt_coursefee.Text);

            string w1 = ddl_trainerid.SelectedItem.Text;
            if (w1.ToLower() == "select")
            {
                w1 = "";
            }


            cmd.Parameters.AddWithValue("@trainerID", w1);
         
            string p = ddl_feepaid.SelectedItem.Text;
            if (p.ToLower() == "select")
            {
                p = "";
            }

            cmd.Parameters.AddWithValue("@fee_paidby", p);
            cmd.Parameters.AddWithValue("@batch_start_date", hf_bstart.Value);
            cmd.Parameters.AddWithValue("@batch_end_date", hf_bend.Value);
            cmd.Parameters.AddWithValue("@training_status", ddl_train_status.SelectedItem.Text);

            string i = ddl_data_month.SelectedItem.Text;
            if (i.ToLower() == "select")
            {
                i = "";
            }

            cmd.Parameters.AddWithValue("@data_month", i);
            string j = ddl_data_year.SelectedItem.Text;
            if (j.ToLower() == "select")
            {
                j = "";
            }

            cmd.Parameters.AddWithValue("@data_year", j);
            cmd.Parameters.AddWithValue("@attendance", txt_attendance.Text);
            cmd.Parameters.AddWithValue("@passedout_date", hf_passed.Value);

            string aa = ddl_grade.SelectedItem.Text;
            if (aa.ToLower() == "select")
            {
                aa = "";
            }

            cmd.Parameters.AddWithValue("@grade", aa);
            string bb = ddl_certified.SelectedItem.Text;
            if (bb.ToLower() == "select")
            {
                bb = "";
            }
            cmd.Parameters.AddWithValue("@certified", bb);
            cmd.Parameters.AddWithValue("@certification_date", hf_certification.Value);
            cmd.Parameters.AddWithValue("@certificate_name", txt_certfn_name.Text);
            cmd.Parameters.AddWithValue("@certificate_no", txt_certfn_no.Text);
            cmd.Parameters.AddWithValue("@assesment_date", hf_assesment.Value);
            cmd.Parameters.AddWithValue("@agency", txt_agency.Text);
            cmd.Parameters.AddWithValue("@assessor", txt_Assessor.Text);
            cmd.Parameters.AddWithValue("@certifying_agency", txt_certfn_agency.Text);
            string cc = ddl_place_status.SelectedItem.Text;
            if (cc.ToLower() == "select")
            {
                cc = "";
            }
            cmd.Parameters.AddWithValue("@placement_status", cc);
            string dd = ddl_emplymnt_type.SelectedItem.Text;
            if (dd.ToLower() == "select")
            {
                dd = "";
            }
            cmd.Parameters.AddWithValue("@employment_type", dd);
            string ee = ddl_Apprenticeship.SelectedItem.Text;
            if (ee.ToLower() == "select")
            {
                ee = "";
            }

            cmd.Parameters.AddWithValue("@apprenticeship", ee);
            string ff = ddl_undertaking.SelectedItem.Text;
            if (ff.ToLower() == "select")
            {
                ff = "";
            }
            cmd.Parameters.AddWithValue("@undertaking_selfemployed", ff);
            string gg = ddl_upskill.SelectedItem.Text;
            if (gg.ToLower() == "select")
            {
                gg = "";
            }
            cmd.Parameters.AddWithValue("@proof_upskill", gg);
            string hh = ddl_proof.SelectedItem.Text;
            if (hh.ToLower() == "select")
            {
                hh = "";
            }
            cmd.Parameters.AddWithValue("@proof_type", hh);
            cmd.Parameters.AddWithValue("@joining_date", hf_joindate.Value);
            cmd.Parameters.AddWithValue("@employer_name", txt_empname.Text);
            cmd.Parameters.AddWithValue("@employer_person_name", txt_empcontact_name.Text);
            cmd.Parameters.AddWithValue("@employer_person_designation", txt_empcontact_desgtn.Text);
            cmd.Parameters.AddWithValue("@employer_contactno", txt_empcontact_no.Text);

            string ii = ddl_emploc_state.SelectedItem.Text;
            if (ii.ToLower() == "select")
            {
                ii = "";
            }


            cmd.Parameters.AddWithValue("@employer_state", ii);
            cmd.Parameters.AddWithValue("@employer_district", hf_emploc_district.Value);

            string jj = ddl_feedback.SelectedItem.Text;
            if (jj.ToLower() == "select")
            {
                jj = "";
            }



            cmd.Parameters.AddWithValue("@employer_feedback", jj);
            string kk = ddl_freq_feedback.SelectedItem.Text;
            if (kk.ToLower() == "select")
            {
                kk = "";
            }

            cmd.Parameters.AddWithValue("@employer_freq_feedback", kk);
            string ll = ddl_work_state.SelectedItem.Text;
            if (ll.ToLower() == "select")
            {
                ll = "";
            }

            cmd.Parameters.AddWithValue("@work_state", ll);
            cmd.Parameters.AddWithValue("@work_district", hf_work_district.Value);
            cmd.Parameters.AddWithValue("@CTC_before_training", txt_earning_b4.Text);
            cmd.Parameters.AddWithValue("@current_CTC", txt_earning_after.Text);
            cmd.Parameters.AddWithValue("@poverty_line", ddl_poverty.SelectedValue);
            cmd.Parameters.AddWithValue("@annual_income", ddl_annual_income.SelectedValue);
            cmd.Parameters.AddWithValue("@passport_no", txt_passport.Text);
            cmd.Parameters.AddWithValue("@passport_validity", hf_pvalidity.Value);
            cmd.Parameters.AddWithValue("@skilling_category", ddl_skills.SelectedValue);
            cmd.Parameters.AddWithValue("@fund_source", ddl_fund_source.SelectedValue);
            cmd.Parameters.AddWithValue("@bank_name", txt_bank_name.Text);
            cmd.Parameters.AddWithValue("@bank_branch_name", txt_bank_branchadd.Text);
            cmd.Parameters.AddWithValue("@ifsc_code", txt_ifsc.Text);
            cmd.Parameters.AddWithValue("@bank_account_no", txt_accno.Text);
            cmd.Parameters.Add("@retval", SqlDbType.VarChar, 50);
            cmd.Parameters["@retval"].Direction = ParameterDirection.Output;
  
            
        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
    }

   
}
