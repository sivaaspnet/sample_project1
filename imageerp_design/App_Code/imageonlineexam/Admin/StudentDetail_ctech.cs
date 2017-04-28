using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Globalization;
/// <summary>
/// Summary description for StudentDetail
/// </summary>
namespace MVC1
{
    public class StudentDetail_ctech
    {
        private int _retInt;
        private string _qry;

        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        #region Declaring All Details In The Constructor
        public StudentDetail_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }
        #endregion

        #region Getting Course Details
        public void GettingCourseDetails(GridView GridView1, int refWhere, int studentId)
        {
            try
            {
                if (refWhere == 1)
                {
                    //_qry = " SELECT C.courseId,REPLACE(C.courseName,'~','''')as dispCourseName,";
                    //_qry += " Case IFNULL(S.courseId,0) When 0 Then 0 else 1 end as flag,ifnull(S.status,2)as dispStatus   from Exam_CourseDetails C LEFT outer join ";
                    //_qry += " Exam_StudentCourseDetails S ON S.courseId=C.courseId  And S.studentId=" + studentId + "  ";//Where C.status=1
                    _qry = " SELECT soft.softwareId,REPLACE(soft.software_name,'~','''')as dispCourseName,";
                    _qry += " Case IFNULL(S.courseId,0) When 0 Then 0 else 1 end as flag,ifnull(S.status,2)as dispStatus   from Exam_CourseDetails C LEFT outer join ";
                    _qry += " Exam_StudentCourseDetails S ON S.courseId=soft.softwareId  And S.studentId=" + studentId + "  ";//Where C.status=1
                
                   // MVC.SiteFunctions.WriteString(_qry);
                    FillDataControls.FillGridView(GridView1, _qry);
                    //FillDataControls.FillDataList(dtaCourseList, _qry);
                }
                else
                {
                    _qry = "SELECT soft.softwareId,soft.software_name FROM Exam_softwareDetails soft inner join Exam_SubModuleDetails S on soft.softwareId=S.subModuleName where softstatus=1";
                    //_qry = "SELECT C.courseId,REPLACE(C.courseName,'~','''')as dispCourseName,0 as flag,2 as dispStatus From Exam_CourseDetails C ";//Where C.status=1
                    FillDataControls.FillGridView(GridView1, _qry);
                    //FillDataControls.FillDataList(dtaCourseList, _qry);
                }
            }
            catch(Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            
        }
        #endregion

        #region Getting Student Details
        public void GetStudentDetail(GridView grdStudentDetails,DropDownList ddlCenter,TextBox txtFromDate,TextBox txtToDate, TextBox txtSearch, Label lblNoOfRecords)
        {
            try
            {
                string searchText = "",fromText="",toText="";
                if (txtSearch.Text.Trim() == "Name / RegNo / Centre")
                {
                    searchText = "";
                }
                else
                {
                    searchText = SiteFunctions.databaseset(txtSearch.Text.Trim());
                }
                fromText = SiteFunctions.databaseset(txtFromDate.Text.Trim());
                toText = SiteFunctions.databaseset(txtToDate.Text.Trim());


               


                string chkCentreId = "", chkDateRange="";

                if (HttpContext.Current.Session["CentreId"] != null)
                {
                    int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    if (userType != "MASTER")
                    {
                        chkCentreId = " Where C.centreId=" + centreId + " ";
                    }
                }
                if (fromText != "" && toText != "")
                {
                    /*string sfMnth = fromText.Split('-')[1].ToString();
                    string sfDay = fromText.Split('-')[0].ToString();
                    string sfYr = fromText.Split('-')[2].ToString();
                    fromText = sfMnth + "/" + sfDay + "/" + sfYr;

                    string stMnth = toText.Split('-')[1].ToString();
                    string stDay = toText.Split('-')[0].ToString();
                    string stYr = toText.Split('-')[2].ToString();
                    toText = stMnth + "/" + stDay + "/" + stYr;*/

                    chkDateRange += " AND S.dateIns between STR_TO_DATE('" + fromText + "', '%m/%d/%Y')   and STR_TO_DATE('" + toText + "', '%m/%d/%Y') ";
                }
                
                DataTable dt;
                _qry = "SELECT S.studentId,REPLACE(S.studentName,'~','''')as dispStudentName,REPLACE(S.studentRegNo,'~','''')as dispStudentRegNo,S.centreId,REPLACE(C.centreLocation,'~','''')as location,DATE_FORMAT(IFNULL(S.doj,''), '%d/%m/%Y' ) AS doj,DATE_FORMAT(IFNULL(S.examdate,''), '%d/%m/%Y' ) AS examdate,IFNULL(S.invoiceno,'') AS  invoiceno,DATE_FORMAT(IFNULL(S.dateIns,''), '%d/%m/%Y' ) AS dateIns,(SELECT Course_name from  Exam_coursedetail where course_id=S.Course_diploma) as Diploma, (SELECT Course_name from  Exam_coursedetail where course_id=S.Course_certificate) as certificate, ";
                _qry += " case ri.fees_checking_status  when 1 then 'Enable' else 'Disable' end as feeschecking_status,ri.feeStatus_reason,ri.feeStatus_datemod ,S.reason_admin_registration";
                _qry += " From Exam_StudentDetails S ";
                _qry += " inner join Exam_coursedetail ec on (ec.Course_id=S.Course_diploma or ec.Course_id=S.Course_certificate) ";
                _qry += " INNER JOIN Exam_CentreDetails C ON C.centreId=S.centreId And C.status=1 " + chkDateRange + " ";
                if (searchText !="")
                {
                    _qry += " And (ifNull(S.studentName,'') LIKE '%" + searchText + "%' OR ifNull(S.studentRegNo,'') LIKE '%" + searchText + "%'   OR S.centreId IN (Select centreId From Exam_CentreDetails Where C.centreLocation LIKE '%" + searchText + "%' ))";
                }                  
                if (ddlCenter.SelectedIndex > 0)
                {
                    _qry += " And S.centreId =" + ddlCenter.SelectedValue + " ";
                }
                _qry += " left join registration_indent ri on ri.student_exam_id=S.studentId";
                 _qry += "  where ec.Erp_courseid<>'' and Course_name like '%ctech%'";
                 _qry += " Order By S.dateIns Desc,S.studentId desc";


         
                //HttpContext.Current.Response.Write(_qry);

                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);

                grdStudentDetails.DataSource = dt;
                grdStudentDetails.DataBind();

                lblNoOfRecords.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
         
        }

        public void GetCertificateStudentDetail(GridView grdStudentDetails, TextBox txtSearch, Label lblNoOfRecords)
        {
            try
            {
                string searchText = "";
                if (txtSearch.Text.Trim() == "Name / RegNo / Centre")
                {
                    searchText = "";
                }
                else
                {
                    searchText = SiteFunctions.databaseset(txtSearch.Text.Trim());
                }
                 

                string chkCentreId = "";

                if (HttpContext.Current.Session["CentreId"] != null)
                {
                    int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    if (userType != "MASTER")
                    {
                        chkCentreId = " Where C.centreId=" + centreId + " ";
                    }
                }


                DataTable dt;
                _qry = "SELECT S.studentId,REPLACE(S.studentName,'~','''')as dispStudentName,REPLACE(S.studentRegNo,'~','''')as dispStudentRegNo,S.centreId,REPLACE(C.centreLocation,'~','''')as location,DATE_FORMAT(IFNULL(doj,''), '%d/%m/%Y' ) AS doj,DATE_FORMAT(IFNULL(examdate,''), '%d/%m/%Y' ) AS examdate,IFNULL(invoiceno,'') AS  invoiceno,DATE_FORMAT(IFNULL(S.dateIns,''), '%d/%m/%Y' ) AS dateIns ";
                _qry += " From Exam_StudentDetails S INNER JOIN Exam_CentreDetails C ON C.centreId=S.centreId And C.status=1 " + chkCentreId + " ";
                _qry += " And (ifNull(S.studentName,'') LIKE '%" + searchText + "%' OR ifNull(S.studentRegNo,'') LIKE '%" + searchText + "%'   OR S.centreId IN (Select centreId From Exam_CentreDetails Where C.centreLocation LIKE '%" + searchText + "%' ))";
                _qry += " Order By S.dateMod Desc";



               /// HttpContext.Current.Response.Write(_qry);

                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);

                grdStudentDetails.DataSource = dt;
                grdStudentDetails.DataBind();

                lblNoOfRecords.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }

        }
        #endregion

