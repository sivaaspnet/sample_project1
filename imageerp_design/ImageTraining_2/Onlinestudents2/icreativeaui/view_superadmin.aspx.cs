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
using System.IO;

public partial class Onlinestudents2_superadmin_view_superadmin : System.Web.UI.Page
{
    string _Qry, strLine;

    #region for Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["cencod"] != "" && Request.QueryString["Enq"] == "1")
            {
                enqtable.Visible = true;
                admtable.Visible = false;
                Table1.Visible = false;
                tablestudent.Visible = false;
                gridenquiry();
            }
            if (Request.QueryString["cencod"] != "" && Request.QueryString["Adm"] == "1")
            {
                enqtable.Visible = false;
                admtable.Visible = true;
                Table1.Visible = false;
                tablestudent.Visible = false;
                fillgridAdmission();
            }
            if (Request.QueryString["cencod"] != "" && Request.QueryString["Batch"] == "1")
            {
                enqtable.Visible = false;
                admtable.Visible = false;
                Table1.Visible = true;
                tablestudent.Visible = false;
                fillgridbatch();
                
            }
            if (Request.QueryString["cencod"] != "" && Request.QueryString["studlist"] == "1" && Request.QueryString["bthcode"] != "")
            {
                enqtable.Visible = false;
                admtable.Visible = false;
                Table1.Visible = false;
                tablestudent.Visible = true;
                studentview();
               
            
            }
           
        }
    }
    #endregion

    #region for Displaying the Equiry Details for the Super Admin
    private void gridenquiry()
    {
        try
        {
            if (Request.QueryString["cencod"] != "")
            {
                _Qry = "select enq.enq_number,enq.enq_personal_name,f2.enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq inner join img_enquiryform1 f2 on enq.enq_id=f2.enq_id where enq.centre_code='" + Request.QueryString["cencod"] + "' ";

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        { 
        
        }
    }
    #endregion

    #region for Paging the Equiry Details for the Super Admin
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridenquiry();
    }
    #endregion

    #region for displaying the admission details for the Super Admin 
    private void fillgridAdmission()
    {
        try
        {
            if (Request.QueryString["cencod"] != "")
            {
                _Qry = "select a.student_id,a.enq_personal_name,(select m.coursename from img_coursedetails m inner join adm_generalinfo gen on gen.coursename=m.course_id where gen.student_id=a.student_id)as coursename from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where b.centre_code='" + Request.QueryString["cencod"] + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                Gridview_admission.DataSource = dt;
                Gridview_admission.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region for paging for admission
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgridAdmission();
    }
    #endregion

    #region for Displaying the batch details for the Super Admin
    private void fillgridbatch()
    {
        try
        {
            if (Request.QueryString["cencod"] != "")
            {
                _Qry = "select a.batch_code,a.batch_track,a.batch_slot,a.batch_time,a.batch_faculty,convert(varchar,a.batch_startdate,3) as batch_startdate,convert(varchar,a.batch_enddate,3) as batch_enddate,a.batch_facultyid,a.batch_softwarename,(select count(*) from batch_details where centre_code='" + Request.QueryString["cencod"] + "' and batch_status='Inprogress' and batch_code=a.batch_code)as noofstudents from batch_details a where a.centre_code='" + Request.QueryString["cencod"] + "'  and a.batch_status='Inprogress' group by a.batch_code,";
                _Qry += "a.batch_track,a.batch_slot,a.batch_time,a.batch_faculty,batch_startdate,batch_enddate,a.batch_facultyid,a.batch_softwarename,noofstudents";

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                Gridview2.DataSource = dt;
                Gridview2.DataBind();
                if (dt.Rows.Count == 0)
                {
                    Button2.Visible = false;
                }


               
            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region for paging the batch detail
    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview2.PageIndex = e.NewPageIndex;
        fillgridbatch();
    }
    #endregion

    #region for displaying the students detail for Super Admin
    private void studentview()
    {
        try
        {
            if (Request.QueryString["cencod"] != "")
            {
              //  _Qry = "select a.batch_studentid,b.enq_personal_name from batch_details a inner join adm_personalparticulars b on b.student_id=a.batch_studentid  where a.batch_code='" + Request.QueryString["bthcode"] + "' and a.centre_code='" + Request.QueryString["cencod"] + "' and a.batch_status='Inprogress'  group by a.batch_studentid";

                _Qry = "select a.batch_code as BatchCode,a.batch_track as Track ,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,a.batch_studentid as StudentId,b.enq_personal_name as Studentname,convert(varchar,a.batch_startdate,3) as Batchstartdate,convert(varchar,a.batch_enddate,3) as Batchenddate,a.batch_softwarename as Softwarename from batch_details a inner join adm_personalparticulars b on b.student_id=a.batch_studentid where a.centre_code='" + Request.QueryString["cencod"] + "'  and a.batch_status='Inprogress' and  a.batch_code='" + Request.QueryString["bthcode"] + "' group by a.batch_studentid,";
                _Qry += "a.batch_track as Track ,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,a.batch_studentid as StudentId,b.enq_personal_name as Studentname,Batchenddate,a.batch_softwarename as Softwarename";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                GridView3.DataSource = dt;
                GridView3.DataBind();

                GridView4.DataSource = dt;
                GridView4.DataBind();

                if (dt.Rows.Count == 0)
                {
                    Button3.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region for paging students dtail for the super Admin
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        studentview();
    }
    #endregion

    #region for Redirecting to display the student info
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "stud")
            {

                if (Request.QueryString["cencod"] != "" && e.CommandArgument.ToString() != "")
                {

                    Response.Redirect("view_superadmin.aspx?cencod=" + Request.QueryString["cencod"] + "&studlist=1&bthcode=" + e.CommandArgument.ToString() + "");
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region for going back to the batch detail
    protected void Button1_Click(object sender, EventArgs e)
    {
         Response.Redirect("view_superadmin.aspx?cencod=" + Request.QueryString["cencod"] +"&Batch=1");
    }
#endregion

    #region for batch excel
    private void batchexcel()
    {
        try
        {

            string fileExcel, filePath, fileName, strLine;


            FileStream objFileStream;
            StreamWriter objStreamWriter;
            Random nRandom = new Random(DateTime.Now.Millisecond);

            //Create a random file name.
            fileExcel = "Batch-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            //  fileExcel = "t" + nRandom.Next().ToString() + ".xls";

            //Set a virtual folder to save the file.
            //Make sure to change the application name to match your folder.
            filePath = Server.MapPath("excel_batch");
            fileName = filePath + "\\" + fileExcel;

            //Use FileSystem objects to create the .xls file.
            objFileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            objStreamWriter = new StreamWriter(objFileStream);

            //Use a DataReader object to connect to the Pubs database.
            //MySqlConnection Conn = new MySqlConnection(obj.connectionstring);
            //Conn.Open();

            SqlConnection con = new SqlConnection(MVC.DataAccess.ConnectionString);
            con.Open();

            if (Request.QueryString["cencod"] != "")
            {
                _Qry = "select a.batch_code as BatchCode,a.batch_track as Track,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,convert(varchar,a.batch_startdate,3) as BatchStartdate,convert(varchar,a.batch_enddate,3) as BatchEnddate,a.batch_facultyid as FacultyId,a.batch_softwarename as Softwarename,(select count(*) from batch_details where centre_code='" + Request.QueryString["cencod"] + "' and batch_status='Inprogress' and batch_code=a.batch_code)as NoofStudents from batch_details a where a.centre_code='" + Request.QueryString["cencod"] + "'  and a.batch_status='Inprogress' group by a.batch_code,";
                _Qry += "a.batch_track as Track,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,BatchStartdate,BatchEnddate,a.batch_facultyid as FacultyId,a.batch_softwarename as Softwarename,NoofStudents";
            }
            //MySqlCommand cmd = new MySqlCommand(_Qry, Conn);
            //MySqlDataReader dr = cmd.ExecuteReader();

            SqlCommand cmd = new SqlCommand(_Qry, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();



            //Initialize the string that is used to build the file.
            strLine = "";

            //Enumerate the field names and the records that are used to build 
            //the file.
            for (int i = 0; i <= dr.FieldCount - 1; i++)
            {
                strLine = strLine + dr.GetName(i).ToString() + Convert.ToChar(9);

            }

            //Write the field name information to the file.

            strLine = strLine + Convert.ToChar(13);
            //Reinitialize the string for data.


            //Enumerate the database that is used to populate the file.
            while (dr.Read())
            {
                for (int i = 0; i <= dr.FieldCount - 1; i++)
                {
                    strLine = strLine + dr.GetValue(i).ToString() + Convert.ToChar(9);

                }
                strLine = strLine + Convert.ToChar(13);

            }
            objStreamWriter.WriteLine(strLine);
            con.Close();
            //con.Close();
            dr.Close();
            objStreamWriter.Close();
            objFileStream.Close();

            //Include a link to the Excel file.
            Button2.Visible = false;
            HyperLink2.Text = "Open Excel";
            HyperLink2.NavigateUrl = "excel_batch/" + fileExcel;


        }
        catch (Exception ex)
        {

        }


    }
    #endregion


    #region for Exporting Batch Details to Excel
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string fileExcel;

            fileExcel = "Batch-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileExcel));
            Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    //  add the header row to the table
                    if (Gridview2.HeaderRow != null)
                    {
                        PrepareControlForExport(Gridview2.HeaderRow);
                        table.Rows.Add(Gridview2.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in Gridview2.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (Gridview2.FooterRow != null)
                    {
                        PrepareControlForExport(Gridview2.FooterRow);
                        table.Rows.Add(Gridview2.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        { 
        
        }
 
    }
    #endregion

    #region for PrepareControlForExport
    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }
    #endregion


    #region for Exporting Student Details to Excel
    private void studentexcel()
    { 
    try
        {
            string fileExcel, filePath, fileName, strLine;
            FileStream objFileStream;
            StreamWriter objStreamWriter;
            Random nRandom = new Random(DateTime.Now.Millisecond);

            //Create a random file name.
            fileExcel = "Student-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            //  fileExcel = "t" + nRandom.Next().ToString() + ".xls";

            //Set a virtual folder to save the file.
            //Make sure to change the application name to match your folder.
            filePath = Server.MapPath("excel_student");
            fileName = filePath + "\\" + fileExcel;

            //Use FileSystem objects to create the .xls file.
            objFileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            objStreamWriter = new StreamWriter(objFileStream);

            //Use a DataReader object to connect to the Pubs database.
            //MySqlConnection Conn = new MySqlConnection(obj.connectionstring);
            //Conn.Open();

            SqlConnection con = new SqlConnection(MVC.DataAccess.ConnectionString);
            con.Open();
            if (Request.QueryString["cencod"] != "")
            {
                _Qry = "select a.batch_code as BatchCode,a.batch_track as Track ,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,a.batch_studentid as StudentId,b.enq_personal_name as Studentname,convert(varchar,a.batch_startdate,3) as Batchstartdate,convert(varchar,a.batch_enddate,3) as Batchenddate,a.batch_softwarename as Softwarename from batch_details a inner join adm_personalparticulars b on b.student_id=a.batch_studentid where a.centre_code='" + Request.QueryString["cencod"] + "'  and a.batch_status='Inprogress' and  a.batch_code='" + Request.QueryString["bthcode"] + "' group by a.batch_studentid,";
                _Qry += "a.batch_track as Track ,a.batch_slot as Slot,a.batch_time as BatchTime,a.batch_faculty as Facultyname,a.batch_studentid as StudentId,b.enq_personal_name as Studentname,Batchstartdate,Batchenddate,a.batch_softwarename as Softwarename";
            }
            //MySqlCommand cmd = new MySqlCommand(_Qry, Conn);
            //MySqlDataReader dr = cmd.ExecuteReader();
            SqlCommand cmd = new SqlCommand(_Qry, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();



            //Initialize the string that is used to build the file.
            strLine = "";

            //Enumerate the field names and the records that are used to build 
            //the file.
            for (int i = 0; i <= dr.FieldCount - 1; i++)
            {
                strLine = strLine + dr.GetName(i).ToString() + Convert.ToChar(9);

            }

            //Write the field name information to the file.

            strLine = strLine + Convert.ToChar(13);
            //Reinitialize the string for data.


            //Enumerate the database that is used to populate the file.
            while (dr.Read())
            {
                for (int i = 0; i <= dr.FieldCount - 1; i++)
                {
                    strLine = strLine + dr.GetValue(i).ToString() + Convert.ToChar(9);

                }
                strLine = strLine + Convert.ToChar(13);

            }
            objStreamWriter.WriteLine(strLine);
            con.Close();
            dr.Close();
            objStreamWriter.Close();
            objFileStream.Close();

            //Include a link to the Excel file.
            Button3.Visible = false;
            HyperLink1.Text = "Open Excel";
            HyperLink1.NavigateUrl = "excel_student/" + fileExcel;
      }
        catch (Exception ex)
        {

        }
    }
    
    #endregion


    #region for Exporting Studentdetail
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string fileExcel;

            fileExcel = "Student-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileExcel));
            Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    //  add the header row to the table
                    if (GridView4.HeaderRow != null)
                    {
                        PrepareControlForExport(GridView4.HeaderRow);
                        table.Rows.Add(GridView4.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in GridView4.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (GridView4.FooterRow != null)
                    {
                        PrepareControlForExport(GridView4.FooterRow);
                        table.Rows.Add(GridView4.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }

        }
        catch (Exception ex)
        { 
        
        }
    }
    #endregion

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string fileExcel;

            fileExcel = "Enquiry-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileExcel));
            Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    //  add the header row to the table
                    if (GridView1.HeaderRow != null)
                    {
                        PrepareControlForExport(GridView1.HeaderRow);
                        table.Rows.Add(GridView1.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (GridView1.FooterRow != null)
                    {
                        PrepareControlForExport(GridView1.FooterRow);
                        table.Rows.Add(GridView1.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            string fileExcel;

            fileExcel = "Enrolment-" + Request.QueryString["cencod"] + "-" + System.DateTime.Now.Millisecond.ToString() + ".xls";
            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileExcel));
            Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    //  add the header row to the table
                    if (Gridview_admission.HeaderRow != null)
                    {
                        PrepareControlForExport(Gridview_admission.HeaderRow);
                        table.Rows.Add(Gridview_admission.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in Gridview_admission.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (Gridview_admission.FooterRow != null)
                    {
                        PrepareControlForExport(Gridview_admission.FooterRow);
                        table.Rows.Add(Gridview_admission.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}
