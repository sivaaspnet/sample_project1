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
using System.Collections.Generic;
public partial class superadmin_AddEnquiry : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5,_Qry6, CentreCount, CentreCode, enqno, enqvalue,  dob1;

    int enqcount;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Response.Write(Session["SA_centre_code"]);
        //Response.End();

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            lblalertmsg.Text = "";
            fillcoursedropdown();
            fillcoursedropdown1();
            fillcentre();
            if (Request.QueryString["teleid"] != null)
            {
                filltele();
            }
        }

    }

    private void filltele()
    {
        _Qry = "Select * from TeleEnquiry where teleenquiryid='" + Request.QueryString["teleid"] + "' and centrecode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            ddl_aboutimage.SelectedValue = dt.Rows[0]["sourse"].ToString();
            ddl_profile.SelectedValue=dt.Rows[0]["profile"].ToString();
            txtname.Text = dt.Rows[0]["enquiryname"].ToString();
            txtmobile.Text = dt.Rows[0]["mobileno"].ToString();
            txtemail.Text = dt.Rows[0]["emailid"].ToString();
            txtreferstudentname.Text = dt.Rows[0]["referedstudentname"].ToString();
            txt_courseasked.Items.FindByText(dt.Rows[0]["CourseInterested"].ToString()).Selected = true;
        }
    }
    private void fillcentre()
    {
        _Qry = "Select Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_Centre.DataSource = dt;
        ddl_Centre.DataTextField = "Centre_location";
        ddl_Centre.DataValueField = "Centre_location";
        ddl_Centre.DataBind();
        ddl_Centre.Items.Insert(0, new ListItem("Select", ""));
    }


    private void fillcoursedropdown()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {
        //        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' and a.year=1 Group By a.Program,a.course_id,b.Program";

                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program  and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";

            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";
            }
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

    }

    private void fillcoursedropdown1()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";

              //  _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' and a.year=1 Group By a.Program,a.course_id,b.Program";
            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and a.year=1 Group By a.Program,a.course_id,b.Program";
            }

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

    }

    private void insertenqno()
    {

        _Qry5 = "select Enquiry_Count from img_centredetails where centre_code='" + Session["SA_centre_code"] + "'";


        //Response.Write(_Qry5);
        //Response.End();

            DataTable dt5 = new DataTable();
            dt5 = MVC.DataAccess.ExecuteDataTable(_Qry5);
            if (dt5.Rows.Count > 0)
            {


                enqvalue = dt5.Rows[0]["Enquiry_Count"].ToString();



                enqcount =Convert.ToInt32( enqvalue) + 1 ;

                int month3 = System.DateTime.Now.Month;

                enqno = "Enq" + "-" + Session["SA_centre_code"] + "-" + month3 + "-" + enqcount;

                Session["Enqno"] = enqno;

                _Qry6 = "update img_centredetails set Enquiry_Count='" + enqcount + "' where centre_code='" + Session["SA_centre_code"] + "'";

                //Response.Write(_Qry6);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry6);

            }
    }

    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
      //  _Qry = "Select count(*) from img_enquiryform where enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "' And enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "' And enq_personal_email='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtemail.Text) + "' And Centre_Code='" + Session["SA_centre_code"] + "' And (select count(*) from img_enquiryform1 where enq_courseasked='" + txt_courseasked.SelectedValue + "' And enq_number=img_enquiryform.enq_number)>0";
       // _Qry = "Select count(*) from img_enquiryform where enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "' And enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "' And Centre_Code='" + Session["SA_centre_code"] + "' ";

        _Qry = "Select count(*) from img_enquiryform where (enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "' And Centre_Code='" + Session["SA_centre_code"] + "') OR ( Centre_Code='" + Session["SA_centre_code"] + "' And enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "' ) ";
        //Response.Write(_Qry);
        //Response.End();

        int enqcount = 0;

        enqcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        if (enqcount > 0)
        {
           // Response.Redirect("ViewEnquiry.aspx");
            lblalertmsg.Text = "Enquiry Details /Mobile Number Already Exists";
        }
        else
        {
            //to insert enquiry no
            insertenqno();

            //To split the date and time 
            string dob = txtdob.Text;
            string[] strSplitArr = dob.Split(' ');
            dob1 = strSplitArr[0].ToString();

            string dob2 = dob1;

            string[] strSplitArr1 = dob2.Split('-');
            string dday = strSplitArr1[0].ToString();
            string dmonth = strSplitArr1[1].ToString();
            string dyear = strSplitArr1[2].ToString();

            string apdate = dyear + "-" + dmonth + "-" + dday;


            //Form1 insert
            _Qry2 = "INSERT INTO img_enquiryform (centre_code,enq_number,enq_for , enq_for_others,enq_reason , enq_aboutimage , enq_aboutimage_others,referedstudentname , gender , enq_high_qualification , enq_high_mainsubject , enq_high_institution , enq_high_city , enq_high_state , enq_high_status , enq_animation_inst , enq_animation_branch , enq_animation_status , enq_personal_name , enq_personal_dob , enq_personal_mobile , enq_personal_altmobile , enq_personal_email , enq_personal_phone , enq_present_address , enq_present_city , enq_present_district , enq_present_state , enq_present_pincode , enq_permanant_address , enq_permanant_city , enq_permanant_state , enq_permanant_district , enq_permanant_pincode,enq_lastname,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality )VALUES ('" + Session["SA_centre_code"] + "','" + Session["Enqno"] + "','" + ddl_enquiryfor.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtenqothers.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreason.Text) + "','" + ddl_aboutimage.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_abt_image.Text) + "','"+ MVC.CommonFunction.ReplaceQuoteWithTild(txtreferstudentname.Text) +"','" + ddl_gender.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtqualification.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmainsub.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtschoolcolname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstate.Text) + "','" + ddl_completionstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstitute.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbranch.Text) + "','" + ddl_animationstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "','" + apdate + "' ,'" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtaltmobile.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtemail.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtphone.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentaddress.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentdistrict.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentstate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentpincode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentaddress.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentstate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentdistrict.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentpincode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtLname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_bloodgroup.SelectedValue) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_maritalstatus.SelectedValue) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_mothertongue.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Nationality.SelectedValue) + "') ";

            //Response.Write(_Qry2);
            //Response.End();


            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
            if (Request.QueryString["teleid"] != null)
            {
                _Qry = " delete from TeleEnquiry Where TeleEnquiryId='" + Request.QueryString["teleid"].ToString() + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            _Qry3 = "SELECT Top 1 enq_id FROM img_enquiryform ORDER BY enq_id DESC";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry3);
            Session["ENQ_ID"] = dt1.Rows[0][0].ToString();

            //Form2 insert      



            //DateTime datestrdate = DateTime.Parse(txt_enrolldate.Text);

            //Response.Write("Test:" + txt_enrolldate.Text);
            //Response.End();

            if (txt_enrolldate.Text != "" && txt_enrolldate.Text != null)
            {
                string str = txt_enrolldate.Text;
                string[] split = str.Split('-');
                string datet = split[2] + "-" + split[1] + "-" + split[0];
                //Response.Write(d);
                //Response.End();
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
                _Qry = "INSERT INTO img_enquiryform1 (enq_id,centre_code,enq_number,enq_parent_name, enq_parent_relation,enq_parentrelation_others, enq_parent_phone, enq_parent_mobile, enq_parent_email, enq_parent_company, enq_parent_empstatus, enq_parent_designation, enq_parent_workplace, enq_parent_industrytype, enq_parent_income, enq_parent_selfemployed, enq_parent_support, enq_parent_incomesource, enq_source_others, enq_student_profile, enq_requirement, enq_questionraised, enq_competitor_brand, enq_competitor_location, enq_competitor_positive, enq_competitor_negative, enq_financialstatus, enq_financialdetail_min, enq_financialdetail_max, enq_fundplan, enq_interestlevel, enq_attendedcounseling, enq_decisionmaker_name, enq_decisionmaker_relation, enq_decisionmaker_address, enq_ref_name, enq_ref_abtimage,enq_refabtimage_others,enq_refcenter,enq_refstudentID, enq_ref_address, enq_counseledtime, enq_knowimage, enq_courseasked, enq_coursepositioned,enq_enqstatus, enq_enrol_date, enq_actionplan,created_by,dateins) VALUES ('" + Session["ENQ_ID"] + "','" + Session["SA_centre_code"] + "','" + Session["Enqno"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentname.Text) + "', '" + txtparentrelation.Text + "','" + txtrelationothers.Text + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentphnumber.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentmobile.Text) + "', '" + txtparentemail.Text + "', '" + txtparent_cmp.Text + "', '" + ddl_employementstatus.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_designation.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_placeofwork.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_typeofindustry.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_monthlyincome.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtselfemployed.Text) + "', '" + ddl_support.SelectedValue + "', '" + ddl_source.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsource.Text) + "', '" + ddl_profile.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtrequirements.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtquestions.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbrand.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtlocation.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpositive.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnegative.Text) + "', '" + ddl_finstatus.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmininvestment.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmaxinvestment.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtarrangefund.Text) + "', '', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtwhoallattended.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakername.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakerrelationship.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakercontactdetails.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_referrername.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_knowsimage.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtothersrefer.Text) + "','" + ddl_Centre.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtReferalstudentid.Text) + "', '" + txt_referrercontactdetails.Text + "', '" + txt_counseledtime.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_knowsimage.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseasked.SelectedValue) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_coursepositioned.SelectedValue) + "', '" + ddl_status.SelectedValue + "', '" + datet + "' ,'" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_actionplan.Text) + "','" + Session["SA_Username"] + "',getdate())";
                //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else
            {
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
                _Qry = "INSERT INTO img_enquiryform1 (enq_id,centre_code,enq_number,enq_parent_name, enq_parent_relation,enq_parentrelation_others, enq_parent_phone, enq_parent_mobile, enq_parent_email, enq_parent_company, enq_parent_empstatus, enq_parent_designation, enq_parent_workplace, enq_parent_industrytype, enq_parent_income, enq_parent_selfemployed, enq_parent_support, enq_parent_incomesource, enq_source_others, enq_student_profile, enq_requirement, enq_questionraised, enq_competitor_brand, enq_competitor_location, enq_competitor_positive, enq_competitor_negative, enq_financialstatus, enq_financialdetail_min, enq_financialdetail_max, enq_fundplan, enq_interestlevel, enq_attendedcounseling, enq_decisionmaker_name, enq_decisionmaker_relation, enq_decisionmaker_address, enq_ref_name, enq_ref_abtimage,enq_refabtimage_others,enq_refcenter,enq_refstudentID, enq_ref_address, enq_counseledtime, enq_knowimage, enq_courseasked, enq_coursepositioned,enq_enqstatus, enq_enrol_date, enq_actionplan,created_by,dateins) VALUES ('" + Session["ENQ_ID"] + "','" + Session["SA_centre_code"] + "','" + Session["Enqno"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentname.Text) + "', '" + txtparentrelation.Text + "','" + txtrelationothers.Text + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentphnumber.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparentmobile.Text) + "', '" + txtparentemail.Text + "', '" + txtparent_cmp.Text + "', '" + ddl_employementstatus.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_designation.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_placeofwork.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_typeofindustry.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtparent_monthlyincome.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtselfemployed.Text) + "', '" + ddl_support.SelectedValue + "', '" + ddl_source.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsource.Text) + "', '" + ddl_profile.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtrequirements.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtquestions.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbrand.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtlocation.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpositive.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtnegative.Text) + "', '" + ddl_finstatus.SelectedValue + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmininvestment.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmaxinvestment.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtarrangefund.Text) + "', '', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txtwhoallattended.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakername.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakerrelationship.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_dmakercontactdetails.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_referrername.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_knowsimage.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtothersrefer.Text) + "','" + ddl_Centre.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtReferalstudentid.Text) + "', '" + txt_referrercontactdetails.Text + "', '" + txt_counseledtime.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_knowsimage.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseasked.SelectedValue) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_coursepositioned.SelectedValue) + "', '" + ddl_status.SelectedValue + "', '" + txt_enrolldate.Text + "' ,'" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_actionplan.Text) + "','" + Session["SA_Username"] + "',getdate())";
                //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }

            Response.Redirect("Thankyou.aspx");
        }
    }
}
