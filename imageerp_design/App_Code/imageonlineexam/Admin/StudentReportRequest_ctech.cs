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
/// Summary description for StudentReportRequest_ctech
/// </summary>
/// 
namespace MVC1
{
    public class StudentReportRequest_ctech
    {


        private string _qry;
        private int _retInt;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;


        public StudentReportRequest_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        #region Getting Student Report
        public void GetStudentReport(GridView grdStudentReport, Label lblNoOfRecords, DropDownList ddlLocation, TextBox txtFromDate, TextBox txtToDate, TextBox txtSearch, DropDownList ddlTestStatus, Label lblMsg, int writeStatus, ListBox ddlcourse)
        {
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            MySqlCommand Comm = new MySqlCommand();

            string schText = "", fromText = "", toText = "";
            if (txtSearch.Text.Trim() == "Name/RegNo")
            {
                schText = "";
            }
            else
            {
                schText = txtSearch.Text.Trim();
            }
            fromText = SiteFunctions.databaseset(txtFromDate.Text.Trim());
            toText = SiteFunctions.databaseset(txtToDate.Text.Trim());


            string chkCentre = "", chkDateRange = "";
            if (HttpContext.Current.Session["UserType"] != null)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());
                if (userType != "MASTER")
                {
                    chkCentre = " And CE.centreId=" + centreId + " ";

                    grdStudentReport.Columns[9].Visible = false;
                }
            }
            string course_qry = " And ec.Course_id in(";
            int items_count = 0;
            foreach (ListItem item in ddlcourse.Items)
            {
                if (item.Selected)
                {
                    if (items_count == 0)
                    {
                        course_qry += item.Value;

                    }
                    else
                        course_qry += "," + item.Value;
                    items_count++;
                }

            }
            course_qry += ")";
            if (fromText != "" && toText != "")
            {
         
                chkDateRange += " AND R.dateIns between STR_TO_DATE('" + fromText + "', '%m/%d/%Y')   and STR_TO_DATE('" + toText + "', '%m/%d/%Y') ";
            }
            _qry = "SELECT R.Software_Id,R.Certificate_Id,S.studentId,Replace(S.studentName,'~','''')as studentName,Replace(CE.centreLocation,'~','''')as centreName,";
            _qry += " R.totalQuestion,R.resultId,R.correctAnswer,R.wrongAnswer,R.mark,concat_ws('/',convert(R.mark,char),'100')as totalMark,R.dateIns,";
            _qry += " CASE When R.mark>=40 Then 'Pass' Else 'Fail' End as testStatus, CASE when R.Certificate_Id=0 Then Soft.software_name else (select Course_name from Exam_coursedetail where Course_id=R.Certificate_Id) End as software ";
            _qry += " ,DATE_FORMAT(IFNULL(doj,''), '%d-%m-%Y' ) AS doj,IFNULL(invoiceno,'') AS  invoiceno,0 as noOfAppearance FROM Exam_StudentDetails S inner join Exam_CentreDetails CE on CE.centreId=S.centreId  ";

      
            if (ddlLocation.SelectedValue != "0")
            {
                _qry += " And S.centreId=" + ddlLocation.SelectedValue + " ";
            }
            _qry += " inner join Exam_coursedetail ec on (ec.Course_id=S.Course_diploma or ec.Course_id=S.Course_certificate) ";
            _qry += " INNER JOIN Exam_Results R on R.studentId=S.StudentId Left JOIN Exam_softwareDetails Soft on Soft.SoftwareId=R.Software_Id  Where ";
            _qry += "  (S.studentName Like '%" + schText + "%' OR S.studentRegNo Like '%" + schText + "%') " + chkDateRange + " ";
            _qry += " And R.reqStatus=1";
            _qry += " And ec.Erp_courseid<>'' and ec.Course_name like '%ctech%'";

            if (items_count != 0)
                _qry += course_qry;
            if (ddlTestStatus.SelectedValue != "0")
            {
                if (ddlTestStatus.SelectedValue == "P")
                {
                    _qry += " And R.mark>=40 ";
                }
                else
                {
                    _qry += " And R.mark<=39 ";
                }

            }

            _qry += " order by resultId desc";
            //if (chkDate.Checked == true)
            //{
            //    string fDate, tDate, fromDate, toDate;
            //    fDate = SiteFunctions.databaseset(TxtFdate.Text.Trim());
            //    tDate = SiteFunctions.databaseset(TxtTdate.Text.Trim());

            //    IFormatProvider provider1 = new System.Globalization.CultureInfo("en-CA", true);
            //    String datetime1 = fDate;
            //    DateTime dt2 = DateTime.Parse(datetime1, provider1, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //    fromDate = dt2.Date.ToString();

