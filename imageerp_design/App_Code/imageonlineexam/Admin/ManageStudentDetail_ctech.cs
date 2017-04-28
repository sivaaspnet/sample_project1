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

/// <summary>
/// Summary description for ManageStudentDetail
/// </summary>
namespace MVC1
{
    public class ManageStudentDetail_ctech
    {
        private int _retInt;
        private string _qry;
        string cou_taken;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        #region Constructor To Declare Predeclare Values
        public ManageStudentDetail_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }
        #endregion

        #region Show Student Information
        public void ShowStudentInfo(int studentId, Label lblStudentName, Label lblRegNo, Label lblCentre,Label course_taken,GridView GridView1, Label lblNoCourseMsg,Label lblDOJ,Label lblInvoiceNo,Label lbl_feestatus_reason,Label lbl_feestatus_date)
        {
            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            int xx = 0;
            MySqlCommand Comm = new MySqlCommand();
            _qry = "SELECT S.studentId,REPLACE(C.centreLocation,'~','''')as location,REPLACE(S.studentName,'~','''')as dispStudentName, ";
            _qry += " REPLACE(S.studentRegNo,'~','''')as dispStudentRegNo,S.centreId,S.Course_diploma,S.Course_certificate,REPLACE(S.invoiceno,'~','''')as invoiceno,DATE_FORMAT(S.doj,'%d/%m/%Y') as doj, S.reason_admin_registration as feesreason, S.dateIns as feesdate";
            _qry += " From Exam_StudentDetails S INNER JOIN Exam_CentreDetails C ON C.centreId=S.centreId Where S.studentId=@studentId ";//And C.status=1
            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;
            Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
            try
            {
               
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count>0)
                {
                    lblStudentName.Text = dt.Rows[0]["dispStudentName"].ToString();
                    lblRegNo.Text = dt.Rows[0]["dispStudentRegNo"].ToString();
                    lblCentre.Text = dt.Rows[0]["location"].ToString();
                    lblInvoiceNo.Text = dt.Rows[0]["invoiceno"].ToString();
                    lblDOJ.Text = dt.Rows[0]["doj"].ToString();
                    lbl_feestatus_reason.Text = dt.Rows[0]["feesreason"].ToString();
                    lbl_feestatus_date.Text=dt.Rows[0]["feesdate"].ToString();
                    if (dt.Rows[0]["Course_diploma"].ToString() != "0")
                    {
                        cou_taken = dt.Rows[0]["Course_diploma"].ToString();
                        xx = 1;
                    }
                    else
                    {
                        cou_taken = dt.Rows[0]["Course_certificate"].ToString();
                        xx = 2;
                    }

                    _qry = "select Course_name from Exam_coursedetail where Course_id=" + cou_taken + "";
                    //HttpContext.Current.Response.Write(_qry);
                    //HttpContext.Current.Response.End();
                    DataTable dt8 = new DataTable();
                    dt8 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);
                    if (dt8.Rows.Count > 0)
                    {
                        course_taken.Text = dt8.Rows[0]["Course_name"].ToString();
                    }

                    if (xx == 1)
                    {
                        _qry = "SELECT Case ifnull(SC.status,1) When 1 THEN 'Enabled' When 2 Then 'Disabled' Else 'Completed' End as status, CASE when SC.Certificate_Id='0' Then soft.software_name else (select Course_name from Exam_coursedetail where Course_id=SC.Certificate_Id) End as software from Exam_StudentCourseDetails SC  left join Exam_softwareDetails soft on soft.softwareId=SC.softwareId WHERE SC.studentId=" + studentId + "";
                        //HttpContext.Current.Response.Write(_qry);
                        //HttpContext.Current.Response.End();

                        DataTable dt6 = new DataTable();
                        dt6 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);

                        GridView1.DataSource = dt6;
                        GridView1.DataBind();
                    }
                    if (xx == 2)
                    {
                       _qry ="select C.Certificate_Id,Case ifNull(C.certificate_status,1) ";
                       _qry +=" When 1 Then 'Enabled' Else 'Disabled' End as status,CASE when C.Comb_CourseId=0 Then ";
                       _qry +=" S.software_name else (select replace(Course_name,'~','''') as Course_name from Exam_coursedetail where ";
                       _qry +=" Course_id=C.Comb_CourseId) End as software From Exam_Certificate C left join Exam_softwareDetails S on ";
                       _qry += " C.softwareId=S.softwareId inner join Exam_StudentCourseDetails SC on C.Course_Id=SC.Certificate_Id WHERE SC.studentId=" + studentId + "";

                       //HttpContext.Current.Response.Write(_qry);
                       //HttpContext.Current.Response.End();

                       DataTable dt6 = new DataTable();
                       dt6 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);