        #region Inserting New Student Details With Selected Diploma Course
        public int AddNewStudentDetail(TextBox txtRegNo, TextBox txtName, DropDownList ddlLocation, GridView GridView1, Label lblMsg, DropDownList ddldiploma, DropDownList ddlcertificate,TextBox txtDoj,TextBox txtInvoice,TextBox txtexamdate,DropDownList ddlupgrade,TextBox txt_reason)
        {
            _retInt = 0;
            int setFlag = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
            MySqlCommand StudentComm = new MySqlCommand();
            MySqlCommand CourseComm = new MySqlCommand();
            try
            {
                DateTime dt = new DateTime();
                DateTime dtexam = new DateTime();
                CultureInfo culture = new CultureInfo("ru-RU");
                dt = Convert.ToDateTime(txtDoj.Text, culture);
                dtexam = Convert.ToDateTime(txtexamdate.Text, culture);
                _qry = "SELECT r.mark,CASE When r.mark>=40 Then 'Pass' Else 'Fail' End as TestStatus,COALESCE((Select course_name from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_name from Exam_coursedetail where course_id=r.Certificate_Id)) as Coursename,COALESCE((Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id)) as Courseid ,Count( r.mark ) AS numattempt FROM Exam_Results r INNER JOIN Exam_StudentDetails s ON s.studentid = r.studentid WHERE TRIM(s.studentRegNo)=@txtRegNo AND @coursenameid=COALESCE((Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id))  ORDER BY r.resultid LIMIT 1";
                Comm.CommandText = _qry;
                Comm.Connection = mySqlConn;
                Comm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                Comm.Parameters.Add("@coursenameid", MySqlDbType.Int32, 4).Value = ddldiploma.SelectedValue;
                //Comm.Parameters.Add("@txtName", MySqlDbType.VarChar, 100).Value = txtName.Text.Trim();


                DataTable dt1 = new DataTable();
                dt1 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);

                if (dt1.Rows.Count > 0)
                {

                    //
                    if ((dt1.Rows[0]["TestStatus"].ToString() == "Pass") || ((dt1.Rows[0]["TestStatus"].ToString() == "Fail")  && dt1.Rows[0]["Courseid"].ToString() == ddldiploma.SelectedValue) || (dt1.Rows[0]["Courseid"].ToString() != ddldiploma.SelectedValue))
                    {
                        setFlag = 1;
                        int studentId = 0;
                        _qry = " Insert into Exam_StudentDetails ";
                        _qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod,doj,invoiceno,examdate,reason_admin_registration) Values ";
                        _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000'),@doj,@invoiceno,@examdate,@reason_admin_registration); Select LAST_INSERT_ID() as studentId ";

                        // _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,current_date,current_date,@doj,@invoiceno,@delstatus); Select LAST_INSERT_ID() as studentId ";
                        //HttpContext.Current.Response.Write(_qry);
                        //HttpContext.Current.Response.End();


                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = mySqlConn;



                        StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                        StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                        StudentComm.Parameters.Add("@ddldiploma", MySqlDbType.Int32).Value = ddldiploma.SelectedValue;
                        StudentComm.Parameters.Add("@ddlcertificate", MySqlDbType.Int32).Value = "0";
                        StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = ddlLocation.SelectedValue;

                        StudentComm.Parameters.Add("@doj", MySqlDbType.VarChar, 50).Value = dt.ToString("yyyy/MM/dd");
                        StudentComm.Parameters.Add("@invoiceno", MySqlDbType.VarChar, 50).Value = txtInvoice.Text;

                        StudentComm.Parameters.Add("@examdate", MySqlDbType.VarChar, 50).Value = dtexam.ToString("yyyy/MM/dd");

                        StudentComm.Parameters.Add("@reason_admin_registration", MySqlDbType.VarChar, 500).Value = txt_reason.Text;

                        studentId = Mysqlconn_ctech.ExecuteMysqlScalar(StudentComm);


                        if (studentId > 0)
                        {
                            int courseId = 0;
                            int status = 2;

                            foreach (GridViewRow row in GridView1.Rows)
                            {


                                DropDownList ddlstatus = new DropDownList();
                                ddlstatus = (DropDownList)row.FindControl("ddlstatusdiploma");

                                string lbl = ((Label)row.FindControl("hdnlblsftid1")).Text;

                                string lblcertId1 = ((Label)row.FindControl("hdncertID1")).Text;


                                string lblSOFTid = ((Label)row.FindControl("hdnsoft")).Text;

                                if (lblcertId1 != "" && lblcertId1 != "0")
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + "," + lblcertId1 + ",0," + ddlstatus.SelectedValue + ",current_date,current_date) ";
                                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }

                                if (lblSOFTid != "" && lblSOFTid != "0")
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + ",0," + lblSOFTid + "," + ddlstatus.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";

                                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }

                            }

                        }

