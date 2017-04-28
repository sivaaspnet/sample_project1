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

public partial class Onlinestudents2_superadmin_BookApprovalDetails : System.Web.UI.Page
{
    string _Qry;
    int courseid;
    int getdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            int Courseware_Id = Convert.ToInt32(Request.QueryString["Courseware_Id"]);
            int CoursewareId = Convert.ToInt32(Request.QueryString["CoursewareId"]);
            if (Courseware_Id>0)
            {
                CourseDis.Visible = true;
                btnback.Visible = false;
                BookReq();
            }
            else
            {
                if (CoursewareId>0)
                {
                    CourseDis.Visible = false;
                    btnback.Visible = true;
                    BookReq1();
                }
            }
            //Response.Write("Courseware ID:" + Request.QueryString["CoursewareId"]);  
        }
    }

    protected void Btnadd_Click(object sender, EventArgs e)
    {

        _Qry = "update Courseware set CourierName='" + txtCourier.Text + "',ContactName='" + txtContact.Text + "',Bookstatus='Sent', ";
        _Qry += "TrackingId='" + txtTracking.Text + "',Mobile='" + txtMobile.Text + "',Description='" + txtDescription.Text + "',SentDate=getdate() where Courseware_Id=" + Request.QueryString["Courseware_Id"] + "";


      //_Qry = "Insert into Courseware values('" + txtstudentid.Text + "','" + txtstudentname.Text + "','" + courseid + "','" + CheckBoxList1.Items[i].Value + "','Pending',getdate(),getdate())";
      MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

      _Qry = "Select StudentId from Courseware where Courseware_Id=" + Request.QueryString["Courseware_Id"] + "";

      SqlDataReader dr;
      dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
      string StudId = "";
      if (dr.HasRows)
      {
          dr.Read();
          StudId = dr["StudentId"].ToString();
          dr.Close();
      }

      _Qry = "Update adm_personalparticulars set Bookstatus='Sent',DateMod=getdate() where student_id='" + StudId + "'";
      MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

      Response.Redirect("BookApproval.aspx?BookAppr=Succ&student_id="+txtstudentid.Text+"");
      //  //Response.End();
    }

    private void BookReq()
    {
        CourseDis.Visible = true;
        btnback.Visible = false;

        //Response.Write("ttttttttttttttttttttt");
        _Qry = "Select Courseware_Id,StudentId,StudentName,(select CourseName from Courseware_Course where Course_id=Courseware.CourseId) as CourseName,";
        _Qry += " (select SoftwareName from Courseware_Software where Software_Id=Courseware.SoftwareId) as SoftwareName,Bookstatus from courseware";
        _Qry += " Where Courseware_Id='" + Request.QueryString["Courseware_Id"] + "'";

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            txtstudentid.Text = dr["StudentId"].ToString();
            txtstudentname.Text = dr["StudentName"].ToString();
            txtCourse.Text = dr["coursename"].ToString();
            txtBook.Text = dr["SoftwareName"].ToString();
            dr.Close();
        }
        CourseDis.Visible = true;
    }

    private void BookReq1()
    {
        CourseDis.Visible = false;
        btnback.Visible = true;

        //Response.Write("xxxxxxxxxxxxxxxxxxxxxx");
        _Qry = "Select Courseware_Id,StudentId,StudentName,(select CourseName from Courseware_Course where Course_id=Courseware.CourseId) as CourseName,";
        _Qry += " (select SoftwareName from Courseware_Software where Software_Id=Courseware.SoftwareId) as SoftwareName,Bookstatus,";
        _Qry += " CourierName,TrackingId,ContactName,Mobile,Description  from courseware";
        _Qry += " Where Courseware_Id='" + Request.QueryString["CoursewareId"] + "'";

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            txtstudentid.Text = dr["StudentId"].ToString();
            txtstudentid.ReadOnly = true;
            txtstudentname.Text = dr["StudentName"].ToString();
            txtstudentname.ReadOnly = true;
            txtCourse.Text = dr["coursename"].ToString();
            txtCourse.ReadOnly = true;
            txtBook.Text = dr["SoftwareName"].ToString();
            txtBook.ReadOnly = true;
            txtCourier.Text = dr["CourierName"].ToString();
            txtCourier.ReadOnly = true;
            txtTracking.Text = dr["TrackingId"].ToString();
            txtTracking.ReadOnly = true;
            txtContact.Text = dr["ContactName"].ToString();
            txtContact.ReadOnly = true;
            txtMobile.Text = dr["Mobile"].ToString();
            txtMobile.ReadOnly = true;
            txtDescription.Text = dr["Description"].ToString();
            txtDescription.ReadOnly = true;
            dr.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookApproval.aspx?student_id=" + txtstudentid.Text + "");
    }
}
