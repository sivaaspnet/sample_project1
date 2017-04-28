using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (! IsPostBack)
        {
        year();
        faculty();
        }
    }

    private void gridtable()
    {
        qry = "select  * from batch_details as bd INNER JOIN Onlinestudent_MasterAttendance as at on at.batch_code=bd.batch_code where batch_facultyId='"+DropDownList3.SelectedValue+"'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            lbl_month.Text = DropDownList1.SelectedValue;
            lbl_year.Text = DropDownList2.SelectedValue;
            int year = Convert.ToInt32(lbl_year.Text);
            int month = Convert.ToInt32(lbl_month.Text);
      
            int days = System.DateTime.DaysInMonth(year, month);
          
            

            string tab = "<table border='1' style=' border-collapse:collapse '><tr style='background:#328AA4;color:white;  font-weight: bold;' align='center'><td colspan='3'>" + DropDownList1.SelectedItem.Text + "</td><td></td><td colspan='3' align='center'>" + year + "</td></tr><tr style='font-weight:bold '><td>Day</td><td>7AM - 9AM</td><td>9AM - 11Am</td><td>11AM-1PM</td><td>1PM-3PM</td><td>3PM-5PM</td><td>5PM-7PM</td></tr>";
            for (int i = 1; i <= days; i++)
            {

      
                string date = i.ToString() + "/" + lbl_month.Text + "/" + year.ToString();

                tab = tab + "<tr><td>" + i.ToString("00") + "</td><td>" + getResultValaues(dt, "batch_time='7amto9am' and class_date='" + date + "'") + "</td><td>" + getResultValaues(dt, "batch_time='9amto11am' and class_date='" + date + "'") + "</td><td>" + getResultValaues(dt, "batch_time='11amto1pm' and class_date='" + date + "'") + "</td><td>" + getResultValaues(dt, "batch_time='1pmto3pm' and class_date='" + date + "'") + "</td><td>" + getResultValaues(dt, "batch_time='3pmto5pm' and class_date='" + date + "'") + "</td><td>" + getResultValaues(dt, "batch_time='5pmto7pm' and class_date='" + date + "'") + "</td></tr>";
            }
            tab = tab + "</table>";
            lbl_grid.Text = tab;
        }
        else
        {
            lbl_grid.Text = "No Record";

        }  
    }
    string getResultValaues(DataTable dt, string expression)
    {
        string res = "";
        DataRow[] dr=new DataRow[1000];
        dr=dt.Select(expression);
        for (int i = 0; i < dr.Length; i++)
        {
            if (res == "")
            {
             res=dr[i]["class_content"].ToString();
            }
            else
            {
                res = "," + dr[i]["class_content"].ToString();
            }
        }
        return res;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        gridtable();
    }


    private void year()
    {
        DropDownList2.Items.Clear();
        for (int i = 2010; i < 2075; i++)
        {
            DropDownList2.Items.Add(i.ToString());
        }
        
      
        DropDownList2.Items.Insert(0, new ListItem("-Select-", ""));

    }

    private void faculty()
    {
        qry = "select  FacultyName,Faculty_ID from onlinestudentsfacultydetails";
        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "FacultyName";
            DropDownList3.DataValueField = "Faculty_ID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("-Select-", ""));
        }
       

    }
}
