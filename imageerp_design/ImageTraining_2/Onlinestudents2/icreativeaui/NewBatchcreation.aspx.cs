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

public partial class superadmin_NewBatchcreation : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, couname, couid, todate, holdate;
    int noofcls, weekday,endate;
    int yy = 0;
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
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "'";
       
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_facultyname.DataSource = dt;
        ddl_facultyname.DataValueField = "faculty_id";
        ddl_facultyname.DataTextField = "facultyname";
        ddl_facultyname.DataBind();
        ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    }
    private void display_lab()
    {
        _Qry = "select LabId,LabName from online_students_labavail where centre_code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_labname.DataSource = dt;
        ddl_labname.DataValueField = "LabId";
        ddl_labname.DataTextField = "LabName";
        ddl_labname.DataBind();
        ddl_labname.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillgrid()
    {
        // _Qry = "select gen.student_id,per.enq_personal_name,gen.Track,cou.coursename,cou.program,enq.enq_personal_mobile from (adm_generalinfo gen inner join adm_personalparticulars per on per.student_id=gen.student_id) inner join img_enquiryform enq on gen.enq_number=enq.enq_number inner join img_coursedetails cou on gen.coursename=cou.course_id  where gen.coursename='"+ddl_coursename.SelectedValue+"' and gen.track='" + ddl_Track.SelectedValue + "' and gen.centre_code='" + Session["SA_centre_code"] + "'";
        //_Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=enq.enq_number where G.centre_code='" + Session["SA_centre_code"] + "'and SUB.software_id='" + ddl_coursename.SelectedValue + "' and G.track='" + ddl_Track.SelectedValue + "' GROUP by G.student_id";

        //_Qry = "Select Course_Code,C.Course_Id From OnlineStudent_Course c inner join module_details cs on ";
        //_Qry += " c.course_id=cs.course_id where Module_Id="+ddl_coursename.SelectedValue+"";

      
        _Qry = "Select module_id from module_details where Module_Id=" + ddl_coursename.SelectedValue + " ";
        
        //Response.Write(_Qry);
        //Response.End();

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        string Software_ID = "";
        if (dr.HasRows)
        {
            dr.Read();

            _Qry=" select cs.Course_ID,c.course_Code from Onlinestudent_Coursesoftware as cs inner join OnlineStudent_Course as c on ";
            _Qry +=" cs.course_Id=c.Course_ID";
            _Qry += " where module_id in(" + dr["module_id"] + ") group ";
            _Qry += " by cs.course_ID,c.course_Code";

            //Response.Write(_Qry);
            //Response.End();


            dr.Close();
        }

        //Response.Write(_Qry);
        //Response.End();
        //Response.Write("Test:"+_Qry);
        //Response.End();

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

        //Response.Write(Course_Code);
        //Response.End();

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


            string qryCondition = "";
            if (txt_search.Text != "")
            {
                qryCondition = " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%'  or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%')";
            }

            //by siva
            _Qry = @"select top 5 p.enq_personal_name,p.student_id,Enqf.enq_personal_mobile,G.Track,cou.program,cou.course_id from adm_personalparticulars as p inner join adm_generalinfo G on p.student_id=G.student_id  INNER JOIN  img_enquiryform1 Enq on enq.enq_number=g.enq_number INNER JOIN img_enquiryform enqf on enqf.enq_number=enq.enq_number 
inner join img_coursedetails cou on cou.course_id=g.coursename where  G.track<>'Batched' and G.centre_code='" + Session["SA_centre_code"] + "' and Enq.enq_enqstatus<>'Dropped' and G.coursename in (select course_id from img_coursedetails where program in (" + Course_Code + "))" + qryCondition + " order by Cou.Course_id";

        }

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

        foreach (GridViewRow gr in Gridvw.Rows)
        {
            Label lbl_bTrack = new Label();
            lbl_bTrack = ((Label)gr.FindControl("lbl_Bindtrack"));
            if (lbl_bTrack.Text == "Batched")
            {
                lbl_bTrack.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbl_bTrack.ForeColor = System.Drawing.Color.Green;
            }
        }
    }


    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + ddl_Track.SelectedValue + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT Module_Id,Replace(Module_Content,'~','''') as Module_Content from Module_Details ORDER by Module_Id";

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

        _Qry = "Select [" + DropDownList1.SelectedValue + "] as Faculty_Track From onlinestudentsfacultydetails where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
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
            if (slot1 == Faculty_Track || Faculty_Track=="free")
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
            if (slot1 == Lab_Track || Lab_Track=="free")
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

        _Qry = "Select System from online_students_labavail where Labname='"+ddl_labname.SelectedItem+"'";
        int countss = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        int noofstudents=0;

        foreach (GridViewRow roww in Gridvw.Rows)
        {
            CheckBox chbox = new CheckBox();
            chbox = (CheckBox)roww.FindControl("CheckBox1");
            if (chbox.Checked == true)
            {
                noofstudents = noofstudents + 1;
            }
        }

        if (noofstudents > countss)
        {
            lblmsg1.Text = "Please select only " + countss + " students for this batch";
        }
        else
        {
            if (i == 100)
            {
                _Qry = "select batch_code from batch_details where centre_code='" + Session["SA_centre_code"] + "' And (SELECT MONTH(Dateins))='" + System.DateTime.Now.Month + "' And (SELECT YEAR(Dateins))='" + System.DateTime.Now.Year + "' group by batch_code";

                //int ccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                DataTable dtc = new DataTable();
                dtc = MVC.DataAccess.ExecuteDataTable(_Qry);

                int ccount = 0;

                ccount = dtc.Rows.Count;
                //Response.Write("Count Is:" + ccount);
                //Response.End();

                if (ccount > 0)
                {
                    BatchCount = Convert.ToString(Convert.ToInt32(ccount) + 1);
                }
                else
                {
                    BatchCount = "1";
                }
                int dday = System.DateTime.Now.Day;

                //if (dday == 1)
                //{
                //    BatchCount = 1;
                //}

                int yearr = System.DateTime.Now.Year;
                int Mmonth = System.DateTime.Now.Month;

                string bat_time = "";
                string centrcode = Session["SA_centre_code"].ToString();
                string tim = DropDownList1.SelectedValue;
                string[] strSplitArr = tim.Split('-');
                if (strSplitArr[0] == "7amto9am")
                {
                    bat_time = "7to9";
                }
                if (strSplitArr[0] == "9amto11am")
                {
                    bat_time = "9to11";
                }
                if (strSplitArr[0] == "11amto1pm")
                {
                    bat_time = "11to13";
                }
                if (strSplitArr[0] == "1pmto3pm")
                {
                    bat_time = "13to15";
                }
                if (strSplitArr[0] == "3pmto5pm")
                {
                    bat_time = "15to17";
                }
                if (strSplitArr[0] == "5pmto7pm")
                {
                    bat_time = "17to19";
                }
                if (strSplitArr[0] == "7pmto9pm")
                {
                    bat_time = "19to21";
                }

                string mon = "";

                if (Mmonth < 10)
                {
                    mon = "0" + Mmonth.ToString();
                }
                else
                {
                    mon = Mmonth.ToString();
                }

                string Labcode = "";
                _Qry = "Select Labcode From online_students_labavail Where LabId=" + ddl_labname.SelectedValue + "";
                SqlDataReader drCode;
                drCode = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (drCode.HasRows)
                {
                    drCode.Read();

                    Labcode = drCode["Labcode"].ToString();

                    drCode.Close();
                }

                //batch_code = "BC" + yearr + strSplitArr[0] + "-" + centrcode + "-" + BatchCount;

                batch_code = "BC" + "-" + centrcode + "-" + mon + "/" + yearr + "-" + bat_time + "-" + Labcode + "-" + BatchCount;

                //Response.Write(batch_code);
                //Response.End();

                int checkcc = 0;

                foreach (GridViewRow roww in Gridvw.Rows)
                {
                    CheckBox chbox = new CheckBox();
                    chbox = (CheckBox)roww.FindControl("CheckBox1");
                    if (chbox.Checked == true)
                    {
                        checkcc = checkcc + 1;
                    }
                }

                if (checkcc > 0)
                {
                    datecalc();
                }

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

                        _Qry = "Select Count(*) from Batch_details where Batch_StudentId='" + stdid + "' And (Batch_Time='" + DropDownList1.SelectedValue + "' or Batch_Module_Content='"+ddl_coursename.SelectedItem+"')";

                        int cccount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                        if (cccount > 0)
                        {
                            yy = yy + 1;
                        }
                        else
                        {
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
                                _Qry = "Select Count(*) as count from Batch_Details Where Batch_Time='" + DropDownList1.SelectedValue + "' And Batch_Slot='" + ddl_slotfast.SelectedValue + "' And batch_labname='" + ddl_labname.SelectedItem + "'";

                                //Response.Write(_Qry);
                                //Response.End();

                                _Qry = "Select System from online_students_labavail where Batch_Time='" + DropDownList1.SelectedValue + "'";


                                _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + ddl_Track.SelectedValue + "', '" + ddl_slotfast.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "','" + dateFrom + "','" + dateTo + "', '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";//str_to_date('" + txt_enddate.Text + "','%d-%m-%Y')

                                //Response.Write(_Qry);
                                //Response.End();

                                MVC.DataAccess.ExecuteDataTable(_Qry);

                                if (DropDownList1.SelectedValue != "Select")
                                {
                                    _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='Daily' where LabId=" + ddl_labname.SelectedValue + "";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                                    _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                }
                            }
                            if (lbl_track.Text == "Normal")
                            {
                                _Qry = "Select Count(*) as count from Batch_Details Where Batch_Time='" + DropDownList1.SelectedValue + "' And Batch_Slot='" + ddl_slotnormal.SelectedValue + "' And batch_labname='" + ddl_labname.SelectedItem + "'";
                                //Response.Write(_Qry);
                                //Response.End();

                                _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + ddl_Track.SelectedValue + "', '" + ddl_slotnormal.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "','" + dateFrom + "','" + dateTo + "', '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";

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
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else if (FacultySlot == "TTS")
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else if (FacultySlot == "Daily")
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='" + ddl_slotnormal.SelectedValue + "' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                }
                            }
                            if (lbl_track.Text == "Zip")
                            {
                                _Qry = "Select Count(*) as count from Batch_Details Where Batch_Time='" + DropDownList1.SelectedValue + "' And Batch_Slot='" + ddl_slotzip.SelectedValue + "' And batch_labname='" + ddl_labname.SelectedItem + "'";
                                //Response.Write(_Qry);
                                //Response.End();

                                _Qry = "INSERT INTO batch_details (batch_code , centre_code , batch_studentid , batch_coursename , batch_Module_id , batch_Module_Content , batch_track , batch_slot , batch_time , batch_facultyid , batch_faculty , batch_startdate , batch_enddate , batch_labname , batch_status , dateins )VALUES ('" + batch_code + "', '" + Session["SA_centre_code"] + "', '" + stdid + "', '" + lb_course.Text + "', '" + ddl_coursename.SelectedValue + "', '" + ddl_coursename.SelectedItem + "', '" + ddl_Track.SelectedValue + "', '" + ddl_slotzip.SelectedValue + "', '" + DropDownList1.SelectedValue + "', '" + ddl_facultyname.SelectedValue + "', '" + ddl_facultyname.SelectedItem + "','" + dateFrom + "','" + dateTo + "', '" + ddl_labname.SelectedItem + "','Inprogress',getdate())";
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
                                        _Qry = "Update online_students_labavail set [" + DropDownList1.SelectedValue + "]='" + ddl_slotzip.SelectedValue + "' where LabId=" + ddl_labname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }

                                    if (FacultySlot == "MWF")
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else if (FacultySlot == "TTS")
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else if (FacultySlot == "Daily")
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='Daily' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                                    }
                                    else
                                    {
                                        _Qry = "Update onlinestudentsfacultydetails set [" + DropDownList1.SelectedValue + "]='" + ddl_slotzip.SelectedValue + "' where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
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
                }

                if (abc == 0)
                {
                    lblmsg1.Text = "*Please select students to be batched!";
                }
                if (abc == 0 && yy > 0)
                {
                    lblmsg1.Text = "*Selected student are not available for this batch!";
                }
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
    private static int dayOfWeek(DateTime adSource)
    {

        // Calender Functionality cloned by used defined logic
        DayOfWeek dWeek = adSource.DayOfWeek;

        switch (dWeek)
        {

            case DayOfWeek.Monday:
                return 1;

            case DayOfWeek.Tuesday:
                return 2;

            case DayOfWeek.Wednesday:
                return 3;

            case DayOfWeek.Thursday:
                return 4;

            case DayOfWeek.Friday:
                return 5;

            case DayOfWeek.Saturday:
                return 6;

            case DayOfWeek.Sunday:
                return 0;

        }

        return 0;

    }
    public static DateTime getDate(string date)//date= 24-10-2007
    {

        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("nl-NL");
        System.IFormatProvider format = new System.Globalization.CultureInfo("nl-NL", true);
        //string format = "ddd dd MMM h:mm tt yyyy";

        //string strdate=Convert.ToDateTime(date).ToString("dd/MM/yyyy"); //24-10-2007 not required
        DateTime date1 = DateTime.ParseExact(date, "yyyy/MM/dd", null);

        //DateTime date2 = DateTime.ParseExact(date, "yyyy/MM/dd",null );

        //DateTime dateTime = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);


        //HttpContext.Current.Response.Write(date);
        //HttpContext.Current.Response.Write(dateTime);
        //HttpContext.Current.Response.End();

        return date1; // 10-24-2007

    }
    private void datecalc()
    {

        string soft_id = "";
        int Noofdays = 0;
        _Qry = "Select software_id from module_details where module_id=" + ddl_coursename.SelectedValue + "";

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();

            soft_id = dr["software_id"].ToString();

            dr.Close();
        }

        string[] soft = soft_id.Split(',');

        foreach (string ar in soft)
        {
            _Qry = "Select Noofdays from onlinestudent_software where Software_Id="+ar+"";
            dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr.HasRows)
            {
                dr.Read();

                if (Noofdays == 0 || Noofdays == null)
                {
                    Noofdays = Convert.ToInt32(dr["Noofdays"]);
                }
                else
                {
                    Noofdays = Noofdays + Convert.ToInt32(dr["Noofdays"]);
                }
                dr.Close();
            }
        }

        //DateTime xDate = new DateTime();
        //string MyString;
        //xDate = DateTime.ParseExact("2001/03/20", "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //MyString = xDate.ToString("yyyy/MM/dd");
        //xDate = DateTime.ParseExact(MyString, "yyyy/M/d", CultureInfo.InvariantCulture);
        //Response.Write("Test:" + xDate);
        //Response.End();

        noofcls = Noofdays;

        string sdate;

        string str = txt_stratdate.Text;
        string[] split = str.Split('-');

        sdate = split[2] + "-" + split[1] + "-" + split[0];

        DateTime stdat = getDate(sdate);

        //stdat = stdat.
        //Response.Write(stdat);
        //Response.End();
        int submod_Id = 0;
        int z = 0;
        int submodule_id = 0;
        string module_name="", software_name="", mod_content = "";
        int i = 0;
        while (noofcls > i)
        {
            string MyString;
            MyString = stdat.ToString("yyyy-MM-dd");
            stdat = DateTime.ParseExact(MyString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //Response.Write("Test:" + MyString + "One More:" + stdat);
            //Response.End();

            holdate = "";
            _Qry = "select Hoilday_date from atn_hoilday where Hoilday_date='" + MyString + "'";

            //Response.Write(_Qry);
            //Response.End();
            DataTable dt6 = new DataTable();
            dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);
            
            
            if (z == 0)
            {
                _Qry = "Select Top 1 * from submodule_details_new where moduleId="+ddl_coursename.SelectedValue+"";
                //Response.Write(_Qry);
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    submodule_id = Convert.ToInt32(dr["Submodule_id"]);
                    module_name = dr["Module"].ToString();
                    software_name = dr["Software"].ToString();
                    mod_content = dr["Content"].ToString();
                    dr.Close();
                }
            }
            else
            {
                _Qry = "Select Top 1 * from submodule_details_new where moduleId=" + ddl_coursename.SelectedValue + " And Submodule_id>"+submod_Id+"";
                //SqlDataReader dr;
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    submodule_id = Convert.ToInt32(dr["Submodule_id"]);
                    module_name = dr["Module"].ToString();
                    software_name = dr["Software"].ToString();
                    mod_content = dr["Content"].ToString();
                    dr.Close();
                }
            }

            
            //Response.End();

            if (dt6.Rows.Count > 0)
            {
                holdate = dt6.Rows[0]["Hoilday_date"].ToString();
            }
            if (ddl_Track.SelectedValue == "Normal" && ddl_slotnormal.SelectedValue == "MWF")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("<br>Content is:" + mod_content + "Submodule_Id is:" + submodule_id);
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry+=" Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','"+ddl_coursename.SelectedItem.Text+"','"+software_name+"',";
                    _Qry += " '"+batch_code+"','"+ddl_Track.SelectedValue+"','"+ddl_slotnormal.SelectedValue+"',";
                    _Qry += "'"+DropDownList1.SelectedValue+"','"+ddl_facultyname.SelectedValue+"','"+ddl_labname.SelectedValue+"',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotnormal.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (ddl_Track.SelectedValue == "Normal" && ddl_slotnormal.SelectedValue == "TTS")
            {

                if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotnormal.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotnormal.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (ddl_Track.SelectedValue == "Zip" && ddl_slotzip.SelectedValue == "MWF")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (ddl_Track.SelectedValue == "Zip" && ddl_slotzip.SelectedValue == "TTS")
            {
                if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }

            if (ddl_Track.SelectedValue == "Fast" && ddl_slotfast.SelectedValue == "Daily")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotfast.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotfast.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (ddl_Track.SelectedValue == "Zip" && ddl_slotzip.SelectedValue == "Daily")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;
                    //Response.Write("value of z is:" + z);
                    //Response.Write("<br>Content is:" + mod_content + "<br>Submodule_Id is:" + submodule_id);
                    //Response.End();

                    _Qry = "insert into Onlinestudent_ScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                    _Qry = "insert into Onlinestudent_EditScheduleBatch (Centre_Code,Module_Name,Software_Name,Batch_Code,Batch_Track,";
                    _Qry += " Batch_Slot,Batch_Timing,Faculty_Name,Lab_Name,Content,Date_Class,Date_Ins) ";
                    _Qry += " Values ('" + Session["SA_centre_code"] + "','" + ddl_coursename.SelectedItem.Text + "','" + software_name + "',";
                    _Qry += " '" + batch_code + "','" + ddl_Track.SelectedValue + "','" + ddl_slotzip.SelectedValue + "',";
                    _Qry += "'" + DropDownList1.SelectedValue + "','" + ddl_facultyname.SelectedValue + "','" + ddl_labname.SelectedValue + "',";
                    _Qry += "'" + mod_content + "','" + MyString + "',getdate())";

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);


                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
        }
        string dob = lastday.ToString("dd-MM-yyyy");
        //string[] strSplitArr = dob.Split('-');
        //string dob1 = strSplitArr[2] + "-" + strSplitArr[1] + "-" + strSplitArr[0];

        //Response.Write("Lastday is:" + dob);
        //Response.End();

        txt_enddate.Text = dob;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid();

        lbl_coursename.Text = ddl_coursename.SelectedItem.ToString();
        //lbl_track.Text = ddl_Track.SelectedValue.ToString();
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string test = lbl_coursename.Text;
        if (test == "" || test == null)
        {
            lblmsg1.Text = "Please enter software name";
        }
        else if (DropDownList1.SelectedValue != "Select")
        {
            lbl_track.Text = ddl_Track.SelectedValue.ToString();
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


            //Response.Write(_Qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

            ddl_labname.DataSource = dt;
            ddl_labname.DataTextField = "Labname";
            ddl_labname.DataValueField = "LabId";
            ddl_labname.DataBind();

            ddl_labname.Items.Remove("Select");
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));


            if (lbl_track.Text == "Fast")
            {
                _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]='free' And [" + DropDownList1.SelectedValue + "]<>'NIL'";

            }
            if (lbl_track.Text == "Normal")
            {
                _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily' And [" + DropDownList1.SelectedValue + "]<>'NIL' ";

            }
            if (lbl_track.Text == "Zip")
            {
                _Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
                _Qry += " And [" + DropDownList1.SelectedValue + "]<>'Daily' And [" + DropDownList1.SelectedValue + "]<>'NIL'";

            }

            //_Qry = "Select Faculty_Id,FacultyName From onlinestudentsfacultydetails where Centre_Code='" + Session["SA_centre_code"] + "'";
            //_Qry += " And [" + DropDownList1.SelectedValue + "]='free'";


            DataTable dt12 = new DataTable();
            dt12 = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

            ddl_facultyname.DataSource = dt12;
            ddl_facultyname.DataTextField = "FacultyName";
            ddl_facultyname.DataValueField = "Faculty_Id";
            ddl_facultyname.DataBind();

            ddl_facultyname.Items.Remove("Select");
            ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
        }
        else
        {
            lblmsg1.Text = "Please Select batch timing";
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

        //_Qry = "Select [" + DropDownList1.SelectedValue + "] as Faculty_Track From onlinestudentsfacultydetails where Faculty_Id=" + ddl_facultyname.SelectedValue + "";
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

    protected void Gridvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lnl_Btrack = e.Row.FindControl("lbl_Bindtrack") as Label;

            if (lnl_Btrack.Text == "Batched")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Green;
            }
        }
    }
    //protected void ddl_Track_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //display_track();
    //}
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewBatchcreation.aspx");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewBatchcreation.aspx");
    }
}

