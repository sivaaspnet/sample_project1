using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Globalization;
/// <summary>
/// Summary description for UploadExcel
/// </summary>
namespace MVC1
{
    public class UploadExcel_ctech
    {
        private string excelPath; //Excel File Pathe.
        private string notePadPath; //Note Pad Path.
        private string connectionString; //Connection String For Excel File.
        private string retResult;
        private string tableName; //Sheet In Excel File.
        private string qry;
        private int retInt;

        public UploadExcel_ctech()
        {
            tableName = "Sheet1";
            notePadPath = HttpContext.Current.Server.MapPath("ExcelUpload/uploadstatus.txt");
            excelPath = HttpContext.Current.Server.MapPath("ExcelUpload/ExcelQuestion.xls");
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;HDR=YES'";
            retResult = "";
            retInt = 0;
        }

        #region Started For Uploading Excel
        public int ValidatingExcel()
        {
            int errorStatus = 0;
            DataTable dt = new DataTable();
            if (!isValidTable())
            {
                //CurrentStatus("Invalid table name on the excel sheet. Note :" + tableName + " is not found...");
                return 0;
            }

            if (!isValidColumn("Submodule,Question,Answerone,Answertwo,Answerthree,Answerfour,CorrectAnswer"))
            {
               // CurrentStatus("Invalid columns name on the excel sheet...");
                return 0;
            }

            //--Checking Module/Course Details*********Changed*******
            //dt = ExecuteDataTable(connectionString, "Select Course From [" + tableName + "$] Where Course<>''");
            //if (!isValidCourse(dt))
            //{
            //    return 0;
            //}
            //--

            //--Checking Submodule Details
            dt = ExecuteDataTable(connectionString, "Select Submodule From [" + tableName + "$] Where Submodule<>''");
            if (!isValidSubmodule(dt))
            {
                return 0;
            }
            //--

            //--Checking Module With Submodule Details
            //*********Changed***********
           // dt = ExecuteDataTable(connectionString, "Select Course,Submodule From [" + tableName + "$] Where Course<>'' AND Submodule<>'' ");
            //*********Changed***********
            dt = ExecuteDataTable(connectionString, "Select Submodule From [" + tableName + "$] Where  Submodule<>'' ");
            int totCount = dt.Rows.Count; //--Main Count
            //HttpContext.Current.Response.Write("totCount" + totCount.ToString() +"</br>");
            if (!isValidCourseSubModule(dt))
            {
                return 0;
            }
            //--

            //--Checking Question Is Given For All The Course Details And Submodule Details
            dt = ExecuteDataTable(connectionString, "Select Question From [" + tableName + "$] Where Question<>''");
           // HttpContext.Current.Response.Write("cur" + dt.Rows.Count.ToString() + "</br>");
            if (totCount != dt.Rows.Count)
            {
                CurrentStatus("Invalid Question On The Excel Sheet. Please Check The Question Is Given For All The Course And Submodule In The Excel Sheet");
                return 0;
            } 
            //--

            //--Checking The Given Answer Is Right Or Not
            //dt = ExecuteDataTable(connectionString, "Select * From [" + tableName + "$] Where Answer1<>'' AND Answer2<>'' AND Answer3<>'' AND Answer4<>''");
            ////HttpContext.Current.Response.Write("cur" + dt.Rows.Count.ToString() + "</br>");
            //if (totCount != dt.Rows.Count)
            //{
            //    CurrentStatus("Invalid Answers On The Excel Sheet. Please Check All The Four Answers Is Given For All The Questions In The Excel Sheet");
            //    return 0;
            //}
            //--

            //--Checking The Correct Ansser Is Given OR Not
            dt = ExecuteDataTable(connectionString, "Select CorrectAnswer From [" + tableName + "$] Where Question<>''  ");//where CorrectAnswer<>''
            //HttpContext.Current.Response.Write("cur" + dt.Rows.Count.ToString() + "</br>");
            if (totCount != dt.Rows.Count)
            {
                CurrentStatus("Invalid Correct Answer On The Excel Sheet. Please Check The CorrectAnswer Is Given For All The Questions In The Excel Sheet");
                return 0;
            }
            else if (!isValidCorrectAnswer(dt))
            {
                //CurrentStatus("Invalid Correct Answer On The Excel Sheet. Please Check The CorrectAnswer For All The Questions In The Excel Sheet Is Given In Numeric And It Should Be Less Than 5");
                return 0;
            }
            //--

            dt = ExecuteDataTable(connectionString, "Select * From [" + tableName + "$] Where Submodule<>''");
            if (totCount != dt.Rows.Count)
            {
                CurrentStatus("Invalid Records In The Excel Sheet");
            } 
            retInt = UploadData(dt);
            if (retInt != 0)
                retInt = 2;
            else
                retInt = 1;
            return retInt;

        }