                       GridView1.DataSource = dt6;
                       GridView1.DataBind();
                    }
                }
               
            }
            catch(Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
            }
        }
        #endregion

        #region Getting Course In The DataList
        private void GetCourseDetails(int studentId, GridView GridView1, Label lblNoCourseMsg)
        {
            try
            {
                _qry = "SELECT soft.software_id,REPLACE(soft.software_name,'~','''')as dispCourseName From Exam_softwareDetails soft Where  soft.software_id IN (Select courseId From Exam_StudentCourseDetails Where studentId=" + studentId + ")";//C.status=1 And
                FillDataControls.FillGridView(GridView1, _qry);
                //FillDataControls.FillDataList(dtaCourseList, _qry);
                if (GridView1.Rows.Count <=0 )
                {
                    lblNoCourseMsg.Visible = true;
                }
                else
                {
                    lblNoCourseMsg.Visible = false;
                }
            }
            catch(Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion


       #region Getting Course In The Grid
        public void GetCourse123(int studentId, GridView grdCourseDetails, Label lblNoCourseMsg, Button btnChangeStatus)
        {
            try
            {
                int stuId = studentId;
                _qry = "SELECT soft.software_id,REPLACE(soft.software_name,'~','''')as dispCourseName From Exam_softwareDetails soft Where  soft.software_id IN (Select courseId From Exam_StudentCourseDetails Where studentId=" + stuId + ")";//C.status=1 And
                FillDataControls.FillGridView(grdCourseDetails, _qry);
                //FillDataControls.FillDataList(dtaCourseList, _qry);
                if (grdCourseDetails.Rows.Count <= 0)
                {
                    lblNoCourseMsg.Visible = true;
                }
                else
                {
                    lblNoCourseMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
          #endregion
        #region Edit Student Information
        public void EditStudentInfo(int studentId, TextBox txtName, TextBox txtRegNo, DropDownList ddlLocation, DropDownList DropDownList1, GridView GridView1)
        {

            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
            _qry = "Select studentName,studentRegNo,centreId,Course_taken From Exam_StudentDetails Where studentId=@studentId";
            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;
            Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count>0)
                {
                    txtName.Text = SiteFunctions.databaseget(dt.Rows[0]["studentName"].ToString());
                    txtRegNo.Text = SiteFunctions.databaseget(dt.Rows[0]["studentRegNo"].ToString());
                    ddlLocation.SelectedValue = dt.Rows[0]["centreId"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["Course_taken"].ToString();

                    MVC1.StudentDetail_ctech studentDetail = new StudentDetail_ctech();
                    studentDetail.GettingCourseDetails(GridView1, 1, studentId);

                    //CheckCheckBox(dtaUpdateCourseList);
                }
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
            }
        }
        #endregion

        //#region Chekcking CheckBox
        //private void CheckCheckBox(DataList dtaUpdateCourseList)
        //{
        //    foreach (DataListItem Item in dtaUpdateCourseList.Items)
        //    {
        //        if (((HiddenField)Item.FindControl("hdnFlag")).Value == "1")
        //        {
        //            ((CheckBox)Item.FindControl("chkCourse")).Checked = true;
        //        }
        //        else
        //        {
        //            ((CheckBox)Item.FindControl("chkCourse")).Checked = false;
        //        }

        //    }
        //}
        //#endregion

        #region Updating The Student Details and Course Details
        public int UpdateStudentDetail(int studentId, TextBox txtRegNo, TextBox txtName, DropDownList ddlLocation, GridView GridView1, Label lblMsg, DropDownList DropDownList1)
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
                    //if (!IsCourseSelected(dtaUpdateCourseList))
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

                        StudentComm.CommandText = _qry;
                        StudentComm.Connection = mySqlConn;

                        StudentComm.Parameters.Add("@txtName", MySqlDbType.VarChar, 50).Value = txtName.Text.Trim();
                        StudentComm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = txtRegNo.Text.Trim();
                        StudentComm.Parameters.Add("@ddlLocation", MySqlDbType.Int32).Value = Convert.ToInt32(ddlLocation.SelectedValue.ToString());
                        StudentComm.Parameters.Add("@DropDownList1", MySqlDbType.Int32).Value = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                        StudentComm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;

                        _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(StudentComm);

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
                               
                              
                                  //_qry = "Insert Into Exam_StudentCourseDetails (studentId,courseId,status,dateIns,dateMod) Values ";
                                    //_qry += " (" + studentId + "," + courseId + "," + status + ",current_date,current_date) ";

                                _qry = "Update Exam_StudentCourseDetails Set status=" + ddlstatus.SelectedValue + ",dateMod=current_date ";
                                _qry += " Where studentId=" + studentId + " And courseId=" + lbl + ""; 

                                if (Convert.ToInt32(ddlstatus.SelectedValue) < 3)
                                {
                                    _qry += "Update Exam_Results Set delStatus=1 Where studentId=" + studentId + " and courseId=" + lbl + "";
                                }

                                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                            }
                        }
                        _insCount = 1;
                    //}
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

        #region Getting Course Detail For This Student
        public void GetCourseDetail(int studentId, GridView grdCourseDetails, Label lblNoOfRecords, Button btnChangeStatus)
        {
            int studId = studentId;
            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
            //_qry = "Select S.courseId,replace(C.courseName,'~','''')as dispCourseName,S.status,Case When ifNull(S.status,2)= 3 Then 1 else S.status End as chkStatus,";
            //_qry += "Case IFNULL(S.STATUS,2) When 3 Then 'Finished'";
            //_qry += " When 2 Then 'Disabled' When 1 Then 'Enabled' End as dispStatus ";
            //_qry += " From Exam_StudentCourseDetails S Inner Join  Exam_CourseDetails C On S.courseId=C.courseId Where S.studentId=@studentId Order By S.status Desc";
            _qry = "Select Soft.softwareId,S.courseId,replace(Soft.software_name,'~','''')as software_name,S.status,Case When ifNull(S.status,1)= 3 Then 1 else S.status End as chkStatus,";
            _qry += "Case IFNULL(S.STATUS,1) When 3 Then 'Finished'";
            _qry += " When 2 Then 'Disabled' When 1 Then 'Enabled' End as dispStatus ";
            _qry += " From Exam_StudentCourseDetails S Inner Join  Exam_softwareDetails Soft On S.courseId=Soft.softwareId Where S.studentId="+studId+" Order By S.status Desc";
            //HttpContext.Current.Response.Write(_qry);
            //HttpContext.Current.Response.End();
            try
            {
                Comm.Connection = mySqlConn;
                Comm.CommandText = _qry;
                //Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);

                grdCourseDetails.DataSource = dt;
                grdCourseDetails.DataBind();

                lblNoOfRecords.Text = dt.Rows.Count.ToString();

                if (dt.Rows.Count > 0)
                {
                    if (HttpContext.Current.Session["UserType"] != null)
                    {
                        string userType = HttpContext.Current.Session["UserType"].ToString();
                        if (userType == "MASTER")
                        {
                            HideControls(grdCourseDetails, btnChangeStatus);
                        }
                        else
                        {
                            btnChangeStatus.Visible = false;
                            grdCourseDetails.Columns[2].Visible = false;
                        }
                    }
                }
                else
                {
                    btnChangeStatus.Visible = false;
                }

                
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
            }
        }
        #endregion

        #region Hiding The DropdownList
        private void HideControls(GridView grdCourseDetails, Button btnChangeStatus)
        {
            int flag = 0;
            foreach (GridViewRow Row in grdCourseDetails.Rows)
            {
                int status = 0;
                status = Convert.ToInt32(((HiddenField)Row.FindControl("hdnStatus")).Value);

                if (status == 3)
                {
                    ((DropDownList)Row.FindControl("ddlStatus")).Visible = false;
                }
                else
                {
                    flag = 1;
                    ((DropDownList)Row.FindControl("ddlStatus")).Visible = true;
                }
            }

            if (flag == 1)
            {
                btnChangeStatus.Visible = true;
            }
            else
            {
                btnChangeStatus.Visible = false;
            }
        }
        #endregion

        #region Deleting The Course Details And Result Details
        public void DeleteCourseDetails(int studentId, int courseId, Label lblCommonMsg)
        {
            try
            {
                _qry = "Delete From Exam_StudentCourseDetails Where studentId=" + studentId + " and courseId=" + courseId + "";
                _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(_qry);

                if (_retInt > 0)
                {
                    _qry = "Delete From Exam_Results Where studentId=" + studentId + " and courseId=" + courseId + "";
                    Mysqlconn_ctech.ExecuteMySqlCommand(_qry);

                    lblCommonMsg.Text = "Course Detail Deleted Successfully";
                }
              
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Changing The Status OF The Course Detail
        public void ChangeStatus(int studentId, GridView grdCourseDetails, Label lblCommonMsg)
        {
            try
            {
                foreach (GridViewRow Row in grdCourseDetails.Rows)
                {
                    int status = 0;
                    status = Convert.ToInt32(((HiddenField)Row.FindControl("hdnStatus")).Value);
                    if (status != 3)
                    {
                        int chgStatus = 0;
                        int courseId = 0;
                        chgStatus = Convert.ToInt32(((DropDownList)Row.FindControl("ddlStatus")).SelectedValue);
                        courseId =(int)grdCourseDetails.DataKeys[Row.RowIndex].Value;

                        _qry = "Update Exam_StudentCourseDetails Set status=" + chgStatus + ",dateMod=current_date ";
                        _qry += " Where studentId=" + studentId + " and courseId=" + courseId + " ";
                        Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                    }
                }
                lblCommonMsg.Text = "Status Updated Successfully";

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
           
        }
        #endregion

        #region Getting Course Detail To Generate Result
        public void FillCourseDetails(int studentId, DropDownList ddlCourse)
        {
            try
            {
                _qry = "SELECT CASE when D.Certificate_Id=0 then soft.softwareId else (select course_Id from Exam_coursedetail where course_Id=D.Certificate_Id)End as CouId ,CASE when D.Certificate_Id=0 then soft.software_name else (select course_name from Exam_coursedetail where course_Id=D.Certificate_Id)End as software from Exam_Results D left join Exam_softwareDetails soft on soft.softwareId=D.software_Id Where D.studentId="+studentId+" and ifNull(delStatus,0)=0";
                
                FillDataControls.FillDropDownList(ddlCourse, _qry, "software", "CouId");
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Getting Module Result Information
        public int SetInformation(int studentId, int courseId, Label lblModule, Label lblTotalQuestion, Label lblCorrectAnswer, Label lblWrongAnswer, Label lblMark, Label lblDate)
        {
            _retInt = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            DataTable dt;
            MySqlCommand Comm = new MySqlCommand();
            //_qry = " SELECT soft.software_name,S.studentName,R.totalQuestion,R.correctAnswer,R.wrongAnswer,R.mark,R.dateIns ";
            //_qry += " FROM Exam_Results R INNER JOIN Exam_softwareDetails soft ON soft.softwareId=R.courseId";
            //_qry += " INNER JOIN Exam_StudentDetails S ON S.studentId=R.studentId Where R.studentId=@studentId AND R.courseId=@courseId Order By R.resultId Desc Limit 1 ";

            _qry = "SELECT CASE when D.Certificate_Id=0 then soft.software_name else (select course_name from Exam_coursedetail where course_Id=D.Certificate_Id)End as software,";
           _qry += "D.totalQuestion,D.correctAnswer,D.wrongAnswer,D.mark,D.dateIns from Exam_Results D left join Exam_softwareDetails soft ";
           _qry += " on soft.softwareId=D.software_Id Where D.studentId=@studentId and  and ifNull(delStatus,0)=0";
           HttpContext.Current.Response.Write(_qry);
           HttpContext.Current.Response.End();
            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;

            Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
            Comm.Parameters.Add("@courseId", MySqlDbType.Int32).Value = courseId;

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count>0)
                {
                    _retInt = 1;

                    lblModule.Text = SiteFunctions.databaseget(dt.Rows[0]["software"].ToString());
                    lblTotalQuestion.Text = SiteFunctions.databaseget(dt.Rows[0]["totalQuestion"].ToString());
                    lblCorrectAnswer.Text = SiteFunctions.databaseget(dt.Rows[0]["correctAnswer"].ToString());
                    lblWrongAnswer.Text = SiteFunctions.databaseget(dt.Rows[0]["wrongAnswer"].ToString());
                    lblMark.Text = SiteFunctions.databaseget(dt.Rows[0]["mark"].ToString()) + "/100";
                    lblDate.Text = DateTime.Parse(SiteFunctions.databaseget(dt.Rows[0]["dateIns"].ToString())).ToString("dd/MM/yyyy");
                }
                else
                {
                    _retInt = 0;
                }
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, Comm);
            }

            return _retInt;
        }
        #endregion

    }
}