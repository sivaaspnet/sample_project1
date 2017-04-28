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
using System.Text.RegularExpressions;
using System.Net;

public partial class superadmin_addcentre : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
    string chk = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
     
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
     
        }
        fillgrid();
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        
      
    
    
       
    }


    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtc_code.Text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = "select  studentid from erp_oldbatchdetails where studentid='" + txtc_code.Text + "' and status='active'";
            DataTable dt2 = new DataTable();
            dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt2.Rows.Count > 0)
            {
                lblmsg.Text = "Student already Exist";
                t1.Visible = false;
                t2.Visible = false;
                t3.Visible = false;
                t4.Visible = false;
            }
            else
            {

                _Qry = "select studentid from erp_batchschedule where studentid='" + txtc_code.Text + "' and status='Completed'";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt1.Rows.Count > 0)
                {
                    lblmsg.Text = "Already  student is running in a batch";

                }
                else
                {

                    t1.Visible = true;
                    t2.Visible = false;
                    t3.Visible = false;
                    t4.Visible = false;
                    lblmsg.Text = "";
                    _Qry = "select b.program,a.courseId,c.studentstatus from erp_invoicedetails a inner join img_coursedetails b on a.courseId=b.course_id inner join adm_personalparticulars c on a.studentId=c.student_id where a.studentId='" + txtc_code.Text + "' and a.status='active'";
                    DataTable dt = new DataTable();
                    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["studentstatus"].ToString() == "active")
                        {
                            CheckBoxList1.DataSource = dt;
                            CheckBoxList1.DataTextField = "program";
                            CheckBoxList1.DataValueField = "courseId";
                            CheckBoxList1.DataBind();
                        }
                        else if (dt.Rows[0]["studentstatus"].ToString() == "Dropped")
                        {
                            lblmsg.Text = "Student Dropped";

                        }
                        else if (dt.Rows[0]["studentstatus"].ToString() == "Break")
                        {
                            lblmsg.Text = "Student Break";

                        }
                        else if (dt.Rows[0]["studentstatus"].ToString() == "Completed")
                        {
                            lblmsg.Text = "Student Completed the course";

                        }

                    }
                    else
                    {
                        lblmsg.Text = "No Record";
                        t2.Visible = false;
                        t3.Visible = false;
                        t4.Visible = false;
                    }
                }
            }
        }

    }




    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        t2.Visible = true;
        t3.Visible = true;
        t4.Visible = true;
        _Qry = " select module_Id,module_content from Onlinestudent_Coursesoftware where Course_Id='" + CheckBoxList1.SelectedValue + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            CheckBoxList2.DataSource = dt1;
            CheckBoxList2.DataTextField = "module_content";
            CheckBoxList2.DataValueField = "module_Id";
            CheckBoxList2.DataBind();
           
        }
        else
        {
            lblmsg.Text = "No Record";
            t2.Visible = false;
            t3.Visible = false;
            t4.Visible = false;
        }
        foreach (ListItem li in CheckBoxList2.Items)
        {
            
                li.Selected = true;
            
        }
       
        _Qry = "select distinct a.module_content,a.module_Id,b.Software_Id,b.Software from Onlinestudent_Coursesoftware a inner join Submodule_details_new  b on a.module_Id=b.ModuleId where a.Course_Id='" + CheckBoxList1.SelectedValue + "'";
        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            CheckBoxList3.DataSource = dt2;
            CheckBoxList3.DataTextField  ="Software";
            CheckBoxList3.DataValueField ="Software_Id";
            CheckBoxList3.DataBind();
        }
        else
        {
            lblmsg.Text = "No Record";
            t2.Visible = false;
            t3.Visible = false;
            t4.Visible = false;
        }
        foreach (ListItem li1 in CheckBoxList3.Items)
        {

            li1.Selected = true;

        } 


    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //getcheckbox();
        //Response.Write(chk);
    
       

            _Qry = "insert into erp_oldbatchdetails(studentid,moduleid,centre_code,Software_Id,status)select distinct '" + txtc_code.Text + "', a.module_Id,'" + Session["SA_centre_code"] + "',b.Software_Id,'active' from Onlinestudent_Coursesoftware a inner join Submodule_details_new  b on a.module_Id=b.ModuleId where a.Course_Id='" + CheckBoxList1.SelectedValue + "'";
            //Response.Write(_Qry);
            MVC.DataAccess.ExecuteDataTable(_Qry);
            _Qry = "update erp_oldbatchdetails set softwarestatus='completed' where studentid='" + txtc_code.Text + "' and centre_code='" + Session["SA_centre_code"] + "'";
            //Response.Write(_Qry);
            MVC.DataAccess.ExecuteDataTable(_Qry);
            txtc_code.Text = "";
            t1.Visible = false;
            t2.Visible = false;
            t3.Visible = false;
            t4.Visible = false;
            lblmsg.Text = "Sumbitted Successfully";
        

    }

    public void getcheckbox()
    {

        int n;
        for (n = 0; n <= CheckBoxList3.Items.Count - 1; n++)
        {
            if (CheckBoxList3.Items[n].Selected)
            {

                if (chk == "")
                {
                    chk = CheckBoxList3.Items[n].Value;
                }
                else
                {
                    chk = chk + "," + CheckBoxList3.Items[n].Value;
                }

            }

        }


    }


    private void fillgrid()
    {
        _Qry = "select student_id,enq_personal_name,studentstatus from adm_personalparticulars where studentstatus='Completed' and centre_code='"+Session["SA_centre_code"].ToString()+"'";
        
        


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
   
    }
}
