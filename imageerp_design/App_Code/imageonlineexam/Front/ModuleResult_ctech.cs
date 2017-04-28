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
/// Summary description for ModuleResult
/// </summary>
namespace MVC1
{
    public class ModuleResult_ctech
    {
        private int _retInt;
        private string _qry;

        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        public ModuleResult_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        #region Getting Module Result Information
        public int SetInformation(int studentId, int courseId, Label lblstudentName,Label lblModule, Label lblTotalQuestion, Label lblCorrectAnswer, Label lblWrongAnswer, Label lblMark, Label lblDate)
        {
            _retInt = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            DataTable dt;
            MySqlCommand Comm = new MySqlCommand();

            if (HttpContext.Current.Session["RefCourse"].ToString() == "C")
            {
                _qry = " SELECT C.course_name as c_name,S.studentName,R.totalQuestion,R.correctAnswer,R.wrongAnswer,R.mark,R.dateIns ";
                _qry += " FROM Exam_Results R INNER JOIN Exam_Certificate ED on R.Certificate_Id=ED.course_id Inner join ";
                _qry += " Exam_coursedetail C on C.course_Id=ED.Course_Id INNER JOIN Exam_StudentDetails S ON S.studentId=R.studentId";
                _qry += " Where R.studentId=" + HttpContext.Current.Session["StudentId"] + " AND R.Certificate_Id=" + HttpContext.Current.Session["CourseId"] + " Order By R.resultId Desc Limit 1";
              
            
            }
            if (HttpContext.Current.Session["RefCourse"].ToString() == "S")
            {
                 _qry = "SELECT C.software_name as c_name,S.studentName,R.totalQuestion,R.correctAnswer,";
                 _qry += " R.wrongAnswer,R.mark,R.dateIns FROM Exam_Results R INNER JOIN Exam_Diploma ED ";
                 _qry += " on R.Software_Id=ED.SoftwareId INNER JOIN Exam_softwareDetails C on C.softwareId=ED.SoftwareId";
                 _qry += " inner join Exam_StudentDetails S ON S.studentId=R.studentId Where R.studentId=" + HttpContext.Current.Session["StudentId"] + " ";
                 _qry += " AND R.Software_Id=" + HttpContext.Current.Session["CourseId"] + " Order By R.resultId Desc Limit 1";
            }

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

                    lblstudentName.Text = SiteFunctions.databaseget(dt.Rows[0]["studentName"].ToString());
                    lblModule.Text = SiteFunctions.databaseget(dt.Rows[0]["c_name"].ToString());
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