            //    IFormatProvider provider2 = new System.Globalization.CultureInfo("en-CA", true);
            //    String datetime = tDate;
            //    DateTime dt1 = DateTime.Parse(datetime, provider2, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //    toDate = dt1.Date.ToString();

            //    _qry += " AND R.dateIns BETWEEN '" + DateTime.Parse(fromDate).ToString("yyyy/MM/dd") + "'  AND '" + DateTime.Parse(toDate).ToString("yyyy/MM/dd") + "' ";
            //}

            //if (ddlOrder.SelectedValue != "" && ddlOrder.SelectedValue != "0")
            //{
            //    if (ddlOrder.SelectedValue == "E")
            //    {
            //        _qry += " Order By R.dateIns Desc ";
            //    }
            //    else if (ddlOrder.SelectedValue == "M")
            //    {
            //        _qry += " Order By R.mark Desc ";
            //    }
            //    else if (ddlOrder.SelectedValue == "P")
            //    {
            //        _qry += " Order By R.mark Desc ";
            //    }
            //    else if (ddlOrder.SelectedValue == "F")
            //    {
            //        _qry += " Order By R.mark ASC ";
            //    }
            //}
            //else
            //{
            //    _qry += " Order By R.resultId Desc ";
            //}



            // HttpContext.Current.Response.Write(_qry);
            // HttpContext.Current.Response.End();

            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;

