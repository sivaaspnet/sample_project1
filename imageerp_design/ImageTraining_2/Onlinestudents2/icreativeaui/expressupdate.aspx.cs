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

public partial class superadmin_Admission : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, studid, CentreCount, radiobtn, dateofissue, dateofexp, dofissue,dofexp;
    string knowimagesep, digitalcourse, digitalinstitute, digitalcity, digitalstatus, plevelactivity, plevelparticipation;
    string cmptername, cmpterindustry, cmpterorganisation, cmpterdesign,cmptercontactno;
    string medianame, mediainstitution, mediadesignation, mediacontactno;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        
        if (!IsPostBack)
        {          

          
           
            studentid();
            selectfromenquiry();
        }
        
        
          
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
                qry1 = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.coursename,a.course_id,b.Program,a.Program";
            }
            else
            {
                qry1 = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";
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
                qry = "SElect program,lump_sum,instal_amount from img_centre_coursefee_details where centre_code='ICH-102'";
            }
            else
            {
                qry = "SElect program,lump_sum,instal_amount from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";

            }
            qry = "SElect program,lump_sum,instal_amount from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";

            //Response.Write(qry);
            //Response.End();
            
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i;
                js = "<script language='javascript' type='text/javascript'>\n";
                js += "var courseFees=new Array();\n";

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    js += "courseFees[" + i + "]=new Array();\n";
                    js += "courseFees[" + i + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                    js += "courseFees[" + i + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                    js += "courseFees[" + i + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";


                }
                js += "</script>";
            }
            return js;
        }
    }
    private void GetCoursefee()
    {
        string js= "";
        js = generatecoursefee();
        Page.RegisterClientScriptBlock("SubcategoryDetail", js);
    }

    


    private void selectfromenquiry()
    {

        //Select Query of img_enquiryform

        _Qry = "SELECT enq_personal_name,enq_lastname,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality,gender,enq_high_qualification,enq_high_mainsubject,enq_high_institution,enq_high_city,enq_high_state,convert( varchar,enq_personal_dob,105)enq_personal_dob, enq_personal_mobile,enq_personal_phone, enq_personal_altmobile, enq_personal_email, enq_present_address, enq_present_district, enq_present_state, enq_present_pincode, enq_permanant_address, enq_permanant_state, enq_permanant_district, enq_permanant_pincode,enq_present_city,enq_permanant_city from img_enquiryform where enq_number='" + Request.QueryString["end_id"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            //Converting the db dob to the right format

            txt_firstname.Text = dt.Rows[0]["enq_personal_name"].ToString();
            txt_lastname.Text = dt.Rows[0]["enq_lastname"].ToString();
            txt_mothertongue.Text = dt.Rows[0]["enq_mothertongue"].ToString();
            ddl_bloodgroup.SelectedValue = dt.Rows[0]["enq_Bloodgroup"].ToString();
            ddl_maritalstatus.SelectedValue = dt.Rows[0]["enq_martialstatus"].ToString();
            txt_nationality.SelectedValue = dt.Rows[0]["enq_Nationality"].ToString();
            ddl_gender.SelectedValue = dt.Rows[0]["gender"].ToString();
            ddlprimary.Value = dt.Rows[0]["enq_high_qualification"].ToString();
            txt_tenthmajor.Value = dt.Rows[0]["enq_high_mainsubject"].ToString();
            txt_tenthinstitution.Value = dt.Rows[0]["enq_high_institution"].ToString();
            txt_tenthcity.Value = dt.Rows[0]["enq_high_city"].ToString();
            txt_tenthstate.Value = dt.Rows[0]["enq_high_state"].ToString();

            //  string dob = dt.Rows[0]["enq_personal_dob"].ToString();
          //  string[] strSplitArr = dob.Split(' ');
          //  string dob1 = strSplitArr[0].ToString();

          //  string dob2 = dob1;
          //  string[] strSplitArr1 = dob2.Split('/');

          //  string smonth = strSplitArr1[0].ToString();
          //  string sdate = strSplitArr1[1].ToString();
          //  string syear = strSplitArr1[2].ToString();

          //  string apdate = sdate + "-" + smonth + "-" + syear;
          //txt_dob.Text = apdate;

            txt_dob.Text = dt.Rows[0]["enq_personal_dob"].ToString();

            txt_mobile.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            txt_altmobile.Text = dt.Rows[0]["enq_personal_altmobile"].ToString();
            //txt_presentphone.Text = dt.Rows[0]["enq_personal_phone"].ToString();
            txt_permanentphone.Text = dt.Rows[0]["enq_personal_phone"].ToString();
            txt_email.Text = dt.Rows[0]["enq_personal_email"].ToString();
            txt_presentaddress.Value = dt.Rows[0]["enq_present_address"].ToString();
            txt_presentdistrict.Value = dt.Rows[0]["enq_present_district"].ToString();
            txtpresentcity.Text = dt.Rows[0]["enq_present_city"].ToString();
            txt_presentpin.Value = dt.Rows[0]["enq_present_pincode"].ToString();
            txt_presentstate.Value = dt.Rows[0]["enq_present_state"].ToString();
            txt_permanentaddress.Value = dt.Rows[0]["enq_permanant_address"].ToString();
            txt_permanentdistrict.Value = dt.Rows[0]["enq_permanant_district"].ToString();
            txtpermanentcity.Text = dt.Rows[0]["enq_permanant_city"].ToString();
            txt_permanentstate.Value = dt.Rows[0]["enq_permanant_state"].ToString();
            txt_permanentpin.Value = dt.Rows[0]["enq_permanant_pincode"].ToString();
        }
        //Select Query of img_enquiryform1

        _Qry1 = "SELECT enq_parent_name, enq_parent_relation, enq_parent_phone, enq_parent_mobile, enq_parent_email, enq_parent_company, enq_parent_empstatus, enq_parent_designation, enq_parent_workplace, enq_parent_industrytype, enq_parent_income, enq_parent_selfemployed,enq_Coursepositioned FROM img_enquiryform1 where enq_number='" + Request.QueryString["end_id"] + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
        if (dt1.Rows.Count > 0)
        {
            txt_guardianname.Text = dt1.Rows[0]["enq_parent_name"].ToString();
            txt_relationship.Text = dt1.Rows[0]["enq_parent_relation"].ToString();
            txt_guardianmobile.Text = dt1.Rows[0]["enq_parent_mobile"].ToString();
            txt_guardianphone.Text = dt1.Rows[0]["enq_parent_phone"].ToString();
            txt_guardianemail.Text = dt1.Rows[0]["enq_parent_email"].ToString();
            txt_company.Value = dt1.Rows[0]["enq_parent_company"].ToString();
            ddl_empstatus.SelectedValue = dt1.Rows[0]["enq_parent_empstatus"].ToString();
            txt_designation.Value = dt1.Rows[0]["enq_parent_designation"].ToString();
            txt_workPlace.Value = dt1.Rows[0]["enq_parent_workplace"].ToString();
            txt_industryType.Value = dt1.Rows[0]["enq_parent_industrytype"].ToString();
            txt_income.Value = dt1.Rows[0]["enq_parent_income"].ToString();

            if (txt_income.Value == "0")
            {
                txt_income.Value = "";
            }

            txt_selfemployed.Value = dt1.Rows[0]["enq_parent_selfemployed"].ToString();

            //Response.Write(dt1.Rows[0]["enq_Coursepositioned"].ToString());
            //Response.End();

            
        }

        _Qry = "select installno,paymentType from erp_invoicedetails where centercode='"+Session["SA_centre_code"]+"' and studentid='"+ Label2.Text + "'";

      
        DataTable dt9 = new DataTable();
        dt9 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt9.Rows.Count > 0)
        {
            string type;
            type = dt9.Rows[0]["paymentType"].ToString();
            if (type == "Installment")
            {
                txt_install.Text = dt9.Rows[0]["installno"].ToString();
            }
            else
            {
                txt_install.Visible = false;
                txt_install.Text = "1";
            }
        }


    }


    private void insertstudno()
    {
        _Qry = "Select InvoiceCount+1 as cnt from Invoice_Count where centre_code='" + Session["SA_centre_code"] + "'";

        //_Qry = "select Invoice_No+1 as cnt from adm_studentid where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CentreCount = dt.Rows[0]["cnt"].ToString();
            _Qry = "Update Invoice_Count set InvoiceCount=InvoiceCount+1 where centre_code='" + Session["SA_centre_code"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        else
        {
            CentreCount = "3000";
            _Qry = "Insert into Invoice_Count Values('" + CentreCount + "','" + Session["SA_centre_code"] + "')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }

        if (Convert.ToInt32(CentreCount) < 10)
        {
            CentreCount = "00" + CentreCount;
        }
        else if (Convert.ToInt32(CentreCount) < 100)
        {
            CentreCount = "0" + CentreCount;
        }

        Session["Invoice_no"] = CentreCount;

        int month3 = System.DateTime.Now.Month;
        //string 

        string year2=System.DateTime.Now.ToString("yy");
        if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
        {
            studid = Session["SA_centre_code"] + "-" + month3 + "-" + CentreCount;
        }
        else
        {
            string mm3 = "";
            if (month3 < 10)
            {
                mm3 = "0" + month3.ToString();
            }
            else
            {
                mm3 = month3.ToString();
            }


            studid = Session["SA_centre_code"] + "-" + mm3 + year2 + "-" + CentreCount;
            //studid = Session["SA_centre_code"] + "-" + year2 + month3 + "-" + CentreCount;
        }        

        Session["Stud_ID"] = studid;
    }

    private void insertadm3()
    {
        //Comma Seperator for Check box digital Media
        digitalcourse = "";
        if (WebDesigning.Value != "")
        {
            digitalcourse = WebDesigning.Value;
        
        }
        if(chk_3DAnimation.Value != "")
        {
            if(digitalcourse == "")
            {
             digitalcourse = chk_3DAnimation.Value;
            }
            else
            {
            digitalcourse = digitalcourse+","+chk_3DAnimation.Value;
            }
        }
        if (PostProduction.Value != "")
        {
          if(digitalcourse == "")
            {
             digitalcourse = PostProduction.Value;
            }
            else
            {
            digitalcourse = digitalcourse+","+PostProduction.Value;
            }
        }
         if (FineArts.Value != "")
         {
          if(digitalcourse == "")
            {
             digitalcourse = FineArts.Value;
            }
            else
            {
            digitalcourse = digitalcourse+","+FineArts.Value;
            }
         }
        if (Programming.Value != "")
        {
         if(digitalcourse == "")
            {
             digitalcourse = Programming.Value;
            }
            else
            {
            digitalcourse = digitalcourse +","+ Programming.Value;
            }  
        }
        if(check_2DAnimation.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = check_2DAnimation.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + check_2DAnimation.Value;
            }  
        }
        if (Hardware.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = Hardware.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + Hardware.Value;
            }  
         }               
        if (GameDesigning.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = GameDesigning.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + GameDesigning.Value;
            }  
         }                         
        if (GameProgramming.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = GameProgramming.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + GameProgramming.Value;
            }  
         }     
        if (Networking.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = Networking.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + Networking.Value;
            }  
         }
         if (FlashScripting.Value != "")
        {
         if(digitalcourse == "")
            {
                digitalcourse = FlashScripting.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + FlashScripting.Value;
            }  
         }

         //Comma Seperator for textbox institution

         digitalinstitute = "";
         if (txt_institutename1.Value != "")
         {
             digitalinstitute = txt_institutename1.Value;

         }
         if (txt_institutename2.Value != "")
         {
             if (digitalinstitute == "")
             {
                 digitalinstitute = txt_institutename2.Value;
             }
             else
             {
                 digitalinstitute = digitalinstitute + "," + txt_institutename2.Value;
             }
         }

         //Comma Seperator for textbox Digitalcity

         digitalcity = "";
         if (txt_city1.Value != "")
         {
             digitalcity = txt_city1.Value;

         }
         if (txt_city2.Value != "")
         {
             if (digitalcity == "")
             {
                 digitalcity = txt_city2.Value;
             }
             else
             {
                 digitalcity = digitalcity + "," + txt_city2.Value;
             }
         }

         //Comma Seperator for dropdown digitalstatus

         digitalstatus = "";
         if (ddl_digitalstatus.SelectedValue != "")
         {
             digitalstatus = ddl_digitalstatus.SelectedValue;

         }
         if (ddl_digitalstatus2.SelectedValue != "")
         {
             if (digitalstatus == "")
             {
                 digitalstatus = ddl_digitalstatus2.SelectedValue;
             }
             else
             {
                 digitalstatus = digitalstatus + "," + ddl_digitalstatus2.SelectedValue;
             }
         }

         //Comma Seperator for textbox activity
         plevelactivity = "";
         if (txt_activity1.Value != "")
         {
             plevelactivity = txt_activity1.Value;

         }
         if (txt_activity2.Value != "")
         {
             if (plevelactivity == "")
             {
                 plevelactivity = txt_activity2.Value;
             }
             else
             {
                 plevelactivity = plevelactivity + "," + txt_activity2.Value;
             }
         }

         //Comma Seperator for textbox participation

          plevelparticipation = "";

         if (txt_participation1.SelectedValue != "")
         {
             plevelparticipation = txt_participation1.SelectedValue;

         }
         if (txt_participation2.SelectedValue != "")
         {
             if (plevelparticipation == "")
             {
                 plevelparticipation = txt_participation2.SelectedValue;
             }
             else
             {
                 plevelparticipation = plevelparticipation + "," + txt_participation2.SelectedValue;
             }
         }
    }
    private void insertadm4()
    {
        //Comma Seperator for dropdown & textbox know image when

         knowimagesep = "";

        if (ddl_whenmonth.SelectedValue != "")
        {
            knowimagesep = ddl_whenmonth.SelectedValue;

        }
        if (txt_whenyear.Text != "")
        {
            if (knowimagesep == "")
            {
                knowimagesep = txt_whenyear.Text;
            }
            else
            {
                knowimagesep = knowimagesep + "," + txt_whenyear.Text;
            }
        }

        //Comma Seperator for competitornames
        cmptername = "";

        if (txtname_person1.Value != "")
        {
            cmptername = txtname_person1.Value;
        }
        if (txtname_person2.Value != "")
        {
            if (cmptername == "")
            {
                cmptername = txtname_person2.Value;
            }
            else
            {
                cmptername = cmptername + "," + txtname_person2.Value;
            }
        }
        //Comma Seperator for competitorIndustry

         cmpterindustry = "";

        if (txt_industry1.Value != "")
        {
            cmpterindustry = txt_industry1.Value;
        }
        if (txt_industry2.Value != "")
        {
            if (cmpterindustry == "")
            {
                cmpterindustry = txt_industry2.Value;
            }
            else
            {
                cmpterindustry = cmpterindustry + "," + txt_industry2.Value;
            }
        }

        //Comma Seperator for competitorOrganisation

         cmpterorganisation = "";

        if (txt_org1.Value != "")
        {
            cmpterorganisation = txt_org1.Value;
        }
        if (txt_org2.Value != "")
        {
            if (cmpterorganisation == "")
            {
                cmpterorganisation = txt_org2.Value;
            }
            else
            {
                cmpterorganisation = cmpterorganisation + "," + txt_org2.Value;
            }
        }
        //Comma Seperator for competitorDesign

         cmpterdesign = "";

        if (txt_desig1.Value != "")
        {
            cmpterdesign = txt_desig1.Value;
        }
        if (txt_desig2.Value != "")
        {
            if (cmpterdesign == "")
            {
                cmpterdesign = txt_desig2.Value;
            }
            else
            {
                cmpterdesign = cmpterdesign + "," + txt_desig2.Value;
            }
        }
        //Comma Seperator for competitorcontactno

         cmptercontactno = "";

        if (txt_contactno1.Value != "")
        {
            cmptercontactno = txt_contactno1.Value;
        }
        if (txt_contactno2.Value != "")
        {
            if (cmptercontactno == "")
            {
                cmptercontactno = txt_contactno2.Value;
            }
            else
            {
                cmptercontactno = cmptercontactno + "," + txt_contactno2.Value;
            }
        }

        //Comma Seperator for medianames

         medianame = "";

        if (txtwhomknow1.Value != "")
        {
            medianame = txtwhomknow1.Value;
        }
        if (txtwhomknow2.Value != "")
        {
            if (medianame == "")
            {
                medianame = txtwhomknow2.Value;
            }
            else
            {
                medianame = medianame + "," + txtwhomknow2.Value;
            }
        }
        //Comma Seperator for mediainstitution

         mediainstitution = "";

        if (txtcompinst1.Value != "")
        {
            mediainstitution = txtcompinst1.Value;
        }
        if (txtcompinst2.Value != "")
        {
            if (mediainstitution == "")
            {
                mediainstitution = txtcompinst2.Value;
            }
            else
            {
                mediainstitution = mediainstitution + "," + txtcompinst2.Value;
            }
        }
        //Comma Seperator for mediadesignation

         mediadesignation = "";

        if (txtdesig1.Value != "")
        {
            mediadesignation = txtdesig1.Value;
        }
        if (txtdesig2.Value != "")
        {
            if (mediadesignation == "")
            {
                mediadesignation = txtdesig2.Value;
            }
            else
            {
                mediadesignation = mediadesignation + "," + txtdesig2.Value;
            }
        }
        //Comma Seperator for mediacontactno

         mediacontactno = "";

        if (txtcontactno1.Value != "")
        {
            mediacontactno = txtcontactno1.Value;
        }
        if (txtcontactno2.Value != "")
        {
            if (mediacontactno == "")
            {
                mediacontactno = txtcontactno2.Value;
            }
            else
            {
                mediacontactno = mediacontactno + "," + txtcontactno2.Value;
            }
        }

        

    }



    protected void btnnext3_Click1(object sender, EventArgs e)
    {
        
        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandText = "[spQuickenrollupdate]";
        cmd.CommandType = CommandType.StoredProcedure;
        //table adm_personalparticulars
        cmd.Parameters.AddWithValue("centercode", Session["SA_centre_code"]);
        cmd.Parameters.AddWithValue("enqID", Request.QueryString["end_id"]);
        cmd.Parameters.AddWithValue("firstname", txt_firstname.Text);
        cmd.Parameters.AddWithValue("lastname", txt_lastname.Text);
        cmd.Parameters.AddWithValue("mothertongue", txt_mothertongue.Text);
        cmd.Parameters.AddWithValue("maritalstatus", ddl_maritalstatus.SelectedValue);
        cmd.Parameters.AddWithValue("nationality", txt_nationality.SelectedValue);
        cmd.Parameters.AddWithValue("bloodgroup", ddl_bloodgroup.SelectedValue);
        cmd.Parameters.AddWithValue("altmail", txt_altemail.Text);
        cmd.Parameters.AddWithValue("phone", txt_permanentphone.Text);
        cmd.Parameters.AddWithValue("perphone", txt_permanentphone.Text);
        //table img_enquiryform
        string str = txt_dob.Text;
        string[] split = str.Split('-');
        string datet = split[2] + "-" + split[1] + "-" + split[0];
        cmd.Parameters.AddWithValue("gen", ddl_gender.SelectedValue);
        cmd.Parameters.AddWithValue("highqual",ddlprimary.Value);
        cmd.Parameters.AddWithValue("highmainsub", txt_tenthmajor.Value);
        cmd.Parameters.AddWithValue("highinst", txt_tenthinstitution.Value);
        cmd.Parameters.AddWithValue("highcit", txt_tenthcity.Value);
        cmd.Parameters.AddWithValue("highstate", txt_tenthstate.Value);
        cmd.Parameters.AddWithValue("edob", datet);
        cmd.Parameters.AddWithValue("eperson_mobile", txt_mobile.Text);
        cmd.Parameters.AddWithValue("eperson_altmobile", txt_altmobile.Text);
        cmd.Parameters.AddWithValue("eperson_email", txt_email.Text);
        cmd.Parameters.AddWithValue("epresent_ad", txt_presentaddress.Value);
        cmd.Parameters.AddWithValue("epresent_dis", txt_presentdistrict.Value);
        cmd.Parameters.AddWithValue("epresent_cit", txtpresentcity.Text);
        cmd.Parameters.AddWithValue("epresent_state", txt_presentstate.Value);
        cmd.Parameters.AddWithValue("epresent_pin", txt_presentpin.Value);
        cmd.Parameters.AddWithValue("eperman_ad", txt_permanentaddress.Value);
        cmd.Parameters.AddWithValue("eperman_state", txt_permanentstate.Value);
        cmd.Parameters.AddWithValue("eperman_cit", txtpermanentcity.Text);
        cmd.Parameters.AddWithValue("@eperman_dis", txt_permanentdistrict.Value);
        cmd.Parameters.AddWithValue("@eperman_pin", txt_permanentpin.Value);
        cmd.Parameters.AddWithValue("studentid",Label2.Text);
        //table img_enquiryform1
        cmd.Parameters.AddWithValue("epar_name", txt_guardianname.Text);
        cmd.Parameters.AddWithValue("epar_rel", txt_relationship.Text);
        cmd.Parameters.AddWithValue("epar_mob", txt_guardianmobile.Text);
        cmd.Parameters.AddWithValue("epar_phone", txt_guardianphone.Text);
        cmd.Parameters.AddWithValue("epar_email", txt_guardianemail.Text);
        cmd.Parameters.AddWithValue("epar_cmp", txt_company.Value);
        cmd.Parameters.AddWithValue("epar_status", ddl_empstatus.SelectedValue);
        cmd.Parameters.AddWithValue("epar_desig", txt_designation.Value);
        cmd.Parameters.AddWithValue("epar_wp", txt_workPlace.Value);
        cmd.Parameters.AddWithValue("epar_ind", txt_industryType.Value);
        cmd.Parameters.AddWithValue("epar_income", txt_income.Value);
        cmd.Parameters.AddWithValue("epar_selfemp", txt_selfemployed.Value);
        //table adm_course_empdetails
        cmd.Parameters.AddWithValue("dig_coursename", txt_guardianname.Text);
        cmd.Parameters.AddWithValue("dig_institute", txt_institutename1.Value);
        cmd.Parameters.AddWithValue("dig_city", txt_city1.Value);
        cmd.Parameters.AddWithValue("dig_stscompletion", ddl_digitalstatus.SelectedValue);
        cmd.Parameters.AddWithValue("emp_org", txt_stu_organization.Value);
        cmd.Parameters.AddWithValue("emp_period", txt_stu_employment.Value);
        cmd.Parameters.AddWithValue("emp_degignation", txt_stu_designation.Value);
        cmd.Parameters.AddWithValue("emp_currentsts", ddworkingstatus.SelectedValue);
        cmd.Parameters.AddWithValue("emp_annualincome", txt_stu_annualincome.Value);
        cmd.Parameters.AddWithValue("activity", txt_activity1.Value);
        cmd.Parameters.AddWithValue("participation_level", txt_participation1.SelectedValue);
        cmd.Parameters.AddWithValue("phy_ill", ddl_phydefect.SelectedValue);
        cmd.Parameters.AddWithValue("phy_reason", txt_defectYes.Value);
        cmd.Parameters.AddWithValue("colorblindess", ddl_clrblind.SelectedValue);
        cmd.Parameters.AddWithValue("batchtime", ddlbatchtime.SelectedValue);


    


        Conn.Open();
        cmd.ExecuteNonQuery();
     
        Conn.Close();


        SqlConnection Conn1 = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = Conn1;
        cmd1.CommandText = "addinstall";
        cmd1.CommandType = CommandType.StoredProcedure;

        //table adm_personalparticulars
        cmd1.Parameters.AddWithValue("centercode", Session["SA_centre_code"]);
        cmd1.Parameters.AddWithValue("studentid", Label2.Text);
        cmd1.Parameters.AddWithValue("noofinstall", txt_install.Text);


        Conn1.Open();
        cmd1.ExecuteNonQuery();
        Conn1.Close();

        Response.Redirect("ViewAdmission.aspx");


         
    }

    private void studentid()
    {
        _Qry = "select student_id from adm_personalparticulars where enq_number='" + Request.QueryString["end_id"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            Label2.Text = dt.Rows[0]["student_id"].ToString();
        }
    }
 
}
