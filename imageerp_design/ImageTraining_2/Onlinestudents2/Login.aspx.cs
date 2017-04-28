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

public partial class superadmin_Login : System.Web.UI.Page
{
    string _Qry;
    string Ipaddr = "";
    string CentreCode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        loadbanner();

    }
    private void loadbanner()
    {
        _Qry = "select * from erp_homeimage";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            Image1.ImageUrl = dt.Rows[0]["imageurl"].ToString();
            Image2.ImageUrl = dt.Rows[1]["imageurl"].ToString();
            Image3.ImageUrl = dt.Rows[2]["imageurl"].ToString();
            Image4.ImageUrl = dt.Rows[3]["imageurl"].ToString();
        }

    }
   
    protected void login_Click(object sender, EventArgs e)
    {




        string password = "";
        _Qry = "Select Password from adm_generalinfo where student_id='" + txtusername.Text + "'";

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt1.Rows.Count > 0)
        {
            password = dt1.Rows[0]["Password"].ToString();
        }
        else
        {
            lblerrmsg.Text = "Invalid UserID & Password";
        }
        
        if (password == "" || password == null)
        {
            _Qry = "Select info.Student_Id,info.Centre_Code From adm_generalinfo info inner join adm_personalparticulars per on per.student_id=info.student_id and per.studentstatus='active'  where info.student_id='" + txtusername.Text + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                
                Session["CentreCode"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Centre_Code"].ToString());

              
                    Session["Student_Id"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Student_Id"].ToString());
                    Session["Password"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Student_Id"].ToString());
                    Session["Centrerole"] = "";
                    _Qry = "Update adm_generalinfo set Password='" + Session["Student_Id"] + "' where Student_Id='" + Session["Student_Id"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);



                    _Qry = "select top 1 * from erp_studentleave where studentid='" + txtusername.Text + "' and centercode='" + Session["CentreCode"].ToString() + "' and status='Approved' order by id desc";
                    DataTable dt5 = new DataTable();
                    dt5 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt5.Rows.Count > 0)
                    {

                        string from = dt5.Rows[0]["fromdate"].ToString();
                        string to = dt5.Rows[0]["todate"].ToString();
                        _Qry = " select * from [spstartendclassdate]('" + from + "','" + to + "','Daily') where classdate=convert(varchar,getdate(),101) ";
                        DataTable temp = new DataTable();
                        temp = MVC.DataAccess.ExecuteDataTable(_Qry);
                        if(temp.Rows.Count>0)
                        {
                            lblerrmsg.Text = "Contact Admin:[Leave]";
                        }
                        else
                        {
                            Response.Redirect("welcome.aspx");

                        }


                    }
                    else
                    {
                        Response.Redirect("welcome.aspx");

                    }





            }
            else
            {
                _Qry = "Select studentstatus From adm_generalinfo info inner join adm_personalparticulars per on per.student_id=info.student_id  where info.student_id='" + txtusername.Text + "' And info.Password='" + txtpassword.Text + "'";
                DataTable dt13 = new DataTable();
                dt13 = MVC.DataAccess.ExecuteDataTable(_Qry);
                
                if (dt13.Rows.Count > 0)
                {
                    string status = dt13.Rows[0]["studentstatus"].ToString();
                    if (status == "Dropped")
                    {
                        lblerrmsg.Text = "Student Got Dropped";
                    }
                    else
                    {
                        lblerrmsg.Text = "Invalid UserID & Password";
                    }
                }
                else
                {
                    lblerrmsg.Text = "Invalid UserID & Password";
                }
            }
        }
        else
        {
            _Qry = "Select info.Student_Id,info.Centre_Code,info.Password From adm_generalinfo info inner join adm_personalparticulars per on per.student_id=info.student_id and per.studentstatus='active' where info.student_id='" + txtusername.Text + "' And info.Password='" + txtpassword.Text + "'";
         
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
               
                Session["CentreCode"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Centre_Code"].ToString());
           
        
                    Session["Student_Id"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Student_Id"].ToString());
                    Session["Password"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Password"].ToString());
                    Session["Centrerole"] = "";


                    _Qry = "select top 1 * from erp_studentleave where studentid='" + txtusername.Text + "' and centercode='" + Session["CentreCode"].ToString() + "' and status='Approved' order by id desc";
                    DataTable dt5 = new DataTable();
                    dt5 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt5.Rows.Count > 0)
                    {

                        string from = dt5.Rows[0]["fromdate"].ToString();
                        string to = dt5.Rows[0]["todate"].ToString();
                        _Qry = " select * from [spstartendclassdate]('" + from + "','" + to + "','Daily') where classdate=convert(varchar,getdate(),101) ";
                        DataTable temp = new DataTable();
                        temp = MVC.DataAccess.ExecuteDataTable(_Qry);
                        if (temp.Rows.Count > 0)
                        {
                            lblerrmsg.Text = "Contact Admin:[Leave]";
                        }
                        else
                        {
                            Response.Redirect("welcome.aspx");

                        }


                    }
                    else
                    {
                        Response.Redirect("welcome.aspx");

                    }


            }
            else
            {
                _Qry = "Select studentstatus From adm_generalinfo info inner join adm_personalparticulars per on per.student_id=info.student_id  where info.student_id='" + txtusername.Text + "' And info.Password='" + txtpassword.Text + "'";
                DataTable dt11 = new DataTable();
                dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);
               
                if(dt11.Rows.Count>0)
                {
                    string status = dt11.Rows[0]["studentstatus"].ToString();
                if (status == "Dropped")
                {
                    lblerrmsg.Text = "Student Got Dropped";
                }
                else
                {
                    lblerrmsg.Text = "Invalid UserID & Password";
                }
                }
                else
                {
                    lblerrmsg.Text = "Invalid UserID & Password";
                }
            }
        }
    }
}
