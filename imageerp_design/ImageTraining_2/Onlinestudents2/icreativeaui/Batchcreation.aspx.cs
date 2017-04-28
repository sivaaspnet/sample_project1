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

public partial class Onlinestudents2_superadmin_Batchcreation : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, couname, couid, todate, holdate;
    int noofcls, weekday,endate;
    DateTime stdate, lastday;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            displaycourseonload();
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));

            ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
          
            //display_track();
            //display_faculty();
            //display_lab();
            Button1.Visible = false;
        }
       
    }
    private void display_track()
    {
        lbl_track.Text = ddl_Track.SelectedValue.ToString();
        if (lbl_track.Text == "Fast")
        {
            ddl_slotfast.Visible = true;
            ddl_slotnormal.Visible = false;
            ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Normal")
        {
            ddl_slotfast.Visible = false;
            ddl_slotnormal.Visible = true;
            ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Zip")
        {
            ddl_slotfast.Visible = false;
            ddl_slotnormal.Visible = false;
            ddl_slotzip.Visible = true;
        }
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

    private void display_faculty()
    {
        _Qry = "select fac_name,faculty_id from faculty_details where centre_code='" + Session["SA_centre_code"] + "'";
       
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_facultyname.DataSource = dt;
        ddl_facultyname.DataValueField = "faculty_id";
        ddl_facultyname.DataTextField = "fac_name";
        ddl_facultyname.DataBind();
        ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    }
    private void display_lab()
    {
        _Qry = "select lab_name from img_labdetails where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_labname.DataSource = dt;
        ddl_labname.DataValueField = "lab_name";
        ddl_labname.DataTextField = "lab_name";
        ddl_labname.DataBind();
        ddl_labname.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillgrid()
    {
       // _Qry = "select gen.student_id,per.enq_personal_name,gen.Track,cou.coursename,cou.program,enq.enq_personal_mobile from (adm_generalinfo gen inner join adm_personalparticulars per on per.student_id=gen.student_id) inner join img_enquiryform enq on gen.enq_number=enq.enq_number inner join img_coursedetails cou on gen.coursename=cou.course_id  where gen.coursename='"+ddl_coursename.SelectedValue+"' and gen.track='" + Request.QueryString["track"] + "' and gen.centre_code='" + Session["SA_centre_code"] + "'";
        //_Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=enq.enq_number where G.centre_code='" + Session["SA_centre_code"] + "'and SUB.software_id='" + ddl_coursename.SelectedValue + "' and G.track='" + Request.QueryString["track"] + "' GROUP by G.student_id";

        _Qry = "Select Course_Code,C.Course_Id From OnlineStudent_Course c inner join OnlineStudent_CourseSoftware cs on ";
        _Qry += " c.course_id=cs.course_id where Software_Id="+ddl_coursename.SelectedValue+"";

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
            _Qry += " enq.enq_number where cou.Program='' And G.centre_code='" + Session["SA_centre_code"] + "' And G.track='" + ddl_Track.SelectedValue + "' ";
            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";
        }
        else
        {
            _Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
            _Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
            _Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
            _Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
            _Qry += " enq.enq_number where cou.Program in (" + Course_Code + ") And G.centre_code='" + Session["SA_centre_code"] + "' And G.track='" + ddl_Track.SelectedValue + "' ";
            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";
        }

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridvw.DataSource = dt12;
        Gridvw.DataBind();
    }


    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + Request.QueryString["track"] + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT software_Id,software_name from onlinestudent_software ORDER by software_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "software_Id";
        ddl_coursename.DataTextField = "software_name";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //datecalc();
        //Response.Write("Track Is:" + lbl_track.Text);
        string Lab_Track = "";
        string Faculty_Track = "";
        string slot = "";
        string slot1 = "";
        string LabSLot = "";
        string FacultySlot = "";
        _Qry = "Select [" + DropDownList1.SelectedValue + "] as Lab_Track From online_students_labavail where LabId=" + ddl_labname.SelectedValue + "";
        
        //Response.Write(_Qry);
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        LabSLot = dt.Rows[0]["Lab_Track"].ToString();
        if (lbl_track.Text == "Fast")
        {
            slot1 = ddl_slotfast.SelectedValue.ToString(); 
            if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
            {
                Lab_Track = "Lab Not Available";
            }
            else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
            {
                Lab_Track = "Lab Not Available";
            }
            else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
            {
                Lab_Track = "Lab Not Available";
            }
            else
            {
                Lab_Track = "free";
                ddl_slotfast.Visible = true;
            }
            ddl_slotnormal.Visible = false;
            ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Normal")
        {
            slot1 = ddl_slotnormal.SelectedValue.ToString();
            string Track = dt.Rows[0]["Lab_Track"].ToString();
            if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
            {
                Lab_Track = "TTS";
            }
            else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
            {
                Lab_Track = "MWF";
            }
            else if (dt.Rows[0]["Lab_Track"] == "Daily")
            {
                Lab_Track = "Lab Not Available";
            }
            else
            {
                Lab_Track = "free";
                ddl_slotnormal.Visible = true;
            }
            ddl_slotfast.Visible = false;
            ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Zip")
        {
            slot1 = ddl_slotzip.SelectedValue.ToString();
            if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
            {
                Lab_Track = "TTS";
            }
            else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
            {
                Lab_Track = "MWF";
            }
            else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
            {
                Lab_Track = "Lab Not Available";
            }
            else
            {
                Lab_Track = "free";
                ddl_slotzip.Visible = true;
            }
            ddl_slotfast.Visible = false;
            ddl_slotnormal.Visible = false;
        }

        _Qry = "Select [" + DropDownList1.SelectedValue + "] as Faculty_Track From Onlinestudentsfacultydetails where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
        //Response.Write(_Qry);
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        FacultySlot = dt12.Rows[0]["Faculty_Track"].ToString();
        if (lbl_track.Text == "Fast")
        {
            if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
            {
                Faculty_Track = "Lab Not Available";
            }
            else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
            {
                Faculty_Track = "Lab Not Available";
            }
            else if (dt12.Rows[0]["Faculty_Track"].ToString() == "Daily")
            {
                Faculty_Track = "Lab Not Available";
            }
            else
            {
                //ddl_slotfast.Visible = true;
                Faculty_Track = "free";
                slot=ddl_slotfast.SelectedValue.ToString();
            }
            //ddl_slotnormal.Visible = false;
            //ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Normal")
        {
            string Track = dt12.Rows[0]["Faculty_Track"].ToString();
            if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
            {
                Faculty_Track = "TTS";
            }
            else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
            {
                Faculty_Track = "MWF";
            }
            else if (dt12.Rows[0]["Faculty_Track"] == "Daily")
            {
                Faculty_Track = "Lab Not Available";
            }
            else
            {
                //ddl_slotnormal.Visible = true;
                Faculty_Track = "free";
                slot=ddl_slotnormal.SelectedValue.ToString();
            }
            //ddl_slotfast.Visible = false;
            //ddl_slotzip.Visible = false;
        }
        if (lbl_track.Text == "Zip")
        {
            if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
            {
                Faculty_Track = "TTS";
            }
            else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
            {
                Faculty_Track = "MWF";
            }
            else if (dt12.Rows[0]["Faculty_Track"].ToString() == "Daily")
            {
                Faculty_Track = "Lab Not Available";
            }
            else
            {
//                ddl_slotzip.Visible = true;
                Faculty_Track = "free";
                slot=ddl_slotzip.SelectedValue.ToString();
            }
            //ddl_slotfast.Visible = false;
            //ddl_slotnormal.Visible = false;
        }
        int i = 0;

        if (Lab_Track == slot1)
        {
            if (slot1 == Faculty_Track)
            {
                i = 100;
            }
            else
            {
                lblmsg1.Text = "Faculty Not Available for this slot";
            }
        }
        else if (Faculty_Track == slot1)
        {
            if (slot1 == Lab_Track)
            {
                i = 100;
            }
            else
            {
                lblmsg1.Text = "Lab Not available for this slot";
            }
        }
        else if (Lab_Track == "free" && Faculty_Track != "free")
        {
            if (slot1 == Faculty_Track)
            {
                i = 100;
            }
            else
            {
                lblmsg1.Text = "Faculty Not available for this slot";
            }
        }
        else if (Faculty_Track == "free" && Lab_Track!="free")
        {
            if (slot1 == Lab_Track)
            {
                i = 100;
            }
            else
            {
                lblmsg1.Text = "Lab Not available for this slot";
            }
        }
        else if (Faculty_Track == "free" && Lab_Track == "free")
        {
                i = 100;
        }
        else 
        {
            lblmsg1.Text = "Lab and Faculty not available for this slot";
        }

        //Response.Write("Lab_Track:" + Lab_Track);
        //Response.Write("Faculty_Track:" + Faculty_Track);
        //Response.Write("Slot Is:" + slot1);
        ////Response.Write("Msg Is :" + lblmsg1.Text);
        ////Response.Write("Value Of I is:" + i);
        //Response.End();

        if (i == 100)
        {
            _Qry = "select count(*) as cnt from batch_details where centre_code='" + Session["SA_centre_code"] + "' group by batch_code";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                BatchCount = Convert.ToString(dt1.Rows.Count + 1);
            }
            else
            {
                BatchCount = "1";
            }
            int yearr = System.DateTime.Now.Year;
            string centrcode = Session["SA_centre_code"].ToString();
            string tim = DropDownList1.SelectedValue;
            string[] strSplitArr = tim.Split('-');

            batch_code = "BC" + yearr + strSplitArr[0] + "-" + centrcode + "-" + BatchCount;

            int abc = 0;
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
                    string stdtrack = lb_trak.Text;
                    string dateFrom = "";
                    string dateTo = "";
                    if (txt_stratdate.Text != "")
                    {
                        string str = txt_stratdate.Text;
                        string[] split = str.Split('-');
                        dateFrom = split[2] + "-" + split[1] + "-" + split[0];
                    }

                    if (txt_enddate.Text != "")
                    {
                        string str1 = txt_enddate.Text;
                        string[] split1 = str1.Split('-');
                        dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                    }

                    if (lbl_track.Text == "Fast")
                    {
                        _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_software_id , batch_softwarename , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + lbl_track.Text + "', '" + ddl_slotfast.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "'," + dateFrom + "," + dateTo + ", '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";//str_to_date('" + txt_enddate.Text + "','%d-%m-%Y')
                        MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (DropDownList1.SelectedValue != "Select")
                        {
                            _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                        }
                    }
                    if (lbl_track.Text == "Normal")
                    {
                        _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_software_id , batch_softwarename , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + lbl_track.Text + "', '" + ddl_slotnormal.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "','" + dateFrom + "','" + dateTo + "', '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";

                        //Response.Write(_Qry);
                        //Response.End();
                        MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (DropDownList1.SelectedValue != "Select")
                        {
                            if (LabSLot == "MWF")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);   
                            }
                            else if (LabSLot == "TTS")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            
                            else if (LabSLot == "Daily")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }

                            else
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='" + ddl_slotnormal.SelectedValue + "' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }

                            if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='" + ddl_slotnormal.SelectedValue + "' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                        }
                    }
                    if (lbl_track.Text == "Zip")
                    {
                        _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_software_id , batch_softwarename , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + lbl_track.Text + "', '" + ddl_slotzip.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "'," + dateFrom + "," + dateTo + ", '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";
                        MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (DropDownList1.SelectedValue != "Select")
                        {
                            if (slot1 == "MWF")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                            }
                            else if (slot1 == "TTS")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                            }
                            else if (slot1 == "Daily")
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                            }
                            else
                            {
                                _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='" + ddl_slotzip.SelectedValue + "' where LabId=" + ddl_labname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }

                            if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else if (FacultySlot == "MWF")
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                            else
                            {
                                _Qry = "Update Onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='" + ddl_slotzip.SelectedValue + "' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            }
                        }
                    }
                    //update geninfo

                    _Qry1 = "update adm_generalinfo set Track='Batched' where student_id='" + stdid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);



                    btn_submit.Visible = false;
                    Button1.Visible = true;
                    lblmsg1.Text = "*Batch created sucessfully!";
                    fillgrid();
                    //DropDownList1.SelectedValue = "Select";
                    //ddl_labname.SelectedValue = "";
                    //ddl_facultyname.SelectedValue = "";

                    abc = abc + 1;

                }

            }

            if (abc == 0)
            {
                lblmsg1.Text = "*Please select students to be batched!";
            }
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

        lbl_coursename.Text = ddl_coursename.SelectedItem.ToString();
        lbl_track.Text = ddl_Track.SelectedValue.ToString();
        display_track();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string test = lbl_coursename.Text;
        if (test == "" || test == null)
        {
            lblmsg1.Text = "Please enter software name";
        }
        else
        {
            if (lbl_track.Text == "Fast")
            {
                _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]='free'";

            }
            if (lbl_track.Text == "Normal")
            {
                _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";
            }
            if (lbl_track.Text == "Zip")
            {
                _Qry = "Select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";
            }



            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            ddl_labname.DataSource = dt;
            ddl_labname.DataTextField = "Labname";
            ddl_labname.DataValueField = "LabId";
            ddl_labname.DataBind();

            ddl_labname.Items.Remove("Select");
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));


            if (lbl_track.Text == "Fast")
            {
                _Qry = "Select Faculty_Id,FacultyName From Onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]='free'";

            }
            if (lbl_track.Text == "Normal")
            {
                _Qry = "Select Faculty_Id,FacultyName From Onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";

            }
            if (lbl_track.Text == "Zip")
            {
                _Qry = "Select Faculty_Id,FacultyName From Onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily'";

            }

            //_Qry = "Select Faculty_Id,FacultyName From Onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
            //_Qry += " And [" + DropDownList1.SelectedValue + "]='free'";


            DataTable dt12 = new DataTable();
            dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);

            ddl_facultyname.DataSource = dt12;
            ddl_facultyname.DataTextField = "FacultyName";
            ddl_facultyname.DataValueField = "Faculty_Id";
            ddl_facultyname.DataBind();

            ddl_facultyname.Items.Remove("Select");
            ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    protected void ddl_labname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //_Qry = "Select [" + DropDownList1.SelectedValue + "] as Lab_Track From online_students_labavail where LabId=" + ddl_labname.SelectedValue + "";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        //if (lbl_track.Text == "Fast")
        //{
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        lbl_Slot.Text = "Lab Not Available";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        lbl_Slot.Text = "Lab Not Available";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
        //    {
        //        lbl_Slot.Text = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotfast.Visible = true;
        //    }
        //    ddl_slotnormal.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Normal")
        //{
        //    string Track = dt.Rows[0]["Lab_Track"].ToString();
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        lbl_Slot.Text = "TTS";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        lbl_Slot.Text = "MWF";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"] == "Daily")
        //    {
        //        lbl_Slot.Text = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotnormal.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Zip")
        //{
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        lbl_Slot.Text = "TTS";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        lbl_Slot.Text = "MWF";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
        //    {
        //        lbl_Slot.Text = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotzip.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotnormal.Visible = false;
        //}
    }
    protected void ddl_facultyname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string Lab_Track = "";
        //string Faculty_Track = "";
        //_Qry = "Select [" + DropDownList1.SelectedValue + "] as Lab_Track From online_students_labavail where LabId=" + ddl_labname.SelectedValue + "";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        //if (lbl_track.Text == "Fast")
        //{
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        Lab_Track = "Lab Not Available";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        Lab_Track = "Lab Not Available";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
        //    {
        //        Lab_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotfast.Visible = true;
        //    }
        //    ddl_slotnormal.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Normal")
        //{
        //    string Track = dt.Rows[0]["Lab_Track"].ToString();
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        Lab_Track = "TTS";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        Lab_Track = "MWF";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"] == "Daily")
        //    {
        //        Lab_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotnormal.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Zip")
        //{
        //    if (dt.Rows[0]["Lab_Track"].ToString() == "MWF")
        //    {
        //        Lab_Track = "TTS";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "TTS")
        //    {
        //        Lab_Track = "MWF";
        //    }
        //    else if (dt.Rows[0]["Lab_Track"].ToString() == "Daily")
        //    {
        //        Lab_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotzip.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotnormal.Visible = false;
        //}

        //_Qry = "Select [" + DropDownList1.SelectedValue + "] as Faculty_Track From Onlinestudentsfacultydetails where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
        //DataTable dt12 = new DataTable();
        //dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);

        //if (lbl_track.Text == "Fast")
        //{
        //    if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
        //    {
        //        Faculty_Track = "Lab Not Available";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
        //    {
        //        Faculty_Track = "Lab Not Available";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"].ToString() == "Daily")
        //    {
        //        Faculty_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotfast.Visible = true;
        //    }
        //    ddl_slotnormal.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Normal")
        //{
        //    string Track = dt12.Rows[0]["Faculty_Track"].ToString();
        //    if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
        //    {
        //        Faculty_Track = "TTS";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
        //    {
        //        Faculty_Track = "MWF";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"] == "Daily")
        //    {
        //        Faculty_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotnormal.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotzip.Visible = false;
        //}
        //if (lbl_track.Text == "Zip")
        //{
        //    if (dt12.Rows[0]["Faculty_Track"].ToString() == "MWF")
        //    {
        //        Faculty_Track = "TTS";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"].ToString() == "TTS")
        //    {
        //        Faculty_Track = "MWF";
        //    }
        //    else if (dt12.Rows[0]["Faculty_Track"].ToString() == "Daily")
        //    {
        //        Faculty_Track = "Lab Not Available";
        //    }
        //    else
        //    {
        //        ddl_slotzip.Visible = true;
        //    }
        //    ddl_slotfast.Visible = false;
        //    ddl_slotnormal.Visible = false;
        //}
        //Response.Write("Lab_Track:"+ Lab_Track);
        //Response.Write("Faculty_Track:" + Lab_Track);
        //Response.End();
    }

}

