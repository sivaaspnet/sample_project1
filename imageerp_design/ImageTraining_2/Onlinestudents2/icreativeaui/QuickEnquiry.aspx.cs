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
using System.Data.SqlClient;
using System.Web.Mail;

public partial class superadmin_AddEnquiry : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5,_Qry6, CentreCount, CentreCode, enqno, enqvalue,  dob1;
    string  studid, radiobtn, dateofissue, dateofexp, dofissue, dofexp;
    string knowimagesep, digitalcourse, digitalinstitute, digitalcity, digitalstatus, plevelactivity, plevelparticipation;
    string cmptername, cmpterindustry, cmpterorganisation, cmpterdesign, cmptercontactno;
    string medianame, mediainstitution, mediadesignation, mediacontactno;

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
            fillcoursedropdown();
            fillcoursedropdown1();
            fillcentre();
            GetSubcategoryDetails();
            getdetails();

            
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
        string js = "";
        js = generatecoursefee();
        Page.RegisterClientScriptBlock("SubcategoryDetail", js);
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
            //    _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.Program,a.course_id,b.Program";
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";

            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";
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
                txt_coursenamee.DataSource = dt;
                txt_coursenamee.DataValueField = "course_id";
                txt_coursenamee.DataTextField = "Program";
                txt_coursenamee.DataBind();
                txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));
            
            
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
              //  _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.Program,a.course_id,b.Program";

                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";

            
            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";
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

    private void insertstudno()
    {
        _Qry = @" select runningInvoiceCentreCode,runningStudentIdType from img_centre_coursefee_details a 
 inner join img_coursedetails b on b.course_id = a.program inner join img_centredetails c
on a.centre_code=c.centre_code where  a.centre_code='" + Session["SA_centre_code"] + "' and a.program='" + txt_coursenamee.SelectedValue + "' and track='" + ddtrack.SelectedItem.Text + "'";
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


        string year2 = System.DateTime.Now.ToString("yy");
       
   

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

        _Qry = "Update  erp_quickreceipt set studentIdNo='" + studid + "' where receiptNo=" + Request.QueryString["recptno"] + " and centrecode='" + Session["SA_centre_code"] + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    }
    private void insertadm3()
    {
        //Comma Seperator for Check box digital Media
        digitalcourse = "";
        if (WebDesigning.Value != "")
        {
            digitalcourse = WebDesigning.Value;

        }
        if (chk_3DAnimation.Value != "")
        {
            if (digitalcourse == "")
            {
                digitalcourse = chk_3DAnimation.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + chk_3DAnimation.Value;
            }
        }
        if (PostProduction.Value != "")
        {
            if (digitalcourse == "")
            {
                digitalcourse = PostProduction.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + PostProduction.Value;
            }
        }
        if (FineArts.Value != "")
        {
            if (digitalcourse == "")
            {
                digitalcourse = FineArts.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + FineArts.Value;
            }
        }
        if (Programming.Value != "")
        {
            if (digitalcourse == "")
            {
                digitalcourse = Programming.Value;
            }
            else
            {
                digitalcourse = digitalcourse + "," + Programming.Value;
            }
        }
        if (check_2DAnimation.Value != "")
        {
            if (digitalcourse == "")
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
            if (digitalcourse == "")
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
            if (digitalcourse == "")
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
            if (digitalcourse == "")
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
            if (digitalcourse == "")
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
            if (digitalcourse == "")
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


    protected void btnsubmit5_Click(object sender, EventArgs e)
    {

        //add enquiry 
          string last_enrollmentid ="";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, "select top 1 student_id from adm_personalparticulars a where centre_code='" + Session["SA_centre_code"] + "' order by Admission_id desc");
        if(dt.Rows.Count>0)
       last_enrollmentid=dt.Rows[0]["student_id"].ToString();
         _Qry = "select count(*) from erp_invoicedetails where studentId='"+last_enrollmentid+"' ";
        int result = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (result > 0)
        {
        _Qry = "Select count(*) from img_enquiryform where  enq_personal_mobile='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "' And  Centre_Code='" + Session["SA_centre_code"] + "' ";

        //Response.Write(_Qry);
        //Response.End();

        int enqcount = 0;

        enqcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        //if (enqcount > 0)
        if (1==2)
        {
            Response.Redirect("ViewEnquiry.aspx");
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
            _Qry2 = "INSERT INTO img_enquiryform (centre_code,enq_number,enq_for , enq_for_others,enq_reason , enq_aboutimage , enq_aboutimage_others , gender , enq_high_qualification , enq_high_mainsubject , enq_high_institution , enq_high_city , enq_high_state , enq_high_status , enq_animation_inst , enq_animation_branch , enq_animation_status , enq_personal_name , enq_personal_dob , enq_personal_mobile , enq_personal_altmobile , enq_personal_email , enq_personal_phone , enq_present_address , enq_present_city , enq_present_district , enq_present_state , enq_present_pincode , enq_permanant_address , enq_permanant_city , enq_permanant_state , enq_permanant_district , enq_permanant_pincode,enq_lastname,enq_Bloodgroup,enq_martialstatus,enq_mothertongue,enq_Nationality )VALUES ('" + Session["SA_centre_code"] + "','" + Session["Enqno"] + "','" + ddl_enquiryfor.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtenqothers.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtreason.Text) + "','" + ddl_aboutimage.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_abt_image.Text) + "','" + ddl_gender.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtqualification.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmainsub.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtschoolcolname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtstate.Text) + "','" + ddl_completionstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstitute.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtbranch.Text) + "','" + ddl_animationstatus.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtname.Text) + "','" + apdate + "' ,'" + MVC.CommonFunction.ReplaceQuoteWithTild(txtmobile.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtaltmobile.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtemail.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtphone.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentaddress.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentdistrict.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentstate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpresentpincode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentaddress.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentcity.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentstate.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentdistrict.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermanentpincode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtLname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_bloodgroup.SelectedValue) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_maritalstatus.SelectedValue) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_mothertongue.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Nationality.SelectedValue) + "') ";

            //Response.Write(_Qry2);
            //Response.End();


            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);

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

        }



        /// admisssion  form
        /// 






        _Qry = "Select count(*) from adm_generalinfo where enq_number='" + Session["Enqno"] + "'";

        int checkcount = 0;
        checkcount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        if (checkcount > 0)
        {
            Response.Redirect("quickpreInvoice.aspx?studid=" + Session["Stud_ID"] + "&Track=" + ddtrack.SelectedValue + "&receiptno=" + Request.QueryString["recptno"] + "");

        }
        else
        {


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
            cmd.Parameters.AddWithValue("enqID", Session["Enqno"]);
            cmd.Parameters.AddWithValue("fname", txtname.Text);
            cmd.Parameters.AddWithValue("lname", txtLname.Text);
            cmd.Parameters.AddWithValue("mtongue", txt_mothertongue.Text);
            cmd.Parameters.AddWithValue("mstatus", ddl_maritalstatus.SelectedValue);
            cmd.Parameters.AddWithValue("nation", txt_Nationality.SelectedValue);
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
            cmd1.Parameters.AddWithValue("enqno", Session["Enqno"]);
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
            cmd1.Parameters.AddWithValue("student_type", txt_Nationality.SelectedValue);
            cmd1.Parameters.AddWithValue("nri_country", "");
            cmd1.Parameters.AddWithValue("nri_passport", "");
            cmd1.Parameters.AddWithValue("nri_placeofissue", "");
            cmd1.Parameters.AddWithValue("adm5", Session["adm_id"]);
            cmd1.Parameters.AddWithValue("std_id5", Session["Stud_ID"]);
            cmd1.Parameters.AddWithValue("c_code5", Session["SA_centre_code"]);
            cmd1.Parameters.AddWithValue("enq_id7", Session["Enqno"]);
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

            string dob = txtdob.Text;
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
            cmd2.Parameters.AddWithValue("highqual", txtqualification.Text);
            cmd2.Parameters.AddWithValue("highmainsub", txtmainsub.Text);
            cmd2.Parameters.AddWithValue("highinst", txtschoolcolname.Text);
            cmd2.Parameters.AddWithValue("highcit", txtcity.Text);
            cmd2.Parameters.AddWithValue("highstate", txtstate.Text);

            cmd2.Parameters.AddWithValue("edob", apdate);
            cmd2.Parameters.AddWithValue("eperson_mobile", txtmobile.Text);
            cmd2.Parameters.AddWithValue("eperson_altmobile", txt_altmobile.Text);
            cmd2.Parameters.AddWithValue("eperson_email", txtemail.Text);
            cmd2.Parameters.AddWithValue("epresent_ad", txtpresentaddress.Text);
            cmd2.Parameters.AddWithValue("epresent_dis", txtpresentdistrict.Text);
            cmd2.Parameters.AddWithValue("epresent_cit", txtpresentcity.Text);
            cmd2.Parameters.AddWithValue("epresent_state", txtpresentstate.Text);
            cmd2.Parameters.AddWithValue("epresent_pin", txtpresentpincode.Text);
            cmd2.Parameters.AddWithValue("eperman_ad", txtpermanentaddress.Text);
            cmd2.Parameters.AddWithValue("eperman_dis", txtpermanentdistrict.Text);
            cmd2.Parameters.AddWithValue("eperman_cit", txtpermanentcity.Text);
            cmd2.Parameters.AddWithValue("eperman_state", txtpermanentstate.Text);
            cmd2.Parameters.AddWithValue("eperman_pin", txtpermanentpincode.Text);
            cmd2.Parameters.AddWithValue("enqID1", Session["Enqno"]);
            cmd2.Parameters.AddWithValue("epar_name", txtparentname.Text);
            cmd2.Parameters.AddWithValue("epar_rel", txtparentrelation.SelectedValue);
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

            _Qry = "Update  img_enquiryform1 set enq_enqstatus='Enrolled' where enq_number='" + Session["Enqno"] + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = "Update  adm_personalparticulars set Bookreceived='No',DateMod=getdate() where admission_id=" + admissionid + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = "Update  adm_generalinfo set Enrolled_By='" + Session["SA_Username"].ToString() + "' where admission_id=" + admissionid + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);


            Response.Redirect("quickpreInvoice.aspx?studid=" + Session["Stud_ID"] + "&Track=" + ddtrack.SelectedValue + "&receiptno=" + Request.QueryString["recptno"] + "");
        }



        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Update Invoice of StudentId  " + last_enrollmentid + "  Properly.....' )", true);
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



            enqcount = Convert.ToInt32(enqvalue) + 1;

            int month3 = System.DateTime.Now.Month;

            enqno = "Enq" + "-" + Session["SA_centre_code"] + "-" + month3 + "-" + enqcount;

            Session["Enqno"] = enqno;

            _Qry6 = "update img_centredetails set Enquiry_Count='" + enqcount + "' where centre_code='" + Session["SA_centre_code"] + "'";

            //Response.Write(_Qry6);
            //Response.End();

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry6);

        }
    }

    private void getdetails()
    {
_Qry = @"select contactno,sourse,profile,a.ReceiptNo,c.studentname,studentid,c.coursecode from 
erp_receiptdetails a inner join erp_quickreceipt c on c.receiptNo=a.receiptno inner join img_coursedetails on 
course_id=c.coursecode where c.coursecode='" + Request.QueryString["cid"] + "' and a.studentid='" + Request.QueryString["studid"] + "' and  c.centrecode='" + Session["SA_centre_code"] + "' and a.receiptno='" + Request.QueryString["recptno"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);


        if(dt.Rows.Count>0)
        {
            ddl_aboutimage.SelectedValue = dt.Rows[0]["sourse"].ToString();
            ddl_profile.SelectedValue = dt.Rows[0]["profile"].ToString();
            txtmobile.Text = dt.Rows[0]["contactno"].ToString();
            txtname.Text = dt.Rows[0]["studentname"].ToString();
            txt_courseasked.SelectedValue = dt.Rows[0]["coursecode"].ToString();
            txt_coursepositioned.SelectedValue = dt.Rows[0]["coursecode"].ToString();
            txt_coursenamee.SelectedValue = dt.Rows[0]["coursecode"].ToString();
        }
    }

   
}
