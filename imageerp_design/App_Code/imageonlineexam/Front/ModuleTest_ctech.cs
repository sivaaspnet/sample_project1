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
using System.Collections;


/// <summary>
/// Summary description for ModuleTest
/// </summary>
namespace MVC1
{
    public class ModuleTest_ctech
    {
        public int page_question;
        private string _qry;
        private int _retInt;
        private int questionId;
        private int correctAns;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        public ModuleTest_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);

           
        }

        public struct QuestionInfo
        {
            public int questionId;
            public string questionName;
            public string answer1;
            public string answer2;
            public string answer3;
            public string answer4;
            public int correctAnswer;

            public string headerText;
        }

        #region Get Question By Passing Page No
        public int GetQuestionId(int pageNo)
        {
         
            _retInt = 0;
            _retInt = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["PageTable"])[pageNo]);
           
            return _retInt;
        }
        #endregion

        #region Get Selected Answer By Passing Question Id
        public int GetSelectedAnswer(int questionId)
        {
            _retInt = 0;
            _retInt = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["QueTable"])[questionId]);
           
            return _retInt;
        }
        #endregion

        #region Passing Question Info In Structure
      
        public QuestionInfo GetQuestionInfo(int pageNo)
        {
            questionId = 0;
            correctAns = 0;
            questionId = GetQuestionId(pageNo);
            //page_question = pageNo;
            //HttpContext.Current.Response.Write(pageNo + "First " + questionId);
            //HttpContext.Current.Response.End();
            correctAns = GetSelectedAnswer(questionId);
         //HttpContext.Current.Response.Write("First " + correctAns.ToString());
          
            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();

            if (HttpContext.Current.Session["RefCourse"].ToString() == "C")
            {
          
                _qry = "Select Q.*,C.course_Name,S.software_name From Exam_QuestionAnswerDetails Q ";
                _qry += " Inner Join Exam_softwareDetails S On Q.subModuleId=S.softwareId inner join ";
                _qry += " Exam_Certificate EC  on EC.SoftwareId=S.softwareId inner join Exam_coursedetail C on C.course_Id=EC.course_Id ";
                _qry += " Where Q.questionId="+questionId+" ";
            
            }
            if (HttpContext.Current.Session["RefCourse"].ToString() == "S")
            {

                //_qry = "Select Q.*,C.course_Name,S.software_name From Exam_QuestionAnswerDetails Q ";
                //_qry += " Inner Join Exam_softwareDetails S On Q.subModuleId=S.softwareId inner join ";
                //_qry += " Exam_Diploma ED on ED.SoftwareId=S.softwareId inner join Exam_coursedetail C on C.course_Id=ED.course_Id ";
                //_qry += " Where Q.questionId=" + questionId + " ";

                _qry = "Select *,(select course_name from Exam_coursedetail where course_Id=" + HttpContext.Current.Session["Dip_CourseId"] + ") as course_Name,";
                _qry +="(select software_name from Exam_softwareDetails where softwareId=" + HttpContext.Current.Session["CourseId"] + ") as software_name From Exam_QuestionAnswerDetails ";
                _qry += " Where questionId=" + questionId + "";
                //HttpContext.Current.Response.Write(_qry);
                //HttpContext.Current.Response.End();
 
            }
            Comm.CommandText = _qry;
            
            Comm.Connection = mySqlConn;

            Comm.Parameters.Add("@questionId", MySqlDbType.Int32).Value = questionId;
        
            QuestionInfo info = new QuestionInfo();

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count>0)
                {
                    info.questionId = questionId;
                    info.questionName =SiteFunctions.databaseget(dt.Rows[0]["question"].ToString());
                    info.answer1 = SiteFunctions.databaseget(dt.Rows[0]["answer1"].ToString());
                    info.answer2 = SiteFunctions.databaseget(dt.Rows[0]["answer2"].ToString());
                    info.answer3 = SiteFunctions.databaseget(dt.Rows[0]["answer3"].ToString());
                    info.answer4 = SiteFunctions.databaseget(dt.Rows[0]["answer4"].ToString());

                    info.correctAnswer = correctAns;
                    info.headerText =SiteFunctions.databaseget(dt.Rows[0]["software_name"].ToString());
                }
            }
            catch(Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn,Comm);
            }

            return info;
        }
        #endregion

        #region Finish The Exam
        public int FinishExam(int studentId,int Module_Id,int totalQuestion)
        {
            _retInt = 0;
            int i;
            int questionId;
            int correctAnswer;
            int givenAnswer;

            int totalCorrectAnswer = 0;
            int totalWrongAnswer = 0;
            int mark = 0;
            decimal totalMark;

            for (i = 1; i <= totalQuestion; i++)
            {
                page_question = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["pagenum"])[i]);
                questionId = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["PageTable"])[i].ToString());
                givenAnswer = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["QueTable"])[questionId].ToString());
                correctAnswer = Convert.ToInt32(((Hashtable)HttpContext.Current.Session["AnsTable"])[questionId].ToString());

                if (correctAnswer == givenAnswer)
                {
                    totalCorrectAnswer += 1;
                }
                else
                {
                    totalWrongAnswer += 1;
                }
            }
            //HttpContext.Current.Response.End();
            totalMark = (Convert.ToDecimal(totalCorrectAnswer) / Convert.ToDecimal(totalQuestion)) * 100;
            //HttpContext.Current.Response.Write("totalCorrectAnswer " + totalCorrectAnswer.ToString() + "</BR>");
            //HttpContext.Current.Response.Write("totalWrongAnswer " + totalWrongAnswer.ToString() + "</BR>");
            //HttpContext.Current.Response.Write("totalMark " + totalMark.ToString() +"</BR>");
            mark = Convert.ToInt32(System.Math.Ceiling(totalMark));
            //HttpContext.Current.Response.Write("mark " + totalMark);
            _retInt = InsertValues(studentId, Module_Id, totalQuestion, totalCorrectAnswer, totalWrongAnswer, mark);
            return _retInt;
            
        }
        #endregion

        #region Inserting Values Into The Result Table
        public int InsertValues(int studentId, int Module_Id, int totalQuestion, int correctAnswer, int wrongAnswer, int mark)
        {
            //HttpContext.Current.Response.Write(HttpContext.Current.Session["RefCourse"]);
            //HttpContext.Current.Response.End();
            _retInt = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            MySqlCommand Comm = new MySqlCommand();
            MySqlCommand UpdStatusComm = new MySqlCommand();

            if (HttpContext.Current.Session["RefCourse"] == "C")
            {
                _qry = "Insert Into Exam_Results(studentId,Certificate_Id,Software_Id,totalQuestion,correctAnswer,wrongAnswer,mark,status,delStatus,delDate,dateIns) Values ";
                _qry += " (@studentId,@Module_Id,0,@totalQuestion,@correctAnswer,@wrongAnswer,@mark,1,0,@curDate,@curDate) ";

            }
            if (HttpContext.Current.Session["RefCourse"] == "S")
            {
                _qry = "Insert Into Exam_Results(studentId,Certificate_Id,Software_Id,totalQuestion,correctAnswer,wrongAnswer,mark,status,delStatus,delDate,dateIns) Values ";
                _qry += " (@studentId,0,@Module_Id,@totalQuestion,@correctAnswer,@wrongAnswer,@mark,1,0,@curDate,@curDate) ";

            }
            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;

            Comm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
            Comm.Parameters.Add("@Module_Id", MySqlDbType.Int32).Value = Module_Id;
            Comm.Parameters.Add("@totalQuestion", MySqlDbType.Int32).Value = totalQuestion;
            Comm.Parameters.Add("@correctAnswer", MySqlDbType.Int32).Value = correctAnswer;
            Comm.Parameters.Add("@wrongAnswer", MySqlDbType.Int32).Value = wrongAnswer;
            Comm.Parameters.Add("@mark", MySqlDbType.Int32).Value = mark;
            Comm.Parameters.Add("@curDate", MySqlDbType.Date).Value = DateTime.Parse(HttpContext.Current.Session["StartDate"].ToString()).ToString("yyyy/MM/dd");

            try
            {
                _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(Comm);

                

                if (_retInt > 0)
                {
                    //HttpContext.Current.Response.Write("Test:" + HttpContext.Current.Session["RefCourse"]);
                    
                    Mysqlconn_ctech.disposeConnection(mySqlConn);
                    mySqlConn.Open();
                    if (HttpContext.Current.Session["RefCourse"] == "C")
                    {
                        _qry = "Update Exam_StudentCourseDetails Set status=3 Where studentId=@studentId And Certificate_Id=@Module_Id";
                        _qry = "Update Exam_StudentCourseDetails Set status=3 Where studentId='"+studentId+"' And Certificate_Id='"+Module_Id+"'";
                        HttpContext.Current.Response.Write("Test:" + _qry);
                    }
                    if (HttpContext.Current.Session["RefCourse"] == "S")
                    {
                        _qry = "Update Exam_StudentCourseDetails Set status=3 Where studentId=@studentId And SoftwareId=@Module_Id";
                    }
                 
                    UpdStatusComm.CommandText = _qry;
                    UpdStatusComm.Connection = mySqlConn;

                    UpdStatusComm.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;
                    UpdStatusComm.Parameters.Add("@Module_Id", MySqlDbType.Int32).Value = Module_Id;

                    _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(UpdStatusComm);
                    //HttpContext.Current.Response.Write("Test:" + _retInt);
                    //HttpContext.Current.Response.End();
                }
            }
            catch(Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn,Comm);
                Mysqlconn_ctech.disposeCommand(UpdStatusComm);
            }
            return _retInt;

        }
        #endregion
    }
}


