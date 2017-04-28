using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class NSDC_candidatelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["centreID"] == "")
            Response.Redirect("NSDC.aspx");
        else
        {
            // Session["Centrerole"] = "others";
           //Session["Centrerole"] = "SuperAdmin";
             if (!IsPostBack)
            {
                gridfill();
                ddl_coursefill();
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CEdit")
        {
            Response.Redirect("NSDC_registration.aspx?id=edit&student_id=" + e.CommandArgument.ToString() + "&centreID=" + hf_centreID.Value);

        }
        else if (e.CommandName == "CEdit_name")
        {
            Response.Redirect("NSDC_registration.aspx?id=edit&student_id=" + e.CommandArgument.ToString() + "&centreID=" + hf_centreID.Value);

        }
       
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
        dr = dt.Select("NSDCCourseid='" + nsdc_courseid + "'");          
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
    protected void GridView1_DataBound(object sender,GridViewRowEventArgs e)
    {
        Label coursename = (e.Row.FindControl("lbl_course") as Label);
        Label placement = (e.Row.FindControl("lbl_placement") as Label);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string courseid = coursename.Text;
          //  coursename.Text = nsdc.DataAccess.ExecuteScalar_str("select coursename from img_coursedetails where course_id='" + courseid + "'");
            coursename.Text = getcourse_name(courseid);
            if (placement.Text == "")
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    tc.Style.Add("color", "red");
                    tc.Style.Add("border-color", "#000000");

                }
            }
            else
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    tc.Style.Add("color", "green");
                    tc.Style.Add("border-color", "#000000");
                } 
            }

        }
       
    }
    protected string getcentreID()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataRow[] dr;
        DataTable dt1 = new DataTable();
        //Here i load all xml data in to dataset
        string filepath = Server.MapPath("centre_details.xml");
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        //Filter here 
        dr = dt.Select("Center_Code='" + Request.QueryString["centreID"] + "'");
      //  dr = dt.Select("Center_Code='" + Session["centre_code"].ToString() + "'");   
        dt1 = dr.CopyToDataTable();
        foreach (DataRow dtrow in dt1.Rows)
        {
            
            return dtrow["SDMS_CenterID"].ToString();
        }
        return "";



    }
    protected void gridfill()
    {//  string centreID = Request.QueryString["centreID"];
    string centreID = Session["centre_code"].ToString();   
      
        hf_centreID.Value = centreID;
        string query = "select nsdc_regno,proposal_no,sdms_enrolno,centerID,enrollment_no,salutation,first_name,last_name,guardian_type,date_birth,place_birth,firstname_guardian,lastname_guardian,mother_name,aadhar_enrollno,aadhar_no,ration_cardno,grade,gender,caste,disability,religion,trainee_address,tc_state,tc_district,tc_pincode,trainee_mobile,trainee_type_mobile,trainee_emailid,pretraining_status,experience_year,experience_month,education_level,technical_education,sector_covered,courseID,course_fee,trainerID,fee_paidby,batch_start_date,batch_end_date,training_status,data_month,data_year,attendance,passedout_date,certified,";
        query += "certification_date,certificate_name,certificate_no,assesment_date,agency,assessor,certifying_Agency,placement_status,employment_type,apprenticeship,undertaking_selfemployed,proof_upskill,proof_type,joining_date,employer_name,employer_person_designation,employer_person_name,employer_contactno,employer_state,employer_district,employer_freq_feedback,employer_feedback,work_state,work_district,CTC_before_training,current_CTC,skilling_category ,poverty_line,passport_no,annual_income,passport_validity,fund_source,bank_name,ifsc_code,bank_account_no,bank_branch_name from NSDC_registration_details where centerID='" + getcentreID() + "' order by ID desc  ";
        DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataTable dt = getdata();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    }
   protected void ddl_coursefill()
    {
        DataTable dt = nsdc.DataAccess.ExecuteDataTable("select distinct course_id,coursename from  img_coursedetails");
        ddl_course.DataSource = dt;
        ddl_course.DataValueField = "course_id";
        ddl_course.DataTextField = "coursename";
        ddl_course.DataBind();
        ddl_course.Items.Insert(0,new ListItem("select",""));
    }

    protected void btn_search_Click(object sender, EventArgs e)
   {
       DataTable dt = getdata();
    GridView1.DataSource = dt;
    GridView1.DataBind();
        
    }
    protected DataTable getdata()
    {
        string query;
        if (Session["Centrerole"].ToString() == "SuperAdmin")
        {
            query = "select nsdc_regno,proposal_no,sdms_enrolno,centerID,enrollment_no,salutation,first_name,last_name,guardian_type,date_birth,place_birth,firstname_guardian,lastname_guardian,mother_name,aadhar_enrollno,aadhar_no,ration_cardno,grade,gender,caste,disability,religion,trainee_address,tc_state,tc_district,tc_pincode,trainee_mobile,trainee_type_mobile,trainee_emailid,pretraining_status,experience_year,experience_month,education_level,technical_education,sector_covered,courseID,course_fee,trainerID,fee_paidby,batch_start_date,batch_end_date,training_status,data_month,data_year,attendance,passedout_date,certified,";
            query += "certification_date,certificate_name,certificate_no,assesment_date,agency,assessor,certifying_Agency,placement_status,employment_type,apprenticeship,undertaking_selfemployed,proof_upskill,proof_type,joining_date,employer_name,employer_person_designation,employer_person_name,employer_contactno,employer_state,employer_district,employer_freq_feedback,employer_feedback,work_state,work_district,CTC_before_training,current_CTC,skilling_category ,poverty_line,passport_no,annual_income,passport_validity,fund_source,bank_name,ifsc_code,bank_account_no,bank_branch_name from NSDC_registration_details where centerID='" + getcentreID() + "' ";
        }
        else
        {
            query = "select enrollment_no,salutation,first_name,last_name,guardian_type,date_birth,place_birth,firstname_guardian,lastname_guardian,mother_name,aadhar_enrollno,aadhar_no,ration_cardno,grade,gender,caste,disability,religion,trainee_address,tc_state,tc_district,tc_pincode,trainee_mobile,trainee_type_mobile,trainee_emailid,pretraining_status,experience_year,experience_month,education_level,technical_education,sector_covered,courseID,course_fee,trainerID,fee_paidby,batch_start_date,batch_end_date,training_status,data_month,data_year,attendance,passedout_date,certified,";
            query += "certification_date,certificate_name,certificate_no,assesment_date,agency,assessor,certifying_Agency,placement_status,employment_type,apprenticeship,undertaking_selfemployed,proof_upskill,proof_type,joining_date,employer_name,employer_person_designation,employer_person_name,employer_contactno,employer_state,employer_district,employer_freq_feedback,employer_feedback,work_state,work_district,CTC_before_training,current_CTC,skilling_category ,poverty_line,passport_no,annual_income,passport_validity,fund_source,bank_name,ifsc_code,bank_account_no,bank_branch_name from NSDC_registration_details where centerID='" + getcentreID() + "' ";
     
        }
        if (txt_student_name.Text != "")
        {
            query += " and first_name='" + txt_student_name.Text + "'";
        }
         if (txt_enroll_no.Text != "")
        {
            query += " and enrollment_no='" + txt_enroll_no.Text + "'";
           
        }
         if (ddl_course.SelectedItem.Text != "select")
        {

            query += "and courseID='" + ddl_course.SelectedValue + "'";
            
        }
        
        query += "order by ID desc  ";
        DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
        return dt;
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "NSDC.xls"));
        Response.ContentType = "application/ms-excel";
        DataTable dt = getdata();
        string str = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {

                if (dr[j].ToString() == "Male")
                {
                    dr[j] = "M";
                }
                else if (dr[j].ToString() == "Female")
                {
                    dr[j] = "F";
                }
                else if (dr[j].ToString() == "Transgender")
                {
                    dr[j] = "T";
                }
                else
                {
                    dr[j] = dr[j].ToString();
                }
                Response.Write(str + Convert.ToString(dr[j]));
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

    }
}
