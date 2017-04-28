using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ImageTraining_2_Onlinestudents2_superadmin_studentbatchreport : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();

    }
    private void fillgrid()
    {
        _Qry = "select  distinct class_content,Student_Id,Student_Name,convert(varchar,cast (classdate as datetime),103 ) as Date_Attendance,isnull(Student_Reason,'Nil') as Student_Reason,Attendance_Status from Onlinestudent_Attendance inner join erp_batchschedule sce on sce.studentId=Student_Id and content_id=subContentId where Student_Id='" + Request.QueryString["studentid"].ToString() + "' and Batch_Code='" + Request.QueryString["batchcode"].ToString() + "' and Centre_Code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            studentid.Visible = true;
            studentname.Visible = true;
            studentid.Text = dt.Rows[0]["student_id"].ToString();
            studentname.Text = dt.Rows[0]["Student_Name"].ToString();
        }
        else
        {
            t1.Visible = false;
            t2.Visible = false;
            studentid.Visible = false;
            studentname.Visible = false;
        }


        DataTable dt1 = new DataTable();
        dt1.Columns.Add(new DataColumn("class_content", System.Type.GetType("System.String")));
        dt1.Columns.Add(new DataColumn("Student_Id", System.Type.GetType("System.String")));
        dt1.Columns.Add(new DataColumn("Student_Name", System.Type.GetType("System.String")));
        dt1.Columns.Add(new DataColumn("Date_Attendance", System.Type.GetType("System.String")));
        dt1.Columns.Add(new DataColumn("Student_Reason", System.Type.GetType("System.String")));
        dt1.Columns.Add(new DataColumn("Attendance_Status", System.Type.GetType("System.String")));
        DataRow dratt = dt1.NewRow();

      

        foreach (DataRow drs in dt.Rows)
        {
            dratt = dt1.NewRow();
            dratt["Date_Attendance"] = drs["Date_Attendance"];
            dratt["Student_Reason"] = drs["Student_Reason"];
            dratt["Student_Id"] = drs["Student_Id"];
            dratt["Student_Name"] = drs["Student_Name"];
            dratt["Attendance_Status"] = drs["Attendance_Status"];
            dratt["class_content"] = drs["class_content"];
            dt1.Rows.Add(dratt);
        }


        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }

   string datesplit(string value)
    {
        string str = value;
        string[] split = str.Split('/');
        string dateFrom = split[2] + "-" + split[1] + "-" + split[0];
        return dateFrom;
   }

   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       GridView1.PageIndex = e.NewPageIndex;
       fillgrid();
   }
}
