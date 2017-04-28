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

public partial class EditRegistration : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1;
    string inv_id = "";
    string rec_id = "";

    string manual;   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Label2.Text = "";
            int mm = System.DateTime.Now.Month;
            if (mm == 1)
            {
                ddl_month.SelectedValue = "Jan";
            }
            if (mm == 2)
            {
                ddl_month.SelectedValue = "Feb";
            }
            if (mm == 3)
            {
                ddl_month.SelectedValue = "Mar";
            }
            if (mm == 4)
            {
                ddl_month.SelectedValue = "Apr";
            }
            if (mm == 5)
            {
                ddl_month.SelectedValue = "May";
            }
            if (mm == 6)
            {
                ddl_month.SelectedValue = "Jun";
            }
            if (mm == 7)
            {
                ddl_month.SelectedValue = "Jul";
            }
            if (mm == 8)
            {
                ddl_month.SelectedValue = "Aug";
            }
            if (mm == 9)
            {
                ddl_month.SelectedValue = "Sep";
            }
            if (mm == 10)
            {
                ddl_month.SelectedValue = "Oct";
            }
            if (mm == 11)
            {
                ddl_month.SelectedValue = "Nov";
            }
            if (mm == 12)
            {
                ddl_month.SelectedValue = "Dec";
            }

            
            fillgrid();
           fillcoursedropdown(); 
           
        }
        GetSubcategoryDetails();
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
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' and b.status=1 Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
            }
            else
            {
                qry1 = "select a.Program,a.course_id,a.coursetype from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' and b.status=1 Group By a.coursename,a.course_id,b.Program,a.Program,a.coursetype";
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
                int i, normalval = 0,fastval=0 ;
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
                    if(dt.Rows[i]["track"].ToString().ToLower() == "normal")
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

    private void fillcoursedropdown()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program and a.status='active' and b.status=1  where centre_code='" + Session["SA_centre_code"].ToString() + "' and   a.status='Active' and b.status=1 and a.year=1 Group By a.coursename,a.course_id,b.Program,a.Program";
          
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


 

    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        double b = Convert.ToDouble(txt_initialamt.Text) / (Convert.ToDouble(HiddenField2.Value) + 100);

        double a = b * 100;
        double c = a * Convert.ToDouble(HiddenField2.Value) / 100;
        _Qry = "update erp_quickreceipt set studentname='" + txt_studname.Text + "',coursecode='" + txt_coursepositioned.SelectedValue + "',contactno='" + TextBox1.Text + "',sourse='" + DropDownList1.SelectedValue + "',[profile]='" + ddl_profile0.SelectedValue + "' ,referstudent='" + txtreferstudent.Text + "' where centrecode='" + Session["SA_centre_code"] + "' and receiptno='" + hdnReceiptNum.Value + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        _Qry = "";
        _Qry = "update erp_receiptdetails set totalamount='" + txt_initialamt.Text + "',amount='" + Math.Round(a) + "',taxamount='"+c+"',monthinstall='" + ddl_month.SelectedValue + "',paymentwords='" + txt_paymentwords.Text + "',paymentMode='" + ddl_paymode.SelectedValue + "',bankName='" + txt_bankname.Text + "',ddNo='" + txt_ddcc.Text + "',ddDate='" + dddate.Text + "' where centerCode='" + Session["SA_centre_code"] + "' and receiptno='" + hdnReceiptNum.Value + "' and id='" + hdnReceiptID.Value + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        Label2.Text = "Receipt Updated Successfully";
        fillgrid();
    }

    private void fillgrid()
    {


        _Qry = @"select  c.receiptno,case isnull(studentidno,'') when '' then 'quickenquiry.aspx?recptno='+c.receiptNo else 'quickpreInvoice.aspx?receiptno='+c.receiptNo+'&studid='+studentidno end as link,studentname,studentid,contactno,a.id from 
erp_receiptdetails a inner join erp_quickreceipt c on c.receiptNo=a.receiptno inner join img_coursedetails on 
course_id=c.coursecode  and c.centrecode=a.centercode  where centercode='" + Session["SA_centre_code"].ToString() + @"' and
 substring(studentid,1,5)='Quick' and a.installno=0 order by a.id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

   
    protected void txt_coursepositioned_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txt_coursepositioned.SelectedValue != "")
        {
            _Qry = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "' and track='Normal' and program='" + txt_coursepositioned.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            HiddenField2.Value = dt.Rows[0]["tax"].ToString();
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select r.id,q.studentname,q.coursecode,q.receiptno,q.centrecode,q.contactno,q.sourse,q.[profile] ,q.referstudent,r.amount,r.totalamount,r.monthinstall,r.installno,r.paymentwords,r.taxamount,r.studentid,r.dateIns,r.receipttype,r.status,r.receiptcutby,r.paymenttowards,r.paymentMode,r.bankName,r.ddNo,r.ddDate,r.id from erp_receiptdetails r inner join erp_quickreceipt q on r.receiptno=q.receiptno where r.id=" + e.CommandArgument.ToString() + "";
            DataTable dt2 = new DataTable();
            dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt2.Rows.Count > 0)
            {
                Label2.Text = "";
                hdnReceiptID.Value = dt2.Rows[0]["id"].ToString();
                hdnReceiptNum.Value = dt2.Rows[0]["receiptno"].ToString();
                txt_studname.Text = dt2.Rows[0]["studentname"].ToString();
                txt_coursepositioned.SelectedValue = dt2.Rows[0]["coursecode"].ToString();
                _Qry = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "' and track='Normal' and program='" + txt_coursepositioned.SelectedValue + "'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                HiddenField2.Value = dt.Rows[0]["tax"].ToString();

                TextBox1.Text = dt2.Rows[0]["contactno"].ToString();
                DropDownList1.SelectedValue = dt2.Rows[0]["sourse"].ToString();
                ddl_profile0.SelectedValue = dt2.Rows[0]["profile"].ToString();
                txtreferstudent.Text = dt2.Rows[0]["referstudent"].ToString();
                ddl_paymode.SelectedValue = dt2.Rows[0]["paymentMode"].ToString();
                txt_ddcc.Text = dt2.Rows[0]["ddNo"].ToString();
                dddate.Text = dt2.Rows[0]["ddDate"].ToString();
                txt_bankname.Text = dt2.Rows[0]["bankName"].ToString();
                txt_initialamt.Text = dt2.Rows[0]["totalamount"].ToString();
                lblamtwithtax.Text = dt2.Rows[0]["amount"].ToString();
                txt_paymentwords.Text = dt2.Rows[0]["paymentwords"].ToString();
                ddl_month.SelectedValue = dt2.Rows[0]["monthinstall"].ToString();
            }

        }
    }
}
