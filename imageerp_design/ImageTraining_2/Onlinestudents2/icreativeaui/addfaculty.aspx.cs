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

public partial class superadmin_addfaculty : System.Web.UI.Page
{
    string _Qry, faculty_id, CentreCount,os,pro_languages,applications,db,gui,webdev,multi,authour,conversions,miscell,fac_idd;
    string othersft;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
     insertfacultydetails();
    }
    private void insertfacultydetails()
    {
        //ICH1011
        _Qry = "select count(*)+1 as cnt from faculty_details where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CentreCount = dt.Rows[0]["cnt"].ToString();
        }
        else
        {
            CentreCount = "1";
        }
        string centr_cod = Session["SA_centre_code"].ToString();
        //string substr = centr_cod.Substring(0, 6);

        faculty_id = "F-" + centr_cod+"-"+ CentreCount;
        fac_idd = faculty_id;
   
        //Softwares Known    
        int i;
        for (i = 0; i <= ddl_OS.Items.Count - 1; i++)
        {
            if (ddl_OS.Items[i].Selected)
            {
                os = os + ddl_OS.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_proglanguages.Items.Count - 1; i++)
        {
            if (ddl_proglanguages.Items[i].Selected)
            {
                pro_languages = pro_languages + ddl_proglanguages.Items[i].Text + ",";
            }
        }

        for (i = 0; i <= ddl_applications.Items.Count - 1; i++)
        {
            if (ddl_applications.Items[i].Selected)
            {
                applications = applications + ddl_applications.Items[i].Text + ",";
            }
        }

        for (i = 0; i <= ddl_database.Items.Count - 1; i++)
        {
            if (ddl_database.Items[i].Selected)
            {
                db = db + ddl_database.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_GUI.Items.Count - 1; i++)
        {
            if (ddl_GUI.Items[i].Selected)
            {
                gui = gui + ddl_GUI.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_webdevelop.Items.Count - 1; i++)
        {
            if (ddl_webdevelop.Items[i].Selected)
            {
                webdev = webdev + ddl_webdevelop.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_multimedia.Items.Count - 1; i++)
        {
            if (ddl_multimedia.Items[i].Selected)
            {
                multi = multi + ddl_multimedia.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_authoring.Items.Count - 1; i++)
        {
            if (ddl_authoring.Items[i].Selected)
            {
                authour = authour + ddl_authoring.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_conversions.Items.Count - 1; i++)
        {
            if (ddl_conversions.Items[i].Selected)
            {
                conversions = conversions + ddl_conversions.Items[i].Text + ",";
            }
        }
        for (i = 0; i <= ddl_miscellaneous.Items.Count - 1; i++)
        {
            if (ddl_miscellaneous.Items[i].Selected)
            {
                miscell = miscell + ddl_miscellaneous.Items[i].Text + ",";
            }
        }
        othersft = "";
        if (sftothers.Text != "")
        {
            othersft = othersft + "," + sftothers.Text;
        }
        else
        {
            othersft = othersft;
        }

        string dateofbirth = txt_dob.Text;
        string[] splitdob = dateofbirth.Split('-');
        string datetdob = splitdob[2] + "-" + splitdob[1] + "-" + splitdob[0];

        string str = txt_fromdate.Text;
        string[] splitf = str.Split('-');
        string datef = splitf[2] + "-" + splitf[1] + "-" + splitf[0];

        string strt = txt_todate.Text;
        string[] splitt = strt.Split('-');
        string datet = splitt[2] + "-" + splitt[1] + "-" + splitt[0];
        //Insert faculty_details
        _Qry = "INSERT INTO faculty_details (faculty_id , centre_code , fac_name , fac_dob , fac_permanentaddress , fac_tempaddress , fac_mobile , fac_landline , fac_email , fac_exp_company , fac_exp_desg , fac_exp_fromdate , fac_exp_todate , fac_exp_description , fac_exp_reason , fac_qua_Institute , fac_qua_course , fac_qua_subject , fac_percentage , fac_qua_yearofcompletion , fac_os , fac_pl , fac_applications , fac_database , fac_gui , fac_web , fac_multimedia , fac_authoring , fac_conversions , fac_miscellaneous ,Othersftware, dateins )VALUES ('" + fac_idd + "', '" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_facultyname.Text) + "', '" + datetdob + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_per_address.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_temp_address.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_mobile.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_landline.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_email.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_company.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_designation.Text) + "', '" + datef + "', '" + datet + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_description.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_reason.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_institute.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_course.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_subject.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_percentage.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_yearofcompletion.Text) + "', '" + os + "' , '" + pro_languages + "' , '" + applications + "' , '" + db + "' , '" + gui + "' , '" + webdev + "' , '" + multi + "' , '" + authour + "' , '" + conversions + "' , '" + miscell + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(othersft) + "',getdate())";

        //Response.Write(_Qry);
        //Response.End();
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
        lbl_errormsg.Text = "Faculty details added sucessfully";
        Response.Redirect("Thankyoufaculty.aspx");
        refresh();
    }
    void refresh()
    {
        txt_facultyname.Text = "";
        txt_dob.Text = "";
        txt_per_address.Text="";
        txt_temp_address.Text="";
        txt_mobile.Text = "";
        txt_landline.Text = "";
        txt_email.Text = "";

        txt_company.Text = "";
        txt_designation.Text = "";
        txt_fromdate.Text = "";
        txt_todate.Text = "";
        txt_description.Text = "";
        txt_reason.Text = "";

        txt_institute.Text = "";
        txt_course.Text = "";
        txt_subject.Text = "";
        txt_percentage.Text = "";
        txt_yearofcompletion.Text = "";


    }
    /* else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").value=="";
             alert("Please enter landline number");
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").value!="" && document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").value.length<11)
         {
             alert("Invalid landline number(Must have 11 digits)")
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_landline").style.backgroundColor="#e8ebd9";
             return false;
         }   */

}
