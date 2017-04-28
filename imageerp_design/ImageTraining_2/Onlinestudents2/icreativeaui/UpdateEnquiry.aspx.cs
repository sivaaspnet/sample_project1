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

public partial class UpdateEnquiry : System.Web.UI.Page
{
    string _Qry, _Qry1, dob1;

    protected void Page_Load(object sender, EventArgs e)
    {
        


        if (!IsPostBack)
        {

            
            fillcoursedropdown();
            fillcoursedropdown1();
           
        }
        if (!IsPostBack)
        {
            selectfromenquiry();
        }
    }
    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
//_Qry = "Select count(*) from img_enquiryform where enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfname.Text) + "' And enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "' And Centre_Code='" + Session["SA_centre_code"] + "' ";

        //Response.Write(_Qry);
        //Response.End();

        //int enqcount = 1;

       // enqcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (1 == 2)
        {

            lblmsg1.Text = "Student Already Enrolled..!";

        }
        else
        {


            //string dob = txtdob.Text;
            //string[] strSplitArr = dob.Split(' ');
            //dob1 = strSplitArr[0].ToString();

            //string dob2 = dob1;

            //string[] strSplitArr1 = dob2.Split('-');
            //string dday = strSplitArr1[0].ToString();
            //string dmonth = strSplitArr1[1].ToString();
            //string dyear = strSplitArr1[2].ToString();

            //string dobdate = dyear + "-" + dmonth + "-" + dday;

            string dob = txtdob.Text;


            string[] strArr = dob.Split('-');

            string dday = strArr[0].ToString();
            string dmonth = strArr[1].ToString();
            string dyear = strArr[2].ToString();

            string dobdate = dyear + "-" + dmonth + "-" + dday;

            //Response.Write(dobdate);
            //Response.End();

            _Qry = "update img_enquiryform set enq_for='" + ddl_enquiryfor.SelectedValue + "',enq_reason='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreason.Text) + "',enq_aboutimage='" + ddl_aboutimage.SelectedValue + "',gender='" + ddl_gender.SelectedValue + "',enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtfname.Text) + "',enq_lastname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtLname.Text) + "',enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "',enq_personal_altmobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtaltmobile.Text) + "',enq_personal_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtemail.Text) + "',enq_personal_phone='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtphone.Text) + "',enq_Bloodgroup='" + ddl_bloodgroup.SelectedValue + "',enq_personal_dob='" + dobdate + "',enq_martialstatus='" + ddl_maritalstatus.SelectedValue + "',enq_mothertongue='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_mothertongue.Text) + "',enq_Nationality='" + txt_Nationality.SelectedValue + "',enq_present_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentaddress.Text) + "',enq_present_district='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentdistrict.Text) + "',enq_present_city='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentcity.Text) + "',enq_present_pincode='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentpincode.Text) + "',enq_present_state='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentstate.Text) + "',enq_permanant_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentstate.Text) + "',enq_permanant_district='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentdistrict.Text) + "',enq_permanant_city='" + (txtpermanentcity.Text) + "',enq_permanant_state='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentstate.Text) + "',enq_permanant_pincode='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentpincode.Text) + "',enq_high_qualification='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtqualification.Text) + "',enq_high_mainsubject='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmainsub.Text) + "',enq_high_institution='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtschoolcolname.Text) + "',enq_high_city='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcity.Text) + "',enq_high_state='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstate.Text) + "',enq_high_status='" + ddl_completionstatus.SelectedValue + "',enq_animation_status='" + ddl_animationstatus.SelectedValue + "',enq_animation_branch='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbranch.Text) + "',enq_animation_inst='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstitute.Text) + "',datemod=getdate() where enq_number='" + Request.QueryString["end_id"] + "'";

            //Response.Write(_Qry);
            //Response.End();

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);


            if (ddl_Inv_Possible.SelectedValue.ToString() == "Rs.25,000 to 50,000")
            {
                txtmininvestment.Text = "25000";
                txtmaxinvestment.Text = "50000";
            }
            if (ddl_Inv_Possible.SelectedValue.ToString() == "Rs.50,000 to 75,000")
            {
                txtmininvestment.Text = "50000";
                txtmaxinvestment.Text = "75000";
            }
            if (ddl_Inv_Possible.SelectedValue.ToString() == "Rs.75,000 to 1,00,000")
            {
                txtmininvestment.Text = "75000";
                txtmaxinvestment.Text = "100000";
            }
            if (ddl_Inv_Possible.SelectedValue.ToString() == "Above 1,00,000")
            {
                txtmininvestment.Text = "100000";
                txtmaxinvestment.Text = "100000";
            }


            //string enroll = txt_enrolldate.Text;

            //string[] strSplitArr1 = enroll.Split('-');
            //string enrollday = strSplitArr1[0].ToString();
            //string enrollmonth = strSplitArr1[1].ToString();
            //string enrollyear = strSplitArr1[2].ToString();


            //string enrolldate = enrollyear + "-" + enrollmonth + "-" + enrollday;



            _Qry1 = "update img_enquiryform1 set enq_parent_name='" + txtparentname.Text + "',enq_parent_relation='" + txtparentrelation.SelectedValue + "',enq_parent_mobile='" + txtparentmobile.Text + "',enq_parent_phone='" + txtparentphnumber.Text + "',enq_parent_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentemail.Text) + "',enq_parent_company='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_cmp.Text) + "',enq_parent_empstatus='" + ddl_employementstatus.SelectedValue + "',enq_parent_designation='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_designation.Text) + "',enq_parent_workplace='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_placeofwork.Text) + "',enq_parent_industrytype='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_typeofindustry.Text) + "',enq_parent_income='" + txtparent_monthlyincome.Text + "',enq_parent_support='" + ddl_support.SelectedValue + "',enq_parent_selfemployed='" + txtselfemployed.Text + "',enq_student_profile='" + ddl_profile.SelectedValue + "',enq_requirement='" + txtrequirements.Text + "',enq_questionraised='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtquestions.Text) + "',enq_competitor_brand='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbrand.Text) + "',enq_competitor_location='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtlocation.Text) + "',enq_competitor_positive='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpositive.Text) + "',enq_competitor_negative='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnegative.Text) + "',enq_financialstatus='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_finstatus.SelectedValue) + "',enq_financialdetail_min='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmininvestment.Text) + "',enq_financialdetail_max='" + (txtmaxinvestment.Text) + "',enq_decisionmaker_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakername.Text) + "',enq_decisionmaker_relation='" + ddldecision_relation.SelectedValue + "',enq_decisionmaker_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakercontactdetails.Text) + "',enq_ref_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_referrername.Text) + "',enq_ref_abtimage='" + txt_knowsimage.SelectedValue + "',enq_ref_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_referrercontactdetails.Text) + "',enq_counseledtime='" + txt_counseledtime.SelectedValue + "',enq_courseasked='" + txt_courseasked.SelectedValue + "',enq_coursepositioned='" + txt_coursepositioned.SelectedValue + "',datemod=getdate() where enq_number='" + Request.QueryString["end_id"] + "'";

            //Response.Write(_Qry + "<br>");
            //Response.Write(apdate);
            //Response.End();

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);


            lblmsg1.Text = "Enquiry details has been updated Successfully";
        }
    }

    private void fillcoursedropdown()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program Group By a.Program,a.course_id,b.Program";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txt_courseasked.DataSource = dt;
        txt_courseasked.DataValueField = "course_id";
        txt_courseasked.DataTextField = "Program";
        txt_courseasked.DataBind();
        txt_courseasked.Items.Insert(0, new ListItem("Select", ""));

    }


    private void fillcoursedropdown1()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program Group By a.Program,a.course_id,b.Program";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txt_coursepositioned.DataSource = dt;
        txt_coursepositioned.DataValueField = "course_id";
        txt_coursepositioned.DataTextField = "Program";
        txt_coursepositioned.DataBind();
        txt_coursepositioned.Items.Insert(0, new ListItem("Select", ""));

    }
    private void selectfromenquiry()
    {

        //Select Query of img_enquiryform

        //_Qry = "SELECT enq_personal_name,enq_lastname,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality,gender,enq_high_qualification,enq_high_mainsubject,enq_high_institution,enq_high_city,enq_high_state,enq_personal_dob, enq_personal_mobile,enq_personal_phone, enq_personal_altmobile, enq_personal_email, enq_present_address, enq_present_district, enq_present_state, enq_present_pincode, enq_permanant_address, enq_permanant_state, enq_permanant_district, enq_permanant_pincode,enq_present_city,enq_permanant_city from img_enquiryform where enq_number='" + Request.QueryString["end_id"] + "'";


        //_Qry = "SELECT enq_for,enq_aboutimage,gender,enq_personal_name,enq_lastname,enq_personal_mobile,enq_personal_altmobile,enq_personal_email,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality,enq_present_address,enq_present_district,enq_present_city,enq_present_pincode,enq_present_state,enq_permanant_address,enq_permanant_district,enq_permanant_city,enq_permanant_state,enq_permanant_pincode,convert(varchar, enq_personal_dob, 103) as enq_personal_dob  from img_enquiryform where enq_number='Enq-IMGDEV-12-6'";


        _Qry = "SELECT enq_for,enq_reason,enq_aboutimage,gender,enq_personal_name,enq_lastname,enq_personal_mobile,enq_personal_altmobile,enq_personal_email,enq_personal_phone,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality,enq_present_address,enq_present_district,enq_present_city,enq_present_pincode,enq_present_state,enq_permanant_address,enq_permanant_district,enq_permanant_city,enq_permanant_state,enq_permanant_pincode,convert(varchar, enq_personal_dob, 105) as enq_personal_dob,enq_high_qualification,enq_high_mainsubject,enq_high_institution,enq_high_city,enq_high_state,enq_high_status,enq_animation_status,enq_animation_branch,enq_animation_inst  from img_enquiryform where enq_number='" + Request.QueryString["end_id"] + "'";



        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            //Converting the db dob to the right format

            ddl_enquiryfor.SelectedValue = dt.Rows[0]["enq_for"].ToString();
            txtreason.Text = dt.Rows[0]["enq_reason"].ToString();
            ddl_aboutimage.SelectedValue = dt.Rows[0]["enq_aboutimage"].ToString();
            ddl_gender.SelectedValue = dt.Rows[0]["gender"].ToString();
            txtfname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            txtLname.Text = dt.Rows[0]["enq_lastname"].ToString();
            txtmobile.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            txtaltmobile.Text = dt.Rows[0]["enq_personal_altmobile"].ToString();
            txtemail.Text = dt.Rows[0]["enq_personal_email"].ToString();
            txtphone.Text = dt.Rows[0]["enq_personal_phone"].ToString();

            string apdate = dt.Rows[0]["enq_personal_dob"].ToString();

            txtdob.Text = apdate;

            ddl_bloodgroup.SelectedValue = dt.Rows[0]["enq_Bloodgroup"].ToString();
            ddl_maritalstatus.SelectedValue = dt.Rows[0]["enq_martialstatus"].ToString();
            txt_mothertongue.Text = dt.Rows[0]["enq_mothertongue"].ToString();
            txt_Nationality.Text = dt.Rows[0]["enq_Nationality"].ToString();


            //string[] strSplitArr = dob.Split(' ');
            //string dob1 = strSplitArr[0].ToString();

            //string dob2 = dob1;
            //string[] strSplitArr1 = dob2.Split('/');

            //string smonth = strSplitArr1[0].ToString();
            //string sdate = strSplitArr1[1].ToString();
            //string syear = strSplitArr1[2].ToString();

            //string apdate = sdate + "-" + smonth + "-" + syear;

            txtpresentaddress.Text = dt.Rows[0]["enq_present_address"].ToString();
            txtpresentdistrict.Text = dt.Rows[0]["enq_present_district"].ToString();
            txtpresentcity.Text = dt.Rows[0]["enq_present_city"].ToString();
            txtpresentpincode.Text = dt.Rows[0]["enq_present_pincode"].ToString();
            txtpresentstate.Text = dt.Rows[0]["enq_present_state"].ToString();
            txtpermanentaddress.Text = dt.Rows[0]["enq_permanant_address"].ToString();
            txtpermanentdistrict.Text = dt.Rows[0]["enq_permanant_district"].ToString();
            txtpermanentcity.Text = dt.Rows[0]["enq_permanant_city"].ToString();
            txtpermanentstate.Text = dt.Rows[0]["enq_permanant_state"].ToString();
            txtpermanentpincode.Text = dt.Rows[0]["enq_permanant_pincode"].ToString();


            txtqualification.Text = dt.Rows[0]["enq_high_qualification"].ToString();
            txtmainsub.Text = dt.Rows[0]["enq_high_mainsubject"].ToString();
            txtschoolcolname.Text = dt.Rows[0]["enq_high_institution"].ToString();
            txtcity.Text = dt.Rows[0]["enq_high_city"].ToString();
            txtstate.Text = dt.Rows[0]["enq_high_state"].ToString();
            ddl_completionstatus.SelectedValue = dt.Rows[0]["enq_high_status"].ToString();
            ddl_animationstatus.SelectedValue = dt.Rows[0]["enq_animation_status"].ToString();
            txtbranch.Text = dt.Rows[0]["enq_animation_branch"].ToString();
            txtinstitute.Text = dt.Rows[0]["enq_animation_inst"].ToString();
        }
        //Select Query of img_enquiryform1

        _Qry1 = "SELECT enq_parent_name,enq_parent_relation,enq_parent_mobile,enq_parent_phone,enq_parent_email,enq_parent_company,enq_parent_empstatus,enq_parent_designation,enq_parent_workplace,enq_parent_industrytype,enq_parent_income,enq_parent_support,enq_parent_selfemployed,enq_student_profile,enq_requirement,enq_questionraised,enq_competitor_brand,enq_competitor_location,enq_competitor_positive,enq_competitor_negative,enq_financialstatus,enq_financialdetail_min,enq_financialdetail_max,enq_fundplan,enq_interestlevel,enq_attendedcounseling,enq_decisionmaker_name,enq_decisionmaker_relation,enq_decisionmaker_address,enq_ref_name,enq_ref_abtimage,enq_refabtimage_others,enq_ref_address,enq_counseledtime,enq_courseasked,enq_coursepositioned,enq_enqstatus,convert(varchar, enq_enrol_date, 105) as enq_enrol_date,enq_financialdetail_min,enq_financialdetail_max FROM img_enquiryform1 where enq_number='" + Request.QueryString["end_id"] + "'";

        //Response.Write(_Qry1);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
        if (dt1.Rows.Count > 0)
        {
            txtparentname.Text = dt1.Rows[0]["enq_parent_name"].ToString();
            txtparentrelation.SelectedValue = dt1.Rows[0]["enq_parent_relation"].ToString();
            txtparentmobile.Text = dt1.Rows[0]["enq_parent_mobile"].ToString();
            txtparentphnumber.Text = dt1.Rows[0]["enq_parent_phone"].ToString();
            txtparentemail.Text = dt1.Rows[0]["enq_parent_email"].ToString();

            txtparent_cmp.Text = dt1.Rows[0]["enq_parent_company"].ToString();
            ddl_employementstatus.SelectedValue = dt1.Rows[0]["enq_parent_empstatus"].ToString();
            txtparent_designation.Text = dt1.Rows[0]["enq_parent_designation"].ToString();
            txtparent_placeofwork.Text = dt1.Rows[0]["enq_parent_workplace"].ToString();
            txtparent_typeofindustry.Text = dt1.Rows[0]["enq_parent_industrytype"].ToString();
            txtparent_monthlyincome.Text = dt1.Rows[0]["enq_parent_income"].ToString();
            ddl_support.SelectedValue = dt1.Rows[0]["enq_parent_support"].ToString();


            ddl_profile.SelectedValue = dt1.Rows[0]["enq_student_profile"].ToString();
            txtrequirements.Text = dt1.Rows[0]["enq_requirement"].ToString();
            txtquestions.Text = dt1.Rows[0]["enq_questionraised"].ToString();
            txtbrand.Text = dt1.Rows[0]["enq_competitor_brand"].ToString();
            txtlocation.Text = dt1.Rows[0]["enq_competitor_location"].ToString();
            txtpositive.Text = dt1.Rows[0]["enq_competitor_positive"].ToString();
            txtnegative.Text = dt1.Rows[0]["enq_competitor_negative"].ToString();
            ddl_finstatus.SelectedValue = dt1.Rows[0]["enq_financialstatus"].ToString();



            txtmininvestment.Text = dt1.Rows[0]["enq_financialdetail_min"].ToString();
            txtmaxinvestment.Text = dt1.Rows[0]["enq_financialdetail_max"].ToString();


            if (dt1.Rows[0]["enq_financialdetail_min"].ToString() == "25000" && dt1.Rows[0]["enq_financialdetail_max"].ToString() == "50000") 
            {
                

               ddl_Inv_Possible.SelectedValue="Rs.25,000 to 50,000";
            }

            if (dt1.Rows[0]["enq_financialdetail_min"].ToString() == "50000" && dt1.Rows[0]["enq_financialdetail_max"].ToString() == "75000")
            {


                ddl_Inv_Possible.SelectedValue = "Rs.75,000 to 1,00,000";
            }
            if (dt1.Rows[0]["enq_financialdetail_min"].ToString() == "75000" && dt1.Rows[0]["enq_financialdetail_max"].ToString() == "100000")
            {


                ddl_Inv_Possible.SelectedValue = "Rs.50,000 to 75,000";
            }
            if (dt1.Rows[0]["enq_financialdetail_min"].ToString() == "100000" && dt1.Rows[0]["enq_financialdetail_max"].ToString() == "100000")
            {


                ddl_Inv_Possible.SelectedValue = "Above 1,00,000";
            }


            txtarrangefund.Text = dt1.Rows[0]["enq_fundplan"].ToString();
            ddl_interestlevel.SelectedValue = dt1.Rows[0]["enq_interestlevel"].ToString();
            txtwhoallattended.Text = dt1.Rows[0]["enq_attendedcounseling"].ToString();
            txt_dmakername.Text = dt1.Rows[0]["enq_decisionmaker_name"].ToString();
            ddldecision_relation.SelectedValue = dt1.Rows[0]["enq_decisionmaker_relation"].ToString();
            txt_dmakercontactdetails.Text = dt1.Rows[0]["enq_decisionmaker_address"].ToString();

            txt_referrername.Text = dt1.Rows[0]["enq_ref_name"].ToString();
            txt_knowsimage.SelectedValue = dt1.Rows[0]["enq_ref_abtimage"].ToString();
            txt_referrercontactdetails.Text = dt1.Rows[0]["enq_ref_address"].ToString();

            txt_counseledtime.SelectedValue = dt1.Rows[0]["enq_counseledtime"].ToString();
            txt_courseasked.SelectedValue = dt1.Rows[0]["enq_courseasked"].ToString();
            txt_coursepositioned.SelectedValue = dt1.Rows[0]["enq_coursepositioned"].ToString();
           // ddl_status.SelectedValue = dt1.Rows[0]["enq_enqstatus"].ToString();
           // txt_enrolldate.Text = dt1.Rows[0]["enq_enrol_date"].ToString();
            


            //if (txt_income.Value == "0")
            //{
            //    txt_income.Value = "";
            //}

            txtselfemployed.Text = dt1.Rows[0]["enq_parent_selfemployed"].ToString();

            //Response.Write(dt1.Rows[0]["enq_Coursepositioned"].ToString());
            //Response.End();


        }
    }

}
