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

public partial class ImageTraining_2_Onlinestudents2_superadmin_ViewFeedback : System.Web.UI.Page
{
    string _Qry;
    string os = "";
    int percentvalue = 0;
    decimal overallpercent = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {

            fillgrid();
            filldrop();
            fillfaculty();

        }
    }
    public void fillgrid()
    {
        _Qry = @"select a.date,Software_Name,a.batchcode, a.student_id,a.software_id,
a.timing,a.track,a.communication,a.clarify,a.extra_assignments,feedback_assignments,
a.pace_class,a.interaction,a.examples,a.time,a.confidence_level,a.overall,a.suggestion,
b.FacultyName,c.centre_location from 
Student_Feedback a inner join onlinestudentsfacultydetails  b on a.faculty_id=b.Faculty_ID 
inner join img_centredetails c on c.centre_code=a.centre 
inner join Onlinestudent_Software d on d.software_id in (select  * from Split2(a.software_id,',')) where a.centre='" + Session["SA_centre_code"].ToString() + "'";
        if (TextBox1.Text != "")
        {
            _Qry +="and a.date like '"+TextBox1.Text.ToString()+"%'";
        }
        if (TextBox2.Text != "")
        {
            _Qry += "and a.date like '" + TextBox2.Text.ToString() + "%'";
        }
        if (ddl_software.SelectedValue != "")
        {
            _Qry += "and d.software_id in (" + ddl_software.SelectedValue.ToString() + ")";
            //Response.Write(_Qry);
        }
        if (ddl_faculty.SelectedValue != "")
        {
            _Qry += " and a.faculty_id = '" + ddl_faculty.SelectedValue.ToString() + "'";
        }

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        int percentage = 0;
        if (ddl_faculty.SelectedIndex > 0)
        {
           

            string _QryExcellent = @"select count(a.overall) from Student_Feedback a inner join onlinestudentsfacultydetails  b on a.faculty_id=b.Faculty_ID 
inner join img_centredetails c on c.centre_code=a.centre 
inner join Onlinestudent_Software d on d.software_id in (select  * from Split2(a.software_id,',')) where a.centre='" + Session["SA_centre_code"].ToString() + "'";
            if (TextBox1.Text != "")
            {
                _QryExcellent += "and a.date like '" + TextBox1.Text.ToString() + "%'";
            }
            if (TextBox2.Text != "")
            {
                _QryExcellent += "and a.date like '" + TextBox2.Text.ToString() + "%'";
            }
            if (ddl_software.SelectedValue != "")
            {
                _QryExcellent += "and d.software_id in (" + ddl_software.SelectedValue.ToString() + ")";

            }
            if (ddl_faculty.SelectedValue != "")
            {
                _QryExcellent += " and a.faculty_id = '" + ddl_faculty.SelectedValue.ToString() + "' and a.overall='Excellent'";
            }
            string _QryGood = @"select count(a.overall) from Student_Feedback a inner join onlinestudentsfacultydetails  b on a.faculty_id=b.Faculty_ID 
inner join img_centredetails c on c.centre_code=a.centre 
inner join Onlinestudent_Software d on d.software_id in (select  * from Split2(a.software_id,',')) where a.centre='" + Session["SA_centre_code"].ToString() + "'";
            if (TextBox1.Text != "")
            {
                _QryGood += "and a.date like '" + TextBox1.Text.ToString() + "%'";
            }
            if (TextBox2.Text != "")
            {
                _QryGood += "and a.date like '" + TextBox2.Text.ToString() + "%'";
            }
            if (ddl_software.SelectedValue != "")
            {
                _QryGood += "and d.software_id in (" + ddl_software.SelectedValue.ToString() + ")";

            }
            if (ddl_faculty.SelectedValue != "")
            {
                _QryGood += " and a.faculty_id = '" + ddl_faculty.SelectedValue.ToString() + "' and a.overall='Good'";
            }

            string _QryAverage = @"select count(a.overall) from Student_Feedback a inner join onlinestudentsfacultydetails  b on a.faculty_id=b.Faculty_ID 
inner join img_centredetails c on c.centre_code=a.centre 
inner join Onlinestudent_Software d on d.software_id in (select  * from Split2(a.software_id,',')) where a.centre='" + Session["SA_centre_code"].ToString() + "'";
            if (TextBox1.Text != "")
            {
                _QryAverage += "and a.date like '" + TextBox1.Text.ToString() + "%'";
            }
            if (TextBox2.Text != "")
            {
                _QryAverage += "and a.date like '" + TextBox2.Text.ToString() + "%'";
            }
            if (ddl_software.SelectedValue != "")
            {
                _QryAverage += "and d.software_id in (" + ddl_software.SelectedValue.ToString() + ")";

            }
            if (ddl_faculty.SelectedValue != "")
            {
                _QryAverage += " and a.faculty_id = '" + ddl_faculty.SelectedValue.ToString() + "' and a.overall='Average'";
            }
            DataTable dtExcellent = new DataTable();
            DataTable dtGood = new DataTable();
            DataTable dtAverage = new DataTable();
            dtExcellent = MVC.DataAccess.ExecuteDataTable(_QryExcellent);
            dtGood = MVC.DataAccess.ExecuteDataTable(_QryGood);
            dtAverage = MVC.DataAccess.ExecuteDataTable(_QryAverage);
            /* Excellent --> 5 is the maximum value            
            * Good --> 4
            * Average --> 3
            * Poor --> 2
            *
            * */
            int excellentval = 0;
            int goodval = 0;
            int averageval = 0;
            int totalCount = 0;
            if (dtExcellent.Rows.Count > 0)
            {
                int excount = Convert.ToInt32(dtExcellent.Rows[0][0].ToString());
                excellentval = 5 * excount;
                totalCount = totalCount + excount;
            }
            if (dtGood.Rows.Count > 0)
            {
                int goodcount = Convert.ToInt32(dtGood.Rows[0][0].ToString());
                goodval = 4 * goodcount;
                totalCount = totalCount + goodcount;
            }
            if (dtAverage.Rows.Count > 0)
            {
                int avcount = Convert.ToInt32(dtAverage.Rows[0][0].ToString());
                averageval = 3 * avcount;
                totalCount = totalCount + avcount;
            }
            percentvalue = excellentval + goodval + averageval;
            if (percentvalue > 0)
            {
                decimal firstval = (percentvalue / totalCount);

                decimal secondval = (firstval / 5);

                overallpercent = (firstval / 5) * 100;
            }
            percentage = (int)(overallpercent);

        }
        lblPercent.Text = percentage.ToString();
    }
    public void filldrop()
    {
        _Qry = "select * from Onlinestudent_Software";

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_software.DataSource = dt;
        ddl_software.DataTextField = "Software_Name";
        ddl_software.DataValueField = "Software_Id";
        ddl_software.DataBind();
        ddl_software.Items.Insert(0, new ListItem("All", ""));
    }
    public void fillfaculty()
    {
        _Qry = "select * from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"].ToString() + "'";

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_faculty.DataSource = dt;
        ddl_faculty.DataTextField = "FacultyName";
        ddl_faculty.DataValueField = "Faculty_ID";
        ddl_faculty.DataBind();
        ddl_faculty.Items.Insert(0, new ListItem("All", ""));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (ddl_faculty.SelectedIndex > 0)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
 
                 
                  
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

    }
}
