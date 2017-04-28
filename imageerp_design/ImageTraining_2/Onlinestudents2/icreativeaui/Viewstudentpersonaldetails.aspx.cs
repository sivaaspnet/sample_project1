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

public partial class superadmin_Viewstudentpersonaldetails : System.Web.UI.Page
{
    string _Qry,_Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        studname();
        
        stu_parent();
        stu_contactdetails();
    }
    private void studname()
    {
        _Qry = "select enq_personal_name from adm_personalparticulars where student_id='" + Request.QueryString["stuid"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblstu_name.Text = dt.Rows[0]["enq_personal_name"].ToString();
        }
    }
 
    private void stu_contactdetails()
    {
        _Qry = "select enq_present_address,enq_personal_email,enq_personal_mobile,enq_present_district,enq_present_state,enq_present_pincode,enq_high_qualification,enq_high_institution,enq_high_city,enq_high_state from Img_enquiryform where enq_number='" + hdnENQID.Value + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        
        if (dt.Rows.Count > 0)
        {
            lblprimary.Text = dt.Rows[0]["enq_high_qualification"].ToString();
            lbl_stumobile.Text = dt.Rows[0]["enq_personal_mobile"].ToString();
            lbl_stuemail.Text = dt.Rows[0]["enq_personal_email"].ToString();
            
            lblstu_tenthinsti.Text = dt.Rows[0]["enq_high_institution"].ToString();
            lblstu_tenthcity.Text = dt.Rows[0]["enq_high_city"].ToString();
            lblstate.Text = dt.Rows[0]["enq_high_state"].ToString();
            lbl_stu_addr.Text = dt.Rows[0]["enq_present_address"].ToString();
            lbl_stu_dist.Text = dt.Rows[0]["enq_present_district"].ToString();
            lbl_stu_state.Text = dt.Rows[0]["enq_present_state"].ToString();
            lbl_stu_pin.Text = dt.Rows[0]["enq_present_pincode"].ToString();
        }
        _Qry = "select photo from adm_personalparticulars where student_id='" + Request.QueryString["stuid"] + "'";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {
            //Response.Write("kkkk" + dt1.Rows[0]["photo"].ToString());
            if (dt1.Rows[0]["photo"].ToString() == null || dt1.Rows[0]["photo"].ToString() =="")
            {
                Image1.ImageUrl = "~/studentphoto/blank person.jpg";
             
            }
            else
            {
                Image1.ImageUrl = "~/studentphoto/" + dt1.Rows[0]["photo"].ToString();
            
            }
        }
    }
    private void stu_parent()
    {
        _Qry = "select enq_number from adm_personalparticulars where student_id='" + Request.QueryString["stuid"] + "'"; 
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            hdnENQID.Value = dt.Rows[0]["enq_number"].ToString();
          
        }

        _Qry1 = "select enq_parent_name,enq_parent_relation,enq_parent_mobile from Img_enquiryform1 where enq_number='" + hdnENQID.Value + "'";
       
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);

        if (dt1.Rows.Count > 0)
        {
            lblstu_parent_name.Text = dt1.Rows[0]["enq_parent_name"].ToString();
            lblstu_parent_relation.Text = dt1.Rows[0]["enq_parent_relation"].ToString();
            lblstu_parent_mobile.Text = dt1.Rows[0]["enq_parent_mobile"].ToString();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      

        string temp = FileUpload1.FileName;
        Random rand = new Random();
        int code = rand.Next(9999);
        temp = code + temp;
        string img = "~/studentphoto/" + temp;
        FileUpload1.SaveAs(Server.MapPath(img));
        //Image2.ImageUrl = img;
        string stud_id = Request.QueryString["stuid"].ToString(); 
        _Qry1 = "Update adm_personalparticulars set photo='" + temp + "' where student_id='" + stud_id + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
        Label2.Visible = true;
        Label2.Text = "Uploaded Successfully";
        stu_contactdetails();
            }
           
        }
    