        public bool isValidTable()
        {
            CurrentStatus("Checking the table name from the excel sheet...");
            DataTable dt;
            dt = ExecuteDataTable(connectionString);
            foreach (DataRow Row in dt.Rows)
            {
                if (tableName.ToLower() + "$" == Row["table_name"].ToString().ToLower())
                {                    
                    CurrentStatus("Table name checked successfully on the excel sheet ...");
                    return true;
                }
            }
            CurrentStatus("Invalid table name on the excel sheet ...");
            return false;
        }

        public bool isValidColumn(string colsName)
        {
            CurrentStatus("Checking Valid Column Name In The Excel Sheet");
            DataTable dt;
            string columns = "";
            dt = ExecuteDataTable(connectionString, "select * from [" + tableName + "$]");
            int j = 0;

             //HttpContext.Current.Response.Write(colsName +"</BR>");
            for (j = 0; j < dt.Columns.Count; j++)
            {
                if (columns == "")
                {
                    columns = dt.Columns[j].ColumnName;
                }
                else
                {
                    columns = columns + "," + dt.Columns[j].ColumnName;
                }
                
            }

           //HttpContext.Current.Response.Write(columns + "</BR>");

           if (columns.Trim().ToLower() == colsName.Trim().ToLower())
           {
               CurrentStatus("Columns name checked successfully on the excel sheet ...");
               return true;
           }
           else
           {
               CurrentStatus("Invalid columns name on the excel sheet ...<br> Columns in excel is: " + columns.Trim().ToLower() + " <br> Correct columns are : " + colsName.Trim());
               return false;
           }

            return false;
        }

        public bool isValidCourse(DataTable dt)
        {
            int i = 0;
            int courseCount = 0;
            CurrentStatus("Checking Course Details..");
            //*********Changed********
            //foreach (DataRow Row in dt.Rows)
            //{
            //    retInt = 0;
            //    qry = "Select Count(courseId) From Exam_CourseDetails Where courseName='" + SiteFunctions.databaseset(Row[0].ToString().Trim()) + "'";
            //    retInt = Mysqlconn.ExecuteMysqlScalar(qry);
            //    if (retInt <= 0)
            //    {
            //        CurrentStatus("Invalid Course Name In The Excel Sheet. Note : " + Row[0].ToString().Trim() + " On " + (i + 1) + " Row In The Excel Sheet");
            //        return false;
            //    }

            //    i += 1;
            //}
            //*********Changed********
            CurrentStatus("Course Details Checked Successfully On The Excel Sheet..");
            return true;
        }

        public bool isValidSubmodule(DataTable dt)
        {
            int i = 0;
            int courseCount = 0;
            CurrentStatus("Checking Submodule Details..");
            foreach (DataRow Row in dt.Rows)
            {
                retInt = 0;
                qry = "Select Count(softwareId) From Exam_softwareDetails Where software_name='" + SiteFunctions.databaseset(Row[0].ToString().Trim()) + "'";
                retInt = Mysqlconn_ctech.ExecuteMysqlScalar(qry);
                if (retInt <= 0)
                {
                    CurrentStatus("Invalid Submodule Name In The Excel Sheet. Note : " + Row[0].ToString().Trim() + " On " + (i + 1) + " Row In The Excel Sheet");
                    return false;
                }

                i += 1;
            }
            CurrentStatus("Submodule Details Checked Successfully..");
            return true;
        }

        public bool isValidCourseSubModule(DataTable dt)
        {
            int i = 0;
            int courseCount = 0;
            CurrentStatus("Checking Course And Submodule Details..");
            //*********Changed********
            //foreach (DataRow Row in dt.Rows)
            //{
            //    retInt = 0;
            //    qry = "Select Count(S.subModuleId) From Exam_SubModuleDetails S INNER JOIN Exam_CourseDetails C ON S.courseId=C.courseId ";
            //    qry += " Where C.courseName='" + SiteFunctions.databaseset(Row[0].ToString().Trim()) + "' AND S.subModuleName='" + SiteFunctions.databaseset(Row[1].ToString().Trim()) + "' ";
            //    retInt = Mysqlconn.ExecuteMysqlScalar(qry);
            //    if (retInt <= 0)
            //    {
            //        CurrentStatus("Invalid Course Match With Submodule Name In The Excel Sheet. Note : " + Row[0].ToString().Trim() + " Doesnot Match With " + Row[1].ToString().Trim() + " On " + (i + 1) + " Row In The Excel Sheet");
            //        return false;
            //    }

            //    i += 1;
            //}
            //*********Changed********
            CurrentStatus("Course And Submodule Details Checked Successfully..");
            return true;
        }

