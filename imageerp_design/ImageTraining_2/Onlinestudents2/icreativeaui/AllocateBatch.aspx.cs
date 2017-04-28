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
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;



public partial class Onlinestudents2_superadmin_AllocateBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, couname, couid, todate, holdate;
    int noofcls, weekday,endate;
    DateTime stdate, lastday;
    int yy = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            displaycourseonload();
            //ddl_labname.Items.Insert(0, new ListItem("Select", ""));

            //ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
            
            //display_track();
            //display_faculty();
            //display_lab();
            ddl_BatchCode.Items.Insert(0, new ListItem("Select", ""));
            Button1.Visible = false;
        }
       
    }
    private void display_track()
    {
        //lbl_track.Text = ddl_Track.SelectedValue.ToString();
        //if (lbl_track.Text == "Fast")
        //{
        //    ddl_slotfast.Visible = true;
        //    ddl_slotnormal.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Normal")
        //{
        //    ddl_slotfast.Visible = false;
        //    ddl_slotnormal.Visible = true;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Zip")
        //{
        //    ddl_slotfast.Visible = false;
        //    ddl_slotnormal.Visible = false;
        //    ddl_slotzip.Visible = true;
        //}
    }
   
    //private void fillmoduleddl()
    //{
    //    ddl_modname.Items.Clear();
    //    _Qry = "select module_content,module_Id from module_details where course_id='" + couid + "'";
    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

    //    ddl_modname.DataSource = dt1;
    //    ddl_modname.DataValueField = "module_Id";
    //    ddl_modname.DataTextField = "module_content";
    //    ddl_modname.DataBind();
    //    ddl_modname.Items.Insert(0, new ListItem("Select", ""));
    //}

    //private void display_faculty()
    //{
    //    _Qry = "select fac_name,faculty_id from faculty_details where centre_code='" + Session["SA_centre_code"] + "'";
       
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    ddl_facultyname.DataSource = dt;
    //    ddl_facultyname.DataValueField = "faculty_id";
    //    ddl_facultyname.DataTextField = "fac_name";
    //    ddl_facultyname.DataBind();
    //    ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    //}
    //private void display_lab()
    //{
    //    _Qry = "select lab_name from img_labdetails where centre_code='" + Session["SA_centre_code"] + "'";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    ddl_labname.DataSource = dt;
    //    ddl_labname.DataValueField = "lab_name";
    //    ddl_labname.DataTextField = "lab_name";
    //    ddl_labname.DataBind();
    //    ddl_labname.Items.Insert(0, new ListItem("Select", ""));
    //}

    private void fillgrid()
    {
       // _Qry = "select gen.student_id,per.enq_personal_name,gen.Track,cou.coursename,cou.program,enq.enq_personal_mobile from (adm_generalinfo gen inner join adm_personalparticulars per on per.student_id=gen.student_id) inner join img_enquiryform enq on gen.enq_number=enq.enq_number inner join img_coursedetails cou on gen.coursename=cou.course_id  where gen.coursename='"+ddl_coursename.SelectedValue+"' and gen.track='" + Request.QueryString["track"] + "' and gen.centre_code='" + Session["SA_centre_code"] + "'";
        //_Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=enq.enq_number where G.centre_code='" + Session["SA_centre_code"] + "'and SUB.software_id='" + ddl_coursename.SelectedValue + "' and G.track='" + Request.QueryString["track"] + "' GROUP by G.student_id";

        //_Qry = "Select Course_Code,C.Course_Id From OnlineStudent_Course c inner join module_details cs on ";
        //_Qry += " c.course_id=cs.course_id where Module_Id=" + ddl_coursename.SelectedValue + "";

        _Qry = "Select module_id from module_details where Module_Id=" + ddl_coursename.SelectedValue + "";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        string Software_ID = "";
        if (dr.HasRows)
        {
            dr.Read();

            //_Qry = " select cs.Course_ID,c.course_Code from Onlinestudent_Coursesoftware as cs inner join OnlineStudent_Course as c on ";
            //_Qry += " cs.course_Id=c.Course_ID";
            //_Qry += " where software_Id in(" + dr["module_id"] + ") group ";
            //_Qry += " by cs.course_ID,c.course_Code";

            _Qry = " select cs.Course_ID,c.course_Code from Onlinestudent_Coursesoftware as cs inner join OnlineStudent_Course as c on ";
            _Qry += " cs.course_Id=c.Course_ID";
            _Qry += " where module_id in(" + dr["module_id"] + ") group ";
            _Qry += " by cs.course_ID,c.course_Code";

            dr.Close();
        }

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        string Course_Code = "";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Course_Code == "")
            {
                Course_Code = "'"+dt.Rows[i]["Course_Code"].ToString()+"'";
            }
            else
            {
                Course_Code +=","+"'"+ dt.Rows[i]["Course_Code"].ToString()+"'";
            }
        }
        if (Course_Code == "")
        {
            _Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
            _Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
            _Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
            _Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
            _Qry += " enq.enq_number where cou.Program='' And G.centre_code='" + Session["SA_centre_code"] + "' And G.track<>'Batched' ";
            if (txt_search.Text == "" || txt_search.Text == null)
            {

            }
            else
            {
                _Qry += " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_search.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_search.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%') ";
            }
            _Qry = _Qry + " And (Select enq_enqstatus from img_enquiryform1 Where img_enquiryform1.enq_number=P.enq_number)<>'Dropped'";

            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";
        }
        else
        {
            _Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
            _Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
            _Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
            _Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
            _Qry += " enq.enq_number where cou.Program in (" + Course_Code + ") And G.centre_code='" + Session["SA_centre_code"] + "' And G.track<>'Batched' ";
            if (txt_search.Text == "" || txt_search.Text == null)
            {

            }
            else
            {
                _Qry += " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%' or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%') ";
            }
            _Qry = _Qry + " And (Select enq_enqstatus from img_enquiryform1 Where img_enquiryform1.enq_number=P.enq_number)<>'Dropped'";

            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";
        }

        //_Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
        //_Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
        //_Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
        //_Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
        //_Qry += " enq.enq_number where cou.Program in (" + Course_Code + ") And G.centre_code='" + Session["SA_centre_code"] + "' ";
        //_Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridvw.DataSource = dt12;
        Gridvw.DataBind();

        if (dt12.Rows.Count > 0)
        {
            tblBatch.Visible = true;
        }
        else
        {
            tblBatch.Visible = false;
        }

        //foreach (GridViewRow gr in Gridvw.Rows)
        //{
        //    Label lbl_bTrack = new Label();
        //    lbl_bTrack = ((Label)gr.FindControl("lbl_Bindtrack"));
        //    if (lbl_bTrack.Text == "Batched")
        //    {
        //        lbl_bTrack.ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //    {
        //        lbl_bTrack.ForeColor = System.Drawing.Color.Green;
        //    }
        //}
    }

    

    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + Request.QueryString["track"] + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT Module_Id,Module_Content from Module_Details ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        int abc = 0;
        _Qry = "Select System from online_students_labavail where Labname='" + lbl_Lab.Text + "'";
        int countss = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        int noofstudents = 0;

        foreach (GridViewRow roww in Gridvw.Rows)
        {
            CheckBox chbox = new CheckBox();
            chbox = (CheckBox)roww.FindControl("CheckBox1");
            if (chbox.Checked == true)
            {
                noofstudents = noofstudents + 1;
            }   

        }

        _Qry = "Select Count(*) from Batch_Details where Batch_Code='"+ddl_BatchCode.SelectedValue+"'";
        int countbb = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        //Response.Write("Count Is:" + countbb);
        //Response.End();

        int totalcount = noofstudents + countbb;
        int displayCount = countss - countbb;

        //Response.Write("Total Count Is:" + totalcount);
        //Response.Write("Countbb Is:" + countss);
        //Response.End();

        if (totalcount > countss)
        {
            if (displayCount == 0)
            {
                lblmsg1.Text = "This Batch is full";
                abc = 1;
            }
            else
            {
                lblmsg1.Text = "Please select only " + displayCount + " students for this batch";
                abc = 1;
            }
        }
        else
        {
            foreach (GridViewRow roww in Gridvw.Rows)
            {
                CheckBox chbox = new CheckBox();
                chbox = (CheckBox)roww.FindControl("CheckBox1");
                if (chbox.Checked == true)
                {
                    Label lbl = new Label();
                    lbl = (Label)roww.FindControl("lbl_stdid");
                    string stdid = lbl.Text;

                    Label lb_course = new Label();
                    lb_course = (Label)roww.FindControl("lbl_coursename");
                    string course = lb_course.Text;

                    Label lb_trak = new Label();
                    lb_trak = (Label)roww.FindControl("lbl_track");

                    //Response.Write(lbl_BatchStartDate.Text);
                    //Response.Write(lbl_BatchEndDate.Text);
                    //Response.End();

                    string dateFrom = "";
                    string dateTo = "";
                    if (lbl_BatchStartDate.Text != "")
                    {
                        string str = lbl_BatchStartDate.Text;
                        string[] split = str.Split('/');
                        dateFrom = split[2] + "-" + split[1] + "-" + split[0];
                    }

                    if (lbl_BatchEndDate.Text != "")
                    {
                        string str1 = lbl_BatchEndDate.Text;
                        string[] split1 = str1.Split('/');
                        dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    }

                    //Response.Write(dateFrom);
                    //Response.Write(dateTo);
                    //Response.End();

                    _Qry = "Select Count(*) from Batch_details where Batch_StudentId='" + stdid + "' And Batch_Time='" + lbl_Timing.Text + "'";

                    int cccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                    if (cccount > 0)
                    {
                        yy = yy + 1;
                    }
                    else
                    {
                        _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id ,";
                        _Qry += " batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate ,";
                        _Qry += " batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + ddl_BatchCode.SelectedValue + "', '" + Session["SA_centre_code"] + "',";
                        _Qry += "'" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "',";
                        _Qry += "'" + lbl_track.Text + "', '" + lbl_Slot.Text + "', '" + lbl_Timing.Text + "', '" + Convert.ToInt32(ViewState["FacultyId"]) + "',";
                        _Qry += "'" + lbl_Faculty.Text + "','" + dateFrom + "','" + dateTo + "', '" + lbl_Lab.Text + "','Inprogress',getdate())";//str_to_date('" + txt_enddate.Text + "','%d-%m-%Y')

                        //Response.Write(_Qry);
                        //Response.End();
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        _Qry1 = "update adm_generalinfo set Track='Batched' where student_id='" + stdid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);



                        btn_submit.Visible = false;
                        //Button1.Visible = true;
                        lblmsg1.Text = "*Batch Allocated sucessfully!";
                        fillgrid();
                        //DropDownList1.SelectedValue = "Select";
                        //ddl_labname.SelectedValue = "";
                        //ddl_facultyname.SelectedValue = "";

                        abc = abc + 1;
                    }
                }
            }
        }

            if (abc == 0)
            {
                lblmsg1.Text = "*Please select students to be batched!";
            }
            if (abc == 0 && yy > 0)
            {
                lblmsg1.Text = "*Selected student are not available in this batch timing!";
            }
        }         
    protected void ddl_coursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        //couname = ddl_coursename.SelectedItem.ToString();
        //lbl_coursename.Text = couname;
        //couid = ddl_coursename.SelectedValue.ToString();

        ////fillmoduleddl();
    
        //fillgrid();
       
    }

    protected void Gridvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridvw.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enterbatchcode.aspx");
    }
    //protected void ddl_modname_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //     ddl_software.Items.Clear();
    //    _Qry = "select software_id,software_name from module_details where module_id='" + ddl_modname.SelectedValue + "'";

    //    DataTable dt1 = new DataTable();
    //    dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    //split software
    //    if (dt1.Rows.Count > 0)
    //    {
    //         string id = dt1.Rows[0]["software_id"].ToString();
    //            string sft_name = dt1.Rows[0]["software_name"].ToString();
    //            string[] strSplitArr = id.Split(',');
    //            string[] strSplitArra = sft_name.Split(',');

    //            for (int i = 0; i < strSplitArra.Length; i++)
    //            {
    //                if (strSplitArra[i] != "")
    //                {
    //                    ddl_software.Items.Add(new ListItem(strSplitArra[i], strSplitArr[i]));
    //                }
    //            }         
    //        ddl_software.Items.Insert(0, new ListItem("Select", ""));
    //    }
    //}
    //This is the function to get the day of the week like monday=1,tuesday=2;
    //private static int dayOfWeek(DateTime adSource)
    //{

    //    // Calender Functionality cloned by used defined logic
    //    DayOfWeek dWeek = adSource.DayOfWeek;

    //    switch (dWeek)
    //    {

    //        case DayOfWeek.Monday:
    //            return 1;

    //        case DayOfWeek.Tuesday:
    //            return 2;

    //        case DayOfWeek.Wednesday:
    //            return 3;

    //        case DayOfWeek.Thursday:
    //            return 4;

    //        case DayOfWeek.Friday:
    //            return 5;

    //        case DayOfWeek.Saturday:
    //            return 6;

    //        case DayOfWeek.Sunday:
    //            return 0;

    //    }

    //    return 0;

    //}
    //public static DateTime getDate(string date)//date= 24-10-2007
    //{

    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");
    //    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("nl-NL");
    //    System.IFormatProvider format = new System.Globalization.CultureInfo("nl-NL", true);

    //    //string strdate=Convert.ToDateTime(date).ToString("dd/MM/yyyy"); //24-10-2007 not required
    //    DateTime date1 = DateTime.ParseExact(date, "dd/MM/yyyy", format);
    //    return date1; // 10-24-2007

    //}
    //private void datecalc()
    //{
    //    _Qry = "select Noofclasses from software_details where software_id='" + ddl_coursename.SelectedValue + "'";
    //    //Response.Write(_Qry);
    //    //Response.End();
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    if (dt.Rows.Count > 0)
    //    {
    //        noofcls = Convert.ToInt32(dt.Rows[0]["Noofclasses"].ToString());
    //    }

      
    //    DateTime stdat = getDate(txt_stratdate.Text.ToString());
     

    //            int  i=0;
    //            while (noofcls >= i)
    //            {
    //                holdate = "";
    //                _Qry = "select Hoilday_date from atn_hoilday where Hoilday_date=str_to_date('" + stdat + "','%d-%m-%Y')";

    //                DataTable dt6 = new DataTable();
    //                dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);

    //                if (dt6.Rows.Count > 0)
    //                {
    //                    holdate = dt6.Rows[0]["Hoilday_date"].ToString();
    //                }
    //                if (Request.QueryString["track"] == "Normal" && ddl_slotnormal.SelectedValue == "MWF")
    //                {
    //                        if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
    //                        {
                               
    //                            i = i + 1;
    //                            if (i == noofcls)
    //                            {
    //                                lastday = stdat;
    //                            }
    //                        }

    //                        stdat = stdat.AddDays(1);
                       
    //                }
    //                if (Request.QueryString["track"] == "Normal" && ddl_slotnormal.SelectedValue == "TTS")
    //                {
                       
    //                    if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
    //                    {
                          
    //                        i = i + 1;
    //                        if (i == noofcls)
    //                        {
    //                            lastday = stdat;
    //                        }
    //                    }

    //                    stdat = stdat.AddDays(1);
                       
    //                }
    //                if (Request.QueryString["track"] == "Zip" && ddl_slotzip.SelectedValue == "MWF")
    //                {
    //                    if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
    //                    {
                           
    //                        i = i + 1;
    //                        if (i == noofcls)
    //                        {
    //                            lastday = stdat;
    //                        }
    //                    }

    //                    stdat = stdat.AddDays(1);

    //                }
    //                if (Request.QueryString["track"] == "Zip" && ddl_slotzip.SelectedValue == "TTS")
    //                {
    //                    if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
    //                    {
                            
    //                        i = i + 1;
    //                        if (i == noofcls)
    //                        {
    //                            lastday = stdat;
    //                        }
    //                    }

    //                    stdat = stdat.AddDays(1);

    //                }
                 
    //                if (Request.QueryString["track"] == "Fast" && ddl_slotfast.SelectedValue == "Daily")
    //                {
    //                        if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
    //                        {
    //                            i = i + 1;
    //                            if (i == noofcls)
    //                            {
    //                                lastday = stdat;
    //                            }
    //                        }

    //                        stdat = stdat.AddDays(1);

    //                }
    //                if (Request.QueryString["track"] == "Zip" && ddl_slotzip.SelectedValue == "Daily")
    //                {
    //                    if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
    //                    {
    //                        i = i + 1;
    //                        if (i == noofcls)
    //                        {
    //                            lastday = stdat;
    //                        }
    //                    }

    //                    stdat = stdat.AddDays(1);

    //                }


                  
    //            }
    //            string dob = lastday.ToString();
    //            string[] strSplitArr = dob.Split(' ');
    //            string dob1 = strSplitArr[0].ToString();

    //            txt_enddate.Text = dob1;
              
       
    //}


    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid();

        HiddenField1.Value = "1";

        _Qry = "Select Batch_Code From Batch_Details Where Batch_Module_Content='" + ddl_coursename.SelectedItem + "' And Centre_Code='" + Session["SA_centre_code"] + "' And Batch_Status='Inprogress' And (SELECT convert(varchar, Batch_startdate, 112)) >= (SELECT convert(varchar, getdate(), 112)) Group By Batch_Code";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            ddl_BatchCode.DataSource = dt;
            ddl_BatchCode.DataTextField = "Batch_Code";
            ddl_BatchCode.DataValueField = "Batch_Code";
            ddl_BatchCode.DataBind();
            ddl_BatchCode.Items.Insert(0, new ListItem("Select", ""));

        //ddl_BatchCode.Items.Insert(0, new ListItem("Select", ""));
        //ddl_BatchCode.Items.Remove("Select");

        //_Qry = "Select Batch_Code,Batch_SoftwareName,Batch_Track,Batch_Slot,Batch_Time,Batch_Faculty,Batch_labname,Batch_startdate,Batch_endate Where Batch_softwareName='" + ddl_coursename.SelectedItem + "' And Batch_Track='" + ddl_Track.SelectedValue + "' And Centre_Code='" + Session["SA_centre_code"] + "' And Bach_Status='Inprogress'";

        //ddl_BatchCode.SelectedValue = "";
        lbl_track.Text = "";
        lbl_Timing.Text = "";
        lbl_Slot.Text = "";
        lbl_Lab.Text = "";
        lbl_Faculty.Text = "";
        //lbl_coursename.Text = "";
        lbl_BatchStartDate.Text = "";
        lbl_BatchEndDate.Text = "";

        lbl_coursename.Text = ddl_coursename.SelectedItem.ToString();
        //lbl_track.Text = dt.Rows[0][""]
        //display_track();
    }
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string test = lbl_coursename.Text;
    //    if (test == "" || test == null)
    //    {
    //        lblmsg1.Text = "Please enter software name";
    //    }
    //    else
    //    {
    //        if (lbl_track.Text == "Fast")
    //        {
    //            _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]='free'";

    //        }
    //        if (lbl_track.Text == "Normal")
    //        {
    //            _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";
    //        }
    //        if (lbl_track.Text == "Zip")
    //        {
    //            _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";
    //        }



    //        DataTable dt = new DataTable();
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

    //        ddl_labname.DataSource = dt;
    //        ddl_labname.DataTextField = "Labname";
    //        ddl_labname.DataValueField = "LabId";
    //        ddl_labname.DataBind();

    //        ddl_labname.Items.Remove("Select");
    //        ddl_labname.Items.Insert(0, new ListItem("Select", ""));


    //        if (lbl_track.Text == "Fast")
    //        {
    //            _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]='free'";

    //        }
    //        if (lbl_track.Text == "Normal")
    //        {
    //            _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";

    //        }
    //        if (lbl_track.Text == "Zip")
    //        {
    //            _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
    //            _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";

    //        }

    //        //_Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
    //        //_Qry += " And [" + DropDownList1.SelectedValue + "]='free'";


    //        DataTable dt12 = new DataTable();
    //        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);

    //        ddl_facultyname.DataSource = dt12;
    //        ddl_facultyname.DataTextField = "FacultyName";
    //        ddl_facultyname.DataValueField = "Faculty_Id";
    //        ddl_facultyname.DataBind();

    //        ddl_facultyname.Items.Remove("Select");
    //        ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    //    }
    //}

    protected void ddl_BatchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        _Qry = "Select Batch_Code,Batch_Module_Content,Batch_Track,Batch_FacultyId,Batch_Slot,Batch_Time,Batch_Faculty,Batch_labname,CONVERT(VARCHAR(10),Batch_startdate,103) as Batch_startdate,";
        _Qry += " CONVERT(VARCHAR(10),Batch_enddate,103) as Batch_enddate From Batch_Details Where Batch_Module_Content='" + ddl_coursename.SelectedItem + "' ";
        _Qry += " And Centre_Code='" + Session["SA_centre_code"] + "' And Batch_Status='Inprogress' And Batch_Code='" + ddl_BatchCode .SelectedValue+ "'";
        _Qry += " Group By Batch_Code,Batch_FacultyId,Batch_Module_Content,Batch_Track,Batch_Slot,Batch_Time,Batch_Faculty,Batch_labname,";
        _Qry += " Batch_startdate,Batch_enddate";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            lbl_Timing.Text = dt.Rows[0]["Batch_Time"].ToString();
            lbl_Lab.Text = dt.Rows[0]["Batch_labname"].ToString();
            lbl_Faculty.Text = dt.Rows[0]["Batch_Faculty"].ToString();
            lbl_Slot.Text = dt.Rows[0]["Batch_Slot"].ToString();
            lbl_BatchStartDate.Text = dt.Rows[0]["Batch_startdate"].ToString();
            lbl_BatchEndDate.Text = dt.Rows[0]["Batch_enddate"].ToString();
            lbl_track.Text = dt.Rows[0]["Batch_Track"].ToString();
            //Response.Write(lbl_BatchStartDate.Text);
            //Response.Write("<br/>" + lbl_BatchEndDate.Text);
            //Response.End();

            ViewState["FacultyId"] = dt.Rows[0]["Batch_FacultyId"].ToString();
        }
        else
        {
            lbl_track.Text = "";
            lbl_Timing.Text = "";
            lbl_Slot.Text = "";
            lbl_Lab.Text = "";
            lbl_Faculty.Text = "";
            lbl_BatchStartDate.Text = "";
            lbl_BatchEndDate.Text = "";
        }

    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllocateBatch.aspx");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllocateBatch.aspx");
    }
}

