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
using MySql.Data.MySqlClient;

public partial class Onlinestudents2_superadmin_BatchedAlert : System.Web.UI.Page
{
    int xx = 0;
    string _qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            Fillsearchmodule();
            Fillsearchcourse();
            FillGrid();
        }
    }

    private void Fillsearchcourse()
    {
        _qry = "select Course_Code,Course_Id from onlinestudent_course order by Course_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlsearchcourse.DataSource = dt1;
        ddlsearchcourse.DataValueField = "Course_Id";
        ddlsearchcourse.DataTextField = "Course_Code";
        ddlsearchcourse.DataBind();
        ddlsearchcourse.Items.Insert(0, new ListItem("Select", ""));
    }


    private void Fillsearchmodule()
    {
        _qry = "select module_content,module_Id from module_details order by Module_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_content";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }


    private void FillGrid()
    {
        MySqlConnection con = new MySqlConnection("data source=localhost;user ID=root;Password=;Initial catalog=imageonlineexam;charset=utf8");
        con.Open();
        string CurrentModule = "";
        string NextModule = "";

        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add();
        dt.Columns.Add("Student ID", typeof(string));
        dt.Columns.Add("Student Name", typeof(string));
        //dt.Columns.Add("Track", typeof(string));
        //dt.Columns.Add("Course", typeof(string));
        dt.Columns.Add("Current Module", typeof(string));
        dt.Columns.Add("Waiting For", typeof(string));
        dt.Columns.Add("Exam Date", typeof(string));
        dt.Columns.Add("Batch Id", typeof(string));
        dt.Columns.Add("Course", typeof(string));

        _qry = "Select G.student_id,(P.enq_personal_name+' '+student_lastname) as StudentName ,G.Track1,cou.program,cou.course_id from img_coursedetails cou inner join ";
        _qry += " adm_generalinfo G on G.coursename= cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id ";

        _qry += " Where G.Student_id in (select batch_studentid from batch_details as bd inner join Onlinestudent_EditScheduleBatch as sb on ";
        _qry += " bd.Batch_code=sb.Batch_code where (Select top 1 date_class from Onlinestudent_EditScheduleBatch where batch_Code=bd.Batch_code";
        _qry += "  order by schedule_Id desc)>1 And (Select Status From Add_moduledetails where Module_Id=Batch_Module_Id)='Enable') ";
        _qry += " And (SELECT replace(convert(varchar, getdate(), 111), '/', '-')) > (Select top 1 DATEADD([day], - 6, date_class) from";
        _qry += " Onlinestudent_EditScheduleBatch as sb inner join Batch_Details as bd on bd.Batch_code=sb.Batch_code";
        _qry += "  where Batch_StudentId=G.student_id order by schedule_Id desc)";
        _qry += " And G.centre_code='" + Session["SA_centre_code"] + "' ";

        if (ddlsearchcourse.SelectedValue == "" || ddlsearchcourse.SelectedValue == null)
        {

        }
        else
        {
            _qry += " And cou.program='" + ddlsearchcourse.SelectedItem.Text + "'";
        }

        _qry += " GROUP by G.student_id,P.student_id,P.enq_personal_name,student_lastname,G.Track1,cou.program,cou.course_id order by Cou.Course_id";

        //Response.Write(_qry);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {


            _qry = "Select StudentId from exam_studentdetails Where StudentRegNo='" + dt1.Rows[i]["student_id"].ToString() + "' ";
            MySqlCommand cmd1 = new MySqlCommand(_qry, con);
            int stdid = Convert.ToInt32(cmd1.ExecuteScalar());
                DataRow dr1 = dt.NewRow();

                dr1[0] = dt1.Rows[i]["student_id"].ToString();
                dr1[1] = dt1.Rows[i]["StudentName"].ToString();
                //dr1[2] = dt1.Rows[i]["Track1"].ToString();
                dr1[6] = dt1.Rows[i]["program"].ToString();

                int ii = 0;
                _qry = "Select Batch_Code,Batch_Module_Content from Batch_Details where Batch_studentId='" + dt1.Rows[i]["student_id"].ToString() + "' And Batch_Status<>'Completed'";

                _qry += " And (Select top 1 date_class from Onlinestudent_EditScheduleBatch where batch_Code=Batch_Details.Batch_code";
                _qry += "  And getdate() > (SELECT DATEADD([day], - 6, date_class)) order by schedule_Id desc)>1 And (Select Status From Add_moduledetails where Module_Id=Batch_Module_Id)='Enable'";
                if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
                {

                }
                else
                {
                    _qry += " And Batch_Module_Id=" + ddlsearchmodname.SelectedValue + "";
                }

                _qry += " order by Batch_studentId ";
                //Response.Write(_qry);
                //Response.End();
                DataTable dt2 = new DataTable();
                dt2 = MVC.DataAccess.ExecuteDataTable(_qry);
                if (dt2.Rows.Count > 0)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        if (ii == 0)
                        {
                            dr1[5] = dt2.Rows[j]["Batch_Code"].ToString();
                            CurrentModule = dt2.Rows[j]["Batch_Module_Content"].ToString();
                            dr1[2] = CurrentModule;
                            _qry = "Select Top 1 Module_Content From Onlinestudent_Coursesoftware where Course_Id=";
                            _qry += " (select I.Course_Id from Onlinestudent_Course I inner join img_coursedetails c on";
                            _qry += " I.Course_Code=C.Program where C.Course_Id='" + dt1.Rows[i]["course_id"].ToString() + "') And ";
                            _qry += " Module_Content Not In(Select Batch_Module_Content From batch_details where Batch_studentid='" + dt1.Rows[i]["student_id"].ToString() + "') ";

                            DataTable dt3 = new DataTable();
                            dt3 = MVC.DataAccess.ExecuteDataTable(_qry);
                            if (dt3.Rows.Count > 0)
                            {
                                dr1[3] = dt3.Rows[0]["Module_Content"].ToString();
                            }
                            else
                            {
                                dr1[3] = "Course Completed";
                            }

                            _qry = "Select Top 1  convert(varchar, Date_Class, 110) as ClassDate from Onlinestudent_EditScheduleBatch Where batch_code='" + dt2.Rows[j]["Batch_Code"].ToString() + "' Order By Schedule_Id Desc";
                            DataTable dt5 = new DataTable();
                            dt5 = MVC.DataAccess.ExecuteDataTable(_qry);
                            if (dt5.Rows.Count > 0)
                            {
                                dr1[4] = "Course Completed";
                            }
                            dr1[4] = dt5.Rows[0]["ClassDate"].ToString();


                            //LinkButton lnkExam = new LinkButton();
                            //lnkExam.ID = "ExamApprove";
                            //lnkExam.Text="

                            //dr1[5]=

                            string cour_Name = "";
                            int cour_idd = 0;
                            cour_Name = MVC.CommonFunction.GetCoursecode(CurrentModule);


                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                            MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcour = new DataTable();
                            da15.Fill(dtcour);
                            if (dtcour.Rows.Count > 0)
                            {
                                cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                            }
                            if (stdid > 0)
                            {

                                _qry = "Select * from exam_studentcoursedetails where StudentId=" + stdid + "";
                                _qry += " And Status=2 And (Certificate_Id=" + cour_idd + " || softwareId=" + cour_idd + ")";
                                //Response.Write("<br>" + _qry);
                                DataTable dt11 = new DataTable();
                                MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                                da1.Fill(dt11);

                                if (dt11.Rows.Count > 0)
                                {
                                    dt.Rows.Add(dr1);
                                }
                            }
                            else
                            {
                                dt.Rows.Add(dr1);
                            }
                        }
                        else
                        {
                            DataRow dr2 = dt.NewRow();
                            CurrentModule = dt2.Rows[j]["Batch_Module_Content"].ToString();
                            dr2[0] = dt1.Rows[i]["student_id"].ToString();
                            dr2[1] = dt1.Rows[i]["StudentName"].ToString();
                            //dr2[2] = dt1.Rows[i]["Track1"].ToString();
                            dr2[6] = dt1.Rows[i]["program"].ToString();
                            dr2[5] = dt2.Rows[j]["Batch_Code"].ToString();
                            dr2[2] = CurrentModule;
                            _qry = "Select Top 1 Module_Content From Onlinestudent_Coursesoftware where Course_Id=";
                            _qry += " (select I.Course_Id from Onlinestudent_Course I inner join img_coursedetails c on";
                            _qry += " I.Course_Code=C.Program where C.Course_Id='" + dt1.Rows[i]["course_id"].ToString() + "') And ";
                            _qry += " Module_Content Not In(Select Batch_Module_Content From batch_details where Batch_studentid='" + dt1.Rows[i]["student_id"].ToString() + "') ";

                            DataTable dt4 = new DataTable();
                            dt4 = MVC.DataAccess.ExecuteDataTable(_qry);

                            if (dt4.Rows.Count > 0)
                            {
                                dr2[3] = dt4.Rows[0]["Module_Content"].ToString();
                            }
                            else
                            {
                                dr2[3] = "Course Completed";
                            }

                            _qry = "Select Top 1  convert(varchar, Date_Class, 110) as ClassDate from Onlinestudent_EditScheduleBatch Where batch_code='" + dt2.Rows[j]["Batch_Code"].ToString() + "' Order By Schedule_Id Desc";
                            DataTable dt6 = new DataTable();
                            dt6 = MVC.DataAccess.ExecuteDataTable(_qry);
                            if (dt6.Rows.Count > 0)
                            {
                                dr2[4] = dt6.Rows[0]["ClassDate"].ToString();
                            }
                            else
                            {
                                dr2[4] = "Course Completed";
                            }

                            string cour_Name = "";
                            int cour_idd = 0;
                            cour_Name = MVC.CommonFunction.GetCoursecode(CurrentModule);


                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                            MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcour = new DataTable();
                            da15.Fill(dtcour);
                            if (dtcour.Rows.Count > 0)
                            {
                                cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                            }

                            if (stdid > 0)
                            {

                                _qry = "Select * from Exam_StudentCourseDetails where StudentId=" + stdid + "";
                                _qry += " And Status=2 And (Certificate_Id=" + cour_idd + " || softwareId=" + cour_idd + ")";
                                //Response.Write("<br>" + _qry);
                                DataTable dt11 = new DataTable();
                                MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                                da1.Fill(dt11);

                                if (dt11.Rows.Count > 0)
                                {
                                    dt.Rows.Add(dr2);
                                }
                            }
                            else
                            {
                                dt.Rows.Add(dr2);
                            }
                        }
                        ii = ii + 1;
                    }
                }
                //else
                //{
                //    _qry = "Select Top 1 Module_Content From Onlinestudent_Coursesoftware where Course_Id=";
                //    _qry += " (select I.Course_Id from Onlinestudent_Course I inner join img_coursedetails c on";
                //    _qry += " I.Course_Code=C.Program where C.Course_Id='" + dt1.Rows[i]["course_id"].ToString() + "') And ";
                //    _qry += " Module_Content Not In(Select Batch_Module_Content From batch_details where Batch_studentid='" + dt1.Rows[i]["student_id"].ToString() + "') ";

                //    DataTable dt3 = new DataTable();
                //    dt3 = MVC.DataAccess.ExecuteDataTable(_qry);
                //    dr1[6] = dt3.Rows[0]["Module_Content"].ToString();

                //    dt.Rows.Add(dr1);
                //}

        }
        //Response.End();
        GridView1.DataSource = dt;
        GridView1.DataBind();

        if (dt.Rows.Count > 0)
        {
            //GridView1.PageSize = dt.Rows.Count;
        }

        //GridView1.PageSize = dt.Rows.Count;
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkApr")
        {
            string idInfo = e.CommandArgument.ToString();
            string[] args = new string[3];
            char[] splitter = { ';' };
            args = idInfo.Split(splitter);
            Response.Write("Stu Id=" + args[0].ToString() + "Module=" + args[1].ToString() + "Batch Code=" + args[2].ToString());
            Response.End();
        }
    }
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    FillGrid();
    //}
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        int _retInt = 0;
        int setFlag = 0;
        MySqlConnection con = new MySqlConnection("data source=localhost;user ID=root;Password=;Initial catalog=imageonlineexam;charset=utf8");
        con.Open();
        MySqlCommand Comm = new MySqlCommand();
        MySqlCommand StudentComm = new MySqlCommand();
        MySqlCommand CourseComm = new MySqlCommand();
        foreach (GridViewRow roww in GridView1.Rows)
        {
            xx = 0;

            Label lblstdid = new Label();
            lblstdid = (Label)roww.FindControl("lblstdId");

            Label lblstdname = new Label();
            lblstdname = (Label)roww.FindControl("lblName");

            Label lblcourse = new Label();
            lblcourse = (Label)roww.FindControl("lblCourse");

            Label lblcurrmod = new Label();
            lblcurrmod = (Label)roww.FindControl("lblCurrmod");

            CheckBox chbox = new CheckBox();
            chbox = (CheckBox)roww.FindControl("chkstd");
            if (chbox.Checked == true)
            {
                Comm.Dispose();
                _qry = "Select count(studentId)as cnt From exam_studentdetails Where TRIM(studentRegNo)='" + lblstdid.Text.ToString() + "'";
                Comm.CommandText = _qry;
                Comm.Connection = con;
                //Comm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = lblstdid.Text.ToString();
                //Comm.Parameters.Add("@txtName", MySqlDbType.VarChar, 100).Value = lblstdname.Text.ToString();
                _retInt = Convert.ToInt32(Comm.ExecuteScalar());
                if (_retInt > 0)
                {
                        int Cert_Id = 0;
                        int Course_Id = 0;
                        int Dcou_Id = 0;
                        int CCou_Id = 0;
                        string DCourseType = "";
                        string CCOurseType = "";
                        string centre_location = "";
                        DataTable dtcourse = new DataTable();
                        //dtcourse.Rows.Count = 0;
                        DataTable dtdiploma = new DataTable();
                        int centre_id = 0;
                        _qry = "Select centre_location from img_centredetails where Centre_id=" + Session["SA_CenterID"] + "";
                        DataTable dt = new DataTable();
                        dt = MVC.DataAccess.ExecuteDataTable(_qry);
                        if (dt.Rows.Count > 0)
                        {
                            centre_location = dt.Rows[0]["centre_location"].ToString();
                        }
                        setFlag = 1;
                        int studentId = 0;

                        _qry = "Select centreId From exam_centredetails where centreLocation='" + centre_location + "'";
                        MySqlDataAdapter da = new MySqlDataAdapter(_qry, con);
                        DataTable dtcen = new DataTable();
                        da.Fill(dtcen);
                        if (dtcen.Rows.Count > 0)
                        {
                            centre_id = Convert.ToInt32(dtcen.Rows[0]["centreId"]);
                        }

                        string Course_Name = lblcourse.Text.ToString();
                        Course_Name = Course_Name.Substring(0, 1);
                        if (Course_Name == "d" || Course_Name == "D" && lblcourse.Text.ToString() != "Dreamweaver")
                        {
                            DCourseType = lblcourse.Text.ToString();
                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + lblcourse.Text.ToString() + "'";
                            MySqlDataAdapter da12 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcouid = new DataTable();
                            da12.Fill(dtcouid);
                            if (dtcouid.Rows.Count > 0)
                            {
                                Dcou_Id = Convert.ToInt32(dtcouid.Rows[0]["Course_id"]);
                            }
                        }
                        else
                        {
                            DCourseType = "0";
                        }

                        if (Course_Name == "c" || Course_Name == "C" || lblcourse.Text.ToString() == "Dreamweaver")
                        {
                            CCOurseType = lblcourse.Text.ToString();
                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + lblcourse.Text.ToString() + "'";
                            MySqlDataAdapter da12 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcouid = new DataTable();
                            da12.Fill(dtcouid);
                            if (dtcouid.Rows.Count > 0)
                            {
                                CCou_Id = Convert.ToInt32(dtcouid.Rows[0]["Course_id"]);
                            }
                        }
                        else
                        {
                            CCOurseType = "0";
                        }


                        if (Course_Name == "c" || Course_Name == "C" || lblcourse.Text.ToString() == "Dreamweaver")
                        {
                            _qry = "  Select Certificate_Id,Case ifNull(C.certificate_status,1) When 1 Then 'Enabled' Else 'Disabled'";
                            _qry += " End as Diploma_status,Course_Id,C.SoftwareId,Comb_CourseId,CASE when ";
                            _qry += " C.Comb_CourseId=0 Then S.software_name else (select replace(Course_name,'~','''') as Course_name ";
                            _qry += " from exam_coursedetail where Course_id=C.Comb_CourseId) End as software ";
                            _qry += "from exam_certificate C left join exam_softwaredetails S on ";
                            _qry += "C.softwareId=S.softwareId where C.Course_Id=" + CCou_Id + "";

                            //Response.Write("<br>" + _qry);

                            MySqlDataAdapter dacou = new MySqlDataAdapter(_qry, con);
                            //dtcourse = new DataTable();
                            dacou.Fill(dtcourse);

                            for (int i = 0; i < dtcourse.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtcourse.Rows[i]["SoftwareId"]) == 0)
                                {
                                    xx = xx + 1;
                                }
                            }
                        }
                        if (Course_Name == "d" || Course_Name == "D" && lblcourse.Text.ToString() != "Dreamweaver")
                        {
                            _qry = "SELECT Diploma_Id,Diploma_status,D.Course_Id,D.Certificate_Id,CASE when D.Certificate_Id='0' Then soft.software_name else (select replace(Course_name,'~','''')as Course_name from exam_coursedetail where Course_id=D.Certificate_Id) End as software,D.softwareId from exam_diploma D  left join exam_softwaredetails soft on soft.softwareId=D.softwareId where D.Course_Id=" + Dcou_Id + "";

                            //Response.Write(_qry);
                            //Response.End();

                            MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                            //dtdiploma = new DataTable();
                            da1.Fill(dtdiploma);
                        }
                        //_qry = " Insert into Exam_StudentDetails ";
                        //_qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod) Values ";
                        //_qry += " ('" + lblstdname.Text.ToString() + "','" + lblstdid.Text.ToString() + "'," + Dcou_Id + "," + CCou_Id + "," + centre_id + ",current_date,current_date); Select LAST_INSERT_ID() as studentId ";

                        _qry = "Select StudentId From exam_studentdetails where StudentName='" + lblstdname.Text.ToString() + "' And studentRegNo='" + lblstdid.Text.ToString() + "'";
                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = con;

                        studentId = Convert.ToInt32(StudentComm.ExecuteScalar().ToString());
                        //studentId = 10;

                        //Response.Write("Course:" + dtcourse.Rows.Count);
                        //Response.Write("Diploma:" + dtdiploma.Rows.Count);
                        //Response.End();

                        if (studentId > 0)
                        {
                            int courseId = 0;
                            int status = 2;
                            //Response.Write("Count Is:"+dtcourse.Rows.Count);
                            //Response.End();
                            if (dtcourse.Rows.Count > 0)
                            {
                                string cour_Name = "";
                                int cour_idd = 0;
                                int sstatus = 2;
                                cour_Name = MVC.CommonFunction.GetCoursecode(lblcurrmod.Text.ToString());
                                _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                                MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                                DataTable dtcour = new DataTable();
                                da15.Fill(dtcour);
                                if (dtcour.Rows.Count > 0)
                                {
                                    cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                                }
                                //Response.Write("Course ID:" + cour_idd);
                                if (xx > 0)
                                {
                                    for (int icourse = 0; icourse < dtcourse.Rows.Count; icourse++)
                                    {
                                        sstatus = 2;
                                        if (dtcourse.Rows[icourse]["Comb_CourseId"] != "" && dtcourse.Rows[icourse]["Comb_CourseId"] != "0")
                                        {
                                            if (cour_idd == Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]))
                                            {
                                                sstatus = 1;

                                                //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                                //_qry += " (" + studentId + "," + Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]) + ",0," + sstatus + ",current_date,current_date) ";

                                                _qry = "Update exam_studentcoursedetails set studentId=" + studentId + ",Certificate_Id=" + Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]) + ",";
                                                _qry += "softwareID=0,Status=" + sstatus + ",dateMod=current_date where studentId=" + studentId + " And Certificate_Id=" + Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]) + "";

                                                MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                                coursecmd.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (cour_idd == Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]))
                                            {
                                                sstatus = 1;

                                                //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                                //_qry += " (" + studentId + ",0," + Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]) + "," + sstatus + ",current_date,current_date) ";

                                                _qry = "Update exam_studentcoursedetails set studentId=" + studentId + ",Certificate_Id=0,";
                                                _qry += "softwareID=" + Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]) + ",Status=" + sstatus + ",dateMod=current_date where studentId=" + studentId + " And softwareID=" + Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]) + "";
                                                MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                                coursecmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (cour_idd == Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]))
                                    {
                                        sstatus = 1;

                                        //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                        //_qry += " (" + studentId + "," + Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]) + ",0," + sstatus + ",current_date,current_date) ";

                                        _qry = "Update exam_studentcoursedetails set studentId=" + studentId + ",Certificate_Id=" + Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]) + ",";
                                        _qry += "softwareID=0,Status=" + sstatus + ",dateMod=current_date where studentId=" + studentId + " And Certificate_Id=" + Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]) + "";
                                        MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                        coursecmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else if (dtdiploma.Rows.Count > 0)
                            {
                                string cour_Name = "";
                                int cour_idd = 0;
                                int sstatus = 2;
                                cour_Name = MVC.CommonFunction.GetCoursecode(lblcurrmod.Text.ToString());
                                _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                                MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                                DataTable dtcour = new DataTable();
                                da15.Fill(dtcour);
                                if (dtcour.Rows.Count > 0)
                                {
                                    cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                                }
                                for (int idiploma = 0; idiploma < dtdiploma.Rows.Count; idiploma++)
                                {
                                    sstatus = 2;
                                    if (dtdiploma.Rows[idiploma]["Certificate_Id"] != "" && Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) != 0)
                                    {
                                        if (cour_idd == Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]))
                                        {
                                            sstatus = 1;

                                            //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                            //_qry += " (" + studentId + "," + Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) + ",0," + sstatus + ",current_date,current_date) ";

                                            _qry = "Update exam_studentcoursedetails set studentId=" + studentId + ",Certificate_Id=" + Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) + ",";
                                            _qry += "softwareID=0,Status=" + sstatus + ",dateMod=current_date where studentId=" + studentId + " And Certificate_Id=" + Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) + "";
                                            MySqlCommand dipcmd = new MySqlCommand(_qry, con);
                                            dipcmd.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        if (cour_idd == Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]))
                                        {
                                            sstatus = 1;

                                            //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                            //_qry += " (" + studentId + ",0," + Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]) + "," + sstatus + ",current_date,current_date) ";

                                            _qry = "Update exam_studentcoursedetails set studentId=" + studentId + ",Certificate_Id=0,";
                                            _qry += "softwareID=" + Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]) + ",Status=" + sstatus + ",dateMod=current_date where studentId=" + studentId + " And softwareID=" + Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]) + "";

                                            MySqlCommand dipcmd = new MySqlCommand(_qry, con);
                                            dipcmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                        }
                }
                else
                {
                    int Cert_Id = 0;
                    int Course_Id = 0;
                    int Dcou_Id = 0;
                    int CCou_Id = 0;
                    string DCourseType = "";
                    string CCOurseType = "";
                    string centre_location = "";
                    DataTable dtcourse = new DataTable();
                    //dtcourse.Rows.Count = 0;
                    DataTable dtdiploma = new DataTable();
                    int centre_id = 0;
                    _qry = "Select centre_location from img_centredetails where Centre_id=" + Session["SA_CenterID"] + "";
                    DataTable dt = new DataTable();
                    dt=MVC.DataAccess.ExecuteDataTable(_qry);
                    if (dt.Rows.Count > 0)
                    {
                        centre_location = dt.Rows[0]["centre_location"].ToString();
                    }
                    setFlag = 1;
                    int studentId = 0;

                    _qry = "Select centreId From exam_centredetails where centreLocation='" + centre_location + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(_qry, con);
                    DataTable dtcen = new DataTable();
                    da.Fill(dtcen);
                    if (dtcen.Rows.Count > 0)
                    {
                        centre_id = Convert.ToInt32(dtcen.Rows[0]["centreId"]);
                    }

                    string Course_Name = lblcourse.Text.ToString();
                    Course_Name=Course_Name.Substring(0, 1);
                    if (Course_Name == "d" || Course_Name == "D")
                    {
                        DCourseType = lblcourse.Text.ToString();
                        _qry = "Select Course_id From exam_coursedetail where Course_name='" + lblcourse.Text.ToString() + "'";
                        MySqlDataAdapter da12 = new MySqlDataAdapter(_qry, con);
                        DataTable dtcouid = new DataTable();
                        da12.Fill(dtcouid);
                        if (dtcouid.Rows.Count > 0)
                        {
                            Dcou_Id = Convert.ToInt32(dtcouid.Rows[0]["Course_id"]);
                        }
                    }
                    else
                    {
                        DCourseType = "0";
                    }
                    if (Course_Name == "c" || Course_Name == "C")
                    {
                        CCOurseType = lblcourse.Text.ToString();
                        _qry = "Select Course_id From exam_coursedetail where Course_name='" + lblcourse.Text.ToString() + "'";
                        MySqlDataAdapter da12 = new MySqlDataAdapter(_qry, con);
                        DataTable dtcouid = new DataTable();
                        da12.Fill(dtcouid);
                        if (dtcouid.Rows.Count > 0)
                        {
                            CCou_Id = Convert.ToInt32(dtcouid.Rows[0]["Course_id"]);
                        }
                    }
                    else
                    {
                        CCOurseType = "0";
                    }

                    
                    if (Course_Name == "c" || Course_Name == "C")
                    {
                        _qry = "  Select Certificate_Id,Case ifNull(C.certificate_status,1) When 1 Then 'Enabled' Else 'Disabled'";
                        _qry += " End as Diploma_status,Course_Id,C.SoftwareId,Comb_CourseId,CASE when ";
                        _qry += " C.Comb_CourseId=0 Then S.software_name else (select replace(Course_name,'~','''') as Course_name ";
                        _qry += " from exam_coursedetail where Course_id=C.Comb_CourseId) End as software ";
                        _qry += "from exam_certificate C left join exam_softwaredetails S on ";
                        _qry += "C.softwareId=S.softwareId where C.Course_Id=" + CCou_Id + "";

                        //Response.Write("<br>" + _qry);

                        MySqlDataAdapter dacou = new MySqlDataAdapter(_qry, con);
                        //dtcourse = new DataTable();
                        dacou.Fill(dtcourse);

                        for (int i = 0; i < dtcourse.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dtcourse.Rows[i]["SoftwareId"]) == 0)
                            {
                                xx = xx + 1;
                            }
                        }
                    }
                    if (Course_Name == "d" || Course_Name == "D")
                    {
                        _qry = "SELECT Diploma_Id,Diploma_status,D.Course_Id,D.Certificate_Id,CASE when D.Certificate_Id='0' Then soft.software_name else (select replace(Course_name,'~','''')as Course_name from exam_coursedetail where Course_id=D.Certificate_Id) End as software,D.softwareId from exam_diploma D  left join exam_softwaredetails soft on soft.softwareId=D.softwareId where D.Course_Id=" + Dcou_Id + "";

                        //Response.Write(_qry);
                        //Response.End();

                        MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                        //dtdiploma = new DataTable();
                        da1.Fill(dtdiploma);
                    }
                    _qry = " Insert into exam_studentdetails ";
                    _qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod) Values ";
                    _qry += " ('" + lblstdname.Text.ToString() + "','" + lblstdid.Text.ToString() + "'," + Dcou_Id + "," + CCou_Id + "," + centre_id + ",current_date,current_date); Select LAST_INSERT_ID() as studentId ";
                    //HttpContext.Current.Response.Write(_qry);
                    //HttpContext.Current.Response.End();
                    StudentComm.CommandText = _qry;
                    StudentComm.Connection = con;

                    studentId = Convert.ToInt32(StudentComm.ExecuteScalar().ToString());
                    //studentId = 10;

                    //Response.Write("Course:" + dtcourse.Rows.Count);
                    //Response.Write("Diploma:" + dtdiploma.Rows.Count);
                    //Response.End();

                    if (studentId > 0)
                    {
                        int courseId = 0;
                        int status = 2;
                        //Response.Write("Count Is:"+dtcourse.Rows.Count);
                        //Response.End();
                        if (dtcourse.Rows.Count > 0)
                        {
                            string cour_Name = "";
                            int cour_idd = 0;
                            int sstatus = 2;
                            cour_Name = MVC.CommonFunction.GetCoursecode(lblcurrmod.Text.ToString());
                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                            MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcour = new DataTable();
                            da15.Fill(dtcour);
                            if (dtcour.Rows.Count > 0)
                            {
                                cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                            }
                            //Response.Write("Course ID:" + cour_idd);
                            if (xx > 0)
                            {
                                for (int icourse = 0; icourse < dtcourse.Rows.Count; icourse++)
                                {
                                    sstatus = 2;
                                    if (dtcourse.Rows[icourse]["Comb_CourseId"] != "" && dtcourse.Rows[icourse]["Comb_CourseId"] != "0")
                                    {
                                        if (cour_idd == Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]))
                                        {
                                            sstatus = 1;
                                        }
                                        _qry = "Insert Into exam_studentcoursedetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                        _qry += " (" + studentId + "," + Convert.ToInt32(dtcourse.Rows[icourse]["Comb_CourseId"]) + ",0," + sstatus + ",current_date,current_date) ";
                                        MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                        coursecmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        if (cour_idd == Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]))
                                        {
                                            sstatus = 1;
                                        }
                                        _qry = "Insert Into exam_studentcoursedetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                        _qry += " (" + studentId + ",0," + Convert.ToInt32(dtcourse.Rows[icourse]["softwareId"]) + "," + sstatus + ",current_date,current_date) ";
                                        MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                        coursecmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                if (cour_idd == Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]))
                                {
                                    sstatus = 1;
                                }
                                _qry = "Insert Into exam_studentcoursedetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                _qry += " (" + studentId + "," + Convert.ToInt32(dtcourse.Rows[0]["Course_Id"]) + ",0," + sstatus + ",current_date,current_date) ";
                                MySqlCommand coursecmd = new MySqlCommand(_qry, con);
                                coursecmd.ExecuteNonQuery();
                            }
                        }
                        else if (dtdiploma.Rows.Count > 0)
                        {
                            string cour_Name = "";
                            int cour_idd = 0;
                            int sstatus = 2;
                            cour_Name = MVC.CommonFunction.GetCoursecode(lblcurrmod.Text.ToString());
                            _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                            MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                            DataTable dtcour = new DataTable();
                            da15.Fill(dtcour);
                            if (dtcour.Rows.Count > 0)
                            {
                                cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                            }
                            for (int idiploma = 0; idiploma < dtdiploma.Rows.Count; idiploma++)
                            {
                                sstatus = 2;
                                if (dtdiploma.Rows[idiploma]["Certificate_Id"] != "" && Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) != 0)
                                {
                                    if (cour_idd == Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]))
                                    {
                                        sstatus = 1;
                                    }
                                    _qry = "Insert Into exam_studentcoursedetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + "," + Convert.ToInt32(dtdiploma.Rows[idiploma]["Certificate_Id"]) + ",0," + sstatus + ",current_date,current_date) ";
                                    MySqlCommand dipcmd = new MySqlCommand(_qry, con);
                                    dipcmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    if (cour_idd == Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]))
                                    {
                                        sstatus = 1;
                                    }
                                    _qry = "Insert Into exam_studentcoursedetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + ",0," + Convert.ToInt32(dtdiploma.Rows[idiploma]["softwareId"]) + "," + sstatus + ",current_date,current_date) ";

                                    MySqlCommand dipcmd = new MySqlCommand(_qry, con);
                                    dipcmd.ExecuteNonQuery();
                                }
                            }
                        }

                    }

                    lblmsg1.Text = "Student Details Added Successfully";
                }
                
            }
        }
        FillGrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}
