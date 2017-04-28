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
/// Summary description for StudentLogin
/// </summary>
namespace MVC1
{

    public class StudentLogin_ctech
    {
        private string _qry,getquery1;
        private int _retInt;
        private int sno = 0;


        public int len123, varcou_Id;
        public string varsubid, vartotcount;
        public string varsubid1, varsubid2, var1, var2;
      

        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;


        public StudentLogin_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        public struct TimeLimit
        {
            public string hour;
            public string min;
        }
     
         public int AddHour
         {
             get
             {
                 return 9;
             }
         }

        public int AddMin
        {
            get
            {
                return 30;
            }
        }

        public string DisplayDate
        {
            get
            {
                return DateTime.Now.AddHours(AddHour).AddMinutes(AddMin).ToString("dd/MM/yyyy");
            }
        }

        public string CurrentDateTimer
        {
            get
            {
                return DateTime.Now.AddHours(AddHour).AddMinutes(AddMin).ToString();
            }
        }


        public string CurrentDate
        {
            get
            {
              return DateTime.Now.AddHours(AddHour).AddMinutes(AddMin).ToShortDateString();
            }
        }


        public string CurrentTime
        {
            get
            {
                return DateTime.Now.AddHours(AddHour).AddMinutes(AddMin).ToShortTimeString();
            }
        }

        public string EndTime(string hour,string min)
        {
            return DateTime.Now.AddHours(AddHour + Convert.ToInt32(hour)).AddMinutes(AddMin + Convert.ToInt32(min)).ToShortTimeString(); 
        }


