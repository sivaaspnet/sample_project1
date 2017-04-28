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
/// Note : Not Implemented 3 Tier Architecutre.
/// </summary>
namespace MVC1
{
    public class AdminBusinessLogic_ctech
    {
        #region Validating Whether The Admin User Is Valid Or Not
        public static int CheckAdminLogin(int centreId,string userName, string password)
            {
                string qry;
                int retId = 0;
                DataTable dt;

                qry = "Select loginId,ifNull(userType,'NON')as chkUserType From Exam_AdminLogin Where centreId=" + centreId + " AND userName='" + SiteFunctions.databaseset(userName) + "' and password='" + SiteFunctions.databaseset(password) + "' AND status=1";
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        retId =Convert.ToInt32(dt.Rows[0]["loginId"].ToString());
                        HttpContext.Current.Session["AdUserId"] = retId.ToString();
                        HttpContext.Current.Session["CentreId"] = centreId.ToString();
                        HttpContext.Current.Session["UserType"] = dt.Rows[0]["chkUserType"].ToString();
                    }
                    else
                    {
                        retId = 0;
                    }
                }
                catch(Exception ex)
                {
                    SiteFunctions.Log(ex);
                }
                return retId;
            }
        #endregion

        //--Static Sections
        #region Filling Location In Drop Down
        public static void FillLocation(DropDownList dpDown)
        {
            try
            {
                string qry;
                if (HttpContext.Current.Session["UserType"] != null && HttpContext.Current.Session["CentreId"]!=null)
                {
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());

                    if (userType == "MASTER")
                    {
                        qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>'' and status=1 Order By location ASC";
                        //qry += " UNION Select 0 as centreId,'Select' as location    ";
                    }
                    else
                    {
                        qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>''and status=1 And centreId=" + centreId + " Order By location ASC ";
                        //qry += " UNION Select 0 as centreId,'Select' as location    ";
                    }
                }
                else
                {
                    qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>'' and status=1 Order By location ASC";
                    //qry += " UNION Select 0 as centreId,'Select' as location    ";
                }

                FillDataControls.FillDropDownList(dpDown, qry, "location", "centreId");
                dpDown.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Filling Location In Drop Down In Admin
        public static void FillLocationLogin(DropDownList dpDown)
        {
            try
            {
                string qry;

                qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where status=1 Order By location ASC";
                //qry += " UNION Select 0 as centreId,'Select' as location    ";

                FillDataControls.FillDropDownList(dpDown, qry, "location", "centreId");


                dpDown.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Filling Course Details In Dropdown
        public static void FillCourseDetails(DropDownList dpDown)
        {
            try
            {
                string qry;
                qry = "Select courseId,REPLACE(courseName,'~','''')as course From Exam_CourseDetails Order By course ASC ";//Where status=1
                //qry += " UNION Select 0 as courseId,'All' as course  ";
                FillDataControls.FillDropDownList(dpDown, qry, "course", "courseId");
                dpDown.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Filling SubModule Details In DropDown
        public static void FillSubModuleDetails(DropDownList dpDown)
        {
            try
            {
                string qry;
                qry = "Select SoftwareId,REPLACE(software_name,'~','''')as software_name From Exam_softwareDetails where softstatus=1 Order By software_name ASC ";//and status=1 
                //qry += " UNION Select 0 as subModuleId,'Select' as subModuleName  ";
                FillDataControls.FillDropDownList(dpDown, qry, "software_name", "SoftwareId");

                dpDown.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        //--Search Section
        #region Filling Course Details In Dropdown
        public static void SearchFillCourseDetails(DropDownList dpDown)
        {
            try
            {
                string qry;
                qry = "Select SoftwareId,REPLACE(software_name,'~','''')as software_name From Exam_softwareDetails Order By software_name ASC ";//Where status=1
                //qry += " UNION Select 0 as courseId,'All' as course  ";
                FillDataControls.FillDropDownList(dpDown, qry, "software_name", "SoftwareId");
                dpDown.Items.Insert(0, new ListItem("All", "0"));

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Filling SubModule Details In DropDown
        public static void SearchFillSubModuleDetails(DropDownList dpDown)
        {
            try
            {
                string qry;
                qry = "Select softwareId,REPLACE(software_name,'~','''')as software_name From Exam_softwareDetails where softstatus=1 Order By software_name ASC ";//and status=1 
                //qry += " UNION Select 0 as subModuleId,'All' as subModuleName  ";
                FillDataControls.FillDropDownList(dpDown, qry, "software_name", "softwareId");
                dpDown.Items.Insert(0, new ListItem("All", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Filling Location In Drop Down
        public static void SearchFillLocation(DropDownList dpDown)
        {
            try
            {
                string qry;
                if (HttpContext.Current.Session["UserType"] != null && HttpContext.Current.Session["CentreId"] != null)
                {
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());

                    if (userType == "MASTER")
                    {
                        qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>'' and status=1 Order By location ASC";
                        //qry += " UNION Select 0 as centreId,'Select' as location    ";
                    }
                    else
                    {
                        qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>'' and status=1 And centreId=" + centreId + " Order By location ASC ";
                        //qry += " UNION Select 0 as centreId,'Select' as location    ";
                    }
                }
                else
                {
                    qry = "Select centreId,REPLACE(centreLocation,'~','''')as location From Exam_CentreDetails Where centre_code<>'' and status=1 Order By location ASC";
                    //qry += " UNION Select 0 as centreId,'Select' as location    ";
                }

                FillDataControls.FillDropDownList(dpDown, qry, "location", "centreId");
                dpDown.Items.Insert(0, new ListItem("All", "0"));
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

    }
}
