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

public partial class ImageTraining_2_Onlinestudents2_Student_Feedback : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Student_Id"] == null || Session["Student_Id"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            getdata();
        }
    }

    public void getdata()
    {
        _Qry = @"
select  distinct bat.batchcode,mod.module_content,bat.slot,bat.batchtiming,bat.status ,b.track,sce.labid,sce.facultyid,lab.labname,facultyname,
(select  CONVERT(VARCHAR(10),min( scheduledate ),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode ) as Startdate,
(select  CONVERT(VARCHAR(10),max( scheduledate),103) from erp_batchcontentstatus sts where sts.batchcode=sce.batchcode )as Enddate,fac.Faculty_ID,(select enq_personal_name from adm_personalparticulars where student_id=b.studentId) as name
 from erp_batchdetails bat inner join module_details mod on moduleid=module_id  inner join erp_batchschedule sce
on sce.batchcode=bat.batchcode inner join online_students_labavail lab on lab.labid=sce.labid inner join 
onlinestudentsfacultydetails fac on fac.faculty_id=sce.facultyid inner join erp_invoicedetails b on b.studentId='" + Session["Student_Id"].ToString() + "' where  bat.centrecode='" + Session["CentreCode"].ToString() + "' and bat.batchcode='" + Request.QueryString["batchcode"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry = @"select  distinct a.software_id,software_name,batchcode  from erp_batchcontentstatus a inner join Onlinestudent_Software b on a.Software_id=b.Software_id ";
        DataTable dtab = new DataTable();
        dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lbl_Name.Text = dt.Rows[0]["facultyname"].ToString();
            lbl_Timing.Text = dt.Rows[0]["batchtiming"].ToString();
            lbl_Track.Text = dt.Rows[0]["track"].ToString();
            lbl_no.Text = Session["Student_Id"].ToString();
            lbl_sname.Text = dt.Rows[0]["name"].ToString();
            lbl_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //txt_Batchcode.Text = dt.Rows[0]["BatchCode"].ToString();
            lbl_Software.Text = getsoft(dtab, "batchcode='" + Request.QueryString["batchcode"] + "'", "software_Name");
            HiddenField1.Value = dt.Rows[0]["Faculty_ID"].ToString();
            HiddenField3.Value = Session["CentreCode"].ToString();
            HiddenField2.Value = getsoft(dtab, "batchcode='" + Request.QueryString["batchcode"] + "'", "software_id");
        }
    }
    string getsoft(DataTable dtexp, string expression, string column)
    {
        string soft = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (soft == "")
                {
                    soft = (val[column].ToString());
                }
                else if (soft == (val[column].ToString()))
                {
                    soft = (val[column].ToString());

                }
                else
                {
                    soft = soft + "," + (val[column].ToString());
                }

            }

        }
        return soft.ToString();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        insertdata();
    }

    public void insertdata()
    {

        _Qry = "select * from Student_Feedback where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and student_id='" + Session["Student_Id"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            string strScript1 = "<script language='JavaScript'>alert('Feedback Already submitted')</script>";
            Page.RegisterStartupScript("PopUp", strScript1);
        }
        else
        {
            _Qry = "update Feedback_request set Status='Completed' where Batch_Code='" + Request.QueryString["batchcode"].ToString() + "' and Student_id='" + Session["Student_Id"].ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            _Qry = "insert into Student_Feedback(student_id,faculty_id,software_id,timing,track,date,communication,clarify,extra_assignments,feedback_assignments,pace_class,interaction,examples,time,confidence_level,overall,suggestion,batchcode,centre)values('" + Session["Student_Id"].ToString() + "','" + HiddenField1.Value + "','" + HiddenField2.Value + "','" + lbl_Timing.Text + "','" + lbl_Track.Text + "','" + lbl_Date.Text + "','" + RadioButtonList1.SelectedValue.ToString() + "','" + RadioButtonList2.SelectedValue.ToString() + "','" + RadioButtonList3.SelectedValue.ToString() + "','" + RadioButtonList4.SelectedValue.ToString() + "','" + RadioButtonList5.SelectedValue.ToString() + "','" + RadioButtonList6.SelectedValue.ToString() + "','" + RadioButtonList7.SelectedValue.ToString() + "','" + RadioButtonList8.SelectedValue.ToString() + "','" + RadioButtonList9.SelectedValue.ToString() + "','" + RadioButtonList10.SelectedValue.ToString() + "','" + t1.Text + "','" + Request.QueryString["batchcode"] + "','" + HiddenField3.Value + "')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

            string strScript = "<script language='JavaScript'>alert('Submitted Successfully')</script>";
            Page.RegisterStartupScript("PopUp", strScript);
            Response.Redirect("welcome.aspx");

        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        ClearFields(Form.Controls);

    }
    public  void ClearFields(ControlCollection pageControls)
    {
        foreach (Control cont1 in pageControls)
        {
            string strCntName = (cont1.GetType()).Name;

            if(cont1.GetType().Name=="RadioButtonList")
            {
                RadioButtonList rblSource = (RadioButtonList)cont1;
                rblSource.SelectedIndex = -1;
            }
            else
                if (cont1.GetType().Name == "TextBox")
                {
                    TextBox tbSource = (TextBox)cont1;
                    tbSource.Text = "";
                }
            ClearFields(cont1.Controls);   
            } 
        }
     
    }
