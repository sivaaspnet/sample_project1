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
using System.Collections.Generic;
using System.Web.Mail;

public partial class Onlinestudents2_Default2 : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1;
    string inv_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        if (!IsPostBack)
        {



      
        //  fillcoursedropdown();
          GetSubcategoryDetails();
           
        }

    }
   
    
    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
       
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
                qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";
            }
            qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "'";


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
                    js += "courseFees[" + i + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";


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

    




    protected void btnsubmit5_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            string str = txt_coursedatedate.Text;
            string[] split = str.Split('-');
            string datet = split[2] + "-" + split[1] + "-" + split[0];
            string str1 = txt_installdate.Text;
            string[] split1 = str1.Split('-');
            string datet2 = split1[2] + "-" + split1[1] + "-" + split1[0];
            cmd.CommandText = "[sp_upgrade]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
            cmd.Parameters.AddWithValue("studentid",txt_studentid.Text);
            cmd.Parameters.AddWithValue("course", txt_coursenamee.SelectedValue);
            cmd.Parameters.AddWithValue("track", ddtrack.SelectedValue);
            cmd.Parameters.AddWithValue("courseamt", txt_lumpamt.Text);
            cmd.Parameters.AddWithValue("installmenttype", ddl_payment.SelectedValue);
            cmd.Parameters.AddWithValue("initialAmt", txt_netamount.Text);
            cmd.Parameters.AddWithValue("taxinitialAmt", txt_vat.Text);
            cmd.Parameters.AddWithValue("totalinitialAmt", netamount.Value);
            cmd.Parameters.AddWithValue("noofInstallment", txt_instalamt1.Text);
            cmd.Parameters.AddWithValue("cashType", ddlpaymentmode.SelectedValue);
            cmd.Parameters.AddWithValue("bankname", txtbankname.Text);
            cmd.Parameters.AddWithValue("chequeNo", txtchequeno.Text);
            cmd.Parameters.AddWithValue("chequeDt", txtchequeno.Text);
            cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
            cmd.Parameters.AddWithValue("installmentDate", datet2);
            cmd.Parameters.AddWithValue("coursestartdate", datet);
            cmd.Parameters.Add("@invoiceNo", SqlDbType.VarChar, 50);
            cmd.Parameters["@invoiceNo"].Direction = ParameterDirection.Output;
            Conn.Open();
            cmd.ExecuteNonQuery();
            inv_id = (string)cmd.Parameters["@invoiceNo"].Value;
            Conn.Close();
            switch (inv_id)
            {
                case "E1":
                    Label1.Text = "No running number in receipt";
                    break;
                case "E2":
                    Label1.Text = "No running number in invoice";
                    break;
                case "E3":
                    Label1.Text = "No Coursefees";
                    break;
                case "E4":
                    Label1.Text = "No details of user";
                    break;
                case "E5":
                    Label1.Text = "No centre code";
                    break;
                case "E6":
                    Label1.Text = "student still have pending";
                    break;
                case "E7":
                    Label1.Text = "wrong course";
                    break;
                default:

                    Label1.Text = "Successfully Upgraded";
                  
                    break;


            }
            Label1.Visible = true;
           
        }
        catch (Exception ex)
        {
          Label1.Text = ex.ToString();
            //Label1.Text = "Input Data Is Not In Correct Format";
        }

    }


    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=%]+$");
        e.IsValid = rx.IsMatch(txt_studentid.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            d1.Visible = true;
            _Qry = "select count(student_id) from adm_personalparticulars where student_id='" + txt_studentid.Text.Trim() + "' and centre_Code='" + Session["SA_centre_code"] + "' and studentstatus='active'";
            int count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count1 > 0)
            {

                //_Qry = "select coursecode,program,course_id,year from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "' and status='active'";
                // _Qry = "select a.invoiceId,b.coursecode,b.program,b.course_id,year,a.courseFees,cast(cast(sum(c.amount) as decimal(9,2)) AS FLOAT) as Amount_Paid,cast(cast(avg(a.coursefees-c.amount) as decimal(9,2)) AS FLOAT) as Pending from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid inner join erp_receiptdetails c on a.studentId=c.studentId where a.centercode='" + Session["SA_centre_code"] + "' and a.studentid='" + txt_studentid.Text.Trim() + "' and a.status='active' group by a.courseFees,c.amount,b.coursecode,b.program,b.course_id,a.invoiceId,year";
                _Qry = @"select enq_personal_name,courseid,invoiceId,program,sum(rep.amount) as Amount_Paid ,inv.coursefees,inv.courseid,(inv.coursefees-sum(rep.amount))as pending from erp_receiptdetails rep
inner join erp_invoicedetails inv on inv.studentid=rep.studentid and inv.status='active'
inner join img_coursedetails cou on cou.course_id=inv.courseid inner join adm_personalparticulars adm on adm.student_id=inv.studentid
where rep.centercode='" + Session["SA_centre_code"] + "' and rep.studentid='" + txt_studentid.Text.Trim() + "' and rep.invoiceno=inv.invoiceid group by inv.coursefees ,inv.courseid,program,invoiceId,enq_personal_name";

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    sid.Text = txt_studentid.Text;
                    cfees.Text = dt.Rows[0]["courseFees"].ToString();
                    Label14.Text = dt.Rows[0]["program"].ToString();
                    invoice.Text = dt.Rows[0]["invoiceId"].ToString();
                    HiddenField1.Value = dt.Rows[0]["courseid"].ToString();
                    Label4.Text = dt.Rows[0]["enq_personal_name"].ToString();
                    //  HiddenField2.Value = dt.Rows[0]["year"].ToString();
                    Session["a"] = dt.Rows[0]["courseFees"].ToString();
                    Session["b"] = dt.Rows[0]["Amount_Paid"].ToString();
                    //Response.Write(Session["a"].ToString() + "<br/>");
                    //Response.Write(Session["b"].ToString());
                    if (Convert.ToDouble(Session["b"].ToString()) >= (Convert.ToDouble(Session["a"].ToString())))
                    {
                        Fees_pending.Text = "No";
                        pendingamt.Text = "Nil";
                        t4.Visible = true;
                        t5.Visible = true;
                        d2.Visible = true;
                        tr1.Visible = true;
                        tr2.Visible = true;
                        tr3.Visible = true;
                        tr4.Visible = true;
                        tr5.Visible = true;
                        tr6.Visible = true;
                        Label1.Visible = false;
                        paypattern.Visible = true;


                        fillcourse();

                    }
                    else
                    {
                        Fees_pending.Text = "Yes";
                        pendingamt.Text = dt.Rows[0]["Pending"].ToString();
                        Label1.Visible = true;
                        Label1.Text = "Have to settle the pending amount to upgrade the course";
                        t4.Visible = false;
                        t5.Visible = false;
                        d2.Visible = false;
                        tr1.Visible = false;
                        tr2.Visible = false;
                        tr3.Visible = false;
                        tr4.Visible = false;
                        tr5.Visible = false;
                        tr6.Visible = false;

                        paypattern.Visible = false;
                    }

                    GetSubcategoryDetails();

                }
            }
            else
            {
                Label1.Text = "Student Dropped from ERP System,Contact Admin";
                d1.Visible = false;
            }
        }
    }
    //public void pending()
    //{
    //    _Qry = "select a.courseFees,cast(cast(sum(b.amount) as decimal(9,2)) AS FLOAT)as Amount_Paid,a.coursefees-b.amount as Pending from erp_invoicedetails a inner join erp_receiptdetails b on a.studentId=b.studentId where a.studentid='" + txt_studentid.Text + "' group by a.courseFees,b.amount ";
    //    DataTable dtab = new DataTable();
    //    dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    if (dtab.Rows.Count > 0)
    //    {
    //        Session["a"] = dtab.Rows[0]["courseFees"].ToString();
    //        Session["b"] = dtab.Rows[0]["Amount_Paid"].ToString();
    //        //Response.Write(Session["a"].ToString() + "<br/>");
    //        //Response.Write(Session["b"].ToString());
    //        if ((Session["a"].ToString()) == (Session["b"].ToString()))
    //        {
    //            Fees_pending.Text = "No";
    //            Amount_paid.Text = dtab.Rows[0]["Amount_Paid"].ToString();
    //            Pending_Amt.Text = "Nil";
    //            ddl_course.Visible = true;
    //            fillcourse();

    //        }
    //        else
    //        {
    //            Fees_pending.Text = "Yes";
    //            Amount_paid.Text = dtab.Rows[0]["Amount_Paid"].ToString();
    //            Pending_Amt.Text = dtab.Rows[0]["Pending"].ToString();
    //            ddl_course.Visible = false;
    //        }
    //    }
    //}

    public void fillcourse()
    {
        _Qry = @"select distinct b.program,a.program as course_id from img_centre_coursefee_details a inner join 
img_coursedetails b on a.program=course_id where centre_code='"+Session["SA_centre_code"]+"'";
        DataTable dtab = new DataTable();
        dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
        txt_coursenamee.DataSource = dtab;
        txt_coursenamee.DataValueField = "course_id";
        txt_coursenamee.DataTextField = "Program";
        txt_coursenamee.DataBind();
        txt_coursenamee.Items.Insert(0, new ListItem("Select", ""));

    }


    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}