                        lblMsg.Text = "Student Details Added Successfully";
                    }
                    else
                    {
                        lblMsg.Text = "Student failed in previous exam, No. of Attempt :" + dt1.Rows[0]["numattempt"].ToString() + "";
                    }

                }
                else  
                {
                    
                        setFlag = 1;
                        int studentId = 0;
                        _qry = " Insert into Exam_StudentDetails ";
                        _qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod,doj,invoiceno,examdate,reason_admin_registration) Values ";
                        _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000'),@doj,@invoiceno,@examdate,@reason_admin_registration); Select LAST_INSERT_ID() as studentId ";
                    
                       // _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,current_date,current_date,@doj,@invoiceno,@delstatus); Select LAST_INSERT_ID() as studentId ";
                        //HttpContext.Current.Response.Write(_qry);
                        //HttpContext.Current.Response.End();


                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = mySqlConn;

                

                        StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                        StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                        StudentComm.Parameters.Add("@ddldiploma", MySqlDbType.Int32).Value = ddldiploma.SelectedValue;
                        StudentComm.Parameters.Add("@ddlcertificate", MySqlDbType.Int32).Value = "0";
                        StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = ddlLocation.SelectedValue;

                        StudentComm.Parameters.Add("@doj", MySqlDbType.VarChar,50).Value = dt.ToString("yyyy/MM/dd");
                        StudentComm.Parameters.Add("@invoiceno", MySqlDbType.VarChar,50).Value = txtInvoice.Text;
                    
                        StudentComm.Parameters.Add("@examdate", MySqlDbType.VarChar, 50).Value = dtexam.ToString("yyyy/MM/dd");

                        StudentComm.Parameters.Add("@reason_admin_registration", MySqlDbType.VarChar, 500).Value = txt_reason.Text;


                        studentId = Mysqlconn_ctech.ExecuteMysqlScalar(StudentComm);

                      
                        if (studentId > 0)
                        {
                            int courseId = 0;
                            int status = 2;
                           
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                
                                
                                DropDownList ddlstatus = new DropDownList();
                                ddlstatus = (DropDownList)row.FindControl("ddlstatusdiploma");

                                string lbl = ((Label)row.FindControl("hdnlblsftid1")).Text;

                                string lblcertId1 = ((Label)row.FindControl("hdncertID1")).Text;


                                string lblSOFTid = ((Label)row.FindControl("hdnsoft")).Text;
                            
                                if (lblcertId1 != "" && lblcertId1 != "0")
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + "," + lblcertId1 + ",0," + ddlstatus.SelectedValue + ",current_date,current_date) ";
                                   Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }
                                   
                                if (lblSOFTid != "" && lblSOFTid != "0")
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + ",0," + lblSOFTid + "," + ddlstatus.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";
                                   
                                   Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }
                              
                            }
                               
                            }

                            lblMsg.Text = "Student Details Added Successfully";
                        }
            
                   
                
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
                Mysqlconn_ctech.disposeCommand(StudentComm);
                Mysqlconn_ctech.disposeCommand(CourseComm);
            }

            return setFlag;
        }
        #endregion

       #region Inserting New Student Details With Selected Certificate Course
        public int AddNewStudentCertificateDetail(TextBox txtRegNo, TextBox txtName, DropDownList ddlLocation, DropDownList ddlstatuscerti, GridView GridView2, Label lblMsg, DropDownList ddldiploma, DropDownList ddlcertificate, TextBox txtDoj, TextBox txtInvoice, TextBox txtExamDate, DropDownList ddlupgrade,TextBox txt_reason)
        {
            _retInt = 0;
            int setFlag = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
            MySqlCommand Comm2 = new MySqlCommand();
            MySqlCommand StudentComm = new MySqlCommand();
            MySqlCommand CourseComm = new MySqlCommand();
            try
            {
               // _qry = "SELECT r.mark,CASE When r.mark>=40 Then 'Pass' Else 'Fail' End as TestStatus,COALESCE((Select course_name from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_name from Exam_coursedetail where course_id=r.Certificate_Id)) as Coursename,COALESCE((Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id)) as Courseid ,Count( r.mark ) AS numattempt FROM Exam_Results r INNER JOIN Exam_StudentDetails s ON s.studentid = r.studentid WHERE TRIM(s.studentRegNo)=@txtRegNo AND @coursenameid=Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id))  ORDER BY r.resultid LIMIT 1";
                _qry = "SELECT r.mark,CASE When r.mark>=40 Then 'Pass' Else 'Fail' End as TestStatus,COALESCE((Select course_name from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_name from Exam_coursedetail where course_id=r.Certificate_Id)) as Coursename,COALESCE((Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id)) as Courseid ,Count( r.mark ) AS numattempt FROM Exam_Results r INNER JOIN Exam_StudentDetails s ON s.studentid = r.studentid WHERE TRIM(s.studentRegNo)=@txtRegNo AND @coursenameid=COALESCE((Select course_id from Exam_coursedetail where course_id=r.Software_Id) ,(Select course_id from Exam_coursedetail where course_id=r.Certificate_Id))  ORDER BY r.resultid LIMIT 1";
                Comm.CommandText = _qry;
                Comm.Connection = mySqlConn;
                Comm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                Comm.Parameters.Add("@coursenameid", MySqlDbType.Int32, 4).Value = ddlcertificate.SelectedValue;
                DataTable dt1 = new DataTable();
                dt1 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);

             
                if (dt1.Rows.Count > 0)
                { 
                    if ((dt1.Rows[0]["TestStatus"].ToString() == "Pass") || ((dt1.Rows[0]["TestStatus"].ToString() == "Fail") && dt1.Rows[0]["Courseid"].ToString() == ddlcertificate.SelectedValue) || (dt1.Rows[0]["Courseid"].ToString() != ddlcertificate.SelectedValue))
                    {
                        DateTime dt = new DateTime();
                        DateTime dtExam = new DateTime();
                        CultureInfo culture = new CultureInfo("ru-RU");
                        dt = Convert.ToDateTime(txtDoj.Text, culture);
                        dtExam = Convert.ToDateTime(txtExamDate.Text, culture);
                        setFlag = 1;
                        int studentId = 0;
                        _qry = " Insert into Exam_StudentDetails ";
                        _qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod,doj,invoiceno,examdate,reason_admin_registration) Values ";
                        _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000'),@doj,@invoiceno,@examdate,@reason_admin_registration); Select LAST_INSERT_ID() as studentId ";
                        //HttpContext.Current.Response.Write(_qry);
                        //HttpContext.Current.Response.End();
                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = mySqlConn;

                        StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                        StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                        StudentComm.Parameters.Add("@ddldiploma", MySqlDbType.Int32).Value = "0";
                        StudentComm.Parameters.Add("@ddlcertificate", MySqlDbType.Int32).Value = ddlcertificate.SelectedValue;
                        StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = ddlLocation.SelectedValue;

                        StudentComm.Parameters.Add("@doj", MySqlDbType.VarChar, 50).Value = dt.ToString("yyyy/MM/dd");
                        StudentComm.Parameters.Add("@invoiceno", MySqlDbType.VarChar, 50).Value = txtInvoice.Text;
                        StudentComm.Parameters.Add("@examdate", MySqlDbType.VarChar, 50).Value = dtExam.ToString("yyyy/MM/dd");
                        StudentComm.Parameters.Add("@reason_admin_registration", MySqlDbType.VarChar, 500).Value = txt_reason.Text;

                        
                        studentId = Mysqlconn_ctech.ExecuteMysqlScalar(StudentComm);
                        if (studentId > 0)
                        {
                            int courseId = 0;
                            int status = 2;

                            //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                            //_qry += " (" + studentId + "," + ddlcertificate.SelectedValue+ ",0," + ddlstatuscerti.SelectedValue + ",current_date,current_date) ";


                            //Mysqlconn.ExecuteMySqlCommand(_qry);  


                            if (GridView2.Visible == true)
                            {
                                foreach (GridViewRow row in GridView2.Rows)
                                {
                                    DropDownList ddlstatus1 = new DropDownList();
                                    ddlstatus1 = (DropDownList)row.FindControl("ddlstatuscerti1");

                                    string lblcertId2 = ((Label)row.FindControl("hdncertID2")).Text;
                                    string lbl = ((Label)row.FindControl("hdnlblsftid2")).Text;

                                    string lblsoftId = ((Label)row.FindControl("hdnsoftId")).Text;

                                    if (lblcertId2 != "" && lblcertId2 != "0")
                                    {
                                        _qry = "Insert Into Exam_StudentCourseDetails(studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                        _qry += " (" + studentId + "," + lblcertId2 + ",0," + ddlstatus1.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                                        Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                    }
                                    else
                                    {
                                        _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                        _qry += " (" + studentId + ",0," + lblsoftId + "," + ddlstatus1.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                                        Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                    }

                                }
                            }

                            else
                            {
                                _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                _qry += " (" + studentId + "," + ddlcertificate.SelectedValue + ",0," + ddlstatuscerti.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                                Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                            }

                        }

                        lblMsg.Text = "Student Details Added Successfully";
                    }
                    else
                    {
                        lblMsg.Text = "Student failed in previous exam, No. of Attempt :" + dt1.Rows[0]["numattempt"].ToString() + "";
                    }
                }
                else
                {
                    DateTime dt = new DateTime();
                    DateTime dtExam = new DateTime();
                    CultureInfo culture = new CultureInfo("ru-RU");
                    dt = Convert.ToDateTime(txtDoj.Text, culture);
                    dtExam = Convert.ToDateTime(txtExamDate.Text, culture);
                    setFlag = 1;
                    int studentId = 0;
                    _qry = " Insert into Exam_StudentDetails ";
                    _qry += " (studentName,studentRegNo,Course_diploma,Course_certificate,centreId,dateIns,dateMod,doj,invoiceno,examdate,reason_admin_registration) Values ";
                    _qry += " (@txtName,@txtRegNo,@ddldiploma,@ddlcertificate,@ddlLocation,ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000'),@doj,@invoiceno,@examdate,@reason_admin_registration); Select LAST_INSERT_ID() as studentId ";
                    //HttpContext.Current.Response.Write(_qry);
                    //HttpContext.Current.Response.End();
                    StudentComm.CommandText = _qry;
                    StudentComm.Connection = mySqlConn;

                    StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                    StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                    StudentComm.Parameters.Add("@ddldiploma", MySqlDbType.Int32).Value = "0";
                    StudentComm.Parameters.Add("@ddlcertificate", MySqlDbType.Int32).Value = ddlcertificate.SelectedValue;
                    StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = ddlLocation.SelectedValue;

                    StudentComm.Parameters.Add("@doj", MySqlDbType.VarChar, 50).Value = dt.ToString("yyyy/MM/dd");
                    StudentComm.Parameters.Add("@invoiceno", MySqlDbType.VarChar, 50).Value = txtInvoice.Text;
                    StudentComm.Parameters.Add("@examdate", MySqlDbType.VarChar, 50).Value = dtExam.ToString("yyyy/MM/dd");
                    StudentComm.Parameters.Add("@reason_admin_registration", MySqlDbType.VarChar, 500).Value = txt_reason.Text;

                    
                    studentId = Mysqlconn_ctech.ExecuteMysqlScalar(StudentComm);
                    if (studentId > 0)
                    {
                        int courseId = 0;
                        int status = 2;

                        //_qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                        //_qry += " (" + studentId + "," + ddlcertificate.SelectedValue+ ",0," + ddlstatuscerti.SelectedValue + ",current_date,current_date) ";


                        //Mysqlconn.ExecuteMySqlCommand(_qry);  


                        if (GridView2.Visible == true)
                        {
                            foreach (GridViewRow row in GridView2.Rows)
                            {
                                DropDownList ddlstatus1 = new DropDownList();
                                ddlstatus1 = (DropDownList)row.FindControl("ddlstatuscerti1");

                                string lblcertId2 = ((Label)row.FindControl("hdncertID2")).Text;
                                string lbl = ((Label)row.FindControl("hdnlblsftid2")).Text;

                                string lblsoftId = ((Label)row.FindControl("hdnsoftId")).Text;

                                if (lblcertId2 != "" && lblcertId2 != "0")
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails(studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + "," + lblcertId2 + ",0," + ddlstatus1.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }
                                else
                                {
                                    _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                                    _qry += " (" + studentId + ",0," + lblsoftId + "," + ddlstatus1.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                                }

                            }
                        }

                        else
                        {
                            _qry = "Insert Into Exam_StudentCourseDetails (studentId,Certificate_Id,softwareId,status,dateIns,dateMod) Values ";
                            _qry += " (" + studentId + "," + ddlcertificate.SelectedValue + ",0," + ddlstatuscerti.SelectedValue + ",ADDTIME(Now(), '0 12:30:0.000000'),ADDTIME(Now(), '0 12:30:0.000000')) ";


                            Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                        }

                    }

                    lblMsg.Text = "Student Details Added Successfully";
                }
               
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
                Mysqlconn_ctech.disposeCommand(StudentComm);
                Mysqlconn_ctech.disposeCommand(CourseComm);
            }

            return setFlag;
        }
       #endregion

        #region Updating The Student Details and Course Details
        public int UpdateStudentDetail(int studentId, TextBox txtRegNo, TextBox txtName, DropDownList ddlLocation, GridView GridView1, Label lblMsg, Label lblMsgOnGrid, DropDownList DropDownList1)
        {
            int _insCount = 0;
            _retInt = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
            MySqlCommand StudentComm = new MySqlCommand();
            MySqlCommand CourseComm = new MySqlCommand();
            try
            {
                _qry = "Select count(studentId)as cnt From Exam_StudentDetails Where TRIM(studentRegNo)=@txtRegNo And studentId<>@studentId ";
                Comm.CommandText = _qry;
                Comm.Connection = mySqlConn;

                Comm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;

                _retInt = Mysqlconn_ctech.ExecuteMysqlScalar(Comm);
                if (_retInt > 0)
                {
                    lblMsg.Text = "Registration number already exists";
                }
                else
                {
                    //if (!IsCourseSelected(dtaCourseList))
                    //{
                    //    lblMsg.Text = "Course Is Not Selected For This Student";
                    //}
                    //else
                    //{
                        Mysqlconn_ctech.disposeConnection(mySqlConn);
                        mySqlConn.Open();

                        _qry = " Update Exam_StudentDetails Set ";
                        _qry += " studentName=@txtName,studentRegNo=@txtRegNo,Course_taken=@DropDownList1,centreId=@ddlLocation,dateMod=current_date ";
                        _qry += " Where studentId=@studentId ";

                        //lblMsg.Text = _qry;

                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = mySqlConn;

                        StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                        StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                        StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = Convert.ToInt32(ddlLocation.SelectedValue.ToString());
                        StudentComm.Parameters.Add("@DropDownList1", MySqlDbType.Int32).Value = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                        StudentComm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;

                        _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(StudentComm);

                        //lblMsg.Text = _retInt.ToString();

                        if (_retInt > 0)
                        {
                            int courseId = 0;
                            int flag = 0;
                            int status = 2;
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                DropDownList ddlstatus = new DropDownList();
                                ddlstatus = (DropDownList)row.FindControl("DropDownList2");

                                string lbl = ((Label)row.FindControl("hdnlblsftid")).Text;

                                _qry = "Update Exam_StudentCourseDetails Set status=" + ddlstatus.SelectedValue + ",dateMod=current_date ";
                               _qry += " Where studentId=" + studentId + " And courseId=" + lbl + "";
                               Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                               if (Convert.ToInt32(ddlstatus.SelectedValue) < 3)
                               {
                                   _qry += "Update Exam_Results Set delStatus=1 Where studentId=" + studentId + " and courseId=" + lbl + "";
                               }
                               Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                            }
                            lblMsg.Text = "Student Details Updated Successfully";
                        //    foreach (GridViewRow row in GridView1.Rows)
                        //    {
                        //        //courseId = Convert.ToInt32(dtaCourseList.DataKeys[Item.ItemIndex].ToString());
                        //        //flag = Convert.ToInt32(((HiddenField)Item.FindControl("hdnFlag")).Value);
                        //        //status = Convert.ToInt32(((DropDownList)Item.FindControl("ddlStatus")).SelectedValue);
                        //        if (((CheckBox)Item.FindControl("chkCourse")).Checked == false && flag == 1)
                        //        {
                        //            _qry = "Delete From Exam_StudentCourseDetails Where courseId=" + courseId + " And studentId=" + studentId + "";
                        //            Mysqlconn.ExecuteMySqlCommand(_qry);
                        //        }
                        //        else if (((CheckBox)Item.FindControl("chkCourse")).Checked == true && flag == 0)
                        //        {
                        //            _qry = "Insert Into Exam_StudentCourseDetails (studentId,courseId,status,dateIns,dateMod) Values ";
                        //            _qry += " (" + studentId + "," + courseId + "," + status + ",current_date,current_date) ";

                        //            Mysqlconn.ExecuteMySqlCommand(_qry);
                        //        }
                        //        else if (((CheckBox)Item.FindControl("chkCourse")).Checked == true && flag == 1)
                        //        {
                        //            //_qry = "Insert Into Exam_StudentCourseDetails (studentId,courseId,status,dateIns,dateMod) Values ";
                        //            //_qry += " (" + studentId + "," + courseId + "," + status + ",current_date,current_date) ";

                        //            _qry = "Update Exam_StudentCourseDetails Set status=" + status + ",dateMod=current_date ";
                        //            _qry += " Where studentId=" + studentId + " And courseId=" + courseId + "; ";
                        //            if (status < 3)
                        //            {
                        //                _qry += "Update Exam_Results Set delStatus=1 Where studentId=" + studentId + " and courseId=" + courseId + "";
                        //            }

                        //            Mysqlconn.ExecuteMySqlCommand(_qry);
                        //        }

                        //    }
                          
                        //}
                        //_insCount = 1;
                   }
                }
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
                Mysqlconn_ctech.disposeCommand(StudentComm);
                Mysqlconn_ctech.disposeCommand(CourseComm);
            }

            return _insCount;
        }
        #endregion

        #region Checking Course Id From DataTable
        public bool IsCourseSelected(DataList dtaCourseList)
        {
            foreach (DataListItem Item in dtaCourseList.Items)
            {
                if (((CheckBox)Item.FindControl("chkCourse")).Checked == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion


    }
}
