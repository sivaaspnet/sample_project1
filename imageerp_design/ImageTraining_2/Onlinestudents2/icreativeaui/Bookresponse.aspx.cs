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
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1, chk1 = "";
    string inv_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {

            fillgrid();
        }
    }

    public void fillgrid()
    {
        _Qry = @"select distinct br.id, br.studentid,adm.enq_personal_name,br.courseid,cou.program,bd.bookname,br.requested_date from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid inner join img_coursedetails cou on cou.course_id=br.courseid inner join bookdetails bd on bd.bookid=br.bookid where br.studentid='" + Request.QueryString["studentid"].ToString() + "'and br.courseid='" + Request.QueryString["course"].ToString() + "'and convert(varchar,br.requested_date,103)='" + Request.QueryString["request"].ToString() + "' and br.bookstatus ='Pending' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count <= 0)
        {
            Button1.Visible = false;
        }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        
       
          
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = DateTime.Now.ToString("dd-MM-yyyy");
        foreach (GridViewRow gr in GridView1.Rows)
        {
            DropDownList dl = new DropDownList();
            dl = (DropDownList)gr.FindControl("DropDownList1");
            HiddenField hf = new HiddenField();
            hf = (HiddenField)gr.FindControl("HiddenField1");
            if (dl.SelectedValue == "Issued")
            {
                _Qry = "update book_request set bookstatus='" + dl.SelectedValue.ToString() + "',issuedate= '"+DateTime.Now.ToString("MM-dd-yyyy")+"' where id='" + hf.Value + "'";
            }
            else
            {
                _Qry = "update book_request set bookstatus='" + dl.SelectedValue.ToString() + "' where id='" + hf.Value + "'";
            }
          
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();

        }
       
    }
}
    

   
    
  






    







   


