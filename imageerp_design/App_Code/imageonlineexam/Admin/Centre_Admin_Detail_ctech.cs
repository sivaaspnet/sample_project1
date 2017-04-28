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
/// Summary description for Centre_Admin_Detail
/// </summary>

namespace MVC1
{
    public class Centre_Admin_Detail_ctech
    {
        private string qry;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        #region Declaring Predefined Values
        public Centre_Admin_Detail_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }
        #endregion

        #region Getting Centre Details
        public void GetCentreDetails(GridView grdCentreDetails)
        {
            try
            {
                int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());

                DataTable dt;
                qry = " Select C.centreId,REPLACE(C.centreLocation,'~','''')as location,REPLACE(C.centrePassword,'~','''')as centrePassword,C.status, ";
                qry += " Case ifNull(C.status,1) When 1 Then 'Enabled' Else 'Disabled' End as dispStatus ";
                qry += " From Exam_CentreDetails C Where C.centreId=" + centreId + "  ";
                qry += " Order By C.dateMod desc ";
                dt = FillDataControls.FillGridView(qry, grdCentreDetails);
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Fill UserDetails In The GridView
        public void GetAdminUserDetails(GridView grdUserDetails)
        {
            try
            {
                DataTable dt;
                int userId = Convert.ToInt32(HttpContext.Current.Session["AdUserId"].ToString());

                qry = " SELECT L.loginId,REPLACE(L.userName,'~','''')as userName,REPLACE(L.password,'~','''')as adminPassword,L.centreId,REPLACE(C.centreLocation,'~','''')as location,";
                qry += "Case IFNULL(L.status,1) When 1 THEN 'Enabled' Else 'Disabled' End as dispStatus";
                qry += " From Exam_AdminLogin L Inner JOIN ";
                qry += " Exam_CentreDetails C ON C.centreId=L.centreId And C.status=1 And L.loginId=" + userId + " ";
                qry += " Order By L.dateMod Desc";
                //HttpContext.Current.Response.Write(qry);

                dt = FillDataControls.FillGridView(qry, grdUserDetails);
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion
    }
}
