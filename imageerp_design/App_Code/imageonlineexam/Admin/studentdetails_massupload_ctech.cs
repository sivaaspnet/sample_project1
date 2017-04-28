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
using MySql.Data.MySqlClient;
/// <summary>
/// Summary description for studentdetails_massupload
/// </summary>
/// 
namespace MVC1
{
    public class studentdetails_massupload_ctech
    {
        private string excelPath; //Excel File Pathe.
        private string notePadPath; //Note Pad Path.
        private string connectionString; //Connection String For Excel File.
        private string retResult;
        private string tableName; //Sheet In Excel File.
        private string qry;
        private int retInt;
        CultureInfo culture = new CultureInfo("ru-RU");
        //temp usage

        private GridView gv1;

        public GridView Gv1
        {
            set
            {
                gv1 = value;
            }
            get
            {
                return gv1;
            }
        }
        private Label lblMsg;
        public Label LblMsg
        {
            set
            {
                lblMsg = value;
            }

        }

        //used to get the data to insert process, It is loaded when validate the excel.
         DataTable _regNoDt=new DataTable();
         DataTable _centreDt=new DataTable();
         DataTable _courseDt=new DataTable();
         DataTable _softwaresDt=new DataTable();

         public studentdetails_massupload_ctech()
        {
            tableName = "IcatOnline";
            notePadPath = HttpContext.Current.Server.MapPath("ExcelUpload/studentdetails.txt");
            excelPath = HttpContext.Current.Server.MapPath("ExcelUpload/studentdetails.xls");

            //notePadPath = "ExcelUpload/studentdetails.txt";
            //excelPath = "ExcelUpload/studentdetails.xls";
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;HDR=YES;'";
            retResult = "";
            retInt = 0;


        }
        bool isVallidTable(string tplname,DataTable dt)
        {
            bool res = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["table_name"].ToString() == tplname + "$")
                {
                    res = true;
                    break;
                }
            }
            if (res == false)
            {
                CurrentStatus("Table name is invalid from the uploaded excel file.");
            }
            return res;
        }

        bool isValidColumns(string columnNames,DataTable dt)
        {
            bool res = true;
            int j;
            string columns = "";
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
            if (columnNames.ToLower() !=columns.ToLower().Trim())
            {
                res = false;
                CurrentStatus("Please check the columns name and order are correct as it on sample excel wich is given by the developer.");
            }

            return res;
        }
        bool isValidRegNos(DataTable dt)
        {
            bool res = false;
            res = isDuplicateData(dt);
            if (!res)
            {
                DataTable oldDt = new DataTable();
                oldDt = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable("select studentRegNo from Exam_StudentDetails order by studentRegNo");
                _regNoDt = oldDt;
                res=isDuplicateDataFromExistingColumn(oldDt, dt);
                if (!res)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }

                 
            }

            return res;

        }

        bool isDuplicateDataFromExistingColumn(DataTable oldDt,DataTable excelDt)
        {
             int i,j;
              bool res = false;
              for (i = 0; i < excelDt.Rows.Count; i++)
              {
                  for (j = 0; j < oldDt.Rows.Count; j++)
                  {
                      if (oldDt.Rows[j]["studentRegNo"].ToString().Trim().ToLower() == excelDt.Rows[i]["RegNo"].ToString().Trim().ToLower())
                      {
                          CurrentStatus(excelDt.Rows[i]["RegNo"].ToString().Trim().ToLower() + " is exists already,It is on the row " + (i + 1) + " ");
                          res = true;
                          break;
                          
                      }
                  }
              }

            return res;
        }

        bool  isDuplicateData(DataTable dt)
        {
              int i,j;
              bool res = false;
              for(i=0; i<dt.Rows.Count-1;i++)
              {
                  for (j = 0; j < dt.Rows.Count; j++)
                  {
                      if(i!=j)
                      if (dt.Rows[i]["RegNo"].ToString().Trim().ToLower() == dt.Rows[j]["RegNo"].ToString().Trim().ToLower())
                      {
                          CurrentStatus("RegNo column has duplicate values on the excel,Please check the rows " + (i+1) + " and " + (j + 1) + "");
                          res = true;
                          break; 
                      }
                  }
              }
              return res;
        }

        
        bool isValidDataformat(DataTable dt)
        {
            bool res = true;
            DateTime datetime = new DateTime();
            
          
            string excelDt = "";
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                 excelDt= dt.Rows[i]["DOJ"].ToString();
                
                 try
                 {
                     datetime = Convert.ToDateTime(excelDt, culture);
                     DateTime.TryParse(datetime.ToString("MM/dd/yyyy").ToString(),out datetime);
                     //DateTime.TryParse("12/12/2012",out datetime);
                 }
                 catch
                 {
                     CurrentStatus("Please check the DOJ Collumn Date format on the row "+(i+1));
                     res = false;
                     break;
                 }

            }
            return res;
        }
        bool isValidName(DataTable dt)
        {
              bool res = true;
              int i;
              for (i = 0; i < dt.Rows.Count; i++)
              {
                  if (dt.Rows[i]["Name"].ToString().Trim() == "")
                  {
                      CurrentStatus("Please check the Name Collumn on the row " + (i + 1));
                      res = false;
                  }
              }
              return res;

        }

        bool isValidCentreNames(DataTable dt)
        {
            bool res = true;
            string qry = "SELECT centreLocation,centreId FROM Exam_CentreDetails";
            DataTable centreDt = new DataTable();
            centreDt = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
            _centreDt = centreDt;
             int i;
             for (i = 0; i < dt.Rows.Count ; i++)
             {
                 DataRow[] dr = new DataRow[10];
                 dr = centreDt.Select("centreLocation='" + dt.Rows[i]["centre"].ToString() + "'");

                 //HttpContext.Current.Response.Write(dr.Length.ToString()+"_x<br>");
                 if (dr.Length == 0)
                 {
                     CurrentStatus(dt.Rows[i]["centre"].ToString() + " does not exists on the center details,Please check the center Collumn on the row " + (i + 1));
                     res = false;
                     break;
                 }
             }
            return res;
        }

        bool isValidCourseType(DataTable dt)
        {
            bool res = true;
             int i;
             for (i = 0; i < dt.Rows.Count; i++)
             {
                 if (dt.Rows[i]["courseType"].ToString() != "Diploma" && dt.Rows[i]["courseType"].ToString() != "Certificate")
                 {
                     CurrentStatus("Invalid course type on courseType column,courseType should be Diploma/Certificate,Please check the courseType Collumn on the row " + (i + 1));
                     res = false;
                     break;
                 }
             }
             return res;
        }



        bool isValidCourseName(DataTable dt)
        {
            bool res = true;
            string qry = "select Exam_id,Course_name,Course_id from Exam_coursedetail";
            DataTable centreDt = new DataTable();
            centreDt = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
            _courseDt = centreDt;
            string courseType="";
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["courseType"].ToString().Trim().ToLower() == "diploma")
                {
                    courseType = "1";
                }
                else if (dt.Rows[i]["courseType"].ToString().Trim().ToLower() == "certificate")
                {
                    courseType = "2";
                }
                DataRow[] dr = new DataRow[10];
                dr = centreDt.Select("Exam_id='" + courseType + "' and Course_name='" + dt.Rows[i]["courseName"].ToString() + "'");

                //HttpContext.Current.Response.Write(dr.Length.ToString()+"_x<br>");
                if (dr.Length == 0)
                {
                    CurrentStatus(dt.Rows[i]["courseName"].ToString() + " does not exists on the " + dt.Rows[i]["courseType"].ToString() + " course type ,Please check the courseName Collumn of the row " + (i + 1));
                    res = false;
                    break;
                }
            }
            return res;
        }

        bool isValidSoftwares(DataTable dt)
        {

            string qry = @"select  'C' as type,dip.Exam_Id,Certificate_Id,dip.softwareId,dip.course_id,course.course_name,module.course_name as module  from Exam_Diploma  as dip 

inner join Exam_coursedetail as course on course.Course_id=dip.course_id inner join Exam_coursedetail  as module on module.course_id=Certificate_Id 
union 
select  'S' as type,dip.Exam_Id,Certificate_Id,dip.softwareId,dip.course_id,course.course_name,module.software_name as module  from Exam_Diploma  as dip 

inner join Exam_coursedetail as course on course.Course_id=dip.course_id inner join Exam_softwareDetails  as module on dip.softwareId=module.softwareId 
union
SELECT 'C' as type,cert.Exam_Id,comb_CourseId,cert.softwareId,cert.course_id,course.course_name,module.course_name as module   FROM `Exam_Certificate` as 

cert inner join Exam_coursedetail as course on course.Course_id=cert.course_id inner join Exam_coursedetail  as module on module.course_id=comb_CourseId
union
SELECT 'S' as type,cert.Exam_Id,comb_CourseId,cert.softwareId,cert.course_id,course.course_name,module.software_name as module   FROM `Exam_Certificate` 

as cert inner join Exam_coursedetail as course on course.Course_id=cert.course_id inner join Exam_softwareDetails  as module on 

module.softwareId=cert.softwareId order by Exam_Id,course_id,type";

            DataTable softwareDt = new DataTable();
            softwareDt = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
            _softwaresDt = softwareDt;
            bool res = true;
            int i;
     
            string coursetype, courseName;
            courseName = "";
            coursetype = "";
            string[] softwares = new string[20];
            for (i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] dr = new DataRow[10];
                coursetype = dt.Rows[i]["courseType"].ToString();
                if (coursetype == "Diploma")
                {
                    coursetype = "1";
                    courseName = dt.Rows[i]["courseName"].ToString();
                    softwares = dt.Rows[i]["softwareNames"].ToString().Split(',');


                    for (int j = 0; j < softwares.Length; j++)
                    {
                        for (int k = 0; k < softwares.Length; k++)
                        {
                            if (j != k)
                                if (softwares[j] == softwares[k])
                                {
                                    CurrentStatus(softwares[j] + " dublicate software names on the softwareNames column of the row " + (i + 1));
                                    res = false;
                                    break;
                                }
                        }
                    }
                    if (res == true)
                        foreach (string sw in softwares)
                        {
                            dr = softwareDt.Select("course_name='" + courseName + "' and Exam_Id='" + coursetype + "' and module='" + sw + "'");
                            if (dr.Length == 0)
                            {
                                CurrentStatus(sw + " is does not exists on the database,Please check the softwareNames column on the row " + (i + 1));
                                res = false;
                                break;
                            }
                        }
                }
                else if (coursetype == "Certificate")
                {
                     coursetype = "2";
                     if (dt.Rows[i]["softwareNames"].ToString() != "")
                     {
                         CurrentStatus("Certificate course softwaresNames column should be blank,please check the the row " + (i + 1));
                         res = false;
                         break;
                     }

                }
               
                 
            }
            return res;
        }

        #region Writing Current Status Of The File Upload
        public void CurrentStatus(string curStatus)
        {
            System.IO.TextWriter textWriter = new System.IO.StreamWriter(notePadPath);
            textWriter.WriteLine(curStatus);
            textWriter.Close();
        }
        #endregion

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


        public void uploadStudentDetails()
        {
            bool res = false;
            string msg = "";
            string courseType="0";
            CurrentStatus("Starting...");
            DataTable dt=new DataTable();
            dt = ExecuteDataTable(connectionString);
            //Check the table name exists or not.
            res = isVallidTable(tableName, dt);
            
            //Load the data from excel.
            if(res)
            dt = ExecuteDataTable(connectionString, "Select * From [" + tableName + "$]");

            // Check the columns and order are correct format.
            if (res)
                res = isValidColumns("RegNo,Name,DOJ,invoiceno,centre,courseType,courseName,softwareNames",dt);

            if (res)
                res = isValidRegNos(dt);

            if (res)
                res = isValidName(dt);

            if (res)
                res = isValidDataformat(dt);

            if (res)
               res=isValidCentreNames(dt);

           if (res)
               res=isValidCourseType(dt);

           if (res)
               res = isValidCourseName(dt);

           if (res)
               res = isValidSoftwares(dt);


           

            MySqlCommand bulkcmd = null;
            MySqlConnection bulkConn = null;
            if(res)
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string studentName, studentRegNo, Course_diploma, Course_certificate, centreId, doj, invoiceno, dateIns, dateMod;
                    studentName = MVC1.SiteFunctions.databaseset(dr["Name"].ToString());
                    studentRegNo = MVC1.SiteFunctions.databaseset(dr["RegNo"].ToString());

                    Course_diploma = "";
                    Course_certificate = "";
                    if (dr["courseType"].ToString() == "Diploma")
                    {
                        Course_certificate = "0";
                        courseType="1";
                        Course_diploma = getDataValue(_courseDt, "Exam_id='1' and Course_name='" + dr["courseName"].ToString() + "'", "Course_id");
                    }
                    else if (dr["courseType"].ToString() == "Certificate")
                    {
                        Course_certificate = getDataValue(_courseDt, "Exam_id='2' and Course_name='" + dr["courseName"].ToString() + "'", "Course_id");
                         courseType="2";
                        Course_diploma="0";
                    }


                    centreId = getDataValue(_centreDt, "centreLocation='" + dr["centre"].ToString() + "'", "centreId");
                  
                    
                    DateTime datetime = new DateTime();
                    datetime = Convert.ToDateTime(dr["DOJ"].ToString(), culture);
                    doj = datetime.ToString("yyyy/MM/dd").ToString();
                    invoiceno=dr["invoiceno"].ToString();
                    string qry = "Insert into Exam_StudentDetails(studentName,studentRegNo,Course_diploma,Course_certificate,centreId,doj,invoiceno,dateIns,dateMod) values('" + studentName + "', '" + studentRegNo + "','" + Course_diploma + "', '" + Course_certificate + "','" + centreId + "','" + doj + "','" + invoiceno + "',curdate(),curdate());  Select LAST_INSERT_ID() as studentId";
                    int  studentId=MVC1.Mysqlconn_ctech.ExecuteMysqlScalar(qry);

                    string[] softwares = new string[20];
                    softwares = dr["softwareNames"].ToString().Split(',');
                    foreach (string sw in softwares)
                    {
                       string certificateId="0";
                       string softwareId="0";
                       
                       if (courseType=="1")
                       {
                         certificateId = getDataValue(_softwaresDt, "module='" + sw + "' and Exam_Id='" + courseType + "' and course_name='" + dr["courseName"].ToString() + "'", "Certificate_Id");
                         softwareId = getDataValue(_softwaresDt, "module='" + sw + "' and Exam_Id='" + courseType + "' and course_name='" + dr["courseName"].ToString() + "'", "softwareId");
                       }
                       else if (courseType == "2")
                       {
                           certificateId = Course_certificate;
                       }
                       qry = "Insert into  Exam_StudentCourseDetails(studentId,Certificate_Id,softwareId,status,dateIns,dateMod)values('" + studentId.ToString() + "','" + certificateId + "','" + softwareId + "','1',curdate(),curdate())";
                       MVC1.Mysqlconn_ctech.ExecuteMySqlCommand(qry);
                    }
                    CurrentStatus("Imported successfully...");
                }
                catch (Exception ex)
                {
          
                    HttpContext.Current.Response.Write(ex.Message.ToString());
                }
               
              
            }


        msg = ReadCurrentStatus();

        lblMsg.Text = msg;

            //HttpContext.Current.Response.Write(dt.Rows.Count);

        }
        string getDataValue(DataTable dt, string expression,string columnName)
        {
            string res = "";
            DataRow[] dr = new DataRow[20];
            dr = dt.Select(expression);
            if (dr.Length > 0)
            {
               res = dr[0][columnName].ToString();
            }
            return res;
        }

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


        #region Reading Current Status Of The File Upload
        public string ReadCurrentStatus()
        {
            System.IO.TextReader textReader = new System.IO.StreamReader(notePadPath);
            retResult = textReader.ReadLine();
            textReader.Close();
            return retResult;
        }
        #endregion



    }
    
}