            try
            {
                DataTable dt;
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                dt = showNoAppearance(dt);

                grdStudentReport.DataSource = dt;
                grdStudentReport.DataBind();

                lblNoOfRecords.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn);
            }
        }
        #endregion

        #region Delete Student Report
        public int DeleteResult(int reportId, Label lblMsg, string delId)
        {
            _retInt = 0;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            MySqlCommand Comm = new MySqlCommand();
            _qry = "Update Exam_Results Set delStatus=1,delId=@delId Where resultId=@reportId";


            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;

            Comm.Parameters.Add("@reportId", MySqlDbType.Int32).Value = reportId;
            Comm.Parameters.Add("@delId", MySqlDbType.VarChar, 25).Value = delId;

            try
            {
                _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(Comm);
                if (_retInt > 0)
                {
                    _qry = "select certificate_Id,Software_Id from Exam_Results WHERE resultId=" + reportId + "";
                    DataTable dt23 = new DataTable();
                    dt23 = Mysqlconn_ctech.ExecuteMysqlDataTable(_qry);

                    if (dt23.Rows.Count > 0)
                    {
                        if (dt23.Rows[0]["certificate_Id"].ToString() != "0")
                        {
                            _qry = "Update Exam_StudentCourseDetails Set status=1,delId='" + delId + "' Where ";
                            _qry += "  studentId=(select studentId FROM Exam_Results WHERE resultId=" + reportId + ") ";
                            _qry += " And certificate_Id=(select case when Certificate_Id=0 then software_id else Certificate_Id End as cou_Id FROM Exam_Results WHERE resultId=" + reportId + ") ";


                            Mysqlconn_ctech.ExecuteMySqlCommand(_qry);
                        }
                        if (dt23.Rows[0]["Software_Id"].ToString() != "0")
                        {
                            _qry = "Update Exam_StudentCourseDetails Set status=1,delId='" + delId + "' Where ";
                            _qry += "  studentId=(select studentId FROM Exam_Results WHERE resultId=" + reportId + ") ";
                            _qry += " And softwareId=(select case when Certificate_Id=0 then software_id else Certificate_Id End as cou_Id FROM Exam_Results WHERE resultId=" + reportId + ") ";

                            Mysqlconn_ctech.ExecuteMySqlCommand(_qry);

                        }

                    }


                    _qry = "Delete From Exam_Results Where resultId=@reportId";

                    MySqlCommand Comm12 = new MySqlCommand();
                    Comm12.CommandText = _qry;
                    Comm12.Connection = mySqlConn;

                    Comm12.Parameters.Add("@reportId", MySqlDbType.Int32).Value = reportId;
                    Comm12.Parameters.Add("@delId", MySqlDbType.VarChar, 25).Value = delId;
                    _retInt = Mysqlconn_ctech.ExecuteMySqlCommand(Comm12);

                    lblMsg.Text = "Report Deleted Successfully";
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

        

        #region ""
        public DataTable showNoAppearance(DataTable filledDt)
        {
            string qry = "select studentId,Certificate_Id,Software_Id,appearance from exam_appearancedetails";
            DataTable dt = new DataTable();
            dt = MVC1.Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
            int cnt;
            cnt = 0;
            foreach (DataRow dr in filledDt.Rows)
            {
                filledDt.Rows[cnt]["noOfAppearance"] = getScalarValue(dt, "studentId='" + dr["studentId"] + "' and Certificate_Id='" + dr["Certificate_Id"] + "' and Software_Id='" + dr["Software_Id"] + "'");
                cnt += 1;

            }
            return filledDt;
        }
        #endregion

        string getScalarValue(DataTable dt, string exp)
        {
            string res = "0";
            DataRow[] dr = new DataRow[10];
            if (dt.Rows.Count > 0)
            {
                dr = dt.Select(exp);
                if (dr.Length > 0)
                {
                    res = dr[0]["appearance"].ToString();
                }
            }
            return res;
        }
        #region Getting student report for excel
        public DataTable GetStudentReport_excel(GridView grdStudentReport, Label lblNoOfRecords, DropDownList ddlLocation, TextBox txtFromDate, TextBox txtToDate, TextBox txtSearch, DropDownList ddlTestStatus, Label lblMsg, int writeStatus, ListBox ddlcourse)
        {
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            MySqlCommand Comm = new MySqlCommand();

            string schText = "", fromText = "", toText = "";
            if (txtSearch.Text.Trim() == "Name/RegNo")
            {
                schText = "";
            }
            else
            {
                schText = txtSearch.Text.Trim();
            }
            fromText = SiteFunctions.databaseset(txtFromDate.Text.Trim());
            toText = SiteFunctions.databaseset(txtToDate.Text.Trim());


            string chkCentre = "", chkDateRange = "";
            if (HttpContext.Current.Session["UserType"] != null)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());
                if (userType != "MASTER")
                {
                    chkCentre = " And CE.centreId=" + centreId + " ";

                    grdStudentReport.Columns[9].Visible = false;
                }
            }
            string course_qry = " And ec.Course_id in(";
            int items_count = 0;
            foreach (ListItem item in ddlcourse.Items)
            {
                if (item.Selected)
                {
                    if (items_count == 0)
                    {
                        course_qry += item.Value;

                    }
                    else
                        course_qry += "," + item.Value;
                    items_count++;
                }

            }
            course_qry += ")";
            if (fromText != "" && toText != "")
            {
             
                chkDateRange += " AND R.dateIns between STR_TO_DATE('" + fromText + "', '%m/%d/%Y')   and STR_TO_DATE('" + toText + "', '%m/%d/%Y') ";
            }

            _qry = "SELECT R.Software_Id,R.Certificate_Id,S.studentId,Replace(S.studentName,'~','''')as studentName,Replace(CE.centreLocation,'~','''')as centreName,";
            _qry += " R.totalQuestion,R.resultId,R.correctAnswer,R.wrongAnswer,R.mark,concat_ws('/',convert(R.mark,char),'100')as totalMark,R.dateIns,";
            _qry += " CASE When R.mark>=40 Then 'Pass' Else 'Fail' End as testStatus, CASE when R.Certificate_Id=0 Then Soft.software_name else (select Course_name from Exam_coursedetail where Course_id=R.Certificate_Id) End as software ";
            _qry += " ,DATE_FORMAT(IFNULL(doj,''), '%d-%m-%Y' ) AS doj,IFNULL(invoiceno,'') AS  invoiceno,0 as noOfAppearance FROM Exam_StudentDetails S inner join Exam_CentreDetails CE on CE.centreId=S.centreId  ";


            if (ddlLocation.SelectedValue != "0")
            {
                _qry += " And S.centreId=" + ddlLocation.SelectedValue + " ";
            }
            _qry += " inner join Exam_coursedetail ec on (ec.Course_id=S.Course_diploma or ec.Course_id=S.Course_certificate) ";
            _qry += " INNER JOIN Exam_Results R on R.studentId=S.StudentId Left JOIN Exam_softwareDetails Soft on Soft.SoftwareId=R.Software_Id  Where ";
            _qry += "  (S.studentName Like '%" + schText + "%' OR S.studentRegNo Like '%" + schText + "%') " + chkDateRange + " ";
            _qry += " And R.reqStatus=1";
            _qry += " And ec.Erp_courseid<>'' and ec.Course_name like '%ctech%'";
            if (items_count != 0)
                _qry += course_qry;
            if (ddlTestStatus.SelectedValue != "0")
            {
                if (ddlTestStatus.SelectedValue == "P")
                {
                    _qry += " And R.mark>=40 ";
                }
                else
                {
                    _qry += " And R.mark<=39 ";
                }

            }

            _qry += " order by resultId desc";

            Comm.CommandText = _qry;
            Comm.Connection = mySqlConn;
            DataTable dt = new DataTable();

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
                dt = showNoAppearance(dt);
                grdStudentReport.DataSource = dt;
                grdStudentReport.DataBind();
                lblNoOfRecords.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn);
            }
            return dt;
        }
        #endregion



    }

}