        #region Genrating Javascript For Showing Hours and Minutes 
        public string GenerateJavascript()
        {
            string js = "";

            MySqlCommand cmd = new MySqlCommand();
            DataTable dt;

            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            cmd.Connection = mySqlConn;
            cmd.CommandText = "SELECT courseId,hour,min From Exam_CourseDetails Where status=1";

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    int i;
                    js = "<script language='javascript' type='text/javascript'>\n";
                    js += "var hourDetail=new Array();\n";

                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        js += "hourDetail[" + dt.Rows[i]["courseId"].ToString() + "]=new Array();\n";
                        js += "hourDetail[" + dt.Rows[i]["courseId"].ToString() + "]['HOUR']=" + dt.Rows[i]["hour"].ToString() + "\n";
                        js += "hourDetail[" + dt.Rows[i]["courseId"].ToString() + "]['MIN']=" + dt.Rows[i]["min"].ToString() + "\n";
                    }
                    js += "</script>";
                }

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, cmd);
            }

            return js;
        }
        #endregion

        #region Checking Whether The Student Is Valid Or Not
        public int CheckStudentInfo(string studentName,string regNumber,int centreId)
        {

            _retInt = 0;

            MySqlCommand Comm = new MySqlCommand();

            DataTable dt;

            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            Comm.Connection = mySqlConn;

            Comm.CommandText = "SELECT studentId From Exam_StudentDetails Where studentName=@studentName And studentRegNo=@regNumber And centreId=@centreId ";

          
            Comm.Parameters.Add("@studentName", MySqlDbType.VarChar, 30);
            Comm.Parameters["@studentName"].Value = @studentName.Trim();

            Comm.Parameters.Add("@regNumber", MySqlDbType.VarChar, 30);
            Comm.Parameters["@regNumber"].Value = @regNumber.Trim();

            Comm.Parameters.Add("@centreId", MySqlDbType.Int32);
            Comm.Parameters["@centreId"].Value = centreId;

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count > 0)
                {
                    _retInt = Convert.ToInt32(dt.Rows[0]["studentId"].ToString());
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

        #region Getting Total Questions From Admin For Selected Course
        public int GetTotalQuestion(int courseId,string refWhere,int subMod)
        {
            _retInt = 0;
            MySqlCommand Comm = new MySqlCommand();
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

         
            if (refWhere == "Sub")
            {
                Comm.CommandText = "select SUM(No_of_questions)as totalsubQuestion from Exam_Certificate where courseid=@courseId";
            }
            if (refWhere == "C")
            {
                Comm.CommandText = "Select ifNull(totalQuestion,0)as CNT From Exam_CourseDetails Where courseId=@courseId"; 
            }
            if (refWhere == "Q")
            {
               
                Comm.CommandText = "Select Count(questionId)as CNT From Exam_QuestionAnswerDetails Where submoduleId="+subMod+" and answer1<>'' And answer2<>'' And answer3<>'' And answer4<>'' ";
            }
            Comm.Connection = mySqlConn;

            Comm.Parameters.Add("@courseId", MySqlDbType.Int32);
            Comm.Parameters["@courseId"].Value = courseId;

            try
            {
                _retInt = Mysqlconn_ctech.ExecuteMysqlScalar(Comm);
            }
            catch(Exception ex)
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

        #region toget the info for submoduleid and totalcountofquestions in each
        public string infogetit(int courseid,string Refwhere,string DipId)
        {
            if (Refwhere == "C")
            {
                varcou_Id = courseid;
                _qry = "select SoftwareId,No_of_questions from Exam_Certificate where course_id=" + courseid + "";

                DataTable dt11 = new DataTable();
                dt11 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);
                if (dt11.Rows.Count > 0)
                {
                    varsubid = "";
                    vartotcount = "";
                    varsubid1 = "";
                    for (int i = 0; i < dt11.Rows.Count; i++)
                    {
                        varsubid = dt11.Rows[i]["SoftwareId"].ToString();
                        vartotcount = dt11.Rows[i]["No_of_questions"].ToString();

                        if (varsubid != "" && vartotcount != "")
                        {
                            varsubid1 = varsubid1 + "|" + varsubid + "@" + vartotcount;
                        }

                    }

                    varsubid2 = varsubid1.Remove(0, 1);
                    len123 = Convert.ToInt32(varsubid2.Length);

                    
                }
               
            }
            return splitofsubarray(varsubid2);
        }
        #endregion
        
        #region toget the info for submoduleid and totalcountofquestions in each software alone
        public string infogetitsoftware(int courseid, string Refwhere, string DipId)
        {
            if (Refwhere == "S")
            {
                varcou_Id = courseid;
                _qry = "select SoftwareId,No_of_questions from Exam_Diploma where SoftwareId=" + courseid + " and Course_Id="+DipId+"";
                //HttpContext.Current.Response.Write(_qry);
                //HttpContext.Current.Response.End();
                DataTable dt11 = new DataTable();
                dt11 = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);
                if (dt11.Rows.Count > 0)
                {
                    varsubid = "";
                    vartotcount = "";
                    varsubid1 = "";
                    for (int i = 0; i < dt11.Rows.Count; i++)
                    {
                        varsubid = dt11.Rows[i]["SoftwareId"].ToString();
                        vartotcount = dt11.Rows[i]["No_of_questions"].ToString();

                        if (varsubid != "" && vartotcount != "")
                        {
                            varsubid1 = varsubid1 + "|" + varsubid + "@" + vartotcount;
                        }

                    }

                    varsubid2 = varsubid1.Remove(0, 1);
                    len123 = Convert.ToInt32(varsubid2.Length);


                }
                
            }
            return splitofsubarraysoftware(varsubid2);
        }
         #endregion

        #region Spliiting of the array formed for Certificate
        public string splitofsubarray(string varsub)
        {
             string[] strSplitArr1=new string[20];
             string[] strsplit=new string[2];
            //varsubid2="48@10|49@10|50@10|51@10" ;
            strSplitArr1 = varsub.Split('|');
           
            int len = strSplitArr1.Length;
            var1 = "";
            var2 = "";
            _qry = "";
            for (int i = 0; i < len; i++)
            {
                strsplit = strSplitArr1[i].Split('@');

                var1 = strsplit[0];//SoftwareId
                var2 = strsplit[1];//TotalQuestions in each Software
                if (_qry == "")
                {
                   
                    _qry = "Select * FROM (Select Q.questionId,Q.correctAnswer From Exam_QuestionAnswerDetails Q INNER JOIN Exam_Certificate S on Q.subModuleId=S.softwareId where Q.status=1 AND S.course_Id='" + varcou_Id + "' and Q.subModuleId='" + var1 + "' and Q.answer1<>'' And Q.answer2<>'' And Q.answer3<>'' And Q.answer4<>'' Order By RAND() LIMIT " + var2 + ") as ss" + i.ToString();
                    
                }
                else
                {

                    _qry += "  UNION ALL  Select * FROM (Select Q.questionId,Q.correctAnswer From Exam_QuestionAnswerDetails Q  INNER JOIN Exam_Certificate S on Q.subModuleId=S.softwareId where Q.status=1 AND S.course_Id='" + varcou_Id + "' and Q.subModuleId='" + var1 + "' and Q.answer1<>'' And Q.answer2<>'' And Q.answer3<>'' And Q.answer4<>'' Order By RAND() LIMIT " + var2 + ") as ss" + i.ToString();
                    
                }

            }
            //HttpContext.Current.Response.Write(_qry);
            //HttpContext.Current.Response.End();
            return _qry;


        }
        #endregion

        #region Spliiting of the array formed for Software
        public string splitofsubarraysoftware(string varsub)
        {
            string[] strSplitArr1 = new string[20];
            string[] strsplit = new string[2];
            //varsubid2="48@10|49@10|50@10|51@10" ;
            strSplitArr1 = varsub.Split('|');

            int len = strSplitArr1.Length;
            var1 = "";
            var2 = "";
            _qry = "";
            for (int i = 0; i < len; i++)
            {
                strsplit = strSplitArr1[i].Split('@');

                var1 = strsplit[0];//SoftwareId
                var2 = strsplit[1];//TotalQuestions in each Software
                if (_qry == "")
                {

                    _qry = "Select * FROM (Select Q.questionId,Q.correctAnswer From Exam_QuestionAnswerDetails Q INNER JOIN Exam_Diploma D on Q.subModuleId=D.SoftwareId where Q.status=1 AND D.Course_Id=" + HttpContext.Current.Session["Dip_CourseId"] + " and Q.subModuleId='" + var1 + "' and Q.answer1<>'' And Q.answer2<>'' And Q.answer3<>'' And Q.answer4<>'' Order By RAND() LIMIT " + var2 + ") as ss" + i.ToString();

                }
                else
                {

                    _qry += "  UNION ALL  Select * FROM (Select Q.questionId,Q.correctAnswer From Exam_QuestionAnswerDetails Q  INNER JOIN Exam_Diploma D  on Q.subModuleId=D.SoftwareId where Q.status=1 AND D.Course_Id=" + HttpContext.Current.Session["Dip_CourseId"] + " and Q.subModuleId='" + var1 + "' and Q.answer1<>'' And Q.answer2<>'' And Q.answer3<>'' And Q.answer4<>'' Order By RAND() LIMIT " + var2 + ") as ss" + i.ToString();

                }

            }
           //HttpContext.Current.Response.Write(_qry);
           //HttpContext.Current.Response.End();
            return _qry;


        }
        #endregion

        #region Create Paging And Question In Hash Table
        public int CreatePaging(int totalQue,int courseId,string RefVar,string DipId)
        {
            
            sno = 0;
            DataTable dt;

            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            MySqlCommand Comm = new MySqlCommand();
         
            if (RefVar == "C")
            {
                Comm.CommandText = infogetit(courseId, RefVar, DipId);
                Comm.Connection = mySqlConn;

                try
                {

                    dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                    if (dt.Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            sno += 1;
                            ((Hashtable)HttpContext.Current.Session["Pagenum"]).Add(sno, sno);
                            ((Hashtable)HttpContext.Current.Session["PageTable"]).Add(sno, dt.Rows[i]["questionId"].ToString());
                            ((Hashtable)HttpContext.Current.Session["QueTable"]).Add(Convert.ToInt32(dt.Rows[i]["questionId"].ToString()), 0);
                            ((Hashtable)HttpContext.Current.Session["AnsTable"]).Add(Convert.ToInt32(dt.Rows[i]["questionId"].ToString()), Convert.ToInt32(dt.Rows[i]["correctAnswer"].ToString()));
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
                }
            }
            if (RefVar == "S")
            {
                Comm.CommandText = infogetitsoftware(courseId, RefVar, DipId);
                Comm.Connection = mySqlConn;

                try
                {

                    dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                    if (dt.Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            sno += 1;
                            ((Hashtable)HttpContext.Current.Session["Pagenum"]).Add(sno, sno);
                            ((Hashtable)HttpContext.Current.Session["PageTable"]).Add(sno, dt.Rows[i]["questionId"].ToString());
                            ((Hashtable)HttpContext.Current.Session["QueTable"]).Add(Convert.ToInt32(dt.Rows[i]["questionId"].ToString()), 0);
                            ((Hashtable)HttpContext.Current.Session["AnsTable"]).Add(Convert.ToInt32(dt.Rows[i]["questionId"].ToString()), Convert.ToInt32(dt.Rows[i]["correctAnswer"].ToString()));
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
                }
            }
           
           
            //HttpContext.Current.Response.Write("sno" + sno);
            return sno;

        }
        #endregion

        #region Getting Time Limit For Selected Module
        public TimeLimit GetTimeLimit(int courseId)
        {
            TimeLimit timeLimit = new TimeLimit();

            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            MySqlCommand Comm = new MySqlCommand();
            Comm.CommandText = "Select hour,min From Exam_CourseDetails Where courseId=@courseId";
            Comm.Connection = mySqlConn;
            Comm.Parameters.Add("@courseId", MySqlDbType.Int32).Value = courseId;
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count>0)
                {
                    
                    timeLimit.hour = dt.Rows[0]["hour"].ToString();
                    timeLimit.min = dt.Rows[0]["min"].ToString();
                }
                else
                {
                    timeLimit.hour = "0";
                    timeLimit.min = "0";
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

            return timeLimit;
        }
        #endregion
        #region Getting student id
        public int getstudentid(string studentName, string regNumber, int centreId,int course_type,string  course_id)
        {

            _retInt = 0;

            MySqlCommand Comm = new MySqlCommand();

            DataTable dt;

            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            Comm.Connection = mySqlConn;
            string query = "SELECT studentId From Exam_StudentDetails Where studentName=@studentName And studentRegNo=@regNumber And centreId=@centreId ";
            if (course_type == 1)
                query += "And Course_diploma=@course_id";
            else if(course_type==2)
                query += "And Course_certificate=@course_id";
            Comm.CommandText = query;


            Comm.Parameters.Add("@studentName", MySqlDbType.VarChar, 30);
            Comm.Parameters["@studentName"].Value = studentName;

            Comm.Parameters.Add("@regNumber", MySqlDbType.VarChar, 30);
            Comm.Parameters["@regNumber"].Value = regNumber;

            Comm.Parameters.Add("@centreId", MySqlDbType.Int32);
            Comm.Parameters["@centreId"].Value = centreId;

            Comm.Parameters.Add("@course_id", MySqlDbType.Int32);
            Comm.Parameters["@course_id"].Value = course_id;

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count > 0)
                {
                    _retInt = Convert.ToInt32(dt.Rows[0]["studentId"].ToString());
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
        #region Getting course type
        public int getcoursetype(string courseid)
        {

            _retInt = 0;

            MySqlCommand Comm = new MySqlCommand();

            DataTable dt;

            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            Comm.Connection = mySqlConn;

            Comm.CommandText = "SELECT Exam_id From exam_coursedetail Where  Course_id='"+@courseid+"' ";           

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                if (dt.Rows.Count > 0)
                {
                    _retInt = Convert.ToInt32(dt.Rows[0]["Exam_id"].ToString());
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
