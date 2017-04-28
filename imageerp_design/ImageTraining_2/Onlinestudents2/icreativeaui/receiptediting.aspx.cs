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

public partial class superadmin_Receiptedit : System.Web.UI.Page
{
    string rec_id = "";
    string _Qry;
     string manual;   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
         {
            Response.Redirect("Login.aspx");
         }

        

        if(!IsPostBack)
         {
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
        
            fillcoursedropdown1();
            fillgrid();
            
         }
       
    }
   

  
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
       
        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
   
        cmd.CommandText = "[quickreceipt]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
        cmd.Parameters.AddWithValue("course", txt_coursepositioned.SelectedValue);
        cmd.Parameters.AddWithValue("totalinitialAmt", txt_initialamt.Text);
        double b = Convert.ToDouble(txt_initialamt.Text) * Convert.ToDouble(HiddenField2.Value) / 100;
        double a = Convert.ToDouble(txt_initialamt.Text) - b;
        cmd.Parameters.AddWithValue("initialAmt", Math.Round( a));
        cmd.Parameters.AddWithValue("taxinitialAmt", b);
        cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
        cmd.Parameters.AddWithValue("studentname", txt_studname.Text);
        cmd.Parameters.AddWithValue("month", ddl_month.SelectedValue);
        cmd.Parameters.AddWithValue("paywords", hdnpayinword.Value);
        cmd.Parameters.Add("@runningReceipt", SqlDbType.VarChar, 50);
        cmd.Parameters["@runningReceipt"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@student", SqlDbType.VarChar, 50);
        cmd.Parameters["@student"].Direction = ParameterDirection.Output;
        Conn.Open();
        cmd.ExecuteNonQuery();
        rec_id = (string)cmd.Parameters["@runningReceipt"].Value;
        string student = (string)cmd.Parameters["@student"].Value;
        Conn.Close();
        Response.Redirect("receiptprint2.aspx?rec_no=" + rec_id+"&student_id="+student);
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
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='ICH-102' Group By a.Program,a.course_id,b.Program";
            }
            else
            {
                _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.Program,a.course_id,b.Program";
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

    private void fillgrid()
    {
        _Qry = "select manual_code from old_student_manual where center_code='" + Session["SA_centre_code"] + "'";
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt4.Rows.Count > 0)
        {
            manual = dt4.Rows[0]["manual_code"].ToString();

        }

        _Qry = @"select student_name,rec_no,student_id from 
oldreceipt_details  a inner join img_coursedetails on 
course_id=course_code where center_code='" + manual + "' and substring(student_id,1,5)='Quick' order by id desc";
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
        if( txt_coursepositioned.SelectedValue!="")
        {
        _Qry = "select tax from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"] + "' and track='Normal' and program='"+txt_coursepositioned.SelectedValue+"'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        HiddenField2.Value =  dt.Rows[0]["tax"].ToString();
        }
     
    }
}