        public bool isValidCorrectAnswer(DataTable dt)
        {
            int i = 0;
            int courseCount = 0;
            CurrentStatus("Checking Correct Answer Is Given Or Not..");
            foreach (DataRow Row in dt.Rows)
            {
                if (Row[0].ToString().Trim() != "")
                {

                    CommonFunction commonFunction = new CommonFunction();
                    courseCount = commonFunction.isNumeric(Row[0].ToString().Trim());
                    if (courseCount <= 0 || courseCount > 4)
                    {
                        //HttpContext.Current.Response.Write(courseCount.ToString());

                        CurrentStatus("Invalid Correct Answer Is Given For The Question On " + (i + 1) + " Row In The Excel Sheet");
                        return false;
                    }
                    i += 1;
                }

            }
            CurrentStatus("Correct Answer Checked Successfully..");
            return true;
        }

        public int UploadData(DataTable dt)
        {
            CurrentStatus("Starting To Upload Datas To The DataBase From The Excel Sheet");
            int count = 0;
            int courseId, subModuleId = 0;
            int totalCount = dt.Rows.Count;
            try
            {
                foreach (DataRow Row in dt.Rows)
                {
                    //courseId = Mysqlconn.ExecuteMysqlScalar("select courseId From Exam_CourseDetails Where courseName ='" + SiteFunctions.databaseset(Row["Course"].ToString().Trim()) + "'");
                    subModuleId = Mysqlconn_ctech.ExecuteMysqlScalar("select softwareId From Exam_softwareDetails Where software_name ='" + SiteFunctions.databaseset(Row["Submodule"].ToString().Trim()) + "'");
                    qry = "Insert Into Exam_QuestionAnswerDetails (subModuleId,question,answer1,answer2,answer3,answer4,correctAnswer,status,fromExcel,dateIns,dateMod) Values ( ";
                    //qry += " " + courseId + ", ";
                    qry += " " + subModuleId + ", ";
                    //qry += " '" + Row[1].ToString().Trim() + "', ";
                    //qry += " '" + Row[2].ToString().Trim() + "', ";
                    //qry += " '" + Row[3].ToString().Trim() + "', ";
                    //qry += " '" + Row[4].ToString().Trim() + "', ";
                    //qry += " '" + Row[5].ToString().Trim() + "', ";
                    //qry += " '" + Row[6].ToString().Trim() + "',1,1,current_date,current_date) ";

                    qry += " '" + SiteFunctions.databaseset(Row["Question"].ToString().Trim()) + "', ";
                    qry += " '" + SiteFunctions.databaseset(Row["answerone"].ToString().Trim()) + "', ";
                    qry += " '" + SiteFunctions.databaseset(Row["answertwo"].ToString().Trim()) + "', ";
                    qry += " '" + SiteFunctions.databaseset(Row["answerthree"].ToString().Trim()) + "', ";
                    qry += " '" + SiteFunctions.databaseset(Row["answerfour"].ToString().Trim()) + "', ";
                    qry += " '" + SiteFunctions.databaseset(Row["CorrectAnswer"].ToString().Trim()) + "',1,1,current_date,current_date) ";
                    //HttpContext.Current.Response.Write(qry + "<br>");
                    Mysqlconn_ctech.ExecuteMySqlCommand(qry);
                    count += 1;
                }

            }
            catch(Exception ex)
            {
                count = 0;
                //SiteFunctions.Log(ex);
            }

            CurrentStatus("Upload completed : " + count + " of " + totalCount + " Records ...");

            return count;
        }

        #endregion

        #region Writing Current Status Of The File Upload
        public void CurrentStatus(string curStatus)
        {
            System.IO.TextWriter textWriter = new System.IO.StreamWriter(notePadPath);
            textWriter.WriteLine(curStatus);
            textWriter.Close();
        }
        #endregion

        #region Reading Current Status Of The File Upload
        public string ReadCurrentStatus()
        {
            System.IO.TextReader textReader = new System.IO.StreamReader(notePadPath);
            retResult = textReader.ReadLine();
            textReader.Close();
            return retResult;
        }
        #endregion

        //--Objects

        #region Execute DataTable With Schema GUID
        public DataTable ExecuteDataTable(string Connection)
        {
            DataTable dt = new DataTable();
            OleDbConnection Conn = new OleDbConnection(Connection);
            Conn.Open();
            try
            {
                dt = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Conn.Close();
            }
            return dt;
        }
        #endregion

        #region Execute DataTable And Return The Datatable
        public DataTable ExecuteDataTable(string Connection, string excelQry)
        {
            DataTable dt = new DataTable();
            OleDbConnection Conn = new OleDbConnection(Connection);
            Conn.Open();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(excelQry, Conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Conn.Close();
            }
            return dt;
        }
        #endregion


    }
}
