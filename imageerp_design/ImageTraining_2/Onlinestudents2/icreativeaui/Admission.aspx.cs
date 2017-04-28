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
            hdncentrecode.Value = Session["SA_centre_code"].ToString();

            fillcoursedropdown();
            GetSubcategoryDetails();

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
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
            }
            else
            {
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
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
                    jss += "coursetrack[" + j + "]['coursetype']='" + dt1.Rows[j]["coursetype"].ToString() + "'\n";
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
                qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='ICH-101'";
            }
            else
            {
                qry = "SElect program,lump_sum,instal_amount,tax,noofinstall  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1";
            }
            qry = "select program,lump_sum,instal_amount,tax,noofinstall,track  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1 ";


            //Response.Write(qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i, normalval = 0, fastval = 0;
                js = "<script language='javascript' type='text/javascript'>\n";
                js += "var courseFeesfast=new Array();\n";
                js += "var courseFeesnormal=new Array();\n";
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["track"].ToString().ToLower() == "fast")
                    {
                        js += "courseFeesfast[" + fastval + "]=new Array();\n";
                        js += "courseFeesfast[" + fastval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        fastval += 1;
                    }
                    if (dt.Rows[i]["track"].ToString().ToLower() == "normal")
                    {
                        js += "courseFeesnormal[" + normalval + "]=new Array();\n";
                        js += "courseFeesnormal[" + normalval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        normalval += 1;
                    }
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
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.coursename,a.course_id,b.Program,a.Program";
            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";
            }

            _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            txt_coursenamee.DataSource = dt;
            txt_coursenamee.DataValueField = "course_id";
            txt_coursenamee.DataTextField = "Program";
            txt_coursenamee.DataBind();
            txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));
        }
    }


    private void selectfromenquiry()
    {

        //Select Query of img_enquiryform

        _Qry = "SELECT enq_personal_name,enq_lastname,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality,gender,enq_high_qualification,enq_high_mainsubject,enq_high_institution,enq_high_city,enq_high_state,enq_personal_dob, enq_personal_mobile,enq_personal_phone, enq_personal_altmobile, enq_personal_email, enq_present_address, enq_present_district, enq_present_state, enq_present_pincode, enq_permanant_address, enq_permanant_state, enq_permanant_district, enq_permanant_pincode,enq_present_city,enq_permanant_city from img_enquiryform where enq_number='" + Request.QueryString["end_id"] + "'";
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
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

            if (dt.Rows[0]["enq_personal_dob"].ToString() != "")
            {
                string dob = dt.Rows[0]["enq_personal_dob"].ToString();
                string[] strSplitArr = dob.Split(' ');
                string dob1 = strSplitArr[0].ToString();

                string dob2 = dob1;
                string[] strSplitArr1 = dob2.Split('/');

                string smonth = strSplitArr1[0].ToString();
                string sdate = strSplitArr1[1].ToString();
                string syear = strSplitArr1[2].ToString();

                string apdate = sdate + "-" + smonth + "-" + syear;
                txt_dob.Text = apdate;
            }
            else
            {
                txt_dob.Text = "";
            }

            
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
        dt1=MVC.DataAccess.ExecuteDataTable(_Qry1);
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

            txt_coursenamee.SelectedValue = dt1.Rows[0]["enq_Coursepositioned"].ToString();
        }
    }


    private void insertstudno()
    {
        _Qry = @" select runningInvoiceCentreCode,runningStudentIdType from img_centre_coursefee_details a 
 inner join img_coursedetails b on b.course_id = a.program inner join img_centredetails c
on a.centre_code=c.centre_code where  a.centre_code='" + Session["SA_centre_code"] + "'  and a.program='" + txt_coursenamee.SelectedValue + "' and track='" + ddtrack.SelectedItem.Text + "'";
   
        DataTable invoice = MVC.DataAccess.ExecuteDataTable(_Qry);
        string centreCodeofRunningInvoice = invoice.Rows[0]["runningInvoiceCentreCode"].ToString();

        _Qry = "Select InvoiceCount+1 as cnt from Invoice_Count where centre_code='" + centreCodeofRunningInvoice + "'";
       
        //_Qry = "select Invoice_No+1 as cnt from adm_studentid where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CentreCount = dt.Rows[0]["cnt"].ToString();
            _Qry = "Update Invoice_Count set InvoiceCount=InvoiceCount+1 where centre_code='" + centreCodeofRunningInvoice + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        else
        {
            CentreCount = "3000";
            _Qry = "Insert into Invoice_Count Values('" + CentreCount + "','" + invoice.Rows[0]["runningInvoiceCentreCode"].ToString() + "')";
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

        string mm3 = "";
        if (month3 < 10)
        {
            mm3 = "0" + month3.ToString();
        }
        else
        {
            mm3 = month3.ToString();
        }

        string year2=System.DateTime.Now.ToString("yy");

        string studentid = invoice.Rows[0]["runningStudentIdType"].ToString();
        if (studentid == "monthyear")
        {
           
            studid = centreCodeofRunningInvoice + "-" + mm3 + year2 + "-" + CentreCount;
        }
        else if (studentid == "month")
        {

           
            studid = centreCodeofRunningInvoice + "-" + mm3 + "-" + CentreCount;
        }
        else
        {
            studid = centreCodeofRunningInvoice + "-" + mm3 + "-" + CentreCount;
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
         string last_enrollmentid ="";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, "select top 1 student_id from adm_personalparticulars a where centre_code='" + Session["SA_centre_code"] + "' order by Admission_id desc");
        if(dt.Rows.Count>0)
       last_enrollmentid=dt.Rows[0]["student_id"].ToString();
         _Qry = "select count(*) from erp_invoicedetails where studentId='"+last_enrollmentid+"' ";
        int result = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (result > 0)
        {
            _Qry = "Select count(*) from adm_generalinfo where enq_number='" + Request.QueryString["end_id"] + "'";

            int checkcount = 0;
            checkcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (checkcount > 0)
            {
                Response.Redirect("preInvoicedetail.aspx?studid=" + Session["Stud_ID"] + "&Track=" + ddtrack.SelectedValue + "");
            }
            else
            {

                _Qry = @"select count(*) from img_enquiryform im1 inner join img_enquiryform1 im2 on im1.enq_number=im2.enq_number 
inner join adm_personalparticulars adm on adm.enq_number=im2.enq_number  where
enq_personal_mobile='" + txt_mobile.Text + "' and im1.enq_personal_name='" + txt_firstname.Text + "' and im1.centre_code='" + Session["SA_centre_code"] + "'";
                int checkcount1 = 0;
                checkcount1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                if (checkcount1 > 0)
                {
                  

        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('Student Already Enrolled..!');</script>";
        page.Controls.Add(lbl);
        Response.Redirect("ViewAdmission.aspx");
                }
                else
                {

                    //if (radiobtnindia1.Checked == true)
                    //{
                    //    radiobtn =radiobtnindia1.Text;

                    //}
                    //else
                    //{
                    //    radiobtn = radiobtnnri.Text;
                    //}
                    radiobtn = txt_nationality.SelectedValue;
                    //Converting the dateofissue to db format
                    //if (txt_dateofissue.Text != "")
                    //{
                    //    dateofissue = txt_dateofissue.Text;

                    //    string[] strsplit = dateofissue.Split(' ');
                    //    string dissue = strsplit[0].ToString();

                    //    string dob4 = dissue;

                    //    string[] strSplita = dob4.Split('-');

                    //    string sdate2 = strSplita[0].ToString();
                    //    string smonth2 = strSplita[1].ToString();
                    //    string syear2 = strSplita[2].ToString();

                    //    dofissue = syear2 + "-" + smonth2 + "-" + sdate2;
                    //}

                    ////Converting the dateofexpiry to db format
                    //if (txt_dateofexpiry.Text != "")
                    //{
                    //    dateofexp = txt_dateofexpiry.Text;

                    //    string[] splitstr = dateofexp.Split(' ');
                    //    string dexp = splitstr[0].ToString();

                    //    string dob3 = dexp;
                    //    string[] splitstra = dob3.Split('-');

                    //    string sdate1 = splitstra[0].ToString();
                    //    string smonth1 = splitstra[1].ToString();
                    //    string syear1 = splitstra[2].ToString();

                    //    dofexp = syear1 + "-" + smonth1 + "-" + sdate1;
                    //}

                    //Inserting the Student No 
                    insertstudno();

                    //Comma seperator in adm_generalinfo table

                    insertadm4();

                    //Comma seperator in adm_course_empdetails

                    insertadm3();

                    //INSERT SP for table  adm_studentid and adm_personalparticulars

                    //Response.Write("Value Is:" + hdncou_id.Value);
                    //Response.End();
                    SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "admissionsp";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("sid", Session["Stud_ID"]);
                    cmd.Parameters.AddWithValue("ccode", Session["SA_centre_code"]);

                    cmd.Parameters.AddWithValue("s1id", Session["Stud_ID"]);
                    cmd.Parameters.AddWithValue("ccode1", Session["SA_centre_code"]);
                    cmd.Parameters.AddWithValue("enqID", Request.QueryString["end_id"]);
                    cmd.Parameters.AddWithValue("fname", txt_firstname.Text);
                    cmd.Parameters.AddWithValue("lname", txt_lastname.Text);
                    cmd.Parameters.AddWithValue("mtongue", txt_mothertongue.Text);
                    cmd.Parameters.AddWithValue("mstatus", ddl_maritalstatus.SelectedValue);
                    cmd.Parameters.AddWithValue("nation", txt_nationality.SelectedValue);
                    cmd.Parameters.AddWithValue("bloodgp", ddl_bloodgroup.SelectedValue);
                    cmd.Parameters.AddWithValue("altmail", txt_altemail.Text);
                    cmd.Parameters.AddWithValue("prephone", txt_permanentphone.Text);
                    cmd.Parameters.AddWithValue("permanphone", txt_permanentphone.Text);
                    cmd.Parameters.AddWithValue("invno", Session["Invoice_no"]);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                    _Qry3 = "SELECT Top 1 Admission_id FROM adm_personalparticulars ORDER BY Admission_id DESC ";
                    DataTable dt1 = new DataTable();
                    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry3);
                    Session["adm_id"] = dt1.Rows[0][0].ToString();


                    SqlConnection Conn1 = new SqlConnection(MVC.DataAccess.ConnectionString);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = Conn1;
                    cmd1.CommandText = "admissionsp1";
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.AddWithValue("adm_id2", Session["adm_id"]);
                    cmd1.Parameters.AddWithValue("std_id1", Session["Stud_ID"]);
                    cmd1.Parameters.AddWithValue("c_code3", Session["SA_centre_code"]);
                    cmd1.Parameters.AddWithValue("enqno", Request.QueryString["end_id"]);
                    cmd1.Parameters.AddWithValue("enqreason", txtarea_reason.Text);
                    cmd1.Parameters.AddWithValue("enqwhen", knowimagesep);
                    cmd1.Parameters.AddWithValue("enqabt", txtarea_heardimage.Text);
                    cmd1.Parameters.AddWithValue("know_image", txtarea_howuknw.Text);
                    cmd1.Parameters.AddWithValue("rec_name", cmptername);
                    cmd1.Parameters.AddWithValue("rec_ind", cmpterindustry);
                    cmd1.Parameters.AddWithValue("rec_org", cmpterorganisation);
                    cmd1.Parameters.AddWithValue("rec_desig", cmpterdesign);
                    cmd1.Parameters.AddWithValue("rec_cno", cmptercontactno);
                    cmd1.Parameters.AddWithValue("media_name", medianame);
                    cmd1.Parameters.AddWithValue("media_org", mediainstitution);
                    cmd1.Parameters.AddWithValue("media_desg", mediadesignation);
                    cmd1.Parameters.AddWithValue("media_cno", mediacontactno);
                    cmd1.Parameters.AddWithValue("course_name", hdncou_id.Value);
                    cmd1.Parameters.AddWithValue("track", ddtrack.SelectedValue);
                    cmd1.Parameters.AddWithValue("track1", ddtrack.SelectedValue);
                    cmd1.Parameters.AddWithValue("pay", ddl_payment.SelectedValue);
                    cmd1.Parameters.AddWithValue("paycfee", hdnlumpamt.Value);
                    cmd1.Parameters.AddWithValue("payinstall", hdnlumpamt.Value);
                    cmd1.Parameters.AddWithValue("paynoofinstall", txt_instalamt1.Text);
                    cmd1.Parameters.AddWithValue("payinitial", txt_lumpinitial.Text);
                    cmd1.Parameters.AddWithValue("batchtime", ddlbatchtime.SelectedValue);
                    cmd1.Parameters.AddWithValue("paymode", ddlpaymentmode.SelectedValue);
                    cmd1.Parameters.AddWithValue("creditno", txtchequeno.Text);
                    cmd1.Parameters.AddWithValue("Bankname", txtbankname.Text);
                    cmd1.Parameters.AddWithValue("fundplan", ddl_fundplann.SelectedValue);
                    cmd1.Parameters.AddWithValue("fundloan", txt_loan.Value);
                    cmd1.Parameters.AddWithValue("fundsponser", txt_sponsor.Value);
                    cmd1.Parameters.AddWithValue("student_type", radiobtn);
                    cmd1.Parameters.AddWithValue("nri_country", "");
                    cmd1.Parameters.AddWithValue("nri_passport", "");
                    cmd1.Parameters.AddWithValue("nri_placeofissue", "");
                    cmd1.Parameters.AddWithValue("adm5", Session["adm_id"]);
                    cmd1.Parameters.AddWithValue("std_id5", Session["Stud_ID"]);
                    cmd1.Parameters.AddWithValue("c_code5", Session["SA_centre_code"]);
                    cmd1.Parameters.AddWithValue("enq_id7", Request.QueryString["end_id"]);
                    cmd1.Parameters.AddWithValue("dm_cname", digitalcourse);
                    cmd1.Parameters.AddWithValue("dm_inst", digitalinstitute);
                    cmd1.Parameters.AddWithValue("dm_city", digitalcity);
                    cmd1.Parameters.AddWithValue("dm_status", digitalstatus);
                    cmd1.Parameters.AddWithValue("emporg", txt_stu_organization.Value);
                    cmd1.Parameters.AddWithValue("empperiod", txt_stu_employment.Value);
                    cmd1.Parameters.AddWithValue("empdesg", txt_stu_designation.Value);
                    cmd1.Parameters.AddWithValue("empstatus", ddworkingstatus.SelectedValue);
                    cmd1.Parameters.AddWithValue("empa_income", txt_stu_annualincome.Value);
                    cmd1.Parameters.AddWithValue("activity", plevelactivity);
                    cmd1.Parameters.AddWithValue("p_level", plevelparticipation);
                    cmd1.Parameters.AddWithValue("p_ill", ddl_phydefect.SelectedValue);
                    cmd1.Parameters.AddWithValue("p_illreason", txt_defectYes.Value);
                    cmd1.Parameters.AddWithValue("color_blind", ddl_clrblind.SelectedValue);
                    Conn1.Open();
                    cmd1.ExecuteNonQuery();
                    Conn1.Close();

                    //Converting the form format of dob to database format

                    string dob = txt_dob.Text;
                    string[] strSplitArr = dob.Split(' ');
                    string dob1 = strSplitArr[0].ToString();

                    string dob2 = dob1;

                    string[] strSplitArr1 = dob2.Split('-');
                    string dday = strSplitArr1[0].ToString();
                    string dmonth = strSplitArr1[1].ToString();
                    string dyear = strSplitArr1[2].ToString();

                    string apdate = dyear + "-" + dmonth + "-" + dday;



                    //SP for Update in enquiry table

                    SqlConnection Conn2 = new SqlConnection(MVC.DataAccess.ConnectionString);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Conn2;
                    cmd2.CommandText = "admissionupdate";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("gen", ddl_gender.SelectedValue);
                    cmd2.Parameters.AddWithValue("highqual", ddlprimary.Value);
                    cmd2.Parameters.AddWithValue("highmainsub", txt_tenthmajor.Value);
                    cmd2.Parameters.AddWithValue("highinst", txt_tenthinstitution.Value);
                    cmd2.Parameters.AddWithValue("highcit", txt_tenthcity.Value);
                    cmd2.Parameters.AddWithValue("highstate", txt_tenthstate.Value);

                    cmd2.Parameters.AddWithValue("edob", apdate);
                    cmd2.Parameters.AddWithValue("eperson_mobile", txt_mobile.Text);
                    cmd2.Parameters.AddWithValue("eperson_altmobile", txt_altmobile.Text);
                    cmd2.Parameters.AddWithValue("eperson_email", txt_email.Text);
                    cmd2.Parameters.AddWithValue("epresent_ad", txt_presentaddress.Value);
                    cmd2.Parameters.AddWithValue("epresent_dis", txt_presentdistrict.Value);
                    cmd2.Parameters.AddWithValue("epresent_cit", txtpresentcity.Text);
                    cmd2.Parameters.AddWithValue("epresent_state", txt_presentstate.Value);
                    cmd2.Parameters.AddWithValue("epresent_pin", txt_presentpin.Value);
                    cmd2.Parameters.AddWithValue("eperman_ad", txt_permanentaddress.Value);
                    cmd2.Parameters.AddWithValue("eperman_dis", txt_permanentdistrict.Value);
                    cmd2.Parameters.AddWithValue("eperman_cit", txtpermanentcity.Text);
                    cmd2.Parameters.AddWithValue("eperman_state", txt_permanentstate.Value);
                    cmd2.Parameters.AddWithValue("eperman_pin", txt_permanentpin.Value);
                    cmd2.Parameters.AddWithValue("enqID1", Request.QueryString["end_id"]);
                    cmd2.Parameters.AddWithValue("epar_name", txt_guardianname.Text);
                    cmd2.Parameters.AddWithValue("epar_rel", txt_relationship.Text);
                    cmd2.Parameters.AddWithValue("epar_mob", txt_guardianmobile.Text);
                    cmd2.Parameters.AddWithValue("epar_phone", txt_guardianphone.Text);
                    cmd2.Parameters.AddWithValue("epar_email", txt_guardianemail.Text);
                    cmd2.Parameters.AddWithValue("epar_cmp", txt_company.Value);
                    cmd2.Parameters.AddWithValue("epar_status", ddl_empstatus.SelectedValue);
                    cmd2.Parameters.AddWithValue("epar_desig", txt_designation.Value);
                    cmd2.Parameters.AddWithValue("epar_wp", txt_workPlace.Value);
                    cmd2.Parameters.AddWithValue("epar_ind", txt_industryType.Value);
                    cmd2.Parameters.AddWithValue("epar_income", txt_income.Value);
                    cmd2.Parameters.AddWithValue("epar_selfemp", txt_selfemployed.Value);


                    Conn2.Open();
                    cmd2.ExecuteNonQuery();
                    Conn2.Close();

                    //_Qry = "insert into adm_generalinfo(student_type,nri_country,nri_passportno,nri_placeofissue,nri_dateofissue,nri_dateofexp)values('" + radiobtnindia1.Text + "','" + txt_countryofresi.Text + "','" + txt_passportnum.Text + "','" + txt_placeofiisue.Text + "',str_to_date('" + txt_dateofissue.Text + "','%d-%m-%Y'),str_to_date('" + txt_dateofexpiry.Text + "','%d-%m-%Y'))";
                    //obj.executenonquery(_Qry);

                    _Qry = "Select Top 1 admission_id from adm_personalparticulars order by admission_id Desc ";

                    int admissionid = 0;
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                    if (dr.HasRows)
                    {
                        dr.Read();
                        admissionid = Convert.ToInt32(dr["admission_id"]);
                        dr.Close();
                    }

                    _Qry = "Update  img_enquiryform1 set enq_enqstatus='Enrolled' where enq_number='" + Request.QueryString["end_id"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "Update  adm_personalparticulars set Bookreceived='No',DateMod=getdate() where admission_id=" + admissionid + "";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "Update  adm_generalinfo set Enrolled_By='" + Session["SA_username"].ToString() + "' where admission_id=" + admissionid + "";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);



                    Response.Redirect("preInvoicedetail.aspx?studid=" + Session["Stud_ID"] + "&Track=" + ddtrack.SelectedValue + "");
                }
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Update Invoice of StudentId  " + last_enrollmentid + "  Properly.....' )", true);

        }
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

        _Qry = "select Coursename from img_coursedetails where Course_ID=" + hdncou_id.Value + "";
        DataTable dtcour = MVC.DataAccess.ExecuteDataTable(_Qry);

        //SendMail.From = "universityimage.project@gmail.com";
        _Qry = "select enq_personal_email from img_enquiryform where  enq_number= '" + Request.QueryString["end_id"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string send = dt.Rows[0]["enq_personal_email"].ToString();
            SendMail.To = send;
            SendMail.Subject = "Successfully Registered";
            SendMail.BodyFormat = MailFormat.Html;
            string GetTxt = "Thank you for joining " + dtcour.Rows[0]["Coursename"].ToString() + " In Image";
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

        _Qry = "select Coursename from img_coursedetails where Course_ID=" + hdncou_id.Value + "";
        DataTable dtcour = MVC.DataAccess.ExecuteDataTable(_Qry);

        _Qry = "select centre_useremail from img_centrelogin  where centre_code='" + Session["SA_centre_code"] + "' and role='Technical Head' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string send = dt.Rows[0]["centre_useremail"].ToString();
            SendMail.To = send;
            SendMail.Subject = "Student Enrolled";
            SendMail.BodyFormat = MailFormat.Html;
            string GetTxt = "The Student " + txt_firstname.Text + " (" + Session["Stud_ID"].ToString() + ") " + " Has Got Enrolled For " + dtcour.Rows[0]["Coursename"].ToString() + "";
            SendMail.Body = GetTxt;
            SmtpMail.Send(SendMail);
        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    double amt_ex_initial = Convert.ToDouble(lbllumpamt.Value) - Convert.ToDouble(txt_lumpinitial.Text);
    //    double noofinstallments = Convert.ToDouble(txt_instalamt1.Text);
    //    double monthlyinstall = amt_ex_initial / noofinstallments;
    //    txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
    //}
}
